using CefSharp;
using CefSharp.WinForms;

namespace FAckupWizard
{
    public partial class LoginForm : Form
    {
        private ChromiumWebBrowser browser;

        public Session FASession { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser("https://www.furaffinity.net/login");
            browser.Dock = DockStyle.Fill;
            BrowserPanel.Controls.Add(browser);
            FASession = new Session("", "");
            FormClosing += LoginForm_FormClosing;
        }

        private void LoginForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var cMgr = browser.GetCookieManager();
            Session sess = new Session("", "");
            var cookies = cMgr.VisitAllCookiesAsync()
                              .ConfigureAwait(false)
                              .GetAwaiter()
                              .GetResult();

            foreach(var cookie in cookies) 
            { 
                if(cookie.Name == "a")
                {
                    FASession.a = cookie.Value;
                }
                if(cookie.Name == "b") 
                { 
                    FASession.b = cookie.Value;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
