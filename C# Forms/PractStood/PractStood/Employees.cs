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
    public partial class Employees : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        public Employees()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuEmployee menuEmployee = new MenuEmployee();
            menuEmployee.ShowDialog();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter($"select [ID_user] from [User] where Type_user = '1' or Type_user = '2'",connection);
                DataSet Count = new DataSet();
                dataAdapter.Fill(Count);

                cmd = new SqlCommand($"update Hostel set QuantityTentants = '{Count.Tables[0].Rows.Count}'", connection);
                cmd.ExecuteNonQuery();

                dataAdapter = new SqlDataAdapter($"select [Class_hotel] as 'Класс отеля', QuantityTentants as 'Количество клиентов', Revenue as 'Доходы',Expenses as 'Расходы' from Hostel",connection);
                DataSet Info = new DataSet();
                dataAdapter.Fill(Info);

                InfoDataGrid.DataSource = Info.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
            finally
            {
                connection.Close();
            }
        }

        private void Employees_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
