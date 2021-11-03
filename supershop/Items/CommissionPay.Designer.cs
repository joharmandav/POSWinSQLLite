namespace supershop
{
    partial class CommissionPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommissionPay));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.datagrdReportDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCommTotal = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCashierRefresh = new System.Windows.Forms.Button();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.lblFirstEmployee = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblCommPaid = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCommDue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.resourceHolder1 = new ResourceEditor.ResourceHolder();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.MyPrintPreviewDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).BeginInit();
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
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(579, 47);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 26);
            this.btnSave.TabIndex = 186;
            this.btnSave.Text = "Pay";
            this.toolTip1.SetToolTip(this.btnSave, "I want to Submit");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Silver;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrint.Location = new System.Drawing.Point(914, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 26);
            this.btnPrint.TabIndex = 237;
            this.btnPrint.Text = "Print";
            this.toolTip1.SetToolTip(this.btnPrint, "I want to Submit");
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.datagrdReportDetails);
            this.panel4.Location = new System.Drawing.Point(12, 96);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1014, 502);
            this.panel4.TabIndex = 177;
            // 
            // datagrdReportDetails
            // 
            this.datagrdReportDetails.AllowUserToAddRows = false;
            this.datagrdReportDetails.AllowUserToDeleteRows = false;
            this.datagrdReportDetails.AllowUserToResizeColumns = false;
            this.datagrdReportDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.datagrdReportDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrdReportDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrdReportDetails.BackgroundColor = System.Drawing.Color.White;
            this.datagrdReportDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdReportDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrdReportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrdReportDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagrdReportDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrdReportDetails.Location = new System.Drawing.Point(0, 0);
            this.datagrdReportDetails.Name = "datagrdReportDetails";
            this.datagrdReportDetails.ReadOnly = true;
            this.datagrdReportDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrdReportDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagrdReportDetails.RowTemplate.Height = 33;
            this.datagrdReportDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdReportDetails.Size = new System.Drawing.Size(1012, 500);
            this.datagrdReportDetails.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(689, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 193;
            this.label1.Text = "Comm. Total :";
            // 
            // lblCommTotal
            // 
            this.lblCommTotal.AutoSize = true;
            this.lblCommTotal.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommTotal.Location = new System.Drawing.Point(804, 15);
            this.lblCommTotal.Name = "lblCommTotal";
            this.lblCommTotal.Size = new System.Drawing.Size(16, 16);
            this.lblCommTotal.TabIndex = 194;
            this.lblCommTotal.Text = "-";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(167, 51);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(130, 21);
            this.dtEndDate.TabIndex = 202;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label3.Location = new System.Drawing.Point(164, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 201;
            this.label3.Text = "TO DATE";
            // 
            // btnCashierRefresh
            // 
            this.btnCashierRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCashierRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCashierRefresh.FlatAppearance.BorderSize = 0;
            this.btnCashierRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCashierRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashierRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCashierRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnCashierRefresh.Image")));
            this.btnCashierRefresh.Location = new System.Drawing.Point(308, 47);
            this.btnCashierRefresh.Name = "btnCashierRefresh";
            this.btnCashierRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnCashierRefresh.TabIndex = 200;
            this.btnCashierRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashierRefresh.UseVisualStyleBackColor = false;
            this.btnCashierRefresh.Click += new System.EventHandler(this.btnCashierRefresh_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(17, 51);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(130, 21);
            this.dtStartDate.TabIndex = 199;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label9.Location = new System.Drawing.Point(14, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 198;
            this.label9.Text = "FROM DATE";
            // 
            // comboEmployee
            // 
            this.comboEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(352, 49);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(205, 24);
            this.comboEmployee.TabIndex = 217;
            this.comboEmployee.SelectedIndexChanged += new System.EventHandler(this.comboEmployee_SelectedIndexChanged);
            // 
            // lblFirstEmployee
            // 
            this.lblFirstEmployee.AutoSize = true;
            this.lblFirstEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstEmployee.Location = new System.Drawing.Point(547, 33);
            this.lblFirstEmployee.Name = "lblFirstEmployee";
            this.lblFirstEmployee.Size = new System.Drawing.Size(10, 13);
            this.lblFirstEmployee.TabIndex = 228;
            this.lblFirstEmployee.Text = "-";
            this.lblFirstEmployee.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(349, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 231;
            this.label4.Text = "Employee";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Crimson;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReset.Location = new System.Drawing.Point(914, 40);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(83, 28);
            this.btnReset.TabIndex = 232;
            this.btnReset.Text = "Exit";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblCommPaid
            // 
            this.lblCommPaid.AutoSize = true;
            this.lblCommPaid.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommPaid.Location = new System.Drawing.Point(805, 36);
            this.lblCommPaid.Name = "lblCommPaid";
            this.lblCommPaid.Size = new System.Drawing.Size(16, 16);
            this.lblCommPaid.TabIndex = 234;
            this.lblCommPaid.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(689, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 233;
            this.label5.Text = "Comm. Paid  :";
            // 
            // lblCommDue
            // 
            this.lblCommDue.AutoSize = true;
            this.lblCommDue.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommDue.Location = new System.Drawing.Point(807, 55);
            this.lblCommDue.Name = "lblCommDue";
            this.lblCommDue.Size = new System.Drawing.Size(16, 16);
            this.lblCommDue.TabIndex = 236;
            this.lblCommDue.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(689, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 16);
            this.label7.TabIndex = 235;
            this.label7.Text = "Comm. Due   :";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(998, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 238;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CommissionPay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1028, 599);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblCommDue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCommPaid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFirstEmployee);
            this.Controls.Add(this.comboEmployee);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCashierRefresh);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCommTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommissionPay";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Commission Payment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CommissionPay_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView datagrdReportDetails;
        private System.Windows.Forms.Button btnSave;
        private ResourceEditor.ResourceHolder resourceHolder1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCommTotal;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCashierRefresh;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.Label lblFirstEmployee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblCommPaid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCommDue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog MyPrintPreviewDialog1;
        private System.Windows.Forms.Button button1;
    }
}