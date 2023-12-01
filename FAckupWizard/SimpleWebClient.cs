using System.Net;
using FAckupWizard.FAClient;

namespace FAckupWizard
{
    public class SimpleWebClient: IDisposable, IWebClient
    {
        public int RequestDelay { get; set; } = 1;
        public string UserAgent { get; set; } = 
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36";

        private IWebProxy? Proxy = null;
        private CookieContainer? Cookies;
        private HttpClient? httpClient;
        private HttpClientHandler? httpClientHandler;

        public SimpleWebClient(IWebProxy proxy)
        {
            Proxy = proxy;
            Init();
        }

        public SimpleWebClient() 
        {
            Init();
        }

        private void Init()
        {
            Cookies = new CookieContainer();
            httpClientHandler = new HttpClientHandler();
            httpClientHandler.CookieContainer = Cookies;

            if(Proxy != null)
                httpClientHandler.Proxy = Proxy;
            
            httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders
                .UserAgent
                .ParseAdd(UserAgent);
        }

        public void Reset()
        {
            httpClientHandler?.Dispose();
            httpClient?.Dispose();

            httpClient = null;
            httpClientHandler = null; 

            Init();
        }

        public void SetCookies(List<Cookie> cookies)
        {
            foreach (Cookie c in cookies)
                Cookies?.Add(c);
        }

        public async Task<(HttpStatusCode, string)> GetResponse(string url, Dictionary<string, string>? data= null, string referer = "")
        {
            string response = "";
            HttpStatusCode err = HttpStatusCode.OK;
            try
            {
                string urlRequestData = "";
                if (data != null)
                {
                    int del = 0;
                    foreach (var kvp in data)
                    {
                        urlRequestData += del == 0 ? "?" : "&";
                        urlRequestData += kvp.Key + "=" + Uri.EscapeDataString(kvp.Value);
                        ++del;
                    }
                }

                if (!string.IsNullOrEmpty(referer) && httpClient != null)
                    httpClient.DefaultRequestHeaders.Referrer = new Uri(referer);

                await Task.Delay(TimeSpan.FromSeconds(RequestDelay));

                if (httpClient != null)
                {
                    HttpResponseMessage msgResponse = await httpClient
                        .GetAsync(url + urlRequestData, HttpCompletionOption.ResponseContentRead)
                        .ConfigureAwait(false);

                    err = msgResponse.StatusCode;
                    if (msgResponse.StatusCode == HttpStatusCode.OK)
                        response = await msgResponse.Content.ReadAsStringAsync();
                }
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex); 
            }
            return (err, response);
        }

        public void Dispose() 
        {
            httpClient?.Dispose();
            httpClientHandler?.Dispose();
        }
    }
}
