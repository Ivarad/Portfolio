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
    public partial class RegistrationForm : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=ZooshopBD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        public RegistrationForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("Отдел продаж");
            comboBox1.Items.Add("Отдел маркетинга");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            if(textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex != -1)
            {
                if (textBox1.Text.Contains(" ") || textBox2.Text.Contains(" "))
                {
                    MessageBox.Show("Поля не должны содержать пробелы.");
                }
                else
                {
                    try
                    {
                        connection.Open();
                        cmd = new SqlCommand($"insert into [dbo].[Users] ([Login],[Password],[Role]) values  ('{textBox1.Text}','{textBox2.Text}','{comboBox1.SelectedIndex}' )", connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                        MessageBox.Show("Регистрация прошла успешно");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Поля и список не должны быть пустыми.");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
