using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace supershop.Report
{
    public partial class TopCustomer : Form
    {
        public TopCustomer()
        {
            InitializeComponent();
            ComboLimit.Text = "10";
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
            string sql3 = "select * from tbl_terminalLocation where Tenentid=" + Tenent.TenentID + " and  Shopid = '" + UserInfo.Shopid + "'";
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

            printDocument1.DocumentName = "Top " + lblLimit.Text + " Customer Report";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            printDocument1, true, true, Header + " Top " + lblLimit.Text + " Customer Report \n", new Font("Baskerville Old Face", 13,
            FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            // tosend = "<html><table>" + tosend + "</table></html>";
            //  mail.IsBodyHtml = true;
            //mail.Body = tosend;

            //else

            //    MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            //    printDocument1, false, true, Header + "   Sales Report   \n", new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            return true;
        }


        private void ShortCutReport_Load(object sender, EventArgs e)
        {
            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";

            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";

            dtStartDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            lblStartDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");

            dtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblENDdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            datagrdReportDetails.EnableHeadersVisualStyles = false;
            datagrdReportDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            Last30daysReport(lblStartDate.Text, lblENDdate.Text);

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

        public string Limit
        {
            set
            {
                lblLimit.Text = value;
            }
            get
            {
                return lblLimit.Text;
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

        public void Last30daysReport(string startDate, string endDate)
        {
            if (lblStartDate.Text == "")
            {
                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {
                    DateTime end = Convert.ToDateTime(endDate);
                    end = end.AddDays(1);
                    endDate = end.ToString("yyyy-MM-dd");

                    string sql = " Select distinct c_id,Customer,count(c_id) as NoofCID ,sum(Payment_Amount) as 'Total Amount' from sales_payment where Tenentid=" + Tenent.TenentID + " and  SaleDt BETWEEN '" + startDate + "' AND '" + endDate + "' " +
                                 " group by c_id order by sum(Payment_Amount) desc limit '" + lblLimit.Text + "' ";

                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;

                    datagrdReportDetails.Columns[0].Visible = false;
                    //datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[2].Visible = false;

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

        private void ComboLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboLimit.Text != "" && ComboLimit.Text != "System.Data.DataRowView")
            {
                lblLimit.Text = ComboLimit.Text;
                Last30daysReport(dtStartDate.Text, dtEndDate.Text);
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
                DashBoard go = new DashBoard();
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent]; ;
                go.Show();
            }
            this.Close();
        }


    }
}
