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
            //load();
        }
        /*Connection*/
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3N6GONB\\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");

  

 



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
