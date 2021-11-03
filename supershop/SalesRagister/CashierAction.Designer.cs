namespace supershop
{
    partial class CashierAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierAction));
            this.lblorderNO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnColse = new System.Windows.Forms.Button();
            this.btnBookingDelivered = new System.Windows.Forms.Button();
            this.btnBookingEdit = new System.Windows.Forms.Button();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCashprint = new System.Windows.Forms.Button();
            this.btnCOD = new System.Windows.Forms.Button();
            this.btnSalesCredit = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnDeliverd = new System.Windows.Forms.Button();
            this.btnDriverAssign = new System.Windows.Forms.Button();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnBookingDelivered);
            this.splitContainer1.Panel2.Controls.Add(this.btnBookingEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteInvoice);
            this.splitContainer1.Panel2.Controls.Add(this.btnedit);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnCashprint);
            this.splitContainer1.Panel2.Controls.Add(this.btnCOD);
            this.splitContainer1.Panel2.Controls.Add(this.btnSalesCredit);
            this.splitContainer1.Panel2.Controls.Add(this.btnReturn);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeliverd);
            this.splitContainer1.Panel2.Controls.Add(this.btnDriverAssign);
            this.splitContainer1.Size = new System.Drawing.Size(325, 343);
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
            this.btnColse.Location = new System.Drawing.Point(297, -1);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(28, 28);
            this.btnColse.TabIndex = 96;
            this.btnColse.Text = "X";
            this.btnColse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColse.UseVisualStyleBackColor = false;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // btnBookingDelivered
            // 
            this.btnBookingDelivered.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBookingDelivered.FlatAppearance.BorderSize = 0;
            this.btnBookingDelivered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingDelivered.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnBookingDelivered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBookingDelivered.Location = new System.Drawing.Point(167, 72);
            this.btnBookingDelivered.Name = "btnBookingDelivered";
            this.btnBookingDelivered.Size = new System.Drawing.Size(132, 39);
            this.btnBookingDelivered.TabIndex = 182;
            this.btnBookingDelivered.Text = "Delivered";
            this.btnBookingDelivered.UseVisualStyleBackColor = false;
            this.btnBookingDelivered.Visible = false;
            this.btnBookingDelivered.Click += new System.EventHandler(this.btnBookingDelivered_Click);
            // 
            // btnBookingEdit
            // 
            this.btnBookingEdit.BackColor = System.Drawing.Color.Blue;
            this.btnBookingEdit.FlatAppearance.BorderSize = 0;
            this.btnBookingEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingEdit.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnBookingEdit.ForeColor = System.Drawing.Color.Yellow;
            this.btnBookingEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookingEdit.Location = new System.Drawing.Point(18, 182);
            this.btnBookingEdit.Name = "btnBookingEdit";
            this.btnBookingEdit.Size = new System.Drawing.Size(123, 39);
            this.btnBookingEdit.TabIndex = 181;
            this.btnBookingEdit.Text = "Edit ";
            this.btnBookingEdit.UseVisualStyleBackColor = false;
            this.btnBookingEdit.Visible = false;
            this.btnBookingEdit.Click += new System.EventHandler(this.btnBookingEdit_Click);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteInvoice.FlatAppearance.BorderSize = 0;
            this.btnDeleteInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteInvoice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteInvoice.Location = new System.Drawing.Point(65, 247);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(174, 39);
            this.btnDeleteInvoice.TabIndex = 180;
            this.btnDeleteInvoice.Text = "Delete This Invoice";
            this.btnDeleteInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteInvoice.UseVisualStyleBackColor = false;
            this.btnDeleteInvoice.Visible = false;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.Blue;
            this.btnedit.FlatAppearance.BorderSize = 0;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnedit.ForeColor = System.Drawing.Color.Yellow;
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.Location = new System.Drawing.Point(18, 182);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(123, 39);
            this.btnedit.TabIndex = 179;
            this.btnedit.Text = "Edit ";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.Blue;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(167, 182);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(132, 39);
            this.btnPrint.TabIndex = 178;
            this.btnPrint.Text = "Print Invoice";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCashprint
            // 
            this.btnCashprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCashprint.FlatAppearance.BorderSize = 0;
            this.btnCashprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashprint.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnCashprint.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnCashprint.Image = ((System.Drawing.Image)(resources.GetObject("btnCashprint.Image")));
            this.btnCashprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCashprint.Location = new System.Drawing.Point(18, 128);
            this.btnCashprint.Name = "btnCashprint";
            this.btnCashprint.Size = new System.Drawing.Size(123, 39);
            this.btnCashprint.TabIndex = 177;
            this.btnCashprint.Text = "Cash    ";
            this.btnCashprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCashprint.UseVisualStyleBackColor = false;
            this.btnCashprint.Click += new System.EventHandler(this.btnCashprint_Click);
            // 
            // btnCOD
            // 
            this.btnCOD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCOD.FlatAppearance.BorderSize = 0;
            this.btnCOD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCOD.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnCOD.ForeColor = System.Drawing.Color.GreenYellow;
            this.btnCOD.Image = ((System.Drawing.Image)(resources.GetObject("btnCOD.Image")));
            this.btnCOD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCOD.Location = new System.Drawing.Point(18, 72);
            this.btnCOD.Name = "btnCOD";
            this.btnCOD.Size = new System.Drawing.Size(123, 39);
            this.btnCOD.TabIndex = 176;
            this.btnCOD.Text = "COD    ";
            this.btnCOD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCOD.UseVisualStyleBackColor = false;
            this.btnCOD.Click += new System.EventHandler(this.btnCOD_Click);
            // 
            // btnSalesCredit
            // 
            this.btnSalesCredit.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSalesCredit.FlatAppearance.BorderSize = 0;
            this.btnSalesCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesCredit.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnSalesCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSalesCredit.Image = ((System.Drawing.Image)(resources.GetObject("btnSalesCredit.Image")));
            this.btnSalesCredit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesCredit.Location = new System.Drawing.Point(15, 15);
            this.btnSalesCredit.Name = "btnSalesCredit";
            this.btnSalesCredit.Size = new System.Drawing.Size(126, 39);
            this.btnSalesCredit.TabIndex = 175;
            this.btnSalesCredit.Text = "Payment";
            this.btnSalesCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalesCredit.UseVisualStyleBackColor = false;
            this.btnSalesCredit.Click += new System.EventHandler(this.btnSalesCredit_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.OrangeRed;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReturn.Location = new System.Drawing.Point(167, 127);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(132, 39);
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
            this.btnDeliverd.Location = new System.Drawing.Point(167, 72);
            this.btnDeliverd.Name = "btnDeliverd";
            this.btnDeliverd.Size = new System.Drawing.Size(132, 39);
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
            this.btnDriverAssign.Location = new System.Drawing.Point(167, 15);
            this.btnDriverAssign.Name = "btnDriverAssign";
            this.btnDriverAssign.Size = new System.Drawing.Size(132, 39);
            this.btnDriverAssign.TabIndex = 173;
            this.btnDriverAssign.Text = "Driver Assign";
            this.btnDriverAssign.UseVisualStyleBackColor = false;
            this.btnDriverAssign.Click += new System.EventHandler(this.btnDriverAssign_Click);
            // 
            // CashierAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(331, 346);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashierAction";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier Action";
            this.Load += new System.EventHandler(this.CashierAction_Load);
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
        private System.Windows.Forms.Button btnSalesCredit;
        private System.Windows.Forms.Button btnCOD;
        private System.Windows.Forms.Button btnCashprint;
        private System.Windows.Forms.Button btnColse;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Button btnBookingDelivered;
        private System.Windows.Forms.Button btnBookingEdit;
    }
}