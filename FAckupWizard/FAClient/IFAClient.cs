namespace FAckupWizard.FAClient
{
    public interface IFAClient
    {
        Task<bool> IsSessionValid();
        Task<GalleryPage> GetUserGalleryPageAsync(string relativePath);
        Task<List<GalleryItem>> GetUserGalleryAsync(string userName, EGallerySection section, int depth = 1000);
        Task<UserProfile> GetUserProfileInfoAsync(string user);
        Task<List<string>> GetWatchedUsers(string user, int pageNum = 1);
        Task<SubmissionDetails> GetSubmissionInfoAsync(string viewUrl);
    }
}
