namespace supershop
{
    partial class Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chart));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.printGrid = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.combCategory = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend2";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Label = "#VAL";
            series1.LabelToolTip = "#VAL";
            series1.Legend = "Legend2";
            series1.Name = "price";
            series2.ChartArea = "ChartArea1";
            series2.Label = "#VAL";
            series2.LabelToolTip = "#VAL";
            series2.Legend = "Legend2";
            series2.MarkerSize = 1;
            series2.Name = "msrp";
            series2.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1182, 403);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // printGrid
            // 
            this.printGrid.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.printGrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("printGrid.BackgroundImage")));
            this.printGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.printGrid.FlatAppearance.BorderSize = 0;
            this.printGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.printGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printGrid.Location = new System.Drawing.Point(1053, 3);
            this.printGrid.Name = "printGrid";
            this.printGrid.Size = new System.Drawing.Size(126, 30);
            this.printGrid.TabIndex = 7;
            this.printGrid.UseVisualStyleBackColor = false;
            this.printGrid.Click += new System.EventHandler(this.printGrid_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.combCategory);
            this.splitContainer1.Panel1.Controls.Add(this.label24);
            this.splitContainer1.Panel1.Controls.Add(this.printGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Size = new System.Drawing.Size(1182, 442);
            this.splitContainer1.SplitterDistance = 35;
            this.splitContainer1.TabIndex = 8;
            // 
            // combCategory
            // 
            this.combCategory.Font = new System.Drawing.Font("Times New Roman", 9.25F);
            this.combCategory.FormattingEnabled = true;
            this.combCategory.Location = new System.Drawing.Point(130, 5);
            this.combCategory.Name = "combCategory";
            this.combCategory.Size = new System.Drawing.Size(328, 23);
            this.combCategory.TabIndex = 152;
            this.combCategory.SelectedIndexChanged += new System.EventHandler(this.combCategory_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.label24.Location = new System.Drawing.Point(12, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 14);
            this.label24.TabIndex = 151;
            this.label24.Text = "Select Category";
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1182, 442);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Chart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button printGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox combCategory;
        private System.Windows.Forms.Label label24;

    }
}