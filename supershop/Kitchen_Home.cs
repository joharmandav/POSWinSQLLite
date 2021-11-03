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
    public partial class Kitchen_Home : Form
    {
        public Kitchen_Home(string a)
        {
            InitializeComponent();
            toolStripMenuItemUser.Text = a;
            toolStripStatusLabel2.Text = a;
            userProfileToolStripMenuItem.Text = " User Profile ( " + a + ")";
            toolStripMenuItem1.Text = DataAccess.GetCompany();
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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Sign out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login go = new Login();
                go.Show();
                this.Close();
            }
        }

        private void Kitchen_Home_Load(object sender, EventArgs e)
        {
            if (Application.OpenForms["PendingKitchen"] != null)
            {
                Application.OpenForms["PendingKitchen"].Close();
            }
            this.Refresh();
            Report.PendingKitchen go = new Report.PendingKitchen();
            go.MdiParent = Application.OpenForms["Kitchen_Home"];
            go.Show();

            int Syntime = Home.getsyncTime();

            timerSyncronize.Interval = Syntime;

        }

        private void aboutSoftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_soft go = new About_soft();
            go.MdiParent = this;
            go.Show();
        }

        private void toolStripStatusLabel6_Click(object sender, EventArgs e)
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

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlLogIn = " insert into tbl_workrecords (TenentID, Username, datatype, logdate, logtime, logdatetime,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + ",'" + UserInfo.UserName + "' , 'OUT' , '" + logdate + "' , " +
                                  " '" + logtime + "' , '" + logdatetime + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
            int flag1 = DataAccess.ExecuteSQL(sqlLogIn);

            string sqlLogInWin = " insert into Win_tbl_workrecords (TenentID, Username, datatype, logdate, logtime, logdatetime,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + ",'" + UserInfo.UserName + "' , 'OUT' , '" + logdate + "' , " +
                                  " '" + logtime + "' , '" + logdatetime + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
            Datasyncpso.insert_Live_sync(sqlLogInWin, "Win_tbl_workrecords", "INSERT");

        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            toolStripMenuItem2.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void toolStripMenuItem3Mini_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   //Minimized 
        }

        private void xToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
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

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void statusStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void saveAsDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime today = DateTime.Today;
                string fileName = "psodb.db";
                string fileName2 = "posBackup_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss" + ".db");
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

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
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

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpPage go = new HelpPage();
            go.MdiParent = this;
            go.Show();
        }

        private void toolStripMenuItemUser_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["UserProfile"] != null)
            {
                Application.OpenForms["UserProfile"].BringToFront();
                Application.OpenForms["UserProfile"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                UserProfile go = new UserProfile(toolStripMenuItemUser.Text);
                go.MdiParent = this;
                go.Show();
            }
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
            aboutSoftToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_aboutSoftToolStripMenuItem", cul);
            arabicToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_arabicToolStripMenuItem", cul);
            englishToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_englishToolStripMenuItem", cul);
            exitToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_exitToolStripMenuItem", cul);
            fileToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_fileToolStripMenuItem", cul);
            helpToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_helpToolStripMenuItem", cul);
            helpToolStripMenuItem1.Text = res_man.GetString("SalesMan_Home_helpToolStripMenuItem1", cul);
            //kitchenDisplayToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_kitchenDisplayToolStripMenuItem", cul);
            languageToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_languageToolStripMenuItem", cul);
            saveAsDatabaseToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_saveAsDatabaseToolStripMenuItem", cul);
            toolStripStatusLabel5.Text = res_man.GetString("Kitchen_Home_toolStripStatusLabel5", cul);
            transectionToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_transectionToolStripMenuItem", cul);
            userProfileToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_userProfileToolStripMenuItem", cul);
            transectionToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_transectionToolStripMenuItem", cul);
            helpToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_helpToolStripMenuItem", cul);
            languageToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_languageToolStripMenuItem", cul);
            englishToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_englishToolStripMenuItem", cul);
            arabicToolStripMenuItem.Text = res_man.GetString("SalesMan_Home_arabicToolStripMenuItem", cul);
            toolKitchenDisplay.Text = res_man.GetString("Kitchen_Home_toolKitchenDisplay", cul);

        }

        private void toolKitchenDisplay_Click(object sender, EventArgs e)
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Report.OrderComplateList go = new Report.OrderComplateList();
            go.MdiParent = this;
            go.Show();
        }

        private void complateOrderLIstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.OrderComplateList go = new Report.OrderComplateList();
            go.MdiParent = this;
            go.Show();
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

        private void timer1_Tick(object sender, EventArgs e)
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
