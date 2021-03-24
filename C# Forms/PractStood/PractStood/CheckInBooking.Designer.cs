namespace PractStood
{
    partial class CheckInBooking
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
            this.HotelsComboBox = new System.Windows.Forms.ComboBox();
            this.PeopleCoutComboBox = new System.Windows.Forms.ComboBox();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FinishDatePicker = new System.Windows.Forms.DateTimePicker();
            this.HostelLabel = new System.Windows.Forms.Label();
            this.PeopleQuantityLabel = new System.Windows.Forms.Label();
            this.DateBookingLabel = new System.Windows.Forms.Label();
            this.CLabel = new System.Windows.Forms.Label();
            this.PoLabel = new System.Windows.Forms.Label();
            this.PayButton = new System.Windows.Forms.Button();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HotelsComboBox
            // 
            this.HotelsComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.HotelsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HotelsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HotelsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HotelsComboBox.Location = new System.Drawing.Point(158, 46);
            this.HotelsComboBox.Name = "HotelsComboBox";
            this.HotelsComboBox.Size = new System.Drawing.Size(140, 28);
            this.HotelsComboBox.TabIndex = 14;
            // 
            // PeopleCoutComboBox
            // 
            this.PeopleCoutComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.PeopleCoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PeopleCoutComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PeopleCoutComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PeopleCoutComboBox.Location = new System.Drawing.Point(545, 46);
            this.PeopleCoutComboBox.Name = "PeopleCoutComboBox";
            this.PeopleCoutComboBox.Size = new System.Drawing.Size(44, 28);
            this.PeopleCoutComboBox.TabIndex = 15;
            this.PeopleCoutComboBox.SelectedValueChanged += new System.EventHandler(this.PeopleCoutComboBox_SelectedValueChanged);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.StartDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartDatePicker.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.StartDatePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.StartDatePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.StartDatePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.StartDatePicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.StartDatePicker.Cursor = System.Windows.Forms.Cursors.Default;
            this.StartDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartDatePicker.Location = new System.Drawing.Point(140, 138);
            this.StartDatePicker.MinDate = new System.DateTime(2021, 2, 17, 0, 0, 0, 0);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 26);
            this.StartDatePicker.TabIndex = 0;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
            // 
            // FinishDatePicker
            // 
            this.FinishDatePicker.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.FinishDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FinishDatePicker.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.FinishDatePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.FinishDatePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.FinishDatePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.FinishDatePicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.FinishDatePicker.Cursor = System.Windows.Forms.Cursors.Default;
            this.FinishDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FinishDatePicker.Location = new System.Drawing.Point(472, 138);
            this.FinishDatePicker.MinDate = new System.DateTime(2021, 2, 17, 0, 0, 0, 0);
            this.FinishDatePicker.Name = "FinishDatePicker";
            this.FinishDatePicker.Size = new System.Drawing.Size(200, 26);
            this.FinishDatePicker.TabIndex = 16;
            this.FinishDatePicker.ValueChanged += new System.EventHandler(this.FinishDatePicker_ValueChanged);
            // 
            // HostelLabel
            // 
            this.HostelLabel.AutoSize = true;
            this.HostelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HostelLabel.Location = new System.Drawing.Point(136, 9);
            this.HostelLabel.Name = "HostelLabel";
            this.HostelLabel.Size = new System.Drawing.Size(170, 24);
            this.HostelLabel.TabIndex = 17;
            this.HostelLabel.Text = "Выбор гостиницы";
            // 
            // PeopleQuantityLabel
            // 
            this.PeopleQuantityLabel.AutoSize = true;
            this.PeopleQuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PeopleQuantityLabel.Location = new System.Drawing.Point(457, 9);
            this.PeopleQuantityLabel.Name = "PeopleQuantityLabel";
            this.PeopleQuantityLabel.Size = new System.Drawing.Size(239, 24);
            this.PeopleQuantityLabel.TabIndex = 18;
            this.PeopleQuantityLabel.Text = "Выбор количетсва людей";
            // 
            // DateBookingLabel
            // 
            this.DateBookingLabel.AutoSize = true;
            this.DateBookingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateBookingLabel.Location = new System.Drawing.Point(310, 101);
            this.DateBookingLabel.Name = "DateBookingLabel";
            this.DateBookingLabel.Size = new System.Drawing.Size(189, 24);
            this.DateBookingLabel.TabIndex = 19;
            this.DateBookingLabel.Text = "Дата бронирования";
            // 
            // CLabel
            // 
            this.CLabel.AutoSize = true;
            this.CLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CLabel.Location = new System.Drawing.Point(105, 138);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(23, 24);
            this.CLabel.TabIndex = 20;
            this.CLabel.Text = "С";
            // 
            // PoLabel
            // 
            this.PoLabel.AutoSize = true;
            this.PoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PoLabel.Location = new System.Drawing.Point(391, 140);
            this.PoLabel.Name = "PoLabel";
            this.PoLabel.Size = new System.Drawing.Size(38, 24);
            this.PoLabel.TabIndex = 21;
            this.PoLabel.Text = "ПО";
            // 
            // PayButton
            // 
            this.PayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.PayButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PayButton.FlatAppearance.BorderSize = 2;
            this.PayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PayButton.ForeColor = System.Drawing.Color.Black;
            this.PayButton.Location = new System.Drawing.Point(266, 383);
            this.PayButton.Name = "PayButton";
            this.PayButton.Size = new System.Drawing.Size(297, 35);
            this.PayButton.TabIndex = 22;
            this.PayButton.Text = "Оплатить";
            this.PayButton.UseVisualStyleBackColor = false;
            this.PayButton.Click += new System.EventHandler(this.PayButton_Click);
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountLabel.Location = new System.Drawing.Point(391, 309);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(30, 24);
            this.AmountLabel.TabIndex = 24;
            this.AmountLabel.Text = "0$";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BackButton.FlatAppearance.BorderSize = 2;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.ForeColor = System.Drawing.Color.Black;
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(95, 35);
            this.BackButton.TabIndex = 30;
            this.BackButton.Text = "Выход";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CheckInBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.PayButton);
            this.Controls.Add(this.PoLabel);
            this.Controls.Add(this.CLabel);
            this.Controls.Add(this.DateBookingLabel);
            this.Controls.Add(this.PeopleQuantityLabel);
            this.Controls.Add(this.HostelLabel);
            this.Controls.Add(this.FinishDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.PeopleCoutComboBox);
            this.Controls.Add(this.HotelsComboBox);
            this.Name = "CheckInBooking";
            this.Text = "CheckInBooking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckInBooking_FormClosing);
            this.Load += new System.EventHandler(this.CheckInBooking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox HotelsComboBox;
        private System.Windows.Forms.ComboBox PeopleCoutComboBox;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker FinishDatePicker;
        private System.Windows.Forms.Label HostelLabel;
        private System.Windows.Forms.Label PeopleQuantityLabel;
        private System.Windows.Forms.Label DateBookingLabel;
        private System.Windows.Forms.Label CLabel;
        private System.Windows.Forms.Label PoLabel;
        private System.Windows.Forms.Button PayButton;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Button BackButton;
    }
}