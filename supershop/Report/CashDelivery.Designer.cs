namespace supershop.Report
{
    partial class CashDelivery
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
            this.lblTodayShiftCash = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDelivered = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMSG = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTodayShiftCash
            // 
            this.lblTodayShiftCash.AutoSize = true;
            this.lblTodayShiftCash.ForeColor = System.Drawing.Color.Red;
            this.lblTodayShiftCash.Location = new System.Drawing.Point(173, 42);
            this.lblTodayShiftCash.Name = "lblTodayShiftCash";
            this.lblTodayShiftCash.Size = new System.Drawing.Size(10, 13);
            this.lblTodayShiftCash.TabIndex = 99;
            this.lblTodayShiftCash.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "Today Cash Amount";
            // 
            // txtCash
            // 
            this.txtCash.Location = new System.Drawing.Point(173, 69);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(159, 20);
            this.txtCash.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Delivered Amount";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(113, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 23);
            this.btnSave.TabIndex = 102;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Delivered To Employee";
            // 
            // comboDelivered
            // 
            this.comboDelivered.FormattingEnabled = true;
            this.comboDelivered.Location = new System.Drawing.Point(173, 103);
            this.comboDelivered.Name = "comboDelivered";
            this.comboDelivered.Size = new System.Drawing.Size(159, 21);
            this.comboDelivered.TabIndex = 104;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(271, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 105;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.Red;
            this.lblDate.Location = new System.Drawing.Point(280, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(10, 13);
            this.lblDate.TabIndex = 118;
            this.lblDate.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 117;
            this.label3.Text = "Date : ";
            // 
            // lblMSG
            // 
            this.lblMSG.AutoSize = true;
            this.lblMSG.ForeColor = System.Drawing.Color.Red;
            this.lblMSG.Location = new System.Drawing.Point(27, 202);
            this.lblMSG.Name = "lblMSG";
            this.lblMSG.Size = new System.Drawing.Size(10, 13);
            this.lblMSG.TabIndex = 119;
            this.lblMSG.Text = "-";
            // 
            // CashDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 261);
            this.Controls.Add(this.lblMSG);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboDelivered);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTodayShiftCash);
            this.Controls.Add(this.label4);
            this.Name = "CashDelivery";
            this.Text = "CashDelivery";
            this.Load += new System.EventHandler(this.CashDelivery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTodayShiftCash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboDelivered;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMSG;
    }
}