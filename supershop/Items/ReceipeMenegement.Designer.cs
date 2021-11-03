namespace supershop
{
    partial class ReceipeMenegement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceipeMenegement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelStockItem = new System.Windows.Forms.Label();
            this.picCloseEvent = new System.Windows.Forms.PictureBox();
            this.lblMinimized = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.combCategory = new System.Windows.Forms.ComboBox();
            this.comboReceipe = new System.Windows.Forms.ComboBox();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbRectype = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.linkLabelAllCatagory = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.datagrdReportDetails = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridAlwaysShow = new System.Windows.Forms.DataGridView();
            this.btnCashierRefresh = new System.Windows.Forms.Button();
            this.AddNewReceipe = new System.Windows.Forms.LinkLabel();
            this.btnRefreshReceipe = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridItems = new System.Windows.Forms.DataGridView();
            this.labelSearchItems = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblComplateTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblinputTotal = new System.Windows.Forms.Label();
            this.lbloutputTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lnkReceipeSearch = new System.Windows.Forms.LinkLabel();
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.resourceHolder1 = new ResourceEditor.ResourceHolder();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseEvent)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlwaysShow)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).BeginInit();
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
            this.labelStockItem.Size = new System.Drawing.Size(271, 23);
            this.labelStockItem.TabIndex = 42;
            this.labelStockItem.Text = "Receipe / Package Management";
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
            this.combCategory.Location = new System.Drawing.Point(668, 57);
            this.combCategory.Name = "combCategory";
            this.combCategory.Size = new System.Drawing.Size(329, 23);
            this.combCategory.TabIndex = 150;
            this.toolTip1.SetToolTip(this.combCategory, "Please Select Item category");
            this.combCategory.SelectedIndexChanged += new System.EventHandler(this.combCategory_SelectedIndexChanged);
            // 
            // comboReceipe
            // 
            this.comboReceipe.Font = new System.Drawing.Font("Times New Roman", 9.25F);
            this.comboReceipe.FormattingEnabled = true;
            this.comboReceipe.Location = new System.Drawing.Point(289, 57);
            this.comboReceipe.Name = "comboReceipe";
            this.comboReceipe.Size = new System.Drawing.Size(260, 23);
            this.comboReceipe.TabIndex = 176;
            this.toolTip1.SetToolTip(this.comboReceipe, "Please Select Item");
            this.comboReceipe.SelectedIndexChanged += new System.EventHandler(this.comboReceipe_SelectedIndexChanged);
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.BackColor = System.Drawing.SystemColors.Control;
            this.txtSearchItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtSearchItem.Location = new System.Drawing.Point(17, 114);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(541, 22);
            this.txtSearchItem.TabIndex = 184;
            this.toolTip1.SetToolTip(this.txtSearchItem, "Search by Item Id  or Item Name");
            this.txtSearchItem.TextChanged += new System.EventHandler(this.txtSearchItem_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(1055, 52);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 28);
            this.btnSave.TabIndex = 186;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "I want to Submit");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbRectype
            // 
            this.cmbRectype.Font = new System.Drawing.Font("Times New Roman", 9.25F);
            this.cmbRectype.FormattingEnabled = true;
            this.cmbRectype.Items.AddRange(new object[] {
            "Receipe",
            "Package"});
            this.cmbRectype.Location = new System.Drawing.Point(23, 60);
            this.cmbRectype.Name = "cmbRectype";
            this.cmbRectype.Size = new System.Drawing.Size(203, 23);
            this.cmbRectype.TabIndex = 190;
            this.cmbRectype.Text = "Receipe";
            this.toolTip1.SetToolTip(this.cmbRectype, "Please Select Item");
            this.cmbRectype.SelectedIndexChanged += new System.EventHandler(this.cmbRectype_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnDelete.ForeColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(1172, 52);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 28);
            this.btnDelete.TabIndex = 197;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // linkLabelAllCatagory
            // 
            this.linkLabelAllCatagory.AutoSize = true;
            this.linkLabelAllCatagory.Location = new System.Drawing.Point(822, 41);
            this.linkLabelAllCatagory.Name = "linkLabelAllCatagory";
            this.linkLabelAllCatagory.Size = new System.Drawing.Size(63, 13);
            this.linkLabelAllCatagory.TabIndex = 174;
            this.linkLabelAllCatagory.TabStop = true;
            this.linkLabelAllCatagory.Text = "All Catagory";
            this.linkLabelAllCatagory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.datagrdReportDetails);
            this.panel4.Location = new System.Drawing.Point(615, 138);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(641, 377);
            this.panel4.TabIndex = 177;
            // 
            // datagrdReportDetails
            // 
            this.datagrdReportDetails.AllowDrop = true;
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
            this.datagrdReportDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdReportDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagrdReportDetails.RowTemplate.Height = 33;
            this.datagrdReportDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdReportDetails.Size = new System.Drawing.Size(639, 375);
            this.datagrdReportDetails.TabIndex = 3;
            this.datagrdReportDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellClick);
            this.datagrdReportDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellEndEdit);
            this.datagrdReportDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellValueChanged);
            this.datagrdReportDetails.DragDrop += new System.Windows.Forms.DragEventHandler(this.datagrdReportDetails_DragDrop);
            this.datagrdReportDetails.DragOver += new System.Windows.Forms.DragEventHandler(this.datagrdReportDetails_DragOver);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dataGridAlwaysShow);
            this.panel5.Location = new System.Drawing.Point(615, 541);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(642, 191);
            this.panel5.TabIndex = 179;
            // 
            // dataGridAlwaysShow
            // 
            this.dataGridAlwaysShow.AllowDrop = true;
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
            this.dataGridAlwaysShow.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAlwaysShow.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridAlwaysShow.RowTemplate.Height = 33;
            this.dataGridAlwaysShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAlwaysShow.Size = new System.Drawing.Size(640, 189);
            this.dataGridAlwaysShow.TabIndex = 4;
            this.dataGridAlwaysShow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAlwaysShow_CellClick);
            this.dataGridAlwaysShow.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAlwaysShow_CellEndEdit);
            this.dataGridAlwaysShow.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAlwaysShow_CellValueChanged);
            this.dataGridAlwaysShow.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridAlwaysShow_DragDrop);
            this.dataGridAlwaysShow.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridAlwaysShow_DragOver);
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
            this.btnCashierRefresh.Location = new System.Drawing.Point(569, 111);
            this.btnCashierRefresh.Name = "btnCashierRefresh";
            this.btnCashierRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnCashierRefresh.TabIndex = 180;
            this.btnCashierRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashierRefresh.UseVisualStyleBackColor = false;
            this.btnCashierRefresh.Click += new System.EventHandler(this.btnCashierRefresh_Click);
            // 
            // AddNewReceipe
            // 
            this.AddNewReceipe.AutoSize = true;
            this.AddNewReceipe.Location = new System.Drawing.Point(485, 41);
            this.AddNewReceipe.Name = "AddNewReceipe";
            this.AddNewReceipe.Size = new System.Drawing.Size(51, 13);
            this.AddNewReceipe.TabIndex = 181;
            this.AddNewReceipe.TabStop = true;
            this.AddNewReceipe.Text = "Add New";
            this.AddNewReceipe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddNewReceipe_LinkClicked);
            // 
            // btnRefreshReceipe
            // 
            this.btnRefreshReceipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefreshReceipe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefreshReceipe.FlatAppearance.BorderSize = 0;
            this.btnRefreshReceipe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRefreshReceipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshReceipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnRefreshReceipe.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshReceipe.Image")));
            this.btnRefreshReceipe.Location = new System.Drawing.Point(554, 57);
            this.btnRefreshReceipe.Name = "btnRefreshReceipe";
            this.btnRefreshReceipe.Size = new System.Drawing.Size(26, 25);
            this.btnRefreshReceipe.TabIndex = 182;
            this.btnRefreshReceipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshReceipe.UseVisualStyleBackColor = false;
            this.btnRefreshReceipe.Click += new System.EventHandler(this.btnRefreshReceipe_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridItems);
            this.panel2.Location = new System.Drawing.Point(17, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 593);
            this.panel2.TabIndex = 183;
            // 
            // dataGridItems
            // 
            this.dataGridItems.AllowDrop = true;
            this.dataGridItems.AllowUserToAddRows = false;
            this.dataGridItems.AllowUserToDeleteRows = false;
            this.dataGridItems.AllowUserToResizeColumns = false;
            this.dataGridItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridItems.BackgroundColor = System.Drawing.Color.White;
            this.dataGridItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridItems.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridItems.Location = new System.Drawing.Point(0, 0);
            this.dataGridItems.Name = "dataGridItems";
            this.dataGridItems.ReadOnly = true;
            this.dataGridItems.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridItems.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridItems.RowTemplate.Height = 33;
            this.dataGridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridItems.Size = new System.Drawing.Size(575, 591);
            this.dataGridItems.TabIndex = 4;
            this.dataGridItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridItems_MouseDown);
            this.dataGridItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridItems_MouseMove);
            // 
            // labelSearchItems
            // 
            this.labelSearchItems.AutoSize = true;
            this.labelSearchItems.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.labelSearchItems.Location = new System.Drawing.Point(20, 97);
            this.labelSearchItems.Name = "labelSearchItems";
            this.labelSearchItems.Size = new System.Drawing.Size(91, 14);
            this.labelSearchItems.TabIndex = 185;
            this.labelSearchItems.Text = "Search Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 189;
            this.label2.Text = "Select Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label3.Location = new System.Drawing.Point(615, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 14);
            this.label3.TabIndex = 191;
            this.label3.Text = "Total Sessions :";
            // 
            // lblComplateTime
            // 
            this.lblComplateTime.AutoSize = true;
            this.lblComplateTime.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lblComplateTime.Location = new System.Drawing.Point(734, 119);
            this.lblComplateTime.Name = "lblComplateTime";
            this.lblComplateTime.Size = new System.Drawing.Size(14, 14);
            this.lblComplateTime.TabIndex = 192;
            this.lblComplateTime.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label1.Location = new System.Drawing.Point(907, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 14);
            this.label1.TabIndex = 193;
            this.label1.Text = "Total Cost Price :";
            // 
            // lblinputTotal
            // 
            this.lblinputTotal.AutoSize = true;
            this.lblinputTotal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lblinputTotal.Location = new System.Drawing.Point(1038, 122);
            this.lblinputTotal.Name = "lblinputTotal";
            this.lblinputTotal.Size = new System.Drawing.Size(14, 14);
            this.lblinputTotal.TabIndex = 194;
            this.lblinputTotal.Text = "-";
            // 
            // lbloutputTotal
            // 
            this.lbloutputTotal.AutoSize = true;
            this.lbloutputTotal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lbloutputTotal.Location = new System.Drawing.Point(1038, 525);
            this.lbloutputTotal.Name = "lbloutputTotal";
            this.lbloutputTotal.Size = new System.Drawing.Size(14, 14);
            this.lbloutputTotal.TabIndex = 196;
            this.lbloutputTotal.Text = "-";
            this.lbloutputTotal.TextChanged += new System.EventHandler(this.lbloutputTotal_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label5.Location = new System.Drawing.Point(948, 524);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 195;
            this.label5.Text = "Total MSRP :";
            // 
            // lnkReceipeSearch
            // 
            this.lnkReceipeSearch.AutoSize = true;
            this.lnkReceipeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkReceipeSearch.Location = new System.Drawing.Point(286, 40);
            this.lnkReceipeSearch.Name = "lnkReceipeSearch";
            this.lnkReceipeSearch.Size = new System.Drawing.Size(134, 13);
            this.lnkReceipeSearch.TabIndex = 198;
            this.lnkReceipeSearch.TabStop = true;
            this.lnkReceipeSearch.Text = "Select Receipe / Package";
            this.lnkReceipeSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReceipeSearch_LinkClicked);
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lnkCategory.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkCategory.Location = new System.Drawing.Point(666, 40);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(82, 13);
            this.lnkCategory.TabIndex = 174;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "Select Category";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // ReceipeMenegement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1270, 744);
            this.Controls.Add(this.lnkCategory);
            this.Controls.Add(this.lnkReceipeSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lbloutputTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblinputTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblComplateTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRectype);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchItem);
            this.Controls.Add(this.labelSearchItems);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRefreshReceipe);
            this.Controls.Add(this.AddNewReceipe);
            this.Controls.Add(this.btnCashierRefresh);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.comboReceipe);
            this.Controls.Add(this.linkLabelAllCatagory);
            this.Controls.Add(this.combCategory);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceipeMenegement";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Receipe Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReceipeMenegement_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.detail_info_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseEvent)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlwaysShow)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMinimized;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picCloseEvent;
        private System.Windows.Forms.Label labelStockItem;
        private System.Windows.Forms.ComboBox combCategory;
        private System.Windows.Forms.LinkLabel linkLabelAllCatagory;
        private System.Windows.Forms.ComboBox comboReceipe;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView datagrdReportDetails;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridAlwaysShow;
        private System.Windows.Forms.Button btnCashierRefresh;
        private System.Windows.Forms.LinkLabel AddNewReceipe;
        private System.Windows.Forms.Button btnRefreshReceipe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridItems;
        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.Label labelSearchItems;
        private System.Windows.Forms.Button btnSave;
        private ResourceEditor.ResourceHolder resourceHolder1;
        private System.Windows.Forms.ComboBox cmbRectype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblComplateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblinputTotal;
        private System.Windows.Forms.Label lbloutputTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.LinkLabel lnkReceipeSearch;
        private System.Windows.Forms.LinkLabel lnkCategory;
    }
}