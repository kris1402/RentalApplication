using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SQL
{
    public partial class Form_Reg : Form
    {
        public Form_Reg()
        {
            InitializeComponent();
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            string uname = txtUser.Text;
            string pass = txtPass.Text;
            if(uname.Equals("admin") && pass.Equals("qwe"))
            {
                Main m = new Main();
                this.Hide();
                m.Show();
            }
            else
            {
                MessageBox.Show("Wrong Password");
                txtUser.Clear();
                txtPass.Clear();
                txtUser.Focus();
            }
        }
    }
}
