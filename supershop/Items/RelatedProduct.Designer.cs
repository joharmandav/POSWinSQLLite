namespace supershop
{
    partial class RelatedProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatedProduct));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelStockItem = new System.Windows.Forms.Label();
            this.picCloseEvent = new System.Windows.Forms.PictureBox();
            this.lblMinimized = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.combCategory = new System.Windows.Forms.ComboBox();
            this.comboItem = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelUserList = new System.Windows.Forms.FlowLayoutPanel();
            this.labelSelectCategory = new System.Windows.Forms.Label();
            this.linkLabelAllCatagory = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.datagrdReportDetails = new System.Windows.Forms.DataGridView();
            this.lblRows = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridAlwaysShow = new System.Windows.Forms.DataGridView();
            this.btnCashierRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseEvent)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlwaysShow)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Violet;
            this.panel1.Controls.Add(this.labelStockItem);
            this.panel1.Controls.Add(this.picCloseEvent);
            this.panel1.Controls.Add(this.lblMinimized);
            this.panel1.Location = new System.Drawing.Point(5, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1265, 30);
            this.panel1.TabIndex = 37;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.detail_info_MouseDown);
            // 
            // labelStockItem
            // 
            this.labelStockItem.AutoSize = true;
            this.labelStockItem.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStockItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelStockItem.Location = new System.Drawing.Point(8, 4);
            this.labelStockItem.Name = "labelStockItem";
            this.labelStockItem.Size = new System.Drawing.Size(115, 23);
            this.labelStockItem.TabIndex = 42;
            this.labelStockItem.Text = "Related Item";
            // 
            // picCloseEvent
            // 
            this.picCloseEvent.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCloseEvent.Image = ((System.Drawing.Image)(resources.GetObject("picCloseEvent.Image")));
            this.picCloseEvent.Location = new System.Drawing.Point(1235, 5);
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
            this.lblMinimized.Location = new System.Drawing.Point(1209, 2);
            this.lblMinimized.Name = "lblMinimized";
            this.lblMinimized.Size = new System.Drawing.Size(19, 25);
            this.lblMinimized.TabIndex = 38;
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
            this.combCategory.Location = new System.Drawing.Point(396, 68);
            this.combCategory.Name = "combCategory";
            this.combCategory.Size = new System.Drawing.Size(328, 23);
            this.combCategory.TabIndex = 150;
            this.toolTip1.SetToolTip(this.combCategory, "Please Select Item category");
            this.combCategory.SelectedIndexChanged += new System.EventHandler(this.combCategory_SelectedIndexChanged);
            // 
            // comboItem
            // 
            this.comboItem.Font = new System.Drawing.Font("Times New Roman", 9.25F);
            this.comboItem.FormattingEnabled = true;
            this.comboItem.Location = new System.Drawing.Point(17, 68);
            this.comboItem.Name = "comboItem";
            this.comboItem.Size = new System.Drawing.Size(328, 23);
            this.comboItem.TabIndex = 176;
            this.toolTip1.SetToolTip(this.comboItem, "Please Select Item");
            this.comboItem.SelectedIndexChanged += new System.EventHandler(this.comboItem_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.flowLayoutPanelUserList);
            this.panel3.Location = new System.Drawing.Point(12, 102);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(779, 630);
            this.panel3.TabIndex = 145;
            // 
            // flowLayoutPanelUserList
            // 
            this.flowLayoutPanelUserList.AutoScroll = true;
            this.flowLayoutPanelUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelUserList.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelUserList.Name = "flowLayoutPanelUserList";
            this.flowLayoutPanelUserList.Size = new System.Drawing.Size(777, 628);
            this.flowLayoutPanelUserList.TabIndex = 5;
            // 
            // labelSelectCategory
            // 
            this.labelSelectCategory.AutoSize = true;
            this.labelSelectCategory.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.labelSelectCategory.Location = new System.Drawing.Point(393, 54);
            this.labelSelectCategory.Name = "labelSelectCategory";
            this.labelSelectCategory.Size = new System.Drawing.Size(112, 14);
            this.labelSelectCategory.TabIndex = 149;
            this.labelSelectCategory.Text = "Select Category";
            // 
            // linkLabelAllCatagory
            // 
            this.linkLabelAllCatagory.AutoSize = true;
            this.linkLabelAllCatagory.Location = new System.Drawing.Point(550, 52);
            this.linkLabelAllCatagory.Name = "linkLabelAllCatagory";
            this.linkLabelAllCatagory.Size = new System.Drawing.Size(63, 13);
            this.linkLabelAllCatagory.TabIndex = 174;
            this.linkLabelAllCatagory.TabStop = true;
            this.linkLabelAllCatagory.Text = "All Catagory";
            this.linkLabelAllCatagory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label1.Location = new System.Drawing.Point(14, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 175;
            this.label1.Text = "Select Item";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.datagrdReportDetails);
            this.panel4.Location = new System.Drawing.Point(799, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(459, 321);
            this.panel4.TabIndex = 177;
            // 
            // datagrdReportDetails
            // 
            this.datagrdReportDetails.AllowUserToAddRows = false;
            this.datagrdReportDetails.AllowUserToDeleteRows = false;
            this.datagrdReportDetails.AllowUserToResizeColumns = false;
            this.datagrdReportDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.datagrdReportDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrdReportDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrdReportDetails.BackgroundColor = System.Drawing.Color.White;
            this.datagrdReportDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdReportDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrdReportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrdReportDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagrdReportDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrdReportDetails.Location = new System.Drawing.Point(0, 0);
            this.datagrdReportDetails.Name = "datagrdReportDetails";
            this.datagrdReportDetails.ReadOnly = true;
            this.datagrdReportDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.datagrdReportDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagrdReportDetails.RowTemplate.Height = 44;
            this.datagrdReportDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdReportDetails.Size = new System.Drawing.Size(457, 319);
            this.datagrdReportDetails.TabIndex = 3;
            this.datagrdReportDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellClick);            
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(654, 52);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(13, 13);
            this.lblRows.TabIndex = 178;
            this.lblRows.Text = "0";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dataGridAlwaysShow);
            this.panel5.Location = new System.Drawing.Point(800, 397);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(457, 335);
            this.panel5.TabIndex = 179;
            // 
            // dataGridAlwaysShow
            // 
            this.dataGridAlwaysShow.AllowUserToAddRows = false;
            this.dataGridAlwaysShow.AllowUserToDeleteRows = false;
            this.dataGridAlwaysShow.AllowUserToResizeColumns = false;
            this.dataGridAlwaysShow.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridAlwaysShow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridAlwaysShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAlwaysShow.BackgroundColor = System.Drawing.Color.White;
            this.dataGridAlwaysShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAlwaysShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridAlwaysShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridAlwaysShow.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridAlwaysShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAlwaysShow.Location = new System.Drawing.Point(0, 0);
            this.dataGridAlwaysShow.Name = "dataGridAlwaysShow";
            this.dataGridAlwaysShow.ReadOnly = true;
            this.dataGridAlwaysShow.RowHeadersVisible = false;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridAlwaysShow.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridAlwaysShow.RowTemplate.Height = 44;
            this.dataGridAlwaysShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAlwaysShow.Size = new System.Drawing.Size(455, 333);
            this.dataGridAlwaysShow.TabIndex = 4;
            this.dataGridAlwaysShow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAlwaysShow_CellClick);            
            // 
            // btnCashierRefresh
            // 
            this.btnCashierRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCashierRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCashierRefresh.FlatAppearance.BorderSize = 0;
            this.btnCashierRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCashierRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashierRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCashierRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnCashierRefresh.Image")));
            this.btnCashierRefresh.Location = new System.Drawing.Point(740, 68);
            this.btnCashierRefresh.Name = "btnCashierRefresh";
            this.btnCashierRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnCashierRefresh.TabIndex = 180;
            this.btnCashierRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashierRefresh.UseVisualStyleBackColor = false;
            this.btnCashierRefresh.Click += new System.EventHandler(this.btnCashierRefresh_Click);
            // 
            // RelatedProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1270, 744);
            this.Controls.Add(this.btnCashierRefresh);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.comboItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabelAllCatagory);
            this.Controls.Add(this.combCategory);
            this.Controls.Add(this.labelSelectCategory);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelatedProduct";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Product List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.detail_info_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.detail_info_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseEvent)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlwaysShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMinimized;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picCloseEvent;
        private System.Windows.Forms.Label labelStockItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUserList;
        private System.Windows.Forms.ComboBox combCategory;
        private System.Windows.Forms.Label labelSelectCategory;
        private System.Windows.Forms.LinkLabel linkLabelAllCatagory;
        private System.Windows.Forms.ComboBox comboItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView datagrdReportDetails;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridAlwaysShow;
        private System.Windows.Forms.Button btnCashierRefresh;
    }
}