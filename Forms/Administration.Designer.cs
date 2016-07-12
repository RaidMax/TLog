namespace TLog.Forms
{
    partial class Administration
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administration));
            this.needActivationList = new System.Windows.Forms.ListBox();
            this.studentInfoPanel = new System.Windows.Forms.Panel();
            this.maxSemesterHours = new System.Windows.Forms.Label();
            this.maxSemesterText = new System.Windows.Forms.TextBox();
            this.classificationDropdown = new System.Windows.Forms.ComboBox();
            this.saveUserButton = new System.Windows.Forms.Button();
            this.lastLoginLabel = new System.Windows.Forms.Label();
            this.totalLoginsLabel = new System.Windows.Forms.Label();
            this.loggedInLabel = new System.Windows.Forms.Label();
            this.activatedCheckBox = new System.Windows.Forms.CheckBox();
            this.secretKeyLabel = new System.Windows.Forms.Label();
            this.secretKeyText = new System.Windows.Forms.TextBox();
            this.tNumLabel = new System.Windows.Forms.Label();
            this.tNumText = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.lNameLabel = new System.Windows.Forms.Label();
            this.lNameText = new System.Windows.Forms.TextBox();
            this.fNamLabel = new System.Windows.Forms.Label();
            this.fNameText = new System.Windows.Forms.TextBox();
            this.studentInfoLabel = new System.Windows.Forms.Label();
            this.searchUserButton = new System.Windows.Forms.Button();
            this.matchedUsersList = new System.Windows.Forms.ListBox();
            this.searchUserText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dailyHoursLabel = new System.Windows.Forms.Label();
            this.weeklyHoursLabel = new System.Windows.Forms.Label();
            this.semesterHoursLabel = new System.Windows.Forms.Label();
            this.hoursList = new System.Windows.Forms.ListBox();
            this.editHoursContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayList = new System.Windows.Forms.ListBox();
            this.weekList = new System.Windows.Forms.ListBox();
            this.studentHourLabel = new System.Windows.Forms.Label();
            this.searchResultLabel = new System.Windows.Forms.Label();
            this.exportTimesheetButton = new System.Windows.Forms.Button();
            this.activationLabel = new System.Windows.Forms.Label();
            this.updatePasskeyButton = new System.Windows.Forms.Button();
            this.searchResultContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.studentInfoPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.editHoursContext.SuspendLayout();
            this.searchResultContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // needActivationList
            // 
            this.needActivationList.FormattingEnabled = true;
            this.needActivationList.Location = new System.Drawing.Point(1006, 35);
            this.needActivationList.Name = "needActivationList";
            this.needActivationList.Size = new System.Drawing.Size(120, 498);
            this.needActivationList.TabIndex = 0;
            this.needActivationList.SelectedIndexChanged += new System.EventHandler(this.needActivationList_SelectedIndexChanged);
            // 
            // studentInfoPanel
            // 
            this.studentInfoPanel.Controls.Add(this.maxSemesterHours);
            this.studentInfoPanel.Controls.Add(this.maxSemesterText);
            this.studentInfoPanel.Controls.Add(this.classificationDropdown);
            this.studentInfoPanel.Controls.Add(this.saveUserButton);
            this.studentInfoPanel.Controls.Add(this.lastLoginLabel);
            this.studentInfoPanel.Controls.Add(this.totalLoginsLabel);
            this.studentInfoPanel.Controls.Add(this.loggedInLabel);
            this.studentInfoPanel.Controls.Add(this.activatedCheckBox);
            this.studentInfoPanel.Controls.Add(this.secretKeyLabel);
            this.studentInfoPanel.Controls.Add(this.secretKeyText);
            this.studentInfoPanel.Controls.Add(this.tNumLabel);
            this.studentInfoPanel.Controls.Add(this.tNumText);
            this.studentInfoPanel.Controls.Add(this.emailLabel);
            this.studentInfoPanel.Controls.Add(this.emailText);
            this.studentInfoPanel.Controls.Add(this.usernameLabel);
            this.studentInfoPanel.Controls.Add(this.usernameText);
            this.studentInfoPanel.Controls.Add(this.lNameLabel);
            this.studentInfoPanel.Controls.Add(this.lNameText);
            this.studentInfoPanel.Controls.Add(this.fNamLabel);
            this.studentInfoPanel.Controls.Add(this.fNameText);
            this.studentInfoPanel.Location = new System.Drawing.Point(12, 34);
            this.studentInfoPanel.Name = "studentInfoPanel";
            this.studentInfoPanel.Size = new System.Drawing.Size(224, 614);
            this.studentInfoPanel.TabIndex = 1;
            // 
            // maxSemesterHours
            // 
            this.maxSemesterHours.AutoSize = true;
            this.maxSemesterHours.Location = new System.Drawing.Point(5, 359);
            this.maxSemesterHours.Margin = new System.Windows.Forms.Padding(5);
            this.maxSemesterHours.Name = "maxSemesterHours";
            this.maxSemesterHours.Size = new System.Drawing.Size(105, 13);
            this.maxSemesterHours.TabIndex = 19;
            this.maxSemesterHours.Text = "Max Semester Hours";
            // 
            // maxSemesterText
            // 
            this.maxSemesterText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.maxSemesterText.Location = new System.Drawing.Point(7, 383);
            this.maxSemesterText.Margin = new System.Windows.Forms.Padding(5);
            this.maxSemesterText.Name = "maxSemesterText";
            this.maxSemesterText.Size = new System.Drawing.Size(103, 20);
            this.maxSemesterText.TabIndex = 18;
            // 
            // classificationDropdown
            // 
            this.classificationDropdown.FormattingEnabled = true;
            this.classificationDropdown.Location = new System.Drawing.Point(7, 450);
            this.classificationDropdown.Name = "classificationDropdown";
            this.classificationDropdown.Size = new System.Drawing.Size(212, 21);
            this.classificationDropdown.TabIndex = 17;
            // 
            // saveUserButton
            // 
            this.saveUserButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.saveUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveUserButton.Location = new System.Drawing.Point(8, 476);
            this.saveUserButton.Name = "saveUserButton";
            this.saveUserButton.Size = new System.Drawing.Size(211, 23);
            this.saveUserButton.TabIndex = 16;
            this.saveUserButton.Text = "Save";
            this.saveUserButton.UseVisualStyleBackColor = false;
            this.saveUserButton.Click += new System.EventHandler(this.saveUserButton_Click);
            // 
            // lastLoginLabel
            // 
            this.lastLoginLabel.AutoSize = true;
            this.lastLoginLabel.Location = new System.Drawing.Point(5, 410);
            this.lastLoginLabel.Name = "lastLoginLabel";
            this.lastLoginLabel.Size = new System.Drawing.Size(59, 13);
            this.lastLoginLabel.TabIndex = 15;
            this.lastLoginLabel.Text = "Last Login:";
            // 
            // totalLoginsLabel
            // 
            this.totalLoginsLabel.AutoSize = true;
            this.totalLoginsLabel.Location = new System.Drawing.Point(5, 430);
            this.totalLoginsLabel.Name = "totalLoginsLabel";
            this.totalLoginsLabel.Size = new System.Drawing.Size(68, 13);
            this.totalLoginsLabel.TabIndex = 14;
            this.totalLoginsLabel.Text = "Total Logins:";
            // 
            // loggedInLabel
            // 
            this.loggedInLabel.AutoSize = true;
            this.loggedInLabel.Location = new System.Drawing.Point(135, 430);
            this.loggedInLabel.Name = "loggedInLabel";
            this.loggedInLabel.Size = new System.Drawing.Size(58, 13);
            this.loggedInLabel.TabIndex = 13;
            this.loggedInLabel.Text = "Logged In:";
            // 
            // activatedCheckBox
            // 
            this.activatedCheckBox.AutoSize = true;
            this.activatedCheckBox.Location = new System.Drawing.Point(138, 385);
            this.activatedCheckBox.Name = "activatedCheckBox";
            this.activatedCheckBox.Size = new System.Drawing.Size(71, 17);
            this.activatedCheckBox.TabIndex = 12;
            this.activatedCheckBox.Text = "Activated";
            this.activatedCheckBox.UseVisualStyleBackColor = true;
            // 
            // secretKeyLabel
            // 
            this.secretKeyLabel.AutoSize = true;
            this.secretKeyLabel.Location = new System.Drawing.Point(5, 303);
            this.secretKeyLabel.Margin = new System.Windows.Forms.Padding(5);
            this.secretKeyLabel.Name = "secretKeyLabel";
            this.secretKeyLabel.Size = new System.Drawing.Size(63, 13);
            this.secretKeyLabel.TabIndex = 11;
            this.secretKeyLabel.Text = "Check-in ID";
            // 
            // secretKeyText
            // 
            this.secretKeyText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.secretKeyText.Location = new System.Drawing.Point(7, 327);
            this.secretKeyText.Margin = new System.Windows.Forms.Padding(5);
            this.secretKeyText.Name = "secretKeyText";
            this.secretKeyText.Size = new System.Drawing.Size(212, 20);
            this.secretKeyText.TabIndex = 10;
            // 
            // tNumLabel
            // 
            this.tNumLabel.AutoSize = true;
            this.tNumLabel.Location = new System.Drawing.Point(5, 243);
            this.tNumLabel.Margin = new System.Windows.Forms.Padding(5);
            this.tNumLabel.Name = "tNumLabel";
            this.tNumLabel.Size = new System.Drawing.Size(54, 13);
            this.tNumLabel.TabIndex = 9;
            this.tNumLabel.Text = "T Number";
            // 
            // tNumText
            // 
            this.tNumText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tNumText.Location = new System.Drawing.Point(7, 267);
            this.tNumText.Margin = new System.Windows.Forms.Padding(5);
            this.tNumText.Name = "tNumText";
            this.tNumText.Size = new System.Drawing.Size(212, 20);
            this.tNumText.TabIndex = 8;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(5, 185);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(5);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 7;
            this.emailLabel.Text = "Email";
            // 
            // emailText
            // 
            this.emailText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.emailText.Location = new System.Drawing.Point(7, 209);
            this.emailText.Margin = new System.Windows.Forms.Padding(5);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(212, 20);
            this.emailText.TabIndex = 6;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(5, 125);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(5);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "Username";
            // 
            // usernameText
            // 
            this.usernameText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.usernameText.Location = new System.Drawing.Point(7, 149);
            this.usernameText.Margin = new System.Windows.Forms.Padding(5);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(212, 20);
            this.usernameText.TabIndex = 4;
            // 
            // lNameLabel
            // 
            this.lNameLabel.AutoSize = true;
            this.lNameLabel.Location = new System.Drawing.Point(5, 64);
            this.lNameLabel.Margin = new System.Windows.Forms.Padding(5);
            this.lNameLabel.Name = "lNameLabel";
            this.lNameLabel.Size = new System.Drawing.Size(58, 13);
            this.lNameLabel.TabIndex = 3;
            this.lNameLabel.Text = "Last Name";
            // 
            // lNameText
            // 
            this.lNameText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lNameText.Location = new System.Drawing.Point(7, 88);
            this.lNameText.Margin = new System.Windows.Forms.Padding(5);
            this.lNameText.Name = "lNameText";
            this.lNameText.Size = new System.Drawing.Size(212, 20);
            this.lNameText.TabIndex = 2;
            // 
            // fNamLabel
            // 
            this.fNamLabel.AutoSize = true;
            this.fNamLabel.Location = new System.Drawing.Point(5, 5);
            this.fNamLabel.Margin = new System.Windows.Forms.Padding(5);
            this.fNamLabel.Name = "fNamLabel";
            this.fNamLabel.Size = new System.Drawing.Size(57, 13);
            this.fNamLabel.TabIndex = 1;
            this.fNamLabel.Text = "First Name";
            // 
            // fNameText
            // 
            this.fNameText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fNameText.Location = new System.Drawing.Point(7, 29);
            this.fNameText.Margin = new System.Windows.Forms.Padding(5);
            this.fNameText.Name = "fNameText";
            this.fNameText.Size = new System.Drawing.Size(212, 20);
            this.fNameText.TabIndex = 0;
            // 
            // studentInfoLabel
            // 
            this.studentInfoLabel.AutoSize = true;
            this.studentInfoLabel.Location = new System.Drawing.Point(73, 12);
            this.studentInfoLabel.Name = "studentInfoLabel";
            this.studentInfoLabel.Size = new System.Drawing.Size(99, 13);
            this.studentInfoLabel.TabIndex = 2;
            this.studentInfoLabel.Text = "Student Information";
            // 
            // searchUserButton
            // 
            this.searchUserButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.searchUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchUserButton.Location = new System.Drawing.Point(1132, 510);
            this.searchUserButton.Name = "searchUserButton";
            this.searchUserButton.Size = new System.Drawing.Size(120, 23);
            this.searchUserButton.TabIndex = 3;
            this.searchUserButton.Text = "Search";
            this.searchUserButton.UseVisualStyleBackColor = false;
            this.searchUserButton.Click += new System.EventHandler(this.searchUserButton_Click);
            // 
            // matchedUsersList
            // 
            this.matchedUsersList.ContextMenuStrip = this.searchResultContextMenu;
            this.matchedUsersList.FormattingEnabled = true;
            this.matchedUsersList.Location = new System.Drawing.Point(1132, 35);
            this.matchedUsersList.Name = "matchedUsersList";
            this.matchedUsersList.Size = new System.Drawing.Size(120, 433);
            this.matchedUsersList.TabIndex = 4;
            this.matchedUsersList.Click += new System.EventHandler(this.matchedUsersList_Click);
            this.matchedUsersList.SelectedIndexChanged += new System.EventHandler(this.matchedUsersList_SelectedIndexChanged);
            // 
            // searchUserText
            // 
            this.searchUserText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchUserText.Location = new System.Drawing.Point(1132, 484);
            this.searchUserText.Name = "searchUserText";
            this.searchUserText.Size = new System.Drawing.Size(120, 20);
            this.searchUserText.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dailyHoursLabel);
            this.panel1.Controls.Add(this.weeklyHoursLabel);
            this.panel1.Controls.Add(this.semesterHoursLabel);
            this.panel1.Controls.Add(this.hoursList);
            this.panel1.Controls.Add(this.dayList);
            this.panel1.Controls.Add(this.weekList);
            this.panel1.Location = new System.Drawing.Point(253, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 516);
            this.panel1.TabIndex = 6;
            // 
            // dailyHoursLabel
            // 
            this.dailyHoursLabel.AutoSize = true;
            this.dailyHoursLabel.Location = new System.Drawing.Point(131, 190);
            this.dailyHoursLabel.Name = "dailyHoursLabel";
            this.dailyHoursLabel.Size = new System.Drawing.Size(44, 13);
            this.dailyHoursLabel.TabIndex = 5;
            this.dailyHoursLabel.Text = "0 Hours";
            // 
            // weeklyHoursLabel
            // 
            this.weeklyHoursLabel.AutoSize = true;
            this.weeklyHoursLabel.Location = new System.Drawing.Point(131, 11);
            this.weeklyHoursLabel.Name = "weeklyHoursLabel";
            this.weeklyHoursLabel.Size = new System.Drawing.Size(44, 13);
            this.weeklyHoursLabel.TabIndex = 4;
            this.weeklyHoursLabel.Text = "0 Hours";
            // 
            // semesterHoursLabel
            // 
            this.semesterHoursLabel.AutoSize = true;
            this.semesterHoursLabel.Location = new System.Drawing.Point(3, 11);
            this.semesterHoursLabel.Name = "semesterHoursLabel";
            this.semesterHoursLabel.Size = new System.Drawing.Size(67, 13);
            this.semesterHoursLabel.TabIndex = 3;
            this.semesterHoursLabel.Text = "Semester/All";
            // 
            // hoursList
            // 
            this.hoursList.ContextMenuStrip = this.editHoursContext;
            this.hoursList.FormattingEnabled = true;
            this.hoursList.Location = new System.Drawing.Point(131, 209);
            this.hoursList.Name = "hoursList";
            this.hoursList.Size = new System.Drawing.Size(120, 290);
            this.hoursList.TabIndex = 2;
            // 
            // editHoursContext
            // 
            this.editHoursContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.addToolStripMenuItem});
            this.editHoursContext.Name = "editHoursContext";
            this.editHoursContext.Size = new System.Drawing.Size(108, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // dayList
            // 
            this.dayList.FormattingEnabled = true;
            this.dayList.Location = new System.Drawing.Point(131, 27);
            this.dayList.Name = "dayList";
            this.dayList.Size = new System.Drawing.Size(120, 160);
            this.dayList.TabIndex = 1;
            this.dayList.SelectedIndexChanged += new System.EventHandler(this.dayList_SelectedIndexChanged);
            // 
            // weekList
            // 
            this.weekList.FormattingEnabled = true;
            this.weekList.Location = new System.Drawing.Point(5, 27);
            this.weekList.Name = "weekList";
            this.weekList.Size = new System.Drawing.Size(120, 472);
            this.weekList.TabIndex = 0;
            this.weekList.SelectedIndexChanged += new System.EventHandler(this.weekList_SelectedIndexChanged);
            // 
            // studentHourLabel
            // 
            this.studentHourLabel.AutoSize = true;
            this.studentHourLabel.Location = new System.Drawing.Point(346, 12);
            this.studentHourLabel.Name = "studentHourLabel";
            this.studentHourLabel.Size = new System.Drawing.Size(75, 13);
            this.studentHourLabel.TabIndex = 7;
            this.studentHourLabel.Text = "Student Hours";
            // 
            // searchResultLabel
            // 
            this.searchResultLabel.AutoSize = true;
            this.searchResultLabel.Location = new System.Drawing.Point(1153, 12);
            this.searchResultLabel.Name = "searchResultLabel";
            this.searchResultLabel.Size = new System.Drawing.Size(79, 13);
            this.searchResultLabel.TabIndex = 9;
            this.searchResultLabel.Text = "Search Results";
            // 
            // exportTimesheetButton
            // 
            this.exportTimesheetButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.exportTimesheetButton.Enabled = false;
            this.exportTimesheetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exportTimesheetButton.Location = new System.Drawing.Point(696, 243);
            this.exportTimesheetButton.Name = "exportTimesheetButton";
            this.exportTimesheetButton.Size = new System.Drawing.Size(130, 23);
            this.exportTimesheetButton.TabIndex = 10;
            this.exportTimesheetButton.Text = "Export Timesheet";
            this.exportTimesheetButton.UseVisualStyleBackColor = false;
            this.exportTimesheetButton.Click += new System.EventHandler(this.exportTimesheetButton_Click);
            // 
            // activationLabel
            // 
            this.activationLabel.AutoSize = true;
            this.activationLabel.Location = new System.Drawing.Point(1013, 12);
            this.activationLabel.Name = "activationLabel";
            this.activationLabel.Size = new System.Drawing.Size(102, 13);
            this.activationLabel.TabIndex = 11;
            this.activationLabel.Text = "Activation Requests";
            // 
            // updatePasskeyButton
            // 
            this.updatePasskeyButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.updatePasskeyButton.Enabled = false;
            this.updatePasskeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updatePasskeyButton.Location = new System.Drawing.Point(696, 272);
            this.updatePasskeyButton.Name = "updatePasskeyButton";
            this.updatePasskeyButton.Size = new System.Drawing.Size(130, 23);
            this.updatePasskeyButton.TabIndex = 12;
            this.updatePasskeyButton.Text = "Update Passkey";
            this.updatePasskeyButton.UseVisualStyleBackColor = false;
            this.updatePasskeyButton.Click += new System.EventHandler(this.updatePasskeyButton_Click);
            // 
            // searchResultContextMenu
            // 
            this.searchResultContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
            this.searchResultContextMenu.Name = "searchResultContextMenu";
            this.searchResultContextMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // Administration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 542);
            this.Controls.Add(this.updatePasskeyButton);
            this.Controls.Add(this.activationLabel);
            this.Controls.Add(this.exportTimesheetButton);
            this.Controls.Add(this.searchResultLabel);
            this.Controls.Add(this.studentHourLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchUserText);
            this.Controls.Add(this.matchedUsersList);
            this.Controls.Add(this.searchUserButton);
            this.Controls.Add(this.studentInfoLabel);
            this.Controls.Add(this.studentInfoPanel);
            this.Controls.Add(this.needActivationList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Administration";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Administration_FormClosing);
            this.studentInfoPanel.ResumeLayout(false);
            this.studentInfoPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.editHoursContext.ResumeLayout(false);
            this.searchResultContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox needActivationList;
        private System.Windows.Forms.Panel studentInfoPanel;
        private System.Windows.Forms.Label fNamLabel;
        private System.Windows.Forms.TextBox fNameText;
        private System.Windows.Forms.Label studentInfoLabel;
        private System.Windows.Forms.CheckBox activatedCheckBox;
        private System.Windows.Forms.Label secretKeyLabel;
        private System.Windows.Forms.TextBox secretKeyText;
        private System.Windows.Forms.Label tNumLabel;
        private System.Windows.Forms.TextBox tNumText;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Label lNameLabel;
        private System.Windows.Forms.TextBox lNameText;
        private System.Windows.Forms.Label loggedInLabel;
        private System.Windows.Forms.Button saveUserButton;
        private System.Windows.Forms.Label lastLoginLabel;
        private System.Windows.Forms.Label totalLoginsLabel;
        private System.Windows.Forms.ComboBox classificationDropdown;
        private System.Windows.Forms.Button searchUserButton;
        private System.Windows.Forms.ListBox matchedUsersList;
        private System.Windows.Forms.TextBox searchUserText;
        private System.Windows.Forms.Label maxSemesterHours;
        private System.Windows.Forms.TextBox maxSemesterText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox dayList;
        private System.Windows.Forms.ListBox weekList;
        private System.Windows.Forms.Label dailyHoursLabel;
        private System.Windows.Forms.Label weeklyHoursLabel;
        private System.Windows.Forms.Label studentHourLabel;
        private System.Windows.Forms.Label semesterHoursLabel;
        private System.Windows.Forms.ContextMenuStrip editHoursContext;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ListBox hoursList;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.Label searchResultLabel;
        private System.Windows.Forms.Button exportTimesheetButton;
        private System.Windows.Forms.Label activationLabel;
        private System.Windows.Forms.Button updatePasskeyButton;
        private System.Windows.Forms.ContextMenuStrip searchResultContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
    }
}