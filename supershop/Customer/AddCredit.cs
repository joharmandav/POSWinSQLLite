using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Customer
{
    public partial class AddCredit : Form
    {
        public AddCredit()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AddCredit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Customer.RewardsManagerReport go = new Customer.RewardsManagerReport();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void AddCredit_Load(object sender, EventArgs e)
        {
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "yyyy-MM-dd";

            string sql5 = "select   DISTINCT  *   from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer'";
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            ComboCustID.DataSource = dt5;
            ComboCustID.DisplayMember = "Name";

            // lblCustID.Text = dt5.Rows[0].ItemArray[0].ToString();
            CustomerID();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtDesCription.Text = Add_Item.voidQueryValidate(txtDesCription.Text);
               
                if (txtDesCription.Text == "")
                {
                    MessageBox.Show("Please Write Description");
                }
                else
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sqlCmd = "insert into tbl_custcredit (TenentID, CustID, orderID, Date, Credit, Description,Uploadby ,UploadDate ,SynID)  values (" + Tenent.TenentID + ",'" + lblCustID.Text + "', 'SyS', '" + dtDate.Text + "', '" + NumUDcredit.Text + "', '" + txtDesCription.Text + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                    int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                    string sqlCmdwin = "insert into Win_tbl_custcredit (TenentID, CustID, orderID, Date, Credit, Description,Uploadby ,UploadDate ,SynID)  values (" + Tenent.TenentID + ",'" + lblCustID.Text + "', 'SyS', '" + dtDate.Text + "', '" + NumUDcredit.Text + "', '" + txtDesCription.Text + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                    Datasyncpso.insert_Live_sync(sqlCmdwin, "Win_tbl_custcredit", "INSERT");

                    string ActivityName = "Add Customer Cradit";
                    string LogData = "Add Customer Cradit with CustID = " + lblCustID.Text + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                    MessageBox.Show("Successfully Added Credit to " + lblCustID.Text);
                    txtDesCription.Text = string.Empty;
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Sorry\r\n this id already added \n\n " + exp.Message);
            }
        }

        private void ComboCustID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                CustomerID();
            }
            catch // (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public void CustomerID()
        {
            string sqlCmd = "Select ID from  tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = '" + ComboCustID.Text + "'";
            DataAccess.ExecuteSQL(sqlCmd);
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);

            lblCustID.Text = dt1.Rows[0].ItemArray[0].ToString();
        }



    }
}
