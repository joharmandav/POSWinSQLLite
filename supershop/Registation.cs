using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Transactions;
using System.Windows.Forms;


namespace supershop
{
    public partial class Registation : Form
    {
        //POSWinAppEntities DB = new POSWinAppEntities();

        InputLanguage arabic;
        InputLanguage english;
        InputLanguage French;
        public Registation()
        {
            InitializeComponent();
            lblmsg.Visible = false;
            lblmsg.Text = "";

            string MAc_add =
            lblCmac.Text = Login.GetMACAddress();

            bool Internat = Login.InternetConnection();

            if (Internat == false)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Check Internet Connention";
                return;
            }
        }

        public string CompanyName
        {
            set
            {
                txtCopName_Eng.Text = value;
            }
            get
            {
                return txtCopName_Eng.Text;
            }
        }

        public string Country
        {
            set
            {
                comCountry.Text = value;
            }
            get
            {
                return comCountry.Text;
            }
        }

        public string EmailID
        {
            set
            {
                txtEmailaddress.Text = value;
                txtTremail.Text = value;
            }
            get
            {
                return txtEmailaddress.Text;
            }
        }

        public string WeSiteURL
        {
            set
            {
                txtWebSite.Text = value;
            }
            get
            {
                return txtWebSite.Text;
            }
        }

        public string MobileNo
        {
            set
            {
                txtTerminalPhone.Text = value;
                txtPhone.Text = value;
                txtContact.Text = value;
            }
            get
            {
                return txtTerminalPhone.Text;
            }
        }

        public string UserName
        {
            set
            {
                txtUsername.Text = value;
            }
            get
            {
                return txtUsername.Text;
            }
        }

        public string Password
        {
            set
            {
                textUserPass.Text = value;
            }
            get
            {
                return textUserPass.Text;
            }
        }

        public string Key = @"SOFTWARE\Encrypt\Encrypt";
        public void ExpireApp()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

            string mac = null;
            string Install = null;
            string regexpire = null;
            int TenentID = 1;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii1") != null)
                    mac = EncryptionClass.Decrypt(Readkey.GetValue("kascii1").ToString());
                if (Readkey.GetValue("kascii2") != null)
                    Install = EncryptionClass.Decrypt(Readkey.GetValue("kascii2").ToString());
                if (Readkey.GetValue("kascii3") != null)
                    regexpire = EncryptionClass.Decrypt(Readkey.GetValue("kascii3").ToString());
                if (Readkey.GetValue("kascii4") != null)
                    TenentID = Convert.ToInt32(EncryptionClass.Decrypt(Readkey.GetValue("kascii4").ToString()));

                if (Readkey.GetValue("kascii1") != null && Readkey.GetValue("kascii2") != null && Readkey.GetValue("kascii3") != null && Readkey.GetValue("kascii4") != null)
                {
                    UserInfo.TenentID = TenentID;
                    DateTime expire = Convert.ToDateTime(regexpire);
                    UserInfo.ExpireDate = expire.ToString("dd-MMM-yyyy");

                    string msg = "Your License " + UserInfo.TenentID + "\n for this Terminal= " + UserInfo.Shopid + " \n expires on " + regexpire;
                    lblExpire.Text = msg;
                    txtSearchTenent.Text = UserInfo.TenentID != 0 ? UserInfo.TenentID.ToString() : "";
                }
            }
        }

        private void Registation_Load(object sender, EventArgs e)
        {
            dtDOB.Format = DateTimePickerFormat.Custom;
            dtDOB.CustomFormat = "MM/dd/yyyy";

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

                ExpireApp();
                string sqlCust = "select   DISTINCT  CuntryName from tblCountry where Active = 'Y'";
                //DataAccess.ExecuteSQL(sqlCust);
                DataTable dtCust = DataAccess.GetDataTable(sqlCust);
                comCountry.DataSource = dtCust;
                comCountry.DisplayMember = "CuntryName";
                comCountry.Text = "Kuwait";
                lblCountryid.Text = "126";

                txtShopID.Text = "1";

                string sqlMac = "Select * FROM  mycompanysetup_winapp";
                //DataAccess.ExecuteSQL(sqlMac);
                DataTable dtMAC = DataAccess.GetDataTable(sqlMac);

                if (dtMAC.Rows.Count > 0)
                {
                    CheckRegitration();
                }
                else
                {
                    int Tenent = 9000001;
                    bool CON_Ceck = Login.CheckDBConnection();

                    if (CON_Ceck == true)
                    {
                        // string sql = "select *  from Win_mycompanysetup_winapp";
                        // DataTable dt = DataLive.GetLiveDataTable(sql);
                        // if (dt.Rows.Count > 0)
                        // {
                        string sqlCHeck = "select MAX(TenentID)  from Win_mycompanysetup_winapp";
                        DataTable dtCheck = DataLive.GetLiveDataTable(sqlCHeck);
                        if (dtCheck.Rows.Count > 0)
                        {
                            int id = Convert.ToInt32(dtCheck.Rows[0][0]);
                            Tenent = id + 1;
                        }
                        // }
                    }

                    //int Tenent = DB.Win_mycompanysetup_winapp.Count() > 0 ? Convert.ToInt32(DB.Win_mycompanysetup_winapp.Max(p => p.TenentID)) + 1 : 9000001;
                    txtTenentid.Text = Tenent.ToString();


                }
                string MacAll = getAllMac();
                int RegID = Login.get_reg_TenentID();
                txtmac.Text = MacAll;
                reg_tenent.Text = RegID.ToString();
                BindStore();
                BindTerminal();
                Bindshopbranch();
                checkUser();

                loadData(lblUid.Text);

                DefaultValue();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void DefaultValue()
        {
            if (lblCountryid.Text == null || lblCountryid.Text == "")
                lblCountryid.Text = "126";

            if (comCountry.Text == null || comCountry.Text == "")
                comCountry.Text = "Kuwait";

            if (txtCompanyName.Text == null || txtCompanyName.Text == "")
                txtCompanyName.Text = txtCopName_Eng.Text;

            if (txtUserFullName.Text == null || txtUserFullName.Text == "")
                txtUserFullName.Text = txtCopName_Eng.Text;

            if (comDefaultLanguage.Text == null || comDefaultLanguage.Text == null)
                comDefaultLanguage.Text = "English";

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

        public void checkUser()
        {
            string sqluser = "select * from usermgt";
            DataTable dtuser = DataAccess.GetDataTable(sqluser);

            if (dtuser.Rows.Count > 0)
            {
                lblUid.Text = dtuser.Rows[0][0].ToString();
                txtUsername.Enabled = false;
            }
            else
            {
                lblUid.Text = "-";
                txtUsername.Enabled = true;
            }
        }

        private void txtCopName_Eng_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }

        private void txtCopName_Arabic_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = arabic;
        }

        private void txtCopname_Franch_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = French;
        }

        private void txtCopname_Franch_LostFocus(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }

        private void txtCopName_Arabic_LostFocus(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }

        public void mainatince()
        {
            try
            {
                string sqlCmd = "update  ICUOM set TenentID = (select TenentID from mycompanysetup_winapp ) where TenentID = 0 ";
                DataAccess.ExecuteSQL(sqlCmd);
            }
            catch
            { }

            try
            {
                string sqlCmd = "update  REFTABLE set TenentID = (select TenentID from mycompanysetup_winapp ) where TenentID = 0 ";
                DataAccess.ExecuteSQL(sqlCmd);
            }
            catch
            { }

            try
            {
                string sqlCmd1 = "update  tbl_customer set TenentID = (select TenentID from mycompanysetup_winapp ) where TenentID = 0 ";
                DataAccess.ExecuteSQL(sqlCmd1);
            }
            catch
            { }

            try
            {
                string sqlCmd2 = "update  tbl_orderWay_Maintenance set TenentID = (select TenentID from mycompanysetup_winapp ) where TenentID = 0 ";
                DataAccess.ExecuteSQL(sqlCmd2);
            }
            catch
            { }

            try
            {
                string sqlCmd3 = "update  tblCountry set TenentID = (select TenentID from mycompanysetup_winapp ) where TenentID = 0 ";
                DataAccess.ExecuteSQL(sqlCmd3);
            }
            catch
            { }
        }

        public void mainatince1(int TenentID)
        {
            try
            {
                string sqlCmd = "update  ICUOM set TenentID = " + TenentID + " where TenentID = 0 and UOM not in (select UOM from ICUOM where TenentID = " + TenentID + ")";
                DataAccess.ExecuteSQL(sqlCmd);
            }
            catch
            { }

            try
            {
                string sqlCmd = "update  REFTABLE set TenentID = " + TenentID + " where TenentID = 0 ";
                DataAccess.ExecuteSQL(sqlCmd);
            }
            catch
            { }

            try
            {
                string sqlCmd1 = "update  tbl_customer set TenentID = " + TenentID + "  where TenentID = 0 and ID not in (select ID from tbl_customer where TenentID = " + TenentID + ")";
                DataAccess.ExecuteSQL(sqlCmd1);
            }
            catch
            { }

            try
            {
                string sqlCmd2 = "update  tbl_orderWay_Maintenance set TenentID = " + TenentID + "  where TenentID = 0 ";
                DataAccess.ExecuteSQL(sqlCmd2);
            }
            catch
            { }

            try
            {
                string sqlCmd3 = "update  tblCountry set TenentID = " + TenentID + "  where TenentID = 0 ";
                DataAccess.ExecuteSQL(sqlCmd3);
            }
            catch
            { }
        }

        public static void UodateSuperuser()
        {
            if (Login.InternetConnection() == true)
            {
                if (Login.CheckDBConnection() == true)
                {
                    string sqlselect = "select * from MODULE_MST where TenentID = 0 and Module_Name = 'POS_WIN' and Parent_Module_id != 0 ";
                    DataTable dtselect = DataLive.GetLiveDataTable(sqlselect);

                    if (dtselect.Rows.Count > 0)
                    {
                        string Suser = dtselect.Rows[0]["Suser"] != null ? dtselect.Rows[0]["Suser"].ToString() : "";
                        string temppass = dtselect.Rows[0]["Suser"] != null ? dtselect.Rows[0]["SPass"].ToString() : "";

                        if (Suser != "" && temppass != "")
                        {
                            string SPass = EncryptionClass.Encrypt(temppass);

                            string sqlupdate = " Update mycompanysetup_winapp set" +
                                               " Suser = '" + Suser + "', SPass = '" + SPass + "' ";
                            DataAccess.ExecuteSQL(sqlupdate);
                        }
                    }
                }
            }
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
            if (txtTenentid.Text == "")
            {
                MessageBox.Show("Tenentid Requird", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenentid.Focus();
                return;
            }
            else if (txtShopID.Text == "")
            {
                MessageBox.Show("Shop ID Requird", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShopID.Focus();
                return;
            }
            else if (txtCopName_Eng.Text == "")
            {
                MessageBox.Show("Company Name In English Requird", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCopName_Eng.Focus();
                return;
            }
            else if (txtCopName_Arabic.Text == "")
            {
                MessageBox.Show("Company Name In Arabic  Requird", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCopName_Arabic.Focus();
                return;
            }
            else if (txtCopname_Franch.Text == "")
            {
                MessageBox.Show("Company Name In Franch  Requird", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCopname_Franch.Focus();
                return;
            }
            else if (comCountry.Text == "")
            {
                MessageBox.Show("Country Requird", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comCountry.Focus();
                return;
            }
            else if (comDefaultLanguage.Text == "")
            {
                MessageBox.Show("Default Language Requird", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comDefaultLanguage.Focus();
                return;
            }
            else
            {
                int Tenentid = Convert.ToInt32(txtTenentid.Text);
                string Shopid = txtShopID.Text;
                int TenentGroupID = 1;
                string COMPNAME1 = txtCopName_Eng.Text;
                string COMPNAME2 = txtCopName_Arabic.Text;
                string COMPNAME3 = txtCopname_Franch.Text;
                //string Mac_Addr = Login.GetMACAddress();
                string MacAll = getAllMac();
                int COUNTRYID = Convert.ToInt32(lblCountryid.Text);
                string DefaultLanguage = comDefaultLanguage.Text;

                CheckActivation();

                bool Falg = insertLive(Tenentid, COMPNAME1, COMPNAME2, COMPNAME3, COUNTRYID, MacAll, DefaultLanguage);

                if (Falg == true)
                {
                    string sqlMac = "Select * FROM  mycompanysetup_winapp where TenentID=" + Tenentid + " and Shopid = '" + Shopid + "' ";
                    DataTable dtMAC = DataAccess.GetDataTable(sqlMac);
                    if (dtMAC.Rows.Count < 1)
                    {
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sqlLogIn = " insert into tblsetupsalesh (TenentID, LocationID,AllowMinusQty,Uploadby ,UploadDate ,SynID) " +
                                            " values ('" + Tenentid + "' ,1,1,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                        int flag = DataAccess.ExecuteSQL(sqlLogIn);


                        string sqlLogI = " insert into Win_tblsetupsalesh (TenentID, LocationID,AllowMinusQty,Uploadby ,UploadDate ,SynID) " +
                                           " values ('" + Tenentid + "' ,1,1,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                        Datasyncpso.insert_Live_sync(sqlLogI, "Win_tblsetupsalesh", "INSERT");
                        //Insert_mycompanysetup_winapp_CompanyRegistration sahir
                        string sqlinsert = " insert into mycompanysetup_winapp " +
                                                   "(TenentID, Shopid, TenentGroupID ,COMPNAME1 , COMPNAME2 ,  COMPNAME3, COUNTRYID , Mac_Addr,DefaultLanguage,AllowUser,Uploadby ,UploadDate ,SynID) " +
                                                   " values (" + Tenentid + ",'" + Shopid + "'," + TenentGroupID + ",'" + COMPNAME1 + "','" + COMPNAME2 + "','" + COMPNAME3 + "'," + COUNTRYID + ",'" + MacAll + "','" + DefaultLanguage + "','1','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        DataAccess.ExecuteSQL(sqlinsert);


                        //string ActivityName = "Registration";
                        //string LogData = "Registration with TenentID = " + Tenentid + " ";
                        //Login.InsertUserLog(ActivityName, LogData);

                        DataAccess.getTEnentID();
                        //Datasyncpso.insert_Live_sync_Query(sqlinsert);
                    }
                    else
                    {
                        //Edit_mycompanysetup_winapp_CompanyRegistration sahir
                        string sqlupdate = " Update mycompanysetup_winapp set" +
                                                   " Shopid='" + Shopid + "' , COMPNAME1='" + COMPNAME1 + "', COMPNAME2='" + COMPNAME2 + "', COMPNAME3='" + COMPNAME3 + "', Mac_Addr='" + MacAll + "' , COUNTRYID=" + COUNTRYID + ", DefaultLanguage='" + DefaultLanguage + "' where TenentID=" + Tenentid + " and Shopid='" + Shopid + "' ";

                        DataAccess.ExecuteSQL(sqlupdate);

                        DataAccess.getTEnentID();
                    }

                    mainatince();

                    this.tabStore.Parent = this.tabControl1; //show
                    tabControl1.SelectedTab = tabStore;
                }
            }
        }

        public void CheckRegitration()
        {
            string sqlMac = "Select * FROM  mycompanysetup_winapp";
            DataTable dtMAC = DataAccess.GetDataTable(sqlMac);

            if (dtMAC.Rows.Count > 0)
            {
                txtTenentid.Text = dtMAC.Rows[0]["TenentID"].ToString();
                txtShopID.Text = dtMAC.Rows[0]["Shopid"].ToString();
                txtCopName_Eng.Text = dtMAC.Rows[0]["COMPNAME1"].ToString();
                txtCopName_Arabic.Text = dtMAC.Rows[0]["COMPNAME2"].ToString();
                txtCopname_Franch.Text = dtMAC.Rows[0]["COMPNAME3"].ToString();
                lblCountryid.Text = dtMAC.Rows[0]["COUNTRYID"].ToString();

                int ID = Convert.ToInt32(dtMAC.Rows[0]["COUNTRYID"]);

                string sqlCountry = "Select * FROM  tblCountry where id=" + ID;
                DataTable dtCountry = DataAccess.GetDataTable(sqlCountry);

                if (dtCountry.Rows.Count > 0)
                {
                    comCountry.Text = dtCountry.Rows[0]["CuntryName"].ToString();
                }

                comDefaultLanguage.Text = dtMAC.Rows[0]["DefaultLanguage"].ToString();

                string Mac_Addr = Login.GetMACAddress();

            }
            else
            {
                int TenentID = Convert.ToInt32(dtMAC.Rows[0]["TenentID"]);
                string Shopid = dtMAC.Rows[0]["Shopid"].ToString();
                getLivedata(TenentID, Shopid);
            }
        }

        public void getLivedata(int TenentID, string Shopid)
        {
            bool CON_Ceck = Login.CheckDBConnection();

            if (CON_Ceck == true)
            {
                string sql = "select *  from Win_mycompanysetup_winapp where TenentID=" + TenentID + " and Shopid='" + Shopid + "' ";
                DataTable dt = DataLive.GetLiveDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    txtTenentid.Text = dt.Rows[0]["TenentID"].ToString();
                    txtShopID.Text = dt.Rows[0]["Shopid"].ToString();
                    txtCopName_Eng.Text = dt.Rows[0]["COMPNAME1"].ToString();
                    txtCopName_Arabic.Text = dt.Rows[0]["COMPNAME2"].ToString();
                    txtCopname_Franch.Text = dt.Rows[0]["COMPNAME3"].ToString();
                    lblCountryid.Text = dt.Rows[0]["COUNTRYID"].ToString();
                    comDefaultLanguage.Text = dt.Rows[0]["DefaultLanguage"].ToString();
                }
            }

        }

        public static string getAllMac()
        {
            string Mac = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) //&& nic.OperationalStatus == OperationalStatus.Up
                {
                    Mac += nic.GetPhysicalAddress().ToString() + ",";
                }
            }

            Mac = Mac.Trim();
            Mac = Mac.TrimStart(',');
            Mac = Mac.TrimEnd(',');
            return Mac;
        }

        public bool insertLive(int Tenent, string COMPNAME1, string COMPNAME2, string COMPNAME3, int COUNTRYID, string Mac_Addr, string DefaultLanguage)
        {
            string allmac = getAllMac();

            string Shopid = txtShopID.Text.ToString();
            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == true)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = "select *  from Win_mycompanysetup_winapp where TenentID=" + Tenent + " and Shopid='" + Shopid + "' ";
                DataTable dt = DataLive.GetLiveDataTable(sql);
                if (dt.Rows.Count < 1)
                {
                    DateTime InstallDate1 = DateTime.Now;
                    string InstallDate = InstallDate1.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    DateTime Exp_Date1 = InstallDate1.AddDays(30);
                    string Exp_Date = Exp_Date1.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string sqlinsert = " insert into Win_mycompanysetup_winapp " +
                                             "(TenentID, Shopid, TenentGroupID ,COMPNAME1 , COMPNAME2 ,  COMPNAME3, COUNTRYID , Mac_Addr,DefaultLanguage,AllowUser,Uploadby ,UploadDate ,SynID,installDate,ExpireDate) " +
                                             " values (" + Tenent + ",'" + Shopid + "'," + 1 + ",'" + COMPNAME1 + "', N'" + COMPNAME2 + "','" + COMPNAME3 + "'," + COUNTRYID + ",'" + allmac + "','" + DefaultLanguage + "', '1' ,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + InstallDate + "','" + Exp_Date + "')";

                    //Datasyncpso.insert_Live_sync(sqlinsert, "Win_mycompanysetup_winapp");
                    int Falg = DataLive.ExecuteLiveSQL(sqlinsert);
                    if (Falg == 1)
                    {
                        return true;
                    }
                }
                else
                {
                    string sqlupdate = " Update Win_mycompanysetup_winapp set" +
                                              " Mac_Addr = '" + allmac + "' , COMPNAME1='" + COMPNAME1 + "', COMPNAME2= N'" + COMPNAME2 + "', COMPNAME3='" + COMPNAME3 + "', COUNTRYID=" + COUNTRYID + ", DefaultLanguage='" + DefaultLanguage + "' where TenentID=" + Tenent + " and  Shopid='" + Shopid + "' ";

                    int Falg = DataLive.ExecuteLiveSQL(sqlupdate);
                    if (Falg == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void AddTblLocation(int TenentID, int LOCATIONID, string PHYSICALLOCID, string LOCNAME1, string LOCNAME2, string LOCNAME3, string ADDRESS, string DEPT, string SECTIONCODE, string ACCOUNT, int MAXDISCOUNT, string USERID, string Uploadby)
        {
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string ENTRYDATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string ENTRYTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string UPDTTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sqlselect = "select * from TBLLOCATION where TenentID = " + TenentID + " and LOCATIONID = " + LOCATIONID + "; ";
            DataTable dt = DataAccess.GetDataTable(sqlselect);
            if (dt.Rows.Count < 1)
            {
                string sqlinsert = " insert into TBLLOCATION (TenentID,LOCATIONID,PHYSICALLOCID,LOCNAME1,LOCNAME2,LOCNAME3,ADDRESS,DEPT,SECTIONCODE,ACCOUNT,MAXDISCOUNT, " +
                               " USERID,ENTRYDATE,ENTRYTIME,UPDTTIME,Active,UploadDate,Uploadby,SynID) " +
                               " values ( " + TenentID + " , " + LOCATIONID + ", '" + PHYSICALLOCID + "' , '" + LOCNAME1 + "', '" + LOCNAME2 + "', '" + LOCNAME3 + "', " +
                               " '" + ADDRESS + "', '" + DEPT + "', '" + SECTIONCODE + "', '" + ACCOUNT + "', '" + MAXDISCOUNT + "', '" + USERID + "', '" + ENTRYDATE + "', " +
                               " '" + ENTRYTIME + "','" + UPDTTIME + "','Y', '" + UploadDate + "','" + Uploadby + "' , 1)";
                DataAccess.ExecuteSQL(sqlinsert);
            }
            else
            {
                string sqlUpdate = " Update TBLLOCATION set PHYSICALLOCID = '" + PHYSICALLOCID + "' , LOCNAME1 = '" + LOCNAME1 + "' , LOCNAME2 = '" + LOCNAME2 + "' , " +
                                   " LOCNAME3 = '" + LOCNAME3 + "' , ADDRESS = '" + ADDRESS + "' , DEPT = '" + DEPT + "' , SECTIONCODE = '" + SECTIONCODE + "' ," +
                                   " ACCOUNT = '" + ACCOUNT + "' , MAXDISCOUNT = '" + MAXDISCOUNT + "' , USERID = '" + USERID + "' , UPDTTIME = '" + UPDTTIME + "' ," +
                                   " UploadDate = '" + UploadDate + "', Uploadby = '" + Uploadby + "', SynID = 2 " +
                                   " Where TenentID = " + TenentID + " and LOCATIONID = " + LOCATIONID + " ";
                DataAccess.ExecuteSQL(sqlUpdate);
            }
        }
        public string get_reg_regexpire()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);
            string regexpire = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii3") != null && Readkey.GetValue("kascii3") != "")
                {
                    regexpire = EncryptionClass.Decrypt(Readkey.GetValue("kascii3").ToString());
                }
            }

            //return "2019-09-30 14:08:11";
            return regexpire;
        }
        public bool CheckActivation()
        {
            DateTime today = DateTime.Now;
            string PC_name = System.Environment.MachineName;
            string MacAddr = Login.GetMACAddress();
            DateTime InstallDate = DateTime.Now;
            DateTime Exp_Date = InstallDate.AddDays(30);


            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

            string mac = null;
            string Install = null;
            string regexpire = null;
            int TenentID = Convert.ToInt32(txtTenentid.Text);

            mac = Login.get_reg_MAC();
            Install = Login.get_reg_Install();
            regexpire = get_reg_regexpire();
            TenentID = Login.get_reg_TenentID();

            if (mac != null && Install != null && regexpire != null && TenentID != 0)
            {
                string stenent = txtTenentid.Text;
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
                string EncTenentID = EncryptionClass.Encrypt(stenent);

                key.SetValue("kascii4", EncTenentID);

                UserInfo.TenentID = Convert.ToInt32(stenent);
                DateTime expire = Convert.ToDateTime(regexpire);
                UserInfo.ExpireDate = expire.ToString("dd-MMM-yyyy");
            }

            string Install_Date = InstallDate.ToString("yyyy-MM-dd HH:MM:ss");
            string ExpDate = Exp_Date.ToString("yyyy-MM-dd HH:MM:ss");

            if (regexpire == null && Install == null)
            {
                string stenent = txtTenentid.Text;
                RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);

                string AppPath = Application.StartupPath.ToString();

                string EncMacAddr = EncryptionClass.Encrypt(MacAddr);
                string EncInstall_Date = EncryptionClass.Encrypt(Install_Date);
                string EncExpDate = EncryptionClass.Encrypt(ExpDate);
                string EncTenentID = EncryptionClass.Encrypt(stenent);
                string EcnAppPath = EncryptionClass.Encrypt(AppPath);

                //storing the values  
                key.SetValue("kascii1", EncMacAddr);
                key.SetValue("kascii2", EncInstall_Date);
                key.SetValue("kascii3", EncExpDate);
                key.SetValue("kascii4", EncTenentID);
                key.SetValue("kascii8", EcnAppPath);
                key.Close();
                RegistryKey Readkey1 = Registry.CurrentUser.OpenSubKey(Key);
                string Readaddmac = "";
                string ReadaddInstall_Date = "";
                string ReadaddExpireDate = "";
                string ReadaddTenentID = "";
                if (Readkey1 != null)
                {
                    Readaddmac = EncryptionClass.Decrypt(Readkey1.GetValue("kascii1").ToString());
                    ReadaddInstall_Date = EncryptionClass.Decrypt(Readkey1.GetValue("kascii2").ToString());
                    ReadaddExpireDate = EncryptionClass.Decrypt(Readkey1.GetValue("kascii3").ToString());
                    ReadaddTenentID = EncryptionClass.Decrypt(Readkey1.GetValue("kascii4").ToString());

                    UserInfo.TenentID = Convert.ToInt32(ReadaddTenentID);
                    DateTime expire = Convert.ToDateTime(regexpire);
                    UserInfo.ExpireDate = expire.ToString("dd-MMM-yyyy");
                }

                if (Readaddmac == MacAddr && ReadaddInstall_Date == Install_Date && ReadaddExpireDate == ExpDate)
                    return true;
                else
                    return false;

            }
            else
            {
                DateTime Exp = Convert.ToDateTime(regexpire);
                if (Exp <= today)
                {
                    MessageBox.Show("Activation expired");
                    lblmsg.Visible = true;
                    lblmsg.Text = "Activation expired";
                    return false;
                }
                else
                {

                }
                return true;
            }
        }

        private void comCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Name = comCountry.Text;
                Name = Name.Trim();
                string sqlCmd = "Select id from  tblCountry  where CuntryName  = '" + Name + "'";
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                if (dt1.Rows.Count > 0)
                    lblCountryid.Text = dt1.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }


        public void loadData(string Uid)
        {
            groupBox2.Enabled = true;
            string sql3 = "select * from usermgt where id = '" + Uid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            if (dt1.Rows.Count > 0)
            {
                txtUserFullName.Enabled = false;
                txtLastName.Enabled = false;
                btnGenerate.Enabled = false;
                txtEmailaddress.Enabled = false;
                textUserPass.Enabled = false;
                pictureBox3.Enabled = false;

                txtUserFullName.Text = dt1.Rows[0].ItemArray[1].ToString();
                txtLastName.Text = dt1.Rows[0].ItemArray[2].ToString();
                txtAddress.Text = dt1.Rows[0].ItemArray[3].ToString();
                txtEmailaddress.Text = dt1.Rows[0].ItemArray[4].ToString();
                txtContact.Text = dt1.Rows[0].ItemArray[5].ToString();
                dtDOB.Value = Convert.ToDateTime(dt1.Rows[0].ItemArray[6].ToString());
                txtUsername.Text = dt1.Rows[0].ItemArray[7].ToString();
                textUserPass.Text = dt1.Rows[0].ItemArray[8].ToString();

                lblimagename.Text = dt1.Rows[0].ItemArray[11].ToString();

                string path = Application.StartupPath + @"\IMAGE\" + dt1.Rows[0].ItemArray[11].ToString() + "";
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
                cmboShopid.SelectedValue = dt1.Rows[0].ItemArray[12].ToString();

                groupBox2.Enabled = false;
            }

        }

        private void ClearForm()
        {
            txtUserFullName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtUsername.Text = string.Empty;
            textUserPass.Text = string.Empty;
            txtEmailaddress.Text = string.Empty;
            dtDOB.Text = string.Empty;

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string myPWD = supershop.User_mgt.PWDGenerator.GeneratePWD();
            textUserPass.Text = myPWD;
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
                txtDatabse.Text = folderDlg.FileName;
                string DB = txtDatabse.Text.Trim();
                DB = DB.TrimStart('\\');
                txtDatabse.Text = DB;
            }
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                if (emailaddress != "")
                {
                    MailAddress m = new MailAddress(emailaddress);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void txtEmailaddress_Validating(object sender, CancelEventArgs e)
        {
            bool falge = IsValid(txtEmailaddress.Text);

            if (falge == false)
            {
                lblEmailerrormsg.Visible = true;
                lblEmailerrormsg.Text = "Invalid Email address";
                txtEmailaddress.SelectAll();
            }
            else
            {
                btnSave.Enabled = true;
                lblEmailerrormsg.Visible = false;
            }

            //System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            //if (txtEmailaddress.Text.Length > 0 && txtEmailaddress.Text.Trim().Length != 0)
            //{
            //    if (!rEmail.IsMatch(txtEmailaddress.Text.Trim()))
            //    {
            //        lblEmailerrormsg.Visible = true;
            //        lblEmailerrormsg.Text = "Invalid Email address";
            //        txtEmailaddress.SelectAll();
            //        // e.Cancel = true;

            //    }
            //    else
            //    {
            //        btnSave.Enabled = true;
            //        lblEmailerrormsg.Visible = false;
            //    }
            //}

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

        public void BindTerminal()
        {
            string sql = "select * from tbl_terminalLocation where Tenentid= " + Tenent.TenentID + " ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                string Shopid = dt.Rows[0]["Shopid"].ToString();
                string sqlterminallist = "select *   from tbl_terminalLocation " +
                                         " where TenentID = " + txtTenentid.Text + " and Shopid = '" + Shopid + "' ";
                DataTable dtterminallist = DataAccess.GetDataTable(sqlterminallist);
                if (dtterminallist.Rows.Count > 0)
                {
                    lblIDSHOP.Text = dtterminallist.Rows[0]["ID"].ToString();
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
                    ComboTerminal_Type.Text = dtterminallist.Rows[0]["Terminal_Type"].ToString();
                    lbltrmsg.Visible = false;
                }
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


        public void BindStore()
        {
            string sql3 = "select * from storeconfig";
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            int TID = Convert.ToInt32(txtTenentid.Text);

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
            else
            {
                string sqlstoreconfig = "Select * from storeconfig";
                DataTable dtstoreconfig = DataAccess.GetDataTable(sqlstoreconfig);

                if (dtstoreconfig.Rows.Count > 0)
                {
                    int ID = Convert.ToInt32(dtstoreconfig.Rows[0]["id"]);
                    lblid.Text = (ID + 1).ToString();
                }
                else
                {
                    lblid.Text = "1";
                }
            }
        }

        public void Display_store_Live(int Tenentid)
        {
            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == true)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = "select *  from Win_storeconfig where TenentID=" + Tenentid + " ";
                DataTable dt = DataLive.GetLiveDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    lblid.Text = dt.Rows[0]["id"].ToString();
                    txtCompanyName.Text = dt.Rows[0]["companyname"] != DBNull.Value && dt.Rows[0]["companyname"] != "" ? dt.Rows[0]["companyname"].ToString() : "";
                    txtCompanyAddress.Text = dt.Rows[0]["companyaddress"] != DBNull.Value && dt.Rows[0]["companyaddress"] != "" ? dt.Rows[0]["companyaddress"].ToString() : "";
                    txtPhone.Text = dt.Rows[0]["companyphone"] != DBNull.Value && dt.Rows[0]["companyphone"] != "" ? dt.Rows[0]["companyphone"].ToString() : "";
                    txtVatRegiNo.Text = dt.Rows[0]["vatno"] != DBNull.Value && dt.Rows[0]["vatno"] != "" ? dt.Rows[0]["vatno"].ToString() : "";
                    txtWebSite.Text = dt.Rows[0]["web"] != DBNull.Value && dt.Rows[0]["web"] != "" ? dt.Rows[0]["web"].ToString() : "";
                    txtVATRate.Text = dt.Rows[0]["vatrate"] != DBNull.Value && dt.Rows[0]["vatrate"] != "" ? dt.Rows[0]["vatrate"].ToString() : "";
                    txtDiscountRate.Text = dt.Rows[0]["disrate"] != DBNull.Value && dt.Rows[0]["disrate"] != "" ? dt.Rows[0]["disrate"].ToString() : "";
                    txtFootermsg.Text = dt.Rows[0]["footermsg"] != DBNull.Value && dt.Rows[0]["footermsg"] != "" ? dt.Rows[0]["footermsg"].ToString() : "";
                    txtStoreFacebook.Text = dt.Rows[0]["FaceBook"] != DBNull.Value && dt.Rows[0]["FaceBook"] != "" ? dt.Rows[0]["FaceBook"].ToString() : "";
                    txtstoreTwitter.Text = dt.Rows[0]["Twitter"] != DBNull.Value && dt.Rows[0]["Twitter"] != "" ? dt.Rows[0]["Twitter"].ToString() : "";
                    txtStoreInsta.Text = dt.Rows[0]["Insta"] != DBNull.Value && dt.Rows[0]["Insta"] != "" ? dt.Rows[0]["Insta"].ToString() : "";
                    txtDatabse.Text = dt.Rows[0]["DbPath"] != DBNull.Value && dt.Rows[0]["DbPath"] != "" ? dt.Rows[0]["DbPath"].ToString() : "";
                    txtImagePath.Text = dt.Rows[0]["ImgPath"] != DBNull.Value && dt.Rows[0]["ImgPath"] != "" ? dt.Rows[0]["ImgPath"].ToString() : "";
                    txtAddinal.Text = dt.Rows[0]["InvAddtionalLine"] != DBNull.Value && dt.Rows[0]["InvAddtionalLine"] != "" ? dt.Rows[0]["InvAddtionalLine"].ToString() : "";
                    txtLOGO.Text = dt.Rows[0]["Logo"] != DBNull.Value && dt.Rows[0]["Logo"] != "" ? dt.Rows[0]["Logo"].ToString() : "";
                }

            }

        }

        public bool insert_Store()
        {
            int Tenentid = Convert.ToInt32(txtTenentid.Text);
            int id = Convert.ToInt32(lblid.Text);

            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == true)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = "select *  from Win_storeconfig where TenentID=" + Tenentid + " ";
                DataTable dt = DataLive.GetLiveDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    string Ext = Path.GetExtension(txtLOGO.Text);
                    string imageName = "LOGO" + txtCompanyName.Text + Ext;
                    string sqlupdate = "update Win_storeconfig set companyname= '" + txtCompanyName.Text + "', companyaddress = '" + txtCompanyAddress.Text + "', " +
                          " companyphone = '" + txtPhone.Text + "', vatno = '" + txtVatRegiNo.Text + "' , web = '" + txtWebSite.Text + "' ,    " +
                           " vatrate = '" + txtVATRate.Text + "', disrate = '" + txtDiscountRate.Text + "' , footermsg = '" + txtFootermsg.Text + "' ,   " +
                           " FaceBook = '" + txtStoreFacebook.Text + "', Twitter = '" + txtstoreTwitter.Text + "' , Insta = '" + txtStoreInsta.Text + "' , InvAddtionalLine='" + txtAddinal.Text + "',  " +
                            " DbPath = '" + txtDatabse.Text + "', ImgPath = '" + txtImagePath.Text + "', Logo='" + imageName + "', " +
                          " UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null  where TenentID='" + Tenentid + "' and  id = '" + lblid.Text + "'";
                    int Flag = DataLive.ExecuteLiveSQL(sqlupdate);
                    if (Flag == 1)
                    {
                        return true;
                    }
                }
                else
                {
                    //SET IDENTITY_INSERT [dbo].[tblProduct] ON    SET IDENTITY_INSERT [dbo].[tblProduct] OFF

                    string Sqlinsert = "SET IDENTITY_INSERT [dbo].[Win_storeconfig] ON;  insert into Win_storeconfig (TenentID, id, companyname, companyaddress,companyphone,vatno,web,vatrate,disrate,footermsg,FaceBook,Twitter,Insta,DbPath,ImgPath,InvAddtionalLine,Logo,Uploadby ,UploadDate ,SynID) " +
                                    "  values( " + Tenent.TenentID + ", " + id + ",'" + txtCompanyName.Text + "', '" + txtCompanyAddress.Text + "', '" + txtPhone.Text + "', '" + txtVatRegiNo.Text + "','" + txtWebSite.Text + "', " +
                                    " '" + txtVATRate.Text + "', '" + txtDiscountRate.Text + "' , '" + txtFootermsg.Text + "',   " +
                                    " '" + txtStoreFacebook.Text + "', '" + txtstoreTwitter.Text + "' , '" + txtStoreInsta.Text + "',   " +
                                    " '" + txtDatabse.Text + "', '" + txtImagePath.Text + "','" + txtAddinal.Text + "','" + txtLOGO.Text + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1);SET IDENTITY_INSERT [dbo].[Win_storeconfig] OFF";

                    int Flag = DataLive.ExecuteLiveSQL(Sqlinsert);
                    if (Flag == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }

        }

        private void btnStoreSave_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "" || txtCompanyAddress.Text == "" || txtPhone.Text == "" || txtVATRate.Text == "" || txtDiscountRate.Text == "")
            {
                // MessageBox.Show("You are Not able to Update");
                MessageBox.Show("You are Not able to insert", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLOGO.Text == "")
            {
                MessageBox.Show("Logo Not Found", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(lblid.Text);

                    string Ext = Path.GetExtension(txtLOGO.Text);
                    string imageName = "LOGO" + txtCompanyName.Text + Ext;

                    bool Flag = insert_Store();

                    if (Flag == true)
                    {
                        //remove this
                        string sqlCmd = "Select * from  storeconfig  where id  = " + id + " ";
                        DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                        if (dt1.Rows.Count < 1)
                        {
                            //in one procedure
                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            string Sqlinsert = "insert into storeconfig (TenentID, id, companyname, companyaddress,companyphone,vatno,web,vatrate,disrate,footermsg,FaceBook,Twitter,Insta,DbPath,ImgPath,InvAddtionalLine,Logo,Uploadby ,UploadDate ,SynID) " +
                                    "  values( " + Tenent.TenentID + ", " + id + ",'" + txtCompanyName.Text + "', '" + txtCompanyAddress.Text + "', '" + txtPhone.Text + "', '" + txtVatRegiNo.Text + "','" + txtWebSite.Text + "', " +
                                    " '" + txtVATRate.Text + "', '" + txtDiscountRate.Text + "' , '" + txtFootermsg.Text + "',   " +
                                    " '" + txtStoreFacebook.Text + "', '" + txtstoreTwitter.Text + "' , '" + txtStoreInsta.Text + "',   " +
                                    " '" + txtDatabse.Text + "', '" + txtImagePath.Text + "','" + txtAddinal.Text + "','" + imageName + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            DataAccess.ExecuteSQL(Sqlinsert);

                            //string ActivityName = "insert Store Detail";
                            //string LogData = "insert Store Detail ";
                            //Login.InsertUserLog(ActivityName, LogData);
                            //Datasyncpso.insert_Live_sync_Query(Sqlinsert);
                        }
                        else
                        {
                            string sql = "update storeconfig set companyname= '" + txtCompanyName.Text + "', companyaddress = '" + txtCompanyAddress.Text + "', " +
                           " companyphone = '" + txtPhone.Text + "', vatno = '" + txtVatRegiNo.Text + "' , web = '" + txtWebSite.Text + "' ,    " +
                            " vatrate = '" + txtVATRate.Text + "', disrate = '" + txtDiscountRate.Text + "' , footermsg = '" + txtFootermsg.Text + "' ,   " +
                            " FaceBook = '" + txtStoreFacebook.Text + "', Twitter = '" + txtstoreTwitter.Text + "' , Insta = '" + txtStoreInsta.Text + "' , InvAddtionalLine='" + txtAddinal.Text + "',  " +
                             " DbPath = '" + txtDatabse.Text + "', ImgPath = '" + txtImagePath.Text + "', Logo='" + imageName + "', " +
                           " UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null  where TenentID='" + Tenent.TenentID + "' and  id = '" + lblid.Text + "'";
                            DataAccess.ExecuteSQL(sql);

                            //string ActivityName = "Update Store Detail";
                            //string LogData = "Update Store Detail ";
                            //Login.InsertUserLog(ActivityName, LogData);
                        }

                        string imgpath1 = Application.StartupPath + @"\LOGO\";
                        string imageFile = imgpath1 + @"\" + imageName;
                        // if (!File.Exists(imageFile))
                        // {
                        //     System.IO.File.Delete(imageFile);
                        //     if (!System.IO.Directory.Exists(imgpath1))
                        //         System.IO.Directory.CreateDirectory(Application.StartupPath + @"\LOGO\");
                        //     string filename = imgpath1 + @"\" + openFileDialog1.SafeFileName;
                        //     picItemimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        //     System.IO.File.Move(imgpath1 + @"\" + openFileDialog1.SafeFileName, imgpath1 + @"\" + imageName);
                        //
                        // }



                        lblmsg.Text = "Configuation has been Saved";
                        lblmsg.Visible = true;
                        BindStore();

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
                        this.tabTerminal.Parent = this.tabControl1; //show
                        tabControl1.SelectedTab = tabTerminal;
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Sorry\r\n You have to Check the Data" + exp.Message);
                }
                Fill_Default();
            }
        }

        public void Fill_Default()
        {
            if (txtTerminaladdress.Text == null || txtTerminaladdress.Text == "") { txtTerminaladdress.Text = txtCompanyAddress.Text; }
            if (txtTerminalPhone.Text == null || txtTerminalPhone.Text == "") { txtTerminalPhone.Text = txtPhone.Text; }
            if (txtTrFootermsg.Text == null || txtTrFootermsg.Text == "") { txtTrFootermsg.Text = txtFootermsg.Text; }
            if (txtTrFootermsg.Text == null || txtTrFootermsg.Text == "") { txtTrFootermsg.Text = txtFootermsg.Text; }
            if (txtTrVATregino.Text == null || txtTrVATregino.Text == "") { txtTrVATregino.Text = txtVatRegiNo.Text; }
            if (txtTrVAT.Text == null || txtTrVAT.Text == "") { txtTrVAT.Text = txtVATRate.Text; }
            if (txtTrDis.Text == null || txtTrDis.Text == "") { txtTrDis.Text = txtDiscountRate.Text; }
            if (txtTrweb.Text == null || txtTrweb.Text == "") { txtTrweb.Text = txtWebSite.Text; }
            if (txtTerminalAddninal.Text == null || txtTerminalAddninal.Text == "") { txtTerminalAddninal.Text = txtAddinal.Text; }
            if (txtFacebookID.Text == null || txtFacebookID.Text == "") { txtFacebookID.Text = txtStoreFacebook.Text; }
            if (txtTwitter.Text == null || txtTwitter.Text == "") { txtTwitter.Text = txtstoreTwitter.Text; }
            if (txtInsta.Text == null || txtInsta.Text == "") { txtInsta.Text = txtStoreInsta.Text; }
            if (txtterminalDatabase.Text == null || txtterminalDatabase.Text == "") { txtterminalDatabase.Text = txtDatabse.Text; }
            if (txttreminalImage.Text == null || txttreminalImage.Text == "") { txttreminalImage.Text = txtImagePath.Text; }

        }
        private void btnTerminalDatabase_Click(object sender, EventArgs e)
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
                txtterminalDatabase.Text = folderDlg.FileName;
                string DB = txtterminalDatabase.Text.Trim();
                DB = DB.TrimStart('\\');
                txtterminalDatabase.Text = DB;
            }
        }

        private void txtTrDis_KeyPress(object sender, KeyPressEventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txttreminalImage.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

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

        public void Bindshopbranch()
        {
            string sql5 = "select   BranchName , Shopid from tbl_terminallocation";
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            cmboShopid.DataSource = dt5;
            cmboShopid.DisplayMember = "BranchName";
            cmboShopid.ValueMember = "Shopid";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lblWait.Text = " ";
                lblWait.Refresh();
                if (txtSearchTenent.Text == "")
                {
                    lblWait.Visible = true;
                    lblWait.Text = " Please Enter Tenent ";
                    lblWait.Refresh();
                    return;
                }

                lblWait.Visible = true;
                lblWait.Text = "Connecting And Searching Online Data Please Wait ";
                lblWait.Refresh();

                lblmsg.Visible = true;
                lblmsg.Refresh();

                string MAc_add = Login.GetMACAddress();
                string Mac_all = getAllMac();

                string[] Str = txtSearchTenent.Text.ToString().Split(',');

                int lenth = Str.Length;

                int TenentID = 0;
                string EnterMace = null;
                if (lenth > 1)
                {
                    TenentID = Convert.ToInt32(Str[0]);
                    EnterMace = Str[1].ToString();
                }
                else
                {
                    TenentID = Convert.ToInt32(Str[0]);
                }

                bool CON_Ceck = Login.CheckDBConnection();
                if (CON_Ceck == true)
                {
                    string Username = txtsearchUser.Text;
                    string password = txtSearchPassword.Text;

                    string sql = "select *  from VW_CheckLogin_Win where TenentID=" + TenentID + " and Username='" + Username + "' and password='" + password + "' and Mac_Addr like '%" + MAc_add + "%' ";
                    DataTable dt = DataLive.GetLiveDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        lblmsg.Text = "Searching Registation Data";
                        lblmsg.Refresh();

                        string sqlMac = "Select * FROM  Win_mycompanysetup_winapp where TenentID=" + TenentID + " and Mac_Addr like '%" + MAc_add + "%' ";
                        DataTable dtMAC = DataLive.GetLiveDataTable(sqlMac);
                        if (dtMAC.Rows.Count > 0)
                        {
                            txtTenentid.Text = dtMAC.Rows[0]["TenentID"].ToString();
                            txtShopID.Text = dtMAC.Rows[0]["Shopid"].ToString();
                            txtCopName_Eng.Text = dtMAC.Rows[0]["COMPNAME1"].ToString();
                            txtCopName_Arabic.Text = dtMAC.Rows[0]["COMPNAME2"].ToString();
                            txtCopname_Franch.Text = dtMAC.Rows[0]["COMPNAME3"].ToString();
                            lblCountryid.Text = dtMAC.Rows[0]["COUNTRYID"].ToString();
                            int COUNTRYID = Convert.ToInt32(lblCountryid.Text);
                            SetCuntry(COUNTRYID);
                            comDefaultLanguage.Text = dtMAC.Rows[0]["DefaultLanguage"].ToString();

                            lblmsg.Text = "Searching store Data";
                            lblmsg.Refresh();

                            Display_store_Live(TenentID);

                            lblmsg.Text = "Searching store Data";
                            lblmsg.Refresh();

                            dispay_Terminal_Live(TenentID);

                            lblmsg.Text = "Searching store Data";
                            lblmsg.Refresh();

                            display_user(TenentID);

                            lblmsg.Text = "Searching store Data";
                            lblmsg.Refresh();

                            syncData.Visible = true;

                        }
                    }
                    else
                    {
                        string sql1 = "select *  from VW_CheckLogin_Win where TenentID=" + TenentID + " and Username='" + Username + "' and password='" + password + "' ";
                        DataTable dt1 = DataLive.GetLiveDataTable(sql1);
                        if (dt1.Rows.Count > 0)
                        {
                            string sql2 = "select *  from VW_CheckLogin_Win where TenentID=" + TenentID + " and Username='" + Username + "' and password='" + password + "' and Mac_Addr = '" + Username + "' ";
                            DataTable dt2 = DataLive.GetLiveDataTable(sql2);

                            int C = 0;
                            if (dt2 != null)
                            {
                                C = dt2.Rows.Count;
                            }

                            if (C > 0)
                            {
                                string sqlupdate = " Update Win_mycompanysetup_winapp set" +
                                             " Mac_Addr='" + Mac_all + "' where TenentID=" + TenentID + " and Mac_Addr = '" + Username + "' ";

                                DataLive.ExecuteLiveSQL(sqlupdate);

                                string sqlMac = "Select * FROM  Win_mycompanysetup_winapp where TenentID=" + TenentID + " and Mac_Addr like '%" + MAc_add + "%' ";
                                DataTable dtMAC = DataLive.GetLiveDataTable(sqlMac);
                                if (dtMAC.Rows.Count > 0)
                                {
                                    txtTenentid.Text = dtMAC.Rows[0]["TenentID"].ToString();
                                    txtShopID.Text = dtMAC.Rows[0]["Shopid"].ToString();
                                    txtCopName_Eng.Text = dtMAC.Rows[0]["COMPNAME1"].ToString();
                                    txtCopName_Arabic.Text = dtMAC.Rows[0]["COMPNAME2"].ToString();
                                    txtCopname_Franch.Text = dtMAC.Rows[0]["COMPNAME3"].ToString();
                                    lblCountryid.Text = dtMAC.Rows[0]["COUNTRYID"].ToString();
                                    int COUNTRYID = Convert.ToInt32(lblCountryid.Text);
                                    SetCuntry(COUNTRYID);
                                    comDefaultLanguage.Text = dtMAC.Rows[0]["DefaultLanguage"].ToString();

                                    lblmsg.Text = "Searching store Data";
                                    lblmsg.Refresh();

                                    Display_store_Live(TenentID);

                                    lblmsg.Text = "Searching store Data";
                                    lblmsg.Refresh();

                                    dispay_Terminal_Live(TenentID);

                                    lblmsg.Text = "Searching store Data";
                                    lblmsg.Refresh();

                                    display_user(TenentID);

                                    lblmsg.Text = "Searching store Data";
                                    lblmsg.Refresh();

                                    syncData.Visible = true;
                                }
                            }
                            else
                            {
                                string MSG = "Your System not Registared in our Record ..";
                                MessageBox.Show(MSG);

                                lblmsg.Text = MSG;
                                lblmsg.Refresh();
                                return;
                            }
                        }
                    }
                }

                lblWait.Visible = false;

                lblmsg.Visible = false;
                lblmsg.Refresh();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        public void SetCuntry(int COUNTRYID)
        {
            string sqlCust = "select  * from tblCountry where id=" + COUNTRYID + " and  Active = 'Y'";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust.Rows.Count > 0)
            {
                comCountry.Text = dtCust.Rows[0]["CuntryName"].ToString();
            }
        }


        public void dispay_Terminal_Live(int TenentID)
        {

            string sqlMac = "Select * FROM  Win_tbl_terminalLocation where TenentID=" + TenentID + "  ";
            DataTable dtMAC = DataLive.GetLiveDataTable(sqlMac);
            if (dtMAC.Rows.Count > 0)
            {
                ComboTerminal_Type.Text = dtMAC.Rows[0]["Terminal_Type"] != DBNull.Value && dtMAC.Rows[0]["Terminal_Type"] != "" ? dtMAC.Rows[0]["Terminal_Type"].ToString() : "";
                txtCompanyName.Text = dtMAC.Rows[0]["CompanyName"] != DBNull.Value && dtMAC.Rows[0]["companyname"] != "" ? dtMAC.Rows[0]["companyname"].ToString() : "";
                txtterminalname.Text = dtMAC.Rows[0]["Branchname"] != DBNull.Value && dtMAC.Rows[0]["Branchname"] != "" ? dtMAC.Rows[0]["Branchname"].ToString() : "";
                txtTerminaladdress.Text = dtMAC.Rows[0]["Location"] != DBNull.Value && dtMAC.Rows[0]["Location"] != "" ? dtMAC.Rows[0]["Location"].ToString() : "";
                txtTerminalPhone.Text = dtMAC.Rows[0]["Phone"] != DBNull.Value && dtMAC.Rows[0]["Phone"] != "" ? dtMAC.Rows[0]["Phone"].ToString() : "";
                txtTremail.Text = dtMAC.Rows[0]["Email"] != DBNull.Value && dtMAC.Rows[0]["Email"] != "" ? dtMAC.Rows[0]["Email"].ToString() : "";
                txtTrweb.Text = dtMAC.Rows[0]["Web"] != DBNull.Value && dtMAC.Rows[0]["Web"] != "" ? dtMAC.Rows[0]["Web"].ToString() : "";
                txtTrVAT.Text = dtMAC.Rows[0]["VAT"] != DBNull.Value && dtMAC.Rows[0]["VAT"] != "" ? dtMAC.Rows[0]["VAT"].ToString() : "";
                txtTrDis.Text = dtMAC.Rows[0]["Dis"] != DBNull.Value && dtMAC.Rows[0]["Dis"] != "" ? dtMAC.Rows[0]["Dis"].ToString() : "";
                txtTrVATregino.Text = dtMAC.Rows[0]["VATRegiNo"] != DBNull.Value && dtMAC.Rows[0]["VATRegiNo"] != "" ? dtMAC.Rows[0]["VATRegiNo"].ToString() : "";
                txtTrFootermsg.Text = dtMAC.Rows[0]["Footermsg"] != DBNull.Value && dtMAC.Rows[0]["Footermsg"] != "" ? dtMAC.Rows[0]["Footermsg"].ToString() : "";
                txtFacebookID.Text = dtMAC.Rows[0]["FaceBook"] != DBNull.Value && dtMAC.Rows[0]["FaceBook"] != "" ? dtMAC.Rows[0]["FaceBook"].ToString() : "";
                txtTwitter.Text = dtMAC.Rows[0]["Twitter"] != DBNull.Value && dtMAC.Rows[0]["Twitter"] != "" ? dtMAC.Rows[0]["Twitter"].ToString() : "";
                txtInsta.Text = dtMAC.Rows[0]["Insta"] != DBNull.Value && dtMAC.Rows[0]["Insta"] != "" ? dtMAC.Rows[0]["Insta"].ToString() : "";
                txtTerminalAddninal.Text = dtMAC.Rows[0]["InvAddtionalLine"] != DBNull.Value && dtMAC.Rows[0]["InvAddtionalLine"] != "" ? dtMAC.Rows[0]["InvAddtionalLine"].ToString() : "";
                txtterminalDatabase.Text = dtMAC.Rows[0]["DbPath"] != DBNull.Value && dtMAC.Rows[0]["DbPath"] != "" ? dtMAC.Rows[0]["DbPath"].ToString() : "";
                txttreminalImage.Text = dtMAC.Rows[0]["ImgPath"] != DBNull.Value && dtMAC.Rows[0]["ImgPath"] != "" ? dtMAC.Rows[0]["ImgPath"].ToString() : "";
                txtSyncAfter.Text = dtMAC.Rows[0]["syncAfter"] != DBNull.Value ? dtMAC.Rows[0]["syncAfter"].ToString() : "10";
            }

        }

        public bool Insert_Terminal(int TenentID, string Shopid, int ID)
        {
            int syncAfter = txtSyncAfter.Text != "" ? Convert.ToInt32(txtSyncAfter.Text) : 10;

            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == true)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                // remove this one 
                string sql = "select *  from Win_tbl_terminalLocation where TenentID=" + TenentID + " and Shopid = '" + Shopid + "' ";
                DataTable dt = DataLive.GetLiveDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    string Ext = Path.GetExtension(txtLOGO.Text);
                    //Insert_tbl_terminallocation procdure
                    string sqlUpdate = "update Win_tbl_terminalLocation set Terminal_Type = '" + ComboTerminal_Type.Text + "', Branchname = N'" + txtterminalname.Text + "', Location = N'" + txtTerminaladdress.Text + "', " +
                        " Email = '" + txtTremail.Text + "' , Phone = '" + txtTerminalPhone.Text + "', VAT = '" + txtTrVAT.Text + "' , Web = '" + txtTrweb.Text + "' ,    " +
                        " Dis = '" + txtTrDis.Text + "', VATRegiNo = '" + txtTrVATregino.Text + "' , Footermsg = N'" + txtTrFootermsg.Text + "' ,   " +
                        " CompanyName = N'" + txtCompanyName.Text + "' , FaceBook = '" + txtFacebookID.Text + "', Twitter = '" + txtTwitter.Text + "', Insta = '" + txtInsta.Text + "' ,InvAddtionalLine= N'" + txtTerminalAddninal.Text + "' ,   " +
                        " DbPath = '" + txtterminalDatabase.Text + "', ImgPath = '" + txttreminalImage.Text + "', syncAfter = " + syncAfter + " , " +
                        " UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null  where TenentID='" + TenentID + "' and Shopid = '" + Shopid + "' ";
                    int Flag = DataLive.ExecuteLiveSQL(sqlUpdate);
                    if (Flag == 1)
                    {
                        return true;
                    }
                }
                else
                {
                    string sqlinsert = " insert into Win_tbl_terminalLocation " +
                                           "(TenentID, ID, Shopid,Terminal_Type, CompanyName, Branchname , Location ,Phone , Email ,  Web, VAT , Dis , VATRegiNo , Footermsg,FaceBook,Twitter,Insta,InvAddtionalLine,DbPath,ImgPath,syncAfter,Uploadby ,UploadDate ,SynID) " +
                                           " values (" + TenentID + ", " + ID + ",'" + Shopid + "' , '" + ComboTerminal_Type.Text + "' , N'" + txtCompanyName.Text + "' , N'" + txtterminalname.Text + "' , " +
                                            " N'" + txtTerminaladdress.Text + "' , '" + txtTerminalPhone.Text + "' , '" + txtTremail.Text + "' ," +
                                            " '" + txtTrweb.Text + "',  '" + txtTrVAT.Text + "', " +
                                            " '" + txtTrDis.Text + "' , '" + txtTrVATregino.Text + "',  N'" + txtTrFootermsg.Text + "' ," +
                                            " '" + txtFacebookID.Text + "','" + txtTwitter.Text + "','" + txtInsta.Text + "', N'" + txtTerminalAddninal.Text + "'," +
                                            " '" + txtterminalDatabase.Text + "',  '" + txttreminalImage.Text + "'," + syncAfter + ",'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                    int Flag = DataLive.ExecuteLiveSQL(sqlinsert);
                    if (Flag == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }

        }

        private void btnTerminalSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtterminalname.Text == "" || txtTerminaladdress.Text == "" || txtTerminalPhone.Text == "" || txtTrVAT.Text == "" || txtTrDis.Text == "")
                {
                    MessageBox.Show("Please fill Terminal info", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int TenentID = Convert.ToInt32(txtTenentid.Text);
                    //Add new Terminal Info
                    if (lblShopID.Text == "-")
                    {
                        //procdure Get_TerminalAllocationID
                        int ID = DataAccess.getterminallocationMYid(Tenent.TenentID);

                        string Shopid = txtShopID.Text; //txtterminalname.Text.Substring(0, 2) + txtTrVATregino.Text.Substring(0, 2);
                        bool Flag = Insert_Terminal(TenentID, Shopid, ID);

                        if (Flag == true)
                        {
                            int syncAfter = txtSyncAfter.Text != "" ? Convert.ToInt32(txtSyncAfter.Text) : 10;

                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//yyyy-MM-dd HH:mm:ss.fff
                            string sqlinsert = " insert into tbl_terminallocation " +
                                               "(TenentID,ID,Shopid,Terminal_Type, CompanyName, Branchname , Location ,Phone , Email ,  Web, VAT , Dis , VATRegiNo , Footermsg,FaceBook,Twitter,Insta,InvAddtionalLine,DbPath,ImgPath,syncAfter,Uploadby ,UploadDate ,SynID) " +
                                               " values (" + Tenent.TenentID + ", " + ID + " ,'" + Shopid + "' , '" + ComboTerminal_Type.Text + "' , '" + txtCompanyName.Text + "' , '" + txtterminalname.Text + "' , " +
                                                " '" + txtTerminaladdress.Text + "' , '" + txtTerminalPhone.Text + "' , '" + txtTremail.Text + "' ," +
                                                " '" + txtTrweb.Text + "',  '" + txtTrVAT.Text + "', " +
                                                " '" + txtTrDis.Text + "' , '" + txtTrVATregino.Text + "',  '" + txtTrFootermsg.Text + "' ," +
                                                " '" + txtFacebookID.Text + "','" + txtTwitter.Text + "','" + txtInsta.Text + "','" + txtTerminalAddninal.Text + "'," +
                                                " '" + txtterminalDatabase.Text + "',  '" + txttreminalImage.Text + "'," + syncAfter + ",'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            DataAccess.ExecuteSQL(sqlinsert);
                            //Datasyncpso.insert_Live_sync_Query(sqlinsert);

                            //string ActivityName = "insert Terminal";
                            //string LogData = "insert Terminal with Branchname = " + txtterminalname.Text + " ";
                            //Login.InsertUserLog(ActivityName, LogData);

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

                            BindTerminal();
                            Bindshopbranch();

                            this.tabUserRegistration.Parent = this.tabControl1; //show
                            tabControl1.SelectedTab = tabUserRegistration;
                        }
                    }
                    else // Update selected 
                    {
                        string Shopid = lblShopID.Text;
                        int ID = Convert.ToInt32(lblIDSHOP.Text);
                        bool Flag = Insert_Terminal(TenentID, Shopid, ID);
                        if (Flag == true)
                        {
                            string sql = "update tbl_terminallocation set Terminal_Type = '" + ComboTerminal_Type.Text + "', Branchname = '" + txtterminalname.Text + "', Location = '" + txtTerminaladdress.Text + "', " +
                            " Email = '" + txtTremail.Text + "' , Phone = '" + txtTerminalPhone.Text + "', VAT = '" + txtTrVAT.Text + "' , Web = '" + txtTrweb.Text + "' ,    " +
                            " Dis = '" + txtTrDis.Text + "', VATRegiNo = '" + txtTrVATregino.Text + "' , Footermsg = '" + txtTrFootermsg.Text + "' ,   " +
                            " CompanyName = '" + txtCompanyName.Text + "' , FaceBook = '" + txtFacebookID.Text + "', Twitter = '" + txtTwitter.Text + "', Insta = '" + txtInsta.Text + "' ,InvAddtionalLine= '" + txtTerminalAddninal.Text + "' ,   " +
                            " DbPath = '" + txtterminalDatabase.Text + "', ImgPath = '" + txttreminalImage.Text + "', syncAfter = " + Convert.ToInt32(txtSyncAfter.Text) + " , " +
                            " UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null  where Shopid = '" + lblShopID.Text + "' ";
                            DataAccess.ExecuteSQL(sql);

                            //string ActivityName = "update Terminal";
                            //string LogData = "update Terminal with Shopid = " + lblShopID.Text + " ";
                            //Login.InsertUserLog(ActivityName, LogData);

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

                            BindTerminal();
                            Bindshopbranch();

                            this.tabUserRegistration.Parent = this.tabControl1; //show
                            tabControl1.SelectedTab = tabUserRegistration;

                        }
                    }

                }

            }
            catch
            {
            }
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

        public void display_user(int TenentID)
        {
            groupBox2.Enabled = true;
            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == true)
            {
                string sql = "select *  from Win_usermgt where TenentID=" + TenentID + " ";
                DataTable dt = DataLive.GetLiveDataTable(sql);
                if (dt.Rows.Count > 0)
                {

                    txtUserFullName.Text = dt.Rows[0]["Name"] != DBNull.Value ? dt.Rows[0]["Name"].ToString() : "";
                    txtLastName.Text = dt.Rows[0]["Father_name"] != DBNull.Value ? dt.Rows[0]["Father_name"].ToString() : "";
                    txtAddress.Text = dt.Rows[0]["Address"] != DBNull.Value ? dt.Rows[0]["Address"].ToString() : "";
                    txtEmailaddress.Text = dt.Rows[0]["Email"] != DBNull.Value ? dt.Rows[0]["Email"].ToString() : "";
                    txtContact.Text = dt.Rows[0]["Contact"] != DBNull.Value ? dt.Rows[0]["Contact"].ToString() : "";
                    if (dt.Rows[0]["DOB"] != DBNull.Value)
                    {
                        DateTime BOD = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                        dtDOB.Value = BOD;
                    }

                    txtUsername.Text = dt.Rows[0]["Username"] != DBNull.Value ? dt.Rows[0]["Username"].ToString() : "";
                    textUserPass.Text = dt.Rows[0]["password"] != DBNull.Value ? dt.Rows[0]["password"].ToString() : "";

                    if (dt.Rows[0]["usertype"] != DBNull.Value)
                    {
                        int flag = Convert.ToInt32(dt.Rows[0]["usertype"]);

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
                    }
                    else
                    {
                        rdbtnblock.Checked = true;
                    }

                    cmboShopid.Text = dt.Rows[0]["Shopid"] != DBNull.Value ? dt.Rows[0]["Shopid"].ToString() : "";

                    groupBox2.Enabled = false;

                }
            }

        }

        public void insert_User(int TenentID, int flag, string posi, string imageName, int ID)
        {
            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == true)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = "select *  from Win_usermgt where TenentID=" + TenentID + " and Username='" + txtUsername.Text + "' ";
                DataTable dt = DataLive.GetLiveDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    string dob = dtDOB.Value.ToString("MM/dd/yyyy");
                    string sqlupdate = "UPDATE Win_usermgt set  Name = '" + txtUserFullName.Text + "', Father_name = '" + txtLastName.Text + "', " +
                      " Address = '" + txtAddress.Text + "', Email = '" + txtEmailaddress.Text + "', Contact = '" + txtContact.Text + "', " +
                      " DOB = '" + dob + "' , Username= '" + txtUsername.Text + "', password = '" + textUserPass.Text + "',imagename = '" + imageName + "' ,    " +
                      " usertype    = '" + flag + "', position = '" + posi + "', Shopid = '" + cmboShopid.SelectedValue + "',UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null " +
                      " where TenentID=" + TenentID + " and (id = '" + lblUid.Text + "' )";
                    DataLive.ExecuteLiveSQL(sqlupdate);
                }
                else
                {
                    string dob = dtDOB.Value.ToString("MM/dd/yyyy");
                    string sql1 = "insert into Win_usermgt (TenentID,id, Name, Father_name, Address, Email , Contact, DOB , Username , password , usertype , position , imagename, Shopid,Uploadby ,UploadDate ,SynID) " +
                                     "  values(" + Tenent.TenentID + "," + ID + ",'" + txtUserFullName.Text + "', '" + txtLastName.Text + "', '" + txtAddress.Text + "', '" + txtEmailaddress.Text + "', " +
                                     " '" + txtContact.Text + "',  '" + dob + "', '" + txtUsername.Text + "', '" + textUserPass.Text + "', " +
                                     " '" + flag + "', '" + posi + "' , '" + imageName + "' , '" + cmboShopid.SelectedValue + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                    DataLive.ExecuteLiveSQL(sql1);
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserFullName.Text == "")
            {
                MessageBox.Show("Please Add User full Name", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserFullName.Focus();
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Please fill fathers name", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLastName.Focus();
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
            else if (cmboShopid.Text == "")
            {
                MessageBox.Show("Save Terminal First", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    int TenentID = Convert.ToInt32(txtTenentid.Text);

                    //Get_UserMgtID procdure
                    int ID = DataAccess.getusermgtMYid(TenentID);

                    //New Insert / New Entry
                    if (lblUid.Text == "-")
                    {
                        bool allow = User_mgt.User_regi.Allowuser(flag);
                        if (allow == false)
                        {
                            int AllowuserCkeck = User_mgt.User_regi.CheckUserPermition(TenentID);

                            int AllowuserFinal = User_mgt.User_regi.Finalallow(flag, AllowuserCkeck);

                            MessageBox.Show("You allow Only " + AllowuserFinal + " " + posi + "  ", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //check_User procdure
                        string sql3 = "select * from usermgt where Username= '" + txtUsername.Text + "' and password= '" + textUserPass.Text + "' ";
                        DataTable dt1 = DataAccess.GetDataTable(sql3);

                        if (dt1.Rows.Count > 0)
                        {
                            MessageBox.Show("User Already Exist", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                        //string selno = txtUid.Text;
                        string imageName = txtUid.Text + lblFileExtension.Text; //System.IO.Path.GetFileName(openFileDialog1.FileName);
                        //live
                        insert_User(TenentID, flag, posi, imageName, ID);

                        string UploadDate = DateTime.Now.ToString("dd-MM-yyyy");
                        string sql1 = "insert into usermgt (TenentID,id, Name, Father_name, Address, Email , Contact, DOB , Username , password , usertype , position , imagename, Shopid,Uploadby ,UploadDate ,SynID) " +
                                      "  values(" + Tenent.TenentID + "," + ID + ",'" + txtUserFullName.Text + "', '" + txtLastName.Text + "', '" + txtAddress.Text + "', '" + txtEmailaddress.Text + "', " +
                                      " '" + txtContact.Text + "',  '" + dtDOB.Text + "', '" + txtUsername.Text + "', '" + textUserPass.Text + "', " +
                                      " '" + flag + "', '" + posi + "' , '" + imageName + "' , '" + cmboShopid.SelectedValue + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        DataAccess.ExecuteSQL(sql1);

                        //string ActivityName = "Add User";
                        //string LogData = "Add User with username = : " + txtUsername.Text.Trim() + " ";
                        //Login.InsertUserLog(ActivityName, LogData);

                        //Datasyncpso.insert_Live_sync_Query(sql1);

                        /////////////////////picture upload  /////////////////
                        // string path = Application.StartupPath + @"\IMAGE\";
                        // System.IO.File.Delete(path + @"\" + imageName);
                        // if (!System.IO.Directory.Exists(path))
                        //     System.IO.Directory.CreateDirectory(Application.StartupPath + @"\IMAGE\");
                        // string filename = path + @"\" + openFileDialog1.SafeFileName;
                        // picUserimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        // System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                        MessageBox.Show("User hase been Created Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblEmailerrormsg.Visible = false;

                        OnlineRegACM();
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

                        insert_User(TenentID, flag, posi, imageName, ID);

                        string sql = "UPDATE usermgt set  Name = '" + txtUserFullName.Text + "', Father_name = '" + txtLastName.Text + "', " +
                        " Address = '" + txtAddress.Text + "', Email = '" + txtEmailaddress.Text + "', Contact = '" + txtContact.Text + "', " +
                        " DOB = '" + dtDOB.Value.ToString("MM/dd/yyyy") + "' , Username= '" + txtUsername.Text + "', password = '" + textUserPass.Text + "',imagename = '" + imageName + "' ,    " +
                        " usertype    = '" + flag + "', position = '" + posi + "', Shopid = '" + cmboShopid.SelectedValue + "',UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null where TenentID='" + TenentID + "' and (id = '" + lblUid.Text + "' )";
                        DataAccess.ExecuteSQL(sql);

                        //string ActivityName = "update User";
                        //string LogData = "update User with username = : " + txtUsername.Text.Trim() + " ";
                        //Login.InsertUserLog(ActivityName, LogData);

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

                    Application.Restart();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Sorry\r\n" + exp.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
            Application.Restart();

        }
        public void OnlineRegACM()
        {
            try
            {
                string tenent = txtTenentid.Text.ToString();
                string username = txtUsername.Text.ToString();
                string Password = textUserPass.Text.ToString();
                string CompnayName = txtCopName_Eng.Text.ToString();
                string CompnayNamearabic = txtCopName_Arabic.Text.ToString();
                string CompnayNamefranch = txtCopname_Franch.Text.ToString();
                string defaultLanguage = comCountry.Text.ToString();
                string CompnayAddress = txtCompanyAddress.Text.ToString();
                string Compnayphone = txtPhone.Text.ToString();
                string Compnayweb = txtWebSite.Text.ToString();
                string userlastname = txtLastName.Text.ToString();
                string useraddress = txtAddress.Text.ToString();
                string userphone = txtContact.Text.ToString();
                string userBirth = dtDOB.Text.ToString();
                string userEmail = txtEmailaddress.Text.ToString();
                string userType = UserTypeselection();


                string enctenent = EncryptionClass.Encrypt(tenent);
                string encusername = EncryptionClass.Encrypt(username);
                string encPassword = EncryptionClass.Encrypt(Password);
                string encCompnayName = EncryptionClass.Encrypt(CompnayName);
                string encCompnayNamearabic = EncryptionClass.Encrypt(CompnayNamearabic);
                string encCompnayNamefranch = EncryptionClass.Encrypt(CompnayNamefranch);
                string encdefaultLanguage = EncryptionClass.Encrypt(defaultLanguage);
                string encCompnayAddress = EncryptionClass.Encrypt(CompnayAddress);
                string encCompnayphone = EncryptionClass.Encrypt(Compnayphone);
                string encCompnayweb = EncryptionClass.Encrypt(Compnayweb);
                string encuserlastname = EncryptionClass.Encrypt(userlastname);
                string encuseraddress = EncryptionClass.Encrypt(useraddress);
                string encuserphone = EncryptionClass.Encrypt(userphone);
                string encuserBirth = EncryptionClass.Encrypt(userBirth);
                string encuserEmail = EncryptionClass.Encrypt(userEmail);
                string encuserType = EncryptionClass.Encrypt(userType);


                erp53.com.WinRegistration reg = new erp53.com.WinRegistration();

                bool flag = reg.WinReg(enctenent, encusername, encPassword, encCompnayName, encCompnayNamearabic, encCompnayNamefranch, encdefaultLanguage, encCompnayAddress, encCompnayphone, encCompnayweb, encuserlastname, encuseraddress, encuserphone, encuserBirth, encuserEmail, encuserType);

                if (flag == true)
                {
                    MessageBox.Show("Registation Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Your Online Registration Fail Please Contect Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Registation Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show("Your Online Registration Fail Please Contect Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string UserTypeselection()
        {
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
            else if (rdbtnblock.Checked)
            {
                posi = "Block";
            }
            else
            {
                posi = "";
            }

            return posi;
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

        private void syncData_Click(object sender, EventArgs e)
        {
            if (txtsearchUser.Text == "")
            {
                lblWait.Visible = true;
                lblWait.Text = " Please Enter User Name ";
                lblWait.Refresh();
                txtsearchUser.Focus();
                return;
            }

            if (txtSearchPassword.Text == "")
            {
                lblWait.Visible = true;
                lblWait.Text = " Please Enter Password ";
                lblWait.Refresh();
                txtSearchPassword.Focus();
                return;
            }

            Login.set_Macaddr();


            string MacAddr = Login.GetMACAddress();
            int TID = Convert.ToInt32(txtTenentid.Text);
            lblmsg.Visible = true;

            string Shopid = txtShopID.Text.ToString();
            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == true)
            {
                string Username = txtsearchUser.Text;
                string password = txtSearchPassword.Text;

                string sql = "select *  from VW_CheckLogin_Win where TenentID=" + TID + " and Username='" + Username + "' and password='" + password + "' and Mac_Addr like '%" + MacAddr + "%' ";
                DataTable dt = DataLive.GetLiveDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    DateTime installDate = Convert.ToDateTime(dt.Rows[0]["installDate"]);
                    DateTime ExpireDate = Convert.ToDateTime(dt.Rows[0]["ExpireDate"]);

                    Login.setTenent(TID);
                    Login.set_Install_EXP_Date(installDate, ExpireDate);

                    Registation.UodateSuperuser();

                    msgCount.Visible = true;

                    var bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                    bw.RunWorkerAsync();
                }
            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblmsg.Visible = false;
            msgCount.Visible = false;
            Application.Restart();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            backSyncro.isRun = true;

            int TID = Convert.ToInt32(txtTenentid.Text);

            //string ActivityName = "Syncronization";
            //string LogData = "Syncronization Start ";
            //Login.InsertUserLog(ActivityName, LogData);

            mainatince1(TID);
            Data_Manage.Update_App.DBSyncro(TID);

            //mainatince();
        }


        private void txtLOGO_TextChanged(object sender, EventArgs e)
        {

        }

        public static bool MatchLiveUser(string Username)
        {
            string sql = "select *  from Win_usermgt where TenentID=" + Tenent.TenentID + " and Username='" + Username + "' ";
            DataTable dt = DataLive.GetLiveDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsername.Text != "")
            {
                bool LiveFalg = MatchLiveUser(txtUsername.Text);

                if (LiveFalg == true)
                {
                    txtUsername.Text = "";
                    lblUserMsg.Text = "User Name Already Exist ";
                    txtUsername.Focus();
                }
                else
                {
                    bool Falg = User_mgt.User_regi.MatchUser(txtUsername.Text);

                    if (Falg == true)
                    {
                        txtUsername.Text = "";
                        lblUserMsg.Text = "User Name Already Exist ";
                        txtUsername.Focus();
                    }
                    else
                    {
                        lblUserMsg.Text = "-";
                    }
                }
            }
        }

        private void linkbtnSlpit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["OnlineRegisered"] != null)
            {
                Application.OpenForms["OnlineRegisered"].Close();
            }
            OnlineRegisered GO = new OnlineRegisered();
            GO.Show();
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

        private void DateTimer_Tick(object sender, EventArgs e)
        {
            lblmsg.Text = backSyncro.Msg;
            lblmsg.Refresh();

            msgCount.Text = backSyncro.MsgCount;
            msgCount.Refresh();

        }

        private void txtSearchTenent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            textUserPass.UseSystemPasswordChar = true;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textUserPass.UseSystemPasswordChar = false;
        }

        private void txtCopName_Eng_Leave(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == null || txtCompanyName.Text == "")
                txtCompanyName.Text = txtCopName_Eng.Text;

            if (txtUserFullName.Text == null || txtUserFullName.Text == "")
                txtUserFullName.Text = txtCopName_Eng.Text;

            bool Internat = Login.InternetConnection();
            if (Internat == true)
            {
                txtCopName_Arabic.Text = DataAccess.Translate(txtCopName_Eng.Text, "ar");
                txtCopname_Franch.Text = DataAccess.Translate(txtCopName_Eng.Text, "fr");
            }
            else
            {
                txtCopName_Arabic.Text = txtCopName_Eng.Text;
                txtCopname_Franch.Text = txtCopName_Eng.Text;
            }
        }

        private void btnkey_Click(object sender, EventArgs e)
        {
            string stenent = reg_tenent.Text;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
            string EncTenentID = EncryptionClass.Encrypt(stenent);
            key.SetValue("kascii4", EncTenentID);
            MessageBox.Show("key updated");
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            if (txtsearchUser.Text.Trim() == string.Empty || txtSearchPassword.Text.Trim() == string.Empty) { MessageBox.Show("Enter UserName and Password"); return; }
            int TID = Convert.ToInt32(txtTenentid.Text);

            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == true)
            {
                string Username = txtsearchUser.Text;
                string password = txtSearchPassword.Text;

                string sql = "select installDate,ExpireDate  from VW_CheckLogin_Win where TenentID=" + TID + "";
                DataTable dt = DataLive.GetLiveDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    DateTime installDate = Convert.ToDateTime(dt.Rows[0]["installDate"]);
                    DateTime ExpireDate = Convert.ToDateTime(dt.Rows[0]["ExpireDate"]);

                    Login.setTenent(TID);
                    Login.set_Install_EXP_Date(installDate, ExpireDate);
                    MessageBox.Show("License Updated Successfully");
                }
                else
                {
                    MessageBox.Show("user not matched");
                }
            }
            else
            {
                MessageBox.Show("connetion not establish");
            }
        }
    }
}
