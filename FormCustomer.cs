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
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
            Autono();
            //load();
        }
        /*Connection*/
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3N6GONB\\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");


        string sql;
        string proid;
        SqlCommand cmd;
        SqlDataReader dr;



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




        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into Customers(ID,Tittle,Name,Surname,Street,PostCode,Area,Mobile) values('" + txtID.Text.ToString() + "','" + txtTittle.Text.ToString() + "','" + txtName.Text.ToString() + "','" + txtSurname.Text.ToString() + "','" + textStreet.Text.ToString() + "','" + textPostCode.Text.ToString() + "','" + txtArea.Text.ToString() + "', '" + int.Parse(mobile.Text) + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Connected Successfuly! ");
            }
            con.Close();
        }
    }
}
