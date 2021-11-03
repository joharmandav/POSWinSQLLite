using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Expenses
{
    public partial class ExpensesList : Form
    {
        public ExpensesList()
        {
            InitializeComponent();
        }

        private void lnkAddExpense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Expenses.AddExpense go = new Expenses.AddExpense();
            go.MdiParent = this.ParentForm;
            go.Show();
        }
        public void Expensebind()
        {
            string sql = " select  ID, Date , ReferenceNo as 'Refer No' , Category ,	Amount , Note ,	Createdby as 'Posted by', Attachment , fileextension from tbl_expense where TenentID = " + Tenent.TenentID + " ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            datagridExpenses.DataSource = dt1;
            lblRow.Text = datagridExpenses.RowCount.ToString() + " Records Found";

            double sum = 0;
            for (int i = 0; i < datagridExpenses.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(datagridExpenses.Rows[i].Cells[4].Value);
            }
            lblSum.Text = "Total amount: " + sum.ToString();

        }

        private void ExpensesList_Load(object sender, EventArgs e)
        {
            try
            {
                Expensebind();

                DataGridViewButtonColumn View = new DataGridViewButtonColumn();
                datagridExpenses.Columns.Add(View);
                View.HeaderText = "Attachment";
                View.Text = "View";
                View.Name = "View";
                View.ToolTipText = "View this attachment";
                View.UseColumnTextForButtonValue = true;


                DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                datagridExpenses.Columns.Add(del);
                del.HeaderText = "Delete";
                del.Text = "X";
                del.Name = "del";
                del.ToolTipText = "Delete this category";
                del.UseColumnTextForButtonValue = true;

                DataGridViewColumn ColID = datagridExpenses.Columns[0];
                ColID.Width = 31;
                DataGridViewColumn ColName = datagridExpenses.Columns[5];
                ColName.Width = 230;
                datagridExpenses.RowTemplate.MinimumHeight = 35;

                datagridExpenses.Columns[7].Visible = false;
                datagridExpenses.Columns[8].Visible = false;
                txtSearch.Focus();
            }
            catch
            {
            }
        }

        private void datagridExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // View support document From Gridview
                if (e.ColumnIndex == datagridExpenses.Columns["View"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in datagridExpenses.SelectedRows)
                    {

                        Expenses.ViewDoc mkc = new Expenses.ViewDoc(row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString());
                        mkc.ShowDialog();
                    }
                }
                // Delete category  
                if (e.ColumnIndex == datagridExpenses.Columns["del"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in datagridExpenses.SelectedRows)
                    {
                        DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (result == DialogResult.Yes)
                        {

                            string sqldel = " delete from tbl_expense  where  TenentID=" + Tenent.TenentID + " and ID = '" + rowdel.Cells[2].Value.ToString() + "'";
                            DataAccess.ExecuteSQL(sqldel);

                            string SqlDelLive = "delete from Win_tbl_expense  where TenentID=" + Tenent.TenentID + " and ID = '" + rowdel.Cells[2].Value.ToString() + "'";
                            Datasyncpso.insert_Live_sync(SqlDelLive, "Win_tbl_expense", "DELETE");

                            string ActivityName = "Delete Expense";
                            string LogData = "Delete Expense with ID = " + rowdel.Cells[2].Value.ToString() + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            if (rowdel.Cells[9].Value.ToString() != string.Empty)
                            {
                                string path = Application.StartupPath + @"\ExpenseAttachment\";
                                System.IO.File.Delete(path + @"\" + rowdel.Cells[9].Value.ToString());
                            }
                            MessageBox.Show("Deleted");
                            Expensebind();

                        }
                    }
                }

            }
            catch
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = " select  ID, Date , ReferenceNo as 'Refer No' , Category ,	Amount , Note ,	Createdby as 'Posted by', Attachment , fileextension from tbl_expense " +
                          " Where TenentID = " + Tenent.TenentID + " and ReferenceNo like '" + txtSearch.Text + "%'  or Note like   '%" + txtSearch.Text + "%' or Createdby like '" + txtSearch.Text + "%'  ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            datagridExpenses.DataSource = dt1;
            lblRow.Text = datagridExpenses.RowCount.ToString() + " Records Found";

            double sum = 0;
            for (int i = 0; i < datagridExpenses.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(datagridExpenses.Rows[i].Cells[6].Value);
            }
            lblSum.Text = "Total amount: " + sum.ToString();
        }
    }
}
