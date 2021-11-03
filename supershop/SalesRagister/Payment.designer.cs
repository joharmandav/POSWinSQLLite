namespace supershop
{
    partial class Payment
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
            this.dgrvSalesItemList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustID = new System.Windows.Forms.Label();
            this.ComboCustID = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtDueAmount = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.txtChangeAmount = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.CombPayby = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblTotalPayable = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtVATRate = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblTotalVAT = new System.Windows.Forms.Label();
            this.lblTotalDisCount = new System.Windows.Forms.Label();
            this.txtDiscountRate = new System.Windows.Forms.TextBox();
            this.btnCompleteSalesAndPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtSalesDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.lbluser = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveOnly = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvSalesItemList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrvSalesItemList
            // 
            this.dgrvSalesItemList.AllowUserToAddRows = false;
            this.dgrvSalesItemList.AllowUserToResizeColumns = false;
            this.dgrvSalesItemList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.dgrvSalesItemList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrvSalesItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvSalesItemList.BackgroundColor = System.Drawing.Color.White;
            this.dgrvSalesItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvSalesItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrvSalesItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvSalesItemList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrvSalesItemList.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgrvSalesItemList.Location = new System.Drawing.Point(341, 231);
            this.dgrvSalesItemList.Name = "dgrvSalesItemList";
            this.dgrvSalesItemList.ReadOnly = true;
            this.dgrvSalesItemList.RowHeadersVisible = false;
            this.dgrvSalesItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrvSalesItemList.Size = new System.Drawing.Size(810, 192);
            this.dgrvSalesItemList.TabIndex = 94;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gold;
            this.groupBox1.Controls.Add(this.lblCustID);
            this.groupBox1.Controls.Add(this.ComboCustID);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.txtCustName);
            this.groupBox1.Controls.Add(this.txtDueAmount);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.txtPaidAmount);
            this.groupBox1.Controls.Add(this.txtChangeAmount);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.CombPayby);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 349);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Receive";
            // 
            // lblCustID
            // 
            this.lblCustID.AutoSize = true;
            this.lblCustID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblCustID.Location = new System.Drawing.Point(135, 194);
            this.lblCustID.Name = "lblCustID";
            this.lblCustID.Size = new System.Drawing.Size(55, 13);
            this.lblCustID.TabIndex = 102;
            this.lblCustID.Text = "10000009";
            // 
            // ComboCustID
            // 
            this.ComboCustID.FormattingEnabled = true;
            this.ComboCustID.Location = new System.Drawing.Point(136, 211);
            this.ComboCustID.Name = "ComboCustID";
            this.ComboCustID.Size = new System.Drawing.Size(147, 24);
            this.ComboCustID.TabIndex = 4;
            this.ComboCustID.Text = "Guest";
            this.toolTip1.SetToolTip(this.ComboCustID, "Select Register Customer. \r\nIf not leave it as a guest\r\n");
            this.ComboCustID.SelectedIndexChanged += new System.EventHandler(this.ComboCustID_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.label39.Location = new System.Drawing.Point(21, 94);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(105, 12);
            this.label39.TabIndex = 72;
            this.label39.Text = "Insert Customer amount";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.label36.Location = new System.Drawing.Point(86, 226);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(39, 12);
            this.label36.TabIndex = 71;
            this.label36.Text = "Optional";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.label35.Location = new System.Drawing.Point(87, 270);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(39, 12);
            this.label35.TabIndex = 70;
            this.label35.Text = "Optional";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(58, 253);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(68, 16);
            this.label34.TabIndex = 69;
            this.label34.Text = "Comment:";
            // 
            // txtCustName
            // 
            this.txtCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustName.Location = new System.Drawing.Point(136, 253);
            this.txtCustName.Multiline = true;
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(147, 80);
            this.txtCustName.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtCustName, "Comment/ Note");
            // 
            // txtDueAmount
            // 
            this.txtDueAmount.Enabled = false;
            this.txtDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDueAmount.Location = new System.Drawing.Point(136, 163);
            this.txtDueAmount.Name = "txtDueAmount";
            this.txtDueAmount.Size = new System.Drawing.Size(147, 26);
            this.txtDueAmount.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtDueAmount, "Due amount");
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Enabled = false;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(87, 169);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(39, 16);
            this.label26.TabIndex = 67;
            this.label26.Text = "Due :";
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidAmount.Location = new System.Drawing.Point(136, 70);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(147, 31);
            this.txtPaidAmount.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtPaidAmount, "Insert Customer amount");
            this.txtPaidAmount.TextChanged += new System.EventHandler(this.txtPaidAmount_TextChanged);
            this.txtPaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaidAmount_KeyPress);
            // 
            // txtChangeAmount
            // 
            this.txtChangeAmount.Enabled = false;
            this.txtChangeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChangeAmount.Location = new System.Drawing.Point(136, 118);
            this.txtChangeAmount.Name = "txtChangeAmount";
            this.txtChangeAmount.Size = new System.Drawing.Size(147, 26);
            this.txtChangeAmount.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtChangeAmount, "Change Amount to back customer");
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(55, 210);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 16);
            this.label21.TabIndex = 65;
            this.label21.Text = "Customer  :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Enabled = false;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(20, 125);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(109, 16);
            this.label20.TabIndex = 62;
            this.label20.Text = "Change Amount :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.label19.Location = new System.Drawing.Point(16, 72);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(114, 20);
            this.label19.TabIndex = 60;
            this.label19.Text = "Paid Amount :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 11.75F);
            this.label18.Location = new System.Drawing.Point(71, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 19);
            this.label18.TabIndex = 59;
            this.label18.Text = "Pay by :";
            // 
            // CombPayby
            // 
            this.CombPayby.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombPayby.FormattingEnabled = true;
            this.CombPayby.Items.AddRange(new object[] {
            "Cash",
            "Debit Card",
            "Credit Card",
            "Interac",
            "Check ",
            "Gift Card",
            "PayPal",
            "Skrill/MoneyBrooker",
            "Payza",
            "ApplePay",
            "PayTM",
            "MasterCard",
            "Bank TT",
            "Other[    ]"});
            this.CombPayby.Location = new System.Drawing.Point(136, 39);
            this.CombPayby.Name = "CombPayby";
            this.CombPayby.Size = new System.Drawing.Size(147, 26);
            this.CombPayby.TabIndex = 0;
            this.CombPayby.Text = "Cash";
            this.toolTip1.SetToolTip(this.CombPayby, "Select Payment Type");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblTotalItems);
            this.panel3.Controls.Add(this.lblsubtotal);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label32);
            this.panel3.Controls.Add(this.lblTotalPayable);
            this.panel3.Controls.Add(this.label29);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.txtVATRate);
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.lblTotalVAT);
            this.panel3.Controls.Add(this.lblTotalDisCount);
            this.panel3.Controls.Add(this.txtDiscountRate);
            this.panel3.Location = new System.Drawing.Point(341, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(810, 173);
            this.panel3.TabIndex = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label1.Location = new System.Drawing.Point(12, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 161;
            this.label1.Text = "Total Items:";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.lblTotalItems.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTotalItems.Location = new System.Drawing.Point(276, 150);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(19, 13);
            this.lblTotalItems.TabIndex = 160;
            this.lblTotalItems.Text = "00";
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.lblsubtotal.Location = new System.Drawing.Point(264, 58);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(75, 20);
            this.lblsubtotal.TabIndex = 141;
            this.lblsubtotal.Text = "-----------";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 140;
            this.label10.Text = "Sub Total";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(5, 107);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(471, 20);
            this.label32.TabIndex = 135;
            this.label32.Text = "==========================================";
            // 
            // lblTotalPayable
            // 
            this.lblTotalPayable.AutoSize = true;
            this.lblTotalPayable.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPayable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalPayable.Location = new System.Drawing.Point(264, 124);
            this.lblTotalPayable.Name = "lblTotalPayable";
            this.lblTotalPayable.Size = new System.Drawing.Size(87, 23);
            this.lblTotalPayable.TabIndex = 134;
            this.lblTotalPayable.Text = "-----------";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.label29.Location = new System.Drawing.Point(5, 5);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(51, 20);
            this.label29.TabIndex = 123;
            this.label29.Text = "Total:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Location = new System.Drawing.Point(5, 124);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(115, 20);
            this.label30.TabIndex = 125;
            this.label30.Text = "Total Payable:";
            // 
            // txtVATRate
            // 
            this.txtVATRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtVATRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVATRate.Location = new System.Drawing.Point(102, 89);
            this.txtVATRate.Name = "txtVATRate";
            this.txtVATRate.Size = new System.Drawing.Size(43, 13);
            this.txtVATRate.TabIndex = 3;
            this.txtVATRate.Text = "5";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(264, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(86, 20);
            this.lblTotal.TabIndex = 133;
            this.lblTotal.Text = "-----------";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(151, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 100;
            this.label12.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 16);
            this.label11.TabIndex = 131;
            this.label11.Text = "VAT Rate:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(149, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 102;
            this.label13.Text = "%";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(9, 34);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(87, 15);
            this.label28.TabIndex = 132;
            this.label28.Text = "Discount Rate:";
            // 
            // lblTotalVAT
            // 
            this.lblTotalVAT.AutoSize = true;
            this.lblTotalVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.lblTotalVAT.Location = new System.Drawing.Point(265, 84);
            this.lblTotalVAT.Name = "lblTotalVAT";
            this.lblTotalVAT.Size = new System.Drawing.Size(18, 20);
            this.lblTotalVAT.TabIndex = 49;
            this.lblTotalVAT.Text = "0";
            // 
            // lblTotalDisCount
            // 
            this.lblTotalDisCount.AutoSize = true;
            this.lblTotalDisCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.lblTotalDisCount.Location = new System.Drawing.Point(265, 34);
            this.lblTotalDisCount.Name = "lblTotalDisCount";
            this.lblTotalDisCount.Size = new System.Drawing.Size(18, 20);
            this.lblTotalDisCount.TabIndex = 51;
            this.lblTotalDisCount.Text = "0";
            // 
            // txtDiscountRate
            // 
            this.txtDiscountRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDiscountRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiscountRate.Location = new System.Drawing.Point(102, 35);
            this.txtDiscountRate.Name = "txtDiscountRate";
            this.txtDiscountRate.Size = new System.Drawing.Size(24, 13);
            this.txtDiscountRate.TabIndex = 2;
            this.txtDiscountRate.Text = "5";
            // 
            // btnCompleteSalesAndPrint
            // 
            this.btnCompleteSalesAndPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCompleteSalesAndPrint.FlatAppearance.BorderSize = 0;
            this.btnCompleteSalesAndPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteSalesAndPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.btnCompleteSalesAndPrint.ForeColor = System.Drawing.Color.Linen;
            this.btnCompleteSalesAndPrint.Location = new System.Drawing.Point(148, 407);
            this.btnCompleteSalesAndPrint.Name = "btnCompleteSalesAndPrint";
            this.btnCompleteSalesAndPrint.Size = new System.Drawing.Size(165, 29);
            this.btnCompleteSalesAndPrint.TabIndex = 1;
            this.btnCompleteSalesAndPrint.Text = "Complete Sale and Print";
            this.btnCompleteSalesAndPrint.UseVisualStyleBackColor = false;
            this.btnCompleteSalesAndPrint.Click += new System.EventHandler(this.btnCompleteSalesAndPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 153;
            this.label2.Text = "Sales Date";
            // 
            // dtSalesDate
            // 
            this.dtSalesDate.CustomFormat = "";
            this.dtSalesDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSalesDate.Location = new System.Drawing.Point(12, 25);
            this.dtSalesDate.Name = "dtSalesDate";
            this.dtSalesDate.Size = new System.Drawing.Size(301, 22);
            this.dtSalesDate.TabIndex = 152;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(338, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 157;
            this.label8.Text = "New Invoice No";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Enabled = false;
            this.txtInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoice.Location = new System.Drawing.Point(341, 24);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(810, 22);
            this.txtInvoice.TabIndex = 156;
            this.txtInvoice.Text = "1";
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lbluser.Location = new System.Drawing.Point(428, 6);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(15, 15);
            this.lbluser.TabIndex = 158;
            this.lbluser.Text = "--";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // btnSaveOnly
            // 
            this.btnSaveOnly.BackColor = System.Drawing.Color.Navy;
            this.btnSaveOnly.FlatAppearance.BorderSize = 0;
            this.btnSaveOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveOnly.ForeColor = System.Drawing.Color.Linen;
            this.btnSaveOnly.Location = new System.Drawing.Point(12, 407);
            this.btnSaveOnly.Name = "btnSaveOnly";
            this.btnSaveOnly.Size = new System.Drawing.Size(130, 29);
            this.btnSaveOnly.TabIndex = 159;
            this.btnSaveOnly.Text = "Only Save";
            this.btnSaveOnly.UseVisualStyleBackColor = false;
            this.btnSaveOnly.Click += new System.EventHandler(this.btnSaveOnly_Click);
            // 
            // Payment
            // 
            this.AcceptButton = this.btnCompleteSalesAndPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(325, 441);
            this.Controls.Add(this.btnSaveOnly);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtSalesDate);
            this.Controls.Add(this.btnCompleteSalesAndPrint);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgrvSalesItemList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvSalesItemList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvSalesItemList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCustID;
        private System.Windows.Forms.ComboBox ComboCustID;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtDueAmount;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.TextBox txtChangeAmount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox CombPayby;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblTotalPayable;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtVATRate;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblTotalVAT;
        private System.Windows.Forms.Label lblTotalDisCount;
        private System.Windows.Forms.TextBox txtDiscountRate;
        private System.Windows.Forms.Button btnCompleteSalesAndPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtSalesDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSaveOnly;
    }
}