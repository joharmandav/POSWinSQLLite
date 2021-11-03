
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop.Report
{
    public partial class SaleReportViewer : Form
    {
        DataTable _ReportDt = new DataTable();
        decimal _openingbalance;
        public SaleReportViewer(DataTable ReportDt, decimal openingbalance)
        {
            this._ReportDt = ReportDt;
            this._openingbalance = openingbalance;
            InitializeComponent();
        }

        private void SaleReportViewer_Load(object sender, EventArgs e)
        {
            SaleReport.LocalReport.DataSources.Clear();

            ReportDataSource rprtDTSource = new ReportDataSource("DataSet1", _ReportDt);
            // this.SaleReport.LocalReport.ReportEmbeddedResource = "salesreport.rdlc";
            ReportParameter rp = new ReportParameter("OpeningBalance", _openingbalance.ToString());
            SaleReport.LocalReport.SetParameters(new ReportParameter[] { rp });
            SaleReport.LocalReport.DataSources.Add(rprtDTSource);
            
            SaleReport.RefreshReport();

            
        }
    }
}
