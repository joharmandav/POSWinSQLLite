namespace supershop.Customer
{
    partial class Due_payment_History
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
            this.dtgviewCustDueHistory = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblcustid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblinvoNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewCustDueHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgviewCustDueHistory
            // 
            this.dtgviewCustDueHistory.AllowUserToAddRows = false;
            this.dtgviewCustDueHistory.AllowUserToDeleteRows = false;
            this.dtgviewCustDueHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgviewCustDueHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgviewCustDueHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgviewCustDueHistory.Location = new System.Drawing.Point(0, 0);
            this.dtgviewCustDueHistory.Name = "dtgviewCustDueHistory";
            this.dtgviewCustDueHistory.ReadOnly = true;
            this.dtgviewCustDueHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgviewCustDueHistory.Size = new System.Drawing.Size(626, 265);
            this.dtgviewCustDueHistory.TabIndex = 1;
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
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblinvoNo);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblcustid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgviewCustDueHistory);
            this.splitContainer1.Size = new System.Drawing.Size(626, 305);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 2;
            // 
            // lblcustid
            // 
            this.lblcustid.AutoSize = true;
            this.lblcustid.Location = new System.Drawing.Point(476, 9);
            this.lblcustid.Name = "lblcustid";
            this.lblcustid.Size = new System.Drawing.Size(39, 13);
            this.lblcustid.TabIndex = 0;
            this.lblcustid.Text = "CustID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Invoice No:";
            // 
            // lblinvoNo
            // 
            this.lblinvoNo.AutoSize = true;
            this.lblinvoNo.Location = new System.Drawing.Point(79, 9);
            this.lblinvoNo.Name = "lblinvoNo";
            this.lblinvoNo.Size = new System.Drawing.Size(19, 13);
            this.lblinvoNo.TabIndex = 2;
            this.lblinvoNo.Text = "00";
            // 
            // Due_payment_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 305);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Due_payment_History";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Due payment History";
            this.Load += new System.EventHandler(this.Due_payment_History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewCustDueHistory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgviewCustDueHistory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblcustid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblinvoNo;
    }
}