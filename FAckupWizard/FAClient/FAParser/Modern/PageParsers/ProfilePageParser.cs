using AngleSharp;
using AngleSharp.Dom;

namespace FAckupWizard.FAClient.FAParser.Modern
{
    internal class ProfilePageParser : IDisposable, IPageParser<UserProfile>
    {
        private UserProfile Profile;
        private string Text;
        private IBrowsingContext Context;
        private IDocument? Document;

        public ProfilePageParser(string pageText)
        {
            Context = BrowsingContext.New(Configuration.Default);
            Text = pageText;
            Profile = new UserProfile();
        }

        private void GetStats()
        {
            var statNodes = Document?.QuerySelectorAll("div.section-body > div.table > div.cell");
            if(statNodes != null) 
            { 
                foreach (var statNode in statNodes)
                {
                    string[] lines = statNode.TextContent.Split('\n');
                    foreach (string line in lines) 
                    { 
                        string[] kvp = line.Split(':');
                        if (kvp.Length ==  2)
                        {
                            if (kvp[0].IndexOf("views", StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                if(int.TryParse(kvp[1], out int views))
                                    Profile.Views = views;
                            }
                            else if (kvp[0].IndexOf("Submissions", StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                if(int.TryParse(kvp[1], out int subs))
                                    Profile.SubmissionsCount = subs;
                            }
                            else if (kvp[0].IndexOf("Favs", StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                if (int.TryParse(kvp[1], out int favs))
                                    Profile.Favs = favs;
                            }
                            else if (kvp[0].IndexOf("Comments Earned", StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                if (int.TryParse(kvp[1], out int earned))
                                    Profile.CommentsEarned = earned;
                            }
                            else if (kvp[0].IndexOf("Comments Made", StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                if (int.TryParse(kvp[1], out int made))
                                    Profile.CommentsMade = made;
                            }
                        }
                    }
                }
            }
        }

        void GetProfileDesc()
        {
            var userNameNode = Document?.QuerySelector("h1 > username");
            if (userNameNode != null) 
            {
                Profile.Name = userNameNode.TextContent;
            }

            var descNode = Document?.QuerySelector("div.section-body.userpage-profile");
            if (descNode != null) 
            { 
                Profile.Profile = descNode.TextContent.Trim();
            }
        }

        public async Task<UserProfile> Parse()
        {
            try
            {
                Document = await Context.OpenAsync(req => req.Content(Text));
                GetProfileDesc();
                GetStats();
            }
            catch { }
            return Profile;
        }

        public void Dispose()
        {
            Document?.Dispose();
            Context?.Dispose();
        }
    }
}
