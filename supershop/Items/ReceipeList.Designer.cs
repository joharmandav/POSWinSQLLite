namespace supershop.Items
{
    partial class ReceipeList
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
            this.lnkAddcategory = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.datagridcategories = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridcategories)).BeginInit();
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
            // lnkAddcategory
            // 
            this.lnkAddcategory.AutoSize = true;
            this.lnkAddcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lnkAddcategory.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkAddcategory.Location = new System.Drawing.Point(18, 17);
            this.lnkAddcategory.Name = "lnkAddcategory";
            this.lnkAddcategory.Size = new System.Drawing.Size(88, 16);
            this.lnkAddcategory.TabIndex = 0;
            this.lnkAddcategory.TabStop = true;
            this.lnkAddcategory.Text = "Add Receipe";
            this.lnkAddcategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddcategory_LinkClicked);
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
            this.splitContainer1.Panel1.Controls.Add(this.datagridcategories);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lnkAddcategory);
            this.splitContainer1.Size = new System.Drawing.Size(1171, 309);
            this.splitContainer1.SplitterDistance = 1023;
            this.splitContainer1.TabIndex = 18;
            // 
            // datagridcategories
            // 
            this.datagridcategories.AllowUserToAddRows = false;
            this.datagridcategories.AllowUserToResizeColumns = false;
            this.datagridcategories.AllowUserToResizeRows = false;
            this.datagridcategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridcategories.BackgroundColor = System.Drawing.SystemColors.Info;
            this.datagridcategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridcategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridcategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridcategories.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridcategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridcategories.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.datagridcategories.Location = new System.Drawing.Point(0, 0);
            this.datagridcategories.Name = "datagridcategories";
            this.datagridcategories.RowHeadersVisible = false;
            this.datagridcategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridcategories.Size = new System.Drawing.Size(1023, 309);
            this.datagridcategories.TabIndex = 95;
            this.datagridcategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridcategories_CellClick);
            // 
            // ReceipeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 309);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceipeList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipe List";
            this.Load += new System.EventHandler(this.ReceipeList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridcategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel lnkAddcategory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView datagridcategories;
    }
}