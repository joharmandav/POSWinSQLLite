namespace supershop.User_mgt
{
    partial class WorkSheet
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
            this.btnExport = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtgrdWorkingHoursList = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdWorkingHoursList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(820, 24);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(142, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dtStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.dtEndDate);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgrdWorkingHoursList);
            this.splitContainer1.Size = new System.Drawing.Size(974, 419);
            this.splitContainer1.SplitterDistance = 58;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(307, 20);
            this.txtSearch.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtSearch, "Search by user name");
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label1.Location = new System.Drawing.Point(537, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "End Date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(340, 23);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(168, 24);
            this.dtStartDate.TabIndex = 1;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(540, 23);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(168, 24);
            this.dtEndDate.TabIndex = 2;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label9.Location = new System.Drawing.Point(337, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 89;
            this.label9.Text = "Start Date";
            // 
            // dtgrdWorkingHoursList
            // 
            this.dtgrdWorkingHoursList.AllowUserToAddRows = false;
            this.dtgrdWorkingHoursList.AllowUserToDeleteRows = false;
            this.dtgrdWorkingHoursList.AllowUserToResizeColumns = false;
            this.dtgrdWorkingHoursList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtgrdWorkingHoursList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgrdWorkingHoursList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrdWorkingHoursList.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtgrdWorkingHoursList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdWorkingHoursList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgrdWorkingHoursList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdWorkingHoursList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgrdWorkingHoursList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdWorkingHoursList.Location = new System.Drawing.Point(0, 0);
            this.dtgrdWorkingHoursList.Name = "dtgrdWorkingHoursList";
            this.dtgrdWorkingHoursList.ReadOnly = true;
            this.dtgrdWorkingHoursList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dtgrdWorkingHoursList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgrdWorkingHoursList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrdWorkingHoursList.Size = new System.Drawing.Size(974, 357);
            this.dtgrdWorkingHoursList.TabIndex = 4;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "SalesReport.csv";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 9;
            this.toolTip1.ReshowDelay = 9;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // WorkSheet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(974, 419);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "WorkSheet";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Work Sheet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WorkSheet_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdWorkingHoursList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dtgrdWorkingHoursList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}