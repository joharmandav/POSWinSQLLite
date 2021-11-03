namespace supershop.Items
{
    partial class Serialize
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrvMultiUomList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dateProduct = new System.Windows.Forms.DateTimePicker();
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
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvMultiUomList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrvMultiUomList
            // 
            this.dgrvMultiUomList.AllowUserToAddRows = false;
            this.dgrvMultiUomList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvMultiUomList.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgrvMultiUomList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvMultiUomList.Location = new System.Drawing.Point(9, 97);
            this.dgrvMultiUomList.Name = "dgrvMultiUomList";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvMultiUomList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrvMultiUomList.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgrvMultiUomList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrvMultiUomList.Size = new System.Drawing.Size(326, 314);
            this.dgrvMultiUomList.TabIndex = 116;
            this.dgrvMultiUomList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvMultiUomList_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 13);
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
            this.dateProduct.Location = new System.Drawing.Point(39, 29);
            this.dateProduct.Name = "dateProduct";
            this.dateProduct.Size = new System.Drawing.Size(110, 22);
            this.dateProduct.TabIndex = 97;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(51, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(51, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 103;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "Product Code:";
            // 
            // lblprodid
            // 
            this.lblprodid.AutoSize = true;
            this.lblprodid.ForeColor = System.Drawing.Color.Red;
            this.lblprodid.Location = new System.Drawing.Point(116, 64);
            this.lblprodid.Name = "lblprodid";
            this.lblprodid.Size = new System.Drawing.Size(10, 13);
            this.lblprodid.TabIndex = 105;
            this.lblprodid.Text = "-";
            // 
            // lblUom
            // 
            this.lblUom.AutoSize = true;
            this.lblUom.ForeColor = System.Drawing.Color.Red;
            this.lblUom.Location = new System.Drawing.Point(82, 95);
            this.lblUom.Name = "lblUom";
            this.lblUom.Size = new System.Drawing.Size(10, 13);
            this.lblUom.TabIndex = 107;
            this.lblUom.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "Uom : ";
            // 
            // lblMYTRANSID
            // 
            this.lblMYTRANSID.AutoSize = true;
            this.lblMYTRANSID.ForeColor = System.Drawing.Color.Red;
            this.lblMYTRANSID.Location = new System.Drawing.Point(96, 127);
            this.lblMYTRANSID.Name = "lblMYTRANSID";
            this.lblMYTRANSID.Size = new System.Drawing.Size(10, 13);
            this.lblMYTRANSID.TabIndex = 109;
            this.lblMYTRANSID.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "MTransID : ";
            // 
            // lblMYSYSNAME
            // 
            this.lblMYSYSNAME.AutoSize = true;
            this.lblMYSYSNAME.ForeColor = System.Drawing.Color.Red;
            this.lblMYSYSNAME.Location = new System.Drawing.Point(98, 157);
            this.lblMYSYSNAME.Name = "lblMYSYSNAME";
            this.lblMYSYSNAME.Size = new System.Drawing.Size(10, 13);
            this.lblMYSYSNAME.TabIndex = 111;
            this.lblMYSYSNAME.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 110;
            this.label10.Text = "SysName : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 113;
            this.label7.Text = "Total Qty";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.ForeColor = System.Drawing.Color.Red;
            this.lblTotalQty.Location = new System.Drawing.Point(98, 191);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(10, 13);
            this.lblTotalQty.TabIndex = 114;
            this.lblTotalQty.Text = "-";
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(12, 23);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(310, 38);
            this.txtSerial.TabIndex = 1;
            this.txtSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerial_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSerial);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 88);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dateProduct);
            this.panel2.Controls.Add(this.lblTotalQty);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lblMYSYSNAME);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblprodid);
            this.panel2.Controls.Add(this.lblMYTRANSID);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblUom);
            this.panel2.Location = new System.Drawing.Point(345, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 314);
            this.panel2.TabIndex = 118;
            // 
            // Serialize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 422);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgrvMultiUomList);
            this.Name = "Serialize";
            this.Text = "Serialize";
            this.Load += new System.EventHandler(this.Perishable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvMultiUomList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvMultiUomList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateProduct;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}