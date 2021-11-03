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
    public partial class LedgerReport : Form
    {
        public LedgerReport()
        {
            InitializeComponent();
        }

        private void LedgerReport_Load(object sender, EventArgs e)
        {

            try
            {
                Databind();

                dtStartDate.Format = DateTimePickerFormat.Custom;
                dtStartDate.CustomFormat = "yyyy-MM-dd";

                dtEndDate.Format = DateTimePickerFormat.Custom;
                dtEndDate.CustomFormat = "yyyy-MM-dd";
            }
            catch
            {
            }

        }

        public void Databind()
        {
            string sqlCmd = "SELECT * from vw_general_ledger  order by Date desc";
            DataAccess.ExecuteSQL(sqlCmd);
            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            dtGrdLedgerReport.DataSource = dt1;

            string sqlSUM = "SELECT   Sum(Sales) as Credit, Sum(Return) as Debit from vw_general_ledger";
            DataAccess.ExecuteSQL(sqlSUM);
            DataTable dtSUM = DataAccess.GetDataTable(sqlSUM);

            DataRow dr = dt1.NewRow();
            dr[0] = "______________________________________________ ";
            dt1.Rows.Add(dr);

            DataRow Total = dt1.NewRow();
            Total[0] = "Total = ";
            Total[1] = dtSUM.Rows[0].ItemArray[0].ToString();
            Total[2] = dtSUM.Rows[0].ItemArray[1].ToString();
            dt1.Rows.Add(Total);

            DataRow Balance = dt1.NewRow();
            Balance[0] = "Balance = ";
            Balance[1] = Convert.ToDouble(dtSUM.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dtSUM.Rows[0].ItemArray[1].ToString());
            // Balance[2] = dtSUM.Rows[0].ItemArray[1].ToString();
            dt1.Rows.Add(Balance);
        }

        public void ReportByDate(string StartDate, string EndDate)
        {
            try
            {
                string sqlCmd = "Select * from  vw_general_ledger where  Date BETWEEN '" + StartDate + "' AND    '" + EndDate + "'   order by Date desc ";
                DataAccess.ExecuteSQL(sqlCmd);
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                dtGrdLedgerReport.DataSource = dt1;

                string sqlSUM = "SELECT   Sum(Sales) as Credit, Sum(Return) as Debit from vw_general_ledger";
                DataAccess.ExecuteSQL(sqlSUM);
                DataTable dtSUM = DataAccess.GetDataTable(sqlSUM);

                DataRow dr = dt1.NewRow();
                dr[0] = "______________________________________________ ";
                dt1.Rows.Add(dr);

                DataRow Total = dt1.NewRow();
                Total[0] = "Total = ";
                Total[1] = dtSUM.Rows[0].ItemArray[0].ToString();
                Total[2] = dtSUM.Rows[0].ItemArray[1].ToString();
                dt1.Rows.Add(Total);

                DataRow Balance = dt1.NewRow();
                Balance[0] = "Balance = ";
                Balance[1] = Convert.ToDouble(dtSUM.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dtSUM.Rows[0].ItemArray[1].ToString());
                dt1.Rows.Add(Balance);

                DataRow dr3 = dt1.NewRow();
                dr3[0] = "______________________________________________ ";
                dt1.Rows.Add(dr3);
            }
            catch
            {
            }
        }

        /// //////////////  Print Part  Start
        /// 

        DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            string sql3 = "select * from storeconfig where TenentID = " + Tenent.TenentID + "";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);
            DateTime dt = DateTime.Now;
            string s = dt.ToString("MMMM dd, yyyy    HH:mm:ss tt");

            string sd = dt1.Rows[0].ItemArray[1].ToString() + "\n" + dt1.Rows[0].ItemArray[2].ToString() + "." + "\n" + dt1.Rows[0].ItemArray[3].ToString() + "\n" + s + "\n";

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

            printDocument1.DocumentName = "Ledger Report";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(dtGrdLedgerReport,
            printDocument1, true, true, sd + " General Ledger Report \n", new Font("Baskerville Old Face", 15,
            FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            //else

            //    MyDataGridViewPrinter = new DataGridViewPrinter(dtGrdLedgerReport,
            //    printDocument1, false, true, sd + "   General Ledger Report  \n", new Font("Times New Roman", 15, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtGrdLedgerReport.RowsDefaultCellStyle.BackColor = Color.White;
                this.dtGrdLedgerReport.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                if (SetupThePrinting())
                {
                    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    MyPrintPreviewDialog.Document = printDocument1;
                    MyPrintPreviewDialog.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("!!! Please Print Preview or Setup Print only for First time " + exp.Message);
            }
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            ReportByDate(dtStartDate.Text, dtEndDate.Text);
        }

    }
}
