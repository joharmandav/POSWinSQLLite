namespace supershop
{
    partial class ReciepeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReciepeReport));
            this.dtGrdLedgerReport = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRefreshReceipe = new System.Windows.Forms.Button();
            this.comboReceipe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.MyPrintPreviewDialog = new System.Windows.Forms.PageSetupDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdLedgerReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGrdLedgerReport
            // 
            this.dtGrdLedgerReport.AllowUserToAddRows = false;
            this.dtGrdLedgerReport.AllowUserToDeleteRows = false;
            this.dtGrdLedgerReport.AllowUserToResizeColumns = false;
            this.dtGrdLedgerReport.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGrdLedgerReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGrdLedgerReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrdLedgerReport.BackgroundColor = System.Drawing.Color.White;
            this.dtGrdLedgerReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrdLedgerReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGrdLedgerReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGrdLedgerReport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtGrdLedgerReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrdLedgerReport.Location = new System.Drawing.Point(0, 0);
            this.dtGrdLedgerReport.Name = "dtGrdLedgerReport";
            this.dtGrdLedgerReport.ReadOnly = true;
            this.dtGrdLedgerReport.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGrdLedgerReport.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtGrdLedgerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdLedgerReport.Size = new System.Drawing.Size(636, 272);
            this.dtGrdLedgerReport.TabIndex = 2;
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.btnRefreshReceipe);
            this.splitContainer1.Panel1.Controls.Add(this.comboReceipe);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrintReport);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtGrdLedgerReport);
            this.splitContainer1.Size = new System.Drawing.Size(636, 341);
            this.splitContainer1.SplitterDistance = 65;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnRefreshReceipe
            // 
            this.btnRefreshReceipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefreshReceipe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefreshReceipe.FlatAppearance.BorderSize = 0;
            this.btnRefreshReceipe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRefreshReceipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshReceipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnRefreshReceipe.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshReceipe.Image")));
            this.btnRefreshReceipe.Location = new System.Drawing.Point(293, 27);
            this.btnRefreshReceipe.Name = "btnRefreshReceipe";
            this.btnRefreshReceipe.Size = new System.Drawing.Size(25, 25);
            this.btnRefreshReceipe.TabIndex = 185;
            this.btnRefreshReceipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshReceipe.UseVisualStyleBackColor = false;
            this.btnRefreshReceipe.Click += new System.EventHandler(this.btnRefreshReceipe_Click);
            // 
            // comboReceipe
            // 
            this.comboReceipe.Font = new System.Drawing.Font("Times New Roman", 9.25F);
            this.comboReceipe.FormattingEnabled = true;
            this.comboReceipe.Location = new System.Drawing.Point(28, 27);
            this.comboReceipe.Name = "comboReceipe";
            this.comboReceipe.Size = new System.Drawing.Size(259, 23);
            this.comboReceipe.TabIndex = 184;
            this.toolTip1.SetToolTip(this.comboReceipe, "Please Select Item");
            this.comboReceipe.SelectedIndexChanged += new System.EventHandler(this.comboReceipe_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 183;
            this.label1.Text = "Select Receipe";
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrintReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrintReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrintReport.FlatAppearance.BorderSize = 0;
            this.btnPrintReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Uighur", 11.25F);
            this.btnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.Image")));
            this.btnPrintReport.Location = new System.Drawing.Point(481, 8);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(63, 54);
            this.btnPrintReport.TabIndex = 10;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnPrintReport, "Print Report");
            this.btnPrintReport.UseVisualStyleBackColor = false;
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
            // ReciepeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 341);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReciepeReport";
            this.Text = "ReciepeReport";
            this.Load += new System.EventHandler(this.ReciepeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdLedgerReport)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGrdLedgerReport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog MyPrintPreviewDialog;
        private System.Windows.Forms.Button btnRefreshReceipe;
        private System.Windows.Forms.ComboBox comboReceipe;
        private System.Windows.Forms.Label label1;
    }
}