namespace supershop
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnReset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.lblmsg = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.LnkBtnForgotPassword = new System.Windows.Forms.LinkLabel();
            this.BtnRegister = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTerminal = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnterminalImage = new System.Windows.Forms.Button();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnTerminalDatabase = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this._down_btn = new System.Windows.Forms.Button();
            this._close_btn = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BackgroundImage = global::supershop.Properties.Resources.log_button_1_over;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(256, 243);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(134, 29);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolTipInfo
            // 
            this.toolTipInfo.AutomaticDelay = 800;
            this.toolTipInfo.AutoPopDelay = 80000;
            this.toolTipInfo.BackColor = System.Drawing.Color.OliveDrab;
            this.toolTipInfo.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolTipInfo.InitialDelay = 1;
            this.toolTipInfo.ReshowDelay = 1;
            this.toolTipInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // lblmsg
            // 
            this.lblmsg.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblmsg.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(118, 275);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(360, 38);
            this.lblmsg.TabIndex = 23;
            this.lblmsg.Text = "msg";
            this.lblmsg.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.linkLabel1.Location = new System.Drawing.Point(361, 313);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(141, 18);
            this.linkLabel1.TabIndex = 25;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Activation POS System";
            this.linkLabel1.Visible = false;
            // 
            // LnkBtnForgotPassword
            // 
            this.LnkBtnForgotPassword.AutoSize = true;
            this.LnkBtnForgotPassword.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LnkBtnForgotPassword.Location = new System.Drawing.Point(301, 201);
            this.LnkBtnForgotPassword.Name = "LnkBtnForgotPassword";
            this.LnkBtnForgotPassword.Size = new System.Drawing.Size(86, 13);
            this.LnkBtnForgotPassword.TabIndex = 25;
            this.LnkBtnForgotPassword.TabStop = true;
            this.LnkBtnForgotPassword.Text = "Forgot Password";
            this.LnkBtnForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkBtnForgotPassword_LinkClicked);
            // 
            // BtnRegister
            // 
            this.BtnRegister.AutoSize = true;
            this.BtnRegister.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegister.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnRegister.Location = new System.Drawing.Point(191, 313);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(123, 18);
            this.BtnRegister.TabIndex = 25;
            this.BtnRegister.TabStop = true;
            this.BtnRegister.Text = "Register a new user";
            this.BtnRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnRegister_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(116, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 28;
            this.label3.Text = "Terminal";
            // 
            // comboTerminal
            // 
            this.comboTerminal.FormattingEnabled = true;
            this.comboTerminal.Location = new System.Drawing.Point(115, 217);
            this.comboTerminal.Name = "comboTerminal";
            this.comboTerminal.Size = new System.Drawing.Size(275, 21);
            this.comboTerminal.TabIndex = 29;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(425, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 27);
            this.btnSave.TabIndex = 71;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnterminalImage
            // 
            this.btnterminalImage.Location = new System.Drawing.Point(361, 57);
            this.btnterminalImage.Name = "btnterminalImage";
            this.btnterminalImage.Size = new System.Drawing.Size(63, 27);
            this.btnterminalImage.TabIndex = 70;
            this.btnterminalImage.Text = "Browse";
            this.btnterminalImage.UseVisualStyleBackColor = true;
            this.btnterminalImage.Click += new System.EventHandler(this.btnterminalImage_Click);
            // 
            // txtImage
            // 
            this.txtImage.Enabled = false;
            this.txtImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtImage.Location = new System.Drawing.Point(107, 58);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(252, 24);
            this.txtImage.TabIndex = 69;
            // 
            // btnTerminalDatabase
            // 
            this.btnTerminalDatabase.Location = new System.Drawing.Point(361, 27);
            this.btnTerminalDatabase.Name = "btnTerminalDatabase";
            this.btnTerminalDatabase.Size = new System.Drawing.Size(63, 27);
            this.btnTerminalDatabase.TabIndex = 68;
            this.btnTerminalDatabase.Text = "Browse";
            this.btnTerminalDatabase.UseVisualStyleBackColor = true;
            this.btnTerminalDatabase.Click += new System.EventHandler(this.btnTerminalDatabase_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label29.Location = new System.Drawing.Point(5, 58);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 17);
            this.label29.TabIndex = 67;
            this.label29.Text = "Image Path:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Enabled = false;
            this.txtDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDatabase.Location = new System.Drawing.Point(107, 28);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(252, 24);
            this.txtDatabase.TabIndex = 65;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label28.Location = new System.Drawing.Point(5, 29);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(106, 17);
            this.label28.TabIndex = 66;
            this.label28.Text = "Database Path:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(426, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 27);
            this.button1.TabIndex = 183;
            this.button1.Text = "sync";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.BackgroundImage = global::supershop.Properties.Resources.button_login_main;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(115, 243);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(133, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.expandablePanel1);
            this.panel3.Controls.Add(this.txtPassword);
            this.panel3.Controls.Add(this.txtUserName);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.btnLogin);
            this.panel3.Controls.Add(this.BtnRegister);
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Controls.Add(this.comboTerminal);
            this.panel3.Controls.Add(this.lblmsg);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.LnkBtnForgotPassword);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(507, 422);
            this.panel3.TabIndex = 78;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.txtDatabase);
            this.expandablePanel1.Controls.Add(this.button1);
            this.expandablePanel1.Controls.Add(this.btnterminalImage);
            this.expandablePanel1.Controls.Add(this.btnTerminalDatabase);
            this.expandablePanel1.Controls.Add(this.btnSave);
            this.expandablePanel1.Controls.Add(this.label28);
            this.expandablePanel1.Controls.Add(this.label29);
            this.expandablePanel1.Controls.Add(this.txtImage);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandablePanel1.Expanded = false;
            this.expandablePanel1.ExpandedBounds = new System.Drawing.Rectangle(0, 331, 505, 89);
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 394);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(505, 26);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.expandablePanel1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 187;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "Database Setting";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(115, 167);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(275, 26);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.WatermarkImageAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtPassword.WatermarkText = "password";
            // 
            // txtUserName
            // 
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(115, 132);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(275, 26);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.WatermarkImageAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtUserName.WatermarkText = "User Name";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(213, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(187, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 22);
            this.label6.TabIndex = 80;
            this.label6.Text = "Member Login";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._down_btn);
            this.panel1.Controls.Add(this._close_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 26);
            this.panel1.TabIndex = 77;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 80;
            this.label4.Text = "Login";
            // 
            // _down_btn
            // 
            this._down_btn.BackColor = System.Drawing.Color.Transparent;
            this._down_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_down_btn.BackgroundImage")));
            this._down_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._down_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this._down_btn.FlatAppearance.BorderSize = 0;
            this._down_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._down_btn.Location = new System.Drawing.Point(459, 2);
            this._down_btn.Margin = new System.Windows.Forms.Padding(4);
            this._down_btn.Name = "_down_btn";
            this._down_btn.Size = new System.Drawing.Size(19, 21);
            this._down_btn.TabIndex = 78;
            this._down_btn.TabStop = false;
            this._down_btn.UseVisualStyleBackColor = false;
            this._down_btn.Click += new System.EventHandler(this._down_btn_Click);
            // 
            // _close_btn
            // 
            this._close_btn.BackColor = System.Drawing.Color.Transparent;
            this._close_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_close_btn.BackgroundImage")));
            this._close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._close_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._close_btn.FlatAppearance.BorderSize = 0;
            this._close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._close_btn.Location = new System.Drawing.Point(483, 2);
            this._close_btn.Margin = new System.Windows.Forms.Padding(4);
            this._close_btn.Name = "_close_btn";
            this._close_btn.Size = new System.Drawing.Size(19, 21);
            this._close_btn.TabIndex = 79;
            this._close_btn.TabStop = false;
            this._close_btn.UseVisualStyleBackColor = false;
            this._close_btn.Click += new System.EventHandler(this._close_btn_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(507, 422);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel LnkBtnForgotPassword;
        private System.Windows.Forms.LinkLabel BtnRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTerminal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnterminalImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnTerminalDatabase;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _down_btn;
        private System.Windows.Forms.Button _close_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
    }
}

