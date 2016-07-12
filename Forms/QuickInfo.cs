using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLog.Forms
{
    public partial class QuickInfo : Form
    {
        public QuickInfo()
        {
            InitializeComponent();
            populateData();
            killWindow();
        }

        private void populateData()
        {
            var user = Manager.Main.Instance.lastUser;

            if (user != null)
            {
                var studentWorker = (Users.StudentWorker)user;

                nameLabel.Text = (studentWorker.loggedIn) ? "WELCOME " + studentWorker.firstName.ToUpper() : "GOODBYE " + studentWorker.firstName.ToUpper();

                hoursWorkedLabel.Text = studentWorker.dailyHours() + " hours today";
                weeklyHoursLabel.Text = studentWorker.weeklyHours() + " hours this week";
                totalSemesterHours.Text = studentWorker.semesterHours() + "/" + studentWorker.maxHoursPerSemester + " hours for the semester";
            }
        }

        private void killWindow()
        {
            var T = new Timer();
            T.Interval = 8000;
            T.Tick += delegate { T.Stop(); Close(); };
            T.Start();
        }
    }
}
