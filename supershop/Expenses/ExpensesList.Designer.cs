namespace supershop.Expenses
{
    partial class ExpensesList
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.datagridExpenses = new System.Windows.Forms.DataGridView();
            this.lblRow = new System.Windows.Forms.Label();
            this.lnkAddExpense = new System.Windows.Forms.LinkLabel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.datagridExpenses);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblSum);
            this.splitContainer1.Panel2.Controls.Add(this.lblRow);
            this.splitContainer1.Panel2.Controls.Add(this.lnkAddExpense);
            this.splitContainer1.Panel2.Controls.Add(this.txtSearch);
            this.splitContainer1.Size = new System.Drawing.Size(1204, 356);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.TabIndex = 19;
            // 
            // datagridExpenses
            // 
            this.datagridExpenses.AllowUserToAddRows = false;
            this.datagridExpenses.AllowUserToDeleteRows = false;
            this.datagridExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridExpenses.BackgroundColor = System.Drawing.SystemColors.Info;
            this.datagridExpenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.datagridExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridExpenses.DefaultCellStyle = dataGridViewCellStyle8;
            this.datagridExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridExpenses.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.datagridExpenses.Location = new System.Drawing.Point(0, 0);
            this.datagridExpenses.Name = "datagridExpenses";
            this.datagridExpenses.ReadOnly = true;
            this.datagridExpenses.RowHeadersVisible = false;
            this.datagridExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridExpenses.Size = new System.Drawing.Size(1204, 313);
            this.datagridExpenses.TabIndex = 95;
            this.datagridExpenses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridExpenses_CellClick);
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(469, 16);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(10, 13);
            this.lblRow.TabIndex = 1;
            this.lblRow.Text = "-";
            // 
            // lnkAddExpense
            // 
            this.lnkAddExpense.AutoSize = true;
            this.lnkAddExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lnkAddExpense.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAddExpense.Location = new System.Drawing.Point(12, 13);
            this.lnkAddExpense.Name = "lnkAddExpense";
            this.lnkAddExpense.Size = new System.Drawing.Size(89, 16);
            this.lnkAddExpense.TabIndex = 0;
            this.lnkAddExpense.TabStop = true;
            this.lnkAddExpense.Text = "Add Expense";
            this.lnkAddExpense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddExpense_LinkClicked);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(188, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(263, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(633, 15);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(10, 13);
            this.lblSum.TabIndex = 3;
            this.lblSum.Text = "-";
            // 
            // ExpensesList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1204, 356);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ExpensesList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expenses";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExpensesList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridExpenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView datagridExpenses;
        private System.Windows.Forms.LinkLabel lnkAddExpense;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSum;
    }
}