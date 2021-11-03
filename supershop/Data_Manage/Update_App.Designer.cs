namespace supershop.Data_Manage
{
    partial class Update_App
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
            this.lblMSg = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblcontinuemsg = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnColse = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblflag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMSg
            // 
            this.lblMSg.AutoSize = true;
            this.lblMSg.ForeColor = System.Drawing.Color.Red;
            this.lblMSg.Location = new System.Drawing.Point(54, 76);
            this.lblMSg.Name = "lblMSg";
            this.lblMSg.Size = new System.Drawing.Size(10, 13);
            this.lblMSg.TabIndex = 13;
            this.lblMSg.Text = "-";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(54, 127);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(482, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(54, 153);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(10, 13);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "-";
            // 
            // lblcontinuemsg
            // 
            this.lblcontinuemsg.AutoSize = true;
            this.lblcontinuemsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcontinuemsg.ForeColor = System.Drawing.Color.Red;
            this.lblcontinuemsg.Location = new System.Drawing.Point(50, 228);
            this.lblcontinuemsg.Name = "lblcontinuemsg";
            this.lblcontinuemsg.Size = new System.Drawing.Size(16, 24);
            this.lblcontinuemsg.TabIndex = 18;
            this.lblcontinuemsg.Text = "-";
            this.lblcontinuemsg.Visible = false;
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.Yellow;
            this.btnContinue.Location = new System.Drawing.Point(430, 211);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(129, 38);
            this.btnContinue.TabIndex = 80;
            this.btnContinue.Text = "Continue";
            this.btnContinue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Visible = false;
            this.btnContinue.Click += new System.EventHandler(this.btnUomAdd_Click);
            // 
            // btnColse
            // 
            this.btnColse.BackColor = System.Drawing.Color.Crimson;
            this.btnColse.FlatAppearance.BorderSize = 0;
            this.btnColse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnColse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnColse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColse.Font = new System.Drawing.Font("Trebuchet MS", 13.25F, System.Drawing.FontStyle.Bold);
            this.btnColse.ForeColor = System.Drawing.SystemColors.Window;
            this.btnColse.Location = new System.Drawing.Point(562, 1);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(28, 28);
            this.btnColse.TabIndex = 81;
            this.btnColse.Text = "X";
            this.btnColse.UseVisualStyleBackColor = false;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblflag
            // 
            this.lblflag.AutoSize = true;
            this.lblflag.ForeColor = System.Drawing.Color.Red;
            this.lblflag.Location = new System.Drawing.Point(580, 248);
            this.lblflag.Name = "lblflag";
            this.lblflag.Size = new System.Drawing.Size(10, 13);
            this.lblflag.TabIndex = 82;
            this.lblflag.Text = "-";
            // 
            // Update_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(591, 261);
            this.Controls.Add(this.lblflag);
            this.Controls.Add(this.btnColse);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblcontinuemsg);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMSg);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Update_App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Application";
            this.Load += new System.EventHandler(this.Update_App_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMSg;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblcontinuemsg;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnColse;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblflag;
    }
}