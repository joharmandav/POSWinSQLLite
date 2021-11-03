using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop.Data_Manage
{
    public partial class Update_App : Form
    {
        static POSWinAppEntities DB = new POSWinAppEntities(Login.BuildConnectionString());
        public Update_App()
        {
            InitializeComponent();
        }
        private void Update_App_Load(object sender, EventArgs e)
        {
            // Update();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblflag.Text == "-")
            {
                lblflag.Text = "1";
                update_app();
            }
        }

        public void Update1()
        {
            bool Internat = Login.InternetConnection();

            if (Internat == true)
            {
                try
                {
                    int tenent = Tenent.TenentID;
                    string sql = "select * from mycompanysetup_winapp where TenentID = " + tenent + " and AppVer not null ";
                    DataTable dt = DataAccess.GetDataTable(sql);
                    decimal AppVersionLocal = 0;
                    decimal AppVersionLive = 0;
                    string downloadpath = "";
                    if (dt.Rows.Count > 0)
                    {
                        AppVersionLocal = Convert.ToDecimal(dt.Rows[0]["AppVer"]);
                    }

                    //select *  from MODULE_MST where TenentID=0 and Module_Name='POS_WIN' and Parent_Module_id !=0 
                    //Update MODULE_MST set appver = '2.1' , Appverdate = '2018-08-23 03:03:00.000' Where TenentID=0 and Module_Name='POS_WIN' and Parent_Module_id !=0 



                    string sqlCheck2 = "select *  from MODULE_MST where TenentID=0 and Module_Name='POS_WIN' and Parent_Module_id !=0 ";
                    DataTable dtCheck2 = DataLive.GetLiveDataTable(sqlCheck2);
                    if (dtCheck2.Rows.Count > 0)
                    {
                        AppVersionLive = Convert.ToDecimal(dtCheck2.Rows[0]["AppVer"]);
                        downloadpath = dtCheck2.Rows[0]["AppDownLoadURL"].ToString();
                    }


                    //if (DB.MODULE_MST.Where(p => p.TenentID == 0 && p.Module_Name == "POS_WIN" && p.Parent_Module_id != 0).Count() > 0)
                    //{
                    //    AppVersionLive = Convert.ToDecimal(DB.MODULE_MST.Where(p => p.TenentID == 0 && p.Module_Name == "POS_WIN" && p.Parent_Module_id != 0).FirstOrDefault().AppVer);
                    //    downloadpath = DB.MODULE_MST.Where(p => p.TenentID == 0 && p.Module_Name == "POS_WIN" && p.Parent_Module_id != 0).FirstOrDefault().AppDownLoadURL.ToString();
                    //}

                    if (AppVersionLive == AppVersionLocal)
                    {
                        IdelTime.WorkingFalg = false;
                        lblMSg.Text = "Your POS Application is Up to Date; No Update required..";
                        lblMSg.Refresh();
                        string MSG = lblMSg.Text;
                        MessageBox.Show(MSG);
                        return;
                    }
                    else if (AppVersionLive > AppVersionLocal)
                    {
                        //Database_import.local_to_Live(lblMSg, progressBar1);

                        //string downloadpath = @"\\Ayo\g\Parimal\POS_Win.zip";

                        Uri uriResult;
                        bool result = Uri.TryCreate(downloadpath, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                        if (result == true)
                        {
                            //downloadpath = @"\\Ayo\g\Parimal\POS_Win.zip";

                            Download(downloadpath);
                        }
                        else
                        {
                            IdelTime.WorkingFalg = false;
                            MessageBox.Show("DownLoad URL Not Valid OR Temparary Unavalable");
                            return;
                        }

                    }
                    else
                    {
                        IdelTime.WorkingFalg = false;
                        MessageBox.Show("Application is Upto Date");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    IdelTime.WorkingFalg = false;
                    MessageBox.Show("DownLoad URL Not Valid OR Temparary Unavalable  ");
                    return;
                }


            }
            else
            {
                IdelTime.WorkingFalg = false;
                MessageBox.Show("Check Internet Connection");
                return;
            }
        }

        public void Download(string downloadpath)
        {
            string BackupSource = Application.StartupPath;
            string Datetime = DateTime.Now.ToString("yyyy_MMM_dd_HH_mm");
            string ZipName = Datetime + ".zip";

            //string Destination = Application.StartupPath + @"\update\" + ZipName;

            string Path = "C:\\pos_update\\";
            DeleteDerectry(Path);
            Directory.CreateDirectory(Path);

            string Destination = Path + ZipName;

            progressBar1.Visible = true;
            lblMSg.Visible = true;

            using (WebClient wc = new WebClient())
            {
                lblMSg.Text = "Downloadding ....";
                lblMSg.Refresh();

                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(downloadpath), Destination);
            }
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                int bytesDownloaded = Int32.Parse(e.BytesReceived.ToString());
                int totalBytes = Int32.Parse(e.TotalBytesToReceive.ToString());
                if ((totalBytes / 1024) >= 1024)
                {
                    decimal totalinkb = (totalBytes / 1024);
                    decimal Downloadinkb = (bytesDownloaded / 1024);

                    decimal TotabBype = (totalinkb / 1024);
                    decimal downloadbyte = (Downloadinkb / 1024);

                    TotabBype = Math.Round(TotabBype, 2);
                    downloadbyte = Math.Round(downloadbyte, 2);

                    progressBar1.Value = e.ProgressPercentage;
                    lblStatus.Text = downloadbyte.ToString() + " MB out of " + TotabBype.ToString() + " MB downloaded (" + e.ProgressPercentage.ToString() + "%).";
                }
                else
                {
                    progressBar1.Value = e.ProgressPercentage;
                    lblStatus.Text = (bytesDownloaded / 1024).ToString() + " KB out of " + (totalBytes / 1024).ToString() + " KB downloaded (" + e.ProgressPercentage.ToString() + "%).";
                }
            }
            catch (Exception ex)
            {
                IdelTime.WorkingFalg = false;
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            lblStatus.Text = "-";
            if (e.Cancelled)
            {
                IdelTime.WorkingFalg = false;
                lblMSg.Text = "The download has been cancelled";
                MessageBox.Show("The download has been cancelled");
                return;
            }

            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                IdelTime.WorkingFalg = false;
                MessageBox.Show("An error ocurred while trying to download file");
                return;
            }

            lblMSg.Text = "please Wait Application Prepair to Install";
            lblMSg.Refresh();
            Unzip();
        }

        public void Unzip()
        {
            string BackupSource = "C:\\pos_update\\";
            //DirectoryInfo source = new DirectoryInfo(BackupSource);
            //FileInfo[] sourceFiles = source.GetFiles("*.zip", SearchOption.AllDirectories);
            string[] files = System.IO.Directory.GetFiles(BackupSource, "*.zip");
            string FileName = files[0].ToString();

            lblMSg.Text = "please Wait Application Prepair to Install.... Zip Extract";
            lblMSg.Refresh();
            string ZipSorce = "C:\\pos_update";
            //ZipFile.ExtractToDirectory(FileName, ZipSorce);

            lblMSg.Text = "please Wait Application Prepair to Install.... Remove old Installer";
            lblMSg.Refresh();


            lblMSg.Text = "please Wait Open POS_Installer";
            lblMSg.Refresh();

            bool flag = SyncSetup.IsProgramInstalled("installer");

            if (flag == true)
            {
                string FileVertion = ProductVirsion();
                string Vertioninstalled = IsProgramInstalledProductCode("installer");

                if (FileVertion == Vertioninstalled)
                {
                    open_Installer();
                }
                else
                {
                    bool flagun = UninstallProgram("installer");
                    if (flagun == true)
                    {
                        install();
                        open_Installer();
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("The process Will be continue after installation", "ok", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    install();
                    open_Installer();

                    lblcontinuemsg.Visible = true;
                    lblcontinuemsg.Text = "please Click The Countinue Button";
                    lblcontinuemsg.Refresh();

                    btnContinue.Visible = true;
                    btnContinue.Refresh();

                }
            }
        }

        public void install()
        {
            string AppPath = "C:\\pos_update";
            Process p = new Process();
            p.StartInfo.FileName = AppPath + "\\installer\\installer.msi";
            p.Start();
            p.WaitForExit();
        }

        private bool UninstallProgram(string programDisplayName)
        {
            try
            {
                foreach (var item in Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames())
                {
                    object programName = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("DisplayName");

                    if (string.Equals(programName, programDisplayName))
                    {

                        RegistryKey rgKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item);
                        ProcessStartInfo info = new ProcessStartInfo();
                        Process uninstallProcess = new Process();

                        string dispName = Convert.ToString(rgKey.GetValue("DisplayName"));
                        string uninstlString = Convert.ToString(rgKey.GetValue("UninstallString"));

                        programDisplayName = programDisplayName.ToLower();
                        if (dispName.ToLower().Contains(programDisplayName)) //Put the name of the Application you want to uninstall here
                        {
                            string prdctId = uninstlString.Substring((uninstlString.IndexOf("{")));
                            uninstallProcess.StartInfo.FileName = "MsiExec.exe";//MsiExec.exe /I{BA2BBF02-E09B-4176-A71E-0C42FB61E197}
                            uninstallProcess.StartInfo.Arguments = " /x " + prdctId + " /qr ";
                            uninstallProcess.Start();
                            uninstallProcess.WaitForExit();
                            break;
                        }
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string IsProgramInstalledProductCode(string programDisplayName)
        {

            Console.WriteLine(string.Format("Checking install status of: {0}", programDisplayName));
            foreach (var item in Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames())
            {
                RegistryKey rgKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item);

                string dispName = Convert.ToString(rgKey.GetValue("DisplayName"));
                string version = Convert.ToString(rgKey.GetValue("DisplayVersion"));

                if (string.Equals(dispName, programDisplayName))
                {
                    return version;
                }
            }
            return "";
        }

        public string ProductVirsion()
        {
            Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");
            WindowsInstaller.Installer installer = (WindowsInstaller.Installer)
            Activator.CreateInstance(type);
            string Path = Application.StartupPath + "\\installer\\installer.msi";
            WindowsInstaller.Database db = installer.OpenDatabase(Path, 0);
            WindowsInstaller.View dv = db.OpenView("SELECT `Value` FROM `Property` WHERE `Property`='ProductVersion'");
            WindowsInstaller.Record record = null;
            dv.Execute(record);
            record = dv.Fetch();
            string str = record.get_StringData(1).ToString();
            return str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            open_Installer();
        }

        public void open_Installer()
        {
            Process myProcess = new Process();

            try
            {
                // You can start any process, HelloWorld is a do-nothing example.
                myProcess.StartInfo.FileName = @"C:\Program Files (x86)\POS System\installer\POS_Installer.exe";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                // This code assumes the process you are starting will terminate itself.
                // Given that is is started without a window so you cannot terminate it
                // on the desktop, it must terminate itself or you can do it programmatically
                // from this application using the Kill method.
            }
            catch (Exception Exc)
            {
                Console.WriteLine(Exc.Message);
            }
        }

        public void DELETE_Destination_Directory(string Path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Path);
            if (di.Exists)
            {
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    if (dir.Name == "installer")
                    {
                        dir.Delete(true);
                    }
                }
            }
        }

        public void DeleteDerectry(string Path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Path);

            if (di.Exists)
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }

            if (di.Exists)
            {
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_app();
        }

        public void update_app()
        {
            bool internet = Login.InternetConnection();
            if (internet == true)
            {
                bool CON_Ceck = Login.CheckDBConnection();
                if (CON_Ceck == true)
                {
                    IdelTime.WorkingFalg = true;

                    lblMSg.Text = "please  Wait Data will be Sysncronize First";
                    lblMSg.Refresh();

                    Call_suncro();//only local to Online data
                    Update1();
                }

                else
                {

                }
            }
            else
            {
                MessageBox.Show("Check Internet Connection");
                return;
            }
        }

        #region Sync

        public static void Call_suncro_Up()
        {

            backSyncro.Msg = "please Wait Data will be Sysncronize Started";

            string sqlSync_pos_Delete = "select * from Sync_pos_DELETE where ISSync = 1";
            DataTable dtSync_pos_Delete = Datasyncpso.GetDataTablesyncpso(sqlSync_pos_Delete);
            if (dtSync_pos_Delete.Rows.Count > 0)
            {
                for (int i = 0; i < dtSync_pos_Delete.Rows.Count; i++)
                {
                    try
                    {
                        string Query1 = dtSync_pos_Delete.Rows[i]["Qyery"].ToString();
                        int ID = Convert.ToInt32(dtSync_pos_Delete.Rows[i]["ID"]);
                        string Dicstring = EncryptionClass.Decrypt(Query1);
                        //SyncQuery += Dicstring + ";";                       
                        bool falg = Database_import.runsql_Live(Dicstring);
                        if (falg == true)
                        {
                            string sqlUpdate = "Update Sync_pos_DELETE set ISSync = 0 where ID =" + ID;
                            Datasyncpso.ExecuteSQLsyncpso(sqlUpdate);
                        }

                    }
                    catch
                    {

                    }
                }
            }

            string sql = "select * from Sync_pos where ISSync = 1";
            DataTable dt = Datasyncpso.GetDataTablesyncpso(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string Query = dt.Rows[i]["Qyery"].ToString();
                        int ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                        string Dicstring = EncryptionClass.Decrypt(Query);
                        //SyncQuery += Dicstring + ";";
                        bool falg = Database_import.runsql_Live(Dicstring);
                        if (falg == true)
                        {
                            string sqlupdate = "Update Sync_pos set ISSync = 0 where ID =" + ID;
                            Datasyncpso.ExecuteSQLsyncpso(sqlupdate);
                        }

                    }
                    catch
                    {

                    }

                }
            }

            string sqlSync_pos_Update = "select * from Sync_pos_Update where ISSync = 1";
            DataTable dtSync_pos_Update = Datasyncpso.GetDataTablesyncpso(sqlSync_pos_Update);
            if (dtSync_pos_Update.Rows.Count > 0)
            {
                for (int i = 0; i < dtSync_pos_Update.Rows.Count; i++)
                {
                    try
                    {
                        string Query1 = dtSync_pos_Update.Rows[i]["Qyery"].ToString();
                        int ID = Convert.ToInt32(dtSync_pos_Update.Rows[i]["ID"]);
                        string Dicstring = EncryptionClass.Decrypt(Query1);
                        //SyncQuery += Dicstring + ";";                       
                        bool falg = Database_import.runsql_Live(Dicstring);
                        if (falg == true)
                        {
                            string sqlUpdate = "Update Sync_pos_Update set ISSync = 0 where ID =" + ID;
                            Datasyncpso.ExecuteSQLsyncpso(sqlUpdate);
                        }

                    }
                    catch
                    {

                    }
                }
            }

        }
        public static void Call_suncro()
        {

            backSyncro.Msg = "please Wait Data will be Sysncronize Started";

            string sql = "select * from Sync_pos where ISSync = 1";
            DataTable dt = Datasyncpso.GetDataTablesyncpso(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        if (backSyncro.isRun == true)
                        {
                            string Query = dt.Rows[i]["Qyery"].ToString();
                            int ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                            string Dicstring = EncryptionClass.Decrypt(Query);
                            //SyncQuery += Dicstring + ";";
                            bool falg = Database_import.runsql_Live(Dicstring);
                            if (falg == true)
                            {
                                string sqlupdate = "Update Sync_pos set ISSync = 0 where ID =" + ID;
                                Datasyncpso.ExecuteSQLsyncpso(sqlupdate);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }

        }

        public static void DBSyncro(int TenentID)
        {
            bool Falginternet = Login.InternetConnection();

            if (Falginternet == false)
            {
                MessageBox.Show("Internet Connection Not Avalable");
                return;
            }

            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == false)
            {
                MessageBox.Show("online Server Connection Fail");
                return;
            }


            int Totalcount = 0;
            int currentCount = 0;

            Call_suncro();

            // mycompanysetup_winapp  1

            backSyncro.Msg = " System is Synchronizing your company setup Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                string Mac = Login.GetMACAddress();
                List<Win_mycompanysetup_winapp> Listmycompanysetup = DB.Win_mycompanysetup_winapp.Where(p => p.TenentID == TenentID && p.Mac_Addr.Contains(Mac)).ToList();
                Totalcount = Listmycompanysetup.Count();
                currentCount = 0;
                foreach (Win_mycompanysetup_winapp items in Listmycompanysetup)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdupdate = "update mycompanysetup_winapp set COMPNAME1='" + items.COMPNAME1 + "',COMPNAME2='" + items.COMPNAME2 + "', " +
                                      " COMPNAME3='" + items.COMPNAME3 + "',COUNTRYID='" + items.COUNTRYID + "', " +
                                      " DefaultLanguage='" + items.DefaultLanguage + "',AllowUser='" + items.AllowUser + "' " +
                                      " where TenentID= " + TenentID + " and Shopid = '" + items.Shopid + "' and Mac_Addr ='" + items.Mac_Addr + "' ;";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdupdate);

                        if (Falg != 1)
                        {

                            string sqlinsert = "insert into mycompanysetup_winapp " +
                                               " (TenentID, Shopid, TenentGroupID ,COMPNAME1 , COMPNAME2 ,  COMPNAME3, COUNTRYID , Mac_Addr,DefaultLanguage,AllowUser) " +
                                               "  select " + TenentID + ",'" + items.Shopid + "'," + items.TenentGroupID + ",'" + items.COMPNAME1 + "','" + items.COMPNAME2 + "', " +
                                               " '" + items.COMPNAME3 + "'," + items.COUNTRYID + ",'" + items.Mac_Addr + "','" + items.DefaultLanguage + "', '" + items.AllowUser + "' " +
                                               "  where not exists ( SELECT * from mycompanysetup_winapp  WHERE TenentID= " + TenentID + " and Shopid = '" + items.Shopid + "' and Mac_Addr ='" + items.Mac_Addr + "' );";
                            DataAccess.ExecuteSQL(sqlinsert);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in mycompanysetup_winapp query :" + ex.Message);
            }

            // storeconfig  2

            backSyncro.Msg = " System is Synchronizing your store config Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_storeconfig> LisStore = DB.Win_storeconfig.Where(p => p.TenentID == TenentID).ToList();
                Totalcount = LisStore.Count();
                currentCount = 0;

                foreach (Win_storeconfig itemstore in LisStore)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmd = "Select * from  storeconfig  where TenentID =" + TenentID + " and companyname  = '" + itemstore.companyname + "' ";
                        DataAccess.ExecuteSQL(sqlCmd);
                        DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                        if (dt1.Rows.Count < 1)
                        {
                            string sqlstoreconfig = "Select * from storeconfig";
                            DataAccess.ExecuteSQL(sqlstoreconfig);
                            DataTable dtstoreconfig = DataAccess.GetDataTable(sqlstoreconfig);
                            int id = 1;
                            if (dtstoreconfig.Rows.Count > 0)
                            {
                                int ID = Convert.ToInt32(dtstoreconfig.Rows[0]["id"]);
                                id = (ID + 1);
                            }
                            string Sqlinsert = "insert into storeconfig (TenentID, id, companyname, companyaddress,companyphone,vatno,web,vatrate,disrate,footermsg,FaceBook,Twitter,Insta,DbPath,ImgPath,InvAddtionalLine,Logo) " +
                           "  values( " + TenentID + ", " + id + ",'" + itemstore.companyname + "', '" + itemstore.companyaddress + "', '" + itemstore.companyphone + "', '" + itemstore.vatno + "','" + itemstore.web + "', " +
                                    " '" + itemstore.vatrate + "', '" + itemstore.disrate + "' , '" + itemstore.footermsg + "',   " +
                                    " '" + itemstore.footermsg + "', '" + itemstore.Twitter + "' , '" + itemstore.Insta + "',   " +
                                    " '" + itemstore.DbPath + "', '" + itemstore.ImgPath + "','" + itemstore.InvAddtionalLine + "','" + itemstore.Logo + "' )";
                            DataAccess.ExecuteSQL(Sqlinsert);
                        }
                        else
                        {
                            string sql = "update storeconfig set companyname= '" + itemstore.companyname + "', companyaddress = '" + itemstore.companyaddress + "', " +
                           " companyphone = '" + itemstore.companyphone + "', vatno = '" + itemstore.vatno + "' , web = '" + itemstore.web + "' ,    " +
                            " vatrate = '" + itemstore.vatrate + "', disrate = '" + itemstore.disrate + "' , footermsg = '" + itemstore.footermsg + "' ,   " +
                            " FaceBook = '" + itemstore.FaceBook + "', Twitter = '" + itemstore.Twitter + "' , Insta = '" + itemstore.Insta + "' , InvAddtionalLine='" + itemstore.InvAddtionalLine + "',  " +
                             " DbPath = '" + itemstore.DbPath + "', ImgPath = '" + itemstore.ImgPath + "', Logo='" + itemstore.Logo + "', " +
                           " UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null  where TenentID = " + TenentID + " and  companyname  = '" + itemstore.companyname + "' ";
                            DataAccess.ExecuteSQL(sql);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in storeconfig query :" + ex.Message);
            }


            // tbl_terminallocation  3

            backSyncro.Msg = " System is Synchronizing your terminal Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_terminalLocation> Listterminal = DB.Win_tbl_terminalLocation.Where(p => p.TenentID == TenentID).ToList();
                Totalcount = Listterminal.Count();
                currentCount = 0;
                foreach (Win_tbl_terminalLocation itemterminal in Listterminal)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        //remove this one sahir
                        string sqlCmd = "Select * from  tbl_terminallocation  where TenentID =" + TenentID + " and Shopid = '" + itemterminal.Shopid + "' ";
                        DataAccess.ExecuteSQL(sqlCmd);
                        DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                        if (dt1.Rows.Count < 1)
                        {
                            //combine in one procedure sahir Insert_tbl_terminallocation
                            string sqlinsert = " insert into tbl_terminallocation " +
                                               "(TenentID,ID,Shopid,Terminal_Type, CompanyName, Branchname , Location ,Phone , Email ,  Web, VAT , Dis , " +
                                               " VATRegiNo , Footermsg,FaceBook,Twitter,Insta,InvAddtionalLine,DbPath,ImgPath,syncAfter,dayofSync,Salesync) " +
                                               " values (" + TenentID + "," + itemterminal.ID + ",'" + itemterminal.Shopid + "' , '" + itemterminal.Terminal_Type + "' , '" + itemterminal.CompanyName + "' , '" + itemterminal.Branchname + "' , " +
                                               " '" + itemterminal.Location + "' , '" + itemterminal.Phone + "' , '" + itemterminal.Email + "' ," +
                                               " '" + itemterminal.Web + "',  '" + itemterminal.VAT + "', " +
                                               " '" + itemterminal.Dis + "' , '" + itemterminal.VATRegiNo + "',  '" + itemterminal.Footermsg + "' ," +
                                               " '" + itemterminal.FaceBook + "','" + itemterminal.Twitter + "','" + itemterminal.Insta + "','" + itemterminal.InvAddtionalLine + "'," +
                                               " '" + itemterminal.DbPath + "',  '" + itemterminal.ImgPath + "'," + itemterminal.syncAfter + "," + itemterminal.dayofSync + " , " + itemterminal.Salesync + " )";
                            DataAccess.ExecuteSQL(sqlinsert);
                        }
                        else
                        {
                            string sql = "update tbl_terminallocation set Terminal_Type = '" + itemterminal.Terminal_Type + "', Branchname = '" + itemterminal.Branchname + "', Location = '" + itemterminal.Location + "', " +
                               " Email = '" + itemterminal.Email + "' , Phone = '" + itemterminal.Phone + "', VAT = '" + itemterminal.VAT + "' , Web = '" + itemterminal.Web + "' ,    " +
                               " Dis = '" + itemterminal.Dis + "', VATRegiNo = '" + itemterminal.VATRegiNo + "' , Footermsg = '" + itemterminal.Footermsg + "' ,   " +
                               " CompanyName = '" + itemterminal.CompanyName + "' , FaceBook = '" + itemterminal.FaceBook + "', Twitter = '" + itemterminal.Twitter + "', Insta = '" + itemterminal.Insta + "' ,InvAddtionalLine= '" + itemterminal.InvAddtionalLine + "' ,   " +
                               " DbPath = '" + itemterminal.DbPath + "', ImgPath = '" + itemterminal.ImgPath + "',syncAfter = " + itemterminal.syncAfter + ",dayofSync = " + itemterminal.dayofSync + " , Salesync = " + itemterminal.Salesync + " ," +
                               " UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null  where TenentID = " + TenentID + " and Shopid = '" + itemterminal.Shopid + "' ";
                            DataAccess.ExecuteSQL(sql);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_terminallocation query :" + ex.Message);
            }


            // usermgt  4

            backSyncro.Msg = " System is Synchronizing your user Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_usermgt> Listuser = DB.Win_usermgt.Where(p => p.TenentID == TenentID).ToList();
                Totalcount = Listuser.Count();
                currentCount = 0;
                foreach (Win_usermgt itemuser in Listuser)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        //remove this sahir
                        string sql3 = "select * from usermgt where TenentID =" + TenentID + " and Username= '" + itemuser.Username + "' and password= '" + itemuser.password + "' ";
                        DataAccess.ExecuteSQL(sql3);
                        DataTable dt1 = DataAccess.GetDataTable(sql3);

                        if (dt1.Rows.Count < 1)
                        {
                            //one procedure for insert update sahir Insert_UserMgt
                            string sql1 = "insert into usermgt (TenentID,id, Name, Father_name, Address, Email , Contact, DOB , Username , password , usertype , position , imagename, Shopid ) " +
                                             "  values(" + TenentID + "," + itemuser.id + " , '" + itemuser.Name + "', '" + itemuser.Father_name + "', '" + itemuser.Address + "', '" + itemuser.Email + "', " +
                                             " '" + itemuser.Contact + "',  '" + itemuser.DOB + "', '" + itemuser.Username + "', '" + itemuser.password + "', " +
                                             " '" + itemuser.usertype + "', '" + itemuser.position + "' , '" + itemuser.imagename + "' , '" + itemuser.Shopid + "')";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        else
                        {
                            string sql = "UPDATE usermgt set  Name = '" + itemuser.Name + "', Father_name = '" + itemuser.Father_name + "', " +
                                " Address = '" + itemuser.Address + "', Email = '" + itemuser.Email + "', Contact = '" + itemuser.Contact + "', " +
                                " DOB = '" + itemuser.DOB + "' , Username= '" + itemuser.Username + "', password = '" + itemuser.password + "',imagename = '" + itemuser.imagename + "' ,    " +
                                " usertype    = '" + itemuser.usertype + "', position = '" + itemuser.position + "', Shopid = '" + itemuser.Shopid + "',UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null " +
                                " where TenentID =" + TenentID + " and Username= '" + itemuser.Username + "' and password= '" + itemuser.password + "'";
                            DataAccess.ExecuteSQL(sql);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in usermgt query :" + ex.Message);
            }


            // CAT_MST  5

            backSyncro.Msg = " System is Synchronizing your Catagory Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<CAT_MST> ListCAT_MST = DB.CAT_MST.Where(p => p.TenentID == TenentID).ToList();
                Totalcount = ListCAT_MST.Count();
                currentCount = 0;
                foreach (CAT_MST itemCAT_MST in ListCAT_MST)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdupdate = "update CAT_MST set CAT_TYPE = 'WEBSALE', DefaultPic='" + itemCAT_MST.DefaultPic + "',SHORT_NAME='" + itemCAT_MST.SHORT_NAME + "', " +
                                           " CAT_NAME1='" + itemCAT_MST.CAT_NAME1 + "',CAT_NAME2='" + itemCAT_MST.CAT_NAME2 + "', " +
                                           " DisplaySort='" + itemCAT_MST.DisplaySort + "',AlwaysShow='" + itemCAT_MST.AlwaysShow + "' " +
                                           " where TenentID =" + TenentID + " and CATID='" + itemCAT_MST.CATID + "' ;";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdupdate);

                        if (Falg != 1)
                        {
                            string sqlCmd = "insert into CAT_MST " +
                                       " (TenentID,CATID,PARENT_CATID, SHORT_NAME,CAT_NAME1,CAT_NAME2,CAT_NAME3,CAT_TYPE,DefaultPic,DisplaySort,AlwaysShow,COLOR_NAME) " +
                                       "  select " + TenentID + "," + itemCAT_MST.CATID + ",'" + itemCAT_MST.PARENT_CATID + "','" + itemCAT_MST.SHORT_NAME + "','" + itemCAT_MST.CAT_NAME1 + "','" + itemCAT_MST.CAT_NAME2 + "','" + itemCAT_MST.CAT_NAME3 + "','WEBSALE','" + itemCAT_MST.DefaultPic + "', " +
                                       "  '" + itemCAT_MST.DisplaySort + "' , '" + itemCAT_MST.AlwaysShow + "','" + itemCAT_MST.COLOR_NAME + "' " +
                                       "  where not exists ( SELECT * from CAT_MST  WHERE TenentID =" + TenentID + " and CATID = " + itemCAT_MST.CATID + " );";
                            DataAccess.ExecuteSQL(sqlCmd);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in CAT_MST query :" + ex.Message);
            }

            // purchase  6
            backSyncro.Msg = " System is Synchronizing your purchase Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_purchase> Listpurchase = DB.Win_purchase.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listpurchase.Count();
                currentCount = 0;
                foreach (Win_purchase itempurchase in Listpurchase)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int BaseUOM = itempurchase.BaseUOM != null ? Convert.ToInt32(itempurchase.BaseUOM) : 0;
                        int IsPerishable = itempurchase.IsPerishable != null ? Convert.ToInt32(itempurchase.IsPerishable) : 0;
                        string sqlCmdUpdate = " update purchase set product_name='" + itempurchase.product_name + "' , category='" + itempurchase.category + "' , " +
                                              " supplier='" + itempurchase.supplier + "' , imagename='" + itempurchase.imagename + "' , taxapply='" + itempurchase.taxapply + "' , Shopid='" + itempurchase.Shopid + "' , " +
                                              " status='" + itempurchase.status + "' , product_name_Arabic='" + itempurchase.product_name_Arabic + "' , category_arabic='" + itempurchase.category_arabic + "', " +
                                              " ExpiryDate = '" + itempurchase.ExpiryDate + "', IsPerishable = '" + IsPerishable + "' , CustItemCode = '" + itempurchase.CustItemCode + "', BarCode = '" + itempurchase.BarCode + "' , BaseUOM = '" + BaseUOM + "'  " +
                                              " where TenentID =" + TenentID + " and product_id='" + itempurchase.product_id + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sqlCmd = " insert into purchase " +
                                            " (TenentID, product_id ,UOM, product_name ,product_name_print," +
                                            " supplier , category , imagename, taxapply, Shopid, status,product_name_Arabic,category_arabic,ExpiryDate,	IsPerishable,CustItemCode,BarCode,BaseUOM) " +
                                            "  select " + TenentID + ",'" + itempurchase.product_id + "' ,'" + itempurchase.UOM + "' , '" + itempurchase.product_name + "','" + itempurchase.product_name_print + "',  " +
                                            " '" + itempurchase.supplier + "', '" + itempurchase.category + "', '" + itempurchase.imagename + "' , " +
                                            " '" + itempurchase.taxapply + "' , '" + itempurchase.Shopid + "', '" + itempurchase.status + "', '" + itempurchase.product_name_Arabic + "', '" + itempurchase.category_arabic + "' , " +
                                            " '" + itempurchase.ExpiryDate + "' , '" + IsPerishable + "','" + itempurchase.CustItemCode + "','" + itempurchase.BarCode + "', '" + BaseUOM + "'  " +
                                            " where not exists ( SELECT * from purchase  WHERE TenentID =" + TenentID + " and product_id='" + itempurchase.product_id + "');";
                            DataAccess.ExecuteSQL(sqlCmd);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in purchase query :" + ex.Message);
            }

            // tbl_item_uom_price  7
            backSyncro.Msg = " System is Synchronizing your item uom price Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_item_uom_price> Listuom_price = DB.Win_tbl_item_uom_price.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listuom_price.Count();
                currentCount = 0;
                foreach (Win_tbl_item_uom_price item_uom_price in Listuom_price)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        decimal total_cost_price = item_uom_price.total_cost_price != null ? Convert.ToDecimal(item_uom_price.total_cost_price) : 0;
                        decimal total_retail_price = item_uom_price.total_retail_price != null ? Convert.ToDecimal(item_uom_price.total_retail_price) : 0;
                        int recNo = item_uom_price.recNo != null ? Convert.ToInt32(item_uom_price.recNo) : 0;
                        decimal Discount = item_uom_price.Discount != null ? Convert.ToDecimal(item_uom_price.Discount) : 0;

                        string sql1Update = "update tbl_item_uom_price set OpQty = '" + item_uom_price.OpQty + "',OnHand = '" + item_uom_price.OnHand + "', " +
                                      " QtyOut = '" + item_uom_price.QtyOut + "',QtyConsumed = '" + item_uom_price.QtyConsumed + "', QtyReserved = '" + item_uom_price.QtyReserved + "', " +
                                      " QtyRecived = '" + item_uom_price.QtyRecived + "' , Deleted = '" + item_uom_price.Deleted + "',Discount='" + Discount + "' , " +
                                      " price = '" + item_uom_price.price + "' , msrp = '" + item_uom_price.msrp + "' , " +
                                      " minQty ='" + item_uom_price.minQty + "' , MaxQty = '" + item_uom_price.MaxQty + "' ,total_cost_price = '" + total_cost_price + "' , " +
                                      " RecipeType = '" + item_uom_price.RecipeType + "' , recNo = " + recNo + " , " +
                                      " total_retail_price = '" + total_retail_price + "' , ExpiryDate = '" + item_uom_price.ExpiryDate + "' " +
                                      " where TenentID =" + TenentID + " and itemID='" + item_uom_price.itemID + "' and UOMID='" + item_uom_price.UOMID + "'";
                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_item_uom_price " +
                                           " (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,price,msrp,Deleted,minQty,MaxQty,Discount,total_cost_price,total_retail_price,ExpiryDate,RecipeType,recNo) " +
                                           "  select " + TenentID + "," + item_uom_price.ID + ",'" + item_uom_price.itemID + "', '" + item_uom_price.UOMID + "', '" + item_uom_price.OpQty + "', '" + item_uom_price.OnHand + "' , " +
                                             " '" + item_uom_price.QtyOut + "', '" + item_uom_price.QtyConsumed + "', '" + item_uom_price.QtyReserved + "', '" + item_uom_price.QtyRecived + "', " +
                                             " '" + item_uom_price.price + "', '" + item_uom_price.msrp + "','" + item_uom_price.Deleted + "', '" + item_uom_price.minQty + "', '" + item_uom_price.MaxQty + "', '" + Discount + "', " +
                                             " '" + total_cost_price + "','" + total_retail_price + "','" + item_uom_price.ExpiryDate + "','" + item_uom_price.RecipeType + "' , " + recNo + " " +
                                           "  where not exists ( SELECT * from tbl_item_uom_price  WHERE TenentID =" + TenentID + " and itemID='" + item_uom_price.itemID + "' and UOMID='" + item_uom_price.UOMID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_item_uom_price query :" + ex.Message);
            }

            // tbl_customer  8
            backSyncro.Msg = " System is Synchronizing your customer Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_customer> Listcustomer = DB.Win_tbl_customer.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listcustomer.Count();
                currentCount = 0;
                foreach (Win_tbl_customer itemCustomer in Listcustomer)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlUpdateCmd = "update tbl_customer set Name = '" + itemCustomer.Name + "', NameArabic= '" + itemCustomer.NameArabic + "' , EmailAddress= '" + itemCustomer.EmailAddress + "', " +
                                     " address = '" + itemCustomer.Address + "', Phone = '" + itemCustomer.Phone + "', City = '" + itemCustomer.City + "' , PeopleType = '" + itemCustomer.PeopleType + "', " +
                                     " Facebook= '" + itemCustomer.Facebook + "', Twitter= '" + itemCustomer.Twitter + "', Insta= '" + itemCustomer.Insta + "', DateOfBirth = '" + itemCustomer.DateOfBirth + "', DateOfBirth = '" + itemCustomer.DateOfAnniversary + "' , Remark = '" + itemCustomer.Remark + "', " +
                                     "UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null   where TenentID = " + TenentID + " and ID='" + itemCustomer.ID + "'";
                        int Falg = DataAccess.ExecuteSQL(sqlUpdateCmd);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_customer " +
                                       " (TenentID,ID, Name, EmailAddress, Phone, address, City, PeopleType,Facebook,Twitter,Insta,NameArabic,DateOfBirth,DateOfBirth,Remark) " +
                                       "  select " + TenentID + ",'" + itemCustomer.ID + "','" + itemCustomer.Name + "', '" + itemCustomer.EmailAddress + "', '" + itemCustomer.Phone + "', '" + itemCustomer.Address + "', " +
                                       " '" + itemCustomer.City + "', '" + itemCustomer.PeopleType + "', '" + itemCustomer.Facebook + "', '" + itemCustomer.Twitter + "', '" + itemCustomer.Insta + "', '" + itemCustomer.NameArabic + "','" + itemCustomer.DateOfBirth + "','" + itemCustomer.DateOfAnniversary + "','" + itemCustomer.Remark + "' " +
                                       "  where not exists ( SELECT * from tbl_customer  WHERE TenentID =" + TenentID + " and ID='" + itemCustomer.ID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_customer query :" + ex.Message);
            }

            // tbl_purchase_history  9
            backSyncro.Msg = " System is Synchronizing your purchase history Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_purchase_history> Listpurchase_history = DB.Win_tbl_purchase_history.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listpurchase_history.Count();
                currentCount = 0;
                foreach (Win_tbl_purchase_history item_history in Listpurchase_history)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int MYTRANSID = item_history.MYTRANSID != null ? Convert.ToInt32(item_history.MYTRANSID) : 0;
                        string sqlpur = " update tbl_purchase_history  set product_id='" + item_history.product_id + "', product_name='" + item_history.product_name + "', product_quantity = '" + item_history.product_quantity + "' ,  retail_price='" + item_history.retail_price + "', " +
                                         " cost_price='" + item_history.cost_price + "', category='" + item_history.category + "',supplier='" + item_history.supplier + "', purchase_date='" + item_history.purchase_date + "',Shopid='" + item_history.Shopid + "', ptype='" + item_history.ptype + "', " +
                                         " uom='" + item_history.UOM + "' , ExpiryDate = '" + item_history.ExpiryDate + "' , TotalCost_price = '" + item_history.TotalCost_price + "', MYTRANSID = '" + MYTRANSID + "', InvoiceNO = '" + item_history.InvoiceNO + "', TranStatus = '" + item_history.TranStatus + "',Remarks = '" + item_history.Remarks + "'  " +
                                         " where TenentID = " + TenentID + " and id='" + item_history.id + "' ";

                        int Falg = DataAccess.ExecuteSQL(sqlpur);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_purchase_history " +
                                           " (TenentID,id, product_id, product_name,product_quantity,retail_price, cost_price, category,supplier, purchase_date, Shopid, ptype,uom,ExpiryDate,TotalCost_price,MYTRANSID,InvoiceNO,TranStatus,Remarks ) " +
                                           "  select " + TenentID + "," + item_history.id + ",'" + item_history.product_id + "', '" + item_history.product_name + "', '" + item_history.product_quantity + "' , '" + item_history.retail_price + "', '" + item_history.cost_price + "', '" + item_history.category + "', " +
                                            "  '" + item_history.supplier + "', '" + item_history.purchase_date + "' ,'" + item_history.Shopid + "', '" + item_history.ptype + "','" + item_history.UOM + "','" + item_history.ExpiryDate + "','" + item_history.TotalCost_price + "' , '" + MYTRANSID + "','" + item_history.InvoiceNO + "','" + item_history.TranStatus + "','" + item_history.Remarks + "' " +
                                           "  where not exists ( SELECT * from tbl_purchase_history  WHERE TenentID =" + TenentID + " and id='" + item_history.id + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_purchase_history query :" + ex.Message);
            }

            // sales_item  10
            backSyncro.Msg = " System is Synchronizing your sales Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_sales_item> Listsales_item = DB.Win_sales_item.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listsales_item.Count();
                currentCount = 0;
                foreach (Win_sales_item itemsales in Listsales_item)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int COD = itemsales.COD != null ? Convert.ToInt32(itemsales.COD) : 0;
                        decimal OrderTotal = itemsales.OrderTotal != null ? Convert.ToDecimal(itemsales.OrderTotal) : 0;

                        string sql1update = " Update sales_item set itemName='" + itemsales.itemName + "',Qty='" + itemsales.Qty + "',RetailsPrice='" + itemsales.RetailsPrice + "', " +
                             " Total='" + itemsales.Total + "', profit='" + itemsales.profit + "',sales_time='" + itemsales.sales_time + "', itemcode='" + itemsales.itemcode + "' , " +
                             " discount='" + itemsales.discount + "', taxapply='" + itemsales.taxapply + "', status='" + itemsales.status + "',UOM='" + itemsales.UOM + "', " +
                             " Customer='" + itemsales.Customer + "',InvoiceNO='" + itemsales.InvoiceNO + "',returnQty='" + itemsales.returnQty + "',returnTotal='" + itemsales.returnTotal + "' , " +
                             " product_name_print = '" + itemsales.product_name_print + "' , ExpiryDate = '" + itemsales.ExpiryDate + "', SoldBy = '" + itemsales.SoldBy + "' , " +
                             " OrderStutas = '" + itemsales.OrderStutas + "', Driver = '" + itemsales.Driver + "' ,COD = '" + COD + "' , OrderTotal = '" + OrderTotal + "' ,  " +
                             " PaymentMode = '" + itemsales.PaymentMode + "', Shopid = '" + itemsales.Shopid + "' , c_id = '" + itemsales.c_id + "' , BatchNo = '" + itemsales.BatchNo + "', OrderWay = '" + itemsales.OrderWay + "', " +
                             " CustItemCode = '" + itemsales.CustItemCode + "',BarCode= '" + itemsales.BarCode + "',ISPaymentCredit = '" + itemsales.ISPaymentCredit + "', Remarks = '" + itemsales.Remarks + "' " +
                             " where TenentID =" + TenentID + " and sales_id='" + itemsales.sales_id + "' and item_id='" + itemsales.item_id + "' and UOM='" + itemsales.UOM + "' and BatchNo='" + itemsales.BatchNo + "' and Shopid = '" + itemsales.Shopid + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sql1update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into sales_item " +
                                          " (TenentID, item_id, sales_id,itemName,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, status,UOM,Customer,InvoiceNO,returnQty,returnTotal, " +
                                          " product_name_print,ExpiryDate,SoldBy,OrderStutas,Driver,COD,OrderTotal,PaymentMode,Shopid,c_id,BatchNo,OrderWay,CustItemCode,BarCode,ISPaymentCredit ,Remarks ) " +
                                          "  select " + TenentID + ", '" + itemsales.item_id + "' ,'" + itemsales.sales_id + "', '" + itemsales.itemName + "', '" + itemsales.Qty + "', '" + itemsales.RetailsPrice + "', '" + itemsales.Total + "', '" + itemsales.profit + "', " +
                                          " '" + itemsales.sales_time + "','" + itemsales.itemcode + "','" + itemsales.discount + "','" + itemsales.taxapply + "','" + itemsales.status + "','" + itemsales.UOM + "', " +
                                          " '" + itemsales.Customer + "','" + itemsales.InvoiceNO + "','" + itemsales.returnQty + "','" + itemsales.returnTotal + "','" + itemsales.product_name_print + "' ,'" + itemsales.ExpiryDate + "' , " +
                                          " '" + itemsales.SoldBy + "','" + itemsales.OrderStutas + "','" + itemsales.Driver + "','" + COD + "','" + OrderTotal + "', '" + itemsales.PaymentMode + "', " +
                                          " '" + itemsales.Shopid + "','" + itemsales.c_id + "','" + itemsales.BatchNo + "','" + itemsales.OrderWay + "','" + itemsales.CustItemCode + "','" + itemsales.BarCode + "','" + itemsales.ISPaymentCredit + "', '" + itemsales.Remarks + "'  " +
                                          "  where not exists ( SELECT * from sales_item  WHERE TenentID =" + TenentID + " and sales_id='" + itemsales.sales_id + "' and item_id='" + itemsales.item_id + "' and UOM='" + itemsales.UOM + "' and BatchNo='" + itemsales.BatchNo + "' and Shopid = '" + itemsales.Shopid + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in sales_item query :" + ex.Message);
            }

            // sales_payment 11
            backSyncro.Msg = " System is Synchronizing your sales payment Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_sales_payment> Listpayment = DB.Win_sales_payment.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listpayment.Count();
                currentCount = 0;

                foreach (Win_sales_payment itempayment in Listpayment)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        decimal Delivery_Cahrge = itempayment.Delivery_Cahrge != null ? Convert.ToDecimal(itempayment.Delivery_Cahrge) : 0;

                        string sql1Update = " Update sales_payment set return_id='" + itempayment.return_id + "', payment_type='" + itempayment.payment_type + "',Reffrance='" + itempayment.Reffrance + "', " +
                                    " payment_amount='" + itempayment.payment_amount + "',change_amount='" + itempayment.change_amount + "',due_amount='" + itempayment.due_amount + "', dis='" + itempayment.dis + "', vat='" + itempayment.vat + "', " +
                                    " sales_time='" + itempayment.sales_time + "',c_id='" + itempayment.c_id + "',emp_id='" + itempayment.emp_id + "',comment='" + itempayment.comment + "', TrxType='" + itempayment.TrxType + "', " +
                                    " Shopid='" + itempayment.Shopid + "', ovdisrate='" + itempayment.ovdisrate + "', vaterate='" + itempayment.vaterate + "',InvoiceNO='" + itempayment.InvoiceNO + "',Customer='" + itempayment.Customer + "' , " +
                                    " Delivery_Cahrge = '" + itempayment.Delivery_Cahrge + "' , PaymentStutas = '" + itempayment.PaymentStutas + "', AmountSplit = '" + itempayment.AmountSplit + "', SaleDt = '" + itempayment.SaleDt + "' " +
                                    "   where TenentID =" + TenentID + " and sales_id='" + itempayment.sales_id + "' and payment_type='" + itempayment.payment_type + "' and Shopid = '" + itempayment.Shopid + "' ";

                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into sales_payment " +
                                           " (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                           " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Delivery_Cahrge,PaymentStutas,AmountSplit,SaleDt ) " +
                                           "  select " + TenentID + ",'" + itempayment.ID + "','" + itempayment.sales_id + "','" + itempayment.return_id + "','" + itempayment.payment_type + "','" + itempayment.Reffrance + "' , " +
                                           " '" + itempayment.payment_amount + "', '" + itempayment.change_amount + "', " +
                                           " '" + itempayment.due_amount + "', '" + itempayment.dis + "', '" + itempayment.vat + "', '" + itempayment.sales_time + "', '" + itempayment.c_id + "', " +
                                           " '" + itempayment.emp_id + "','" + itempayment.comment + "','" + itempayment.TrxType + "','" + itempayment.Shopid + "' , '" + itempayment.ovdisrate + "' , " +
                                           " '" + itempayment.vaterate + "','" + itempayment.InvoiceNO + "','" + itempayment.Customer + "','" + Delivery_Cahrge + "','" + itempayment.PaymentStutas + "','" + itempayment.AmountSplit + "','" + itempayment.SaleDt + "' " +
                                           "  where not exists ( SELECT * from sales_payment  WHERE TenentID =" + TenentID + " and sales_id='" + itempayment.sales_id + "' and payment_type='" + itempayment.payment_type + "' and Shopid = '" + itempayment.Shopid + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in sales_payment query :" + ex.Message);
            }


            // return_item  12
            backSyncro.Msg = " System is Synchronizing your return item Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_return_item> Listreturn = DB.Win_return_item.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listreturn.Count();
                currentCount = 0;
                foreach (Win_return_item intemreturn in Listreturn)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int IsWastage = intemreturn.IsWastage != null ? Convert.ToInt32(intemreturn.IsWastage) : 0;

                        string sql1Update = " update return_item set  itemName='" + intemreturn.itemName + "', Qty='" + intemreturn.Qty + "', RetailsPrice ='" + intemreturn.RetailsPrice + "', " +
                            " Total='" + intemreturn.Total + "', return_time='" + intemreturn.return_time + "', custno='" + intemreturn.custno + "', emp='" + intemreturn.emp + "', " +
                            " SoldInvoiceNo='" + intemreturn.SoldInvoiceNo + "', Comment='" + intemreturn.Comment + "', disamt='" + intemreturn.disamt + "' , " +
                            " vatamt='" + intemreturn.vatamt + "',UOM='" + intemreturn.UOM + "',Customer='" + intemreturn.Customer + "' , ExpiryDate = '" + intemreturn.ExpiryDate + "', " +
                            " ReturnReason = '" + intemreturn.ReturnReason + "', IsWastage = '" + intemreturn.IsWastage + "' , BatchNo = '" + intemreturn.BatchNo + "' " +
                            "  where TenentID =" + TenentID + " and return_id='" + intemreturn.return_id + "' and item_id='" + intemreturn.item_id + "' and UOM='" + intemreturn.UOM + "' and BatchNo='" + intemreturn.BatchNo + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into return_item " +
                                          " (TenentID,ID, return_id,item_id, itemName, Qty, RetailsPrice, Total, return_time, custno, emp, SoldInvoiceNo, Comment, disamt , vatamt,UOM,Customer, " +
                                          " ExpiryDate,ReturnReason,IsWastage,BatchNo) " +
                                          "  select " + TenentID + ",'" + intemreturn.ID + "'," + intemreturn.return_id + ", '" + intemreturn.item_id + "', '" + intemreturn.itemName + "', '" + intemreturn.Qty + "', " +
                                          " '" + intemreturn.RetailsPrice + "' , '" + intemreturn.Total + "', '" + intemreturn.return_time + "',   " +
                                          " '" + intemreturn.custno + "', '" + intemreturn.emp + "' , '" + intemreturn.SoldInvoiceNo + "',  " +
                                          " '" + intemreturn.Comment + "', '" + intemreturn.disamt + "', '" + intemreturn.vatamt + "', '" + intemreturn.UOM + "' ,'" + intemreturn.Customer + "', " +
                                          " '" + intemreturn.ExpiryDate + "','" + intemreturn.ReturnReason + "' ,'" + IsWastage + "','" + intemreturn.BatchNo + "' " +
                                          "  where not exists ( SELECT * from return_item  WHERE TenentID =" + TenentID + " and return_id='" + intemreturn.return_id + "' and item_id='" + intemreturn.item_id + "' and UOM='" + intemreturn.UOM + "' and BatchNo='" + intemreturn.BatchNo + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in return_item query :" + ex.Message);
            }


            // tbl_custcredit 13

            backSyncro.Msg = " System is Synchronizing your customer credit Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_CustCredit> ListCustCredit = DB.Win_tbl_CustCredit.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListCustCredit.Count();
                currentCount = 0;
                foreach (Win_tbl_CustCredit itemCustCredit in ListCustCredit)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmd = "Update tbl_custcredit set CustID='" + itemCustCredit.CustID + "', orderID='" + itemCustCredit.OrderID + "', " +
                                       " Date='" + itemCustCredit.Date + "', Credit='" + itemCustCredit.Credit + "', Description='" + itemCustCredit.Description + "' " +
                                           " where TenentID =" + TenentID + " and ID='" + itemCustCredit.ID + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmd);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_custcredit " +
                                       " (TenentID, CustID, orderID, Date, Credit, Description ) " +
                                       "  select " + TenentID + ",'" + itemCustCredit.CustID + "', '" + itemCustCredit.OrderID + "', '" + itemCustCredit.Date + "', '" + itemCustCredit.Credit + "', '" + itemCustCredit.Description + "' " +
                                       "  where not exists ( SELECT * from tbl_custcredit  WHERE TenentID =" + TenentID + " and ID='" + itemCustCredit.ID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_custcredit query :" + ex.Message);
            }

            // tbl_duepayment 14
            backSyncro.Msg = " System is Synchronizing your due payment Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_duepayment> Listdue = DB.Win_tbl_duepayment.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listdue.Count();
                currentCount = 0;
                foreach (Win_tbl_duepayment itemdue in Listdue)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqldueUpdate = " update tbl_duepayment set receivedate='" + itemdue.receivedate + "', sales_id='" + itemdue.sales_id + "', totalamt='" + itemdue.totalamt + "' , " +
                                            " dueamt='" + itemdue.dueamt + "', receiveamt='" + itemdue.receiveamt + "' , custid='" + itemdue.custid + "' " +
                                            "   where TenentID = " + TenentID + " and id='" + itemdue.id + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqldueUpdate);

                        if (Falg != 1)
                        {
                            string sqldue = "insert into tbl_duepayment " +
                                   " (TenentID,id, receivedate, sales_id, totalamt , dueamt, receiveamt , custid) " +
                                   "  select " + TenentID + "," + itemdue.id + ",'" + itemdue.receivedate + "' , '" + itemdue.sales_id + "', '" + itemdue.totalamt + "', " +
                                   " '" + itemdue.dueamt + "', '" + itemdue.receiveamt + "', '" + itemdue.custid + "' " +
                                   "  where not exists ( SELECT * from tbl_duepayment  WHERE TenentID =" + TenentID + " and id='" + itemdue.id + "' and sales_id='" + itemdue.sales_id + "'  );";
                            DataAccess.ExecuteSQL(sqldue);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_duepayment query :" + ex.Message);
            }

            // tbl_expense 15
            backSyncro.Msg = " System is Synchronizing your expense Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_expense> Listexpense = DB.Win_tbl_expense.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listexpense.Count();
                currentCount = 0;
                foreach (Win_tbl_expense itemexpense in Listexpense)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sql1Update = " Update tbl_expense set Date = '" + itemexpense.Date + "' , ReferenceNo = '" + itemexpense.ReferenceNo + "' , Category= '" + itemexpense.Category + "' , " +
                                          "	Amount= '" + itemexpense.Amount + "' ,	Attachment= '" + itemexpense.Attachment + "' , fileextension= '" + itemexpense.fileextension + "' , " +
                                          " Note= '" + itemexpense.Note + "' ,	Createdby= '" + itemexpense.Createdby + "'  " +
                                          "   where TenentID = " + TenentID + " and id='" + itemexpense.ID + "'";
                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_expense " +
                               " (TenentID,ID, Date , ReferenceNo , Category ,	Amount ,	Attachment , fileextension, Note ,	Createdby) " +
                               "  select " + TenentID + ",'" + itemexpense.ID + "','" + itemexpense.Date + "', '" + itemexpense.ReferenceNo + "','" + itemexpense.Category + "', '" + itemexpense.Amount + "',  " +
                               " '" + itemexpense.Attachment + "', '" + itemexpense.fileextension + "', '" + itemexpense.Note + "' , '" + itemexpense.Createdby + "' " +
                               "  where not exists ( SELECT * from tbl_expense  WHERE TenentID =" + TenentID + " and ID='" + itemexpense.ID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_expense query :" + ex.Message);
            }

            // tbl_saleInfo 16
            backSyncro.Msg = " System is Synchronizing your sale Info Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_saleInfo> ListsaleInfo = DB.Win_tbl_saleInfo.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListsaleInfo.Count();
                currentCount = 0;
                foreach (Win_tbl_saleInfo itemsaleInfo in ListsaleInfo)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sql1Update = "update tbl_saleInfo set InvoiceNo = '" + itemsaleInfo.InvoiceNo + "', WarehouseNo = '" + itemsaleInfo.WarehouseNo + "', Biller = '" + itemsaleInfo.Biller + "', " +
                                   " Customer = '" + itemsaleInfo.Customer + "', Note = '" + itemsaleInfo.Note + "', DisRate = '" + itemsaleInfo.DisRate + "', TaxRate = '" + itemsaleInfo.TaxRate + "', " +
                                   " ShippingFee = '" + itemsaleInfo.ShippingFee + "', SoldBy = '" + itemsaleInfo.SoldBy + "', Datetime = '" + itemsaleInfo.DateTime + "'" +
                                   " where TenentID =" + TenentID + " and ID='" + itemsaleInfo.ID + "'";
                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_saleInfo " +
                                         " (TenentID,ID, InvoiceNo, WarehouseNo, Biller, Customer, Note, DisRate, TaxRate, ShippingFee, SoldBy, Datetime) " +
                                         "  select " + TenentID + ",'" + itemsaleInfo.ID + "','" + itemsaleInfo.InvoiceNo + "', '" + itemsaleInfo.WarehouseNo + "', '" + itemsaleInfo.Biller + "', '" + itemsaleInfo.Customer + "', '" + itemsaleInfo.Note + "', '" + itemsaleInfo.DisRate + "'," +
                                        " '" + itemsaleInfo.TaxRate + "','" + itemsaleInfo.ShippingFee + "', '" + itemsaleInfo.SoldBy + "','" + itemsaleInfo.DateTime + "' " +
                                        "  where not exists ( SELECT * from tbl_saleInfo  WHERE TenentID =" + TenentID + " and InvoiceNo='" + itemsaleInfo.InvoiceNo + "' and ID='" + itemsaleInfo.ID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_saleInfo query :" + ex.Message);
            }

            // ICUOM 17
            backSyncro.Msg = " System is Synchronizing your uom Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<ICUOM> ListICUOM = DB.ICUOMs.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListICUOM.Count();
                currentCount = 0;
                foreach (ICUOM itemUOM in ListICUOM)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int MultiUOMAllow = itemUOM.MultiUOMAllow != null ? itemUOM.MultiUOMAllow == true ? 1 : 0 : 0;
                        int CalculateAspectRatio = itemUOM.CalculateAspectRatio != null ? itemUOM.CalculateAspectRatio == true ? 1 : 0 : 0;
                        string sql1Update = "Update ICUOM set UOMNAMESHORT = '" + itemUOM.UOMNAMESHORT + "' , UOMNAME1 = '" + itemUOM.UOMNAME1 + "' ,  " +
                            " UOMNAME2 ='" + itemUOM.UOMNAME2 + "' , UOMNAME3 = '" + itemUOM.UOMNAME3 + "' , REMARKS = '" + itemUOM.REMARKS + "' , " +
                            " UOM_TYPE ='" + itemUOM.UOM_TYPE + "' , MultiUOMAllow = '" + MultiUOMAllow + "' , CalculateAspectRatio = '" + CalculateAspectRatio + "'  " +
                            " where TenentID =" + TenentID + " and UOM ='" + itemUOM.UOM + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into ICUOM " +
                                 " (TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,UOM_TYPE,MultiUOMAllow,CalculateAspectRatio) " +
                                    "  select " + TenentID + ",'" + itemUOM.UOM + "' , '" + itemUOM.UOMNAMESHORT + "','" + itemUOM.UOMNAME1 + "','" + itemUOM.UOMNAME2 + "' , " +
                                    " '" + itemUOM.UOMNAME3 + "' , '" + itemUOM.REMARKS + "' ,'" + itemUOM.UOM_TYPE + "' , '" + MultiUOMAllow + "' , '" + CalculateAspectRatio + "' " +
                                    "  where not exists ( SELECT * from ICUOM  WHERE TenentID =" + TenentID + " and UOM='" + itemUOM.UOM + "');";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ICUOM query :" + ex.Message);
            }

            // tbl_workrecords  18
            backSyncro.Msg = " System is Synchronizing your work records Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_workrecords> Listworkrecords = DB.Win_tbl_workrecords.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listworkrecords.Count();
                currentCount = 0;
                foreach (Win_tbl_workrecords itemwork in Listworkrecords)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlLogIn = " update tbl_workrecords set Username ='" + itemwork.Username + "', datatype='" + itemwork.datatype + "', logdate='" + itemwork.logdate + "', " +
                                               " logtime ='" + itemwork.logtime + "', logdatetime ='" + itemwork.logdatetime + "' " +
                                               "   where TenentID = " + TenentID + " and logdatetime='" + itemwork.logdatetime + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlLogIn);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_workrecords " +
                                          " (TenentID,id, Username, datatype, logdate, logtime, logdatetime ) " +
                                          "  select " + TenentID + "," + itemwork.id + ",'" + itemwork.Username + "' , '" + itemwork.datatype + "' , '" + itemwork.logdate + "' , " +
                                              " '" + itemwork.logtime + "' , '" + itemwork.logdatetime + "' " +
                                          "  where not exists ( SELECT * from tbl_workrecords  WHERE TenentID =" + TenentID + " and id=" + itemwork.id + "  );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_workrecords query :" + ex.Message);
            }

            // tblsetupsalesh 19
            backSyncro.Msg = " System is Synchronizing your setup sales Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tblsetupsalesh> Listsetupsalesh = DB.Win_tblsetupsalesh.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listsetupsalesh.Count();
                currentCount = 0;
                foreach (Win_tblsetupsalesh itemSet in Listsetupsalesh)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlLogInupdate = "update tblsetupsalesh set AllowMinusQty =" + itemSet.AllowMinusQty + " where TenentID=" + itemSet.TenentID + " and LocationID=1";
                        int Falg = DataAccess.ExecuteSQL(sqlLogInupdate);

                        if (Falg != 1)
                        {
                            string sqlLogIn = "insert into tblsetupsalesh " +
                               " (TenentID, locationID, AllowMinusQty) " +
                               "  select " + TenentID + " , '" + itemSet.locationID + "' , '" + itemSet.AllowMinusQty + "' " +
                               "  where not exists ( SELECT * from tblsetupsalesh where TenentID=" + itemSet.TenentID + " and LocationID=1 );";
                            DataAccess.ExecuteSQL(sqlLogIn);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tblsetupsalesh query :" + ex.Message);
            }

            // tbl_orderWay_Maintenance 20 
            backSyncro.Msg = " System is Synchronizing your orderWay Maintenance Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_orderWay_Maintenance> ListMaintenance = DB.Win_tbl_orderWay_Maintenance.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListMaintenance.Count();
                currentCount = 0;
                foreach (Win_tbl_orderWay_Maintenance itemMaintenance in ListMaintenance)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdUpdate = "update tbl_orderWay_Maintenance set Name1='" + itemMaintenance.Name1 + "', Name2='" + itemMaintenance.Name2 + "' , Commission_per='" + itemMaintenance.Commission_per + "', " +
                                            " Commission_Amount='" + itemMaintenance.Commission_Amount + "',DeliveryCharges='" + itemMaintenance.DeliveryCharges + "', " +
                                            " Paid_Commission='" + itemMaintenance.Paid_Commission + "',Pending_Commission='" + itemMaintenance.Pending_Commission + "' " +
                                            " where TenentID =" + TenentID + " and OrderWayID='" + itemMaintenance.OrderWayID + "' and Name1='" + itemMaintenance.Name1 + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sqlCmd = "insert into tbl_orderWay_Maintenance " +
                                            " (TenentID,ID, OrderWayID,Name1,Name2,Commission_per,Commission_Amount,DeliveryCharges,Paid_Commission,Pending_Commission) " +
                                            "  select " + TenentID + "," + itemMaintenance.ID + ",'" + itemMaintenance.OrderWayID + "','" + itemMaintenance.Name1 + "','" + itemMaintenance.Name2 + "', '" + itemMaintenance.Commission_per + "', " +
                                            " '" + itemMaintenance.Commission_Amount + "','" + itemMaintenance.DeliveryCharges + "' ,'" + itemMaintenance.Paid_Commission + "','" + itemMaintenance.Pending_Commission + "' " +
                                            "  where not exists ( SELECT * from tbl_orderWay_Maintenance where TenentID =" + TenentID + " and OrderWayID='" + itemMaintenance.OrderWayID + "' and Name1='" + itemMaintenance.Name1 + "' );";
                            DataAccess.ExecuteSQL(sqlCmd);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_orderWay_Maintenance query :" + ex.Message);
            }

            // tbl_orderWay_transection 21 
            backSyncro.Msg = " System is Synchronizing your orderWay transection Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_orderWay_transection> Listtransection = DB.Win_tbl_orderWay_transection.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = Listtransection.Count();
                currentCount = 0;
                foreach (Win_tbl_orderWay_transection itemtensection in Listtransection)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdUpdate = "Update tbl_orderWay_transection set Name2 ='" + itemtensection.Name2 + "' ,Commission_per ='" + itemtensection.Commission_per + "',Commission_Amount ='" + itemtensection.Commission_Amount + "', " +
                               " Paid_Commission ='" + itemtensection.Paid_Commission + "',Paid_Date ='" + itemtensection.Paid_Date + "',Paid_Reffrance ='" + itemtensection.Paid_Reffrance + "',Pending_Commission ='" + itemtensection.Pending_Commission + "' " +
                                           " where TenentID =" + TenentID + " and OrderWayID='" + itemtensection.OrderWayID + "' and Sales_ID = '" + itemtensection.Sales_ID + "' and Name1='" + itemtensection.Name1 + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sqlCmd = "insert into tbl_orderWay_transection " +
                                " (TenentID,ID, OrderWayID,Sales_ID,Name1,Name2,Commission_per,Commission_Amount,Paid_Commission,Paid_Date,Paid_Reffrance,Pending_Commission) " +
                                 "  select " + TenentID + "," + itemtensection.ID + ",'" + itemtensection.OrderWayID + "' ,'" + itemtensection.Sales_ID + "' ,'" + itemtensection.Name1 + "' , '" + itemtensection.Name2 + "' , " +
                                " '" + itemtensection.Commission_per + "' ,'" + itemtensection.Commission_Amount + "' ,'" + itemtensection.Paid_Commission + "' ,'" + itemtensection.Paid_Date + "' , " +
                                 " '" + itemtensection.Paid_Reffrance + "' ,'" + itemtensection.Pending_Commission + "' " +
                                "  where not exists ( SELECT * from tbl_orderWay_transection where TenentID =" + TenentID + " and OrderWayID='" + itemtensection.OrderWayID + "' and Sales_ID = '" + itemtensection.Sales_ID + "' and Name1='" + itemtensection.Name1 + "' );";
                            DataAccess.ExecuteSQL(sqlCmd);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_orderWay_transection query :" + ex.Message);
            }

            // DayClose 22
            backSyncro.Msg = " System is Synchronizing your Day Close Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<DayClose> ListDayClose = DB.DayCloses.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListDayClose.Count();
                currentCount = 0;
                foreach (DayClose itemDayClose in ListDayClose)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string Date = itemDayClose.Date.ToString("yyyy-MM-dd");

                        int DeliveredTO = itemDayClose.DeliveredTO == null ? Convert.ToInt32(itemDayClose.DeliveredTO) : 0;
                        int ShiftStutas = itemDayClose.ShiftStutas == null ? Convert.ToInt32(itemDayClose.ShiftStutas) : 0;
                        int Employee = itemDayClose.Employee == null ? Convert.ToInt32(itemDayClose.Employee) : UserInfo.Userid;

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        string sqlCmdUpdate = "Update DayClose set OpAMT = '" + itemDayClose.OpAMT + "', ShiftSales = '" + itemDayClose.ShiftSales + "', ShiftReturn = '" + itemDayClose.ShiftReturn + "' , " +
                                        " ShiftPurchase = '" + itemDayClose.ShiftPurchase + "',ShiftCIH = '" + itemDayClose.ShiftCIH + "', VoucharAMT = '" + itemDayClose.VoucharAMT + "', " +
                                        " ExpAMT = '" + itemDayClose.ExpAMT + "' ,ChequeAMT = '" + itemDayClose.ChequeAMT + "' ,AMTDelivered = '" + itemDayClose.AMTDelivered + "' , " +
                                        " DeliveredTO ='" + DeliveredTO + "' ,undeliverdAMT = '" + itemDayClose.undeliverdAMT + "',RefNO = '" + itemDayClose.RefNO + "', " +
                                        " Notes = '" + itemDayClose.Notes + "' ,Employee = '" + Employee + "',ShiftStutas = '" + ShiftStutas + "'  " +
                                        " where TenentID =" + TenentID + "  and ID = " + itemDayClose.ID + "  and UserID=" + itemDayClose.UserID + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into DayClose " +
                            " (TenentID,ID,UserID,TrmID,ShiftID,Date,OpAMT,ShiftSales,ShiftReturn,ShiftPurchase,ShiftCIH,VoucharAMT, " +
                                          " ExpAMT,ChequeAMT,AMTDelivered,DeliveredTO,undeliverdAMT,RefNO,Notes,UploadDate,Uploadby,SyncDate,Syncby,SynID,Employee,ShiftStutas) " +
                                           "  select " + TenentID + "," + itemDayClose.ID + "," + itemDayClose.UserID + ",'" + itemDayClose.TrmID + "'," + itemDayClose.ShiftID + ", " +
                                          " '" + Date + "','" + itemDayClose.OpAMT + "'," + itemDayClose.ShiftSales + ", " + itemDayClose.ShiftReturn + "," + itemDayClose.ShiftPurchase + "," + itemDayClose.ShiftCIH + ", " +
                                          " " + itemDayClose.VoucharAMT + "," + itemDayClose.ExpAMT + "," + itemDayClose.ChequeAMT + ", " + itemDayClose.AMTDelivered + "," + DeliveredTO + ", " +
                                          " " + itemDayClose.undeliverdAMT + ",'" + itemDayClose.RefNO + "','" + itemDayClose.Notes + "', " +
                                          " '" + itemDayClose.UploadDate + "' , '" + itemDayClose.Uploadby + "' ,'" + itemDayClose.SyncDate + "' , '" + itemDayClose.Syncby + "' , " + itemDayClose.SynID + "," + Employee + ", " + ShiftStutas + " " +
                                    "  where not exists ( SELECT * from DayClose where TenentID =" + TenentID + "  and ID = " + itemDayClose.ID + "  and UserID=" + itemDayClose.UserID + " );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in DayClose query :" + ex.Message);
            }

            // CashDelivery  23
            backSyncro.Msg = " System is Synchronizing your Cash Delivery Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<CashDelivery> ListCashDelivery = DB.CashDeliveries.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListCashDelivery.Count();
                currentCount = 0;
                foreach (CashDelivery itemCashDelivery in ListCashDelivery)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        DateTime Date1 = Convert.ToDateTime(itemCashDelivery.Date);
                        string Date = Date1.ToString("yyyy-MM-dd");

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        string sqlCmdUpdate = "Update CashDelivery set AMTDelivered = '" + itemCashDelivery.AMTDelivered + "' , DeliveredTO = '" + itemCashDelivery.DeliveredTO + "' , " +
                                        " RefNO = '" + itemCashDelivery.RefNO + "' , Notes = '" + itemCashDelivery.Notes + "'  " +
                                        " where TenentID =" + TenentID + " and UserID=" + itemCashDelivery.UserID + " and TrmID='" + itemCashDelivery.TrmID + "' and ShiftID=" + itemCashDelivery.ShiftID + " and Date='" + Date + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into CashDelivery " +
                                " (TenentID ,ID,UserID ,TrmID ,ShiftID , Date ,  AMTDelivered , DeliveredTO , RefNO , Notes , UploadDate , Uploadby, SyncDate , Syncby, SynID) " +
                                "  select " + TenentID + ",'" + itemCashDelivery.ID + "'," + itemCashDelivery.UserID + ",'" + itemCashDelivery.TrmID + "'," + itemCashDelivery.ShiftID + " , " +
                                          " '" + Date + "'," + itemCashDelivery.AMTDelivered + "," + itemCashDelivery.DeliveredTO + ",'" + itemCashDelivery.RefNO + "','" + itemCashDelivery.Notes + "', " +
                                          " '" + itemCashDelivery.UploadDate + "' , '" + itemCashDelivery.Uploadby + "' ,'" + itemCashDelivery.SyncDate + "' , '" + itemCashDelivery.Syncby + "' , " + itemCashDelivery.SynID + " " +
                                "  where not exists ( SELECT * from CashDelivery where TenentID =" + TenentID + " and UserID=" + itemCashDelivery.UserID + " and TrmID='" + itemCashDelivery.TrmID + "' and ShiftID=" + itemCashDelivery.ShiftID + " and Date='" + Date + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Cash Delivery query :" + ex.Message);
            }

            // ICIT_BR_Perishable  24
            backSyncro.Msg = " System is Synchronizing your Perishable Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<ICIT_BR_Perishable> ListICIT_BR_Perishable = DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListICIT_BR_Perishable.Count();
                currentCount = 0;
                foreach (ICIT_BR_Perishable Perishable in ListICIT_BR_Perishable)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int OpQty = Perishable.OpQty != null ? Convert.ToInt32(Perishable.OpQty) : 0;
                        int OnHand = Perishable.OnHand != null ? Convert.ToInt32(Perishable.OnHand) : 0;
                        int QtyOut = Perishable.QtyOut != null ? Convert.ToInt32(Perishable.QtyOut) : 0;
                        int QtyReceived = Perishable.QtyReceived != null ? Convert.ToInt32(Perishable.QtyReceived) : 0;

                        string sqlCmdUpdate = "Update ICIT_BR_Perishable set LocationID = '" + Perishable.LocationID + "', MYTRANSID = '" + Perishable.MYTRANSID + "', " +
                                        " OpQty = '" + OpQty + "', OnHand = '" + OnHand + "' , QtyOut = '" + QtyOut + "', QtyReceived  = '" + QtyReceived + "' , " +
                                        " ProdDate = '" + Perishable.ProdDate + "',ExpiryDate = '" + Perishable.ExpiryDate + "',LeadDays2Destroy = '" + Perishable.LeadDays2Destroy + "', " +
                                        " Reference = '" + Perishable.Reference + "', Active = '" + Perishable.Active + "' " +
                                        " WHERE TenentID =" + TenentID + " and MyProdID=" + Perishable.MyProdID + " and period_code='" + Perishable.period_code + "' and MySysName='" + Perishable.MySysName + "' and UOM='" + Perishable.UOM + "' and BatchNo = '" + Perishable.BatchNo + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into ICIT_BR_Perishable " +
                            " (TenentID,MyProdID,period_code,MySysName,UOM,BatchNo,LocationID,MYTRANSID,OpQty,OnHand,QtyOut,QtyReceived,ProdDate,ExpiryDate,LeadDays2Destroy,Reference,Active) " +
                            "  select " + TenentID + "," + Perishable.MyProdID + ",'" + Perishable.period_code + "','" + Perishable.MySysName + "' ,'" + Perishable.UOM + "' ,'" + Perishable.BatchNo + "' , " +
                                          " '" + Perishable.LocationID + "'," + Perishable.MYTRANSID + ",'" + OpQty + "','" + OnHand + "','" + QtyOut + "','" + QtyReceived + "' , " +
                                          " '" + Perishable.ProdDate + "' ,'" + Perishable.ExpiryDate + "' , '" + Perishable.LeadDays2Destroy + "' , '" + Perishable.Reference + "', '" + Perishable.Active + "' " +
                            "  where not exists ( SELECT * from ICIT_BR_Perishable where TenentID =" + TenentID + " and MyProdID=" + Perishable.MyProdID + " and period_code='" + Perishable.period_code + "' and MySysName='" + Perishable.MySysName + "' and UOM='" + Perishable.UOM + "' and BatchNo = '" + Perishable.BatchNo + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Perishable query :" + ex.Message);
            }

            // ICIT_BR_TMP  25
            backSyncro.Msg = " System is Synchronizing your Perishable TEMP Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<ICIT_BR_TMP> ListICIT_BR_TMP = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListICIT_BR_TMP.Count();
                currentCount = 0;
                foreach (ICIT_BR_TMP BR_TMP in ListICIT_BR_TMP)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int SIZECODE = BR_TMP.SIZECODE != null ? BR_TMP.SIZECODE : 999999998;
                        int COLORID = BR_TMP.COLORID != null ? BR_TMP.COLORID : 999999998;
                        int Bin_ID = BR_TMP.Bin_ID != null ? BR_TMP.Bin_ID : 999999998;
                        string BatchNo = BR_TMP.BatchNo != null && BR_TMP.BatchNo != " " ? BR_TMP.BatchNo.ToString() : "999999998";
                        string Serial_Number = BR_TMP.Serial_Number != null && BR_TMP.Serial_Number != " " ? BR_TMP.Serial_Number.ToString() : "NO";
                        int LocationID = BR_TMP.LocationID != null ? BR_TMP.LocationID : 1;

                        int OpQty = BR_TMP.OpQty != null ? Convert.ToInt32(BR_TMP.OpQty) : 0;
                        int OnHand = BR_TMP.OnHand != null ? Convert.ToInt32(BR_TMP.OnHand) : 0;
                        int QtyOut = BR_TMP.QtyOut != null ? Convert.ToInt32(BR_TMP.QtyOut) : 0;
                        int QtyConsumed = BR_TMP.QtyConsumed != null ? Convert.ToInt32(BR_TMP.QtyConsumed) : 0;
                        int QtyReceived = BR_TMP.QtyReceived != null ? Convert.ToInt32(BR_TMP.QtyReceived) : 0;
                        int QtyReserved = BR_TMP.QtyReserved != null ? Convert.ToInt32(BR_TMP.QtyReserved) : 0;

                        int MinQty = BR_TMP.MinQty != null ? Convert.ToInt32(BR_TMP.MinQty) : 0;
                        int MaxQty = BR_TMP.MaxQty != null ? Convert.ToInt32(BR_TMP.MaxQty) : 0;

                        double MyProdID = Convert.ToDouble(BR_TMP.MyProdID);

                        int ID = DataAccess.getICIT_BR_TMPMYid(TenentID, MyProdID, BR_TMP.UOM);

                        string sqlCmdUpdate = "Update ICIT_BR_TMP set SIZECODE = '" + SIZECODE + "' , COLORID = '" + COLORID + "', Bin_ID = '" + Bin_ID + "', BatchNo = '" + BatchNo + "', " +
                                        " Serial_Number = '" + Serial_Number + "', MYTRANSID = " + BR_TMP.MYTRANSID + ", LocationID = '" + LocationID + "' , " +
                                        " NewQty = '" + BR_TMP.NewQty + "', OpQty = '" + OpQty + "', OnHand = '" + OnHand + "', QtyOut = '" + QtyOut + "', QtyConsumed = '" + QtyConsumed + "'," +
                                        " QtyReceived = '" + QtyReceived + "', QtyReserved = '" + QtyReserved + "', MinQty = '" + MinQty + "', MaxQty = '" + MaxQty + "' , " +
                                        " LeadTime = '" + BR_TMP.LeadTime + "', Reference = '" + BR_TMP.Reference + "', RecodName = '" + BR_TMP.RecodName + "' , " +
                                        " ProdDate = '" + BR_TMP.ProdDate + "' , ExpiryDate = '" + BR_TMP.ExpiryDate + "' , LeadDays2Destroy = '" + BR_TMP.LeadDays2Destroy + "' , Active = '" + BR_TMP.Active + "'  " +
                                        " WHERE TenentID =" + TenentID + " and MyProdID=" + BR_TMP.MyProdID + " and period_code='" + BR_TMP.period_code + "' and MySysName='" + BR_TMP.MySysName + "' and UOM='" + BR_TMP.UOM + "' and BatchNo = '" + BR_TMP.BatchNo + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into ICIT_BR_TMP " +
                                        " (TenentID,ID,MyProdID,period_code,MySysName,UOM,SIZECODE,COLORID,Bin_ID,BatchNo,Serial_Number,MYTRANSID,LocationID,NewQty,OpQty,OnHand,QtyOut,QtyConsumed," +
                                          " QtyReceived,QtyReserved,MinQty,MaxQty,LeadTime,Reference,RecodName,ProdDate,ExpiryDate,LeadDays2Destroy,Active) " +
                                        "  select " + TenentID + "," + ID + "," + BR_TMP.MyProdID + ",'" + BR_TMP.period_code + "','" + BR_TMP.MySysName + "' ,'" + BR_TMP.UOM + "' ,'" + SIZECODE + "' , " +
                                          " '" + COLORID + "'," + Bin_ID + ",'" + BatchNo + "','" + Serial_Number + "','" + BR_TMP.MYTRANSID + "','" + LocationID + "', " +
                                          " '" + BR_TMP.NewQty + "','" + OpQty + "','" + OnHand + "','" + QtyOut + "','" + QtyConsumed + "','" + QtyReceived + "', " +
                                          " '" + QtyReserved + "','" + MinQty + "','" + MaxQty + "','" + BR_TMP.LeadTime + "','" + BR_TMP.Reference + "','" + BR_TMP.RecodName + "', " +
                                          " '" + BR_TMP.ProdDate + "','" + BR_TMP.ExpiryDate + "','" + BR_TMP.LeadDays2Destroy + "','" + BR_TMP.Active + "'  " +
                                          "  where not exists ( SELECT * from ICIT_BR_TMP where TenentID =" + TenentID + " and MyProdID=" + BR_TMP.MyProdID + " and period_code='" + BR_TMP.period_code + "' and MySysName='" + BR_TMP.MySysName + "' and UOM='" + BR_TMP.UOM + "' and BatchNo = '" + BR_TMP.BatchNo + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Perishable TEMP query :" + ex.Message);
            }

            // TblProductRelated  26
            backSyncro.Msg = " System is Synchronizing your Related Item Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_TblProductRelated> ListProductRelated = DB.Win_TblProductRelated.Where(p => p.TenentID == TenentID && p.ACTIVE == true).ToList();
                Totalcount = ListProductRelated.Count();
                currentCount = 0;
                foreach (Win_TblProductRelated ProductRelated in ListProductRelated)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int sortNO = ProductRelated.sortNO != null ? Convert.ToInt32(ProductRelated.AlwaysShow) : 999;
                        bool AlwaysShow = ProductRelated.AlwaysShow != null ? Convert.ToBoolean(ProductRelated.AlwaysShow) : true;
                        string ACTIVE = ProductRelated.ACTIVE != null ? ProductRelated.ACTIVE == true ? "Y" : "N" : "N";

                        string sqlCmdUpdate = "Update TblProductRelated set sortNO = '" + sortNO + "' , AlwaysShow = '" + ProductRelated.AlwaysShow + "', ACTIVE = '" + ACTIVE + "'  " +
                                        " WHERE TenentID =" + TenentID + " and LOCATION_ID = '" + ProductRelated.LOCATION_ID + "' and MYPRODID = '" + ProductRelated.MYPRODID + "' and RalatedProdID = '" + ProductRelated.RalatedProdID + "'   ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into TblProductRelated " +
                                          " ( TenentID,LOCATION_ID,MYPRODID,RalatedProdID,sortNO,AlwaysShow,ACTIVE ) " +
                                          "  select " + TenentID + ",'" + ProductRelated.LOCATION_ID + "','" + ProductRelated.MYPRODID + "','" + ProductRelated.RalatedProdID + "' , " +
                                          " '" + sortNO + "','" + AlwaysShow + "','" + ACTIVE + "' " +
                                          "  where not exists ( SELECT * from TblProductRelated  WHERE TenentID =" + TenentID + " and LOCATION_ID = '" + ProductRelated.LOCATION_ID + "' and MYPRODID = '" + ProductRelated.MYPRODID + "' and RalatedProdID = '" + ProductRelated.RalatedProdID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Related Item query :" + ex.Message);
            }

            // tbl_Receipe  28
            backSyncro.Msg = " System is Synchronizing your Receipe Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,Receipe_English,Receipe_Arabic,ExpireDays
                List<tbl_Receipe> ListReceipe = DB.tbl_Receipe.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListReceipe.Count();
                currentCount = 0;
                foreach (tbl_Receipe itemReceipe in ListReceipe)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int HourToComplate = itemReceipe.HourToComplate != null ? Convert.ToInt32(itemReceipe.HourToComplate) : 0;
                        int SynID = itemReceipe.SynID != null ? Convert.ToInt32(itemReceipe.SynID) : 0;
                        string UploadDate = itemReceipe.UploadDate != null ? (Convert.ToDateTime(itemReceipe.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update tbl_Receipe set Receipe_English = '" + itemReceipe.Receipe_English + "' , Receipe_Arabic = '" + itemReceipe.Receipe_Arabic + "', RecType = '" + itemReceipe.RecType + "' ,  " +
                                              " ExpireDays = '" + itemReceipe.ExpireDays + "', HourToComplate = '" + HourToComplate + "', " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemReceipe.Uploadby + "' , SynID = '" + SynID + "'" +
                                              " WHERE TenentID =" + TenentID + " and recNo=" + itemReceipe.recNo + "  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);
                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_Receipe " +
                                                  " (TenentID,recNo,Receipe_English,Receipe_Arabic,ExpireDays,RecType,HourToComplate,UploadDate,Uploadby,SynID ) " +
                                                  "  select " + TenentID + ", " + itemReceipe.recNo + " ,'" + itemReceipe.Receipe_English + "','" + itemReceipe.Receipe_Arabic + "' , " +
                                                  " '" + itemReceipe.ExpireDays + "' , '" + itemReceipe.RecType + "' , '" + HourToComplate + "', '" + UploadDate + "','" + itemReceipe.Uploadby + "','" + SynID + "' " +
                                                  "  where not exists ( SELECT * from tbl_Receipe  WHERE TenentID =" + TenentID + " and recNo=" + itemReceipe.recNo + "  );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Receipe query :" + ex.Message);
            }

            // Receipe_Menegement  29
            backSyncro.Msg = " System is Synchronizing your Receipe Menegement Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Receipe_Menegement> ListReceipeM = DB.Receipe_Menegement.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListReceipeM.Count();
                currentCount = 0;
                foreach (Receipe_Menegement itemReceipeM in ListReceipeM)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        double ItemCode = itemReceipeM.ItemCode != null ? itemReceipeM.ItemCode : 0;
                        int UOM = itemReceipeM.UOM != null ? Convert.ToInt32(itemReceipeM.UOM) : 0;

                        string CostPrice = itemReceipeM.CostPrice != null && itemReceipeM.CostPrice.ToString() != "" ? itemReceipeM.CostPrice.ToString() : ReceipeMenegement.Get_CostPrice(TenentID, ItemCode, UOM);
                        string msrp = itemReceipeM.msrp != null && itemReceipeM.msrp.ToString() != "" ? itemReceipeM.msrp.ToString() : ReceipeMenegement.Get_MSRT(TenentID, ItemCode, UOM);


                        string sqlCmdUpdate = " Update Receipe_Menegement set IOSwitch = '" + itemReceipeM.IOSwitch + "' , ItemCode = '" + itemReceipeM.ItemCode + "',  " +
                                              " UOM = '" + itemReceipeM.UOM + "' , Qty = '" + itemReceipeM.Qty + "' , Perc = '" + itemReceipeM.Perc + "' , RecType = '" + itemReceipeM.RecType + "' ,  " +
                                              " CostPrice = '" + CostPrice + "', msrp = '" + msrp + "' " +
                                              " WHERE TenentID =" + TenentID + " and recNo=" + itemReceipeM.recNo + " and IOSwitch = '" + itemReceipeM.IOSwitch + "' and ItemCode = '" + itemReceipeM.ItemCode + "' and UOM = '" + itemReceipeM.UOM + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into Receipe_Menegement " +
                                                  " (TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc,RecType,CostPrice,msrp) " +
                                                  "  select " + TenentID + ", " + itemReceipeM.recNo + " ,'" + itemReceipeM.IOSwitch + "','" + itemReceipeM.ItemCode + "' ,'" + itemReceipeM.UOM + "' , " +
                                                  "  '" + itemReceipeM.Qty + "' ,'" + itemReceipeM.Perc + "' , '" + itemReceipeM.RecType + "' , '" + CostPrice + "' ,'" + msrp + "'   " +
                                                  "  where not exists ( SELECT * from Receipe_Menegement  WHERE TenentID =" + TenentID + " and recNo=" + itemReceipeM.recNo + " and IOSwitch = '" + itemReceipeM.IOSwitch + "' and ItemCode = '" + itemReceipeM.ItemCode + "' and UOM = '" + itemReceipeM.UOM + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Receipe Menegement query :" + ex.Message);
            }

            // tblPrintSetup  30
            backSyncro.Msg = " System is Synchronizing your Print Setup Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<tblPrintSetup> ListPrintSetup = DB.tblPrintSetups.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListPrintSetup.Count();
                currentCount = 0;
                foreach (tblPrintSetup itemPrintSetup in ListPrintSetup)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdUpdate = "Update tblPrintSetup set CashReciptPRinter = '" + itemPrintSetup.CashReciptPRinter + "' , CashReceiptFile = '" + itemPrintSetup.CashReceiptFile + "',  " +
                                              " CreditInvoicePrinter = '" + itemPrintSetup.CreditInvoicePrinter + "' , CreditInvoiceFile = '" + itemPrintSetup.CreditInvoiceFile + "' , KitchenNotePrinter = '" + itemPrintSetup.KitchenNotePrinter + "' , KitchenNoteFile = '" + itemPrintSetup.KitchenNoteFile + "'   " +
                                        " WHERE TenentID =" + TenentID + " and Shopid='" + itemPrintSetup.Shopid + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tblPrintSetup " +
                                                  " (TenentID,Shopid,CashReciptPRinter,CashReceiptFile,CreditInvoicePrinter,CreditInvoiceFile,KitchenNotePrinter,KitchenNoteFile) " +
                                                  "  select " + TenentID + ", '" + itemPrintSetup.Shopid + "' ,'" + itemPrintSetup.CashReciptPRinter + "','" + itemPrintSetup.CashReceiptFile + "' ,'" + itemPrintSetup.CreditInvoicePrinter + "' , " +
                                                  "  '" + itemPrintSetup.CreditInvoiceFile + "' ,'" + itemPrintSetup.KitchenNotePrinter + "','" + itemPrintSetup.KitchenNoteFile + "'  " +
                                                  "  where not exists ( SELECT * from tblPrintSetup  WHERE TenentID =" + TenentID + " and Shopid='" + itemPrintSetup.Shopid + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Print Setup query :" + ex.Message);
            }

            // CashDrawerLibrary  31
            backSyncro.Msg = " System is Synchronizing your Drawer Library Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                DateTime Today = DateTime.Now.AddDays(-3);
                List<CashDrawerLibrary> ListDrawer = DB.CashDrawerLibraries.Where(p => p.SynID != 3).ToList();
                Totalcount = ListDrawer.Count();
                currentCount = 0;
                foreach (CashDrawerLibrary itemDrawer in ListDrawer)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdUpdate = "Update CashDrawerLibrary set Manufacturer = '" + itemDrawer.Manufacturer + "' , Model = '" + itemDrawer.Model + "',  " +
                                              " Drawer_Codes = '" + itemDrawer.Drawer_Codes + "' , UploadDate = '" + itemDrawer.UploadDate + "'  " +
                                        " WHERE ID =" + itemDrawer.ID + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into CashDrawerLibrary " +
                                          " (ID,Manufacturer,Model,Drawer_Codes,UploadDate,Syncby,SynID) " +
                                          "  select " + itemDrawer.ID + ", '" + itemDrawer.Manufacturer + "' ,'" + itemDrawer.Model + "','" + itemDrawer.Drawer_Codes + "' ,'" + itemDrawer.UploadDate + "' , " +
                                          "  '" + itemDrawer.Uploadby + "' ,'" + itemDrawer.SynID + "'  " +
                                          "  where not exists ( SELECT * from CashDrawerLibrary  WHERE ID =" + itemDrawer.ID + " );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Drawer Library query :" + ex.Message);
            }

            // Appointment  32
            backSyncro.Msg = " System is Synchronizing your Appointment Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<Appointment> ListAppointment = DB.Appointments.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListAppointment.Count();
                currentCount = 0;
                foreach (Appointment itemApp in ListAppointment)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string ExpStartDate = itemApp.ExpStartDate != null ? Convert.ToDateTime(itemApp.ExpStartDate).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        string ExpEndDate = itemApp.ExpEndDate != null ? Convert.ToDateTime(itemApp.ExpEndDate).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        string DateAdd = itemApp.DateTime != null ? Convert.ToDateTime(itemApp.DateTime).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        int Deleted = itemApp.DateTime != null ? itemApp.Deleted == true ? 1 : 0 : 1;
                        int JobDone = itemApp.JobDone != null ? itemApp.JobDone == true ? 1 : 0 : 0;
                        int Active = itemApp.Active != null ? itemApp.Active == true ? 1 : 0 : 1;

                        string sqlCmdUpdate = "Update Appointment set Title = '" + itemApp.Title + "', ExpStartDate = '" + ExpStartDate + "', ExpEndDate = '" + ExpEndDate + "', " +
                                        " StartDt = '" + itemApp.StartDt + "', EndDt = '" + itemApp.EndDt + "', Employee = '" + itemApp.Employee + "', customer = '" + itemApp.customer + "', " +
                                        " status = '" + itemApp.status + "', Color = '" + itemApp.Color + "',url= '" + itemApp.url + "', JobDone= '" + JobDone + "', Createby = '" + itemApp.Createby + "', " +
                                        " DateTime = '" + DateAdd + "', Active = '" + Active + "', Deleted = '" + Deleted + "', UploadDate = '" + itemApp.UploadDate + "',Uploadby = '" + itemApp.Uploadby + "', " +
                                        " SyncDate = '" + itemApp.SyncDate + "', Syncby = '" + itemApp.Syncby + "', SynID = '" + itemApp.SynID + "', CRMReference = '" + itemApp.CRMReference + "', MyID = '" + itemApp.MyID + "', " +
                                        " MySerial = '" + itemApp.MySerial + "', TransactionStatus = '" + itemApp.TransactionStatus + "', Type = '" + itemApp.Type + "', ActionType = '" + itemApp.ActionType + "', " +
                                        " FromAppoint = '" + itemApp.FromAppoint + "', ToAppoint = '" + itemApp.ToAppoint + "', C_ID = '" + itemApp.C_ID + "' " +
                                        " WHERE TenentID =" + TenentID + " and LocationID='" + itemApp.LocationID + "' and ID = '" + itemApp.ID + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into Appointment " +
                                          " (TenentID,LocationID, ID, Title, ExpStartDate, ExpEndDate, StartDt, EndDt, Employee, customer, status, Color,url, JobDone, Createby, DateTime, " +
                                          " Active, Deleted, UploadDate,Uploadby, SyncDate, Syncby, SynID, CRMReference, MyID,MySerial, TransactionStatus, Type, ActionType, FromAppoint, ToAppoint, C_ID ) " +
                                          " select " + TenentID + " , '" + itemApp.LocationID + "', '" + itemApp.ID + "', '" + itemApp.Title + "', '" + ExpStartDate + "','" + ExpEndDate + "', " +
                                          " '" + itemApp.StartDt + "','" + itemApp.EndDt + "','" + itemApp.Employee + "','" + itemApp.customer + "','" + itemApp.status + "','" + itemApp.Color + "', " +
                                          " '" + itemApp.url + "','" + JobDone + "','" + itemApp.Createby + "','" + DateAdd + "','" + Active + "','" + Deleted + "', " +
                                          " '" + itemApp.UploadDate + "','" + itemApp.Uploadby + "','" + itemApp.SyncDate + "','" + itemApp.Syncby + "','" + itemApp.SynID + "','" + itemApp.CRMReference + "', " +
                                          " '" + itemApp.MyID + "','" + itemApp.MySerial + "','" + itemApp.TransactionStatus + "','" + itemApp.Type + "','" + itemApp.ActionType + "','" + itemApp.FromAppoint + "', " +
                                          " '" + itemApp.ToAppoint + "', '" + itemApp.C_ID + "'  " +
                                          "  where not exists ( SELECT * from Appointment  WHERE TenentID =" + TenentID + " and LocationID='" + itemApp.LocationID + "' and ID = '" + itemApp.ID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Appointment query :" + ex.Message);
            }

            // CRMActivities  33
            backSyncro.Msg = " System is Synchronizing your CRMActivities Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<CRMActivity> ListCRMAC = DB.CRMActivities.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListCRMAC.Count();
                currentCount = 0;
                foreach (CRMActivity itemCRMAC in ListCRMAC)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UPDTTIME = itemCRMAC.UPDTTIME != null ? (Convert.ToDateTime(itemCRMAC.UPDTTIME)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string InitialDate = itemCRMAC.InitialDate != null ? (Convert.ToDateTime(itemCRMAC.InitialDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string DeadLineDate = itemCRMAC.DeadLineDate != null ? (Convert.ToDateTime(itemCRMAC.DeadLineDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string UploadDate = itemCRMAC.UploadDate != null ? (Convert.ToDateTime(itemCRMAC.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string ExpStartDate = itemCRMAC.ExpStartDate != null ? (Convert.ToDateTime(itemCRMAC.ExpStartDate)).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        string ExpEndDate = itemCRMAC.ExpEndDate != null ? (Convert.ToDateTime(itemCRMAC.ExpEndDate)).ToString("yyyy-MM-dd HH:mm:ss") : "";

                        string sqlCmdUpdate = "Update CRMActivities set MenuID = '" + itemCRMAC.MenuID + "' , ACTIVITYTYPE = '" + itemCRMAC.ACTIVITYTYPE + "' , REFTYPE  = '" + itemCRMAC.REFTYPE + "' , " +
                                        " REFSUBTYPE  = '" + itemCRMAC.REFSUBTYPE + "' , PerfReferenceNo  = '" + itemCRMAC.PerfReferenceNo + "' , EarlierRefNo  = '" + itemCRMAC.EarlierRefNo + "' , " +
                                        " NextUser   = '" + itemCRMAC.NextUser + "' , NextRefNo  = '" + itemCRMAC.NextRefNo + "'  , AMIGLOBAL  = '" + itemCRMAC.AMIGLOBAL + "'   , " +
                                        " MYPERSONNEL  = '" + itemCRMAC.MYPERSONNEL + "'  , ActivityPerform  = '" + itemCRMAC.ActivityPerform + "'  , REMINDERNOTE  = '" + itemCRMAC.REMINDERNOTE + "' , " +
                                        " ESTCOST  = '" + itemCRMAC.ESTCOST + "'  , GROUPCODE  = '" + itemCRMAC.GROUPCODE + "'  , USERCODEENTERED  = '" + itemCRMAC.USERCODEENTERED + "'  , " +
                                        " UPDTTIME  = '" + UPDTTIME + "'  , USERNAME  = '" + itemCRMAC.USERNAME + "'  , CRUP_ID  = '" + itemCRMAC.CRUP_ID + "'  , " +
                                        " InitialDate  = '" + InitialDate + "'  ,DeadLineDate  = '" + DeadLineDate + "' ,RouteID  = '" + itemCRMAC.RouteID + "' ,Version  = '" + itemCRMAC.Version + "' , " +
                                        " Type  = '" + itemCRMAC.Type + "' ,MyStatus  = '" + itemCRMAC.MyStatus + "' ,GroupBy  = '" + itemCRMAC.GroupBy + "' ,DocID  = '" + itemCRMAC.DocID + "' ,ToColumn  = '" + itemCRMAC.ToColumn + "' , " +
                                        " FromColumn  = '" + itemCRMAC.FromColumn + "' ,Active  = '" + itemCRMAC.Active + "' ,MainSubRefNo  = '" + itemCRMAC.MainSubRefNo + "' ,UrlRedirct  = '" + itemCRMAC.UrlRedirct + "' ,USERCODE  = '" + itemCRMAC.USERCODE + "' , " +
                                        " ExpStartDate = '" + ExpStartDate + "' ,  ExpEndDate = '" + ExpEndDate + "' , " +
                                        " UploadDate   = '" + UploadDate + "' ,Uploadby   = '" + itemCRMAC.Uploadby + "' ,SyncDate   = '" + itemCRMAC.SyncDate + "' ,Syncby   = '" + itemCRMAC.Syncby + "' ,SynID   = '" + itemCRMAC.SynID + "'  " +
                                        " WHERE TenentID =" + TenentID + " and COMPID = '" + itemCRMAC.COMPID + "' and MasterCODE = '" + itemCRMAC.MasterCODE + "' and MyLineNo = '" + itemCRMAC.MyLineNo + "' and LocationID = '" + itemCRMAC.LocationID + "' and LinkMasterCODE = '" + itemCRMAC.LinkMasterCODE + "' and ActivityID = '" + itemCRMAC.ActivityID + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into CRMActivities " +
                                          " (TenentID,COMPID,MasterCODE,MyLineNo,LocationID,LinkMasterCODE,MenuID,ActivityID,ACTIVITYTYPE,REFTYPE,REFSUBTYPE,PerfReferenceNo,EarlierRefNo,NextUser, " +
                                          " NextRefNo,AMIGLOBAL,MYPERSONNEL,ActivityPerform,REMINDERNOTE,ESTCOST,GROUPCODE,USERCODEENTERED,UPDTTIME,USERNAME,CRUP_ID,InitialDate,DeadLineDate,RouteID, " +
                                          " Version,Type,MyStatus,GroupBy,DocID,ToColumn,FromColumn,Active,MainSubRefNo,UrlRedirct,USERCODE,UploadDate,Uploadby,SynID,ExpStartDate,ExpEndDate) " +
                                          " select " + TenentID + " , '" + itemCRMAC.COMPID + "', '" + itemCRMAC.MasterCODE + "', '" + itemCRMAC.MyLineNo + "', '" + itemCRMAC.LocationID + "', " +
                                          " '" + itemCRMAC.LinkMasterCODE + "','" + itemCRMAC.MenuID + "','" + itemCRMAC.ActivityID + "','" + itemCRMAC.ACTIVITYTYPE + "','" + itemCRMAC.REFTYPE + "', " +
                                          " '" + itemCRMAC.REFSUBTYPE + "','" + itemCRMAC.PerfReferenceNo + "','" + itemCRMAC.EarlierRefNo + "','" + itemCRMAC.NextUser + "','" + itemCRMAC.NextRefNo + "', " +
                                          " '" + itemCRMAC.AMIGLOBAL + "','" + itemCRMAC.MYPERSONNEL + "','" + itemCRMAC.ActivityPerform + "','" + itemCRMAC.REMINDERNOTE + "','" + itemCRMAC.ESTCOST + "', " +
                                          " '" + itemCRMAC.GROUPCODE + "','" + itemCRMAC.USERCODEENTERED + "','" + UPDTTIME + "','" + itemCRMAC.USERNAME + "','" + itemCRMAC.CRUP_ID + "', " +
                                          " '" + InitialDate + "','" + DeadLineDate + "','" + itemCRMAC.RouteID + "','" + itemCRMAC.Version + "','" + itemCRMAC.Type + "', " +
                                          " '" + itemCRMAC.MyStatus + "','" + itemCRMAC.GroupBy + "', '" + itemCRMAC.DocID + "','" + itemCRMAC.ToColumn + "', '" + itemCRMAC.FromColumn + "', " +
                                          " '" + itemCRMAC.Active + "', '" + itemCRMAC.MainSubRefNo + "','" + itemCRMAC.UrlRedirct + "' ,'" + itemCRMAC.USERCODE + "' ,'" + UploadDate + "' , " +
                                          " '" + itemCRMAC.Uploadby + "' ,'" + itemCRMAC.SynID + "' , '" + ExpStartDate + "' , '" + ExpEndDate + "' " +
                                          " where not exists ( SELECT * from CRMActivities   WHERE TenentID =" + TenentID + " and COMPID = '" + itemCRMAC.COMPID + "' and MasterCODE = '" + itemCRMAC.MasterCODE + "' and MyLineNo = '" + itemCRMAC.MyLineNo + "' and LocationID = '" + itemCRMAC.LocationID + "' and LinkMasterCODE = '" + itemCRMAC.LinkMasterCODE + "' and ActivityID = '" + itemCRMAC.ActivityID + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Appointment query :" + ex.Message);
            }

            // CRMMainActivities  34
            backSyncro.Msg = " System is Synchronizing your CRMMainActivities Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<CRMMainActivity> ListCRMMAin = DB.CRMMainActivities.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListCRMMAin.Count();
                currentCount = 0;
                foreach (CRMMainActivity CRMMAin in ListCRMMAin)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string REPEATTILL = CRMMAin.REPEATTILL != null ? (Convert.ToDateTime(CRMMAin.REPEATTILL)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string UPDTTIME = CRMMAin.UPDTTIME != null ? (Convert.ToDateTime(CRMMAin.UPDTTIME)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string UploadDate = CRMMAin.UploadDate != null ? (Convert.ToDateTime(CRMMAin.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update CRMMainActivities set RouteID = '" + CRMMAin.RouteID + "' , USERCODE= '" + CRMMAin.USERCODE + "' , ACTIVITYE= '" + CRMMAin.ACTIVITYE + "' ,ACTIVITYA= '" + CRMMAin.ACTIVITYA + "' , " +
                                        " ACTIVITYA2= '" + CRMMAin.ACTIVITYA2 + "' , Reference= '" + CRMMAin.Reference + "' , AMIGLOBAL= '" + CRMMAin.AMIGLOBAL + "' , MYPERSONNEL= '" + CRMMAin.MYPERSONNEL + "' , INTERVALDAYS= '" + CRMMAin.INTERVALDAYS + "' , " +
                                        " REPEATFOREVER= '" + CRMMAin.REPEATFOREVER + "' , REPEATTILL= '" + REPEATTILL + "' , REMINDERNOTE= '" + CRMMAin.REMINDERNOTE + "' , ESTCOST= '" + CRMMAin.ESTCOST + "' , GROUPCODE= '" + CRMMAin.GROUPCODE + "' , " +
                                        " USERCODEENTERED= '" + CRMMAin.USERCODEENTERED + "' , UPDTTIME= '" + UPDTTIME + "' , USERNAME= '" + CRMMAin.USERNAME + "' , Remarks= '" + CRMMAin.Remarks + "' , CRUP_ID= '" + CRMMAin.CRUP_ID + "' , " +
                                        " Version= '" + CRMMAin.Version + "' , Type= '" + CRMMAin.Type + "' , MyStatus= '" + CRMMAin.MyStatus + "' , MainID= '" + CRMMAin.MainID + "' , ModuleID= '" + CRMMAin.ModuleID + "' , DisplayFDName= '" + CRMMAin.DisplayFDName + "' , " +
                                        " Description= '" + CRMMAin.Description + "' , Ratting= '" + CRMMAin.Ratting + "' , Active= '" + CRMMAin.Active + "' , JobDone= '" + CRMMAin.JobDone + "' , UploadDate= '" + UploadDate + "' , Uploadby= '" + CRMMAin.Uploadby + "' , SynID = '" + CRMMAin.SynID + "', UseReciepeName = '" + CRMMAin.UseReciepeName + "', UseReciepeID = '" + CRMMAin.UseReciepeID + "'  " +
                                        " WHERE TenentID = " + TenentID + " and COMPID = '" + CRMMAin.COMPID + "' and MasterCODE = '" + CRMMAin.MasterCODE + "' and LinkMasterCODE = '" + CRMMAin.LinkMasterCODE + "' and LocationID = '" + CRMMAin.LocationID + "' and MyID= '" + CRMMAin.MyID + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into CRMMainActivities " +
                                          " (TenentID , COMPID , MasterCODE , LinkMasterCODE , LocationID , MyID , RouteID , USERCODE , ACTIVITYE ,ACTIVITYA , ACTIVITYA2 , Reference , AMIGLOBAL , MYPERSONNEL , " +
                                          " INTERVALDAYS , REPEATFOREVER , REPEATTILL , REMINDERNOTE , ESTCOST , GROUPCODE , USERCODEENTERED , UPDTTIME , USERNAME , Remarks , CRUP_ID , Version , Type , MyStatus , " +
                                          " MainID , ModuleID , DisplayFDName , Description , Ratting , Active , JobDone , UploadDate , Uploadby , SynID , UseReciepeName , UseReciepeID) " +
                                          " select " + TenentID + " , '" + CRMMAin.COMPID + "', '" + CRMMAin.MasterCODE + "', '" + CRMMAin.LinkMasterCODE + "', '" + CRMMAin.LocationID + "', " +
                                          " '" + CRMMAin.MyID + "','" + CRMMAin.RouteID + "','" + CRMMAin.USERCODE + "','" + CRMMAin.ACTIVITYE + "','" + CRMMAin.ACTIVITYA + "',  " +
                                          " '" + CRMMAin.ACTIVITYA2 + "','" + CRMMAin.Reference + "','" + CRMMAin.AMIGLOBAL + "','" + CRMMAin.MYPERSONNEL + "','" + CRMMAin.INTERVALDAYS + "', " +
                                          " '" + CRMMAin.REPEATFOREVER + "','" + REPEATTILL + "','" + CRMMAin.REMINDERNOTE + "','" + CRMMAin.ESTCOST + "', '" + CRMMAin.GROUPCODE + "', " +
                                          " '" + CRMMAin.USERCODEENTERED + "','" + UPDTTIME + "','" + CRMMAin.USERNAME + "','" + CRMMAin.Remarks + "','" + CRMMAin.CRUP_ID + "', " +
                                          " '" + CRMMAin.Version + "','" + CRMMAin.Type + "','" + CRMMAin.MyStatus + "','" + CRMMAin.MainID + "','" + CRMMAin.ModuleID + "', " +
                                          " '" + CRMMAin.DisplayFDName + "','" + CRMMAin.Description + "', '" + CRMMAin.Ratting + "','" + CRMMAin.Active + "', '" + CRMMAin.JobDone + "', " +
                                          " '" + UploadDate + "', '" + CRMMAin.Uploadby + "','" + CRMMAin.SynID + "' ,'" + CRMMAin.UseReciepeName + "','" + CRMMAin.UseReciepeID + "' " +
                                          "  where not exists ( SELECT * from CRMMainActivities WHERE TenentID = " + TenentID + " and COMPID = '" + CRMMAin.COMPID + "' and MasterCODE = '" + CRMMAin.MasterCODE + "' and LinkMasterCODE = '" + CRMMAin.LinkMasterCODE + "' and LocationID = '" + CRMMAin.LocationID + "' and MyID= '" + CRMMAin.MyID + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Appointment query :" + ex.Message);
            }

            // ICUOMCONV  35
            backSyncro.Msg = " System is Synchronizing your UOM ConversionData Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<ICUOMCONV> ListCONV = DB.ICUOMCONVs.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListCONV.Count();
                currentCount = 0;
                foreach (ICUOMCONV itemCONV in ListCONV)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemCONV.UploadDate != null ? (Convert.ToDateTime(itemCONV.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update ICUOMCONV set CONVERSION = '" + itemCONV.CONVERSION + "', ConvRatio = '" + itemCONV.ConvRatio + "' , REMARKS = '" + itemCONV.REMARKS + "',  " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemCONV.Uploadby + "' , SynID = '" + itemCONV.SynID + "'" +
                                              " WHERE TenentID = " + TenentID + " and FUOM = " + itemCONV.FUOM + " and TUOM = " + itemCONV.TUOM + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into ICUOMCONV " +
                                          " (TenentID,FUOM,TUOM,CONVERSION,ConvRatio,REMARKS,USERID,ENTRYDATE,ENTRYTIME,UPDTTIME,UploadDate,Uploadby,SynID) " +
                                          "  select " + TenentID + " , " + itemCONV.FUOM + ", '" + itemCONV.TUOM + "' , '" + itemCONV.CONVERSION + "', '" + itemCONV.ConvRatio + "' , '" + itemCONV.REMARKS + "' , " +
                                          " '" + itemCONV.USERID + "' , '" + itemCONV.ENTRYDATE + "' , '" + itemCONV.ENTRYTIME + "' , '" + itemCONV.UPDTTIME + "','" + UploadDate + "','" + itemCONV.Uploadby + "' ,'" + itemCONV.SynID + "' " +
                                          "  where not exists ( SELECT * from ICUOMCONV  WHERE TenentID = " + TenentID + " and FUOM = " + itemCONV.FUOM + " and TUOM = " + itemCONV.TUOM + " );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in UOM ConversionData query :" + ex.Message);
            }

            // REFTABLE  36
            backSyncro.Msg = " System is Synchronizing your REFTABLE Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<REFTABLE> ListRef = DB.REFTABLEs.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListRef.Count();
                currentCount = 0;
                foreach (REFTABLE itemRef in ListRef)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemRef.UploadDate != null ? (Convert.ToDateTime(itemRef.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemRef.SyncDate != null ? (Convert.ToDateTime(itemRef.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update REFTABLE set REFTYPE = '" + itemRef.REFTYPE + "', REFSUBTYPE = '" + itemRef.REFSUBTYPE + "', SHORTNAME = '" + itemRef.SHORTNAME + "', " +
                                              " REFNAME1 = '" + itemRef.REFNAME1 + "', REFNAME2 = '" + itemRef.REFNAME2 + "', REFNAME3 = '" + itemRef.REFNAME3 + "', SWITCH1 = '" + itemRef.SWITCH1 + "', " +
                                              " SWITCH2 = '" + itemRef.SWITCH2 + "', SWITCH3 = '" + itemRef.SWITCH3 + "', SWITCH4 = '" + itemRef.SWITCH4 + "', Remarks = '" + itemRef.Remarks + "', " +
                                              " ACTIVE = '" + itemRef.ACTIVE + "', CRUP_ID = '" + itemRef.CRUP_ID + "', Infrastructure = '" + itemRef.Infrastructure + "', " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemRef.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemRef.Syncby + "' , SynID = '" + itemRef.SynID + "'" +
                                              " WHERE TenentID = " + TenentID + " and REFID = " + itemRef.REFID + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into REFTABLE " +
                                          " (TenentID,REFID,REFTYPE,REFSUBTYPE,SHORTNAME,REFNAME1,REFNAME2,REFNAME3,SWITCH1,SWITCH2,SWITCH3,SWITCH4,Remarks,ACTIVE,CRUP_ID,Infrastructure,UploadDate, " +
                                          " Uploadby,SyncDate,Syncby,SynID) " +
                                          "  select " + TenentID + " , " + itemRef.REFID + ", '" + itemRef.REFTYPE + "' , '" + itemRef.REFSUBTYPE + "', '" + itemRef.SHORTNAME + "' , " +
                                          " '" + itemRef.REFNAME1 + "' , '" + itemRef.REFNAME2 + "' , '" + itemRef.REFNAME3 + "' , '" + itemRef.SWITCH1 + "','" + itemRef.SWITCH2 + "'," +
                                          " '" + itemRef.SWITCH3 + "' , '" + itemRef.SWITCH4 + "' , '" + itemRef.Remarks + "' , '" + itemRef.ACTIVE + "','" + itemRef.CRUP_ID + "','" + itemRef.Infrastructure + "'," +
                                          " '" + UploadDate + "','" + itemRef.Uploadby + "' ,'" + SyncDate + "','" + itemRef.Syncby + "' ,'" + itemRef.SynID + "' " +
                                          "  where not exists ( SELECT * from REFTABLE  WHERE TenentID = " + TenentID + " and REFID = " + itemRef.REFID + ");";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in REFTABLE query :" + ex.Message);
            }

            // tbl_Customer_Medical  37
            backSyncro.Msg = " System is Synchronizing your Customer Medical Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<tbl_Customer_Medical> ListMedical = DB.tbl_Customer_Medical.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListMedical.Count();
                currentCount = 0;
                foreach (tbl_Customer_Medical itemCM in ListMedical)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemCM.UploadDate != null ? (Convert.ToDateTime(itemCM.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemCM.SyncDate != null ? (Convert.ToDateTime(itemCM.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update tbl_Customer_Medical set Age = '" + itemCM.Age + "' , BirthDate = '" + itemCM.BirthDate + "', status = '" + itemCM.status + "' , " +
                                              " Address = '" + itemCM.Address + "' , Phone = '" + itemCM.Phone + "' , RefferdBy = '" + itemCM.RefferdBy + "', Email = '" + itemCM.Email + "', " +
                                              " ChiftComplaint = '" + itemCM.ChiftComplaint + "', ScreenProblem = '" + itemCM.ScreenProblem + "',TakingMedication = '" + itemCM.TakingMedication + "', " +
                                              " ISPregnent = '" + itemCM.ISPregnent + "', AnyRiskFactor = '" + itemCM.AnyRiskFactor + "' , PreviousSkinTreatments = '" + itemCM.PreviousSkinTreatments + "' ,  " +
                                              " ApplyToYou = '" + itemCM.ApplyToYou + "', AnyCondition = '" + itemCM.AnyCondition + "' , " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemCM.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemCM.Syncby + "' , SynID = '" + itemCM.SynID + "'" +
                                              " WHERE TenentID = " + TenentID + " and CustomerID = " + itemCM.CustomerID + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into tbl_Customer_Medical " +
                                          " (TenentID, CustomerID, Age, BirthDate, status, Address, Phone, RefferdBy, Email, ChiftComplaint, ScreenProblem,TakingMedication, ISPregnent,  " +
                                          " AnyRiskFactor, PreviousSkinTreatments, ApplyToYou, AnyCondition, UploadDate, Uploadby,SyncDate,Syncby,SynID) " +
                                          "  select " + TenentID + " , " + itemCM.CustomerID + ", '" + itemCM.Age + "' , '" + itemCM.BirthDate + "', '" + itemCM.status + "' , " +
                                          " '" + itemCM.Address + "' , '" + itemCM.Phone + "' , '" + itemCM.RefferdBy + "' , '" + itemCM.Email + "','" + itemCM.ChiftComplaint + "'," +
                                          " '" + itemCM.ScreenProblem + "' , '" + itemCM.TakingMedication + "' , '" + itemCM.ISPregnent + "' , '" + itemCM.AnyRiskFactor + "', " +
                                          " '" + itemCM.PreviousSkinTreatments + "','" + itemCM.ApplyToYou + "', '" + itemCM.AnyCondition + "', " +
                                          " '" + UploadDate + "','" + itemCM.Uploadby + "' ,'" + SyncDate + "','" + itemCM.Syncby + "' ,'" + itemCM.SynID + "' " +
                                          "  where not exists ( SELECT * from tbl_Customer_Medical  WHERE TenentID = " + TenentID + " and CustomerID = " + itemCM.CustomerID + ");";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Customer Medical query :" + ex.Message);
            }

            // tbl_Customer_Eye_history  38
            backSyncro.Msg = " System is Synchronizing your Customer Eye Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<tbl_Customer_Eye_history> ListEye = DB.tbl_Customer_Eye_history.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListEye.Count();
                currentCount = 0;
                foreach (tbl_Customer_Eye_history itemCE in ListEye)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemCE.UploadDate != null ? (Convert.ToDateTime(itemCE.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemCE.SyncDate != null ? (Convert.ToDateTime(itemCE.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update tbl_Customer_Eye_history set DateOFCheck = '" + itemCE.DateOFCheck + "' , RSPHDistance = '" + itemCE.RSPHDistance + "', RSPHReading = '" + itemCE.RSPHReading + "', " +
                                              " RCylDistance = '" + itemCE.RCylDistance + "' , RCylReading = '" + itemCE.RCylReading + "' , RAxisDistance = '" + itemCE.RAxisDistance + "' , RAxisReading = '" + itemCE.RAxisReading + "' , " +
                                              " LPDDistance = '" + itemCE.LPDDistance + "' , LPDReading = '" + itemCE.LPDReading + "' , LSPHDistance = '" + itemCE.LSPHDistance + "' , LSPHReading = '" + itemCE.LSPHReading + "' , " +
                                              " LCylDistance = '" + itemCE.LCylDistance + "' , LCylReading = '" + itemCE.LCylReading + "' , LAxisDistance = '" + itemCE.LAxisDistance + "' , LAxisReading = '" + itemCE.LAxisReading + "' , " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemCE.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemCE.Syncby + "' , SynID = '" + itemCE.SynID + "'" +
                                              " WHERE TenentID = " + TenentID + " and CustomerID = " + itemCE.CustomerID + " and MyID =" + itemCE.MyID + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into tbl_Customer_Eye_history " +
                                          " (TenentID, CustomerID, MyID, DateOFCheck, RSPHDistance, RSPHReading, RCylDistance, RCylReading, RAxisDistance, RAxisReading, LPDDistance, LPDReading, " +
                                          " LSPHDistance, LSPHReading, LCylDistance, LCylReading, LAxisDistance, LAxisReading, UploadDate, Uploadby, SyncDate, Syncby, SynID) " +
                                          "  select " + TenentID + " , " + itemCE.CustomerID + ", " + itemCE.MyID + " , '" + itemCE.DateOFCheck + "', '" + itemCE.RSPHDistance + "' , " +
                                          " '" + itemCE.RSPHReading + "' , '" + itemCE.RCylDistance + "' , '" + itemCE.RCylReading + "' , '" + itemCE.RAxisDistance + "','" + itemCE.RAxisReading + "', " +
                                          " '" + itemCE.LPDDistance + "' , '" + itemCE.LPDReading + "', '" + itemCE.LSPHDistance + "', '" + itemCE.LSPHReading + "', " +
                                          "  '" + itemCE.LCylDistance + "', '" + itemCE.LCylReading + "', '" + itemCE.LAxisDistance + "', '" + itemCE.LAxisReading + "', " +
                                          " '" + UploadDate + "','" + itemCE.Uploadby + "' ,'" + SyncDate + "','" + itemCE.Syncby + "' ,'" + itemCE.SynID + "' " +
                                          "  where not exists ( SELECT * from tbl_Customer_Eye_history  WHERE TenentID = " + TenentID + " and CustomerID = " + itemCE.CustomerID + " and MyID =" + itemCE.MyID + " );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Customer Eye query :" + ex.Message);
            }

            // AppointmentReceipe  39
            backSyncro.Msg = " System is Synchronizing your Appointment Receipe Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<AppointmentReceipe> ListappReceipe = DB.AppointmentReceipes.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListappReceipe.Count();
                currentCount = 0;
                foreach (AppointmentReceipe itemAR in ListappReceipe)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemAR.UploadDate != null ? (Convert.ToDateTime(itemAR.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemAR.SyncDate != null ? (Convert.ToDateTime(itemAR.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update AppointmentReceipe set  Qty = '" + itemAR.Qty + "', CostPrice= '" + itemAR.CostPrice + "', msrp= '" + itemAR.msrp + "', recNo= '" + itemAR.recNo + "', " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemAR.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemAR.Syncby + "' , SynID = '" + itemAR.SynID + "', product_name= '" + itemAR.product_name + "', RecipeType= '" + itemAR.RecipeType + "', EmpOperator='" + itemAR.EmpOperator + "', QtyIntoCostprice='" + itemAR.QtyIntoCostprice + "'" +
                                              " WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and AppointmentID =" + itemAR.AppointmentID + " and JobID = '" + itemAR.JobID + "' and  IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode  = '" + itemAR.ItemCode + "' and  UOM = '" + itemAR.UOM + "' ;";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into AppointmentReceipe " +
                                          " (TenentID,LocationID, AppointmentID, JobID, IOSwitch, ItemCode, UOM, Qty, CostPrice, msrp, recNo, UploadDate, Uploadby, SyncDate, Syncby, SynID, product_name, RecipeType, EmpOperator,QtyIntoCostprice) " +
                                          "  select " + TenentID + " , " + itemAR.LocationID + ", " + itemAR.AppointmentID + " , '" + itemAR.JobID + "', '" + itemAR.IOSwitch + "' , " +
                                          " '" + itemAR.ItemCode + "' , '" + itemAR.UOM + "' , '" + itemAR.Qty + "' , '" + itemAR.CostPrice + "','" + itemAR.msrp + "','" + itemAR.recNo + "', " +
                                          " '" + UploadDate + "','" + itemAR.Uploadby + "' ,'" + SyncDate + "','" + itemAR.Syncby + "' ,'" + itemAR.SynID + "','" + itemAR.product_name + "','" + itemAR.RecipeType + "', '" + itemAR.EmpOperator + "', '" + itemAR.QtyIntoCostprice + "' " +
                                          "  where not exists ( SELECT * from AppointmentReceipe  WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and AppointmentID =" + itemAR.AppointmentID + " and JobID = '" + itemAR.JobID + "' and  IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode  = '" + itemAR.ItemCode + "' and  UOM = '" + itemAR.UOM + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Appointment Receipe query :" + ex.Message);
            }

            // CommisionPayment  40
            backSyncro.Msg = " System is Synchronizing your Commision Payment  Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<CommisionPayment> ListappCommision = DB.CommisionPayments.Where(p => p.TenentID == TenentID && p.SynID != 3).ToList();
                Totalcount = ListappCommision.Count();
                currentCount = 0;
                foreach (CommisionPayment itemAR in ListappCommision)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemAR.UploadDate != null ? (Convert.ToDateTime(itemAR.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemAR.SyncDate != null ? (Convert.ToDateTime(itemAR.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update CommisionPayment set  PaidAmt = '" + itemAR.PaidAmt + "', PaidDate= '" + itemAR.PaidDate + "', FinaRef= '" + itemAR.FinaRef + "', Status= '" + itemAR.Status + "', " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemAR.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemAR.Syncby + "' , SynID = '" + itemAR.SynID + "', Remark= '" + itemAR.Remark + "', Employee='" + itemAR.Employee + "'" +
                                              " WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and recNo =" + itemAR.recNo + " and IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode = '" + itemAR.ItemCode + "' and  PaymentSerial  = '" + itemAR.PaymentSerial + "' and  UOM = '" + itemAR.UOM + "' and JobNo = '" + itemAR.JobNo + "' );";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into CommisionPayment " +
                                          " (TenentID,LocationID, recNo, IOSwitch, ItemCode, UOM, PaymentSerial, JobNo, PaidAmt, PaidDate, FinaRef, Status, UploadDate, Uploadby, SyncDate, Syncby, SynID, Remark, Employee) " +
                                          "  select " + TenentID + " , " + itemAR.LocationID + ", " + itemAR.recNo + " , '" + itemAR.IOSwitch + "', '" + itemAR.ItemCode + "' , " +
                                          " '" + itemAR.UOM + "' , '" + itemAR.PaymentSerial + "' , '" + itemAR.JobNo + "' , '" + itemAR.PaidAmt + "', '" + itemAR.PaidDate + "','" + itemAR.FinaRef + "','" + itemAR.Status + "', " +
                                          " '" + UploadDate + "','" + itemAR.Uploadby + "' ,'" + SyncDate + "','" + itemAR.Syncby + "' ,'" + itemAR.SynID + "','" + itemAR.Remark + "','" + itemAR.Employee + "'" +
                                          "  where not exists ( SELECT * from CommisionPayment  WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and recNo =" + itemAR.recNo + " and IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode = '" + itemAR.ItemCode + "' and  PaymentSerial  = '" + itemAR.PaymentSerial + "' and  UOM = '" + itemAR.UOM + "' and JobNo = '" + itemAR.JobNo + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }
                                                                                   
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Commision Payment query :" + ex.Message);
            }

            // Win_tbl_UserLog  27
            backSyncro.Msg = " System is Synchronizing your User Log Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                DateTime yesterDay = DateTime.Now.AddDays(-1);
                List<Win_tbl_UserLog> ListUserLog = DB.Win_tbl_UserLog.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.UploadDate > yesterDay).ToList();
                Totalcount = ListUserLog.Count();
                currentCount = 0;
                foreach (Win_tbl_UserLog itemUserLog in ListUserLog)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        DateTime logdate1 = Convert.ToDateTime(itemUserLog.logdate);
                        DateTime logdatetime1 = Convert.ToDateTime(itemUserLog.logdatetime);

                        string logdate = logdate1.ToString("yyyy-MM-dd");
                        string logdatetime = logdatetime1.ToString("yyyy-MM-dd hh:mm:ss");

                        string sql1 = "insert into Win_tbl_UserLog " +
                                          " ( TenentID, id,UserID, Username,ActivityName, Log_Data,logdate , logtime, logdatetime,status ) " +
                                          "  select " + TenentID + ", " + itemUserLog.id + " ," + itemUserLog.UserID + ",'" + itemUserLog.Username + "' ,'" + itemUserLog.ActivityName + "', " +
                                              " '" + itemUserLog.Log_Data + "' , '" + logdate + "' ,'" + itemUserLog.logtime + "' , '" + logdatetime + "' ," + itemUserLog.status + " " +
                                          "  where not exists ( SELECT * from Win_tbl_UserLog  WHERE TenentID =" + TenentID + " and id=" + itemUserLog.id + "  );";
                        DataAccess.ExecuteSQL(sql1);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in User Log query :" + ex.Message);
            }

            Registation.UodateSuperuser();

            backSyncro.Msg = " Live TO Local Syncronize Complate";

            string ActivityName = "Syncronization";
            string LogData = "Syncronization Complate ";
            Login.InsertUserLog(ActivityName, LogData);

        }

        public static void DBSyncro_BAckground(int TenentID, DateTime syncDate)
        {
            bool Falginternet = Login.InternetConnection();

            if (Falginternet == false)
            {
                MessageBox.Show("Internet Connection Not Avalable");
                return;
            }

            bool CON_Ceck = Login.CheckDBConnection();
            if (CON_Ceck == false)
            {
                MessageBox.Show("online Server Connection Fail");
                return;
            }

            string ActivityName = "Syncronization";
            string LogData = "Syncronization Start ";
            Login.InsertUserLog(ActivityName, LogData);

            Call_suncro();

            int Totalcount = 0;
            int currentCount = 0;

            // mycompanysetup_winapp  1

            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your company setup Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {

                    string Mac = Login.GetMACAddress();
                    List<Win_mycompanysetup_winapp> Listmycompanysetup = DB.Win_mycompanysetup_winapp.Where(p => p.TenentID == TenentID && p.Mac_Addr.Contains(Mac) && p.UploadDate >= syncDate).ToList();
                    Totalcount = Listmycompanysetup.Count();
                    currentCount = 0;
                    foreach (Win_mycompanysetup_winapp items in Listmycompanysetup)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            string sqlCmdupdate = "update mycompanysetup_winapp set COMPNAME1='" + items.COMPNAME1 + "',COMPNAME2='" + items.COMPNAME2 + "', " +
                                       " COMPNAME3='" + items.COMPNAME3 + "',COUNTRYID='" + items.COUNTRYID + "', " +
                                       " DefaultLanguage='" + items.DefaultLanguage + "',AllowUser='" + items.AllowUser + "' " +
                                       " where TenentID= " + TenentID + " and Shopid = '" + items.Shopid + "' and Mac_Addr ='" + items.Mac_Addr + "' ;";
                            int Falg = DataAccess.ExecuteSQL(sqlCmdupdate);

                            if (Falg != 1)
                            {

                                string sqlinsert = "insert into mycompanysetup_winapp " +
                                                   " (TenentID, Shopid, TenentGroupID ,COMPNAME1 , COMPNAME2 ,  COMPNAME3, COUNTRYID , Mac_Addr,DefaultLanguage,AllowUser) " +
                                                   "  select " + TenentID + ",'" + items.Shopid + "'," + items.TenentGroupID + ",'" + items.COMPNAME1 + "','" + items.COMPNAME2 + "', " +
                                                   " '" + items.COMPNAME3 + "'," + items.COUNTRYID + ",'" + items.Mac_Addr + "','" + items.DefaultLanguage + "', '" + items.AllowUser + "' " +
                                                   "  where not exists ( SELECT * from mycompanysetup_winapp  WHERE TenentID= " + TenentID + " and Shopid = '" + items.Shopid + "' and Mac_Addr ='" + items.Mac_Addr + "' );";
                                DataAccess.ExecuteSQL(sqlinsert);
                            }

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in mycompanysetup_winapp query :" + ex.Message);
                }
            }


            // storeconfig  2

            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your store Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<Win_storeconfig> LisStore = DB.Win_storeconfig.Where(p => p.TenentID == TenentID && p.UploadDate >= syncDate).ToList();
                    Totalcount = LisStore.Count();
                    currentCount = 0;
                    foreach (Win_storeconfig itemstore in LisStore)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            string sqlCmd = "Select * from  storeconfig  where TenentID =" + TenentID + " and companyname  = '" + itemstore.companyname + "' ";
                            DataAccess.ExecuteSQL(sqlCmd);
                            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                            if (dt1.Rows.Count < 1)
                            {
                                string sqlstoreconfig = "Select * from storeconfig";
                                DataAccess.ExecuteSQL(sqlstoreconfig);
                                DataTable dtstoreconfig = DataAccess.GetDataTable(sqlstoreconfig);
                                int id = 1;
                                if (dtstoreconfig.Rows.Count > 0)
                                {
                                    int ID = Convert.ToInt32(dtstoreconfig.Rows[0]["id"]);
                                    id = (ID + 1);
                                }
                                string Sqlinsert = "insert into storeconfig (TenentID, id, companyname, companyaddress,companyphone,vatno,web,vatrate,disrate,footermsg,FaceBook,Twitter,Insta,DbPath,ImgPath,InvAddtionalLine,Logo) " +
                               "  values( " + TenentID + ", " + id + ",'" + itemstore.companyname + "', '" + itemstore.companyaddress + "', '" + itemstore.companyphone + "', '" + itemstore.vatno + "','" + itemstore.web + "', " +
                                        " '" + itemstore.vatrate + "', '" + itemstore.disrate + "' , '" + itemstore.footermsg + "',   " +
                                        " '" + itemstore.footermsg + "', '" + itemstore.Twitter + "' , '" + itemstore.Insta + "',   " +
                                        " '" + itemstore.DbPath + "', '" + itemstore.ImgPath + "','" + itemstore.InvAddtionalLine + "','" + itemstore.Logo + "' )";
                                DataAccess.ExecuteSQL(Sqlinsert);
                            }
                            else
                            {
                                string sql = "update storeconfig set companyname= '" + itemstore.companyname + "', companyaddress = '" + itemstore.companyaddress + "', " +
                               " companyphone = '" + itemstore.companyphone + "', vatno = '" + itemstore.vatno + "' , web = '" + itemstore.web + "' ,    " +
                                " vatrate = '" + itemstore.vatrate + "', disrate = '" + itemstore.disrate + "' , footermsg = '" + itemstore.footermsg + "' ,   " +
                                " FaceBook = '" + itemstore.FaceBook + "', Twitter = '" + itemstore.Twitter + "' , Insta = '" + itemstore.Insta + "' , InvAddtionalLine='" + itemstore.InvAddtionalLine + "',  " +
                                 " DbPath = '" + itemstore.DbPath + "', ImgPath = '" + itemstore.ImgPath + "', Logo='" + itemstore.Logo + "', " +
                               " UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null  where TenentID = " + TenentID + " and  companyname  = '" + itemstore.companyname + "' ";
                                DataAccess.ExecuteSQL(sql);
                            }
                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in storeconfig query :" + ex.Message);
                }
            }

            // tbl_terminallocation  3

            backSyncro.Msg = "System is Synchronizing your Terminal Data Please Wait !!";
            backSyncro.MsgCount = "-";

            try
            {
                List<Win_tbl_terminalLocation> Listterminal = DB.Win_tbl_terminalLocation.Where(p => p.TenentID == TenentID && p.UploadDate >= syncDate).ToList();
                Totalcount = Listterminal.Count();
                currentCount = 0;
                foreach (Win_tbl_terminalLocation itemterminal in Listterminal)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmd = "Select * from  tbl_terminallocation  where TenentID =" + TenentID + " and Shopid = '" + itemterminal.Shopid + "' ";
                        DataAccess.ExecuteSQL(sqlCmd);
                        DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                        if (dt1.Rows.Count < 1)
                        {
                            string sqlinsert = " insert into tbl_terminallocation " +
                                               "(TenentID,ID,Shopid,Terminal_Type, CompanyName, Branchname , Location ,Phone , Email ,  Web, VAT , Dis , " +
                                               " VATRegiNo , Footermsg,FaceBook,Twitter,Insta,InvAddtionalLine,DbPath,ImgPath,syncAfter,dayofSync,Salesync) " +
                                               " values (" + TenentID + "," + itemterminal.ID + ",'" + itemterminal.Shopid + "' , '" + itemterminal.Terminal_Type + "' , '" + itemterminal.CompanyName + "' , '" + itemterminal.Branchname + "' , " +
                                               " '" + itemterminal.Location + "' , '" + itemterminal.Phone + "' , '" + itemterminal.Email + "' ," +
                                               " '" + itemterminal.Web + "',  '" + itemterminal.VAT + "', " +
                                               " '" + itemterminal.Dis + "' , '" + itemterminal.VATRegiNo + "',  '" + itemterminal.Footermsg + "' ," +
                                               " '" + itemterminal.FaceBook + "','" + itemterminal.Twitter + "','" + itemterminal.Insta + "','" + itemterminal.InvAddtionalLine + "'," +
                                               " '" + itemterminal.DbPath + "',  '" + itemterminal.ImgPath + "'," + itemterminal.syncAfter + "," + itemterminal.dayofSync + " , " + itemterminal.Salesync + " )";
                            DataAccess.ExecuteSQL(sqlinsert);
                        }
                        else
                        {
                            string sql = "update tbl_terminallocation set Terminal_Type = '" + itemterminal.Terminal_Type + "', Branchname = '" + itemterminal.Branchname + "', Location = '" + itemterminal.Location + "', " +
                               " Email = '" + itemterminal.Email + "' , Phone = '" + itemterminal.Phone + "', VAT = '" + itemterminal.VAT + "' , Web = '" + itemterminal.Web + "' ,    " +
                               " Dis = '" + itemterminal.Dis + "', VATRegiNo = '" + itemterminal.VATRegiNo + "' , Footermsg = '" + itemterminal.Footermsg + "' ,   " +
                               " CompanyName = '" + itemterminal.CompanyName + "' , FaceBook = '" + itemterminal.FaceBook + "', Twitter = '" + itemterminal.Twitter + "', Insta = '" + itemterminal.Insta + "' ,InvAddtionalLine= '" + itemterminal.InvAddtionalLine + "' ,   " +
                               " DbPath = '" + itemterminal.DbPath + "', ImgPath = '" + itemterminal.ImgPath + "',syncAfter = " + itemterminal.syncAfter + ",dayofSync = " + itemterminal.dayofSync + " , Salesync = " + itemterminal.Salesync + " ," +
                               " UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null  where TenentID = " + TenentID + " and Shopid = '" + itemterminal.Shopid + "' ";
                            DataAccess.ExecuteSQL(sql);
                        }
                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_terminallocation query :" + ex.Message);
            }


            // usermgt  4
            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your User Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<Win_usermgt> Listuser = DB.Win_usermgt.Where(p => p.TenentID == TenentID && p.UploadDate >= syncDate && ((p.SynID != 3 && p.SynID != 9) || p.SynID == null)).ToList();
                    Totalcount = Listuser.Count();
                    currentCount = 0;
                    foreach (Win_usermgt itemuser in Listuser)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            string sql3 = "select * from usermgt where TenentID =" + TenentID + " and Username= '" + itemuser.Username + "' and password= '" + itemuser.password + "' ";
                            DataAccess.ExecuteSQL(sql3);
                            DataTable dt1 = DataAccess.GetDataTable(sql3);

                            if (dt1.Rows.Count < 1)
                            {
                                string sql1 = "insert into usermgt (TenentID,id, Name, Father_name, Address, Email , Contact, DOB , Username , password , usertype , position , imagename, Shopid ) " +
                                                 "  values(" + TenentID + "," + itemuser.id + " , '" + itemuser.Name + "', '" + itemuser.Father_name + "', '" + itemuser.Address + "', '" + itemuser.Email + "', " +
                                                 " '" + itemuser.Contact + "',  '" + itemuser.DOB + "', '" + itemuser.Username + "', '" + itemuser.password + "', " +
                                                 " '" + itemuser.usertype + "', '" + itemuser.position + "' , '" + itemuser.imagename + "' , '" + itemuser.Shopid + "')";
                                DataAccess.ExecuteSQL(sql1);
                            }
                            else
                            {
                                string sql = "UPDATE usermgt set  Name = '" + itemuser.Name + "', Father_name = '" + itemuser.Father_name + "', " +
                                    " Address = '" + itemuser.Address + "', Email = '" + itemuser.Email + "', Contact = '" + itemuser.Contact + "', " +
                                    " DOB = '" + itemuser.DOB + "' , Username= '" + itemuser.Username + "', password = '" + itemuser.password + "',imagename = '" + itemuser.imagename + "' ,    " +
                                    " usertype    = '" + itemuser.usertype + "', position = '" + itemuser.position + "', Shopid = '" + itemuser.Shopid + "',UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null " +
                                    " where TenentID =" + TenentID + " and Username= '" + itemuser.Username + "' and password= '" + itemuser.password + "'";
                                DataAccess.ExecuteSQL(sql);
                            }

                            string Dicstring = "update Win_usermgt set SynID = 9 where TenentID =" + TenentID + " and Username= '" + itemuser.Username + "' and password= '" + itemuser.password + "'; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in usermgt query :" + ex.Message);
                }
            }


            // CAT_MST  5

            backSyncro.Msg = "System is Synchronizing your Catagory Data Please Wait !!";
            backSyncro.MsgCount = "-";

            try
            {
                List<CAT_MST> ListCAT_MST = DB.CAT_MST.Where(p => p.TenentID == TenentID && p.UploadDate >= syncDate).ToList();
                Totalcount = ListCAT_MST.Count();
                currentCount = 0;
                foreach (CAT_MST itemCAT_MST in ListCAT_MST)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdupdate = "update CAT_MST set CAT_TYPE = 'WEBSALE', DefaultPic='" + itemCAT_MST.DefaultPic + "',SHORT_NAME='" + itemCAT_MST.SHORT_NAME + "', " +
                                        " CAT_NAME1='" + itemCAT_MST.CAT_NAME1 + "',CAT_NAME2='" + itemCAT_MST.CAT_NAME2 + "', " +
                                        " DisplaySort='" + itemCAT_MST.DisplaySort + "',AlwaysShow='" + itemCAT_MST.AlwaysShow + "' " +
                                        " where TenentID =" + TenentID + " and CATID='" + itemCAT_MST.CATID + "' ;";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdupdate);

                        if (Falg != 1)
                        {
                            string sqlCmd = "insert into CAT_MST " +
                                       " (TenentID,CATID,PARENT_CATID, SHORT_NAME,CAT_NAME1,CAT_NAME2,CAT_NAME3,CAT_TYPE,DefaultPic,DisplaySort,AlwaysShow,COLOR_NAME) " +
                                       "  select " + TenentID + "," + itemCAT_MST.CATID + ",'" + itemCAT_MST.PARENT_CATID + "','" + itemCAT_MST.SHORT_NAME + "','" + itemCAT_MST.CAT_NAME1 + "','" + itemCAT_MST.CAT_NAME2 + "','" + itemCAT_MST.CAT_NAME3 + "', 'WEBSALE','" + itemCAT_MST.DefaultPic + "', " +
                                       "  '" + itemCAT_MST.DisplaySort + "' , '" + itemCAT_MST.AlwaysShow + "','" + itemCAT_MST.COLOR_NAME + "' " +
                                       "  where not exists ( SELECT * from CAT_MST  WHERE TenentID =" + TenentID + " and CATID = " + itemCAT_MST.CATID + " );";
                            DataAccess.ExecuteSQL(sqlCmd);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in CAT_MST query :" + ex.Message);
            }

            // purchase  6
            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your purchase Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<Win_purchase> Listpurchase = DB.Win_purchase.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                    Totalcount = Listpurchase.Count();
                    currentCount = 0;
                    foreach (Win_purchase itempurchase in Listpurchase)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            int BaseUOM = itempurchase.BaseUOM != null ? Convert.ToInt32(itempurchase.BaseUOM) : 0;
                            int IsPerishable = itempurchase.IsPerishable != null ? Convert.ToInt32(itempurchase.IsPerishable) : 0;
                            string sqlCmdUpdate = "update purchase set product_name='" + itempurchase.product_name + "' , category='" + itempurchase.category + "' , " +
                                                " supplier='" + itempurchase.supplier + "' , imagename='" + itempurchase.imagename + "' , taxapply='" + itempurchase.taxapply + "' , Shopid='" + itempurchase.Shopid + "' , " +
                                                " status='" + itempurchase.status + "' , product_name_Arabic='" + itempurchase.product_name_Arabic + "' , category_arabic='" + itempurchase.category_arabic + "', " +
                                                " ExpiryDate = '" + itempurchase.ExpiryDate + "', IsPerishable = '" + IsPerishable + "' , CustItemCode = '" + itempurchase.CustItemCode + "', BarCode = '" + itempurchase.BarCode + "' , BaseUOM = '" + BaseUOM + "'  " +
                                                " where TenentID =" + TenentID + " and product_id='" + itempurchase.product_id + "' ";
                            int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                            if (Falg != 1)
                            {
                                string sqlCmd = "insert into purchase " +
                                               " (TenentID, product_id ,UOM, product_name ,product_name_print," +
                                                " supplier , category , imagename, taxapply, Shopid, status,product_name_Arabic,category_arabic,ExpiryDate,	IsPerishable,CustItemCode,BarCode,BaseUOM) " +
                                               "  select " + TenentID + ",'" + itempurchase.product_id + "' ,'" + itempurchase.UOM + "' , '" + itempurchase.product_name + "','" + itempurchase.product_name_print + "',  " +
                                                " '" + itempurchase.supplier + "', '" + itempurchase.category + "', '" + itempurchase.imagename + "' , " +
                                                " '" + itempurchase.taxapply + "' , '" + itempurchase.Shopid + "', '" + itempurchase.status + "', '" + itempurchase.product_name_Arabic + "', '" + itempurchase.category_arabic + "' , " +
                                                " '" + itempurchase.ExpiryDate + "' , '" + IsPerishable + "','" + itempurchase.CustItemCode + "','" + itempurchase.BarCode + "', '" + BaseUOM + "'  " +
                                               "  where not exists ( SELECT * from purchase  WHERE TenentID =" + TenentID + " and product_id='" + itempurchase.product_id + "');";
                                DataAccess.ExecuteSQL(sqlCmd);
                            }

                            string Dicstring = "update Win_purchase set SynID = 9 where TenentID =" + TenentID + " and product_id='" + itempurchase.product_id + "'; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in purchase query :" + ex.Message);
                }
            }

            // tbl_item_uom_price  7
            backSyncro.Msg = "System is Synchronizing your item uom price Data Please Wait !!";
            backSyncro.MsgCount = "-";

            try
            {
                List<Win_tbl_item_uom_price> Listuom_price = DB.Win_tbl_item_uom_price.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = Listuom_price.Count();
                currentCount = 0;
                foreach (Win_tbl_item_uom_price item_uom_price in Listuom_price)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        decimal total_cost_price = item_uom_price.total_cost_price != null ? Convert.ToDecimal(item_uom_price.total_cost_price) : 0;
                        decimal total_retail_price = item_uom_price.total_retail_price != null ? Convert.ToDecimal(item_uom_price.total_retail_price) : 0;
                        int recNo = item_uom_price.recNo != null ? Convert.ToInt32(item_uom_price.recNo) : 0;
                        decimal Discount = item_uom_price.Discount != null ? Convert.ToDecimal(item_uom_price.Discount) : 0;

                        string sql1Update = "update tbl_item_uom_price set OpQty = '" + item_uom_price.OpQty + "',OnHand = '" + item_uom_price.OnHand + "', " +
                                       " QtyOut = '" + item_uom_price.QtyOut + "',QtyConsumed = '" + item_uom_price.QtyConsumed + "', QtyReserved = '" + item_uom_price.QtyReserved + "', " +
                                       " QtyRecived = '" + item_uom_price.QtyRecived + "' , Deleted = '" + item_uom_price.Deleted + "',Discount='" + Discount + "' , " +
                                       " price = '" + item_uom_price.price + "' , msrp = '" + item_uom_price.msrp + "' , " +
                                       " minQty ='" + item_uom_price.minQty + "' , MaxQty = '" + item_uom_price.MaxQty + "' ,total_cost_price = '" + total_cost_price + "' , " +
                                       " RecipeType = '" + item_uom_price.RecipeType + "' , recNo = " + recNo + " , " +
                                       " total_retail_price = '" + total_retail_price + "' , ExpiryDate = '" + item_uom_price.ExpiryDate + "' " +
                                       " where TenentID =" + TenentID + " and itemID='" + item_uom_price.itemID + "' and UOMID='" + item_uom_price.UOMID + "'";
                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_item_uom_price " +
                                           " (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,price,msrp,Deleted,minQty,MaxQty,Discount,total_cost_price,total_retail_price,ExpiryDate,RecipeType,recNo) " +
                                           "  select " + TenentID + "," + item_uom_price.ID + ",'" + item_uom_price.itemID + "', '" + item_uom_price.UOMID + "', '" + item_uom_price.OpQty + "', '" + item_uom_price.OnHand + "' , " +
                                             " '" + item_uom_price.QtyOut + "', '" + item_uom_price.QtyConsumed + "', '" + item_uom_price.QtyReserved + "', '" + item_uom_price.QtyRecived + "', " +
                                             " '" + item_uom_price.price + "', '" + item_uom_price.msrp + "','" + item_uom_price.Deleted + "', '" + item_uom_price.minQty + "', '" + item_uom_price.MaxQty + "', '" + Discount + "', " +
                                             " '" + total_cost_price + "','" + total_retail_price + "','" + item_uom_price.ExpiryDate + "','" + item_uom_price.RecipeType + "' , " + recNo + " " +
                                           "  where not exists ( SELECT * from tbl_item_uom_price  WHERE TenentID =" + TenentID + " and itemID='" + item_uom_price.itemID + "' and UOMID='" + item_uom_price.UOMID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update Win_tbl_item_uom_price set SynID = 9 where TenentID =" + TenentID + " and itemID='" + item_uom_price.itemID + "' and UOMID='" + item_uom_price.UOMID + "'; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_item_uom_price query :" + ex.Message);
            }


            // tbl_customer  8

            backSyncro.Msg = "System is Synchronizing your customer Data Please Wait !!";
            backSyncro.MsgCount = "-";

            try
            {
                List<Win_tbl_customer> Listcustomer = DB.Win_tbl_customer.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = Listcustomer.Count();
                currentCount = 0;
                foreach (Win_tbl_customer itemCustomer in Listcustomer)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlUpdateCmd = "update tbl_customer set Name = '" + itemCustomer.Name + "', NameArabic= '" + itemCustomer.NameArabic + "' , EmailAddress= '" + itemCustomer.EmailAddress + "', " +
                                 " address = '" + itemCustomer.Address + "', Phone = '" + itemCustomer.Phone + "', City = '" + itemCustomer.City + "' , PeopleType = '" + itemCustomer.PeopleType + "', " +
                                 " Facebook= '" + itemCustomer.Facebook + "', Twitter= '" + itemCustomer.Twitter + "', Insta= '" + itemCustomer.Insta + "', DateOfBirth = '" + itemCustomer.DateOfBirth + "', DateOfBirth = '" + itemCustomer.DateOfAnniversary + "' , Remark = '" + itemCustomer.Remark + "', " +
                                 "UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null   where TenentID = " + TenentID + " and ID='" + itemCustomer.ID + "'";
                        int Falg = DataAccess.ExecuteSQL(sqlUpdateCmd);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_customer " +
                                       " (TenentID,ID, Name, EmailAddress, Phone, address, City, PeopleType,Facebook,Twitter,Insta,NameArabic,DateOfBirth,DateOfBirth,Remark) " +
                                       "  select " + TenentID + ",'" + itemCustomer.ID + "','" + itemCustomer.Name + "', '" + itemCustomer.EmailAddress + "', '" + itemCustomer.Phone + "', '" + itemCustomer.Address + "', " +
                                       " '" + itemCustomer.City + "', '" + itemCustomer.PeopleType + "', '" + itemCustomer.Facebook + "', '" + itemCustomer.Twitter + "', '" + itemCustomer.Insta + "', '" + itemCustomer.NameArabic + "','" + itemCustomer.DateOfBirth + "','" + itemCustomer.DateOfAnniversary + "','" + itemCustomer.Remark + "' " +
                                       "  where not exists ( SELECT * from tbl_customer  WHERE TenentID =" + TenentID + " and ID='" + itemCustomer.ID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update Win_tbl_customer set SynID = 9 where TenentID =" + TenentID + " and ID='" + itemCustomer.ID + "'; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_customer query :" + ex.Message);
            }



            // tbl_purchase_history  9

            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your purchase history Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<Win_tbl_purchase_history> Listpurchase_history = DB.Win_tbl_purchase_history.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                    Totalcount = Listpurchase_history.Count();
                    currentCount = 0;
                    foreach (Win_tbl_purchase_history item_history in Listpurchase_history)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            int MYTRANSID = item_history.MYTRANSID != null ? Convert.ToInt32(item_history.MYTRANSID) : 0;
                            string sqlpur = " update tbl_purchase_history  set product_id='" + item_history.product_id + "', product_name='" + item_history.product_name + "', product_quantity = '" + item_history.product_quantity + "' ,  retail_price='" + item_history.retail_price + "', " +
                                             " cost_price='" + item_history.cost_price + "', category='" + item_history.category + "',supplier='" + item_history.supplier + "', purchase_date='" + item_history.purchase_date + "',Shopid='" + item_history.Shopid + "', ptype='" + item_history.ptype + "', " +
                                             " uom='" + item_history.UOM + "' , ExpiryDate = '" + item_history.ExpiryDate + "' , TotalCost_price = '" + item_history.TotalCost_price + "', MYTRANSID = '" + MYTRANSID + "', InvoiceNO = '" + item_history.InvoiceNO + "', TranStatus = '" + item_history.TranStatus + "',Remarks = '" + item_history.Remarks + "'  " +
                                             " where TenentID = " + TenentID + " and id='" + item_history.id + "' ";

                            int Falg = DataAccess.ExecuteSQL(sqlpur);

                            if (Falg != 1)
                            {
                                string sql1 = "insert into tbl_purchase_history " +
                                               " (TenentID,id, product_id, product_name,product_quantity,retail_price, cost_price, category,supplier, purchase_date, Shopid, ptype,uom,ExpiryDate,TotalCost_price,MYTRANSID,InvoiceNO,TranStatus,Remarks ) " +
                                               "  select " + TenentID + "," + item_history.id + ",'" + item_history.product_id + "', '" + item_history.product_name + "', '" + item_history.product_quantity + "' , '" + item_history.retail_price + "', '" + item_history.cost_price + "', '" + item_history.category + "', " +
                                                "  '" + item_history.supplier + "', '" + item_history.purchase_date + "' ,'" + item_history.Shopid + "', '" + item_history.ptype + "','" + item_history.UOM + "','" + item_history.ExpiryDate + "','" + item_history.TotalCost_price + "' , '" + MYTRANSID + "','" + item_history.InvoiceNO + "','" + item_history.TranStatus + "','" + item_history.Remarks + "' " +
                                               "  where not exists ( SELECT * from tbl_purchase_history  WHERE TenentID =" + TenentID + " and id='" + item_history.id + "' );";
                                DataAccess.ExecuteSQL(sql1);
                            }

                            string Dicstring = "update Win_tbl_purchase_history set SynID = 9 where TenentID =" + TenentID + " and id='" + item_history.id + "'; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in tbl_purchase_history query :" + ex.Message);
                }
            }

            // sales_item  10

            backSyncro.Msg = "System is Synchronizing your sales item Data Please Wait !!";
            backSyncro.MsgCount = "-";

            try
            {
                List<Win_sales_item> Listsales_item = DB.Win_sales_item.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = Listsales_item.Count();
                currentCount = 0;
                foreach (Win_sales_item itemsales in Listsales_item)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int COD = itemsales.COD != null ? Convert.ToInt32(itemsales.COD) : 0;
                        decimal OrderTotal = itemsales.OrderTotal != null ? Convert.ToDecimal(itemsales.OrderTotal) : 0;

                        string sql1update = " Update sales_item set itemName='" + itemsales.itemName + "',Qty='" + itemsales.Qty + "',RetailsPrice='" + itemsales.RetailsPrice + "', " +
                            " Total='" + itemsales.Total + "', profit='" + itemsales.profit + "',sales_time='" + itemsales.sales_time + "', itemcode='" + itemsales.itemcode + "' , " +
                            " discount='" + itemsales.discount + "', taxapply='" + itemsales.taxapply + "', status='" + itemsales.status + "',UOM='" + itemsales.UOM + "', " +
                            " Customer='" + itemsales.Customer + "',InvoiceNO='" + itemsales.InvoiceNO + "',returnQty='" + itemsales.returnQty + "',returnTotal='" + itemsales.returnTotal + "' , " +
                            " product_name_print = '" + itemsales.product_name_print + "' , ExpiryDate = '" + itemsales.ExpiryDate + "', SoldBy = '" + itemsales.SoldBy + "' , " +
                            " OrderStutas = '" + itemsales.OrderStutas + "', Driver = '" + itemsales.Driver + "' ,COD = '" + COD + "' , OrderTotal = '" + OrderTotal + "' ,  " +
                            " PaymentMode = '" + itemsales.PaymentMode + "', Shopid = '" + itemsales.Shopid + "' , c_id = '" + itemsales.c_id + "' , BatchNo = '" + itemsales.BatchNo + "', OrderWay = '" + itemsales.OrderWay + "', " +
                            " CustItemCode = '" + itemsales.CustItemCode + "',BarCode= '" + itemsales.BarCode + "',ISPaymentCredit = '" + itemsales.ISPaymentCredit + "', Remarks = '" + itemsales.Remarks + "' " +
                            " where TenentID =" + TenentID + " and sales_id='" + itemsales.sales_id + "' and item_id='" + itemsales.item_id + "' and UOM='" + itemsales.UOM + "' and BatchNo='" + itemsales.BatchNo + "' and Shopid = '" + itemsales.Shopid + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sql1update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into sales_item " +
                                          " (TenentID, item_id, sales_id,itemName,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, status,UOM,Customer,InvoiceNO,returnQty,returnTotal, " +
                                          " product_name_print,ExpiryDate,SoldBy,OrderStutas,Driver,COD,OrderTotal,PaymentMode,Shopid,c_id,BatchNo,OrderWay,CustItemCode,BarCode,ISPaymentCredit ,Remarks ) " +
                                          "  select " + TenentID + ", '" + itemsales.item_id + "' ,'" + itemsales.sales_id + "', '" + itemsales.itemName + "', '" + itemsales.Qty + "', '" + itemsales.RetailsPrice + "', '" + itemsales.Total + "', '" + itemsales.profit + "', " +
                                          " '" + itemsales.sales_time + "','" + itemsales.itemcode + "','" + itemsales.discount + "','" + itemsales.taxapply + "','" + itemsales.status + "','" + itemsales.UOM + "', " +
                                          " '" + itemsales.Customer + "','" + itemsales.InvoiceNO + "','" + itemsales.returnQty + "','" + itemsales.returnTotal + "','" + itemsales.product_name_print + "' ,'" + itemsales.ExpiryDate + "' , " +
                                          " '" + itemsales.SoldBy + "','" + itemsales.OrderStutas + "','" + itemsales.Driver + "','" + COD + "','" + OrderTotal + "', '" + itemsales.PaymentMode + "', " +
                                          " '" + itemsales.Shopid + "','" + itemsales.c_id + "','" + itemsales.BatchNo + "','" + itemsales.OrderWay + "','" + itemsales.CustItemCode + "','" + itemsales.BarCode + "','" + itemsales.ISPaymentCredit + "', '" + itemsales.Remarks + "'  " +
                                          "  where not exists ( SELECT * from sales_item  WHERE TenentID =" + TenentID + " and sales_id='" + itemsales.sales_id + "' and item_id='" + itemsales.item_id + "' and UOM='" + itemsales.UOM + "' and BatchNo='" + itemsales.BatchNo + "' and Shopid = '" + itemsales.Shopid + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update Win_sales_item set SynID = 9 where TenentID =" + TenentID + " and sales_id='" + itemsales.sales_id + "' and item_id='" + itemsales.item_id + "' and UOM='" + itemsales.UOM + "' and BatchNo='" + itemsales.BatchNo + "' and Shopid = '" + itemsales.Shopid + "'; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in sales_item query :" + ex.Message);
            }


            // sales_payment 11

            backSyncro.Msg = "System is Synchronizing your sales payment Data Please Wait !!";
            backSyncro.MsgCount = "-";

            try
            {
                List<Win_sales_payment> Listpayment = DB.Win_sales_payment.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = Listpayment.Count();
                currentCount = 0;
                foreach (Win_sales_payment itempayment in Listpayment)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        decimal Delivery_Cahrge = itempayment.Delivery_Cahrge != null ? Convert.ToDecimal(itempayment.Delivery_Cahrge) : 0;

                        string sql1Update = " Update sales_payment set return_id='" + itempayment.return_id + "', payment_type='" + itempayment.payment_type + "',Reffrance='" + itempayment.Reffrance + "', " +
                                    " payment_amount='" + itempayment.payment_amount + "',change_amount='" + itempayment.change_amount + "',due_amount='" + itempayment.due_amount + "', dis='" + itempayment.dis + "', vat='" + itempayment.vat + "', " +
                                    " sales_time='" + itempayment.sales_time + "',c_id='" + itempayment.c_id + "',emp_id='" + itempayment.emp_id + "',comment='" + itempayment.comment + "', TrxType='" + itempayment.TrxType + "', " +
                                    " Shopid='" + itempayment.Shopid + "', ovdisrate='" + itempayment.ovdisrate + "', vaterate='" + itempayment.vaterate + "',InvoiceNO='" + itempayment.InvoiceNO + "',Customer='" + itempayment.Customer + "' , " +
                                    " Delivery_Cahrge = '" + itempayment.Delivery_Cahrge + "' , PaymentStutas = '" + itempayment.PaymentStutas + "', AmountSplit = '" + itempayment.AmountSplit + "', SaleDt = '" + itempayment.SaleDt + "' " +
                                    " where TenentID =" + TenentID + " and sales_id='" + itempayment.sales_id + "' and payment_type='" + itempayment.payment_type + "' and Shopid = '" + itempayment.Shopid + "' ";

                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into sales_payment " +
                                           " (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                           " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Delivery_Cahrge,PaymentStutas,AmountSplit,SaleDt ) " +
                                           "  select " + TenentID + ",'" + itempayment.ID + "','" + itempayment.sales_id + "','" + itempayment.return_id + "','" + itempayment.payment_type + "','" + itempayment.Reffrance + "' , " +
                                           " '" + itempayment.payment_amount + "', '" + itempayment.change_amount + "', " +
                                           " '" + itempayment.due_amount + "', '" + itempayment.dis + "', '" + itempayment.vat + "', '" + itempayment.sales_time + "', '" + itempayment.c_id + "', " +
                                           " '" + itempayment.emp_id + "','" + itempayment.comment + "','" + itempayment.TrxType + "','" + itempayment.Shopid + "' , '" + itempayment.ovdisrate + "' , " +
                                           " '" + itempayment.vaterate + "','" + itempayment.InvoiceNO + "','" + itempayment.Customer + "','" + Delivery_Cahrge + "','" + itempayment.PaymentStutas + "','" + itempayment.AmountSplit + "','" + itempayment.SaleDt + "' " +
                                           "  where not exists ( SELECT * from sales_payment  WHERE TenentID =" + TenentID + " and sales_id='" + itempayment.sales_id + "' and payment_type='" + itempayment.payment_type + "' and Shopid = '" + itempayment.Shopid + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update Win_sales_payment set SynID = 9 where TenentID =" + TenentID + " and sales_id='" + itempayment.sales_id + "' and payment_type='" + itempayment.payment_type + "' and Shopid = '" + itempayment.Shopid + "'; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in sales_payment query :" + ex.Message);
            }

            // return_item  12

            backSyncro.Msg = "System is Synchronizing your return item Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_return_item> Listreturn = DB.Win_return_item.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = Listreturn.Count();
                currentCount = 0;
                foreach (Win_return_item intemreturn in Listreturn)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int IsWastage = intemreturn.IsWastage != null ? Convert.ToInt32(intemreturn.IsWastage) : 0;

                        string sql1Update = " update return_item set  itemName='" + intemreturn.itemName + "', Qty='" + intemreturn.Qty + "', RetailsPrice ='" + intemreturn.RetailsPrice + "', " +
                            " Total='" + intemreturn.Total + "', return_time='" + intemreturn.return_time + "', custno='" + intemreturn.custno + "', emp='" + intemreturn.emp + "', " +
                            " SoldInvoiceNo='" + intemreturn.SoldInvoiceNo + "', Comment='" + intemreturn.Comment + "', disamt='" + intemreturn.disamt + "' , " +
                            " vatamt='" + intemreturn.vatamt + "',UOM='" + intemreturn.UOM + "',Customer='" + intemreturn.Customer + "' , ExpiryDate = '" + intemreturn.ExpiryDate + "', " +
                            " ReturnReason = '" + intemreturn.ReturnReason + "', IsWastage = '" + intemreturn.IsWastage + "' , BatchNo = '" + intemreturn.BatchNo + "' " +
                            "  where TenentID =" + TenentID + " and return_id='" + intemreturn.return_id + "' and item_id='" + intemreturn.item_id + "' and UOM='" + intemreturn.UOM + "' and BatchNo='" + intemreturn.BatchNo + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into return_item " +
                                          " (TenentID,ID, return_id,item_id, itemName, Qty, RetailsPrice, Total, return_time, custno, emp, SoldInvoiceNo, Comment, disamt , vatamt,UOM,Customer, " +
                                          " ExpiryDate,ReturnReason,IsWastage,BatchNo) " +
                                          "  select " + TenentID + ",'" + intemreturn.ID + "'," + intemreturn.return_id + ", '" + intemreturn.item_id + "', '" + intemreturn.itemName + "', '" + intemreturn.Qty + "', " +
                                          " '" + intemreturn.RetailsPrice + "' , '" + intemreturn.Total + "', '" + intemreturn.return_time + "',   " +
                                          " '" + intemreturn.custno + "', '" + intemreturn.emp + "' , '" + intemreturn.SoldInvoiceNo + "',  " +
                                          " '" + intemreturn.Comment + "', '" + intemreturn.disamt + "', '" + intemreturn.vatamt + "', '" + intemreturn.UOM + "' ,'" + intemreturn.Customer + "', " +
                                          " '" + intemreturn.ExpiryDate + "','" + intemreturn.ReturnReason + "' ,'" + IsWastage + "','" + intemreturn.BatchNo + "' " +
                                          "  where not exists ( SELECT * from return_item  WHERE TenentID =" + TenentID + " and return_id='" + intemreturn.return_id + "' and item_id='" + intemreturn.item_id + "' and UOM='" + intemreturn.UOM + "' and BatchNo='" + intemreturn.BatchNo + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update Win_return_item set SynID = 9 where TenentID =" + TenentID + " and return_id='" + intemreturn.return_id + "' and item_id='" + intemreturn.item_id + "' and UOM='" + intemreturn.UOM + "' and BatchNo='" + intemreturn.BatchNo + "' ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in return_item query :" + ex.Message);
            }

            // tbl_custcredit 13
            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your customer credit Data Please Wait !!";

                try
                {
                    List<Win_tbl_CustCredit> ListCustCredit = DB.Win_tbl_CustCredit.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                    Totalcount = ListCustCredit.Count();
                    currentCount = 0;
                    foreach (Win_tbl_CustCredit itemCustCredit in ListCustCredit)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            string sqlCmd = "Update tbl_custcredit set CustID='" + itemCustCredit.CustID + "', orderID='" + itemCustCredit.OrderID + "', " +
                                        " Date='" + itemCustCredit.Date + "', Credit='" + itemCustCredit.Credit + "', Description='" + itemCustCredit.Description + "' " +
                                            " where TenentID =" + TenentID + " and ID='" + itemCustCredit.ID + "' ";
                            int Falg = DataAccess.ExecuteSQL(sqlCmd);

                            if (Falg != 1)
                            {
                                string sql1 = "insert into tbl_custcredit " +
                                           " (TenentID, CustID, orderID, Date, Credit, Description ) " +
                                           "  select " + TenentID + ",'" + itemCustCredit.CustID + "', '" + itemCustCredit.OrderID + "', '" + itemCustCredit.Date + "', '" + itemCustCredit.Credit + "', '" + itemCustCredit.Description + "' " +
                                           "  where not exists ( SELECT * from tbl_custcredit  WHERE TenentID =" + TenentID + " and ID='" + itemCustCredit.ID + "' );";
                                DataAccess.ExecuteSQL(sql1);
                            }

                            string Dicstring = "update Win_tbl_CustCredit set SynID = 9 where TenentID =" + TenentID + " and ID='" + itemCustCredit.ID + "'; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in tbl_custcredit query :" + ex.Message);
                }
            }

            // tbl_duepayment 14

            backSyncro.Msg = "System is Synchronizing your due payment Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_duepayment> Listdue = DB.Win_tbl_duepayment.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = Listdue.Count();
                currentCount = 0;
                foreach (Win_tbl_duepayment itemdue in Listdue)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqldueUpdate = " update tbl_duepayment set receivedate='" + itemdue.receivedate + "', sales_id='" + itemdue.sales_id + "', totalamt='" + itemdue.totalamt + "' , " +
                                        " dueamt='" + itemdue.dueamt + "', receiveamt='" + itemdue.receiveamt + "' , custid='" + itemdue.custid + "' " +
                                        "   where TenentID = " + TenentID + " and id='" + itemdue.id + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqldueUpdate);

                        if (Falg != 1)
                        {
                            string sqldue = "insert into tbl_duepayment " +
                                   " (TenentID,id, receivedate, sales_id, totalamt , dueamt, receiveamt , custid) " +
                                   "  select " + TenentID + "," + itemdue.id + ",'" + itemdue.receivedate + "' , '" + itemdue.sales_id + "', '" + itemdue.totalamt + "', " +
                                   " '" + itemdue.dueamt + "', '" + itemdue.receiveamt + "', '" + itemdue.custid + "' " +
                                   "  where not exists ( SELECT * from tbl_duepayment  WHERE TenentID =" + TenentID + " and id='" + itemdue.id + "' and sales_id='" + itemdue.sales_id + "'  );";
                            DataAccess.ExecuteSQL(sqldue);
                        }

                        string Dicstring = "update Win_tbl_duepayment set SynID = 9 where TenentID =" + TenentID + " and id='" + itemdue.id + "' and sales_id='" + itemdue.sales_id + "' ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_duepayment query :" + ex.Message);
            }

            // tbl_expense 15
            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your expense Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<Win_tbl_expense> Listexpense = DB.Win_tbl_expense.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                    Totalcount = Listexpense.Count();
                    currentCount = 0;
                    foreach (Win_tbl_expense itemexpense in Listexpense)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            string sql1Update = " Update tbl_expense set Date = '" + itemexpense.Date + "' , ReferenceNo = '" + itemexpense.ReferenceNo + "' , Category= '" + itemexpense.Category + "' , " +
                                          "	Amount= '" + itemexpense.Amount + "' ,	Attachment= '" + itemexpense.Attachment + "' , fileextension= '" + itemexpense.fileextension + "' , " +
                                          " Note= '" + itemexpense.Note + "' ,	Createdby= '" + itemexpense.Createdby + "'  " +
                                          "   where TenentID = " + TenentID + " and id='" + itemexpense.ID + "'";
                            int Falg = DataAccess.ExecuteSQL(sql1Update);

                            if (Falg != 1)
                            {
                                string sql1 = "insert into tbl_expense " +
                                   " (TenentID,ID, Date , ReferenceNo , Category ,	Amount ,	Attachment , fileextension, Note ,	Createdby) " +
                                   "  select " + TenentID + ",'" + itemexpense.ID + "','" + itemexpense.Date + "', '" + itemexpense.ReferenceNo + "','" + itemexpense.Category + "', '" + itemexpense.Amount + "',  " +
                                   " '" + itemexpense.Attachment + "', '" + itemexpense.fileextension + "', '" + itemexpense.Note + "' , '" + itemexpense.Createdby + "' " +
                                   "  where not exists ( SELECT * from tbl_expense  WHERE TenentID =" + TenentID + " and ID='" + itemexpense.ID + "' );";
                                DataAccess.ExecuteSQL(sql1);
                            }

                            string Dicstring = "update Win_tbl_expense set SynID = 9 where TenentID =" + TenentID + " and ID='" + itemexpense.ID + "' ; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in tbl_expense query :" + ex.Message);
                }

            }

            // tbl_saleInfo 16

            backSyncro.Msg = "System is Synchronizing your sale Info Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_saleInfo> ListsaleInfo = DB.Win_tbl_saleInfo.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListsaleInfo.Count();
                currentCount = 0;
                foreach (Win_tbl_saleInfo itemsaleInfo in ListsaleInfo)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sql1Update = "update tbl_saleInfo set InvoiceNo = '" + itemsaleInfo.InvoiceNo + "', WarehouseNo = '" + itemsaleInfo.WarehouseNo + "', Biller = '" + itemsaleInfo.Biller + "', " +
                                " Customer = '" + itemsaleInfo.Customer + "', Note = '" + itemsaleInfo.Note + "', DisRate = '" + itemsaleInfo.DisRate + "', TaxRate = '" + itemsaleInfo.TaxRate + "', " +
                                " ShippingFee = '" + itemsaleInfo.ShippingFee + "', SoldBy = '" + itemsaleInfo.SoldBy + "', Datetime = '" + itemsaleInfo.DateTime + "'" +
                                " where TenentID =" + TenentID + " and ID='" + itemsaleInfo.ID + "'";
                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_saleInfo " +
                                         " (TenentID,ID, InvoiceNo, WarehouseNo, Biller, Customer, Note, DisRate, TaxRate, ShippingFee, SoldBy, Datetime) " +
                                         "  select " + TenentID + ",'" + itemsaleInfo.ID + "','" + itemsaleInfo.InvoiceNo + "', '" + itemsaleInfo.WarehouseNo + "', '" + itemsaleInfo.Biller + "', '" + itemsaleInfo.Customer + "', '" + itemsaleInfo.Note + "', '" + itemsaleInfo.DisRate + "'," +
                                        " '" + itemsaleInfo.TaxRate + "','" + itemsaleInfo.ShippingFee + "', '" + itemsaleInfo.SoldBy + "','" + itemsaleInfo.DateTime + "' " +
                                        "  where not exists ( SELECT * from tbl_saleInfo  WHERE TenentID =" + TenentID + " and InvoiceNo='" + itemsaleInfo.InvoiceNo + "' and ID='" + itemsaleInfo.ID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update Win_tbl_saleInfo set SynID = 9 where TenentID =" + TenentID + " and InvoiceNo='" + itemsaleInfo.InvoiceNo + "' and ID='" + itemsaleInfo.ID + "' ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_saleInfo query :" + ex.Message);
            }


            // ICUOM 17

            backSyncro.Msg = "System is Synchronizing your UOM Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<ICUOM> ListICUOM = DB.ICUOMs.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListICUOM.Count();
                currentCount = 0;
                foreach (ICUOM itemUOM in ListICUOM)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int MultiUOMAllow = itemUOM.MultiUOMAllow != null ? itemUOM.MultiUOMAllow == true ? 1 : 0 : 0;
                        int CalculateAspectRatio = itemUOM.CalculateAspectRatio != null ? itemUOM.CalculateAspectRatio == true ? 1 : 0 : 0;
                        string sql1Update = "Update ICUOM set UOMNAMESHORT = '" + itemUOM.UOMNAMESHORT + "' , UOMNAME1 = '" + itemUOM.UOMNAME1 + "' ,  " +
                            " UOMNAME2 ='" + itemUOM.UOMNAME2 + "' , UOMNAME3 = '" + itemUOM.UOMNAME3 + "' , REMARKS = '" + itemUOM.REMARKS + "' , " +
                            " UOM_TYPE ='" + itemUOM.UOM_TYPE + "' , MultiUOMAllow = '" + MultiUOMAllow + "' , CalculateAspectRatio = '" + CalculateAspectRatio + "'  " +
                            " where TenentID =" + TenentID + " and UOM ='" + itemUOM.UOM + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sql1Update);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into ICUOM " +
                                 " (TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,UOM_TYPE,MultiUOMAllow,CalculateAspectRatio) " +
                                    "  select " + TenentID + ",'" + itemUOM.UOM + "' , '" + itemUOM.UOMNAMESHORT + "','" + itemUOM.UOMNAME1 + "','" + itemUOM.UOMNAME2 + "' , " +
                                    " '" + itemUOM.UOMNAME3 + "' , '" + itemUOM.REMARKS + "' ,'" + itemUOM.UOM_TYPE + "' , '" + MultiUOMAllow + "' , '" + CalculateAspectRatio + "' " +
                                    "  where not exists ( SELECT * from ICUOM  WHERE TenentID =" + TenentID + " and UOM='" + itemUOM.UOM + "');";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update ICUOM set SynID = 9 where TenentID =" + TenentID + " and UOM='" + itemUOM.UOM + "' ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ICUOM query :" + ex.Message);
            }


            // tbl_workrecords  18
            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your work record Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<Win_tbl_workrecords> Listworkrecords = DB.Win_tbl_workrecords.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                    Totalcount = Listworkrecords.Count();
                    currentCount = 0;
                    foreach (Win_tbl_workrecords itemwork in Listworkrecords)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            string sqlLogIn = " update tbl_workrecords set Username ='" + itemwork.Username + "', datatype='" + itemwork.datatype + "', logdate='" + itemwork.logdate + "', " +
                                              " logtime ='" + itemwork.logtime + "', logdatetime ='" + itemwork.logdatetime + "' " +
                                              "   where TenentID = " + TenentID + " and logdatetime='" + itemwork.logdatetime + "' ";
                            int Falg = DataAccess.ExecuteSQL(sqlLogIn);

                            if (Falg != 1)
                            {
                                string sql1 = "insert into tbl_workrecords " +
                                              " (TenentID,id, Username, datatype, logdate, logtime, logdatetime ) " +
                                              "  select " + TenentID + "," + itemwork.id + ",'" + itemwork.Username + "' , '" + itemwork.datatype + "' , '" + itemwork.logdate + "' , " +
                                                  " '" + itemwork.logtime + "' , '" + itemwork.logdatetime + "' " +
                                              "  where not exists ( SELECT * from tbl_workrecords  WHERE TenentID =" + TenentID + " and id=" + itemwork.id + "  );";
                                DataAccess.ExecuteSQL(sql1);
                            }

                            string Dicstring = "update Win_tbl_workrecords set SynID = 9 where TenentID =" + TenentID + " and id=" + itemwork.id + " ; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in tbl_workrecords query :" + ex.Message);
                }
            }


            // tblsetupsalesh 19
            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your setup Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<Win_tblsetupsalesh> Listsetupsalesh = DB.Win_tblsetupsalesh.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                    Totalcount = Listsetupsalesh.Count();
                    currentCount = 0;
                    foreach (Win_tblsetupsalesh itemSet in Listsetupsalesh)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            string sqlLogInupdate = "update tblsetupsalesh set AllowMinusQty =" + itemSet.AllowMinusQty + " where TenentID=" + itemSet.TenentID + " and LocationID=1";
                            int Falg = DataAccess.ExecuteSQL(sqlLogInupdate);

                            if (Falg != 1)
                            {
                                string sqlLogIn = "insert into tblsetupsalesh " +
                                   " (TenentID, locationID, AllowMinusQty) " +
                                   "  select " + TenentID + " , '" + itemSet.locationID + "' , '" + itemSet.AllowMinusQty + "' " +
                                   "  where not exists ( SELECT * from tblsetupsalesh where TenentID=" + itemSet.TenentID + " and LocationID=1 );";
                                DataAccess.ExecuteSQL(sqlLogIn);
                            }

                            string Dicstring = "update Win_tblsetupsalesh set SynID = 9 where TenentID=" + itemSet.TenentID + " and LocationID=1 ; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in tblsetupsalesh query :" + ex.Message);
                }
            }

            // tbl_orderWay_Maintenance 20 

            backSyncro.Msg = "System is Synchronizing your orderWay Maintenance Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_orderWay_Maintenance> ListMaintenance = DB.Win_tbl_orderWay_Maintenance.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListMaintenance.Count();
                currentCount = 0;
                foreach (Win_tbl_orderWay_Maintenance itemMaintenance in ListMaintenance)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdUpdate = "update tbl_orderWay_Maintenance set Name1='" + itemMaintenance.Name1 + "', Name2='" + itemMaintenance.Name2 + "' , Commission_per='" + itemMaintenance.Commission_per + "', " +
                                       " Commission_Amount='" + itemMaintenance.Commission_Amount + "',DeliveryCharges='" + itemMaintenance.DeliveryCharges + "', " +
                                       " Paid_Commission='" + itemMaintenance.Paid_Commission + "',Pending_Commission='" + itemMaintenance.Pending_Commission + "' " +
                                       " where TenentID =" + TenentID + " and OrderWayID='" + itemMaintenance.OrderWayID + "' and Name1='" + itemMaintenance.Name1 + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sqlCmd = "insert into tbl_orderWay_Maintenance " +
                                            " (TenentID,ID, OrderWayID,Name1,Name2,Commission_per,Commission_Amount,DeliveryCharges,Paid_Commission,Pending_Commission) " +
                                            "  select " + TenentID + "," + itemMaintenance.ID + ",'" + itemMaintenance.OrderWayID + "','" + itemMaintenance.Name1 + "','" + itemMaintenance.Name2 + "', '" + itemMaintenance.Commission_per + "', " +
                                            " '" + itemMaintenance.Commission_Amount + "','" + itemMaintenance.DeliveryCharges + "' ,'" + itemMaintenance.Paid_Commission + "','" + itemMaintenance.Pending_Commission + "' " +
                                            "  where not exists ( SELECT * from tbl_orderWay_Maintenance where TenentID =" + TenentID + " and OrderWayID='" + itemMaintenance.OrderWayID + "' and Name1='" + itemMaintenance.Name1 + "' );";
                            DataAccess.ExecuteSQL(sqlCmd);
                        }

                        string Dicstring = "update Win_tbl_orderWay_Maintenance set SynID = 9 where TenentID =" + TenentID + " and OrderWayID='" + itemMaintenance.OrderWayID + "' and Name1='" + itemMaintenance.Name1 + "' ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_orderWay_Maintenance query :" + ex.Message);
            }


            // tbl_orderWay_transection 21 

            backSyncro.Msg = "System is Synchronizing your orderWay transection Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<Win_tbl_orderWay_transection> Listtransection = DB.Win_tbl_orderWay_transection.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = Listtransection.Count();
                currentCount = 0;
                foreach (Win_tbl_orderWay_transection itemtensection in Listtransection)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdUpdate = "Update tbl_orderWay_transection set Name2 ='" + itemtensection.Name2 + "' ,Commission_per ='" + itemtensection.Commission_per + "',Commission_Amount ='" + itemtensection.Commission_Amount + "', " +
                            " Paid_Commission ='" + itemtensection.Paid_Commission + "',Paid_Date ='" + itemtensection.Paid_Date + "',Paid_Reffrance ='" + itemtensection.Paid_Reffrance + "',Pending_Commission ='" + itemtensection.Pending_Commission + "' " +
                                        " where TenentID =" + TenentID + " and OrderWayID='" + itemtensection.OrderWayID + "' and Sales_ID = '" + itemtensection.Sales_ID + "' and Name1='" + itemtensection.Name1 + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sqlCmd = "insert into tbl_orderWay_transection " +
                                " (TenentID,ID, OrderWayID,Sales_ID,Name1,Name2,Commission_per,Commission_Amount,Paid_Commission,Paid_Date,Paid_Reffrance,Pending_Commission) " +
                                 "  select " + TenentID + "," + itemtensection.ID + ",'" + itemtensection.OrderWayID + "' ,'" + itemtensection.Sales_ID + "' ,'" + itemtensection.Name1 + "' , '" + itemtensection.Name2 + "' , " +
                                " '" + itemtensection.Commission_per + "' ,'" + itemtensection.Commission_Amount + "' ,'" + itemtensection.Paid_Commission + "' ,'" + itemtensection.Paid_Date + "' , " +
                                 " '" + itemtensection.Paid_Reffrance + "' ,'" + itemtensection.Pending_Commission + "' " +
                                "  where not exists ( SELECT * from tbl_orderWay_transection where TenentID =" + TenentID + " and OrderWayID='" + itemtensection.OrderWayID + "' and Sales_ID = '" + itemtensection.Sales_ID + "' and Name1='" + itemtensection.Name1 + "' );";
                            DataAccess.ExecuteSQL(sqlCmd);
                        }

                        string Dicstring = "update Win_tbl_orderWay_transection set SynID = 9 where TenentID =" + TenentID + " and OrderWayID='" + itemtensection.OrderWayID + "' and Sales_ID = '" + itemtensection.Sales_ID + "' and Name1='" + itemtensection.Name1 + "' ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tbl_orderWay_transection query :" + ex.Message);
            }

            // DayClose 22
            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your Day Close Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<DayClose> ListDayClose = DB.DayCloses.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9).ToList();
                    Totalcount = ListDayClose.Count();
                    currentCount = 0;
                    foreach (DayClose itemDayClose in ListDayClose)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            string Date = itemDayClose.Date.ToString("yyyy-MM-dd");

                            int DeliveredTO = itemDayClose.DeliveredTO == null ? Convert.ToInt32(itemDayClose.DeliveredTO) : 0;
                            int ShiftStutas = itemDayClose.ShiftStutas == null ? Convert.ToInt32(itemDayClose.ShiftStutas) : 0;
                            int Employee = itemDayClose.Employee == null ? Convert.ToInt32(itemDayClose.Employee) : UserInfo.Userid;

                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            string sqlCmdUpdate = "Update DayClose set OpAMT = '" + itemDayClose.OpAMT + "', ShiftSales = '" + itemDayClose.ShiftSales + "', ShiftReturn = '" + itemDayClose.ShiftReturn + "' , " +
                                            " ShiftPurchase = '" + itemDayClose.ShiftPurchase + "',ShiftCIH = '" + itemDayClose.ShiftCIH + "', VoucharAMT = '" + itemDayClose.VoucharAMT + "', " +
                                            " ExpAMT = '" + itemDayClose.ExpAMT + "' ,ChequeAMT = '" + itemDayClose.ChequeAMT + "' ,AMTDelivered = '" + itemDayClose.AMTDelivered + "' , " +
                                            " DeliveredTO ='" + DeliveredTO + "' ,undeliverdAMT = '" + itemDayClose.undeliverdAMT + "',RefNO = '" + itemDayClose.RefNO + "', " +
                                            " Notes = '" + itemDayClose.Notes + "' ,Employee = '" + Employee + "',ShiftStutas = '" + ShiftStutas + "'  " +
                                            " where TenentID =" + TenentID + " and ID = " + itemDayClose.ID + " and UserID=" + itemDayClose.UserID + "  ";
                            int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                            if (Falg != 1)
                            {
                                string sql1 = "insert into DayClose " +
                                " (TenentID,ID,UserID,TrmID,ShiftID,Date,OpAMT,ShiftSales,ShiftReturn,ShiftPurchase,ShiftCIH,VoucharAMT, " +
                                              " ExpAMT,ChequeAMT,AMTDelivered,DeliveredTO,undeliverdAMT,RefNO,Notes,UploadDate,Uploadby,SyncDate,Syncby,SynID,Employee,ShiftStutas) " +
                                               "  select " + TenentID + "," + itemDayClose.ID + "," + itemDayClose.UserID + ",'" + itemDayClose.TrmID + "'," + itemDayClose.ShiftID + ", " +
                                              " '" + Date + "','" + itemDayClose.OpAMT + "'," + itemDayClose.ShiftSales + ", " + itemDayClose.ShiftReturn + "," + itemDayClose.ShiftPurchase + "," + itemDayClose.ShiftCIH + ", " +
                                              " " + itemDayClose.VoucharAMT + "," + itemDayClose.ExpAMT + "," + itemDayClose.ChequeAMT + ", " + itemDayClose.AMTDelivered + "," + DeliveredTO + ", " +
                                              " " + itemDayClose.undeliverdAMT + ",'" + itemDayClose.RefNO + "','" + itemDayClose.Notes + "', " +
                                              " '" + itemDayClose.UploadDate + "' , '" + itemDayClose.Uploadby + "' ,'" + itemDayClose.SyncDate + "' , '" + itemDayClose.Syncby + "' , " + itemDayClose.SynID + "," + Employee + ", " + ShiftStutas + " " +
                                        "  where not exists ( SELECT * from DayClose where TenentID =" + TenentID + " and ID = " + itemDayClose.ID + " and UserID=" + itemDayClose.UserID + " );";
                                DataAccess.ExecuteSQL(sql1);
                            }

                            string Dicstring = "update DayClose set SynID = 9 where TenentID =" + TenentID + " and ID = " + itemDayClose.ID + " and UserID=" + itemDayClose.UserID + "  ; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in DayClose query :" + ex.Message);
                }
            }

            // CashDelivery  23

            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your Cash Delivery Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<CashDelivery> ListCashDelivery = DB.CashDeliveries.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                    Totalcount = ListCashDelivery.Count();
                    currentCount = 0;
                    foreach (CashDelivery itemCashDelivery in ListCashDelivery)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            DateTime Date1 = Convert.ToDateTime(itemCashDelivery.Date);
                            string Date = Date1.ToString("yyyy-MM-dd");

                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            string sqlCmdUpdate = "Update CashDelivery set AMTDelivered = '" + itemCashDelivery.AMTDelivered + "' , DeliveredTO = '" + itemCashDelivery.DeliveredTO + "' , " +
                                            " RefNO = '" + itemCashDelivery.RefNO + "' , Notes = '" + itemCashDelivery.Notes + "'  " +
                                            " where TenentID =" + TenentID + " and UserID=" + itemCashDelivery.UserID + " and TrmID='" + itemCashDelivery.TrmID + "' and ShiftID=" + itemCashDelivery.ShiftID + " and Date='" + Date + "'  ";
                            int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                            if (Falg != 1)
                            {
                                string sql1 = "insert into CashDelivery " +
                                    " (TenentID ,ID,UserID ,TrmID ,ShiftID , Date ,  AMTDelivered , DeliveredTO , RefNO , Notes , UploadDate , Uploadby, SyncDate , Syncby, SynID) " +
                                    "  select " + TenentID + ",'" + itemCashDelivery.ID + "'," + itemCashDelivery.UserID + ",'" + itemCashDelivery.TrmID + "'," + itemCashDelivery.ShiftID + " , " +
                                              " '" + Date + "'," + itemCashDelivery.AMTDelivered + "," + itemCashDelivery.DeliveredTO + ",'" + itemCashDelivery.RefNO + "','" + itemCashDelivery.Notes + "', " +
                                              " '" + itemCashDelivery.UploadDate + "' , '" + itemCashDelivery.Uploadby + "' ,'" + itemCashDelivery.SyncDate + "' , '" + itemCashDelivery.Syncby + "' , " + itemCashDelivery.SynID + " " +
                                    "  where not exists ( SELECT * from CashDelivery where TenentID =" + TenentID + " and UserID=" + itemCashDelivery.UserID + " and TrmID='" + itemCashDelivery.TrmID + "' and ShiftID=" + itemCashDelivery.ShiftID + " and Date='" + Date + "'  );";
                                DataAccess.ExecuteSQL(sql1);
                            }

                            string Dicstring = "update CashDelivery set SynID = 9 where TenentID =" + TenentID + " and UserID=" + itemCashDelivery.UserID + " and TrmID='" + itemCashDelivery.TrmID + "' and ShiftID=" + itemCashDelivery.ShiftID + " and Date='" + Date + "'  ; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Cash Delivery query :" + ex.Message);
                }
            }

            // ICIT_BR_Perishable  24

            backSyncro.Msg = "System is Synchronizing your Perishable Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<ICIT_BR_Perishable> ListICIT_BR_Perishable = DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListICIT_BR_Perishable.Count();
                currentCount = 0;
                foreach (ICIT_BR_Perishable Perishable in ListICIT_BR_Perishable)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int OpQty = Perishable.OpQty != null ? Convert.ToInt32(Perishable.OpQty) : 0;
                        int OnHand = Perishable.OnHand != null ? Convert.ToInt32(Perishable.OnHand) : 0;
                        int QtyOut = Perishable.QtyOut != null ? Convert.ToInt32(Perishable.QtyOut) : 0;
                        int QtyReceived = Perishable.QtyReceived != null ? Convert.ToInt32(Perishable.QtyReceived) : 0;

                        string sqlCmdUpdate = "Update ICIT_BR_Perishable set LocationID = '" + Perishable.LocationID + "', MYTRANSID = '" + Perishable.MYTRANSID + "', " +
                                        " OpQty = '" + OpQty + "', OnHand = '" + OnHand + "' , QtyOut = '" + QtyOut + "', QtyReceived  = '" + QtyReceived + "' , " +
                                        " ProdDate = '" + Perishable.ProdDate + "',ExpiryDate = '" + Perishable.ExpiryDate + "',LeadDays2Destroy = '" + Perishable.LeadDays2Destroy + "', " +
                                        " Reference = '" + Perishable.Reference + "', Active = '" + Perishable.Active + "' " +
                                        " WHERE TenentID =" + TenentID + " and MyProdID=" + Perishable.MyProdID + " and period_code='" + Perishable.period_code + "' and MySysName='" + Perishable.MySysName + "' and UOM='" + Perishable.UOM + "' and BatchNo = '" + Perishable.BatchNo + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into ICIT_BR_Perishable " +
                            " (TenentID,MyProdID,period_code,MySysName,UOM,BatchNo,LocationID,MYTRANSID,OpQty,OnHand,QtyOut,QtyReceived,ProdDate,ExpiryDate,LeadDays2Destroy,Reference,Active) " +
                            "  select " + TenentID + "," + Perishable.MyProdID + ",'" + Perishable.period_code + "','" + Perishable.MySysName + "' ,'" + Perishable.UOM + "' ,'" + Perishable.BatchNo + "' , " +
                                          " '" + Perishable.LocationID + "'," + Perishable.MYTRANSID + ",'" + OpQty + "','" + OnHand + "','" + QtyOut + "','" + QtyReceived + "' , " +
                                          " '" + Perishable.ProdDate + "' ,'" + Perishable.ExpiryDate + "' , '" + Perishable.LeadDays2Destroy + "' , '" + Perishable.Reference + "', '" + Perishable.Active + "' " +
                            "  where not exists ( SELECT * from ICIT_BR_Perishable where TenentID =" + TenentID + " and MyProdID=" + Perishable.MyProdID + " and period_code='" + Perishable.period_code + "' and MySysName='" + Perishable.MySysName + "' and UOM='" + Perishable.UOM + "' and BatchNo = '" + Perishable.BatchNo + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update ICIT_BR_Perishable set SynID = 9 where TenentID =" + TenentID + " and MyProdID=" + Perishable.MyProdID + " and period_code='" + Perishable.period_code + "' and MySysName='" + Perishable.MySysName + "' and UOM='" + Perishable.UOM + "' and BatchNo = '" + Perishable.BatchNo + "'   ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Perishable query :" + ex.Message);
            }

            // ICIT_BR_TMP  25

            backSyncro.Msg = "System is Synchronizing your Perishable Temp Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<ICIT_BR_TMP> ListICIT_BR_TMP = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListICIT_BR_TMP.Count();
                currentCount = 0;
                foreach (ICIT_BR_TMP BR_TMP in ListICIT_BR_TMP)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int SIZECODE = BR_TMP.SIZECODE != null ? BR_TMP.SIZECODE : 999999998;
                        int COLORID = BR_TMP.COLORID != null ? BR_TMP.COLORID : 999999998;
                        int Bin_ID = BR_TMP.Bin_ID != null ? BR_TMP.Bin_ID : 999999998;
                        string BatchNo = BR_TMP.BatchNo != null && BR_TMP.BatchNo != " " ? BR_TMP.BatchNo.ToString() : "999999998";
                        string Serial_Number = BR_TMP.Serial_Number != null && BR_TMP.Serial_Number != " " ? BR_TMP.Serial_Number.ToString() : "NO";
                        int LocationID = BR_TMP.LocationID != null ? BR_TMP.LocationID : 1;

                        int OpQty = BR_TMP.OpQty != null ? Convert.ToInt32(BR_TMP.OpQty) : 0;
                        int OnHand = BR_TMP.OnHand != null ? Convert.ToInt32(BR_TMP.OnHand) : 0;
                        int QtyOut = BR_TMP.QtyOut != null ? Convert.ToInt32(BR_TMP.QtyOut) : 0;
                        int QtyConsumed = BR_TMP.QtyConsumed != null ? Convert.ToInt32(BR_TMP.QtyConsumed) : 0;
                        int QtyReceived = BR_TMP.QtyReceived != null ? Convert.ToInt32(BR_TMP.QtyReceived) : 0;
                        int QtyReserved = BR_TMP.QtyReserved != null ? Convert.ToInt32(BR_TMP.QtyReserved) : 0;

                        int MinQty = BR_TMP.MinQty != null ? Convert.ToInt32(BR_TMP.MinQty) : 0;
                        int MaxQty = BR_TMP.MaxQty != null ? Convert.ToInt32(BR_TMP.MaxQty) : 0;

                        double MyProdID = Convert.ToDouble(BR_TMP.MyProdID);

                        int ID = DataAccess.getICIT_BR_TMPMYid(TenentID, MyProdID, BR_TMP.UOM);

                        string sqlCmdUpdate = "Update ICIT_BR_TMP set SIZECODE = '" + SIZECODE + "' , COLORID = '" + COLORID + "', Bin_ID = '" + Bin_ID + "', BatchNo = '" + BatchNo + "', " +
                                        " Serial_Number = '" + Serial_Number + "', MYTRANSID = " + BR_TMP.MYTRANSID + ", LocationID = '" + LocationID + "' , " +
                                        " NewQty = '" + BR_TMP.NewQty + "', OpQty = '" + OpQty + "', OnHand = '" + OnHand + "', QtyOut = '" + QtyOut + "', QtyConsumed = '" + QtyConsumed + "'," +
                                        " QtyReceived = '" + QtyReceived + "', QtyReserved = '" + QtyReserved + "', MinQty = '" + MinQty + "', MaxQty = '" + MaxQty + "' , " +
                                        " LeadTime = '" + BR_TMP.LeadTime + "', Reference = '" + BR_TMP.Reference + "', RecodName = '" + BR_TMP.RecodName + "' , " +
                                        " ProdDate = '" + BR_TMP.ProdDate + "' , ExpiryDate = '" + BR_TMP.ExpiryDate + "' , LeadDays2Destroy = '" + BR_TMP.LeadDays2Destroy + "' , Active = '" + BR_TMP.Active + "'  " +
                                        " WHERE TenentID =" + TenentID + " and MyProdID=" + BR_TMP.MyProdID + " and period_code='" + BR_TMP.period_code + "' and MySysName='" + BR_TMP.MySysName + "' and UOM='" + BR_TMP.UOM + "' and BatchNo = '" + BR_TMP.BatchNo + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into ICIT_BR_TMP " +
                                        " (TenentID,ID,MyProdID,period_code,MySysName,UOM,SIZECODE,COLORID,Bin_ID,BatchNo,Serial_Number,MYTRANSID,LocationID,NewQty,OpQty,OnHand,QtyOut,QtyConsumed," +
                                          " QtyReceived,QtyReserved,MinQty,MaxQty,LeadTime,Reference,RecodName,ProdDate,ExpiryDate,LeadDays2Destroy,Active) " +
                                        "  select " + TenentID + "," + ID + "," + BR_TMP.MyProdID + ",'" + BR_TMP.period_code + "','" + BR_TMP.MySysName + "' ,'" + BR_TMP.UOM + "' ,'" + SIZECODE + "' , " +
                                          " '" + COLORID + "'," + Bin_ID + ",'" + BatchNo + "','" + Serial_Number + "','" + BR_TMP.MYTRANSID + "','" + LocationID + "', " +
                                          " '" + BR_TMP.NewQty + "','" + OpQty + "','" + OnHand + "','" + QtyOut + "','" + QtyConsumed + "','" + QtyReceived + "', " +
                                          " '" + QtyReserved + "','" + MinQty + "','" + MaxQty + "','" + BR_TMP.LeadTime + "','" + BR_TMP.Reference + "','" + BR_TMP.RecodName + "', " +
                                          " '" + BR_TMP.ProdDate + "','" + BR_TMP.ExpiryDate + "','" + BR_TMP.LeadDays2Destroy + "','" + BR_TMP.Active + "'  " +
                                          "  where not exists ( SELECT * from ICIT_BR_TMP where TenentID =" + TenentID + " and MyProdID=" + BR_TMP.MyProdID + " and period_code='" + BR_TMP.period_code + "' and MySysName='" + BR_TMP.MySysName + "' and UOM='" + BR_TMP.UOM + "' and BatchNo = '" + BR_TMP.BatchNo + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update ICIT_BR_TMP set SynID = 9 where TenentID =" + TenentID + " and MyProdID=" + BR_TMP.MyProdID + " and period_code='" + BR_TMP.period_code + "' and MySysName='" + BR_TMP.MySysName + "' and UOM='" + BR_TMP.UOM + "' and BatchNo = '" + BR_TMP.BatchNo + "'  ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Perishable TEMP query :" + ex.Message);
            }


            // TblProductRelated  26

            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your Product Related Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<Win_TblProductRelated> ListProductRelated = DB.Win_TblProductRelated.Where(p => p.TenentID == TenentID && p.ACTIVE == true).ToList();
                    Totalcount = ListProductRelated.Count();
                    currentCount = 0;
                    foreach (Win_TblProductRelated ProductRelated in ListProductRelated)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            int sortNO = ProductRelated.sortNO != null ? Convert.ToInt32(ProductRelated.AlwaysShow) : 999;
                            bool AlwaysShow = ProductRelated.AlwaysShow != null ? Convert.ToBoolean(ProductRelated.AlwaysShow) : true;
                            string ACTIVE = ProductRelated.ACTIVE != null ? ProductRelated.ACTIVE == true ? "Y" : "N" : "N";

                            string sqlCmdUpdate = "Update TblProductRelated set sortNO = '" + sortNO + "' , AlwaysShow = '" + ProductRelated.AlwaysShow + "', ACTIVE = '" + ACTIVE + "'  " +
                                            " WHERE TenentID =" + TenentID + " and LOCATION_ID = '" + ProductRelated.LOCATION_ID + "' and MYPRODID = '" + ProductRelated.MYPRODID + "' and RalatedProdID = '" + ProductRelated.RalatedProdID + "'   ";
                            int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                            if (Falg != 1)
                            {
                                string sql1 = "insert into TblProductRelated " +
                                              " ( TenentID,LOCATION_ID,MYPRODID,RalatedProdID,sortNO,AlwaysShow,ACTIVE ) " +
                                              "  select " + TenentID + ",'" + ProductRelated.LOCATION_ID + "','" + ProductRelated.MYPRODID + "','" + ProductRelated.RalatedProdID + "' , " +
                                              " '" + sortNO + "','" + AlwaysShow + "','" + ACTIVE + "' " +
                                              "  where not exists ( SELECT * from TblProductRelated  WHERE TenentID =" + TenentID + " and LOCATION_ID = '" + ProductRelated.LOCATION_ID + "' and MYPRODID = '" + ProductRelated.MYPRODID + "' and RalatedProdID = '" + ProductRelated.RalatedProdID + "' );";
                                DataAccess.ExecuteSQL(sql1);
                            }

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Related Item query :" + ex.Message);
                }
            }

            // tbl_Receipe  28
            backSyncro.Msg = " System is Synchronizing your Receipe Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,Receipe_English,Receipe_Arabic,ExpireDays
                List<tbl_Receipe> ListReceipe = DB.tbl_Receipe.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListReceipe.Count();
                currentCount = 0;
                foreach (tbl_Receipe itemReceipe in ListReceipe)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        int HourToComplate = itemReceipe.HourToComplate != null ? Convert.ToInt32(itemReceipe.HourToComplate) : 0;
                        int SynID = itemReceipe.SynID != null ? Convert.ToInt32(itemReceipe.SynID) : 0;
                        string UploadDate = itemReceipe.UploadDate != null ? (Convert.ToDateTime(itemReceipe.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update tbl_Receipe set Receipe_English = '" + itemReceipe.Receipe_English + "' , Receipe_Arabic = '" + itemReceipe.Receipe_Arabic + "', RecType = '" + itemReceipe.RecType + "' ,  " +
                                              " ExpireDays = '" + itemReceipe.ExpireDays + "', HourToComplate = '" + HourToComplate + "', " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemReceipe.Uploadby + "' , SynID = '" + SynID + "'" +
                                              " WHERE TenentID =" + TenentID + " and recNo=" + itemReceipe.recNo + "  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tbl_Receipe " +
                                                  " (TenentID,recNo,Receipe_English,Receipe_Arabic,ExpireDays,RecType,HourToComplate,UploadDate,Uploadby,SynID ) " +
                                                  "  select " + TenentID + ", " + itemReceipe.recNo + " ,'" + itemReceipe.Receipe_English + "','" + itemReceipe.Receipe_Arabic + "' , " +
                                                  " '" + itemReceipe.ExpireDays + "' , '" + itemReceipe.RecType + "' , '" + HourToComplate + "', '" + UploadDate + "','" + itemReceipe.Uploadby + "','" + SynID + "' " +
                                                  "  where not exists ( SELECT * from tbl_Receipe  WHERE TenentID =" + TenentID + " and recNo=" + itemReceipe.recNo + "  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update tbl_Receipe set SynID = 9 where TenentID =" + TenentID + " and recNo=" + itemReceipe.recNo + "  ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Receipe query :" + ex.Message);
            }

            // Receipe_Menegement  29
            backSyncro.Msg = " System is Synchronizing your Receipe Menegement Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<Receipe_Menegement> ListReceipeM = DB.Receipe_Menegement.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListReceipeM.Count();
                currentCount = 0;
                foreach (Receipe_Menegement itemReceipeM in ListReceipeM)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        double ItemCode = itemReceipeM.ItemCode != null ? itemReceipeM.ItemCode : 0;
                        int UOM = itemReceipeM.UOM != null ? Convert.ToInt32(itemReceipeM.UOM) : 0;

                        string CostPrice = itemReceipeM.CostPrice != null && itemReceipeM.CostPrice.ToString() != "" ? itemReceipeM.CostPrice.ToString() : ReceipeMenegement.Get_CostPrice(TenentID, ItemCode, UOM);
                        string msrp = itemReceipeM.msrp != null && itemReceipeM.msrp.ToString() != "" ? itemReceipeM.msrp.ToString() : ReceipeMenegement.Get_MSRT(TenentID, ItemCode, UOM);

                        string sqlCmdUpdate = " Update Receipe_Menegement set IOSwitch = '" + itemReceipeM.IOSwitch + "' , ItemCode = '" + itemReceipeM.ItemCode + "',  " +
                                              " UOM = '" + itemReceipeM.UOM + "' , Qty = '" + itemReceipeM.Qty + "' , Perc = '" + itemReceipeM.Perc + "' , RecType = '" + itemReceipeM.RecType + "' ,  " +
                                              " CostPrice = '" + CostPrice + "', msrp = '" + msrp + "' " +
                                              " WHERE TenentID =" + TenentID + " and recNo=" + itemReceipeM.recNo + " and IOSwitch = '" + itemReceipeM.IOSwitch + "' and ItemCode = '" + itemReceipeM.ItemCode + "' and UOM = '" + itemReceipeM.UOM + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into Receipe_Menegement " +
                                                  " (TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc,RecType,CostPrice,msrp) " +
                                                  "  select " + TenentID + ", " + itemReceipeM.recNo + " ,'" + itemReceipeM.IOSwitch + "','" + itemReceipeM.ItemCode + "' ,'" + itemReceipeM.UOM + "' , " +
                                                  "  '" + itemReceipeM.Qty + "' ,'" + itemReceipeM.Perc + "' , '" + itemReceipeM.RecType + "' , '" + CostPrice + "' ,'" + msrp + "'   " +
                                                  "  where not exists ( SELECT * from Receipe_Menegement  WHERE TenentID =" + TenentID + " and recNo=" + itemReceipeM.recNo + " and IOSwitch = '" + itemReceipeM.IOSwitch + "' and ItemCode = '" + itemReceipeM.ItemCode + "' and UOM = '" + itemReceipeM.UOM + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update Receipe_Menegement set SynID = 9 where TenentID =" + TenentID + " and recNo=" + itemReceipeM.recNo + " and IOSwitch = '" + itemReceipeM.IOSwitch + "'  and ItemCode = '" + itemReceipeM.ItemCode + "' and UOM = '" + itemReceipeM.UOM + "' ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Receipe Menegement query :" + ex.Message);
            }

            // tblPrintSetup  30
            backSyncro.Msg = " System is Synchronizing your Print Setup Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<tblPrintSetup> ListPrintSetup = DB.tblPrintSetups.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListPrintSetup.Count();
                currentCount = 0;
                foreach (tblPrintSetup itemPrintSetup in ListPrintSetup)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdUpdate = "Update tblPrintSetup set CashReciptPRinter = '" + itemPrintSetup.CashReciptPRinter + "' , CashReceiptFile = '" + itemPrintSetup.CashReceiptFile + "',  " +
                                              " CreditInvoicePrinter = '" + itemPrintSetup.CreditInvoicePrinter + "' , CreditInvoiceFile = '" + itemPrintSetup.CreditInvoiceFile + "' , KitchenNotePrinter = '" + itemPrintSetup.KitchenNotePrinter + "' , KitchenNoteFile = '" + itemPrintSetup.KitchenNoteFile + "'   " +
                                        " WHERE TenentID =" + TenentID + " and Shopid='" + itemPrintSetup.Shopid + "' ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into tblPrintSetup " +
                                                  " (TenentID,Shopid,CashReciptPRinter,CashReceiptFile,CreditInvoicePrinter,CreditInvoiceFile,KitchenNotePrinter,KitchenNoteFile) " +
                                                  "  select " + TenentID + ", '" + itemPrintSetup.Shopid + "' ,'" + itemPrintSetup.CashReciptPRinter + "','" + itemPrintSetup.CashReceiptFile + "' ,'" + itemPrintSetup.CreditInvoicePrinter + "' , " +
                                                  "  '" + itemPrintSetup.CreditInvoiceFile + "' ,'" + itemPrintSetup.KitchenNotePrinter + "','" + itemPrintSetup.KitchenNoteFile + "'  " +
                                                  "  where not exists ( SELECT * from tblPrintSetup  WHERE TenentID =" + TenentID + " and Shopid='" + itemPrintSetup.Shopid + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update tblPrintSetup set SynID = 9 where TenentID =" + TenentID + " and Shopid=" + itemPrintSetup.Shopid + " ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Print Setup query :" + ex.Message);
            }

            // CashDrawerLibrary  31
            backSyncro.Msg = " System is Synchronizing your Drawer Library Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                DateTime Today = DateTime.Now.AddDays(-3);
                List<CashDrawerLibrary> ListDrawer = DB.CashDrawerLibraries.Where(p => p.UploadDate >= Today).ToList();
                Totalcount = ListDrawer.Count();
                currentCount = 0;
                foreach (CashDrawerLibrary itemDrawer in ListDrawer)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string sqlCmdUpdate = "Update CashDrawerLibrary set Manufacturer = '" + itemDrawer.Manufacturer + "' , Model = '" + itemDrawer.Model + "',  " +
                                              " Drawer_Codes = '" + itemDrawer.Drawer_Codes + "' , UploadDate = '" + itemDrawer.UploadDate + "'  " +
                                        " WHERE ID =" + itemDrawer.ID + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into CashDrawerLibrary " +
                                          " (ID,Manufacturer,Model,Drawer_Codes,UploadDate) " +
                                          "  select " + itemDrawer.ID + ", '" + itemDrawer.Manufacturer + "' ,'" + itemDrawer.Model + "','" + itemDrawer.Drawer_Codes + "' ,'" + itemDrawer.UploadDate + "' , " +
                                          "  '" + itemDrawer.Uploadby + "' ,'" + itemDrawer.SynID + "'  " +
                                          "  where not exists ( SELECT * from CashDrawerLibrary  WHERE ID =" + itemDrawer.ID + " );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Drawer Library query :" + ex.Message);
            }

            // Appointment  32
            backSyncro.Msg = " System is Synchronizing your Appointment Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<Appointment> ListAppointment = DB.Appointments.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListAppointment.Count();
                currentCount = 0;
                foreach (Appointment itemApp in ListAppointment)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string ExpStartDate = itemApp.ExpStartDate != null ? Convert.ToDateTime(itemApp.ExpStartDate).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        string ExpEndDate = itemApp.ExpEndDate != null ? Convert.ToDateTime(itemApp.ExpEndDate).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        string DateAdd = itemApp.DateTime != null ? Convert.ToDateTime(itemApp.DateTime).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        int Deleted = itemApp.DateTime != null ? itemApp.Deleted == true ? 1 : 0 : 1;
                        int JobDone = itemApp.JobDone != null ? itemApp.JobDone == true ? 1 : 0 : 0;
                        int Active = itemApp.Active != null ? itemApp.Active == true ? 1 : 0 : 1;

                        string sqlCmdUpdate = "Update Appointment set Title = '" + itemApp.Title + "', ExpStartDate = '" + ExpStartDate + "', ExpEndDate = '" + ExpEndDate + "', " +
                                        " StartDt = '" + itemApp.StartDt + "', EndDt = '" + itemApp.EndDt + "', Employee = '" + itemApp.Employee + "', customer = '" + itemApp.customer + "', " +
                                        " status = '" + itemApp.status + "', Color = '" + itemApp.Color + "',url= '" + itemApp.url + "', JobDone= '" + JobDone + "', Createby = '" + itemApp.Createby + "', " +
                                        " DateTime = '" + DateAdd + "', Active = '" + Active + "', Deleted = '" + Deleted + "', UploadDate = '" + itemApp.UploadDate + "',Uploadby = '" + itemApp.Uploadby + "', " +
                                        " SyncDate = '" + itemApp.SyncDate + "', Syncby = '" + itemApp.Syncby + "', SynID = '" + itemApp.SynID + "', CRMReference = '" + itemApp.CRMReference + "', MyID = '" + itemApp.MyID + "', " +
                                        " MySerial = '" + itemApp.MySerial + "', TransactionStatus = '" + itemApp.TransactionStatus + "', Type = '" + itemApp.Type + "', ActionType = '" + itemApp.ActionType + "', " +
                                        " FromAppoint = '" + itemApp.FromAppoint + "', ToAppoint = '" + itemApp.ToAppoint + "', C_ID = '" + itemApp.C_ID + "' " +
                                        " WHERE TenentID =" + TenentID + " and LocationID='" + itemApp.LocationID + "' and ID = '" + itemApp.ID + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into Appointment " +
                                          " (TenentID,LocationID, ID, Title, ExpStartDate, ExpEndDate, StartDt, EndDt, Employee, customer, status, Color,url, JobDone, Createby, DateTime, " +
                                          " Active, Deleted, UploadDate,Uploadby, SyncDate, Syncby, SynID, CRMReference, MyID,MySerial, TransactionStatus, Type, ActionType, FromAppoint, ToAppoint, C_ID ) " +
                                          " select " + TenentID + " , '" + itemApp.LocationID + "', '" + itemApp.ID + "', '" + itemApp.Title + "', '" + ExpStartDate + "','" + ExpEndDate + "', " +
                                          " '" + itemApp.StartDt + "','" + itemApp.EndDt + "','" + itemApp.Employee + "','" + itemApp.customer + "','" + itemApp.status + "','" + itemApp.Color + "', " +
                                          " '" + itemApp.url + "','" + JobDone + "','" + itemApp.Createby + "','" + DateAdd + "','" + Active + "','" + Deleted + "', " +
                                          " '" + itemApp.UploadDate + "','" + itemApp.Uploadby + "','" + itemApp.SyncDate + "','" + itemApp.Syncby + "','" + itemApp.SynID + "','" + itemApp.CRMReference + "', " +
                                          " '" + itemApp.MyID + "','" + itemApp.MySerial + "','" + itemApp.TransactionStatus + "','" + itemApp.Type + "','" + itemApp.ActionType + "','" + itemApp.FromAppoint + "', " +
                                          " '" + itemApp.ToAppoint + "', '" + itemApp.C_ID + "'  " +
                                          "  where not exists ( SELECT * from Appointment  WHERE TenentID =" + TenentID + " and LocationID='" + itemApp.LocationID + "' and ID = '" + itemApp.ID + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update Appointment set SynID = 9 WHERE TenentID =" + TenentID + " and LocationID='" + itemApp.LocationID + "' and ID = '" + itemApp.ID + "' ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Appointment query :" + ex.Message);
            }

            // CRMActivities  33
            backSyncro.Msg = " System is Synchronizing your CRMActivities Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<CRMActivity> ListCRMAC = DB.CRMActivities.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListCRMAC.Count();
                currentCount = 0;
                foreach (CRMActivity itemCRMAC in ListCRMAC)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UPDTTIME = itemCRMAC.UPDTTIME != null ? (Convert.ToDateTime(itemCRMAC.UPDTTIME)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string InitialDate = itemCRMAC.InitialDate != null ? (Convert.ToDateTime(itemCRMAC.InitialDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string DeadLineDate = itemCRMAC.DeadLineDate != null ? (Convert.ToDateTime(itemCRMAC.DeadLineDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string UploadDate = itemCRMAC.UploadDate != null ? (Convert.ToDateTime(itemCRMAC.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string ExpStartDate = itemCRMAC.ExpStartDate != null ? (Convert.ToDateTime(itemCRMAC.ExpStartDate)).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        string ExpEndDate = itemCRMAC.ExpEndDate != null ? (Convert.ToDateTime(itemCRMAC.ExpEndDate)).ToString("yyyy-MM-dd HH:mm:ss") : "";

                        string sqlCmdUpdate = "Update CRMActivities set MenuID = '" + itemCRMAC.MenuID + "' , ACTIVITYTYPE = '" + itemCRMAC.ACTIVITYTYPE + "' , REFTYPE  = '" + itemCRMAC.REFTYPE + "' , " +
                                        " REFSUBTYPE  = '" + itemCRMAC.REFSUBTYPE + "' , PerfReferenceNo  = '" + itemCRMAC.PerfReferenceNo + "' , EarlierRefNo  = '" + itemCRMAC.EarlierRefNo + "' , " +
                                        " NextUser   = '" + itemCRMAC.NextUser + "' , NextRefNo  = '" + itemCRMAC.NextRefNo + "'  , AMIGLOBAL  = '" + itemCRMAC.AMIGLOBAL + "'   , " +
                                        " MYPERSONNEL  = '" + itemCRMAC.MYPERSONNEL + "'  , ActivityPerform  = '" + itemCRMAC.ActivityPerform + "'  , REMINDERNOTE  = '" + itemCRMAC.REMINDERNOTE + "' , " +
                                        " ESTCOST  = '" + itemCRMAC.ESTCOST + "'  , GROUPCODE  = '" + itemCRMAC.GROUPCODE + "'  , USERCODEENTERED  = '" + itemCRMAC.USERCODEENTERED + "'  , " +
                                        " UPDTTIME  = '" + UPDTTIME + "'  , USERNAME  = '" + itemCRMAC.USERNAME + "'  , CRUP_ID  = '" + itemCRMAC.CRUP_ID + "'  , " +
                                        " InitialDate  = '" + InitialDate + "'  ,DeadLineDate  = '" + DeadLineDate + "' ,RouteID  = '" + itemCRMAC.RouteID + "' ,Version  = '" + itemCRMAC.Version + "' , " +
                                        " Type  = '" + itemCRMAC.Type + "' ,MyStatus  = '" + itemCRMAC.MyStatus + "' ,GroupBy  = '" + itemCRMAC.GroupBy + "' ,DocID  = '" + itemCRMAC.DocID + "' ,ToColumn  = '" + itemCRMAC.ToColumn + "' , " +
                                        " FromColumn  = '" + itemCRMAC.FromColumn + "' ,Active  = '" + itemCRMAC.Active + "' ,MainSubRefNo  = '" + itemCRMAC.MainSubRefNo + "' ,UrlRedirct  = '" + itemCRMAC.UrlRedirct + "' ,USERCODE  = '" + itemCRMAC.USERCODE + "' , " +
                                        " ExpStartDate = '" + ExpStartDate + "' ,  ExpEndDate = '" + ExpEndDate + "' , " +
                                        " UploadDate   = '" + UploadDate + "' ,Uploadby   = '" + itemCRMAC.Uploadby + "' ,SyncDate   = '" + itemCRMAC.SyncDate + "' ,Syncby   = '" + itemCRMAC.Syncby + "' ,SynID   = '" + itemCRMAC.SynID + "'   " +
                                        " WHERE TenentID =" + TenentID + " and COMPID = '" + itemCRMAC.COMPID + "' and MasterCODE = '" + itemCRMAC.MasterCODE + "' and MyLineNo = '" + itemCRMAC.MyLineNo + "' and LocationID = '" + itemCRMAC.LocationID + "' and LinkMasterCODE = '" + itemCRMAC.LinkMasterCODE + "' and ActivityID = '" + itemCRMAC.ActivityID + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into CRMActivities " +
                                          " (TenentID,COMPID,MasterCODE,MyLineNo,LocationID,LinkMasterCODE,MenuID,ActivityID,ACTIVITYTYPE,REFTYPE,REFSUBTYPE,PerfReferenceNo,EarlierRefNo,NextUser, " +
                                          " NextRefNo,AMIGLOBAL,MYPERSONNEL,ActivityPerform,REMINDERNOTE,ESTCOST,GROUPCODE,USERCODEENTERED,UPDTTIME,USERNAME,CRUP_ID,InitialDate,DeadLineDate,RouteID, " +
                                          " Version,Type,MyStatus,GroupBy,DocID,ToColumn,FromColumn,Active,MainSubRefNo,UrlRedirct,USERCODE,UploadDate,Uploadby,SynID,ExpStartDate,ExpEndDate) " +
                                          " select " + TenentID + " , '" + itemCRMAC.COMPID + "', '" + itemCRMAC.MasterCODE + "', '" + itemCRMAC.MyLineNo + "', '" + itemCRMAC.LocationID + "', " +
                                          " '" + itemCRMAC.LinkMasterCODE + "','" + itemCRMAC.MenuID + "','" + itemCRMAC.ActivityID + "','" + itemCRMAC.ACTIVITYTYPE + "','" + itemCRMAC.REFTYPE + "', " +
                                          " '" + itemCRMAC.REFSUBTYPE + "','" + itemCRMAC.PerfReferenceNo + "','" + itemCRMAC.EarlierRefNo + "','" + itemCRMAC.NextUser + "','" + itemCRMAC.NextRefNo + "', " +
                                          " '" + itemCRMAC.AMIGLOBAL + "','" + itemCRMAC.MYPERSONNEL + "','" + itemCRMAC.ActivityPerform + "','" + itemCRMAC.REMINDERNOTE + "','" + itemCRMAC.ESTCOST + "', " +
                                          " '" + itemCRMAC.GROUPCODE + "','" + itemCRMAC.USERCODEENTERED + "','" + UPDTTIME + "','" + itemCRMAC.USERNAME + "','" + itemCRMAC.CRUP_ID + "', " +
                                          " '" + InitialDate + "','" + DeadLineDate + "','" + itemCRMAC.RouteID + "','" + itemCRMAC.Version + "','" + itemCRMAC.Type + "', " +
                                          " '" + itemCRMAC.MyStatus + "','" + itemCRMAC.GroupBy + "', '" + itemCRMAC.DocID + "','" + itemCRMAC.ToColumn + "', '" + itemCRMAC.FromColumn + "', " +
                                          " '" + itemCRMAC.Active + "', '" + itemCRMAC.MainSubRefNo + "','" + itemCRMAC.UrlRedirct + "' ,'" + itemCRMAC.USERCODE + "' ,'" + UploadDate + "' , " +
                                          " '" + itemCRMAC.Uploadby + "' ,'" + itemCRMAC.SynID + "' , '" + ExpStartDate + "' , '" + ExpEndDate + "'  " +
                                          " where not exists ( SELECT * from CRMActivities WHERE TenentID =" + TenentID + " and COMPID = '" + itemCRMAC.COMPID + "' and MasterCODE = '" + itemCRMAC.MasterCODE + "' and MyLineNo = '" + itemCRMAC.MyLineNo + "' and LocationID = '" + itemCRMAC.LocationID + "' and LinkMasterCODE = '" + itemCRMAC.LinkMasterCODE + "' and ActivityID = '" + itemCRMAC.ActivityID + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update CRMActivities set SynID = 9 WHERE TenentID =" + TenentID + " and COMPID = '" + itemCRMAC.COMPID + "' and MasterCODE = '" + itemCRMAC.MasterCODE + "' and MyLineNo = '" + itemCRMAC.MyLineNo + "' and LocationID = '" + itemCRMAC.LocationID + "' and LinkMasterCODE = '" + itemCRMAC.LinkMasterCODE + "' and ActivityID = '" + itemCRMAC.ActivityID + "'  ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Appointment query :" + ex.Message);
            }

            // CRMMainActivities  34
            backSyncro.Msg = " System is Synchronizing your CRMActivities Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<CRMMainActivity> ListCRMMAin = DB.CRMMainActivities.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListCRMMAin.Count();
                currentCount = 0;
                foreach (CRMMainActivity CRMMAin in ListCRMMAin)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string REPEATTILL = CRMMAin.REPEATTILL != null ? (Convert.ToDateTime(CRMMAin.REPEATTILL)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string UPDTTIME = CRMMAin.UPDTTIME != null ? (Convert.ToDateTime(CRMMAin.UPDTTIME)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string UploadDate = CRMMAin.UploadDate != null ? (Convert.ToDateTime(CRMMAin.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update CRMMainActivities set RouteID = '" + CRMMAin.RouteID + "' , USERCODE= '" + CRMMAin.USERCODE + "' , ACTIVITYE= '" + CRMMAin.ACTIVITYE + "' ,ACTIVITYA= '" + CRMMAin.ACTIVITYA + "' , " +
                                        " ACTIVITYA2= '" + CRMMAin.ACTIVITYA2 + "' , Reference= '" + CRMMAin.Reference + "' , AMIGLOBAL= '" + CRMMAin.AMIGLOBAL + "' , MYPERSONNEL= '" + CRMMAin.MYPERSONNEL + "' , INTERVALDAYS= '" + CRMMAin.INTERVALDAYS + "' , " +
                                        " REPEATFOREVER= '" + CRMMAin.REPEATFOREVER + "' , REPEATTILL= '" + REPEATTILL + "' , REMINDERNOTE= '" + CRMMAin.REMINDERNOTE + "' , ESTCOST= '" + CRMMAin.ESTCOST + "' , GROUPCODE= '" + CRMMAin.GROUPCODE + "' , " +
                                        " USERCODEENTERED= '" + CRMMAin.USERCODEENTERED + "' , UPDTTIME= '" + UPDTTIME + "' , USERNAME= '" + CRMMAin.USERNAME + "' , Remarks= '" + CRMMAin.Remarks + "' , CRUP_ID= '" + CRMMAin.CRUP_ID + "' , " +
                                        " Version= '" + CRMMAin.Version + "' , Type= '" + CRMMAin.Type + "' , MyStatus= '" + CRMMAin.MyStatus + "' , MainID= '" + CRMMAin.MainID + "' , ModuleID= '" + CRMMAin.ModuleID + "' , DisplayFDName= '" + CRMMAin.DisplayFDName + "' , " +
                                        " Description= '" + CRMMAin.Description + "' , Ratting= '" + CRMMAin.Ratting + "' , Active= '" + CRMMAin.Active + "' , JobDone= '" + CRMMAin.JobDone + "' , UploadDate= '" + UploadDate + "' , Uploadby= '" + CRMMAin.Uploadby + "' , SynID = '" + CRMMAin.SynID + "', UseReciepeName = '" + CRMMAin.UseReciepeName + "', UseReciepeID = '" + CRMMAin.UseReciepeID + "'  " +
                                        " WHERE TenentID = " + TenentID + " and COMPID = '" + CRMMAin.COMPID + "' and MasterCODE = '" + CRMMAin.MasterCODE + "' and LinkMasterCODE = '" + CRMMAin.LinkMasterCODE + "' and LocationID = '" + CRMMAin.LocationID + "' and MyID= '" + CRMMAin.MyID + "'  ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into CRMMainActivities " +
                                          " (TenentID , COMPID , MasterCODE , LinkMasterCODE , LocationID , MyID , RouteID , USERCODE , ACTIVITYE ,ACTIVITYA , ACTIVITYA2 , Reference , AMIGLOBAL , MYPERSONNEL , " +
                                          " INTERVALDAYS , REPEATFOREVER , REPEATTILL , REMINDERNOTE , ESTCOST , GROUPCODE , USERCODEENTERED , UPDTTIME , USERNAME , Remarks , CRUP_ID , Version , Type , MyStatus , " +
                                          " MainID , ModuleID , DisplayFDName , Description , Ratting , Active , JobDone , UploadDate , Uploadby , SynID , UseReciepeName , UseReciepeID) " +
                                          " select " + TenentID + " , '" + CRMMAin.COMPID + "', '" + CRMMAin.MasterCODE + "', '" + CRMMAin.LinkMasterCODE + "', '" + CRMMAin.LocationID + "', " +
                                          " '" + CRMMAin.MyID + "','" + CRMMAin.RouteID + "','" + CRMMAin.USERCODE + "','" + CRMMAin.ACTIVITYE + "','" + CRMMAin.ACTIVITYA + "',  " +
                                          " '" + CRMMAin.ACTIVITYA2 + "','" + CRMMAin.Reference + "','" + CRMMAin.AMIGLOBAL + "','" + CRMMAin.MYPERSONNEL + "','" + CRMMAin.INTERVALDAYS + "', " +
                                          " '" + CRMMAin.REPEATFOREVER + "','" + REPEATTILL + "','" + CRMMAin.REMINDERNOTE + "','" + CRMMAin.ESTCOST + "', '" + CRMMAin.GROUPCODE + "', " +
                                          " '" + CRMMAin.USERCODEENTERED + "','" + UPDTTIME + "','" + CRMMAin.USERNAME + "','" + CRMMAin.Remarks + "','" + CRMMAin.CRUP_ID + "', " +
                                          " '" + CRMMAin.Version + "','" + CRMMAin.Type + "','" + CRMMAin.MyStatus + "','" + CRMMAin.MainID + "','" + CRMMAin.ModuleID + "', " +
                                          " '" + CRMMAin.DisplayFDName + "','" + CRMMAin.Description + "', '" + CRMMAin.Ratting + "','" + CRMMAin.Active + "', '" + CRMMAin.JobDone + "', " +
                                          " '" + UploadDate + "', '" + CRMMAin.Uploadby + "','" + CRMMAin.SynID + "' ,'" + CRMMAin.UseReciepeName + "','" + CRMMAin.UseReciepeID + "' " +
                                          "  where not exists ( SELECT * from CRMMainActivities WHERE TenentID = " + TenentID + " and COMPID = '" + CRMMAin.COMPID + "' and MasterCODE = '" + CRMMAin.MasterCODE + "' and LinkMasterCODE = '" + CRMMAin.LinkMasterCODE + "' and LocationID = '" + CRMMAin.LocationID + "' and MyID= '" + CRMMAin.MyID + "'  );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update CRMMainActivities set SynID = 9 where TenentID = " + TenentID + " and COMPID = '" + CRMMAin.COMPID + "' and MasterCODE = '" + CRMMAin.MasterCODE + "' and LinkMasterCODE = '" + CRMMAin.LinkMasterCODE + "' and LocationID = '" + CRMMAin.LocationID + "' and MyID= '" + CRMMAin.MyID + "'  ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Appointment query :" + ex.Message);
            }

            // ICUOMCONV  35
            backSyncro.Msg = " System is Synchronizing your UOM ConversionData Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<ICUOMCONV> ListCONV = DB.ICUOMCONVs.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListCONV.Count();
                currentCount = 0;
                foreach (ICUOMCONV itemCONV in ListCONV)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemCONV.UploadDate != null ? (Convert.ToDateTime(itemCONV.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update ICUOMCONV set CONVERSION = '" + itemCONV.CONVERSION + "', ConvRatio = '" + itemCONV.ConvRatio + "' , REMARKS = '" + itemCONV.REMARKS + "',  " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemCONV.Uploadby + "' , SynID = '" + itemCONV.SynID + "'" +
                                              " WHERE TenentID = " + TenentID + " and FUOM = " + itemCONV.FUOM + " and TUOM = " + itemCONV.TUOM + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = "insert into ICUOMCONV " +
                                          " (TenentID,FUOM,TUOM,CONVERSION,ConvRatio,REMARKS,USERID,ENTRYDATE,ENTRYTIME,UPDTTIME,UploadDate,Uploadby,SynID) " +
                                          "  select " + TenentID + " , " + itemCONV.FUOM + ", '" + itemCONV.TUOM + "' , '" + itemCONV.CONVERSION + "', '" + itemCONV.ConvRatio + "' , '" + itemCONV.REMARKS + "' , " +
                                          " '" + itemCONV.USERID + "' , '" + itemCONV.ENTRYDATE + "' , '" + itemCONV.ENTRYTIME + "' , '" + itemCONV.UPDTTIME + "','" + UploadDate + "','" + itemCONV.Uploadby + "' ,'" + itemCONV.SynID + "' " +
                                          "  where not exists ( SELECT * from ICUOMCONV  WHERE TenentID = " + TenentID + " and FUOM = " + itemCONV.FUOM + " and TUOM = " + itemCONV.TUOM + " );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update ICUOMCONV set SynID = 9 WHERE TenentID = " + TenentID + " and FUOM = " + itemCONV.FUOM + " and TUOM = " + itemCONV.TUOM + "  ; ";
                        Database_import.runsql_Live(Dicstring);


                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in UOM ConversionData query :" + ex.Message);
            }

            // REFTABLE  36
            backSyncro.Msg = " System is Synchronizing your REFTABLE Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<REFTABLE> ListRef = DB.REFTABLEs.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListRef.Count();
                currentCount = 0;
                foreach (REFTABLE itemRef in ListRef)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemRef.UploadDate != null ? (Convert.ToDateTime(itemRef.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemRef.SyncDate != null ? (Convert.ToDateTime(itemRef.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update REFTABLE set REFTYPE = '" + itemRef.REFTYPE + "', REFSUBTYPE = '" + itemRef.REFSUBTYPE + "', SHORTNAME = '" + itemRef.SHORTNAME + "', " +
                                              " REFNAME1 = '" + itemRef.REFNAME1 + "', REFNAME2 = '" + itemRef.REFNAME2 + "', REFNAME3 = '" + itemRef.REFNAME3 + "', SWITCH1 = '" + itemRef.SWITCH1 + "', " +
                                              " SWITCH2 = '" + itemRef.SWITCH2 + "', SWITCH3 = '" + itemRef.SWITCH3 + "', SWITCH4 = '" + itemRef.SWITCH4 + "', Remarks = '" + itemRef.Remarks + "', " +
                                              " ACTIVE = '" + itemRef.ACTIVE + "', CRUP_ID = '" + itemRef.CRUP_ID + "', Infrastructure = '" + itemRef.Infrastructure + "', " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemRef.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemRef.Syncby + "' , SynID = '" + itemRef.SynID + "'" +
                                              " WHERE TenentID = " + TenentID + " and REFID = " + itemRef.REFID + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into REFTABLE " +
                                          " (TenentID,REFID,REFTYPE,REFSUBTYPE,SHORTNAME,REFNAME1,REFNAME2,REFNAME3,SWITCH1,SWITCH2,SWITCH3,SWITCH4,Remarks,ACTIVE,CRUP_ID,Infrastructure,UploadDate, " +
                                          " Uploadby,SyncDate,Syncby,SynID) " +
                                          "  select " + TenentID + " , " + itemRef.REFID + ", '" + itemRef.REFTYPE + "' , '" + itemRef.REFSUBTYPE + "', '" + itemRef.SHORTNAME + "' , " +
                                          " '" + itemRef.REFNAME1 + "' , '" + itemRef.REFNAME2 + "' , '" + itemRef.REFNAME3 + "' , '" + itemRef.SWITCH1 + "','" + itemRef.SWITCH2 + "'," +
                                          " '" + itemRef.SWITCH3 + "' , '" + itemRef.SWITCH4 + "' , '" + itemRef.Remarks + "' , '" + itemRef.ACTIVE + "','" + itemRef.CRUP_ID + "','" + itemRef.Infrastructure + "'," +
                                          " '" + UploadDate + "','" + itemRef.Uploadby + "' ,'" + SyncDate + "','" + itemRef.Syncby + "' ,'" + itemRef.SynID + "' " +
                                          "  where not exists ( SELECT * from REFTABLE  WHERE TenentID = " + TenentID + " and REFID = " + itemRef.REFID + ");";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update REFTABLE set SynID = 9 WHERE TenentID = " + TenentID + " and REFID = " + itemRef.REFID + " ; ";
                        Database_import.runsql_Live(Dicstring);


                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in REFTABLE query :" + ex.Message);
            }

            // tbl_Customer_Medical  37
            backSyncro.Msg = " System is Synchronizing your Customer Medical Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc
                List<tbl_Customer_Medical> ListMedical = DB.tbl_Customer_Medical.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListMedical.Count();
                currentCount = 0;
                foreach (tbl_Customer_Medical itemCM in ListMedical)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemCM.UploadDate != null ? (Convert.ToDateTime(itemCM.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemCM.SyncDate != null ? (Convert.ToDateTime(itemCM.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update tbl_Customer_Medical set Age = '" + itemCM.Age + "' , BirthDate = '" + itemCM.BirthDate + "', status = '" + itemCM.status + "' , " +
                                              " Address = '" + itemCM.Address + "' , Phone = '" + itemCM.Phone + "' , RefferdBy = '" + itemCM.RefferdBy + "', Email = '" + itemCM.Email + "', " +
                                              " ChiftComplaint = '" + itemCM.ChiftComplaint + "', ScreenProblem = '" + itemCM.ScreenProblem + "',TakingMedication = '" + itemCM.TakingMedication + "', " +
                                              " ISPregnent = '" + itemCM.ISPregnent + "', AnyRiskFactor = '" + itemCM.AnyRiskFactor + "' , PreviousSkinTreatments = '" + itemCM.PreviousSkinTreatments + "' ,  " +
                                              " ApplyToYou = '" + itemCM.ApplyToYou + "', AnyCondition = '" + itemCM.AnyCondition + "' , " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemCM.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemCM.Syncby + "' , SynID = '" + itemCM.SynID + "'" +
                                              " WHERE TenentID = " + TenentID + " and CustomerID = " + itemCM.CustomerID + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into tbl_Customer_Medical " +
                                          " (TenentID, CustomerID, Age, BirthDate, status, Address, Phone, RefferdBy, Email, ChiftComplaint, ScreenProblem,TakingMedication, ISPregnent,  " +
                                          " AnyRiskFactor, PreviousSkinTreatments, ApplyToYou, AnyCondition, UploadDate, Uploadby,SyncDate,Syncby,SynID) " +
                                          "  select " + TenentID + " , " + itemCM.CustomerID + ", '" + itemCM.Age + "' , '" + itemCM.BirthDate + "', '" + itemCM.status + "' , " +
                                          " '" + itemCM.Address + "' , '" + itemCM.Phone + "' , '" + itemCM.RefferdBy + "' , '" + itemCM.Email + "','" + itemCM.ChiftComplaint + "'," +
                                          " '" + itemCM.ScreenProblem + "' , '" + itemCM.TakingMedication + "' , '" + itemCM.ISPregnent + "' , '" + itemCM.AnyRiskFactor + "', " +
                                          " '" + itemCM.PreviousSkinTreatments + "','" + itemCM.ApplyToYou + "', '" + itemCM.AnyCondition + "', " +
                                          " '" + UploadDate + "','" + itemCM.Uploadby + "' ,'" + SyncDate + "','" + itemCM.Syncby + "' ,'" + itemCM.SynID + "' " +
                                          "  where not exists ( SELECT * from tbl_Customer_Medical  WHERE TenentID = " + TenentID + " and CustomerID = " + itemCM.CustomerID + ");";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update tbl_Customer_Medical set SynID = 9 WHERE TenentID = " + TenentID + " and CustomerID = " + itemCM.CustomerID + " ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Customer Medical query :" + ex.Message);
            }

            // tbl_Customer_Eye_history  38
            backSyncro.Msg = " System is Synchronizing your Customer Eye Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<tbl_Customer_Eye_history> ListEye = DB.tbl_Customer_Eye_history.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListEye.Count();
                currentCount = 0;
                foreach (tbl_Customer_Eye_history itemCE in ListEye)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemCE.UploadDate != null ? (Convert.ToDateTime(itemCE.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemCE.SyncDate != null ? (Convert.ToDateTime(itemCE.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update tbl_Customer_Eye_history set DateOFCheck = '" + itemCE.DateOFCheck + "' , RSPHDistance = '" + itemCE.RSPHDistance + "', RSPHReading = '" + itemCE.RSPHReading + "', " +
                                              " RCylDistance = '" + itemCE.RCylDistance + "' , RCylReading = '" + itemCE.RCylReading + "' , RAxisDistance = '" + itemCE.RAxisDistance + "' , RAxisReading = '" + itemCE.RAxisReading + "' , " +
                                              " LPDDistance = '" + itemCE.LPDDistance + "' , LPDReading = '" + itemCE.LPDReading + "' , LSPHDistance = '" + itemCE.LSPHDistance + "' , LSPHReading = '" + itemCE.LSPHReading + "' , " +
                                              " LCylDistance = '" + itemCE.LCylDistance + "' , LCylReading = '" + itemCE.LCylReading + "' , LAxisDistance = '" + itemCE.LAxisDistance + "' , LAxisReading = '" + itemCE.LAxisReading + "' , " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemCE.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemCE.Syncby + "' , SynID = '" + itemCE.SynID + "'" +
                                              " WHERE TenentID = " + TenentID + " and CustomerID = " + itemCE.CustomerID + " and MyID =" + itemCE.MyID + " ";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into tbl_Customer_Eye_history " +
                                          " (TenentID, CustomerID, MyID, DateOFCheck, RSPHDistance, RSPHReading, RCylDistance, RCylReading, RAxisDistance, RAxisReading, LPDDistance, LPDReading, " +
                                          " LSPHDistance, LSPHReading, LCylDistance, LCylReading, LAxisDistance, LAxisReading, UploadDate, Uploadby, SyncDate, Syncby, SynID) " +
                                          "  select " + TenentID + " , " + itemCE.CustomerID + ", " + itemCE.MyID + " , '" + itemCE.DateOFCheck + "', '" + itemCE.RSPHDistance + "' , " +
                                          " '" + itemCE.RSPHReading + "' , '" + itemCE.RCylDistance + "' , '" + itemCE.RCylReading + "' , '" + itemCE.RAxisDistance + "','" + itemCE.RAxisReading + "', " +
                                          " '" + itemCE.LPDDistance + "' , '" + itemCE.LPDReading + "', '" + itemCE.LSPHDistance + "', '" + itemCE.LSPHReading + "', " +
                                          "  '" + itemCE.LCylDistance + "', '" + itemCE.LCylReading + "', '" + itemCE.LAxisDistance + "', '" + itemCE.LAxisReading + "', " +
                                          " '" + UploadDate + "','" + itemCE.Uploadby + "' ,'" + SyncDate + "','" + itemCE.Syncby + "' ,'" + itemCE.SynID + "' " +
                                          "  where not exists ( SELECT * from tbl_Customer_Eye_history  WHERE TenentID = " + TenentID + " and CustomerID = " + itemCE.CustomerID + " and MyID =" + itemCE.MyID + " );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update tbl_Customer_Eye_history set SynID = 9 WHERE TenentID = " + TenentID + " and CustomerID = " + itemCE.CustomerID + " and MyID =" + itemCE.MyID + " ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Customer Eye query :" + ex.Message);
            }

            // AppointmentReceipe  39
            backSyncro.Msg = " System is Synchronizing your Appointment Receipe Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<AppointmentReceipe> ListappReceipe = DB.AppointmentReceipes.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListappReceipe.Count();
                currentCount = 0;
                foreach (AppointmentReceipe itemAR in ListappReceipe)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemAR.UploadDate != null ? (Convert.ToDateTime(itemAR.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemAR.SyncDate != null ? (Convert.ToDateTime(itemAR.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update AppointmentReceipe set  Qty = '" + itemAR.Qty + "', CostPrice= '" + itemAR.CostPrice + "', msrp= '" + itemAR.msrp + "', recNo= '" + itemAR.recNo + "', " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemAR.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemAR.Syncby + "' , SynID = '" + itemAR.SynID + "', product_name= '" + itemAR.product_name + "', RecipeType= '" + itemAR.RecipeType + "', EmpOperator='" + itemAR.EmpOperator + "', EmpOperator='" + itemAR.QtyIntoCostprice + "'" +
                                              " WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and AppointmentID =" + itemAR.AppointmentID + " and JobID = '" + itemAR.JobID + "' and  IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode  = '" + itemAR.ItemCode + "' and  UOM = '" + itemAR.UOM + "' ;";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into AppointmentReceipe " +
                                          " (TenentID,LocationID, AppointmentID, JobID, IOSwitch, ItemCode, UOM, Qty, CostPrice, msrp, recNo, UploadDate, Uploadby, SyncDate, Syncby, SynID, product_name, RecipeType, EmpOperator,QtyIntoCostprice) " +
                                          "  select " + TenentID + " , " + itemAR.LocationID + ", " + itemAR.AppointmentID + " , '" + itemAR.JobID + "', '" + itemAR.IOSwitch + "' , " +
                                          " '" + itemAR.ItemCode + "' , '" + itemAR.UOM + "' , '" + itemAR.Qty + "' , '" + itemAR.CostPrice + "','" + itemAR.msrp + "','" + itemAR.recNo + "', " +
                                          " '" + UploadDate + "','" + itemAR.Uploadby + "' ,'" + SyncDate + "','" + itemAR.Syncby + "' ,'" + itemAR.SynID + "','" + itemAR.product_name + "','" + itemAR.RecipeType + "','" + itemAR.EmpOperator + "','" + itemAR.QtyIntoCostprice + "' " +
                                          "  where not exists ( SELECT * from AppointmentReceipe  WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and AppointmentID =" + itemAR.AppointmentID + " and JobID = '" + itemAR.JobID + "' and  IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode  = '" + itemAR.ItemCode + "' and  UOM = '" + itemAR.UOM + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update AppointmentReceipe set SynID = 9 WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and AppointmentID =" + itemAR.AppointmentID + " and JobID = '" + itemAR.JobID + "' and  IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode  = '" + itemAR.ItemCode + "' and  UOM = '" + itemAR.UOM + "' ; ";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Appointment Receipe query :" + ex.Message);
            }


            // AppointmentReceipe  40
            backSyncro.Msg = " System is Synchronizing your Commision Payment Data Please Wait !!";
            backSyncro.MsgCount = "-";
            try
            {
                List<CommisionPayment> ListappCommision = DB.CommisionPayments.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                Totalcount = ListappCommision.Count();
                currentCount = 0;
                foreach (CommisionPayment itemAR in ListappCommision)
                {
                    currentCount = currentCount + 1;
                    if (backSyncro.isRun == true)
                    {
                        string UploadDate = itemAR.UploadDate != null ? (Convert.ToDateTime(itemAR.UploadDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                        string SyncDate = itemAR.SyncDate != null ? (Convert.ToDateTime(itemAR.SyncDate)).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";

                        string sqlCmdUpdate = " Update CommisionPayment set  PaidAmt = '" + itemAR.PaidAmt + "', PaidDate= '" + itemAR.PaidDate + "', FinaRef= '" + itemAR.FinaRef + "', Status= '" + itemAR.Status + "', " +
                                              " UploadDate= '" + UploadDate + "' , Uploadby= '" + itemAR.Uploadby + "' ,SyncDate = '" + SyncDate + "',Syncby= '" + itemAR.Syncby + "' , SynID = '" + itemAR.SynID + "', Remark= '" + itemAR.Remark + "', Employee='" + itemAR.Employee + "'" +
                                              " WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and recNo =" + itemAR.recNo + " and IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode = '" + itemAR.ItemCode + "' and  PaymentSerial  = '" + itemAR.PaymentSerial + "' and  UOM = '" + itemAR.UOM + "' and JobNo = '" + itemAR.JobNo + "' );";
                        int Falg = DataAccess.ExecuteSQL(sqlCmdUpdate);

                        if (Falg != 1)
                        {
                            string sql1 = " insert into CommisionPayment " +
                                          " (TenentID,LocationID, recNo, IOSwitch, ItemCode, UOM, PaymentSerial, JobNo, PaidAmt, PaidDate, FinaRef, Status, UploadDate, Uploadby, SyncDate, Syncby, SynID, Remark, Employee) " +
                                          "  select " + TenentID + " , " + itemAR.LocationID + ", " + itemAR.recNo + " , '" + itemAR.IOSwitch + "', '" + itemAR.ItemCode + "' , " +
                                          " '" + itemAR.UOM + "' , '" + itemAR.PaymentSerial + "' , '" + itemAR.JobNo + "' , '" + itemAR.PaidAmt + "', '" + itemAR.PaidDate + "','" + itemAR.FinaRef + "','" + itemAR.Status + "', " +
                                          " '" + UploadDate + "','" + itemAR.Uploadby + "' ,'" + SyncDate + "','" + itemAR.Syncby + "' ,'" + itemAR.SynID + "','" + itemAR.Remark + "','" + itemAR.Employee + "'" +
                                          "  where not exists ( SELECT * from CommisionPayment  WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and recNo =" + itemAR.recNo + " and IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode = '" + itemAR.ItemCode + "' and  PaymentSerial  = '" + itemAR.PaymentSerial + "' and  UOM = '" + itemAR.UOM + "' and JobNo = '" + itemAR.JobNo + "' );";
                            DataAccess.ExecuteSQL(sql1);
                        }

                        string Dicstring = "update CommisionPayment set SynID = 9 WHERE TenentID = " + TenentID + " and LocationID = " + itemAR.LocationID + " and recNo =" + itemAR.recNo + " and IOSwitch = '" + itemAR.IOSwitch + "' and  ItemCode = '" + itemAR.ItemCode + "' and  PaymentSerial  = '" + itemAR.PaymentSerial + "' and  UOM = '" + itemAR.UOM + "' and JobNo = '" + itemAR.JobNo + "' );";
                        Database_import.runsql_Live(Dicstring);

                        backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Commision Payment query :" + ex.Message);
            }

            // Win_tbl_UserLog  27

            if (backSyncro.Salessync == false)
            {
                backSyncro.Msg = "System is Synchronizing your User Log Data Please Wait !!";
                backSyncro.MsgCount = "-";
                try
                {
                    List<Win_tbl_UserLog> ListUserLog = DB.Win_tbl_UserLog.Where(p => p.TenentID == TenentID && p.SynID != 3 && p.SynID != 9 && p.UploadDate >= syncDate).ToList();
                    Totalcount = ListUserLog.Count();
                    currentCount = 0;
                    foreach (Win_tbl_UserLog itemUserLog in ListUserLog)
                    {
                        currentCount = currentCount + 1;
                        if (backSyncro.isRun == true)
                        {
                            DateTime logdate1 = Convert.ToDateTime(itemUserLog.logdate);
                            DateTime logdatetime1 = Convert.ToDateTime(itemUserLog.logdatetime);

                            string logdate = logdate1.ToString("yyyy-MM-dd");
                            string logdatetime = logdatetime1.ToString("yyyy-MM-dd hh:mm:ss");

                            string sql1 = "insert into Win_tbl_UserLog " +
                                              " ( TenentID, id,UserID, Username,ActivityName, Log_Data,logdate , logtime, logdatetime,status ) " +
                                              "  select " + TenentID + ", " + itemUserLog.id + " ," + itemUserLog.UserID + ",'" + itemUserLog.Username + "' ,'" + itemUserLog.ActivityName + "', " +
                                                  " '" + itemUserLog.Log_Data + "' , '" + logdate + "' ,'" + itemUserLog.logtime + "' , '" + logdatetime + "' ," + itemUserLog.status + " " +
                                              "  where not exists ( SELECT * from Win_tbl_UserLog  WHERE TenentID =" + TenentID + " and id=" + itemUserLog.id + "  );";
                            DataAccess.ExecuteSQL(sql1);

                            string Dicstring = "update Win_tbl_UserLog set SynID = 9 where TenentID =" + TenentID + " and id=" + itemUserLog.id + " ; ";
                            Database_import.runsql_Live(Dicstring);

                            backSyncro.MsgCount = currentCount + " of " + Totalcount + "  Record Synchronized";
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in User Log query :" + ex.Message);
                }
            }

            Registation.UodateSuperuser();

            backSyncro.Msg = "System is Synchronizing Complate Successfully";

            string ActivityName1 = "Syncronization";
            string LogData1 = "Syncronization Complate ";
            Login.InsertUserLog(ActivityName1, LogData1);

        }

        #endregion
        private void btnUomAdd_Click(object sender, EventArgs e)
        {
            open_Installer();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
          // DialogResult result = MessageBox.Show(" Restart Application ", "OK", MessageBoxButtons.OK, MessageBoxIcon.Question);
          // if (result == DialogResult.OK)
          // {
          //     Environment.Exit(0);
          // }
        }

    }
}
