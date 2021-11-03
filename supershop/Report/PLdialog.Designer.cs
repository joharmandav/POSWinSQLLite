namespace supershop.Report
{
    partial class PLdialog
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(259, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "End Date";
            // 
            // btnContinue
            // 
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Location = new System.Drawing.Point(112, 129);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(232, 23);
            this.btnContinue.TabIndex = 95;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(43, 75);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(168, 24);
            this.dtStartDate.TabIndex = 94;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(262, 75);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(168, 24);
            this.dtEndDate.TabIndex = 92;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(42, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 93;
            this.label9.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(165, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 97;
            this.label2.Text = "Profit loss Report";
            // 
            // PLdialog
            // 
            this.AcceptButton = this.btnContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(479, 177);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.label9);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PLdialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profit loss Report";
            this.Load += new System.EventHandler(this.PLdialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
    }
}