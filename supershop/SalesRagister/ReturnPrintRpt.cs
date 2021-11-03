using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;


namespace supershop
{
    public partial class ReturnPrintRpt : Form
    {
        public ReturnPrintRpt(string saleno)
        {
            InitializeComponent();
            toolsaleno.Text = saleno;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void POSPrintRpt_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = " SELECT  sp.sales_id AS salerid, sp.payment_amount AS Payamount," +
                             " sp.change_amount AS charAmt, sp.due_amount AS due, sp.dis, sp.vat, sp.sales_time AS s_time," +
                             " sp.c_id AS custID, sp.emp_id AS empID, sp.comment AS Note, sp.TrxType, ri.return_id,ri.item_id," +
                             " ri.itemName,IC.UOMNAME1 as 'UOM', ri.Qty, ri.RetailsPrice, ri.Total,ri.BatchNo,ri.ExpiryDate, sp.Shopid, tl.*,c.* " +
                             " FROM  sales_payment sp " +
                             " INNER JOIN   return_item ri ON sp.return_id  = ri.return_id and sp.TenentID  = ri.TenentID " +
                             " INNER JOIN tbl_terminalLocation tl ON sp.Shopid  = tl.Shopid and sp.TenentID  = tl.TenentID " +
                             " INNER JOIN tbl_customer c  ON  sp.c_id  = c.ID and sp.TenentID  = c.TenentID " +
                             " INNER JOIN ICUOM IC ON  ri.UOM  = IC.UOM and ri.TenentID  = IC.TenentID " +
                             " Where sp.TenentID = " + Tenent.TenentID + " and sp.return_id  = '" + toolsaleno.Text + "' ";

                DataTable dt = DataAccess.GetDataTable(sql);

                string sqlpay = " SELECT * from sales_payment Where return_id= '" + toolsaleno.Text + "'";
                DataAccess.ExecuteSQL(sqlpay);
                DataTable dtpay = DataAccess.GetDataTable(sqlpay);

                ReportDataSource reportDSDetail = new ReportDataSource("ReturnPRINDataSet", dt);
                ReportDataSource reportDSPayment = new ReportDataSource("DataSet_Return", dtpay);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                this.reportViewer1.LocalReport.DataSources.Add(reportDSPayment);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
                //this.reportViewer1.ZoomPercent = 80;
                this.reportViewer1.RefreshReport();
                //Print();

                if (parameter.autoprintid == "1")
                {
                    timerpregress.Interval = 100;
                    timerpregress.Start();
                    this.reportViewer1.PrintDialog();
                    //Print();
                }
                else
                {
                    timerpregress.Stop();
                    toolstrpProgressCount.Visible = false;
                    toolStripProgressBar1.Visible = false;
                    btnstopPrint.Visible = false;
                }

            }
            catch
            {
            }
        }

        private IList<Stream> m_streams;
        private int m_currentPageIndex;
        private void Print()
        {
            PrinterSettings settings = new PrinterSettings(); //set printer settings
            string printerName = settings.PrinterName; //use default printer name

            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();

            if (!printDoc.PrinterSettings.IsValid)
            {
                MessageBox.Show(printerName, "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }

        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);

        }
        private void btnPrintDialog_Click(object sender, EventArgs e)
        {
            this.reportViewer1.PrintDialog();
        }

        //Auto open printpreview 
        public void prgressbar()
        {

            toolStripProgressBar1.Increment(5);
            toolstrpProgressCount.Text = " " + toolStripProgressBar1.Value.ToString() + "%";
            if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
            {
                timerpregress.Stop();
                this.reportViewer1.PrintDialog();
                timerpregress.Stop();
            }
        }
        private void timerpregress_Tick(object sender, EventArgs e)
        {
            try
            {
                prgressbar();
            }
            catch
            {
            }
        }

        private void btnstopPrint_Click(object sender, EventArgs e)
        {
            if (btnstopPrint.Text != "START")
            {
                timerpregress.Stop();
                btnstopPrint.Text = "START";
            }
            else
            {
                btnstopPrint.Text = "STOP";
                timerpregress.Start();
            }

        }
    }
}
