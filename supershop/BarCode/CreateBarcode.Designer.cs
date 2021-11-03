namespace supershop
{
    partial class CreateBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateBarcode));
            this.txtCountryCode = new System.Windows.Forms.TextBox();
            this.butCreateBitmap = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboScale = new System.Windows.Forms.ComboBox();
            this.txtChecksumDigit = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtManufacturerCode = new System.Windows.Forms.TextBox();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.butPrint = new System.Windows.Forms.Button();
            this.butDraw = new System.Windows.Forms.Button();
            this.rdbtnEAN13 = new System.Windows.Forms.RadioButton();
            this.rdbtnUPCA = new System.Windows.Forms.RadioButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label6 = new System.Windows.Forms.Label();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.cmboProductCode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.linkHelp = new System.Windows.Forms.LinkLabel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnlabelPrint = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.printDocLabelprint = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCountryCode
            // 
            this.txtCountryCode.Location = new System.Drawing.Point(12, 169);
            this.txtCountryCode.MaxLength = 3;
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.Size = new System.Drawing.Size(218, 20);
            this.txtCountryCode.TabIndex = 0;
            this.txtCountryCode.Text = "0";
            this.toolTipInfo.SetToolTip(this.txtCountryCode, "Please Insert Country Code: Ex: 02");
            // 
            // butCreateBitmap
            // 
            this.butCreateBitmap.Location = new System.Drawing.Point(241, 293);
            this.butCreateBitmap.Name = "butCreateBitmap";
            this.butCreateBitmap.Size = new System.Drawing.Size(100, 23);
            this.butCreateBitmap.TabIndex = 5;
            this.butCreateBitmap.Text = "Print Preview";
            this.butCreateBitmap.Click += new System.EventHandler(this.butCreateBitmap_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Scale Factor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Checksum Digit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product Code :   5 digit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Manufacturer Code : 5 digit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Country Code :";
            // 
            // cboScale
            // 
            this.cboScale.FormattingEnabled = true;
            this.cboScale.Items.AddRange(new object[] {
            "0.8",
            "0.9",
            "1.0",
            "1.1",
            "1.2",
            "1.3",
            "1.4",
            "1.5",
            "1.6",
            "1.7",
            "1.8",
            "1.9",
            "2.0"});
            this.cboScale.Location = new System.Drawing.Point(241, 169);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(100, 21);
            this.cboScale.TabIndex = 21;
            this.cboScale.Text = "1.5";
            // 
            // txtChecksumDigit
            // 
            this.txtChecksumDigit.Location = new System.Drawing.Point(12, 311);
            this.txtChecksumDigit.MaxLength = 1;
            this.txtChecksumDigit.Name = "txtChecksumDigit";
            this.txtChecksumDigit.Size = new System.Drawing.Size(218, 20);
            this.txtChecksumDigit.TabIndex = 3;
            this.toolTipInfo.SetToolTip(this.txtChecksumDigit, "The checksum digit is calculated using the Country code /product type, manufactur" +
                    "er\'s code, and the product code.");
            // 
            // txtProductCode
            // 
            this.txtProductCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductCode.Location = new System.Drawing.Point(12, 265);
            this.txtProductCode.MaxLength = 5;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(218, 20);
            this.txtProductCode.TabIndex = 2;
            this.toolTipInfo.SetToolTip(this.txtProductCode, "Please Insert 5 digit Product Code Ex: 67451 ");
            // 
            // txtManufacturerCode
            // 
            this.txtManufacturerCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtManufacturerCode.Location = new System.Drawing.Point(12, 217);
            this.txtManufacturerCode.MaxLength = 5;
            this.txtManufacturerCode.Name = "txtManufacturerCode";
            this.txtManufacturerCode.Size = new System.Drawing.Size(218, 20);
            this.txtManufacturerCode.TabIndex = 1;
            this.toolTipInfo.SetToolTip(this.txtManufacturerCode, resources.GetString("txtManufacturerCode.ToolTip"));
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(3, 61);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(406, 268);
            this.picBarcode.TabIndex = 17;
            this.picBarcode.TabStop = false;
            // 
            // butPrint
            // 
            this.butPrint.Location = new System.Drawing.Point(241, 348);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(100, 23);
            this.butPrint.TabIndex = 7;
            this.butPrint.Text = "Print Barcode";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butDraw
            // 
            this.butDraw.Location = new System.Drawing.Point(241, 233);
            this.butDraw.Name = "butDraw";
            this.butDraw.Size = new System.Drawing.Size(100, 29);
            this.butDraw.TabIndex = 4;
            this.butDraw.Text = "Draw Barcode";
            this.butDraw.Click += new System.EventHandler(this.butDraw_Click);
            // 
            // rdbtnEAN13
            // 
            this.rdbtnEAN13.AutoSize = true;
            this.rdbtnEAN13.Checked = true;
            this.rdbtnEAN13.Location = new System.Drawing.Point(15, 103);
            this.rdbtnEAN13.Name = "rdbtnEAN13";
            this.rdbtnEAN13.Size = new System.Drawing.Size(62, 17);
            this.rdbtnEAN13.TabIndex = 28;
            this.rdbtnEAN13.TabStop = true;
            this.rdbtnEAN13.Text = "EAN-13";
            this.rdbtnEAN13.UseVisualStyleBackColor = true;
            this.rdbtnEAN13.CheckedChanged += new System.EventHandler(this.rdbtnEAN13_CheckedChanged);
            // 
            // rdbtnUPCA
            // 
            this.rdbtnUPCA.AutoSize = true;
            this.rdbtnUPCA.Location = new System.Drawing.Point(112, 103);
            this.rdbtnUPCA.Name = "rdbtnUPCA";
            this.rdbtnUPCA.Size = new System.Drawing.Size(57, 17);
            this.rdbtnUPCA.TabIndex = 29;
            this.rdbtnUPCA.TabStop = true;
            this.rdbtnUPCA.Text = "UPC-A";
            this.rdbtnUPCA.UseVisualStyleBackColor = true;
            this.rdbtnUPCA.CheckedChanged += new System.EventHandler(this.rdbtnUPCA_CheckedChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "Barcode";
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Product Type :";
            this.label6.Visible = false;
            // 
            // cboProductType
            // 
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Items.AddRange(new object[] {
            "0",
            "2",
            "3",
            "4",
            "5",
            "7",
            "8"});
            this.cboProductType.Location = new System.Drawing.Point(241, 124);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(97, 21);
            this.cboProductType.TabIndex = 31;
            this.cboProductType.Text = "0";
            this.cboProductType.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "BarCode Creator";
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
            // cmboProductCode
            // 
            this.cmboProductCode.FormattingEnabled = true;
            this.cmboProductCode.Location = new System.Drawing.Point(15, 61);
            this.cmboProductCode.Name = "cmboProductCode";
            this.cmboProductCode.Size = new System.Drawing.Size(346, 21);
            this.cmboProductCode.TabIndex = 34;
            this.cmboProductCode.SelectedIndexChanged += new System.EventHandler(this.cmboProductCode_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Select Product from list";
            // 
            // linkHelp
            // 
            this.linkHelp.AutoSize = true;
            this.linkHelp.Location = new System.Drawing.Point(332, 9);
            this.linkHelp.Name = "linkHelp";
            this.linkHelp.Size = new System.Drawing.Size(29, 13);
            this.linkHelp.TabIndex = 36;
            this.linkHelp.TabStop = true;
            this.linkHelp.Text = "Help";
            this.linkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelp_LinkClicked);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnlabelPrint);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.linkHelp);
            this.splitContainer1.Panel1.Controls.Add(this.butDraw);
            this.splitContainer1.Panel1.Controls.Add(this.butPrint);
            this.splitContainer1.Panel1.Controls.Add(this.cmboProductCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtManufacturerCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtProductCode);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtChecksumDigit);
            this.splitContainer1.Panel1.Controls.Add(this.cboProductType);
            this.splitContainer1.Panel1.Controls.Add(this.cboScale);
            this.splitContainer1.Panel1.Controls.Add(this.rdbtnUPCA);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.rdbtnEAN13);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtCountryCode);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.butCreateBitmap);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblPrice);
            this.splitContainer1.Panel2.Controls.Add(this.lblProductName);
            this.splitContainer1.Panel2.Controls.Add(this.picBarcode);
            this.splitContainer1.Size = new System.Drawing.Size(800, 399);
            this.splitContainer1.SplitterDistance = 372;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnlabelPrint
            // 
            this.btnlabelPrint.FlatAppearance.BorderSize = 0;
            this.btnlabelPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnlabelPrint.Location = new System.Drawing.Point(12, 348);
            this.btnlabelPrint.Name = "btnlabelPrint";
            this.btnlabelPrint.Size = new System.Drawing.Size(218, 23);
            this.btnlabelPrint.TabIndex = 6;
            this.btnlabelPrint.Text = "Print Barcode N  label";
            this.btnlabelPrint.Click += new System.EventHandler(this.btnlabelPrint_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(104, 42);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(12, 16);
            this.lblPrice.TabIndex = 19;
            this.lblPrice.Text = "-";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.lblProductName.Location = new System.Drawing.Point(7, 42);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(10, 13);
            this.lblProductName.TabIndex = 18;
            this.lblProductName.Text = "-";
            // 
            // printDocLabelprint
            // 
            this.printDocLabelprint.DocumentName = "Barcode_Product_label";
            this.printDocLabelprint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocLabelprint_PrintPage);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // CreateBarcode
            // 
            this.AcceptButton = this.butDraw;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 433);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CreateBarcode";
            this.ShowIcon = false;
            this.Text = "Create Barcode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CreateBarcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCountryCode;
        private System.Windows.Forms.Button butCreateBitmap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboScale;
        private System.Windows.Forms.TextBox txtChecksumDigit;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtManufacturerCode;
        private System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.Button butPrint;
        private System.Windows.Forms.Button butDraw;
        private System.Windows.Forms.RadioButton rdbtnEAN13;
        private System.Windows.Forms.RadioButton rdbtnUPCA;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.ComboBox cmboProductCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkHelp;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Button btnlabelPrint;
        private System.Drawing.Printing.PrintDocument printDocLabelprint;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
    }
}