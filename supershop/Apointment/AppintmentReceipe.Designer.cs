namespace supershop
{
    partial class AppintmentReceipe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppintmentReceipe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.combCategory = new System.Windows.Forms.ComboBox();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.linkLabelAllCatagory = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.datagrdReportDetails = new System.Windows.Forms.DataGridView();
            this.btnCashierRefresh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridItems = new System.Windows.Forms.DataGridView();
            this.labelSearchItems = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblinputTotal = new System.Windows.Forms.Label();
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAppointmentID = new System.Windows.Forms.Label();
            this.lblJobID = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.resourceHolder1 = new ResourceEditor.ResourceHolder();
            this.lblRecNO = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).BeginInit();
            this.SuspendLayout();
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
            this.combCategory.Location = new System.Drawing.Point(17, 31);
            this.combCategory.Name = "combCategory";
            this.combCategory.Size = new System.Drawing.Size(329, 23);
            this.combCategory.TabIndex = 150;
            this.toolTip1.SetToolTip(this.combCategory, "Please Select Item category");
            this.combCategory.SelectedIndexChanged += new System.EventHandler(this.combCategory_SelectedIndexChanged);
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSearchItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtSearchItem.Location = new System.Drawing.Point(18, 84);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(525, 22);
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
            this.btnSave.Location = new System.Drawing.Point(958, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 28);
            this.btnSave.TabIndex = 186;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "I want to Submit");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // linkLabelAllCatagory
            // 
            this.linkLabelAllCatagory.AutoSize = true;
            this.linkLabelAllCatagory.Location = new System.Drawing.Point(171, 15);
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
            this.panel4.Location = new System.Drawing.Point(596, 113);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(604, 410);
            this.panel4.TabIndex = 177;
            // 
            // datagrdReportDetails
            // 
            this.datagrdReportDetails.AllowDrop = true;
            this.datagrdReportDetails.AllowUserToAddRows = false;
            this.datagrdReportDetails.AllowUserToDeleteRows = false;
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
            this.datagrdReportDetails.Size = new System.Drawing.Size(602, 408);
            this.datagrdReportDetails.TabIndex = 3;
            this.datagrdReportDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellClick);
            this.datagrdReportDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellEndEdit);
            this.datagrdReportDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellValueChanged);
            this.datagrdReportDetails.DragDrop += new System.Windows.Forms.DragEventHandler(this.datagrdReportDetails_DragDrop);
            this.datagrdReportDetails.DragOver += new System.Windows.Forms.DragEventHandler(this.datagrdReportDetails_DragOver);
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
            this.btnCashierRefresh.Location = new System.Drawing.Point(555, 82);
            this.btnCashierRefresh.Name = "btnCashierRefresh";
            this.btnCashierRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnCashierRefresh.TabIndex = 180;
            this.btnCashierRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashierRefresh.UseVisualStyleBackColor = false;
            this.btnCashierRefresh.Click += new System.EventHandler(this.btnCashierRefresh_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridItems);
            this.panel2.Location = new System.Drawing.Point(17, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 410);
            this.panel2.TabIndex = 183;
            // 
            // dataGridItems
            // 
            this.dataGridItems.AllowDrop = true;
            this.dataGridItems.AllowUserToAddRows = false;
            this.dataGridItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridItems.BackgroundColor = System.Drawing.Color.White;
            this.dataGridItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridItems.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridItems.Location = new System.Drawing.Point(0, 0);
            this.dataGridItems.Name = "dataGridItems";
            this.dataGridItems.ReadOnly = true;
            this.dataGridItems.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridItems.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridItems.RowTemplate.Height = 33;
            this.dataGridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridItems.Size = new System.Drawing.Size(561, 408);
            this.dataGridItems.TabIndex = 4;
            this.dataGridItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridItems_MouseDown);
            this.dataGridItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridItems_MouseMove);
            // 
            // labelSearchItems
            // 
            this.labelSearchItems.AutoSize = true;
            this.labelSearchItems.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.labelSearchItems.Location = new System.Drawing.Point(21, 67);
            this.labelSearchItems.Name = "labelSearchItems";
            this.labelSearchItems.Size = new System.Drawing.Size(91, 14);
            this.labelSearchItems.TabIndex = 185;
            this.labelSearchItems.Text = "Search Items";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label1.Location = new System.Drawing.Point(907, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 14);
            this.label1.TabIndex = 193;
            this.label1.Text = "Total Cost Price :";
            // 
            // lblinputTotal
            // 
            this.lblinputTotal.AutoSize = true;
            this.lblinputTotal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lblinputTotal.Location = new System.Drawing.Point(1038, 85);
            this.lblinputTotal.Name = "lblinputTotal";
            this.lblinputTotal.Size = new System.Drawing.Size(14, 14);
            this.lblinputTotal.TabIndex = 194;
            this.lblinputTotal.Text = "-";
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lnkCategory.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkCategory.Location = new System.Drawing.Point(15, 14);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(82, 13);
            this.lnkCategory.TabIndex = 174;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "Select Category";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(410, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 23);
            this.label2.TabIndex = 43;
            this.label2.Text = "Appintment id ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(678, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 44;
            this.label3.Text = "Job id ";
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = true;
            this.lblAppointmentID.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentID.ForeColor = System.Drawing.Color.Blue;
            this.lblAppointmentID.Location = new System.Drawing.Point(549, 14);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(17, 23);
            this.lblAppointmentID.TabIndex = 45;
            this.lblAppointmentID.Text = "-";
            // 
            // lblJobID
            // 
            this.lblJobID.AutoSize = true;
            this.lblJobID.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobID.ForeColor = System.Drawing.Color.Blue;
            this.lblJobID.Location = new System.Drawing.Point(749, 17);
            this.lblJobID.Name = "lblJobID";
            this.lblJobID.Size = new System.Drawing.Size(17, 23);
            this.lblJobID.TabIndex = 46;
            this.lblJobID.Text = "-";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnExit.ForeColor = System.Drawing.Color.Yellow;
            this.btnExit.Location = new System.Drawing.Point(1118, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 28);
            this.btnExit.TabIndex = 195;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblRecNO
            // 
            this.lblRecNO.AutoSize = true;
            this.lblRecNO.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lblRecNO.Location = new System.Drawing.Point(296, 9);
            this.lblRecNO.Name = "lblRecNO";
            this.lblRecNO.Size = new System.Drawing.Size(14, 14);
            this.lblRecNO.TabIndex = 196;
            this.lblRecNO.Text = "-";
            this.lblRecNO.Visible = false;
            // 
            // AppintmentReceipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1228, 568);
            this.Controls.Add(this.lblRecNO);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblJobID);
            this.Controls.Add(this.lnkCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAppointmentID);
            this.Controls.Add(this.lblinputTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSearchItem);
            this.Controls.Add(this.labelSearchItems);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCashierRefresh);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.linkLabelAllCatagory);
            this.Controls.Add(this.combCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppintmentReceipe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Appoinment Job Input";
            this.Load += new System.EventHandler(this.AppintmentReceipe_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppintmentReceipe_MouseDown);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox combCategory;
        private System.Windows.Forms.LinkLabel linkLabelAllCatagory;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView datagrdReportDetails;
        private System.Windows.Forms.Button btnCashierRefresh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridItems;
        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.Label labelSearchItems;
        private System.Windows.Forms.Button btnSave;
        private ResourceEditor.ResourceHolder resourceHolder1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblinputTotal;
        private System.Windows.Forms.LinkLabel lnkCategory;
        private System.Windows.Forms.Label lblJobID;
        private System.Windows.Forms.Label lblAppointmentID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblRecNO;
    }
}