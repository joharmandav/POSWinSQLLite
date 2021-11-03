namespace supershop
{
    partial class POSPrintRptonlysave
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
            this.pOSPrintPageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.psodbDataSet1 = new supershop.SalesRagister.psodbDataSet();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolsaleno = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolstrpProgressCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPrintDialog = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pOSPrintPageTableAdapter1 = new supershop.SalesRagister.psodbDataSetTableAdapters.POSPrintPageTableAdapter();
            this.timerpregress = new System.Windows.Forms.Timer(this.components);
            this.btnstopPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pOSPrintPageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psodbDataSet1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pOSPrintPageBindingSource
            // 
            this.pOSPrintPageBindingSource.DataMember = "POSPrintPage";
            this.pOSPrintPageBindingSource.DataSource = this.psodbDataSet1;
            // 
            // psodbDataSet1
            // 
            this.psodbDataSet1.DataSetName = "psodbDataSet";
            this.psodbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsaleno,
            this.toolStripProgressBar1,
            this.toolstrpProgressCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(487, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolsaleno
            // 
            this.toolsaleno.Name = "toolsaleno";
            this.toolsaleno.Size = new System.Drawing.Size(67, 17);
            this.toolsaleno.Text = "------------";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolstrpProgressCount
            // 
            this.toolstrpProgressCount.Name = "toolstrpProgressCount";
            this.toolstrpProgressCount.Size = new System.Drawing.Size(23, 17);
            this.toolstrpProgressCount.Text = "1%";
            // 
            // btnPrintDialog
            // 
            this.btnPrintDialog.FlatAppearance.BorderSize = 0;
            this.btnPrintDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintDialog.Location = new System.Drawing.Point(445, 0);
            this.btnPrintDialog.Name = "btnPrintDialog";
            this.btnPrintDialog.Size = new System.Drawing.Size(41, 23);
            this.btnPrintDialog.TabIndex = 2;
            this.btnPrintDialog.Text = "Print";
            this.btnPrintDialog.UseVisualStyleBackColor = true;
            this.btnPrintDialog.Click += new System.EventHandler(this.btnPrintDialog_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "POSPRINTDataSet";
            reportDataSource1.Value = this.pOSPrintPageBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "supershop.SalesRagister.RptPOSonlysave.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 22);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(487, 662);
            this.reportViewer1.TabIndex = 3;
            // 
            // pOSPrintPageTableAdapter1
            // 
            this.pOSPrintPageTableAdapter1.ClearBeforeFill = true;
            // 
            // timerpregress
            // 
            this.timerpregress.Interval = 1000;
            this.timerpregress.Tick += new System.EventHandler(this.timerpregress_Tick);
            // 
            // btnstopPrint
            // 
            this.btnstopPrint.FlatAppearance.BorderSize = 0;
            this.btnstopPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstopPrint.Location = new System.Drawing.Point(202, 0);
            this.btnstopPrint.Name = "btnstopPrint";
            this.btnstopPrint.Size = new System.Drawing.Size(75, 22);
            this.btnstopPrint.TabIndex = 162;
            this.btnstopPrint.Text = "Stop Print";
            this.btnstopPrint.UseVisualStyleBackColor = true;
            this.btnstopPrint.Click += new System.EventHandler(this.btnstopPrint_Click);
            // 
            // POSPrintRpt
            // 
            this.AcceptButton = this.btnPrintDialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 684);
            this.Controls.Add(this.btnstopPrint);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnPrintDialog);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POSPrintRpt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt Print";
            this.Load += new System.EventHandler(this.POSPrintRpt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pOSPrintPageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psodbDataSet1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolsaleno;
    //    private psodbDataSet psodbDataSet;
      //  private psodbDataSetTableAdapters.POSPrintPageTableAdapter pOSPrintPageTableAdapter;
        private System.Windows.Forms.Button btnPrintDialog;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SalesRagister.psodbDataSet psodbDataSet1;
        private System.Windows.Forms.BindingSource pOSPrintPageBindingSource;
        private SalesRagister.psodbDataSetTableAdapters.POSPrintPageTableAdapter pOSPrintPageTableAdapter1;
        private System.Windows.Forms.Timer timerpregress;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button btnstopPrint;
        private System.Windows.Forms.ToolStripStatusLabel toolstrpProgressCount;
    }
}