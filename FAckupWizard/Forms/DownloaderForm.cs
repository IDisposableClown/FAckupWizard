using FAckupWizard.FAClient;

namespace FAckupWizard.Forms
{
    public partial class DownloaderForm : Form
    {
        private GalleryDownloaderConfig ctx;
        private GalleryDownloaderConfig ctxWatched;
        private IFAClient faclient;
        private List<string> usersList;
        private bool downloadWatched;
        private GalleryDownloader Active;
        private Queue<GalleryDownloader> galleryDownloaders = new Queue<GalleryDownloader>();

        private object _lock = new object();
        private object _prg = new object();
        private object _writeLock = new object();

        private int UsersProcessed = 0;
        private int UsersTotal = 0;
        private int UserDownloadsProcessed = 0;
        private int UserDownloadsTotal = 0;
        private int DownloadsTotal = 0;
        private int DownloadsActual = 0;

        private List<string> UsersSkipped = new List<string>();
        private List<string> EmptySubsUsers = new List<string>();

        public DialogResult Result { get; private set; }

        public DownloaderForm(List<string> users, bool downWatched, IFAClient client, GalleryDownloaderConfig cfg)
        {
            ctx = cfg;
            faclient = client;
            usersList = users;
            downloadWatched = downWatched;

            ctxWatched = new GalleryDownloaderConfig();
            ctxWatched.ParallelDownloadsCount = cfg.ParallelDownloadsCount;
            ctxWatched.OutPath = cfg.OutPath;
            ctxWatched.SubmissionRatings = cfg.SubmissionRatings;
            ctxWatched.SubmissionTypes = cfg.SubmissionTypes;
            ctxWatched.GallerySesctions = cfg.GallerySesctions ^ EGallerySection.Favorites;
            ctxWatched.Proxy = cfg.Proxy;

            InitializeComponent();
        }

        private void QueDownloadSingle(string user, GalleryDownloaderConfig dlcfg)
        {
            GalleryDownloader gdl = new GalleryDownloader(user, faclient, dlcfg);
            gdl.OnGalleryDownloadComplete += Gdl_OnGalleryDownloadComplete;
            gdl.OnGalleryDownloadStarted += Gdl_OnGalleryDownloadStarted;
            gdl.OnItemDownloadStarted += Gdl_OnItemDownloadStarted;
            gdl.OnItemDownloadComplete += Gdl_OnItemDownloadComplete;
            gdl.OnItemDownloadFailed += Gdl_OnItemDownloadFailed;
            gdl.OnSubmissionInfoReceived += Gdl_OnSubmissionInfoReceived;
            galleryDownloaders.Enqueue(gdl);
        }

        private void AppendLog(string text, bool preform = false)
        {
            logView.Invoke((MethodInvoker)delegate
            {
                logView.AppendText(text + "\r\n");
            });

            lock(_writeLock)
            {
                try
                {
                    using (TextWriter writer = File.AppendText(Path.Combine(ctx.OutPath, "download_log.log")))
                    {
                        if (!preform)
                        {
                            writer.WriteLine(string.Format("[{1:u}] {0}", text, DateTime.Now));
                        }
                        else
                        {
                            writer.WriteLine(text);
                        }
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void LogSummary()
        {
            AppendLog("====================================");

            AppendLog("Users skipped: " + string.Join(", ", UsersSkipped));
            AppendLog("Users with no submissions that met download criteria or empty galleries: " + string.Join(", ", EmptySubsUsers));
            AppendLog("Total users parsed: " + UsersTotal);
            AppendLog(string.Format("Downloaded {0} of {1} selected submissions", DownloadsActual, DownloadsTotal));

            AppendLog("", true);
        }

        private void UpdateState(string text)
        {
            labelUser.Invoke((MethodInvoker)delegate
            {
                labelUser.Text = text;
            });
        }

        private void UpdateProgressGallery()
        {
            prgFiles.Invoke((MethodInvoker)delegate
            {
                if(UserDownloadsTotal != 0)
                    prgFiles.Value = UserDownloadsProcessed * 100 / UserDownloadsTotal;
                else
                    prgFiles.Value = 0;
            });
        }

        private void UpdateProgressUser()
        {
            prgUsers.Invoke((MethodInvoker)delegate
            {
                if (UsersTotal != 0)
                    prgUsers.Value = UsersProcessed * 100 / UsersTotal;
            });
        }

        private void Unlock()
        {
            btnCacnel.Invoke((MethodInvoker)delegate
            {
                btnCacnel.Visible = false;
                btnClose.Visible = true;
            });
        }

        private async Task DownloadAll()
        {
            foreach (var user in usersList)
            {
                if (!galleryDownloaders.Where(x => x.User == user).Any())
                {
                    QueDownloadSingle(user, ctx);
                }

                if (downloadWatched)
                {
                    var watched = await faclient.GetWatchedUsers(user, 1).ConfigureAwait(false);
                    foreach (var item in watched)
                    {
                        if (!galleryDownloaders.Where(x => x.User == item).Any())
                        {
                            QueDownloadSingle(item, ctxWatched);
                        }
                    }
                }
            }

            UsersTotal = galleryDownloaders.Count;

            while (galleryDownloaders.Count > 0)
            {
                lock (_lock)
                {
                    Active = galleryDownloaders.Dequeue();
                }

                UpdateState("Downloading " + Active.User + "'s gallery");
                AppendLog("Parsing " + Active.User + "'s gallery");
                UserDownloadsProcessed = 0;
                UpdateProgressGallery();
                UserDownloadsTotal = await Active.GetGalleryItems();

                if(Active.SelectedSubsCount == 0)
                {
                    AppendLog(Active.User + "'s gallery is empty or no submissions that met download criteria");
                    EmptySubsUsers.Add(Active.User);
                }

                if(UserDownloadsTotal == 0)
                {
                    AppendLog("Nothing to download");
                    UsersSkipped.Add(Active.User);
                    UsersProcessed++;
                    UpdateProgressUser();
                }
                else
                {
                    AppendLog("Submission to download count: " + UserDownloadsTotal);
                    DownloadsTotal += UserDownloadsTotal;
                    await Active.Download();
                }
            }

            LogSummary();
            Unlock();
        }

        private void Gdl_OnSubmissionInfoReceived(GalleryItem item)
        {
            AppendLog("Got submission info for subid " + item.SubmissionID);
        }

        private void Gdl_OnItemDownloadFailed(GalleryItem item)
        {
            AppendLog("Download failed: " + item.ViewURL);
        }

        private void Gdl_OnItemDownloadComplete(GalleryItem item)
        {
            AppendLog("Downloaded: " + item.ViewURL);
            UserDownloadsProcessed++;
            DownloadsActual++;
            UpdateProgressGallery();
        }

        private void Gdl_OnItemDownloadStarted(GalleryItem item)
        {
            AppendLog("Downloading: " + item.ViewURL);
        }

        private void Gdl_OnGalleryDownloadStarted(string user)
        {
            AppendLog(user + " gallery download started");
        }

        private void Gdl_OnGalleryDownloadComplete(string user)
        {
            AppendLog(user + " gallery downloaded");
            UsersProcessed++;
            UpdateProgressUser();
        }

        private void btnCacnel_Click(object sender, EventArgs e)
        {
            btnCacnel.Enabled = false;
            Result = DialogResult.Cancel;
            lock (_lock)
            {
                galleryDownloaders.Clear();
            }
            Active.Stop();
            AppendLog("Cancelled!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Result = DialogResult.OK;
            Close();
        }

        private void DownloaderForm_Shown(object sender, EventArgs e)
        {
            DownloadAll();
        }
    }
}
