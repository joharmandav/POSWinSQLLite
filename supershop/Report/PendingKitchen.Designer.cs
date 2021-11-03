namespace supershop.Report
{
    partial class PendingKitchen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingKitchen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtDriverEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtReciptNO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDriverStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtGrdvOrderDetails = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.btnReset);
            this.splitContainer2.Panel1.Controls.Add(this.dtDriverEndDate);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.txtReciptNO);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.dtDriverStartDate);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dtGrdvOrderDetails);
            this.splitContainer2.Size = new System.Drawing.Size(1260, 547);
            this.splitContainer2.SplitterDistance = 65;
            this.splitContainer2.TabIndex = 2;
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
            this.btnReset.Location = new System.Drawing.Point(770, 17);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(180, 37);
            this.btnReset.TabIndex = 161;
            this.btnReset.Text = "Back To DashBoard";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtDriverEndDate
            // 
            this.dtDriverEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDriverEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDriverEndDate.Location = new System.Drawing.Point(198, 30);
            this.dtDriverEndDate.Name = "dtDriverEndDate";
            this.dtDriverEndDate.Size = new System.Drawing.Size(168, 24);
            this.dtDriverEndDate.TabIndex = 98;
            this.dtDriverEndDate.ValueChanged += new System.EventHandler(this.dtDriverStartDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(196, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "To Date";
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
            this.button1.Location = new System.Drawing.Point(403, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 96;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtReciptNO
            // 
            this.txtReciptNO.Location = new System.Drawing.Point(457, 33);
            this.txtReciptNO.Name = "txtReciptNO";
            this.txtReciptNO.Size = new System.Drawing.Size(241, 20);
            this.txtReciptNO.TabIndex = 89;
            this.txtReciptNO.TextChanged += new System.EventHandler(this.txtReciptNO_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(454, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 88;
            this.label3.Text = "Receipt No";
            // 
            // dtDriverStartDate
            // 
            this.dtDriverStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDriverStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDriverStartDate.Location = new System.Drawing.Point(21, 30);
            this.dtDriverStartDate.Name = "dtDriverStartDate";
            this.dtDriverStartDate.Size = new System.Drawing.Size(168, 24);
            this.dtDriverStartDate.TabIndex = 87;
            this.dtDriverStartDate.ValueChanged += new System.EventHandler(this.dtDriverStartDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "From Date";
            // 
            // dtGrdvOrderDetails
            // 
            this.dtGrdvOrderDetails.AllowUserToAddRows = false;
            this.dtGrdvOrderDetails.AllowUserToDeleteRows = false;
            this.dtGrdvOrderDetails.AllowUserToResizeColumns = false;
            this.dtGrdvOrderDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
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
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGrdvOrderDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtGrdvOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrdvOrderDetails.Location = new System.Drawing.Point(0, 0);
            this.dtGrdvOrderDetails.Name = "dtGrdvOrderDetails";
            this.dtGrdvOrderDetails.ReadOnly = true;
            this.dtGrdvOrderDetails.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGrdvOrderDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtGrdvOrderDetails.RowTemplate.Height = 44;
            this.dtGrdvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdvOrderDetails.Size = new System.Drawing.Size(1260, 478);
            this.dtGrdvOrderDetails.TabIndex = 2;
            this.dtGrdvOrderDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdvOrderDetails_CellClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PendingKitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 547);
            this.Controls.Add(this.splitContainer2);
            this.Name = "PendingKitchen";
            this.Text = "PendingDelivery";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PendingDelivery_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvOrderDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtReciptNO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDriverStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtGrdvOrderDetails;
        private System.Windows.Forms.DateTimePicker dtDriverEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnReset;
    }
}