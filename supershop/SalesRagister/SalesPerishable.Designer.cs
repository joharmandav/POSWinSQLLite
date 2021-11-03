namespace supershop
{
    partial class SalesPerishable
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
            this.dtPerishableSalesTemp = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnColse = new System.Windows.Forms.Button();
            this.lblproductName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMYSYSNAME = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMYTRANSID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUom = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblprodid = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.selectBatch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtPerishableSalesTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtPerishableSalesTemp
            // 
            this.dtPerishableSalesTemp.AllowUserToAddRows = false;
            this.dtPerishableSalesTemp.AllowUserToDeleteRows = false;
            this.dtPerishableSalesTemp.AllowUserToResizeColumns = false;
            this.dtPerishableSalesTemp.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtPerishableSalesTemp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtPerishableSalesTemp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtPerishableSalesTemp.BackgroundColor = System.Drawing.Color.White;
            this.dtPerishableSalesTemp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtPerishableSalesTemp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtPerishableSalesTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtPerishableSalesTemp.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtPerishableSalesTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtPerishableSalesTemp.Location = new System.Drawing.Point(0, 0);
            this.dtPerishableSalesTemp.Name = "dtPerishableSalesTemp";
            this.dtPerishableSalesTemp.ReadOnly = true;
            this.dtPerishableSalesTemp.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dtPerishableSalesTemp.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtPerishableSalesTemp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPerishableSalesTemp.Size = new System.Drawing.Size(531, 134);
            this.dtPerishableSalesTemp.TabIndex = 2;
            this.dtPerishableSalesTemp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPerishableSalesTemp_CellContentClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(4, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.selectBatch);
            this.splitContainer1.Panel1.Controls.Add(this.btnColse);
            this.splitContainer1.Panel1.Controls.Add(this.lblproductName);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lblTotalQty);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblMYSYSNAME);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.lblMYTRANSID);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.lblUom);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.lblprodid);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtPerishableSalesTemp);
            this.splitContainer1.Size = new System.Drawing.Size(531, 196);
            this.splitContainer1.SplitterDistance = 58;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnColse
            // 
            this.btnColse.BackColor = System.Drawing.Color.Red;
            this.btnColse.FlatAppearance.BorderSize = 0;
            this.btnColse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnColse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnColse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColse.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColse.ForeColor = System.Drawing.SystemColors.Window;
            this.btnColse.Location = new System.Drawing.Point(501, 3);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(28, 28);
            this.btnColse.TabIndex = 124;
            this.btnColse.Text = "X";
            this.btnColse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColse.UseVisualStyleBackColor = false;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // lblproductName
            // 
            this.lblproductName.AutoSize = true;
            this.lblproductName.ForeColor = System.Drawing.Color.Black;
            this.lblproductName.Location = new System.Drawing.Point(213, 10);
            this.lblproductName.Name = "lblproductName";
            this.lblproductName.Size = new System.Drawing.Size(10, 13);
            this.lblproductName.TabIndex = 123;
            this.lblproductName.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "Product Name:";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.ForeColor = System.Drawing.Color.Black;
            this.lblTotalQty.Location = new System.Drawing.Point(402, 10);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(10, 13);
            this.lblTotalQty.TabIndex = 121;
            this.lblTotalQty.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 120;
            this.label2.Text = "Total Qty : ";
            // 
            // lblMYSYSNAME
            // 
            this.lblMYSYSNAME.AutoSize = true;
            this.lblMYSYSNAME.ForeColor = System.Drawing.Color.Black;
            this.lblMYSYSNAME.Location = new System.Drawing.Point(405, 34);
            this.lblMYSYSNAME.Name = "lblMYSYSNAME";
            this.lblMYSYSNAME.Size = new System.Drawing.Size(10, 13);
            this.lblMYSYSNAME.TabIndex = 119;
            this.lblMYSYSNAME.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(347, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 118;
            this.label10.Text = "SysName : ";
            // 
            // lblMYTRANSID
            // 
            this.lblMYTRANSID.AutoSize = true;
            this.lblMYTRANSID.ForeColor = System.Drawing.Color.Black;
            this.lblMYTRANSID.Location = new System.Drawing.Point(213, 34);
            this.lblMYTRANSID.Name = "lblMYTRANSID";
            this.lblMYTRANSID.Size = new System.Drawing.Size(10, 13);
            this.lblMYTRANSID.TabIndex = 117;
            this.lblMYTRANSID.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 116;
            this.label8.Text = "MTransID : ";
            // 
            // lblUom
            // 
            this.lblUom.AutoSize = true;
            this.lblUom.ForeColor = System.Drawing.Color.Black;
            this.lblUom.Location = new System.Drawing.Point(43, 34);
            this.lblUom.Name = "lblUom";
            this.lblUom.Size = new System.Drawing.Size(10, 13);
            this.lblUom.TabIndex = 115;
            this.lblUom.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 114;
            this.label9.Text = "Uom : ";
            // 
            // lblprodid
            // 
            this.lblprodid.AutoSize = true;
            this.lblprodid.ForeColor = System.Drawing.Color.Black;
            this.lblprodid.Location = new System.Drawing.Point(43, 10);
            this.lblprodid.Name = "lblprodid";
            this.lblprodid.Size = new System.Drawing.Size(10, 13);
            this.lblprodid.TabIndex = 113;
            this.lblprodid.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 112;
            this.label6.Text = "PID:";
            // 
            // selectBatch
            // 
            this.selectBatch.AutoSize = true;
            this.selectBatch.ForeColor = System.Drawing.Color.Black;
            this.selectBatch.Location = new System.Drawing.Point(268, 45);
            this.selectBatch.Name = "selectBatch";
            this.selectBatch.Size = new System.Drawing.Size(10, 13);
            this.selectBatch.TabIndex = 125;
            this.selectBatch.Text = "-";
            this.selectBatch.Visible = false;
            // 
            // SalesPerishable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(538, 199);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesPerishable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesPerishable";
            this.Load += new System.EventHandler(this.SalesPerishable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtPerishableSalesTemp)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtPerishableSalesTemp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblMYSYSNAME;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMYTRANSID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblprodid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblproductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnColse;
        private System.Windows.Forms.Label selectBatch;

    }
}