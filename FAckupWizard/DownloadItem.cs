namespace FAckupWizard
{
    internal class DownloadItem<T>
    {
        public string Url { get; set; } = string.Empty;
        public string DownloadPath { get; set; } = string.Empty;    
        public T DataObject { get; set; }

        public DownloadItem(string url, string downloadPath, T obj)
        {
            Url = url;
            DownloadPath = downloadPath;
            DataObject = obj;
        }
    }
}
