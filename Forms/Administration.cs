using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TLog.Forms
{
    public partial class Administration : Form
    {
        private Users.User currentUser;
        private Users.User selectedUser;
        private Timer refresh = new Timer();

        public Administration()
        {
            InitializeComponent();
            populateData();
            currentUser = Manager.Main.Instance.lastUser;
            Text += " - " + currentUser;

            refresh.Interval = 30000;
            refresh.Tick += autoRefreshData;
            refresh.Start();
        }

        private void Administration_FormClosing(object sender, FormClosingEventArgs e)
        {
           currentUser.logOff();
            refresh.Stop();
        }

        public void autoRefreshData(object sender, EventArgs e)
        {
            foreach (var u in Manager.Main.Instance.archivedUsers.Where(u => u.activationRequested == true))
                needActivationList.Items.Add(u);

            searchUserButton_Click(sender, e);
        }

        public void populateData()
        {
            classificationDropdown.Items.Clear();
            hoursIssueList.Items.Clear();

            foreach (var c in Enum.GetValues(typeof(Users.User.Type)))
                classificationDropdown.Items.Add(c);

            foreach (Users.StudentWorker s in Manager.Main.Instance.activeUsers.FindAll(x => x.Class == Users.User.Type.Student_Worker && ((Users.StudentWorker)(x)).hoursIssue))
                hoursIssueList.Items.Add(s);
        }

        private void needActivationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Users.StudentWorker currentlySelected = (Users.StudentWorker)needActivationList.SelectedItem;
            populateUserInfo(currentlySelected);
        }

        private void populateUserInfo(Users.User currentlySelected)
        {
            fNameText.Text = currentlySelected.firstName;
            lNameText.Text = currentlySelected.lastName;
            usernameText.Text = currentlySelected.userName;
            emailText.Text = currentlySelected.Email;
            tNumText.Text = currentlySelected.ID.ToString();
            secretKeyText.Text = currentlySelected.secretKey.ToString();
            activatedCheckBox.Checked = (currentlySelected.Activated) ? true : false;

            if (currentlySelected.Activated)
                activatedCheckBox.CheckState = CheckState.Checked;
            else
                activatedCheckBox.CheckState = CheckState.Unchecked;

            if (currentlySelected.Class == Users.User.Type.Student_Worker)
            {
                maxSemesterText.Text = ((Users.StudentWorker)currentlySelected).maxHoursPerSemester.ToString();
                populateStudentWorkHours((Users.StudentWorker)currentlySelected);
                semesterHoursLabel.Text = Math.Round(((Users.StudentWorker)currentlySelected).totalHours(), 1).ToString() + "/" + ((Users.StudentWorker)currentlySelected).maxHoursPerSemester + " hours";
            }

            if (currentlySelected.loggedIn)
                loggedInLabel.Text = "Logged In: True";
            else
                loggedInLabel.Text = "Logged In: False";

            totalLoginsLabel.Text = "Total Logins: " + currentlySelected.totalLogins;
            lastLoginLabel.Text = "Last Login: " + currentlySelected.lastLogon.ToString("M/d/yy h:mm tt");

            classificationDropdown.SelectedIndex = classificationDropdown.Items.IndexOf(currentlySelected.Class);

            exportTimesheetButton.Enabled = true;
            saveUserButton.Enabled = true;
            updatePasskeyButton.Enabled = true;


            Manager.Main.Instance.pendingUpload = true;
        }

        private void populateStudentWorkHours(Users.StudentWorker sw)
        {
            weekList.Items.Clear();
            foreach (var w in sw.weeksWorked.Keys.OrderBy(x => DateTime.Parse(x).Date).Reverse())
                weekList.Items.Add(sw.weeksWorked[w]);
            dayList.Items.Clear();
            hoursList.Items.Clear();
        }

        private void clearUserInfo()
        {
            fNameText.Text = "";
            lNameText.Text = "";
            usernameText.Text = "";
            emailText.Text = "";
            tNumText.Text = "";
            secretKeyText.Text = "";
            activatedCheckBox.Checked = false;
            maxSemesterText.Text = "";

            loggedInLabel.Text = "Logged In: ";
            totalLoginsLabel.Text = "Total Logins: ";
            lastLoginLabel.Text = "Last Login: ";

            semesterHoursLabel.Text = "0 hours";
            weeklyHoursLabel.Text = "0 hours";
            dailyHoursLabel.Text = "0 hours";

            classificationDropdown.SelectedItem = null;

            hoursList.Items.Clear();
            dayList.Items.Clear();
            weekList.Items.Clear();

            exportTimesheetButton.Enabled = false;
            saveUserButton.Enabled = false;
            updatePasskeyButton.Enabled = false;

            needActivationList.Items.Clear();
            matchedUsersList.Items.Clear();
            matchedUsersList.ClearSelected();

            searchUserText.Text = "";

            populateData();
        }

        private void saveUserButton_Click(object sender, EventArgs e)
        {
            if (tNumText.Text.Length > 0)
            {
                Users.User oldUser = null;
                try
                {
                    oldUser = Manager.Main.Instance.activeUsers.Find(u => u.ID.Equals(Users.TNumber.convertTo(tNumText.Text)));
                    if (oldUser == null)
                        oldUser = Manager.Main.Instance.archivedUsers.Find(u => u.ID.Equals(Users.TNumber.convertTo(tNumText.Text)));
                }
                catch (FormatException)
                {
                    return;
                }

                if (classificationDropdown.SelectedItem == null)
                {
                    MessageBox.Show("Please select a valid user type.", "Invalid User!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int semesterHours = 0;
                try
                {
                    if ((Users.User.Type)classificationDropdown.SelectedItem == Users.User.Type.Student_Worker)
                        semesterHours = Convert.ToInt32(maxSemesterText.Text);
                }

                catch (Exception)
                {
                    MessageBox.Show("Please enter valid max semester hours.", "Invalid Semester Hours!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                long secretKey = 0;

                try
                {
                    secretKey = Convert.ToInt64(secretKeyText.Text);
                }

                catch (Exception)
                {
                    MessageBox.Show("Please enter a numerical check-in id.", "Invalid secret key!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (oldUser == null)
                {
                    Debug.Log("Saved user does not exist, creating new...");
                    Users.User newUser;

                    var result = MessageBox.Show("This user does not currently exist. Would you like to add a new user?", "User does not exist!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        Debug.Log("User cancelled new user add");
                        return;
                    }

                    if ((Users.User.Type)classificationDropdown.SelectedItem == Users.User.Type.Student_Worker)
                    {
                        newUser = new Users.StudentWorker(fNameText.Text, lNameText.Text, tNumText.Text, secretKey, usernameText.Text, emailText.Text, semesterHours);
                        if (activatedCheckBox.Checked)
                        {
                            newUser.Activate();
                            Manager.Main.Instance.activeUsers.Add(newUser);
                        }

                        else
                            Manager.Main.Instance.archivedUsers.Add(newUser);
                    }

                    else
                    {
                        newUser = new Users.Administrator(fNameText.Text, lNameText.Text, tNumText.Text, secretKey, usernameText.Text, emailText.Text);
                        if (activatedCheckBox.Checked)
                        {
                            newUser.Activate();
                            Manager.Main.Instance.activeUsers.Add(newUser);
                        }

                        else
                        {
                            newUser.Deactivate();
                            Manager.Main.Instance.archivedUsers.Add(newUser);
                        }

                    }

                    Debug.Log("User {0}({1}) created by {2}", newUser, newUser.Class, currentUser);
                }

                else
                {
                    Debug.Log("Saving user modifications...");
                    if (activatedCheckBox.CheckState == CheckState.Checked && !oldUser.Activated)
                    {
                        oldUser.Activate();  
                        Manager.Main.Instance.activeUsers.Add(oldUser);
                    }
                    else if (activatedCheckBox.CheckState != CheckState.Checked)
                    {
                        oldUser.Deactivate();
                        Manager.Main.Instance.activeUsers.RemoveAll(x => x.userName == oldUser.userName);
                    }

                    oldUser.Update(fNameText.Text, lNameText.Text, tNumText.Text, secretKey, usernameText.Text, emailText.Text, (Users.User.Type)classificationDropdown.SelectedItem, semesterHours);
                    Debug.Log("User {0} modified by {1}", oldUser, currentUser);
                }
                clearUserInfo();

                Manager.Main.Instance.pendingUpload = true;
            }
        }

        private void searchUserButton_Click(object sender, EventArgs e)
        {
            if (searchUserText.Text.Length > 0)
            {
                matchedUsersList.Items.Clear();

                var users = Manager.Main.Instance.activeUsers.FindAll(u => u.Search(searchUserText.Text.ToLower()));
                if (users.Count > 0)
                    foreach (var u in users)
                        matchedUsersList.Items.Add(u);
                // we will have duplicate matches if we don't treat active vs archived sepearately
                else
                {
                    users = Manager.Main.Instance.archivedUsers.FindAll(u => u.Search(searchUserText.Text));
                    if (users.Count > 0)
                        foreach (var u in users)
                            matchedUsersList.Items.Add(u);
                }

                Debug.Log(Debug.MessageType.Information, "Retrieved {0} matching users", matchedUsersList.Items.Count);
            }
        }

        private void weekList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weekList.SelectedIndex > -1)
            {
                hoursList.Items.Clear();
                dayList.ClearSelected();
                clearHoursList();

                if (dayList.Items.Count == 0)
                {
                    foreach (var d in Enum.GetValues(typeof(DayOfWeek)))
                        dayList.Items.Add(d);
                }

                var b = ((Schedule.WorkWeek)(weekList.SelectedItem)).weekID;
                weeklyHoursLabel.Text = ((Users.StudentWorker)(selectedUser)).weeklyHours(b) + " hours";
            }
        }

        private void dayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dayList.SelectedIndex > -1)
            {
                // fixme
                hoursList.Items.Clear();
                foreach (var h in ((Schedule.WorkWeek)weekList.SelectedItem).shiftsOnDay((DayOfWeek)dayList.SelectedIndex))
                        hoursList.Items.Add(h);

                var b = ((Schedule.WorkWeek)(weekList.SelectedItem)).weekID;
                dailyHoursLabel.Text = ((Users.StudentWorker)(selectedUser)).dailyHours(b, (DayOfWeek)dayList.SelectedIndex) + " hours";
            }
        }

        private void matchedUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (matchedUsersList.SelectedIndex > -1)
            {
                //clearUserInfo();
                populateUserInfo((Users.User)matchedUsersList.SelectedItem);
                selectedUser = (Users.User)matchedUsersList.SelectedItem;

                updatePasskeyButton.Enabled = true;
            }
        }

        private void clearHoursList()
        {
            // this doesn't need to be cleared. it actually messes things up IF cleared
            //semesterHoursLabel.Text = "0 hours";
            weeklyHoursLabel.Text = "0 hours";
            dailyHoursLabel.Text = "0 hours";
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hoursList.SelectedIndex > -1)
                new DatePicker((Schedule.Shift)hoursList.SelectedItem, this).Show();
            Manager.Main.Instance.pendingUpload = true;
        }

        public void onDatePicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var form = (DatePicker)button.Parent;

            if (form.endDateTimePicker.Value < form.startDateTimePicker.Value)
            {
                MessageBox.Show("Please select a positive amount of time!", "Error picking date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedShift = new Schedule.Shift(form.startDateTimePicker.Value, form.endDateTimePicker.Value);


            // datepicker used to modify hours
            if (selectedShift.timeWorked < (DateTime.Now - DateTime.Now.AddDays(-1)))
            {
                if (form.selectedShift.timeWorked.TotalMinutes > 1)
                    ((Users.StudentWorker)selectedUser).updateShift(form.selectedShift, selectedShift);
                else
                    ((Users.StudentWorker)selectedUser).addShift(selectedShift);
                Debug.Log("User {0} hours were modified by {1}", selectedUser.userName, currentUser.userName);
                populateUserInfo(selectedUser);
            }
            // we're printing a report
            else
            {
                try
                {
                    string fileName = Manager.Export.exportHours((Users.StudentWorker)selectedUser, selectedShift);
                    string filePath = Environment.CurrentDirectory + "\\" + fileName;
                    System.Diagnostics.Process.Start(filePath);
                }

                catch (Manager.ExportException E)
                {
                    Debug.Log(Debug.MessageType.Error, "Could not export timesheet - " + E.Message);
                }

                catch (Exception E)
                {
                    Debug.Log(Debug.MessageType.Error, "Could not open timesheet - " + E.Message);
                }
            }

            form.Close();

            Manager.Main.Instance.pendingUpload = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hoursList.SelectedIndex > -1)
            {
                ((Users.StudentWorker)selectedUser).weeksWorked[Schedule.WorkWeek.workWeekID(((Schedule.Shift)hoursList.SelectedItem).shiftStart)].removeHours(((Schedule.Shift)hoursList.SelectedItem));
                Debug.Log("User {0} hours were deleted by {1}", selectedUser.userName, currentUser.userName);
                populateUserInfo(selectedUser);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (weekList.SelectedIndex > -1 && dayList.SelectedIndex > -1)
            {
                var b = (Schedule.WorkWeek.GetDateTimeOfDayInWeek((DayOfWeek)dayList.SelectedItem, ((Schedule.WorkWeek)(weekList.SelectedItem)).weekID));
                new DatePicker(new Schedule.Shift(b, b), this).Show();
                //populateStudentWorkHours((Users.StudentWorker)selectedUser);
                //Debug.Log("User {0} hours were added to by {1}", selectedUser.userName, currentUser.userName);
            }
            else
            {
                new DatePicker(new Schedule.Shift(DateTime.Now, DateTime.Now), this).Show();
                //populateStudentWorkHours((Users.StudentWorker)selectedUser);
               // Debug.Log("User {0} hours were added to by {1}", selectedUser.userName, currentUser.userName);
            }

            Manager.Main.Instance.pendingUpload = true;
        }

        private void exportTimesheetButton_Click(object sender, EventArgs e)
        {
            new DatePicker(new Schedule.Shift(DateTime.Now.AddMonths(-1), DateTime.Now), this).Show();
        }

        private void updatePasskeyButton_Click(object sender, EventArgs e)
        {
            var result = Interaction.InputBox("Enter new passkey", "Update Passkey!");


            if (result == null || result == string.Empty)
                return;

            if (Manager.Main.Instance.activeUsers.Find(x => x.passKey == result) != null)
            {
                MessageBox.Show("Please enter a different passkey!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedUser.updatePassKey(result))
            {
                MessageBox.Show("Successfully updated user's passkey!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Manager.Main.Instance.pendingUpload = true;
            }
            else
                MessageBox.Show("Please enter a different passkey!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (matchedUsersList.SelectedIndex > -1 && selectedUser != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete " + selectedUser + "?", "Delete User?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    selectedUser.Deactivate();
                    selectedUser.Delete();
                    clearUserInfo();
                    Debug.Log("User {0} has deleted user {1}", currentUser.userName, selectedUser.userName);
                }
            }
        }

        private void matchedUsersList_Click(object sender, EventArgs e)
        {
            var mouse = (MouseEventArgs)e;
            if (mouse.Button == MouseButtons.Right)
            {
                if (selectedUser == null)
                    searchResultContextMenu.Enabled = false;
                else
                    searchResultContextMenu.Enabled = true;
            }
        }

        private void hoursIssueClearBtn_Click(object sender, EventArgs e)
        {
            foreach (Users.StudentWorker S in hoursIssueList.Items)
                S.hoursIssue = false;

            hoursIssueList.Items.Clear();
        }

        private void hoursIssueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hoursIssueList.SelectedIndex > -1 && hoursIssueList.SelectedItem != null)
                populateUserInfo((Users.User)hoursIssueList.SelectedItem);
        }

        private void searchUserText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Return)
                searchUserButton_Click(sender, e);
        }
    }
}
