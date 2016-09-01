namespace TLog
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.userIDTextbox = new System.Windows.Forms.TextBox();
            this.loginCaptionLabel = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.loginButton = new System.Windows.Forms.Button();
            this.helpTipLabel = new System.Windows.Forms.Label();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.connectionIndicatorIcon = new System.Windows.Forms.Label();
            this.activeUserList = new System.Windows.Forms.ListBox();
            this.loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // userIDTextbox
            // 
            this.userIDTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userIDTextbox.BackColor = System.Drawing.Color.Gainsboro;
            this.userIDTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userIDTextbox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIDTextbox.Location = new System.Drawing.Point(390, 37);
            this.userIDTextbox.Name = "userIDTextbox";
            this.userIDTextbox.PasswordChar = '*';
            this.userIDTextbox.Size = new System.Drawing.Size(500, 26);
            this.userIDTextbox.TabIndex = 0;
            this.userIDTextbox.TextChanged += new System.EventHandler(this.userIDTextbox_TextChanged);
            this.userIDTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.userIDTextbox_KeyUp);
            // 
            // loginCaptionLabel
            // 
            this.loginCaptionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginCaptionLabel.AutoSize = true;
            this.loginCaptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginCaptionLabel.ForeColor = System.Drawing.Color.White;
            this.loginCaptionLabel.Location = new System.Drawing.Point(387, 17);
            this.loginCaptionLabel.Name = "loginCaptionLabel";
            this.loginCaptionLabel.Size = new System.Drawing.Size(108, 17);
            this.loginCaptionLabel.TabIndex = 1;
            this.loginCaptionLabel.Text = "T# or Eagle Card";
            // 
            // loginPanel
            // 
            this.loginPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loginPanel.BackColor = System.Drawing.Color.Transparent;
            this.loginPanel.BackgroundImage = global::TLog.Properties.Resources.login_overlay;
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Controls.Add(this.helpTipLabel);
            this.loginPanel.Controls.Add(this.loginCaptionLabel);
            this.loginPanel.Controls.Add(this.userIDTextbox);
            this.loginPanel.Location = new System.Drawing.Point(0, 310);
            this.loginPanel.Margin = new System.Windows.Forms.Padding(0);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(1280, 100);
            this.loginPanel.TabIndex = 2;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loginButton.BackgroundImage")));
            this.loginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.ForeColor = System.Drawing.Color.Transparent;
            this.loginButton.Location = new System.Drawing.Point(896, 37);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(26, 26);
            this.loginButton.TabIndex = 4;
            this.loginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // helpTipLabel
            // 
            this.helpTipLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.helpTipLabel.AutoSize = true;
            this.helpTipLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpTipLabel.ForeColor = System.Drawing.Color.White;
            this.helpTipLabel.Location = new System.Drawing.Point(387, 66);
            this.helpTipLabel.Name = "helpTipLabel";
            this.helpTipLabel.Size = new System.Drawing.Size(106, 17);
            this.helpTipLabel.TabIndex = 3;
            this.helpTipLabel.Text = "Press F1 for help";
            // 
            // logoPicture
            // 
            this.logoPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoPicture.BackColor = System.Drawing.Color.Transparent;
            this.logoPicture.Image = global::TLog.Properties.Resources.CareerServicesLogo_Horizontal;
            this.logoPicture.Location = new System.Drawing.Point(224, 77);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(880, 165);
            this.logoPicture.TabIndex = 4;
            this.logoPicture.TabStop = false;
            // 
            // errorMessageLabel
            // 
            this.errorMessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorMessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorMessageLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMessageLabel.Location = new System.Drawing.Point(0, 0);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(1280, 720);
            this.errorMessageLabel.TabIndex = 5;
            this.errorMessageLabel.Text = "ERROR";
            this.errorMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.errorMessageLabel.Visible = false;
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currentTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentTimeLabel.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTimeLabel.Location = new System.Drawing.Point(1064, 9);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(193, 54);
            this.currentTimeLabel.TabIndex = 6;
            this.currentTimeLabel.Text = "0:00:00";
            this.currentTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // connectionIndicatorIcon
            // 
            this.connectionIndicatorIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connectionIndicatorIcon.BackColor = System.Drawing.Color.Red;
            this.connectionIndicatorIcon.Location = new System.Drawing.Point(-3, 695);
            this.connectionIndicatorIcon.Name = "connectionIndicatorIcon";
            this.connectionIndicatorIcon.Size = new System.Drawing.Size(25, 25);
            this.connectionIndicatorIcon.TabIndex = 7;
            // 
            // activeUserList
            // 
            this.activeUserList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.activeUserList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.activeUserList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeUserList.ForeColor = System.Drawing.Color.White;
            this.activeUserList.FormattingEnabled = true;
            this.activeUserList.Location = new System.Drawing.Point(0, 0);
            this.activeUserList.Name = "activeUserList";
            this.activeUserList.Size = new System.Drawing.Size(120, 182);
            this.activeUserList.TabIndex = 8;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::TLog.Properties.Resources.login_bg;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.errorMessageLabel);
            this.Controls.Add(this.activeUserList);
            this.Controls.Add(this.connectionIndicatorIcon);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.logoPicture);
            this.Controls.Add(this.loginPanel);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to TLog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox userIDTextbox;
        private System.Windows.Forms.Label loginCaptionLabel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label helpTipLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Label errorMessageLabel;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label connectionIndicatorIcon;
        private System.Windows.Forms.ListBox activeUserList;
    }
}

