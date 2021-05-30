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
using Microsoft.Reporting.WinForms;

namespace Project_SQL.Report
{
    public partial class printingInvoiceForm : Form
    {

        string sql;
        SqlCommand cmd;

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3N6GONB\\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");
        public printingInvoiceForm()
        {
            InitializeComponent();
        }

        private void printingInvoiceForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM view_All_Bill_Invoice WHERE InvoiceNumber = '" + txt_Invoice_ID.Text + "' ", con);
            //con.Open();
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "DataTable_Invoice");
            ReportDataSource datasource = new ReportDataSource("DataSet_Report", ds.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();

            /*cmd = new SqlCommand("Select * from itemRegistration", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxItemID.Items.Add(dr["regNumber"].ToString());
            }*/
            //con.Close();
        }
    }
}
