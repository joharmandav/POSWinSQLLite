using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class SyncSetup : Form
    {
        public SyncSetup()
        {
            InitializeComponent();
        }

        private void SyncSetup_Load(object sender, EventArgs e)
        {
            int syntyme = Home.getsyncTime();
            int Secound = syntyme / 60;
            int minutes = Secound / 1000;

            numericUpDown1.Value = minutes;

            numericUpDownDays.Value = Home.getsyncDate();

            int Salesync = ISSaleSync();
            if (Salesync == 1)
            {
                checksaleSync.Checked = true;
            }
            else
            {
                checksaleSync.Checked = false;
            }

        }

        public static int ISSaleSync()
        {
            int Salesync = 0;
            string sqlterminallist = "select * from tbl_terminalLocation where Tenentid=" + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            DataAccess.ExecuteSQL(sqlterminallist);
            DataTable dtterminallist = DataAccess.GetDataTable(sqlterminallist);

            if (dtterminallist.Rows.Count > 0)
            {
                Salesync = Convert.ToInt32(dtterminallist.Rows[0]["Salesync"]);
            }

            return Salesync;
        }

        public static void install()
        {
            string AppPath = Application.StartupPath;
            Process p = new Process();
            p.StartInfo.FileName = AppPath + "\\Syncronization\\Syncronize.msi";
            p.Start();
            p.WaitForExit();
        }

        public static string ProductVirsion()
        {
            Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");
            WindowsInstaller.Installer installer = (WindowsInstaller.Installer)
            Activator.CreateInstance(type);
            string Path = Application.StartupPath + "\\Syncronization\\Syncronize.msi";
            WindowsInstaller.Database db = installer.OpenDatabase(Path, 0);
            WindowsInstaller.View dv = db.OpenView("SELECT `Value` FROM `Property` WHERE `Property`='ProductVersion'");
            WindowsInstaller.Record record = null;
            dv.Execute(record);
            record = dv.Fetch();
            string str = record.get_StringData(1).ToString();
            return str;
        }

        public static bool UninstallProgram(string programDisplayName)
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

        public static bool IsProgramInstalled(string programDisplayName)
        {

            Console.WriteLine(string.Format("Checking install status of: {0}", programDisplayName));
            foreach (var item in Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames())
            {

                object programName = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("DisplayName");

                Console.WriteLine(programName);

                if (string.Equals(programName, programDisplayName))
                {
                    Console.WriteLine("Install status: INSTALLED");
                    return true;
                }
            }
            Console.WriteLine("Install status: NOT INSTALLED");
            return false;
        }

        public static void remove_Task()
        {
            using (TaskService ts = new TaskService())
            {
                try
                {
                    // Remove the task we just created
                    ts.RootFolder.DeleteTask("Syncroniz");
                }
                catch
                {

                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = IsProgramInstalled("Syncronize");

            if (flag == true)
            {

            }
            else
            {
                return;
            }

            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Syncronization";

                // Create a trigger that will fire the task at this time every other day
                //td.Triggers.Add(new DailyTrigger { DaysInterval = 2 });

                int interval = Convert.ToInt32(numericUpDown1.Value);
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

        private void button2_Click(object sender, EventArgs e)
        {
            remove_Task();            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int Salesync = 0;
            if(checksaleSync.Checked == true)
            {
                Salesync = 1;
            }
            else
            {
                Salesync = 0;
            }

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = "update tbl_terminallocation set syncAfter = " + Convert.ToInt32(numericUpDown1.Value) + ",dayofSync = " + Convert.ToInt32(numericUpDownDays.Value) + " , Salesync = " + Salesync + ", " +
            " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
            " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            DataAccess.ExecuteSQL(sql);

            string sqlwin = "update Win_tbl_terminallocation set syncAfter = " + Convert.ToInt32(numericUpDown1.Value) + ",dayofSync = " + Convert.ToInt32(numericUpDownDays.Value) + " ,  Salesync = " + Salesync + ", " +
            " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
            " where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            Datasyncpso.insert_Live_sync(sqlwin, "Win_tbl_terminallocation", "UPDATE");

            string ActivityName = "Syncronization";
            string LogData = "Syncronization Time Change  with Shopid = " + UserInfo.Shopid + " ";
            Login.InsertUserLog(ActivityName, LogData);

            this.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
