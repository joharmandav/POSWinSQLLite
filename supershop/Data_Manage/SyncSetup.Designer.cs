namespace supershop
{
    partial class SyncSetup
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDays = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checksaleSync = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time Intervel in Munute";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(30, 61);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownDays
            // 
            this.numericUpDownDays.Location = new System.Drawing.Point(215, 61);
            this.numericUpDownDays.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDownDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDays.Name = "numericUpDownDays";
            this.numericUpDownDays.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDays.TabIndex = 5;
            this.numericUpDownDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Days Of Syncronize";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.Yellow;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(97, 138);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(153, 39);
            this.btnPrint.TabIndex = 181;
            this.btnPrint.Text = "Save";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(436, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 39);
            this.button1.TabIndex = 182;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // checksaleSync
            // 
            this.checksaleSync.AutoSize = true;
            this.checksaleSync.Location = new System.Drawing.Point(399, 61);
            this.checksaleSync.Name = "checksaleSync";
            this.checksaleSync.Size = new System.Drawing.Size(98, 17);
            this.checksaleSync.TabIndex = 183;
            this.checksaleSync.Text = "Only Sale Sync";
            this.checksaleSync.UseVisualStyleBackColor = true;
            // 
            // SyncSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(575, 224);
            this.Controls.Add(this.checksaleSync);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.numericUpDownDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SyncSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sync Setup";
            this.Load += new System.EventHandler(this.SyncSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDownDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checksaleSync;
    }
}