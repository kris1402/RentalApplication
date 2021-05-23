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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void itemReg_Click(object sender, EventArgs e)
        {
            FormItem m = new FormItem();
            this.Hide();
            m.Show();

        }

        private void rental_Click(object sender, EventArgs e)
        {
            Formula m = new Formula();
            this.Hide();
            m.Show();
        }

        private void cust_Click(object sender, EventArgs e)
        {
            FormCustomer m = new FormCustomer();
            this.Hide();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormRental m = new FormRental();
            this.Hide();
            m.Show();
        }
    }
}
