namespace supershop.Report
{
    partial class DeliveryReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryReport));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.txtReciptNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchCustCode = new System.Windows.Forms.Label();
            this.lblCustomerPage = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.comboCustomer = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.helplnk = new System.Windows.Forms.LinkLabel();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.lblReportName = new System.Windows.Forms.Label();
            this.lblENDdate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.datagrdReportDetails = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.MyPrintPreviewDialog = new System.Windows.Forms.PageSetupDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.btnSearchReceipt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.btnSearchReceipt);
            this.splitContainer1.Panel1.Controls.Add(this.btnCustomerSearch);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.txtReciptNO);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchCustCode);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustomerPage);
            this.splitContainer1.Panel1.Controls.Add(this.linkLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.comboCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.helplnk);
            this.splitContainer1.Panel1.Controls.Add(this.dtStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dtEndDate);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrintReport);
            this.splitContainer1.Panel1.Controls.Add(this.lblReportName);
            this.splitContainer1.Panel1.Controls.Add(this.lblENDdate);
            this.splitContainer1.Panel1.Controls.Add(this.lblStartDate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.datagrdReportDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1189, 505);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(296, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 225;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtReciptNO
            // 
            this.txtReciptNO.Location = new System.Drawing.Point(555, 50);
            this.txtReciptNO.Name = "txtReciptNO";
            this.txtReciptNO.Size = new System.Drawing.Size(156, 20);
            this.txtReciptNO.TabIndex = 224;
            this.txtReciptNO.TextChanged += new System.EventHandler(this.txtReciptNO_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(552, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 223;
            this.label1.Text = "Receipt No";
            // 
            // txtSearchCustCode
            // 
            this.txtSearchCustCode.AutoSize = true;
            this.txtSearchCustCode.Location = new System.Drawing.Point(496, 33);
            this.txtSearchCustCode.Name = "txtSearchCustCode";
            this.txtSearchCustCode.Size = new System.Drawing.Size(13, 13);
            this.txtSearchCustCode.TabIndex = 222;
            this.txtSearchCustCode.Text = "0";
            this.txtSearchCustCode.TextChanged += new System.EventHandler(this.txtSearchCustCode_TextChanged);
            // 
            // lblCustomerPage
            // 
            this.lblCustomerPage.AutoSize = true;
            this.lblCustomerPage.Location = new System.Drawing.Point(1060, 39);
            this.lblCustomerPage.Name = "lblCustomerPage";
            this.lblCustomerPage.Size = new System.Drawing.Size(10, 13);
            this.lblCustomerPage.TabIndex = 221;
            this.lblCustomerPage.Text = "-";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.Location = new System.Drawing.Point(333, 29);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(111, 16);
            this.linkLabel2.TabIndex = 220;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Customer Name :";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // comboCustomer
            // 
            this.comboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboCustomer.FormattingEnabled = true;
            this.comboCustomer.Location = new System.Drawing.Point(336, 49);
            this.comboCustomer.Name = "comboCustomer";
            this.comboCustomer.Size = new System.Drawing.Size(173, 21);
            this.comboCustomer.TabIndex = 219;
            this.comboCustomer.SelectedIndexChanged += new System.EventHandler(this.comboCustomer_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Crimson;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReset.Location = new System.Drawing.Point(830, 29);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(180, 37);
            this.btnReset.TabIndex = 160;
            this.btnReset.Text = "Back To DashBoard";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // helplnk
            // 
            this.helplnk.AutoSize = true;
            this.helplnk.Location = new System.Drawing.Point(981, 5);
            this.helplnk.Name = "helplnk";
            this.helplnk.Size = new System.Drawing.Size(29, 13);
            this.helplnk.TabIndex = 157;
            this.helplnk.TabStop = true;
            this.helplnk.Text = "Help";
            this.helplnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.helplnk_LinkClicked);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(15, 49);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(115, 21);
            this.dtStartDate.TabIndex = 90;
            this.toolTip1.SetToolTip(this.dtStartDate, "Please Select  Date 2 \r\n \r\nExample:  2014-10-29\r\nyyyy-mm-dd");
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "To";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(161, 49);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(127, 21);
            this.dtEndDate.TabIndex = 87;
            this.toolTip1.SetToolTip(this.dtEndDate, "Please Select  Date 2 \r\n \r\nExample:  2014-10-29\r\nyyyy-mm-dd");
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 16);
            this.label9.TabIndex = 88;
            this.label9.Text = "Report by date";
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrintReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrintReport.FlatAppearance.BorderSize = 0;
            this.btnPrintReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.Image")));
            this.btnPrintReport.Location = new System.Drawing.Point(750, 12);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(63, 65);
            this.btnPrintReport.TabIndex = 9;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblReportName.Location = new System.Drawing.Point(242, 9);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(32, 18);
            this.lblReportName.TabIndex = 2;
            this.lblReportName.Text = "___";
            // 
            // lblENDdate
            // 
            this.lblENDdate.AutoSize = true;
            this.lblENDdate.Location = new System.Drawing.Point(117, 9);
            this.lblENDdate.Name = "lblENDdate";
            this.lblENDdate.Size = new System.Drawing.Size(13, 13);
            this.lblENDdate.TabIndex = 1;
            this.lblENDdate.Text = "0";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(12, 9);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(31, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "____";
            // 
            // datagrdReportDetails
            // 
            this.datagrdReportDetails.AllowUserToAddRows = false;
            this.datagrdReportDetails.AllowUserToDeleteRows = false;
            this.datagrdReportDetails.AllowUserToResizeColumns = false;
            this.datagrdReportDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.datagrdReportDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrdReportDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrdReportDetails.BackgroundColor = System.Drawing.Color.White;
            this.datagrdReportDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdReportDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrdReportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrdReportDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagrdReportDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrdReportDetails.Location = new System.Drawing.Point(0, 0);
            this.datagrdReportDetails.Name = "datagrdReportDetails";
            this.datagrdReportDetails.ReadOnly = true;
            this.datagrdReportDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.datagrdReportDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagrdReportDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdReportDetails.Size = new System.Drawing.Size(1189, 419);
            this.datagrdReportDetails.TabIndex = 2;
            this.toolTip1.SetToolTip(this.datagrdReportDetails, "Click on Row for Details");
            this.datagrdReportDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellClick);
            this.datagrdReportDetails.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.datagrdReportDetails_ColumnAdded);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
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
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCustomerSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCustomerSearch.FlatAppearance.BorderSize = 0;
            this.btnCustomerSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCustomerSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCustomerSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerSearch.Image")));
            this.btnCustomerSearch.Location = new System.Drawing.Point(519, 46);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(25, 25);
            this.btnCustomerSearch.TabIndex = 226;
            this.btnCustomerSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCustomerSearch.UseVisualStyleBackColor = false;
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // btnSearchReceipt
            // 
            this.btnSearchReceipt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearchReceipt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearchReceipt.FlatAppearance.BorderSize = 0;
            this.btnSearchReceipt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSearchReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSearchReceipt.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchReceipt.Image")));
            this.btnSearchReceipt.Location = new System.Drawing.Point(719, 46);
            this.btnSearchReceipt.Name = "btnSearchReceipt";
            this.btnSearchReceipt.Size = new System.Drawing.Size(25, 25);
            this.btnSearchReceipt.TabIndex = 227;
            this.btnSearchReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearchReceipt.UseVisualStyleBackColor = false;
            this.btnSearchReceipt.Click += new System.EventHandler(this.btnSearchReceipt_Click);
            // 
            // DeliveryReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1189, 505);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeliveryReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Payble Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShortCutReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DataGridView datagrdReportDetails;
        private System.Windows.Forms.Label lblENDdate;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog MyPrintPreviewDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel helplnk;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ComboBox comboCustomer;
        private System.Windows.Forms.Label lblCustomerPage;
        private System.Windows.Forms.Label txtSearchCustCode;
        private System.Windows.Forms.TextBox txtReciptNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCustomerSearch;
        private System.Windows.Forms.Button btnSearchReceipt;
    }
}