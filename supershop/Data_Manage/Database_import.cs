using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace supershop
{
    public partial class Database_import : Form
    {
        public Database_import()
        {
            InitializeComponent();
        }
        //static POSWinAppEntities DB = new POSWinAppEntities();

        //static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ConnectionString);
        //static SqlCommand command = new SqlCommand();

        static SqlConnection con = new SqlConnection(Login.onlineConnection());
        static SqlCommand command = new SqlCommand();

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Title = "Browse Text Files";

            //openFileDialog1.CheckFileExists = true;
            //openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "db";
            openFileDialog1.Filter = "DB files (*.DB)|*.DB| db files (*.db)|*.db";
            //openFileDialog1.Filter = "All files (*.*)|*.* | jpg files (*.jpg)|*.jpg";

            //openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;

            //openFileDialog1.ReadOnlyChecked = true;
            //openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox1.Text = openFileDialog1.FileName;
                txtfilepath.Text = openFileDialog1.FileName;
            }
        }

        private void btnimport_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtfilepath.Text == string.Empty)
                {
                    MessageBox.Show("Please Select Database file first", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtfilepath.Focus();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want Restore Databackup \n After Press Yes you loss your previous Database ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string Newfile = "psodb.db";
                        string targetPath = Application.StartupPath;// +@"\ExpenseAttachment\";

                        if (!System.IO.File.Exists(targetPath + @"\" + Newfile)) //if not File Exists
                        {
                            System.IO.File.Copy(txtfilepath.Text, targetPath + @"\" + Newfile);
                        }
                        else
                        {
                            // Delete a file by using File class static method...                    
                            System.IO.File.Delete(targetPath + @"\" + Newfile);
                            System.IO.File.Copy(txtfilepath.Text, targetPath + @"\" + Newfile);
                        }

                        MessageBox.Show("Database has been succefully Resotred", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
            catch
            {
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want rebuild/Reset Your System \n After Press Yes you loss your previous Database ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // DateTime today = DateTime.Today;
                    string fileName = "pos2db.db";
                    //string fileName2 = "posBackup_" + DateTime.Now.ToString("hh-mm-ss");
                    string sourcePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // @"C:\Users\Public\TestFolder\SubDir";
                    string targetPath = Application.StartupPath; //Application.StartupPath + @"\FinalImage\";
                    //  string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); 

                    // Use Path class to manipulate file and directory paths. 
                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);

                    // To copy a folder's contents to a new location: 
                    // Create a new target folder, if necessary. 
                    if (!System.IO.Directory.Exists(targetPath)) //Delete
                    {
                        // Delete a file by using File class static method...                    
                        System.IO.File.Delete(targetPath + @"\" + fileName);
                    }
                    System.IO.File.Delete(targetPath + @"\" + fileName);
                    MessageBox.Show("Database Stored");

                    //if (!System.IO.Directory.Exists(sourcePath))
                    //{

                    //    // System.IO.Directory.CreateDirectory(targetPath);
                    //    // To move a file or folder to a new location:
                    //    System.IO.File.Move(sourceFile, destFile);
                    //}

                    //System.IO.File.Copy(sourceFile, destFile, true);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnsync_Click(object sender, EventArgs e)
        {
            //string DEfapath = Application.StartupPath + @"\insert.sql";

            bool internet = Login.InternetConnection();
            if (internet == true)
            {
                lblMSg.Text = "plase Wait Data will be Sysncronize First";
                lblMSg.Refresh();
                suncroup();
            }
            else
            {
                MessageBox.Show("Check Internet Connection");
                return;
            }

            //string DEfapath = Application.StartupPath + @"\updateQuery.sql";            

            MessageBox.Show("Syncronization complate");

        }

        public static void suncroup()
        {
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
                        bool falg = runsql_Live(Dicstring);
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
                        bool falg = runsql_Live(Dicstring);
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

        public static void runsql(string FilePath)
        {
            FileInfo file = new FileInfo(FilePath);
            string script = file.OpenText().ReadToEnd();
            DataAccess.ExecuteSQL(script);
            MessageBox.Show("Import complate");
        }

        public static bool runsql_Live(string Query)
        {
            try
            {
                if (Query != "")
                {
                    command = new SqlCommand(Query, con);
                    con.Open();
                    command.ExecuteReader();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Title = "Browse Sql Files";

            openFileDialog1.DefaultExt = "sql";
            openFileDialog1.Filter = "SQL files (*.sql)|*.sql| db files (*.sql)|*.sql";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox1.Text = openFileDialog1.FileName;
                string Path = openFileDialog1.FileName;

                runsql(Path);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


    }
}
