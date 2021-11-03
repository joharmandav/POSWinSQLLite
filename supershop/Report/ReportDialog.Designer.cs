namespace supershop.Report
{
    partial class ReportDialog
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
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmboterminal = new System.Windows.Forms.ComboBox();
            this.btnMoredtl = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(38, 45);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(168, 24);
            this.dtStartDate.TabIndex = 85;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(257, 45);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(168, 24);
            this.dtEndDate.TabIndex = 83;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(37, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 84;
            this.label9.Text = "Start Date";
            // 
            // btnContinue
            // 
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnContinue.Location = new System.Drawing.Point(257, 145);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(168, 23);
            this.btnContinue.TabIndex = 86;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(254, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "End Date";
            // 
            // cmbEmp
            // 
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(40, 109);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(166, 21);
            this.cmbEmp.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Report by Every Transaction";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 98;
            this.label6.Text = "Report by Employee";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 100;
            this.label7.Text = "Report by Terminal";
            // 
            // cmboterminal
            // 
            this.cmboterminal.FormattingEnabled = true;
            this.cmboterminal.Location = new System.Drawing.Point(257, 109);
            this.cmboterminal.Name = "cmboterminal";
            this.cmboterminal.Size = new System.Drawing.Size(168, 21);
            this.cmboterminal.TabIndex = 99;
            // 
            // btnMoredtl
            // 
            this.btnMoredtl.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnMoredtl.FlatAppearance.BorderSize = 0;
            this.btnMoredtl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMoredtl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnMoredtl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoredtl.Location = new System.Drawing.Point(212, 151);
            this.btnMoredtl.Name = "btnMoredtl";
            this.btnMoredtl.Size = new System.Drawing.Size(34, 17);
            this.btnMoredtl.TabIndex = 88;
            this.btnMoredtl.Text = "More Details";
            this.btnMoredtl.UseVisualStyleBackColor = true;
            this.btnMoredtl.Visible = false;
            this.btnMoredtl.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Location = new System.Drawing.Point(38, 145);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(168, 23);
            this.btnReset.TabIndex = 101;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ReportDialog
            // 
            this.AcceptButton = this.btnContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(451, 192);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmboterminal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbEmp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMoredtl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.label9);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.ReportDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEmp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmboterminal;
        private System.Windows.Forms.Button btnMoredtl;
        private System.Windows.Forms.Button btnReset;
    }
}