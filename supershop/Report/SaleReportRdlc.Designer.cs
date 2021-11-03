namespace supershop.Report
{
    partial class SaleReportRdlc
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
            this.salespaymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.psodbDataSet = new supershop.SalesRagister.psodbDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sales_paymentTableAdapter = new supershop.SalesRagister.psodbDataSetTableAdapters.sales_paymentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.salespaymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psodbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // salespaymentBindingSource
            // 
            this.salespaymentBindingSource.DataMember = "sales_payment";
            this.salespaymentBindingSource.DataSource = this.psodbDataSet;
            // 
            // psodbDataSet
            // 
            this.psodbDataSet.DataSetName = "psodbDataSet";
            this.psodbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.salespaymentBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "supershop.Report.ReportSales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(961, 741);
            this.reportViewer1.TabIndex = 0;
            // 
            // sales_paymentTableAdapter
            // 
            this.sales_paymentTableAdapter.ClearBeforeFill = true;
            // 
            // SaleReportRdlc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 741);
            this.Controls.Add(this.reportViewer1);
            this.MinimizeBox = false;
            this.Name = "SaleReportRdlc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report ";
            this.Load += new System.EventHandler(this.SaleReportRdlc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salespaymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psodbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SalesRagister.psodbDataSet psodbDataSet;
        private System.Windows.Forms.BindingSource salespaymentBindingSource;
        private SalesRagister.psodbDataSetTableAdapters.sales_paymentTableAdapter sales_paymentTableAdapter;
    }
}