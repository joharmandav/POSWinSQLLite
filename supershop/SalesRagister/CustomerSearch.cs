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
    public partial class CustomerSearch : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public CustomerSearch()
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
                btnselect.Width = 70;

                //Edit Button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dtGrdvCustomerDetails.Columns.Add(btn);
                btn.HeaderText = "Edit";
                btn.Text = "Edit";
                btn.Name = "Edit";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 50;

            }
            catch
            {
            }

        }
        public void Databind()
        {
            // Customers.ID, Customers.Name, Customers.NameArabic, Customers.Phone as Mobile,Customers.Address , Customers.EmailAddress, Customers.City,Customers.PeopleType

            string sqlCmd = "Select ID,(Name ||' - '|| NameArabic) as Name,Mobile,Address,EmailAddress from  customercredit where TenentID=" + Tenent.TenentID + " and PeopleType = 'Customer' and Mobile<>''   ";
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvCustomerDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            string Name = txtCustomerSearch.Text;
            Name = Name.Trim();
            string sqlCmd = "";
            if (Name != "")
                sqlCmd = "Select ID,(Name ||' - '|| NameArabic) as Name,Mobile,Address,EmailAddress from  customercredit where TenentID=" + Tenent.TenentID + " and PeopleType = 'Customer' and Name like '%" + Name + "%' or  NameArabic like '%" + Name + "%' ";
            else
                sqlCmd = "Select ID,(Name ||' - '|| NameArabic) as Name,Mobile,Address,EmailAddress from  customercredit where TenentID=" + Tenent.TenentID + " and PeopleType = 'Customer' and Mobile<>''   ";
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvCustomerDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void txtcustomeMobile_TextChanged(object sender, EventArgs e)
        {
            string Mobile = txtcustomeMobile.Text;
            Mobile = Mobile.Trim();
            string sqlCmd = "";
            if (Mobile != "")
                sqlCmd = "Select ID,(Name ||' - '|| NameArabic) as Name,Mobile,Address,EmailAddress from  customercredit where TenentID=" + Tenent.TenentID + " and PeopleType = 'Customer' and Mobile like '%" + Mobile + "%'  ";
            else
                sqlCmd = "Select ID,(Name ||' - '|| NameArabic) as Name,Mobile,Address,EmailAddress from  customercredit where TenentID=" + Tenent.TenentID + " and PeopleType = 'Customer' and Mobile<>''   ";

            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvCustomerDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

            string EmailAddress = txtEmail.Text;
            EmailAddress = EmailAddress.Trim();
            string sqlCmd ="";
            if(EmailAddress!="")
                sqlCmd = "Select ID,(Name ||' - '|| NameArabic) as Name,Mobile,Address,EmailAddress from  customercredit where TenentID=" + Tenent.TenentID + " and PeopleType = 'Customer' and EmailAddress like '%" + EmailAddress + "%'   ";
             else
                sqlCmd = "Select ID,(Name ||' - '|| NameArabic) as Name,Mobile,Address,EmailAddress from  customercredit where TenentID=" + Tenent.TenentID + " and PeopleType = 'Customer' and Mobile<>''   ";

             
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvCustomerDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void dtGrdvCustomerDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrdvCustomerDetails.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];
                    // label1.Text = row.Cells[0].Value.ToString();

                    int ID = Convert.ToInt16(row.Cells["ID"].Value);

                    string sqlCmd = "Select ID,Name,NameArabic,EmailAddress,Phone,Address,City,PeopleType,Facebook,Twitter from  tbl_customer where TenentID=" + Tenent.TenentID + " and ID = " + ID + " ";
                    DataTable dt1 = DataAccess.GetDataTable(sqlCmd);

                    Customer.AddNewCustomer mkc = new Customer.AddNewCustomer();
                    mkc.CustID = dt1.Rows[0]["ID"].ToString();
                    //mkc.CustName = dt1.Rows[0]["Name"].ToString();
                    //mkc.CustArabicName = dt1.Rows[0]["NameArabic"].ToString();
                    //mkc.CustPhone = dt1.Rows[0]["Phone"].ToString();
                    //mkc.City = dt1.Rows[0]["City"].ToString();
                    //mkc.Email = dt1.Rows[0]["EmailAddress"].ToString();
                    //mkc.CustAddress = dt1.Rows[0]["Address"].ToString();
                    //mkc.PeopleType = dt1.Rows[0]["PeopleType"].ToString();
                    mkc.ShowDialog();
                }

                // Select

                if (e.ColumnIndex == dtGrdvCustomerDetails.Columns["Select"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvCustomerDetails.Rows[e.RowIndex];
                    // label1.Text = row.Cells[0].Value.ToString();

                    //SalesRegister mkc = new SalesRegister();
                    //mkc.CustName = row.Cells[3].Value.ToString();
                    //mkc.Show();

                    int ID = Convert.ToInt16(row.Cells["ID"].Value);

                    string sqlCmd = "Select ID,Name,NameArabic,EmailAddress,Phone,Address,City,PeopleType,Facebook,Twitter from  tbl_customer where TenentID=" + Tenent.TenentID + " and ID = " + ID + " ";
                    DataTable dt1 = DataAccess.GetDataTable(sqlCmd);

                    string customerName = dt1.Rows[0]["Name"] + " - " + dt1.Rows[0]["Phone"] + " - " + dt1.Rows[0]["EmailAddress"];

                    SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                    mkc1.CustomerPage = "CustomerSearch";
                    mkc1.CustName = customerName;
                    mkc1.Show();
                    this.Hide();
                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string CustomerCode = txtCustomerCode.Text;
            CustomerCode = CustomerCode.Trim();
            string sqlCmd ="";
            if(CustomerCode!="")
                sqlCmd = "Select ID,(Name ||' - '|| NameArabic) as Name,Mobile,Address,EmailAddress from  customercredit where TenentID=" + Tenent.TenentID + " and PeopleType = 'Customer' and ID = '" + CustomerCode + "' and Mobile<>''  ";
             else
                sqlCmd = "Select ID,(Name ||' - '|| NameArabic) as Name,Mobile,Address,EmailAddress from  customercredit where TenentID=" + Tenent.TenentID + " and PeopleType = 'Customer' and Mobile<>''   ";

           
            
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvCustomerDetails.DataSource = dt1;
            dtGrdvCustomerDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvCustomerDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["AddNewCustomer"] != null)
            {
                Application.OpenForms["AddNewCustomer"].BringToFront();
                Application.OpenForms["AddNewCustomer"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                UserInfo.addcustomerflag = true;
                Customer.AddNewCustomer go = new Customer.AddNewCustomer();
                go.Show();
            }
        }
    }
}
