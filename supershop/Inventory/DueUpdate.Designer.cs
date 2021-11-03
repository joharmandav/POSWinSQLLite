namespace supershop
{
    partial class DueUpdate
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
            this.lbsalesid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbpaidamt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbtotalamt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbdate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbcontact = new System.Windows.Forms.Label();
            this.lbDueAmount = new System.Windows.Forms.Label();
            this.lbreceiveamt = new System.Windows.Forms.Label();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Due Amount: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Invoice No:";
            // 
            // lbsalesid
            // 
            this.lbsalesid.AutoSize = true;
            this.lbsalesid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lbsalesid.Location = new System.Drawing.Point(176, 88);
            this.lbsalesid.Name = "lbsalesid";
            this.lbsalesid.Size = new System.Drawing.Size(32, 16);
            this.lbsalesid.TabIndex = 2;
            this.lbsalesid.Text = "------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total Amont :";
            // 
            // lbpaidamt
            // 
            this.lbpaidamt.AutoSize = true;
            this.lbpaidamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lbpaidamt.Location = new System.Drawing.Point(134, 225);
            this.lbpaidamt.Name = "lbpaidamt";
            this.lbpaidamt.Size = new System.Drawing.Size(22, 16);
            this.lbpaidamt.TabIndex = 4;
            this.lbpaidamt.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Paid Amount :";
            // 
            // lbtotalamt
            // 
            this.lbtotalamt.AutoSize = true;
            this.lbtotalamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lbtotalamt.Location = new System.Drawing.Point(134, 191);
            this.lbtotalamt.Name = "lbtotalamt";
            this.lbtotalamt.Size = new System.Drawing.Size(22, 16);
            this.lbtotalamt.TabIndex = 6;
            this.lbtotalamt.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Customer";
            // 
            // lbdate
            // 
            this.lbdate.AutoSize = true;
            this.lbdate.Location = new System.Drawing.Point(12, 62);
            this.lbdate.Name = "lbdate";
            this.lbdate.Size = new System.Drawing.Size(19, 13);
            this.lbdate.TabIndex = 10;
            this.lbdate.Text = "----";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.Location = new System.Drawing.Point(137, 331);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbcontact
            // 
            this.lbcontact.AutoSize = true;
            this.lbcontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lbcontact.Location = new System.Drawing.Point(212, 62);
            this.lbcontact.Name = "lbcontact";
            this.lbcontact.Size = new System.Drawing.Size(32, 16);
            this.lbcontact.TabIndex = 12;
            this.lbcontact.Text = "------";
            // 
            // lbDueAmount
            // 
            this.lbDueAmount.AutoSize = true;
            this.lbDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbDueAmount.Location = new System.Drawing.Point(134, 255);
            this.lbDueAmount.Name = "lbDueAmount";
            this.lbDueAmount.Size = new System.Drawing.Size(26, 18);
            this.lbDueAmount.TabIndex = 13;
            this.lbDueAmount.Text = "00";
            // 
            // lbreceiveamt
            // 
            this.lbreceiveamt.AutoSize = true;
            this.lbreceiveamt.Location = new System.Drawing.Point(31, 290);
            this.lbreceiveamt.Name = "lbreceiveamt";
            this.lbreceiveamt.Size = new System.Drawing.Size(92, 13);
            this.lbreceiveamt.TabIndex = 14;
            this.lbreceiveamt.Text = "Receive Amount :";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(137, 286);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(129, 20);
            this.txtReceive.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "===============================================";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(297, 336);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(27, 25);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "X";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(47, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 155;
            this.label7.Text = "Receive Date:";
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.CustomFormat = "";
            this.dtReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtReceiveDate.Location = new System.Drawing.Point(137, 155);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.Size = new System.Drawing.Size(129, 22);
            this.dtReceiveDate.TabIndex = 154;
            // 
            // DueUpdate
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(336, 442);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtReceiveDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.lbreceiveamt);
            this.Controls.Add(this.lbDueAmount);
            this.Controls.Add(this.lbcontact);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbdate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbtotalamt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbpaidamt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbsalesid);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DueUpdate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receive Due ";
            this.Load += new System.EventHandler(this.DueUpdate_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DueUpdate_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbsalesid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbpaidamt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbtotalamt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbcontact;
        private System.Windows.Forms.Label lbDueAmount;
        private System.Windows.Forms.Label lbreceiveamt;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtReceiveDate;
    }
}