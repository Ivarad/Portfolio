namespace PractStood
{
    partial class Guest
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
            this.ServiceDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ServiceComboBox = new System.Windows.Forms.ComboBox();
            this.MessageComboBox = new System.Windows.Forms.ComboBox();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AgreeButton = new System.Windows.Forms.Button();
            this.AddServiceButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ServiceDataGridView
            // 
            this.ServiceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServiceDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.ServiceDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ServiceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiceDataGridView.Location = new System.Drawing.Point(12, 175);
            this.ServiceDataGridView.Name = "ServiceDataGridView";
            this.ServiceDataGridView.ReadOnly = true;
            this.ServiceDataGridView.RowHeadersVisible = false;
            this.ServiceDataGridView.Size = new System.Drawing.Size(776, 263);
            this.ServiceDataGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(116, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Услуга";
            // 
            // ServiceComboBox
            // 
            this.ServiceComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.ServiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServiceComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServiceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServiceComboBox.Location = new System.Drawing.Point(48, 36);
            this.ServiceComboBox.Name = "ServiceComboBox";
            this.ServiceComboBox.Size = new System.Drawing.Size(199, 28);
            this.ServiceComboBox.TabIndex = 19;
            // 
            // MessageComboBox
            // 
            this.MessageComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.MessageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MessageComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MessageComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageComboBox.Location = new System.Drawing.Point(48, 121);
            this.MessageComboBox.Name = "MessageComboBox";
            this.MessageComboBox.Size = new System.Drawing.Size(86, 28);
            this.MessageComboBox.TabIndex = 20;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageTextBox.Location = new System.Drawing.Point(215, 120);
            this.MessageTextBox.MaxLength = 200;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(313, 29);
            this.MessageTextBox.TabIndex = 21;
            this.MessageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(54)))), ((int)(((byte)(33)))));
            this.label2.Location = new System.Drawing.Point(234, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Напишите здесь отзыв или жалобу";
            // 
            // AgreeButton
            // 
            this.AgreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.AgreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AgreeButton.FlatAppearance.BorderSize = 2;
            this.AgreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AgreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AgreeButton.ForeColor = System.Drawing.Color.Black;
            this.AgreeButton.Location = new System.Drawing.Point(580, 114);
            this.AgreeButton.Name = "AgreeButton";
            this.AgreeButton.Size = new System.Drawing.Size(145, 35);
            this.AgreeButton.TabIndex = 24;
            this.AgreeButton.Text = "Подтвердить";
            this.AgreeButton.UseVisualStyleBackColor = false;
            this.AgreeButton.Click += new System.EventHandler(this.AgreeButton_Click);
            // 
            // AddServiceButton
            // 
            this.AddServiceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.AddServiceButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddServiceButton.FlatAppearance.BorderSize = 2;
            this.AddServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddServiceButton.ForeColor = System.Drawing.Color.Black;
            this.AddServiceButton.Location = new System.Drawing.Point(313, 29);
            this.AddServiceButton.Name = "AddServiceButton";
            this.AddServiceButton.Size = new System.Drawing.Size(145, 35);
            this.AddServiceButton.TabIndex = 25;
            this.AddServiceButton.Text = "Добавить услугу";
            this.AddServiceButton.UseVisualStyleBackColor = false;
            this.AddServiceButton.Click += new System.EventHandler(this.AddServiceButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BackButton.FlatAppearance.BorderSize = 2;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.ForeColor = System.Drawing.Color.Black;
            this.BackButton.Location = new System.Drawing.Point(693, 9);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(95, 35);
            this.BackButton.TabIndex = 30;
            this.BackButton.Text = "Выход";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Guest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AddServiceButton);
            this.Controls.Add(this.AgreeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.MessageComboBox);
            this.Controls.Add(this.ServiceComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServiceDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Guest";
            this.Text = "Tenant";
            this.Load += new System.EventHandler(this.Guest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ServiceDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ServiceComboBox;
        private System.Windows.Forms.ComboBox MessageComboBox;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AgreeButton;
        private System.Windows.Forms.Button AddServiceButton;
        private System.Windows.Forms.Button BackButton;
    }
}