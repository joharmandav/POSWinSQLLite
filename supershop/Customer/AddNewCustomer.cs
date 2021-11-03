using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Customer
{
    public partial class AddNewCustomer : Form
    {
        InputLanguage arabic;
        InputLanguage english;
        InputLanguage French;
        public AddNewCustomer()
        {
            InitializeComponent();

            if (UserInfo.addcustomerflag == true)
            {
                btnAddAdvance.Visible = false;
                CombPeopleType.SelectedItem = "Customer";
                if (UserInfo.Customer_name != null && UserInfo.Customer_name != "")
                {
                    txtCustomerName.Text = UserInfo.Customer_name;
                   
                }
                CombPeopleType.Enabled = false;
                UserInfo.addcustomerflag = false;
                lblpeoplefag.Text = ".";
            }

            if (UserInfo.addSupplierflag == true)
            {
                CombPeopleType.SelectedItem = "Supplier";
                if (UserInfo.Customer_name != null && UserInfo.Customer_name != "")
                {
                    txtCustomerName.Text = UserInfo.Customer_name;
                }
                CombPeopleType.Enabled = false;
                UserInfo.addSupplierflag = false;
                lblpeoplefag.Text = ".";
            }

            dtDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtDateOfBirth.CustomFormat = "yyyy-MM-dd";

            dtDateofAnniversary.Format = DateTimePickerFormat.Custom;
            dtDateofAnniversary.CustomFormat = "yyyy-MM-dd";

            dtDateOfBirth.Text = "1900-01-01";
            dtDateofAnniversary.Text = "1900-01-01";

        }

        public string CustID
        {
            set
            {

                btnAddAdvance.Visible = CombPeopleType.Text=="Customer"?true:false;
                lblCustID.Text = value;
                lnkCustomers.Visible = false;
                grboxCusthistory.Visible = true;
                lblcuthistorylabel.Visible = true;
                lbltoplabel.Visible = true;

            }
            get
            {
                return lblCustID.Text;

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void clearform()
        {
            CombPeopleType.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtCustomerName.Text = Add_Item.voidQueryValidate(txtCustomerName.Text);
                txtCity.Text = Add_Item.voidQueryValidate(txtCity.Text);
                txtNameArabic.Text = Add_Item.voidQueryValidate(txtNameArabic.Text);
                txtPhone.Text = Add_Item.voidQueryValidate(txtPhone.Text);
                txtCustomerAddress.Text = Add_Item.voidQueryValidate(txtCustomerAddress.Text);
                txtEmailAddress.Text = Add_Item.voidQueryValidate(txtEmailAddress.Text);
                txtInsta.Text = Add_Item.voidQueryValidate(txtInsta.Text);
                txtFacebook.Text = Add_Item.voidQueryValidate(txtFacebook.Text);
                txtTwitter.Text = Add_Item.voidQueryValidate(txtTwitter.Text);
                txtRemark.Text = Add_Item.voidQueryValidate(txtRemark.Text);
                string DateOFBirth = "";
                string DateOfAnniversary = "";
                DateOFBirth = dtDateOfBirth.Text;
                DateOfAnniversary = dtDateofAnniversary.Text;


                if (lblCustID.Text == "-")
                {
                    // if (txtPeopleID.Text == "") { MessageBox.Show("Please Fill ID"); txtPeopleID.Focus(); } else
                    if (txtCustomerName.Text == "") { MessageBox.Show("Please Fill Name"); txtCustomerName.Focus(); return; }
                    else if (txtPhone.Text == "") { MessageBox.Show("Please Fill Phone"); txtPhone.Focus(); return; }
                    else if (CombPeopleType.Text == "") { MessageBox.Show("Please Fill People Type"); CombPeopleType.Focus(); return; }
                    //else if (txtCity.Text == "") { MessageBox.Show("Please Fill City"); txtCity.Focus(); }
                    //else if (txtCustomerAddress.Text == "") { MessageBox.Show("Please Fill  Address"); txtCustomerAddress.Focus(); }
                    else
                    {
                        string ExistPhone = txtPhone.Text.Trim().ToUpper();
                        string sqlPhone = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and Phone = '" + txtPhone.Text + "' ";
                        DataTable dtPhone = DataAccess.GetDataTable(sqlPhone);
                        if (dtPhone.Rows.Count >= 1)
                        {
                            MessageBox.Show("Already Add  Phone");
                            lblMsg.Text = "Already Add Phone";
                            txtPhone.Text = "";
                            txtPhone.Focus();
                            return;
                        }



                        string ExistName = txtCustomerName.Text.Trim().ToUpper();
                        ExistName = ExistName.Replace("-", "");
                        string sql = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and upper(trim(Name)) = '" + ExistName + "' and Phone = '" + txtPhone.Text + "' ";
                        DataTable dt = DataAccess.GetDataTable(sql);
                        if (dt.Rows.Count < 1)
                        {

                            int ID = DataAccess.getCustomerMYid(Tenent.TenentID);

                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            string sqlCmd = "insert into tbl_customer (TenentID,ID, Name,NameArabic, EmailAddress, Phone, address, City, PeopleType,Facebook,Twitter,Insta,Uploadby ,UploadDate ,SynID ,DateOfBirth,DateOfAnniversary,Remark) " +
                                            "  values (" + Tenent.TenentID + ",'" + ID + "','" + ExistName + "','" + txtNameArabic.Text.Trim() + "', '" + txtEmailAddress.Text.Trim() + "', '" + txtPhone.Text.Trim() + "', '" + txtCustomerAddress.Text.Trim() + "', " +
                                            " '" + txtCity.Text.Trim() + "', '" + CombPeopleType.Text.Trim() + "', '" + txtFacebook.Text.Trim() + "', '" + txtTwitter.Text.Trim() + "', '" + txtInsta.Text.Trim() + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1, '" + DateOFBirth + "','" + DateOfAnniversary + "','" + txtRemark.Text + "')";
                            int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                            string sqlCmdWin = "insert into Win_tbl_customer (TenentID,ID, Name,NameArabic, EmailAddress, Phone, address, City, PeopleType,Facebook,Twitter,Insta,Uploadby ,UploadDate ,SynID ,DateOfBirth,DateOfAnniversary,Remark )  " +
                                               " values (" + Tenent.TenentID + ",'" + ID + "', N'" + ExistName + "', N'" + txtNameArabic.Text.Trim() + "', '" + txtEmailAddress.Text.Trim() + "', '" + txtPhone.Text + "', N'" + txtCustomerAddress.Text.Trim() + "', " +
                                               " N'" + txtCity.Text.Trim() + "', '" + CombPeopleType.Text.Trim() + "', '" + txtFacebook.Text.Trim() + "', '" + txtTwitter.Text.Trim() + "', '" + txtInsta.Text.Trim() + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ,'" + DateOFBirth + "','" + DateOfAnniversary + "','" + txtRemark.Text.Trim() + "')";
                            Datasyncpso.insert_Live_sync(sqlCmdWin, "Win_tbl_customer", "INSERT");

                            string ActivityName = "add " + CombPeopleType.Text.Trim() + " ";
                            string LogData = "add " + CombPeopleType.Text.Trim() + " with Name = " + ExistName + " ";
                            Login.InsertUserLog(ActivityName, LogData);


                            MessageBox.Show("Customer Code : " + ID + ", Successfully saved");
                            lblMsg.Text = "Customer Code : " + ID + ", Successfully saved";
                            clearform();
                        }
                        else
                        {
                            MessageBox.Show("Already Exist Customer Name and Phone");
                            lblMsg.Text = "Already Exist Customer Name and Phone";
                            return;
                        }

                    }
                }
                else  //Update 
                {
                    string ExistName = txtCustomerName.Text.Trim().ToUpper();
                    ExistName = ExistName.Replace("-", "");
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sqlUpdateCmd = "update tbl_customer set Name = '" + ExistName + "',NameArabic = '" + txtNameArabic.Text.Trim() + "', EmailAddress= '" + txtEmailAddress.Text.Trim() + "', " +
                                          " address = '" + txtCustomerAddress.Text.Trim() + "', Phone = '" + txtPhone.Text.Trim() + "', City = '" + txtCity.Text.Trim() + "' , PeopleType = '" + CombPeopleType.Text.Trim() + "', " +
                                          " Facebook= '" + txtFacebook.Text.Trim() + "', Twitter= '" + txtTwitter.Text.Trim() + "', Insta= '" + txtInsta.Text.Trim() + "', DateOfBirth = '" + DateOFBirth + "', DateOfAnniversary = '" + DateOfAnniversary + "' , Remark = '" + txtRemark.Text.Trim() + "', " +
                                          " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                          " where TenentID= " + Tenent.TenentID + " and ID = '" + lblCustID.Text.Trim() + "'";
                    int Flag = DataAccess.ExecuteSQL(sqlUpdateCmd);
                    if (Flag == 1)
                    {
                        string sqlUpdateCmdwin = "update Win_tbl_customer set Name = N'" + ExistName + "',NameArabic = N'" + txtNameArabic.Text.Trim() + "', EmailAddress= '" + txtEmailAddress.Text.Trim() + "', " +
                                            " address = N'" + txtCustomerAddress.Text.Trim() + "', Phone = '" + txtPhone.Text.Trim() + "', City = N'" + txtCity.Text.Trim() + "' , PeopleType = '" + CombPeopleType.Text.Trim() + "', " +
                                            " Facebook= '" + txtFacebook.Text.Trim() + "', Twitter= '" + txtTwitter.Text.Trim() + "', Insta= '" + txtInsta.Text.Trim() + "', DateOfBirth = '" + DateOFBirth + "', DateOfAnniversary = '" + DateOfAnniversary + "' , Remark = '" + txtRemark.Text.Trim() + "', " +
                                            " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                            " where TenentID= " + Tenent.TenentID + " and ID = '" + lblCustID.Text.Trim() + "'";
                        Datasyncpso.insert_Live_sync(sqlUpdateCmdwin, "Win_tbl_customer", "UPDATE");

                        string ActivityName = "update " + CombPeopleType.Text.Trim() + " ";
                        string LogData = "update " + CombPeopleType.Text.Trim() + " with Name = " + ExistName + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        MessageBox.Show("Customer Code : " + lblCustID.Text.Trim() + ", Successfully Updated");
                    }


                }
                if (lblpeoplefag.Text == ".")
                {
                    txtCustomerName.Text = "";
                    CombPeopleType.Enabled = true;
                    lblpeoplefag.Text = "-";
                    this.Close();
                }
                else
                {
                    Customer.AddNewCustomer go = new Customer.AddNewCustomer();
                    go.MdiParent = this.ParentForm;
                    go.Show();
                    this.Close();
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Sorry\r\n this id already added \n\n " + exp.Message);
            }

        }

        public static int AddCustomer(string CustomerName)
        {
            string ExistName = CustomerName.Trim().ToUpper();
            CustomerName = CustomerName.Replace("-", "");
            ExistName = ExistName.Replace("-", "");
            string sql = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and upper(trim(Name)) = '" + ExistName + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count < 1)
            {
                int ID = DataAccess.getCustomerMYid(Tenent.TenentID);

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlCmd = " insert into tbl_customer (TenentID,ID, Name,NameArabic,PeopleType,Uploadby ,UploadDate ,SynID) " +
                                " values (" + Tenent.TenentID + ",'" + ID + "','" + CustomerName + "','" + CustomerName + "', 'Customer', " +
                                " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                string sqlCmdWin = "insert into Win_tbl_customer (TenentID,ID, Name,NameArabic,PeopleType,Uploadby ,UploadDate ,SynID)  " +
                                   " values (" + Tenent.TenentID + ",'" + ID + "','" + CustomerName + "','" + CustomerName + "', 'Customer', " +
                                   " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                Datasyncpso.insert_Live_sync(sqlCmdWin, "Win_tbl_customer", "INSERT");

                string ActivityName = "add Customer ";
                string LogData = "add Customer with Name = " + CustomerName + " ";
                Login.InsertUserLog(ActivityName, LogData);
                return ID;
            }

            return 0;
        }

        public static void updateCustomerRemark(int ID, string CustomerName, string Remark)
        {
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlUpdateCmd = "update tbl_customer set  Remark = '" + Remark.Trim() + "', " +
                                         " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                         " where TenentID= " + Tenent.TenentID + " and ID = '" + ID + "'";
            int Flag = DataAccess.ExecuteSQL(sqlUpdateCmd);
            if (Flag == 1)
            {
                string sqlUpdateCmdwin = "update Win_tbl_customer set  Remark = '" + Remark.Trim() + "', " +
                                    " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where TenentID= " + Tenent.TenentID + " and ID = '" + ID + "'";
                Datasyncpso.insert_Live_sync(sqlUpdateCmdwin, "Win_tbl_customer", "UPDATE");

                string ActivityName = "update Customer ";
                string LogData = "update Customer with Name = " + CustomerName + " ";
                Login.InsertUserLog(ActivityName, LogData);
            }
        }

        private void AddNewCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Customer.CustomerDetails go = new Customer.CustomerDetails();
            //go.MdiParent = this.ParentForm;
            //go.Show();
        }

        public void Databind()
        {
            string sql = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and ID = '" + lblCustID.Text + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //ID,Name, EmailAddress, Phone, Address, City, PeopleType, Facebook, Twitter, Insta, NameArabic, DateOfBirth, DateOfAnniversary,

                    txtCustomerName.Text = dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"].ToString() != "" ? dt.Rows[0]["Name"].ToString() : "";

                    txtNameArabic.Text = dt.Rows[0]["NameArabic"] != null && dt.Rows[0]["NameArabic"].ToString() != "" ? dt.Rows[0]["NameArabic"].ToString() : "";

                    txtPhone.Text = dt.Rows[0]["Phone"] != null && dt.Rows[0]["Phone"].ToString() != "" ? dt.Rows[0]["Phone"].ToString() : "";

                    CombPeopleType.Text = dt.Rows[0]["PeopleType"] != null && dt.Rows[0]["PeopleType"].ToString() != "" ? dt.Rows[0]["PeopleType"].ToString() : "";

                    txtEmailAddress.Text = dt.Rows[0]["EmailAddress"] != null && dt.Rows[0]["EmailAddress"].ToString() != "" ? dt.Rows[0]["EmailAddress"].ToString() : "";

                    txtCity.Text = dt.Rows[0]["City"] != null && dt.Rows[0]["City"].ToString() != "" ? dt.Rows[0]["City"].ToString() : "";

                    txtCustomerAddress.Text = dt.Rows[0]["Address"] != null && dt.Rows[0]["Address"].ToString() != "" ? dt.Rows[0]["Address"].ToString() : "";

                    txtInsta.Text = dt.Rows[0]["Insta"] != null && dt.Rows[0]["Insta"].ToString() != "" ? dt.Rows[0]["Insta"].ToString() : "";

                    txtFacebook.Text = dt.Rows[0]["Facebook"] != null && dt.Rows[0]["Facebook"].ToString() != "" ? dt.Rows[0]["Facebook"].ToString() : "";

                    txtTwitter.Text = dt.Rows[0]["Twitter"] != null && dt.Rows[0]["Twitter"].ToString() != "" ? dt.Rows[0]["Twitter"].ToString() : "";

                    dtDateOfBirth.Text = dt.Rows[0]["DateOfBirth"] != null && dt.Rows[0]["DateOfBirth"].ToString() != "" ? dt.Rows[0]["DateOfBirth"].ToString() : "1900-01-01";

                    dtDateofAnniversary.Text = dt.Rows[0]["DateOfAnniversary"] != null && dt.Rows[0]["DateOfAnniversary"].ToString() != "" ? dt.Rows[0]["DateOfAnniversary"].ToString() : "1900-01-01";

                    txtRemark.Text = dt.Rows[0]["Remark"] != null && dt.Rows[0]["Remark"].ToString() != "" ? dt.Rows[0]["Remark"].ToString() : "";

                    if (CombPeopleType.Text == "Customer")
                    {
                        linkMedicalHistory.Visible = true;
                        lnkEye.Visible = true;
                        btnAddAdvance.Visible = true;
                    }
                    else
                    {
                        linkMedicalHistory.Visible = false;
                        lnkEye.Visible = false;
                        btnAddAdvance.Visible = false;
                    }

                }
                else
                {
                    linkMedicalHistory.Visible = false;
                    lnkEye.Visible = false;
                }
            }
            else
            {
                linkMedicalHistory.Visible = false;
                lnkEye.Visible = false;
            }

            string sql1 = "  select  sales_id as 'Invo_No' , sales_time as Date , payment_amount as Total , " +
                            "   (payment_amount - due_amount) as 'Paid Amount' ,  payment_type as 'Payment Type' , " +
                            "   due_amount as Due, emp_id as 'Sold by' ,  Comment as 'Cust Name/Comment' " +
                            "   from sales_payment   where TenentID = " + Tenent.TenentID + " and C_id = '" + lblCustID.Text + "' order by  sales_id desc";
            DataTable dt1 = DataAccess.GetDataTable(sql1);
            dtgviewCusttrxHistory.DataSource = dt1;
        }

        private void AddNewCustomer_Load(object sender, EventArgs e)
        {
            arabic = InputLanguage.CurrentInputLanguage;
            english = InputLanguage.CurrentInputLanguage;
            French = InputLanguage.CurrentInputLanguage;
            int count = InputLanguage.InstalledInputLanguages.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("Arabic"))
                {
                    arabic = InputLanguage.InstalledInputLanguages[i];
                }
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("US"))
                {
                    english = InputLanguage.InstalledInputLanguages[i];
                }
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("French"))
                {
                    French = InputLanguage.InstalledInputLanguages[i];
                }

            }

            try
            {
                Databind();

            }
            catch
            {
            }

        }

        private void txtNameArabic_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = arabic;
        }

        private void txtNameArabic_LostFocus(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }

        private void lnkCustomers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (Application.OpenForms["CustomerDetails"] != null)
            {
                Application.OpenForms["CustomerDetails"].Close();
            }
            this.Refresh();

            Customer.CustomerDetails go = new Customer.CustomerDetails();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void dtgviewCusttrxHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = dtgviewCusttrxHistory.Rows[e.RowIndex];

                //this.Hide();
                Customer.Due_payment_History go = new Customer.Due_payment_History(row.Cells["Contact"].Value.ToString(), row.Cells["Invo_No"].Value.ToString());
                go.MdiParent = this.ParentForm;
                go.ShowDialog();

            }
            catch
            {

            }
        }

        private void txtCustomerName_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    SalesRegister.openKeyboard();
            //}
            //catch
            //{

            //}
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            bool Internat = Login.InternetConnection();
            if (Internat == true)
            {
                txtNameArabic.Text = DataAccess.Translate(txtCustomerName.Text, "ar");
            }
            else
            {
                txtNameArabic.Text = txtCustomerName.Text;
            }
        }

        private void lblCustID_TextChanged(object sender, EventArgs e)
        {
            Databind();
        }

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == '~' || e.KeyChar == '.' || e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
           
        }
        private void CombPeopleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtCustomerAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtEmailAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtTwitter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void linkMedicalHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Customer_Medical_info"] != null)
            {
                Application.OpenForms["Customer_Medical_info"].Close();
            }
            this.Refresh();

            Customer.Customer_Medical_info go = new Customer.Customer_Medical_info();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.CustomerID = lblCustID.Text;
            go.CustomerName = txtCustomerName.Text;
            go.Show();
        }

        private void txtEmailAddress_Leave(object sender, EventArgs e)
        {
            validemail();
        }

        private void txtEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            validemail();
        }

        public void validemail()
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmailAddress.Text.Length > 0 && txtEmailAddress.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(txtEmailAddress.Text.Trim()))
                {
                    lblEmailerrormsg.Visible = true;
                    lblEmailerrormsg.Text = "Invalid Email address";
                    txtEmailAddress.SelectAll();
                    // e.Cancel = true;

                }
                else
                {
                    lblEmailerrormsg.Visible = false;
                }
            }
        }

        private void lnkEye_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Cusromer_Eye_Data"] != null)
            {
                Application.OpenForms["Cusromer_Eye_Data"].Close();
            }
            this.Refresh();

            Cusromer_Eye_Data go = new Cusromer_Eye_Data();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.CustomerID = lblCustID.Text;
            go.CustomerName = txtCustomerName.Text;
            go.Show();
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (lblCustID.Text == "-")
            {
                string ExistPhone = txtPhone.Text.Trim().ToUpper();
                string sqlPhone = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and Phone = '" + txtPhone.Text + "' ";
                DataTable dtPhone = DataAccess.GetDataTable(sqlPhone);
                if (dtPhone.Rows.Count >= 1)
                {
                    MessageBox.Show("Already Add  Phone");
                    lblMsg.Text = "Already Add Phone";
                    txtPhone.Text = "";
                    txtPhone.Focus();
                    return;
                }
            }
        }

        private void btnAddAdvance_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Cusromer_AdvancePay"] != null)
            {
                Application.OpenForms["Cusromer_AdvancePay"].Close();
            }
            this.Refresh();

            Cusromer_AdvancePay go = new Cusromer_AdvancePay();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.CustomerID = lblCustID.Text;
            go.CustomerName = txtCustomerName.Text;
            go.Show();
          
        }

    }
}
         
