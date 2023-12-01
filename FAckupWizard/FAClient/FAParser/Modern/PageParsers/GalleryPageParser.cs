using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace FAckupWizard.FAClient.FAParser.Modern
{
    internal class GalleryPageParser : IDisposable, IPageParser<GalleryPage>
    {
        private GalleryPage Page;
        private string Text;
        private IBrowsingContext Context;
        private IDocument? Document;

        public GalleryPageParser(string pageText)
        {
            Context = BrowsingContext.New(Configuration.Default);
            Page = new GalleryPage();
            Text = pageText;
        }

        private ERating RatingFromClassList(ITokenList classes)
        {
            if (classes.Contains("r-mature"))
            {
                return ERating.Mature;
            }
            else if (classes.Contains("r-adult"))
            {
                return ERating.Adult;
            }
            return ERating.General;
        }

        private ESubmissionType SubmissionTypeFromClassList(ITokenList classes)
        {
            if (classes.Contains("t-image"))
            {
                return ESubmissionType.Image;
            }
            else if (classes.Contains("t-none"))
            {
                return ESubmissionType.None;
            }
            else if (classes.Contains("t-audio"))
            {
                return ESubmissionType.Audio;
            }
            else if (classes.Contains("t-text"))
            {
                return ESubmissionType.Text;
            }
            else if (classes.Contains("t-flash"))
            {
                return ESubmissionType.Flash;
            }
            return ESubmissionType.Other;
        }

        private void GetNavLinks()
        {
            var nav = Document?.QuerySelectorAll("div.aligncenter:nth-child(1) > div.pagination > a.button");
            if (nav != null && nav.Length != 0)
            {
                foreach (IHtmlAnchorElement el in nav)
                {
                    if (el.PathName.EndsWith("next"))
                    {
                        Page.Next = el.PathName;
                    }
                    else if (el.PathName.EndsWith("prev"))
                    {
                        Page.Prev = el.PathName;
                    }
                }
            }
            else
            {
                var navAlt = Document?.QuerySelectorAll("div.aligncenter:nth-child(1) > div.inline > form");
                if (navAlt != null)
                {
                    foreach (IHtmlFormElement el in navAlt)
                    {
                        if (el.TextContent.IndexOf("next", StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            Page.Next = el.Action;
                        }
                        else if (el.TextContent.IndexOf("prev", StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            Page.Prev = el.Action;
                        }
                    }
                }
            }
        }

        private void GetGalleryItems()
        {
            var subFigs = Document?.QuerySelectorAll("div.section-body section > figure");
            if (subFigs != null)
            {
                foreach (var figure in subFigs)
                {
                    GalleryItem sub = new GalleryItem();
                    sub.Rating = RatingFromClassList(figure.ClassList);
                    sub.SubmissionType = SubmissionTypeFromClassList(figure.ClassList);
                    var hrefs = figure.QuerySelectorAll("figcaption a");
                    if (hrefs.Length == 2)
                    {
                        sub.ViewURL = ((IHtmlAnchorElement)hrefs[0]).PathName;
                        sub.Author = ((IHtmlAnchorElement)hrefs[1]).PathName.Split('/')[2];
                        sub.Title = hrefs[0].TextContent;
                    }
                    if (ulong.TryParse(figure.Id?[4..], out ulong subID))
                        sub.SubmissionID = subID;
                    Page.Items.Add(sub);
                }
            }
        }

        public async Task<GalleryPage> Parse()
        {
            try
            {
                Document = await Context.OpenAsync(req => req.Content(Text));
                GetGalleryItems();
                GetNavLinks();
            }
            catch { }
            return Page;
        }

        public void Dispose()
        {
            Document?.Dispose();
            Context?.Dispose();
        }
    }
}
