using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Report
{
    public partial class ReportDialog : Form
    {
        public ReportDialog()
        {
            InitializeComponent();
            dtStartDate.Text = dtStartDate.Value.AddDays(-30).ToShortDateString();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                ReportValue.StartDate = dtStartDate.Text; // dtStartDate.Value.ToShortDateString();
                ReportValue.EndDate = dtEndDate.Text; // dtEndDate.Value.ToShortDateString();
                ReportValue.emp = cmbEmp.Text;
                ReportValue.Terminal = cmboterminal.SelectedValue.ToString();
                SaleReportRdlc go = new SaleReportRdlc();
                go.ShowDialog();
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            salesreport go = new salesreport();
            // go.MdiParent = this;
            go.Show();
        }

        private void ReportDialog_Load(object sender, EventArgs e)
        {
            try
            {
                dtStartDate.Format = DateTimePickerFormat.Custom;
                dtStartDate.CustomFormat = "yyyy-MM-dd";
                dtEndDate.Format = DateTimePickerFormat.Custom;
                dtEndDate.CustomFormat = "yyyy-MM-dd";

                string sql5 = "   select     DISTINCT '' as Username    from usermgt where TenentID = " + Tenent.TenentID + " union all " +
                                " select   DISTINCT  Username   from usermgt where TenentID = " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                cmbEmp.DataSource = dt5;
                cmbEmp.DisplayMember = "Username";


                string sqltr = " select  DISTINCT '' as BranchName ,'' as Shopid from tbl_terminalLocation  where TenentID = " + Tenent.TenentID + "  union all" +
                               " select   BranchName , Shopid from tbl_terminalLocation   where TenentID = " + Tenent.TenentID + "  ";
                DataAccess.ExecuteSQL(sqltr);
                DataTable dttr = DataAccess.GetDataTable(sqltr);
                cmboterminal.DataSource = dttr;
                cmboterminal.DisplayMember = "BranchName";
                cmboterminal.ValueMember = "Shopid";
            }
            catch
            {
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbEmp.Text = "";
            cmboterminal.Text = "";
            cmboterminal.SelectedValue = "";
        }


    }
}
