namespace supershop
{
    partial class Sale_chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sale_chart));
            this.chartBarSale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBarSalesProfitCom = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dtyearmonth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarSalesProfitCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartBarSale
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBarSale.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBarSale.Legends.Add(legend1);
            this.chartBarSale.Location = new System.Drawing.Point(12, 38);
            this.chartBarSale.Name = "chartBarSale";
            this.chartBarSale.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Label = "#VAL{00.00}";
            series1.LabelToolTip = "#VAL{00.00}";
            series1.Legend = "Legend1";
            series1.Name = "Sale";
            series1.YValuesPerPoint = 2;
            this.chartBarSale.Series.Add(series1);
            this.chartBarSale.Size = new System.Drawing.Size(1129, 300);
            this.chartBarSale.TabIndex = 0;
            this.chartBarSale.Text = "chart1";
            this.toolTip1.SetToolTip(this.chartBarSale, "Daily base Sales Comparison");
            // 
            // chartBarSalesProfitCom
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBarSalesProfitCom.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartBarSalesProfitCom.Legends.Add(legend2);
            this.chartBarSalesProfitCom.Location = new System.Drawing.Point(12, 361);
            this.chartBarSalesProfitCom.Name = "chartBarSalesProfitCom";
            series2.ChartArea = "ChartArea1";
            series2.Label = "#VAL{00.00}";
            series2.LabelToolTip = "#VAL{00.00}";
            series2.Legend = "Legend1";
            series2.Name = "Sale";
            series3.ChartArea = "ChartArea1";
            series3.Label = "#VAL{00.00}";
            series3.LabelToolTip = "#VAL{00.00}";
            series3.Legend = "Legend1";
            series3.Name = "Profit";
            this.chartBarSalesProfitCom.Series.Add(series2);
            this.chartBarSalesProfitCom.Series.Add(series3);
            this.chartBarSalesProfitCom.Size = new System.Drawing.Size(1129, 309);
            this.chartBarSalesProfitCom.TabIndex = 3;
            this.chartBarSalesProfitCom.Text = "chart2";
            this.toolTip1.SetToolTip(this.chartBarSalesProfitCom, "Sales and Profit Comparison");
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 30);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(513, 677);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(246, 30);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1014, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(369, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Monthly Chart";
            // 
            // dtyearmonth
            // 
            this.dtyearmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtyearmonth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtyearmonth.Location = new System.Drawing.Point(475, 8);
            this.dtyearmonth.Name = "dtyearmonth";
            this.dtyearmonth.Size = new System.Drawing.Size(172, 24);
            this.dtyearmonth.TabIndex = 13;
            this.toolTip1.SetToolTip(this.dtyearmonth, "Please Select Year and Month");
            this.dtyearmonth.ValueChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 673);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Sales and Profit Comparison";
            this.toolTip1.SetToolTip(this.label1, "Sales and Profit Comparison\r\non daily");
            // 
            // Sale_chart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1149, 715);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtyearmonth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chartBarSalesProfitCom);
            this.Controls.Add(this.chartBarSale);
            this.Name = "Sale_chart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Sale Chart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sale_chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartBarSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarSalesProfitCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartBarSale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBarSalesProfitCom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker dtyearmonth;
        private System.Windows.Forms.Label label1;
    }
}