namespace supershop
{
    partial class OnlineRegisered
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblmsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(28, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "Registered Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtEmail.Location = new System.Drawing.Point(31, 116);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(363, 26);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblmsg.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(28, 9);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(28, 16);
            this.lblmsg.TabIndex = 31;
            this.lblmsg.Text = "msg";
            this.lblmsg.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "User Name";
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
            this.btnReset.Location = new System.Drawing.Point(297, 197);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 28);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Exit";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BurlyWood;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.LavenderBlush;
            this.btnLogin.Location = new System.Drawing.Point(31, 195);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(246, 32);
            this.btnLogin.TabIndex = 28;
            this.btnLogin.Text = "Submit";
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtUserName.Location = new System.Drawing.Point(31, 51);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(363, 26);
            this.txtUserName.TabIndex = 1;
            // 
            // OnlineRegisered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(423, 308);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserName);
            this.Name = "OnlineRegisered";
            this.Text = "Search Data";
            this.Load += new System.EventHandler(this.GetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUserName;
    }
}