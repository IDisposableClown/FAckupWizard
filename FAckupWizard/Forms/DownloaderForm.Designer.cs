namespace FAckupWizard.Forms
{
    partial class DownloaderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            prgUsers = new ProgressBar();
            prgFiles = new ProgressBar();
            logView = new TextBox();
            btnCacnel = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnClose = new Button();
            labelUser = new Label();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // prgUsers
            // 
            prgUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            prgUsers.Location = new Point(12, 27);
            prgUsers.Name = "prgUsers";
            prgUsers.Size = new Size(605, 21);
            prgUsers.TabIndex = 0;
            // 
            // prgFiles
            // 
            prgFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            prgFiles.Location = new Point(12, 54);
            prgFiles.Name = "prgFiles";
            prgFiles.Size = new Size(605, 21);
            prgFiles.TabIndex = 1;
            // 
            // logView
            // 
            logView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logView.Location = new Point(12, 96);
            logView.Multiline = true;
            logView.Name = "logView";
            logView.ReadOnly = true;
            logView.ScrollBars = ScrollBars.Vertical;
            logView.Size = new Size(605, 335);
            logView.TabIndex = 2;
            // 
            // btnCacnel
            // 
            btnCacnel.Location = new Point(116, 3);
            btnCacnel.Name = "btnCacnel";
            btnCacnel.Size = new Size(81, 23);
            btnCacnel.TabIndex = 3;
            btnCacnel.Text = "Cancel";
            btnCacnel.UseVisualStyleBackColor = true;
            btnCacnel.Click += btnCacnel_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(btnCacnel);
            flowLayoutPanel1.Controls.Add(btnClose);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(417, 437);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 32);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(35, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Visible = false;
            btnClose.Click += btnClose_Click;
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new Point(12, 9);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(0, 15);
            labelUser.TabIndex = 6;
            // 
            // DownloaderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 481);
            ControlBox = false;
            Controls.Add(labelUser);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(logView);
            Controls.Add(prgFiles);
            Controls.Add(prgUsers);
            MinimizeBox = false;
            MinimumSize = new Size(645, 520);
            Name = "DownloaderForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Downloader";
            Shown += DownloaderForm_Shown;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar prgUsers;
        private ProgressBar prgFiles;
        private TextBox logView;
        private Button btnCacnel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnClose;
        private Label label1;
        private Label labelUser;
    }
}