namespace supershop
{
    partial class Overview
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview));
            this.chartbarProfit = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPieProfit = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chartPieSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dtyearmonth = new System.Windows.Forms.DateTimePicker();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalesview = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.chartbarProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPieProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPieSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartbarProfit
            // 
            chartArea7.Name = "ChartArea1";
            this.chartbarProfit.ChartAreas.Add(chartArea7);
            this.chartbarProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend2";
            this.chartbarProfit.Legends.Add(legend7);
            this.chartbarProfit.Location = new System.Drawing.Point(0, 0);
            this.chartbarProfit.Name = "chartbarProfit";
            series7.ChartArea = "ChartArea1";
            series7.Label = "#VAL{00.00}";
            series7.LabelToolTip = "#VAL{00.00} \\n\\n #PERCENT Of Total  Profit\\n";
            series7.Legend = "Legend2";
            series7.MarkerSize = 1;
            series7.Name = "Profit";
            this.chartbarProfit.Series.Add(series7);
            this.chartbarProfit.Size = new System.Drawing.Size(1233, 322);
            this.chartbarProfit.TabIndex = 0;
            this.chartbarProfit.Text = "Profit";
            this.toolTip1.SetToolTip(this.chartbarProfit, "Daily Profit Amount chart");
            this.chartbarProfit.MouseLeave += new System.EventHandler(this.chart1_MouseLeave);
            this.chartbarProfit.MouseHover += new System.EventHandler(this.chart1_MouseHover);
            // 
            // chartPieProfit
            // 
            this.chartPieProfit.AllowDrop = true;
            this.chartPieProfit.BorderlineWidth = 4;
            chartArea8.Name = "ChartArea1";
            this.chartPieProfit.ChartAreas.Add(chartArea8);
            this.chartPieProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend2";
            this.chartPieProfit.Legends.Add(legend8);
            this.chartPieProfit.Location = new System.Drawing.Point(0, 0);
            this.chartPieProfit.Name = "chartPieProfit";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series8.Label = "#VALX  \\nProfit = #VAL{00.00}  \\n#PERCENT   ";
            series8.LabelToolTip = "#VALX  \\n\\nProfit = #VAL{00.00} \\n\\n #PERCENT Of Total  Profit\\n";
            series8.Legend = "Legend2";
            series8.MarkerSize = 1;
            series8.Name = "Profit";
            series8.YValuesPerPoint = 4;
            this.chartPieProfit.Series.Add(series8);
            this.chartPieProfit.Size = new System.Drawing.Size(633, 319);
            this.chartPieProfit.TabIndex = 2;
            this.chartPieProfit.Text = "chart2";
            this.toolTip1.SetToolTip(this.chartPieProfit, "Daily Profit Amount \r\nPie chart");
            this.chartPieProfit.Click += new System.EventHandler(this.chart2_Click);
            this.chartPieProfit.MouseLeave += new System.EventHandler(this.chart2_MouseLeave);
            this.chartPieProfit.MouseHover += new System.EventHandler(this.chart2_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(886, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "M";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chartPieSales
            // 
            this.chartPieSales.AllowDrop = true;
            this.chartPieSales.BorderlineWidth = 4;
            chartArea9.Name = "ChartArea1";
            this.chartPieSales.ChartAreas.Add(chartArea9);
            this.chartPieSales.Dock = System.Windows.Forms.DockStyle.Fill;
            legend9.Name = "Legend2";
            this.chartPieSales.Legends.Add(legend9);
            this.chartPieSales.Location = new System.Drawing.Point(0, 0);
            this.chartPieSales.Name = "chartPieSales";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series9.Label = "#VALX  \\nSale = #VAL{00.00}  \\n #PERCENT ";
            series9.LabelToolTip = "#VALX  \\n\\nSale = #VAL{00.00}  \\n\\n #PERCENT Of Total  Sales\\n";
            series9.Legend = "Legend2";
            series9.MarkerSize = 1;
            series9.Name = "Total";
            series9.YValuesPerPoint = 4;
            this.chartPieSales.Series.Add(series9);
            this.chartPieSales.Size = new System.Drawing.Size(596, 319);
            this.chartPieSales.TabIndex = 2;
            this.chartPieSales.Text = "chart3";
            this.toolTip1.SetToolTip(this.chartPieSales, "Daily Sales Amount \r\nPie chart");
            this.chartPieSales.MouseLeave += new System.EventHandler(this.chart3_MouseLeave);
            this.chartPieSales.MouseHover += new System.EventHandler(this.chart3_MouseHover);
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
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 31);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // dtyearmonth
            // 
            this.dtyearmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtyearmonth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtyearmonth.Location = new System.Drawing.Point(280, 5);
            this.dtyearmonth.Name = "dtyearmonth";
            this.dtyearmonth.Size = new System.Drawing.Size(161, 24);
            this.dtyearmonth.TabIndex = 12;
            this.toolTip1.SetToolTip(this.dtyearmonth, "Please Select Year and Month");
            this.dtyearmonth.ValueChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(598, 6);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(161, 24);
            this.dtDate.TabIndex = 14;
            this.toolTip1.SetToolTip(this.dtDate, "Please Select Year and Month");
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
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
            // btnSalesview
            // 
            this.btnSalesview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalesview.BackgroundImage")));
            this.btnSalesview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalesview.FlatAppearance.BorderSize = 0;
            this.btnSalesview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSalesview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesview.Location = new System.Drawing.Point(1073, 3);
            this.btnSalesview.Name = "btnSalesview";
            this.btnSalesview.Size = new System.Drawing.Size(157, 35);
            this.btnSalesview.TabIndex = 11;
            this.btnSalesview.Text = "Sale View";
            this.btnSalesview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesview.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalesview.UseVisualStyleBackColor = true;
            this.btnSalesview.Click += new System.EventHandler(this.button3_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.dtDate);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.dtyearmonth);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnSalesview);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(1233, 686);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(474, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Daily Chart";
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
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1233, 645);
            this.splitContainer2.SplitterDistance = 322;
            this.splitContainer2.TabIndex = 7;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.chartPieProfit);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chartPieSales);
            this.splitContainer3.Size = new System.Drawing.Size(1233, 319);
            this.splitContainer3.SplitterDistance = 633;
            this.splitContainer3.TabIndex = 0;
            // 
            // Overview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1233, 686);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Name = "Overview";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Overview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Overview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartbarProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPieProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPieSales)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartbarProfit;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPieProfit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPieSales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalesview;
        private System.Windows.Forms.DateTimePicker dtyearmonth;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label5;
    }
}