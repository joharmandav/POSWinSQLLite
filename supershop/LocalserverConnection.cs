using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.ModifyRegistry;

namespace supershop
{
    public partial class LocalserverConnection : Form
    {
        public LocalserverConnection()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                string constr;
                if (cbxIntegrated.Checked)
                {
                    constr = GetSqlServerConnectionString(txtSqlAddress.Text, "master");
                }
                else
                {
                    constr = GetSqlServerConnectionString(txtSqlAddress.Text, "master", txtUserDB.Text, txtPassDB.Text);
                }
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();

                    // Get the names of all DBs in the database server.
                    SqlCommand query = new SqlCommand(@"select distinct [name] from sysdatabases", conn);
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        cboDatabases.Items.Clear();
                        while (reader.Read())
                            cboDatabases.Items.Add((string)reader[0]);
                        if (cboDatabases.Items.Count > 0)
                            cboDatabases.SelectedIndex = 0;
                    } // using
                } // using

                cboDatabases.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    ex.Message,
                    "Failed To Connect",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } // catch
        }

        private static string GetSqlServerConnectionString(string address, string db)
        {
            string res = @"Data Source=" + address.Trim() +
                    ";Initial Catalog=" + db.Trim() + ";Integrated Security=SSPI;";
            return res;
        }
        private static string GetSqlServerConnectionString(string address, string db, string user, string pass)
        {
            string res = @"Data Source=" + address.Trim() +
                ";Initial Catalog=" + db.Trim() + ";User ID=" + user.Trim() + ";Password=" + pass.Trim();
            return res;
        }

        private void cbxIntegrated_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxIntegrated.Checked)
            {
                lblPassword.Visible = false;
                lblUser.Visible = false;
                txtPassDB.Visible = false;
                txtUserDB.Visible = false;
            }
            else
            {
                lblPassword.Visible = true;
                lblUser.Visible = true;
                txtPassDB.Visible = true;
                txtUserDB.Visible = true;
            }
        }

        ModifyRegistry myRegistry = new ModifyRegistry();
        public static string Key = @"SOFTWARE\Encrypt\Encrypt";

        private void button1_Click(object sender, EventArgs e)
        {
            string DataSource = txtSqlAddress.Text.Trim();
            string Database = cboDatabases.Text;
            string User = txtUserDB.Text;
            string Password = txtPassDB.Text;

            Properties.Settings.Default.DataSourceLocal = DataSource;

            Properties.Settings.Default.DatabaseLocal = Database;

            Properties.Settings.Default.UseridLocal = User;

            Properties.Settings.Default.PasswordLocal = Password;

            RegistryKey Readkey = Registry.CurrentUser.OpenSubKey(Key);

            string DataSourceenc = null;
            string Databaseenc = null;
            string Userenc = null;
            string Passwordenc = null;
            if (Readkey != null)
            {
                if (Readkey.GetValue("kascii11") != null)
                    DataSourceenc = EncryptionClass.Decrypt(Readkey.GetValue("kascii11").ToString());
                if (Readkey.GetValue("kascii12") != null)
                    Databaseenc = EncryptionClass.Decrypt(Readkey.GetValue("kascii12").ToString());
                if (Readkey.GetValue("kascii13") != null)
                    Userenc = EncryptionClass.Decrypt(Readkey.GetValue("kascii13").ToString());
                if (Readkey.GetValue("kascii14") != null)
                    Passwordenc = EncryptionClass.Decrypt(Readkey.GetValue("kascii14").ToString());
            }

            if (DataSourceenc == null && Databaseenc == null && Userenc == null && Passwordenc == null)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(Key);

                if (DataSource != "")
                {
                    DataSourceenc = EncryptionClass.Encrypt(DataSource);
                    key.SetValue("kascii11", DataSourceenc);
                }

                if (Database != "")
                {
                    Databaseenc = EncryptionClass.Encrypt(Database);
                    key.SetValue("kascii12", Databaseenc);
                }

                if (User != "")
                {
                    Userenc = EncryptionClass.Encrypt(User);
                    key.SetValue("kascii13", Userenc);
                }
                if (Password != "")
                {
                    Passwordenc = EncryptionClass.Encrypt(Password);
                    key.SetValue("kascii14", Passwordenc);
                }

            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Key, true);
                if (DataSource != "")
                {
                    DataSourceenc = EncryptionClass.Encrypt(DataSource);
                    key.SetValue("kascii11", DataSourceenc);
                }

                if (Database != "")
                {
                    Databaseenc = EncryptionClass.Encrypt(Database);
                    key.SetValue("kascii12", Databaseenc);
                }

                if (User != "")
                {
                    Userenc = EncryptionClass.Encrypt(User);
                    key.SetValue("kascii13", Userenc);
                }
                if (Password != "")
                {
                    Passwordenc = EncryptionClass.Encrypt(Password);
                    key.SetValue("kascii14", Passwordenc);
                }
            }

            Login.LocalServerConnection();
            Application.Restart();

        }

        private void LocalserverConnection_Load(object sender, EventArgs e)
        {
            cbxIntegrated.Checked = false;

            lblPassword.Visible = true;
            lblUser.Visible = true;
            txtPassDB.Visible = true;
            txtUserDB.Visible = true;

            txtSqlAddress.Text = Properties.Settings.Default.DataSourceLocal != "NeedToSet" ? Properties.Settings.Default.DataSourceLocal : "";

            cboDatabases.Text = Properties.Settings.Default.DatabaseLocal != "NeedToSet" ? Properties.Settings.Default.DatabaseLocal : "";

            txtUserDB.Text = Properties.Settings.Default.UseridLocal != "NeedToSet" ? Properties.Settings.Default.UseridLocal : "";

            txtPassDB.Text = Properties.Settings.Default.PasswordLocal != "NeedToSet" ? Properties.Settings.Default.PasswordLocal : "";
        }
    }
}
