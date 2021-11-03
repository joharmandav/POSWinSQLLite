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
    public partial class UomList : Form
    {
        public UomList()
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
            Add_UOM go = new Add_UOM();
            go.MdiParent = this.ParentForm;
            go.Show();
            this.Close();
            //}
        }

        public void UOMbind()
        {
            string sql = " select UOM, UOMNAME1 as 'UOM in English' , UOMNAME2 as 'UOM in Arabic' from ICUOM where TenentID=" + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql);
            datagridcategories.DataSource = dt1;
            datagridcategories.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            if (dt1 != null)
            {
                if (dt1.Rows.Count > 0)
                {
                    int UOM = Convert.ToInt32(dt1.Rows[0]["UOM"]);
                    bindUOMConvrsion(UOM);
                }
            }
        }

        public void bindUOMConvrsion(int UOM)
        {
            string sql = " select (select UOMname1 from icuom where TenentID = " + Tenent.TenentID + " and UOM = FUOM ) as 'From UOM', " +
                         " (select UOMname1 from icuom where TenentID = " + Tenent.TenentID + " and UOM = TUOM ) as 'TO UOM', Conversion,Remarks,FUOM ,TUOM " +
                         " from ICUOMCONV Where TenentID = " + Tenent.TenentID + " and FUOM = " + UOM + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql);
            DataUOMConv.DataSource = dt1;
            DataUOMConv.Columns["From UOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DataUOMConv.Columns["TO UOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DataUOMConv.Columns["Conversion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataUOMConv.Columns["FUOM"].Visible = false;
            DataUOMConv.Columns["TUOM"].Visible = false;

        }

        private void Categories_Load(object sender, EventArgs e)
        {
            try
            {

                UOMbind();

                //DataGridViewButtonColumn save = new DataGridViewButtonColumn();
                //datagridcategories.Columns.Add(save);
                //save.HeaderText = "save";
                //save.Text = "save";
                //save.Name = "save";
                //save.ToolTipText = "save this UOM";
                //save.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn AddConv = new DataGridViewButtonColumn();
                datagridcategories.Columns.Add(AddConv);
                AddConv.HeaderText = "Add Conversion";
                AddConv.Text = "Add Conversion";
                AddConv.Name = "Add Conversion";
                AddConv.ToolTipText = "Add Conversion";
                AddConv.UseColumnTextForButtonValue = true;
                AddConv.Width = 150;

                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                datagridcategories.Columns.Add(Edit);
                Edit.HeaderText = "Edit";
                Edit.Text = "Edit";
                Edit.Name = "Edit";
                Edit.ToolTipText = "Edit this UOM";
                Edit.UseColumnTextForButtonValue = true;
                Edit.Width = 100;

                DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                datagridcategories.Columns.Add(del);
                del.HeaderText = "Delete";
                del.Text = "Delete";
                del.Name = "Delete";
                del.ToolTipText = "Delete this UOM";
                del.UseColumnTextForButtonValue = true;
                del.Width = 100;

                DataGridViewButtonColumn EditConv = new DataGridViewButtonColumn();
                DataUOMConv.Columns.Add(EditConv);
                EditConv.HeaderText = "Edit";
                EditConv.Text = "Edit";
                EditConv.Name = "Edit";
                EditConv.ToolTipText = "Edit this UOM Conversion";
                EditConv.UseColumnTextForButtonValue = true;
                EditConv.Width = 100;

                DataGridViewButtonColumn delConv = new DataGridViewButtonColumn();
                DataUOMConv.Columns.Add(delConv);
                delConv.HeaderText = "Delete";
                delConv.Text = "Delete";
                delConv.Name = "Delete";
                delConv.ToolTipText = "Delete this UOM Conversion";
                delConv.UseColumnTextForButtonValue = true;
                delConv.Width = 100;

                //DataGridViewColumn ColID = datagridcategories.Columns[0];
                //ColID.Width = 31;
                //DataGridViewColumn ColName = datagridcategories.Columns[1];
                //ColName.Width = 240;
                //DataGridViewColumn ColNamearabic = datagridcategories.Columns[2];
                //ColNamearabic.Width = 240;                
            }
            catch
            {
            }
        }

        private void datagridcategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Delete UOM  
                if (e.ColumnIndex == datagridcategories.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in datagridcategories.SelectedRows)
                    {
                        //select UOM, UOMNAME1 as 'UOM in English' , UOMNAME2 as 'UOM in Arabic'
                        string UOMNAME = rowdel.Cells["UOM in English"].Value.ToString();
                        string UOMID = rowdel.Cells["UOM"].Value.ToString();

                        string sql1 = "select * from ICUOMCONV Where TenentID = " + Tenent.TenentID + " and ( FUOM = '" + UOMID + "' OR TUOM = '" + UOMID + "' ) ";
                        DataTable dt = DataAccess.GetDataTable(sql1);

                        string sql = "select * from  tbl_item_uom_price where TenentID=" + Tenent.TenentID + " and UOMID = '" + UOMID + "' ";
                        DataTable dt1 = DataAccess.GetDataTable(sql);

                        if (dt1.Rows.Count > 0)
                        {
                            int Count = dt1.Rows.Count;
                            MessageBox.Show(" '" + UOMNAME + "' Used in  " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        if (dt.Rows.Count > 0)
                        {
                            int Count = dt.Rows.Count;
                            MessageBox.Show(" '" + UOMNAME + "' Used in  " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                                string UOM = rowdel.Cells["UOM"].Value.ToString();
                                string sqldel = " delete from ICUOM  where UOM = '" + UOM + "' and TenentID= " + Tenent.TenentID + "";
                                //int DeleteFalf = DataLive.ExecuteLiveSQL(sqldel);
                                //if (DeleteFalf == 1)
                                //{

                                DataAccess.ExecuteSQL(sqldel);

                                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                string sqlUpdateCmdWIN = " delete from ICUOM  where UOM = '" + UOM + "' and TenentID= " + Tenent.TenentID + " ";
                                Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "ICUOM", "DELETE");

                                string ActivityName = "delete UOM";
                                string LogData = "delete UOM With UOM = " + UOMID + " ";
                                Login.InsertUserLog(ActivityName, LogData);

                                UOMbind();
                                //}
                                //}
                            }
                            else
                            {
                                MessageBox.Show("Please Check Your internet Connection");
                                return;
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == datagridcategories.Columns["Add Conversion"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in datagridcategories.SelectedRows)
                    {
                        string UOMNAME = row.Cells["UOM in English"].Value.ToString();
                        string UOM = row.Cells["UOM"].Value.ToString();
                        int UOMID = Convert.ToInt32(UOM);
                        bool flag = CheckMultiUomAlllow(UOMID);

                        if (flag == true)
                        {
                            if (Application.OpenForms["UOMConversion"] != null)
                            {
                                Application.OpenForms["UOMConversion"].Close();
                            }

                            UOMConversion go = new UOMConversion();
                            go.ActionMode = "ADD";
                            go.FUOM = UOM;
                            go.Show();
                        }
                        else
                        {
                            MessageBox.Show( " Add Conversion Not Allow In '" + UOMNAME + "' \n Please make Enable 'Multiple Unit Of Massure' In 'Edit' ");
                            return;
                        }
                    }
                }
                else if (e.ColumnIndex == datagridcategories.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in datagridcategories.SelectedRows)
                    {
                        //bool Internat = Login.InternetConnection();
                        //if (Internat == true)
                        //{
                        //select UOM, UOMNAME1 as 'UOM in English' , UOMNAME2 as 'UOM in Arabic'
                        this.Hide();
                        Add_UOM mkc = new Add_UOM();
                        mkc.UOMID = row.Cells["UOM"].Value.ToString();
                        mkc.MdiParent = this.ParentForm;
                        mkc.Show();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Please Check Your internet Connection");
                        //    return;
                        //}
                    }
                }
                else
                {
                    foreach (DataGridViewRow rowselect in datagridcategories.SelectedRows)
                    {
                        int UOM = Convert.ToInt32(rowselect.Cells["UOM"].Value);
                        lblFromUOMID.Text = UOM.ToString();
                        lblFromUOMname.Text = rowselect.Cells["UOM in English"].Value.ToString();
                        bindUOMConvrsion(UOM);
                    }
                }

            }
            catch
            {

            }
        }


        private void DataUOMConv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Delete Conversion  
                if (e.ColumnIndex == DataUOMConv.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in DataUOMConv.SelectedRows)
                    {
                        int FUOM = Convert.ToInt32(rowdel.Cells["FUOM"].Value);
                        int TUOM = Convert.ToInt32(rowdel.Cells["TUOM"].Value);

                        string sql = "select * from  tbl_item_uom_price where TenentID=" + Tenent.TenentID + " and UOMID = '" + FUOM + "' ";
                        DataTable dt1 = DataAccess.GetDataTable(sql);

                        if (dt1.Rows.Count > 0)
                        {
                            int Count = dt1.Rows.Count;
                            MessageBox.Show(" This Conversion  Used in  " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (result == DialogResult.Yes)
                            {
                                string sqldel = " delete from ICUOMCONV  where TenentID = " + Tenent.TenentID + " and FUOM = " + FUOM + " and TUOM= " + TUOM + "";
                                DataAccess.ExecuteSQL(sqldel);

                                string sqlUpdateCmdWIN = " delete from ICUOMCONV  where TenentID = " + Tenent.TenentID + " and FUOM = " + FUOM + " and TUOM= " + TUOM + " ";
                                Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "ICUOMCONV", "DELETE");

                                if (lblFromUOMID.Text != "-")
                                {
                                    int UOM = Convert.ToInt32(lblFromUOMID.Text);
                                    bindUOMConvrsion(UOM);
                                }
                            }
                        }
                    }
                }

                // Edit Conversion  
                if (e.ColumnIndex == DataUOMConv.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowEdit in DataUOMConv.SelectedRows)
                    {
                        int FUOM = Convert.ToInt32(rowEdit.Cells["FUOM"].Value);
                        int TUOM = Convert.ToInt32(rowEdit.Cells["TUOM"].Value);
                        string Conversion = rowEdit.Cells["Conversion"].Value.ToString();
                        string Remarks = rowEdit.Cells["Remarks"].Value.ToString();

                        if (Application.OpenForms["UOMConversion"] != null)
                        {
                            Application.OpenForms["UOMConversion"].Close();
                        }

                        UOMConversion go = new UOMConversion();
                        go.ActionMode = "EDIT";
                        go.FUOM = FUOM.ToString();
                        go.TUOM = TUOM.ToString();
                        go.Conversion = Conversion;
                        go.Remarks = Remarks;
                        go.Show();
                    }
                }
            }
            catch
            {

            }
        }

        public bool CheckMultiUomAlllow(int UOM)
        {
            bool Flag = false;
            string sql = " select * from ICUOM where TenentID=" + Tenent.TenentID + " and UOM = '" + UOM + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql);
            if (dt1 != null)
            {
                Flag = dt1.Rows[0]["MultiUOMAllow"].ToString() == "1" ? true : false;
            }
            return Flag;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ISrun = backSyncro.isRun;
            if (ISrun != true)
            {
                if (lblFromUOMID.Text != "-")
                {
                    int UOM = Convert.ToInt32(lblFromUOMID.Text);
                    bindUOMConvrsion(UOM);
                }
            }
        }
    }
}
