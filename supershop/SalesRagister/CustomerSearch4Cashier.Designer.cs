namespace supershop
{
    partial class CustomerSearch4Cashier
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelCustomerEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelCustomerMobile = new System.Windows.Forms.Label();
            this.txtcustomeMobile = new System.Windows.Forms.TextBox();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.dtGrdvCustomerDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvCustomerDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomerCode);
            this.splitContainer1.Panel1.Controls.Add(this.labelCustomerEmail);
            this.splitContainer1.Panel1.Controls.Add(this.txtEmail);
            this.splitContainer1.Panel1.Controls.Add(this.labelCustomerMobile);
            this.splitContainer1.Panel1.Controls.Add(this.txtcustomeMobile);
            this.splitContainer1.Panel1.Controls.Add(this.labelCustomerName);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomerSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtGrdvCustomerDetails);
            this.splitContainer1.Size = new System.Drawing.Size(785, 197);
            this.splitContainer1.SplitterDistance = 48;
            this.splitContainer1.TabIndex = 1;
            // 
            // labelCustomerEmail
            // 
            this.labelCustomerEmail.AutoSize = true;
            this.labelCustomerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerEmail.ForeColor = System.Drawing.Color.White;
            this.labelCustomerEmail.Location = new System.Drawing.Point(454, 5);
            this.labelCustomerEmail.Name = "labelCustomerEmail";
            this.labelCustomerEmail.Size = new System.Drawing.Size(93, 13);
            this.labelCustomerEmail.TabIndex = 35;
            this.labelCustomerEmail.Text = "Customer Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(457, 21);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(154, 20);
            this.txtEmail.TabIndex = 34;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // labelCustomerMobile
            // 
            this.labelCustomerMobile.AutoSize = true;
            this.labelCustomerMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerMobile.ForeColor = System.Drawing.Color.White;
            this.labelCustomerMobile.Location = new System.Drawing.Point(280, 5);
            this.labelCustomerMobile.Name = "labelCustomerMobile";
            this.labelCustomerMobile.Size = new System.Drawing.Size(100, 13);
            this.labelCustomerMobile.TabIndex = 33;
            this.labelCustomerMobile.Text = "Customer Mobile";
            // 
            // txtcustomeMobile
            // 
            this.txtcustomeMobile.Location = new System.Drawing.Point(283, 21);
            this.txtcustomeMobile.Name = "txtcustomeMobile";
            this.txtcustomeMobile.Size = new System.Drawing.Size(157, 20);
            this.txtcustomeMobile.TabIndex = 32;
            this.txtcustomeMobile.TextChanged += new System.EventHandler(this.txtcustomeMobile_TextChanged);
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerName.ForeColor = System.Drawing.Color.White;
            this.labelCustomerName.Location = new System.Drawing.Point(109, 5);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(95, 13);
            this.labelCustomerName.TabIndex = 31;
            this.labelCustomerName.Text = "Customer Name";
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Location = new System.Drawing.Point(112, 21);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(154, 20);
            this.txtCustomerSearch.TabIndex = 0;
            this.txtCustomerSearch.TextChanged += new System.EventHandler(this.txtCustomerSearch_TextChanged);
            // 
            // dtGrdvCustomerDetails
            // 
            this.dtGrdvCustomerDetails.AllowUserToAddRows = false;
            this.dtGrdvCustomerDetails.AllowUserToDeleteRows = false;
            this.dtGrdvCustomerDetails.AllowUserToResizeColumns = false;
            this.dtGrdvCustomerDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtGrdvCustomerDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGrdvCustomerDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrdvCustomerDetails.BackgroundColor = System.Drawing.Color.White;
            this.dtGrdvCustomerDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGrdvCustomerDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGrdvCustomerDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtGrdvCustomerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrdvCustomerDetails.Location = new System.Drawing.Point(0, 0);
            this.dtGrdvCustomerDetails.Name = "dtGrdvCustomerDetails";
            this.dtGrdvCustomerDetails.ReadOnly = true;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dtGrdvCustomerDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtGrdvCustomerDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdvCustomerDetails.Size = new System.Drawing.Size(785, 145);
            this.dtGrdvCustomerDetails.TabIndex = 2;
            this.dtGrdvCustomerDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdvCustomerDetails_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Customer Code";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(12, 21);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(79, 20);
            this.txtCustomerCode.TabIndex = 36;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 197);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CustomerSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Search";
            this.Load += new System.EventHandler(this.CustomerSearch_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvCustomerDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.DataGridView dtGrdvCustomerDetails;
        private System.Windows.Forms.Label labelCustomerMobile;
        private System.Windows.Forms.TextBox txtcustomeMobile;
        private System.Windows.Forms.Label labelCustomerEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerCode;
    }
}