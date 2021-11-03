namespace supershop.Report
{
    partial class SaleReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SaleReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Report = new supershop.Report.Report();
            this.SaleReportDtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleReportDtBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SaleReport
            // 
            this.SaleReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SaleReportDtBindingSource;
            this.SaleReport.LocalReport.DataSources.Add(reportDataSource1);
            this.SaleReport.LocalReport.ReportEmbeddedResource = "supershop.Report.SalesReport.rdlc";
            this.SaleReport.Location = new System.Drawing.Point(0, 0);
            this.SaleReport.Name = "SaleReport";
            this.SaleReport.Size = new System.Drawing.Size(1143, 612);
            this.SaleReport.TabIndex = 0;
            // 
            // Report
            // 
            this.Report.DataSetName = "Report";
            this.Report.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SaleReportDtBindingSource
            // 
            this.SaleReportDtBindingSource.DataMember = "SaleReportDt";
            this.SaleReportDtBindingSource.DataSource = this.Report;
            // 
            // SaleReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 612);
            this.Controls.Add(this.SaleReport);
            this.Name = "SaleReportViewer";
            this.Text = "SaleReportViewer";
            this.Load += new System.EventHandler(this.SaleReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleReportDtBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer SaleReport;
        private System.Windows.Forms.BindingSource SaleReportDtBindingSource;
        private Report Report;
    }
}