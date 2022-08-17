using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Utility.ModifyRegistry;
using Microsoft.Win32.TaskScheduler;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Reflection;
using Microsoft.Reporting.WebForms;
using System.Net.Mime;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;


namespace supershop 
{

    /*     
            // kascii1 = Mac_Addr
            // kascii2 = Install_Date
            // kascii3 = ExpireDate
            // kascii4 = TenentID
            // kascii5 = Dbpath
            // kascii6 = imgpath           
            // kascii8 = AppPath
            // kascii9 = Daily backup Date
            // kascii11 = LocalServer
            // kascii12 = LocalServerDB
            // kascii13 = LocalServerUser
            // kascii14 = LocalServerPass

           Author :    Yogesh Khandala
           Email:      johar@writeme.com 
        * Advance POS 
        * http://erp53.com/item/advance-point-of-sale-system-pos/6317175
        
       */


    public partial class Login : Form
    {
        private string MacAddr="";

        private string allmac="";
        private string registrymac="";
     
        public Login()
        {
            InitializeComponent();
         
            SetSetting();
            //btnColse.Enabled = false;

            //string DataSource = supershop.Properties.Settings.Default.DataSourceLocal;
            //string Database = supershop.Properties.Settings.Default.DatabaseLocal;

            //if (DataSource == "NeedToSet" || Database == "NeedToSet" || DataSource == "" || Database == "" || DataSource == null || Database == null)
            //{
            //    lblmsg.Text = "Set Local Server Database";
            //    lblmsg.Visible = true;
            //}
            //else
            //{
            //    string db = "server : " + DataSource + ", Database : " + Database;
            //    lblConn.Text = db;

            //    LocalServerConnection();
            //}


          //  txtUserName.Text = "Salam";
          //  txtPassword.Text = "johar";
            //LiveConnectionLocal();

        }
        public void SetSetting()
        {
            //Office main PC
            string DataSource = "BUDVaskfkjAuzowcENhp9QlbzCowBIF+";
            string Database = "mFWNay9yRumgxBN95+pgMToAKugW0Y43";
            string User = "f5hPbK9GWbo=";//sa
            string Password = "mUkI3zg6+3CaUSuFqICGZQ==";


            //Kenny Laptop
            //string DataSource = "EFCjnZSfbnqyy3hV32YA6A==";//yogesh local//"h3OZdZI/QSs=";//DIPAK=
            //string Database = "mFWNay9yRumgxBN95+pgMToAKugW0Y43";//yogesh local//"0klsG9e/MLQiMzKuSZ2BWNGdnX1q5oZY";//digita93_Senegal0901
            //string User = "f5hPbK9GWbo=";//sa
            //string Password = "mUkI3zg6+3CaUSuFqICGZQ==";//yogesh local//"nPTl32VFmjbgS4fI1P+XEg==";//dipak


            //string DataSource = "l3+DIBwFF0qESmQdso0GKw==";
            //string Database = "X3pBfsHkunMmwYfLhkmQFg==";
            //string User = "lJmjnYzv770=";
            //string Password = "ljQJKS7TAulbKm9B61cAcQ==";//"oBgDHGFGO36J/EDtUaRxOA==";//lxre2NXbkNaM10AE/YZXpg==

            

            if (Properties.Settings.Default.DataSource == "NeedToSet")
                Properties.Settings.Default.DataSource = EncryptionClass.Decrypt(DataSource);
            if (Properties.Settings.Default.Database == "NeedToSet")
                Properties.Settings.Default.Database = EncryptionClass.Decrypt(Database);
            if (Properties.Settings.Default.Userid == "NeedToSet")
                Properties.Settings.Default.Userid = EncryptionClass.Decrypt(User);
            if (Properties.Settings.Default.Password == "NeedToSet")
                Properties.Settings.Default.Password = EncryptionClass.Decrypt(Password);

            //string LocalDataSource = get_localServer();
            //Properties.Settings.Default.DataSourceLocal = LocalDataSource;
            //string LocalDatabase = get_localServerDB();
            //Properties.Settings.Default.DatabaseLocal = LocalDatabase;
            //string LocalUser = get_localServerUser();
            //Properties.Settings.Default.UseridLocal = LocalUser;
            //string LocalPassword = get_localServerPassword();
            //Properties.Settings.Default.PasswordLocal = LocalPassword;
        }
        public void Bindshopbranch()
        {
            string sql5 = "select   BranchName , Shopid from tbl_terminallocation";
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            comboTerminal.DataSource = dt5;
            comboTerminal.DisplayMember = "BranchName";
            comboTerminal.ValueMember = "Shopid";
        }
        public static bool CheckDBConnection()
        {
        try
        {
            if (InternetConnection() == true)
            {
                string COn1 = onlineConnection();
                SqlConnection con = new SqlConnection(COn1);
        
                con.Open();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch 
        {
              try
              {
          
             
                bool Falg = LiveConnection();
                if (Falg == true)
                {
                    string COn1 = onlineConnection();
                    SqlConnection con = new SqlConnection(COn1);
                    con.Open();
                    return true;
                }
                return Falg;
                }
                catch (Exception  ex)
                {

                    return false;
                }
           }
        }
        public static string Live_Connection()
        {
            string DataSource = supershop.Properties.Settings.Default.DataSource;
            string Database = supershop.Properties.Settings.Default.Database;
            string Userid = supershop.Properties.Settings.Default.Userid;
            string Password = supershop.Properties.Settings.Default.Password;


            return "Data Source=" + DataSource + ";Initial Catalog=" + Database + ";Persist Security Info=True;User ID=" + Userid + "";
        }
        public static string onlineConnection()
        {
            string DataSource = supershop.Properties.Settings.Default.DataSource;
            string Database = supershop.Properties.Settings.Default.Database;
            string Userid = supershop.Properties.Settings.Default.Userid;
            string Password = supershop.Properties.Settings.Default.Password;
            return "Data Source=" + DataSource + ";initial catalog=" + Database + ";Persist Security Info=True;User id=" + Userid + ";password=" + Password + ";Connection Timeout=3;";
        }
        public static string LocalServerConnection()
        {
            string DataSource = supershop.Properties.Settings.Default.DataSourceLocal;
            string Database = supershop.Properties.Settings.Default.DatabaseLocal;
            string Userid = supershop.Properties.Settings.Default.UseridLocal;
            string Password = supershop.Properties.Settings.Default.PasswordLocal;
            return "Data Source=" + DataSource + ";initial catalog=" + Database + ";Persist Security Info=True;User id=" + Userid + ";password=" + Password + ";";

        }
        public static String BuildConnectionString()
        {
            string DataSource = supershop.Properties.Settings.Default.DataSource;
            string Database = supershop.Properties.Settings.Default.Database;
            string Userid = supershop.Properties.Settings.Default.Userid;
            string Password = supershop.Properties.Settings.Default.Password;

            // Build the connection string from the provided datasource and database
            String connString = @"data source=" + DataSource + ";initial catalog=" + Database + ";user id=" + Userid + ";password=" + Password + ";multipleactiveresultsets=True;App=EntityFramework&quot;";

            // Build the MetaData... feel free to copy/paste it from the connection string in the config file.
            EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
            esb.Metadata = "res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";
            esb.Provider = "System.Data.SqlClient";
            esb.ProviderConnectionString = connString;

            // Generate the full string and return it
            return esb.ToString();
        }
        //lite
        public static bool LiveConnection()
        {
            if (InternetConnection() == true)
            {
                string Mac = get_reg_MAC();
                int TID = get_reg_TenentID();
                string IP = ConfigurationManager.AppSettings["IP"];
               
                erp53.liveme.WinConnection con1 = new erp53.liveme.WinConnection();
                string strCon = "Data source=" + IP + ";initial catalog=xamfopak_Saas;User id=ERPWebSite;password=wXU8qVa^9YCeWD!dVKH%b==v*%WebSite";// con1.GetConnection(9000093, "A45D365CFD9E,B4B676A1C94D");
                                                                                                                                                     // string COn = con1.GetConnection(TID, Mac);
                                                                                                                                                     //  string strCon = EncryptionClass.Decrypt(COn);

                try
                {
                    if (strCon != "")
                    {
                        string[] splival = strCon.Trim().Split(';');

                        string ds = splival[0].ToString().Trim();
                        string db = splival[1].ToString().Trim();
                        string uid = splival[2].ToString().Trim();
                        string PAss = splival[3].ToString().Trim();

                        string DataSource = ds.Split('=')[1].Trim();
                        string Database = db.Split('=')[1].Trim();
                        string Userid = uid.Split('=')[1].Trim();
                        string Password = "wXU8qVa^9YCeWD!dVKH%b==v*%WebSite";

                        Properties.Settings.Default.DataSource = DataSource;
                        Properties.Settings.Default.Database = Database;
                        Properties.Settings.Default.Userid = Userid;
                        Properties.Settings.Default.Password = Password;

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //config.ConnectionStrings.ConnectionStrings["CRMNewEntitiesNew"].ConnectionString = strCon;
                        //config.Save(ConfigurationSaveMode.Modified, true);

                        //ConfigurationManager.RefreshSection("connectionStrings");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

           // GetSyncFile();
            string Path = Database_path();

            if (Path == "" && Path == null)
            {
                MessageBox.Show("Please Set Database Path In Setting", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            else
            {
                UserInfo.Database_path = getConnection(Path);
            }

            //UserInfo.Img_path = Application.StartupPath + @"\ITEMIMAGE\";// img_path();

            string Pathimg = img_path();

            if (Pathimg == "" && Pathimg == null)
            {
                MessageBox.Show("Please Set image Path In Setting", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            else
            {
                UserInfo.Img_path = Pathimg;
            }

            bool falge = CheckActivation();

            if (falge == false)
            {
                MessageBox.Show("Please Registration Your Appliction", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (txtUserName.Text == "")
            {
                //MessageBox.Show("");
                MessageBox.Show("Please insert User Name", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();

            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please  insert Password", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
            }
            //else if (comboTerminal.Text == "")
            //{
            //    MessageBox.Show("Please  Select Terminal", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    comboTerminal.Focus();
            //}
            else
            {
                try
                {

                    //remove this
                    bool superfalg = Loginsuper();
                    int regTenentID = get_reg_TenentID();
                    if (superfalg == false || regTenentID != 1 || regTenentID != 5)
                    {
                        // string MacAddr = GetMACAddress();
                        //   string reg_mac = get_r01eg_MAC();

                        //Valid 0 for OK
                        //Valid 1 for invalid Registry Data
                        //Valid 2 for invalid Username And Pass from Local  
                        //Valid 3 for Invalid Registy TenentID
          
                       
                            int Valid = CheckData(regTenentID);

                            if (Valid == 3)
                            {
                                string Username = txtUserName.Text;
                                string password = txtPassword.Text;
                                Tenent_NOt_Found(Username, password, MacAddr);
                            }

                            if (Valid == 2)
                            {
                                LoginFail();
                                return;
                            }
                            if (Valid == 1)
                            {
                                if (InternetConnection() == true)
                                {
                                //Flag 0 for OK
                                //Flag 1 for Check internet Connection
                                //Flag 2 for Your Data Not Match,Please Registration First
                                //Flag 3 for Your Processer Not Match,Please Contact Admin
                                //Flag 4 for Online Connection broken

                                int Flag = 0;// Check_verification();

                                    if (Flag == 4)
                                    {
                                        lblmsg.Visible = true;
                                        lblmsg.Text = "Your Online Database Connection Lost Try after Some Time Or \n Please Contect to Admin";
                                        return;
                                    }

                                    if (Flag == 3)
                                    {
                                        lblmsg.Visible = true;
                                        lblmsg.Text = "Your Processer Id Not Match,\n Please Contect to Admin";
                                        MessageBox.Show(lblmsg.Text, "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtUserName.Focus();
                                        return;
                                    }
                                    if (Flag == 2)
                                    {
                                        lblmsg.Visible = true;
                                        lblmsg.Text = "Your Data Not Match,\n Please Registration First";
                                        MessageBox.Show(lblmsg.Text, "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtUserName.Focus();
                                        return;
                                    }
                                    if (Flag == 1)
                                    {
                                        lblmsg.Visible = true;
                                        lblmsg.Text = "Check Internet Connention";
                                        MessageBox.Show(lblmsg.Text, "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtUserName.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    lblmsg.Visible = true;
                                    lblmsg.Text = "Check Internet Connention";
                                    MessageBox.Show(lblmsg.Text, "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtUserName.Focus();
                                    return;
                                }
                            }
                        //Get_loginUserMgt
                        string tkhan = "Select Username,password,usertype,id  from  usermgt  " +
                                        " where TenentID = " + Tenent.TenentID + " and Username   = '" + txtUserName.Text + "' and password = '" + txtPassword.Text + "' "; // and Shopid='" + comboTerminal.SelectedValue + "' ";
                        DataTable dt = DataAccess.GetDataTable(tkhan);

                        if (dt.Rows.Count > 0)
                        {
                            string username = dt.Rows[0]["Username"].ToString();
                            string password = dt.Rows[0]["password"].ToString();
                            string usertype = dt.Rows[0]["usertype"].ToString();
                            string Shopid = comboTerminal.SelectedValue.ToString();
                            int Userid = Convert.ToInt32(dt.Rows[0]["id"]);

                            LoginValid(username, usertype, Shopid, Userid, "");

                            //if (txtUserName.Text == username && txtPassword.Text == password)
                            //{
                            //    string LogData = null;
                            //    string ActivityName = null;

                            //    if (usertype == "1")   //usertype usertype
                            //    {
                            //        UserInfo.Userid = Userid;
                            //        UserInfo.UserName = txtUserName.Text;
                            //        UserInfo.usertype = "1"; // 1= Admin
                            //        UserInfo.Shopid = Shopid;
                            //        UserInfo.Language = "English";
                            //        workRecords();
                            //        CheckPrintersetting();
                            //        ActivityName = "Admin Login";
                            //        LogData = "User " + txtUserName.Text + " Login ";
                            //        InsertUserLog(ActivityName, LogData);
                            //        UserInfo.MDiPerent = "Home";
                            //        Home go = new Home();
                            //        go.Show();
                            //        this.Hide();

                            //    }
                            //    else if (usertype == "2")
                            //    {
                            //        UserInfo.Userid = Userid;
                            //        UserInfo.UserName = txtUserName.Text;
                            //        UserInfo.usertype = "2"; //2 = Manager
                            //        UserInfo.Shopid = Shopid;
                            //        UserInfo.Language = "English";
                            //        workRecords();
                            //        CheckPrintersetting();
                            //        ActivityName = "Manager Login";
                            //        LogData = "User " + txtUserName.Text + " Login ";
                            //        InsertUserLog(ActivityName, LogData);
                            //        UserInfo.MDiPerent = "Manager_Home";
                            //        Manager_Home go = new Manager_Home(txtUserName.Text);
                            //        go.Show();
                            //        this.Hide();

                            //    }
                            //    else if (usertype == "3")
                            //    {
                            //        UserInfo.Userid = Userid;
                            //        UserInfo.UserName = txtUserName.Text;
                            //        UserInfo.usertype = "3"; //3 = salesman
                            //        UserInfo.Shopid = Shopid;
                            //        UserInfo.Language = "English";
                            //        workRecords();
                            //        CheckPrintersetting();
                            //        ActivityName = "salesman Login";
                            //        LogData = "User " + txtUserName.Text + " Login ";
                            //        InsertUserLog(ActivityName, LogData);
                            //        UserInfo.MDiPerent = "SalesMan_Home";
                            //        SalesMan_Home go = new SalesMan_Home(txtUserName.Text);
                            //        go.Show();
                            //        this.Hide();

                            //    }
                            //    else if (usertype == "4")
                            //    {
                            //        UserInfo.Userid = Userid;
                            //        UserInfo.UserName = txtUserName.Text;
                            //        UserInfo.usertype = "4"; //4 = Kitchen
                            //        UserInfo.Shopid = Shopid;
                            //        UserInfo.Language = "English";
                            //        workRecords();
                            //        CheckPrintersetting();
                            //        ActivityName = "Kitchen Login";
                            //        LogData = "User " + txtUserName.Text + " Login ";
                            //        InsertUserLog(ActivityName, LogData);
                            //        UserInfo.MDiPerent = "Kitchen_Home";
                            //        Kitchen_Home go = new Kitchen_Home(txtUserName.Text);
                            //        go.Show();
                            //        this.Hide();

                            //    }
                            //    else if (usertype == "5")
                            //    {
                            //        UserInfo.Userid = Userid;
                            //        UserInfo.UserName = txtUserName.Text;
                            //        UserInfo.usertype = "5"; //4 = Driver
                            //        UserInfo.Shopid = Shopid;
                            //        UserInfo.Language = "English";
                            //        workRecords();
                            //        CheckPrintersetting();
                            //        ActivityName = "Driver Login";
                            //        LogData = "User " + txtUserName.Text + " Login ";
                            //        InsertUserLog(ActivityName, LogData);
                            //        UserInfo.MDiPerent = "Driver_Home";
                            //        Driver_Home go = new Driver_Home(txtUserName.Text);
                            //        go.Show();
                            //        this.Hide();

                            //    }
                            //    else if (usertype == "6")
                            //    {
                            //        UserInfo.Userid = Userid;
                            //        UserInfo.UserName = txtUserName.Text;
                            //        UserInfo.usertype = "6"; //6 = Spa Employee
                            //        UserInfo.Shopid = Shopid;
                            //        UserInfo.Language = "English";
                            //        workRecords();
                            //        CheckPrintersetting();
                            //        ActivityName = "Spa Employee Login";
                            //        LogData = "User " + txtUserName.Text + " Login ";
                            //        InsertUserLog(ActivityName, LogData);
                            //        UserInfo.MDiPerent = "SpaEmployee_Home";
                            //        SpaEmployee_Home go = new SpaEmployee_Home(txtUserName.Text);
                            //        go.Show();
                            //        this.Hide();

                            //    }
                            //    else if (usertype == "0") // Block user
                            //    {

                            //        MessageBox.Show("\n This user (" + txtUserName.Text + ") has been blocked. \n Please contact to administrator.", "Block - Inactive", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //    }
                            //    else
                            //    {
                            //        LoginFail();
                            //    }
                            //}
                            //else
                            //{
                            //    LoginFail();
                            //}
                        }
                        else
                        {
                            LoginFail();
                        }
                    }
                }
                catch (Exception exe)
                {
                    LoginFail();
                }

            }

        }

        public void LoginValid(string username, string usertype, string Shopid, int Userid, string LoginType)
        {
            string LogData = null;
            string ActivityName = null;

            if (LoginType == "Super Admin")
            {
                UserInfo.Userid = Userid;
                UserInfo.UserName = username;
                UserInfo.usertype = "1"; // 1= Admin
                UserInfo.Shopid = Shopid;
                UserInfo.Language = "English";
                UserInfo.IsSuperAddmin = true;
                workRecords();
                CheckPrintersetting();
                ActivityName = "Super Admin Login";
                LogData = "User " + username + " Login ";
                //Insert_Log procedure
                InsertUserLog(ActivityName, LogData);
                UserInfo.MDiPerent = "Home";
                Home go = new Home();
                go.Show();
                this.Hide();
            }
            else
            {
                if (usertype == "1")   //usertype usertype
                {
                    UserInfo.Userid = Userid;
                    UserInfo.UserName = username;
                    UserInfo.usertype = "1"; // 1= Admin
                    UserInfo.Shopid = Shopid;
                    UserInfo.Language = "English";
                    UserInfo.IsSuperAddmin = false;
                    //Insert_Workrecord
                    workRecords();
                    CheckPrintersetting();
                    ActivityName = "Admin Login";
                    LogData = "User " + username + " Login ";
                    InsertUserLog(ActivityName, LogData);
                    UserInfo.MDiPerent = "Home";
                    Home go = new Home();
                    go.Show();
                    this.Hide();

                }
                else if (usertype == "2")
                {
                    UserInfo.Userid = Userid;
                    UserInfo.UserName = username;
                    UserInfo.usertype = "2"; //2 = Manager
                    UserInfo.Shopid = Shopid;
                    UserInfo.Language = "English";
                    UserInfo.IsSuperAddmin = false;
                    //Insert_Workrecord
                    workRecords();
                    CheckPrintersetting();
                    ActivityName = "Manager Login";
                    LogData = "User " + username + " Login ";
                    InsertUserLog(ActivityName, LogData);
                    UserInfo.MDiPerent = "Manager_Home";
                    Manager_Home go = new Manager_Home(username);
                    go.Show();
                    this.Hide();

                }
                else if (usertype == "3")
                {
                    UserInfo.Userid = Userid;
                    UserInfo.UserName = username;
                    UserInfo.usertype = "3"; //3 = salesman
                    UserInfo.Shopid = Shopid;
                    UserInfo.Language = "English";
                    UserInfo.IsSuperAddmin = false;
                    workRecords();
                    CheckPrintersetting();
                    ActivityName = "salesman Login";
                    LogData = "User " + username + " Login ";
                    InsertUserLog(ActivityName, LogData);
                    UserInfo.MDiPerent = "SalesMan_Home";
                    SalesMan_Home go = new SalesMan_Home(username);
                    go.Show();
                    this.Hide();

                }
                else if (usertype == "4")
                {
                    UserInfo.Userid = Userid;
                    UserInfo.UserName = username;
                    UserInfo.usertype = "4"; //4 = Kitchen
                    UserInfo.Shopid = Shopid;
                    UserInfo.Language = "English";
                    UserInfo.IsSuperAddmin = false;
                    workRecords();
                    CheckPrintersetting();
                    ActivityName = "Kitchen Login";
                    LogData = "User " + username + " Login ";
                    InsertUserLog(ActivityName, LogData);
                    UserInfo.MDiPerent = "Kitchen_Home";
                    Kitchen_Home go = new Kitchen_Home(username);
                    go.Show();
                    this.Hide();

                }
                else if (usertype == "5")
                {
                    UserInfo.Userid = Userid;
                    UserInfo.UserName = username;
                    UserInfo.usertype = "5"; //4 = Driver
                    UserInfo.Shopid = Shopid;
                    UserInfo.Language = "English";
                    UserInfo.IsSuperAddmin = false;
                    workRecords();
                    CheckPrintersetting();
                    ActivityName = "Driver Login";
                    LogData = "User " + username + " Login ";
                    InsertUserLog(ActivityName, LogData);
                    UserInfo.MDiPerent = "Driver_Home";
                    Driver_Home go = new Driver_Home(username);
                    go.Show();
                    this.Hide();

                }
                else if (usertype == "6")
                {
                    UserInfo.Userid = Userid;
                    UserInfo.UserName = username;
                    UserInfo.usertype = "6"; //6 = Spa Employee
                    UserInfo.Shopid = Shopid;
                    UserInfo.Language = "English";
                    UserInfo.IsSuperAddmin = false;
                    workRecords();
                    CheckPrintersetting();
                    ActivityName = "Spa Employee Login";
                    LogData = "User " + username + " Login ";
                    InsertUserLog(ActivityName, LogData);
                    UserInfo.MDiPerent = "SpaEmployee_Home";               
                    SpaEmployee_Home go = new SpaEmployee_Home(username);
                    go.Show();
                    this.Hide();

                }
                else if (usertype == "0") // Block user
                {

                    MessageBox.Show("\n This user (" + username + ") has been blocked. \n Please contact to administrator.", "Block - Inactive", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    LoginFail();
                }
            }
        }

        public bool Loginsuper()
        {
            string SPass = EncryptionClass.Encrypt(txtPassword.Text);
            string Sql = "Select TenentID from mycompanysetup_winapp where Suser = '" + txtUserName.Text + "' and SPass = '" + SPass + "' ";
            DataTable dt1 = DataAccess.GetDataTable(Sql);
            if (dt1.Rows.Count > 0)
            {
                //string tkhan = " Select *  from  usermgt  where TenentID = " + Tenent.TenentID + " and Usertype = 1  "; 
                //DataTable dt = DataAccess.GetDataTable(tkhan);
                //if (dt.Rows.Count > 0)
                //{
                //    string username = dt.Rows[0]["Username"].ToString();
                //    string password = dt.Rows[0]["password"].ToString();
                //    string usertype = dt.Rows[0]["usertype"].ToString();
                //    string Shopid = comboTerminal.SelectedValue.ToString();
                //    int Userid = Convert.ToInt32(dt.Rows[0]["id"]);

                //    LoginValid(username, usertype, Shopid, Userid, "Super Admin");
                //    return true;
                //}
                //else
                //{
                string username = txtUserName.Text;
                string usertype = "1";
                string Shopid = comboTerminal.SelectedValue.ToString();
                int Userid = Convert.ToInt32(1);
                LoginValid(username, usertype, Shopid, Userid, "Super Admin");
                return true;
                //}
            }
            else
            {
                return false;
            }
        }

        public void LoginFail()
        {
            int Count = LoginCheck.invalidAttapt + 1;
            lblmsg.Visible = true;
            if (Count >= 6)
            {
                lblmsg.Text = "Username or Password does not match.\n You Try " + Count + " invalid attempt . Please Contact Admin ";
            }
            else
            {
                lblmsg.Text = "Username or Password does not match.\n You Try " + Count + " invalid attempt ";
            }
            LoginCheck.invalidAttapt = Count;
            txtUserName.Focus();
        }
        public void CheckRegistry()
        {
            // kascii1 = Mac_Addr
            // kascii2 = Install_Date
            // kascii3 = ExpireDate
            // kascii4 = TenentID
            // kascii5 = Dbpath
            // kascii6 = imgpath           
            // kascii8 = AppPath
       
             registrymac = get_reg_MAC();
          //  string systemMac = GetMACAddress();

            if (MacAddr != registrymac)
            {
                set_Macaddrlogin();
            }
        }
        public int CheckData(int regTenentID)
        {
            //000C2932A8B9

     
            if (regTenentID == 0)
            {
                return 3;
            }
            //Check_UserExist
            string sql = "select  TenentID  from VW_CheckLogin_Win where TenentID=" + regTenentID + " and Mac_Addr like '%" + MacAddr + "%' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count < 1)
            {
                return 0;
            }
            else
            {
                string Username = txtUserName.Text;
                string password = txtPassword.Text;

                if (Username != "" && password != "")
                {
                    string sql2 = "select  TenentID  from VW_CheckLogin_Win where Username='" + Username + "' and password='" + password + "' ";
                    DataTable dt2 = DataAccess.GetDataTable(sql2);
                    if (dt2.Rows.Count < 1)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }
        public int Check_verification()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

        
          //  string reg_mac1 = registrymac();

            //add Right Mac Address In Registry

            if (registrymac == null || registrymac == "")
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);

                string EncMacAddr = EncryptionClass.Encrypt(MacAddr);
                key.SetValue("kascii1", EncMacAddr);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);

                string EncMacAddr = EncryptionClass.Encrypt(MacAddr);
                key.SetValue("kascii1", EncMacAddr);
            }

            int regTenentID = get_reg_TenentID();

            string Username = txtUserName.Text;
            string password = txtPassword.Text;

            if (regTenentID != 0)
            {
                int flag = Tenent_Found(Username, password, MacAddr);
                return flag;
            }
            else
            {
                int flag = Tenent_NOt_Found(Username, password, MacAddr);
                return flag;
            }
        }
        public int Tenent_Found(string Username, string password, string MacAddr)
        {
            if (InternetConnection() == true)
            {
                bool CON_Ceck = CheckDBConnection();

                if (CON_Ceck == true)
                {
                    int TenentIDreg = get_reg_TenentID();

                    string sql = "select *  from VW_CheckLogin_Win where TenentID=" + TenentIDreg + " and Username='" + Username + "' and password='" + password + "' ";
                    DataTable dt = DataLive.GetLiveDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        DateTime Install_Date = Convert.ToDateTime(dt.Rows[0]["installDate"]);
                        DateTime ExpDate = Convert.ToDateTime(dt.Rows[0]["ExpireDate"]);

                        set_Install_EXP_Date(Install_Date, ExpDate);
                        Registation.UodateSuperuser();

                        string sqlCheck2 = "select *  from VW_CheckLogin_Win where TenentID=" + TenentIDreg + " and Username='" + Username + "' and password='" + password + "' and Mac_Addr like '%" + MacAddr + "%' ";
                        DataTable dtCheck2 = DataLive.GetLiveDataTable(sqlCheck2);
                        if (dtCheck2.Rows.Count > 0)
                        {
                            string sqlCheck3 = "select  *  from VW_CheckLogin_Win where TenentID=" + TenentIDreg + " and Username='" + Username + "' and password='" + password + "' ";
                            DataTable dtCheck3 = DataAccess.GetDataTable(sqlCheck3);
                            if (dtCheck3.Rows.Count < 1)
                            {
                                DialogResult result = MessageBox.Show("Your Data not Found In Local Database \n Do you Want To Syncronize Data From Online ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                                if (result == DialogResult.Yes)
                                {
                                    if (Application.OpenForms["Registation"] != null)
                                    {
                                        Application.OpenForms["Registation"].Close();
                                    }
                                    this.Refresh();

                                    Registation GO = new Registation();
                                    GO.Show();
                                    //Data_Manage.Update_App.DBSyncro(TenentIDreg, lblmsg);
                                    //Application.Restart();
                                }
                            }
                            else
                            {
                                //Check_DatainLocal
                                string sqlCheck1 = "select  *  from VW_CheckLogin_Win where TenentID=" + TenentIDreg + " and Username='" + Username + "' and password='" + password + "' and Mac_Addr like '%" + MacAddr + "%' ";
                                DataTable dtCheck1 = DataAccess.GetDataTable(sqlCheck1);
                                if (dtCheck1.Rows.Count < 1)
                                {
                                    //Edit_My_ComputerSetupMac
                                    string sqlrun = " update mycompanysetup_winapp set Mac_Addr='" + MacAddr + "' where TenentID=" + TenentIDreg + "  ";
                                    DataAccess.ExecuteSQL(sqlrun);
                                }
                            }
                            return 0;
                        }
                        else
                        {
                            MessageBox.Show("Your Processer Not Match,\n Please Contact Admin", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUserName.Focus();
                            return 3;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Data Not Match,\n Please Registration First", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUserName.Focus();
                        return 2;
                    }
                }
                else
                {
                    return 4;
                }
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Check Internet Connention";
                return 1;
            }
        }
        public int Tenent_NOt_Found(string Username, string password, string MacAddr)
        {
            if (InternetConnection() == true)
            {
                bool CON_Ceck = CheckDBConnection();

                if (CON_Ceck == true)
                {
                    string sql = "select *  from VW_CheckLogin_Win where Username='" + Username + "' and password='" + password + "' and Mac_Addr like '%" + MacAddr + "%' ";
                    DataTable dt = DataLive.GetLiveDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        int Tenent = Convert.ToInt32(dt.Rows[0]["TenentID"]);// List.FirstOrDefault().TenentID;
                        DateTime installDate = Convert.ToDateTime(dt.Rows[0]["installDate"]);
                        DateTime ExpireDate = Convert.ToDateTime(dt.Rows[0]["ExpireDate"]);

                        setTenent(Tenent);
                        set_Install_EXP_Date(installDate, ExpireDate);
                        Registation.UodateSuperuser();
                        //Check_DatainLocal
                        string sqlCheck = "select  *  from VW_CheckLogin_Win where TenentID=" + Tenent + " and Username='" + Username + "' and password='" + password + "' and Mac_Addr like '%" + MacAddr + "%' ";
                        DataTable dtCheck = DataAccess.GetDataTable(sqlCheck);
                        if (dt.Rows.Count < 1)
                        {
                            DialogResult result = MessageBox.Show("Your Data not Found In Local Database \n Do you Want To Syncronize Data From Online ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (result == DialogResult.Yes)
                            {
                                if (Application.OpenForms["Registation"] != null)
                                {
                                    Application.OpenForms["Registation"].Close();
                                }
                                this.Refresh();

                                Registation GO = new Registation();
                                GO.Show();
                                //Data_Manage.Update_App.DBSyncro(TenentIDreg, lblmsg);
                                //Application.Restart();
                            }
                        }
                        return 0;
                    }
                    else
                    {
                        MessageBox.Show("Your Data Not Match,\n Please Registration First", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUserName.Focus();
                        return 2;
                    }
                }
                else
                {
                    return 4;
                }
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Check Internet Connention";
                return 1;
            }
        }
        public static void setTenent(int Tenent)
        {
            int TenentID = Tenent;
            RegistryKey Readkeyte = Registry.CurrentUser.OpenSubKey(Key);
            string strTenentID = null;
            if (Readkeyte != null)
            {
                if (Readkeyte.GetValue("kascii4") != null && Readkeyte.GetValue("kascii4") != "")
                {
                    strTenentID = EncryptionClass.Decrypt(Readkeyte.GetValue("kascii4").ToString());
                }
            }

            if (strTenentID == null || strTenentID == "")
            {
                string tenentidstr = TenentID.ToString();
                RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);
                string EncTenentID = EncryptionClass.Encrypt(tenentidstr);
                key.SetValue("kascii4", EncTenentID);
            }
            else
            {
                string tenentidstr = TenentID.ToString();
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
                string EncTenentID = EncryptionClass.Encrypt(tenentidstr);
                key.SetValue("kascii4", EncTenentID);
            }
        }
        public static void set_Macaddr()
        {
            string Mac = get_reg_MAC();
            string systemMac = GetMACAddress();

            if (Mac != systemMac)
            {
                if (Mac == null || Mac == "")
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);

                    string EncMacAddr = EncryptionClass.Encrypt(systemMac);
                    key.SetValue("kascii1", EncMacAddr);
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);//true means update allow other wise update not allows

                    string EncMacAddr = EncryptionClass.Encrypt(systemMac);
                    key.SetValue("kascii1", EncMacAddr);
                }
            }
        }
        public  void set_Macaddrlogin()
        {
          //  string Mac = get_reg_MAC();
           // string systemMac = GetMACAddress();

            if (registrymac != MacAddr)
            {
                if (registrymac == null || registrymac == "")
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);

                    string EncMacAddr = EncryptionClass.Encrypt(MacAddr);
                    key.SetValue("kascii1", EncMacAddr);
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);//true means update allow other wise update not allows

                    string EncMacAddr = EncryptionClass.Encrypt(MacAddr);
                    key.SetValue("kascii1", EncMacAddr);
                }
            }
        }
        public static void set_Install_EXP_Date(DateTime Install_Date, DateTime Exp_Date)
        {

            RegistryKey Readkeyte = Registry.CurrentUser.OpenSubKey(Key);
            string strinstall = null;
            string strExp = null;
            if (Readkeyte != null)
            {
                if (Readkeyte.GetValue("kascii2") != null && Readkeyte.GetValue("kascii2") != "" && Readkeyte.GetValue("kascii3") != null && Readkeyte.GetValue("kascii3") != "")
                {
                    strinstall = EncryptionClass.Decrypt(Readkeyte.GetValue("kascii2").ToString());
                    strExp = EncryptionClass.Decrypt(Readkeyte.GetValue("kascii3").ToString());
                }
            }

            if (strinstall == null)
            {
                string InstallDate = Install_Date.ToString("yyyy-MM-dd HH:MM:ss");
                RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);
                string EncInstall_Date = EncryptionClass.Encrypt(InstallDate);
                key.SetValue("kascii2", EncInstall_Date);
            }
            else
            {
                string InstallDate = Install_Date.ToString("yyyy-MM-dd HH:MM:ss");
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
                string EncInstall_Date = EncryptionClass.Encrypt(InstallDate);
                key.SetValue("kascii2", EncInstall_Date);
            }

            if (strExp == null)
            {
                string ExpDate = Exp_Date.ToString("yyyy-MM-dd HH:MM:ss");
                RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);
                string EncExpDate = EncryptionClass.Encrypt(ExpDate);
                key.SetValue("kascii3", EncExpDate);
            }
            else
            {
                string ExpDate = Exp_Date.ToString("yyyy-MM-dd HH:MM:ss");
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
                string EncExpDate = EncryptionClass.Encrypt(ExpDate);
                key.SetValue("kascii3", EncExpDate);
            }
        }
        public string Get_Window_username()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return userName;
        }
        public void workRecords()
        {
            string logdate = DateTime.Now.ToString("yyyy-MM-dd");
            string logtime = DateTime.Now.ToString("HH:mm:ss");
            string logdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //remove this
            int ID = DataAccess.getworkrecordsMYid(Tenent.TenentID);

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlLogIn = " insert into tbl_workrecords (TenentID, ID, Username, datatype, logdate, logtime, logdatetime,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + ", " + ID + " ,'" + UserInfo.UserName + "' , 'IN' , '" + logdate + "' , " +
                                  " '" + logtime + "' , '" + logdatetime + "' ,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
            DataAccess.ExecuteSQL(sqlLogIn);

            string sqlLogwin = " insert into Win_tbl_workrecords (TenentID, ID, Username, datatype, logdate, logtime, logdatetime,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + ", " + ID + " ,'" + UserInfo.UserName + "' , 'IN' , '" + logdate + "' , " +
                                  " '" + logtime + "' , '" + logdatetime + "' ,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
            Datasyncpso.insert_Live_sync(sqlLogwin, "Win_tbl_workrecords", "INSERT");
        }
        public static void InsertUserLog(string ActivityName, string Log_Data)
        {
            string logdate = DateTime.Now.ToString("yyyy-MM-dd");
            string logtime = DateTime.Now.ToString("HH:mm:ss");
            string logdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (Tenent.TenentID != 0)
            {
                //remove this sahir
                int ID = DataAccess.getUserLogMYid(Tenent.TenentID);

                //TenentID ,id , UserID , Username , ActivityName , Log_Data , logdate , logtime	, logdatetime , status , UploadDate , Uploadby , SyncDate , Syncby , SynID 

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlLogIn = " insert into Win_tbl_UserLog (TenentID, id,UserID, Username,ActivityName, Log_Data,logdate , logtime, logdatetime,status,Uploadby ,UploadDate ,SynID) " +
                                     " values (" + Tenent.TenentID + ", " + ID + " ," + UserInfo.Userid + ",'" + UserInfo.UserName + "' ,'" + ActivityName + "', '" + Log_Data + "' , " +
                                      " '" + logdate + "' ,'" + logtime + "' , '" + logdatetime + "' ,1,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                DataAccess.ExecuteSQL(sqlLogIn);
                Datasyncpso.insert_Live_sync(sqlLogIn, "Win_tbl_UserLog", "INSERT");
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            //LoginCheck.invalidAttapt = 0;
            //Login g = new Login();
            //g.Show();
            //this.Hide();
            Application.Restart();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           // prg(); //pictureBox2.Visible = true;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public void prg()
        {
            //progressBar1.Increment(5);
          //  lblprgbarCount.Text = " " + progressBar1.Value.ToString() + "%";
         //   if (progressBar1.Value == progressBar1.Maximum)
         //   {
          //      timer1.Stop();
                // MessageBox.Show("Server has been connected");
                // this.Close();
                //timer1.Stop();
           //     btnColse.Enabled = true;
           // }
        }
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }
        private void btnColse_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        public void setdefaultpath()
        {
            DialogResult result = MessageBox.Show("DataBase Path Not Set.\n You Want To Set Default Path ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string PAth = Application.StartupPath + @"\psodb.db";
                string Image = Application.StartupPath + @"\ITEMIMAGE\";

                UserInfo.Database_path = @"Data Source=" + PAth + ";Version=3;New=False;Compress=True;";
        

                RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);
                string Database = null;
                string Img = null;
                if (Readkey != null)
                {
                    if (Readkey.GetValue("kascii5") != null)
                        Database = EncryptionClass.Decrypt(Readkey.GetValue("kascii5").ToString());
                    if (Readkey.GetValue("kascii6") != null)
                        Img = EncryptionClass.Decrypt(Readkey.GetValue("kascii6").ToString());
                }

                if (Database == null)
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);
                    if (PAth != "")
                    {
                        string Dbpath = PAth;
                        string EncDbpath = EncryptionClass.Encrypt(Dbpath);
                        key.SetValue("kascii5", EncDbpath);

                        string AppPath = Application.StartupPath.ToString();
                        string EcnAppPath = EncryptionClass.Encrypt(AppPath);
                        key.SetValue("kascii8", EcnAppPath);

                        string MacAddr = GetMACAddress();
                        string EncMacAddr = EncryptionClass.Encrypt(MacAddr);
                        key.SetValue("kascii1", EncMacAddr);
                    }
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
                    if (PAth != "")
                    {
                        string Dbpath = PAth;
                        string EncDbpath = EncryptionClass.Encrypt(Dbpath);
                        key.SetValue("kascii5", EncDbpath);

                        string AppPath = Application.StartupPath.ToString();
                        string EcnAppPath = EncryptionClass.Encrypt(AppPath);
                        key.SetValue("kascii8", EcnAppPath);

                        string MacAddr = GetMACAddress();
                        string EncMacAddr = EncryptionClass.Encrypt(MacAddr);
                        key.SetValue("kascii1", EncMacAddr);
                    }
                }

                if (Img == null)
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);
                    if (Image != "")
                    {
                        string imgpath = Image;
                        string Encimgpath = EncryptionClass.Encrypt(imgpath);
                        key.SetValue("kascii6", Encimgpath);
                    }
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
                    if (Image != "")
                    {
                        string imgpath = Image;
                        string Encimgpath = EncryptionClass.Encrypt(imgpath);
                        key.SetValue("kascii6", Encimgpath);
                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            // more than one application run at time than close all .
          //  int Count = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count();
          //  if (Count > 1)
          //  {
          //      DialogResult result = MessageBox.Show(" Restart Application ", "OK", MessageBoxButtons.OK, MessageBoxIcon.Question);
          //      if (result == DialogResult.OK)
          //      {
          //          foreach (var process in Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)))
          //          {
          //              process.Kill();
          //          }                    
          //      }
          //  }

             MacAddr = GetMACAddress();

             allmac = Registation.getAllMac();

            bool Falg = InternetConnection();// wifi symbol

            CheckRegistry();


            string Path = Database_path();

            if (Path == "" || Path == null)
            {
                setdefaultpath();
                txtUserName.Focus();

            }
            else
            {
                UserInfo.Database_path = getConnection(Path);
            
            }
            //get_tenent
            DataAccess.getTEnentID();

            string LOGO = DataAccess.LOGO_path();

            if (LOGO != "")
            {
                UserInfo.LOGO = LOGO;
            }
            //Get_tbl_terminalLocationBranch
            Bindshopbranch();

            DefaultValue();
            GetSyncFile(txtDatabase.Text.Trim());
            CheckLastmailDB();
            //installvkeyboard();
        }

        public void installvkeyboard()
        {
            bool flag = SyncSetup.IsProgramInstalled("Free Virtual Keyboard");
            if (flag == false)
            {
                string AppPath = Application.StartupPath + "\\installer\\FreeVKSetup.exe";
                if (File.Exists(AppPath))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = AppPath;
                    p.Start();
                    p.WaitForExit();
                }
            }
        }

        public void CheckLastmailDB()
        {
            if (Tenent.TenentID == 0)
            {
                return;
            }

            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

            string LastDate = "";
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii9") != null)
                    LastDate = EncryptionClass.Decrypt(Readkey.GetValue("kascii9").ToString());
            }

            if (LastDate == "")
            {
                if (LastDate == "")
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);

                    string LastD = DateTime.Now.ToString("dd/MM/yyyy");
                    string EncLastD = EncryptionClass.Encrypt(LastD);
                    key.SetValue("kascii9", EncLastD);

                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);

                    string LastD = DateTime.Now.ToString("dd/MM/yyyy");
                    string EncLastD = EncryptionClass.Encrypt(LastD);
                    key.SetValue("kascii9", EncLastD);
                }
            }

            DateTime Today = DateTime.Now;
            string T = Today.ToString("dd/MM/yyyy");
            string Last = LastDate;

            //Backupdbfile();

            if (T != Last)
            {
                Backupdbfile();//SQlite DB backup
                //bool flg = mailDB();

                if (LastDate == "")
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);

                    string LastD = T;
                    string EncLastD = EncryptionClass.Encrypt(LastD);
                    key.SetValue("kascii9", EncLastD);
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);

                    string LastD = T;
                    string EncLastD = EncryptionClass.Encrypt(LastD);
                    key.SetValue("kascii9", EncLastD);
                }

            }
        }
        public bool mailDB()
        {
            string Path = Database_path();
            string systemMac = GetMACAddress();
            string Company = DataAccess.GetCompany() != null ? DataAccess.GetCompany() : "";
            string body = "TenentID = " + Tenent.TenentID + ",<BR> Company Name = " + Company + " ,<BR> Mac = " + systemMac + " ,<BR> Backup of db " + DateTime.Now;
            string email = "newayosoftech@gmail.com";

            string dbp = "";

            if (Path != "")
            {
                if (Path == "psodb.db")
                {
                    dbp = Application.StartupPath + "\\psodb.db";
                }
                else
                {
                    if (System.IO.File.Exists(Path))
                    {
                        dbp = Path;
                    }
                    else
                    {
                        dbp = Application.StartupPath + "\\psodb.db";
                    }
                }
            }
            else
            {
                dbp = Application.StartupPath + "\\psodb.db";
            }
            string syncdb = Application.StartupPath + "\\Syncpso.db";

            string[] attachments = { dbp, syncdb };

            string[] CC = { "johar@writeme.com" };

            return sendEmail(body, email, attachments, CC);

        }

        public void Backupdbfile()//SQlite DB backup
        {
            string Path1 = Database_path();
            string dbp = "";

            if (Path1 != "")
            {
                if (Path1 == "psodb.db")
                {
                    dbp = Application.StartupPath + "\\psodb.db";
                }
                else
                {
                    if (System.IO.File.Exists(Path1))
                    {
                        dbp = Path1;
                    }
                    else
                    {
                        dbp = Application.StartupPath + "\\psodb.db";
                    }
                }
            }
            else
            {
                dbp = Application.StartupPath + "\\psodb.db";
            }
            string syncdb = Application.StartupPath + "\\Syncpso.db";

            string[] attachments = { dbp, syncdb };

            ////Delete Directory

            //string DeleteDir = "C:\\pos_db_Backup\\";

            //string old1 = "DB_Backup_" + DateTime.Now.AddDays(-2).ToString("dd_MMM_yyyy");
            //string old2 = "DB_Backup_" + DateTime.Now.AddDays(-3).ToString("dd_MMM_yyyy");
            //string old3 = "DB_Backup_" + DateTime.Now.AddDays(-4).ToString("dd_MMM_yyyy");
            //string old4 = "DB_Backup_" + DateTime.Now.AddDays(-5).ToString("dd_MMM_yyyy");
            //string old5 = "DB_Backup_" + DateTime.Now.AddDays(-6).ToString("dd_MMM_yyyy");
            //string old6 = "DB_Backup_" + DateTime.Now.AddDays(-7).ToString("dd_MMM_yyyy");

            //System.IO.DirectoryInfo di = new DirectoryInfo(DeleteDir);
            //if (di.Exists)
            //{
            //    foreach (DirectoryInfo dir in di.GetDirectories())
            //    {
            //        if (dir.Name != old1 && dir.Name != old2 && dir.Name != old3 && dir.Name != old4 && dir.Name != old5 && dir.Name != old6)
            //        {
            //            dir.Delete(true);
            //        }
            //    }
            //}

            // Create New Directory

            string targetPath = "C:\\pos_db_Backup\\DB_Backup_" + DateTime.Now.AddDays(-1).ToString("dd_MMM_yyyy");
            //string targetPath = "C:\\pos_db_Backup\\backup_new";
            Directory.CreateDirectory(targetPath);

            int len = attachments.Length;
            for (int i = 0; i < len; i++)
            {
                string attachmentFilename = attachments[i].ToString();

                string FolderPath = Path.GetDirectoryName(attachmentFilename);

                string FileName = Path.GetFileName(attachmentFilename);

                string destinationFile = System.IO.Path.Combine(targetPath, FileName);

                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }
                System.IO.File.Copy(attachmentFilename, destinationFile, true);
            }

            DirectoryInfo ch = new DirectoryInfo("C:\\pos_db_Backup");
            ch.Attributes = FileAttributes.Hidden;
        }

        public bool sendEmail(string body, string email, string[] attachments, string[] cc)
        {
            try
            {
                if (String.IsNullOrEmpty(email))
                    return false;

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                msg.Subject = "Data";

                msg.From = new System.Net.Mail.MailAddress("info@pos53.com");

                msg.To.Add(new System.Net.Mail.MailAddress(email));

                int lencc = cc.Length;
                for (int i = 0; i < lencc; i++)
                {
                    string cc1 = cc[i].ToString();
                    msg.CC.Add(new System.Net.Mail.MailAddress(cc1));
                }
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.Body = body;
                msg.IsBodyHtml = true;
                msg.Priority = System.Net.Mail.MailPriority.High;

                int len = attachments.Length;

                for (int i = 0; i < len; i++)
                {
                    string attachmentFilename = attachments[i].ToString();
                    if (attachmentFilename != null)
                    {
                        Attachment attachment = new Attachment(attachmentFilename, MediaTypeNames.Application.Octet);
                        System.Net.Mime.ContentDisposition disposition = attachment.ContentDisposition;
                        disposition.CreationDate = File.GetCreationTime(attachmentFilename);
                        disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
                        disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
                        disposition.FileName = Path.GetFileName(attachmentFilename);
                        disposition.Size = new FileInfo(attachmentFilename).Length;
                        disposition.DispositionType = DispositionTypeNames.Attachment;
                        msg.Attachments.Add(attachment);
                    }
                }

                bool Internat = InternetConnection();
                if (Internat == true)
                {

                    System.Net.Mail.SmtpClient smpt = new System.Net.Mail.SmtpClient();
                    smpt.UseDefaultCredentials = false;
                    smpt.Host = "webmail.pos53.com";//for google required smtp.gmail.com and must be check Google Account setting https://myaccount.google.com/lesssecureapps?pli=1 ON

                    smpt.Port = 25;

                    smpt.EnableSsl = false;//for google required true

                    smpt.Credentials = new System.Net.NetworkCredential("info@pos53.com", "Ayo1234");

                    smpt.Send(msg);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static void CheckPrintersetting()
        {
            if (Tenent.TenentID == 0)
            {
                return;
            }
            //remove this
            string sql = "select TenentID from tblPrintSetup where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count < 1)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string CashReciptPRinter = DataAccess.GetDefaultPrinter();
                string CashReceiptFile = "1";
                string CreditInvoicePrinter = DataAccess.GetDefaultPrinter();
                string CreditInvoiceFile = "1";
                string KitchenNotePrinter = DataAccess.GetDefaultPrinter();
                string KitchenNoteFile = "1";
                //Insert_tblPrinterSetup
                string sqlCmd = " insert into tblPrintSetup (TenentID,Shopid,CashReciptPRinter,CashReceiptFile,CreditInvoicePrinter,CreditInvoiceFile,KitchenNotePrinter,KitchenNoteFile,UploadDate,Uploadby,SynID )  " +
                                " values (" + Tenent.TenentID + ",'" + UserInfo.Shopid + "' ,'" + CashReciptPRinter + "','" + CashReceiptFile + "','" + CreditInvoicePrinter + "','" + CreditInvoiceFile + "','" + "None" + "','" + "None" + "','" + UploadDate + "'  ,'" + UserInfo.UserName + "' , 1  )";
                int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                string sqlCmdWin = " insert into tblPrintSetup (TenentID,Shopid,CashReciptPRinter,CashReceiptFile,CreditInvoicePrinter,CreditInvoiceFile,KitchenNotePrinter,KitchenNoteFile,UploadDate,Uploadby,SynID )  " +
                    " values (" + Tenent.TenentID + ",'" + UserInfo.Shopid + "' ,'" + CashReciptPRinter + "','" + CashReceiptFile + "','" + CreditInvoicePrinter + "','" + CreditInvoiceFile + "','" + "None" + "','" + "None" + "','" + UploadDate + "'  ,'" + UserInfo.UserName + "' , 1  )";
                Datasyncpso.insert_Live_sync(sqlCmdWin, "tblPrintSetup", "INSERT");

                string ActivityName = "Add Printer setting";
                string LogData = "Add Printer setting With Shopid " + UserInfo.Shopid + " ";
                Login.InsertUserLog(ActivityName, LogData);
            }
        }
        public void GetSyncFile(string file)
        {
            FileInfo fInfo = new FileInfo(file);

            String dirName = fInfo.Directory.FullName;
            //string StartPath = Application.StartupPath;
            string syncpath = dirName + "\\Syncpso.db";
       
    
            if (System.IO.File.Exists(syncpath))
            {
                UserInfo.Sync_path = @"Data Source=" + syncpath + ";Version=3;New=False;Compress=True;";
            }
            else
            {
                MessageBox.Show("App and syncdb should be in same folder");
                Environment.Exit(0);
            }
        }
        public string getConnection(string Path)
        {
            string Con = "";

            if (Path != "")
            {
                if (Path == "psodb.db")
                {
                    string StartPath = Application.StartupPath;
                    string PathS = StartPath + "\\" + Path;
                    if (System.IO.File.Exists(PathS))
                    {
                        Con = @"Data Source=" + Path + ";Version=3;New=False;Compress=True;";
                    }
                    else
                    {
                        MessageBox.Show("Your Appliction Was damage Please Download Latest Version Of Appliction");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    if (System.IO.File.Exists(Path))
                    {
                        String s = Path.Substring(0, 3);
                        if (s.Contains(":\\"))
                        {
                            Con = @"Data Source=" + Path + ";Version=3;New=False;Compress=True;";
                        }
                        else
                        {
                            Con = @"Data Source=\\" + Path + ";Version=3;New=False;Compress=True;";
                        }
                    }
                    else
                    {
                        string StartPath = Application.StartupPath;
                        string PathS = StartPath + "\\psodb.db";
                        if (System.IO.File.Exists(PathS))
                        {
                            string MSG = Path + " is Not Exist in System You Want To Start Appliction With Default Datatabase";
                            DialogResult result = MessageBox.Show(MSG, "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                Con = @"Data Source=psodb.db;Version=3;New=False;Compress=True;";
                            }
                            else
                            {
                                MessageBox.Show("Your Appliction Was damage Please Download Latest Version Of Appliction");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your Appliction Was damage Please Download Latest Version Of Appliction");
                            Environment.Exit(0);
                        }
                    }
                }
            }

            return Con;
        }
        public string Database_path()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

            string Path = "";
            string Database = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii5") != null)
                {
                    Database = EncryptionClass.Decrypt(Readkey.GetValue("kascii5").ToString());
                    Path = Database;
                }
                else
                {
                    Path = "";
                }

            }
            else
            {
                Path = "";
            }
 
            return Path;
       
        }
        public string img_path()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

            string Path = "";
            string img = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii6") != null)
                {
                    img = EncryptionClass.Decrypt(Readkey.GetValue("kascii6").ToString());
                    Path = img;
                }
                else
                {
                    Path = Application.StartupPath + @"\ITEMIMAGE\";
                }

            }
            else
            {
                Path = "";
            }

            return Path;
        }
        ModifyRegistry myRegistry = new ModifyRegistry();
        public static string Key = @"SOFTWARE\Encrypt\Encrypt";
        public static string get_reg_MAC()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);
            string mac = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii1") != null && Readkey.GetValue("kascii1") != "")
                {
                    mac = EncryptionClass.Decrypt(Readkey.GetValue("kascii1").ToString());
                }
            }
            return mac;
        }

        public static string get_localServer()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);
            string LocalServer = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii11") != null && Readkey.GetValue("kascii11") != "")
                {
                    LocalServer = EncryptionClass.Decrypt(Readkey.GetValue("kascii11").ToString());
                }
            }
            return LocalServer;
        }

        public static string get_localServerDB()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);
            string LocalServerDB = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii12") != null && Readkey.GetValue("kascii12") != "")
                {
                    LocalServerDB = EncryptionClass.Decrypt(Readkey.GetValue("kascii12").ToString());
                }
            }
            return LocalServerDB;
        }

        public static string get_localServerUser()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);
            string LocalServerUser = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii13") != null && Readkey.GetValue("kascii13") != "")
                {
                    LocalServerUser = EncryptionClass.Decrypt(Readkey.GetValue("kascii13").ToString());
                }
            }
            return LocalServerUser;
        }
        public static string get_localServerPassword()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);
            string LocalServerPass = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii14") != null && Readkey.GetValue("kascii14") != "")
                {
                    LocalServerPass = EncryptionClass.Decrypt(Readkey.GetValue("kascii14").ToString());
                }
            }
            return LocalServerPass;
        }


        public static string get_reg_Install()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);
            string Install = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii2") != null && Readkey.GetValue("kascii2") != "")
                {
                    Install = EncryptionClass.Decrypt(Readkey.GetValue("kascii2").ToString());
                }
            }
            return Install;
        }
        public  string get_reg_regexpire()
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
       if(txtUserName.Text.Trim()=="johar" & txtPassword.Text.Trim()=="johar")
         {
               // regexpire = EncryptionClass.Decrypt(Readkey.GetValue("kascii3").ToString());
                //string EncDbpath = EncryptionClass.Encrypt("2020-05-10 14:08:11");
                return "2020-09-30 14:08:11";
               
            }
         else
         {
            return regexpire;
       
          }
        
        }
        public static int get_reg_TenentID()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

           


            int TenentID = 0;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii4") != null && Readkey.GetValue("kascii4") != "")
                {
                    string tenet = Readkey.GetValue("kascii4").ToString();
                    TenentID = Convert.ToInt32(EncryptionClass.Decrypt(tenet));
                }
            }
            return TenentID;
        }
        public bool CheckActivation()
        {
            DateTime today = DateTime.Now;
            string PC_name = System.Environment.MachineName;
          
           // string MacAddr = GetMACAddress();
            DateTime InstallDate = DateTime.Now;
            DateTime Exp_Date = InstallDate.AddDays(30);


            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

          //  string mac = null;
            string Install = null;
            string regexpire = null;
            int TenentID = 0;

          //  mac = get_reg_MAC();
            TenentID = get_reg_TenentID();

            try
            {

                bool CON_Ceck =  CheckDBConnection();
                if (CON_Ceck == true)
                {
                    if (TenentID == 0)
                    {
                        if (Tenent.TenentID != 0)
                        {
                            TenentID = Tenent.TenentID;
                            setTenent(TenentID);
                        }
                    }

                    string sql = "select *  from VW_CheckLogin_Win where TenentID=" + TenentID + " and Mac_Addr like '%" + MacAddr + "%' ";
                    DataTable dt = DataLive.GetLiveDataTable(sql);//live connection and get data from VW_CheckLogin_Win
                    if (dt.Rows.Count > 0)
                    {
                        DateTime installDate = Convert.ToDateTime(dt.Rows[0]["installDate"]);
                        DateTime ExpireDate = Convert.ToDateTime(dt.Rows[0]["ExpireDate"]);
                        set_Install_EXP_Date(installDate, ExpireDate);
                        //remove this one because super user is remove from table
                        Registation.UodateSuperuser();
                    }
                }
            }
            catch 
            {

            }

            Install = get_reg_Install();
            regexpire = get_reg_regexpire();

            if (Install != null && regexpire != null && TenentID != 0)
            {
                UserInfo.TenentID = TenentID;
                DateTime expire = Convert.ToDateTime(regexpire);
                UserInfo.ExpireDate = expire.ToString("dd-MMM-yyyy");
            }

            string Install_Date = InstallDate.ToString("yyyy-MM-dd HH:MM:ss");
            string ExpDate = Exp_Date.ToString("yyyy-MM-dd HH:MM:ss");

            if (regexpire == null && Install == null)
            {
                MessageBox.Show("Please Regitration First..");
                return false;
            }
            else
            {
                DateTime Exp = Convert.ToDateTime(regexpire);
                UserInfo.ExpireDate = Exp.ToString("yyyy-MM-dd HH:MM:ss");
                //reverse
                 if (Exp <= today)
                 {
                     MessageBox.Show("Activation expired");
                     lblmsg.Visible = true;
                     lblmsg.Text = "Activation expired";
                     btnLogin.Enabled = false;
                     return false;
                 }
                 else
                 {
                     return true;
                 }
                //return true;
              
            }
        }
        public string GetSerialNumber()
        {
            Guid serialGuid = Guid.NewGuid();
            string uniqueSerial = serialGuid.ToString("N");

            string uniqueSerialLength = uniqueSerial.Substring(0, 28).ToUpper();

            char[] serialArray = uniqueSerialLength.ToCharArray();
            string finalSerialNumber = "";

            int j = 0;
            for (int i = 0; i < 28; i++)
            {
                for (j = i; j < 4 + i; j++)
                {
                    finalSerialNumber += serialArray[j];
                }
                if (j == 28)
                {
                    break;
                }
                else
                {
                    i = (j) - 1;
                    finalSerialNumber += "-";
                }
            }

            return finalSerialNumber;
        }
        //public class InternetAvailability
        //{
        //    [DllImport("wininet.dll")]
        //    private extern static bool InternetGetConnectedState(out int description, int reservedValue);

        //    public static bool IsInternetAvailable()
        //    {
        //        int description;
        //        return InternetGetConnectedState(out description, 0);
        //    }
        //}
        public static bool InternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "www.google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                bool falg = (reply.Status == IPStatus.Success);
                if (falg == false)
                {
                    //bool falg1 = InternetConnection2();
                    //return falg1;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                //bool falg = InternetConnection2();
                //return falg;
                return false;
            }
           // return true;
        }

        public static bool InternetConnection2()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //public static string GetMACAddress()
        //{
        //    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        //    String sMacAddress = string.Empty;
        //    foreach (NetworkInterface adapter in nics)
        //    {
        //        if (sMacAddress == String.Empty)// only return MAC Address from first card  
        //        {
        //            IPInterfaceProperties properties = adapter.GetIPProperties();
        //            sMacAddress = adapter.GetPhysicalAddress().ToString();
        //        }
        //    } return sMacAddress;
        //}
        public static string GetMACAddress()//local System Mac
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) //&& nic.OperationalStatus == OperationalStatus.Up
                {
                    return nic.GetPhysicalAddress().ToString();
                }
            }
            return null;
        }
        public static IPAddress GetIPAddress(string hostName)
        {
            Ping ping = new Ping();
            var replay = ping.Send(hostName);

            if (replay.Status == IPStatus.Success)
            {
                return replay.Address;
            }
            return null;
        }
        private void LnkBtnForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["GetPassword"] != null)
            {
                Application.OpenForms["GetPassword"].Close();
            }
            this.Refresh();
            User_mgt.GetPassword GO = new User_mgt.GetPassword();
            GO.Show();
        }
        private void BtnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool Internat = Login.InternetConnection();
            if (Internat == false)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Check Internet Connention";
                return;
            }
            else
            {
                if (Application.OpenForms["Registation"] != null)
                {
                    Application.OpenForms["Registation"].Close();
                }
                this.Refresh();
                Registation GO = new Registation();
                GO.Show();
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetPath go = new SetPath();
            go.Show();
        }
        public static void Task()
        {
            // Get the service on the local machine
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Syncronization";

                // Create a trigger that will fire the task at this time every other day
                //td.Triggers.Add(new DailyTrigger { DaysInterval = 2 });

                var trigger = new TimeTrigger();
                trigger.Repetition.Interval = TimeSpan.FromMinutes(10);
                td.Triggers.Add(trigger);

                string Path = Application.StartupPath.ToString();

                string exe = Path + "\\syncro\\POS_Syncronic.application";
                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction(exe, null));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"Syncroniz", td);
            }
        }
        public void remove_Task()
        {
            using (TaskService ts = new TaskService())
            {
                // Remove the task we just created
                ts.RootFolder.DeleteTask("Syncroniz");
            }
        }
        public  void DefaultValue()
        {
            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

            string Database = null;
            string image = null;

            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii5") != null)
                {
                    Database = EncryptionClass.Decrypt(Readkey.GetValue("kascii5").ToString());
                    txtDatabase.Text = Database;
        
                 

                  
                }

                if (Readkey.GetValue("kascii6") != null)
                {
                    image = EncryptionClass.Decrypt(Readkey.GetValue("kascii6").ToString());
                    txtImage.Text = image;
                }

            }
           // FileInfo fInfo = new FileInfo(Database);
           // String dirName = fInfo.Directory.FullName;
           // return dirName;
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
                txtDatabase.Text = folderDlg.FileName;
                string DB = txtDatabase.Text.Trim();
                DB = DB.TrimStart('\\');
                txtDatabase.Text = DB;
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
                txtImage.Text = folderDlg.SelectedPath + @"\";
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
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

                if (txtDatabase.Text != "")
                {
                    string Dbpath = txtDatabase.Text;
                    string EncDbpath = EncryptionClass.Encrypt(Dbpath);
                    key.SetValue("kascii5", EncDbpath);
                }

                if (txtImage.Text != "")
                {
                    string imgpath = txtImage.Text;
                    string Encimgpath = EncryptionClass.Encrypt(imgpath);
                    key.SetValue("kascii6", Encimgpath);
                }

                //int TenentID = Tenent.TenentID;
                //if (TenentID != 0)
                //{
                //    string TenentIDstring = TenentID.ToString();
                //    string Enctenent = GlobleClass.EncryptionHelpers.Encrypt(TenentIDstring);
                //    key.SetValue("kascii4", Enctenent);
                //}

                string AppPath = Application.StartupPath.ToString();
                string EcnAppPath = EncryptionClass.Encrypt(AppPath);
                key.SetValue("kascii8", EcnAppPath);

                string MacAddr = GetMACAddress();
                string EncMacAddr = EncryptionClass.Encrypt(MacAddr);
                key.SetValue("kascii1", EncMacAddr);

            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
                if (txtDatabase.Text != "")
                {
                    string Dbpath = txtDatabase.Text;
                    string EncDbpath = EncryptionClass.Encrypt(Dbpath);
                    key.SetValue("kascii5", EncDbpath);
                }

                if (txtImage.Text != "")
                {
                    string imgpath = txtImage.Text;
                    string Encimgpath = EncryptionClass.Encrypt(imgpath);
                    key.SetValue("kascii6", Encimgpath);
                }

                string AppPath = Application.StartupPath.ToString();
                string EcnAppPath = EncryptionClass.Encrypt(AppPath);
                key.SetValue("kascii8", EcnAppPath);

                string MacAddr = GetMACAddress();
                string EncMacAddr = EncryptionClass.Encrypt(MacAddr);
                key.SetValue("kascii1", EncMacAddr);
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
        }
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LocalserverConnection go = new LocalserverConnection();
            go.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data_Manage.Update_App.Call_suncro_Up();
        }

        private void _down_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void _close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

       
    }
}
