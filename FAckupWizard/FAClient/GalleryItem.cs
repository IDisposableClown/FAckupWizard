namespace FAckupWizard.FAClient
{
    public class GalleryItem
    {
        public string Author { get; set; } = string.Empty;
        public ESubmissionType SubmissionType { get; set; } = ESubmissionType.Image;
        public ulong SubmissionID { get; set; } = 0;
        public string ViewURL { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public ERating Rating { get; set; } = ERating.General;
        public EGallerySection GallerySection { get; set; } = EGallerySection.Gallery;

        public GalleryItem() 
        {
        }
    }
}
