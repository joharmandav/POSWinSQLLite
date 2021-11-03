﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace supershop.Report
{
    public partial class Top10Product : Form
    {
        public Top10Product()
        {
            InitializeComponent();
            ComboLimit.Text = "10";
        }

        private void TopSales_Load(object sender, EventArgs e)
        {
            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";
            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";

            dtStartDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");

            BindData();
        }

        public string ReportName
        {
            set
            {
                lblReportName.Text = value;
            }
            get
            {
                return lblReportName.Text;
            }
        }

        public string Limit
        {
            set
            {
                lblLimit.Text = value;
            }
            get
            {
                return lblLimit.Text;
            }
        }

        public string OrderBY
        {
            set
            {
                lblorderby.Text = value;
            }
            get
            {
                return lblorderby.Text;
            }
        }

        public void BindData()
        {
            try
            {
                // Sales Pie chart by QTY
                string sql3 = " select   itemName  as 'Name'   , SUM(Qty)   as 'QTY' from sales_item " +
                              " where Tenentid=" + Tenent.TenentID + " and sales_time   between  '" + dtStartDate.Text + "'  and '" + dtEndDate.Text + "'  and status = 1  or status = 3 " +
                              " GROUP BY    itemName order by  Qty " + lblorderby.Text + " limit '" + lblLimit.Text + "' ";
                DataAccess.ExecuteSQL(sql3);
                DataTable dt3 = DataAccess.GetDataTable(sql3);
                chartPieSales.DataSource = dt3;
                // chartPieSales.ChartAreas[0].AxisY.LabelStyle.Angle = -45;
                chartPieSales.Series["Total"].XValueMember = "Name";
                chartPieSales.Series["Total"].YValueMembers = "QTY";
                chartPieSales.DataBind();
                datagrdReportDetails.DataSource = dt3;

                DataRow dr = dt3.NewRow();
                dr[0] = " ";
                dt3.Rows.Add(dr);

                DataRow dr2 = dt3.NewRow();
                dr2[0] = "Top 10 Sold items by QTY";
                dt3.Rows.Add(dr2);


                // Sales Pie chart by Sales value
                string sqlSvalue = " select    itemName  as 'Name'  , SUM(Total) as 'Total' from sales_item " +
                                    "where Tenentid=" + Tenent.TenentID + " and sales_time    between  '" + dtStartDate.Text + "'  and '" + dtEndDate.Text + "'  and status = 1   or status = 3  " +
                                    " GROUP BY    itemName order by  Total  " + lblorderby.Text + " limit '" + lblLimit.Text + "' ";
                DataAccess.ExecuteSQL(sqlSvalue);
                DataTable dtSvalue = DataAccess.GetDataTable(sqlSvalue);
                chartSalesValue.DataSource = dtSvalue;
                chartSalesValue.Series["Salevaule"].XValueMember = "Name";
                chartSalesValue.Series["Salevaule"].YValueMembers = "Total";
                chartSalesValue.DataBind();


                DataRow drSvalue = dtSvalue.NewRow();
                dr[0] = " ";
                dtSvalue.Rows.Add(drSvalue);

                DataRow drSvalue2 = dtSvalue.NewRow();
                drSvalue2[0] = "Top 10 Sold items by Value";
                dtSvalue.Rows.Add(drSvalue2);
                datagrdSalesvalue.DataSource = dtSvalue;
            }
            catch //(Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }

        private void dtyearmonth_ValueChanged(object sender, EventArgs e)
        {
            BindData();
        }

            //declare event handler for printing in constructor
      //  printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);

        //Rest of the code
        Bitmap MemoryImage;
        public void GetPrintArea(Panel panel1)
        {
            MemoryImage = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(MemoryImage, new Rectangle(0, 0, panel1.Width, panel1.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           // panel1.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
            Rectangle pagearea = e.PageBounds;
           e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
          //  panel1.DrawToBitmap(MemoryImage, new Rectangle(0, 0, panel1.Width, panel1.Height));
   
        }
        public void Print(Panel panel1)
        {
          //  pannel = panel1;
            GetPrintArea(panel1);

            PaperSize paperSize = new PaperSize("My Envelope", 680, 1350);
            paperSize.RawKind = (int)PaperKind.Custom;

           

            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.Margins = new Margins(0, 0, 10, 0);

            
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DocumentName = "Top " + lblLimit.Text + " Product Report" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
            printPreviewDialog1.ShowDialog();             
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(this.panel1);
        }

        private void ComboLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboLimit.Text != "" && ComboLimit.Text != "System.Data.DataRowView")
            {
                lblLimit.Text = ComboLimit.Text;
                BindData();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DashBoard"] != null)
            {
                DashBoard go = (DashBoard)Application.OpenForms["DashBoard"];
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent]; ;
                go.Show();
            }
            else
            {
                DashBoard go = new DashBoard();
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent]; ;
                go.Show();
            }
            this.Close();
        }

    
    }
}
