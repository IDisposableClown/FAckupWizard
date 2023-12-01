using FAckupWizard.FAClient;
using FAckupWizard.Forms;
using System.Net;

namespace FAckupWizard
{
    enum EPage
    {
        User,
        Section,
        Type,
        Rating,
        Proxy,
        DownloadPath,
        Login,
        Finish
    }

    public partial class FormMain : Form
    {
        private int tabIndex = 0;
        private string SettingsPath;
        private GalleryDownloaderConfig? Config;
        private Settings Sets;
        private Session FASession;
        private IFAClient? FAClient;
        private IWebProxy? Proxy = null;
        private SimpleWebClient? SWClient;

        private int PreviousPage = 0;
        private bool SessionValidated = false;
        private bool SessionValid = false;

        private bool BackupWatched;
        private string Users;
        private EGallerySection Sections;
        private ESubmissionType SubmissionTypes;
        private ERating SubmissionRatings;
        private ProxySettings ProxySets;
        private bool UseProxy;
        private string DownloadPath;

        public FormMain()
        {
            InitializeComponent();

            BackupWatched = false;
            Users = string.Empty;
            DownloadPath = string.Empty;

            fakeWizard.ItemSize = new Size(0, 1);
            fakeWizard.SizeMode = TabSizeMode.Fixed;
            btnBack.Enabled = false;

            string appDataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FAckupWizard");
            SettingsPath = Path.Combine(appDataFolder, "settings.json");
            Sets = Settings.Load(SettingsPath);

            FASession = new Session(Sets.Session.a, Sets.Session.b);
            Sections = Sets.Sections;
            SubmissionTypes = Sets.SubmissionTypes;
            SubmissionRatings = Sets.SubmissionRatings;
            UseProxy = Sets.UseProxy;
            ProxySets = Sets.ProxySettings;

            RefreshControls();
        }

        private void RefreshControls()
        {
            cbGallery.Checked = Sections.HasFlag(EGallerySection.Gallery);
            cbScraps.Checked = Sections.HasFlag(EGallerySection.Scraps);
            cbFavs.Checked = Sections.HasFlag(EGallerySection.Favorites);

            cbImage.Checked = SubmissionTypes.HasFlag(ESubmissionType.Image);
            cbAudio.Checked = SubmissionTypes.HasFlag(ESubmissionType.Audio);
            cbText.Checked = SubmissionTypes.HasFlag(ESubmissionType.Text);
            cbFlash.Checked = SubmissionTypes.HasFlag(ESubmissionType.Flash);
            cbOther.Checked = SubmissionTypes.HasFlag(ESubmissionType.Other);

            cbAdult.Checked = SubmissionRatings.HasFlag(ERating.Adult);
            cbGeneral.Checked = SubmissionRatings.HasFlag(ERating.General);
            cbMature.Checked = SubmissionRatings.HasFlag(ERating.Mature);

            cbUseProxy.Checked = UseProxy;
            panelProxy.Enabled = UseProxy;
            tbProxyAddress.Text = ProxySets.Address;
            tbProxyUser.Text = ProxySets.User;
            tbProxyPassword.Text = ProxySets.Password;
        }

        private void InitProxy()
        {
            if (UseProxy)
            {
                if(Proxy != null)
                {
                    Proxy = null;
                }
                if (!string.IsNullOrEmpty(ProxySets.Address))
                {
                    Proxy = new WebProxy()
                    {
                        Address = new Uri(ProxySets.Address),
                    };

                    var cred = new NetworkCredential();
                    if (!string.IsNullOrEmpty(ProxySets.User))
                    {
                        cred.UserName = ProxySets.User;
                    }
                    if (!string.IsNullOrEmpty(ProxySets.Password))
                    {
                        cred.Password = ProxySets.Password;
                    }
                    Proxy.Credentials = cred;
                }
            }
        }

        private void InitClient()
        {
            if(SWClient != null)
            {
                SWClient.Dispose();
                SWClient = null;
            }

            if (Proxy != null)
            {
                SWClient = new SimpleWebClient(Proxy);
            }
            else
            {
                SWClient = new SimpleWebClient();
            }

            if(FAClient != null)
            {
                FAClient = null;
            }

            FAClient = new FAWebClient(SWClient);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateNavControls()
        {
            PreviousPage = fakeWizard.SelectedIndex;

            fakeWizard.SelectTab(tabIndex);

            if (tabIndex == fakeWizard.TabCount - 2)
            {
                btnNext.Enabled = false;
                btnStart.Visible = true;
            }
            else if (tabIndex == fakeWizard.TabCount - 1)
            {
                btnFinish.Visible = true;
                btnCancel.Visible = false;
                btnNext.Visible = false;
                btnBack.Visible = false;
                btnStart.Visible = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnStart.Visible = false;
            }

            if (tabIndex > 0)
                btnBack.Enabled = true;
            else
                btnBack.Enabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabIndex++;
            UpdateNavControls();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabIndex--;
            UpdateNavControls();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            GalleryDownloaderConfig cfg = new GalleryDownloaderConfig();
            cfg.OutPath = DownloadPath;
            cfg.Proxy = Proxy;
            cfg.SubmissionRatings = SubmissionRatings;
            cfg.GallerySesctions = Sections;
            cfg.SubmissionTypes = SubmissionTypes;
            cfg.ParallelDownloadsCount = 4;

            List<string> userList = Users.Split(' ').ToList();

            DownloaderForm prf = new DownloaderForm(userList, BackupWatched, FAClient, cfg);
            prf.ShowDialog(this);

            tabIndex++;
            UpdateNavControls();
        }

        private void cbUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            panelProxy.Enabled = cbUseProxy.Checked;
        }

        private async Task ValidateSession()
        {
            if (!SessionValidated && FAClient != null)
            {
                btnStart.Enabled = false;

                labelValidating.Visible = true;
                labelNoSession.Visible = false;
                labelSessionFound.Visible = false;

                UpdateWebCookies();

                SessionValid = await FAClient.IsSessionValid();
                labelNoSession.Visible = !SessionValid;
                labelSessionFound.Visible = SessionValid;
                labelValidating.Visible = false;

                SessionValidated = true;
                btnStart.Enabled = true;
            }
        }

        private void UpdateWebCookies()
        {
            SWClient?.Reset();
            List<Cookie> cookies = new List<Cookie>
            {
                new Cookie("a", FASession.a, "/", ".furaffinity.net"),
                new Cookie("b", FASession.b, "/", ".furaffinity.net")
            };
            SWClient?.SetCookies(cookies);
        }

        private async void btnFALogin_Click(object sender, EventArgs e)
        {
            Enabled = false;

            LoginForm login = new LoginForm();
            login.ShowDialog(this);

            SessionValidated = false;

            if (!string.IsNullOrEmpty(login.FASession.a))
            {
                FASession.a = login.FASession.a;
                FASession.b = login.FASession.b;
            }

            if (!string.IsNullOrEmpty(login.FASession.a))
            {
                var msgb = MessageBox.Show(this, "Save session?", "FA Login", MessageBoxButtons.YesNo);
                if (msgb == DialogResult.Yes)
                {
                    Sets.Session = FASession;
                    Sets.Save(SettingsPath);
                }
            }

            Enabled = true;

            await ValidateSession();
        }

        private void btnFinish_Click_1(object sender, EventArgs e)
        {
            if(cbSaveSettings.Checked)
            {
                Sets.Sections = Sections;
                Sets.SubmissionTypes = SubmissionTypes;
                Sets.SubmissionRatings = SubmissionRatings;
                Sets.UseProxy = UseProxy;
                Sets.ProxySettings = ProxySets;

                Sets.Save(SettingsPath);
            }
            Close();
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog(this);
            tbDlPath.Text = fbd.SelectedPath;
        }

        private async void stepLogin_Enter(object sender, EventArgs e)
        {
            ValidateSession();
        }

        private void stepUsers_Leave(object sender, EventArgs e)
        {
            Users = tbUsers.Text;
            BackupWatched = cbBackupWatched.Checked;
            return;
        }

        private void UpdateUsers()
        {
            Users = tbUsers.Text;
            BackupWatched = cbBackupWatched.Checked;
        }

        private void UpdateSections()
        {
            EGallerySection sections = EGallerySection.None;
            if (cbGallery.Checked)
                sections |= EGallerySection.Gallery;
            if (cbScraps.Checked)
                sections |= EGallerySection.Scraps;
            if (cbFavs.Checked)
                sections |= EGallerySection.Favorites;

            Sections = sections;
        }

        private void UpdateSubmissionType()
        {
            ESubmissionType types = ESubmissionType.None;
            if (cbAudio.Checked)
                types |= ESubmissionType.Audio;
            if (cbText.Checked)
                types |= ESubmissionType.Text;
            if (cbImage.Checked)
                types |= ESubmissionType.Image;
            if (cbFlash.Checked)
                types |= ESubmissionType.Flash;
            if (cbOther.Checked)
                types |= ESubmissionType.Other;

            SubmissionTypes = types;
        }

        private void UpdateRatings()
        {
            ERating rating = ERating.None;
            if (cbGeneral.Checked)
                rating |= ERating.General;
            if (cbMature.Checked)
                rating |= ERating.Mature;
            if (cbAdult.Checked)
                rating |= ERating.Adult;

            SubmissionRatings = rating;
        }

        private void UpdateProxy()
        {
            UseProxy = cbUseProxy.Checked;
            if(UseProxy)
            {
                ProxySets.Address = tbProxyAddress.Text;
                ProxySets.User = tbProxyUser.Text;
                ProxySets.Password = tbProxyPassword.Text;
            }
        }

        private void UpdateDownloadPath()
        {
            DownloadPath = tbDlPath.Text;
        }

        private void fakeWizard_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((EPage)(PreviousPage))
            {
                case EPage.User:
                    UpdateUsers();
                    break;
                case EPage.Section:
                    UpdateSections();
                    break;
                case EPage.Type:
                    UpdateSubmissionType();
                    break;
                case EPage.Rating:
                    UpdateRatings();
                    break;
                case EPage.Proxy:
                    UpdateProxy();
                    InitProxy();
                    InitClient();
                    break;
                case EPage.DownloadPath:
                    UpdateDownloadPath();
                    break;
                case EPage.Login:
                case EPage.Finish:
                    break;
            }
        }
    }
}