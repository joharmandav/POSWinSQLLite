using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void lnkAddcategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //bool Internat = Login.InternetConnection();
            //if (Internat == false)
            //{
            //    MessageBox.Show("Please Check Your internet Connection");
            //    return;
            //}
            //else
            //{
            Items.Add_Category go = new Items.Add_Category();
            go.MdiParent = this.ParentForm;
            go.Show();
            this.Close();
            //}
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            parameter.peopleid = "SUP";
            Customer.CustomerDetails go = new Customer.CustomerDetails();
            go.MdiParent = this.ParentForm;
            go.Show();
            this.Close();
        }

        public void categorybind()
        {
            string sql = " select CATID, CAT_NAME1 as 'Category in English' , CAT_NAME2 as 'Category in Arabic' , DisplaySort as 'Diasplay Sort NO', AlwaysShow as 'Always Show(Y/N)' from CAT_MST where TenentID = " + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql);
            datagridcategories.DataSource = dt1;
            datagridcategories.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            try
            {

                categorybind();

                DataGridViewButtonColumn save = new DataGridViewButtonColumn();
                datagridcategories.Columns.Add(save);
                save.HeaderText = "save";
                save.Text = "save";
                save.Name = "save";
                save.ToolTipText = "save this category";
                save.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                datagridcategories.Columns.Add(Edit);
                Edit.HeaderText = "Edit";
                Edit.Text = "Edit";
                Edit.Name = "Edit";
                Edit.ToolTipText = "Edit this category";
                Edit.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                datagridcategories.Columns.Add(del);
                del.HeaderText = "Del";
                del.Text = "X";
                del.Name = "del";
                del.ToolTipText = "Delete this category";
                del.UseColumnTextForButtonValue = true;

                DataGridViewColumn ColID = datagridcategories.Columns[0];
                ColID.Width = 31;
                DataGridViewColumn ColName = datagridcategories.Columns[1];
                ColName.Width = 240;
                DataGridViewColumn ColNamearabic = datagridcategories.Columns[2];
                ColNamearabic.Width = 240;
            }
            catch
            {
            }
        }

        private void datagridcategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Delete category  
                if (e.ColumnIndex == datagridcategories.Columns["del"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in datagridcategories.SelectedRows)
                    {
                        int CATID = Convert.ToInt32(rowdel.Cells["CATID"].Value);
                        string category = rowdel.Cells["Category in English"].Value.ToString();
                        string sql = "select * from  purchase where TenentID = " + Tenent.TenentID + " and Category = '" + CATID + "' ";
                        DataTable dt = DataAccess.GetDataTable(sql);

                        if (dt.Rows.Count > 0)
                        {
                            int Count = dt.Rows.Count;
                            MessageBox.Show(" '" + category + "' Used in  " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (result == DialogResult.Yes)
                            {
                                //bool Internat = Login.InternetConnection();
                                //if (Internat == true)
                                //{
                                    int catid = Convert.ToInt32(rowdel.Cells["CATID"].Value);

                                    //string sqlLive = "delete from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID = '" + CATID + "' ";
                                    //int DeleteFlag = DataLive.ExecuteLiveSQL(sqlLive);
                                    //if (DeleteFlag == 1)
                                    //{
                                    string sqldel = " delete from CAT_MST  where TenentID = " + Tenent.TenentID + " and CATID = '" + CATID + "' ";
                                    DataAccess.ExecuteSQL(sqldel);

                                    string sqlLive = "delete from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID = '" + CATID + "' ";
                                    Datasyncpso.insert_Live_sync(sqlLive, "CAT_MST", "DELETE");

                                    string ActivityName = "delete Catagory";
                                    string LogData = "delete Catagory With CatID = " + catid + " and Catagory Name = " + category + " ";
                                    Login.InsertUserLog(ActivityName, LogData);

                                    categorybind();
                                    //}
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Please Check Your internet Connection");
                                //    return;
                                //}
                            }
                        }
                    }
                }

                // Delete items From Gridview
                if (e.ColumnIndex == datagridcategories.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in datagridcategories.SelectedRows)
                    {
                        //bool Internat = Login.InternetConnection();
                        //if (Internat == true)
                        //{
                        string sql12 = " select * from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID='" + row.Cells["CATID"].Value.ToString() + "'  ";
                        DataTable dt1 = DataAccess.GetDataTable(sql12);
                        if (dt1.Rows.Count > 0)
                        {

                            this.Hide();
                            Items.Add_Category mkc = new Items.Add_Category();
                            mkc.categoryID = row.Cells["CATID"].Value.ToString();
                            mkc.categoryName = row.Cells["Category in English"].Value.ToString();
                            mkc.categoryNameArabic = row.Cells["Category in Arabic"].Value.ToString();
                            mkc.imagename = dt1.Rows[0]["DefaultPic"].ToString();
                            mkc.ColorName = dt1.Rows[0]["COLOR_NAME"].ToString();
                            mkc.MdiParent = this.ParentForm;
                            mkc.Show();
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Please Check Your internet Connection");
                        //    return;
                        //}
                    }
                }

                if (e.ColumnIndex == datagridcategories.Columns["save"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in datagridcategories.SelectedRows)
                    {
                        //bool Internat = Login.InternetConnection();
                        //if (Internat == true)
                        //{
                        string categoryID = row.Cells["CATID"].Value.ToString();
                        string categoryName = row.Cells["Category in English"].Value.ToString();
                        string categoryNameArabic = row.Cells["Category in Arabic"].Value.ToString();
                        string shorno = row.Cells["Diasplay Sort NO"].Value.ToString();

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        //string sqlUpdateCmdWin = " update CAT_MST set SHORT_NAME='" + categoryName + "', CAT_NAME1 = '" + categoryName + "', CAT_NAME2 = N'" + categoryNameArabic + "', " +
                        //                       " CAT_NAME3 = '" + categoryName + "',DisplaySort='" + shorno + "' , Active = '1'," +
                        //                       " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                        //                       " where CATID = '" + categoryID + "' and TenentID= " + Tenent.TenentID + " ";
                        //int UpdateFlag = DataLive.ExecuteLiveSQL(sqlUpdateCmdWin);
                        //if (UpdateFlag == 1)
                        //{
                            string sqlUpdateCmd = " update CAT_MST set SHORT_NAME='" + categoryName + "', CAT_NAME1 = '" + categoryName + "', CAT_NAME2 = '" + categoryNameArabic + "', " +
                                               " CAT_NAME3 = '" + categoryName + "',DisplaySort='" + shorno + "' , Active = '1'," +
                                               " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                               " where CATID = '" + categoryID + "' and TenentID= " + Tenent.TenentID + " ";
                            DataAccess.ExecuteSQL(sqlUpdateCmd);

                            string sqlUpdateCmdWin = " update CAT_MST set SHORT_NAME='" + categoryName + "', CAT_NAME1 = '" + categoryName + "', CAT_NAME2 = N'" + categoryNameArabic + "', " +
                                                    " CAT_NAME3 = '" + categoryName + "',DisplaySort='" + shorno + "' , Active = '1'," +
                                                    " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                                    " where CATID = '" + categoryID + "' and TenentID= " + Tenent.TenentID + " ";
                            Datasyncpso.insert_Live_sync(sqlUpdateCmdWin, "CAT_MST", "UPDATE");

                            string ActivityName = "Update Catagory";
                            string LogData = "Update Catagory With CatID = " + categoryID + " and Catagory = " + categoryName + " ";
                            Login.InsertUserLog(ActivityName, LogData);
                        //}
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Please Check Your internet Connection");
                        //    return;
                        //}
                    }
                }

            }
            catch
            {

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int rows = datagridcategories.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                string categoryID = datagridcategories.Rows[i].Cells["CATID"].Value.ToString();
                string categoryName = datagridcategories.Rows[i].Cells["Category in English"].Value.ToString();
                string categoryNameArabic = datagridcategories.Rows[i].Cells["Category in Arabic"].Value.ToString();
                string shorno = datagridcategories.Rows[i].Cells["Diasplay Sort NO"].Value.ToString();

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlUpdateCmd = " update CAT_MST set SHORT_NAME='" + categoryName + "', CAT_NAME1 = '" + categoryName + "', CAT_NAME2 = '" + categoryNameArabic + "', " +
                                                " CAT_NAME3 = '" + categoryName + "',DisplaySort='" + shorno + "' , CAT_TYPE = 'WEBSALE' ,Active = '1'," +
                                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                                " where CATID = '" + categoryID + "' and TenentID= " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sqlUpdateCmd);

                string sqlUpdateCmdWin = " update CAT_MST set SHORT_NAME='" + categoryName + "', CAT_NAME1 = '" + categoryName + "', CAT_NAME2 = N'" + categoryNameArabic + "', " +
                                                " CAT_NAME3 = '" + categoryName + "',DisplaySort='" + shorno + "' ,CAT_TYPE = 'WEBSALE' ,Active = '1'," +
                                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                                " where CATID = '" + categoryID + "' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sqlUpdateCmdWin, "CAT_MST", "UPDATE");

                string ActivityName = "Update Catagory";
                string LogData = "Update Catagory With CatID = " + categoryID + " and Catagory = " + categoryName + " ";
                Login.InsertUserLog(ActivityName, LogData);
            }

            MessageBox.Show("save successfully ", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }


        private void datagridcategories_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow Myrow in datagridcategories.Rows)
            {
                string CatName = Myrow.Cells["CATID"].Value.ToString();
                Myrow.DefaultCellStyle.BackColor = SalesRegister.GetCatagoryColor(CatName);
            }
        }

    }
}
