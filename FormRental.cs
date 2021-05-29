using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_SQL
{
    public partial class FormRental : Form
    {
        public FormRental()
        {
            InitializeComponent();
            itemLoad();
            regLoad();
        }


        /*----------------*/
        Double dailyRate;
        Double daysRent;
        Double No_of_days;
        Double discount;




        /*Connection*/
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3N6GONB\\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");


        string sql;
        string sql1;
        string proid;
        SqlCommand cmd;
        SqlDataReader dr;
        /*----------------*/
        SqlCommand cmd_1;
        SqlDataReader dr_1;
        string proid_1;
        bool Mode = true;
        string id;



        public void itemLoad()
        {
            cmd = new SqlCommand("Select * from itemRegistration", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxItemID.Items.Add(dr["regNumber"].ToString());
            }
            con.Close();
        }

        /*static double calculateFinalRate(string dailyRateTextBox, string number_of_DaysTextBox, string discountTextBox)
        {
            Double CostofRenting;
            Double totalR;
            Double Discount_Rate;
            Double dailyRate;
            Double No_of_days;
            Double discount;

            if (number_of_DaysTextBox.Text == " ")
            {
                MessageBox.Show("Enter Number of Days", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                number_of_DaysTextBox.Focus();
                totalR = 0;
            }
            else
            {
                dailyRate = Double.Parse(dailyRateTextBox.Text);
                No_of_days = Double.Parse(number_of_DaysTextBox.Text);
                discount = Double.Parse(discountTextBox.Text);
                CostofRenting = dailyRate * No_of_days;
                Discount_Rate = ((CostofRenting) * discount) / 100;
                totalR = CostofRenting;
                totalR = totalR - Discount_Rate;


                //total_CostTextBox.Text = String.Format("{0:C}", totalR);
                //MessageBox.Show("Wyn; " + totalR);
            }
            return totalR;
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            {
                Double CostofRenting;
                Double totalR;
                Double Discount_Rate;

                if (number_of_DaysTextBox.Text == " ")
                {
                    MessageBox.Show("Enter Number of Days", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    number_of_DaysTextBox.Focus();
                }
                else
                {
                    dailyRate = Double.Parse(dailyRateTextBox.Text);
                    No_of_days = Double.Parse(number_of_DaysTextBox.Text);
                    discount = Double.Parse(discountTextBox.Text);
                    CostofRenting = dailyRate * No_of_days;
                    Discount_Rate = ((CostofRenting) * discount) / 100;
                    totalR = CostofRenting;
                    totalR = totalR - Discount_Rate;

                    total_CostTextBox.Text = String.Format("{0:C}", totalR);
                    //total_CostTextBox.Text = totalR.ToString();
                }
            }


            //Adding Invoice Number

            //----------------//
            cmd = new SqlCommand("Select * from itemRegistration where regNumber = '" + comboBoxItemID.Text + "'   ", con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                /*Validation if No nothing can be done*/
                string aval;
                aval = ("INV/" + DateTime.Now.Year.ToString() +"/" + DateTime.Now.Month.ToString() + "/" + dr["regNumber"].ToString());
                invNum1.Text = aval;

            }
            else
            {
                invNum1.Text = "NOT Available";
            }
            con.Close();
            //----------------//


        }

        private void comboBoxItemID_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * from itemRegistration where regNumber = '" + comboBoxItemID.Text + "'   ", con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                /*Validation if No nothing can be done*/
                string aval;
                aval = (dr["Available"].ToString());
                labelStatus.Text = aval;

                if (aval == "No")
                {
                    txtCustomerID.Enabled = false;
                    cutomerName.Enabled = false;
                    dailyRateTextBox.Enabled = false;
                    discountTextBox.Enabled = false;
                    number_of_DaysTextBox.Enabled = false;

                }
            }
            else
            {
                labelStatus.Text = "NOT Available";
            }
            con.Close();
        }

        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmd = new SqlCommand("Select * from Customers where ID = '" + txtCustomerID.Text + "'   ", con);
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cutomerName.Text = dr["Name"].ToString();
                }
                else
                {
                    MessageBox.Show("Customer Not Found");
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Main m = new Main();
                this.Hide();
                m.Show();
        }



        public void regLoad()
        {
            sql = "select * from ReNTalItems";
            cmd_1 = new SqlCommand(sql, con);
            con.Open();
            dr_1 = cmd_1.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr_1.Read())
            {
                dataGridView1.Rows.Add(dr_1[1], dr_1[2], dr_1[3], dr_1[4], dr_1[7], dr_1[8], dr_1[10], dr_1[11]);
            }
            con.Close();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string itemId = comboBoxItemID.SelectedItem.ToString();
            string txtCustomerId = txtCustomerID.Text;
            string custName = cutomerName.Text;
            string dailyRate = dailyRateTextBox.Text;
            string discountBox = discountTextBox.Text;
            string paymentMethod = comboBox1.SelectedItem.ToString();
            string rentalDate = dateRental.Value.Date.ToString("yyyy-MM-dd");
            string dueDate = dateToDate.Value.Date.ToString("yyyy-MM-dd");
            string numDays = number_of_DaysTextBox.Text;
            string total = total_CostTextBox.Text;
            string invNum = invNum1.Text;
            string avl = labelStatus.Text;






            sql = "insert into ReNTalItems(Item_ID, Customer_ID, CustomerName, DailyRate, Discount, PaymentMethod, RentalDate,DueDate, NumberOfDays, TotalToPay,InvoiceNumber) " +
                "values(@Item_ID, @Customer_ID, @CustomerName, @DailyRate, @Discount, @PaymentMethod, @RentalDate,@DueDate, @NumberOfDays, @TotalToPay,@InvoiceNumber)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Item_ID", itemId);
            cmd.Parameters.AddWithValue("@Customer_ID", txtCustomerId);
            cmd.Parameters.AddWithValue("@CustomerName", custName);
            cmd.Parameters.AddWithValue("@DailyRate", dailyRate);
            cmd.Parameters.AddWithValue("@Discount", discountBox);

            cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
            cmd.Parameters.AddWithValue("@RentalDate", rentalDate);
            cmd.Parameters.AddWithValue("@DueDate", dueDate);

            cmd.Parameters.AddWithValue("@NumberOfDays", numDays);
            cmd.Parameters.AddWithValue("@TotalToPay", total);
            cmd.Parameters.AddWithValue("@InvoiceNumber", invNum);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Added");

            sql1 = "update itemRegistration set Available = 'No' where regNumber = @regNumber";
            
            cmd_1 = new SqlCommand(sql1, con);
            cmd_1.Parameters.AddWithValue("@regNumber", itemId);
            cmd_1.ExecuteNonQuery();
            MessageBox.Show("Record Updatted");
            con.Close();
            //comboBoxItemID.SelectedItem.ToString();
            txtCustomerID.Clear();
            cutomerName.Clear();
            dailyRateTextBox.Clear();
            discountTextBox.Clear();
            comboBox1.Items.Clear();
            //dateRental.Value.Date.ToString("yyyy-MM-dd");
            //dateToDate.Value.Date.ToString("yyyy-MM-dd");
            number_of_DaysTextBox.Clear();
            total_CostTextBox.Clear();
            txtCustomerID.Focus();
            //invNum1.Clear();
            //labelStatus.Clear();
            /*string regNumber = txtID.Text;
            string typeEqu = comboBoxType.SelectedItem.ToString();
            //string model = txtmodel.Text;
            string comStyle = comboBoxStyle.SelectedItem.ToString();
            string available = comboBoxAvl.SelectedItem.ToString();
            string skiLen = txtSkiLen.Text;
            string skiMod = txtModel.Text;*/

            /*if (Mode == true)
            {
                //sql = "insert into itemRegistration(regNumber, TypeOfEquimpent,SkiStyle, Available, SkiLenght,SkiModel) values(@regNumber,@TypeOfEquimpent, @SkiStyle, @Available, @SkiLenght, @SkiModel)";
                sql = "sp_I_item";
                con.Open();
                cmd_1 = new SqlCommand(sql, con);
                cmd_1.CommandType = CommandType.StoredProcedure;
                cmd_1.Parameters.AddWithValue("@TypeOfEquimpent", typeEqu);
                cmd_1.Parameters.AddWithValue("@SkiStyle", comStyle);
                cmd_1.Parameters.AddWithValue("@Available", available);
                cmd_1.Parameters.AddWithValue("@SkiLenght", skiLen);
                cmd_1.Parameters.AddWithValue("@SkiModel", skiMod);
                cmd_1.ExecuteNonQuery();
                MessageBox.Show("Record Added");
            }
            else
            {
                MessageBox.Show("Record not added!");
            }
            con.Close();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime startTime = dateRental.Value;
            DateTime endTime = dateToDate.Value;

            TimeSpan duration = new TimeSpan(endTime.Ticks - startTime.Ticks);
            
            number_of_DaysTextBox.Text = duration.ToString(@"dd");/*comment*/
 
        }
    }
}
