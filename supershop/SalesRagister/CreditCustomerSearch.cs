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
    public partial class CreditCustomerSearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public CreditCustomerSearch()
        {
            InitializeComponent();

            if (UserInfo.Language == "English")
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                switch_language();
            }
            else if (UserInfo.Language == "Arabic")
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("Ar");
                switch_language();
            }
            else
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                switch_language();
            }
        }

        private void switch_language()
        {
            labelCustomerName.Text = res_man.GetString("CustomerSearch_labelCustomerName", cul);
            labelCustomerMobile.Text = res_man.GetString("CustomerSearch_labelCustomerMobile", cul);
            labelCustomerEmail.Text = res_man.GetString("CustomerSearch_labelCustomerEmail", cul);
        }

        private void CreditCustomerSearch_Load(object sender, EventArgs e)
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
                btnselect.Width = 70;
            }
            catch
            {
            }

        }
        public void Databind()
        {
            // Customers.ID, Customers.Name, Customers.NameArabic, Customers.Phone as Mobile,Customers.Address , Customers.EmailAddress, Customers.City,Customers.PeopleType

            string sqlCmd = " select tbl_customer.ID as 'ID' , ( Name || ' - ' || Phone || ' - ' || EmailAddress ) as 'Name' " +
                            " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = tbl_customer.ID " +
                            " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                            " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                            " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) " +
                            " group by sales_item.C_id  ";  
       
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            string Name = txtCustomerSearch.Text;
            Name = Name.Trim();

            string sqlCmd = " select tbl_customer.ID as 'ID' , ( Name || ' - ' || Phone || ' - ' || EmailAddress ) as 'Name' " +
                            " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = tbl_customer.ID " +
                            " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                            " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                            " (tbl_customer.Name like '%" + Name + "%' or  tbl_customer.NameArabic like '%" + Name + "%' ) and " +
                            " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) " +
                            " group by sales_item.C_id  ";
            
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void txtcustomeMobile_TextChanged(object sender, EventArgs e)
        {
            string Mobile = txtcustomeMobile.Text;
            Mobile = Mobile.Trim();

            string sqlCmd = " select tbl_customer.ID as 'ID' , ( Name || ' - ' || Phone || ' - ' || EmailAddress ) as 'Name' " +
                            " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = tbl_customer.ID " +
                            " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                            " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                            " tbl_customer.Phone like '%" + Mobile + "%' and " +
                            " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) " +
                            " group by sales_item.C_id  ";

            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string EmailAddress = txtEmail.Text;
            EmailAddress = EmailAddress.Trim();
            string sqlCmd = " select tbl_customer.ID as 'ID' , ( Name || ' - ' || Phone || ' - ' || EmailAddress ) as 'Name' " +
                            " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = tbl_customer.ID " +
                            " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                            " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                            " tbl_customer.EmailAddress like '%" + EmailAddress + "%' and " +
                            " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) " +
                            " group by sales_item.C_id  ";
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void dtGrdvCustomerDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrdvCustomerDetails.Columns["Select"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];
                    // label1.Text = row.Cells[0].Value.ToString();

                    //SalesRegister mkc = new SalesRegister();
                    //mkc.CustName = row.Cells[3].Value.ToString();
                    //mkc.Show();
                    
                    int ID = Convert.ToInt16(row.Cells["ID"].Value);

                    string CustName = row.Cells["Name"].Value.ToString();

                    payablecredit mkc1 = (payablecredit)Application.OpenForms["payablecredit"];
                    mkc1.CustName = CustName;
                    mkc1.Show();
                    this.Hide();
                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            string CustomerCode = txtCustomerCode.Text;
            CustomerCode = CustomerCode.Trim();
            string sqlCmd = " select tbl_customer.ID as 'ID' , ( Name || ' - ' || Phone || ' - ' || EmailAddress ) as 'Name' " +
                           " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = tbl_customer.ID " +
                           " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                           " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                           " tbl_customer.ID = '" + CustomerCode + "' and " +
                           " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) " +
                           " group by sales_item.C_id  ";

            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }


    }
}
