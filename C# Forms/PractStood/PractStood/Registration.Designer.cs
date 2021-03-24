namespace PractStood
{
    partial class Registration
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.RoleComboBox = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PatranomicTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.ToAuthButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.RoleComboBox);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.LoginTextBox);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.PasswordTextBox);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.PatranomicTextBox);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.SurnameTextBox);
            this.panel1.Controls.Add(this.NameTextBox);
            this.panel1.Controls.Add(this.RegistrationButton);
            this.panel1.Controls.Add(this.ToAuthButton);
            this.panel1.Location = new System.Drawing.Point(199, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 393);
            this.panel1.TabIndex = 1;
            // 
            // RoleComboBox
            // 
            this.RoleComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.RoleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RoleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RoleComboBox.Location = new System.Drawing.Point(137, 188);
            this.RoleComboBox.Name = "RoleComboBox";
            this.RoleComboBox.Size = new System.Drawing.Size(140, 28);
            this.RoleComboBox.TabIndex = 13;
            this.RoleComboBox.SelectedIndexChanged += new System.EventHandler(this.RoleComboBox_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(90, 264);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(220, 2);
            this.panel6.TabIndex = 12;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.LoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginTextBox.Location = new System.Drawing.Point(90, 250);
            this.LoginTextBox.MaxLength = 30;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(220, 13);
            this.LoginTextBox.TabIndex = 11;
            this.LoginTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LoginTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            this.LoginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginTextBox_KeyPress);
            this.LoginTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(90, 311);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(220, 2);
            this.panel5.TabIndex = 10;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextBox.Location = new System.Drawing.Point(90, 297);
            this.PasswordTextBox.MaxLength = 30;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(220, 13);
            this.PasswordTextBox.TabIndex = 9;
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            this.PasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextBox_KeyPress);
            this.PasswordTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(90, 158);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 2);
            this.panel4.TabIndex = 8;
            // 
            // PatranomicTextBox
            // 
            this.PatranomicTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.PatranomicTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PatranomicTextBox.Location = new System.Drawing.Point(90, 144);
            this.PatranomicTextBox.MaxLength = 100;
            this.PatranomicTextBox.Name = "PatranomicTextBox";
            this.PatranomicTextBox.Size = new System.Drawing.Size(220, 13);
            this.PatranomicTextBox.TabIndex = 7;
            this.PatranomicTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PatranomicTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            this.PatranomicTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatranomicTextBox_KeyPress);
            this.PatranomicTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(90, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 2);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(90, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 2);
            this.panel2.TabIndex = 5;
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.SurnameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SurnameTextBox.Location = new System.Drawing.Point(90, 106);
            this.SurnameTextBox.MaxLength = 100;
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(220, 13);
            this.SurnameTextBox.TabIndex = 4;
            this.SurnameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SurnameTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            this.SurnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SurnameTextBox_KeyPress);
            this.SurnameTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameTextBox.Location = new System.Drawing.Point(90, 62);
            this.NameTextBox.MaxLength = 100;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(220, 13);
            this.NameTextBox.TabIndex = 3;
            this.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            this.NameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameTextBox_KeyPress);
            this.NameTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.RegistrationButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RegistrationButton.FlatAppearance.BorderSize = 2;
            this.RegistrationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegistrationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationButton.ForeColor = System.Drawing.Color.Black;
            this.RegistrationButton.Location = new System.Drawing.Point(127, 363);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(164, 25);
            this.RegistrationButton.TabIndex = 2;
            this.RegistrationButton.Text = "Зарегистрироваться";
            this.RegistrationButton.UseVisualStyleBackColor = false;
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // ToAuthButton
            // 
            this.ToAuthButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.ToAuthButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ToAuthButton.FlatAppearance.BorderSize = 50;
            this.ToAuthButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ToAuthButton.ForeColor = System.Drawing.Color.Black;
            this.ToAuthButton.Location = new System.Drawing.Point(159, 14);
            this.ToAuthButton.Name = "ToAuthButton";
            this.ToAuthButton.Size = new System.Drawing.Size(97, 23);
            this.ToAuthButton.TabIndex = 0;
            this.ToAuthButton.Text = "Вернуться";
            this.ToAuthButton.UseVisualStyleBackColor = false;
            this.ToAuthButton.Click += new System.EventHandler(this.ToAuthButton_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Registration";
            this.Text = "Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registration_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.Button ToAuthButton;
        private System.Windows.Forms.ComboBox RoleComboBox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox PatranomicTextBox;
    }
}