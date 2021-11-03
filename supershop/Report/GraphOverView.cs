using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class GraphOverView : UserControl
    {
        public GraphOverView()
        {
            InitializeComponent();
        }

        private void GraphOverView_Load(object sender, EventArgs e)
        {
            dtyearmonth.Format = DateTimePickerFormat.Custom;
            dtyearmonth.CustomFormat = "yyyy-MM";

            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");

            DateTime STdt = DateTime.Now.AddDays(-7);
            string Stdate = STdt.ToString("yyyy-MM-dd");

            try
            {
                //Profit Chart
                string sql5 = " select sales_time, SUM(profit * Qty) as Profit from sales_item " +
                                " where sales_time   BETWEEN  '" + Stdate + "' AND    '" + date + "' and status = 1  or status = 3 GROUP BY  sales_time ";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartbarProfit.DataSource = dt5;
                chartbarProfit.Visible = true;
                chartbarProfit.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartbarProfit.Series["Profit"].XValueMember = "sales_time";
                chartbarProfit.Series["Profit"].YValueMembers = "Profit";
                chartbarProfit.DataBind();

                ////Profit Pie chart 
                //string sql2 = "select  SUM(profit * Qty) as Profit , sales_time from sales_item " +
                //            " where sales_time   like  '%" + date + "%' and status = 1  or status = 3  GROUP BY  sales_time ";
                //DataAccess.ExecuteSQL(sql2);
                //DataTable dt2 = DataAccess.GetDataTable(sql2);
                //chartPieProfit.DataSource = dt2;
                //chartPieProfit.Visible = true;
                //chartPieProfit.Series["Profit"].XValueMember = "sales_time";
                //chartPieProfit.Series["Profit"].YValueMembers = "Profit";
                //chartPieProfit.DataBind();

                //// Sales Pie chart
                //string sql3 = " select sales_time, SUM(total) as Total from sales_item where sales_time " +
                //                "  like  '%" + date + "%' and status = 1  or status = 3  GROUP BY  sales_time ";
                //DataAccess.ExecuteSQL(sql3);
                //DataTable dt3 = DataAccess.GetDataTable(sql3);
                //chartPieSales.DataSource = dt3;
                //chartPieSales.Visible = true;
                //chartPieSales.Series["Total"].XValueMember = "sales_time";
                //chartPieSales.Series["Total"].YValueMembers = "Total";
                //chartPieSales.DataBind();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //}
        }

        private void dtyearmonth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sql5 = " select sales_time,  SUM(profit * Qty) as Profit from sales_item " +
                               " where sales_time   like  '%" + dtyearmonth.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartbarProfit.DataSource = dt5;
                chartbarProfit.Visible = true;
                chartbarProfit.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartbarProfit.Series["Profit"].XValueMember = "sales_time";
                chartbarProfit.Series["Profit"].YValueMembers = "Profit";
                chartbarProfit.DataBind();



                //string sql2 = "select   SUM(profit * Qty) as Profit, sales_time from sales_item " +
                //                " where sales_time   like  '%" + dtyearmonth.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";

                //DataAccess.ExecuteSQL(sql2);
                //DataTable dt2 = DataAccess.GetDataTable(sql2);
                //chartPieProfit.DataSource = dt2;
                //chartPieProfit.Visible = true;
                //chartPieProfit.Series["Profit"].XValueMember = "sales_time";
                //chartPieProfit.Series["Profit"].YValueMembers = "Profit";
                //chartPieProfit.DataBind();

                //string sql3 = " select sales_time, SUM(total) as Total from sales_item " +
                //                " where sales_time   like  '%" + dtyearmonth.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";

                //DataAccess.ExecuteSQL(sql3);
                //DataTable dt3 = DataAccess.GetDataTable(sql3);
                //chartPieSales.DataSource = dt3;
                //chartPieSales.Visible = true;
                //chartPieSales.Series["Total"].XValueMember = "sales_time";
                //chartPieSales.Series["Total"].YValueMembers = "Total";
                //chartPieSales.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "yyyy-MM-dd";

            DTTO.Format = DateTimePickerFormat.Custom;
            DTTO.CustomFormat = "yyyy-MM-dd";

            try
            {
                string sql5 = " select sales_time,  SUM(profit * Qty) as Profit from sales_item " +
                               " where sales_time   BETWEEN  '" + dtDate.Text + "' AND    '" + DTTO.Text + "' and (status = 1  or status = 3) GROUP BY  sales_time";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartbarProfit.DataSource = dt5;
                chartbarProfit.Visible = true;
                chartbarProfit.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartbarProfit.Series["Profit"].XValueMember = "sales_time";
                chartbarProfit.Series["Profit"].YValueMembers = "Profit";
                chartbarProfit.DataBind();



                //string sql2 = "select   SUM(profit * Qty) as Profit, sales_time from sales_item " +
                //                " where sales_time   like  '%" + dtDate.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";

                //DataAccess.ExecuteSQL(sql2);
                //DataTable dt2 = DataAccess.GetDataTable(sql2);
                //chartPieProfit.DataSource = dt2;
                //chartPieProfit.Visible = true;
                //chartPieProfit.Series["Profit"].XValueMember = "sales_time";
                //chartPieProfit.Series["Profit"].YValueMembers = "Profit";
                //chartPieProfit.DataBind();

                //string sql3 = " select sales_time, SUM(total) as Total from sales_item " +
                //                " where sales_time   like  '%" + dtDate.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";

                //DataAccess.ExecuteSQL(sql3);
                //DataTable dt3 = DataAccess.GetDataTable(sql3);
                //chartPieSales.DataSource = dt3;
                //chartPieSales.Visible = true;
                //chartPieSales.Series["Total"].XValueMember = "sales_time";
                //chartPieSales.Series["Total"].YValueMembers = "Total";
                //chartPieSales.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                //chart1.Dock = DockStyle.Fill;
                //chartPieProfit.Dock = DockStyle.Fill;
                //chartPieSales.Dock = DockStyle.Fill;
                chartbarProfit.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                //chartPieProfit.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                //chartPieSales.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                // Print preview chart

                chartbarProfit.Printing.PrintPreview();
                //chartPieProfit.Printing.PrintPreview();
                //chartPieSales.Printing.PrintPreview();

            }
            catch
            {

            }
        }

    }
}
