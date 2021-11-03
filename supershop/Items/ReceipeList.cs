using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Items
{
    public partial class ReceipeList : Form
    {
        public ReceipeList()
        {
            InitializeComponent();
        }

        private void lnkAddcategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Items.Add_Receipe go = new Items.Add_Receipe();
            go.MdiParent = this.ParentForm;
            go.Show();
            this.Close();
        }

        public void Receipebind()
        {

            string sql = " select recNo, Receipe_English as 'Receipe in English' , Receipe_Arabic as 'Receipe in Arabic' , RecType AS 'Receipe Type' , ExpireDays from tbl_Receipe where TenentID=" + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql);
            datagridcategories.DataSource = dt1;
            datagridcategories.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void ReceipeList_Load(object sender, EventArgs e)
        {
            try
            {

                Receipebind();

                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                datagridcategories.Columns.Add(Edit);
                Edit.HeaderText = "Edit";
                Edit.Text = "Edit";
                Edit.Name = "Edit";
                Edit.ToolTipText = "Edit this Receipe";
                Edit.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                datagridcategories.Columns.Add(del);
                del.HeaderText = "Del";
                del.Text = "X";
                del.Name = "del";
                del.ToolTipText = "Delete this Receipe";
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

                        string recNo = rowdel.Cells["recNo"].Value.ToString();
                        string recName = rowdel.Cells["Receipe in English"].Value.ToString();
                        string sql = "select * from  Receipe_Menegement where TenentID = " + Tenent.TenentID + " and recNo = '" + recNo + "' ";
                        DataTable dt = DataAccess.GetDataTable(sql);

                        if (dt.Rows.Count > 0)
                        {
                            int Count = dt.Rows.Count;
                            MessageBox.Show(" '" + recName + "' Used in  " + Count + " times, Not allow To Delete. ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        else
                        {


                            DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (result == DialogResult.Yes)
                            {
                                string sqldel = " delete from tbl_Receipe  where recNo = '" + recNo + "' and TenentID= " + Tenent.TenentID + " ";
                                DataAccess.ExecuteSQL(sqldel);

                                string sqlLive = "delete from tbl_Receipe where recNo = '" + recNo + "' and TenentID= " + Tenent.TenentID + " ";
                                Datasyncpso.insert_Live_sync(sqlLive, "tbl_Receipe", "DELETE");

                                string ActivityName = "delete Receipe";
                                string LogData = "delete Receipe With Receipe = " + recName + " ";
                                Login.InsertUserLog(ActivityName, LogData);

                                Receipebind();
                            }
                        }
                    }
                }

                // Delete items From Gridview
                if (e.ColumnIndex == datagridcategories.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in datagridcategories.SelectedRows)
                    {
                        Items.Add_Receipe mkc = new Items.Add_Receipe();
                        mkc.recNo = row.Cells["recNo"].Value.ToString();
                        mkc.Receipe_English = row.Cells["Receipe in English"].Value.ToString();
                        mkc.Receipe_Arabic = row.Cells["Receipe in Arabic"].Value.ToString();
                        mkc.DaysinExpire = row.Cells["ExpireDays"].Value.ToString();
                        mkc.MdiParent = this.ParentForm;
                        mkc.Show();
                        this.Close();
                    }
                }

            }
            catch
            {

            }
        }

    }
}
