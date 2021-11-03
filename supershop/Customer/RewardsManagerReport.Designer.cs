namespace supershop.Customer
{
    partial class RewardsManagerReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RewardsManagerReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewCreditLink = new System.Windows.Forms.Button();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.dtGrdvCustomerDetails = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.MyPrintPreviewDialog = new System.Windows.Forms.PageSetupDialog();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvCustomerDetails)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dtStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dtEndDate);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrintReport);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddNewCreditLink);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomerSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtGrdvCustomerDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1006, 476);
            this.splitContainer1.SplitterDistance = 56;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrintReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrintReport.FlatAppearance.BorderSize = 0;
            this.btnPrintReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Uighur", 11.25F);
            this.btnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.Image")));
            this.btnPrintReport.Location = new System.Drawing.Point(5, 0);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(63, 65);
            this.btnPrintReport.TabIndex = 10;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnPrintReport, "Print Report");
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Search ...";
            // 
            // btnAddNewCreditLink
            // 
            this.btnAddNewCreditLink.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddNewCreditLink.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddNewCreditLink.FlatAppearance.BorderSize = 0;
            this.btnAddNewCreditLink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddNewCreditLink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.btnAddNewCreditLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCreditLink.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewCreditLink.Image")));
            this.btnAddNewCreditLink.Location = new System.Drawing.Point(67, 3);
            this.btnAddNewCreditLink.Name = "btnAddNewCreditLink";
            this.btnAddNewCreditLink.Size = new System.Drawing.Size(146, 44);
            this.btnAddNewCreditLink.TabIndex = 30;
            this.btnAddNewCreditLink.Text = "Add Credit";
            this.btnAddNewCreditLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewCreditLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewCreditLink.UseVisualStyleBackColor = false;
            this.btnAddNewCreditLink.Click += new System.EventHandler(this.btnAddNewCustLink_Click);
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCustomerSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtCustomerSearch.Location = new System.Drawing.Point(266, 21);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(291, 20);
            this.txtCustomerSearch.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtCustomerSearch, "Info Search by : Name or Customer ID, Contact .... ");
            this.txtCustomerSearch.TextChanged += new System.EventHandler(this.txtCustomerSearch_TextChanged);
            // 
            // dtGrdvCustomerDetails
            // 
            this.dtGrdvCustomerDetails.AllowUserToAddRows = false;
            this.dtGrdvCustomerDetails.AllowUserToDeleteRows = false;
            this.dtGrdvCustomerDetails.AllowUserToResizeColumns = false;
            this.dtGrdvCustomerDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtGrdvCustomerDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGrdvCustomerDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrdvCustomerDetails.BackgroundColor = System.Drawing.Color.White;
            this.dtGrdvCustomerDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGrdvCustomerDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGrdvCustomerDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtGrdvCustomerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrdvCustomerDetails.Location = new System.Drawing.Point(0, 0);
            this.dtGrdvCustomerDetails.Name = "dtGrdvCustomerDetails";
            this.dtGrdvCustomerDetails.ReadOnly = true;
            this.dtGrdvCustomerDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            this.dtGrdvCustomerDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtGrdvCustomerDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdvCustomerDetails.Size = new System.Drawing.Size(1006, 416);
            this.dtGrdvCustomerDetails.TabIndex = 2;
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
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(662, 21);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(130, 21);
            this.dtStartDate.TabIndex = 86;
            this.toolTip1.SetToolTip(this.dtStartDate, "Please Select  Date 2 \r\n \r\nExample:  2014-10-29\r\nyyyy-mm-dd");
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(798, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "To";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(824, 21);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(141, 21);
            this.dtEndDate.TabIndex = 83;
            this.toolTip1.SetToolTip(this.dtEndDate, "Please Select  Date 2 \r\n \r\nExample:  2014-10-29\r\nyyyy-mm-dd");
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label9.Location = new System.Drawing.Point(659, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 84;
            this.label9.Text = "Report by date";
            // 
            // RewardsManagerReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1006, 476);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RewardsManagerReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store Credit and Rewards Manager Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RewardsManagerReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvCustomerDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewCreditLink;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dtGrdvCustomerDetails;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog MyPrintPreviewDialog;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label9;
    }
}