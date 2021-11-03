using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace supershop.Report
{
    public partial class SaleReportRdlc : Form
    {
        public SaleReportRdlc()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 

        private void SaleReportRdlc_Load(object sender, EventArgs e)
        {
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            try
            {
                DateTime end = Convert.ToDateTime(ReportValue.EndDate);
                end = end.AddDays(1);

                string EndDate = end.ToString("yyyy-MM-dd");

                if (ReportValue.emp == "" && ReportValue.Terminal == "")   //Report by Every transaction -  Only Date to Date 
                {
                   
                    ReportParameter parReportParam1 = new ReportParameter("Dates", ReportValue.StartDate + "  To  " + ReportValue.EndDate);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parReportParam1 });
                    string sql = "select storeconfig.* , sum(sales_payment.payment_amount) AS Payamount,  sum(sales_payment.due_amount) AS due, " +
                     " sum(sales_payment.dis), sum(sales_payment.vat), sales_payment.sales_time AS sales_time , sales_payment.emp_id AS empID , sales_payment.sales_id AS salesid   " +
                     " from sales_payment , storeconfig " +
                     " where sales_payment.TenentID = " + Tenent.TenentID + " and sales_payment.SaleDt BETWEEN '" + ReportValue.StartDate + "' AND    '" + EndDate + "' and PaymentStutas='Success' and return_id=0 " +
                     " group by sales_id Order  by sales_payment.sales_time";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt = DataAccess.GetDataTable(sql);

                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dt);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                }
                else if (ReportValue.emp != "" && ReportValue.Terminal == "")   //Report by Every transaction -  Employee with date to date 
                {
                    string paravalue = ReportValue.StartDate + "  To  " + ReportValue.EndDate + " and " + ReportValue.emp;
                    ReportParameter parReportParam1 = new ReportParameter("Dates", "Report by : " + paravalue);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parReportParam1 });
                    string sql = "select storeconfig.* , sum(sales_payment.payment_amount) AS Payamount,  sum(sales_payment.due_amount) AS due, " +
                     " sum(sales_payment.dis), sum(sales_payment.vat), sales_payment.sales_time AS sales_time , sales_payment.emp_id AS empID , sales_payment.sales_id AS salesid   " +
                     " from sales_payment , storeconfig " +
                     " where sales_payment.TenentID = " + Tenent.TenentID + " and sales_payment.SaleDt BETWEEN '" + ReportValue.StartDate + "' AND    '" + EndDate + "' and PaymentStutas='Success' and return_id=0 " +
                     " AND sales_payment.emp_id = '" + ReportValue.emp + "' " +
                     " group by sales_id  Order  by sales_payment.sales_time";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt = DataAccess.GetDataTable(sql);

                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dt);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                }
                else if (ReportValue.emp == "" && ReportValue.Terminal != "")     //Report by Every transaction -    Terminal with date to date
                {
                    string paravalue = ReportValue.StartDate + "  To  " + ReportValue.EndDate + " and " + ReportValue.Terminal;
                    ReportParameter parReportParam1 = new ReportParameter("Dates", "Report by : " + paravalue);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parReportParam1 });
                    string sql = "select storeconfig.* , sum(sales_payment.payment_amount) AS Payamount,  sum(sales_payment.due_amount) AS due, " +
                     " sum(sales_payment.dis), sum(sales_payment.vat), sales_payment.sales_time AS sales_time , sales_payment.emp_id AS empID , sales_payment.sales_id AS salesid   " +
                     " from sales_payment , storeconfig " +
                     " where sales_payment.TenentID = " + Tenent.TenentID + " and sales_payment.SaleDt BETWEEN '" + ReportValue.StartDate + "' AND    '" + EndDate + "' and PaymentStutas='Success' and return_id=0 " +
                     " AND sales_payment.Shopid = '" + ReportValue.Terminal + "' " +
                     " group by sales_id Order  by sales_payment.sales_time";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt = DataAccess.GetDataTable(sql);

                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dt);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                }
                else if (ReportValue.emp != "" && ReportValue.Terminal != "")   //Report by Every transaction -  Employee and  Terminal with date to date  -- All
                {
                    string empterminal = ReportValue.StartDate + "  To  " + ReportValue.EndDate + " and " + ReportValue.emp + " - " + ReportValue.Terminal;
                    ReportParameter parReportParam1 = new ReportParameter("Dates", "Report by : " + empterminal);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parReportParam1 });
                    string sql = "select storeconfig.* , sum(sales_payment.payment_amount) AS Payamount,  sum(sales_payment.due_amount) AS due, " +
                     " sum(sales_payment.dis), sum(sales_payment.vat), sales_payment.sales_time AS sales_time , sales_payment.emp_id AS empID , sales_payment.sales_id AS salesid   " +
                     " from sales_payment , storeconfig " +
                     " where sales_payment.TenentID = " + Tenent.TenentID + " and sales_payment.SaleDt BETWEEN '" + ReportValue.StartDate + "'  AND    '" + EndDate + "' " +
                     " AND sales_payment.emp_id = '" + ReportValue.emp + "' AND sales_payment.Shopid = '" + ReportValue.Terminal + "' and PaymentStutas='Success' and return_id=0 " +
                     " group by sales_id Order  by sales_payment.sales_time";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt = DataAccess.GetDataTable(sql);

                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dt);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                }
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
               // this.reportViewer1.ZoomPercent = 35;
                this.reportViewer1.RefreshReport(); 
            }
            catch
            {
            }

        }
    }
}
