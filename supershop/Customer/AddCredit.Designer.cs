namespace supershop.Customer
{
    partial class AddCredit
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesCription = new System.Windows.Forms.TextBox();
            this.NumUDcredit = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboCustID = new System.Windows.Forms.ComboBox();
            this.lblCustID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumUDcredit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // txtDesCription
            // 
            this.txtDesCription.Location = new System.Drawing.Point(22, 166);
            this.txtDesCription.Multiline = true;
            this.txtDesCription.Name = "txtDesCription";
            this.txtDesCription.Size = new System.Drawing.Size(166, 55);
            this.txtDesCription.TabIndex = 1;
            // 
            // NumUDcredit
            // 
            this.NumUDcredit.Location = new System.Drawing.Point(22, 120);
            this.NumUDcredit.Name = "NumUDcredit";
            this.NumUDcredit.Size = new System.Drawing.Size(166, 20);
            this.NumUDcredit.TabIndex = 0;
            this.NumUDcredit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(61, 232);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.CustomFormat = "";
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(22, 31);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(163, 20);
            this.dtDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Cust ID";
            // 
            // ComboCustID
            // 
            this.ComboCustID.FormattingEnabled = true;
            this.ComboCustID.Location = new System.Drawing.Point(22, 77);
            this.ComboCustID.Name = "ComboCustID";
            this.ComboCustID.Size = new System.Drawing.Size(163, 21);
            this.ComboCustID.TabIndex = 100;
            this.ComboCustID.SelectedIndexChanged += new System.EventHandler(this.ComboCustID_SelectedIndexChanged);
            // 
            // lblCustID
            // 
            this.lblCustID.AutoSize = true;
            this.lblCustID.Location = new System.Drawing.Point(66, 61);
            this.lblCustID.Name = "lblCustID";
            this.lblCustID.Size = new System.Drawing.Size(13, 13);
            this.lblCustID.TabIndex = 101;
            this.lblCustID.Text = "--";
            // 
            // AddCredit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(212, 272);
            this.Controls.Add(this.lblCustID);
            this.Controls.Add(this.ComboCustID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.NumUDcredit);
            this.Controls.Add(this.txtDesCription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCredit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Credit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddCredit_FormClosed);
            this.Load += new System.EventHandler(this.AddCredit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumUDcredit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesCription;
        private System.Windows.Forms.NumericUpDown NumUDcredit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComboCustID;
        private System.Windows.Forms.Label lblCustID;
    }
}