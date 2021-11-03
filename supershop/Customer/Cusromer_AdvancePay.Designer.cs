namespace supershop
{
    partial class Cusromer_AdvancePay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblAvailableBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtDateOFAdvance = new System.Windows.Forms.DateTimePicker();
            this.lblMyID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.datagridAdvanceHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridAdvanceHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblAvailableBalance);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtRemark);
            this.splitContainer1.Panel1.Controls.Add(this.txtAmount);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.dtDateOFAdvance);
            this.splitContainer1.Panel1.Controls.Add(this.lblMyID);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustomerID);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomerName);
            this.splitContainer1.Panel1.Controls.Add(this.label17);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.datagridAdvanceHistory);
            this.splitContainer1.Size = new System.Drawing.Size(824, 497);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.TabIndex = 79;
            // 
            // lblAvailableBalance
            // 
            this.lblAvailableBalance.AutoSize = true;
            this.lblAvailableBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableBalance.Location = new System.Drawing.Point(229, 292);
            this.lblAvailableBalance.Name = "lblAvailableBalance";
            this.lblAvailableBalance.Size = new System.Drawing.Size(26, 29);
            this.lblAvailableBalance.TabIndex = 200;
            this.lblAvailableBalance.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 29);
            this.label1.TabIndex = 199;
            this.label1.Text = "Advance Amount :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 29);
            this.label3.TabIndex = 198;
            this.label3.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtRemark.Location = new System.Drawing.Point(133, 194);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(552, 82);
            this.txtRemark.TabIndex = 197;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtAmount.Location = new System.Drawing.Point(133, 144);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(552, 35);
            this.txtAmount.TabIndex = 196;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 29);
            this.label2.TabIndex = 194;
            this.label2.Text = "Amount";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Crimson;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 12.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReset.Location = new System.Drawing.Point(412, 284);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 42);
            this.btnReset.TabIndex = 193;
            this.btnReset.Text = "Exit";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtDateOFAdvance
            // 
            this.dtDateOFAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOFAdvance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateOFAdvance.Location = new System.Drawing.Point(133, 95);
            this.dtDateOFAdvance.Name = "dtDateOFAdvance";
            this.dtDateOFAdvance.Size = new System.Drawing.Size(552, 35);
            this.dtDateOFAdvance.TabIndex = 192;
            this.dtDateOFAdvance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLAxisReading_KeyPress);
            // 
            // lblMyID
            // 
            this.lblMyID.AutoSize = true;
            this.lblMyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyID.Location = new System.Drawing.Point(12, 311);
            this.lblMyID.Name = "lblMyID";
            this.lblMyID.Size = new System.Drawing.Size(12, 16);
            this.lblMyID.TabIndex = 191;
            this.lblMyID.Text = "-";
            this.lblMyID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Gold;
            this.btnSave.Location = new System.Drawing.Point(561, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 42);
            this.btnSave.TabIndex = 190;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.Location = new System.Drawing.Point(730, 53);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(4, 5);
            this.lblCustomerID.TabIndex = 87;
            this.lblCustomerID.Text = "-";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtCustomerName.Location = new System.Drawing.Point(133, 40);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(552, 35);
            this.txtCustomerName.TabIndex = 85;
            this.txtCustomerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLAxisReading_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(49, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 29);
            this.label17.TabIndex = 82;
            this.label17.Text = "Date";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(38, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 29);
            this.label16.TabIndex = 81;
            this.label16.Text = "Name";
            // 
            // datagridAdvanceHistory
            // 
            this.datagridAdvanceHistory.AllowUserToAddRows = false;
            this.datagridAdvanceHistory.AllowUserToResizeColumns = false;
            this.datagridAdvanceHistory.AllowUserToResizeRows = false;
            this.datagridAdvanceHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridAdvanceHistory.BackgroundColor = System.Drawing.SystemColors.Info;
            this.datagridAdvanceHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridAdvanceHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridAdvanceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridAdvanceHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridAdvanceHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridAdvanceHistory.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.datagridAdvanceHistory.Location = new System.Drawing.Point(0, 0);
            this.datagridAdvanceHistory.Name = "datagridAdvanceHistory";
            this.datagridAdvanceHistory.RowHeadersVisible = false;
            this.datagridAdvanceHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridAdvanceHistory.Size = new System.Drawing.Size(824, 159);
            this.datagridAdvanceHistory.TabIndex = 96;
            this.datagridAdvanceHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridEyeHistory_CellContentClick);
            // 
            // Cusromer_AdvancePay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 497);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Cusromer_AdvancePay";
            this.Text = "Customer Advance Payment";
            this.Load += new System.EventHandler(this.Cusromer_AdvancePay_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridAdvanceHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMyID;
        private System.Windows.Forms.DataGridView datagridAdvanceHistory;
        private System.Windows.Forms.DateTimePicker dtDateOFAdvance;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAvailableBalance;



    }
}