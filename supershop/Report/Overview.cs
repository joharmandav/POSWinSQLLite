using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
//using System.Data.SqlClient;
using Finisar.SQLite;

namespace supershop
{
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Overview_Load(object sender, EventArgs e)
        {
            dtyearmonth.Format = DateTimePickerFormat.Custom;
            dtyearmonth.CustomFormat = "yyyy-MM";

            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM");
            try
            {
                //Profit Chart
                string sql5 = " select sales_time, SUM(profit * Qty) as Profit from sales_item " + 
                                " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + date + "%' and status = 1  or status = 3 GROUP BY  sales_time ";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartbarProfit.DataSource = dt5;
                chartbarProfit.Visible = true;
                chartbarProfit.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartbarProfit.Series["Profit"].XValueMember = "sales_time";
                chartbarProfit.Series["Profit"].YValueMembers = "Profit";
                chartbarProfit.DataBind();

                //Profit Pie chart 
                string sql2 = "select  SUM(profit * Qty) as Profit , sales_time from sales_item " +
                            " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + date + "%' and status = 1  or status = 3  GROUP BY  sales_time ";
                DataAccess.ExecuteSQL(sql2);
                DataTable dt2 = DataAccess.GetDataTable(sql2);
                chartPieProfit.DataSource = dt2;
                chartPieProfit.Visible = true;
                chartPieProfit.Series["Profit"].XValueMember = "sales_time";
                chartPieProfit.Series["Profit"].YValueMembers = "Profit";
                chartPieProfit.DataBind();

                // Sales Pie chart
                string sql3 = " select sales_time, SUM(total) as Total from sales_item where TenentID = " + Tenent.TenentID + " and sales_time " +
                                "  like  '%" + date + "%' and status = 1  or status = 3  GROUP BY  sales_time ";
                DataAccess.ExecuteSQL(sql3);
                DataTable dt3 = DataAccess.GetDataTable(sql3);
                chartPieSales.DataSource = dt3;
                chartPieSales.Visible = true;
                chartPieSales.Series["Total"].XValueMember = "sales_time";
                chartPieSales.Series["Total"].YValueMembers = "Total";
                chartPieSales.DataBind();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql5 = " select sales_time,  SUM(profit * Qty) as Profit from sales_item " +
                               " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + dtyearmonth.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartbarProfit.DataSource = dt5;
                chartbarProfit.Visible = true;
                chartbarProfit.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartbarProfit.Series["Profit"].XValueMember = "sales_time";
                chartbarProfit.Series["Profit"].YValueMembers = "Profit";
                chartbarProfit.DataBind();



                string sql2 = "select   SUM(profit * Qty) as Profit, sales_time from sales_item " +
                                " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + dtyearmonth.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";

                DataAccess.ExecuteSQL(sql2);
                DataTable dt2 = DataAccess.GetDataTable(sql2);
                chartPieProfit.DataSource = dt2;
                chartPieProfit.Visible = true;
                chartPieProfit.Series["Profit"].XValueMember = "sales_time";
                chartPieProfit.Series["Profit"].YValueMembers = "Profit";
                chartPieProfit.DataBind();

                string sql3 = " select sales_time, SUM(total) as Total from sales_item " +
                                " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + dtyearmonth.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";

                DataAccess.ExecuteSQL(sql3);
                DataTable dt3 = DataAccess.GetDataTable(sql3);
                chartPieSales.DataSource = dt3;
                chartPieSales.Visible = true;
                chartPieSales.Series["Total"].XValueMember = "sales_time";
                chartPieSales.Series["Total"].YValueMembers = "Total";
                chartPieSales.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string sql3 = "select SUM(Profit)   from sales where sales_time   like  '%" + textBox1.Text + "%'";
                //DataAccess.ExecuteSQL(sql3);
                //DataTable dt3 = DataAccess.GetDataTable(sql3);


                //int pro = Convert.ToInt32(dt3.Rows[0].ItemArray[0].ToString());
                //string pr = Convert.ToString(pro.ToString()); 
                //label1.Text = pr;
                // string sql3 = " Select   rollno as 'Class Roll' , stdname as 'Student Name' , SUM(point)as 'Total Marks',CAST(AVG(gpatb) AS DECIMAL(10,2)) as 'GPA' From markspostdb WHERE  classname ='" + textBox2.Text + "' and section = '" + textBox3.Text + "' and examterm = '" + textBox4.Text + "'  GROUP BY  rollno,stdname   ORDER by SUM(point) DESC ";

                string sql5 = "select sales_time, SUM(profit) as Profit from sales_time where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + dtyearmonth.Text + "%' GROUP BY  sales_time ";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                // string pro = dt5.Rows[0].ItemArray[0].ToString();

                chartbarProfit.DataSource = dt5;
                chartbarProfit.Visible = true;

                chartbarProfit.Series["Profit"].XValueMember = "sales_time";
                chartbarProfit.Series["Profit"].YValueMembers = "Profit";
                chartbarProfit.DataBind();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        private void chart2_Click(object sender, EventArgs e)
        {
            //chart2.Dock = DockStyle.Fill;
        }

        private void chart2_MouseLeave(object sender, EventArgs e)
        {
            chartPieProfit.Dock = DockStyle.None;
            label3.Visible = true;
        }

        private void chart2_MouseHover(object sender, EventArgs e)
        {
            chartPieProfit.Dock = DockStyle.Fill;
            label3.Visible = false;
        }

        private void chart1_MouseHover(object sender, EventArgs e)
        {
            chartbarProfit.Dock = DockStyle.None;
            chartPieProfit.Visible = false;
            chartPieSales.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            chartbarProfit.Dock = DockStyle.None;
            chartPieProfit.Visible = true;
            chartPieSales.Visible = true;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
        }

        private void chart3_MouseHover(object sender, EventArgs e)
        {
            chartPieSales.Dock = DockStyle.Fill;
            chartPieProfit.Visible = false;
            chartbarProfit.Visible = false;
            label2.Visible = false;

        }

        private void chart3_MouseLeave(object sender, EventArgs e)
        {
            chartPieSales.Dock = DockStyle.None;
            chartPieProfit.Visible = true;
            chartbarProfit.Visible = true;
            label2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //chart1.Dock = DockStyle.Fill;
                chartPieProfit.Dock = DockStyle.Fill;
                chartPieSales.Dock = DockStyle.Fill;
                chartbarProfit.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                chartPieProfit.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                chartPieSales.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                // Print preview chart

                chartbarProfit.Printing.PrintPreview();
                chartPieProfit.Printing.PrintPreview();
                chartPieSales.Printing.PrintPreview();

            }
            catch
            {

            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Sale_chart go = new Sale_chart();
            go.MdiParent = this.ParentForm;
            go.Show();

            this.Hide();
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "yyyy-MM-dd";
            try
            {
                string sql5 = " select sales_time,  SUM(profit * Qty) as Profit from sales_item " +
                               " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + dtDate.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartbarProfit.DataSource = dt5;
                chartbarProfit.Visible = true;
                chartbarProfit.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartbarProfit.Series["Profit"].XValueMember = "sales_time";
                chartbarProfit.Series["Profit"].YValueMembers = "Profit";
                chartbarProfit.DataBind();



                string sql2 = "select   SUM(profit * Qty) as Profit, sales_time from sales_item " +
                                " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + dtDate.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";

                DataAccess.ExecuteSQL(sql2);
                DataTable dt2 = DataAccess.GetDataTable(sql2);
                chartPieProfit.DataSource = dt2;
                chartPieProfit.Visible = true;
                chartPieProfit.Series["Profit"].XValueMember = "sales_time";
                chartPieProfit.Series["Profit"].YValueMembers = "Profit";
                chartPieProfit.DataBind();

                string sql3 = " select sales_time, SUM(total) as Total from sales_item " +
                                " where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + dtDate.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";

                DataAccess.ExecuteSQL(sql3);
                DataTable dt3 = DataAccess.GetDataTable(sql3);
                chartPieSales.DataSource = dt3;
                chartPieSales.Visible = true;
                chartPieSales.Series["Total"].XValueMember = "sales_time";
                chartPieSales.Series["Total"].YValueMembers = "Total";
                chartPieSales.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
