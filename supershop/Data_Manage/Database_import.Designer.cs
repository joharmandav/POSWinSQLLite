namespace supershop
{
    partial class Database_import
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
            this.btnimport = new System.Windows.Forms.Button();
            this.txtfilepath = new System.Windows.Forms.TextBox();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.btnsync = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMSg = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnimport
            // 
            this.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimport.Location = new System.Drawing.Point(72, 118);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(311, 23);
            this.btnimport.TabIndex = 0;
            this.btnimport.Text = "Import";
            this.btnimport.UseVisualStyleBackColor = true;
            this.btnimport.Click += new System.EventHandler(this.btnimport_Click);
            // 
            // txtfilepath
            // 
            this.txtfilepath.Location = new System.Drawing.Point(71, 67);
            this.txtfilepath.Name = "txtfilepath";
            this.txtfilepath.ReadOnly = true;
            this.txtfilepath.Size = new System.Drawing.Size(312, 20);
            this.txtfilepath.TabIndex = 1;
            this.txtfilepath.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // btnbrowse
            // 
            this.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowse.Location = new System.Drawing.Point(389, 67);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(68, 23);
            this.btnbrowse.TabIndex = 2;
            this.btnbrowse.Text = "Browse";
            this.toolTipInfo.SetToolTip(this.btnbrowse, "Select your new database file");
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(165, 184);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(205, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "I want to Rebuild/Reset my System\r\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // btnsync
            // 
            this.btnsync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsync.Location = new System.Drawing.Point(389, 184);
            this.btnsync.Name = "btnsync";
            this.btnsync.Size = new System.Drawing.Size(105, 23);
            this.btnsync.TabIndex = 7;
            this.btnsync.Text = "Syncronization";
            this.toolTipInfo.SetToolTip(this.btnsync, "Select your new database file");
            this.btnsync.UseVisualStyleBackColor = true;
            this.btnsync.Click += new System.EventHandler(this.btnsync_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(91, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "import Sql File";
            this.toolTipInfo.SetToolTip(this.button1, "Select your new database file");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(12, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "export Sql";
            this.toolTipInfo.SetToolTip(this.button2, "Select your new database file");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select your Backup database file (only support SQlite)\r\nBefore import db file ple" +
    "ase close you Sqlite browser if you open.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(173, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Restore Databse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "I want to Restore Database with my Backup";
            // 
            // lblMSg
            // 
            this.lblMSg.AutoSize = true;
            this.lblMSg.ForeColor = System.Drawing.Color.Blue;
            this.lblMSg.Location = new System.Drawing.Point(12, 234);
            this.lblMSg.Name = "lblMSg";
            this.lblMSg.Size = new System.Drawing.Size(10, 13);
            this.lblMSg.TabIndex = 11;
            this.lblMSg.Text = "-";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 250);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(482, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // Database_import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 285);
            this.Controls.Add(this.lblMSg);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnsync);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnbrowse);
            this.Controls.Add(this.txtfilepath);
            this.Controls.Add(this.btnimport);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Database_import";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Restore only apply Sqlite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.TextBox txtfilepath;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnsync;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblMSg;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}