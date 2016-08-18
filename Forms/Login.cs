using System;
using System.Drawing;
using System.Windows.Forms;

namespace TLog
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
            // login parents;
            userIDTextbox.Parent = loginPanel;
            loginCaptionLabel.Parent = loginPanel;
            helpTipLabel.Parent = loginPanel;
            updateClock();
        }

        private void updateClock()
        { 
            var T = new Timer();
            // we wanna see sync in progress
            T.Interval = 25;
            T.Tick += delegate { currentTimeLabel.Text = System.DateTime.Now.ToString("h:mm:ss"); };
            T.Tick += updateConnectionIndicator;
            T.Start();
        }

        private void updateConnectionIndicator(object sender, EventArgs e)
        {
            // bad here
            if (DateTime.Now.Hour > 17 && DateTime.Now.Minute == 0)
            {
                var stillLoggedIn = Manager.Main.Instance.activeUsers.FindAll(x => x.Class == Users.User.Type.Student_Worker && x.loggedIn);
                foreach (Users.StudentWorker s in stillLoggedIn)
                {
                    Debug.Log("{0} is still logged in at end of day, flagging...", s.userName);
                    s.logOff();
                    s.hoursIssue = true;
                    Manager.Main.Instance.pendingUpload = true;
                }
            }

            if (Manager.Cron.failedSaves > 0)
                connectionIndicatorIcon.BackColor = Color.Yellow;
            else if (Manager.Cron.failedSaves == 0)
                connectionIndicatorIcon.BackColor = Color.LimeGreen;
            if (!Manager.Cron.connectionGood)
                connectionIndicatorIcon.BackColor = Color.Red;

            if ((Manager.Main.Instance.serviceServer != null && Manager.Main.Instance.serviceServer.State == System.ServiceModel.CommunicationState.Opened) || Manager.Cron.syncInProgress)
                connectionIndicatorIcon.BackColor = Color.Blue;
        }

        private void refreshUserCount()
        {
            string newStr = String.Empty;
            foreach (var u in Manager.Main.Instance.onlineUsers())
                newStr += u.firstName + Environment.NewLine;

           // activeUsers.Text = newStr;
        }

        private void hideControl(Control ctrl, int time)
        {
            var T = new Timer();
            T.Interval = time * 1000;
            T.Tick += delegate { ctrl.Hide(); T.Stop(); };
            T.Start();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (userIDTextbox.Text == String.Empty)
                return;

            var anc = Manager.Main.Instance.Authenticate(userIDTextbox.Text);
            userIDTextbox.Text = String.Empty;

            if (anc.success)
            {
                switch (anc.currentUser.Class)
                {
                    case Users.User.Type.Student_Worker:
                        new Forms.QuickInfo().Show();
                        break;
                    case Users.User.Type.Administrator:
                        new Forms.Administration().Show();
                        break;
                }
            }
               
            else if (!anc.success)
            {
                errorMessageLabel.Show();
                errorMessageLabel.Text = ErrorCodes.getString(anc.error);
                hideControl(errorMessageLabel, 6);

                if (anc.error == Manager.Main.FailReason.ID_INACTIVE)
                {
                    var result = MessageBox.Show("Would you like to request account activation?", "ID inactive!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        anc.currentUser.requestActivation();
                        // for networking
                        Manager.Main.Instance.activeUsers.Add(anc.currentUser);
                    }
                }
            }

            refreshUserCount();
        }

        private void userIDTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && userIDTextbox.Focused)
                loginButton_Click(sender, e);
        }

        private void userIDTextbox_TextChanged(object sender, EventArgs e)
        {
            if (userIDTextbox.Text.Length > 0)
            {
                if (userIDTextbox.Text.Substring(0, 1).ToLower() == "t")
                    userIDTextbox.PasswordChar = '\0';
                else
                    userIDTextbox.PasswordChar = '*';
            }
        }
    }
}
