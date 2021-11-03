namespace supershop.Report
{
    partial class OpeningBalance
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOpeningBalance = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboShift = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMSG = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Opening Balance";
            // 
            // txtOpeningBalance
            // 
            this.txtOpeningBalance.Location = new System.Drawing.Point(74, 48);
            this.txtOpeningBalance.Name = "txtOpeningBalance";
            this.txtOpeningBalance.Size = new System.Drawing.Size(159, 20);
            this.txtOpeningBalance.TabIndex = 1;
            this.txtOpeningBalance.LostFocus += new System.EventHandler(this.txtOpeningBalance_LostFocus);
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(279, 48);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(159, 20);
            this.txtDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Shift";
            // 
            // ComboShift
            // 
            this.ComboShift.FormattingEnabled = true;
            this.ComboShift.Location = new System.Drawing.Point(74, 102);
            this.ComboShift.Name = "ComboShift";
            this.ComboShift.Size = new System.Drawing.Size(159, 21);
            this.ComboShift.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Amount";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ForeColor = System.Drawing.Color.Red;
            this.lblAmount.Location = new System.Drawing.Point(276, 105);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(10, 13);
            this.lblAmount.TabIndex = 7;
            this.lblAmount.Text = "-";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(74, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(242, 23);
            this.btnSave.TabIndex = 87;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMSG
            // 
            this.lblMSG.AutoSize = true;
            this.lblMSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSG.ForeColor = System.Drawing.Color.Red;
            this.lblMSG.Location = new System.Drawing.Point(71, 193);
            this.lblMSG.Name = "lblMSG";
            this.lblMSG.Size = new System.Drawing.Size(296, 22);
            this.lblMSG.TabIndex = 88;
            this.lblMSG.Text = "Please Enter Opening Balance First";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(341, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 89;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OpeningBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(479, 245);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMSG);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ComboShift);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOpeningBalance);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpeningBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opning Balance";
            this.Load += new System.EventHandler(this.DayClose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOpeningBalance;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboShift;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMSG;
        private System.Windows.Forms.Button button1;
    }
}