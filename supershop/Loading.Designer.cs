namespace supershop
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // picLoader
            // 
            this.picLoader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLoader.BackColor = System.Drawing.Color.Transparent;
            this.picLoader.Image = ((System.Drawing.Image)(resources.GetObject("picLoader.Image")));
            this.picLoader.Location = new System.Drawing.Point(-3, 5);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(157, 157);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLoader.TabIndex = 184;
            this.picLoader.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 31);
            this.label1.TabIndex = 185;
            this.label1.Text = "Loading...";
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(153, 215);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLoader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Loading";
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.Label label1;
    }
}