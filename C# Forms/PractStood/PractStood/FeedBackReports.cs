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
    public partial class FeedBackReports : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        public FeedBackReports()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuEmployee menuEmployee = new MenuEmployee();
            menuEmployee.ShowDialog();
        }

        private void FeedBackReports_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            try
            {


                connection.Open();
                dataAdapter = new SqlDataAdapter($"select First_name + ' ' + Last_name as 'Жилец',ID_room as 'Номер' ,Feedback_Tenant as 'Отзыв', Report as 'Жалоба' from Tenant inner join [User] on [ID_user] = [User_ID] inner join Hostel_number on Hostel_number.Booking_ID = Tenant.Booking_ID ", connection);
                DataSet Mess = new DataSet();
                dataAdapter.Fill(Mess);

                InfoDataGrid.DataSource = Mess.Tables[0];
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
