using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace supershop.Items
{
    public partial class Add_Category : Form
    {

        InputLanguage arabic;
        InputLanguage english;
        InputLanguage French;
        public Add_Category()
        {
            InitializeComponent();

            arabic = InputLanguage.CurrentInputLanguage;
            english = InputLanguage.CurrentInputLanguage;
            French = InputLanguage.CurrentInputLanguage;
            int count = InputLanguage.InstalledInputLanguages.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("Arabic"))
                {
                    arabic = InputLanguage.InstalledInputLanguages[i];
                }
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("US"))
                {
                    english = InputLanguage.InstalledInputLanguages[i];
                }
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("French"))
                {
                    French = InputLanguage.InstalledInputLanguages[i];
                }

            }

            if (txtcolor.Text == "Control")
            {
                Color C = SystemColors.Control;
                txtcolor.Text = C.Name.ToString();
            }
        }

        private void txtCategoryArabic_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = arabic;
        }

        private void txtCategoryArabic_LostFocus(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public string categoryID
        {
            set { lblID.Text = value; }
            get { return lblID.Text; }
        }
        public string categoryName
        {
            set { txtCategoryName.Text = value; btnSave.Text = "Update"; }
            get { return txtCategoryName.Text; }
        }

        public string categoryNameArabic
        {
            set { txtCategoryArabic.Text = value; }
            get { return txtCategoryArabic.Text; }
        }

        public string imagename
        {
            set { lblImage.Text = value; }
            get { return lblImage.Text; }
        }

        public string ColorName
        {
            set { txtcolor.Text = value; }
            get { return txtcolor.Text; }
        }


        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Categories go = new Categories();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            parameter.peopleid = "SUP";
            Customer.CustomerDetails go = new Customer.CustomerDetails();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtCategoryName.Text = Add_Item.voidQueryValidate(txtCategoryName.Text);
                txtCategoryArabic.Text = Add_Item.voidQueryValidate(txtCategoryArabic.Text);
                //if (Login.InternetConnection() == false)
                //{
                //    lblMsg.Text = "Internet Connection Avalable. try again later";
                //    return;
                //}

                //bool Falg = Login.CheckDBConnection();
                //if (Falg == false)
                //{
                //    lblMsg.Text = "online Server Connection Fail. try again later";
                //    return;
                //}

                if (txtCategoryName.Text == "")
                {
                    MessageBox.Show("Please Fill  Category Name");
                    txtCategoryName.Focus();
                }
                else
                {

                    string Cat_Name = txtCategoryName.Text;
                    Cat_Name = Cat_Name.Trim();

                    string COLOR_NAME = "";

                    if (txtcolor.Text == "Control")
                    {
                       // Color C = SystemColors.Control;
                        COLOR_NAME = "FFFFFF80";
                    }
                    else
                    {
                        COLOR_NAME = txtcolor.Text.ToString().Trim();
                    }

                    if (lblID.Text == "-")
                    {
                        int CATID = DataAccess.getCAT_MSTMYid(Tenent.TenentID);

                        string imageName;
                        if (lblFileExtension.Text == "item.png") //if not select image
                        {
                            imageName = lblImage.Text;
                        }
                        else  // select image
                        {
                            imageName = CATID + Cat_Name + lblFileExtension.Text;
                        }

                        //string sqlitemcode = "select * from CAT_MST where tenentid=" + Tenent.TenentID + " and Cat_Name1='" + Cat_Name + "'";
                        //DataTable dtitemcode = DataLive.GetLiveDataTable(sqlitemcode);
                        //if (dtitemcode.Rows.Count < 1)
                        //{
                        string CatNameU = Cat_Name.ToUpper();
                        string sqlitemcode = "select * from CAT_MST where tenentid=" + Tenent.TenentID + " and upper(Cat_Name1)='" + CatNameU + "'";
                        DataTable dtitemcode = DataAccess.GetDataTable(sqlitemcode);
                        if (dtitemcode.Rows.Count < 1)
                        {
                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); //2018-02-05 12:07:36.390  string.Format("0:yyyy-MM-dd HH:mm:ss.fff", DateTime.Now)

                            //string sqlCmdWin = " insert into CAT_MST (TenentID,CATID,DefaultPic,PARENT_CATID, SHORT_NAME,CAT_NAME1,CAT_NAME2,CAT_NAME3,COLOR_NAME,CAT_TYPE,Active,Uploadby ,UploadDate ,SynID)  values (" + Tenent.TenentID + "," + CATID + ",'" + imageName + "' , 0 ,'" + Cat_Name + "','" + Cat_Name + "',N'" + txtCategoryArabic.Text + "','" + Cat_Name + "' ,'" + COLOR_NAME + "','WEBSALE','1', '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                            //int InsertFlag = DataLive.ExecuteLiveSQL(sqlCmdWin);

                            //if(InsertFlag==1)
                            //{
                                string sqlCmd = " insert into CAT_MST (TenentID,CATID,DefaultPic,PARENT_CATID, SHORT_NAME,CAT_NAME1,CAT_NAME2,CAT_NAME3,COLOR_NAME,CAT_TYPE,Active,Uploadby ,UploadDate ,SynID)  values (" + Tenent.TenentID + "," + CATID + ",'" + imageName + "' , 0 ,'" + Cat_Name + "','" + Cat_Name + "','" + txtCategoryArabic.Text + "','" + Cat_Name + "' ,'" + COLOR_NAME + "','WEBSALE','1','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                                int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                                string sqlCmdWin = " insert into CAT_MST (TenentID,CATID,DefaultPic,PARENT_CATID, SHORT_NAME,CAT_NAME1,CAT_NAME2,CAT_NAME3,COLOR_NAME,CAT_TYPE,Active,Uploadby ,UploadDate ,SynID)  values (" + Tenent.TenentID + "," + CATID + ",'" + imageName + "' , 0 ,N'" + Cat_Name + "',N'" + Cat_Name + "',N'" + txtCategoryArabic.Text + "',N'" + Cat_Name + "' ,'" + COLOR_NAME + "','WEBSALE','1','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                                Datasyncpso.insert_Live_sync(sqlCmdWin, "CAT_MST", "INSERT");

                                string ActivityName = "Add Catagory";
                                string LogData = "Add Catagory With CatID = " + CATID + " and Name  = " + Cat_Name + " ";
                                Login.InsertUserLog(ActivityName, LogData);

                                if (txtImage.Text != "")
                                {
                                    picItemimage.InitialImage.Dispose();

                                    string path = Application.StartupPath + @"\ITEMIMAGE\";

                                    System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);
                                    if (di.Exists)
                                    {
                                        path = UserInfo.Img_path;
                                    }
                                    System.IO.File.Delete(path + @"\" + imageName);
                                    if (!System.IO.Directory.Exists(path))
                                        System.IO.Directory.CreateDirectory(path);
                                    string filename = path + @"\" + openFileDialog1.SafeFileName;
                                    picItemimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                                    System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                                }

                                txtCategoryName.Text = "";
                                txtCategoryArabic.Text = "";
                                lblMsg.Visible = true;
                                lblMsg.Text = "Successfully saved";

                                Categories mkc = new Categories();
                                mkc.MdiParent = this.ParentForm;
                                mkc.Show();
                                this.Close();
                            //}                           
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = Cat_Name + " Already Exist";
                        }
                    }
                    else  //Update 
                    {

                        string imageName;
                        if (lblFileExtension.Text == "item.png") //if not select image
                        {
                            imageName = lblImage.Text;
                        }
                        else  // select image
                        {
                            imageName = lblID.Text + Cat_Name + lblFileExtension.Text;
                        }

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        //string sqlUpdateCmdWin = " update CAT_MST set SHORT_NAME='" + Cat_Name + "', CAT_NAME1 = '" + Cat_Name + "', CAT_NAME2 = N'" + txtCategoryArabic.Text + "', CAT_NAME3 = '" + Cat_Name + "',DefaultPic='" + imageName + "',COLOR_NAME='" + COLOR_NAME + "', CAT_TYPE = 'WEBSALE' , Active = '1', " +
                        //                     " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                        //                     " where CATID = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        //int UpdateFlag = DataLive.ExecuteLiveSQL(sqlUpdateCmdWin);

                        //if(UpdateFlag==1)
                        //{
                            string sqlUpdateCmd = " update CAT_MST set SHORT_NAME='" + Cat_Name + "', CAT_NAME1 = '" + Cat_Name + "', CAT_NAME2 = '" + txtCategoryArabic.Text + "', CAT_NAME3 = '" + Cat_Name + "',DefaultPic='" + imageName + "',COLOR_NAME='" + COLOR_NAME + "', CAT_TYPE = 'WEBSALE' , Active = '1', " +
                                              " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                              " where CATID = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";
                            DataAccess.ExecuteSQL(sqlUpdateCmd);

                            string sqlUpdateCmdwin = " update CAT_MST set SHORT_NAME=N'" + Cat_Name + "', CAT_NAME1 = N'" + Cat_Name + "', CAT_NAME2 = N'" + txtCategoryArabic.Text + "', CAT_NAME3 = N'" + Cat_Name + "',DefaultPic='" + imageName + "',COLOR_NAME='" + COLOR_NAME + "', CAT_TYPE = 'WEBSALE' , Active = '1', " +
                                                  " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                                  " where CATID = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";

                            Datasyncpso.insert_Live_sync(sqlUpdateCmdwin, "CAT_MST", "UPDATE");

                            string ActivityName = "Update Catagory";
                            string LogData = "Update Catagory With CatID = " + lblID.Text + " and Name  = " + Cat_Name + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            if (txtImage.Text != "")
                            {
                                picItemimage.InitialImage.Dispose();

                                string path = Application.StartupPath + @"\ITEMIMAGE\";

                                System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);
                                if (di.Exists)
                                {
                                    path = UserInfo.Img_path;
                                }

                                System.IO.File.Delete(path + @"\" + imageName);
                                if (!System.IO.Directory.Exists(path))
                                    System.IO.Directory.CreateDirectory(path);
                                string filename = path + @"\" + openFileDialog1.SafeFileName;
                                picItemimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                                System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                            }

                            // lblMsg.Visible = true;
                            // lblMsg.Text = "Successfully Updated";

                            Categories mkc = new Categories();
                            mkc.MdiParent = this.ParentForm;
                            mkc.Show();
                            this.Close();
                        //}
                    }
                }


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();

            FileDialog.InitialDirectory = @"C:\";
            FileDialog.Title = "Browse IMAGE Files";

            FileDialog.CheckFileExists = true;
            FileDialog.CheckPathExists = true;

            FileDialog.DefaultExt = "png";
            FileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            FileDialog.FilterIndex = 2;
            FileDialog.RestoreDirectory = true;

            FileDialog.ReadOnlyChecked = true;
            FileDialog.ShowReadOnly = true;
            DialogResult result = FileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                picItemimage.Image = new Bitmap(FileDialog.FileName);
                txtImage.Text = FileDialog.FileName;
                lblFileExtension.Text = Path.GetExtension(txtImage.Text);
                lblImage.Text = Path.GetFileName(txtImage.Text);
            }
        }

        private void txtCategoryName_Leave(object sender, EventArgs e)
        {
            bool Internat = Login.InternetConnection();
            if (Internat == true)
            {
                txtCategoryArabic.Text = DataAccess.Translate(txtCategoryName.Text, "ar");
            }
            else
            {
                txtCategoryArabic.Text = txtCategoryName.Text;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Categories mkc = new Categories();
            mkc.MdiParent = this.ParentForm;
            mkc.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color Colour = colorDialog1.Color;
                txtcolor.BackColor = Colour;
                string cname = ToHex(Colour);
                txtcolor.Text = "    " + cname + "    ";
                txtcolor.Padding = new Padding(3, 3, 3, 3);
            }
        }
        public string ToHex(Color color)
        {
            return String.Format("{0}{1}{2}{3}"
                , color.A.ToString("X").Length == 1 ? String.Format("0{0}", color.A.ToString("X")) : color.A.ToString("X")
                , color.R.ToString("X").Length == 1 ? String.Format("0{0}", color.R.ToString("X")) : color.R.ToString("X")
                , color.G.ToString("X").Length == 1 ? String.Format("0{0}", color.G.ToString("X")) : color.G.ToString("X")
                , color.B.ToString("X").Length == 1 ? String.Format("0{0}", color.B.ToString("X")) : color.B.ToString("X"));
        }

        private void txtcolor_TextChanged(object sender, EventArgs e)
        {
            string coName = txtcolor.Text.Trim();
            coName = coName.Substring(2);
            coName = "#" + coName;

            Color c = System.Drawing.ColorTranslator.FromHtml(coName);
            byte A = c.A;
            byte R = c.R;
            byte G = c.G;
            byte B = c.B;

            txtcolor.BackColor = Color.FromArgb(A, R, G, B);
        }

    }
}
