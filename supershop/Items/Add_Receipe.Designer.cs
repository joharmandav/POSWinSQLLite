namespace supershop.Items
{
    partial class Add_Receipe
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
            this.lblID = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblMinute = new System.Windows.Forms.Label();
            this.dtstTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRecType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDaysinExpire = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReceipeArabic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReceipeName = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblID.Location = new System.Drawing.Point(39, 22);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(8, 12);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "-";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblMinute);
            this.splitContainer1.Panel1.Controls.Add(this.dtstTime);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.cmbRecType);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtDaysinExpire);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtReceipeArabic);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblID);
            this.splitContainer1.Panel1.Controls.Add(this.txtReceipeName);
            this.splitContainer1.Panel1.Controls.Add(this.lblMsg);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Size = new System.Drawing.Size(489, 392);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 17;
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblMinute.Location = new System.Drawing.Point(282, 180);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(8, 12);
            this.lblMinute.TabIndex = 110;
            this.lblMinute.Text = "-";
            // 
            // dtstTime
            // 
            this.dtstTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtstTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtstTime.Location = new System.Drawing.Point(41, 194);
            this.dtstTime.Name = "dtstTime";
            this.dtstTime.Size = new System.Drawing.Size(277, 24);
            this.dtstTime.TabIndex = 109;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 13);
            this.label5.TabIndex = 108;
            this.label5.Text = "Hours Required to complete Job";
            // 
            // cmbRecType
            // 
            this.cmbRecType.FormattingEnabled = true;
            this.cmbRecType.Items.AddRange(new object[] {
            "Receipe",
            "Package"});
            this.cmbRecType.Location = new System.Drawing.Point(41, 150);
            this.cmbRecType.Name = "cmbRecType";
            this.cmbRecType.Size = new System.Drawing.Size(277, 21);
            this.cmbRecType.TabIndex = 107;
            this.cmbRecType.Text = "Receipe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Receipe / Package *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Days In Expire *";
            // 
            // txtDaysinExpire
            // 
            this.txtDaysinExpire.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtDaysinExpire.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDaysinExpire.Location = new System.Drawing.Point(41, 244);
            this.txtDaysinExpire.Name = "txtDaysinExpire";
            this.txtDaysinExpire.Size = new System.Drawing.Size(277, 24);
            this.txtDaysinExpire.TabIndex = 102;
            this.txtDaysinExpire.Text = "0";
            this.toolTip1.SetToolTip(this.txtDaysinExpire, "Add category Name");
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Crimson;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReset.Location = new System.Drawing.Point(241, 278);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 28);
            this.btnReset.TabIndex = 101;
            this.btnReset.Text = "Exit";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Receipe / Package Name in Arabic  *";
            // 
            // txtReceipeArabic
            // 
            this.txtReceipeArabic.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtReceipeArabic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtReceipeArabic.Location = new System.Drawing.Point(41, 106);
            this.txtReceipeArabic.Name = "txtReceipeArabic";
            this.txtReceipeArabic.Size = new System.Drawing.Size(277, 24);
            this.txtReceipeArabic.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtReceipeArabic, "Add category Name");
            this.txtReceipeArabic.Enter += new System.EventHandler(this.txtReceipeArabic_Enter);
            this.txtReceipeArabic.LostFocus += new System.EventHandler(this.txtReceipeArabic_LostFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Receipe / Package Name in English  *";
            // 
            // txtReceipeName
            // 
            this.txtReceipeName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtReceipeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtReceipeName.Location = new System.Drawing.Point(41, 62);
            this.txtReceipeName.Name = "txtReceipeName";
            this.txtReceipeName.Size = new System.Drawing.Size(277, 24);
            this.txtReceipeName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtReceipeName, "Add category Name");
            this.txtReceipeName.Leave += new System.EventHandler(this.txtReceipeName_Leave);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(80, 335);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(24, 16);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "----";
            this.lblMsg.Visible = false;
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
            this.btnSave.Location = new System.Drawing.Point(46, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "I want to Submit");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 9;
            this.toolTip1.ReshowDelay = 9;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // Add_Receipe
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 392);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Add_Receipe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Receipe / Package";
            this.Load += new System.EventHandler(this.Add_Receipe_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReceipeName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReceipeArabic;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDaysinExpire;
        private System.Windows.Forms.ComboBox cmbRecType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtstTime;
        private System.Windows.Forms.Label lblMinute;
    }
}