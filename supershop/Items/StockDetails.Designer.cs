namespace supershop.Items
{
    partial class StockDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockDetails));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labl2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblRow = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datagridItemList = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnrefress = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridItemList)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnrefress);
            this.splitContainer1.Panel1.Controls.Add(this.labl2);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1060, 452);
            this.splitContainer1.SplitterDistance = 65;
            this.splitContainer1.TabIndex = 0;
            // 
            // labl2
            // 
            this.labl2.AutoSize = true;
            this.labl2.Location = new System.Drawing.Point(76, 9);
            this.labl2.Name = "labl2";
            this.labl2.Size = new System.Drawing.Size(172, 13);
            this.labl2.TabIndex = 1;
            this.labl2.Text = "Search by Item Code or Item Name";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtSearch.Location = new System.Drawing.Point(79, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(486, 24);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer2.Panel1.Controls.Add(this.btnExport);
            this.splitContainer2.Panel1.Controls.Add(this.lblRow);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer2.Panel2.Controls.Add(this.datagridItemList);
            this.splitContainer2.Size = new System.Drawing.Size(1060, 383);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.TabIndex = 0;
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
            this.btnExport.Location = new System.Drawing.Point(719, -4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(169, 40);
            this.btnExport.TabIndex = 93;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(590, 10);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(10, 13);
            this.lblRow.TabIndex = 3;
            this.lblRow.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(291, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "OUT STOCK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Check Stock";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IN STOCK";
            // 
            // datagridItemList
            // 
            this.datagridItemList.AllowUserToAddRows = false;
            this.datagridItemList.AllowUserToDeleteRows = false;
            this.datagridItemList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.datagridItemList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridItemList.BackgroundColor = System.Drawing.Color.White;
            this.datagridItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagridItemList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagridItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridItemList.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagridItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridItemList.Location = new System.Drawing.Point(0, 0);
            this.datagridItemList.Name = "datagridItemList";
            this.datagridItemList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridItemList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.datagridItemList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.datagridItemList.Size = new System.Drawing.Size(1060, 349);
            this.datagridItemList.TabIndex = 2;
            this.datagridItemList.Tag = "";
            this.datagridItemList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.datagridItemList_CellFormatting);
            this.datagridItemList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.datagridItemList_RowPostPaint);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "StockDetails.csv";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // btnrefress
            // 
            this.btnrefress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnrefress.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnrefress.FlatAppearance.BorderSize = 0;
            this.btnrefress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnrefress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnrefress.Image = ((System.Drawing.Image)(resources.GetObject("btnrefress.Image")));
            this.btnrefress.Location = new System.Drawing.Point(593, 26);
            this.btnrefress.Name = "btnrefress";
            this.btnrefress.Size = new System.Drawing.Size(25, 25);
            this.btnrefress.TabIndex = 173;
            this.btnrefress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnrefress.UseVisualStyleBackColor = false;
            this.btnrefress.Click += new System.EventHandler(this.btnrefress_Click);
            // 
            // StockDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1060, 452);
            this.Controls.Add(this.splitContainer1);
            this.Name = "StockDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Details";
            this.Load += new System.EventHandler(this.StockDetails_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridItemList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView datagridItemList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label labl2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnrefress;
    }
}