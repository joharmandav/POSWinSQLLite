namespace supershop
{
    partial class PaymentTypeList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lnkAddPayType = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.datagridPayment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 9;
            this.toolTip1.ReshowDelay = 9;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // lnkAddPayType
            // 
            this.lnkAddPayType.AutoSize = true;
            this.lnkAddPayType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lnkAddPayType.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkAddPayType.Location = new System.Drawing.Point(10, 22);
            this.lnkAddPayType.Name = "lnkAddPayType";
            this.lnkAddPayType.Size = new System.Drawing.Size(124, 16);
            this.lnkAddPayType.TabIndex = 0;
            this.lnkAddPayType.TabStop = true;
            this.lnkAddPayType.Text = "Add Payment Type";
            this.lnkAddPayType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddPayType_LinkClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.datagridPayment);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lnkAddPayType);
            this.splitContainer1.Size = new System.Drawing.Size(1171, 411);
            this.splitContainer1.SplitterDistance = 983;
            this.splitContainer1.TabIndex = 18;
            // 
            // datagridPayment
            // 
            this.datagridPayment.AllowUserToAddRows = false;
            this.datagridPayment.AllowUserToResizeColumns = false;
            this.datagridPayment.AllowUserToResizeRows = false;
            this.datagridPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridPayment.BackgroundColor = System.Drawing.SystemColors.Info;
            this.datagridPayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridPayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridPayment.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridPayment.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.datagridPayment.Location = new System.Drawing.Point(0, 0);
            this.datagridPayment.Name = "datagridPayment";
            this.datagridPayment.RowHeadersVisible = false;
            this.datagridPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridPayment.Size = new System.Drawing.Size(983, 411);
            this.datagridPayment.TabIndex = 95;
            this.datagridPayment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridPayment_CellClick);
            // 
            // PaymentTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1171, 411);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentTypeList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Type";
            this.Load += new System.EventHandler(this.PaymentTypeList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel lnkAddPayType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView datagridPayment;
    }
}