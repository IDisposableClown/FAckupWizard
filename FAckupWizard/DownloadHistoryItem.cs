namespace FAckupWizard
{
    internal class DownloadHistoryItem
    {
        public ulong SubmissionID { get; set; }
        public string SourceURL { get; set; } = string.Empty;
        public string DestPath { get; set; } = string.Empty;

        public DownloadHistoryItem(ulong subid, string url, string path ) 
        {
            SubmissionID = subid;
            SourceURL = url;
            DestPath = path;
        }

    }
}
