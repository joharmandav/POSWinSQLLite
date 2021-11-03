namespace supershop
{
    partial class LocalserverConnection
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
            this.txtPassDB = new System.Windows.Forms.TextBox();
            this.txtUserDB = new System.Windows.Forms.TextBox();
            this.cboDatabases = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtSqlAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.cbxIntegrated = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPassDB
            // 
            this.txtPassDB.Location = new System.Drawing.Point(135, 89);
            this.txtPassDB.Name = "txtPassDB";
            this.txtPassDB.PasswordChar = '*';
            this.txtPassDB.Size = new System.Drawing.Size(186, 20);
            this.txtPassDB.TabIndex = 16;
            this.txtPassDB.Visible = false;
            // 
            // txtUserDB
            // 
            this.txtUserDB.Location = new System.Drawing.Point(135, 56);
            this.txtUserDB.Name = "txtUserDB";
            this.txtUserDB.Size = new System.Drawing.Size(186, 20);
            this.txtUserDB.TabIndex = 14;
            this.txtUserDB.Visible = false;
            // 
            // cboDatabases
            // 
            this.cboDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabases.Enabled = false;
            this.cboDatabases.FormattingEnabled = true;
            this.cboDatabases.Location = new System.Drawing.Point(135, 175);
            this.cboDatabases.Name = "cboDatabases";
            this.cboDatabases.Size = new System.Drawing.Size(254, 21);
            this.cboDatabases.TabIndex = 12;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(73, 92);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 15;
            this.lblPassword.Text = "Password:";
            this.lblPassword.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(97, 56);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 13;
            this.lblUser.Text = "User:";
            this.lblUser.Visible = false;
            // 
            // txtSqlAddress
            // 
            this.txtSqlAddress.Location = new System.Drawing.Point(135, 21);
            this.txtSqlAddress.Name = "txtSqlAddress";
            this.txtSqlAddress.Size = new System.Drawing.Size(186, 20);
            this.txtSqlAddress.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "SQL Server Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Select DB:";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(135, 125);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(78, 23);
            this.btnSet.TabIndex = 18;
            this.btnSet.Text = "Connect";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // cbxIntegrated
            // 
            this.cbxIntegrated.Location = new System.Drawing.Point(346, 21);
            this.cbxIntegrated.Name = "cbxIntegrated";
            this.cbxIntegrated.Size = new System.Drawing.Size(130, 21);
            this.cbxIntegrated.TabIndex = 19;
            this.cbxIntegrated.Text = "Integrated security";
            this.cbxIntegrated.UseVisualStyleBackColor = true;
            this.cbxIntegrated.CheckedChanged += new System.EventHandler(this.cbxIntegrated_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LocalserverConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 310);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxIntegrated);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassDB);
            this.Controls.Add(this.txtUserDB);
            this.Controls.Add(this.cboDatabases);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtSqlAddress);
            this.Controls.Add(this.label1);
            this.Name = "LocalserverConnection";
            this.Text = "LocalserverConnection";
            this.Load += new System.EventHandler(this.LocalserverConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassDB;
        private System.Windows.Forms.TextBox txtUserDB;
        private System.Windows.Forms.ComboBox cboDatabases;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtSqlAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.CheckBox cbxIntegrated;
        private System.Windows.Forms.Button button1;
    }
}