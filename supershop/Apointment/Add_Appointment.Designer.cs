namespace supershop
{
    partial class Add_Appointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Appointment));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAPOtitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.comboCustomer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.combostatus = new System.Windows.Forms.ComboBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtstTime = new System.Windows.Forms.DateTimePicker();
            this.lblAppintmentID = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnCashierRefresh = new System.Windows.Forms.Button();
            this.comboReciepe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkCustomerHistory = new System.Windows.Forms.LinkLabel();
            this.btnCustomerAdd = new System.Windows.Forms.Button();
            this.lblCustomerAddFLag = new System.Windows.Forms.Label();
            this.GridAppintment = new System.Windows.Forms.DataGridView();
            this.btnAppGridAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFirstEmployee = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridAppintment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Apointment Title";
            // 
            // txtAPOtitle
            // 
            this.txtAPOtitle.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtAPOtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtAPOtitle.Location = new System.Drawing.Point(34, 183);
            this.txtAPOtitle.Name = "txtAPOtitle";
            this.txtAPOtitle.Size = new System.Drawing.Size(305, 24);
            this.txtAPOtitle.TabIndex = 7;
            this.txtAPOtitle.Enter += new System.EventHandler(this.txtAPOtitle_Enter);
            this.txtAPOtitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAPOtitle_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Expected Start Date";
            // 
            // dateFrom
            // 
            this.dateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(34, 133);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(140, 24);
            this.dateFrom.TabIndex = 5;
            this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // comboCustomer
            // 
            this.comboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboCustomer.FormattingEnabled = true;
            this.comboCustomer.Location = new System.Drawing.Point(43, 38);
            this.comboCustomer.Name = "comboCustomer";
            this.comboCustomer.Size = new System.Drawing.Size(305, 21);
            this.comboCustomer.TabIndex = 2;
            this.comboCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboCustomer_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 193;
            this.label8.Text = "Status";
            // 
            // combostatus
            // 
            this.combostatus.FormattingEnabled = true;
            this.combostatus.Items.AddRange(new object[] {
            "Confirmed",
            "Not Confirmed",
            "No Answer",
            "In Waiting",
            "Visited",
            "Closed",
            "Canceled",
            "No Status"});
            this.combostatus.Location = new System.Drawing.Point(43, 395);
            this.combostatus.Name = "combostatus";
            this.combostatus.Size = new System.Drawing.Size(305, 21);
            this.combostatus.TabIndex = 9;
            this.combostatus.Text = "Confirmed";
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.OrangeRed;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnexit.Location = new System.Drawing.Point(241, 429);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(107, 39);
            this.btnexit.TabIndex = 11;
            this.btnexit.Text = "Exit";
            this.btnexit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(43, 429);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 39);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtstTime
            // 
            this.dtstTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtstTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtstTime.Location = new System.Drawing.Point(193, 133);
            this.dtstTime.Name = "dtstTime";
            this.dtstTime.Size = new System.Drawing.Size(146, 24);
            this.dtstTime.TabIndex = 6;
            this.dtstTime.ValueChanged += new System.EventHandler(this.dtstTime_ValueChanged);
            // 
            // lblAppintmentID
            // 
            this.lblAppintmentID.AutoSize = true;
            this.lblAppintmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppintmentID.Location = new System.Drawing.Point(210, 167);
            this.lblAppintmentID.Name = "lblAppintmentID";
            this.lblAppintmentID.Size = new System.Drawing.Size(10, 13);
            this.lblAppintmentID.TabIndex = 200;
            this.lblAppintmentID.Text = "-";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(276, 22);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(51, 13);
            this.linkLabel1.TabIndex = 201;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add New";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
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
            this.btnCashierRefresh.Location = new System.Drawing.Point(349, 34);
            this.btnCashierRefresh.Name = "btnCashierRefresh";
            this.btnCashierRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnCashierRefresh.TabIndex = 202;
            this.btnCashierRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashierRefresh.UseVisualStyleBackColor = false;
            this.btnCashierRefresh.Click += new System.EventHandler(this.btnCashierRefresh_Click);
            // 
            // comboReciepe
            // 
            this.comboReciepe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboReciepe.FormattingEnabled = true;
            this.comboReciepe.Location = new System.Drawing.Point(34, 33);
            this.comboReciepe.Name = "comboReciepe";
            this.comboReciepe.Size = new System.Drawing.Size(305, 21);
            this.comboReciepe.TabIndex = 3;
            this.comboReciepe.SelectedIndexChanged += new System.EventHandler(this.comboReciepe_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 215;
            this.label5.Text = "Preferred Employer";
            // 
            // comboEmployee
            // 
            this.comboEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(34, 84);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(305, 21);
            this.comboEmployee.TabIndex = 4;
            this.comboEmployee.SelectedIndexChanged += new System.EventHandler(this.comboEmployee_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 217;
            this.label6.Text = "remark";
            // 
            // txtremark
            // 
            this.txtremark.AcceptsReturn = true;
            this.txtremark.AcceptsTab = true;
            this.txtremark.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtremark.Location = new System.Drawing.Point(34, 228);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(305, 63);
            this.txtremark.TabIndex = 8;
            this.txtremark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtremark_KeyPress);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.Location = new System.Drawing.Point(40, 22);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(51, 13);
            this.linkLabel2.TabIndex = 218;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Customer";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel3.Location = new System.Drawing.Point(31, 17);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(112, 13);
            this.linkLabel3.TabIndex = 219;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Use Service Template";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkCustomerHistory
            // 
            this.linkCustomerHistory.AutoSize = true;
            this.linkCustomerHistory.Location = new System.Drawing.Point(148, 22);
            this.linkCustomerHistory.Name = "linkCustomerHistory";
            this.linkCustomerHistory.Size = new System.Drawing.Size(86, 13);
            this.linkCustomerHistory.TabIndex = 220;
            this.linkCustomerHistory.TabStop = true;
            this.linkCustomerHistory.Text = "Customer History";
            this.linkCustomerHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCustomerHistory_LinkClicked);
            // 
            // btnCustomerAdd
            // 
            this.btnCustomerAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCustomerAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCustomerAdd.FlatAppearance.BorderSize = 0;
            this.btnCustomerAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCustomerAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCustomerAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerAdd.Image")));
            this.btnCustomerAdd.Location = new System.Drawing.Point(387, 30);
            this.btnCustomerAdd.Name = "btnCustomerAdd";
            this.btnCustomerAdd.Size = new System.Drawing.Size(34, 35);
            this.btnCustomerAdd.TabIndex = 221;
            this.btnCustomerAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCustomerAdd.UseVisualStyleBackColor = false;
            this.btnCustomerAdd.Click += new System.EventHandler(this.btnCustomerAdd_Click);
            // 
            // lblCustomerAddFLag
            // 
            this.lblCustomerAddFLag.AutoSize = true;
            this.lblCustomerAddFLag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerAddFLag.Location = new System.Drawing.Point(107, 21);
            this.lblCustomerAddFLag.Name = "lblCustomerAddFLag";
            this.lblCustomerAddFLag.Size = new System.Drawing.Size(10, 13);
            this.lblCustomerAddFLag.TabIndex = 222;
            this.lblCustomerAddFLag.Text = "-";
            // 
            // GridAppintment
            // 
            this.GridAppintment.AllowUserToAddRows = false;
            this.GridAppintment.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridAppintment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridAppintment.Location = new System.Drawing.Point(12, 482);
            this.GridAppintment.Name = "GridAppintment";
            this.GridAppintment.RowHeadersVisible = false;
            this.GridAppintment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridAppintment.Size = new System.Drawing.Size(597, 109);
            this.GridAppintment.TabIndex = 223;
            this.GridAppintment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridAppintment_CellContentClick);
            // 
            // btnAppGridAdd
            // 
            this.btnAppGridAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAppGridAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAppGridAdd.FlatAppearance.BorderSize = 0;
            this.btnAppGridAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAppGridAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppGridAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAppGridAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAppGridAdd.Image")));
            this.btnAppGridAdd.Location = new System.Drawing.Point(354, 256);
            this.btnAppGridAdd.Name = "btnAppGridAdd";
            this.btnAppGridAdd.Size = new System.Drawing.Size(34, 35);
            this.btnAppGridAdd.TabIndex = 224;
            this.btnAppGridAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAppGridAdd.UseVisualStyleBackColor = false;
            this.btnAppGridAdd.Click += new System.EventHandler(this.btnAppGridAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.lblFirstEmployee);
            this.groupBox1.Controls.Add(this.linkLabel3);
            this.groupBox1.Controls.Add(this.btnAppGridAdd);
            this.groupBox1.Controls.Add(this.txtAPOtitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Controls.Add(this.dtstTime);
            this.groupBox1.Controls.Add(this.lblAppintmentID);
            this.groupBox1.Controls.Add(this.comboReciepe);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboEmployee);
            this.groupBox1.Controls.Add(this.txtremark);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 308);
            this.groupBox1.TabIndex = 225;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JobBox";
            // 
            // lblFirstEmployee
            // 
            this.lblFirstEmployee.AutoSize = true;
            this.lblFirstEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstEmployee.Location = new System.Drawing.Point(155, 68);
            this.lblFirstEmployee.Name = "lblFirstEmployee";
            this.lblFirstEmployee.Size = new System.Drawing.Size(10, 13);
            this.lblFirstEmployee.TabIndex = 226;
            this.lblFirstEmployee.Text = "-";
            this.lblFirstEmployee.Visible = false;
            // 
            // Add_Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(621, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GridAppintment);
            this.Controls.Add(this.lblCustomerAddFLag);
            this.Controls.Add(this.btnCustomerAdd);
            this.Controls.Add(this.linkCustomerHistory);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.btnCashierRefresh);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.combostatus);
            this.Controls.Add(this.comboCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_Appointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Appointment";
            this.Load += new System.EventHandler(this.Add_Appointment_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_Appointment_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.GridAppintment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAPOtitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.ComboBox comboCustomer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combostatus;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtstTime;
        private System.Windows.Forms.Label lblAppintmentID;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnCashierRefresh;
        private System.Windows.Forms.ComboBox comboReciepe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkCustomerHistory;
        private System.Windows.Forms.Button btnCustomerAdd;
        private System.Windows.Forms.Label lblCustomerAddFLag;
        private System.Windows.Forms.DataGridView GridAppintment;
        private System.Windows.Forms.Button btnAppGridAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFirstEmployee;
    }
}