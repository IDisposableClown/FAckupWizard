namespace FAckupWizard.FAClient
{
    public class GalleryPage
    {
        public List<GalleryItem> Items = new List<GalleryItem>();
        public string Prev { get; set; } = string.Empty;
        public string Next { get; set; } = string.Empty;

        public GalleryPage() { }
    }
}
