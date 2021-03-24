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
    public partial class Form1 : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=ZooshopBD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlDataAdapter dataAdapter;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter($"Select [Login] as 'Login', [Password] as 'Password', [Role] as 'Role' from [dbo].[Users]", connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                bool flex = false;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i][0].ToString() == textBox1.Text && ds.Tables[0].Rows[i][1].ToString() == textBox2.Text)
                    {
                        BDFlex bDFlex = new BDFlex(ds.Tables[0].Rows[i][2].ToString());
                        bDFlex.ShowDialog();
                        flex = true;
                        break;
                    }
                }

                if (flex == false) MessageBox.Show("Неправльный логин или пароль.");
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
}
