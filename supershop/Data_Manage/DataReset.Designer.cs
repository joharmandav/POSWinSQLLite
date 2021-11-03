namespace supershop.Data_Manage
{
    partial class DataReset
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
            this.btntruncate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbsqlite = new System.Windows.Forms.RadioButton();
            this.bdbMySQL = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btntruncate
            // 
            this.btntruncate.Location = new System.Drawing.Point(93, 157);
            this.btntruncate.Name = "btntruncate";
            this.btntruncate.Size = new System.Drawing.Size(179, 23);
            this.btntruncate.TabIndex = 0;
            this.btntruncate.Text = "Truncate";
            this.btntruncate.UseVisualStyleBackColor = true;
            this.btntruncate.Click += new System.EventHandler(this.btntruncate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(126, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reset System";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Reset Database - Empty system";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Now I\'m using Database";
            // 
            // rdbsqlite
            // 
            this.rdbsqlite.AutoSize = true;
            this.rdbsqlite.Location = new System.Drawing.Point(98, 105);
            this.rdbsqlite.Name = "rdbsqlite";
            this.rdbsqlite.Size = new System.Drawing.Size(57, 17);
            this.rdbsqlite.TabIndex = 6;
            this.rdbsqlite.Text = "SQLite";
            this.rdbsqlite.UseVisualStyleBackColor = true;
            // 
            // bdbMySQL
            // 
            this.bdbMySQL.AutoSize = true;
            this.bdbMySQL.Location = new System.Drawing.Point(189, 105);
            this.bdbMySQL.Name = "bdbMySQL";
            this.bdbMySQL.Size = new System.Drawing.Size(88, 17);
            this.bdbMySQL.TabIndex = 7;
            this.bdbMySQL.Text = "Mysql or SQL";
            this.bdbMySQL.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Truncate Sales history, Return history , Stock items ";
            // 
            // DataReset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 222);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bdbMySQL);
            this.Controls.Add(this.rdbsqlite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btntruncate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataReset";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Reset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntruncate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbsqlite;
        private System.Windows.Forms.RadioButton bdbMySQL;
        private System.Windows.Forms.Label label4;
    }
}