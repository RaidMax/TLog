using System;
using System.Windows.Forms;

namespace TLog.Forms
{
    public partial class DatePicker : Form
    {
        public Schedule.Shift selectedShift;
        private Administration admin;

        public DatePicker(Schedule.Shift selectedShift, Administration admin)
        {
            InitializeComponent();
            this.selectedShift = selectedShift;
            this.admin = admin;
            chooseButton.Parent = this;

            startDateTimePicker.Value = selectedShift.shiftStart;
            endDateTimePicker.Value = selectedShift.shiftEnd;

            chooseButton.Click += admin.onDatePicked;

            if (selectedShift.timeWorked > (DateTime.Now - DateTime.Now.AddDays(-1)))
            {
                startDateTimePicker.Format = DateTimePickerFormat.Short;
                endDateTimePicker.Format = DateTimePickerFormat.Short;
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {

        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (selectedShift.timeWorked < (DateTime.Now - DateTime.Now.AddDays(-1)))
                endDateTimePicker.Value = startDateTimePicker.Value;
        }
    }
}
