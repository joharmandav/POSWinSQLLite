namespace supershop
{
    partial class payablecredit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(payablecredit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ComboCustID = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.lbreceiveamt = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.RefrashPayby = new System.Windows.Forms.Button();
            this.labelPayby = new System.Windows.Forms.Label();
            this.CombPayby = new System.Windows.Forms.ComboBox();
            this.txtRefrance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblload = new System.Windows.Forms.Label();
            this.lblTotalPayable = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblParsialTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblafterpaid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAdvance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCustAdvance = new System.Windows.Forms.Label();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnPaidRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboCustID
            // 
            this.ComboCustID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboCustID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboCustID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboCustID.FormattingEnabled = true;
            this.ComboCustID.Location = new System.Drawing.Point(29, 46);
            this.ComboCustID.Name = "ComboCustID";
            this.ComboCustID.Size = new System.Drawing.Size(221, 26);
            this.ComboCustID.TabIndex = 172;
            this.ComboCustID.SelectedIndexChanged += new System.EventHandler(this.ComboCustID_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(294, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 176;
            this.label7.Text = "Receive Date:";
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.CustomFormat = "";
            this.dtReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtReceiveDate.Location = new System.Drawing.Point(296, 46);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.Size = new System.Drawing.Size(125, 24);
            this.dtReceiveDate.TabIndex = 175;
            // 
            // txtReceive
            // 
            this.txtReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceive.HideSelection = false;
            this.txtReceive.Location = new System.Drawing.Point(29, 214);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(221, 29);
            this.txtReceive.TabIndex = 177;
            this.txtReceive.Text = "0";
            this.txtReceive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceive_KeyDown);
            this.txtReceive.Leave += new System.EventHandler(this.txtReceive_Leave);
            // 
            // lbreceiveamt
            // 
            this.lbreceiveamt.AutoSize = true;
            this.lbreceiveamt.Location = new System.Drawing.Point(27, 195);
            this.lbreceiveamt.Name = "lbreceiveamt";
            this.lbreceiveamt.Size = new System.Drawing.Size(73, 13);
            this.lbreceiveamt.TabIndex = 179;
            this.lbreceiveamt.Text = "Paid Amount :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(392, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 43);
            this.btnSave.TabIndex = 178;
            this.btnSave.Text = "Payment";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel4.Location = new System.Drawing.Point(199, 87);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(51, 13);
            this.linkLabel4.TabIndex = 209;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Add New";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // RefrashPayby
            // 
            this.RefrashPayby.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RefrashPayby.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RefrashPayby.FlatAppearance.BorderSize = 0;
            this.RefrashPayby.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.RefrashPayby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefrashPayby.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.RefrashPayby.Image = ((System.Drawing.Image)(resources.GetObject("RefrashPayby.Image")));
            this.RefrashPayby.Location = new System.Drawing.Point(258, 107);
            this.RefrashPayby.Name = "RefrashPayby";
            this.RefrashPayby.Size = new System.Drawing.Size(25, 25);
            this.RefrashPayby.TabIndex = 208;
            this.RefrashPayby.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RefrashPayby.UseVisualStyleBackColor = false;
            this.RefrashPayby.Click += new System.EventHandler(this.RefrashPayby_Click);
            // 
            // labelPayby
            // 
            this.labelPayby.AutoSize = true;
            this.labelPayby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPayby.Location = new System.Drawing.Point(27, 87);
            this.labelPayby.Name = "labelPayby";
            this.labelPayby.Size = new System.Drawing.Size(45, 13);
            this.labelPayby.TabIndex = 207;
            this.labelPayby.Text = "Pay by :";
            // 
            // CombPayby
            // 
            this.CombPayby.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombPayby.FormattingEnabled = true;
            this.CombPayby.Location = new System.Drawing.Point(30, 106);
            this.CombPayby.Name = "CombPayby";
            this.CombPayby.Size = new System.Drawing.Size(220, 26);
            this.CombPayby.TabIndex = 206;
            this.CombPayby.Text = "Cash";
            // 
            // txtRefrance
            // 
            this.txtRefrance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefrance.Location = new System.Drawing.Point(29, 159);
            this.txtRefrance.Name = "txtRefrance";
            this.txtRefrance.Size = new System.Drawing.Size(221, 24);
            this.txtRefrance.TabIndex = 212;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 213;
            this.label2.Text = "Reference #";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.Location = new System.Drawing.Point(27, 30);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(60, 13);
            this.linkLabel1.TabIndex = 214;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Customer  :";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(296, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(468, 181);
            this.dataGridView1.TabIndex = 217;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.Location = new System.Drawing.Point(205, 30);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(10, 13);
            this.lblCustomerID.TabIndex = 218;
            this.lblCustomerID.Text = "-";
            // 
            // lblload
            // 
            this.lblload.AutoSize = true;
            this.lblload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblload.Location = new System.Drawing.Point(12, 316);
            this.lblload.Name = "lblload";
            this.lblload.Size = new System.Drawing.Size(10, 13);
            this.lblload.TabIndex = 219;
            this.lblload.Text = "-";
            // 
            // lblTotalPayable
            // 
            this.lblTotalPayable.AutoSize = true;
            this.lblTotalPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPayable.Location = new System.Drawing.Point(138, 250);
            this.lblTotalPayable.Name = "lblTotalPayable";
            this.lblTotalPayable.Size = new System.Drawing.Size(18, 20);
            this.lblTotalPayable.TabIndex = 221;
            this.lblTotalPayable.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 220;
            this.label5.Text = "Total Payable :";
            // 
            // lblParsialTotal
            // 
            this.lblParsialTotal.AutoSize = true;
            this.lblParsialTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParsialTotal.Location = new System.Drawing.Point(541, 51);
            this.lblParsialTotal.Name = "lblParsialTotal";
            this.lblParsialTotal.Size = new System.Drawing.Size(18, 20);
            this.lblParsialTotal.TabIndex = 223;
            this.lblParsialTotal.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(439, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 222;
            this.label6.Text = "Adjust Total :";
            // 
            // lblafterpaid
            // 
            this.lblafterpaid.AutoSize = true;
            this.lblafterpaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblafterpaid.Location = new System.Drawing.Point(138, 280);
            this.lblafterpaid.Name = "lblafterpaid";
            this.lblafterpaid.Size = new System.Drawing.Size(18, 20);
            this.lblafterpaid.TabIndex = 225;
            this.lblafterpaid.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 224;
            this.label3.Text = "Advance         :";
            // 
            // lblAdvance
            // 
            this.lblAdvance.AutoSize = true;
            this.lblAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvance.Location = new System.Drawing.Point(138, 311);
            this.lblAdvance.Name = "lblAdvance";
            this.lblAdvance.Size = new System.Drawing.Size(18, 20);
            this.lblAdvance.TabIndex = 227;
            this.lblAdvance.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 226;
            this.label4.Text = "After Paid       :";
            // 
            // lblCustAdvance
            // 
            this.lblCustAdvance.AutoSize = true;
            this.lblCustAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustAdvance.Location = new System.Drawing.Point(760, 295);
            this.lblCustAdvance.Name = "lblCustAdvance";
            this.lblCustAdvance.Size = new System.Drawing.Size(4, 5);
            this.lblCustAdvance.TabIndex = 228;
            this.lblCustAdvance.Text = "-";
            // 
            // BtnPrint
            // 
            this.BtnPrint.BackColor = System.Drawing.Color.Silver;
            this.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.Location = new System.Drawing.Point(581, 280);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(106, 43);
            this.BtnPrint.TabIndex = 229;
            this.BtnPrint.Text = "Print";
            this.BtnPrint.UseVisualStyleBackColor = false;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(709, 52);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(18, 20);
            this.lblBalance.TabIndex = 231;
            this.lblBalance.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(628, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 230;
            this.label8.Text = "Balance :";
            // 
            // BtnPaidRefresh
            // 
            this.BtnPaidRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnPaidRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnPaidRefresh.FlatAppearance.BorderSize = 0;
            this.BtnPaidRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BtnPaidRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPaidRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.BtnPaidRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BtnPaidRefresh.Image")));
            this.BtnPaidRefresh.Location = new System.Drawing.Point(258, 218);
            this.BtnPaidRefresh.Name = "BtnPaidRefresh";
            this.BtnPaidRefresh.Size = new System.Drawing.Size(25, 25);
            this.BtnPaidRefresh.TabIndex = 232;
            this.BtnPaidRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnPaidRefresh.UseVisualStyleBackColor = false;
            this.BtnPaidRefresh.Click += new System.EventHandler(this.BtnPaidRefresh_Click);
            // 
            // payablecredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(783, 341);
            this.Controls.Add(this.BtnPaidRefresh);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.lblCustAdvance);
            this.Controls.Add(this.lblAdvance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblafterpaid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblParsialTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotalPayable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblload);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtRefrance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.RefrashPayby);
            this.Controls.Add(this.labelPayby);
            this.Controls.Add(this.CombPayby);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.lbreceiveamt);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtReceiveDate);
            this.Controls.Add(this.ComboCustID);
            this.Name = "payablecredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Payable";
            this.Load += new System.EventHandler(this.payablecredit_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.payablecredit_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboCustID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtReceiveDate;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Label lbreceiveamt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Button RefrashPayby;
        private System.Windows.Forms.Label labelPayby;
        private System.Windows.Forms.ComboBox CombPayby;
        private System.Windows.Forms.TextBox txtRefrance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblload;
        private System.Windows.Forms.Label lblTotalPayable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblParsialTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblafterpaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAdvance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCustAdvance;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnPaidRefresh;
    }
}