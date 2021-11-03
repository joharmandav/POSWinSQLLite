using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Finisar.SQLite;
using System.Windows.Forms.DataVisualization.Charting;
 

namespace supershop
{
    public partial class Sale_chart : Form
    {
        public Sale_chart()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 
      
        private void Sale_chart_Load(object sender, EventArgs e)
        {
            dtyearmonth.Format = DateTimePickerFormat.Custom;
            dtyearmonth.CustomFormat = "yyyy-MM";
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM");
            try
            {

                string sql5 = "select sales_time, SUM(total) as Total from sales_item " +
                                " where TenentID = "+ Tenent.TenentID +" and sales_time   like  '%" + date + "%' and status = 1  or status = 3  GROUP BY  sales_time ";
                              

                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartBarSale.DataSource = dt5;
                chartBarSale.Visible = true;
                chartBarSale.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartBarSale.Series["Sale"].XValueMember = "sales_time";
                chartBarSale.Series["Sale"].YValueMembers = "Total";
                chartBarSale.DataBind();

                string sql2 = "select sales_time, SUM(total) as Total , SUM(profit * Qty) as Profit from sales_item " +
                            " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + date + "%' and status = 1  or status = 3  GROUP BY  sales_time ";
                DataAccess.ExecuteSQL(sql2);
                DataTable dt2 = DataAccess.GetDataTable(sql2);
                chartBarSalesProfitCom.DataSource = dt2;
                chartBarSalesProfitCom.Visible = true;
                chartBarSalesProfitCom.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartBarSalesProfitCom.Series["Sale"].XValueMember = "sales_time";
                chartBarSalesProfitCom.Series["Sale"].YValueMembers = "Total";

                chartBarSalesProfitCom.Series["Profit"].XValueMember = "sales_time";
                chartBarSalesProfitCom.Series["Profit"].YValueMembers = "Profit";
                chartBarSalesProfitCom.DataBind();

            }
            catch
            {

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {             
                string sql5 = "select sales_time, SUM(total) as Total from sales_item " +
                    " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + dtyearmonth.Text + "%' and status = 1  or status = 3 GROUP BY  sales_time "; 

                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartBarSale.DataSource = dt5;
                chartBarSale.Visible = true;
                chartBarSale.ChartAreas[0].AxisX.LabelStyle.Angle = 45;  
                chartBarSale.Series["Sale"].XValueMember = "sales_time";
                chartBarSale.Series["Sale"].YValueMembers = "Total";                
                chartBarSale.DataBind();

                string sql2 = "select sales_time, SUM(total) as Total , SUM(profit * Qty) as Profit from sales_item " +
                    "  where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + dtyearmonth.Text + "%'  and status = 1  or status = 3 GROUP BY  sales_time "; 
                DataAccess.ExecuteSQL(sql2);
                DataTable dt2 = DataAccess.GetDataTable(sql2);
                chartBarSalesProfitCom.DataSource = dt2;
                chartBarSalesProfitCom.Visible = true;
                chartBarSalesProfitCom.ChartAreas[0].AxisX.LabelStyle.Angle = 45; 
                chartBarSalesProfitCom.Series["Sale"].XValueMember = "sales_time";
                chartBarSalesProfitCom.Series["Sale"].YValueMembers = "Total";

                chartBarSalesProfitCom.Series["Profit"].XValueMember = "sales_time";
                chartBarSalesProfitCom.Series["Profit"].YValueMembers = "Profit";
                chartBarSalesProfitCom.DataBind();
               
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                chartBarSale.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                // Print preview chart
                chartBarSale.Printing.PrintPreview();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                chartBarSalesProfitCom.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                // Print preview chart
                chartBarSalesProfitCom.Printing.PrintPreview();
            }
            catch
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Overview go = new Overview();
            go.MdiParent = this.ParentForm;
            go.Show();

            this.Hide();
        }

     
    }
}
