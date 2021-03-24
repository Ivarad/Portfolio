using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PractStood
{
    public partial class MenuEmployee : Form
    {
        public MenuEmployee()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization authorization = new Authorization();
            authorization.Show();
        }

        private void HotelInfoButtno_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employees employees = new Employees();
            employees.ShowDialog();
        }

        private void FeedbackReportsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedBackReports feedBackReports = new FeedBackReports();
            feedBackReports.ShowDialog();
        }
    }
}
