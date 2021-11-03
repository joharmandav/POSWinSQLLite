using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Globalization;
using System.Net;
using System.IO.Compression;
using System.IO.Packaging;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.TaskScheduler;
using supershop.Items;
using supershop.Report;
using MessageBoxExample;



/*
           Author :    Yogesh Khandala
           Email:      johar@writeme.com 
        * Advance POS 
        * http://erp53.com/item/advance-point-of-sale-system-pos/6317175
        * 
       */

namespace supershop
{
  
    public partial class Home : Form
    {
        private static int[] RGB_TRANS_MASK = { 230, 240, 250 };
        int originalExStyle = -1;
        bool enableFormLevelDoubleBuffering = true;
        public Home()
        {
            InitializeComponent();
            this.SuspendLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.FromArgb(RGB_TRANS_MASK[0], RGB_TRANS_MASK[1],
                    RGB_TRANS_MASK[2]);
            tsmIUserName.Text = UserInfo.UserName;
            //toolStripStatusLabel7.Text = "User: " + UserInfo.UserName;
            userProfileToolStripMenuItem.Text = " User Profile ( " + UserInfo.UserName + ")";

            if (UserInfo.IsSuperAddmin == true)
            {
                myAccountToolStripMenuItem.Visible = false;
                toolStripSeparator15.Visible = false;
            }
            else
            {
                myAccountToolStripMenuItem.Visible = true;
                toolStripSeparator15.Visible = true;
            }

            string SQl = "SELECT * FROM DayClose where TenentID=" + Tenent.TenentID + " and TrmID = '" + UserInfo.Shopid + "' ORDER BY ID DESC LIMIT 1";
            DataTable dt = DataAccess.GetDataTable(SQl);
            if (dt.Rows.Count > 0)
            {
                UserInfo.ShiftID = Convert.ToInt32(dt.Rows[0]["ShiftID"].ToString());
            }
            //toolStripMenuItem2.Text = "               "; // DataAccess.GetCompany()!=null? DataAccess.GetCompany():"";

            //menuStrip1.BackColor = Color.FromName(Properties.Settings.Default.ThemeColor);
            //statusStrip1.BackColor = Color.FromName(Properties.Settings.Default.ThemeColor);
            //string Path = UserInfo.LOGO;             
            // toolStripMenuItem2.Image = Image.FromFile(Path);

        }

        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                // this.Close();
                // Normal and Maximized
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Home_Load(object sender, EventArgs e)
        {
           // CheckIdleTimer.Start();

            if (Application.OpenForms["DashBoard"] != null)
            {
                Application.OpenForms["DashBoard"].Close();
            }
            DashBoard go = new DashBoard();
            go.MdiParent = this;
            go.Show();

            //int Syntime = getsyncTime();yogesh 290619
            //timerSyncronize.Interval = Syntime;
            

            SyncSetup.remove_Task();


        }

        public void ChackSyncroInstall()
        {
            bool flag = SyncSetup.IsProgramInstalled("Syncronize");

            if (flag == true)
            {
                string FileVertion = SyncSetup.ProductVirsion();
                string Vertioninstalled = SyncSetup.IsProgramInstalledProductCode("Syncronize");

                if (FileVertion != Vertioninstalled)
                {
                    bool flagun = SyncSetup.UninstallProgram("Syncronize");
                    if (flagun == true)
                    {
                        SyncSetup.remove_Task();
                        SyncSetup.install();
                        Addschadular();
                    }
                }
            }
            else
            {
                SyncSetup.remove_Task();
                SyncSetup.install();
                Addschadular();
            }
        }

        public static int getsyncTime()
        {
            int synTime = 0;
            string sqlterminallist = "select * from tbl_terminalLocation where Tenentid=" + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            DataTable dtterminallist = DataAccess.GetDataTable(sqlterminallist);

            if (dtterminallist.Rows.Count > 0)
            {
                int syncAfter = Convert.ToInt32(dtterminallist.Rows[0]["syncAfter"]);
                int Synsecound = syncAfter * 60;
                int milliseconds = Synsecound * 1000;
                synTime = milliseconds;
            }

            return synTime;
        }

        public static int getsyncDate()
        {
            int syncDay = 0;
            string sqlterminallist = "select * from tbl_terminalLocation where Tenentid=" + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            DataAccess.ExecuteSQL(sqlterminallist);
            DataTable dtterminallist = DataAccess.GetDataTable(sqlterminallist);

            if (dtterminallist.Rows.Count > 0)
            {
                syncDay = Convert.ToInt32(dtterminallist.Rows[0]["dayofSync"]);
            }

            return syncDay;
        }

        public void Addschadular()
        {
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Syncronization";

                // Create a trigger that will fire the task at this time every other day
                //td.Triggers.Add(new DailyTrigger { DaysInterval = 2 });

                int interval = Convert.ToInt32(10);
                var trigger = new TimeTrigger();
                trigger.Repetition.Interval = TimeSpan.FromMinutes(interval);
                td.Triggers.Add(trigger);

                string Path = Application.StartupPath.ToString();

                //string exe = Path + "\\syncro\\POS_Syncronic.application";
                string exe = @"C:\Program Files (x86)\Syncronization\POS_Syncronic.exe";
                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction(exe, null));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"Syncroniz", td);
            }
        }

        private void purchaseProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Add_Item"] == null)
            {
                Add_Item go = new Add_Item();
                go.MdiParent = this;
                go.Show();
            }
            else
            {
                Application.OpenForms["Add_Item"].BringToFront();
                Application.OpenForms["Add_Item"].WindowState = FormWindowState.Maximized;
            }

        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Stock_List"] == null)
            {
                Stock_List go = new Stock_List();
                go.MdiParent = this;
                go.Show();
            }
            else
            {
                Application.OpenForms["Stock_List"].BringToFront();
                Application.OpenForms["Stock_List"].WindowState = FormWindowState.Maximized;
            }

        }

        private void importItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Import_Items"] != null)
            {
                Application.OpenForms["Import_Items"].BringToFront();
                Application.OpenForms["Import_Items"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Import_Items go = new Import_Items();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = MyMessageBox.ShowBox("Do you want to Sign out?", "Confirmation");
            if (result == "1")//or 2=cancel
            {
                workRecords();

                string ActivityName = "Log Out";
                string LogData = "User " + UserInfo.UserName + " Log out ";
                Login.InsertUserLog(ActivityName, LogData);

                string openFrm = "";

                foreach (Form Item in Application.OpenForms)
                {
                    openFrm = openFrm + "," + Item.Name;
                }

                openFrm = openFrm.TrimStart(',');
                openFrm = openFrm.TrimEnd(',');

                string[] frm = openFrm.ToString().Trim().Split(',');

                for (int i = 0; i < frm.Length; i++)
                {
                    string FormName = frm[i].ToString();

                    if (FormName != "Home" && FormName != "Login")
                    {
                        if (Application.OpenForms[FormName] != null)
                        {
                            Application.OpenForms[FormName].Close();
                        }
                    }
                }

                Login go = new Login();
                go.Show();
                this.Close();
            }
        }

        public void workRecords()
        {
            string logdate = DateTime.Now.ToString("yyyy-MM-dd");
            string logtime = DateTime.Now.ToString("HH:mm:ss");
            string logdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            int ID = DataAccess.getworkrecordsMYid(Tenent.TenentID);

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlLogIn = " insert into tbl_workrecords (TenentID,ID, Username, datatype, logdate, logtime, logdatetime,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + "," + ID + ",'" + UserInfo.UserName + "' , 'OUT' , '" + logdate + "' , " +
                                  " '" + logtime + "' , '" + logdatetime + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
            int flag = DataAccess.ExecuteSQL(sqlLogIn);

            string sqlLogWin = " insert into Win_tbl_workrecords (TenentID,ID, Username, datatype, logdate, logtime, logdatetime,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + "," + ID + ",'" + UserInfo.UserName + "' , 'OUT' , '" + logdate + "' , " +
                                  " '" + logtime + "' , '" + logdatetime + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
            Datasyncpso.insert_Live_sync(sqlLogWin, "Win_tbl_workrecords", "INSERT");
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["salesreport"] != null)
            {
                Application.OpenForms["salesreport"].BringToFront();
                Application.OpenForms["salesreport"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                salesreport go = new salesreport();
                go.MdiParent = this;
                go.Show();
            }
        }


        private void systemConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Config"] != null)
            {
                Application.OpenForms["Config"].BringToFront();
            }
            else
            {
                Config go = new Config();
                go.ShowDialog();
            }
        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["User_regi"] != null)
            {
                Application.OpenForms["User_regi"].BringToFront();
                Application.OpenForms["User_regi"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                User_mgt.User_regi go = new User_mgt.User_regi();
                go.MdiParent = this;
                go.Show();
            }

        }

        private void manageUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Manage_user"] != null)
            {
                Application.OpenForms["Manage_user"].BringToFront();
                Application.OpenForms["Manage_user"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                User_mgt.Manage_user go = new User_mgt.Manage_user();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void salesRegisterBarcodeScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SalesRegister"] != null)
            {
                Application.OpenForms["SalesRegister"].BringToFront();
                Application.OpenForms["SalesRegister"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                SalesRegister go = new SalesRegister();
                go.MdiParent = this;
                go.Show();
            }

            //statusStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
        }

        private void salesRegistertoolStripStatus_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SalesRegister"] != null)
            {
                Application.OpenForms["SalesRegister"].BringToFront();
                Application.OpenForms["SalesRegister"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                SalesRegister go = new SalesRegister();
                go.MdiParent = this;
                go.Show();
            }

        }

        private void aboutSoftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["About_soft"] != null)
            {
                Application.OpenForms["About_soft"].BringToFront();
                Application.OpenForms["About_soft"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                About_soft go = new About_soft();
                go.MdiParent = this;
                go.Show();
            }

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do you want to Close this System ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }
        protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1)
                    originalExStyle = base.CreateParams.ExStyle;

                CreateParams cp = base.CreateParams;
                if (enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                else
                    cp.ExStyle = originalExStyle;

                return cp;
            }
        }
        private void TurnOffFormLevelDoubleBuffering()
        {
            enableFormLevelDoubleBuffering = false;
            this.MaximizeBox = true;
        }
        private void DateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // DateTime today = DateTime.Today;
                //DatetimertoolStripMenu.Text = DateTime.Now.ToString("hh:mm:ss tt dd-MMM-yyyy");
                toolStripStatusDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                toolStripStatusTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("\POS_Document\index.html");
            //webbrowser.Navigate("File location.html")
            //System.Diagnostics.Process.Start(Microsoft.SqlServer.Server.MapPath("~/HtmlFileFolderNameInSolution/") + "HtmlFileName.htm");

            if (Application.OpenForms["HelpPage"] != null)
            {
                Application.OpenForms["HelpPage"].BringToFront();
                Application.OpenForms["HelpPage"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                HelpPage go = new HelpPage();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void helplinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\POS_Document\index.html";
            System.Diagnostics.Process.Start(path);
        }


        private void toolStripMenuItem3Mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   //Minimized 
        }


        //// Normal and Maximized
        private void menuStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        //Minimized 
        private void MinimizertoolStripMenu_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Restore
        private void RestoretoolStripMenu_Click(object sender, EventArgs e)
        {
            // Normal and Maximized
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
        }

        private void dockStyleLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Dock = System.Windows.Forms.DockStyle.Left;
        }

        private void dockStyleRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Dock = System.Windows.Forms.DockStyle.Right;
        }

        private void dockStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
        }



        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            toolStripMenuOn_statusMenu.Visible = true;
            statusStrip1.Visible = false;
        }

        private void toolStripMenuItem9_Click_1(object sender, EventArgs e)
        {
            statusStrip1.Visible = true;
            toolStripMenuOn_statusMenu.Visible = false;
        }


        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Overview"] != null)
            {
                Application.OpenForms["Overview"].BringToFront();
                Application.OpenForms["Overview"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Overview go = new Overview();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void saleChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Sale_chart"] != null)
            {
                Application.OpenForms["Sale_chart"].BringToFront();
                Application.OpenForms["Sale_chart"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Sale_chart go = new Sale_chart();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void importDBBackupToolStripMenuItem_Click(object sender, EventArgs e)   // import and delete 
        {
            if (Application.OpenForms["Database_import"] != null)
            {
                Application.OpenForms["Database_import"].BringToFront();
                Application.OpenForms["Database_import"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Database_import go = new Database_import();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void returnProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Return_product"] != null)
            {
                Application.OpenForms["Return_product"].BringToFront();
                Application.OpenForms["Return_product"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Return_product go = new Return_product();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void generalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.LedgerReport go = new Report.LedgerReport();
            go.MdiParent = this;
            go.Show();
        }

        private void dueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DueList"] != null)
            {
                Application.OpenForms["DueList"].BringToFront();
                Application.OpenForms["DueList"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                DueList go = new DueList();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void todaySaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ShortCutReport"] != null)
            {
                Application.OpenForms["ShortCutReport"].BringToFront();
                Application.OpenForms["ShortCutReport"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Report.ShortCutReport go = new Report.ShortCutReport();
                go.DTtoday = DateTime.Now.ToString("yyyy-MM-dd");
                go.ReportName = "Daily Report";
                go.MdiParent = this;
                go.Show();
            }

        }
        private void reAssignDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReAssignDriver"] != null)
            {
                Application.OpenForms["ReAssignDriver"].BringToFront();
                Application.OpenForms["ReAssignDriver"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                ReAssignDriver go = new ReAssignDriver();
                go.DTtoday = DateTime.Now.ToString("yyyy-MM-dd");
                go.Show();
            }
        }


        private void last30DaysSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtd = DateTime.Now;
            dtd = dtd.AddDays(-30);

            Report.ShortCutReport go = new Report.ShortCutReport();
            go.last30salesStartDate = dtd.ToString("yyyy-MM-dd");
            go.last30salesENDDate = DateTime.Now.ToString("yyyy-MM-dd");
            go.ReportName = "Last 30 Days Report";
            go.MdiParent = this;
            go.Show();
        }


        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AddNewCustomer"] != null)
            {
                Application.OpenForms["AddNewCustomer"].BringToFront();
                Application.OpenForms["AddNewCustomer"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                UserInfo.addcustomerflag = false;
                Customer.AddNewCustomer go = new Customer.AddNewCustomer();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void CustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CustomerDetails"] != null)
            {
                Application.OpenForms["CustomerDetails"].BringToFront();
                Application.OpenForms["CustomerDetails"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Customer.CustomerDetails go = new Customer.CustomerDetails();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void addSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Add_Sales"] != null)
            {
                Application.OpenForms["Add_Sales"].BringToFront();
                Application.OpenForms["Add_Sales"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Inventory.Add_Sales go = new Inventory.Add_Sales();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void createBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["BarcodeRDLC"] != null)
            {
                Application.OpenForms["BarcodeRDLC"].BringToFront();
                Application.OpenForms["BarcodeRDLC"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                BarcodeRDLC go = new BarcodeRDLC();
                go.MdiParent = this;
                go.Show();
            }

        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["UserProfile"] != null)
            {
                Application.OpenForms["UserProfile"].BringToFront();
                Application.OpenForms["UserProfile"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                UserProfile go = new UserProfile(tsmIUserName.Text);
                go.MdiParent = this;
                go.Show();
            }
        }

        private void storeCreditRewardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["RewardsManagerReport"] != null)
            {
                Application.OpenForms["RewardsManagerReport"].BringToFront();
                Application.OpenForms["RewardsManagerReport"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Customer.RewardsManagerReport go = new Customer.RewardsManagerReport();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void generalLedgerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["LedgerReport"] != null)
            {
                Application.OpenForms["LedgerReport"].BringToFront();
                Application.OpenForms["LedgerReport"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Report.LedgerReport go = new Report.LedgerReport();
                go.MdiParent = this;
                go.Show();
            }

        }


        // Truncate table / remove data from transaction table
        private void dataResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Reset your Data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Data_Manage.DataReset go = new Data_Manage.DataReset();
                go.ShowDialog();
            }

        }

        private void stockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["StockDetails"] != null)
            {
                Application.OpenForms["StockDetails"].BringToFront();
                Application.OpenForms["StockDetails"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Items.StockDetails go = new Items.StockDetails();
                go.MdiParent = this;
                go.Show();
            }

        }

        private void profitLossReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PLdialog"] != null)
            {
                Application.OpenForms["PLdialog"].BringToFront();

            }
            else
            {
                Report.PLdialog go = new Report.PLdialog();
                // go.MdiParent = this;
                go.ShowDialog();
            }

        }


        //Only Save
        private void saveAsDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime today = DateTime.Today;
                string fileName = "psodb.db";
                string fileName2 = "posBackup_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
                string sourcePath = Application.StartupPath; //Application.StartupPath + @"\FinalImage\";
                string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // @"C:\Users\Public\TestFolder\SubDir";

                // Use Path class to manipulate file and directory paths. 
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName2);



                // To copy a folder's contents to a new location: 
                // Create a new target folder, if necessary. 
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);

                }

                System.IO.File.Copy(sourceFile, destFile, true);

                //  File.SetAttributes(destFile, File.GetAttributes(destFile) | (FileAttributes.Archive | FileAttributes.ReadOnly));                

                MessageBox.Show("Your Backup is Created !!! ... \n " +
                                "Please check  your Desktop And \n Keep --posBackup-- File In your Secure folder. " +
                                "\n You should try to keep  the File  " +
                                "\n If File is not Appear Please Show hidden files; From the Folder Option  ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void saveBackupAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "psoBackup_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".db";
            saveFileDialog1.ShowDialog();
        }

        //Save backup As
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string sourceFileName = "psodb.db";
                string destFileFileName = "posBackup_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".db";
                string sourcePath = Application.StartupPath;

                // Get file name and dest path
                string targetPath = saveFileDialog1.FileName;

                //   string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);  

                //// Use Path class to manipulate file and directory paths. 
                string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
                string destFile = System.IO.Path.Combine(targetPath, destFileFileName);



                // To copy a folder's contents to a new location: 
                // Create a new target folder, if necessary. 
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);

                }

                System.IO.File.Copy(sourceFile, destFile, true);


                //File.Copy(sourceFile, destFileFileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Categories"] != null)
            {
                Application.OpenForms["Categories"].BringToFront();
                Application.OpenForms["Categories"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Categories go = new Categories();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ExpensesList"] != null)
            {
                Application.OpenForms["ExpensesList"].BringToFront();
                Application.OpenForms["ExpensesList"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Expenses.ExpensesList go = new Expenses.ExpensesList();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void topSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TopSales"] != null)
            {
                Application.OpenForms["TopSales"].BringToFront();
                Application.OpenForms["TopSales"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Report.TopSales go = new Report.TopSales();
                go.MdiParent = this;
                go.Show();
            }

        }

        private void barcodeCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["BarcodeCreator"] != null)
            {
                Application.OpenForms["BarcodeCreator"].BringToFront();
                Application.OpenForms["BarcodeCreator"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                BarCode.BarcodeCreator go = new BarCode.BarcodeCreator();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.ThemeColor = ColorDialog1.Color.Name;
                menuStrip1.BackColor = ColorDialog1.Color;
                statusStrip1.BackColor = ColorDialog1.Color;
                btnSync.BackColor = ColorDialog1.Color;
                lblSyn.BackColor = ColorDialog1.Color;
                PicSyncro.BackColor = ColorDialog1.Color;
            }
        }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog foreColor = new ColorDialog();
            if (foreColor.ShowDialog() == DialogResult.OK)
            {
                menuStrip1.ForeColor = foreColor.Color;
                statusStrip1.ForeColor = foreColor.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                menuStrip1.Font = fontDialog1.Font;
                statusStrip1.Font = fontDialog1.Font;
            }
        }

        private void kitchenDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Kitchen_display"] != null)
            {
                Application.OpenForms["Kitchen_display"].BringToFront();
                Application.OpenForms["Kitchen_display"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Kitchen_display go = new Kitchen_display();
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }
        }

        private void barcodeMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Barcode_machine1"] != null)
            {
                Application.OpenForms["Barcode_machine1"].BringToFront();
                Application.OpenForms["Barcode_machine1"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                BarCode.Barcode_machine go = new BarCode.Barcode_machine();
                go.MdiParent = this;
                go.Show();
            }

        }

        private void purchaseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Purchase_History"] == null)
            {
                Items.Purchase_History go = new Items.Purchase_History();
                go.MdiParent = this;
                go.Show();
            }
            else
            {
                Application.OpenForms["Purchase_History"].BringToFront();
                Application.OpenForms["Purchase_History"].WindowState = FormWindowState.Maximized;
            }

        }

        private void workSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["WorkSheet"] == null)
            {
                User_mgt.WorkSheet go = new User_mgt.WorkSheet();
                go.MdiParent = this;
                go.Show();
            }
            else
            {
                Application.OpenForms["WorkSheet"].BringToFront();
                Application.OpenForms["WorkSheet"].WindowState = FormWindowState.Maximized;
            }

        }

        private void englishMenu_Click(object sender, EventArgs e)
        {
            res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);

            cul = CultureInfo.CreateSpecificCulture("en");
            switch_language();
            //menuStrip1.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            menuStrip1.RightToLeft = RightToLeft.No;
            statusStrip1.Dock = DockStyle.Left;
            statusStrip2.RightToLeft = RightToLeft.Yes;
            UserInfo.Language = "English";
        }

        private void arebicMenu_Click(object sender, EventArgs e)
        {
            res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);


            cul = CultureInfo.CreateSpecificCulture("Ar");
            switch_language();
            //menuStrip1.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            menuStrip1.RightToLeft = RightToLeft.Yes;
            statusStrip1.Dock = DockStyle.Right;
            statusStrip2.RightToLeft = RightToLeft.No;
            UserInfo.Language = "Arabic";
        }

        private void switch_language()
        {
            addToolStripMenuItem1.Text = res_man.GetString("addToolStripMenuItem1", cul);
            barcodeCreatorToolStripMenuItem.Text = res_man.GetString("barcodeCreatorToolStripMenuItem", cul);
            barcodeMachineToolStripMenuItem.Text = res_man.GetString("barcodeMachineToolStripMenuItem", cul);
            categoriesToolStripMenuItem.Text = res_man.GetString("categoriesToolStripMenuItem", cul);
            createBarcodeToolStripMenuItem.Text = res_man.GetString("createBarcodeToolStripMenuItem", cul);
            dataResetToolStripMenuItem.Text = res_man.GetString("dataResetToolStripMenuItem", cul);
            exitToolStripMenuItem.Text = res_man.GetString("exitToolStripMenuItem", cul);
            fileToolStripMenuItem.Text = res_man.GetString("fileToolStripMenuItem", cul);
            helpToolStripMenuItem.Text = res_man.GetString("helpToolStripMenuItem", cul);
            importItemsToolStripMenuItem.Text = res_man.GetString("importItemsToolStripMenuItem", cul);
            //LanguageToolStripMenuItem.Text = res_man.GetString("LanguageToolStripMenuItem", cul);
            productListToolStripMenuItem.Text = res_man.GetString("productListToolStripMenuItem", cul);
            purchaseHistoryToolStripMenuItem.Text = res_man.GetString("purchaseHistoryToolStripMenuItem", cul);
            purchaseProductToolStripMenuItem.Text = res_man.GetString("purchaseProductToolStripMenuItem", cul);
            restoreDataToolStripMenuItem.Text = res_man.GetString("restoreDataToolStripMenuItem", cul);
            salesRegistertoolStripStatus.Text = res_man.GetString("salesRegistertoolStripStatus", cul);
            saveAsDatabaseToolStripMenuItem.Text = res_man.GetString("saveAsDatabaseToolStripMenuItem", cul);
            saveBackupAsToolStripMenuItem.Text = res_man.GetString("saveBackupAsToolStripMenuItem", cul);
            settingToolStripMenuItem.Text = res_man.GetString("settingToolStripMenuItem", cul);
            stockDetailsToolStripMenuItem.Text = res_man.GetString("stockDetailsToolStripMenuItem", cul);
            toolStripMenuItem20.Text = res_man.GetString("toolStripMenuItem20", cul);
            toolStripMenuOn_statusMenu.Text = res_man.GetString("toolStripMenuOn_statusMenu", cul);
            //toolStripStatusLabel1.Text = res_man.GetString("toolStripStatusLabel1", cul);
            toolStripStatusLabel2.Text = res_man.GetString("toolStripStatusLabel2", cul);
            toolStripStatusLabel4.Text = res_man.GetString("toolStripStatusLabel4", cul);
            toolStripStatusLabel5.Text = res_man.GetString("toolStripStatusLabel5", cul);
            //toolStripStatusLabel1.Text = res_man.GetString("toolStripStatusLabel6", cul);
            toolStripStatusLabel8.Text = res_man.GetString("toolStripStatusLabel8", cul);
            toolStripStatusLabel9.Text = res_man.GetString("toolStripStatusLabel9", cul);
            transectionToolStripMenuItem.Text = res_man.GetString("transectionToolStripMenuItem", cul);
            userProfileToolStripMenuItem.Text = res_man.GetString("userProfileToolStripMenuItem", cul);
            userToolStripMenuItem.Text = res_man.GetString("userToolStripMenuItem", cul);
            viewToolStripMenuItem.Text = res_man.GetString("viewToolStripMenuItem", cul);
            dueListToolStripMenuItem.Text = res_man.GetString("dueListToolStripMenuItem", cul);
            expensesToolStripMenuItem.Text = res_man.GetString("expensesToolStripMenuItem", cul);
            kitchenDisplayToolStripMenuItem.Text = res_man.GetString("kitchenDisplayToolStripMenuItem", cul);
            returnProductToolStripMenuItem.Text = res_man.GetString("returnProductToolStripMenuItem", cul);
            salesRegisterBarcodeScannerToolStripMenuItem.Text = res_man.GetString("salesRegisterBarcodeScannerToolStripMenuItem", cul);
            aboutSoftToolStripMenuItem.Text = res_man.GetString("aboutSoftToolStripMenuItem", cul);
            //arebicMenu.Text = res_man.GetString("arebicMenu", cul);
            customerReportToolStripMenuItem.Text = res_man.GetString("customerReportToolStripMenuItem", cul);
            //englishMenu.Text = res_man.GetString("englishMenu", cul);
            //generalLedgerReportToolStripMenuItem.Text = res_man.GetString("generalLedgerReportToolStripMenuItem", cul);
            helplinkToolStripMenuItem.Text = res_man.GetString("helplinkToolStripMenuItem", cul);
            helpToolStripMenuItem1.Text = res_man.GetString("helpToolStripMenuItem1", cul);
            manageUserToolStripMenuItem.Text = res_man.GetString("manageUserToolStripMenuItem", cul);
            overviewToolStripMenuItem.Text = res_man.GetString("overviewToolStripMenuItem", cul);
            profitLossReportToolStripMenuItem.Text = res_man.GetString("profitLossReportToolStripMenuItem", cul);
            saleChartToolStripMenuItem.Text = res_man.GetString("saleChartToolStripMenuItem", cul);
            salesReportToolStripMenuItem.Text = res_man.GetString("salesReportToolStripMenuItem", cul);
            storeCreditRewardsToolStripMenuItem.Text = res_man.GetString("storeCreditRewardsToolStripMenuItem", cul);
            systemConfigurationToolStripMenuItem.Text = res_man.GetString("systemConfigurationToolStripMenuItem", cul);
            toolStripMenuItem17.Text = res_man.GetString("toolStripMenuItem17", cul);
            topSalesToolStripMenuItem.Text = res_man.GetString("topSalesToolStripMenuItem", cul);
            userRegistrationToolStripMenuItem.Text = res_man.GetString("userRegistrationToolStripMenuItem", cul);
            workSheetToolStripMenuItem.Text = res_man.GetString("workSheetToolStripMenuItem", cul);
            todaySalesToolStripMenuItem.Text = res_man.GetString("todaySalesToolStripMenuItem", cul);

        }

        private void editLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resediter go = new Resediter();
            go.MdiParent = this;
            go.Show();
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);

            cul = CultureInfo.CreateSpecificCulture("en");
            switch_language();
            //menuStrip1.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            menuStrip1.RightToLeft = RightToLeft.No;
            statusStrip1.Dock = DockStyle.Left;
            statusStrip2.RightToLeft = RightToLeft.Yes;
            UserInfo.Language = "English";
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);


            cul = CultureInfo.CreateSpecificCulture("Ar");
            switch_language();
            //menuStrip1.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            menuStrip1.RightToLeft = RightToLeft.Yes;
            statusStrip1.Dock = DockStyle.Right;
            statusStrip2.RightToLeft = RightToLeft.No;
            UserInfo.Language = "Arabic";
        }

        private void commissioonMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderWayMaintenance go = new OrderWayMaintenance();
            go.MdiParent = this;
            go.Show();
        }

        private void payCommissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommissionPay go = new CommissionPay();
            go.MdiParent = this;
            go.Show();
            //SalesRagister.OrderWay_Transection go = new SalesRagister.OrderWay_Transection();
            //go.MdiParent = this;
            //go.Show();
        }

        private void KitchenOrderComplateToolStrip_Click(object sender, EventArgs e)
        {
            Report.OrderComplateList go = new Report.OrderComplateList();
            go.MdiParent = this;
            go.Show();
        }


        private void updateApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Manage.Update_App go = new Data_Manage.Update_App();
            go.Show();
            this.Close();
        }

        private void uOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["UomList"] != null)
            {
                Application.OpenForms["UomList"].BringToFront();
                Application.OpenForms["UomList"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                UomList go = new UomList();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void openingBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["OpeningBalance"] != null)
            {
                Application.OpenForms["OpeningBalance"].BringToFront();
            }
            else
            {
                Report.OpeningBalance go = new Report.OpeningBalance();
                go.Show();
            }

        }

        private void dayCloseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CloseDay"] != null)
            {
                Application.OpenForms["CloseDay"].BringToFront();
            }
            else
            {
                Report.CloseDay go = new Report.CloseDay();
                go.Show();
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CashDelivery"] != null)
            {
                Application.OpenForms["CashDelivery"].BringToFront();
            }
            else
            {
                Report.CashDelivery go = new Report.CashDelivery();
                go.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //bool Falg = Login.InternetConnection();

                //if (Falg == true)
                //{
                //    lblConnection.Text = "Internet Connection Avalable";
                //    //lblstatusmsg.Text = getLastLiveUserLog();
                //}
                //else
                //{
                //    lblConnection.Text = "Internet Connection Not Avalable";
                //    lblstatusmsg.Text = "online Server Connection Fail";
                //}

             //  if (Application.OpenForms["DashBoard"] == null)
             //  {
             //      DashBoard go = new DashBoard();
             //      go.MdiParent = this;
             //      go.Show();
             //  }
             //
            }
            catch
            {
                //bool Falg = Login.InternetConnection();

                //if (Falg == true)
                //{
                //    lblConnection.Text = "Internet Connection Avalable";
                //    lblstatusmsg.Text = "online Server Connection Fail";
                //}
                //else
                //{
                //    lblConnection.Text = "Internet Connection Not Avalable";
                //    lblstatusmsg.Text = "online Server Connection Fail";
                //}
            }
        }



        private void syncronizationSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SyncSetup"] != null)
            {
                Application.OpenForms["SyncSetup"].BringToFront();
            }
            else
            {
                SyncSetup go = new SyncSetup();
                go.Show();
            }
        }

        //private void onlineRegToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    onlineReg go = new onlineReg();
        //    go.Show();
        //}

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Sign out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                workRecords();

                string ActivityName = "Log Out";
                string LogData = "User " + UserInfo.UserName + " Log out ";
                Login.InsertUserLog(ActivityName, LogData);

                Login go = new Login();
                go.Show();
                this.Close();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SetPrinter"] != null)
            {
                Application.OpenForms["SetPrinter"].BringToFront();
            }
            else
            {
                SetPrinter go = new SetPrinter();
                go.Show();
            }
        }

        private void RelatedItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["RelatedProduct"] != null)
            {
                Application.OpenForms["RelatedProduct"].BringToFront();
                Application.OpenForms["RelatedProduct"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                RelatedProduct go = new RelatedProduct();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void weekSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ShortCutReport"] != null)
            {
                Application.OpenForms["ShortCutReport"].Close();
            }
            this.Refresh();
            Report.ShortCutReport go = new Report.ShortCutReport();
            go.ReportName = "Week Sales Report";
            go.last30salesStartDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            go.last30salesENDDate = DateTime.Now.ToString("yyyy-MM-dd");
            go.MdiParent = this;
            go.Show();
        }

        private void toolStripToDaySales_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ShortCutReport"] != null)
            {
                Application.OpenForms["ShortCutReport"].Close();
            }
            this.Refresh();
            Report.ShortCutReport go = new Report.ShortCutReport();
            go.DTtoday = DateTime.Now.ToString("yyyy-MM-dd");
            go.ReportName = "Daily Report";
            go.MdiParent = this;
            go.Show();
        }

        private void monthlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ShortCutReport"] != null)
            {
                Application.OpenForms["ShortCutReport"].Close();
            }
            this.Refresh();
            Report.ShortCutReport go = new Report.ShortCutReport();
            go.ReportName = "Last 30 Day Report";
            go.last30salesStartDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            go.last30salesENDDate = DateTime.Now.ToString("yyyy-MM-dd");
            go.MdiParent = this;
            go.Show();
        }

        private void addRelatedProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["RelatedProduct"] != null)
            {
                Application.OpenForms["RelatedProduct"].Close();
            }
            this.Refresh();
            RelatedProduct go = new RelatedProduct();
            go.MdiParent = this;
            go.Show();
        }

        private void yearYoDaySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);

            if (Application.OpenForms["ShortCutReport"] != null)
            {
                Application.OpenForms["ShortCutReport"].Close();
            }
            this.Refresh();
            Report.ShortCutReport go = new Report.ShortCutReport();
            go.ReportName = "Year TO Day Report";
            go.last30salesStartDate = firstDay.ToString("yyyy-MM-dd");
            go.last30salesENDDate = DateTime.Now.ToString("yyyy-MM-dd");
            go.MdiParent = this;
            go.Show();
        }

        private void DashBoardtoolStripStatus_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DashBoard"] != null)
            {
                Application.OpenForms["DashBoard"].BringToFront();
                Application.OpenForms["DashBoard"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                DashBoard go = new DashBoard();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void CheckIdleTimer_Tick(object sender, EventArgs e)
        {
            int IdelTime1 = Convert.ToInt32(Win32.GetIdleTime());
            if (IdelTime1 > 600000)
            {
                if (IdelTime.WorkingFalg == false)
                {
                    //workRecords();
                    //string ActivityName = "Log Out";
                    //string LogData = "User " + UserInfo.UserName + " Log out ";
                    //Login.InsertUserLog(ActivityName, LogData);
                    Win32.LockWorkStation();
                    //Application.Restart();
                }

            }
        }

      //  public static string getLastLiveUserLog()
      //  {
      //      string StatusMsg = "";
      //      bool CON_Ceck = Login.CheckDBConnection();
      //      if (CON_Ceck == true)
      //      {
      //          string sql = "SELECT top 1 * FROM Win_tbl_UserLog where tenentid=" + Tenent.TenentID + " ORDER BY logdatetime DESC";
      //          DataTable dt = DataLive.GetLiveDataTable(sql);
      //          if (dt.Rows.Count > 0)
      //          {
      //              StatusMsg = dt.Rows[0]["Log_Data"].ToString() + "  -  " + dt.Rows[0]["logdatetime"].ToString();
      //          }
      //      }
      //      else
      //      {
      //          StatusMsg = "online Server Connection Fail";
      //      }
      //
      //      return StatusMsg;
      //  }

        private void toolStripDashBoard_Click(object sender, EventArgs e)
        {
           // if (Application.OpenForms["DashBoard"] != null)
           // {
           //     Application.OpenForms["DashBoard"].Close();
           // }
           // else
           // {
           //     DashBoard go = new DashBoard();
           //     go.MdiParent = this;
           //     go.Show();
           // }
        }

        public static bool TodayFullSync()
        {
            bool Flag = false;
            int Salesync = SyncSetup.ISSaleSync();
            if (Salesync == 1)
            {
                string Today = DateTime.Now.ToString("yyyy-MM-dd");
                string sqlterminallist = "select * from Win_tbl_UserLog where TenentID = " + Tenent.TenentID + " and ActivityName = 'Syncronization' and logdate like '" + Today + "' and status = 2 ";
                DataTable dtterminallist = DataAccess.GetDataTable(sqlterminallist);
                if (dtterminallist.Rows.Count > 0)
                {
                    Flag = true;
                }
            }

            return Flag;
        }

        BackgroundWorker bw = new BackgroundWorker();
        private void timerSyncronize_Tick(object sender, EventArgs e)//Stop Sync Yogesh 290619
        {
            //bool ISrun = backSyncro.isRun;
            //if (ISrun != true)
            //{
            //    int syntyme = Home.getsyncTime();
            //    int Secound = syntyme / 60;
            //    int minutes = Secound / 1000;
            //    backSyncro.Minute = minutes;

            //    backSyncro.isRun = true;
            //    PicSyncro.Visible = true;

            //    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            //    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            //    bw.RunWorkerAsync();

            //    btnSync.Text = "Stop";

            //    if (Application.OpenForms["Syncscreen"] != null)
            //    {
            //        Application.OpenForms["Syncscreen"].Close();
            //    }
            //    Syncscreen go = new Syncscreen();
            //    go.Show();

            //}

        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PicSyncro.Visible = false;
            backSyncro.isRun = false;
            backSyncro.SyncType = null;
            //btnSync.Text = "Sync";
        }


        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int Day = getsyncDate();
            int daysy = Day * -1;
            DateTime syncDate = DateTime.Now.AddDays(daysy);

            bool salesync = TodayFullSync();

            if (salesync == true)
            {
                backSyncro.Salessync = true;
            }
            else
            {
                backSyncro.Salessync = false;
            }

            if (backSyncro.SyncType == "Full")
            {
                Data_Manage.Update_App.DBSyncro(Tenent.TenentID);
            }
            else
            {
                Data_Manage.Update_App.DBSyncro_BAckground(Tenent.TenentID, syncDate);
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Syncprocess();
        }

        public void Syncprocess()
        {
            try
            {
                if (btnSync.Text == "Sync")
                {
                    bool ISrun = backSyncro.isRun;
                    if (ISrun != true)
                    {
                        //int syntyme = Home.getsyncTime();
                        //int Secound = syntyme / 60;
                        //int minutes = Secound / 1000;
                        //backSyncro.Minute = minutes;

                        backSyncro.isRun = true;
                        PicSyncro.Visible = true;

                        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                        bw.RunWorkerAsync();

                        btnSync.Text = "Stop";

                        if (Application.OpenForms["Syncscreen"] != null)
                        {
                            Application.OpenForms["Syncscreen"].Close();
                        }
                        Syncscreen go = new Syncscreen();
                        go.Show();
                    }
                }
                else
                {
                    backSyncro.isRun = false;
                    PicSyncro.Visible = false;
                    btnSync.Text = "Sync";

                    if (Application.OpenForms["Syncscreen"] != null)
                    {
                        Application.OpenForms["Syncscreen"].Close();
                    }
                }

            }
            catch
            {

            }
        }

        public string syncstatus
        {
            set
            {
                lblSyn.Text = value;
            }
            get
            {
                return lblSyn.Text;
            }
        }

        private void lblSyn_TextChanged(object sender, EventArgs e)
        {
            if (lblSyn.Text != ".")
            {
                backSyncro.isRun = false;
                PicSyncro.Visible = false;
                btnSync.Text = "Sync";

                if (Application.OpenForms["Syncscreen"] != null)
                {
                    Application.OpenForms["Syncscreen"].Close();
                }
            }
            lblSyn.Text = ".";
        }

        private void timer2_Tick(object sender, EventArgs e)//Delete Yogesh 290619
        {

            //if (backSyncro.isRun == true)//yogesh Stop Sync 290619
            //{
            //    if (Application.OpenForms["Syncscreen"] != null)
            //    {
            //        Syncscreen go = (Syncscreen)Application.OpenForms["Syncscreen"];
            //        go.Show();
            //    }
            //    else
            //    {
            //        Syncscreen go = new Syncscreen();
            //        go.Show();
            //    }
            //}
            //else
            //{
            //    int Syntime = getsyncTime();

            //    timerSyncronize.Interval = Syntime;

            //    if (Application.OpenForms["Syncscreen"] != null)
            //    {
            //        Application.OpenForms["Syncscreen"].Close();
            //    }
            //}//yogesh Stop Sync 290619
        }

        //private void toolStripStatusLabel1_Click(object sender, EventArgs e)//yogesh 80519
        //{
        //    if (Application.OpenForms["Config"] != null)
        //    {
        //        Application.OpenForms["Config"].BringToFront();

        //    }
        //    else
        //    {
        //        Config go = new Config();
        //        go.ShowDialog();
        //    }

        //}

        private void fullSyncronizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backSyncro.SyncType = "Full";

            string ActivityName = "Syncronization";
            string LogData = "Syncronization Start ";
            Login.InsertUserLog(ActivityName, LogData);
            Syncprocess();
        }

        private void cashDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CashDeliveryReport"] != null)
            {
                Application.OpenForms["CashDeliveryReport"].BringToFront();
                Application.OpenForms["CashDeliveryReport"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                CashDeliveryReport GO = new CashDeliveryReport();
                GO.MdiParent = this;
                GO.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["OpeningBalanceReport"] != null)
            {
                Application.OpenForms["OpeningBalanceReport"].BringToFront();
                Application.OpenForms["OpeningBalanceReport"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                OpeningBalanceReport GO = new OpeningBalanceReport();
                GO.MdiParent = this;
                GO.Show();
            }
        }

        private void receipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReceipeList"] != null)
            {
                Application.OpenForms["ReceipeList"].BringToFront();
                Application.OpenForms["ReceipeList"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Items.ReceipeList go = new Items.ReceipeList();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void receipeMenegementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ReceipeMenegement"] != null)
            {
                Application.OpenForms["ReceipeMenegement"].BringToFront();
            }
            else
            {
                ReceipeMenegement go = new ReceipeMenegement();
                go.MdiParent = this;
                go.Show();
            }
        }

        public void openWindows()
        {
            this.openWindowsToolStripMenuItem.DropDownItems.Clear();
            foreach (Form Item in Application.OpenForms)
            {
                string Title = Item.Text;

                if (Title.Contains("Home - ") == false)
                {
                    if (Title != "Login")
                    {
                        string FormName = Item.Name;
                        ToolStripMenuItem MnuStripItem = new ToolStripMenuItem(Title, null, ChildClick);
                        MnuStripItem.Name = FormName;
                        this.openWindowsToolStripMenuItem.DropDownItems.Add(MnuStripItem);
                    }
                }

            }

        }

        public void ChildClick(object sender, System.EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string pagename = item.Name;

            if (Application.OpenForms[pagename] != null)
            {
                Application.OpenForms[pagename].BringToFront();
                Application.OpenForms[pagename].WindowState = FormWindowState.Maximized;

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
           //if (this.openWindowsToolStripMenuItem.DropDown.Visible == false)
           //{
           //    openWindows();
           //}
           //
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms["printerSetting"] != null)
            {
                Application.OpenForms["printerSetting"].BringToFront();
            }
            else
            {
                printerSetting go = new printerSetting();
                go.Show();
            }
        }

        private void appointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AppointmentS"] != null)
            {
                Application.OpenForms["AppointmentS"].BringToFront();
            }
            else
            {
                AppointmentS go = new AppointmentS();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void toolStripAppointment_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AppointmentS1"] != null)
            {
                Application.OpenForms["AppointmentS1"].BringToFront();
            }
            else
            {
                AppointmentS1 go = new AppointmentS1();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void appointmentTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AppointmentS1"] != null)
            {
                Application.OpenForms["AppointmentS1"].BringToFront();
            }
            else
            {
                AppointmentS1 go = new AppointmentS1();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void purchase_MenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Purchase"] != null)
            {
                Application.OpenForms["Purchase"].BringToFront();
            }
            else
            {
                Purchase go = new Purchase();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void toolStripPaymentType_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PaymentTypeList"] != null)
            {
                Application.OpenForms["PaymentTypeList"].BringToFront();
            }
            else
            {
                PaymentTypeList go = new PaymentTypeList();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void toolStrippayablecredit_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["payablecredit"] != null)
            {
                Application.OpenForms["payablecredit"].BringToFront();
            }
            else
            {
                payablecredit go = new payablecredit();
                go.Show();
            }
        }

        private void calenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Calanders"] != null)
            {
                Application.OpenForms["Calanders"].BringToFront();
            }
            else
            {
                Calander go = new Calander();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void DeleteInvoice_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Delete_Invoice"] != null)
            {
                Application.OpenForms["Delete_Invoice"].BringToFront();
            }
            else
            {
                Delete_Invoice go = new Delete_Invoice();
                go.MdiParent = this;
                go.Show();
            }

        }

        private void commissionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CommissionReport"] != null)
            {
                Application.OpenForms["CommissionReport"].BringToFront();
            }
            else
            {
                CommissionReport go = new CommissionReport();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void serializedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["rptSerialReport"] != null)
            {
                Application.OpenForms["rptSerialReport"].BringToFront();
            }
            else
            {
                rptSerialReport go = new rptSerialReport();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void productSummeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ItemSummery"] != null)
            {
                Application.OpenForms["ItemSummery"].BringToFront();
            }
            else
            {
                ItemSummery go = new ItemSummery();
                go.MdiParent = this;
                go.Show();
            }

        }

        private void maintananceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool Falg = Login.CheckDBConnection();
            if (Falg == false)
            {
                MessageBox.Show("online Server Connection Fail. try again later", "Server Connection Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlMaintanance = "select Query from TBLMaintanance where SwichType =" + Tenent.TenentID + " and MODULEID=39 and Active='True'";//Module_MST.MODULEID=39 is POSWIN
            DataTable dtMaintanance = DataLive.GetLiveDataTable(sqlMaintanance);
            if (dtMaintanance.Rows.Count >= 1)
            {
                string qry = "";
                for (int i = 0; i < dtMaintanance.Rows.Count; i++)
                {
                    qry += dtMaintanance.Rows[i]["Query"].ToString();
                }
                MessageBox.Show("Maintanance Process Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Already Maintanance upto date", "Maintanance Upto Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DeleteInvoiceReport"] != null)
            {
                Application.OpenForms["DeleteInvoiceReport"].BringToFront();
            }
            else
            {
                DeleteInvoiceReport go = new DeleteInvoiceReport();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void adminConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ConfigAdmin"] != null)
            {
                Application.OpenForms["ConfigAdmin"].BringToFront();
            }
            else
            {
                ConfigAdmin go = new ConfigAdmin();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CreditPaybleReport"] != null)
            {
                Application.OpenForms["CreditPaybleReport"].BringToFront();
            }
            else
            {
                CreditPaybleReport go = new CreditPaybleReport();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void deliveryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["DeliveryReport"] != null)
            {
                Application.OpenForms["DeliveryReport"].BringToFront();
            }
            else
            {
                DeliveryReport go = new DeliveryReport();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void btnUserProfile_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DashBoard"] != null)
            {
                Application.OpenForms["DashBoard"].BringToFront();
                Application.OpenForms["DashBoard"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                DashBoard go = new DashBoard();
                go.MdiParent = this;
                go.Show();
            }
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            TurnOffFormLevelDoubleBuffering();
        }
    }
}
