namespace supershop.Expenses
{
    partial class AddExpense
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtReferNo = new System.Windows.Forms.TextBox();
            this.cmboCategory = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtAttachmentFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnaddexpense = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblfileID = new System.Windows.Forms.Label();
            this.lblcopyfile = new System.Windows.Forms.Label();
            this.lblFileExtension = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblfileinfo = new System.Windows.Forms.Label();
            this.lnkExpenses = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reference No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Category *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Amount *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Attachment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Note ";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(30, 92);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(275, 24);
            this.dtStartDate.TabIndex = 86;
            this.toolTip1.SetToolTip(this.dtStartDate, "Select Date");
            // 
            // txtReferNo
            // 
            this.txtReferNo.Location = new System.Drawing.Point(30, 145);
            this.txtReferNo.Name = "txtReferNo";
            this.txtReferNo.Size = new System.Drawing.Size(275, 20);
            this.txtReferNo.TabIndex = 87;
            this.toolTip1.SetToolTip(this.txtReferNo, "Please Fill Reference No");
            // 
            // cmboCategory
            // 
            this.cmboCategory.FormattingEnabled = true;
            this.cmboCategory.Items.AddRange(new object[] {
            "Daily Expense",
            "POS paper Roll",
            "Buy Accessories",
            "Salary",
            "Employee Salary",
            "Bonus",
            "Transportation",
            "Guest Tea Invitaion",
            "Rent",
            "House Rent",
            "Shop Rent",
            "Shop Decoration"});
            this.cmboCategory.Location = new System.Drawing.Point(30, 190);
            this.cmboCategory.Name = "cmboCategory";
            this.cmboCategory.Size = new System.Drawing.Size(273, 21);
            this.cmboCategory.TabIndex = 90;
            this.toolTip1.SetToolTip(this.cmboCategory, "Select Category");
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(30, 240);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(273, 20);
            this.txtAmount.TabIndex = 91;
            this.toolTip1.SetToolTip(this.txtAmount, "Please Fill Amount");
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // txtAttachmentFileName
            // 
            this.txtAttachmentFileName.Location = new System.Drawing.Point(30, 290);
            this.txtAttachmentFileName.Name = "txtAttachmentFileName";
            this.txtAttachmentFileName.Size = new System.Drawing.Size(216, 20);
            this.txtAttachmentFileName.TabIndex = 92;
            this.toolTip1.SetToolTip(this.txtAttachmentFileName, "Please support Document");
            this.txtAttachmentFileName.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(247, 289);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(58, 23);
            this.btnBrowse.TabIndex = 93;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(30, 337);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(273, 57);
            this.txtNote.TabIndex = 94;
            this.toolTip1.SetToolTip(this.txtNote, "Please fill Note");
            // 
            // btnaddexpense
            // 
            this.btnaddexpense.Location = new System.Drawing.Point(30, 400);
            this.btnaddexpense.Name = "btnaddexpense";
            this.btnaddexpense.Size = new System.Drawing.Size(275, 23);
            this.btnaddexpense.TabIndex = 95;
            this.btnaddexpense.Text = "Add Expense";
            this.btnaddexpense.UseVisualStyleBackColor = true;
            this.btnaddexpense.Click += new System.EventHandler(this.btnaddexpense_Click);
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel1.Controls.Add(this.lblfileID);
            this.splitContainer1.Panel1.Controls.Add(this.lblcopyfile);
            this.splitContainer1.Panel1.Controls.Add(this.lblFileExtension);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.dtStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.btnaddexpense);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtNote);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnBrowse);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtAttachmentFileName);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtAmount);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.cmboCategory);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtReferNo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.lblfileinfo);
            this.splitContainer1.Panel2.Controls.Add(this.lnkExpenses);
            this.splitContainer1.Size = new System.Drawing.Size(480, 441);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 96;
            // 
            // lblfileID
            // 
            this.lblfileID.AutoSize = true;
            this.lblfileID.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F);
            this.lblfileID.Location = new System.Drawing.Point(71, 79);
            this.lblfileID.Name = "lblfileID";
            this.lblfileID.Size = new System.Drawing.Size(6, 7);
            this.lblfileID.TabIndex = 100;
            this.lblfileID.Text = "-";
            // 
            // lblcopyfile
            // 
            this.lblcopyfile.AutoSize = true;
            this.lblcopyfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblcopyfile.Location = new System.Drawing.Point(32, 426);
            this.lblcopyfile.Name = "lblcopyfile";
            this.lblcopyfile.Size = new System.Drawing.Size(10, 13);
            this.lblcopyfile.TabIndex = 99;
            this.lblcopyfile.Text = "-";
            this.lblcopyfile.Visible = false;
            // 
            // lblFileExtension
            // 
            this.lblFileExtension.AutoSize = true;
            this.lblFileExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.25F);
            this.lblFileExtension.Location = new System.Drawing.Point(250, 314);
            this.lblFileExtension.Name = "lblFileExtension";
            this.lblFileExtension.Size = new System.Drawing.Size(0, 2);
            this.lblFileExtension.TabIndex = 98;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 13);
            this.label8.TabIndex = 97;
            this.label8.Text = "The field labels marked with * are required input fields.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(284, 20);
            this.label7.TabIndex = 96;
            this.label7.Text = "Add Expense                                             ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "File info";
            // 
            // lblfileinfo
            // 
            this.lblfileinfo.AutoSize = true;
            this.lblfileinfo.Location = new System.Drawing.Point(20, 164);
            this.lblfileinfo.Name = "lblfileinfo";
            this.lblfileinfo.Size = new System.Drawing.Size(13, 13);
            this.lblfileinfo.TabIndex = 1;
            this.lblfileinfo.Text = "--";
            // 
            // lnkExpenses
            // 
            this.lnkExpenses.AutoSize = true;
            this.lnkExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lnkExpenses.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkExpenses.LinkVisited = true;
            this.lnkExpenses.Location = new System.Drawing.Point(21, 89);
            this.lnkExpenses.Name = "lnkExpenses";
            this.lnkExpenses.Size = new System.Drawing.Size(91, 16);
            this.lnkExpenses.TabIndex = 0;
            this.lnkExpenses.TabStop = true;
            this.lnkExpenses.Text = "List Expenses";
            this.lnkExpenses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExpenses_LinkClicked);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddExpense
            // 
            this.AcceptButton = this.btnaddexpense;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 441);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddExpense";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Expense";
            this.Load += new System.EventHandler(this.AddExpense_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.TextBox txtReferNo;
        private System.Windows.Forms.ComboBox cmboCategory;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtAttachmentFileName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnaddexpense;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.LinkLabel lnkExpenses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblFileExtension;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblcopyfile;
        private System.Windows.Forms.Label lblfileinfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblfileID;
    }
}