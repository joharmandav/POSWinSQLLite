namespace supershop
{
    partial class UOMConversion
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
            this.label1 = new System.Windows.Forms.Label();
            this.drpfromUOM = new System.Windows.Forms.ComboBox();
            this.ComTOUOM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConversion = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFromUom = new System.Windows.Forms.Label();
            this.lblToUOM = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From UOM";
            // 
            // drpfromUOM
            // 
            this.drpfromUOM.FormattingEnabled = true;
            this.drpfromUOM.Location = new System.Drawing.Point(28, 98);
            this.drpfromUOM.Name = "drpfromUOM";
            this.drpfromUOM.Size = new System.Drawing.Size(165, 21);
            this.drpfromUOM.TabIndex = 1;
            this.drpfromUOM.SelectedIndexChanged += new System.EventHandler(this.drpfromUOM_SelectedIndexChanged);
            // 
            // ComTOUOM
            // 
            this.ComTOUOM.FormattingEnabled = true;
            this.ComTOUOM.Location = new System.Drawing.Point(235, 98);
            this.ComTOUOM.Name = "ComTOUOM";
            this.ComTOUOM.Size = new System.Drawing.Size(165, 21);
            this.ComTOUOM.TabIndex = 3;
            this.ComTOUOM.SelectedIndexChanged += new System.EventHandler(this.ComTOUOM_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TO UOM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Conversion";
            // 
            // txtConversion
            // 
            this.txtConversion.Location = new System.Drawing.Point(432, 99);
            this.txtConversion.Name = "txtConversion";
            this.txtConversion.Size = new System.Drawing.Size(165, 20);
            this.txtConversion.TabIndex = 5;
            this.txtConversion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConversion_KeyPress);
            // 
            // txtRemark
            // 
            this.txtRemark.AcceptsReturn = true;
            this.txtRemark.AcceptsTab = true;
            this.txtRemark.Location = new System.Drawing.Point(28, 153);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(569, 51);
            this.txtRemark.TabIndex = 7;
            this.txtRemark.Enter += new System.EventHandler(this.txtRemark_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Remark";
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
            this.btnReset.Location = new System.Drawing.Point(500, 236);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 28);
            this.btnReset.TabIndex = 103;
            this.btnReset.Text = "Exit";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSave.ForeColor = System.Drawing.Color.YellowGreen;
            this.btnSave.Location = new System.Drawing.Point(170, 234);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 28);
            this.btnSave.TabIndex = 102;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFromUom
            // 
            this.lblFromUom.AutoSize = true;
            this.lblFromUom.Location = new System.Drawing.Point(115, 81);
            this.lblFromUom.Name = "lblFromUom";
            this.lblFromUom.Size = new System.Drawing.Size(10, 13);
            this.lblFromUom.TabIndex = 104;
            this.lblFromUom.Text = "-";
            this.lblFromUom.Visible = false;
            // 
            // lblToUOM
            // 
            this.lblToUOM.AutoSize = true;
            this.lblToUOM.Location = new System.Drawing.Point(314, 82);
            this.lblToUOM.Name = "lblToUOM";
            this.lblToUOM.Size = new System.Drawing.Size(10, 13);
            this.lblToUOM.TabIndex = 105;
            this.lblToUOM.Text = "-";
            this.lblToUOM.Visible = false;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(25, 53);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(10, 13);
            this.lblMode.TabIndex = 106;
            this.lblMode.Text = "-";
            this.lblMode.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 16);
            this.label5.TabIndex = 218;
            this.label5.Text = "**NOTE : Please Varify Your Convertion before Save.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(68, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(388, 16);
            this.label6.TabIndex = 219;
            this.label6.Text = "Once Conversion Has been Save Can not be Change or Update";
            // 
            // UOMConversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 295);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblToUOM);
            this.Controls.Add(this.lblFromUom);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConversion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComTOUOM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.drpfromUOM);
            this.Controls.Add(this.label1);
            this.Name = "UOMConversion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uom Conversion";
            this.Load += new System.EventHandler(this.UOMConversion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpfromUOM;
        private System.Windows.Forms.ComboBox ComTOUOM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConversion;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFromUom;
        private System.Windows.Forms.Label lblToUOM;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}