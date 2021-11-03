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
    public partial class ReportCustomerSearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public ReportCustomerSearch()
        {
            InitializeComponent();
        }

        private void CustomerSearch_Load(object sender, EventArgs e)
        {
            try
            {
                dtGrdvCustomerDetails.EnableHeadersVisualStyles = false;
                dtGrdvCustomerDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Databind();

                //Select Button
                DataGridViewButtonColumn btnselect = new DataGridViewButtonColumn();
                dtGrdvCustomerDetails.Columns.Add(btnselect);
                btnselect.HeaderText = "Select";
                btnselect.Text = "Select";
                btnselect.Name = "Select";
                btnselect.UseColumnTextForButtonValue = true;
                btnselect.Width = 100;

            }
            catch
            {
            }

        }
        public void Databind()
        {
            // Customers.ID, Customers.Name, Customers.NameArabic, Customers.Phone as Mobile,Customers.Address , Customers.EmailAddress, Customers.City,Customers.PeopleType

            string sqlCmd = " select distinct Customer From sales_item where TenentID=" + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            string Name = txtCustomerSearch.Text;
            Name = Name.Trim();
            string sqlCmd = " select distinct Customer From sales_item where TenentID=" + Tenent.TenentID + " and Customer like '%" + Name + "%' ";
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
        }

        private void dtGrdvCustomerDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrdvCustomerDetails.Columns["Select"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];

                    string Customer = row.Cells["Customer"].Value.ToString();

                    salesreport mkc1 = (salesreport)Application.OpenForms["salesreport"];
                    mkc1.Customer = Customer;
                    mkc1.Show();

                    this.Close();
                }

            }
            catch
            {

            }
        }


    }
}
