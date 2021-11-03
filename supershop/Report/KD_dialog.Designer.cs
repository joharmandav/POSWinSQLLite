namespace supershop.Report
{
    partial class KD_dialog
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
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUOM = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblsaleQty = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteOrder.Location = new System.Drawing.Point(12, 107);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(138, 41);
            this.btnCompleteOrder.TabIndex = 0;
            this.btnCompleteOrder.Text = "Prepared Item ";
            this.toolTip1.SetToolTip(this.btnCompleteOrder, "Action: \r\nClick To complete the order.");
            this.btnCompleteOrder.UseVisualStyleBackColor = true;
            this.btnCompleteOrder.Click += new System.EventHandler(this.btnCompleteOrder_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(100, 163);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(140, 41);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print Receipt";
            this.toolTip1.SetToolTip(this.btnPrint, "Print Receipt\r\nPrint Token.");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order #";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblOrder.Location = new System.Drawing.Point(97, 9);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(12, 16);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = "-";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 39000;
            this.toolTip1.BackColor = System.Drawing.Color.OliveDrab;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 1;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(196, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 41);
            this.button1.TabIndex = 10;
            this.button1.Text = "Prepared Full Order";
            this.toolTip1.SetToolTip(this.button1, "Action: \r\nClick To complete the order.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblItemCode.Location = new System.Drawing.Point(97, 30);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(12, 16);
            this.lblItemCode.TabIndex = 5;
            this.lblItemCode.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.Location = new System.Drawing.Point(33, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item  :-";
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblUOM.Location = new System.Drawing.Point(97, 51);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(12, 16);
            this.lblUOM.TabIndex = 7;
            this.lblUOM.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.Location = new System.Drawing.Point(33, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "UOM  :-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(77, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = " Wait 10 s for Refresh Display ";
            // 
            // lblsaleQty
            // 
            this.lblsaleQty.AutoSize = true;
            this.lblsaleQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblsaleQty.Location = new System.Drawing.Point(97, 75);
            this.lblsaleQty.Name = "lblsaleQty";
            this.lblsaleQty.Size = new System.Drawing.Size(12, 16);
            this.lblsaleQty.TabIndex = 12;
            this.lblsaleQty.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label6.Location = new System.Drawing.Point(33, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Qty  :-";
            // 
            // KD_dialog
            // 
            this.AcceptButton = this.btnCompleteOrder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 260);
            this.Controls.Add(this.lblsaleQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblUOM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblItemCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCompleteOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KD_dialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog";
            this.Load += new System.EventHandler(this.KD_dialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompleteOrder;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblsaleQty;
        private System.Windows.Forms.Label label6;
    }
}