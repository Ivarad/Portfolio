using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PractStood
{
    public partial class Registration : Form //1..4
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;

        public Registration()
        {
            InitializeComponent();
            RoleComboBox.Items.Add("Покупатель");
            RoleComboBox.Items.Add("Организация");

            RoleComboBox.SelectedIndex = 0;

            NameTextBox.Text = "Введите имя";
            SurnameTextBox.Text = "Введите фамилию";
            PatranomicTextBox.Text = "Введите отчетсво(если есть)";
            LoginTextBox.Text = "Введите логин";
            PasswordTextBox.Text = "Введите пароль";


        }

        private void ToAuthButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization authorization = new Authorization();
            authorization.Show();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if(RoleComboBox.SelectedIndex == 0)
            {
                if (NameTextBox.Text != "" && SurnameTextBox.Text != "" && PatranomicTextBox.Text != ""
                && RoleComboBox.SelectedIndex > -1 && LoginTextBox.Text != "" && PasswordTextBox.Text != "" &&
                NameTextBox.Text != "Введите имя" && PatranomicTextBox.Text != "Введите фамилию"
                && LoginTextBox.Text != "Введите логин" && PasswordTextBox.Text != "Введите пароль")
                {
                    if (LoginTextBox.Text.Length > 8 && PasswordTextBox.Text.Length > 8 && !LoginTextBox.Text.Contains(" ") && !PasswordTextBox.Text.Contains(" "))
                    {
                        Registrationinsert();
                    }
                    else MessageBox.Show("Парлоль и логин должны быть больше 8 символов,а также не должны содержать пробелов!");
                }
                else MessageBox.Show("Все поля должны быть заполнены");
            }
            if(RoleComboBox.SelectedIndex == 1)
            {
                if (NameTextBox.Text != "" && RoleComboBox.SelectedIndex > -1 && LoginTextBox.Text != "" && PasswordTextBox.Text != "" &&
                NameTextBox.Text != "Введите имя" && LoginTextBox.Text != "Введите логин" && PasswordTextBox.Text != "Введите пароль")
                {
                    if (LoginTextBox.Text.Length > 8 && PasswordTextBox.Text.Length > 8 && !LoginTextBox.Text.Contains(" ") && !PasswordTextBox.Text.Contains(" "))
                    {
                        Registrationinsert();
                    }
                    else MessageBox.Show("Парлоль и логин должны быть больше 8 символов,а также не должны содержать пробелов!");
                }
                else MessageBox.Show("Все поля должны быть заполнены");
            }
            
            
        }

        private void Registrationinsert()
        {
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                if(RoleComboBox.SelectedIndex == 0)
                {
                    string patr = PatranomicTextBox.Text;
                    if (PatranomicTextBox.Text == "Введите отчетсво(если есть)" || PatranomicTextBox.Text == "") patr = "Отсутствует";
                    
                    cmd = new SqlCommand($"insert into dbo.[User] ([First_name],[Last_name],[Middle_name],[Type_user],[Login],[Password],[Status_tenant]) values ('{NameTextBox.Text}','{SurnameTextBox.Text}','{patr}','{RoleComboBox.SelectedIndex + 1}','{LoginTextBox.Text}','{PasswordTextBox.Text}','{0}')", connection);
                    cmd.ExecuteNonQuery();
                }
                if(RoleComboBox.SelectedIndex == 1)
                {
                    cmd = new SqlCommand($"insert into dbo.[User] ([First_name],[Last_name],[Middle_name],[Type_user],[Login],[Password],[Status_tenant]) values ('{NameTextBox.Text}','-','-','{RoleComboBox.SelectedIndex + 1}','{LoginTextBox.Text}','{PasswordTextBox.Text}','{0}')", connection);
                    cmd.ExecuteNonQuery();
                }
                
                MessageBox.Show("Успешная регистрация!");
                NameTextBox.Text = "";
                SurnameTextBox.Text = "";
                PatranomicTextBox.Text = "";
                LoginTextBox.Text = "";
                PasswordTextBox.Text = "";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    MessageBox.Show("Такой логин уже существует!");
                } 
                else MessageBox.Show("Ошибка");

            }
            finally
            {
                connection.Close();
            }
        }

        private void NameTextBox_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name == "NameTextBox")
                if (((TextBox)sender).Text == "Введите имя") ((TextBox)sender).Text = "";

            if (((TextBox)sender).Name == "SurnameTextBox")
                if (((TextBox)sender).Text == "Введите фамилию") ((TextBox)sender).Text = "";

            if (((TextBox)sender).Name == "PatranomicTextBox")
                if (((TextBox)sender).Text == "Введите отчетсво(если есть)") ((TextBox)sender).Text = "";

            if (((TextBox)sender).Name == "LoginTextBox")
                if (((TextBox)sender).Text == "Введите логин") ((TextBox)sender).Text = "";

            if (((TextBox)sender).Name == "PasswordTextBox")
            {
                if (((TextBox)sender).Text == "Введите пароль") ((TextBox)sender).Text = "";
                PasswordTextBox.PasswordChar = '*';
            }

        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name == "NameTextBox")
                if (((TextBox)sender).Text == "") ((TextBox)sender).Text = "Введите имя";

            if (((TextBox)sender).Name == "SurnameTextBox")
                if (((TextBox)sender).Text == "") ((TextBox)sender).Text = "Введите фамилию";

            if (((TextBox)sender).Name == "PatranomicTextBox")
                if (((TextBox)sender).Text == "") ((TextBox)sender).Text = "Введите отчетсво(если есть)";

            if (((TextBox)sender).Name == "LoginTextBox")
                if (((TextBox)sender).Text == "") ((TextBox)sender).Text = "Введите логин";

            if (((TextBox)sender).Name == "PasswordTextBox")
                if (((TextBox)sender).Text == "")
                {
                    PasswordTextBox.PasswordChar = '\0';
                    ((TextBox)sender).Text = "Введите пароль";
                }
        }

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RoleComboBox.SelectedIndex == 0)
            {
                NameTextBox.Visible = true;
                SurnameTextBox.Visible = true;
                PatranomicTextBox.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
            }
            if (RoleComboBox.SelectedIndex == 1)
            {
                NameTextBox.Visible = true;
                SurnameTextBox.Visible = false;
                PatranomicTextBox.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
            }
        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number)) e.Handled = true;

        }

        private void SurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number)) e.Handled = true;
        }

        private void PatranomicTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number)) e.Handled = true;
        }

        private void LoginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.Match(e.KeyChar.ToString(), @"\p{IsCyrillic}|\p{IsCyrillicSupplement}").Success) e.Handled = true;
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.Match(e.KeyChar.ToString(), @"\p{IsCyrillic}|\p{IsCyrillicSupplement}").Success) e.Handled = true;
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
