namespace supershop
{
    partial class Add_PaymentType
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
            this.lblPageName = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPayTypeArabic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPayTypeName = new System.Windows.Forms.TextBox();
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
            this.lblID.Location = new System.Drawing.Point(39, 31);
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
            this.splitContainer1.Panel1.Controls.Add(this.lblPageName);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtPayTypeArabic);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblID);
            this.splitContainer1.Panel1.Controls.Add(this.txtPayTypeName);
            this.splitContainer1.Panel1.Controls.Add(this.lblMsg);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Size = new System.Drawing.Size(489, 303);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 17;
            // 
            // lblPageName
            // 
            this.lblPageName.AutoSize = true;
            this.lblPageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F);
            this.lblPageName.Location = new System.Drawing.Point(252, 9);
            this.lblPageName.Name = "lblPageName";
            this.lblPageName.Size = new System.Drawing.Size(4, 4);
            this.lblPageName.TabIndex = 102;
            this.lblPageName.Text = "-";
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
            this.btnReset.Location = new System.Drawing.Point(241, 150);
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
            this.label2.Location = new System.Drawing.Point(40, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Paymet Type in Arabic  *";
            // 
            // txtPayTypeArabic
            // 
            this.txtPayTypeArabic.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPayTypeArabic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtPayTypeArabic.Location = new System.Drawing.Point(43, 105);
            this.txtPayTypeArabic.Name = "txtPayTypeArabic";
            this.txtPayTypeArabic.Size = new System.Drawing.Size(277, 24);
            this.txtPayTypeArabic.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtPayTypeArabic, "Add Payment Type");
            this.txtPayTypeArabic.Enter += new System.EventHandler(this.txtPayTypeArabic_Enter);
            this.txtPayTypeArabic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayTypeArabic_KeyPress);
            this.txtPayTypeArabic.Leave += new System.EventHandler(this.txtPayTypeArabic_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Payment Type in English  *";
            // 
            // txtPayTypeName
            // 
            this.txtPayTypeName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPayTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtPayTypeName.Location = new System.Drawing.Point(41, 62);
            this.txtPayTypeName.Name = "txtPayTypeName";
            this.txtPayTypeName.Size = new System.Drawing.Size(277, 24);
            this.txtPayTypeName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtPayTypeName, "Add Payment Type Name");
            this.txtPayTypeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayTypeName_KeyPress);
            this.txtPayTypeName.Leave += new System.EventHandler(this.txtPayTypeName_Leave);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(80, 239);
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
            this.btnSave.Location = new System.Drawing.Point(46, 150);
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
            // Add_PaymentType
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 303);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Add_PaymentType";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Payment Type";
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
        private System.Windows.Forms.TextBox txtPayTypeName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPayTypeArabic;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblPageName;
    }
}