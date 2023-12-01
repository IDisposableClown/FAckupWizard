using System.Net;

namespace FAckupWizard.FAClient
{
    public interface IWebClient
    {
        Task<(HttpStatusCode, string)> GetResponse(string url, Dictionary<string, string>? data = null, string referer = "");
    }
}
