namespace supershop
{
    partial class UserProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfile));
            this.btnChangePic = new System.Windows.Forms.Button();
            this.PicUserPhoto = new System.Windows.Forms.PictureBox();
            this.rdbtnUserRole = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textUserPass = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmailaddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtuid = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblFileExtension = new System.Windows.Forms.Label();
            this.lblimagename = new System.Windows.Forms.Label();
            this.dtDOB = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lnkWorkingHours = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PicUserPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChangePic
            // 
            this.btnChangePic.BackColor = System.Drawing.Color.Blue;
            this.btnChangePic.FlatAppearance.BorderSize = 0;
            this.btnChangePic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChangePic.Location = new System.Drawing.Point(12, 220);
            this.btnChangePic.Name = "btnChangePic";
            this.btnChangePic.Size = new System.Drawing.Size(256, 24);
            this.btnChangePic.TabIndex = 43;
            this.btnChangePic.Text = "Change Picture";
            this.btnChangePic.UseVisualStyleBackColor = false;
            this.btnChangePic.Click += new System.EventHandler(this.btnChangePic_Click);
            // 
            // PicUserPhoto
            // 
            this.PicUserPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicUserPhoto.Image = ((System.Drawing.Image)(resources.GetObject("PicUserPhoto.Image")));
            this.PicUserPhoto.InitialImage = ((System.Drawing.Image)(resources.GetObject("PicUserPhoto.InitialImage")));
            this.PicUserPhoto.Location = new System.Drawing.Point(12, 12);
            this.PicUserPhoto.Name = "PicUserPhoto";
            this.PicUserPhoto.Size = new System.Drawing.Size(256, 202);
            this.PicUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicUserPhoto.TabIndex = 42;
            this.PicUserPhoto.TabStop = false;
            // 
            // rdbtnUserRole
            // 
            this.rdbtnUserRole.AutoSize = true;
            this.rdbtnUserRole.Checked = true;
            this.rdbtnUserRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.rdbtnUserRole.Location = new System.Drawing.Point(15, 399);
            this.rdbtnUserRole.Name = "rdbtnUserRole";
            this.rdbtnUserRole.Size = new System.Drawing.Size(64, 20);
            this.rdbtnUserRole.TabIndex = 40;
            this.rdbtnUserRole.TabStop = true;
            this.rdbtnUserRole.Text = "Admin";
            this.rdbtnUserRole.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label11.Location = new System.Drawing.Point(13, 367);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 18);
            this.label11.TabIndex = 41;
            this.label11.Text = "Position (User Role)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.Location = new System.Drawing.Point(9, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "Password";
            // 
            // textUserPass
            // 
            this.textUserPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.textUserPass.Location = new System.Drawing.Point(12, 322);
            this.textUserPass.Name = "textUserPass";
            this.textUserPass.Size = new System.Drawing.Size(256, 24);
            this.textUserPass.TabIndex = 0;
            this.textUserPass.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtUsername.Location = new System.Drawing.Point(12, 268);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(256, 24);
            this.txtUsername.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.Location = new System.Drawing.Point(9, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 36;
            this.label8.Text = "User Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label10.Location = new System.Drawing.Point(324, 347);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 18);
            this.label10.TabIndex = 54;
            this.label10.Text = "Date Of Birth";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtContact.Location = new System.Drawing.Point(325, 205);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(306, 24);
            this.txtContact.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.Location = new System.Drawing.Point(324, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 18);
            this.label7.TabIndex = 52;
            this.label7.Text = "Contact";
            // 
            // txtEmailaddress
            // 
            this.txtEmailaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtEmailaddress.Location = new System.Drawing.Point(325, 145);
            this.txtEmailaddress.Name = "txtEmailaddress";
            this.txtEmailaddress.Size = new System.Drawing.Size(304, 24);
            this.txtEmailaddress.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(325, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 18);
            this.label6.TabIndex = 50;
            this.label6.Text = "Email";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtAddress.Location = new System.Drawing.Point(325, 259);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(306, 76);
            this.txtAddress.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(322, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 48;
            this.label5.Text = "Address";
            // 
            // txtFatherName
            // 
            this.txtFatherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtFatherName.Location = new System.Drawing.Point(325, 90);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(304, 24);
            this.txtFatherName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(322, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 46;
            this.label3.Text = "Father Name";
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtUserFullName.Location = new System.Drawing.Point(325, 30);
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Size = new System.Drawing.Size(304, 24);
            this.txtUserFullName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(322, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 44;
            this.label2.Text = "Name";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnUpdate.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnUpdate.Location = new System.Drawing.Point(327, 417);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(308, 30);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtuid
            // 
            this.txtuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtuid.Location = new System.Drawing.Point(638, 435);
            this.txtuid.Name = "txtuid";
            this.txtuid.ReadOnly = true;
            this.txtuid.Size = new System.Drawing.Size(18, 24);
            this.txtuid.TabIndex = 57;
            this.txtuid.Text = "0";
            this.txtuid.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.25F);
            this.lblUserName.Location = new System.Drawing.Point(120, 447);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(6, 7);
            this.lblUserName.TabIndex = 58;
            this.lblUserName.Text = ".";
            // 
            // lblFileExtension
            // 
            this.lblFileExtension.AutoSize = true;
            this.lblFileExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F);
            this.lblFileExtension.Location = new System.Drawing.Point(14, 447);
            this.lblFileExtension.Name = "lblFileExtension";
            this.lblFileExtension.Size = new System.Drawing.Size(32, 7);
            this.lblFileExtension.TabIndex = 59;
            this.lblFileExtension.Text = "user.png";
            // 
            // lblimagename
            // 
            this.lblimagename.AutoSize = true;
            this.lblimagename.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.25F);
            this.lblimagename.Location = new System.Drawing.Point(64, 447);
            this.lblimagename.Name = "lblimagename";
            this.lblimagename.Size = new System.Drawing.Size(5, 6);
            this.lblimagename.TabIndex = 60;
            this.lblimagename.Text = "-";
            // 
            // dtDOB
            // 
            this.dtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDOB.Location = new System.Drawing.Point(325, 371);
            this.dtDOB.Name = "dtDOB";
            this.dtDOB.Size = new System.Drawing.Size(304, 20);
            this.dtDOB.TabIndex = 6;
            this.dtDOB.Value = new System.DateTime(1992, 1, 16, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(325, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 61;
            this.label1.Text = "Branch: ";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblBranch.Location = new System.Drawing.Point(383, 395);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(18, 18);
            this.lblBranch.TabIndex = 62;
            this.lblBranch.Text = "--";
            // 
            // lnkWorkingHours
            // 
            this.lnkWorkingHours.AutoSize = true;
            this.lnkWorkingHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lnkWorkingHours.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkWorkingHours.Location = new System.Drawing.Point(325, 453);
            this.lnkWorkingHours.Name = "lnkWorkingHours";
            this.lnkWorkingHours.Size = new System.Drawing.Size(151, 16);
            this.lnkWorkingHours.TabIndex = 70;
            this.lnkWorkingHours.TabStop = true;
            this.lnkWorkingHours.Text = "Show my Working hours";
            this.lnkWorkingHours.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWorkingHours_LinkClicked);
            // 
            // UserProfile
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(658, 478);
            this.Controls.Add(this.lnkWorkingHours);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDOB);
            this.Controls.Add(this.lblimagename);
            this.Controls.Add(this.lblFileExtension);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtuid);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmailaddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFatherName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserFullName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChangePic);
            this.Controls.Add(this.PicUserPhoto);
            this.Controls.Add(this.rdbtnUserRole);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textUserPass);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label8);
            this.Name = "UserProfile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Profile";
            this.Load += new System.EventHandler(this.UserProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicUserPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangePic;
        private System.Windows.Forms.PictureBox PicUserPhoto;
        private System.Windows.Forms.RadioButton rdbtnUserRole;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textUserPass;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmailaddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtuid;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblFileExtension;
        private System.Windows.Forms.Label lblimagename;
        private System.Windows.Forms.DateTimePicker dtDOB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.LinkLabel lnkWorkingHours;

    }
}