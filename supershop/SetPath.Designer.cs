namespace supershop
{
    partial class SetPath
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
            this.btnterminalImage = new System.Windows.Forms.Button();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnTerminalDatabase = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnterminalImage
            // 
            this.btnterminalImage.Location = new System.Drawing.Point(199, 135);
            this.btnterminalImage.Name = "btnterminalImage";
            this.btnterminalImage.Size = new System.Drawing.Size(74, 23);
            this.btnterminalImage.TabIndex = 63;
            this.btnterminalImage.Text = "Browse";
            this.btnterminalImage.UseVisualStyleBackColor = true;
            this.btnterminalImage.Click += new System.EventHandler(this.btnterminalImage_Click);
            // 
            // txtImage
            // 
            this.txtImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtImage.Location = new System.Drawing.Point(14, 135);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(179, 24);
            this.txtImage.TabIndex = 62;
            // 
            // btnTerminalDatabase
            // 
            this.btnTerminalDatabase.Location = new System.Drawing.Point(199, 88);
            this.btnTerminalDatabase.Name = "btnTerminalDatabase";
            this.btnTerminalDatabase.Size = new System.Drawing.Size(74, 23);
            this.btnTerminalDatabase.TabIndex = 61;
            this.btnTerminalDatabase.Text = "Browse";
            this.btnTerminalDatabase.UseVisualStyleBackColor = true;
            this.btnTerminalDatabase.Click += new System.EventHandler(this.btnTerminalDatabase_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label29.Location = new System.Drawing.Point(11, 115);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 17);
            this.label29.TabIndex = 60;
            this.label29.Text = "Image Path:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDatabase.Location = new System.Drawing.Point(14, 88);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(179, 24);
            this.txtDatabase.TabIndex = 58;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label28.Location = new System.Drawing.Point(11, 68);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(106, 17);
            this.label28.TabIndex = 59;
            this.label28.Text = "Database Path:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 64;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SetPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(323, 317);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnterminalImage);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.btnTerminalDatabase);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label28);
            this.Name = "SetPath";
            this.Text = "Setting Of Database Path";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnterminalImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnTerminalDatabase;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}