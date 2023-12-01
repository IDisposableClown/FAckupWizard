namespace FAckupWizard.FAClient.FAParser
{
    public interface IFAParser
    {
        Task<GalleryPage> ParseGalleryPage(string pageText);
        Task<SubmissionDetails> ParseSubmissionPage(string pageText);
        Task<UserProfile> ParseUserProfilePage(string pageText);
        Task<List<string>> ParseWatchedUsersPage(string pageText);
    }
}
