namespace supershop.Inventory
{
    partial class Add_Sales
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
            this.dgrvSalesItemList = new System.Windows.Forms.DataGridView();
            this.txtBarcodeReaderBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtSalesDate = new System.Windows.Forms.DateTimePicker();
            this.txtinvoiceNo = new System.Windows.Forms.TextBox();
            this.CmbWarehouse = new System.Windows.Forms.ComboBox();
            this.CmbBiller = new System.Windows.Forms.ComboBox();
            this.CmbCustomer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalDisCount = new System.Windows.Forms.Label();
            this.lblTotalVAT = new System.Windows.Forms.Label();
            this.txtShippingFee = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTotalPayable = new System.Windows.Forms.Label();
            this.lblAddStockItem = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnIncreaseDisCount = new System.Windows.Forms.Button();
            this.btnDecreaseDiscount = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.txtDiscountRate = new System.Windows.Forms.TextBox();
            this.btnIncreaseVAT = new System.Windows.Forms.Button();
            this.btnDeCreaseVAT = new System.Windows.Forms.Button();
            this.txtVATRate = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lnkAddCust = new System.Windows.Forms.LinkLabel();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.lbloveralldiscount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timer_InvoiceNoRefresh = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblCustID = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.PanelStockList = new System.Windows.Forms.Panel();
            this.flowLayoutPanelUserList = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.lblInvoiceNO = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvSalesItemList)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PanelStockList.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrvSalesItemList
            // 
            this.dgrvSalesItemList.AllowUserToAddRows = false;
            this.dgrvSalesItemList.AllowUserToResizeColumns = false;
            this.dgrvSalesItemList.AllowUserToResizeRows = false;
            this.dgrvSalesItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvSalesItemList.BackgroundColor = System.Drawing.Color.White;
            this.dgrvSalesItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvSalesItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrvSalesItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvSalesItemList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrvSalesItemList.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgrvSalesItemList.Location = new System.Drawing.Point(303, 106);
            this.dgrvSalesItemList.Name = "dgrvSalesItemList";
            this.dgrvSalesItemList.RowHeadersVisible = false;
            this.dgrvSalesItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrvSalesItemList.Size = new System.Drawing.Size(579, 204);
            this.dgrvSalesItemList.TabIndex = 95;
            this.dgrvSalesItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvSalesItemList_CellClick);
            this.dgrvSalesItemList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvSalesItemList_CellEndEdit);
            // 
            // txtBarcodeReaderBox
            // 
            this.txtBarcodeReaderBox.BackColor = System.Drawing.SystemColors.Menu;
            this.txtBarcodeReaderBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcodeReaderBox.Location = new System.Drawing.Point(303, 76);
            this.txtBarcodeReaderBox.Name = "txtBarcodeReaderBox";
            this.txtBarcodeReaderBox.Size = new System.Drawing.Size(579, 22);
            this.txtBarcodeReaderBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtBarcodeReaderBox, "Insert item Bar-code with Barcode Reader");
            this.txtBarcodeReaderBox.Click += new System.EventHandler(this.txtBarcodeReaderBox_Click);
            this.txtBarcodeReaderBox.TextChanged += new System.EventHandler(this.txtBarcodeReaderBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 97;
            this.label2.Text = "Invoice No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Warehouse  *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Biller   *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Customer   *";
            // 
            // dtSalesDate
            // 
            this.dtSalesDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalesDate.CustomFormat = "";
            this.dtSalesDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSalesDate.Location = new System.Drawing.Point(42, 76);
            this.dtSalesDate.Name = "dtSalesDate";
            this.dtSalesDate.Size = new System.Drawing.Size(222, 26);
            this.dtSalesDate.TabIndex = 1;
            // 
            // txtinvoiceNo
            // 
            this.txtinvoiceNo.Location = new System.Drawing.Point(42, 122);
            this.txtinvoiceNo.Name = "txtinvoiceNo";
            this.txtinvoiceNo.ReadOnly = true;
            this.txtinvoiceNo.Size = new System.Drawing.Size(222, 20);
            this.txtinvoiceNo.TabIndex = 2;
            this.txtinvoiceNo.Text = "1";
            // 
            // CmbWarehouse
            // 
            this.CmbWarehouse.FormattingEnabled = true;
            this.CmbWarehouse.Items.AddRange(new object[] {
            "Warehouse-1",
            "Warehouse-2"});
            this.CmbWarehouse.Location = new System.Drawing.Point(42, 162);
            this.CmbWarehouse.Name = "CmbWarehouse";
            this.CmbWarehouse.Size = new System.Drawing.Size(222, 21);
            this.CmbWarehouse.TabIndex = 3;
            this.toolTip1.SetToolTip(this.CmbWarehouse, "Please Select WareHouse");
            // 
            // CmbBiller
            // 
            this.CmbBiller.FormattingEnabled = true;
            this.CmbBiller.Location = new System.Drawing.Point(42, 204);
            this.CmbBiller.Name = "CmbBiller";
            this.CmbBiller.Size = new System.Drawing.Size(222, 21);
            this.CmbBiller.TabIndex = 4;
            // 
            // CmbCustomer
            // 
            this.CmbCustomer.FormattingEnabled = true;
            this.CmbCustomer.Location = new System.Drawing.Point(42, 248);
            this.CmbCustomer.Name = "CmbCustomer";
            this.CmbCustomer.Size = new System.Drawing.Size(222, 21);
            this.CmbCustomer.TabIndex = 5;
            this.CmbCustomer.Text = "Guest";
            this.CmbCustomer.SelectedIndexChanged += new System.EventHandler(this.CmbCustomer_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Barcode Scanner";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 25);
            this.label8.TabIndex = 109;
            this.label8.Text = "Add Sale";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(228, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 110;
            this.label9.Text = "Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(230, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 16);
            this.label11.TabIndex = 112;
            this.label11.Text = "Shipping fee";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(230, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 16);
            this.label12.TabIndex = 113;
            this.label12.Text = "Invoice Tax";
            this.toolTip1.SetToolTip(this.label12, "(+) Increase VAT Rate   ");
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(446, 11);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(15, 16);
            this.lblTotal.TabIndex = 114;
            this.lblTotal.Text = "0";
            // 
            // lblTotalDisCount
            // 
            this.lblTotalDisCount.AutoSize = true;
            this.lblTotalDisCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDisCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDisCount.Location = new System.Drawing.Point(446, 39);
            this.lblTotalDisCount.Name = "lblTotalDisCount";
            this.lblTotalDisCount.Size = new System.Drawing.Size(15, 16);
            this.lblTotalDisCount.TabIndex = 115;
            this.lblTotalDisCount.Text = "0";
            // 
            // lblTotalVAT
            // 
            this.lblTotalVAT.AutoSize = true;
            this.lblTotalVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVAT.ForeColor = System.Drawing.Color.Black;
            this.lblTotalVAT.Location = new System.Drawing.Point(446, 90);
            this.lblTotalVAT.Name = "lblTotalVAT";
            this.lblTotalVAT.Size = new System.Drawing.Size(15, 16);
            this.lblTotalVAT.TabIndex = 116;
            this.lblTotalVAT.Text = "0";
            // 
            // txtShippingFee
            // 
            this.txtShippingFee.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtShippingFee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShippingFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShippingFee.ForeColor = System.Drawing.Color.Black;
            this.txtShippingFee.Location = new System.Drawing.Point(449, 119);
            this.txtShippingFee.Name = "txtShippingFee";
            this.txtShippingFee.Size = new System.Drawing.Size(117, 15);
            this.txtShippingFee.TabIndex = 0;
            this.txtShippingFee.Text = "0";
            this.txtShippingFee.TextChanged += new System.EventHandler(this.txtShippingFee_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnSubmit.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubmit.Location = new System.Drawing.Point(42, 350);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(222, 28);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(230, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 16);
            this.label16.TabIndex = 119;
            this.label16.Text = "Total Payable";
            // 
            // lblTotalPayable
            // 
            this.lblTotalPayable.AutoSize = true;
            this.lblTotalPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.lblTotalPayable.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPayable.Location = new System.Drawing.Point(445, 155);
            this.lblTotalPayable.Name = "lblTotalPayable";
            this.lblTotalPayable.Size = new System.Drawing.Size(18, 20);
            this.lblTotalPayable.TabIndex = 120;
            this.lblTotalPayable.Text = "0";
            // 
            // lblAddStockItem
            // 
            this.lblAddStockItem.AutoSize = true;
            this.lblAddStockItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddStockItem.Location = new System.Drawing.Point(752, 52);
            this.lblAddStockItem.Name = "lblAddStockItem";
            this.lblAddStockItem.Size = new System.Drawing.Size(130, 20);
            this.lblAddStockItem.TabIndex = 121;
            this.lblAddStockItem.TabStop = true;
            this.lblAddStockItem.Text = "(+) Stock item list";
            this.lblAddStockItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddStockItem_LinkClicked);
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
            // btnIncreaseDisCount
            // 
            this.btnIncreaseDisCount.FlatAppearance.BorderSize = 0;
            this.btnIncreaseDisCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseDisCount.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncreaseDisCount.ForeColor = System.Drawing.Color.Black;
            this.btnIncreaseDisCount.Location = new System.Drawing.Point(16, 122);
            this.btnIncreaseDisCount.Name = "btnIncreaseDisCount";
            this.btnIncreaseDisCount.Size = new System.Drawing.Size(19, 27);
            this.btnIncreaseDisCount.TabIndex = 145;
            this.btnIncreaseDisCount.Text = "+";
            this.toolTip1.SetToolTip(this.btnIncreaseDisCount, "Press (+) For Increase Discount Rate");
            this.btnIncreaseDisCount.UseVisualStyleBackColor = true;
            this.btnIncreaseDisCount.Visible = false;
            this.btnIncreaseDisCount.Click += new System.EventHandler(this.btnIncreaseDisCount_Click);
            // 
            // btnDecreaseDiscount
            // 
            this.btnDecreaseDiscount.FlatAppearance.BorderSize = 0;
            this.btnDecreaseDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseDiscount.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecreaseDiscount.ForeColor = System.Drawing.Color.Black;
            this.btnDecreaseDiscount.Location = new System.Drawing.Point(41, 120);
            this.btnDecreaseDiscount.Name = "btnDecreaseDiscount";
            this.btnDecreaseDiscount.Size = new System.Drawing.Size(24, 27);
            this.btnDecreaseDiscount.TabIndex = 144;
            this.btnDecreaseDiscount.Text = "--";
            this.toolTip1.SetToolTip(this.btnDecreaseDiscount, "Press (-) For Decrease Discount Rate");
            this.btnDecreaseDiscount.UseVisualStyleBackColor = true;
            this.btnDecreaseDiscount.Visible = false;
            this.btnDecreaseDiscount.Click += new System.EventHandler(this.btnDecreaseDiscount_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(230, 39);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 16);
            this.label28.TabIndex = 143;
            this.label28.Text = "Discount ";
            this.toolTip1.SetToolTip(this.label28, "(+) Increase Discount Rate   \r\n(-)  Decrease Discount Rate");
            // 
            // txtDiscountRate
            // 
            this.txtDiscountRate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDiscountRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiscountRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F);
            this.txtDiscountRate.ForeColor = System.Drawing.Color.Black;
            this.txtDiscountRate.Location = new System.Drawing.Point(22, 27);
            this.txtDiscountRate.Name = "txtDiscountRate";
            this.txtDiscountRate.Size = new System.Drawing.Size(43, 17);
            this.txtDiscountRate.TabIndex = 140;
            this.txtDiscountRate.Text = "0";
            this.toolTip1.SetToolTip(this.txtDiscountRate, "Insert Discount Rate  \r\nDiscount Rate calculating with sub total");
            this.txtDiscountRate.TextChanged += new System.EventHandler(this.btnIncreaseDisCount_Click);
            this.txtDiscountRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountRate_KeyPress);
            // 
            // btnIncreaseVAT
            // 
            this.btnIncreaseVAT.FlatAppearance.BorderSize = 0;
            this.btnIncreaseVAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseVAT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncreaseVAT.ForeColor = System.Drawing.Color.Black;
            this.btnIncreaseVAT.Location = new System.Drawing.Point(46, 153);
            this.btnIncreaseVAT.Name = "btnIncreaseVAT";
            this.btnIncreaseVAT.Size = new System.Drawing.Size(19, 27);
            this.btnIncreaseVAT.TabIndex = 151;
            this.btnIncreaseVAT.Text = "+";
            this.toolTip1.SetToolTip(this.btnIncreaseVAT, "Press (+) For Increase VAT Rate");
            this.btnIncreaseVAT.UseVisualStyleBackColor = true;
            this.btnIncreaseVAT.Visible = false;
            this.btnIncreaseVAT.Click += new System.EventHandler(this.btnIncreaseVAT_Click);
            // 
            // btnDeCreaseVAT
            // 
            this.btnDeCreaseVAT.FlatAppearance.BorderSize = 0;
            this.btnDeCreaseVAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeCreaseVAT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeCreaseVAT.ForeColor = System.Drawing.Color.Black;
            this.btnDeCreaseVAT.Location = new System.Drawing.Point(16, 151);
            this.btnDeCreaseVAT.Name = "btnDeCreaseVAT";
            this.btnDeCreaseVAT.Size = new System.Drawing.Size(24, 27);
            this.btnDeCreaseVAT.TabIndex = 150;
            this.btnDeCreaseVAT.Text = "--";
            this.toolTip1.SetToolTip(this.btnDeCreaseVAT, "Press (-) For Decrease VAT Rate");
            this.btnDeCreaseVAT.UseVisualStyleBackColor = true;
            this.btnDeCreaseVAT.Visible = false;
            this.btnDeCreaseVAT.Click += new System.EventHandler(this.btnDeCreaseVAT_Click);
            // 
            // txtVATRate
            // 
            this.txtVATRate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtVATRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVATRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVATRate.ForeColor = System.Drawing.Color.Black;
            this.txtVATRate.Location = new System.Drawing.Point(330, 90);
            this.txtVATRate.Name = "txtVATRate";
            this.txtVATRate.ReadOnly = true;
            this.txtVATRate.Size = new System.Drawing.Size(48, 15);
            this.txtVATRate.TabIndex = 146;
            this.txtVATRate.Text = "5";
            this.toolTip1.SetToolTip(this.txtVATRate, "(+) Increase TAX Rate   ");
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(42, 289);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(222, 45);
            this.txtNote.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtNote, "Please insert Note ");
            // 
            // lnkAddCust
            // 
            this.lnkAddCust.AutoSize = true;
            this.lnkAddCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddCust.Location = new System.Drawing.Point(247, 227);
            this.lnkAddCust.Name = "lnkAddCust";
            this.lnkAddCust.Size = new System.Drawing.Size(17, 18);
            this.lnkAddCust.TabIndex = 156;
            this.lnkAddCust.TabStop = true;
            this.lnkAddCust.Text = "+";
            this.toolTip1.SetToolTip(this.lnkAddCust, "Add new Customer/Billler info");
            this.lnkAddCust.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddCust_LinkClicked);
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.Font = new System.Drawing.Font("Times New Roman", 9.25F);
            this.txtSearchItem.Location = new System.Drawing.Point(888, 76);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(258, 22);
            this.txtSearchItem.TabIndex = 159;
            this.toolTip1.SetToolTip(this.txtSearchItem, "Search by Item Id  or Item Name");
            this.txtSearchItem.TextChanged += new System.EventHandler(this.txtSearchItem_TextChanged);
            // 
            // lbloveralldiscount
            // 
            this.lbloveralldiscount.AutoSize = true;
            this.lbloveralldiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lbloveralldiscount.Location = new System.Drawing.Point(100, 57);
            this.lbloveralldiscount.Name = "lbloveralldiscount";
            this.lbloveralldiscount.Size = new System.Drawing.Size(10, 12);
            this.lbloveralldiscount.TabIndex = 167;
            this.lbloveralldiscount.Text = "0";
            this.toolTip1.SetToolTip(this.lbloveralldiscount, "Over all Total Discount ");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(69, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 16);
            this.label13.TabIndex = 142;
            this.label13.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(307, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 16);
            this.label10.TabIndex = 148;
            this.label10.Text = "%";
            // 
            // timer_InvoiceNoRefresh
            // 
            this.timer_InvoiceNoRefresh.Enabled = true;
            this.timer_InvoiceNoRefresh.Interval = 1000;
            this.timer_InvoiceNoRefresh.Tick += new System.EventHandler(this.timer_InvoiceNoRefresh_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblsubtotal);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.btnDecreaseDiscount);
            this.panel1.Controls.Add(this.btnIncreaseDisCount);
            this.panel1.Controls.Add(this.lblTotalItems);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnIncreaseVAT);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnDeCreaseVAT);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtVATRate);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblTotalDisCount);
            this.panel1.Controls.Add(this.lblTotalVAT);
            this.panel1.Controls.Add(this.txtShippingFee);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.lblTotalPayable);
            this.panel1.Location = new System.Drawing.Point(303, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 201);
            this.panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiscountRate);
            this.groupBox1.Controls.Add(this.lbloveralldiscount);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(16, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 81);
            this.groupBox1.TabIndex = 168;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Overall Discount";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.label21.Location = new System.Drawing.Point(20, 57);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 12);
            this.label21.TabIndex = 166;
            this.label21.Text = "Overall Discount:";
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.lblsubtotal.Location = new System.Drawing.Point(445, 60);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(18, 20);
            this.lblsubtotal.TabIndex = 165;
            this.lblsubtotal.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(230, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 15);
            this.label20.TabIndex = 164;
            this.label20.Text = "Sub Total";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label14.Location = new System.Drawing.Point(232, 178);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 161;
            this.label14.Text = "Total Items Type:";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.lblTotalItems.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTotalItems.Location = new System.Drawing.Point(448, 178);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(19, 13);
            this.lblTotalItems.TabIndex = 160;
            this.lblTotalItems.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 154;
            this.label6.Text = "Note";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(19, 34);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(85, 13);
            this.lblUserID.TabIndex = 155;
            this.lblUserID.Text = "Employee_name";
            // 
            // lblCustID
            // 
            this.lblCustID.AutoSize = true;
            this.lblCustID.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustID.Location = new System.Drawing.Point(161, 231);
            this.lblCustID.Name = "lblCustID";
            this.lblCustID.Size = new System.Drawing.Size(40, 12);
            this.lblCustID.TabIndex = 157;
            this.lblCustID.Text = "1000009";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label15.Location = new System.Drawing.Point(1429, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 14);
            this.label15.TabIndex = 160;
            this.label15.Text = "Search Items";
            // 
            // PanelStockList
            // 
            this.PanelStockList.Controls.Add(this.flowLayoutPanelUserList);
            this.PanelStockList.Location = new System.Drawing.Point(888, 106);
            this.PanelStockList.Name = "PanelStockList";
            this.PanelStockList.Size = new System.Drawing.Size(258, 396);
            this.PanelStockList.TabIndex = 158;
            // 
            // flowLayoutPanelUserList
            // 
            this.flowLayoutPanelUserList.AutoScroll = true;
            this.flowLayoutPanelUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelUserList.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelUserList.Name = "flowLayoutPanelUserList";
            this.flowLayoutPanelUserList.Size = new System.Drawing.Size(258, 396);
            this.flowLayoutPanelUserList.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label17.Location = new System.Drawing.Point(885, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 14);
            this.label17.TabIndex = 161;
            this.label17.Text = "Search Items";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(117, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 162;
            this.label18.Text = "Create Invoice";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(39, 476);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 26);
            this.label19.TabIndex = 163;
            this.label19.Text = "1: Tax apply\r\n0: No Tax";
            // 
            // btnSuspend
            // 
            this.btnSuspend.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSuspend.FlatAppearance.BorderSize = 0;
            this.btnSuspend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuspend.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuspend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSuspend.Location = new System.Drawing.Point(42, 381);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(222, 27);
            this.btnSuspend.TabIndex = 164;
            this.btnSuspend.Text = "Suspend";
            this.btnSuspend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuspend.UseVisualStyleBackColor = false;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(247, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 13);
            this.label22.TabIndex = 165;
            this.label22.Text = "Invoice No :";
            // 
            // lblInvoiceNO
            // 
            this.lblInvoiceNO.AutoSize = true;
            this.lblInvoiceNO.Location = new System.Drawing.Point(319, 20);
            this.lblInvoiceNO.Name = "lblInvoiceNO";
            this.lblInvoiceNO.Size = new System.Drawing.Size(10, 13);
            this.lblInvoiceNO.TabIndex = 166;
            this.lblInvoiceNO.Text = "-";
            // 
            // Add_Sales
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1158, 529);
            this.Controls.Add(this.lblInvoiceNO);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSearchItem);
            this.Controls.Add(this.PanelStockList);
            this.Controls.Add(this.lblCustID);
            this.Controls.Add(this.lnkAddCust);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAddStockItem);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbCustomer);
            this.Controls.Add(this.CmbBiller);
            this.Controls.Add(this.CmbWarehouse);
            this.Controls.Add(this.txtinvoiceNo);
            this.Controls.Add(this.dtSalesDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgrvSalesItemList);
            this.Controls.Add(this.txtBarcodeReaderBox);
            this.Name = "Add_Sales";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Add_Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvSalesItemList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PanelStockList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvSalesItemList;
        private System.Windows.Forms.TextBox txtBarcodeReaderBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtSalesDate;
        private System.Windows.Forms.TextBox txtinvoiceNo;
        private System.Windows.Forms.ComboBox CmbWarehouse;
        private System.Windows.Forms.ComboBox CmbBiller;
        private System.Windows.Forms.ComboBox CmbCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalDisCount;
        private System.Windows.Forms.Label lblTotalVAT;
        private System.Windows.Forms.TextBox txtShippingFee;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTotalPayable;
        private System.Windows.Forms.LinkLabel lblAddStockItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnIncreaseDisCount;
        private System.Windows.Forms.Button btnDecreaseDiscount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtDiscountRate;
        private System.Windows.Forms.Button btnIncreaseVAT;
        private System.Windows.Forms.Button btnDeCreaseVAT;
        private System.Windows.Forms.TextBox txtVATRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer_InvoiceNoRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.LinkLabel lnkAddCust;
        private System.Windows.Forms.Label lblCustID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.Panel PanelStockList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUserList;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbloveralldiscount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblInvoiceNO;
    }
}