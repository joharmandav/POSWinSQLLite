namespace supershop 
{
    partial class Import_Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import_Items));
            this.dtgridviewImportPreview = new System.Windows.Forms.DataGridView();
            this.btnImportPreview = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.rbHeaderYes = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblmsg = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblwaiting = new System.Windows.Forms.Label();
            this.picItemimage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridviewImportPreview)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemimage)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgridviewImportPreview
            // 
            this.dtgridviewImportPreview.AllowUserToAddRows = false;
            this.dtgridviewImportPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgridviewImportPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridviewImportPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgridviewImportPreview.Location = new System.Drawing.Point(0, 0);
            this.dtgridviewImportPreview.Name = "dtgridviewImportPreview";
            this.dtgridviewImportPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgridviewImportPreview.Size = new System.Drawing.Size(971, 347);
            this.dtgridviewImportPreview.TabIndex = 0;
            // 
            // btnImportPreview
            // 
            this.btnImportPreview.Location = new System.Drawing.Point(254, 12);
            this.btnImportPreview.Name = "btnImportPreview";
            this.btnImportPreview.Size = new System.Drawing.Size(75, 23);
            this.btnImportPreview.TabIndex = 1;
            this.btnImportPreview.Text = "Select file";
            this.btnImportPreview.UseVisualStyleBackColor = true;
            this.btnImportPreview.Click += new System.EventHandler(this.btnImportPreview_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(372, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save to Database";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbHeaderYes
            // 
            this.rbHeaderYes.AutoSize = true;
            this.rbHeaderYes.Checked = true;
            this.rbHeaderYes.Location = new System.Drawing.Point(12, 390);
            this.rbHeaderYes.Name = "rbHeaderYes";
            this.rbHeaderYes.Size = new System.Drawing.Size(43, 17);
            this.rbHeaderYes.TabIndex = 3;
            this.rbHeaderYes.TabStop = true;
            this.rbHeaderYes.Text = "Yes";
            this.rbHeaderYes.UseVisualStyleBackColor = true;
            this.rbHeaderYes.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgridviewImportPreview);
            this.panel1.Location = new System.Drawing.Point(3, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 347);
            this.panel1.TabIndex = 4;
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblmsg.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(69, 389);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(18, 17);
            this.lblmsg.TabIndex = 5;
            this.lblmsg.Text = "--";
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblRows.ForeColor = System.Drawing.Color.Red;
            this.lblRows.Location = new System.Drawing.Point(12, 11);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(18, 17);
            this.lblRows.TabIndex = 6;
            this.lblRows.Text = "--";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(673, 17);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(68, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Data Sample";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblwaiting
            // 
            this.lblwaiting.AutoSize = true;
            this.lblwaiting.ForeColor = System.Drawing.Color.Red;
            this.lblwaiting.Location = new System.Drawing.Point(458, 395);
            this.lblwaiting.Name = "lblwaiting";
            this.lblwaiting.Size = new System.Drawing.Size(13, 13);
            this.lblwaiting.TabIndex = 8;
            this.lblwaiting.Text = "--";
            // 
            // picItemimage
            // 
            this.picItemimage.Image = ((System.Drawing.Image)(resources.GetObject("picItemimage.Image")));
            this.picItemimage.InitialImage = ((System.Drawing.Image)(resources.GetObject("picItemimage.InitialImage")));
            this.picItemimage.Location = new System.Drawing.Point(925, 12);
            this.picItemimage.Name = "picItemimage";
            this.picItemimage.Size = new System.Drawing.Size(20, 20);
            this.picItemimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picItemimage.TabIndex = 38;
            this.picItemimage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(796, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "Import  Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Import_Items
            // 
            this.AcceptButton = this.btnImportPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(980, 417);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picItemimage);
            this.Controls.Add(this.lblwaiting);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbHeaderYes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnImportPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Import_Items";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Items";
            ((System.ComponentModel.ISupportInitialize)(this.dtgridviewImportPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picItemimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgridviewImportPreview;
        private System.Windows.Forms.Button btnImportPreview;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rbHeaderYes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblwaiting;
        private System.Windows.Forms.PictureBox picItemimage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}