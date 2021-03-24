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
    public partial class MenuBuyer : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        private string ID, Type_user, StatusTenant, Debs;
        public MenuBuyer(string ID, string StatusTenant, string Type_user)
        {
            InitializeComponent();
            this.ID = ID;
            this.StatusTenant = StatusTenant;
            this.Type_user = Type_user;
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization authorization = new Authorization();
            authorization.Show();
        }

        private void ViewBookingButton_Click(object sender, EventArgs e)
        {
            BookingInfo bookingInfo = new BookingInfo(ID);
            bookingInfo.ShowDialog();
        }

        private void MenuBuyer_Load(object sender, EventArgs e)
        {
            Loadfio();
        }

        public void Loadfio()
        {
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                dataAdapter = new SqlDataAdapter($"select First_name + ' ' + Last_name, Debts_Tenant from [User] inner join Tenant on User_ID = ID_user where ID_user = '{ID}'", connection);
                DataSet info = new DataSet();
                dataAdapter.Fill(info);

                dataAdapter = new SqlDataAdapter($"select First_name + ' ' + Last_name from [User] where ID_user = '{ID}'", connection);
                DataSet Fio = new DataSet();
                dataAdapter.Fill(Fio);

                if (info.Tables[0].Rows.Count > 0)
                {
                    NameLabel.Text = info.Tables[0].Rows[0][0].ToString();
                    DebsCountLabel.Text = $"Ваш долг составляет: {info.Tables[0].Rows[0][1].ToString()} $";
                    Debs = info.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    NameLabel.Text = Fio.Tables[0].Rows[0][0].ToString();
                    DebsCountLabel.Text = $"Ваш долг составляет: 0 $";
                    Debs = "0";
                }
                
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

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Loadfio();
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pay pay = new Pay(Debs,ID,Type_user);
            pay.ShowDialog();
        }

        private void BookingButton_Click(object sender, EventArgs e)
        {
            
            CheckInBooking checkInBooking = new CheckInBooking(ID, StatusTenant, Type_user);
            checkInBooking.ShowDialog();
        }

        private void AddServiceButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Guest guest = new Guest(ID,StatusTenant,Type_user);
            guest.ShowDialog();
        }
    }
}
