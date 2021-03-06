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
    public partial class BookingInfo : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        private string ID;
        DataTable dates;

        public BookingInfo(string ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BookingInfo_Load(object sender, EventArgs e)
        {
            
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                dataAdapter = new SqlDataAdapter($"select [Class_hotel] as 'Класс отеля', All_quantity_people as 'Количество людей', Time_Check_In as 'Время заселения', Time_Eviction as 'Время выселения' from Reservations inner join Tenant on [User_ID] = '{ID}' where ID_Booking = Booking_ID", connection);
                DataSet Info = new DataSet();
                dataAdapter.Fill(Info);

                dates = Info.Tables[0];

                InfoDataGrid.DataSource = Info.Tables[0];
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

        private void CancelBookingButton_Click(object sender, EventArgs e)
        {
            if (InfoDataGrid.SelectedRows.Count >= 0)
            {

                if (Convert.ToDateTime(dates.Rows[InfoDataGrid.SelectedRows.Count - 1][2].ToString()) >= DateTime.Now.Date.AddDays(7))
                {
                    connection = new SqlConnection(connectionString);
                    try
                    {
                        connection.Open();

                        dataAdapter = new SqlDataAdapter($"select Reservations.ID_Booking, ID_room from Reservations inner join Tenant on [User_ID] = '{ID}' inner join Hostel_number on Hostel_number.Booking_ID = Tenant.Booking_ID  where ID_Booking = Tenant.Booking_ID", connection);
                        DataSet Info = new DataSet();
                        dataAdapter.Fill(Info);

                        cmd = new SqlCommand($"update Hostel_number set Employment = 0, Booking_ID = null, Contract_ID = null, Condition_drinks = 0, Condition_food = 0, Condition_without = 1, Condition_Aid =0, Condition_Cleaning = 0 where ID_room = '{Info.Tables[0].Rows[InfoDataGrid.SelectedRows.Count - 1][1]}'", connection);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand($"delete from Tenant where [Booking_ID] = '{Info.Tables[0].Rows[InfoDataGrid.SelectedRows.Count - 1][0]}'", connection);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand($"delete from Reservations where ID_Booking = '{Info.Tables[0].Rows[InfoDataGrid.SelectedRows.Count - 1][0]}'", connection);
                        cmd.ExecuteNonQuery();

                        InfoDataGrid.DataSource = null;

                        dataAdapter = new SqlDataAdapter($"select [Class_hotel] as 'Класс отеля', All_quantity_people as 'Количество людей', Time_Check_In as 'Время заселения', Time_Eviction as 'Время выселения' from Reservations inner join Tenant on [User_ID] = '{ID}' where ID_Booking = Booking_ID", connection);
                        DataSet Infogrid = new DataSet();
                        dataAdapter.Fill(Infogrid);


                        InfoDataGrid.DataSource = Infogrid.Tables[0];
                        InfoDataGrid.Refresh();

                        MessageBox.Show("Бронь была отменена!");
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
                else MessageBox.Show("До даты заселения меньше 7 дней, отмена брони невозможна");
            }

        }

    }
}
