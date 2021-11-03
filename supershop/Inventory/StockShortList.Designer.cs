namespace supershop.Inventory
{
    partial class StockShortList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtItemSearchBar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkClose = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtgrdViewStockItem = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdViewStockItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Plum;
            this.panel2.Location = new System.Drawing.Point(3, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 19);
            this.panel2.TabIndex = 48;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StockShortList_MouseDown);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // txtItemSearchBar
            // 
            this.txtItemSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtItemSearchBar.Location = new System.Drawing.Point(9, 48);
            this.txtItemSearchBar.Name = "txtItemSearchBar";
            this.txtItemSearchBar.Size = new System.Drawing.Size(721, 29);
            this.txtItemSearchBar.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtItemSearchBar, "Search by Product ID, Name , Category or Supplier");
            this.txtItemSearchBar.TextChanged += new System.EventHandler(this.txtItemSearchBar_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.lnkClose);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(9, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 26);
            this.panel1.TabIndex = 47;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StockShortList_MouseDown);
            // 
            // lnkClose
            // 
            this.lnkClose.AutoSize = true;
            this.lnkClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClose.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lnkClose.Location = new System.Drawing.Point(694, 2);
            this.lnkClose.Name = "lnkClose";
            this.lnkClose.Size = new System.Drawing.Size(24, 24);
            this.lnkClose.TabIndex = 52;
            this.lnkClose.TabStop = true;
            this.lnkClose.Text = "X";
            this.lnkClose.Visible = false;
            this.lnkClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClose_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 23);
            this.label5.TabIndex = 52;
            this.label5.Text = "Stock Item";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Search Product";
            // 
            // dtgrdViewStockItem
            // 
            this.dtgrdViewStockItem.AllowUserToAddRows = false;
            this.dtgrdViewStockItem.AllowUserToDeleteRows = false;
            this.dtgrdViewStockItem.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LimeGreen;
            this.dtgrdViewStockItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgrdViewStockItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrdViewStockItem.BackgroundColor = System.Drawing.Color.White;
            this.dtgrdViewStockItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdViewStockItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgrdViewStockItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdViewStockItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgrdViewStockItem.Location = new System.Drawing.Point(9, 83);
            this.dtgrdViewStockItem.Name = "dtgrdViewStockItem";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdViewStockItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkGreen;
            this.dtgrdViewStockItem.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgrdViewStockItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrdViewStockItem.Size = new System.Drawing.Size(721, 257);
            this.dtgrdViewStockItem.TabIndex = 51;
            this.dtgrdViewStockItem.Tag = "fgfg";
            this.dtgrdViewStockItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdViewStockItem_CellClick);
            this.dtgrdViewStockItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgrdViewStockItem_KeyDown);
            // 
            // StockShortList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(736, 363);
            this.Controls.Add(this.dtgrdViewStockItem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtItemSearchBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockShortList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Short List";
            this.Load += new System.EventHandler(this.StockShortList_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StockShortList_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdViewStockItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtItemSearchBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dtgrdViewStockItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkClose;
    }
}