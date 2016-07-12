namespace TLog.Forms
{
    partial class QuickInfo
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
            this.namePanel = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.weeklyHoursLabel = new System.Windows.Forms.Label();
            this.hoursWorkedLabel = new System.Windows.Forms.Label();
            this.totalSemesterHours = new System.Windows.Forms.Label();
            this.namePanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // namePanel
            // 
            this.namePanel.AutoSize = true;
            this.namePanel.BackColor = System.Drawing.Color.Transparent;
            this.namePanel.BackgroundImage = global::TLog.Properties.Resources.login_overlay;
            this.namePanel.Controls.Add(this.nameLabel);
            this.namePanel.Location = new System.Drawing.Point(0, 50);
            this.namePanel.Margin = new System.Windows.Forms.Padding(0);
            this.namePanel.Name = "namePanel";
            this.namePanel.Size = new System.Drawing.Size(800, 100);
            this.namePanel.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(9, 7);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(492, 86);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "HELLO {NAME}";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoPanel
            // 
            this.infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPanel.BackColor = System.Drawing.Color.Transparent;
            this.infoPanel.BackgroundImage = global::TLog.Properties.Resources.login_overlay;
            this.infoPanel.Controls.Add(this.totalSemesterHours);
            this.infoPanel.Controls.Add(this.weeklyHoursLabel);
            this.infoPanel.Controls.Add(this.hoursWorkedLabel);
            this.infoPanel.Location = new System.Drawing.Point(121, 216);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(1171, 472);
            this.infoPanel.TabIndex = 1;
            // 
            // weeklyHoursLabel
            // 
            this.weeklyHoursLabel.AutoSize = true;
            this.weeklyHoursLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weeklyHoursLabel.ForeColor = System.Drawing.Color.White;
            this.weeklyHoursLabel.Location = new System.Drawing.Point(14, 92);
            this.weeklyHoursLabel.Name = "weeklyHoursLabel";
            this.weeklyHoursLabel.Size = new System.Drawing.Size(596, 65);
            this.weeklyHoursLabel.TabIndex = 1;
            this.weeklyHoursLabel.Text = "_ Hours Worked This Week";
            // 
            // hoursWorkedLabel
            // 
            this.hoursWorkedLabel.AutoSize = true;
            this.hoursWorkedLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoursWorkedLabel.ForeColor = System.Drawing.Color.White;
            this.hoursWorkedLabel.Location = new System.Drawing.Point(14, 18);
            this.hoursWorkedLabel.Name = "hoursWorkedLabel";
            this.hoursWorkedLabel.Size = new System.Drawing.Size(367, 65);
            this.hoursWorkedLabel.TabIndex = 0;
            this.hoursWorkedLabel.Text = "_ Hours Worked";
            // 
            // totalSemesterHours
            // 
            this.totalSemesterHours.AutoSize = true;
            this.totalSemesterHours.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSemesterHours.ForeColor = System.Drawing.Color.White;
            this.totalSemesterHours.Location = new System.Drawing.Point(14, 166);
            this.totalSemesterHours.Name = "totalSemesterHours";
            this.totalSemesterHours.Size = new System.Drawing.Size(661, 65);
            this.totalSemesterHours.TabIndex = 2;
            this.totalSemesterHours.Text = "_ current/total semester hours";
            // 
            // QuickInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TLog.Properties.Resources.login_bg;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.namePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuickInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.namePanel.ResumeLayout(false);
            this.namePanel.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel namePanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label hoursWorkedLabel;
        private System.Windows.Forms.Label weeklyHoursLabel;
        private System.Windows.Forms.Label totalSemesterHours;
    }
}