using AngleSharp.Dom;
using AngleSharp;
using AngleSharp.Html.Dom;

namespace FAckupWizard.FAClient.FAParser.Modern
{
    internal class WatchedPageParser: IDisposable, IPageParser<List<string>>
    {
        private List<string> Watched;
        private string Text;
        private IBrowsingContext Context;
        private IDocument? Document;

        public WatchedPageParser(string pageText)
        {
            Context = BrowsingContext.New(Configuration.Default);
            Watched = new List<string>();
            Text = pageText;
        }

        private void GetWatchedList()
        {
            var hrefs = Document?.QuerySelectorAll("div.watch-list-items > a");
            if (hrefs != null)
            {
                foreach (IHtmlAnchorElement href in hrefs)
                {
                    Watched.Add(href.PathName.Split('/')[2]);
                }
            }
        }

        public async Task<List<string>> Parse()
        {
            try
            {
                Document = await Context.OpenAsync(req => req.Content(Text));
                GetWatchedList();
            }
            catch { }
            return Watched;
        }

        public void Dispose()
        {
            Document?.Dispose();
            Context?.Dispose();
        }
    }
}
