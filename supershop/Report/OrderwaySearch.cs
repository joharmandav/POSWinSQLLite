using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class OrderwaySearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public OrderwaySearch()
        {
            InitializeComponent();

            dtGrdvCustomerDetails.EnableHeadersVisualStyles = false;
            dtGrdvCustomerDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Select Button
            DataGridViewButtonColumn btnselect = new DataGridViewButtonColumn();
            dtGrdvCustomerDetails.Columns.Add(btnselect);
            btnselect.HeaderText = "Select";
            btnselect.Text = "Select";
            btnselect.Name = "Select";
            btnselect.UseColumnTextForButtonValue = true;
            btnselect.Width = 70;

        }

        public string PageName
        {
            set
            {
                lblPageName.Text = value;
            }
            get
            {
                return lblPageName.Text;
            }
        }

        private void OrderwaySearch_Load(object sender, EventArgs e)
        {
            try
            {
                Databind();
            }
            catch
            {
            }

        }
        public void Databind()
        {
            string sqlCmd = " select OrderWay as 'Order Way' from sales_item Where TenentID = " + Tenent.TenentID + " group by OrderWay ";

            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;

            dtGrdvCustomerDetails.Columns["Select"].DisplayIndex = 1;
            dtGrdvCustomerDetails.Columns["Select"].Width = 100;
        }

        private void txtOrderwaySearch_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderwaySearch.Text != "")
            {
                string Name = txtOrderwaySearch.Text;
                Name = Name.Trim();

                string sqlCmd = " select OrderWay as 'Order Way' from sales_item Where TenentID = " + Tenent.TenentID + " and OrderWay like '%" + Name + "%' group by OrderWay ";
                              
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                dtGrdvCustomerDetails.DataSource = dt1;

                dtGrdvCustomerDetails.Columns["Select"].DisplayIndex = 1;
                dtGrdvCustomerDetails.Columns["Select"].Width = 100;
            }
            else
            {
                Databind();
            }

        }

        private void dtGrdvCustomerDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrdvCustomerDetails.Columns["Select"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];

                    string OrderWay = row.Cells["Order Way"].Value.ToString();

                    salesreport mkc1 = (salesreport)Application.OpenForms["salesreport"];
                    mkc1.OrderWay = OrderWay;
                    mkc1.Show();

                    this.Close();
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

    }
}
