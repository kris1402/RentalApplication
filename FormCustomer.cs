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
            load();
        }
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



        public void Autono()
        {
            sql = "select id from Customers order by id desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;

                proid = id.ToString("0");

                MessageBox.Show("Pierwszy if id = " + proid);


            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("0");
                MessageBox.Show("Else if = " + proid);

            }
            else
            {
                proid = ("0");
                MessageBox.Show("Else = " + proid);

            }


            txtID.Text = proid.ToString();

            con.Close();

        }

        public void load()
        {
            sql = "select * from Customers";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView2.Rows.Clear();

            while (dr.Read())
            {
                dataGridView2.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4],dr[5],dr[6],dr[7]);
            }
            con.Close();

        }


        private void button1_Click(object sender, EventArgs e)

        {
            string regCust = txtID.Text;
            string tittleCust = comboBoxTittle.SelectedItem.ToString();
            string nameCust = txtName.Text;
            string surnameCust = txtSurname.Text;
            string streetCust = textStreet.Text;
            string postCode = textPostCode.Text;
            string area = txtArea.Text;
            int mobileCust = int.Parse(mobile.Text);


            if (Mode == true)
            {
                //sql = "insert into Customers(ID, Tittle, Name, Surname,Street,PostCode,Area,Mobile) values(@ID, @Tittle, @Name, @Surname,@Street,@PostCode,@Area,@Mobile)";
                sql = "sp_I_customers";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", regCust);
                cmd.Parameters.AddWithValue("@Tittle", tittleCust);
                cmd.Parameters.AddWithValue("@Name", nameCust);
                cmd.Parameters.AddWithValue("@Surname", surnameCust);
                cmd.Parameters.AddWithValue("@Street", streetCust);

                cmd.Parameters.AddWithValue("@PostCode", postCode);
                cmd.Parameters.AddWithValue("@Area", area);
                cmd.Parameters.AddWithValue("@Mobile", mobileCust);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Added");

            }
            else
            {
                MessageBox.Show("Record not added!");
            }
            con.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
                Main m = new Main();
                this.Hide();
                m.Show();
        }
    }
}
