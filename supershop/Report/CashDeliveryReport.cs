using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace supershop
{
    public partial class CashDeliveryReport : Form
    {
        public CashDeliveryReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            string sql3 = "select * from tbl_terminalLocation where TenentID = " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            DateTime dt = DateTime.Now;
            string printdate = dt.ToString("MMMM dd, yyyy    HH:mm:ss tt");
            string Companyname = dt1.Rows[0].ItemArray[1].ToString();
            string branchname = dt1.Rows[0].ItemArray[2].ToString();
            string Location = dt1.Rows[0].ItemArray[3].ToString();
            string phone = dt1.Rows[0].ItemArray[4].ToString();
            string email = dt1.Rows[0].ItemArray[5].ToString();
            string web = dt1.Rows[0].ItemArray[6].ToString();

            string Header = Companyname + "\n" + Location + "." + "\n" + email + "\n" + branchname + " ph: " + phone + "\n" + printdate + "\n";

            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;


            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            printDocument1.DocumentName = "Cash Delivery Report";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            printDocument1, true, true, Header + " Cash Delivery Report \n", new Font("Baskerville Old Face", 13,
            FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            // tosend = "<html><table>" + tosend + "</table></html>";
            //  mail.IsBodyHtml = true;
            //mail.Body = tosend;

            //else

            //    MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            //    printDocument1, false, true, Header + "   Sales Report   \n", new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            return true;
        }


        private void CashDeliveryReport_Load(object sender, EventArgs e)
        {
            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";

            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";

            lblStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblENDdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            datagrdReportDetails.EnableHeadersVisualStyles = false;
            datagrdReportDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            if (lblENDdate.Text == "0")
            {
                dailyReport();

            }
            else
            {
                Last30daysReport(lblStartDate.Text, lblENDdate.Text);
            }
        }

        public string ReportName
        {
            set
            {
                lblReportName.Text = value;
            }
            get
            {
                return lblReportName.Text;
            }
        }

        public string DTtoday
        {
            set
            {
                lblStartDate.Text = value;
                DateTime DT = Convert.ToDateTime(lblStartDate.Text);
                dtStartDate.Value = DT;
            }
            get
            {
                return lblStartDate.Text;
            }
        }

        public string last30salesStartDate
        {
            set
            {
                lblStartDate.Text = value;
                DateTime DT = Convert.ToDateTime(lblStartDate.Text);
                dtStartDate.Value = DT;
            }
            get
            {
                return lblStartDate.Text;
            }
        }

        public string last30salesENDDate
        {
            set
            {
                lblENDdate.Text = value;
                DateTime DT = Convert.ToDateTime(lblENDdate.Text);
                dtEndDate.Value = DT;
            }
            get
            {
                return lblENDdate.Text;
            }
        }


        public void dailyReport()
        {
            if (lblStartDate.Text == "")
            {

            }
            else
            {
                try
                {
                    string sql = " select TrmID as 'ShopID' , (select Shift_Name from tbl_Shift where ID = CashDelivery.ShiftID ) as 'Shift' , " +
                                 " Date,AMTDelivered as 'Amount Delivered', " +
                                 " (select UserName from usermgt where TenentID= " + Tenent.TenentID + " and id = CashDelivery.DeliVeredTo ) as 'Receivered person' ,RefNO " +
                                 " from CashDelivery where TenentID= " + Tenent.TenentID + " and Date like  '%" + lblStartDate.Text + "%' order by Date  ";

                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        public void Last30daysReport(string startDate, string endDate)
        {
            if (lblStartDate.Text == "")
            {

            }
            else
            {
                try
                {
                    DateTime end = Convert.ToDateTime(endDate);
                    end = end.AddDays(1);
                    endDate = end.ToString("yyyy-MM-dd");

                    string sql = " select TrmID as 'ShopID' , (select Shift_Name from tbl_Shift where  ID = CashDelivery.ShiftID ) as 'Shift' , " +
                                  " Date,AMTDelivered as 'Amount Delivered', " +
                                  " (select UserName from usermgt where TenentID = " + Tenent.TenentID + " and id = CashDelivery.DeliVeredTo ) as 'Receivered person' ,RefNO " +
                                  " from CashDelivery where tenentid= " + Tenent.TenentID + " and Date BETWEEN '" + startDate + "' AND '" + endDate + "' order by Date ";

                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;

                    datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.datagrdReportDetails.RowsDefaultCellStyle.BackColor = Color.White;
                this.datagrdReportDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                if (SetupThePrinting())
                {
                    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    MyPrintPreviewDialog.WindowState = FormWindowState.Maximized;
                    MyPrintPreviewDialog.PrintPreviewControl.Zoom = 1.0;
                    MyPrintPreviewDialog.Document = printDocument1;
                    MyPrintPreviewDialog.ShowDialog();

                    //PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    //MyPrintPreviewDialog.Document = printDocument1;
                    //MyPrintPreviewDialog.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("!!! Please Print Preview or Setup Print only for First time " + exp.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }


        private void helplnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            parameter.helpid = "INV";
            HelpPage go = new HelpPage();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void datagrdReportDetails_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch
            {

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DashBoard"] != null)
            {
                DashBoard go = (DashBoard)Application.OpenForms["DashBoard"];
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent]; ;
                go.Show();
            }
            else
            {
                if (Application.OpenForms["Home"] != null)
                {
                    DashBoard go = new DashBoard();
                    go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                    go.Show();
                }
            }

            this.Close();
        }

    }
}
