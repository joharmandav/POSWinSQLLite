namespace supershop
{
    partial class Stock_List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stock_List));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtItemSearchBar = new System.Windows.Forms.TextBox();
            this.labelSearchProduct = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelStockItem = new System.Windows.Forms.Label();
            this.picCloseEvent = new System.Windows.Forms.PictureBox();
            this.lblMinimized = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnChart = new System.Windows.Forms.Button();
            this.combCategory = new System.Windows.Forms.ComboBox();
            this.bntStock = new System.Windows.Forms.Button();
            this.btnpurchasehistory = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCreateBarcode = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelUserList = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRows = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnDeliverd = new System.Windows.Forms.Button();
            this.DisplayImage = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.dgrvProductList = new System.Windows.Forms.DataGridView();
            this.tabWithImage = new System.Windows.Forms.TabPage();
            this.btnSerch = new System.Windows.Forms.Button();
            this.lblstart = new System.Windows.Forms.Label();
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseEvent)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvProductList)).BeginInit();
            this.tabWithImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtItemSearchBar
            // 
            this.txtItemSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtItemSearchBar.Location = new System.Drawing.Point(17, 59);
            this.txtItemSearchBar.Name = "txtItemSearchBar";
            this.txtItemSearchBar.Size = new System.Drawing.Size(552, 21);
            this.txtItemSearchBar.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtItemSearchBar, "Search by Product Code / Barcode OR  Name ");
            this.txtItemSearchBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemSearchBar_KeyDown);
            this.txtItemSearchBar.Leave += new System.EventHandler(this.txtItemSearchBar_Leave);
            // 
            // labelSearchProduct
            // 
            this.labelSearchProduct.AutoSize = true;
            this.labelSearchProduct.Font = new System.Drawing.Font("Courier New", 10.25F);
            this.labelSearchProduct.Location = new System.Drawing.Point(15, 36);
            this.labelSearchProduct.Name = "labelSearchProduct";
            this.labelSearchProduct.Size = new System.Drawing.Size(120, 17);
            this.labelSearchProduct.TabIndex = 33;
            this.labelSearchProduct.Text = "Search Product";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Violet;
            this.panel1.Controls.Add(this.labelStockItem);
            this.panel1.Controls.Add(this.picCloseEvent);
            this.panel1.Controls.Add(this.lblMinimized);
            this.panel1.Location = new System.Drawing.Point(5, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 30);
            this.panel1.TabIndex = 37;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stock_List_MouseDown);
            // 
            // labelStockItem
            // 
            this.labelStockItem.AutoSize = true;
            this.labelStockItem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStockItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelStockItem.Location = new System.Drawing.Point(8, 4);
            this.labelStockItem.Name = "labelStockItem";
            this.labelStockItem.Size = new System.Drawing.Size(99, 23);
            this.labelStockItem.TabIndex = 42;
            this.labelStockItem.Text = "Stock Item";
            // 
            // picCloseEvent
            // 
            this.picCloseEvent.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCloseEvent.Image = ((System.Drawing.Image)(resources.GetObject("picCloseEvent.Image")));
            this.picCloseEvent.Location = new System.Drawing.Point(1135, 5);
            this.picCloseEvent.Name = "picCloseEvent";
            this.picCloseEvent.Size = new System.Drawing.Size(21, 21);
            this.picCloseEvent.TabIndex = 41;
            this.picCloseEvent.TabStop = false;
            this.picCloseEvent.Click += new System.EventHandler(this.picCloseEvent_Click);
            // 
            // lblMinimized
            // 
            this.lblMinimized.AutoSize = true;
            this.lblMinimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblMinimized.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMinimized.Location = new System.Drawing.Point(1109, 2);
            this.lblMinimized.Name = "lblMinimized";
            this.lblMinimized.Size = new System.Drawing.Size(19, 25);
            this.lblMinimized.TabIndex = 1;
            this.lblMinimized.Text = "-";
            this.toolTip1.SetToolTip(this.lblMinimized, "Minimize");
            this.lblMinimized.Click += new System.EventHandler(this.lblMinimized_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 39000;
            this.toolTip1.InitialDelay = 9;
            this.toolTip1.ReshowDelay = 9;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnChart
            // 
            this.btnChart.FlatAppearance.BorderSize = 0;
            this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnChart.Image = ((System.Drawing.Image)(resources.GetObject("btnChart.Image")));
            this.btnChart.Location = new System.Drawing.Point(964, 636);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(55, 56);
            this.btnChart.TabIndex = 8;
            this.btnChart.Text = "Chart";
            this.btnChart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnChart, "Buying and Sale Rate Comparison");
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // combCategory
            // 
            this.combCategory.Font = new System.Drawing.Font("Times New Roman", 9.25F);
            this.combCategory.FormattingEnabled = true;
            this.combCategory.Location = new System.Drawing.Point(852, 57);
            this.combCategory.Name = "combCategory";
            this.combCategory.Size = new System.Drawing.Size(310, 23);
            this.combCategory.TabIndex = 0;
            this.toolTip1.SetToolTip(this.combCategory, "Please Select Item category");
            this.combCategory.SelectedIndexChanged += new System.EventHandler(this.combCategory_SelectedIndexChanged);
            // 
            // bntStock
            // 
            this.bntStock.FlatAppearance.BorderSize = 0;
            this.bntStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.bntStock.Image = ((System.Drawing.Image)(resources.GetObject("bntStock.Image")));
            this.bntStock.Location = new System.Drawing.Point(640, 636);
            this.bntStock.Name = "bntStock";
            this.bntStock.Size = new System.Drawing.Size(118, 56);
            this.bntStock.TabIndex = 5;
            this.bntStock.Text = "Stock Details";
            this.bntStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.bntStock, "Stock details: Item quantity alert");
            this.bntStock.UseVisualStyleBackColor = true;
            this.bntStock.Click += new System.EventHandler(this.bntStock_Click);
            // 
            // btnpurchasehistory
            // 
            this.btnpurchasehistory.FlatAppearance.BorderSize = 0;
            this.btnpurchasehistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpurchasehistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnpurchasehistory.Image = ((System.Drawing.Image)(resources.GetObject("btnpurchasehistory.Image")));
            this.btnpurchasehistory.Location = new System.Drawing.Point(516, 637);
            this.btnpurchasehistory.Name = "btnpurchasehistory";
            this.btnpurchasehistory.Size = new System.Drawing.Size(118, 56);
            this.btnpurchasehistory.TabIndex = 4;
            this.btnpurchasehistory.Text = "Purchase History";
            this.btnpurchasehistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnpurchasehistory, "Purchase history: Item purchase records");
            this.btnpurchasehistory.UseVisualStyleBackColor = true;
            this.btnpurchasehistory.Click += new System.EventHandler(this.btnpurchasehistory_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.panel2.Location = new System.Drawing.Point(5, 693);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1161, 22);
            this.panel2.TabIndex = 38;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stock_List_MouseDown);
            // 
            // btnCreateBarcode
            // 
            this.btnCreateBarcode.FlatAppearance.BorderSize = 0;
            this.btnCreateBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnCreateBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateBarcode.Image")));
            this.btnCreateBarcode.Location = new System.Drawing.Point(1030, 631);
            this.btnCreateBarcode.Name = "btnCreateBarcode";
            this.btnCreateBarcode.Size = new System.Drawing.Size(126, 61);
            this.btnCreateBarcode.TabIndex = 9;
            this.btnCreateBarcode.Text = "Create Barcode";
            this.btnCreateBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCreateBarcode.UseVisualStyleBackColor = true;
            this.btnCreateBarcode.Click += new System.EventHandler(this.btnCreateBarcode_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.Control;
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Desktop;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.Location = new System.Drawing.Point(852, 636);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(102, 58);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import Item";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanelUserList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1134, 500);
            this.panel3.TabIndex = 145;
            // 
            // flowLayoutPanelUserList
            // 
            this.flowLayoutPanelUserList.AutoScroll = true;
            this.flowLayoutPanelUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelUserList.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelUserList.Name = "flowLayoutPanelUserList";
            this.flowLayoutPanelUserList.Size = new System.Drawing.Size(1134, 500);
            this.flowLayoutPanelUserList.TabIndex = 0;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(14, 659);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(13, 13);
            this.lblRows.TabIndex = 151;
            this.lblRows.Text = "0";
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddNew.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Desktop;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(764, 636);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(73, 56);
            this.btnAddNew.TabIndex = 6;
            this.btnAddNew.Text = "Add New ";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDeliverd
            // 
            this.btnDeliverd.BackColor = System.Drawing.Color.Lime;
            this.btnDeliverd.FlatAppearance.BorderSize = 0;
            this.btnDeliverd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeliverd.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnDeliverd.ForeColor = System.Drawing.Color.Blue;
            this.btnDeliverd.Location = new System.Drawing.Point(728, 41);
            this.btnDeliverd.Name = "btnDeliverd";
            this.btnDeliverd.Size = new System.Drawing.Size(108, 39);
            this.btnDeliverd.TabIndex = 3;
            this.btnDeliverd.Text = "All Category";
            this.btnDeliverd.UseVisualStyleBackColor = false;
            this.btnDeliverd.Click += new System.EventHandler(this.btnDeliverd_Click);
            // 
            // DisplayImage
            // 
            this.DisplayImage.AutoSize = true;
            this.DisplayImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayImage.Location = new System.Drawing.Point(622, 58);
            this.DisplayImage.Name = "DisplayImage";
            this.DisplayImage.Size = new System.Drawing.Size(97, 21);
            this.DisplayImage.TabIndex = 2;
            this.DisplayImage.Text = "With Image";
            this.DisplayImage.UseVisualStyleBackColor = true;
            this.DisplayImage.CheckedChanged += new System.EventHandler(this.DisplayImage_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGrid);
            this.tabControl1.Controls.Add(this.tabWithImage);
            this.tabControl1.Location = new System.Drawing.Point(18, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 532);
            this.tabControl1.TabIndex = 152;
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.dgrvProductList);
            this.tabGrid.Location = new System.Drawing.Point(4, 22);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrid.Size = new System.Drawing.Size(1140, 506);
            this.tabGrid.TabIndex = 0;
            this.tabGrid.Text = "Without Image";
            this.tabGrid.UseVisualStyleBackColor = true;
            // 
            // dgrvProductList
            // 
            this.dgrvProductList.AllowUserToAddRows = false;
            this.dgrvProductList.AllowUserToDeleteRows = false;
            this.dgrvProductList.AllowUserToResizeColumns = false;
            this.dgrvProductList.AllowUserToResizeRows = false;
            this.dgrvProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvProductList.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgrvProductList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvProductList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvProductList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrvProductList.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgrvProductList.Location = new System.Drawing.Point(3, 3);
            this.dgrvProductList.Name = "dgrvProductList";
            this.dgrvProductList.RowHeadersVisible = false;
            this.dgrvProductList.RowTemplate.Height = 44;
            this.dgrvProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrvProductList.Size = new System.Drawing.Size(1134, 500);
            this.dgrvProductList.TabIndex = 182;
            this.dgrvProductList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvProductList_CellContentClick);
            this.dgrvProductList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrvProductList_DataBindingComplete);
            // 
            // tabWithImage
            // 
            this.tabWithImage.Controls.Add(this.panel3);
            this.tabWithImage.Location = new System.Drawing.Point(4, 22);
            this.tabWithImage.Name = "tabWithImage";
            this.tabWithImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabWithImage.Size = new System.Drawing.Size(1140, 506);
            this.tabWithImage.TabIndex = 1;
            this.tabWithImage.Text = "With Image";
            this.tabWithImage.UseVisualStyleBackColor = true;
            // 
            // btnSerch
            // 
            this.btnSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSerch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSerch.FlatAppearance.BorderSize = 0;
            this.btnSerch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSerch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSerch.Image = ((System.Drawing.Image)(resources.GetObject("btnSerch.Image")));
            this.btnSerch.Location = new System.Drawing.Point(575, 55);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(25, 25);
            this.btnSerch.TabIndex = 153;
            this.btnSerch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSerch.UseVisualStyleBackColor = false;
            this.btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // lblstart
            // 
            this.lblstart.AutoSize = true;
            this.lblstart.Location = new System.Drawing.Point(19, 624);
            this.lblstart.Name = "lblstart";
            this.lblstart.Size = new System.Drawing.Size(13, 13);
            this.lblstart.TabIndex = 154;
            this.lblstart.Text = "0";
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lnkCategory.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkCategory.Location = new System.Drawing.Point(850, 38);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(104, 16);
            this.lnkCategory.TabIndex = 173;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "Select Category";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // Stock_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1168, 742);
            this.Controls.Add(this.lnkCategory);
            this.Controls.Add(this.lblstart);
            this.Controls.Add(this.btnSerch);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.DisplayImage);
            this.Controls.Add(this.btnDeliverd);
            this.Controls.Add(this.btnpurchasehistory);
            this.Controls.Add(this.bntStock);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.combCategory);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnCreateBarcode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSearchProduct);
            this.Controls.Add(this.txtItemSearchBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stock_List";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Stock Item";
            this.Load += new System.EventHandler(this.Stock_List_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stock_List_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseEvent)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvProductList)).EndInit();
            this.tabWithImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemSearchBar;
        private System.Windows.Forms.Label labelSearchProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMinimized;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCreateBarcode;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.PictureBox picCloseEvent;
        private System.Windows.Forms.Label labelStockItem;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUserList;
        private System.Windows.Forms.ComboBox combCategory;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button bntStock;
        private System.Windows.Forms.Button btnpurchasehistory;
        private System.Windows.Forms.Button btnDeliverd;
        private System.Windows.Forms.CheckBox DisplayImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGrid;
        private System.Windows.Forms.TabPage tabWithImage;
        private System.Windows.Forms.DataGridView dgrvProductList;
        private System.Windows.Forms.Button btnSerch;
        private System.Windows.Forms.Label lblstart;
        private System.Windows.Forms.LinkLabel lnkCategory;
    }
}