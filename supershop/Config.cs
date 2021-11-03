using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Utility.ModifyRegistry;
using Microsoft.Win32;
using System.IO;

namespace supershop
{
    public partial class Config : Form
    {

        public Config()
        {
            InitializeComponent();
            string regexpire = UserInfo.ExpireDate.ToString();
            string msg = "Your License " + UserInfo.TenentID + "\n for this Terminal= " + UserInfo.Shopid + " \n expires on " + regexpire;
            lblExpire.Text = msg;
            // txtTrVAT.CharacterCasing = CharacterCasing.Upper;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //bind terminal
        public void terminallist()
        {
            string sqlterminallist = "select Shopid as 'ID', Branchname	 ,Location ,Phone ,  " +
                                     " VAT as 'TAX %' ,Dis as 'Discount %'    from tbl_terminallocation where TenentID = " + Tenent.TenentID + " ";
            DataTable dtterminallist = DataAccess.GetDataTable(sqlterminallist);
            dtgrdViewTerminallist.DataSource = dtterminallist;
        }

        private void Config_Load(object sender, EventArgs e)
        {
            //try
            //{
            //Bind store info 
            string sql3 = "select * from storeconfig where TenentID = " + Tenent.TenentID + "";
            DataTable dt1 = DataAccess.GetDataTable(sql3);
            if (dt1.Rows.Count > 0)
            {
                txtCompanyName.Text = dt1.Rows[0]["companyname"].ToString();
                txtCompanyAddress.Text = dt1.Rows[0]["companyaddress"].ToString();
                txtPhone.Text = dt1.Rows[0]["companyphone"].ToString();
                txtVatRegiNo.Text = dt1.Rows[0]["vatno"].ToString();
                txtWebSite.Text = dt1.Rows[0]["web"].ToString();
                lblid.Text = dt1.Rows[0]["id"].ToString();
                txtVATRate.Text = dt1.Rows[0]["vatrate"].ToString();
                txtDiscountRate.Text = dt1.Rows[0]["disrate"].ToString();
                txtFootermsg.Text = dt1.Rows[0]["footermsg"].ToString();
                txtAddinal.Text = dt1.Rows[0]["InvAddtionalLine"].ToString();
                txtStoreFacebook.Text = dt1.Rows[0]["FaceBook"].ToString();
                txtstoreTwitter.Text = dt1.Rows[0]["Twitter"].ToString();
                txtStoreInsta.Text = dt1.Rows[0]["Insta"].ToString();

                txtTrweb.Text = dt1.Rows[0]["web"].ToString();
                txtTrFootermsg.Text = dt1.Rows[0]["footermsg"].ToString();
                string imgpath1 = Application.StartupPath + @"\LOGO\";

                string IMG = imgpath1 + dt1.Rows[0]["Logo"].ToString();
                if (File.Exists(IMG))
                {
                    txtLOGO.Text = imgpath1 + dt1.Rows[0]["Logo"].ToString();
                    string Path = imgpath1 + dt1.Rows[0]["Logo"].ToString();
                    if (File.Exists(Path))
                    {
                        picItemimage.Image = Image.FromFile(Path);
                    }
                }
                else
                {
                    txtLOGO.Text = dt1.Rows[0]["Logo"].ToString();
                    string Path = dt1.Rows[0]["Logo"].ToString();
                    if (File.Exists(Path))
                    {
                        picItemimage.Image = Image.FromFile(Path);
                    }

                }
            }
            DefaultValue();

            terminallist();
            dtgrdViewTerminallist.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (lblShopID.Text == "-")
            {
                btnAddnew.Visible = false;
                lnkDelete.Visible = false;
            }
            else
            {
                btnAddnew.Visible = true;
                lnkDelete.Visible = true;
            }
            //}
            //catch
            //{
            //}

        }

        public void DefaultValue()
        {

            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

            string Database = null;
            string image = null;

            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii5") != null)
                {
                    Database = EncryptionClass.Decrypt(Readkey.GetValue("kascii5").ToString());
                    txtDatabse.Text = Database;
                    txtterminalDatabase.Text = Database;
                }

                if (Readkey.GetValue("kascii6") != null)
                {
                    image = EncryptionClass.Decrypt(Readkey.GetValue("kascii6").ToString());
                    txtImagePath.Text = image;
                    txttreminalImage.Text = image;
                }

            }
        }

        ModifyRegistry myRegistry = new ModifyRegistry();

        public string Key = @"SOFTWARE\Encrypt\Encrypt";

        private void bntSave_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "" || txtCompanyAddress.Text == "" || txtPhone.Text == "" || txtVATRate.Text == "" || txtDiscountRate.Text == "")
            {
                // MessageBox.Show("You are Not able to Update");
                MessageBox.Show("You are Not able to Update", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string Ext = Path.GetExtension(txtLOGO.Text);
                    string imageName = "LOGO" + txtCompanyName.Text + Ext;

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql = " update storeconfig set companyname= '" + txtCompanyName.Text + "', companyaddress = '" + txtCompanyAddress.Text + "', " +
                                 " companyphone = '" + txtPhone.Text + "', vatno = '" + txtVatRegiNo.Text + "' , web = '" + txtWebSite.Text + "' ,    " +
                                 " vatrate = '" + txtVATRate.Text + "', disrate = '" + txtDiscountRate.Text + "' , footermsg = '" + txtFootermsg.Text + "' ,   " +
                                 " FaceBook = '" + txtStoreFacebook.Text + "', Twitter = '" + txtstoreTwitter.Text + "' , Insta = '" + txtStoreInsta.Text + "' ,InvAddtionalLine='" + txtAddinal.Text + "',   " +
                                 " DbPath = '" + txtDatabse.Text + "', ImgPath = '" + txtImagePath.Text + "',Logo='" + imageName + "', " +
                                 " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                 " where TenentID= " + Tenent.TenentID + " and id = '" + lblid.Text + "'";

                    DataAccess.ExecuteSQL(sql);

                    string sqlwin = " update Win_storeconfig set companyname= '" + txtCompanyName.Text + "', companyaddress = '" + txtCompanyAddress.Text + "', " +
                                 " companyphone = '" + txtPhone.Text + "', vatno = '" + txtVatRegiNo.Text + "' , web = '" + txtWebSite.Text + "' ,    " +
                                 " vatrate = '" + txtVATRate.Text + "', disrate = '" + txtDiscountRate.Text + "' , footermsg = '" + txtFootermsg.Text + "' ,   " +
                                 " FaceBook = '" + txtStoreFacebook.Text + "', Twitter = '" + txtstoreTwitter.Text + "' , Insta = '" + txtStoreInsta.Text + "' ,InvAddtionalLine='" + txtAddinal.Text + "',   " +
                                 " DbPath = '" + txtDatabse.Text + "', ImgPath = '" + txtImagePath.Text + "',Logo='" + imageName + "', " +
                                 " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                 " where TenentID= " + Tenent.TenentID + " and id = '" + lblid.Text + "'";
                    Datasyncpso.insert_Live_sync(sqlwin, "Win_storeconfig", "UPDATE");

                    string ActivityName = "Update Store Detail";
                    string LogData = "Update Store Detail ";
                    Login.InsertUserLog(ActivityName, LogData);


                    RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

                    string Database = null;
                    string image = null;

                    if (Readkey != null)
                    {
                        if (Readkey.GetValue("kascii5") != null)
                            Database = EncryptionClass.Decrypt(Readkey.GetValue("kascii5").ToString());
                        if (Readkey.GetValue("kascii6") != null)
                            image = EncryptionClass.Decrypt(Readkey.GetValue("kascii6").ToString());
                    }

                    if (Database == null && image == null)
                    {
                        RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);

                        if (txtDatabse.Text != "")
                        {
                            string Dbpath = txtDatabse.Text;
                            string EncDbpath = EncryptionClass.Encrypt(Dbpath);
                            key.SetValue("kascii5", EncDbpath);
                        }

                        if (txtImagePath.Text != "")
                        {
                            string imgpath = txtImagePath.Text;
                            string Encimgpath = EncryptionClass.Encrypt(imgpath);
                            key.SetValue("kascii6", Encimgpath);
                        }

                    }
                    else
                    {
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
                        if (txtDatabse.Text != "")
                        {
                            string Dbpath = txtDatabse.Text;
                            string EncDbpath = EncryptionClass.Encrypt(Dbpath);
                            key.SetValue("kascii5", EncDbpath);
                        }

                        if (txtImagePath.Text != "")
                        {
                            string imgpath = txtImagePath.Text;
                            string Encimgpath = EncryptionClass.Encrypt(imgpath);
                            key.SetValue("kascii6", Encimgpath);
                        }
                    }

                    try
                    {
                        string imgpath1 = Application.StartupPath + @"\LOGO\";
                        string imageFile = imgpath1 + @"\" + imageName;
                        //if (!File.Exists(imageFile))
                        //{
                        picItemimage.InitialImage.Dispose();

                        using (FileStream fs = new FileStream(imageFile, FileMode.OpenOrCreate, FileAccess.Write))
                        using (BinaryWriter br = new BinaryWriter(fs))
                        {
                            br.Write("BinaryDataFromDB");
                            fs.Flush();
                        }

                        //Force clean up
                        GC.Collect();

                        System.IO.File.Delete(imageFile);
                        if (!System.IO.Directory.Exists(imgpath1))
                            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\LOGO\");
                        string filename = imgpath1 + @"\" + openFileDialog1.SafeFileName;
                        picItemimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        System.IO.File.Move(imgpath1 + @"\" + openFileDialog1.SafeFileName, imgpath1 + @"\" + imageName);
                        //}
                                       
                    }
                    catch
                    {

                    }

                    DialogResult result = MessageBox.Show("Path is Save Successfully. Restart Application?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        Application.Restart();
                    }
                    else
                    {
                        this.Close();
                    }

                    lblmsg.Text = "Configuation has been Saved";
                    lblmsg.Visible = true;

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Sorry\r\n You have to Check the Data" + exp.Message);
                }
            }
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            lblmsg.Visible = false;
        }

        private void txtVATRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtVATRate.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch
            {
            }
        }

        private void txtDiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtDiscountRate.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch
            {
            }
        }

        // Click terminal list and move to add and update
        private void dtgrdViewTerminallist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dtgrdViewTerminallist.Rows[e.RowIndex];
                string terminalid = row.Cells[0].Value.ToString();


                string sqlterminallist = "select * from tbl_terminalLocation " +
                                         " where Tenentid=" + Tenent.TenentID + " and Shopid = '" + terminalid + "' ";
                DataTable dtterminallist = DataAccess.GetDataTable(sqlterminallist);

                if (dtterminallist.Rows.Count > 0)
                {
                    lblShopID.Text = dtterminallist.Rows[0]["Shopid"].ToString();
                    txtterminalname.Text = dtterminallist.Rows[0]["Branchname"].ToString();
                    txtTerminaladdress.Text = dtterminallist.Rows[0]["Location"].ToString();
                    txtTerminalPhone.Text = dtterminallist.Rows[0]["Phone"].ToString();
                    txtTremail.Text = dtterminallist.Rows[0]["Email"].ToString();
                    txtTrweb.Text = dtterminallist.Rows[0]["Web"].ToString();
                    txtTrVAT.Text = dtterminallist.Rows[0]["VAT"].ToString();
                    txtTrDis.Text = dtterminallist.Rows[0]["Dis"].ToString();
                    txtTrVATregino.Text = dtterminallist.Rows[0]["VATRegiNo"].ToString();
                    txtTrFootermsg.Text = dtterminallist.Rows[0]["Footermsg"].ToString();
                    txtTerminalAddninal.Text = dtterminallist.Rows[0]["InvAddtionalLine"].ToString();
                    txtFacebookID.Text = dtterminallist.Rows[0]["FaceBook"].ToString();
                    txtTwitter.Text = dtterminallist.Rows[0]["Twitter"].ToString();
                    txtInsta.Text = dtterminallist.Rows[0]["Insta"].ToString();
                    txtSyncAfter.Text = dtterminallist.Rows[0]["syncAfter"].ToString();

                    tabControl1.SelectedTab = tabterminal;
                    btnAddnew.Visible = true;
                    lnkDelete.Visible = true;
                    lbltrmsg.Visible = false;

                    int AllowMinusQty = DataAccess.checkMinus();
                    if (AllowMinusQty == 1)
                    {
                        AllowChack.Checked = true;
                    }
                    else
                    {
                        AllowChack.Checked = false;
                    }
                }

            }
            catch
            {
            }


        }

        private void bntTrSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtterminalname.Text == "" || txtTerminaladdress.Text == "" || txtTerminalPhone.Text == "" || txtTrVAT.Text == "" || txtTrDis.Text == "")
                {
                    MessageBox.Show("Please fill Terminal info", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Add new Terminal Info
                    if (lblShopID.Text == "-")
                    {
                        string Shopid = txtterminalname.Text.Substring(0, 2) + txtTrVATregino.Text.Substring(0, 2);

                        int ID = DataAccess.getterminallocationMYid(Tenent.TenentID);

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sqlinsert = " insert into tbl_terminallocation " +
                                           "(TenentID, ID, Shopid, CompanyName, Branchname , Location ,Phone , Email ,  Web, VAT , Dis , VATRegiNo , Footermsg,FaceBook,Twitter,Insta,InvAddtionalLine,DbPath,ImgPath,syncAfter,Uploadby ,UploadDate ,SynID ) " +
                                           " values (" + Tenent.TenentID + ", " + ID + " ,'" + Shopid + "' , '" + txtCompanyName.Text + "' , '" + txtterminalname.Text + "' , " +
                                            " '" + txtTerminaladdress.Text + "' , '" + txtTerminalPhone.Text + "' , '" + txtTremail.Text + "' ," +
                                            " '" + txtTrweb.Text + "',  '" + txtTrVAT.Text + "', " +
                                            " '" + txtTrDis.Text + "' , '" + txtTrVATregino.Text + "',  '" + txtTrFootermsg.Text + "' ," +
                                            " '" + txtFacebookID.Text + "','" + txtTwitter.Text + "','" + txtInsta.Text + "','" + txtTerminalAddninal.Text + "'," +
                                            " '" + txtterminalDatabase.Text + "',  '" + txttreminalImage.Text + "'," + Convert.ToInt32(txtSyncAfter.Text) + ",'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        DataAccess.ExecuteSQL(sqlinsert);

                        string sqlinsertWin = " insert into Win_tbl_terminallocation " +
                                           "(TenentID,ID, Shopid, CompanyName, Branchname , Location ,Phone , Email ,  Web, VAT , Dis , VATRegiNo , Footermsg,FaceBook,Twitter,Insta,InvAddtionalLine,DbPath,ImgPath,syncAfter,Uploadby ,UploadDate ,SynID ) " +
                                           " values (" + Tenent.TenentID + "," + ID + " , '" + Shopid + "' , N'" + txtCompanyName.Text + "' , N'" + txtterminalname.Text + "' , " +
                                            " N'" + txtTerminaladdress.Text + "' , '" + txtTerminalPhone.Text + "' , '" + txtTremail.Text + "' ," +
                                            " '" + txtTrweb.Text + "',  '" + txtTrVAT.Text + "', " +
                                            " '" + txtTrDis.Text + "' , '" + txtTrVATregino.Text + "',  N'" + txtTrFootermsg.Text + "' ," +
                                            " '" + txtFacebookID.Text + "','" + txtTwitter.Text + "','" + txtInsta.Text + "', N'" + txtTerminalAddninal.Text + "'," +
                                            " '" + txtterminalDatabase.Text + "',  '" + txttreminalImage.Text + "'," + Convert.ToInt32(txtSyncAfter.Text) + ",'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        Datasyncpso.insert_Live_sync(sqlinsertWin, "Win_tbl_terminallocation", "INSERT");

                        string ActivityName = "insert Terminal";
                        string LogData = "insert Terminal with Branchname = " + txtterminalname.Text + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        if (AllowChack.Checked == true)
                        {
                            DataAccess.UpdateAllowMinus(1);
                        }
                        else
                        {
                            DataAccess.UpdateAllowMinus(0);
                        }
                        lbltrmsg.Text = "Submitted a new Terminal";
                        lbltrmsg.Visible = true;
                        terminallist();
                        tabControl1.SelectedTab = tabterminallist;
                    }
                    else // Update selected 
                    {
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql = "update tbl_terminallocation set Branchname = '" + txtterminalname.Text + "', Location = '" + txtTerminaladdress.Text + "', " +
                        " Email = '" + txtTremail.Text + "' , Phone = '" + txtTerminalPhone.Text + "', VAT = '" + txtTrVAT.Text + "' , Web = '" + txtTrweb.Text + "' ,    " +
                        " Dis = '" + txtTrDis.Text + "', VATRegiNo = '" + txtTrVATregino.Text + "' , Footermsg = '" + txtTrFootermsg.Text + "' ,   " +
                        " CompanyName = '" + txtCompanyName.Text + "' , FaceBook = '" + txtFacebookID.Text + "', Twitter = '" + txtTwitter.Text + "', Insta = '" + txtInsta.Text + "' ,InvAddtionalLine= '" + txtTerminalAddninal.Text + "' ,   " +
                         " DbPath = '" + txtterminalDatabase.Text + "', ImgPath = '" + txttreminalImage.Text + "',syncAfter = " + Convert.ToInt32(txtSyncAfter.Text) + ", " +
                        " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                        " where TenentID= " + Tenent.TenentID + " and Shopid = '" + lblShopID.Text + "' ";
                        DataAccess.ExecuteSQL(sql);

                        string sqlwin = "update Win_tbl_terminallocation set Branchname = N'" + txtterminalname.Text + "', Location = N'" + txtTerminaladdress.Text + "', " +
                        " Email = '" + txtTremail.Text + "' , Phone = '" + txtTerminalPhone.Text + "', VAT = '" + txtTrVAT.Text + "' , Web = '" + txtTrweb.Text + "' ,    " +
                        " Dis = '" + txtTrDis.Text + "', VATRegiNo = '" + txtTrVATregino.Text + "' , Footermsg = N'" + txtTrFootermsg.Text + "' ,   " +
                        " CompanyName = N'" + txtCompanyName.Text + "' , FaceBook = '" + txtFacebookID.Text + "', Twitter = '" + txtTwitter.Text + "', Insta = '" + txtInsta.Text + "' ,InvAddtionalLine= N'" + txtTerminalAddninal.Text + "' ,   " +
                         " DbPath = '" + txtterminalDatabase.Text + "', ImgPath = '" + txttreminalImage.Text + "', syncAfter = " + Convert.ToInt32(txtSyncAfter.Text) + ", " +
                        " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                        " where TenentID= " + Tenent.TenentID + " and Shopid = '" + lblShopID.Text + "' ";
                        Datasyncpso.insert_Live_sync(sqlwin, "Win_tbl_terminallocation", "UPDATE");

                        string ActivityName = "update Terminal";
                        string LogData = "update Terminal with Shopid = " + lblShopID.Text + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        if (AllowChack.Checked == true)
                        {
                            DataAccess.UpdateAllowMinus(1);
                        }
                        else
                        {
                            DataAccess.UpdateAllowMinus(0);
                        }
                        lbltrmsg.Text = "Terminal info has been Saved";
                        lbltrmsg.Visible = true;
                        terminallist();
                        tabControl1.SelectedTab = tabterminallist;
                    }
                }

            }
            catch
            {
            }
        }

        // Prevent String value
        private void txtTrVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtTrVAT.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch
            {
            }
        }

        // Prevent String value
        private void txtTrDis_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtTrDis.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch
            {
            }
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            txtterminalname.Text = string.Empty;
            txtTerminaladdress.Text = string.Empty;
            txtVatRegiNo.Text = string.Empty;
            txtTrweb.Text = txtWebSite.Text;
            txtTrFootermsg.Text = txtFootermsg.Text;
            lblShopID.Text = "-";
        }

        private void helplnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            parameter.helpid = "config";
            HelpPage go = new HelpPage();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {

                if (lblShopID.Text == "-")
                {
                    // MessageBox.Show("You are Not able to Update");
                    MessageBox.Show("You are Not able to Delete", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        string sql = "delete from tbl_terminalLocation where TenentID = " + Tenent.TenentID + " and Shopid ='" + lblShopID.Text + "'";
                        DataAccess.ExecuteSQL(sql);
                        string sqlLive = "delete from Win_tbl_terminalLocation where TenentID = " + Tenent.TenentID + " and Shopid ='" + lblShopID.Text + "'";
                        Datasyncpso.insert_Live_sync(sqlLive, "Win_tbl_terminalLocation", "DELETE");

                        MessageBox.Show("successfully Data Delete !", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        terminallist();
                        tabControl1.SelectedTab = tabterminallist;

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Sorry\r\n You have to Check the Data" + exp.Message);
                    }
                }
            }
        }

        private void btnDatabasepath_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderDlg = new OpenFileDialog();

            folderDlg.InitialDirectory = @"C:\";
            folderDlg.Title = "Browse DataBase Files";

            folderDlg.CheckFileExists = true;
            folderDlg.CheckPathExists = true;

            folderDlg.DefaultExt = "db";
            folderDlg.Filter = "Database files (*.db)|*.db";
            folderDlg.FilterIndex = 2;
            folderDlg.RestoreDirectory = true;

            folderDlg.ReadOnlyChecked = true;
            folderDlg.ShowReadOnly = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnDatabasepath.Text = folderDlg.FileName;
                string DB = btnDatabasepath.Text.Trim();
                DB = DB.TrimStart('\\');
                btnDatabasepath.Text = DB;
            }
        }

        private void btnImagePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtImagePath.Text = folderDlg.SelectedPath + @"\";
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void btnTerminalDatabase_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtterminalDatabase.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void btnterminalImage_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txttreminalImage.Text = folderDlg.SelectedPath + @"\";
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();

            FileDialog.InitialDirectory = @"C:\";
            FileDialog.Title = "Browse IMAGE Files";

            FileDialog.CheckFileExists = true;
            FileDialog.CheckPathExists = true;

            FileDialog.DefaultExt = "png";
            FileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            FileDialog.FilterIndex = 2;
            FileDialog.RestoreDirectory = true;

            FileDialog.ReadOnlyChecked = true;
            FileDialog.ShowReadOnly = true;
            DialogResult result = FileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                picItemimage.Image = new Bitmap(FileDialog.FileName);
                txtLOGO.Text = FileDialog.FileName;
            }
        }

        private void txtSyncAfter_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show(ex.Message);
            }
        }

    }
}
