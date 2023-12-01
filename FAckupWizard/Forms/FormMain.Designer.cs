namespace FAckupWizard
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label4;
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnFinish = new Button();
            btnCancel = new Button();
            btnStart = new Button();
            btnNext = new Button();
            btnBack = new Button();
            fakeWizard = new TabControl();
            stepUsers = new TabPage();
            cbBackupWatched = new CheckBox();
            tbUsers = new TextBox();
            stepSections = new TabPage();
            label5 = new Label();
            cbFavs = new CheckBox();
            cbScraps = new CheckBox();
            cbGallery = new CheckBox();
            stepSubTypes = new TabPage();
            cbOther = new CheckBox();
            cbFlash = new CheckBox();
            cbText = new CheckBox();
            cbAudio = new CheckBox();
            cbImage = new CheckBox();
            label10 = new Label();
            stepRatings = new TabPage();
            label6 = new Label();
            cbGeneral = new CheckBox();
            cbMature = new CheckBox();
            cbAdult = new CheckBox();
            stepProxy = new TabPage();
            panelProxy = new Panel();
            tbProxyAddress = new TextBox();
            tbProxyPassword = new TextBox();
            label3 = new Label();
            tbProxyUser = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label7 = new Label();
            cbUseProxy = new CheckBox();
            stepDlPath = new TabPage();
            label8 = new Label();
            btnBrowseDest = new Button();
            tbDlPath = new TextBox();
            stepLogin = new TabPage();
            labelValidating = new Label();
            labelNoSession = new Label();
            labelSessionFound = new Label();
            label9 = new Label();
            btnFALogin = new Button();
            stepFinish = new TabPage();
            cbSaveSettings = new CheckBox();
            label11 = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            fakeWizard.SuspendLayout();
            stepUsers.SuspendLayout();
            stepSections.SuspendLayout();
            stepSubTypes.SuspendLayout();
            stepRatings.SuspendLayout();
            stepProxy.SuspendLayout();
            panelProxy.SuspendLayout();
            stepDlPath.SuspendLayout();
            stepLogin.SuspendLayout();
            stepFinish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 50);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 2;
            label4.Text = "Users to backup";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 203F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Controls.Add(fakeWizard, 1, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 91.78571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.214286F));
            tableLayoutPanel1.Size = new Size(690, 557);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnFinish);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnStart);
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Controls.Add(btnBack);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(206, 514);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 0, 15, 0);
            flowLayoutPanel1.Size = new Size(481, 40);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(388, 3);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(75, 23);
            btnFinish.TabIndex = 4;
            btnFinish.Text = "Finish";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Visible = false;
            btnFinish.Click += btnFinish_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(307, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(226, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start!";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Visible = false;
            btnStart.Click += btnFinish_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(145, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(64, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // fakeWizard
            // 
            fakeWizard.Appearance = TabAppearance.FlatButtons;
            fakeWizard.Controls.Add(stepUsers);
            fakeWizard.Controls.Add(stepSections);
            fakeWizard.Controls.Add(stepSubTypes);
            fakeWizard.Controls.Add(stepRatings);
            fakeWizard.Controls.Add(stepProxy);
            fakeWizard.Controls.Add(stepDlPath);
            fakeWizard.Controls.Add(stepLogin);
            fakeWizard.Controls.Add(stepFinish);
            fakeWizard.Dock = DockStyle.Fill;
            fakeWizard.ItemSize = new Size(61, 21);
            fakeWizard.Location = new Point(206, 3);
            fakeWizard.Multiline = true;
            fakeWizard.Name = "fakeWizard";
            fakeWizard.SelectedIndex = 0;
            fakeWizard.Size = new Size(481, 505);
            fakeWizard.TabIndex = 1;
            fakeWizard.TabStop = false;
            fakeWizard.SelectedIndexChanged += fakeWizard_SelectedIndexChanged;
            // 
            // stepUsers
            // 
            stepUsers.Controls.Add(label4);
            stepUsers.Controls.Add(cbBackupWatched);
            stepUsers.Controls.Add(tbUsers);
            stepUsers.Location = new Point(4, 25);
            stepUsers.Name = "stepUsers";
            stepUsers.Padding = new Padding(50, 50, 3, 3);
            stepUsers.Size = new Size(473, 476);
            stepUsers.TabIndex = 0;
            stepUsers.Text = "1";
            stepUsers.UseVisualStyleBackColor = true;
            stepUsers.Leave += stepUsers_Leave;
            // 
            // cbBackupWatched
            // 
            cbBackupWatched.AutoSize = true;
            cbBackupWatched.Location = new Point(57, 243);
            cbBackupWatched.Name = "cbBackupWatched";
            cbBackupWatched.Size = new Size(145, 19);
            cbBackupWatched.TabIndex = 1;
            cbBackupWatched.Text = "Backup Watched users";
            cbBackupWatched.UseVisualStyleBackColor = true;
            // 
            // tbUsers
            // 
            tbUsers.Location = new Point(57, 214);
            tbUsers.Name = "tbUsers";
            tbUsers.PlaceholderText = "User names to backup, space separated";
            tbUsers.Size = new Size(359, 23);
            tbUsers.TabIndex = 0;
            // 
            // stepSections
            // 
            stepSections.Controls.Add(label5);
            stepSections.Controls.Add(cbFavs);
            stepSections.Controls.Add(cbScraps);
            stepSections.Controls.Add(cbGallery);
            stepSections.Location = new Point(4, 25);
            stepSections.Name = "stepSections";
            stepSections.Padding = new Padding(50, 50, 3, 3);
            stepSections.Size = new Size(473, 476);
            stepSections.TabIndex = 1;
            stepSections.Text = "2";
            stepSections.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(53, 50);
            label5.Name = "label5";
            label5.Size = new Size(145, 15);
            label5.TabIndex = 3;
            label5.Text = "Gallery sections to backup";
            // 
            // cbFavs
            // 
            cbFavs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbFavs.AutoSize = true;
            cbFavs.Checked = true;
            cbFavs.CheckState = CheckState.Checked;
            cbFavs.Location = new Point(118, 254);
            cbFavs.Name = "cbFavs";
            cbFavs.Size = new Size(238, 19);
            cbFavs.TabIndex = 2;
            cbFavs.Text = "Favorites ( for non Watched users only! )";
            cbFavs.UseVisualStyleBackColor = true;
            // 
            // cbScraps
            // 
            cbScraps.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbScraps.AutoSize = true;
            cbScraps.Checked = true;
            cbScraps.CheckState = CheckState.Checked;
            cbScraps.Location = new Point(118, 229);
            cbScraps.Name = "cbScraps";
            cbScraps.Size = new Size(60, 19);
            cbScraps.TabIndex = 1;
            cbScraps.Text = "Scraps";
            cbScraps.UseVisualStyleBackColor = true;
            // 
            // cbGallery
            // 
            cbGallery.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbGallery.AutoSize = true;
            cbGallery.Checked = true;
            cbGallery.CheckState = CheckState.Checked;
            cbGallery.Location = new Point(118, 204);
            cbGallery.Name = "cbGallery";
            cbGallery.Size = new Size(91, 19);
            cbGallery.TabIndex = 0;
            cbGallery.Text = "Main gallery";
            cbGallery.UseVisualStyleBackColor = true;
            // 
            // stepSubTypes
            // 
            stepSubTypes.Controls.Add(cbOther);
            stepSubTypes.Controls.Add(cbFlash);
            stepSubTypes.Controls.Add(cbText);
            stepSubTypes.Controls.Add(cbAudio);
            stepSubTypes.Controls.Add(cbImage);
            stepSubTypes.Controls.Add(label10);
            stepSubTypes.Location = new Point(4, 25);
            stepSubTypes.Name = "stepSubTypes";
            stepSubTypes.Padding = new Padding(50, 50, 0, 0);
            stepSubTypes.Size = new Size(473, 476);
            stepSubTypes.TabIndex = 7;
            stepSubTypes.Text = "8";
            stepSubTypes.UseVisualStyleBackColor = true;
            // 
            // cbOther
            // 
            cbOther.AutoSize = true;
            cbOther.Checked = true;
            cbOther.CheckState = CheckState.Checked;
            cbOther.Location = new Point(207, 279);
            cbOther.Name = "cbOther";
            cbOther.Size = new Size(56, 19);
            cbOther.TabIndex = 5;
            cbOther.Text = "Other";
            cbOther.UseVisualStyleBackColor = true;
            // 
            // cbFlash
            // 
            cbFlash.AutoSize = true;
            cbFlash.Checked = true;
            cbFlash.CheckState = CheckState.Checked;
            cbFlash.Location = new Point(207, 254);
            cbFlash.Name = "cbFlash";
            cbFlash.Size = new Size(53, 19);
            cbFlash.TabIndex = 4;
            cbFlash.Text = "Flash";
            cbFlash.UseVisualStyleBackColor = true;
            // 
            // cbText
            // 
            cbText.AutoSize = true;
            cbText.Checked = true;
            cbText.CheckState = CheckState.Checked;
            cbText.Location = new Point(207, 229);
            cbText.Name = "cbText";
            cbText.Size = new Size(47, 19);
            cbText.TabIndex = 3;
            cbText.Text = "Text";
            cbText.UseVisualStyleBackColor = true;
            // 
            // cbAudio
            // 
            cbAudio.AutoSize = true;
            cbAudio.Checked = true;
            cbAudio.CheckState = CheckState.Checked;
            cbAudio.Location = new Point(207, 204);
            cbAudio.Name = "cbAudio";
            cbAudio.Size = new Size(58, 19);
            cbAudio.TabIndex = 2;
            cbAudio.Text = "Audio";
            cbAudio.UseVisualStyleBackColor = true;
            // 
            // cbImage
            // 
            cbImage.AutoSize = true;
            cbImage.Checked = true;
            cbImage.CheckState = CheckState.Checked;
            cbImage.Location = new Point(207, 179);
            cbImage.Name = "cbImage";
            cbImage.Size = new Size(59, 19);
            cbImage.TabIndex = 1;
            cbImage.Text = "Image";
            cbImage.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(53, 50);
            label10.Name = "label10";
            label10.Size = new Size(99, 15);
            label10.TabIndex = 0;
            label10.Text = "Submission types";
            // 
            // stepRatings
            // 
            stepRatings.Controls.Add(label6);
            stepRatings.Controls.Add(cbGeneral);
            stepRatings.Controls.Add(cbMature);
            stepRatings.Controls.Add(cbAdult);
            stepRatings.Location = new Point(4, 25);
            stepRatings.Name = "stepRatings";
            stepRatings.Padding = new Padding(50, 50, 3, 3);
            stepRatings.Size = new Size(473, 476);
            stepRatings.TabIndex = 2;
            stepRatings.Text = "3";
            stepRatings.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(53, 50);
            label6.Name = "label6";
            label6.Size = new Size(110, 15);
            label6.TabIndex = 3;
            label6.Text = "Submission ratings ";
            // 
            // cbGeneral
            // 
            cbGeneral.AutoSize = true;
            cbGeneral.Checked = true;
            cbGeneral.CheckState = CheckState.Checked;
            cbGeneral.Location = new Point(203, 204);
            cbGeneral.Name = "cbGeneral";
            cbGeneral.Size = new Size(66, 19);
            cbGeneral.TabIndex = 2;
            cbGeneral.Text = "General";
            cbGeneral.UseVisualStyleBackColor = true;
            // 
            // cbMature
            // 
            cbMature.AutoSize = true;
            cbMature.Checked = true;
            cbMature.CheckState = CheckState.Checked;
            cbMature.Location = new Point(203, 229);
            cbMature.Name = "cbMature";
            cbMature.Size = new Size(64, 19);
            cbMature.TabIndex = 1;
            cbMature.Text = "Mature";
            cbMature.UseVisualStyleBackColor = true;
            // 
            // cbAdult
            // 
            cbAdult.AutoSize = true;
            cbAdult.Location = new Point(203, 254);
            cbAdult.Name = "cbAdult";
            cbAdult.Size = new Size(55, 19);
            cbAdult.TabIndex = 0;
            cbAdult.Text = "Adult";
            cbAdult.UseVisualStyleBackColor = true;
            // 
            // stepProxy
            // 
            stepProxy.Controls.Add(panelProxy);
            stepProxy.Controls.Add(label7);
            stepProxy.Controls.Add(cbUseProxy);
            stepProxy.Location = new Point(4, 25);
            stepProxy.Name = "stepProxy";
            stepProxy.Padding = new Padding(50, 50, 3, 3);
            stepProxy.Size = new Size(473, 476);
            stepProxy.TabIndex = 3;
            stepProxy.Text = "4";
            stepProxy.UseVisualStyleBackColor = true;
            // 
            // panelProxy
            // 
            panelProxy.Controls.Add(tbProxyAddress);
            panelProxy.Controls.Add(tbProxyPassword);
            panelProxy.Controls.Add(label3);
            panelProxy.Controls.Add(tbProxyUser);
            panelProxy.Controls.Add(label2);
            panelProxy.Controls.Add(label1);
            panelProxy.Enabled = false;
            panelProxy.Location = new Point(77, 198);
            panelProxy.Name = "panelProxy";
            panelProxy.Size = new Size(317, 105);
            panelProxy.TabIndex = 8;
            // 
            // tbProxyAddress
            // 
            tbProxyAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbProxyAddress.Location = new Point(64, 14);
            tbProxyAddress.Name = "tbProxyAddress";
            tbProxyAddress.Size = new Size(250, 23);
            tbProxyAddress.TabIndex = 1;
            // 
            // tbProxyPassword
            // 
            tbProxyPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbProxyPassword.Location = new Point(64, 72);
            tbProxyPassword.Name = "tbProxyPassword";
            tbProxyPassword.Size = new Size(250, 23);
            tbProxyPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-2, 75);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 6;
            label3.Text = "Password";
            // 
            // tbProxyUser
            // 
            tbProxyUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbProxyUser.Location = new Point(64, 43);
            tbProxyUser.Name = "tbProxyUser";
            tbProxyUser.Size = new Size(250, 23);
            tbProxyUser.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 46);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 5;
            label2.Text = "User";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 17);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 4;
            label1.Text = "Address";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(53, 50);
            label7.Name = "label7";
            label7.Size = new Size(112, 15);
            label7.TabIndex = 7;
            label7.Text = "Proxy configuration";
            // 
            // cbUseProxy
            // 
            cbUseProxy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbUseProxy.AutoSize = true;
            cbUseProxy.Location = new Point(83, 173);
            cbUseProxy.Name = "cbUseProxy";
            cbUseProxy.Size = new Size(78, 19);
            cbUseProxy.TabIndex = 0;
            cbUseProxy.Text = "Use proxy";
            cbUseProxy.UseVisualStyleBackColor = true;
            cbUseProxy.CheckedChanged += cbUseProxy_CheckedChanged;
            // 
            // stepDlPath
            // 
            stepDlPath.Controls.Add(label8);
            stepDlPath.Controls.Add(btnBrowseDest);
            stepDlPath.Controls.Add(tbDlPath);
            stepDlPath.Location = new Point(4, 25);
            stepDlPath.Name = "stepDlPath";
            stepDlPath.Padding = new Padding(50, 50, 3, 3);
            stepDlPath.Size = new Size(473, 476);
            stepDlPath.TabIndex = 4;
            stepDlPath.Text = "5";
            stepDlPath.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(53, 50);
            label8.Name = "label8";
            label8.Size = new Size(73, 15);
            label8.TabIndex = 2;
            label8.Text = "Backup path";
            // 
            // btnBrowseDest
            // 
            btnBrowseDest.Location = new Point(342, 256);
            btnBrowseDest.Name = "btnBrowseDest";
            btnBrowseDest.Size = new Size(75, 23);
            btnBrowseDest.TabIndex = 1;
            btnBrowseDest.Text = "Browse";
            btnBrowseDest.UseVisualStyleBackColor = true;
            btnBrowseDest.Click += btnBrowseDest_Click;
            // 
            // tbDlPath
            // 
            tbDlPath.Location = new Point(53, 227);
            tbDlPath.Name = "tbDlPath";
            tbDlPath.ReadOnly = true;
            tbDlPath.Size = new Size(364, 23);
            tbDlPath.TabIndex = 0;
            // 
            // stepLogin
            // 
            stepLogin.Controls.Add(labelValidating);
            stepLogin.Controls.Add(labelNoSession);
            stepLogin.Controls.Add(labelSessionFound);
            stepLogin.Controls.Add(label9);
            stepLogin.Controls.Add(btnFALogin);
            stepLogin.Location = new Point(4, 25);
            stepLogin.Name = "stepLogin";
            stepLogin.Padding = new Padding(50, 50, 3, 3);
            stepLogin.Size = new Size(473, 476);
            stepLogin.TabIndex = 6;
            stepLogin.Text = "6";
            stepLogin.UseVisualStyleBackColor = true;
            stepLogin.Enter += stepLogin_Enter;
            // 
            // labelValidating
            // 
            labelValidating.AutoSize = true;
            labelValidating.Location = new Point(165, 190);
            labelValidating.Name = "labelValidating";
            labelValidating.Size = new Size(142, 15);
            labelValidating.TabIndex = 4;
            labelValidating.Text = "Validating saved session...";
            labelValidating.Visible = false;
            // 
            // labelNoSession
            // 
            labelNoSession.AutoSize = true;
            labelNoSession.Location = new Point(40, 190);
            labelNoSession.Name = "labelNoSession";
            labelNoSession.Size = new Size(394, 15);
            labelNoSession.TabIndex = 3;
            labelNoSession.Text = "No valid FA session found, you may need to log in to create a full backup.";
            labelNoSession.Visible = false;
            // 
            // labelSessionFound
            // 
            labelSessionFound.AutoSize = true;
            labelSessionFound.Location = new Point(108, 190);
            labelSessionFound.Name = "labelSessionFound";
            labelSessionFound.Size = new Size(258, 15);
            labelSessionFound.TabIndex = 2;
            labelSessionFound.Text = "Valid session found, you can skip the login step,";
            labelSessionFound.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(53, 50);
            label9.Name = "label9";
            label9.Size = new Size(53, 15);
            label9.TabIndex = 1;
            label9.Text = "FA Login";
            // 
            // btnFALogin
            // 
            btnFALogin.Location = new Point(171, 220);
            btnFALogin.Name = "btnFALogin";
            btnFALogin.Size = new Size(132, 36);
            btnFALogin.TabIndex = 0;
            btnFALogin.Text = "Login";
            btnFALogin.UseVisualStyleBackColor = true;
            btnFALogin.Click += btnFALogin_Click;
            // 
            // stepFinish
            // 
            stepFinish.Controls.Add(cbSaveSettings);
            stepFinish.Controls.Add(label11);
            stepFinish.Location = new Point(4, 25);
            stepFinish.Name = "stepFinish";
            stepFinish.Padding = new Padding(50, 50, 3, 3);
            stepFinish.Size = new Size(473, 476);
            stepFinish.TabIndex = 5;
            stepFinish.Text = "7";
            stepFinish.UseVisualStyleBackColor = true;
            // 
            // cbSaveSettings
            // 
            cbSaveSettings.AutoSize = true;
            cbSaveSettings.Checked = true;
            cbSaveSettings.CheckState = CheckState.Checked;
            cbSaveSettings.Location = new Point(189, 229);
            cbSaveSettings.Name = "cbSaveSettings";
            cbSaveSettings.Size = new Size(94, 19);
            cbSaveSettings.TabIndex = 1;
            cbSaveSettings.Text = "Save settings";
            cbSaveSettings.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(53, 50);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 0;
            label11.Text = "Done!";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.foxinabox;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel1.SetRowSpan(pictureBox1, 2);
            pictureBox1.Size = new Size(197, 551);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 557);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FACkupWizard";
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            fakeWizard.ResumeLayout(false);
            stepUsers.ResumeLayout(false);
            stepUsers.PerformLayout();
            stepSections.ResumeLayout(false);
            stepSections.PerformLayout();
            stepSubTypes.ResumeLayout(false);
            stepSubTypes.PerformLayout();
            stepRatings.ResumeLayout(false);
            stepRatings.PerformLayout();
            stepProxy.ResumeLayout(false);
            stepProxy.PerformLayout();
            panelProxy.ResumeLayout(false);
            panelProxy.PerformLayout();
            stepDlPath.ResumeLayout(false);
            stepDlPath.PerformLayout();
            stepLogin.ResumeLayout(false);
            stepLogin.PerformLayout();
            stepFinish.ResumeLayout(false);
            stepFinish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCancel;
        private Button btnNext;
        private Button btnBack;
        private TabControl fakeWizard;
        private TabPage stepUsers;
        private TabPage stepSections;
        private TabPage stepRatings;
        private TabPage stepProxy;
        private TextBox tbUsers;
        private CheckBox cbBackupWatched;
        private CheckBox cbFavs;
        private CheckBox cbScraps;
        private CheckBox cbGallery;
        private CheckBox cbGeneral;
        private CheckBox cbMature;
        private CheckBox cbAdult;
        private TextBox tbProxyUser;
        private TextBox tbProxyPassword;
        private TextBox tbProxyAddress;
        private CheckBox cbUseProxy;
        private TabPage stepDlPath;
        private Button btnBrowseDest;
        private TextBox tbDlPath;
        private TabPage stepFinish;
        private PictureBox pictureBox1;
        private Button btnStart;
        private TabPage stepLogin;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnFALogin;
        private TabPage stepSubTypes;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private CheckBox cbFlash;
        private CheckBox cbText;
        private CheckBox cbAudio;
        private CheckBox cbImage;
        private Label label10;
        private CheckBox cbOther;
        private Panel panelProxy;
        private Label labelNoSession;
        private Label labelSessionFound;
        private Button btnFinish;
        private Label labelValidating;
        private CheckBox cbSaveSettings;
        private Label label11;
    }
}