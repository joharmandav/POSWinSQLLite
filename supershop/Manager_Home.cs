using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace supershop
{
    public partial class Manager_Home : Form
    {
        public Manager_Home(string a)
        {
            InitializeComponent();
            toolStripMenuItemUserName.Text = a;
            toolStripStatusLabel7.Text = a;
            userProfileToolStripMenuItem.Text = " User Profile ( " + a + ")";
            toolStripMenuItem7.Text = DataAccess.GetCompany();
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


        private void sellProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesRegister go = new SalesRegister();
            go.MdiParent = this;
            go.Show();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salesreport go = new salesreport();
            go.MdiParent = this;
            go.Show();
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_List go = new Stock_List();
            go.MdiParent = this;
            go.Show();
        }

        private void purchaseProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Item go = new Add_Item(); go.MdiParent = this;
            go.Show();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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
            int flag1 = DataAccess.ExecuteSQL(sqlLogIn);

            string sqlLogWin = " insert into Win_tbl_workrecords (TenentID,ID, Username, datatype, logdate, logtime, logdatetime,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + "," + ID + ",'" + UserInfo.UserName + "' , 'OUT' , '" + logdate + "' , " +
                                  " '" + logtime + "' , '" + logdatetime + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
            Datasyncpso.insert_Live_sync(sqlLogWin, "Win_tbl_workrecords", "INSERT");

        }

        private void Manager_Home_Load(object sender, EventArgs e)
        {
            //About_soft go = new About_soft();
            //go.MdiParent = this;
            //go.Show();

            int Syntime = Home.getsyncTime();

            timerSyncronize.Interval = Syntime;
        }

        private void aboutSoftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_soft go = new About_soft();
            go.MdiParent = this;
            go.Show();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            toolStripMenuItem2.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

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
            catch
            {
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

        private void Manager_Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do you want to Sign out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    // Application.Exit();
            //    Login go = new Login();
            //    go.Show();
            //    this.Close();
            //}
        }

        private void Manager_Home_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }


        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   //Minimized 
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
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

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            Return_product go = new Return_product();
            go.MdiParent = this;
            go.Show();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpPage go = new HelpPage();
            go.MdiParent = this;
            go.Show();
        }

        private void createBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarCode.Barcode_machine go = new BarCode.Barcode_machine();
            go.MdiParent = this;
            go.Show();
            //BarcodeRDLC go = new BarcodeRDLC();
            //    go.MdiParent = this;
            //    go.Show();

        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            Inventory.Add_Sales go = new Inventory.Add_Sales();
            go.MdiParent = this;
            go.Show();
        }

        private void toolStripMenuItemUserName_Click(object sender, EventArgs e)
        {            
            if (Application.OpenForms["UserProfile"] != null)
            {
                Application.OpenForms["UserProfile"].BringToFront();
                Application.OpenForms["UserProfile"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                UserProfile go = new UserProfile(toolStripMenuItemUserName.Text);
                go.MdiParent = this;
                go.Show();
            }
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer.AddNewCustomer go = new Customer.AddNewCustomer();
            go.MdiParent = this;
            go.Show();
        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer.CustomerDetails go = new Customer.CustomerDetails();
            go.MdiParent = this;
            go.Show();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Categories go = new Categories();
            go.MdiParent = this;
            go.Show();
        }

        private void kitchenDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PendingKitchen"] != null)
            {
                Application.OpenForms["PendingKitchen"].Close();
            }
            this.Refresh();
            Report.PendingKitchen go = new Report.PendingKitchen();
            go.MdiParent = Application.OpenForms["Kitchen_Home"];
            go.Show();
        }

        private void purchaseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Items.Purchase_History go = new Items.Purchase_History();
            go.MdiParent = this;
            go.Show();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);

            cul = CultureInfo.CreateSpecificCulture("en");
            switch_language();
            //menuStrip1.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            menuStrip1.RightToLeft = RightToLeft.No;
            statusStrip1.Dock = DockStyle.Left;
            UserInfo.Language = "English";
        }

        private void arabicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);


            cul = CultureInfo.CreateSpecificCulture("Ar");
            switch_language();
            //menuStrip1.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            menuStrip1.RightToLeft = RightToLeft.Yes;
            statusStrip1.Dock = DockStyle.Right;
            UserInfo.Language = "Arabic";
        }

        private void switch_language()
        {
            toolStripStatusLabel3.Text = res_man.GetString("Manager_Home_toolStripStatusLabel3", cul);
            //toolStripStatusLblAddSale.Text = res_man.GetString("Manager_Home_toolStripStatusLblAddSale", cul);
            toolStripStatusLabel2.Text = res_man.GetString("Manager_Home_toolStripStatusLabel2", cul);
            toolStripStatusLabel5.Text = res_man.GetString("Manager_Home_toolStripStatusLabel5", cul);
            toolStripStatusLabel4.Text = res_man.GetString("Manager_Home_toolStripStatusLabel4", cul);
            toolStripStatusLabel6.Text = res_man.GetString("Manager_Home_toolStripStatusLabel6", cul);
            saveAsDatabaseToolStripMenuItem.Text = res_man.GetString("Manager_Home_saveAsDatabaseToolStripMenuItem", cul);
            userProfileToolStripMenuItem.Text = res_man.GetString("Manager_Home_userProfileToolStripMenuItem", cul);
            exitToolStripMenuItem.Text = res_man.GetString("Manager_Home_exitToolStripMenuItem", cul);
            sellProductToolStripMenuItem.Text = res_man.GetString("Manager_Home_sellProductToolStripMenuItem", cul);
            //toolStripMenuItem19.Text = res_man.GetString("Manager_Home_toolStripMenuItem19", cul);
            purchaseProductToolStripMenuItem.Text = res_man.GetString("Manager_Home_purchaseProductToolStripMenuItem", cul);
            categoriesToolStripMenuItem.Text = res_man.GetString("Manager_Home_categoriesToolStripMenuItem", cul);
            addCustomerToolStripMenuItem.Text = res_man.GetString("Manager_Home_addCustomerToolStripMenuItem", cul);
            createBarcodeToolStripMenuItem.Text = res_man.GetString("Manager_Home_createBarcodeToolStripMenuItem", cul);
            kitchenDisplayToolStripMenuItem.Text = res_man.GetString("Manager_Home_kitchenDisplayToolStripMenuItem", cul);
            toolStripMenuItem3.Text = res_man.GetString("Manager_Home_toolStripMenuItem3", cul);
            toolStripMenuItem4.Text = res_man.GetString("Manager_Home_toolStripMenuItem4", cul);
            purchaseHistoryToolStripMenuItem.Text = res_man.GetString("Manager_Home_purchaseHistoryToolStripMenuItem", cul);
            customerReportToolStripMenuItem.Text = res_man.GetString("Manager_Home_customerReportToolStripMenuItem", cul);
            helpToolStripMenuItem1.Text = res_man.GetString("Manager_Home_helpToolStripMenuItem1", cul);
            aboutSoftToolStripMenuItem.Text = res_man.GetString("Manager_Home_aboutSoftToolStripMenuItem", cul);
            fileToolStripMenuItem.Text = res_man.GetString("Manager_Home_fileToolStripMenuItem", cul);
            transectionToolStripMenuItem.Text = res_man.GetString("Manager_Home_transectionToolStripMenuItem", cul);
            viewToolStripMenuItem.Text = res_man.GetString("Manager_Home_viewToolStripMenuItem", cul);
            helpToolStripMenuItem.Text = res_man.GetString("Manager_Home_helpToolStripMenuItem", cul);
            languageToolStripMenuItem.Text = res_man.GetString("Manager_Home_languageToolStripMenuItem", cul);
            englishToolStripMenuItem.Text = res_man.GetString("Manager_Home_englishToolStripMenuItem", cul);
            arabicToolStripMenuItem.Text = res_man.GetString("Manager_Home_arabicToolStripMenuItem", cul);


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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

        BackgroundWorker bw = new BackgroundWorker();

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PicSyncro.Visible = false;
            backSyncro.isRun = false;
            backSyncro.SyncType = null;
            //btnSync.Text = "Sync";
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int Day = Home.getsyncDate();
            int daysy = Day * -1;
            DateTime syncDate = DateTime.Now.AddDays(daysy);

            bool salesync = Home.TodayFullSync();

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
                        int syntyme = Home.getsyncTime();
                        int Secound = syntyme / 60;
                        int minutes = Secound / 1000;
                        backSyncro.Minute = minutes;

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

        private void timerSyncronize_Tick(object sender, EventArgs e)
        {
            bool ISrun = backSyncro.isRun;
            if (ISrun != true)
            {
                int syntyme = Home.getsyncTime();
                int Secound = syntyme / 60;
                int minutes = Secound / 1000;
                backSyncro.Minute = minutes;

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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (backSyncro.isRun == true)
            {
                if (Application.OpenForms["Syncscreen"] != null)
                {
                    Syncscreen go = (Syncscreen)Application.OpenForms["Syncscreen"];
                    go.Show();
                }
                else
                {
                    Syncscreen go = new Syncscreen();
                    go.Show();
                }
            }
            else
            {
                if (Application.OpenForms["Syncscreen"] != null)
                {
                    Application.OpenForms["Syncscreen"].Close();
                }
            }
        }

        public void openWindows()
        {
            this.windowToolStripMenuItem.DropDownItems.Clear();
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
                        this.windowToolStripMenuItem.DropDownItems.Add(MnuStripItem);
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
            if (this.windowToolStripMenuItem.DropDown.Visible == false)
            {
                openWindows();
            }

        }
    }
}
