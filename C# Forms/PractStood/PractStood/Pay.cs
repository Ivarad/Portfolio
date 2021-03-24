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
    public partial class Pay : Form
    {
        string connectionString = @"Server=DESKTOP-TTDS29I\MYUDALFLEX;Initial Catalog=Guest_BD;User ID=sa;Password=Flexuser";
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;

        private Label label1;
        private MaskedTextBox CardNumber;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button PayBut;
        private MaskedTextBox Month;
        private MaskedTextBox Year;
        private MaskedTextBox CVV;
        private string Amount, IdUser, StDate, FinDate, Type_user, Hostel, CountPeople, Debs;
        private int AmountPay;
        private double ServAmount;
        public Pay(string Amount, string IdUser, string StDate, string FinDate, string Type_user, string Hostel, string CountPeople)
        {
            InitializeComponent();
            this.Amount = Amount;
            this.IdUser = IdUser;
            this.StDate = StDate;
            this.FinDate = FinDate;
            this.Type_user = Type_user;
            AmountPay = Convert.ToInt32(Amount);
            this.Hostel = Hostel;
            this.CountPeople = CountPeople;
        }

        public Pay(string Debs, string IdUser, string Type_user)
        {
            InitializeComponent();
            this.Debs = Debs;
            this.IdUser = IdUser;
            this.Type_user = Type_user;
            ServAmount = Convert.ToDouble(Debs);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CardNumber = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PayBut = new System.Windows.Forms.Button();
            this.Month = new System.Windows.Forms.MaskedTextBox();
            this.Year = new System.Windows.Forms.MaskedTextBox();
            this.CVV = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(155, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Номер карты";
            // 
            // CardNumber
            // 
            this.CardNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.CardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CardNumber.Location = new System.Drawing.Point(105, 48);
            this.CardNumber.Mask = "0000-0000-0000-0000";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.Size = new System.Drawing.Size(204, 29);
            this.CardNumber.TabIndex = 20;
            this.CardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "ММ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(137, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "ГГ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(23, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 24);
            this.label4.TabIndex = 25;
            this.label4.Text = "CVV:";
            // 
            // PayBut
            // 
            this.PayBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.PayBut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PayBut.FlatAppearance.BorderSize = 2;
            this.PayBut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PayBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PayBut.ForeColor = System.Drawing.Color.Black;
            this.PayBut.Location = new System.Drawing.Point(141, 254);
            this.PayBut.Name = "PayBut";
            this.PayBut.Size = new System.Drawing.Size(132, 35);
            this.PayBut.TabIndex = 27;
            this.PayBut.Text = "Оплатить";
            this.PayBut.UseVisualStyleBackColor = false;
            this.PayBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // Month
            // 
            this.Month.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.Month.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Month.Location = new System.Drawing.Point(83, 100);
            this.Month.Mask = "00";
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(33, 29);
            this.Month.TabIndex = 28;
            this.Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Year
            // 
            this.Year.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.Year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Year.Location = new System.Drawing.Point(180, 100);
            this.Year.Mask = "0000";
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(62, 29);
            this.Year.TabIndex = 29;
            this.Year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CVV
            // 
            this.CVV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(198)))), ((int)(((byte)(233)))));
            this.CVV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CVV.Location = new System.Drawing.Point(83, 153);
            this.CVV.Mask = "000";
            this.CVV.Name = "CVV";
            this.CVV.Size = new System.Drawing.Size(46, 29);
            this.CVV.TabIndex = 30;
            this.CVV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pay
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(188)))));
            this.ClientSize = new System.Drawing.Size(382, 294);
            this.Controls.Add(this.CVV);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.PayBut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CardNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(398, 333);
            this.MinimumSize = new System.Drawing.Size(398, 333);
            this.Name = "Pay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Debs == null)
            {

                if (CardNumber.Text.Length == 19 && Convert.ToInt32(Month.Text) > 0 &&
                Convert.ToInt32(Month.Text) <= 12 && Convert.ToInt32(Year.Text) > DateTime.Now.Year)
                {

                    connection = new SqlConnection(connectionString);
                    try
                    {
                        connection.Open();

                        dataAdapter = new SqlDataAdapter($"select ID_room from Hostel_number where Employment = 0", connection);
                        DataSet IDroom = new DataSet();
                        dataAdapter.Fill(IDroom);

                        dataAdapter = new SqlDataAdapter($"select First_name from [User] where ID_user = '{IdUser}'", connection);
                        DataSet NameOrg = new DataSet();
                        dataAdapter.Fill(NameOrg);

                        dataAdapter = new SqlDataAdapter($"select Hotel_ID from Hostel_number where ID_room = '{IDroom.Tables[0].Rows[0][0]}'", connection);
                        DataSet Hotel = new DataSet();
                        dataAdapter.Fill(Hotel);

                        if (Type_user == "1")
                        {
                            cmd = new SqlCommand($"insert into Reservations (Class_hotel,All_quantity_people,Status_cancel,Time_Check_In,Time_Eviction) values ('{Hostel}',{Convert.ToInt32(CountPeople)},0,'{StDate}','{FinDate}')", connection);
                            cmd.ExecuteNonQuery();

                            dataAdapter = new SqlDataAdapter($"select IDENT_CURRENT ('Reservations')", connection);
                            DataSet BookingID = new DataSet();
                            dataAdapter.Fill(BookingID);

                            cmd = new SqlCommand($"insert into Tenant (Feedback_Tenant,Report,Debts_Tenant,Booking_ID,[Date_Eviction],DLC_cost,[User_ID]) values ('','',0,'{BookingID.Tables[0].Rows[0][0]}','{FinDate}',0,'{IdUser}')", connection);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand($"update Hostel_number set DLC_service_ID = 3, Popularity_numbers = Popularity_numbers + 1, Employment = 1, Booking_ID = '{BookingID.Tables[0].Rows[0][0]}' where ID_room = {IDroom.Tables[0].Rows[0][0]}", connection);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand($"update [User] set Status_tenant = 1 where [ID_user] = '{IdUser}'", connection);
                            cmd.ExecuteNonQuery();
                        }
                        if (Type_user == "2")
                        {
                            AmountPay -= (AmountPay / 100) * 40;
                            int roomscount = Convert.ToInt32(CountPeople) / 4;
                            cmd = new SqlCommand($"insert into Contracts (Discount,Time_CheckIn,Time_eviction, Quantity_peopole, Busy_rooms) values (40,'{StDate}','{FinDate}',{Convert.ToInt32(CountPeople)},{roomscount})", connection);
                            cmd.ExecuteNonQuery();

                            dataAdapter = new SqlDataAdapter($"select IDENT_CURRENT ('Contracts')", connection);
                            DataSet IDContract = new DataSet();
                            dataAdapter.Fill(IDContract);
                            int rooms = Convert.ToInt32(IDroom.Tables[0].Rows[0][0]);
                            while (roomscount > 0)
                            {
                                cmd = new SqlCommand($"update Hostel_number set DLC_service_ID = 3, Popularity_numbers = Popularity_numbers + 1, Employment = 1, Contract_ID = '{IDContract.Tables[0].Rows[0][0]}' where ID_room = {rooms}", connection);
                                cmd.ExecuteNonQuery();
                                rooms++;
                                roomscount--;
                            }

                            cmd = new SqlCommand($"update [User] set Status_tenant = 1 where [ID_user] = '{IdUser}'", connection);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand($"insert into Organiations (Name_organization,Contract_ID,Characteristics_group,[User_ID]) values ('{NameOrg.Tables[0].Rows[0][0].ToString()}','{IDContract.Tables[0].Rows[0][0]}','Группа организации { NameOrg.Tables[0].Rows[0][0].ToString() }','{IdUser}')", connection);
                            cmd.ExecuteNonQuery();

                        }
                        

                        dataAdapter = new SqlDataAdapter($"select Type_user from [User] where [ID_user] = {IdUser}", connection);
                        DataSet type = new DataSet();
                        dataAdapter.Fill(type);

                        cmd = new SqlCommand($"update Hostel set Revenue = Revenue + {Convert.ToDouble(Amount)} where ID_Hostel = '{Hotel.Tables[0].Rows[0][0]}'", connection);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Успешная оплата!");

                        if (type.Tables[0].Rows[0][0].ToString() == "1")
                        {
                            this.Hide();
                            Guest guest = new Guest(IdUser, "1", Type_user);
                            guest.ShowDialog();
                        }
                        if (type.Tables[0].Rows[0][0].ToString() == "2")
                        {
                            this.Hide();
                            EmloyeesCherfulness emloyeesCherfulness = new EmloyeesCherfulness(IdUser, StDate, FinDate,"1",Type_user);
                            emloyeesCherfulness.ShowDialog();


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

                }
                else MessageBox.Show("Неправильные данные!");
            }
            else
            {
                connection = new SqlConnection(connectionString);

                try
                {
                    connection.Open();

                    dataAdapter = new SqlDataAdapter($"select [ID_room] from Hostel_number inner join Tenant on [User_ID] = '{IdUser}' where Hostel_number.Booking_ID = Tenant.Booking_ID", connection);
                    DataSet IDroom = new DataSet();
                    dataAdapter.Fill(IDroom);

                    dataAdapter = new SqlDataAdapter($"select Hotel_ID from Hostel_number where ID_room = '{IDroom.Tables[0].Rows[0][0].ToString()}'", connection);
                    DataSet Hotel = new DataSet();
                    dataAdapter.Fill(Hotel);

                    cmd = new SqlCommand($"update Tenant set Debts_Tenant = 0 where [User_ID] = '{IdUser}'", connection);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand($"update Hostel set Revenue += {ServAmount} where ID_Hostel = '{Hotel.Tables[0].Rows[0][0]}' ", connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Успешная оплата!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка");
                }
                finally
                {
                    connection.Close();
                    this.Close();
                    this.Hide();
                    MenuBuyer menuBuyer = new MenuBuyer(IdUser, "1", Type_user);
                    menuBuyer.ShowDialog();
                }
            }
        }
    }
}
