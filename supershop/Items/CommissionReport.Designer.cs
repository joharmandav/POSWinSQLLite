namespace supershop.Items
{
    partial class CommissionReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommissionReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnrefrash = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.datagrdReportDetails = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.MyPrintPreviewDialog = new System.Windows.Forms.PageSetupDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblFirstEmployee = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblFirstEmployee);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.comboEmployee);
            this.splitContainer1.Panel1.Controls.Add(this.dtEndDate);
            this.splitContainer1.Panel1.Controls.Add(this.dtStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.btnrefrash);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrintReport);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.datagrdReportDetails);
            this.splitContainer1.Size = new System.Drawing.Size(982, 368);
            this.splitContainer1.SplitterDistance = 74;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnrefrash
            // 
            this.btnrefrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnrefrash.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnrefrash.FlatAppearance.BorderSize = 0;
            this.btnrefrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnrefrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnrefrash.Image = ((System.Drawing.Image)(resources.GetObject("btnrefrash.Image")));
            this.btnrefrash.Location = new System.Drawing.Point(362, 22);
            this.btnrefrash.Name = "btnrefrash";
            this.btnrefrash.Size = new System.Drawing.Size(25, 25);
            this.btnrefrash.TabIndex = 180;
            this.btnrefrash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnrefrash.UseVisualStyleBackColor = false;
            this.btnrefrash.Click += new System.EventHandler(this.btnrefrash_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "To";
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrintReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrintReport.FlatAppearance.BorderSize = 0;
            this.btnPrintReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.Image")));
            this.btnPrintReport.Location = new System.Drawing.Point(685, 18);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(46, 41);
            this.btnPrintReport.TabIndex = 9;
            this.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // datagrdReportDetails
            // 
            this.datagrdReportDetails.AllowUserToAddRows = false;
            this.datagrdReportDetails.AllowUserToDeleteRows = false;
            this.datagrdReportDetails.AllowUserToResizeColumns = false;
            this.datagrdReportDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.datagrdReportDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.datagrdReportDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrdReportDetails.BackgroundColor = System.Drawing.Color.White;
            this.datagrdReportDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdReportDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.datagrdReportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 13F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrdReportDetails.DefaultCellStyle = dataGridViewCellStyle7;
            this.datagrdReportDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrdReportDetails.Location = new System.Drawing.Point(0, 0);
            this.datagrdReportDetails.Name = "datagrdReportDetails";
            this.datagrdReportDetails.ReadOnly = true;
            this.datagrdReportDetails.RowHeadersVisible = false;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.datagrdReportDetails.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.datagrdReportDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdReportDetails.Size = new System.Drawing.Size(982, 290);
            this.datagrdReportDetails.TabIndex = 2;
            this.toolTip1.SetToolTip(this.datagrdReportDetails, "Click on Row to delete each record");
            this.datagrdReportDetails.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.datagrdpurchasehistory_ColumnAdded);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(408, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 235;
            this.label4.Text = "Employee";
            // 
            // comboEmployee
            // 
            this.comboEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(411, 28);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(205, 24);
            this.comboEmployee.TabIndex = 234;
            this.comboEmployee.SelectedIndexChanged += new System.EventHandler(this.comboEmployee_SelectedIndexChanged);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(213, 26);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(130, 21);
            this.dtEndDate.TabIndex = 233;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(51, 26);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(130, 21);
            this.dtStartDate.TabIndex = 232;
            // 
            // lblFirstEmployee
            // 
            this.lblFirstEmployee.AutoSize = true;
            this.lblFirstEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstEmployee.Location = new System.Drawing.Point(606, 9);
            this.lblFirstEmployee.Name = "lblFirstEmployee";
            this.lblFirstEmployee.Size = new System.Drawing.Size(10, 13);
            this.lblFirstEmployee.TabIndex = 236;
            this.lblFirstEmployee.Text = "-";
            this.lblFirstEmployee.Visible = false;
            // 
            // CommissionReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(982, 368);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CommissionReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Commission Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.DataGridView datagrdReportDetails;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog MyPrintPreviewDialog;
        private System.Windows.Forms.Button btnrefrash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label lblFirstEmployee;
    }
}