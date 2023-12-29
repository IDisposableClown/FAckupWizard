using Downloader;
using FAckupWizard.FAClient;

namespace FAckupWizard
{
    internal class GalleryDownloader: IDisposable
    {
        public delegate void ItemDownloadComplete(GalleryItem item);
        public event ItemDownloadComplete? OnItemDownloadComplete;

        public delegate void ItemDownloadStarted(GalleryItem item);
        public event ItemDownloadStarted? OnItemDownloadStarted;

        public delegate void ItemDownloadFailed(GalleryItem item);
        public event ItemDownloadFailed? OnItemDownloadFailed;

        public delegate void GalleryDownloadComplete(string user);
        public event GalleryDownloadComplete? OnGalleryDownloadComplete;
        
        public delegate void GalleryDownloadStarted(string user);
        public event GalleryDownloadStarted? OnGalleryDownloadStarted;

        public delegate void SubmissionInfoReceived(GalleryItem item);
        public event SubmissionInfoReceived? OnSubmissionInfoReceived;

        public string User { get; private set; }

        private GalleryDownloaderConfig cfg;
        private IFAClient Client;

        private List<GalleryItem> UserGallery;
        private Queue<DownloadItem<GalleryItem>> DLQueue;
        private Dictionary<DownloadService, DownloadItem<GalleryItem>> ActiveDowloads;
        private DownloadConfiguration DLCfg;

        private string UserOutPath;
        private bool Running;

        private DownloadHistory DownloadedItems;

        private object _lock = new object();

        public GalleryDownloader(string user, IFAClient client, GalleryDownloaderConfig config)
        {
            Running = false;
            cfg = config;
            User = user;
            UserOutPath = Path.Combine(cfg.OutPath, user);
            DLQueue = new Queue<DownloadItem<GalleryItem>>();
            UserGallery = new List<GalleryItem>();
            ActiveDowloads = new Dictionary<DownloadService, DownloadItem<GalleryItem>>();
            DLCfg = new DownloadConfiguration();
            Client = client;
            DownloadedItems = new DownloadHistory(UserOutPath);
            DownloadedItems.Load();

            if(cfg.Proxy != null)
                DLCfg.RequestConfiguration.Proxy = cfg.Proxy;
        }

        private async Task EnqueueGalleryItems()
        {
            foreach (var item in UserGallery)
            {
                if (!Running)
                {
                    return;
                }

                if (!DownloadedItems.Contains(item.SubmissionID))
                {
                    var details = await Client.GetSubmissionInfoAsync(item.ViewURL).ConfigureAwait(false);
                    string savePath = Path.Combine(
                        UserOutPath,
                        item.GallerySection.ToString(),
                        Uri.UnescapeDataString(details.DownloadURL.Split('/').Last()));

                    if (!string.IsNullOrEmpty(details.DownloadURL))
                    {
                        DLQueue.Enqueue(new DownloadItem<GalleryItem>(details.DownloadURL, savePath, item));
                        OnSubmissionInfoReceived?.Invoke(item);
                    }
                }
            }
        }

        public async Task<int> GetGalleryItems()
        {
            if (Running)
                return 0;

            Running = true;

            if (cfg.GallerySesctions.HasFlag(EGallerySection.Gallery) && Running)
            {
                var items = await Client.GetUserGalleryAsync(User, EGallerySection.Gallery).ConfigureAwait(false);
                UserGallery.AddRange(items.Where(x => 
                    cfg.SubmissionTypes.HasFlag(x.SubmissionType) 
                    && cfg.SubmissionRatings.HasFlag(x.Rating)));
            }
            if (cfg.GallerySesctions.HasFlag(EGallerySection.Scraps) && Running)
            {
                var items = await Client.GetUserGalleryAsync(User, EGallerySection.Scraps).ConfigureAwait(false);
                UserGallery.AddRange(items.Where(x =>
                    cfg.SubmissionTypes.HasFlag(x.SubmissionType)
                    && cfg.SubmissionRatings.HasFlag(x.Rating)));
            }
            if (cfg.GallerySesctions.HasFlag(EGallerySection.Favorites) && Running)
            {
                var items = await Client.GetUserGalleryAsync(User, EGallerySection.Favorites).ConfigureAwait(false);
                UserGallery.AddRange(items.Where(x =>
                    cfg.SubmissionTypes.HasFlag(x.SubmissionType)
                    && cfg.SubmissionRatings.HasFlag(x.Rating)));
            }

            await EnqueueGalleryItems();

            Running = false;

            return DLQueue.Count;
        }

        private bool PrepareOut()
        {
            try
            {
                Directory.CreateDirectory(UserOutPath);
                if (cfg.GallerySesctions.HasFlag(EGallerySection.Gallery))
                {
                    Directory.CreateDirectory(Path.Combine(UserOutPath, EGallerySection.Gallery.ToString()));
                }
                if (cfg.GallerySesctions.HasFlag(EGallerySection.Scraps))
                {
                    Directory.CreateDirectory(Path.Combine(UserOutPath, EGallerySection.Scraps.ToString()));
                }
                if (cfg.GallerySesctions.HasFlag(EGallerySection.Favorites))
                {
                    Directory.CreateDirectory(Path.Combine(UserOutPath, EGallerySection.Favorites.ToString()));
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void DownloadNext()
        {
            if (DLQueue.Count > 0 && Running)
            {
                lock (_lock)
                {
                    var item = DLQueue.Dequeue();
                    DownloadService dls = new DownloadService(DLCfg);
                    dls.DownloadFileCompleted += Dl_DownloadFileCompleted;
                    dls.DownloadStarted += Dl_DownloadStarted;
                    dls.DownloadFileTaskAsync(item.Url, item.DownloadPath);
                    ActiveDowloads[dls] = item;
                }
            }
            else
            {
                if (ActiveDowloads.Count == 0)
                    Running = false;
            }
        }

        private void Dl_DownloadStarted(object? sender, DownloadStartedEventArgs e)
        {
            if(sender != null)
                OnItemDownloadStarted?.Invoke(ActiveDowloads[(DownloadService)sender].DataObject);
        }

        private void Dl_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (sender != null)
            {
                lock (_lock)
                {

                    var item = ActiveDowloads[(DownloadService)sender];
                    DownloadPackage? package = e.UserState as DownloadPackage;
                    if (package != null && package.Status == DownloadStatus.Completed)
                    {
                        OnItemDownloadComplete?.Invoke(item.DataObject);
                        DownloadedItems.Append(item.Url, item.DownloadPath, item.DataObject.SubmissionID);
                    }
                    else
                    {
                        OnItemDownloadFailed?.Invoke(item.DataObject);
                    }
                    ActiveDowloads.Remove((DownloadService)sender);
                }
            }

            if (ActiveDowloads.Count < cfg.ParallelDownloadsCount)
            {
                DownloadNext();
            }
        }

        public void Stop()
        {
            lock(_lock)
            {
                DLQueue.Clear();
            }
            Running = false;

            foreach (var item in ActiveDowloads)
            {
                item.Key.CancelAsync();
            }
        }

        public async Task Download()
        {
            if (Running)
                return;

            Running = true;

            OnGalleryDownloadStarted?.Invoke(User);

            if (DLQueue.Count > 0)
            {
                if (PrepareOut())
                {
                    for (int i = 0; i < cfg.ParallelDownloadsCount; ++i)
                    {
                        DownloadNext();
                    }

                    while (Running)
                    {
                        await Task.Delay(1000);
                    }
                }
            }

            OnGalleryDownloadComplete?.Invoke(User);
        }

        public void Dispose()
        {
            if(Running)
                Running = false;
        }
    }
}
