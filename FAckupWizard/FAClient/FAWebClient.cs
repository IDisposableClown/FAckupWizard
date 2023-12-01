using FAckupWizard.FAClient.FAParser;
using FAckupWizard.FAClient.FAParser.Modern;

namespace FAckupWizard.FAClient
{
    public class FAWebClient: IFAClient
    {
        private IWebClient WebClient;

        public string FA_BASE_URL { get; set; } = "https://www.furaffinity.net/";
        public IFAParser FAParser { get; set; } = new FAParserModern();

        public FAWebClient(IWebClient webClient) 
        { 
            WebClient = webClient;
        }

        public async Task<bool> IsSessionValid()
        {
            var (err, resp) = await WebClient.GetResponse(FA_BASE_URL + "controls/site-settings/");
            if(err == System.Net.HttpStatusCode.OK)
            {
                if(resp.IndexOf("log out", StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<GalleryPage> GetUserGalleryPageAsync(string relativePath)
        {
            string reqUrl = FA_BASE_URL + relativePath.TrimStart('/');
            var (err, response) = await WebClient.GetResponse(reqUrl).ConfigureAwait(false);
            if (err == System.Net.HttpStatusCode.OK)
            {
                return await FAParser.ParseGalleryPage(response);
            }
            return new GalleryPage();
        }

        public async Task<List<GalleryItem>> GetUserGalleryAsync(string userName, EGallerySection section, int depth = 1000)
        {
            List<GalleryItem> items = new List<GalleryItem>();
            string nextPage = section.ToString().ToLower() + "/" + userName;
            while (depth != 0)
            {
                GalleryPage page = await GetUserGalleryPageAsync(nextPage);
                page.Items.ForEach(x => { x.GallerySection = section; });
                items.AddRange(page.Items);
                nextPage = page.Next;
                if(string.IsNullOrEmpty(nextPage))
                {
                    break;
                }
                --depth;
            }
            return items;
        }

        public async Task<UserProfile> GetUserProfileInfoAsync(string user)
        {
            string reqUrl = FA_BASE_URL + "user/" + user;
            var (err, response) = await WebClient.GetResponse(reqUrl).ConfigureAwait(false);
            if(err == System.Net.HttpStatusCode.OK)
            {
                return await FAParser.ParseUserProfilePage(response);
            }
            return new UserProfile();
        }

        public async Task<List<string>> GetWatchedUsers(string user, int pageNum = 0)
        {
            string reqUrl = FA_BASE_URL + string.Join('/',
                    "watchlist/by",
                    user,
                    pageNum
                );
            var (err, response) = await WebClient.GetResponse(reqUrl).ConfigureAwait(false);
            if (err == System.Net.HttpStatusCode.OK)
            {
                return await FAParser.ParseWatchedUsersPage(response);
            }
            return new List<string>();
        }

        public async Task<SubmissionDetails> GetSubmissionInfoAsync(string viewUrl)
        {
            string reqUrl = FA_BASE_URL + viewUrl.TrimStart('/');
            var (err, response) = await WebClient.GetResponse(reqUrl).ConfigureAwait(false);
            if(err == System.Net.HttpStatusCode.OK)
            { 
                return await FAParser.ParseSubmissionPage(response);
            }
            return new SubmissionDetails();
        }
    }
}
