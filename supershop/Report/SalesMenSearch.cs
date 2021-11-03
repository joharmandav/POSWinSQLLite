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
    public partial class SalesMenSearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public SalesMenSearch()
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

        private void SalesMenSearch_Load(object sender, EventArgs e)
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
            string sqlCmd = " select distinct SoldBy as 'Sales Man' From sales_item where TenentID = " + Tenent.TenentID + " ";

            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;

            dtGrdvCustomerDetails.Columns["Select"].DisplayIndex = 1;
            dtGrdvCustomerDetails.Columns["Select"].Width = 100;
        }

        private void txtsalesmanSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsalesmanSearch.Text != "")
            {
                string Name = txtsalesmanSearch.Text;
                Name = Name.Trim();

                string sqlCmd = " select distinct SoldBy as 'Sales Man' From sales_item where TenentID = " + Tenent.TenentID + " " +
                                " and SoldBy like '%" + Name + "%' ";

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

                    string salesMen = row.Cells["Sales Man"].Value.ToString();

                    salesreport mkc1 = (salesreport)Application.OpenForms["salesreport"];
                    mkc1.salesMen = salesMen;
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
