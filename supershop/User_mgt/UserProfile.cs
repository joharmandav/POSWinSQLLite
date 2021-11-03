using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace supershop
{
    public partial class UserProfile : Form
    {
        public UserProfile(string UName)
        {
            InitializeComponent();
            lblUserName.Text = UName;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 
        

        ///// Load Method
        public void loadData()
        {
            string sql3 = "select * from usermgt where TenentID = " + Tenent.TenentID + " and Username = '" + lblUserName.Text + "'";            
            DataTable dt1 = DataAccess.GetDataTable(sql3);
            if (dt1.Rows.Count > 0)
            {
                txtuid.Text = dt1.Rows[0].ItemArray[0].ToString();
                txtUserFullName.Text = dt1.Rows[0].ItemArray[1].ToString();
                txtFatherName.Text = dt1.Rows[0].ItemArray[2].ToString();
                txtAddress.Text = dt1.Rows[0].ItemArray[3].ToString();
                txtEmailaddress.Text = dt1.Rows[0].ItemArray[4].ToString();
                txtContact.Text = dt1.Rows[0].ItemArray[5].ToString();
                dtDOB.Value = Convert.ToDateTime(dt1.Rows[0].ItemArray[6].ToString());
                txtUsername.Text = dt1.Rows[0].ItemArray[7].ToString();
                textUserPass.Text = dt1.Rows[0].ItemArray[8].ToString();
                rdbtnUserRole.Text = dt1.Rows[0].ItemArray[10].ToString();
                lblimagename.Text = dt1.Rows[0].ItemArray[11].ToString();
                lblBranch.Text = UserInfo.Shopid;
                // string aa = txtuid.Text + ".JPG";
                string path = Application.StartupPath + @"\IMAGE\" + dt1.Rows[0].ItemArray[11].ToString() + "";
                PicUserPhoto.ImageLocation = path;      
            } 
        }

        //Load event | user info 
        private void UserProfile_Load(object sender, EventArgs e)
        {
            loadData();
        }

        //Browse Picture Dialog
        private void btnChangePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = @"C:\";
            //openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "jpg";
           // openFileDialog1.Filter = "GIF files (*.gif)|*.gif| jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png| All files (*.*)|*.*";
             openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg";

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

           // openFileDialog1.ReadOnlyChecked = true;
           // openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox1.Text = openFileDialog1.FileName;
                PicUserPhoto.ImageLocation = openFileDialog1.FileName;
                lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            }
        }

        //Update user info
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUserFullName.Text == "")
            {
                MessageBox.Show("Please Add User full Name", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserFullName.Focus();
            }
            else if (txtFatherName.Text == "")
            {
                MessageBox.Show("Please fill fathers name", "Fill Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFatherName.Focus();
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
            else
            {
                try
                {
                    string imageName;
                    if (lblFileExtension.Text == "user.png")
                    {
                        imageName = lblimagename.Text; 
                    }
                    else
                    {
                        imageName = txtuid.Text + lblFileExtension.Text; 
                    }

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql = "UPDATE usermgt set  Name = '" + txtUserFullName.Text + "', Father_name = '" + txtFatherName.Text + "', " +
                        " Address = '" + txtAddress.Text + "', Email = '" + txtEmailaddress.Text + "', Contact = '" + txtContact.Text + "', " + 
                        " DOB = '" + dtDOB.Value.ToString("yyyy-MM-dd") + "' , Username= '" + txtUsername.Text + "', password = '" + textUserPass.Text + "' ,   " +
                        " imagename = '" + imageName + "', " +
                        " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " + 
                        " where (Username = '" + lblUserName.Text + "' )"; 
                    DataAccess.ExecuteSQL(sql);

                    string sqlwin = "UPDATE Win_usermgt set  Name = '" + txtUserFullName.Text + "', Father_name = '" + txtFatherName.Text + "', " +
                        " Address = '" + txtAddress.Text + "', Email = '" + txtEmailaddress.Text + "', Contact = '" + txtContact.Text + "', " +
                        " DOB = '" + dtDOB.Value.ToString("yyyy-MM-dd") + "' , Username= '" + txtUsername.Text + "', password = '" + textUserPass.Text + "' ,   " +
                        " imagename = '" + imageName + "', " +
                        " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                        " where (Username = '" + lblUserName.Text + "' )";
                    Datasyncpso.insert_Live_sync(sqlwin, "Win_usermgt", "UPDATE");
                    MessageBox.Show("Successfully Data Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string ActivityName = "update User";
                    string LogData = "update User with username = : " + lblUserName.Text + " to username = : " + txtUsername.Text.Trim() + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                    // cleartext();

                    /////////////////////////////////////////////Update image //////////////////////////////////////////////////////
                  //  string id = txtuid.Text;
                    string path = Application.StartupPath + @"\IMAGE\";
                    System.IO.File.Delete(path + @"\" + imageName );
                    if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\IMAGE\");
                    string filename = path + @"\" + openFileDialog1.SafeFileName;
                    PicUserPhoto.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);

                    loadData();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Sorry  !!!! \r\n You have to Check the Data" + exp.Message);
                }
            }
        }

        private void lnkWorkingHours_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserInfo.usernamWK = txtUsername.Text;
           // this.Hide();
            User_mgt.WorkRecords go = new User_mgt.WorkRecords();
           // go.MdiParent = this.ParentForm;
            go.ShowDialog();
        }

    }
}
