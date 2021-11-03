namespace supershop
{
    partial class salesreport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(salesreport));
            this.dtgrdViewSalesReport = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemSearchBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Report = new System.Windows.Forms.Button();
            this.lblReturnID = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.linkcustomersearch = new System.Windows.Forms.LinkLabel();
            this.linkOrderWay = new System.Windows.Forms.LinkLabel();
            this.comboCatagory = new System.Windows.Forms.ComboBox();
            this.linksalesman = new System.Windows.Forms.LinkLabel();
            this.comboItem = new System.Windows.Forms.ComboBox();
            this.ComboCustomer = new System.Windows.Forms.ComboBox();
            this.linkCategory = new System.Windows.Forms.LinkLabel();
            this.comboSalesman = new System.Windows.Forms.ComboBox();
            this.comboOrderWay = new System.Windows.Forms.ComboBox();
            this.LinkSalesByItem = new System.Windows.Forms.LinkLabel();
            this.lbleventname = new System.Windows.Forms.Label();
            this.btnprisatdis = new System.Windows.Forms.Button();
            this.btnReturnReport = new System.Windows.Forms.Button();
            this.DatetoDateSalesReport = new System.Windows.Forms.Button();
            this.DtodPaymentReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTO = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnRefrash = new System.Windows.Forms.Button();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.lblReportName = new System.Windows.Forms.Label();
            this.MyPrintPreviewDialog = new System.Windows.Forms.PageSetupDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdViewSalesReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgrdViewSalesReport
            // 
            this.dtgrdViewSalesReport.AllowUserToAddRows = false;
            this.dtgrdViewSalesReport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtgrdViewSalesReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgrdViewSalesReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrdViewSalesReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdViewSalesReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgrdViewSalesReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 13F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdViewSalesReport.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtgrdViewSalesReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdViewSalesReport.Location = new System.Drawing.Point(0, 0);
            this.dtgrdViewSalesReport.Name = "dtgrdViewSalesReport";
            this.dtgrdViewSalesReport.ReadOnly = true;
            this.dtgrdViewSalesReport.RowHeadersVisible = false;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dtgrdViewSalesReport.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgrdViewSalesReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrdViewSalesReport.Size = new System.Drawing.Size(951, 636);
            this.dtgrdViewSalesReport.TabIndex = 1;
            this.dtgrdViewSalesReport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdViewSalesReport_CellClick);
            this.dtgrdViewSalesReport.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnAdded);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(284, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Search Product Name , Id,  Sales No";
            // 
            // txtItemSearchBox
            // 
            this.txtItemSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemSearchBox.Font = new System.Drawing.Font("Times New Roman", 12.25F);
            this.txtItemSearchBox.Location = new System.Drawing.Point(281, 27);
            this.txtItemSearchBox.Name = "txtItemSearchBox";
            this.txtItemSearchBox.Size = new System.Drawing.Size(451, 26);
            this.txtItemSearchBox.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtItemSearchBox, "Search Sales Item Details \r\n\r\nSearch  by item Name  , Sales No ");
            this.txtItemSearchBox.TextChanged += new System.EventHandler(this.txtItemSearchBox_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lbleventname);
            this.splitContainer1.Panel1.Controls.Add(this.btnprisatdis);
            this.splitContainer1.Panel1.Controls.Add(this.btnReturnReport);
            this.splitContainer1.Panel1.Controls.Add(this.DatetoDateSalesReport);
            this.splitContainer1.Panel1.Controls.Add(this.DtodPaymentReport);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dateTO);
            this.splitContainer1.Panel1.Controls.Add(this.dateFrom);
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveAs);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.Black;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1268, 713);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.Report);
            this.groupBox1.Controls.Add(this.lblReturnID);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.linkcustomersearch);
            this.groupBox1.Controls.Add(this.linkOrderWay);
            this.groupBox1.Controls.Add(this.comboCatagory);
            this.groupBox1.Controls.Add(this.linksalesman);
            this.groupBox1.Controls.Add(this.comboItem);
            this.groupBox1.Controls.Add(this.ComboCustomer);
            this.groupBox1.Controls.Add(this.linkCategory);
            this.groupBox1.Controls.Add(this.comboSalesman);
            this.groupBox1.Controls.Add(this.comboOrderWay);
            this.groupBox1.Controls.Add(this.LinkSalesByItem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 318);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(313, 395);
            this.groupBox1.TabIndex = 187;
            this.groupBox1.TabStop = false;
            // 
            // Report
            // 
            this.Report.Location = new System.Drawing.Point(229, 44);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(84, 23);
            this.Report.TabIndex = 197;
            this.Report.Text = "Report";
            this.Report.UseVisualStyleBackColor = true;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // lblReturnID
            // 
            this.lblReturnID.AutoSize = true;
            this.lblReturnID.Font = new System.Drawing.Font("Microsoft Sans Serif", 2.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnID.Location = new System.Drawing.Point(5, 379);
            this.lblReturnID.Name = "lblReturnID";
            this.lblReturnID.Size = new System.Drawing.Size(4, 4);
            this.lblReturnID.TabIndex = 196;
            this.lblReturnID.Text = "-";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.Gold;
            this.btnSearch.Location = new System.Drawing.Point(12, 269);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(211, 42);
            this.btnSearch.TabIndex = 188;
            this.btnSearch.Text = "Search";
            this.toolTip1.SetToolTip(this.btnSearch, "Draft");
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // linkcustomersearch
            // 
            this.linkcustomersearch.AutoSize = true;
            this.linkcustomersearch.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkcustomersearch.Location = new System.Drawing.Point(12, 30);
            this.linkcustomersearch.Name = "linkcustomersearch";
            this.linkcustomersearch.Size = new System.Drawing.Size(95, 13);
            this.linkcustomersearch.TabIndex = 195;
            this.linkcustomersearch.TabStop = true;
            this.linkcustomersearch.Text = "Sales By Customer";
            this.linkcustomersearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkcustomersearch_LinkClicked);
            // 
            // linkOrderWay
            // 
            this.linkOrderWay.AutoSize = true;
            this.linkOrderWay.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkOrderWay.Location = new System.Drawing.Point(12, 214);
            this.linkOrderWay.Name = "linkOrderWay";
            this.linkOrderWay.Size = new System.Drawing.Size(102, 13);
            this.linkOrderWay.TabIndex = 194;
            this.linkOrderWay.TabStop = true;
            this.linkOrderWay.Text = "Sales By Order Way";
            this.linkOrderWay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOrderWay_LinkClicked);
            // 
            // comboCatagory
            // 
            this.comboCatagory.FormattingEnabled = true;
            this.comboCatagory.Location = new System.Drawing.Point(12, 138);
            this.comboCatagory.Name = "comboCatagory";
            this.comboCatagory.Size = new System.Drawing.Size(211, 21);
            this.comboCatagory.TabIndex = 182;
            // 
            // linksalesman
            // 
            this.linksalesman.AutoSize = true;
            this.linksalesman.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linksalesman.Location = new System.Drawing.Point(12, 169);
            this.linksalesman.Name = "linksalesman";
            this.linksalesman.Size = new System.Drawing.Size(98, 13);
            this.linksalesman.TabIndex = 193;
            this.linksalesman.TabStop = true;
            this.linksalesman.Text = "Sales By SalesMan";
            this.linksalesman.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linksalesman_LinkClicked);
            // 
            // comboItem
            // 
            this.comboItem.FormattingEnabled = true;
            this.comboItem.Location = new System.Drawing.Point(12, 93);
            this.comboItem.Name = "comboItem";
            this.comboItem.Size = new System.Drawing.Size(211, 21);
            this.comboItem.TabIndex = 180;
            // 
            // ComboCustomer
            // 
            this.ComboCustomer.FormattingEnabled = true;
            this.ComboCustomer.Location = new System.Drawing.Point(12, 46);
            this.ComboCustomer.Name = "ComboCustomer";
            this.ComboCustomer.Size = new System.Drawing.Size(211, 21);
            this.ComboCustomer.TabIndex = 178;
            // 
            // linkCategory
            // 
            this.linkCategory.AutoSize = true;
            this.linkCategory.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkCategory.Location = new System.Drawing.Point(12, 119);
            this.linkCategory.Name = "linkCategory";
            this.linkCategory.Size = new System.Drawing.Size(92, 13);
            this.linkCategory.TabIndex = 192;
            this.linkCategory.TabStop = true;
            this.linkCategory.Text = "Sales By category";
            this.linkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCategory_LinkClicked);
            // 
            // comboSalesman
            // 
            this.comboSalesman.FormattingEnabled = true;
            this.comboSalesman.Location = new System.Drawing.Point(12, 188);
            this.comboSalesman.Name = "comboSalesman";
            this.comboSalesman.Size = new System.Drawing.Size(211, 21);
            this.comboSalesman.TabIndex = 187;
            // 
            // comboOrderWay
            // 
            this.comboOrderWay.FormattingEnabled = true;
            this.comboOrderWay.Location = new System.Drawing.Point(12, 233);
            this.comboOrderWay.Name = "comboOrderWay";
            this.comboOrderWay.Size = new System.Drawing.Size(211, 21);
            this.comboOrderWay.TabIndex = 189;
            // 
            // LinkSalesByItem
            // 
            this.LinkSalesByItem.AutoSize = true;
            this.LinkSalesByItem.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LinkSalesByItem.Location = new System.Drawing.Point(12, 74);
            this.LinkSalesByItem.Name = "LinkSalesByItem";
            this.LinkSalesByItem.Size = new System.Drawing.Size(71, 13);
            this.LinkSalesByItem.TabIndex = 191;
            this.LinkSalesByItem.TabStop = true;
            this.LinkSalesByItem.Text = "Sales By Item";
            this.LinkSalesByItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSalesByItem_LinkClicked);
            // 
            // lbleventname
            // 
            this.lbleventname.AutoSize = true;
            this.lbleventname.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleventname.Location = new System.Drawing.Point(8, 5);
            this.lbleventname.Name = "lbleventname";
            this.lbleventname.Size = new System.Drawing.Size(3, 2);
            this.lbleventname.TabIndex = 75;
            this.lbleventname.Text = "-";
            // 
            // btnprisatdis
            // 
            this.btnprisatdis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnprisatdis.FlatAppearance.BorderSize = 0;
            this.btnprisatdis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprisatdis.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnprisatdis.ForeColor = System.Drawing.Color.Gold;
            this.btnprisatdis.Location = new System.Drawing.Point(12, 169);
            this.btnprisatdis.Name = "btnprisatdis";
            this.btnprisatdis.Size = new System.Drawing.Size(211, 38);
            this.btnprisatdis.TabIndex = 184;
            this.btnprisatdis.Text = "Sales By PreSet Discount";
            this.toolTip1.SetToolTip(this.btnprisatdis, "Draft");
            this.btnprisatdis.UseVisualStyleBackColor = false;
            this.btnprisatdis.Click += new System.EventHandler(this.btnprisatdis_Click);
            // 
            // btnReturnReport
            // 
            this.btnReturnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnReturnReport.FlatAppearance.BorderSize = 0;
            this.btnReturnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnReport.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnReturnReport.ForeColor = System.Drawing.Color.Red;
            this.btnReturnReport.Location = new System.Drawing.Point(12, 217);
            this.btnReturnReport.Name = "btnReturnReport";
            this.btnReturnReport.Size = new System.Drawing.Size(211, 38);
            this.btnReturnReport.TabIndex = 176;
            this.btnReturnReport.Text = "Return Report";
            this.toolTip1.SetToolTip(this.btnReturnReport, "Draft");
            this.btnReturnReport.UseVisualStyleBackColor = false;
            this.btnReturnReport.Click += new System.EventHandler(this.btnReturnReport_Click);
            // 
            // DatetoDateSalesReport
            // 
            this.DatetoDateSalesReport.BackColor = System.Drawing.Color.Blue;
            this.DatetoDateSalesReport.FlatAppearance.BorderSize = 0;
            this.DatetoDateSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DatetoDateSalesReport.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.DatetoDateSalesReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.DatetoDateSalesReport.Location = new System.Drawing.Point(12, 121);
            this.DatetoDateSalesReport.Name = "DatetoDateSalesReport";
            this.DatetoDateSalesReport.Size = new System.Drawing.Size(211, 38);
            this.DatetoDateSalesReport.TabIndex = 175;
            this.DatetoDateSalesReport.Text = "Date to Date Item Wise Report ";
            this.toolTip1.SetToolTip(this.DatetoDateSalesReport, "Draft");
            this.DatetoDateSalesReport.UseVisualStyleBackColor = false;
            this.DatetoDateSalesReport.Click += new System.EventHandler(this.DatetoDateSalesReport_Click);
            // 
            // DtodPaymentReport
            // 
            this.DtodPaymentReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.DtodPaymentReport.FlatAppearance.BorderSize = 0;
            this.DtodPaymentReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DtodPaymentReport.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.DtodPaymentReport.ForeColor = System.Drawing.Color.Green;
            this.DtodPaymentReport.Location = new System.Drawing.Point(12, 68);
            this.DtodPaymentReport.Name = "DtodPaymentReport";
            this.DtodPaymentReport.Size = new System.Drawing.Size(211, 41);
            this.DtodPaymentReport.TabIndex = 174;
            this.DtodPaymentReport.Text = "Date To Date Sales Cash Report";
            this.toolTip1.SetToolTip(this.DtodPaymentReport, "Draft");
            this.DtodPaymentReport.UseVisualStyleBackColor = false;
            this.DtodPaymentReport.Click += new System.EventHandler(this.DtodPaymentReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 95;
            this.label3.Text = "TO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "From";
            // 
            // dateTO
            // 
            this.dateTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTO.Location = new System.Drawing.Point(127, 29);
            this.dateTO.Name = "dateTO";
            this.dateTO.Size = new System.Drawing.Size(113, 24);
            this.dateTO.TabIndex = 83;
            this.toolTip1.SetToolTip(this.dateTO, "Please Select  Date 2 \r\n \r\nExample:  2014-10-29\r\nyyyy-mm-dd");
            this.dateTO.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(5, 29);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(116, 24);
            this.dateFrom.TabIndex = 83;
            this.toolTip1.SetToolTip(this.dateFrom, "Please Select  Date 2 \r\n \r\nExample:  2014-10-29\r\nyyyy-mm-dd");
            this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveAs.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSaveAs.FlatAppearance.BorderSize = 0;
            this.btnSaveAs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnSaveAs.ForeColor = System.Drawing.Color.Black;
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.Location = new System.Drawing.Point(103, 270);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(118, 39);
            this.btnSaveAs.TabIndex = 93;
            this.btnSaveAs.Text = "Save as";
            this.btnSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(9, 270);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 43);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.splitContainer2.Panel1.Controls.Add(this.btnRefrash);
            this.splitContainer2.Panel1.Controls.Add(this.pictureLogo);
            this.splitContainer2.Panel1.Controls.Add(this.lblReportName);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.txtItemSearchBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dtgrdViewSalesReport);
            this.splitContainer2.Size = new System.Drawing.Size(951, 713);
            this.splitContainer2.SplitterDistance = 73;
            this.splitContainer2.TabIndex = 2;
            // 
            // btnRefrash
            // 
            this.btnRefrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefrash.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefrash.FlatAppearance.BorderSize = 0;
            this.btnRefrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRefrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnRefrash.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrash.Image")));
            this.btnRefrash.Location = new System.Drawing.Point(738, 27);
            this.btnRefrash.Name = "btnRefrash";
            this.btnRefrash.Size = new System.Drawing.Size(25, 25);
            this.btnRefrash.TabIndex = 209;
            this.btnRefrash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefrash.UseVisualStyleBackColor = false;
            this.btnRefrash.Click += new System.EventHandler(this.btnRefrash_Click);
            // 
            // pictureLogo
            // 
            this.pictureLogo.Location = new System.Drawing.Point(819, 9);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(100, 50);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLogo.TabIndex = 74;
            this.pictureLogo.TabStop = false;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportName.Location = new System.Drawing.Point(3, 3);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(244, 29);
            this.lblReportName.TabIndex = 73;
            this.lblReportName.Text = "Daily Payment Report";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "SalesReport.csv";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // salesreport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1268, 713);
            this.Controls.Add(this.splitContainer1);
            this.Name = "salesreport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.salesreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdViewSalesReport)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgrdViewSalesReport;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemSearchBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PageSetupDialog MyPrintPreviewDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTO;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Button DtodPaymentReport;
        private System.Windows.Forms.Button DatetoDateSalesReport;
        private System.Windows.Forms.Button btnReturnReport;
        private System.Windows.Forms.ComboBox ComboCustomer;
        private System.Windows.Forms.ComboBox comboItem;
        private System.Windows.Forms.ComboBox comboCatagory;
        private System.Windows.Forms.Button btnprisatdis;
        private System.Windows.Forms.ComboBox comboSalesman;
        private System.Windows.Forms.ComboBox comboOrderWay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbleventname;
        private System.Windows.Forms.Button btnRefrash;
        private System.Windows.Forms.LinkLabel LinkSalesByItem;
        private System.Windows.Forms.LinkLabel linkCategory;
        private System.Windows.Forms.LinkLabel linksalesman;
        private System.Windows.Forms.LinkLabel linkOrderWay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkcustomersearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblReturnID;
        private System.Windows.Forms.Button Report;
    }
}