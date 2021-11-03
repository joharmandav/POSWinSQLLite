namespace supershop.Customer
{
    partial class AddNewCustomer
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
            this.lblCustID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CombPeopleType = new System.Windows.Forms.ComboBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dtgviewCusttrxHistory = new System.Windows.Forms.DataGridView();
            this.txtTwitter = new System.Windows.Forms.TextBox();
            this.txtFacebook = new System.Windows.Forms.TextBox();
            this.txtInsta = new System.Windows.Forms.TextBox();
            this.txtNameArabic = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnAddAdvance = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lnkEye = new System.Windows.Forms.LinkLabel();
            this.lblEmailerrormsg = new System.Windows.Forms.Label();
            this.linkMedicalHistory = new System.Windows.Forms.LinkLabel();
            this.lblpeoplefag = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtDateofAnniversary = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkCustomers = new System.Windows.Forms.LinkLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbltoplabel = new System.Windows.Forms.Label();
            this.lblcuthistorylabel = new System.Windows.Forms.Label();
            this.grboxCusthistory = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewCusttrxHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grboxCusthistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCustID
            // 
            this.lblCustID.AutoSize = true;
            this.lblCustID.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblCustID.Location = new System.Drawing.Point(110, 18);
            this.lblCustID.Name = "lblCustID";
            this.lblCustID.Size = new System.Drawing.Size(8, 12);
            this.lblCustID.TabIndex = 1;
            this.lblCustID.Text = "-";
            this.lblCustID.TextChanged += new System.EventHandler(this.lblCustID_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(109, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "People Type *";
            // 
            // CombPeopleType
            // 
            this.CombPeopleType.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CombPeopleType.FormattingEnabled = true;
            this.CombPeopleType.Items.AddRange(new object[] {
            "Customer",
            "Supplier",
            "Biller"});
            this.CombPeopleType.Location = new System.Drawing.Point(112, 182);
            this.CombPeopleType.Name = "CombPeopleType";
            this.CombPeopleType.Size = new System.Drawing.Size(277, 21);
            this.CombPeopleType.TabIndex = 4;
            this.toolTip1.SetToolTip(this.CombPeopleType, "Select People type Customer or Biller");
            this.CombPeopleType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CombPeopleType_KeyPress);
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtEmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtEmailAddress.Location = new System.Drawing.Point(406, 182);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(277, 24);
            this.txtEmailAddress.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtEmailAddress, "People Email address");
            this.txtEmailAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmailAddress_KeyPress);
            this.txtEmailAddress.Leave += new System.EventHandler(this.txtEmailAddress_Leave);
            this.txtEmailAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmailAddress_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(403, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Email Address";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtCity.Location = new System.Drawing.Point(406, 49);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(277, 24);
            this.txtCity.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtCity, "People City");
            this.txtCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCity_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(403, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "City   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name   *";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtCustomerName.Location = new System.Drawing.Point(112, 49);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(277, 24);
            this.txtCustomerName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtCustomerName, "Customer Name");
            this.txtCustomerName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCustomerName_MouseClick);
            this.txtCustomerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerName_KeyPress);
            this.txtCustomerName.Leave += new System.EventHandler(this.txtCustomerName_Leave);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(444, 389);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(24, 16);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "----";
            this.lblMsg.Visible = false;
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.AcceptsReturn = true;
            this.txtCustomerAddress.AcceptsTab = true;
            this.txtCustomerAddress.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCustomerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtCustomerAddress.Location = new System.Drawing.Point(406, 96);
            this.txtCustomerAddress.Multiline = true;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(277, 66);
            this.txtCustomerAddress.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtCustomerAddress, "People Location Details");
            this.txtCustomerAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerAddress_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSave.ForeColor = System.Drawing.Color.YellowGreen;
            this.btnSave.Location = new System.Drawing.Point(406, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "I want to Submit");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtPhone.Location = new System.Drawing.Point(112, 137);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(277, 24);
            this.txtPhone.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtPhone, "Customer Contact Number");
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Phone  *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(403, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address  ";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 9;
            this.toolTip1.ReshowDelay = 9;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // dtgviewCusttrxHistory
            // 
            this.dtgviewCusttrxHistory.AllowUserToAddRows = false;
            this.dtgviewCusttrxHistory.AllowUserToDeleteRows = false;
            this.dtgviewCusttrxHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgviewCusttrxHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgviewCusttrxHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgviewCusttrxHistory.Location = new System.Drawing.Point(0, 0);
            this.dtgviewCusttrxHistory.Name = "dtgviewCusttrxHistory";
            this.dtgviewCusttrxHistory.ReadOnly = true;
            this.dtgviewCusttrxHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgviewCusttrxHistory.Size = new System.Drawing.Size(840, 90);
            this.dtgviewCusttrxHistory.TabIndex = 0;
            this.toolTip1.SetToolTip(this.dtgviewCusttrxHistory, "Click to view Due payment");
            this.dtgviewCusttrxHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgviewCusttrxHistory_CellClick);
            // 
            // txtTwitter
            // 
            this.txtTwitter.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTwitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtTwitter.Location = new System.Drawing.Point(406, 315);
            this.txtTwitter.Name = "txtTwitter";
            this.txtTwitter.Size = new System.Drawing.Size(277, 24);
            this.txtTwitter.TabIndex = 13;
            this.toolTip1.SetToolTip(this.txtTwitter, "People Email address");
            this.txtTwitter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTwitter_KeyPress);
            // 
            // txtFacebook
            // 
            this.txtFacebook.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtFacebook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtFacebook.Location = new System.Drawing.Point(406, 271);
            this.txtFacebook.Name = "txtFacebook";
            this.txtFacebook.Size = new System.Drawing.Size(277, 24);
            this.txtFacebook.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtFacebook, "People Email address");
            this.txtFacebook.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTwitter_KeyPress);
            // 
            // txtInsta
            // 
            this.txtInsta.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtInsta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtInsta.Location = new System.Drawing.Point(406, 226);
            this.txtInsta.Name = "txtInsta";
            this.txtInsta.Size = new System.Drawing.Size(277, 24);
            this.txtInsta.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtInsta, "People Email address");
            this.txtInsta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTwitter_KeyPress);
            // 
            // txtNameArabic
            // 
            this.txtNameArabic.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNameArabic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtNameArabic.Location = new System.Drawing.Point(112, 95);
            this.txtNameArabic.Name = "txtNameArabic";
            this.txtNameArabic.Size = new System.Drawing.Size(277, 24);
            this.txtNameArabic.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtNameArabic, "Customer Name");
            this.txtNameArabic.Enter += new System.EventHandler(this.txtNameArabic_Enter);
            this.txtNameArabic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerName_KeyPress);
            this.txtNameArabic.LostFocus += new System.EventHandler(this.txtNameArabic_LostFocus);
            // 
            // txtRemark
            // 
            this.txtRemark.AcceptsReturn = true;
            this.txtRemark.AcceptsTab = true;
            this.txtRemark.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtRemark.Location = new System.Drawing.Point(112, 315);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(277, 66);
            this.txtRemark.TabIndex = 29;
            this.toolTip1.SetToolTip(this.txtRemark, "People Location Details");
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            // 
            // btnAddAdvance
            // 
            this.btnAddAdvance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddAdvance.FlatAppearance.BorderSize = 0;
            this.btnAddAdvance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddAdvance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddAdvance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAddAdvance.ForeColor = System.Drawing.Color.YellowGreen;
            this.btnAddAdvance.Location = new System.Drawing.Point(543, 357);
            this.btnAddAdvance.Name = "btnAddAdvance";
            this.btnAddAdvance.Size = new System.Drawing.Size(140, 29);
            this.btnAddAdvance.TabIndex = 196;
            this.btnAddAdvance.Text = "Add Advance";
            this.toolTip1.SetToolTip(this.btnAddAdvance, "I want to Submit");
            this.btnAddAdvance.UseVisualStyleBackColor = false;
            this.btnAddAdvance.Visible = false;
            this.btnAddAdvance.Click += new System.EventHandler(this.btnAddAdvance_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.btnAddAdvance);
            this.splitContainer1.Panel1.Controls.Add(this.lnkEye);
            this.splitContainer1.Panel1.Controls.Add(this.lblEmailerrormsg);
            this.splitContainer1.Panel1.Controls.Add(this.linkMedicalHistory);
            this.splitContainer1.Panel1.Controls.Add(this.lblpeoplefag);
            this.splitContainer1.Panel1.Controls.Add(this.txtRemark);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.dtDateofAnniversary);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.dtDateOfBirth);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.txtNameArabic);
            this.splitContainer1.Panel1.Controls.Add(this.txtInsta);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.txtFacebook);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txtTwitter);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lnkCustomers);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustID);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomerName);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.lblMsg);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomerAddress);
            this.splitContainer1.Panel1.Controls.Add(this.CombPeopleType);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.txtEmailAddress);
            this.splitContainer1.Panel1.Controls.Add(this.txtCity);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtPhone);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(840, 593);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.TabIndex = 0;
            // 
            // lnkEye
            // 
            this.lnkEye.AutoSize = true;
            this.lnkEye.Location = new System.Drawing.Point(735, 79);
            this.lnkEye.Name = "lnkEye";
            this.lnkEye.Size = new System.Drawing.Size(25, 13);
            this.lnkEye.TabIndex = 195;
            this.lnkEye.TabStop = true;
            this.lnkEye.Text = "Eye";
            this.lnkEye.Visible = false;
            this.lnkEye.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEye_LinkClicked);
            // 
            // lblEmailerrormsg
            // 
            this.lblEmailerrormsg.AutoSize = true;
            this.lblEmailerrormsg.ForeColor = System.Drawing.Color.Red;
            this.lblEmailerrormsg.Location = new System.Drawing.Point(502, 165);
            this.lblEmailerrormsg.Name = "lblEmailerrormsg";
            this.lblEmailerrormsg.Size = new System.Drawing.Size(10, 13);
            this.lblEmailerrormsg.TabIndex = 194;
            this.lblEmailerrormsg.Text = "-";
            this.lblEmailerrormsg.Visible = false;
            // 
            // linkMedicalHistory
            // 
            this.linkMedicalHistory.AutoSize = true;
            this.linkMedicalHistory.Location = new System.Drawing.Point(735, 49);
            this.linkMedicalHistory.Name = "linkMedicalHistory";
            this.linkMedicalHistory.Size = new System.Drawing.Size(79, 13);
            this.linkMedicalHistory.TabIndex = 31;
            this.linkMedicalHistory.TabStop = true;
            this.linkMedicalHistory.Text = "Medical History";
            this.linkMedicalHistory.Visible = false;
            this.linkMedicalHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMedicalHistory_LinkClicked);
            // 
            // lblpeoplefag
            // 
            this.lblpeoplefag.AutoSize = true;
            this.lblpeoplefag.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblpeoplefag.Location = new System.Drawing.Point(789, 9);
            this.lblpeoplefag.Name = "lblpeoplefag";
            this.lblpeoplefag.Size = new System.Drawing.Size(8, 12);
            this.lblpeoplefag.TabIndex = 30;
            this.lblpeoplefag.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(109, 298);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Notes";
            // 
            // dtDateofAnniversary
            // 
            this.dtDateofAnniversary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateofAnniversary.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateofAnniversary.Location = new System.Drawing.Point(112, 271);
            this.dtDateofAnniversary.Name = "dtDateofAnniversary";
            this.dtDateofAnniversary.Size = new System.Drawing.Size(277, 24);
            this.dtDateofAnniversary.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(109, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Date of Anniversary ";
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateOfBirth.Location = new System.Drawing.Point(112, 226);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.Size = new System.Drawing.Size(277, 24);
            this.dtDateOfBirth.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(109, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Date of Birth ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(109, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Name  in Arabic  *";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(403, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Instagram";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(403, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "FaceBook";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(403, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Twitter";
            // 
            // lnkCustomers
            // 
            this.lnkCustomers.AutoSize = true;
            this.lnkCustomers.Location = new System.Drawing.Point(614, 393);
            this.lnkCustomers.Name = "lnkCustomers";
            this.lnkCustomers.Size = new System.Drawing.Size(71, 13);
            this.lnkCustomers.TabIndex = 0;
            this.lnkCustomers.TabStop = true;
            this.lnkCustomers.Text = "Customers list";
            this.lnkCustomers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomers_LinkClicked);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbltoplabel);
            this.splitContainer2.Panel1.Controls.Add(this.lblcuthistorylabel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grboxCusthistory);
            this.splitContainer2.Size = new System.Drawing.Size(840, 124);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.TabIndex = 19;
            // 
            // lbltoplabel
            // 
            this.lbltoplabel.AutoSize = true;
            this.lbltoplabel.Location = new System.Drawing.Point(563, 6);
            this.lbltoplabel.Name = "lbltoplabel";
            this.lbltoplabel.Size = new System.Drawing.Size(265, 13);
            this.lbltoplabel.TabIndex = 1;
            this.lbltoplabel.Text = "Click top fo the row to view details due payment history";
            this.lbltoplabel.Visible = false;
            // 
            // lblcuthistorylabel
            // 
            this.lblcuthistorylabel.AutoSize = true;
            this.lblcuthistorylabel.Location = new System.Drawing.Point(3, 6);
            this.lblcuthistorylabel.Name = "lblcuthistorylabel";
            this.lblcuthistorylabel.Size = new System.Drawing.Size(150, 13);
            this.lblcuthistorylabel.TabIndex = 0;
            this.lblcuthistorylabel.Text = "Customer\'s Transaction history";
            this.lblcuthistorylabel.Visible = false;
            // 
            // grboxCusthistory
            // 
            this.grboxCusthistory.Controls.Add(this.dtgviewCusttrxHistory);
            this.grboxCusthistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grboxCusthistory.Location = new System.Drawing.Point(0, 0);
            this.grboxCusthistory.Name = "grboxCusthistory";
            this.grboxCusthistory.Size = new System.Drawing.Size(840, 90);
            this.grboxCusthistory.TabIndex = 1;
            this.grboxCusthistory.Visible = false;
            // 
            // AddNewCustomer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(840, 593);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddNewCustomer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New People";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNewCustomer_FormClosed);
            this.Load += new System.EventHandler(this.AddNewCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewCusttrxHistory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grboxCusthistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CombPeopleType;
        private System.Windows.Forms.Label lblCustID;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.LinkLabel lnkCustomers;
        private System.Windows.Forms.DataGridView dtgviewCusttrxHistory;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblcuthistorylabel;
        private System.Windows.Forms.Panel grboxCusthistory;
        private System.Windows.Forms.Label lbltoplabel;
        private System.Windows.Forms.TextBox txtInsta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFacebook;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTwitter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNameArabic;
        private System.Windows.Forms.DateTimePicker dtDateOfBirth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtDateofAnniversary;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblpeoplefag;
        private System.Windows.Forms.LinkLabel linkMedicalHistory;
        private System.Windows.Forms.Label lblEmailerrormsg;
        private System.Windows.Forms.LinkLabel lnkEye;
        private System.Windows.Forms.Button btnAddAdvance;
    }
}