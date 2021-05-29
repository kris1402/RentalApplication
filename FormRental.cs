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
        }


        /*----------------*/
        Double dailyRate;
        Double daysRent;
        Double No_of_days;
        Double discount;




        /*Connection*/
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3N6GONB\\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");


        string sql;
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
                    //MessageBox.Show("Wyn; " + totalR);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string itemId = comboBoxItemID.SelectedItem.ToString();
            string txtCustomerId = txtCustomerID.Text;


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

    }
}
