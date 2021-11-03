namespace supershop.SalesRagister
{
    partial class OrderWay_Transection
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
            this.comboSalesMan = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPEnding = new System.Windows.Forms.TextBox();
            this.txtPaidCommision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReffrance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bntSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboSalesMan
            // 
            this.comboSalesMan.FormattingEnabled = true;
            this.comboSalesMan.Items.AddRange(new object[] {
            "Walk In",
            "Salesman name",
            "Foodiz"});
            this.comboSalesMan.Location = new System.Drawing.Point(217, 50);
            this.comboSalesMan.Name = "comboSalesMan";
            this.comboSalesMan.Size = new System.Drawing.Size(226, 21);
            this.comboSalesMan.TabIndex = 170;
            this.comboSalesMan.SelectedIndexChanged += new System.EventHandler(this.comboSalesMan_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Trebuchet MS", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(71, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 18);
            this.label16.TabIndex = 169;
            this.label16.Text = "Order way :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 171;
            this.label1.Text = "Pending Commission :";
            // 
            // txtPEnding
            // 
            this.txtPEnding.Enabled = false;
            this.txtPEnding.Location = new System.Drawing.Point(218, 91);
            this.txtPEnding.Name = "txtPEnding";
            this.txtPEnding.Size = new System.Drawing.Size(226, 20);
            this.txtPEnding.TabIndex = 172;
            // 
            // txtPaidCommision
            // 
            this.txtPaidCommision.Location = new System.Drawing.Point(217, 124);
            this.txtPaidCommision.Name = "txtPaidCommision";
            this.txtPaidCommision.Size = new System.Drawing.Size(226, 20);
            this.txtPaidCommision.TabIndex = 174;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 173;
            this.label2.Text = "Paid Commission :";
            // 
            // txtReffrance
            // 
            this.txtReffrance.Location = new System.Drawing.Point(217, 155);
            this.txtReffrance.Name = "txtReffrance";
            this.txtReffrance.Size = new System.Drawing.Size(226, 20);
            this.txtReffrance.TabIndex = 176;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 175;
            this.label3.Text = "Paid Reffrance";
            // 
            // bntSave
            // 
            this.bntSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bntSave.FlatAppearance.BorderSize = 0;
            this.bntSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bntSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bntSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.bntSave.ForeColor = System.Drawing.Color.YellowGreen;
            this.bntSave.Location = new System.Drawing.Point(132, 202);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(248, 29);
            this.bntSave.TabIndex = 177;
            this.bntSave.Text = "Paid Commission";
            this.bntSave.UseVisualStyleBackColor = false;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // OrderWay_Transection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 442);
            this.Controls.Add(this.bntSave);
            this.Controls.Add(this.txtReffrance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPaidCommision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPEnding);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboSalesMan);
            this.Controls.Add(this.label16);
            this.Name = "OrderWay_Transection";
            this.Text = "Order Way Transection";
            this.Load += new System.EventHandler(this.OrderWay_Transection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSalesMan;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPEnding;
        private System.Windows.Forms.TextBox txtPaidCommision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReffrance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bntSave;
    }
}