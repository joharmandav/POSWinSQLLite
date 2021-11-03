namespace supershop
{
    partial class AppointmentS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnCashierRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.datagrdReportDetails = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.btnshowJobs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Crimson;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReset.Location = new System.Drawing.Point(899, 32);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(180, 37);
            this.btnReset.TabIndex = 161;
            this.btnReset.Text = "Back To DashBoard";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(165, 49);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(130, 21);
            this.dtEndDate.TabIndex = 97;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label3.Location = new System.Drawing.Point(162, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Report by To date";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(115, 11);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(10, 13);
            this.lblMsg.TabIndex = 95;
            this.lblMsg.Text = "-";
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
            this.btnCashierRefresh.Location = new System.Drawing.Point(306, 45);
            this.btnCashierRefresh.Name = "btnCashierRefresh";
            this.btnCashierRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnCashierRefresh.TabIndex = 94;
            this.btnCashierRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashierRefresh.UseVisualStyleBackColor = false;
            this.btnCashierRefresh.Click += new System.EventHandler(this.btnCashierRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = "Today";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(15, 49);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(130, 21);
            this.dtStartDate.TabIndex = 90;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label9.Location = new System.Drawing.Point(12, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 88;
            this.label9.Text = "Report by From date";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(49, 10);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(31, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "____";
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11F);
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
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.datagrdReportDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagrdReportDetails.RowTemplate.Height = 44;
            this.datagrdReportDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrdReportDetails.Size = new System.Drawing.Size(1096, 397);
            this.datagrdReportDetails.TabIndex = 2;
            this.datagrdReportDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrdReportDetails_CellClick);
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.btnshowJobs);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.dtEndDate);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lblMsg);
            this.splitContainer1.Panel1.Controls.Add(this.btnCashierRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dtStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.lblStartDate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.datagrdReportDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1096, 483);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(666, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 37);
            this.button1.TabIndex = 162;
            this.button1.Text = "Add New Appointment";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnshowJobs
            // 
            this.btnshowJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnshowJobs.FlatAppearance.BorderSize = 0;
            this.btnshowJobs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnshowJobs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnshowJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnshowJobs.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnshowJobs.ForeColor = System.Drawing.SystemColors.Window;
            this.btnshowJobs.Location = new System.Drawing.Point(514, 32);
            this.btnshowJobs.Name = "btnshowJobs";
            this.btnshowJobs.Size = new System.Drawing.Size(117, 37);
            this.btnshowJobs.TabIndex = 163;
            this.btnshowJobs.Text = "Show Jobs";
            this.btnshowJobs.UseVisualStyleBackColor = false;
            this.btnshowJobs.Click += new System.EventHandler(this.btnshowJobs_Click);
            // 
            // AppointmentS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 483);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AppointmentS";
            this.Text = "Appointment";
            this.Load += new System.EventHandler(this.AppointmentS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrdReportDetails)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnCashierRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DataGridView datagrdReportDetails;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnshowJobs;
    }
}