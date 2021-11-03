namespace supershop.Items
{
    partial class Add_Category
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
            this.lblID = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtcolor = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblFileExtension = new System.Windows.Forms.Label();
            this.picItemimage = new System.Windows.Forms.PictureBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCategoryArabic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lnkSupplier = new System.Windows.Forms.LinkLabel();
            this.lnkCategory = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemimage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblID.Location = new System.Drawing.Point(39, 31);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(8, 12);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "-";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtcolor);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.lblImage);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.lblFileExtension);
            this.splitContainer1.Panel1.Controls.Add(this.picItemimage);
            this.splitContainer1.Panel1.Controls.Add(this.btnImage);
            this.splitContainer1.Panel1.Controls.Add(this.txtImage);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtCategoryArabic);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblID);
            this.splitContainer1.Panel1.Controls.Add(this.txtCategoryName);
            this.splitContainer1.Panel1.Controls.Add(this.lblMsg);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel2.Controls.Add(this.lnkSupplier);
            this.splitContainer1.Panel2.Controls.Add(this.lnkCategory);
            this.splitContainer1.Size = new System.Drawing.Size(489, 394);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 17;
            // 
            // txtcolor
            // 
            this.txtcolor.AutoSize = true;
            this.txtcolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcolor.Location = new System.Drawing.Point(134, 197);
            this.txtcolor.Name = "txtcolor";
            this.txtcolor.Size = new System.Drawing.Size(89, 20);
            this.txtcolor.TabIndex = 105;
            this.txtcolor.Text = "FFFFFFFF";
            this.txtcolor.TextChanged += new System.EventHandler(this.txtcolor_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 104;
            this.button1.Text = "Browse Color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblImage.ForeColor = System.Drawing.Color.Red;
            this.lblImage.Location = new System.Drawing.Point(40, 239);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(24, 16);
            this.lblImage.TabIndex = 101;
            this.lblImage.Text = "----";
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
            this.btnReset.Location = new System.Drawing.Point(258, 267);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 28);
            this.btnReset.TabIndex = 100;
            this.btnReset.Text = "Exit";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblFileExtension
            // 
            this.lblFileExtension.AutoSize = true;
            this.lblFileExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F);
            this.lblFileExtension.Location = new System.Drawing.Point(326, 163);
            this.lblFileExtension.Name = "lblFileExtension";
            this.lblFileExtension.Size = new System.Drawing.Size(32, 7);
            this.lblFileExtension.TabIndex = 99;
            this.lblFileExtension.Text = "item.png";
            // 
            // picItemimage
            // 
            this.picItemimage.Location = new System.Drawing.Point(258, 319);
            this.picItemimage.Name = "picItemimage";
            this.picItemimage.Size = new System.Drawing.Size(100, 50);
            this.picItemimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picItemimage.TabIndex = 76;
            this.picItemimage.TabStop = false;
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(258, 151);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(62, 23);
            this.btnImage.TabIndex = 75;
            this.btnImage.Text = "Browse";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // txtImage
            // 
            this.txtImage.Enabled = false;
            this.txtImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtImage.Location = new System.Drawing.Point(41, 151);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(211, 24);
            this.txtImage.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Category Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Category Name in Arabic  *";
            // 
            // txtCategoryArabic
            // 
            this.txtCategoryArabic.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCategoryArabic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtCategoryArabic.Location = new System.Drawing.Point(43, 105);
            this.txtCategoryArabic.Name = "txtCategoryArabic";
            this.txtCategoryArabic.Size = new System.Drawing.Size(277, 24);
            this.txtCategoryArabic.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtCategoryArabic, "Add category Name");
            this.txtCategoryArabic.Enter += new System.EventHandler(this.txtCategoryArabic_Enter);
            this.txtCategoryArabic.LostFocus += new System.EventHandler(this.txtCategoryArabic_LostFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category Name in English  *";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtCategoryName.Location = new System.Drawing.Point(41, 62);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(277, 24);
            this.txtCategoryName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtCategoryName, "Add category Name");
            this.txtCategoryName.Leave += new System.EventHandler(this.txtCategoryName_Leave);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(40, 318);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(24, 16);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "----";
            this.lblMsg.Visible = false;
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
            this.btnSave.Location = new System.Drawing.Point(41, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(211, 27);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "I want to Submit");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lnkSupplier
            // 
            this.lnkSupplier.AutoSize = true;
            this.lnkSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lnkSupplier.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkSupplier.Location = new System.Drawing.Point(19, 44);
            this.lnkSupplier.Name = "lnkSupplier";
            this.lnkSupplier.Size = new System.Drawing.Size(65, 16);
            this.lnkSupplier.TabIndex = 6;
            this.lnkSupplier.TabStop = true;
            this.lnkSupplier.Text = "Suppliers";
            this.lnkSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupplier_LinkClicked);
            // 
            // lnkCategory
            // 
            this.lnkCategory.AutoSize = true;
            this.lnkCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lnkCategory.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkCategory.Location = new System.Drawing.Point(18, 17);
            this.lnkCategory.Name = "lnkCategory";
            this.lnkCategory.Size = new System.Drawing.Size(74, 16);
            this.lnkCategory.TabIndex = 0;
            this.lnkCategory.TabStop = true;
            this.lnkCategory.Text = "Categories";
            this.lnkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCategory_LinkClicked);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 9;
            this.toolTip1.ReshowDelay = 9;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Add_Category
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 394);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Add_Category";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Category";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picItemimage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel lnkCategory;
        private System.Windows.Forms.LinkLabel lnkSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCategoryArabic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.PictureBox picItemimage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblFileExtension;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtcolor;
    }
}