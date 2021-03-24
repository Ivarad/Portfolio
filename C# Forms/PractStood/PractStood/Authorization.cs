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
    public partial class Authorization : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        string ID, StatusTenant, Type_user;
        public Authorization()
        {
            InitializeComponent();
            
            LoginTextBox.Text = "Введите логин";
            PasswordTextBox.Text = "Введите пароль";
               
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            
            if (((TextBox)sender).Name == "LoginTextBox")
                if (((TextBox)sender).Text == "Введите логин") ((TextBox)sender).Text = "";

            if (((TextBox)sender).Name == "PasswordTextBox")
            {
                if (((TextBox)sender).Text == "Введите пароль") ((TextBox)sender).Text = "";
                PasswordTextBox.PasswordChar = '*';
            }
                
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name == "LoginTextBox")
                if (((TextBox)sender).Text == "") ((TextBox)sender).Text = "Введите логин";

            if (((TextBox)sender).Name == "PasswordTextBox")
                if (((TextBox)sender).Text == "")
                {
                    PasswordTextBox.PasswordChar = '\0';
                    ((TextBox)sender).Text = "Введите пароль";
                }
        }

        private void ToRegButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }

        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                dataAdapter = new SqlDataAdapter($"select [User].[Login], [User].[Password], [User].[Type_user], [User].[ID_user], [User].[Status_tenant] from dbo.[User] where [User].[Login] = '{LoginTextBox.Text}'",connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);


                if (PasswordTextBox.Text == ds.Tables[0].Rows[0][1].ToString())
                {
                    if(ds.Tables[0].Rows[0][2].ToString() == "1")
                    {
                        ID = ds.Tables[0].Rows[0][3].ToString();
                        StatusTenant = ds.Tables[0].Rows[0][4].ToString();
                        Type_user = ds.Tables[0].Rows[0][2].ToString();

                        this.Hide();
                        MenuBuyer menuBuyer = new MenuBuyer(ID, StatusTenant, Type_user);
                        menuBuyer.Show();
                        
                    }
                    if (ds.Tables[0].Rows[0][2].ToString() == "2")
                    {
                        ID = ds.Tables[0].Rows[0][3].ToString();
                        StatusTenant = ds.Tables[0].Rows[0][4].ToString();
                        Type_user = ds.Tables[0].Rows[0][2].ToString();

                       dataAdapter = new SqlDataAdapter($"select Time_CheckIn,Time_eviction from Contracts inner join Organiations on [User_ID] = '{ID}' where ID_contract = Contract_ID", connection);
                        DataSet Dates = new DataSet();
                        dataAdapter.Fill(Dates);

                        this.Hide();
                        if (Dates.Tables[0].Rows.Count > 0)
                        {
                            MenuOrganization menuOrganization = new MenuOrganization(ID, StatusTenant, Type_user, Dates.Tables[0].Rows[0][0].ToString(), Dates.Tables[0].Rows[0][1].ToString());
                            menuOrganization.Show();
                        }
                        else
                        {
                            MenuOrganization menuOrganization = new MenuOrganization(ID, StatusTenant, Type_user, "", "");
                            menuOrganization.Show();
                        }
                 

                    }
                    if (ds.Tables[0].Rows[0][2].ToString() == "3")
                    {
                        this.Hide();
                        MenuEmployee menuEmployee = new MenuEmployee();
                        menuEmployee.ShowDialog();
                    }

                }
                else MessageBox.Show("Неправильный пароль!");

            }
            catch (Exception ex)
            {
               MessageBox.Show("Неправильный логин!");
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
