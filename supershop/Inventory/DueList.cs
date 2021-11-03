using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Finisar.SQLite;

namespace supershop
{
    public partial class DueList : Form
    {
        public DueList()
        {
            InitializeComponent();
        }

        private void DueList_Load(object sender, EventArgs e)
        {
            dateTimeDue.Format = DateTimePickerFormat.Custom;
            dateTimeDue.CustomFormat = "yyyy-MM-dd";

            datagridDueList.EnableHeadersVisualStyles = false;
            datagridDueList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagridDueList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagridDueList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            string sql = "select  sales_id as 'Invoice No' , sales_time as Date , payment_amount as Total , " +
                         " (payment_amount - due_amount) as 'Paid Amount' ,  payment_type as 'Payment Type' , " +
                         "  due_amount as Due, emp_id as 'Sold by' ,   C_id  as CustID , Comment as 'Cust Name/Comment' " +
                         " from sales_payment where TenentID = " + Tenent.TenentID + " and due_amount !='0'  ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            datagridDueList.DataSource = dt1;
            datagridDueList.Columns[5].DefaultCellStyle.ForeColor = Color.DarkViolet;

            //this.datagridDueList.EnableHeadersVisualStyles = false;
            //this.datagridDueList.Columns[5].HeaderCell.Style.BackColor = Color.Red;


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            datagridDueList.Columns.Add(btn);
            btn.HeaderText = "Receive";
            btn.Text = "+";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

        }

        private void datagridDueList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = datagridDueList.Rows[e.RowIndex];
                DueUpdate mkc = new DueUpdate();

                mkc.Salesid = row.Cells[1].Value.ToString();
                mkc.salesdate = row.Cells[2].Value.ToString();
                mkc.totalamount = row.Cells[3].Value.ToString();
                mkc.paidamount = row.Cells[4].Value.ToString();
                mkc.due = row.Cells[6].Value.ToString();
                mkc.contact = row.Cells[8].Value.ToString();
                this.Hide();
                mkc.MdiParent = this.ParentForm;
                mkc.Show();

            }
            catch
            {

            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select  sales_id as 'Invoice No' , sales_time as Date , payment_amount as Total ,  " +
                             " (payment_amount - due_amount) as 'Paid Amount' , payment_type as 'Payment Type' , " +
                             "  due_amount as Due, emp_id as 'Sold by' ,    C_id  as Contact , Comment as 'Cust Name/Comment' " +
                             "  from sales_payment where TenentID = " + Tenent.TenentID + " and sales_id = '" + txtsearch.Text + "' and due_amount !='0'  ";
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagridDueList.DataSource = dt1;
            }
            catch
            {
            }

        }

        private void dateTimeDue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select  sales_id as 'Invoice No' , sales_time as Date , payment_amount as Total , " +
                            " (payment_amount - due_amount) as 'Paid Amount' ,  payment_type as 'Payment Type' ,  " +
                            " due_amount as Due, emp_id as 'Sold by' ,    C_id  as Contact , Comment   " +
                            " from sales_payment where TenentID = " + Tenent.TenentID + " and sales_time = '" + dateTimeDue.Text + "' and due_amount !='0'  ";
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagridDueList.DataSource = dt1;
            }
            catch
            {
            }
        }
    }
}
