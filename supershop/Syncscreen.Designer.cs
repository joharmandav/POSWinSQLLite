namespace supershop
{
    partial class Syncscreen
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.DateTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.msgCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Red;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.Yellow;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(130, 88);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(252, 39);
            this.btnPrint.TabIndex = 180;
            this.btnPrint.Text = "Do it Later 10 Minutes";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(32, 27);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(13, 18);
            this.lblMsg.TabIndex = 181;
            this.lblMsg.Text = "-";
            // 
            // DateTimer
            // 
            this.DateTimer.Enabled = true;
            this.DateTimer.Tick += new System.EventHandler(this.DateTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(32, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 18);
            this.label1.TabIndex = 182;
            this.label1.Text = "Please Don\'t Work When Syncronize Process Running";
            // 
            // msgCount
            // 
            this.msgCount.AutoSize = true;
            this.msgCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgCount.ForeColor = System.Drawing.Color.Red;
            this.msgCount.Location = new System.Drawing.Point(39, 57);
            this.msgCount.Name = "msgCount";
            this.msgCount.Size = new System.Drawing.Size(13, 18);
            this.msgCount.TabIndex = 183;
            this.msgCount.Text = "-";
            // 
            // Syncscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(576, 199);
            this.Controls.Add(this.msgCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnPrint);
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Syncscreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Syncronization";
            this.Load += new System.EventHandler(this.CashierAction_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Timer DateTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label msgCount;

    }
}