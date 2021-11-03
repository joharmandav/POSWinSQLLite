namespace supershop
{
    partial class invoiceAssing
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
            this.lblAppointmentNO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnColse = new System.Windows.Forms.Button();
            this.dataGridViewDriverAssign = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.MasterCODE = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDriverAssign)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAppointmentNO
            // 
            this.lblAppointmentNO.AutoSize = true;
            this.lblAppointmentNO.Location = new System.Drawing.Point(97, 8);
            this.lblAppointmentNO.Name = "lblAppointmentNO";
            this.lblAppointmentNO.Size = new System.Drawing.Size(10, 13);
            this.lblAppointmentNO.TabIndex = 8;
            this.lblAppointmentNO.Text = "-";
            this.lblAppointmentNO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Appintment No :";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(2, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.MasterCODE);
            this.splitContainer1.Panel1.Controls.Add(this.btnColse);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblAppointmentNO);
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewDriverAssign);
            this.splitContainer1.Size = new System.Drawing.Size(289, 251);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.TabIndex = 9;
            // 
            // btnColse
            // 
            this.btnColse.BackColor = System.Drawing.Color.Fuchsia;
            this.btnColse.FlatAppearance.BorderSize = 0;
            this.btnColse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnColse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnColse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColse.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColse.ForeColor = System.Drawing.SystemColors.Window;
            this.btnColse.Location = new System.Drawing.Point(240, 1);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(45, 43);
            this.btnColse.TabIndex = 25;
            this.btnColse.Text = "X";
            this.btnColse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColse.UseVisualStyleBackColor = false;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // dataGridViewDriverAssign
            // 
            this.dataGridViewDriverAssign.AllowUserToAddRows = false;
            this.dataGridViewDriverAssign.AllowUserToDeleteRows = false;
            this.dataGridViewDriverAssign.AllowUserToResizeColumns = false;
            this.dataGridViewDriverAssign.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridViewDriverAssign.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDriverAssign.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDriverAssign.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDriverAssign.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDriverAssign.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDriverAssign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDriverAssign.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDriverAssign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDriverAssign.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDriverAssign.Name = "dataGridViewDriverAssign";
            this.dataGridViewDriverAssign.ReadOnly = true;
            this.dataGridViewDriverAssign.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dataGridViewDriverAssign.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewDriverAssign.RowTemplate.Height = 44;
            this.dataGridViewDriverAssign.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDriverAssign.Size = new System.Drawing.Size(289, 200);
            this.dataGridViewDriverAssign.TabIndex = 4;
            this.dataGridViewDriverAssign.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDriverAssign_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 182;
            this.label2.Text = "JobID :";
            // 
            // MasterCODE
            // 
            this.MasterCODE.AutoSize = true;
            this.MasterCODE.ForeColor = System.Drawing.Color.Blue;
            this.MasterCODE.Location = new System.Drawing.Point(55, 27);
            this.MasterCODE.Name = "MasterCODE";
            this.MasterCODE.Size = new System.Drawing.Size(10, 13);
            this.MasterCODE.TabIndex = 183;
            this.MasterCODE.Text = "-";
            // 
            // JobEmployeeAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(293, 253);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JobEmployeeAssign";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driver Assign";
            this.Load += new System.EventHandler(this.EmployeeAssign_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDriverAssign)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAppointmentNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewDriverAssign;
        private System.Windows.Forms.Button btnColse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MasterCODE;
    }
}