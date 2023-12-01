using FAckupWizard.FAClient;
using System.Net;

namespace FAckupWizard
{
    public class GalleryDownloaderConfig
    {
        public EGallerySection GallerySesctions {  get; set; } = EGallerySection.None;
        public ESubmissionType SubmissionTypes { get; set; } = ESubmissionType.None;
        public ERating SubmissionRatings { get; set; } = ERating.None;
        public IWebProxy? Proxy { get; set; } = null;
        public int ParallelDownloadsCount { get; set; } = 1;
        public string OutPath { get; set; } = string.Empty;

        public GalleryDownloaderConfig() 
        {
        }

    }
}
