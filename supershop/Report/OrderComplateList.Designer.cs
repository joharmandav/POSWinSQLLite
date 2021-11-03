namespace supershop.Report
{
    partial class OrderComplateList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderComplateList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtReciptNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnStoreCreditRewards = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGrdvOrderDetails = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.MyPrintPreviewDialog = new System.Windows.Forms.PageSetupDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvOrderDetails)).BeginInit();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.txtReciptNO);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dtStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.btnStoreCreditRewards);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtGrdvOrderDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1122, 473);
            this.splitContainer1.SplitterDistance = 65;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(650, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 44);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(482, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(163, 40);
            this.btnExport.TabIndex = 93;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtReciptNO
            // 
            this.txtReciptNO.Location = new System.Drawing.Point(211, 31);
            this.txtReciptNO.Name = "txtReciptNO";
            this.txtReciptNO.Size = new System.Drawing.Size(241, 20);
            this.txtReciptNO.TabIndex = 89;
            this.txtReciptNO.TextChanged += new System.EventHandler(this.txtReciptNO_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(208, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 88;
            this.label2.Text = "Receipt No";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(21, 30);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(168, 24);
            this.dtStartDate.TabIndex = 87;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // btnStoreCreditRewards
            // 
            this.btnStoreCreditRewards.BackColor = System.Drawing.Color.White;
            this.btnStoreCreditRewards.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStoreCreditRewards.FlatAppearance.BorderSize = 0;
            this.btnStoreCreditRewards.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStoreCreditRewards.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.btnStoreCreditRewards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoreCreditRewards.Location = new System.Drawing.Point(1174, 3);
            this.btnStoreCreditRewards.Name = "btnStoreCreditRewards";
            this.btnStoreCreditRewards.Size = new System.Drawing.Size(10, 44);
            this.btnStoreCreditRewards.TabIndex = 31;
            this.btnStoreCreditRewards.Text = "Store Credit Rewards";
            this.btnStoreCreditRewards.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStoreCreditRewards.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStoreCreditRewards.UseVisualStyleBackColor = false;
            this.btnStoreCreditRewards.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "From Date";
            // 
            // dtGrdvOrderDetails
            // 
            this.dtGrdvOrderDetails.AllowUserToAddRows = false;
            this.dtGrdvOrderDetails.AllowUserToDeleteRows = false;
            this.dtGrdvOrderDetails.AllowUserToResizeColumns = false;
            this.dtGrdvOrderDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtGrdvOrderDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGrdvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrdvOrderDetails.BackgroundColor = System.Drawing.Color.White;
            this.dtGrdvOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrdvOrderDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGrdvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGrdvOrderDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtGrdvOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrdvOrderDetails.Location = new System.Drawing.Point(0, 0);
            this.dtGrdvOrderDetails.Name = "dtGrdvOrderDetails";
            this.dtGrdvOrderDetails.ReadOnly = true;
            this.dtGrdvOrderDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dtGrdvOrderDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtGrdvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdvOrderDetails.Size = new System.Drawing.Size(1122, 404);
            this.dtGrdvOrderDetails.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dtGrdvOrderDetails, "To Update Customer Info Please click on row");
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
            // OrderComplateList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1122, 473);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrderComplateList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Driver Delivery List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomerDetails_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvOrderDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dtGrdvOrderDetails;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStoreCreditRewards;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReciptNO;
        private System.Windows.Forms.Button btnExport;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog MyPrintPreviewDialog;
        private System.Windows.Forms.Button btnPrint;
    }
}