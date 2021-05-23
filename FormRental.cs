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
    public partial class FormRental : Form
    {
        public FormRental()
        {
            InitializeComponent();
        }


        /*----------------*/
        Double dailyRate;
        Double daysRent;
        Double No_of_days;
        Double discount;


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
                }
            }
        }
    }
}
