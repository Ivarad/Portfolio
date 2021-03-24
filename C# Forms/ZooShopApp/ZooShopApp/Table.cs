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

namespace ZooShopApp
{
    public partial class Table : Form
    {
        public string data;
        public int indextab;
        private string[] TablesList = new string[]
        { 
        "Select [dbo].[Animal].[ID_Animal], [Kind_Animal] as 'Вид', [Class_Animal] as 'Класс', [Family_Animal] as 'Семейство' from [dbo].[Animal]",
        "Select [dbo].[Advertisement].[ID_Advertisement], [Number_Advertisement] as 'Номер рекламы', [Type_Advertisement] as 'Тип рекламы' from [dbo].[Advertisement]",
        "Select [dbo].[Schedule].[ID_Schedule], [Number_Schedule] as 'Номер графика' from [dbo].[Schedule]",
        "Select [dbo].[Frequent_visitor_card].[ID_Frequent_visitor_card], [Number_Frequent_visitor_card] as 'Номер карты', [Expiration_date] as 'Дата конца срока действия' from [dbo].[Frequent_visitor_card]",
        "Select [dbo].[Animal_log].[ID_Animal_log], [Animal_ID] as 'Код животного', [Animal_quantity] as 'Количество животных' from [dbo].[Animal_log]",
        "Select [dbo].[Check].[ID_Check], [Number_Check] as 'Номер чека', [Purchase_date] as 'Дата покупки', [Animal_ID] as 'Код животного' from [dbo].[Check]",
        "Select [dbo].[Marketing].[ID_Marketing], [Advertisement_ID] as 'Код рекламы', [Schedule_ID] as 'Код графика' from [dbo].[Marketing]",
        "Select [dbo].[Sales].[ID_Sales], [Check_ID] as 'Код чека', [Animal_log_ID] as 'Код журнала учета', [Frequent_visitor_card_ID] as 'Код карты постоянного посетителя', [Schedule_ID] as 'Код графика' from [dbo].[Sales]"
        };


        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=ZooshopBD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;


        public Table(string data)
        {
            InitializeComponent();
            this.data = data;
            if (data == "Animal")
            {
                label1.Text = "Вид";
                label2.Text = "Класс";
                label3.Text = "Семейство";
                label4.Hide();
                textBox4.Hide();
                textBox4.Text = "Null";
                indextab = 0;
                label5.Hide();
                dateTimePicker1.Hide();
            }
            if (data == "Advertisement")
            {
                label1.Text = "Номер рекламы";
                label2.Text = "Тип рекламы";
                label3.Hide();
                label4.Hide();
                textBox3.Text = "Null";
                textBox4.Text = "Null";
                textBox3.Hide();
                textBox4.Hide();
                indextab = 1;
                label5.Hide();
                dateTimePicker1.Hide();
            }
            if (data == "Schedule")
            {
                label1.Text = "Номер графика";
                label2.Hide();
                label3.Hide();
                label4.Hide();
                textBox2.Text = "Null";
                textBox3.Text = "Null";
                textBox4.Text = "Null";
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                indextab = 2;
                label5.Hide();
                dateTimePicker1.Hide();
            }
            if (data == "Frequent_visitor_card")
            {
                label1.Text = "Номер карты";
                label5.Text = "Срок действия";
                label2.Hide();
                label3.Hide();
                label4.Hide();
                textBox2.Text = "Null";
                textBox3.Text = "Null";
                textBox4.Text = "Null";
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                indextab = 3;
            }
            if (data == "Animal_log")
            {
                label1.Text = "Количество животных";
                label2.Text = "Код животного";
                label3.Hide();
                label4.Hide();
                textBox3.Text = "Null";
                textBox4.Text = "Null";
                textBox3.Hide();
                textBox4.Hide();
                indextab = 4;
                label5.Hide();
                dateTimePicker1.Hide();
            }
            if (data == "Check")
            {
                label1.Text = "Номер чека";
                label2.Text = "Код животного";
                label5.Text = "Дата покупки";
                label3.Hide();
                label4.Hide();
                textBox3.Text = "Null";
                textBox4.Text = "Null";
                textBox3.Hide();
                textBox4.Hide();
                indextab = 5;
            }
            if (data == "Marketing")
            {
                label1.Text = "Код рекламы";
                label2.Text = "Код графика работы";
                label3.Hide();
                label4.Hide();
                textBox3.Text = "Null";
                textBox4.Text = "Null";
                textBox3.Hide();
                textBox4.Hide();
                indextab = 6;
                label5.Hide();
                dateTimePicker1.Hide();
            }
            if (data == "Sales")
            {
                label1.Text = "Код чека";
                label2.Text = "Код журнала учета";
                label3.Text = "Код карты постоянного постетителя";
                label4.Text = "Код графика работы";
                indextab = 7;
                label5.Hide();
                dateTimePicker1.Hide();
            }
        }

        public void LoadAnimals()
        {
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter(TablesList[indextab], connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        private void Table_Load_1(object sender, EventArgs e)
        {
            LoadAnimals();
        }

        private void AddButton_click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (textBox1.Text.Contains(" ") || textBox2.Text.Contains(" ") || textBox3.Text.Contains(" ") || textBox4.Text.Contains(" "))
                {
                    MessageBox.Show("Поля не должны содержать пробелы!");
                }
                else
                {



                    connection = new SqlConnection(connectionString);

                    if (indextab == 0) cmd = new SqlCommand($"insert into [dbo].[Animal] ([Kind_Animal],[Class_Animal],[Family_Animal]) values  ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}' )", connection);
                    if (indextab == 1) cmd = new SqlCommand($"insert into [dbo].[Advertisement] ([Number_Advertisement],[Type_Advertisement]) values  ('{textBox1.Text}','{textBox2.Text}' )", connection);
                    if (indextab == 2) cmd = new SqlCommand($"insert into [dbo].[Schedule] ([Number_Schedule]) values  ('{textBox1.Text}')", connection);
                    if (indextab == 3) cmd = new SqlCommand($"insert into [dbo].[Frequent_visitor_card] ([Number_Frequent_visitor_card],[Expiration_date]) values  ('{textBox1.Text}','{dateTimePicker1.Value.ToShortDateString()}')", connection);
                    if (indextab == 4) cmd = new SqlCommand($"insert into [dbo].[Animal_log] ([Animal_quantity],[Animal_ID]) values  ('{textBox1.Text}','{textBox2.Text}')", connection);
                    if (indextab == 5 && dateTimePicker1.Value.ToShortDateString() == DateTime.Today.ToShortDateString()) cmd = new SqlCommand($"insert into [dbo].[Check] ([Number_Check],[Purchase_date],[Animal_ID]) values  ('{textBox1.Text}','{dateTimePicker1.Value.ToShortDateString()}','{textBox2.Text}' )", connection);
                    if (indextab == 6) cmd = new SqlCommand($"insert into [dbo].[Marketing] ([Advertisement_ID],[Schedule_ID]) values  ('{textBox1.Text}','{textBox2.Text}' )", connection);
                    if (indextab == 7) cmd = new SqlCommand($"insert into [dbo].[Sales] ([Check_ID],[Animal_log_ID],[Frequent_visitor_card_ID],[Schedule_ID]) values  ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}' )", connection);

                    try
                    {
                        if (indextab == 5 && dateTimePicker1.Value.ToShortDateString() != DateTime.Today.ToShortDateString()) MessageBox.Show("Должна быть текущая дата");
                        else
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            LoadAnimals();
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
            else MessageBox.Show("Поля не должны быть пустыми!");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (textBox1.Text.Contains(" ") || textBox2.Text.Contains(" ") || textBox3.Text.Contains(" ") || textBox4.Text.Contains(" "))
                {
                    MessageBox.Show("Поля не должны содержать пробелы!");
                }
                else
                {


                    connection = new SqlConnection(connectionString);

                    if (indextab == 0) cmd = new SqlCommand($"update [dbo].[Animal] set [Kind_Animal] = '{textBox1.Text}', [Class_Animal] = '{textBox2.Text}', [Family_Animal] = '{textBox3.Text}' where ID_Animal = {dataGridView1.SelectedRows[0].Cells[0].Value} ", connection);
                    if (indextab == 1) cmd = new SqlCommand($"Update [dbo].[Advertisement] set [Number_Advertisement] = '{textBox1.Text}', [Type_Advertisement] = '{textBox2.Text}' where [ID_Advertisement] = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
                    if (indextab == 2) cmd = new SqlCommand($"update [dbo].[Schedule] set [Number_Schedule] = '{textBox1.Text}' where ID_Schedule = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
                    if (indextab == 3) cmd = new SqlCommand($"update [dbo].[Frequent_visitor_card] set [Number_Frequent_visitor_card] = '{textBox1.Text}', [Expiration_date] = '{dateTimePicker1.Value.ToShortDateString()}' where ID_Frequent_visitor_card = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
                    if (indextab == 4) cmd = new SqlCommand($"update [dbo].[Animal_log] set [Animal_quantity] = '{textBox1.Text}', [Animal_ID] ='{textBox2.Text}' where ID_Animal_log = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
                    if (indextab == 5 && dateTimePicker1.Value.ToShortDateString() == DateTime.Today.ToShortDateString()) cmd = new SqlCommand($"update [dbo].[Check] set [Number_Check] = '{textBox1.Text}',[Purchase_date] = '{dateTimePicker1.Value.ToShortDateString()}', [Animal_ID] = '{textBox3.Text}' where ID_Check = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
                    else if (indextab == 5) MessageBox.Show("Должна быть текущая дата");
                    if (indextab == 6) cmd = new SqlCommand($"update [dbo].[Marketing] set [Advertisement_ID] = '{textBox1.Text}',[Schedule_ID] = '{textBox2.Text}' where ID_Marketing = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
                    if (indextab == 7) cmd = new SqlCommand($"update [dbo].[Sales] set [Check_ID] = '{textBox1.Text}', [Animal_log_ID] = '{textBox2.Text}', [Frequent_visitor_card_ID] = '{textBox3.Text}', [Schedule_ID] = '{textBox4.Text}' where ID_Sales = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        LoadAnimals();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
            else MessageBox.Show("Поля не должны быть пустыми!");
        }

        private void DeleteButton_click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);

            if (indextab == 0) cmd = new SqlCommand($"delete from Animal where ID_Animal = {dataGridView1.SelectedRows[0].Cells[0].Value} ", connection);
            if (indextab == 1) cmd = new SqlCommand($"delete from Advertisement where ID_Advertisement = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
            if (indextab == 2) cmd = new SqlCommand($"delete from Schedule where ID_Schedule = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
            if (indextab == 3) cmd = new SqlCommand($"delete from Frequent_visitor_card where ID_Frequent_visitor_card = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
            if (indextab == 4) cmd = new SqlCommand($"delete from Animal_log where ID_Animal_log = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
            if (indextab == 5) cmd = new SqlCommand($"delete from Check where ID_Check = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
            if (indextab == 6) cmd = new SqlCommand($"delete from Marketing where ID_Marketing = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);
            if (indextab == 7) cmd = new SqlCommand($"delete from Sales where ID_Sales = {dataGridView1.SelectedRows[0].Cells[0].Value}", connection);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                LoadAnimals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch { }

        }
    }
}
