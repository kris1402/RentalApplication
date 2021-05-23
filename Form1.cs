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
    public partial class Formula : Form
    {
        public Formula()
        {
            InitializeComponent();
            Autono();
            itemReg();
            load();
        }



        //public string conString = "Data Source=DESKTOP-3N6GONB\\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True";
        //SqlConnection con = new SqlConnection(conString);
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3N6GONB\\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        string proid;
        string sql;
        bool Mode = true;

        /*----------------*/
        SqlCommand cmd_1;
        SqlDataReader dr_1;
        string proid_1;
        /*----------------*/
        Double dailyRate;
        Double daysRent;
        Double No_of_days;
        Double discount;


        private void button1_Click(object sender, EventArgs e)
        {
            
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into Customer(ID,Tittle,Name,Surname,Street,PostCode,Area) values('"+txtID.Text.ToString()+ "','" + txtTittle.Text.ToString() + "','" + txtName.Text.ToString()+ "','" + txtSurname.Text.ToString() + "','" + textStreet.Text.ToString() + "','" + textPostCode.Text.ToString() + "','" + txtArea.Text.ToString() + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Connected Successfuly! ");
            }
            con.Close();
        }


        public void Autono()
        {
             sql = "select id from Customers order by id desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;

                proid = id.ToString("00000");

                MessageBox.Show("Pierwszy if id = " + proid);


            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("00000");
                MessageBox.Show("Else if = " + proid);

            }
            else
            {
                proid = ("00000");
                MessageBox.Show("Else = " + proid);

            }

            
            txtID.Text = proid.ToString();

            con.Close();

        }

        public void itemReg()
        {
            string sql = "select regNumber from itemRegistration order by regNumber desc";
            cmd_1 = new SqlCommand(sql, con);
            con.Open();
            dr_1 = cmd_1.ExecuteReader();


            if (dr_1.Read())
            {
                int id = int.Parse(dr_1[0].ToString()) + 1;

                proid_1 = id.ToString("00000");

                MessageBox.Show("Pierwszy if id = " + proid_1);


            }
            else if (Convert.IsDBNull(dr_1))
            {
                proid_1 = ("00000");
                MessageBox.Show("Else if = " + proid_1);

            }
            else
            {
                proid_1 = ("00000");
                MessageBox.Show("Else = " + proid_1);

            }

            txtregnum.Text = proid_1.ToString();

            con.Close();

        }

        public void load()
        {
            sql = "select * from itemRegistration";
            cmd_1 = new SqlCommand(sql, con);
            con.Open();
            dr_1 = cmd_1.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr_1.Read())
            {
                dataGridView1.Rows.Add(dr_1[0], dr_1[1], dr_1[2], dr_1[3]);
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string regNumber = txtregnum.Text;
            string make = txtmake.Text;
            string model = txtmodel.Text;
            string available = txtavl.SelectedItem.ToString();

            if(Mode == true)
            {
                sql = "insert into itemRegistration(regNumber, make, model, available) values(@regNumber, @make, @model, @available)";
                con.Open();
                cmd_1 = new SqlCommand(sql,con);
                cmd_1.Parameters.AddWithValue("@regNumber", regNumber);
                cmd_1.Parameters.AddWithValue("@make", make);
                cmd_1.Parameters.AddWithValue("@model", model);
                cmd_1.Parameters.AddWithValue("@available", available);
                cmd_1.ExecuteNonQuery();
                MessageBox.Show("Record Added");

            }
            else
            {
                MessageBox.Show("Record not added!");
            }
            con.Close();
        }

        private void totalButton_Click(object sender, EventArgs e)
        {
            Double CostofRenting;
            Double totalR;
            Double Discount_Rate;

            if (number_of_DaysTextBox.Text == " ")
            {
                MessageBox.Show("Enter Number of Days", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                number_of_DaysTextBox.Focus();
            }
            else{
                dailyRate = Double.Parse(dailyRateTextBox.Text);
                No_of_days = Double.Parse(number_of_DaysTextBox.Text);
                discount = Double.Parse(discountTextBox.Text);
                CostofRenting = dailyRate * No_of_days;
                Discount_Rate = ((CostofRenting) * discount) / 100;
                totalR = CostofRenting;
                totalR = totalR - Discount_Rate;

                total_CostTextBox.Text = String.Format("{0:C}", totalR);
            }
        }


    }


}
