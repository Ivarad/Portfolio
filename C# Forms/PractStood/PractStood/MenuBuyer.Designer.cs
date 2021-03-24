namespace PractStood
{
    partial class MenuBuyer
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
            this.AddServiceButton = new System.Windows.Forms.Button();
            this.BookingButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ViewBookingButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DebsCountLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.PayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddServiceButton
            // 
            this.AddServiceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.AddServiceButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddServiceButton.FlatAppearance.BorderSize = 2;
            this.AddServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddServiceButton.ForeColor = System.Drawing.Color.Black;
            this.AddServiceButton.Location = new System.Drawing.Point(256, 160);
            this.AddServiceButton.Name = "AddServiceButton";
            this.AddServiceButton.Size = new System.Drawing.Size(304, 35);
            this.AddServiceButton.TabIndex = 34;
            this.AddServiceButton.Text = "Добавить дополнительные услуги";
            this.AddServiceButton.UseVisualStyleBackColor = false;
            this.AddServiceButton.Click += new System.EventHandler(this.AddServiceButton_Click);
            // 
            // BookingButton
            // 
            this.BookingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.BookingButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BookingButton.FlatAppearance.BorderSize = 2;
            this.BookingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BookingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookingButton.ForeColor = System.Drawing.Color.Black;
            this.BookingButton.Location = new System.Drawing.Point(256, 105);
            this.BookingButton.Name = "BookingButton";
            this.BookingButton.Size = new System.Drawing.Size(304, 35);
            this.BookingButton.TabIndex = 33;
            this.BookingButton.Text = "Забронировать номер";
            this.BookingButton.UseVisualStyleBackColor = false;
            this.BookingButton.Click += new System.EventHandler(this.BookingButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BackButton.FlatAppearance.BorderSize = 2;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.ForeColor = System.Drawing.Color.Black;
            this.BackButton.Location = new System.Drawing.Point(4, 6);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(132, 35);
            this.BackButton.TabIndex = 32;
            this.BackButton.Text = "Выход";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(318, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "Личный кабинет";
            // 
            // ViewBookingButton
            // 
            this.ViewBookingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.ViewBookingButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ViewBookingButton.FlatAppearance.BorderSize = 2;
            this.ViewBookingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ViewBookingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewBookingButton.ForeColor = System.Drawing.Color.Black;
            this.ViewBookingButton.Location = new System.Drawing.Point(256, 212);
            this.ViewBookingButton.Name = "ViewBookingButton";
            this.ViewBookingButton.Size = new System.Drawing.Size(304, 35);
            this.ViewBookingButton.TabIndex = 36;
            this.ViewBookingButton.Text = "Посмотреть свои брони";
            this.ViewBookingButton.UseVisualStyleBackColor = false;
            this.ViewBookingButton.Click += new System.EventHandler(this.ViewBookingButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(66, 66);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(696, 25);
            this.NameLabel.TabIndex = 37;
            this.NameLabel.Text = "ФИО";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DebsCountLabel
            // 
            this.DebsCountLabel.AutoSize = true;
            this.DebsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DebsCountLabel.Location = new System.Drawing.Point(279, 283);
            this.DebsCountLabel.Name = "DebsCountLabel";
            this.DebsCountLabel.Size = new System.Drawing.Size(259, 25);
            this.DebsCountLabel.TabIndex = 38;
            this.DebsCountLabel.Text = "Ваш долг составляет: 0$";
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.RefreshButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RefreshButton.FlatAppearance.BorderSize = 2;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshButton.ForeColor = System.Drawing.Color.Black;
            this.RefreshButton.Location = new System.Drawing.Point(12, 280);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(132, 35);
            this.RefreshButton.TabIndex = 39;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Visible = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // PayButton
            // 
            this.PayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.PayButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PayButton.FlatAppearance.BorderSize = 2;
            this.PayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PayButton.ForeColor = System.Drawing.Color.Black;
            this.PayButton.Location = new System.Drawing.Point(347, 326);
            this.PayButton.Name = "PayButton";
            this.PayButton.Size = new System.Drawing.Size(132, 35);
            this.PayButton.TabIndex = 40;
            this.PayButton.Text = "Оплатить";
            this.PayButton.UseVisualStyleBackColor = false;
            this.PayButton.Click += new System.EventHandler(this.PayButton_Click);
            // 
            // MenuBuyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PayButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.DebsCountLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ViewBookingButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddServiceButton);
            this.Controls.Add(this.BookingButton);
            this.Controls.Add(this.BackButton);
            this.Name = "MenuBuyer";
            this.Text = "MenuBuyer";
            this.Load += new System.EventHandler(this.MenuBuyer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddServiceButton;
        private System.Windows.Forms.Button BookingButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ViewBookingButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DebsCountLabel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button PayButton;
    }
}