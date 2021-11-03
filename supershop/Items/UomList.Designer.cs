namespace supershop
{
    partial class UomList
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lnkAddcategory = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.datagridcategories = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lblFromUOMID = new System.Windows.Forms.Label();
            this.lblFromUOMname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DataUOMConv = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridcategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataUOMConv)).BeginInit();
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
            this.lnkAddcategory.Location = new System.Drawing.Point(10, 22);
            this.lnkAddcategory.Name = "lnkAddcategory";
            this.lnkAddcategory.Size = new System.Drawing.Size(67, 16);
            this.lnkAddcategory.TabIndex = 0;
            this.lnkAddcategory.TabStop = true;
            this.lnkAddcategory.Text = "Add UOM";
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lnkAddcategory);
            this.splitContainer1.Size = new System.Drawing.Size(1171, 411);
            this.splitContainer1.SplitterDistance = 983;
            this.splitContainer1.TabIndex = 18;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.datagridcategories);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(983, 411);
            this.splitContainer2.SplitterDistance = 271;
            this.splitContainer2.TabIndex = 0;
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
            this.datagridcategories.Size = new System.Drawing.Size(983, 271);
            this.datagridcategories.TabIndex = 95;
            this.datagridcategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridcategories_CellClick);
            this.datagridcategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridcategories_CellClick);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.splitContainer3.Panel1.Controls.Add(this.lblFromUOMID);
            this.splitContainer3.Panel1.Controls.Add(this.lblFromUOMname);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.DataUOMConv);
            this.splitContainer3.Size = new System.Drawing.Size(983, 136);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.TabIndex = 0;
            // 
            // lblFromUOMID
            // 
            this.lblFromUOMID.AutoSize = true;
            this.lblFromUOMID.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromUOMID.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblFromUOMID.Location = new System.Drawing.Point(12, 1);
            this.lblFromUOMID.Name = "lblFromUOMID";
            this.lblFromUOMID.Size = new System.Drawing.Size(8, 9);
            this.lblFromUOMID.TabIndex = 2;
            this.lblFromUOMID.Text = "-";
            this.lblFromUOMID.Visible = false;
            // 
            // lblFromUOMname
            // 
            this.lblFromUOMname.AutoSize = true;
            this.lblFromUOMname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromUOMname.ForeColor = System.Drawing.Color.Blue;
            this.lblFromUOMname.Location = new System.Drawing.Point(47, 0);
            this.lblFromUOMname.Name = "lblFromUOMname";
            this.lblFromUOMname.Size = new System.Drawing.Size(19, 25);
            this.lblFromUOMname.TabIndex = 1;
            this.lblFromUOMname.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(395, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "UOM Conversion List";
            // 
            // DataUOMConv
            // 
            this.DataUOMConv.AllowUserToAddRows = false;
            this.DataUOMConv.AllowUserToResizeColumns = false;
            this.DataUOMConv.AllowUserToResizeRows = false;
            this.DataUOMConv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataUOMConv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DataUOMConv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataUOMConv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataUOMConv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataUOMConv.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataUOMConv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataUOMConv.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DataUOMConv.Location = new System.Drawing.Point(0, 0);
            this.DataUOMConv.Name = "DataUOMConv";
            this.DataUOMConv.RowHeadersVisible = false;
            this.DataUOMConv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataUOMConv.Size = new System.Drawing.Size(983, 107);
            this.DataUOMConv.TabIndex = 96;
            this.DataUOMConv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataUOMConv_CellContentClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1171, 411);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UomList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unit Of Masure";
            this.Load += new System.EventHandler(this.Categories_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridcategories)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataUOMConv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel lnkAddcategory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView datagridcategories;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView DataUOMConv;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFromUOMname;
        private System.Windows.Forms.Label lblFromUOMID;
        private System.Windows.Forms.Timer timer1;
    }
}