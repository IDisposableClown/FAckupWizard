namespace FAckupWizard.FAClient
{
    [Flags]
    public enum EGallerySection
    {
        None      = 0,
        Gallery   = 1 << 0, 
        Scraps    = 1 << 1,
        Favorites = 1 << 2,
    }
}
