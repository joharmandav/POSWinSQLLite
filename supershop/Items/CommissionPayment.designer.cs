namespace supershop
{
    partial class CommissionPayment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpaymentDate = new System.Windows.Forms.DateTimePicker();
            this.txtrefrence = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.CombPayby = new System.Windows.Forms.ComboBox();
            this.btnCompleteSalesAndPrint = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveOnly = new System.Windows.Forms.Button();
            this.lblEmp = new System.Windows.Forms.Label();
            this.lblCommPaid = new System.Windows.Forms.Label();
            this.lblCommDue = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gold;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpaymentDate);
            this.groupBox1.Controls.Add(this.txtrefrence);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.txtPaidAmount);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.CombPayby);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 274);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Commision Payment ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 179;
            this.label3.Text = "Date :";
            // 
            // dtpaymentDate
            // 
            this.dtpaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dtpaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpaymentDate.Location = new System.Drawing.Point(136, 100);
            this.dtpaymentDate.Name = "dtpaymentDate";
            this.dtpaymentDate.Size = new System.Drawing.Size(143, 23);
            this.dtpaymentDate.TabIndex = 178;
            // 
            // txtrefrence
            // 
            this.txtrefrence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrefrence.Location = new System.Drawing.Point(132, 129);
            this.txtrefrence.Name = "txtrefrence";
            this.txtrefrence.Size = new System.Drawing.Size(147, 26);
            this.txtrefrence.TabIndex = 71;
            this.toolTip1.SetToolTip(this.txtrefrence, "Due amount");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 72;
            this.label2.Text = "Reference :";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.label35.Location = new System.Drawing.Point(83, 190);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(39, 12);
            this.label35.TabIndex = 70;
            this.label35.Text = "Optional";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(63, 174);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(59, 16);
            this.label34.TabIndex = 69;
            this.label34.Text = "Remark:";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(132, 173);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(147, 80);
            this.txtRemark.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtRemark, "Comment/ Note");
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidAmount.Location = new System.Drawing.Point(136, 57);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(147, 31);
            this.txtPaidAmount.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtPaidAmount, "Insert Customer amount");
            this.txtPaidAmount.Leave += new System.EventHandler(this.txtPaidAmount_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.label19.Location = new System.Drawing.Point(16, 59);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(114, 20);
            this.label19.TabIndex = 60;
            this.label19.Text = "Paid Amount :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 11.75F);
            this.label18.Location = new System.Drawing.Point(71, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 19);
            this.label18.TabIndex = 59;
            this.label18.Text = "Pay by :";
            // 
            // CombPayby
            // 
            this.CombPayby.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombPayby.FormattingEnabled = true;
            this.CombPayby.Items.AddRange(new object[] {
            "Cash",
            "Debit Card",
            "Credit Card",
            "Interac",
            "Check ",
            "Gift Card",
            "PayPal",
            "Skrill/MoneyBrooker",
            "Payza",
            "ApplePay",
            "PayTM",
            "MasterCard",
            "Bank TT",
            "Other[    ]"});
            this.CombPayby.Location = new System.Drawing.Point(136, 26);
            this.CombPayby.Name = "CombPayby";
            this.CombPayby.Size = new System.Drawing.Size(147, 26);
            this.CombPayby.TabIndex = 0;
            this.CombPayby.Text = "Cash";
            this.toolTip1.SetToolTip(this.CombPayby, "Select Payment Type");
            // 
            // btnCompleteSalesAndPrint
            // 
            this.btnCompleteSalesAndPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCompleteSalesAndPrint.FlatAppearance.BorderSize = 0;
            this.btnCompleteSalesAndPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteSalesAndPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.btnCompleteSalesAndPrint.ForeColor = System.Drawing.Color.Linen;
            this.btnCompleteSalesAndPrint.Location = new System.Drawing.Point(148, 292);
            this.btnCompleteSalesAndPrint.Name = "btnCompleteSalesAndPrint";
            this.btnCompleteSalesAndPrint.Size = new System.Drawing.Size(165, 29);
            this.btnCompleteSalesAndPrint.TabIndex = 1;
            this.btnCompleteSalesAndPrint.Text = "Print Pay Slip";
            this.btnCompleteSalesAndPrint.UseVisualStyleBackColor = false;
            this.btnCompleteSalesAndPrint.Click += new System.EventHandler(this.btnCompleteSalesAndPrint_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 80000;
            this.toolTip1.BackColor = System.Drawing.Color.OliveDrab;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 1;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnSaveOnly
            // 
            this.btnSaveOnly.BackColor = System.Drawing.Color.Navy;
            this.btnSaveOnly.FlatAppearance.BorderSize = 0;
            this.btnSaveOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveOnly.ForeColor = System.Drawing.Color.Linen;
            this.btnSaveOnly.Location = new System.Drawing.Point(12, 292);
            this.btnSaveOnly.Name = "btnSaveOnly";
            this.btnSaveOnly.Size = new System.Drawing.Size(130, 29);
            this.btnSaveOnly.TabIndex = 159;
            this.btnSaveOnly.Text = "Save";
            this.btnSaveOnly.UseVisualStyleBackColor = false;
            this.btnSaveOnly.Click += new System.EventHandler(this.btnSaveOnly_Click);
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.lblEmp.Location = new System.Drawing.Point(418, 38);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(15, 20);
            this.lblEmp.TabIndex = 160;
            this.lblEmp.Text = "-";
            // 
            // lblCommPaid
            // 
            this.lblCommPaid.AutoSize = true;
            this.lblCommPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.lblCommPaid.Location = new System.Drawing.Point(418, 80);
            this.lblCommPaid.Name = "lblCommPaid";
            this.lblCommPaid.Size = new System.Drawing.Size(15, 20);
            this.lblCommPaid.TabIndex = 161;
            this.lblCommPaid.Text = "-";
            // 
            // lblCommDue
            // 
            this.lblCommDue.AutoSize = true;
            this.lblCommDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.lblCommDue.Location = new System.Drawing.Point(418, 118);
            this.lblCommDue.Name = "lblCommDue";
            this.lblCommDue.Size = new System.Drawing.Size(15, 20);
            this.lblCommDue.TabIndex = 162;
            this.lblCommDue.Text = "-";
            // 
            // CommissionPayment
            // 
            this.AcceptButton = this.btnCompleteSalesAndPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(320, 328);
            this.Controls.Add(this.lblCommDue);
            this.Controls.Add(this.lblCommPaid);
            this.Controls.Add(this.lblEmp);
            this.Controls.Add(this.btnSaveOnly);
            this.Controls.Add(this.btnCompleteSalesAndPrint);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommissionPayment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox CombPayby;
        private System.Windows.Forms.Button btnCompleteSalesAndPrint;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSaveOnly;
        private System.Windows.Forms.TextBox txtrefrence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpaymentDate;
        private System.Windows.Forms.Label lblEmp;
        private System.Windows.Forms.Label lblCommPaid;
        private System.Windows.Forms.Label lblCommDue;
    }
}