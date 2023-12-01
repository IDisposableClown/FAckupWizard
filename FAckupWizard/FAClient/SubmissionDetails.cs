namespace FAckupWizard.FAClient
{
    public class SubmissionDetails
    {
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; } = DateTime.MinValue;
        public string DownloadURL { get; set; } = string.Empty;
        public uint ViewsCount { get; set; } = 0;
        public uint FavsCount { get; set; } = 0;
        public uint CommentsCount { get; set; } = 0;

        public SubmissionDetails() { }  

    }
}
