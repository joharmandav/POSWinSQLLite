namespace supershop.BarCode
{
    partial class BarcodeCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeCreator));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.nudPages = new System.Windows.Forms.NumericUpDown();
            this.chbShowCheckSum = new System.Windows.Forms.CheckBox();
            this.chbShowText = new System.Windows.Forms.CheckBox();
            this.btnforecolor = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
            this.PrintPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.EaN13Barcode1 = new MyBarcode.EAN13Barcode();
            this.label8 = new System.Windows.Forms.Label();
            this.cmboProductCode = new System.Windows.Forms.ComboBox();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkAdvanceBC = new System.Windows.Forms.LinkLabel();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPages)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnPrint);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btnPreview);
            this.GroupBox1.Controls.Add(this.nudPages);
            this.GroupBox1.Location = new System.Drawing.Point(226, 100);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(280, 107);
            this.GroupBox1.TabIndex = 21;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Priniting";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(141, 66);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(129, 32);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(48, 33);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(92, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Number of Pages:";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(12, 66);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(120, 32);
            this.btnPreview.TabIndex = 9;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // nudPages
            // 
            this.nudPages.Location = new System.Drawing.Point(148, 31);
            this.nudPages.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPages.Name = "nudPages";
            this.nudPages.Size = new System.Drawing.Size(47, 20);
            this.nudPages.TabIndex = 11;
            this.nudPages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chbShowCheckSum
            // 
            this.chbShowCheckSum.AutoSize = true;
            this.chbShowCheckSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.chbShowCheckSum.Location = new System.Drawing.Point(137, 257);
            this.chbShowCheckSum.Name = "chbShowCheckSum";
            this.chbShowCheckSum.Size = new System.Drawing.Size(109, 17);
            this.chbShowCheckSum.TabIndex = 20;
            this.chbShowCheckSum.Text = "Show Check Sum";
            this.chbShowCheckSum.UseVisualStyleBackColor = true;
            this.chbShowCheckSum.CheckedChanged += new System.EventHandler(this.chbShowCheckSum_CheckedChanged);
            // 
            // chbShowText
            // 
            this.chbShowText.AutoSize = true;
            this.chbShowText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.chbShowText.Location = new System.Drawing.Point(16, 257);
            this.chbShowText.Name = "chbShowText";
            this.chbShowText.Size = new System.Drawing.Size(117, 17);
            this.chbShowText.TabIndex = 19;
            this.chbShowText.Text = "Show Barcode Text";
            this.chbShowText.UseVisualStyleBackColor = true;
            this.chbShowText.CheckedChanged += new System.EventHandler(this.chbShowText_CheckedChanged);
            // 
            // btnforecolor
            // 
            this.btnforecolor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnforecolor.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnforecolor.FlatAppearance.BorderSize = 0;
            this.btnforecolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnforecolor.ForeColor = System.Drawing.Color.Black;
            this.btnforecolor.Location = new System.Drawing.Point(367, 47);
            this.btnforecolor.Name = "btnforecolor";
            this.btnforecolor.Size = new System.Drawing.Size(139, 47);
            this.btnforecolor.TabIndex = 18;
            this.btnforecolor.Text = "Fore Color";
            this.btnforecolor.UseVisualStyleBackColor = false;
            this.btnforecolor.Click += new System.EventHandler(this.btnforecolor_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(226, 47);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(132, 47);
            this.btnColor.TabIndex = 17;
            this.btnColor.Text = "Back Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(16, 280);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(200, 23);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Create";
            this.toolTipInfo.SetToolTip(this.btnCreate, "Press to Create Barcode ");
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // PrintDialog1
            // 
            this.PrintDialog1.AllowCurrentPage = true;
            this.PrintDialog1.UseEXDialog = true;
            // 
            // PrintPreviewDialog1
            // 
            this.PrintPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.PrintPreviewDialog1.Enabled = true;
            this.PrintPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("PrintPreviewDialog1.Icon")));
            this.PrintPreviewDialog1.Name = "PrintPreviewDialog1";
            this.PrintPreviewDialog1.Visible = false;
            // 
            // PrintDocument1
            // 
            this.PrintDocument1.DocumentName = "BacodePrint";
            this.PrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // EaN13Barcode1
            // 
            this.EaN13Barcode1.BackColor = System.Drawing.Color.White;
            this.EaN13Barcode1.BarHeight = 0D;
            this.EaN13Barcode1.BarWidth = 0.33D;
            this.EaN13Barcode1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EaN13Barcode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EaN13Barcode1.ForeColor = System.Drawing.Color.Black;
            this.EaN13Barcode1.Location = new System.Drawing.Point(16, 47);
            this.EaN13Barcode1.Margin = new System.Windows.Forms.Padding(6);
            this.EaN13Barcode1.Name = "EaN13Barcode1";
            this.EaN13Barcode1.ShowBarcodeText = false;
            this.EaN13Barcode1.ShowCheckSum = false;
            this.EaN13Barcode1.Size = new System.Drawing.Size(200, 160);
            this.EaN13Barcode1.TabIndex = 22;
            this.EaN13Barcode1.Value = "000000000000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Select Product from list";
            // 
            // cmboProductCode
            // 
            this.cmboProductCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmboProductCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmboProductCode.FormattingEnabled = true;
            this.cmboProductCode.Location = new System.Drawing.Point(16, 230);
            this.cmboProductCode.Name = "cmboProductCode";
            this.cmboProductCode.Size = new System.Drawing.Size(200, 21);
            this.cmboProductCode.TabIndex = 36;
            this.toolTipInfo.SetToolTip(this.cmboProductCode, "Item code must be 12 digit");
            // 
            // toolTipInfo
            // 
            this.toolTipInfo.AutomaticDelay = 800;
            this.toolTipInfo.AutoPopDelay = 80000;
            this.toolTipInfo.BackColor = System.Drawing.Color.OliveDrab;
            this.toolTipInfo.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolTipInfo.InitialDelay = 1;
            this.toolTipInfo.ReshowDelay = 1;
            this.toolTipInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.label2.Location = new System.Drawing.Point(33, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "Item code must be 12 digit in EAN_13 ";
            this.toolTipInfo.SetToolTip(this.label2, "Item code must be 12 digit in EAN_13 ");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(206, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "EAN-13 Bar-code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(499, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "---------------------------------------------------------------------------------" +
                "--------------------------------------------------------------------------------" +
                "---";
            // 
            // lnkAdvanceBC
            // 
            this.lnkAdvanceBC.AutoSize = true;
            this.lnkAdvanceBC.Location = new System.Drawing.Point(413, 290);
            this.lnkAdvanceBC.Name = "lnkAdvanceBC";
            this.lnkAdvanceBC.Size = new System.Drawing.Size(93, 13);
            this.lnkAdvanceBC.TabIndex = 41;
            this.lnkAdvanceBC.TabStop = true;
            this.lnkAdvanceBC.Text = "Advance Barcode";
            this.lnkAdvanceBC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdvanceBC_LinkClicked);
            // 
            // BarcodeCreator
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 325);
            this.Controls.Add(this.lnkAdvanceBC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmboProductCode);
            this.Controls.Add(this.EaN13Barcode1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.chbShowCheckSum);
            this.Controls.Add(this.chbShowText);
            this.Controls.Add(this.btnforecolor);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnCreate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarcodeCreator";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Creator";
            this.Load += new System.EventHandler(this.BarcodeCreator_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnPreview;
        internal System.Windows.Forms.NumericUpDown nudPages;
        internal System.Windows.Forms.CheckBox chbShowCheckSum;
        internal System.Windows.Forms.CheckBox chbShowText;
        internal System.Windows.Forms.Button btnforecolor;
        internal System.Windows.Forms.Button btnColor;
        internal System.Windows.Forms.Button btnCreate;
        internal System.Windows.Forms.PrintDialog PrintDialog1;
        internal System.Windows.Forms.ColorDialog ColorDialog1;
        internal System.Windows.Forms.PrintPreviewDialog PrintPreviewDialog1;
        internal System.Drawing.Printing.PrintDocument PrintDocument1;
        internal MyBarcode.EAN13Barcode EaN13Barcode1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmboProductCode;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lnkAdvanceBC;
    }
}

