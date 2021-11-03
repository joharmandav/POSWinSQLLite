namespace supershop
{
    partial class AppointmentS1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentS1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnCashierRefresh = new System.Windows.Forms.Button();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.datagrdReportDetails = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnJobRefrash = new System.Windows.Forms.Button();
            this.chkPending = new System.Windows.Forms.CheckBox();
            this.chkComplated = new System.Windows.Forms.CheckBox();
            this.chkShowall = new System.Windows.Forms.CheckBox();
            this.btnCreateInvoice = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.AddJob = new System.Windows.Forms.Button();
            this.lblApoint = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DatagridJob = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagridJob)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Crimson;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReset.Location = new System.Drawing.Point(899, 32);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(180, 37);
            this.btnReset.TabIndex = 161;
            this.btnReset.Text = "Back To DashBoard";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(165, 49);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(130, 21);
            this.dtEndDate.TabIndex = 97;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label3.Location = new System.Drawing.Point(162, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Report by To date";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(115, 11);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(10, 13);
            this.lblMsg.TabIndex = 95;
            this.lblMsg.Text = "-";
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
            this.btnCashierRefresh.Location = new System.Drawing.Point(306, 45);
            this.btnCashierRefresh.Name = "btnCashierRefresh";
            this.btnCashierRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnCashierRefresh.TabIndex = 94;
            this.btnCashierRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashierRefresh.UseVisualStyleBackColor = false;
            this.btnCashierRefresh.Click += new System.EventHandler(this.btnCashierRefresh_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(15, 49);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(130, 21);
            this.dtStartDate.TabIndex = 90;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label9.Location = new System.Drawing.Point(12, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 88;
            this.label9.Text = "Report by From date";
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.dtEndDate);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lblMsg);
            this.splitContainer1.Panel1.Controls.Add(this.btnCashierRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.dtStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1096, 489);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Today";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(53, 11);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(31, 13);
            this.lblStartDate.TabIndex = 94;
            this.lblStartDate.Text = "____";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(666, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 37);
            this.button1.TabIndex = 162;
            this.button1.Text = "Add New Appointment";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.datagrdReportDetails);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1096, 403);
            this.splitContainer2.SplitterDistance = 193;
            this.splitContainer2.TabIndex = 0;
            // 
            // datagrdReportDetails
            // 
            this.datagrdReportDetails.AllowUserToAddRows = false;
            this.datagrdReportDetails.AllowUserToDeleteRows = false;
            this.datagrdReportDetails.AllowUserToResizeColumns = false;
            this.datagrdReportDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.datagrdReportDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.datagrdReportDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrdReportDetails.BackgroundColor = System.Drawing.Color.White;
            this.datagrdReportDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdReportDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.datagrdReportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 11F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrdReportDetails.DefaultCellStyle = dataGridViewCellStyle11;
            this.datagrdReportDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrdReportDetails.Location = new System.Drawing.Point(0, 0);
            this.datagrdReportDetails.Name = "datagrdReportDetails";
            this.datagrdReportDetails.ReadOnly = true;
            this.datagrdReportDetails.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.datagrdReportDetails.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.datagrdReportDetails.RowTemplate.Height = 44;
            this.datagrdReportDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdReportDetails.Size = new System.Drawing.Size(1096, 193);
            this.datagrdReportDetails.TabIndex = 3;
            this.datagrdReportDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellClick);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.DatagridJob);
            this.splitContainer3.Size = new System.Drawing.Size(1096, 206);
            this.splitContainer3.SplitterDistance = 34;
            this.splitContainer3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnJobRefrash);
            this.panel1.Controls.Add(this.chkPending);
            this.panel1.Controls.Add(this.chkComplated);
            this.panel1.Controls.Add(this.chkShowall);
            this.panel1.Controls.Add(this.btnCreateInvoice);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.AddJob);
            this.panel1.Controls.Add(this.lblApoint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 34);
            this.panel1.TabIndex = 0;
            // 
            // btnJobRefrash
            // 
            this.btnJobRefrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJobRefrash.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnJobRefrash.FlatAppearance.BorderSize = 0;
            this.btnJobRefrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnJobRefrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobRefrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnJobRefrash.Image = ((System.Drawing.Image)(resources.GetObject("btnJobRefrash.Image")));
            this.btnJobRefrash.Location = new System.Drawing.Point(732, 6);
            this.btnJobRefrash.Name = "btnJobRefrash";
            this.btnJobRefrash.Size = new System.Drawing.Size(25, 25);
            this.btnJobRefrash.TabIndex = 169;
            this.btnJobRefrash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnJobRefrash.UseVisualStyleBackColor = false;
            this.btnJobRefrash.Click += new System.EventHandler(this.btnJobRefrash_Click);
            // 
            // chkPending
            // 
            this.chkPending.AutoSize = true;
            this.chkPending.Location = new System.Drawing.Point(644, 12);
            this.chkPending.Name = "chkPending";
            this.chkPending.Size = new System.Drawing.Size(65, 17);
            this.chkPending.TabIndex = 168;
            this.chkPending.Text = "Pending";
            this.chkPending.UseVisualStyleBackColor = true;
            this.chkPending.CheckedChanged += new System.EventHandler(this.chkPending_CheckedChanged);
            // 
            // chkComplated
            // 
            this.chkComplated.AutoSize = true;
            this.chkComplated.Location = new System.Drawing.Point(562, 12);
            this.chkComplated.Name = "chkComplated";
            this.chkComplated.Size = new System.Drawing.Size(76, 17);
            this.chkComplated.TabIndex = 167;
            this.chkComplated.Text = "Completed";
            this.chkComplated.UseVisualStyleBackColor = true;
            this.chkComplated.CheckedChanged += new System.EventHandler(this.chkComplated_CheckedChanged);
            // 
            // chkShowall
            // 
            this.chkShowall.AutoSize = true;
            this.chkShowall.Checked = true;
            this.chkShowall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowall.Location = new System.Drawing.Point(489, 12);
            this.chkShowall.Name = "chkShowall";
            this.chkShowall.Size = new System.Drawing.Size(67, 17);
            this.chkShowall.TabIndex = 166;
            this.chkShowall.Text = "Show All";
            this.chkShowall.UseVisualStyleBackColor = true;
            this.chkShowall.CheckedChanged += new System.EventHandler(this.chkShowall_CheckedChanged);
            // 
            // btnCreateInvoice
            // 
            this.btnCreateInvoice.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCreateInvoice.FlatAppearance.BorderSize = 0;
            this.btnCreateInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnCreateInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCreateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateInvoice.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateInvoice.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCreateInvoice.Location = new System.Drawing.Point(787, 2);
            this.btnCreateInvoice.Name = "btnCreateInvoice";
            this.btnCreateInvoice.Size = new System.Drawing.Size(134, 32);
            this.btnCreateInvoice.TabIndex = 165;
            this.btnCreateInvoice.Text = "Create Invoice";
            this.btnCreateInvoice.UseVisualStyleBackColor = false;
            this.btnCreateInvoice.Visible = false;
            this.btnCreateInvoice.Click += new System.EventHandler(this.btnCreateInvoice_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(291, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 26);
            this.label4.TabIndex = 164;
            this.label4.Text = "Show Jobs";
            // 
            // AddJob
            // 
            this.AddJob.BackColor = System.Drawing.Color.SeaGreen;
            this.AddJob.FlatAppearance.BorderSize = 0;
            this.AddJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.AddJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.AddJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddJob.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJob.ForeColor = System.Drawing.SystemColors.Window;
            this.AddJob.Location = new System.Drawing.Point(950, 2);
            this.AddJob.Name = "AddJob";
            this.AddJob.Size = new System.Drawing.Size(134, 32);
            this.AddJob.TabIndex = 163;
            this.AddJob.Text = "Add New Job";
            this.AddJob.UseVisualStyleBackColor = false;
            this.AddJob.Click += new System.EventHandler(this.AddJob_Click);
            // 
            // lblApoint
            // 
            this.lblApoint.AutoSize = true;
            this.lblApoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApoint.ForeColor = System.Drawing.Color.Red;
            this.lblApoint.Location = new System.Drawing.Point(160, 5);
            this.lblApoint.Name = "lblApoint";
            this.lblApoint.Size = new System.Drawing.Size(19, 25);
            this.lblApoint.TabIndex = 1;
            this.lblApoint.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(247)))), ((int)(((byte)(234)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointment ID :";
            // 
            // DatagridJob
            // 
            this.DatagridJob.AllowUserToAddRows = false;
            this.DatagridJob.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.DatagridJob.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.DatagridJob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DatagridJob.BackgroundColor = System.Drawing.Color.White;
            this.DatagridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DatagridJob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DatagridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 11F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DatagridJob.DefaultCellStyle = dataGridViewCellStyle15;
            this.DatagridJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatagridJob.Location = new System.Drawing.Point(0, 0);
            this.DatagridJob.Name = "DatagridJob";
            this.DatagridJob.ReadOnly = true;
            this.DatagridJob.RowHeadersVisible = false;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.DatagridJob.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DatagridJob.RowTemplate.Height = 44;
            this.DatagridJob.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatagridJob.Size = new System.Drawing.Size(1096, 168);
            this.DatagridJob.TabIndex = 3;
            this.DatagridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagridJob_CellClick);
            this.DatagridJob.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DatagridJob_DataBindingComplete);
            // 
            // AppointmentS1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 489);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AppointmentS1";
            this.Text = "Appointment";
            this.Load += new System.EventHandler(this.AppointmentS_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagridJob)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnCashierRefresh;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView datagrdReportDetails;
        private System.Windows.Forms.DataGridView DatagridJob;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblApoint;
        private System.Windows.Forms.Button AddJob;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateInvoice;
        private System.Windows.Forms.CheckBox chkPending;
        private System.Windows.Forms.CheckBox chkComplated;
        private System.Windows.Forms.CheckBox chkShowall;
        private System.Windows.Forms.Button btnJobRefrash;
    }
}