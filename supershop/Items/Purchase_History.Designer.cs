namespace supershop.Items
{
    partial class Purchase_History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase_History));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.datagrdpurchasehistory = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.MyPrintPreviewDialog = new System.Windows.Forms.PageSetupDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnrefrash = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdpurchasehistory)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnrefrash);
            this.splitContainer1.Panel1.Controls.Add(this.comboItem);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dtStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dtEndDate);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrintReport);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.datagrdpurchasehistory);
            this.splitContainer1.Size = new System.Drawing.Size(982, 368);
            this.splitContainer1.SplitterDistance = 74;
            this.splitContainer1.TabIndex = 1;
            // 
            // comboItem
            // 
            this.comboItem.FormattingEnabled = true;
            this.comboItem.Location = new System.Drawing.Point(13, 26);
            this.comboItem.Name = "comboItem";
            this.comboItem.Size = new System.Drawing.Size(167, 21);
            this.comboItem.TabIndex = 93;
            this.comboItem.SelectedIndexChanged += new System.EventHandler(this.comboItem_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Purchase History by Item";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(186, 26);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(130, 21);
            this.dtStartDate.TabIndex = 90;
            this.toolTip1.SetToolTip(this.dtStartDate, "Please Select  Date 2 \r\n \r\nExample:  2014-10-29\r\nyyyy-mm-dd");
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
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
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(348, 26);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(141, 21);
            this.dtEndDate.TabIndex = 87;
            this.toolTip1.SetToolTip(this.dtEndDate, "Please Select  Date 2 \r\n \r\nExample:  2014-10-29\r\nyyyy-mm-dd");
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label9.Location = new System.Drawing.Point(183, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 13);
            this.label9.TabIndex = 88;
            this.label9.Text = "Purchase History by date";
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
            this.btnPrintReport.Location = new System.Drawing.Point(582, 17);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(46, 41);
            this.btnPrintReport.TabIndex = 9;
            this.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // datagrdpurchasehistory
            // 
            this.datagrdpurchasehistory.AllowUserToAddRows = false;
            this.datagrdpurchasehistory.AllowUserToDeleteRows = false;
            this.datagrdpurchasehistory.AllowUserToResizeColumns = false;
            this.datagrdpurchasehistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.datagrdpurchasehistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrdpurchasehistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrdpurchasehistory.BackgroundColor = System.Drawing.Color.White;
            this.datagrdpurchasehistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdpurchasehistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrdpurchasehistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrdpurchasehistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagrdpurchasehistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrdpurchasehistory.Location = new System.Drawing.Point(0, 0);
            this.datagrdpurchasehistory.Name = "datagrdpurchasehistory";
            this.datagrdpurchasehistory.ReadOnly = true;
            this.datagrdpurchasehistory.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.datagrdpurchasehistory.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagrdpurchasehistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdpurchasehistory.Size = new System.Drawing.Size(982, 290);
            this.datagrdpurchasehistory.TabIndex = 2;
            this.toolTip1.SetToolTip(this.datagrdpurchasehistory, "Click on Row to delete each record");
            this.datagrdpurchasehistory.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.datagrdpurchasehistory_ColumnAdded);
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
            // btnrefrash
            // 
            this.btnrefrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnrefrash.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnrefrash.FlatAppearance.BorderSize = 0;
            this.btnrefrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnrefrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnrefrash.Image = ((System.Drawing.Image)(resources.GetObject("btnrefrash.Image")));
            this.btnrefrash.Location = new System.Drawing.Point(493, 25);
            this.btnrefrash.Name = "btnrefrash";
            this.btnrefrash.Size = new System.Drawing.Size(25, 25);
            this.btnrefrash.TabIndex = 180;
            this.btnrefrash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnrefrash.UseVisualStyleBackColor = false;
            this.btnrefrash.Click += new System.EventHandler(this.btnrefrash_Click);
            // 
            // Purchase_History
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(982, 368);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Purchase_History";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdpurchasehistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.DataGridView datagrdpurchasehistory;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog MyPrintPreviewDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboItem;
        private System.Windows.Forms.Button btnrefrash;
    }
}