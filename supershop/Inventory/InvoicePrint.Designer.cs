namespace supershop.Inventory
{
    partial class InvoicePrint
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
            this.label1 = new System.Windows.Forms.Label();
            this.lnkClose = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.datagrdSalesInvoice = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.MyPrintPreviewDialog = new System.Windows.Forms.PageSetupDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdSalesInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Invoice No :";
            // 
            // lnkClose
            // 
            this.lnkClose.ActiveLinkColor = System.Drawing.Color.Black;
            this.lnkClose.AutoSize = true;
            this.lnkClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lnkClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnkClose.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lnkClose.Location = new System.Drawing.Point(778, 6);
            this.lnkClose.Name = "lnkClose";
            this.lnkClose.Size = new System.Drawing.Size(24, 24);
            this.lnkClose.TabIndex = 0;
            this.lnkClose.TabStop = true;
            this.lnkClose.Text = "X";
            this.lnkClose.Visible = false;
            this.lnkClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClose_LinkClicked);
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
            this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lnkClose);
            this.splitContainer1.Panel1.Controls.Add(this.lblInvoiceNo);
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Class_mouseMove);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.datagrdSalesInvoice);
            this.splitContainer1.Size = new System.Drawing.Size(810, 573);
            this.splitContainer1.SplitterDistance = 35;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Class_mouseMove);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(390, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(94, 10);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(19, 13);
            this.lblInvoiceNo.TabIndex = 2;
            this.lblInvoiceNo.Text = "11";
            // 
            // datagrdSalesInvoice
            // 
            this.datagrdSalesInvoice.AllowUserToAddRows = false;
            this.datagrdSalesInvoice.AllowUserToDeleteRows = false;
            this.datagrdSalesInvoice.AllowUserToResizeColumns = false;
            this.datagrdSalesInvoice.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.datagrdSalesInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrdSalesInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrdSalesInvoice.BackgroundColor = System.Drawing.Color.White;
            this.datagrdSalesInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagrdSalesInvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datagrdSalesInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdSalesInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrdSalesInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrdSalesInvoice.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagrdSalesInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrdSalesInvoice.Location = new System.Drawing.Point(0, 0);
            this.datagrdSalesInvoice.Name = "datagrdSalesInvoice";
            this.datagrdSalesInvoice.ReadOnly = true;
            this.datagrdSalesInvoice.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.datagrdSalesInvoice.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagrdSalesInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdSalesInvoice.Size = new System.Drawing.Size(810, 534);
            this.datagrdSalesInvoice.TabIndex = 4;
            this.datagrdSalesInvoice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Class_mouseMove);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // InvoicePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 573);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoicePrint";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InvoicePrint";
            this.Load += new System.EventHandler(this.InvoicePrint_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdSalesInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog MyPrintPreviewDialog;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView datagrdSalesInvoice;
    }
}