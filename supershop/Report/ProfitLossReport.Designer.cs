namespace supershop.Report
{
    partial class ProfitLossReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfitLossReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtgrdViewProfitLoss = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdViewProfitLoss)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgrdViewProfitLoss);
            this.splitContainer1.Size = new System.Drawing.Size(704, 494);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(102, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(166, 40);
            this.btnExport.TabIndex = 91;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(3, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 40);
            this.btnPrint.TabIndex = 90;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dtgrdViewProfitLoss
            // 
            this.dtgrdViewProfitLoss.AllowUserToAddRows = false;
            this.dtgrdViewProfitLoss.AllowUserToDeleteRows = false;
            this.dtgrdViewProfitLoss.AllowUserToResizeColumns = false;
            this.dtgrdViewProfitLoss.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtgrdViewProfitLoss.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgrdViewProfitLoss.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrdViewProfitLoss.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgrdViewProfitLoss.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdViewProfitLoss.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgrdViewProfitLoss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdViewProfitLoss.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdViewProfitLoss.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgrdViewProfitLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdViewProfitLoss.Location = new System.Drawing.Point(0, 0);
            this.dtgrdViewProfitLoss.Name = "dtgrdViewProfitLoss";
            this.dtgrdViewProfitLoss.ReadOnly = true;
            this.dtgrdViewProfitLoss.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dtgrdViewProfitLoss.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgrdViewProfitLoss.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgrdViewProfitLoss.Size = new System.Drawing.Size(704, 444);
            this.dtgrdViewProfitLoss.TabIndex = 2;
            this.dtgrdViewProfitLoss.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdViewProfitLoss_CellEndEdit);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "ProfitLossReport.csv";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // ProfitLossReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(704, 516);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfitLossReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profit Loss Report Summary";
            this.Load += new System.EventHandler(this.ProfitLossReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdViewProfitLoss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dtgrdViewProfitLoss;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnExport;

    }
}