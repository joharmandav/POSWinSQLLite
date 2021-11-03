using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace supershop.User_mgt
{
    public partial class Manage_user : Form
    {
        public Manage_user()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Show Use List with image
        public void list_images()
        {
            string img_directory = Application.StartupPath + @"\IMAGE\";
            //dir_image.Text = img_directory;
            string[] files = Directory.GetFiles(img_directory, "*.jpg *.png"); // "*.png"

            try
            {
                string sql = "select * from usermgt Where TenentID = " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sql);
                DataTable dt = DataAccess.GetDataTable(sql);

                //int count = dataReader.FieldCount;
                //image_count.Text = count.ToString();
                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    //Button click event
                    Button b = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = dataReader["id"];
                    b.Click += new EventHandler(b_Click);
                    b.Name = dataReader["Name"].ToString() + "\n Contact: " + dataReader["Contact"].ToString() + "\n Position: " + dataReader["position"].ToString();


                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(150, 120);

                    string PAth = img_directory + dataReader["imagename"];

                    if (File.Exists(PAth))
                    {
                        il.Images.Add(Image.FromFile(PAth));
                    }
                    else
                    {
                        il.Images.Add(Image.FromFile(img_directory + "user.png"));
                    }

                    b.Image = il.Images[0];
                    b.Margin = new Padding(4, 4, 4, 4);

                    b.Size = new Size(330, 130);
                    b.Text.PadRight(4);

                    // ilabel.BackgroundImage = il.Images[currentImage];
                    // ilabel.BackgroundImageLayout = ImageLayout.Stretch;

                    //// Tile View
                    //  b.Text = "ID: ";
                    b.Text += "\n UID: " + dataReader["Username"];
                    b.Text += "\n Name: " + dataReader["Name"].ToString();
                    b.Text += "\n Contact: " + dataReader["Contact"].ToString();
                    b.Text += "\n Position: " + dataReader["position"];
                    b.Text += "\n " + dataReader["Email"];
                    b.Text += "\n " + dataReader["Shopid"];



                    b.Font = new Font("Times New Roman", 10, FontStyle.Regular, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    flowLayoutPanelUserList.Controls.Add(b);
                    currentImage++;
                }
            }
            catch //(Exception)
            {

                // throw;
            }
        }


        //Search User with Image
        private void txtsearchUser_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanelUserList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\IMAGE\";
            //dir_image.Text = img_directory;
            string[] files = Directory.GetFiles(img_directory, "*.jpg *.png"); // "*.png"

            try
            {
                string sql = "select * from usermgt where TenentID = " + Tenent.TenentID + " and Name like '" + txtsearchUser.Text + "%' OR Username like '" + txtsearchUser.Text + "%' " +
                            " OR Contact like '" + txtsearchUser.Text + "%' OR position like '" + txtsearchUser.Text + "%' ";
                DataAccess.ExecuteSQL(sql);
                DataTable dt = DataAccess.GetDataTable(sql);

                //int count = dataReader.FieldCount;
                //image_count.Text = count.ToString();
                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button b = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = dataReader["id"];
                    b.Click += new EventHandler(b_Click);
                    b.Name = dataReader["Name"].ToString() + "\n Contact: " + dataReader["Contact"].ToString() + "\n Position: " + dataReader["position"].ToString();


                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(150, 120);
                    il.Images.Add(Image.FromFile(img_directory + dataReader["imagename"]));

                    b.Image = il.Images[0];
                    b.Margin = new Padding(4, 4, 4, 4);

                    b.Size = new Size(330, 130);
                    b.Text.PadRight(4);

                    // ilabel.BackgroundImage = il.Images[currentImage];
                    // ilabel.BackgroundImageLayout = ImageLayout.Stretch;

                    //  b.Text = "ID: ";
                    b.Text += "\n UID: " + dataReader["Username"];
                    b.Text += "\n Name: " + dataReader["Name"].ToString();
                    b.Text += "\n Contact: " + dataReader["Contact"].ToString();
                    b.Text += "\n Position: " + dataReader["position"];
                    b.Text += "\n " + dataReader["Email"];
                    b.Text += "\n " + dataReader["Shopid"];


                    b.Font = new Font("Trebuchet MS", 9, FontStyle.Regular, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    flowLayoutPanelUserList.Controls.Add(b);
                    currentImage++;


                }
            }
            catch //(Exception)
            {

                // throw;
            }
        }

        //Click add to cart
        protected void b_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();

            this.Hide();
            User_mgt.User_regi go = new User_mgt.User_regi();
            go.Uid = s;
            go.MdiParent = this.ParentForm;
            go.Show();
        }


        private void Manage_user_Load(object sender, EventArgs e)
        {
            try
            {
                list_images();
            }
            catch
            {
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            // //   DataGridViewRow row = dtgrdviewUserList.Rows[e.RowIndex];
            //  //  lblUserName.Text = row.Cells[1].Value.ToString();


            //    string sql3 = "select * from usermgt where Username = '" + lblUserName.Text + "'";
            //    DataAccess.ExecuteSQL(sql3);
            //    DataTable dt1 = DataAccess.GetDataTable(sql3);

            //    txtuid.Text = dt1.Rows[0].ItemArray[0].ToString();
            //    txtUserName.Text = dt1.Rows[0].ItemArray[1].ToString();
            //    txtUserFN.Text = dt1.Rows[0].ItemArray[2].ToString();
            //    txtAddr.Text = dt1.Rows[0].ItemArray[3].ToString();
            //    txtEmailAddress.Text = dt1.Rows[0].ItemArray[4].ToString();
            //    txtcontact.Text = dt1.Rows[0].ItemArray[5].ToString();
            //    txtDOB.Text = dt1.Rows[0].ItemArray[6].ToString();
            //    txtUserID.Text = dt1.Rows[0].ItemArray[7].ToString();
            //    txtPassword.Text = dt1.Rows[0].ItemArray[8].ToString();

            //    //string stid = dt.Rows[0].ItemArray[0].ToString();
            //    string aa = txtuid.Text  + ".JPG";
            //    string path = Application.StartupPath + @"\IMAGE\" + aa + "";
            //    PicUserPhoto.ImageLocation = path;

            //    if (dt1.Rows[0].ItemArray[10].ToString() == "Admin")
            //    {
            //        rdbtnAdmin.Checked = true;
            //    }
            //    else if (dt1.Rows[0].ItemArray[10].ToString() == "Manager")
            //    {
            //        rdbtnManager.Checked = true;
            //    }
            //    else if (dt1.Rows[0].ItemArray[9].ToString() == "3")
            //    {
            //        rdbtnSalesMan.Checked = true;
            //    }
            //    else  
            //    {
            //        rdbtnInactive.Checked = true;
            //    }
            //}
            //catch 
            //{
            //    //MessageBox.Show("Sorry" + exp.Message);
            //}
        }


        // Link to   user registration
        private void btnCreateLink_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_mgt.User_regi go = new User_mgt.User_regi();
            go.MdiParent = this.ParentForm;
            go.Show();

        }

        private void Manage_user_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void lnkWorkingHours_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_mgt.WorkSheet go = new User_mgt.WorkSheet();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

    }
}
