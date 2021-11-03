using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace supershop.User_mgt
{
    public partial class User_regi : Form
    {
        public User_regi()
        {
            InitializeComponent();
        }

        // Get User ID from ManagerUser form
        public string Uid
        {
            set { lblUid.Text = value; }
            get { return lblUid.Text; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Auto Generate Password
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string myPWD = PWDGenerator.GeneratePWD();
            textUserPass.Text = myPWD;
        }

        // Load User Info for Update 
        public void loadData(string Uid)
        {
            // Name,Father_name,Address,Email,Contact,DOB,Username,password,usertype,position,imagename,Shopid
            string sql3 = "select * from usermgt where TenentID = " + Tenent.TenentID + " and id = '" + Uid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            if (dt1.Rows.Count > 0)
            {
                //  lblUid.Text = dt1.Rows[0].ItemArray[0].ToString();
                txtUserFullName.Text = dt1.Rows[0]["Name"].ToString();
                txtFatherName.Text = dt1.Rows[0]["Father_name"].ToString();
                txtAddress.Text = dt1.Rows[0]["Address"].ToString();
                txtEmailaddress.Text = dt1.Rows[0]["Email"].ToString();
                txtContact.Text = dt1.Rows[0]["Contact"].ToString();
                dtDOB.Value = Convert.ToDateTime(dt1.Rows[0]["DOB"].ToString());
                txtUsername.Text = dt1.Rows[0]["Username"].ToString();
                textUserPass.Text = dt1.Rows[0]["password"].ToString();
                lblimagename.Text = dt1.Rows[0]["imagename"].ToString();

                string path = Application.StartupPath + @"\IMAGE\" + dt1.Rows[0]["imagename"].ToString() + "";
                picUserimage.ImageLocation = path;
                picUserimage.InitialImage.Dispose();

                if (dt1.Rows[0]["usertype"].ToString() == "1")
                {
                    rdbtnAdmin.Checked = true;
                }
                else if (dt1.Rows[0]["usertype"].ToString() == "2")
                {
                    rdbtnManager.Checked = true;
                }
                else if (dt1.Rows[0]["usertype"].ToString() == "3")
                {
                    rdbtnSalesMan.Checked = true;
                }
                else if (dt1.Rows[0]["usertype"].ToString() == "4")
                {
                    rdbtncheff.Checked = true;
                }
                else if (dt1.Rows[0]["usertype"].ToString() == "5")
                {
                    rdbtnDriver.Checked = true;
                }
                else if (dt1.Rows[0]["usertype"].ToString() == "6")
                {
                    rdobtnspaEmployee.Checked = true;
                }
                else if (dt1.Rows[0]["usertype"].ToString() == "0")
                {
                    rdbtnblock.Checked = true;
                }
                else
                {
                    // rdbtnInactive.Checked = true;
                }
                cmboShopid.SelectedValue = dt1.Rows[0]["Shopid"].ToString();
            }
        }

        // Load UID No
        private void showincrement()
        {
            string sql = "select id from usermgt where TenentID = " + Tenent.TenentID + " order by id desc";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) + 1;
                txtUid.Text = id.ToString();
            }
            else
            {
                int id = 1;
                txtUid.Text = id.ToString();
            }
        }

        public void Bindshopbranch()
        {
            string sql5 = "select   BranchName , Shopid from tbl_terminallocation where TenentID = " + Tenent.TenentID + " ";
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            cmboShopid.DataSource = dt5;
            cmboShopid.DisplayMember = "BranchName";
            cmboShopid.ValueMember = "Shopid";
        }

        private void User_regi_Load(object sender, EventArgs e)
        {
            bool Internat = Login.InternetConnection();
            if (Internat == false)
            {
                MessageBox.Show("Please Check Your internet Connection");
                this.BeginInvoke(new MethodInvoker(Close));
            }

            try
            {
                dtDOB.Format = DateTimePickerFormat.Custom;
                dtDOB.CustomFormat = "MM/dd/yyyy";
                Bindshopbranch();
                //Update data | If user id has
                if (lblUid.Text != "-")
                {
                    loadData(lblUid.Text);
                    txtUsername.Enabled = false;
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";
                    lnkDelete.Visible = false;
                    groupBox1.Enabled = false;
                }
                else
                {
                    groupBox1.Enabled = true;
                    showincrement();
                    lnkAddnew.Visible = false;
                    lnkDelete.Visible = false;
                }

            }
            catch
            {
            }
        }


        private void ClearForm()
        {
            txtUserFullName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtUsername.Text = string.Empty;
            textUserPass.Text = string.Empty;
            txtEmailaddress.Text = string.Empty;
            dtDOB.Text = string.Empty;

        }



        public static int CheckUserPermition(int TenentID)
        {
            int Allowuser = 1;

            bool Internat = Login.InternetConnection();
            if (Internat == true)
            {
                bool CON_Ceck = Login.CheckDBConnection();
                if (CON_Ceck == true)
                {
                    string sqllist = "select * from Win_mycompanysetup_winapp where Tenentid=" + TenentID + " ";
                    DataTable dtlist = DataLive.GetLiveDataTable(sqllist);
                    if (dtlist.Rows.Count > 0)
                    {
                        Allowuser = Convert.ToInt32(dtlist.Rows[0]["AllowUser"]);
                    }
                }
            }

            return Allowuser;
        }

        public static int CountUserFound(int TenentID, int UserType)
        {
            int Countuser = 0;

            bool Internat = Login.InternetConnection();
            if (Internat == true)
            {
                bool CON_Ceck = Login.CheckDBConnection();
                if (CON_Ceck == true)
                {
                    string sqllist = "select * from Win_usermgt where Tenentid=" + TenentID + " and usertype = '" + UserType + "'";
                    DataTable dtlist = DataLive.GetLiveDataTable(sqllist);
                    if (dtlist.Rows.Count > 0)
                    {
                        Countuser = dtlist.Rows.Count;
                    }
                }
                else
                {
                    //string sqllist = "select * from usermgt where Tenentid=" + TenentID + " and usertype = '" + UserType + "' ";
                    //DataTable dtlist = DataAccess.GetDataTable(sqllist);

                    //if (dtlist.Rows.Count > 0)
                    //{
                    //    Countuser = dtlist.Rows.Count;
                    //}
                }
            }
            else
            {
                //string sqllist = "select * from usermgt where Tenentid=" + TenentID + " and usertype = '" + UserType + "' ";
                //DataTable dtlist = DataAccess.GetDataTable(sqllist);

                //if (dtlist.Rows.Count > 0)
                //{
                //    Countuser = dtlist.Rows.Count;
                //}
            }

            return Countuser;
        }

        public static int Finalallow(int UserType, int Allowuser)
        {
            int AllowuserFinal = 0;

            if (UserType == 1) // Admin
            {
                AllowuserFinal = Allowuser * 1;
            }
            if (UserType == 2) //Manager
            {
                AllowuserFinal = Allowuser * 1;
            }
            if (UserType == 3) //salesman
            {
                AllowuserFinal = Allowuser * 1;
            }
            if (UserType == 4) //Kitchen
            {
                AllowuserFinal = Allowuser * 1;
            }
            if (UserType == 5) //Driver
            {
                AllowuserFinal = Allowuser * 2;
            }
            if (UserType == 6) //Spa Employee
            {
                AllowuserFinal = Allowuser * 2;
            }

            return AllowuserFinal;
        }

        public static bool Allowuser(int UserType)
        {
            int Allowuser = CheckUserPermition(Tenent.TenentID);

            int AllowuserFinal = Finalallow(UserType, Allowuser);

            int Countuser = CountUserFound(Tenent.TenentID, UserType);

            if (AllowuserFinal > Countuser)
            {
                if (AllowuserFinal == Countuser)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        // Save if not UID | Update if UID present
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool Internat = Login.InternetConnection();
            if (Internat == false)
            {
                MessageBox.Show("Check Your Internet Connection");
                return;
            }

            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == false)
            {
                MessageBox.Show("server temporarily unavailable or ");
                return;
            }

            if (txtUserFullName.Text == "")
            {
                MessageBox.Show("Please Add User full Name", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserFullName.Focus();
            }
            else if (txtFatherName.Text == "")
            {
                MessageBox.Show("Please fill fathers name", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFatherName.Focus();
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Please Add Address", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
            }
            else if (txtContact.Text == "")
            {
                MessageBox.Show("Please Add Contact Number", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContact.Focus();
            }
            else if (txtUsername.Text == "")
            {
                MessageBox.Show("Please Add Username \n Username should be unique", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
            }
            else if (txtEmailaddress.Text == "")
            {
                MessageBox.Show("Please Add  Email address", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmailaddress.Focus();
            }
            else if (textUserPass.Text == "")
            {
                MessageBox.Show("Please Add  Password", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textUserPass.Focus();
            }
            else
            {
                try
                {

                    int flag;
                    if (rdbtnAdmin.Checked)
                    {
                        flag = 1;
                    }
                    else if (rdbtnManager.Checked)
                    {
                        flag = 2;
                    }
                    else if (rdbtnSalesMan.Checked)
                    {
                        flag = 3;
                    }
                    else if (rdbtncheff.Checked)
                    {
                        flag = 4;
                    }
                    else if (rdbtnDriver.Checked)
                    {
                        flag = 5;
                    }
                    else if (rdobtnspaEmployee.Checked)
                    {
                        flag = 6;
                    }
                    else if (rdbtnblock.Checked)
                    {
                        flag = 0;
                    }
                    else
                    {
                        flag = 0;
                    }

                    string posi;
                    if (rdbtnAdmin.Checked)
                    {
                        posi = "Admin";
                    }
                    else if (rdbtnManager.Checked)
                    {
                        posi = "Manager";
                    }
                    else if (rdbtnSalesMan.Checked)
                    {
                        posi = "Salesman";
                    }
                    else if (rdbtncheff.Checked)
                    {
                        posi = "Cheff";
                    }
                    else if (rdbtnDriver.Checked)
                    {
                        posi = "Driver";
                    }
                    else if (rdobtnspaEmployee.Checked)
                    {
                        posi = "Spa Employee";
                    }
                    else if (rdbtnblock.Checked)
                    {
                        posi = "Block";
                    }
                    else
                    {
                        posi = "0";
                    }

                    //New Insert / New Entry
                    if (lblUid.Text == "-")
                    {
                        bool allow = Allowuser(flag);
                        if (allow == false)
                        {
                            int AllowuserCkeck = CheckUserPermition(Tenent.TenentID);

                            int AllowuserFinal = Finalallow(flag, AllowuserCkeck);

                            MessageBox.Show("You allow Only " + AllowuserFinal + " " + posi + "  ", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //string selno = txtUid.Text;
                        string imageName = txtUid.Text + lblFileExtension.Text; //System.IO.Path.GetFileName(openFileDialog1.FileName);

                        int ID = DataAccess.getusermgtMYid(Tenent.TenentID);

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        string sql1Win = "insert into Win_usermgt (TenentID,id, Name, Father_name, Address, Email , Contact, DOB , Username , password , usertype , position , imagename, Shopid,Uploadby ,UploadDate ,SynID ) " +
                                     "  values( " + Tenent.TenentID + "," + ID + ",'" + txtUserFullName.Text + "', '" + txtFatherName.Text + "', '" + txtAddress.Text + "', '" + txtEmailaddress.Text + "', " +
                                     " '" + txtContact.Text + "',  '" + dtDOB.Text + "', '" + txtUsername.Text.Trim() + "', '" + textUserPass.Text + "', " +
                                     " '" + flag + "', '" + posi + "' , '" + imageName + "' , '" + cmboShopid.SelectedValue + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        int insertFlag = DataLive.ExecuteLiveSQL(sql1Win);
                        if (insertFlag == 1)
                        {
                            string sql1 = "insert into usermgt (TenentID,id, Name, Father_name, Address, Email , Contact, DOB , Username , password , usertype , position , imagename, Shopid,Uploadby ,UploadDate ,SynID ) " +
                                      "  values( " + Tenent.TenentID + "," + ID + ",'" + txtUserFullName.Text + "', '" + txtFatherName.Text + "', '" + txtAddress.Text + "', '" + txtEmailaddress.Text + "', " +
                                      " '" + txtContact.Text + "',  '" + dtDOB.Text + "', '" + txtUsername.Text.Trim() + "', '" + textUserPass.Text + "', " +
                                      " '" + flag + "', '" + posi + "' , '" + imageName + "' , '" + cmboShopid.SelectedValue + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            DataAccess.ExecuteSQL(sql1);

                            //string sql1Win = "insert into Win_usermgt (TenentID,id, Name, Father_name, Address, Email , Contact, DOB , Username , password , usertype , position , imagename, Shopid,Uploadby ,UploadDate ,SynID ) " +
                            //              "  values( " + Tenent.TenentID + "," + ID + ",'" + txtUserFullName.Text + "', '" + txtFatherName.Text + "', '" + txtAddress.Text + "', '" + txtEmailaddress.Text + "', " +
                            //              " '" + txtContact.Text + "',  '" + dtDOB.Text + "', '" + txtUsername.Text.Trim() + "', '" + textUserPass.Text + "', " +
                            //              " '" + flag + "', '" + posi + "' , '" + imageName + "' , '" + cmboShopid.SelectedValue + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            //Datasyncpso.insert_Live_sync(sql1Win, "Win_usermgt");

                            string ActivityName = "Add User";
                            string LogData = "Add User with username = : " + txtUsername.Text.Trim() + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            /////////////////////picture upload  /////////////////
                            string path = Application.StartupPath + @"\IMAGE\";
                            System.IO.File.Delete(path + @"\" + imageName);
                            if (!System.IO.Directory.Exists(path))
                                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\IMAGE\");
                            string filename = path + @"\" + openFileDialog1.SafeFileName;
                            picUserimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                            System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                            MessageBox.Show("User hase been Created Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblEmailerrormsg.Visible = false;

                            User_mgt.Manage_user go = new User_mgt.Manage_user();
                            go.MdiParent = this.ParentForm;
                            go.Show();
                            this.Close();
                        }
                    }
                    else // Update info
                    {
                        string imageName;
                        if (lblFileExtension.Text == "user.png")
                        {
                            imageName = lblimagename.Text;  //Unchange pictures
                        }
                        else  //When change 
                        {
                            imageName = lblUid.Text + lblFileExtension.Text;
                        }

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        string sqlwin = "UPDATE Win_usermgt set  Name = '" + txtUserFullName.Text + "', Father_name = '" + txtFatherName.Text + "', " +
                                        " Address = '" + txtAddress.Text + "', Email = '" + txtEmailaddress.Text + "', Contact = '" + txtContact.Text + "', " +
                                        " DOB = '" + dtDOB.Value.ToString("MM/dd/yyyy") + "' , Username= '" + txtUsername.Text + "', password = '" + textUserPass.Text + "',imagename = '" + imageName + "' ,    " +
                                        " usertype    = '" + flag + "', position = '" + posi + "', Shopid = '" + cmboShopid.SelectedValue + "', " +
                                        " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                        " where id = '" + lblUid.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        int UpdateFlag = DataLive.ExecuteLiveSQL(sqlwin);
                        if (UpdateFlag == 1)
                        {
                            string sql = "UPDATE usermgt set  Name = '" + txtUserFullName.Text + "', Father_name = '" + txtFatherName.Text + "', " +
                                         " Address = '" + txtAddress.Text + "', Email = '" + txtEmailaddress.Text + "', Contact = '" + txtContact.Text + "', " +
                                         " DOB = '" + dtDOB.Value.ToString("MM/dd/yyyy") + "' , Username= '" + txtUsername.Text + "', password = '" + textUserPass.Text + "',imagename = '" + imageName + "' ,    " +
                                         " usertype    = '" + flag + "', position = '" + posi + "', Shopid = '" + cmboShopid.SelectedValue + "', " +
                                         " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                         " where id = '" + lblUid.Text + "' and TenentID= " + Tenent.TenentID + " ";
                            DataAccess.ExecuteSQL(sql);

                            // string sqlwin = "UPDATE Win_usermgt set  Name = '" + txtUserFullName.Text + "', Father_name = '" + txtFatherName.Text + "', " +
                            //" Address = '" + txtAddress.Text + "', Email = '" + txtEmailaddress.Text + "', Contact = '" + txtContact.Text + "', " +
                            //" DOB = '" + dtDOB.Value.ToString("MM/dd/yyyy") + "' , Username= '" + txtUsername.Text + "', password = '" + textUserPass.Text + "',imagename = '" + imageName + "' ,    " +
                            //" usertype    = '" + flag + "', position = '" + posi + "', Shopid = '" + cmboShopid.SelectedValue + "', " +
                            //" Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                            //" where id = '" + lblUid.Text + "' and TenentID= " + Tenent.TenentID + " ";
                            // Datasyncpso.Update_Live_sync_Update_Query(sqlwin, "Win_usermgt");

                            string ActivityName = "update User";
                            string LogData = "update User with username = : " + txtUsername.Text.Trim() + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            /////////////////////////////////////////////Update image //////////////////////////////////////////////////////
                            if (lblFileExtension.Text != "user.png")
                            {
                                picUserimage.InitialImage.Dispose();
                                string path = Application.StartupPath + @"\IMAGE\";
                                System.IO.File.Delete(path + @"\" + lblimagename.Text);
                                if (!System.IO.Directory.Exists(path))
                                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\IMAGE\");
                                string filename = path + @"\" + openFileDialog1.SafeFileName;
                                picUserimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                                System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                            }

                            MessageBox.Show("Successfully Data Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblEmailerrormsg.Visible = false;
                            loadData(lblUid.Text);
                        }
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Sorry\r\n" + exp.Message);
                }
            }
        }

        // Reset  
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //  openFileDialog1.InitialDirectory = @"C:\";
            //  openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = ".jpg";
            // openFileDialog1.Filter = "GIF files (*.gif)|*.gif| jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png| All files (*.*)|*.*";
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png";

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            //openFileDialog1.ReadOnlyChecked = true;
            //openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox1.Text = openFileDialog1.FileName;
                picUserimage.ImageLocation = openFileDialog1.FileName;
                lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            }
        }

        private void User_regi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void txtEmailaddress_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmailaddress.Text.Length > 0 && txtEmailaddress.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(txtEmailaddress.Text.Trim()))
                {
                    lblEmailerrormsg.Visible = true;
                    lblEmailerrormsg.Text = "Invalid Email address";
                    txtEmailaddress.SelectAll();
                    // e.Cancel = true;

                }
                else
                {
                    btnSave.Enabled = true;
                    lblEmailerrormsg.Visible = false;
                }
            }
        }

        private void lnkManageusers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_mgt.Manage_user go = new User_mgt.Manage_user();
            go.MdiParent = this.ParentForm;
            go.Show();
            this.Close();
        }

        private void lnkCustomers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Customer.CustomerDetails go = new Customer.CustomerDetails();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void lnkAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            User_mgt.User_regi go = new User_mgt.User_regi();
            go.MdiParent = this.ParentForm;
            go.Show();

        }

        //// Delete user
        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {

                if (lblUid.Text == "-")
                {
                    // MessageBox.Show("You are Not able to Update");
                    MessageBox.Show("You are Not able to Delete", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        string sql = "delete from usermgt where id = '" + lblUid.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        DataAccess.ExecuteSQL(sql);

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sqlwin = " Delete From Win_usermgt " +
                                        " where id = '" + lblUid.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        Datasyncpso.insert_Live_sync(sqlwin, "Win_usermgt", "DELETE");

                        picUserimage.InitialImage.Dispose();
                        string path = Application.StartupPath + @"\IMAGE\";
                        //System.IO.File.Delete(path + @"\" + lblimagename.Text);

                        MessageBox.Show("User has been Deleted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        User_mgt.Manage_user go = new User_mgt.Manage_user();
                        go.MdiParent = this.ParentForm;
                        go.Show();
                        this.Close();
                        ClearForm();

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Sorry\r\n You have to Check the Data" + exp.Message);
                    }
                }
            }
        }

        public static bool MatchUser(string Username)
        {
            string sql = "select * from usermgt where TenentID = " + Tenent.TenentID + " and Username='" + Username + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void lnkWorkingHours_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserInfo.usernamWK = txtUsername.Text;
            //this.Hide();
            User_mgt.WorkRecords go = new User_mgt.WorkRecords();
            //  go.MdiParent = this.ParentForm;
            go.ShowDialog();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsername.Text != "")
            {
                bool LiveFalg = Registation.MatchLiveUser(txtUsername.Text);

                if (LiveFalg == true)
                {
                    txtUsername.Text = "";
                    lblMsg.Text = "User Name Already Exist ";
                    txtUsername.Focus();
                }
                else
                {
                    bool Falg = User_mgt.User_regi.MatchUser(txtUsername.Text);

                    if (Falg == true)
                    {
                        txtUsername.Text = "";
                        lblMsg.Text = "User Name Already Exist ";
                        txtUsername.Focus();
                    }
                    else
                    {
                        lblMsg.Text = "-";
                    }
                }
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            textUserPass.UseSystemPasswordChar = true;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textUserPass.UseSystemPasswordChar = false;
        }

    }
}
