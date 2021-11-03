namespace supershop.Customer
{
    partial class CustomerDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDetails));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CombPeopleType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewCustLink = new System.Windows.Forms.Button();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.dtGrdvCustomerDetails = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomerCode);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.CombPeopleType);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddNewCustLink);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustomerSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtGrdvCustomerDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1122, 473);
            this.splitContainer1.SplitterDistance = 48;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "People Code";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCustomerCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtCustomerCode.Location = new System.Drawing.Point(22, 22);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(98, 20);
            this.txtCustomerCode.TabIndex = 34;
            this.toolTip1.SetToolTip(this.txtCustomerCode, "Customer Info Search by : ID, Name or City, Contact .... ");
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(365, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 15);
            this.label6.TabIndex = 33;
            this.label6.Text = "People Type";
            // 
            // CombPeopleType
            // 
            this.CombPeopleType.FormattingEnabled = true;
            this.CombPeopleType.Items.AddRange(new object[] {
            "All",
            "Customer",
            "Supplier",
            "Biller"});
            this.CombPeopleType.Location = new System.Drawing.Point(368, 22);
            this.CombPeopleType.Name = "CombPeopleType";
            this.CombPeopleType.Size = new System.Drawing.Size(277, 21);
            this.CombPeopleType.TabIndex = 32;
            this.CombPeopleType.Text = "Customer";
            this.CombPeopleType.SelectedIndexChanged += new System.EventHandler(this.CombPeopleType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(138, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "People Details";
            // 
            // btnAddNewCustLink
            // 
            this.btnAddNewCustLink.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddNewCustLink.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddNewCustLink.FlatAppearance.BorderSize = 0;
            this.btnAddNewCustLink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddNewCustLink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.btnAddNewCustLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCustLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCustLink.ForeColor = System.Drawing.Color.White;
            this.btnAddNewCustLink.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewCustLink.Image")));
            this.btnAddNewCustLink.Location = new System.Drawing.Point(702, 2);
            this.btnAddNewCustLink.Name = "btnAddNewCustLink";
            this.btnAddNewCustLink.Size = new System.Drawing.Size(176, 44);
            this.btnAddNewCustLink.TabIndex = 30;
            this.btnAddNewCustLink.Text = "Add New Customer";
            this.btnAddNewCustLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewCustLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewCustLink.UseVisualStyleBackColor = false;
            this.btnAddNewCustLink.Click += new System.EventHandler(this.btnAddNewCustLink_Click);
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCustomerSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtCustomerSearch.Location = new System.Drawing.Point(141, 22);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(205, 20);
            this.txtCustomerSearch.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtCustomerSearch, "Customer Info Search by : ID, Name or City, Contact .... ");
            this.txtCustomerSearch.TextChanged += new System.EventHandler(this.txtCustomerSearch_TextChanged);
            // 
            // dtGrdvCustomerDetails
            // 
            this.dtGrdvCustomerDetails.AllowUserToAddRows = false;
            this.dtGrdvCustomerDetails.AllowUserToDeleteRows = false;
            this.dtGrdvCustomerDetails.AllowUserToResizeColumns = false;
            this.dtGrdvCustomerDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtGrdvCustomerDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dtGrdvCustomerDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrdvCustomerDetails.BackgroundColor = System.Drawing.Color.White;
            this.dtGrdvCustomerDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrdvCustomerDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtGrdvCustomerDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGrdvCustomerDetails.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtGrdvCustomerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrdvCustomerDetails.Location = new System.Drawing.Point(0, 0);
            this.dtGrdvCustomerDetails.Name = "dtGrdvCustomerDetails";
            this.dtGrdvCustomerDetails.ReadOnly = true;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dtGrdvCustomerDetails.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dtGrdvCustomerDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdvCustomerDetails.Size = new System.Drawing.Size(1122, 421);
            this.dtGrdvCustomerDetails.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dtGrdvCustomerDetails, "To Update Customer Info Please click on row");
            this.dtGrdvCustomerDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdvCustomerDetails_CellClick);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 80000;
            this.toolTip1.BackColor = System.Drawing.Color.OliveDrab;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 1;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(950, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(169, 40);
            this.btnExport.TabIndex = 94;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // CustomerDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1122, 473);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CustomerDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "People Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomerDetails_Load);
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
        private System.Windows.Forms.DataGridView dtGrdvCustomerDetails;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnAddNewCustLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CombPeopleType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}