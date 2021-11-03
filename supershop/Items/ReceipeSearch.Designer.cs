namespace supershop
{
    partial class ReceipeSearch
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
            this.lblReceipeType = new System.Windows.Forms.Label();
            this.lblPageName = new System.Windows.Forms.Label();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.dtGrdvCustomerDetails = new System.Windows.Forms.DataGridView();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblReceipeType);
            this.splitContainer1.Panel1.Controls.Add(this.lblPageName);
            this.splitContainer1.Panel1.Controls.Add(this.labelCustomerName);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomerSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtGrdvCustomerDetails);
            this.splitContainer1.Size = new System.Drawing.Size(619, 271);
            this.splitContainer1.SplitterDistance = 48;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblReceipeType
            // 
            this.lblReceipeType.AutoSize = true;
            this.lblReceipeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceipeType.ForeColor = System.Drawing.Color.White;
            this.lblReceipeType.Location = new System.Drawing.Point(564, 5);
            this.lblReceipeType.Name = "lblReceipeType";
            this.lblReceipeType.Size = new System.Drawing.Size(5, 4);
            this.lblReceipeType.TabIndex = 33;
            this.lblReceipeType.Text = "-";
            // 
            // lblPageName
            // 
            this.lblPageName.AutoSize = true;
            this.lblPageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageName.ForeColor = System.Drawing.Color.White;
            this.lblPageName.Location = new System.Drawing.Point(494, 5);
            this.lblPageName.Name = "lblPageName";
            this.lblPageName.Size = new System.Drawing.Size(5, 4);
            this.lblPageName.TabIndex = 32;
            this.lblPageName.Text = "-";
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerName.ForeColor = System.Drawing.Color.White;
            this.labelCustomerName.Location = new System.Drawing.Point(19, 5);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(154, 13);
            this.labelCustomerName.TabIndex = 31;
            this.labelCustomerName.Text = "Receipe / Package Name";
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Location = new System.Drawing.Point(22, 21);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(179, 20);
            this.txtCustomerSearch.TabIndex = 0;
            this.txtCustomerSearch.TextChanged += new System.EventHandler(this.txtCustomerSearch_TextChanged);
            // 
            // dtGrdvCustomerDetails
            // 
            this.dtGrdvCustomerDetails.AllowUserToAddRows = false;
            this.dtGrdvCustomerDetails.AllowUserToDeleteRows = false;
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
            this.dtGrdvCustomerDetails.Size = new System.Drawing.Size(619, 219);
            this.dtGrdvCustomerDetails.TabIndex = 2;
            this.dtGrdvCustomerDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdvCustomerDetails_CellContentClick);
            // 
            // ReceipeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 271);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReceipeSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipe / Package Search";
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
        private System.Windows.Forms.Label lblPageName;
        private System.Windows.Forms.Label lblReceipeType;
    }
}