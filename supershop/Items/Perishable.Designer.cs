namespace supershop.Items
{
    partial class Perishable
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtBatchNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateProduct = new System.Windows.Forms.DateTimePicker();
            this.dateExpiry = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLeadTO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblprodid = new System.Windows.Forms.Label();
            this.lblUom = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMYTRANSID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMYSYSNAME = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRestQty = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(685, 185);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtBatchNO
            // 
            this.txtBatchNO.Location = new System.Drawing.Point(36, 57);
            this.txtBatchNO.Name = "txtBatchNO";
            this.txtBatchNO.Size = new System.Drawing.Size(79, 20);
            this.txtBatchNO.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Batch NO";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(141, 57);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(79, 20);
            this.txtQty.TabIndex = 95;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Product Date";
            // 
            // dateProduct
            // 
            this.dateProduct.CustomFormat = "";
            this.dateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateProduct.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateProduct.Location = new System.Drawing.Point(240, 57);
            this.dateProduct.Name = "dateProduct";
            this.dateProduct.Size = new System.Drawing.Size(139, 22);
            this.dateProduct.TabIndex = 97;
            // 
            // dateExpiry
            // 
            this.dateExpiry.CustomFormat = "";
            this.dateExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateExpiry.Location = new System.Drawing.Point(405, 57);
            this.dateExpiry.Name = "dateExpiry";
            this.dateExpiry.Size = new System.Drawing.Size(132, 22);
            this.dateExpiry.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "Expriry Date";
            // 
            // txtLeadTO
            // 
            this.txtLeadTO.Location = new System.Drawing.Point(560, 57);
            this.txtLeadTO.Name = "txtLeadTO";
            this.txtLeadTO.Size = new System.Drawing.Size(79, 20);
            this.txtLeadTO.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Lead Days TO Destroy";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(36, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 102;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(584, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 103;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "Product Code:";
            // 
            // lblprodid
            // 
            this.lblprodid.AutoSize = true;
            this.lblprodid.ForeColor = System.Drawing.Color.Red;
            this.lblprodid.Location = new System.Drawing.Point(85, 9);
            this.lblprodid.Name = "lblprodid";
            this.lblprodid.Size = new System.Drawing.Size(10, 13);
            this.lblprodid.TabIndex = 105;
            this.lblprodid.Text = "-";
            // 
            // lblUom
            // 
            this.lblUom.AutoSize = true;
            this.lblUom.ForeColor = System.Drawing.Color.Red;
            this.lblUom.Location = new System.Drawing.Point(195, 9);
            this.lblUom.Name = "lblUom";
            this.lblUom.Size = new System.Drawing.Size(10, 13);
            this.lblUom.TabIndex = 107;
            this.lblUom.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(151, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "Uom : ";
            // 
            // lblMYTRANSID
            // 
            this.lblMYTRANSID.AutoSize = true;
            this.lblMYTRANSID.ForeColor = System.Drawing.Color.Red;
            this.lblMYTRANSID.Location = new System.Drawing.Point(363, 9);
            this.lblMYTRANSID.Name = "lblMYTRANSID";
            this.lblMYTRANSID.Size = new System.Drawing.Size(10, 13);
            this.lblMYTRANSID.TabIndex = 109;
            this.lblMYTRANSID.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "MTransID : ";
            // 
            // lblMYSYSNAME
            // 
            this.lblMYSYSNAME.AutoSize = true;
            this.lblMYSYSNAME.ForeColor = System.Drawing.Color.Red;
            this.lblMYSYSNAME.Location = new System.Drawing.Point(498, 9);
            this.lblMYSYSNAME.Name = "lblMYSYSNAME";
            this.lblMYSYSNAME.Size = new System.Drawing.Size(10, 13);
            this.lblMYSYSNAME.TabIndex = 111;
            this.lblMYSYSNAME.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(440, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 110;
            this.label10.Text = "SysName : ";
            // 
            // lblRestQty
            // 
            this.lblRestQty.AutoSize = true;
            this.lblRestQty.Location = new System.Drawing.Point(185, 42);
            this.lblRestQty.Name = "lblRestQty";
            this.lblRestQty.Size = new System.Drawing.Size(10, 13);
            this.lblRestQty.TabIndex = 112;
            this.lblRestQty.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(576, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 113;
            this.label7.Text = "Total Qty";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.ForeColor = System.Drawing.Color.Red;
            this.lblTotalQty.Location = new System.Drawing.Point(632, 9);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(10, 13);
            this.lblTotalQty.TabIndex = 114;
            this.lblTotalQty.Text = "-";
            // 
            // Perishable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 321);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblRestQty);
            this.Controls.Add(this.lblMYSYSNAME);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblMYTRANSID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblUom);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblprodid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLeadTO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateExpiry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBatchNO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Perishable";
            this.Text = "Perishable";
            this.Load += new System.EventHandler(this.Perishable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBatchNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateProduct;
        private System.Windows.Forms.DateTimePicker dateExpiry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLeadTO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblprodid;
        private System.Windows.Forms.Label lblUom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMYTRANSID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMYSYSNAME;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRestQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalQty;
    }
}