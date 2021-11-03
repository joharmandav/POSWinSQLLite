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
    public partial class PaymentTypeList : Form
    {
        public PaymentTypeList()
        {
            InitializeComponent();
        }

        public void Paytypebind()
        {
            string sql = "Select REFID,REFNAME1 as 'Name in English',REFNAME2 as 'Name in Arabic' from REFTABLE where TenentID = " + Tenent.TenentID + " and RefType = 'Payment' and RefSubType = 'Method' and ShortName = 'POS' And ACTIVE = 'Y'";
            DataTable dt1 = DataAccess.GetDataTable(sql);
            datagridPayment.DataSource = dt1;
            datagridPayment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;            
        }

        private void PaymentTypeList_Load(object sender, EventArgs e)
        {
            try
            {

                Paytypebind();

                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                datagridPayment.Columns.Add(Edit);
                Edit.HeaderText = "Edit";
                Edit.Text = "Edit";
                Edit.Name = "Edit";
                Edit.ToolTipText = "Edit this UOM";
                Edit.UseColumnTextForButtonValue = true;
                Edit.Width = 100;

                DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                datagridPayment.Columns.Add(del);
                del.HeaderText = "Delete";
                del.Text = "Delete";
                del.Name = "Delete";
                del.ToolTipText = "Delete this UOM";
                del.UseColumnTextForButtonValue = true;
                del.Width = 100;

            }
            catch
            {
            }
        }

        private void datagridPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Delete UOM  
                if (e.ColumnIndex == datagridPayment.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in datagridPayment.SelectedRows)
                    {
                        //select UOM, UOMNAME1 as 'UOM in English' , UOMNAME2 as 'UOM in Arabic'
                        string REFID = rowdel.Cells["REFID"].Value.ToString();
                        string sql = "select * from  REFTABLE where TenentID=" + Tenent.TenentID + " and REFID = '" + REFID + "' ";
                        DataTable dt = DataAccess.GetDataTable(sql);

                        if (dt.Rows.Count > 0)
                        {
                            DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (result == DialogResult.Yes)
                            {
                                string sqldel = " delete from REFTABLE  where REFID = '" + REFID + "' and TenentID= " + Tenent.TenentID + "";
                                DataAccess.ExecuteSQL(sqldel);

                                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                string sqlUpdateCmdWIN = " delete from REFTABLE  where REFID = '" + REFID + "' and TenentID= " + Tenent.TenentID + " ";
                                Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "REFTABLE", "DELETE");

                                string ActivityName = "delete Pay Type";
                                string LogData = "delete Pay Type With REFID = " + REFID + " ";
                                Login.InsertUserLog(ActivityName, LogData);

                                Paytypebind();
                            }
                        }                        
                    }
                }
                else if (e.ColumnIndex == datagridPayment.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in datagridPayment.SelectedRows)
                    {
                        this.Hide();
                        Add_PaymentType mkc = new Add_PaymentType();
                        mkc.REFID = row.Cells["REFID"].Value.ToString();
                        mkc.REFNAME1 = row.Cells["Name in English"].Value.ToString();
                        mkc.REFNAME2 = row.Cells["Name in Arabic"].Value.ToString();
                        mkc.MdiParent = this.ParentForm;
                        mkc.PageName = "PaymentTypeList";
                        mkc.Show();                        
                    }
                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private void lnkAddPayType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_PaymentType go = new Add_PaymentType();
            go.MdiParent = this.ParentForm;
            go.PageName = "PaymentTypeList";
            go.Show();
            this.Close();
        }
    }
}
