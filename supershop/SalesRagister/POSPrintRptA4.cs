using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace supershop
{
    public partial class POSPrintRptA4 : Form
    {
        string DeftPrinter = null;
        public POSPrintRptA4(string saleno, string DefaultPrinter)
        {
            InitializeComponent();
            toolsaleno.Text = saleno;
            DeftPrinter = DefaultPrinter;
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
                string sql = " SELECT  si.sales_id AS salesid, " +
                             " CASE WHEN sp.payment_type is not null THEN sp.payment_type WHEN sp.payment_type is null THEN 'Credit' END paytype, " +
                             " CASE WHEN sp.payment_amount is not null THEN sp.payment_amount WHEN sp.payment_amount is null THEN si.OrderTotal END Payamount, " +
                             " CASE WHEN sp.change_amount is not null THEN sp.change_amount  WHEN sp.change_amount is null THEN '0'  END charAmt, " +
                             " CASE WHEN sp.due_amount is not null THEN  sp.due_amount WHEN sp.due_amount is null THEN '0' END due, " +
                             " CASE WHEN sp.dis is not null THEN sp.dis WHEN sp.dis is null THEN '0' END dis, " +
                             " CASE WHEN sp.Delivery_Cahrge is not null THEN sp.Delivery_Cahrge WHEN sp.Delivery_Cahrge is null THEN '0' END Delivery_Cahrge, " +
                             " CASE WHEN sp.vat is not null THEN sp.vat WHEN sp.vat is null THEN '0' END vat, " +
                             " CASE WHEN sp.sales_time is not null THEN sp.sales_time WHEN sp.sales_time is null THEN si.sales_time END s_time, " +
                             " CASE WHEN sp.c_id is not null THEN sp.c_id WHEN sp.c_id is null THEN si.c_id END custID, " +
                             " CASE WHEN sp.emp_id is not null THEN sp.emp_id WHEN sp.emp_id is null THEN si.SOLDBY  END empID, " +
                             " CASE WHEN sp.comment is not null THEN  sp.comment WHEN sp.comment is null THEN ''  END Note, " +
                             " CASE WHEN sp.TrxType is not null THEN sp.TrxType WHEN sp.TrxType is null THEN 'POS' END TrxType , " +
                             " si.sales_id, si.item_id , si.itemName,IC.UOMNAME1 as 'UOM',si.product_name_print, si.Qty, si.RetailsPrice, si.Total,si.profit, " +
                             " si.sales_time ,si.BatchNo,si.ExpiryDate, sp.Shopid, tl.*,c.* , sc.LOGO ,si.Customer,si.InvoiceNO as 'Invoice_NO',  " +
                             " CASE WHEN si.taxapply = 1 THEN 'TX'  ELSE ''  END 'TaxApply',si.CustItemCode  " +
                             " FROM sales_item si Left JOIN sales_payment sp ON sp.sales_id  = si.sales_id and sp.TenentID  = si.TenentID " +
                             " INNER JOIN tbl_terminalLocation tl ON si.Shopid  = tl.Shopid and si.TenentID  = tl.TenentID " +
                             " INNER JOIN tbl_customer c ON  si.c_id  = c.ID and si.TenentID  = c.TenentID  " +
                             " INNER JOIN storeconfig sc ON  si.TenentID  = sc.TenentID " +
                             " INNER JOIN ICUOM IC ON  si.UOM  = IC.UOM and si.TenentID  = IC.TenentID " +
                             " Where si.TenentID = " + Tenent.TenentID + " and si.sales_id  = '" + toolsaleno.Text + "' and (sp.return_id=0 or sp.return_id is null) " +
                             " group by item_id "; 
                DataTable dt = DataAccess.GetDataTable(sql);

                string sqlpay = " SELECT * from sales_payment Where TenentID = " + Tenent.TenentID + " and sales_id= '" + toolsaleno.Text + "' and return_id=0 "; 
                DataTable dtpay = DataAccess.GetDataTable(sqlpay);
                if (dtpay == null)
                {
                    DataRow drfirst = dtpay.NewRow();
                    drfirst["payment_type"] = "Credit";
                    drfirst["payment_amount"] = "0";
                    drfirst["change_amount"] = "0";
                    drfirst["due_amount"] = "0";
                    drfirst["InvoiceNO"] = dt.Rows[0]["Invoice_NO"].ToString();
                    dtpay.Rows.Add(drfirst);
                }
                else if (dtpay.Rows.Count < 1)
                {
                    DataRow drfirst = dtpay.NewRow();
                    drfirst["payment_type"] = "Credit";
                    drfirst["payment_amount"] = "0";
                    drfirst["change_amount"] = "0";
                    drfirst["due_amount"] = "0";
                    drfirst["InvoiceNO"] = dt.Rows[0]["Invoice_NO"].ToString();
                    dtpay.Rows.Add(drfirst);
                }
                else
                {

                }

                ReportDataSource reportDSDetail = new ReportDataSource("DataSetPrint", dt);
                ReportDataSource reportDSPayment = new ReportDataSource("DataSet1", dtpay);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                this.reportViewer1.LocalReport.DataSources.Add(reportDSPayment);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
                //this.reportViewer1.ZoomPercent = 80;

                this.reportViewer1.LocalReport.EnableExternalImages = true;
                string FilePath = @"file:\" + Application.StartupPath + "\\" + "LOGO\\"; //Application.StartupPath is for WinForms, you should try AppDomain.CurrentDomain.BaseDirectory  for .net
                ReportParameter[] param = new ReportParameter[2];
                param[0] = new ReportParameter("ImgPath", FilePath);
                param[1] = new ReportParameter("EmpName", UserInfo.UserName);
                this.reportViewer1.LocalReport.SetParameters(param);

                this.reportViewer1.RefreshReport();

                //this.reportViewer1.PrinterSettings.PrinterName = DataAccess.GetDefaultPrinter();
                this.reportViewer1.PrinterSettings.PrinterName = DeftPrinter;
                               

                if (parameter.autoprintid == "1")
                {
                    if (IsPrinton())
                    {
                        //   default_PRint(DeftPrinter);

                        Run(dtpay, dt);

                        this.Close();

                    }
                    else
                    {
                        timerpregress.Interval = 100;
                        timerpregress.Start();

                        this.reportViewer1.PrintDialog();
                    }
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

      
     public static bool IsPrinton()
        {
            string sqlIsbooking = "Select IsPrint from storeconfig where TenentID=" + Tenent.TenentID + " and IsPrint='1' "; //From view combination of tbl_customer and custcredit
            DataTable dt1 = DataAccess.GetDataTable(sqlIsbooking);
            if (dt1.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void default_PRint(string DefaultPrinter)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = DefaultPrinter;
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();

            }
        }

        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private DataTable LoadSalesData()
        {
            // Create a new DataSet and read sales data file 
            //    data.xml into the first DataTable.
            DataSet dataSet = new DataSet();
            var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            dataSet.ReadXml(GetDirectory + @"\data.xml");
            return dataSet.Tables[0];
        }
        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.27in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.2in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void Print()
        {
            PrinterSettings settings = new PrinterSettings(); //set printer settings
            string printerName = settings.PrinterName; //use default printer name

            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
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
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        private void Run(DataTable reportds, DataTable reportdetail)
        {
            LocalReport report = new LocalReport();
            var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            report.ReportPath = GetDirectory + @"\Report\RptPOSA4Botiquat.rdlc";
            report.DataSources.Add(
               new ReportDataSource("DataSet1", reportds));
            report.DataSources.Add(
               new ReportDataSource("DataSetPrint", reportdetail));
            report.EnableExternalImages = true;
            string FilePath = @"file:\" + Application.StartupPath + "\\" + "LOGO\\"; //Application.StartupPath is for WinForms, you should try AppDomain.CurrentDomain.BaseDirectory  for .net
            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("ImgPath", FilePath);
            report.SetParameters(param);

            Export(report);
            Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }


        private void btnPrintDialog_Click(object sender, EventArgs e)
        {
            this.reportViewer1.PrintDialog();
        }

        //Auto open printpreview 
        public void prgressbar()
        {

            toolStripProgressBar1.Increment(10);
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
