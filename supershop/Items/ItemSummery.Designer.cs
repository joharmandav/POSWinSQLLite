namespace supershop
{
    partial class ItemSummery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSummery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtItemSearchBar = new System.Windows.Forms.TextBox();
            this.labelSearchProduct = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelStockItem = new System.Windows.Forms.Label();
            this.picCloseEvent = new System.Windows.Forms.PictureBox();
            this.lblMinimized = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.combCategory = new System.Windows.Forms.ComboBox();
            this.lblRows = new System.Windows.Forms.Label();
            this.btnDeliverd = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.dgrvProductList = new System.Windows.Forms.DataGridView();
            this.btnSerch = new System.Windows.Forms.Button();
            this.lblstart = new System.Windows.Forms.Label();
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseEvent)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvProductList)).BeginInit();
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
            this.labelStockItem.Size = new System.Drawing.Size(222, 23);
            this.labelStockItem.TabIndex = 42;
            this.labelStockItem.Text = "Product Summary Report";
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
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(38, 624);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(13, 13);
            this.lblRows.TabIndex = 151;
            this.lblRows.Text = "0";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGrid);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvProductList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvProductList.DefaultCellStyle = dataGridViewCellStyle8;
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
            // ItemSummery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1168, 645);
            this.Controls.Add(this.lnkCategory);
            this.Controls.Add(this.lblstart);
            this.Controls.Add(this.btnSerch);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDeliverd);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.combCategory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSearchProduct);
            this.Controls.Add(this.txtItemSearchBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSummery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Stock Item";
            this.Load += new System.EventHandler(this.Stock_List_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stock_List_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseEvent)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvProductList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemSearchBar;
        private System.Windows.Forms.Label labelSearchProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMinimized;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picCloseEvent;
        private System.Windows.Forms.Label labelStockItem;
        private System.Windows.Forms.ComboBox combCategory;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Button btnDeliverd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGrid;
        private System.Windows.Forms.DataGridView dgrvProductList;
        private System.Windows.Forms.Button btnSerch;
        private System.Windows.Forms.Label lblstart;
        private System.Windows.Forms.LinkLabel lnkCategory;
    }
}