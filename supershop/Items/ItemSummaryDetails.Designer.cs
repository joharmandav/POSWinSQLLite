namespace supershop
{
    partial class ItemSummaryDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelUserList = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.dgrvProductList = new System.Windows.Forms.DataGridView();
            this.tabWithImage = new System.Windows.Forms.TabPage();
            this.lblProductname = new System.Windows.Forms.Label();
            this.lblItemcode = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvProductList)).BeginInit();
            this.tabWithImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 39000;
            this.toolTip1.InitialDelay = 9;
            this.toolTip1.ReshowDelay = 9;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanelUserList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1134, 500);
            this.panel3.TabIndex = 145;
            // 
            // flowLayoutPanelUserList
            // 
            this.flowLayoutPanelUserList.AutoScroll = true;
            this.flowLayoutPanelUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelUserList.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelUserList.Name = "flowLayoutPanelUserList";
            this.flowLayoutPanelUserList.Size = new System.Drawing.Size(1134, 500);
            this.flowLayoutPanelUserList.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGrid);
            this.tabControl1.Controls.Add(this.tabWithImage);
            this.tabControl1.Location = new System.Drawing.Point(8, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 532);
            this.tabControl1.TabIndex = 152;
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.dgrvProductList);
            this.tabGrid.Location = new System.Drawing.Point(4, 22);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrid.Size = new System.Drawing.Size(1140, 506);
            this.tabGrid.TabIndex = 0;
            this.tabGrid.Text = "Sale Summary";
            this.tabGrid.UseVisualStyleBackColor = true;
            // 
            // dgrvProductList
            // 
            this.dgrvProductList.AllowUserToAddRows = false;
            this.dgrvProductList.AllowUserToDeleteRows = false;
            this.dgrvProductList.AllowUserToResizeColumns = false;
            this.dgrvProductList.AllowUserToResizeRows = false;
            this.dgrvProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvProductList.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgrvProductList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvProductList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvProductList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrvProductList.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgrvProductList.Location = new System.Drawing.Point(3, 3);
            this.dgrvProductList.Name = "dgrvProductList";
            this.dgrvProductList.RowHeadersVisible = false;
            this.dgrvProductList.RowTemplate.Height = 44;
            this.dgrvProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrvProductList.Size = new System.Drawing.Size(1134, 500);
            this.dgrvProductList.TabIndex = 182;
            // 
            // tabWithImage
            // 
            this.tabWithImage.Controls.Add(this.panel3);
            this.tabWithImage.Location = new System.Drawing.Point(4, 22);
            this.tabWithImage.Name = "tabWithImage";
            this.tabWithImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabWithImage.Size = new System.Drawing.Size(1140, 506);
            this.tabWithImage.TabIndex = 1;
            this.tabWithImage.Text = "Purchase Summary";
            this.tabWithImage.UseVisualStyleBackColor = true;
            // 
            // lblProductname
            // 
            this.lblProductname.AutoSize = true;
            this.lblProductname.Location = new System.Drawing.Point(503, 13);
            this.lblProductname.Name = "lblProductname";
            this.lblProductname.Size = new System.Drawing.Size(0, 13);
            this.lblProductname.TabIndex = 153;
            this.lblProductname.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemcode
            // 
            this.lblItemcode.AutoSize = true;
            this.lblItemcode.Location = new System.Drawing.Point(15, 12);
            this.lblItemcode.Name = "lblItemcode";
            this.lblItemcode.Size = new System.Drawing.Size(0, 13);
            this.lblItemcode.TabIndex = 154;
            // 
            // ItemSummaryDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1168, 586);
            this.Controls.Add(this.lblItemcode);
            this.Controls.Add(this.lblProductname);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSummaryDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Product Summary Detail";
            this.Load += new System.EventHandler(this.Stock_List_Load);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvProductList)).EndInit();
            this.tabWithImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUserList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGrid;
        private System.Windows.Forms.TabPage tabWithImage;
        private System.Windows.Forms.DataGridView dgrvProductList;
        private System.Windows.Forms.Label lblProductname;
        private System.Windows.Forms.Label lblItemcode;
    }
}