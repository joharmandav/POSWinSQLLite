using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Customer
{
    public partial class Due_payment_History : Form
    {
        public Due_payment_History(string custid, string sales_id)
        {
            InitializeComponent();
            lblcustid.Text = custid;
            lblinvoNo.Text = sales_id;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Due_payment_History_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "  select  sales_id as 'Invo No' , receivedate as Date , receiveamt as 'Receive Amount'  " +
                            "  from tbl_duepayment where TenentID = " + Tenent.TenentID + " and custid = '" + lblcustid.Text + "' and sales_id = '" + lblinvoNo.Text + "'  order by  id desc ";
                             
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                dtgviewCustDueHistory.DataSource = dt1;
            }
            catch
            {
            }
        }
    }
}
