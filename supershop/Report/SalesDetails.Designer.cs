namespace supershop
{
    partial class SalesDetails
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
            this.lnkClose = new System.Windows.Forms.LinkLabel();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSalesID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.datagrdSalesDetails = new System.Windows.Forms.DataGridView();
            this.lblDue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDisCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdSalesDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkClose
            // 
            this.lnkClose.ActiveLinkColor = System.Drawing.Color.Black;
            this.lnkClose.AutoSize = true;
            this.lnkClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lnkClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnkClose.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lnkClose.Location = new System.Drawing.Point(1005, 3);
            this.lnkClose.Name = "lnkClose";
            this.lnkClose.Size = new System.Drawing.Size(24, 24);
            this.lnkClose.TabIndex = 0;
            this.lnkClose.TabStop = true;
            this.lnkClose.Text = "X";
            this.lnkClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClose_LinkClicked);
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(207, 9);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(37, 13);
            this.lblReceiptNo.TabIndex = 2;
            this.lblReceiptNo.Text = "00000";
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.lblSalesID);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrintReceipt);
            this.splitContainer1.Panel1.Controls.Add(this.lblReceiptNo);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lnkClose);
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Class_mouseMove);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1037, 399);
            this.splitContainer1.SplitterDistance = 29;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Class_mouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(344, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sales ID :";
            // 
            // lblSalesID
            // 
            this.lblSalesID.AutoSize = true;
            this.lblSalesID.Location = new System.Drawing.Point(426, 8);
            this.lblSalesID.Name = "lblSalesID";
            this.lblSalesID.Size = new System.Drawing.Size(37, 13);
            this.lblSalesID.TabIndex = 4;
            this.lblSalesID.Text = "00000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Receipt No :";
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.Location = new System.Drawing.Point(858, 3);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(116, 23);
            this.btnPrintReceipt.TabIndex = 1;
            this.btnPrintReceipt.Text = "Print Receipt";
            this.btnPrintReceipt.UseVisualStyleBackColor = true;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sales Detals";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.datagrdSalesDetails);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.splitContainer2.Panel2.Controls.Add(this.lblDue);
            this.splitContainer2.Panel2.Controls.Add(this.label11);
            this.splitContainer2.Panel2.Controls.Add(this.lblChange);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.lblTotal);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.lblSubTotal);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.lblVat);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.lblDisCount);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Class_mouseMove);
            this.splitContainer2.Size = new System.Drawing.Size(1037, 366);
            this.splitContainer2.SplitterDistance = 336;
            this.splitContainer2.TabIndex = 4;
            // 
            // datagrdSalesDetails
            // 
            this.datagrdSalesDetails.AllowUserToAddRows = false;
            this.datagrdSalesDetails.AllowUserToDeleteRows = false;
            this.datagrdSalesDetails.AllowUserToResizeColumns = false;
            this.datagrdSalesDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.datagrdSalesDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrdSalesDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrdSalesDetails.BackgroundColor = System.Drawing.Color.White;
            this.datagrdSalesDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdSalesDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrdSalesDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrdSalesDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagrdSalesDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrdSalesDetails.Location = new System.Drawing.Point(0, 0);
            this.datagrdSalesDetails.Name = "datagrdSalesDetails";
            this.datagrdSalesDetails.ReadOnly = true;
            this.datagrdSalesDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.datagrdSalesDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagrdSalesDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdSalesDetails.Size = new System.Drawing.Size(1037, 336);
            this.datagrdSalesDetails.TabIndex = 3;
            this.datagrdSalesDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Class_mouseMove);
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.Location = new System.Drawing.Point(664, 8);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(13, 13);
            this.lblDue.TabIndex = 15;
            this.lblDue.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(589, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Due Amount:";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Location = new System.Drawing.Point(513, 7);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(13, 13);
            this.lblChange.TabIndex = 13;
            this.lblChange.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(426, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Change Amount:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(845, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "00.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(804, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total: ";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(362, 8);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(13, 13);
            this.lblSubTotal.TabIndex = 9;
            this.lblSubTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sub total:";
            // 
            // lblVat
            // 
            this.lblVat.AutoSize = true;
            this.lblVat.Location = new System.Drawing.Point(218, 7);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(34, 13);
            this.lblVat.TabIndex = 7;
            this.lblVat.Text = "00.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vat:";
            // 
            // lblDisCount
            // 
            this.lblDisCount.AutoSize = true;
            this.lblDisCount.Location = new System.Drawing.Point(90, 6);
            this.lblDisCount.Name = "lblDisCount";
            this.lblDisCount.Size = new System.Drawing.Size(34, 13);
            this.lblDisCount.TabIndex = 5;
            this.lblDisCount.Text = "00.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Discount:";
            // 
            // SalesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 399);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Details";
            this.Load += new System.EventHandler(this.SalesDetails_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Class_mouseMove);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdSalesDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkClose;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView datagrdSalesDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDisCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSalesID;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label9;
    }
}