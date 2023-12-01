using CefSharp.DevTools.IO;
using Downloader;
using FAckupWizard.FAClient;
using Microsoft.VisualBasic.ApplicationServices;

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

        private int UsersProcessed = 0;
        private int DownloadsProcessed = 0;
        private int DownloadsTotal = 0;

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

        private void AppendLog(string text)
        {
            logView.Invoke((MethodInvoker)delegate
            {
                logView.AppendText(text + "\r\n");
            });
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
                if(DownloadsTotal != 0)
                    prgFiles.Value = DownloadsProcessed * 100 / DownloadsTotal;
                else
                    prgFiles.Value = 0;
            });
        }

        private void UpdateProgressUser()
        {
            prgUsers.Invoke((MethodInvoker)delegate
            {
                if (galleryDownloaders.Count != 0)
                    prgUsers.Value = UsersProcessed * 100 / galleryDownloaders.Count ;
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

            while (galleryDownloaders.Count > 0)
            {
                lock (_lock)
                {
                    Active = galleryDownloaders.Dequeue();
                }
                UpdateState("Downloading " + Active.User + "'s gallery");
                AppendLog("Parsing " + Active.User + "'s gallery");
                DownloadsProcessed = 0;
                UpdateProgressGallery();
                DownloadsTotal = await Active.GetGalleryItems();
                await Active.Download();
            }

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
            DownloadsProcessed++;
            UpdateProgressGallery();
        }

        private void Gdl_OnItemDownloadStarted(GalleryItem item)
        {
            AppendLog("Downloading: " + item.ViewURL);
        }

        private void Gdl_OnGalleryDownloadStarted(string user)
        {
            AppendLog(user + " gallery doanload started");
        }

        private void Gdl_OnGalleryDownloadComplete(string user)
        {
            AppendLog(user + " gallery doanloaded");
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
