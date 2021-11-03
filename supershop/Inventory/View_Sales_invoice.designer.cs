namespace supershop
{
    partial class View_Sales_invoice
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
            this.label3 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblctype = new System.Windows.Forms.Label();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.btnDue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCustAddress = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblShippingfee = new System.Windows.Forms.Label();
            this.lblSalesDate = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgrvSalesInvoice = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblcustid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvSalesInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Phone:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(298, 68);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "Email: ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel1.Controls.Add(this.lblcustid);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtCondition);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.lblctype);
            this.splitContainer1.Panel1.Controls.Add(this.lblOrderStatus);
            this.splitContainer1.Panel1.Controls.Add(this.btnDue);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lblEmail);
            this.splitContainer1.Panel1.Controls.Add(this.lblPhone);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustAddress);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.lblShippingfee);
            this.splitContainer1.Panel1.Controls.Add(this.lblSalesDate);
            this.splitContainer1.Panel1.Controls.Add(this.lblInvoiceNo);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrvSalesInvoice);
            this.splitContainer1.Size = new System.Drawing.Size(872, 444);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(505, 26);
            this.txtCondition.Multiline = true;
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(224, 60);
            this.txtCondition.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(499, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Condition / Note";
            // 
            // lblctype
            // 
            this.lblctype.AutoSize = true;
            this.lblctype.Location = new System.Drawing.Point(474, 18);
            this.lblctype.Name = "lblctype";
            this.lblctype.Size = new System.Drawing.Size(10, 13);
            this.lblctype.TabIndex = 18;
            this.lblctype.Text = ".";
            this.lblctype.Visible = false;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Location = new System.Drawing.Point(21, 76);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(10, 13);
            this.lblOrderStatus.TabIndex = 17;
            this.lblOrderStatus.Text = ".";
            // 
            // btnDue
            // 
            this.btnDue.BackColor = System.Drawing.Color.Orange;
            this.btnDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDue.Location = new System.Drawing.Point(748, 46);
            this.btnDue.Name = "btnDue";
            this.btnDue.Size = new System.Drawing.Size(109, 25);
            this.btnDue.TabIndex = 14;
            this.btnDue.Text = "Take Payment";
            this.btnDue.UseVisualStyleBackColor = false;
            this.btnDue.Visible = false;
            this.btnDue.Click += new System.EventHandler(this.btnDue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Email: ";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(298, 52);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Phone:";
            // 
            // lblCustAddress
            // 
            this.lblCustAddress.AutoSize = true;
            this.lblCustAddress.Location = new System.Drawing.Point(257, 34);
            this.lblCustAddress.Name = "lblCustAddress";
            this.lblCustAddress.Size = new System.Drawing.Size(92, 13);
            this.lblCustAddress.TabIndex = 9;
            this.lblCustAddress.Text = "Customer Address";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(256, 12);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(104, 19);
            this.lblCustomer.TabIndex = 8;
            this.lblCustomer.Text = "Customer name";
            // 
            // lblShippingfee
            // 
            this.lblShippingfee.AutoSize = true;
            this.lblShippingfee.Location = new System.Drawing.Point(96, 61);
            this.lblShippingfee.Name = "lblShippingfee";
            this.lblShippingfee.Size = new System.Drawing.Size(69, 13);
            this.lblShippingfee.TabIndex = 7;
            this.lblShippingfee.Text = "Shipping Fee";
            // 
            // lblSalesDate
            // 
            this.lblSalesDate.AutoSize = true;
            this.lblSalesDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesDate.Location = new System.Drawing.Point(20, 21);
            this.lblSalesDate.Name = "lblSalesDate";
            this.lblSalesDate.Size = new System.Drawing.Size(38, 19);
            this.lblSalesDate.TabIndex = 6;
            this.lblSalesDate.Text = "Date";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(96, 43);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(25, 13);
            this.lblInvoiceNo.TabIndex = 5;
            this.lblInvoiceNo.Text = "000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Invoice No: ";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(748, 17);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(109, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgrvSalesInvoice
            // 
            this.dgrvSalesInvoice.AllowUserToAddRows = false;
            this.dgrvSalesInvoice.AllowUserToDeleteRows = false;
            this.dgrvSalesInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvSalesInvoice.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgrvSalesInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvSalesInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrvSalesInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvSalesInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrvSalesInvoice.Location = new System.Drawing.Point(0, 0);
            this.dgrvSalesInvoice.Name = "dgrvSalesInvoice";
            this.dgrvSalesInvoice.ReadOnly = true;
            this.dgrvSalesInvoice.RowHeadersVisible = false;
            this.dgrvSalesInvoice.Size = new System.Drawing.Size(872, 343);
            this.dgrvSalesInvoice.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Shipping Fee";
            // 
            // lblcustid
            // 
            this.lblcustid.AutoSize = true;
            this.lblcustid.Location = new System.Drawing.Point(257, 81);
            this.lblcustid.Name = "lblcustid";
            this.lblcustid.Size = new System.Drawing.Size(10, 13);
            this.lblcustid.TabIndex = 26;
            this.lblcustid.Text = ".";
            // 
            // View_Sales_invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(872, 444);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "View_Sales_invoice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Invoice";
            this.Load += new System.EventHandler(this.View_Sales_invoice_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvSalesInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCustAddress;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblShippingfee;
        private System.Windows.Forms.Label lblSalesDate;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgrvSalesInvoice;
        private System.Windows.Forms.Button btnDue;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.Label lblctype;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblcustid;
    }
}