namespace supershop
{
    partial class DriverAction
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
            this.lblorderNO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnColse = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnDeliverd = new System.Windows.Forms.Button();
            this.btnDriverAssign = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblorderNO
            // 
            this.lblorderNO.AutoSize = true;
            this.lblorderNO.Location = new System.Drawing.Point(74, 8);
            this.lblorderNO.Name = "lblorderNO";
            this.lblorderNO.Size = new System.Drawing.Size(10, 13);
            this.lblorderNO.TabIndex = 8;
            this.lblorderNO.Text = "-";
            this.lblorderNO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Invoice No :";
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
            this.splitContainer1.Panel1.Controls.Add(this.btnColse);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblorderNO);
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);            
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnReturn);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeliverd);
            this.splitContainer1.Panel2.Controls.Add(this.btnDriverAssign);
            this.splitContainer1.Size = new System.Drawing.Size(307, 223);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 9;
            // 
            // btnColse
            // 
            this.btnColse.BackColor = System.Drawing.Color.Fuchsia;
            this.btnColse.FlatAppearance.BorderSize = 0;
            this.btnColse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnColse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnColse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColse.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColse.ForeColor = System.Drawing.SystemColors.Window;
            this.btnColse.Location = new System.Drawing.Point(276, 0);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(28, 33);
            this.btnColse.TabIndex = 96;
            this.btnColse.Text = "X";
            this.btnColse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColse.UseVisualStyleBackColor = false;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.OrangeRed;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReturn.Location = new System.Drawing.Point(166, 92);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(107, 39);
            this.btnReturn.TabIndex = 174;
            this.btnReturn.Text = "Return";
            this.btnReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnDeliverd
            // 
            this.btnDeliverd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDeliverd.FlatAppearance.BorderSize = 0;
            this.btnDeliverd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeliverd.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnDeliverd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeliverd.Location = new System.Drawing.Point(166, 24);
            this.btnDeliverd.Name = "btnDeliverd";
            this.btnDeliverd.Size = new System.Drawing.Size(108, 39);
            this.btnDeliverd.TabIndex = 165;
            this.btnDeliverd.Text = "Delivered";
            this.btnDeliverd.UseVisualStyleBackColor = false;
            this.btnDeliverd.Click += new System.EventHandler(this.btnDeliverd_Click);
            // 
            // btnDriverAssign
            // 
            this.btnDriverAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDriverAssign.FlatAppearance.BorderSize = 0;
            this.btnDriverAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDriverAssign.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnDriverAssign.ForeColor = System.Drawing.Color.Green;
            this.btnDriverAssign.Location = new System.Drawing.Point(23, 24);
            this.btnDriverAssign.Name = "btnDriverAssign";
            this.btnDriverAssign.Size = new System.Drawing.Size(108, 39);
            this.btnDriverAssign.TabIndex = 173;
            this.btnDriverAssign.Text = "Driver Assign";
            this.btnDriverAssign.UseVisualStyleBackColor = false;
            this.btnDriverAssign.Click += new System.EventHandler(this.btnDriverAssign_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.Blue;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(23, 92);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(108, 39);
            this.btnPrint.TabIndex = 179;
            this.btnPrint.Text = "Print Invoice";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // DriverAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(314, 225);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DriverAction";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier Action";
            this.Load += new System.EventHandler(this.DriverAction_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);            
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblorderNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDriverAssign;
        private System.Windows.Forms.Button btnDeliverd;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnColse;
        private System.Windows.Forms.Button btnPrint;
    }
}