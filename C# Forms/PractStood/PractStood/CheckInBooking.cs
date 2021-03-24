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
    public partial class CheckInBooking : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        string ID, StatusTenant, Type_user;
        DataTable TenantleTable;
        public CheckInBooking(string ID, string StatusTenant, string Type_user)
        {
            InitializeComponent();
            this.ID = ID;
            this.StatusTenant = StatusTenant;
            this.Type_user = Type_user;


            if (Type_user == "1")
            {
                PeopleCoutComboBox.Items.Add("1");
                PeopleCoutComboBox.Items.Add("2");
                PeopleCoutComboBox.Items.Add("3");
                PeopleCoutComboBox.Items.Add("4");
            }
            if (Type_user == "2")
            {
                int count = 12;
                while (count < 40)
                {
                    PeopleCoutComboBox.Items.Add(count);
                    count++;
                }
            }

            StartDatePicker.MinDate = DateTime.Now.AddDays(8);
            FinishDatePicker.MinDate = StartDatePicker.Value.AddDays(1);
        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (StartDatePicker.Value >= DateTime.Now.Date.AddDays(7) && FinishDatePicker.Value >= StartDatePicker.Value.AddDays(1) && PeopleCoutComboBox.SelectedIndex > -1)
            {
                AmountLabel.Text = (Convert.ToDouble((FinishDatePicker.Value - StartDatePicker.Value).Days) * 300 * Convert.ToInt32(PeopleCoutComboBox.SelectedItem.ToString())).ToString() + " $";
            }
            else AmountLabel.Text = "0 $";
        }

        private void FinishDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (StartDatePicker.Value >= DateTime.Now.Date.AddDays(7) && FinishDatePicker.Value >= StartDatePicker.Value.AddDays(1) && PeopleCoutComboBox.SelectedIndex > -1)
            {
                AmountLabel.Text = (Convert.ToDouble((FinishDatePicker.Value - StartDatePicker.Value).Days) * 300 * Convert.ToInt32(PeopleCoutComboBox.SelectedItem.ToString())).ToString() + " $";
            }
            else AmountLabel.Text = "0 $";
        }

        private void PeopleCoutComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

            if (StartDatePicker.Value >= DateTime.Now.Date.AddDays(7) && FinishDatePicker.Value >= StartDatePicker.Value.AddDays(1) && PeopleCoutComboBox.SelectedIndex > -1)
            {
                AmountLabel.Text = (Convert.ToDouble((FinishDatePicker.Value - StartDatePicker.Value).Days) * 300 * Convert.ToInt32(PeopleCoutComboBox.SelectedItem.ToString())).ToString() + " $";
            }
            else AmountLabel.Text = "0 $";
        }

        private void CheckInBooking_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            if (HotelsComboBox.SelectedIndex > -1 && PeopleCoutComboBox.SelectedIndex > -1 &&
                FinishDatePicker.Value >= StartDatePicker.Value.AddDays(1))
            {

                int AmountPay;
                int.TryParse(string.Join("", AmountLabel.Text.Where(c => char.IsDigit(c))), out AmountPay);
                this.Hide();
                Pay pay = new Pay(AmountPay.ToString(), ID, StartDatePicker.Value.ToShortDateString(), FinishDatePicker.Value.ToShortDateString(), Type_user, HotelsComboBox.SelectedItem.ToString(), PeopleCoutComboBox.SelectedItem.ToString()); ;
                pay.ShowDialog();

            }

        }

        private void CheckInBooking_Load(object sender, EventArgs e)
        {

            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter($"select [Class_hotel], [All_quantity_people], [Time_Check_In],[Time_Eviction] from Reservations inner join Tenant on Tenant.[User_ID] = '{ID}'", connection);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                TenantleTable = ds.Tables[0];

                dataAdapter = new SqlDataAdapter("select Class_hotel from hostel", connection);
                DataSet ClassH = new DataSet();
                dataAdapter.Fill(ClassH);

                int rows = 0;
                while (rows < ClassH.Tables[0].Rows.Count)
                {
                    HotelsComboBox.Items.Add(ClassH.Tables[0].Rows[rows][0].ToString());
                    rows++;
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

            if (StatusTenant == "true")
            {

                HotelsComboBox.SelectedValue = TenantleTable.Rows[0][0].ToString();
                PeopleCoutComboBox.SelectedValue = TenantleTable.Rows[0][1].ToString();
                StartDatePicker.Value = Convert.ToDateTime(TenantleTable.Rows[0][2]);
                FinishDatePicker.Value = Convert.ToDateTime(TenantleTable.Rows[0][3]);

               
                PayButton.Visible = false;
            }
            else
            {
                
                PayButton.Visible = true;
                StartDatePicker.Value = DateTime.Now.Date.AddDays(9);
                FinishDatePicker.Value = StartDatePicker.Value.AddDays(1);
                PeopleCoutComboBox.SelectedIndex = 0;
                HotelsComboBox.SelectedIndex = 0;
                if (StartDatePicker.Value > DateTime.Now.Date.AddDays(7) && FinishDatePicker.Value >= StartDatePicker.Value.AddDays(1) && PeopleCoutComboBox.SelectedIndex > -1)
                {
                    AmountLabel.Text = (Convert.ToDouble((FinishDatePicker.Value - StartDatePicker.Value).Days) * 300 * Convert.ToInt32(PeopleCoutComboBox.SelectedItem.ToString())).ToString() + " $";
                }
            }
        }
    }
}
