using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.ModifyRegistry;

namespace supershop
{
    public partial class SetPath : Form
    {
        public SetPath()
        {
            InitializeComponent();
        }

        ModifyRegistry myRegistry = new ModifyRegistry();

        public string Key = @"SOFTWARE\Encrypt\Encrypt";
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

                if(txtDatabase.Text!="")
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
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Key,true);
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
    }
}
