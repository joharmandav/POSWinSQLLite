namespace supershop
{
    partial class GraphOverView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphOverView));
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chartbarProfit = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtyearmonth = new System.Windows.Forms.DateTimePicker();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.DTTO = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableAdapterManager1 = new supershop.Dataset_ReturnTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.chartbarProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Date";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 80000;
            this.toolTip1.ForeColor = System.Drawing.Color.ForestGreen;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 4;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // chartbarProfit
            // 
            this.chartbarProfit.BorderlineColor = System.Drawing.Color.Black;
            this.chartbarProfit.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "ChartArea1";
            this.chartbarProfit.ChartAreas.Add(chartArea3);
            this.chartbarProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend2";
            this.chartbarProfit.Legends.Add(legend3);
            this.chartbarProfit.Location = new System.Drawing.Point(0, 0);
            this.chartbarProfit.Name = "chartbarProfit";
            series3.ChartArea = "ChartArea1";
            series3.Label = "#VAL{00.00}";
            series3.LabelToolTip = "#VAL{00.00} \\n\\n #PERCENT Of Total  Profit\\n";
            series3.Legend = "Legend2";
            series3.MarkerSize = 1;
            series3.Name = "Profit";
            this.chartbarProfit.Series.Add(series3);
            this.chartbarProfit.Size = new System.Drawing.Size(1222, 400);
            this.chartbarProfit.TabIndex = 0;
            this.chartbarProfit.Text = "Profit";
            this.toolTip1.SetToolTip(this.chartbarProfit, "Daily Profit Amount chart");
            // 
            // dtyearmonth
            // 
            this.dtyearmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtyearmonth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtyearmonth.Location = new System.Drawing.Point(280, 5);
            this.dtyearmonth.Name = "dtyearmonth";
            this.dtyearmonth.Size = new System.Drawing.Size(161, 24);
            this.dtyearmonth.TabIndex = 12;
            this.toolTip1.SetToolTip(this.dtyearmonth, "Please Select Year and Month");
            this.dtyearmonth.ValueChanged += new System.EventHandler(this.dtyearmonth_ValueChanged);
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(531, 6);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(161, 24);
            this.dtDate.TabIndex = 14;
            this.toolTip1.SetToolTip(this.dtDate, "Please Select Year and Month");
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // DTTO
            // 
            this.DTTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTTO.Location = new System.Drawing.Point(768, 6);
            this.DTTO.Name = "DTTO";
            this.DTTO.Size = new System.Drawing.Size(161, 24);
            this.DTTO.TabIndex = 16;
            this.toolTip1.SetToolTip(this.DTTO, "Please Select Year and Month");
            this.DTTO.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.Location = new System.Drawing.Point(629, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(9, 620);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Profit";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chartbarProfit);
            this.splitContainer2.Size = new System.Drawing.Size(1222, 429);
            this.splitContainer2.SplitterDistance = 400;
            this.splitContainer2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(156, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Monthly Chart";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(15, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 31);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DTTO);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.dtDate);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.dtyearmonth);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(1222, 470);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(727, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(475, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "From ";
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = supershop.Dataset_ReturnTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.Win_sales_paymentTableAdapter = null;
            // 
            // GraphOverView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Name = "GraphOverView";
            this.Size = new System.Drawing.Size(1222, 470);
            this.Load += new System.EventHandler(this.GraphOverView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartbarProfit)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartbarProfit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtyearmonth;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private Dataset_ReturnTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DateTimePicker DTTO;
        private System.Windows.Forms.Label label6;

    }
}
