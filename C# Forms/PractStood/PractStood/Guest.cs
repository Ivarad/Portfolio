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
    public partial class Guest : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        private string ID, command, roomID, StatusTenant, Type_user;
        private DataTable room, services, grid;
        public Guest(string ID, string StatusTenant, string Type_user)
        {
            InitializeComponent();
            this.ID = ID;
            this.StatusTenant = StatusTenant;
            this.Type_user = Type_user;

            MessageComboBox.Items.Add("Отзыв");
            MessageComboBox.Items.Add("Жалоба");
            MessageComboBox.SelectedIndex = 0;
        }

        private void AgreeButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);

            if (MessageComboBox.SelectedIndex > -1 && MessageTextBox.Text != "")
            {
                if (MessageComboBox.SelectedIndex == 0)
                {
                    cmd = new SqlCommand($"update Tenant set Feedback_Tenant = '{MessageTextBox.Text}' where User_ID = '{ID}'", connection);
                }
                if (MessageComboBox.SelectedIndex == 1)
                {
                    cmd = new SqlCommand($"update Tenant set Report = '{MessageTextBox.Text}' where User_ID = '{ID}'", connection);
                }

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageTextBox.Text = "";
                    if (MessageComboBox.SelectedIndex == 0) MessageBox.Show("Ваш отзыв отправлен!");
                    if (MessageComboBox.SelectedIndex == 1) MessageBox.Show("Ваша жалоба отправлена!");
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
            else MessageBox.Show("Поля не должны быть пустыми!");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuBuyer menuBuyer = new MenuBuyer(ID, StatusTenant, Type_user);
            menuBuyer.ShowDialog();
        }

        private void Guest_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter($"select [ID_room] from [Hostel_number] inner join [Tenant] on [User_ID] = '{ID}' where [Hostel_number].Booking_ID = Tenant.Booking_ID", connection);
                DataSet Room = new DataSet();
                dataAdapter.Fill(Room);

                dataAdapter = new SqlDataAdapter($"select * from DLC_service", connection);
                DataSet Service = new DataSet();
                dataAdapter.Fill(Service);

                if (Room.Tables[0].Rows.Count > 0)
                {


                    services = Service.Tables[0];

                    roomID = Room.Tables[0].Rows[0][0].ToString();

                    dataAdapter = new SqlDataAdapter($"select Condition_drinks, Condition_food, Condition_without, Condition_Aid, Condition_Cleaning from Hostel_number where ID_room = '{Room.Tables[0].Rows[0][0]}'", connection);
                    DataSet Roomserv = new DataSet();
                    dataAdapter.Fill(Roomserv);

                    room = Roomserv.Tables[0];
                    bool Without = true;
                    int massind = 0;
                    string[] servmass = new string[5] { "", "", "", "", "" };
                    command = $"select Name_DlC_service as 'Услуга',Quantity_service as 'Стоимость' from DLC_service where";

                    for (int column = 0; column < room.Columns.Count; column++)
                    {
                        if (column != 2)
                        {
                            if (room.Rows[0][column].ToString() == "True")
                            {
                                if (servmass[0] == "")
                                {
                                    servmass[massind] = $" ID_DLC_service = '{column + 1}'";
                                    massind++;
                                }
                                else
                                {
                                    if (servmass[massind] == "")
                                    {
                                        servmass[massind] = $" or ID_DLC_service = '{column + 1}'";
                                        massind++;
                                    }
                                }
                                Without = false;
                            }

                        }
                    }

                    if (Without)
                    {
                        command = $"select Name_DlC_service as 'Услуга',Quantity_service as 'Стоимость' from DLC_service where ID_DLC_service = '3'";
                    }

                    foreach (var services in servmass)
                    {
                        if (services != "") command = command + services;
                    }

                    dataAdapter = new SqlDataAdapter(command, connection);
                    DataSet RoomService = new DataSet();
                    dataAdapter.Fill(RoomService);

                    ServiceDataGridView.DataSource = RoomService.Tables[0];
                }
                else MessageBox.Show("Отсутствует бронь");

                for (int row = 0; row < Service.Tables[0].Rows.Count; row++)
                {
                    ServiceComboBox.Items.Add(Service.Tables[0].Rows[row][1]);
                }

                room = null;

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

        private void AddServiceButton_Click(object sender, EventArgs e)
        {
            if (ServiceDataGridView.Rows.Count > 0)
            {


                string[] servic = { "Condition_drinks = 1 ", "Condition_food = 1 ", "Condition_without = 0 ", "Condition_Aid = 1", "Condition_Cleaning = 1 " };
                if (ServiceComboBox.SelectedIndex > -1)
                {
                    connection = new SqlConnection(connectionString);
                    string sqlcommand = "";
                    try
                    {
                        connection.Open();
                        if (ServiceComboBox.SelectedIndex != 2)
                        {
                            sqlcommand = $"update Hostel_number set {servic[ServiceComboBox.SelectedIndex]}, Condition_without = 0 where ID_room = '{roomID}'";
                        }
                        else sqlcommand = $"update Hostel_number set Condition_drinks = 0, Condition_food = 0, Condition_without = 1, Condition_Aid = 0, Condition_Cleaning = 0 where ID_room = '{roomID}'";
                        cmd = new SqlCommand(sqlcommand, connection);
                        cmd.ExecuteNonQuery();

                        dataAdapter = new SqlDataAdapter($"select Condition_drinks, Condition_food, Condition_without, Condition_Aid, Condition_Cleaning from Hostel_number where ID_room = '{roomID}'", connection);
                        DataSet Roomserv = new DataSet();
                        dataAdapter.Fill(Roomserv);

                        room = Roomserv.Tables[0];
                        bool Without = true;
                        int massind = 0;
                        string[] servmass = new string[5] { "", "", "", "", "" };
                        command = $"select Name_DlC_service as 'Услуга',Quantity_service as 'Стоимость' from DLC_service where";

                        for (int column = 0; column < room.Columns.Count; column++)
                        {
                            if (column != 2)
                            {
                                if (room.Rows[0][column].ToString() == "True")
                                {
                                    if (servmass[0] == "")
                                    {
                                        servmass[massind] = $" ID_DLC_service = '{column + 1}'";
                                        massind++;
                                    }
                                    else
                                    {
                                        if (servmass[massind] == "")
                                        {
                                            servmass[massind] = $" or ID_DLC_service = '{column + 1}'";
                                            massind++;
                                        }
                                    }
                                    Without = false;
                                }

                            }
                        }

                        if (Without)
                        {
                            command = $"select Name_DlC_service as 'Услуга',Quantity_service as 'Стоимость' from DLC_service where ID_DLC_service = '3'";
                            cmd = new SqlCommand($"update Tenant set Debts_Tenant = 0 where [User_ID] = '{ID}'", connection);
                            cmd.ExecuteNonQuery();
                        }

                        foreach (var services in servmass)
                        {
                            if (services != "") command = command + services;
                        }

                        dataAdapter = new SqlDataAdapter(command, connection);
                        DataSet RoomService = new DataSet();
                        dataAdapter.Fill(RoomService);

                        ServiceDataGridView.DataSource = null;
                        ServiceDataGridView.DataSource = RoomService.Tables[0];
                        ServiceDataGridView.Refresh();

                        cmd = new SqlCommand($"update Tenant set Debts_Tenant = '0' where [User_ID] = '{ID}'", connection);
                        cmd.ExecuteNonQuery();

                        for (int Index = 0; Index < ServiceDataGridView.Rows.Count - 1; Index++)
                        {
                            for (int i = 0; i < services.Rows.Count; i++)
                            {
                                if (ServiceDataGridView[0, Index].Value.ToString() == services.Rows[i][1].ToString())
                                {
                                    cmd = new SqlCommand($"update Hostel set Expenses += {Convert.ToInt32(services.Rows[i][3])} where ID_Hostel = 1", connection);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                        }

                        cmd = new SqlCommand($"update Tenant set Debts_Tenant += '{Convert.ToInt32(services.Rows[ServiceComboBox.SelectedIndex][2])}' where [User_ID] = '{ID}'", connection);
                        cmd.ExecuteNonQuery();

                        room = null;


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
                else MessageBox.Show("Отсутствует бронь");

            }
        }
    }
}
