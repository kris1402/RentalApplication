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
    public partial class FormItem : Form
    {
        public FormItem()
        {
            InitializeComponent();
            Autono();
            itemReg();
            load();
        }

        SqlCommand cmd_1;
        SqlDataReader dr_1;
        string proid_1;
        bool Mode = true;


        string sql;
        SqlCommand cmd;
        SqlDataReader dr;
        string proid;



        /*Connection*/
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3N6GONB\\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");


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

            txtID.Text = proid_1.ToString();

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
                //dataGridView1.Rows.Add(dr_1[0], dr_1[1], dr_1[2], dr_1[3]);
            }
            con.Close();

        }




        private void button1_Click(object sender, EventArgs e)
        {
            string regNumber = txtID.Text;
            string typeEqu = comboBoxType.SelectedItem.ToString();
            //string model = txtmodel.Text;
            string comStyle = comboBoxStyle.SelectedItem.ToString();
            string available = comboBoxAvl.SelectedItem.ToString();
            string skiLen = txtSkiLen.Text;
            string skiMod = txtModel.Text;

            if (Mode == true)
            {
                sql = "insert into itemRegistration(regNumber, TypeOfEquimpent,SkiStyle, Available, SkiLenght,SkiModel) values(@regNumber,@TypeOfEquimpent, @SkiStyle, @Available, @SkiLenght, @SkiModel)";
                con.Open();
                cmd_1 = new SqlCommand(sql, con);
                cmd_1.Parameters.AddWithValue("@regNumber", regNumber);
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
            con.Close();
        }
    }
}
