namespace supershop
{
    partial class Appointment_Action
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
            this.btnColse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppointmentNO = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnEmployeeAssign = new System.Windows.Forms.Button();
            this.btnCalcel = new System.Windows.Forms.Button();
            this.btnAddjob = new System.Windows.Forms.Button();
            this.btnDeleteAppoint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnColse
            // 
            this.btnColse.BackColor = System.Drawing.Color.Fuchsia;
            this.btnColse.FlatAppearance.BorderSize = 0;
            this.btnColse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnColse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnColse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColse.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColse.ForeColor = System.Drawing.SystemColors.Window;
            this.btnColse.Location = new System.Drawing.Point(288, 0);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(28, 33);
            this.btnColse.TabIndex = 97;
            this.btnColse.Text = "X";
            this.btnColse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColse.UseVisualStyleBackColor = false;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "Appointment No :";
            // 
            // lblAppointmentNO
            // 
            this.lblAppointmentNO.AutoSize = true;
            this.lblAppointmentNO.ForeColor = System.Drawing.Color.Blue;
            this.lblAppointmentNO.Location = new System.Drawing.Point(107, 11);
            this.lblAppointmentNO.Name = "lblAppointmentNO";
            this.lblAppointmentNO.Size = new System.Drawing.Size(10, 13);
            this.lblAppointmentNO.TabIndex = 99;
            this.lblAppointmentNO.Text = "-";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.LimeGreen;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(35, 51);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(102, 39);
            this.btnEdit.TabIndex = 177;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnEmployeeAssign
            // 
            this.btnEmployeeAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEmployeeAssign.FlatAppearance.BorderSize = 0;
            this.btnEmployeeAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeAssign.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnEmployeeAssign.ForeColor = System.Drawing.Color.Green;
            this.btnEmployeeAssign.Location = new System.Drawing.Point(27, 181);
            this.btnEmployeeAssign.Name = "btnEmployeeAssign";
            this.btnEmployeeAssign.Size = new System.Drawing.Size(144, 39);
            this.btnEmployeeAssign.TabIndex = 176;
            this.btnEmployeeAssign.Text = "Employee Assign";
            this.btnEmployeeAssign.UseVisualStyleBackColor = false;
            this.btnEmployeeAssign.Visible = false;
            this.btnEmployeeAssign.Click += new System.EventHandler(this.btnEmployeeAssign_Click);
            // 
            // btnCalcel
            // 
            this.btnCalcel.BackColor = System.Drawing.Color.Red;
            this.btnCalcel.FlatAppearance.BorderSize = 0;
            this.btnCalcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcel.ForeColor = System.Drawing.Color.Yellow;
            this.btnCalcel.Location = new System.Drawing.Point(189, 51);
            this.btnCalcel.Name = "btnCalcel";
            this.btnCalcel.Size = new System.Drawing.Size(102, 39);
            this.btnCalcel.TabIndex = 178;
            this.btnCalcel.Text = "Cancel";
            this.btnCalcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCalcel.UseVisualStyleBackColor = false;
            this.btnCalcel.Click += new System.EventHandler(this.btnCalcel_Click);
            // 
            // btnAddjob
            // 
            this.btnAddjob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddjob.FlatAppearance.BorderSize = 0;
            this.btnAddjob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddjob.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnAddjob.ForeColor = System.Drawing.Color.Green;
            this.btnAddjob.Location = new System.Drawing.Point(177, 181);
            this.btnAddjob.Name = "btnAddjob";
            this.btnAddjob.Size = new System.Drawing.Size(114, 39);
            this.btnAddjob.TabIndex = 179;
            this.btnAddjob.Text = "Show Jobs";
            this.btnAddjob.UseVisualStyleBackColor = false;
            this.btnAddjob.Visible = false;
            this.btnAddjob.Click += new System.EventHandler(this.btnAddjob_Click);
            // 
            // btnDeleteAppoint
            // 
            this.btnDeleteAppoint.BackColor = System.Drawing.Color.Red;
            this.btnDeleteAppoint.FlatAppearance.BorderSize = 0;
            this.btnDeleteAppoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAppoint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAppoint.ForeColor = System.Drawing.Color.Yellow;
            this.btnDeleteAppoint.Location = new System.Drawing.Point(35, 117);
            this.btnDeleteAppoint.Name = "btnDeleteAppoint";
            this.btnDeleteAppoint.Size = new System.Drawing.Size(256, 39);
            this.btnDeleteAppoint.TabIndex = 180;
            this.btnDeleteAppoint.Text = "Delete This Appintment";
            this.btnDeleteAppoint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteAppoint.UseVisualStyleBackColor = false;
            this.btnDeleteAppoint.Click += new System.EventHandler(this.btnDeleteAppoint_Click);
            // 
            // Appointment_Action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(317, 261);
            this.Controls.Add(this.btnDeleteAppoint);
            this.Controls.Add(this.btnAddjob);
            this.Controls.Add(this.btnCalcel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnEmployeeAssign);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAppointmentNO);
            this.Controls.Add(this.btnColse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Appointment_Action";
            this.Text = "Appointment_Action";
            this.Load += new System.EventHandler(this.Appointment_Action_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnColse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAppointmentNO;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnEmployeeAssign;
        private System.Windows.Forms.Button btnCalcel;
        private System.Windows.Forms.Button btnAddjob;
        private System.Windows.Forms.Button btnDeleteAppoint;

    }
}