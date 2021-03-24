namespace PractStood
{
    partial class MenuEmployee
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
            this.BackButton = new System.Windows.Forms.Button();
            this.HotelInfoButton = new System.Windows.Forms.Button();
            this.FeedbackReportsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.BackButton.Size = new System.Drawing.Size(132, 35);
            this.BackButton.TabIndex = 29;
            this.BackButton.Text = "Выход";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // HotelInfoButton
            // 
            this.HotelInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.HotelInfoButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.HotelInfoButton.FlatAppearance.BorderSize = 2;
            this.HotelInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HotelInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HotelInfoButton.ForeColor = System.Drawing.Color.Black;
            this.HotelInfoButton.Location = new System.Drawing.Point(246, 136);
            this.HotelInfoButton.Name = "HotelInfoButton";
            this.HotelInfoButton.Size = new System.Drawing.Size(304, 35);
            this.HotelInfoButton.TabIndex = 30;
            this.HotelInfoButton.Text = "Информация о гостиницах";
            this.HotelInfoButton.UseVisualStyleBackColor = false;
            this.HotelInfoButton.Click += new System.EventHandler(this.HotelInfoButtno_Click);
            // 
            // FeedbackReportsButton
            // 
            this.FeedbackReportsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.FeedbackReportsButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FeedbackReportsButton.FlatAppearance.BorderSize = 2;
            this.FeedbackReportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FeedbackReportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FeedbackReportsButton.ForeColor = System.Drawing.Color.Black;
            this.FeedbackReportsButton.Location = new System.Drawing.Point(246, 207);
            this.FeedbackReportsButton.Name = "FeedbackReportsButton";
            this.FeedbackReportsButton.Size = new System.Drawing.Size(304, 35);
            this.FeedbackReportsButton.TabIndex = 31;
            this.FeedbackReportsButton.Text = "Отзывы/жалобы";
            this.FeedbackReportsButton.UseVisualStyleBackColor = false;
            this.FeedbackReportsButton.Click += new System.EventHandler(this.FeedbackReportsButton_Click);
            // 
            // MenuEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FeedbackReportsButton);
            this.Controls.Add(this.HotelInfoButton);
            this.Controls.Add(this.BackButton);
            this.Name = "MenuEmployee";
            this.Text = "MenuEmployee";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button HotelInfoButton;
        private System.Windows.Forms.Button FeedbackReportsButton;
    }
}