namespace supershop
{
    partial class OrderWayList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtGrdvorderwayDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvorderwayDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGrdvorderwayDetails
            // 
            this.dtGrdvorderwayDetails.AllowUserToAddRows = false;
            this.dtGrdvorderwayDetails.AllowUserToDeleteRows = false;
            this.dtGrdvorderwayDetails.AllowUserToResizeColumns = false;
            this.dtGrdvorderwayDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtGrdvorderwayDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtGrdvorderwayDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrdvorderwayDetails.BackgroundColor = System.Drawing.Color.White;
            this.dtGrdvorderwayDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrdvorderwayDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtGrdvorderwayDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGrdvorderwayDetails.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtGrdvorderwayDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrdvorderwayDetails.Location = new System.Drawing.Point(0, 0);
            this.dtGrdvorderwayDetails.Name = "dtGrdvorderwayDetails";
            this.dtGrdvorderwayDetails.ReadOnly = true;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dtGrdvorderwayDetails.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dtGrdvorderwayDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdvorderwayDetails.Size = new System.Drawing.Size(912, 283);
            this.dtGrdvorderwayDetails.TabIndex = 3;
            this.dtGrdvorderwayDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdvorderwayDetails_CellContentClick);
            // 
            // OrderWayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 283);
            this.Controls.Add(this.dtGrdvorderwayDetails);
            this.Name = "OrderWayList";
            this.Text = "Order Way List";
            this.Load += new System.EventHandler(this.OrderWayList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdvorderwayDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGrdvorderwayDetails;
    }
}