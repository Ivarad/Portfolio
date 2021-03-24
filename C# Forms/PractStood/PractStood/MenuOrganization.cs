using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PractStood
{
    public partial class MenuOrganization : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        private string ID, Type_user, StatusTenant, Debs, StDate, FinDate;

        private void PayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pay pay = new Pay(Debs, ID, Type_user);
            pay.ShowDialog();
        }

        private void AddServiceButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmloyeesCherfulness emloyeesCherfulness = new EmloyeesCherfulness(ID,StDate,FinDate,StatusTenant,Type_user);
            emloyeesCherfulness.ShowDialog();
        }

        private void ViewBookingButton_Click(object sender, EventArgs e)
        {
            ContracktsView contracktsView = new ContracktsView(ID);
            contracktsView.ShowDialog();
        }

        public MenuOrganization(string ID, string StatusTenant, string Type_user, string StDate, string FinDate)
        {
            InitializeComponent();
            this.ID = ID;
            this.StatusTenant = StatusTenant;
            this.Type_user = Type_user;
            this.StDate = StDate;
            this.FinDate = FinDate;
        }

        private void MenuOrganization_Load(object sender, EventArgs e)
        {
            Loadorg();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization authorization = new Authorization();
            authorization.Show();
        }

        private void BookingButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CheckInBooking checkInBooking = new CheckInBooking(ID, StatusTenant, Type_user);
            checkInBooking.Show();
        }

        public void Loadorg()
        {
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                dataAdapter = new SqlDataAdapter($"select First_name from [User] where ID_user = '{ID}'", connection);
                DataSet info = new DataSet();
                dataAdapter.Fill(info);

                NameLabel.Text = info.Tables[0].Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
