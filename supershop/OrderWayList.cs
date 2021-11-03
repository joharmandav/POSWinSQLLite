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
    public partial class OrderWayList : Form
    {
        public OrderWayList()
        {
            InitializeComponent();
        }

        private void OrderWayList_Load(object sender, EventArgs e)
        {
            bindGrid();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dtGrdvorderwayDetails.Columns.Add(btn);
            btn.HeaderText = "Edit";
            btn.Text = "Edit";
            btn.Name = "btn";
            // btn.Width = 2;
            btn.UseColumnTextForButtonValue = true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void bindGrid()
        {
            // Name,Commission_per,Commission_Amount,Paid_Commission,Pending_Commission
            string sqlCmd = "Select ID,OrderWayID,Name1,Name2,Commission_per,Commission_Amount,DeliveryCharges,Paid_Commission,Pending_Commission from  tbl_orderWay_Maintenance where TenentID = " + Tenent.TenentID + " "; //From view combination of tbl_customer and custcredit
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdvorderwayDetails.DataSource = dt1;
        }

        private void dtGrdvorderwayDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dtGrdvorderwayDetails.Rows[e.RowIndex];
                // label1.Text = row.Cells[0].Value.ToString();

                OrderWayMaintenance mkc = new OrderWayMaintenance();
                mkc.OerderID = row.Cells[0].Value.ToString();
                mkc.OerderwayID = row.Cells[1].Value.ToString();
                mkc.OerderwayNameEnglish = row.Cells[2].Value.ToString();
                mkc.OerderwayNameArabic = row.Cells[3].Value.ToString();
                mkc.Commission_per = row.Cells[4].Value.ToString();
                mkc.Commission_amount = row.Cells[5].Value.ToString();
                mkc.DeliveryCharges = row.Cells[6].Value.ToString();
                mkc.Commission_paid = row.Cells[7].Value.ToString();
                mkc.Commission_Pending = row.Cells[8].Value.ToString();
                mkc.ShowDialog();

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }


    }
}
