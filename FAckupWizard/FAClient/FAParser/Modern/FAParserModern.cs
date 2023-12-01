namespace FAckupWizard.FAClient.FAParser.Modern
{
    public class FAParserModern : IFAParser
    {
        public FAParserModern()
        {
        }

        public async Task<List<string>> ParseWatchedUsersPage(string pageText)
        {
            using (WatchedPageParser parser = new WatchedPageParser(pageText))
                return await parser.Parse();
        }

        public async Task<GalleryPage> ParseGalleryPage(string pageText)
        {
            using (GalleryPageParser parser = new GalleryPageParser(pageText))
                return await parser.Parse();
        }

        public async Task<SubmissionDetails> ParseSubmissionPage(string pageText)
        {
            using (SubmissionInfoParser parser = new SubmissionInfoParser(pageText))
                return await parser.Parse();
        }

        public async Task<UserProfile> ParseUserProfilePage(string pageText)
        {   
            using (ProfilePageParser parser = new ProfilePageParser(pageText))
                return await parser.Parse();
        }
    }
}
