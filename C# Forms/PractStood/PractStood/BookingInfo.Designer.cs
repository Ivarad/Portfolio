namespace PractStood
{
    partial class BookingInfo
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
            this.InfoDataGrid = new System.Windows.Forms.DataGridView();
            this.CancelBookingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDataGrid)).BeginInit();
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
            this.BackButton.TabIndex = 30;
            this.BackButton.Text = "Выход";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // InfoDataGrid
            // 
            this.InfoDataGrid.AllowUserToAddRows = false;
            this.InfoDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InfoDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.InfoDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.InfoDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoDataGrid.GridColor = System.Drawing.Color.Blue;
            this.InfoDataGrid.Location = new System.Drawing.Point(12, 91);
            this.InfoDataGrid.Name = "InfoDataGrid";
            this.InfoDataGrid.ReadOnly = true;
            this.InfoDataGrid.RowHeadersVisible = false;
            this.InfoDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InfoDataGrid.Size = new System.Drawing.Size(776, 347);
            this.InfoDataGrid.TabIndex = 29;
            // 
            // CancelBookingButton
            // 
            this.CancelBookingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.CancelBookingButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CancelBookingButton.FlatAppearance.BorderSize = 2;
            this.CancelBookingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelBookingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelBookingButton.ForeColor = System.Drawing.Color.Black;
            this.CancelBookingButton.Location = new System.Drawing.Point(656, 12);
            this.CancelBookingButton.Name = "CancelBookingButton";
            this.CancelBookingButton.Size = new System.Drawing.Size(132, 35);
            this.CancelBookingButton.TabIndex = 31;
            this.CancelBookingButton.Text = "Отменить";
            this.CancelBookingButton.UseVisualStyleBackColor = false;
            this.CancelBookingButton.Click += new System.EventHandler(this.CancelBookingButton_Click);
            // 
            // BookingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CancelBookingButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.InfoDataGrid);
            this.Name = "BookingInfo";
            this.Text = "BookingInfo";
            this.Load += new System.EventHandler(this.BookingInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InfoDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridView InfoDataGrid;
        private System.Windows.Forms.Button CancelBookingButton;
    }
}