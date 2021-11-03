namespace supershop.Expenses
{
    partial class ViewDoc
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
            this.lblfilename = new System.Windows.Forms.Label();
            this.picSupportfile = new System.Windows.Forms.PictureBox();
            this.lblFileExtension = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.picSupportfile)).BeginInit();
            this.SuspendLayout();
            // 
            // lblfilename
            // 
            this.lblfilename.AutoSize = true;
            this.lblfilename.Location = new System.Drawing.Point(12, 308);
            this.lblfilename.Name = "lblfilename";
            this.lblfilename.Size = new System.Drawing.Size(13, 13);
            this.lblfilename.TabIndex = 2;
            this.lblfilename.Text = "--";
            this.lblfilename.Visible = false;
            // 
            // picSupportfile
            // 
            this.picSupportfile.Location = new System.Drawing.Point(426, 20);
            this.picSupportfile.Name = "picSupportfile";
            this.picSupportfile.Size = new System.Drawing.Size(367, 273);
            this.picSupportfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSupportfile.TabIndex = 4;
            this.picSupportfile.TabStop = false;
            // 
            // lblFileExtension
            // 
            this.lblFileExtension.AutoSize = true;
            this.lblFileExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.25F);
            this.lblFileExtension.Location = new System.Drawing.Point(16, 344);
            this.lblFileExtension.Name = "lblFileExtension";
            this.lblFileExtension.Size = new System.Drawing.Size(6, 2);
            this.lblFileExtension.TabIndex = 99;
            this.lblFileExtension.Text = "----";
            this.lblFileExtension.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 20);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(391, 273);
            this.webBrowser1.TabIndex = 100;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // ViewDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 661);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lblFileExtension);
            this.Controls.Add(this.picSupportfile);
            this.Controls.Add(this.lblfilename);
            this.MinimizeBox = false;
            this.Name = "ViewDoc";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Support Document";
            this.Load += new System.EventHandler(this.ViewDoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSupportfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblfilename;
        private System.Windows.Forms.PictureBox picSupportfile;
        private System.Windows.Forms.Label lblFileExtension;
        private System.Windows.Forms.WebBrowser webBrowser1;

    }
}