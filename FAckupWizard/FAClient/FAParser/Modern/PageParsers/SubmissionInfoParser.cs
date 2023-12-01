using AngleSharp.Dom;
using AngleSharp;
using AngleSharp.Html.Dom;
using System;

namespace FAckupWizard.FAClient.FAParser.Modern
{
    internal class SubmissionInfoParser: IDisposable, IPageParser<SubmissionDetails>
    {
        private SubmissionDetails SubInfo = new SubmissionDetails();
        private string Text;
        private IBrowsingContext Context;
        private IDocument? Document;

        public SubmissionInfoParser(string pageText)
        {
            Text = pageText;
            Context = BrowsingContext.New(Configuration.Default);
        }

        private void GetStats()
        {
            var viewsNode = Document?.QuerySelector("section.stats-container > div.views > span.font-large");
            if(viewsNode != null) 
            {
                uint.TryParse(viewsNode.TextContent, out uint vcnt);
                SubInfo.ViewsCount = vcnt;
            }

            var favsNode = Document?.QuerySelector("section.stats-container > div.favorites > span.font-large");
            if (favsNode != null)
            {
                uint.TryParse(favsNode.TextContent, out uint fcnt);
                SubInfo.FavsCount = fcnt;
            }

            var ccNode = Document?.QuerySelector("section.stats-container > div.comments > span.font-large");
            if (ccNode != null)
            {
                uint.TryParse(ccNode.TextContent, out uint ccnt);
                SubInfo.CommentsCount = ccnt;
            }
        }

        public void GetDownloadLink()
        {
            IHtmlAnchorElement? linkNode = (IHtmlAnchorElement?)Document?.QuerySelector("section.buttons > div.download a");
            if (linkNode != null)
            {
                SubInfo.DownloadURL = linkNode.Href;
            }
        }

        public void GetDetails()
        { 
            IHtmlAnchorElement? authorNode =(IHtmlAnchorElement?)Document?.QuerySelector("div.submission-id-sub-container > a");
            if(authorNode != null)
            {
                SubInfo.Author = authorNode.PathName.Split('/')[2];
            }

            var descNode = Document?.QuerySelector("div.submission-description");
            if(descNode != null)
            {
                SubInfo.Description = descNode.TextContent.Trim();
            }

            IHtmlSpanElement? dateNode = (IHtmlSpanElement?)Document?.QuerySelector("span.popup_date");
            if(dateNode != null)
            {
                DateTime.TryParse(dateNode.Title, out DateTime dt);
                SubInfo.DatePublished = dt;
            }

            var titleNode = Document?.QuerySelector("div.submission-title p");
            if(titleNode != null)
            {
                SubInfo.Title = titleNode.TextContent;
            }
        }

        public async Task<SubmissionDetails> Parse()
        {
            try
            {
                Document = await Context.OpenAsync(req => req.Content(Text));
                GetDownloadLink();
                GetDetails();
                GetStats();
            }
            catch { }
            return SubInfo;
        }

        public void Dispose()
        {
            Document?.Dispose();
            Context?.Dispose();
        }
    }
}
