namespace supershop
{
    partial class BarcodeRDLC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeRDLC));
            this.purchaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnlink = new System.Windows.Forms.Button();
            this.btnSql = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cmbitems = new System.Windows.Forms.ComboBox();
            this.bntSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.UOMBOX = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // purchaseBindingSource
            // 
            this.purchaseBindingSource.DataMember = "purchase";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.purchaseBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "supershop.BarCode.RptBarcode.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(735, 402);
            this.reportViewer1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnlink);
            this.splitContainer1.Panel1.Controls.Add(this.btnSql);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.UOMBOX);
            this.splitContainer1.Panel1.Controls.Add(this.txtQuantity);
            this.splitContainer1.Panel1.Controls.Add(this.cmbitems);
            this.splitContainer1.Panel1.Controls.Add(this.bntSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(938, 402);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnlink
            // 
            this.btnlink.Location = new System.Drawing.Point(12, 320);
            this.btnlink.Name = "btnlink";
            this.btnlink.Size = new System.Drawing.Size(184, 23);
            this.btnlink.TabIndex = 6;
            this.btnlink.Text = "Advance Barcode Creator";
            this.btnlink.UseVisualStyleBackColor = true;
            this.btnlink.Click += new System.EventHandler(this.btnlink_Click);
            // 
            // btnSql
            // 
            this.btnSql.Location = new System.Drawing.Point(15, 248);
            this.btnSql.Name = "btnSql";
            this.btnSql.Size = new System.Drawing.Size(184, 23);
            this.btnSql.TabIndex = 5;
            this.btnSql.Text = "Only for SQL server";
            this.btnSql.UseVisualStyleBackColor = true;
            this.btnSql.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Product Code";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(12, 170);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(184, 20);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.Text = "15";
            this.toolTip1.SetToolTip(this.txtQuantity, "Input Qty . \r\nHow many times Do you need same product Barcode");
            // 
            // cmbitems
            // 
            this.cmbitems.FormattingEnabled = true;
            this.cmbitems.Location = new System.Drawing.Point(12, 56);
            this.cmbitems.Name = "cmbitems";
            this.cmbitems.Size = new System.Drawing.Size(184, 21);
            this.cmbitems.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cmbitems, "Select Product Id");
            this.cmbitems.SelectedIndexChanged += new System.EventHandler(this.cmbitems_SelectedIndexChanged);
            // 
            // bntSearch
            // 
            this.bntSearch.Location = new System.Drawing.Point(15, 201);
            this.bntSearch.Name = "bntSearch";
            this.bntSearch.Size = new System.Drawing.Size(184, 23);
            this.bntSearch.TabIndex = 0;
            this.bntSearch.Text = "Submit";
            this.bntSearch.UseVisualStyleBackColor = true;
            this.bntSearch.Click += new System.EventHandler(this.bntSearch_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 80000;
            this.toolTip1.BackColor = System.Drawing.Color.OliveDrab;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 1;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // UOMBOX
            // 
            this.UOMBOX.FormattingEnabled = true;
            this.UOMBOX.Location = new System.Drawing.Point(12, 110);
            this.UOMBOX.Name = "UOMBOX";
            this.UOMBOX.Size = new System.Drawing.Size(184, 21);
            this.UOMBOX.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "UOM";
            // 
            // BarcodeRDLC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(938, 402);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BarcodeRDLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BarcodeRDLC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BarcodeRDLC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
      //  private psodbDataSet psodbDataSet;
       // private psodbDataSetTableAdapters.purchaseTableAdapter purchaseTableAdapter;
        //yogesh private SalesRagister.psodbDataSet psodbDataSet1;
        private System.Windows.Forms.BindingSource purchaseBindingSource;
        //yogeshprivate SalesRagister.psodbDataSetTableAdapters.purchaseTableAdapter purchaseTableAdapter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmbitems;
        private System.Windows.Forms.Button bntSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSql;
        private System.Windows.Forms.Button btnlink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox UOMBOX;

    }
}