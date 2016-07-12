namespace TLog.Forms
{
    partial class DatePicker
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
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.chooseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startDateTimePicker.Location = new System.Drawing.Point(12, 28);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(222, 20);
            this.startDateTimePicker.TabIndex = 0;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(9, 9);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(29, 13);
            this.startTimeLabel.TabIndex = 1;
            this.startTimeLabel.Text = "Start";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(9, 51);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(26, 13);
            this.endTimeLabel.TabIndex = 3;
            this.endTimeLabel.Text = "End";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endDateTimePicker.Location = new System.Drawing.Point(12, 72);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(222, 20);
            this.endDateTimePicker.TabIndex = 2;
            // 
            // chooseButton
            // 
            this.chooseButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.chooseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chooseButton.Location = new System.Drawing.Point(16, 112);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(215, 23);
            this.chooseButton.TabIndex = 4;
            this.chooseButton.Text = "Choose";
            this.chooseButton.UseVisualStyleBackColor = false;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // DatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 155);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.startDateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DatePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose a date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Button chooseButton;
        public System.Windows.Forms.DateTimePicker startDateTimePicker;
        public System.Windows.Forms.DateTimePicker endDateTimePicker;
    }
}