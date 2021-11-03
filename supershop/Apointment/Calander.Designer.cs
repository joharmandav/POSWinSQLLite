using Syd.ScheduleControls;
namespace supershop
{
    partial class Calander
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calander));
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblApptCount = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dayView2 = new Syd.ScheduleControls.DayScheduleControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.monthView1 = new Syd.ScheduleControls.MonthScheduleControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dayView1 = new Syd.ScheduleControls.DayScheduleControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.weekView1 = new Syd.ScheduleControls.WeekScheduleControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.lblFirstEmployee = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWorkingStart = new System.Windows.Forms.TextBox();
            this.txtWorkingEnd = new System.Windows.Forms.TextBox();
            this.btnWorkingHr = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weekView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(658, 356);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "test";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(658, 356);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "test 2";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(658, 356);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(658, 356);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "tabPage9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(658, 356);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "tabPage10";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(7, 4);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1DateSelected);
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.Location = new System.Drawing.Point(312, 58);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(151, 23);
            this.lblCurrentDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(243, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date shown:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(243, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Appts shown:";
            // 
            // lblApptCount
            // 
            this.lblApptCount.Location = new System.Drawing.Point(321, 81);
            this.lblApptCount.Name = "lblApptCount";
            this.lblApptCount.Size = new System.Drawing.Size(117, 23);
            this.lblApptCount.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Yellow;
            this.tabPage4.Controls.Add(this.dayView2);
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1348, 615);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = " Day (5 day) ";
            // 
            // dayView2
            // 
            this.dayView2.Date = new System.DateTime(((long)(0)));
            this.dayView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayView2.Location = new System.Drawing.Point(3, 3);
            this.dayView2.MinimumSize = new System.Drawing.Size(300, 300);
            this.dayView2.Name = "dayView2";
            this.dayView2.RenderWorkingHoursOnly = true;
            this.dayView2.SingleDay = false;
            this.dayView2.Size = new System.Drawing.Size(1342, 609);
            this.dayView2.TabIndex = 2;
            this.dayView2.WorkEndHour = 19;
            this.dayView2.WorkStartHour = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Orange;
            this.tabPage3.Controls.Add(this.monthView1);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1348, 615);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = " Month ";
            // 
            // monthView1
            // 
            this.monthView1.Date = new System.DateTime(2010, 11, 4, 17, 49, 16, 315);
            this.monthView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthView1.Location = new System.Drawing.Point(3, 3);
            this.monthView1.MinimumSize = new System.Drawing.Size(300, 300);
            this.monthView1.Name = "monthView1";
            this.monthView1.Size = new System.Drawing.Size(1342, 609);
            this.monthView1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LimeGreen;
            this.tabPage2.Controls.Add(this.dayView1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1348, 615);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " Day (1 day) ";
            // 
            // dayView1
            // 
            this.dayView1.Date = new System.DateTime(2010, 10, 25, 19, 4, 0, 0);
            this.dayView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayView1.Location = new System.Drawing.Point(3, 3);
            this.dayView1.MinimumSize = new System.Drawing.Size(300, 300);
            this.dayView1.Name = "dayView1";
            this.dayView1.RenderWorkingHoursOnly = true;
            this.dayView1.SingleDay = true;
            this.dayView1.Size = new System.Drawing.Size(1342, 609);
            this.dayView1.TabIndex = 1;
            this.dayView1.WorkEndHour = 19;
            this.dayView1.WorkStartHour = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Tomato;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.weekView1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1348, 615);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " Week ";
            // 
            // weekView1
            // 
            this.weekView1.Date = new System.DateTime(2010, 10, 25, 19, 4, 39, 0);
            this.weekView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weekView1.Location = new System.Drawing.Point(3, 3);
            this.weekView1.Name = "weekView1";
            this.weekView1.Size = new System.Drawing.Size(1342, 609);
            this.weekView1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 171);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1356, 646);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(246, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 46);
            this.button1.TabIndex = 163;
            this.button1.Text = "Add New Appointment";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboEmployee
            // 
            this.comboEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(246, 22);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(205, 24);
            this.comboEmployee.TabIndex = 216;
            this.comboEmployee.SelectedIndexChanged += new System.EventHandler(this.comboEmployee_SelectedIndexChanged);
            // 
            // lblFirstEmployee
            // 
            this.lblFirstEmployee.AutoSize = true;
            this.lblFirstEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstEmployee.Location = new System.Drawing.Point(441, 2);
            this.lblFirstEmployee.Name = "lblFirstEmployee";
            this.lblFirstEmployee.Size = new System.Drawing.Size(10, 13);
            this.lblFirstEmployee.TabIndex = 227;
            this.lblFirstEmployee.Text = "-";
            this.lblFirstEmployee.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 228;
            this.label3.Text = "Employee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 229;
            this.label4.Text = "Working Hours :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 230;
            this.label5.Text = "To";
            // 
            // txtWorkingStart
            // 
            this.txtWorkingStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkingStart.Location = new System.Drawing.Point(475, 138);
            this.txtWorkingStart.Name = "txtWorkingStart";
            this.txtWorkingStart.Size = new System.Drawing.Size(41, 22);
            this.txtWorkingStart.TabIndex = 231;
            this.txtWorkingStart.Text = "9";
            // 
            // txtWorkingEnd
            // 
            this.txtWorkingEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkingEnd.Location = new System.Drawing.Point(553, 138);
            this.txtWorkingEnd.Name = "txtWorkingEnd";
            this.txtWorkingEnd.Size = new System.Drawing.Size(43, 22);
            this.txtWorkingEnd.TabIndex = 232;
            this.txtWorkingEnd.Text = "19";
            // 
            // btnWorkingHr
            // 
            this.btnWorkingHr.BackColor = System.Drawing.Color.SeaGreen;
            this.btnWorkingHr.FlatAppearance.BorderSize = 0;
            this.btnWorkingHr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnWorkingHr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnWorkingHr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkingHr.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWorkingHr.ForeColor = System.Drawing.SystemColors.Window;
            this.btnWorkingHr.Location = new System.Drawing.Point(551, 106);
            this.btnWorkingHr.Name = "btnWorkingHr";
            this.btnWorkingHr.Size = new System.Drawing.Size(44, 27);
            this.btnWorkingHr.TabIndex = 233;
            this.btnWorkingHr.Text = "Save";
            this.btnWorkingHr.UseVisualStyleBackColor = false;
            this.btnWorkingHr.Click += new System.EventHandler(this.btnWorkingHr_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(518, 166);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 234;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Calander
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 817);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnWorkingHr);
            this.Controls.Add(this.txtWorkingEnd);
            this.Controls.Add(this.txtWorkingStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFirstEmployee);
            this.Controls.Add(this.comboEmployee);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblApptCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Calander";
            this.Text = "Calendar";
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monthView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.weekView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label lblApptCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.MonthCalendar monthCalendar1;

        #endregion

        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage4;
        private DayScheduleControl dayView2;
        private System.Windows.Forms.TabPage tabPage3;
        private MonthScheduleControl monthView1;
        private System.Windows.Forms.TabPage tabPage2;
        private DayScheduleControl dayView1;
        private System.Windows.Forms.TabPage tabPage1;
        private WeekScheduleControl weekView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.Label lblFirstEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWorkingStart;
        private System.Windows.Forms.TextBox txtWorkingEnd;
        private System.Windows.Forms.Button btnWorkingHr;
        private System.Windows.Forms.Button btnRefresh;

    }
}