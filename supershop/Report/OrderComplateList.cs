﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Report
{
    public partial class OrderComplateList : Form
    {
        public OrderComplateList()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        #region Databind
        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            try
            {
                dtGrdvOrderDetails.EnableHeadersVisualStyles = false;
                dtGrdvOrderDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dtGrdvOrderDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dtGrdvOrderDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Databind();


            }
            catch
            {

            }

        }

        public void Databind()
        {
            DateTime startDate = DateTime.Now;
            Daywice(startDate);
        }
        #endregion


        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtStartDate.Text == "")
            {
                MessageBox.Show("Please Select From Date ");
            }
            else
            {
                try
                {
                    DateTime startDate = Convert.ToDateTime(dtStartDate.Text);

                    Daywice(startDate);

                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        public void Daywice(DateTime startDate)
        {
            string start_Date = startDate.ToString("yyyy-MM-dd");

            dtGrdvOrderDetails.Refresh();
            string sql = " SELECT  si.InvoiceNO as 'Receipt No' ,  si.itemcode,  si.itemName as 'ItemName' , IC.UOMNAME1 as  'UOM'," +
                        "  si.Qty ,   si.Total ,   si.sales_time as 'Date', si.driver, " +
                        " CASE     WHEN si.COD = 0 THEN 'Piad'   WHEN si.COD = '1' THEN 'COD'    END 'COD' ," +
                        " CASE     WHEN si.OrderStutas = 'Paid-Ready to Delivery' THEN 'Pending' WHEN si.OrderStutas = 'Not Paid Ready to Delivery' THEN 'Pending'   WHEN si.OrderStutas = 'Deliverd & Cash Recived' THEN 'Served'  WHEN si.OrderStutas = 'Deliverd' THEN 'Served'  END 'Status'" +
                        "  FROM  sales_item si " +
                        "  left join  sales_payment sp " +
                        "  ON si.sales_id = sp.sales_id and si.TenentID = sp.TenentID " +
                        "  left join purchase p " +
                        " ON p.product_id = si.itemcode and p.TenentID = si.TenentID  " +
                        " left join  tbl_item_uom_price tiu " +
                        " ON tiu.itemID = si.itemcode and tiu.TenentID = si.TenentID  " +
                        " inner Join ICUOM IC ON IC.UOM = si.UOM and IC.TenentID = si.TenentID " +
                        "  where si.status = 1   and  si.Qty != 0 and  si.TenentID=" + Tenent.TenentID + " and si.sales_time Like '%" + start_Date + "%' " +
                        " group by si.sales_id,si.item_id " +
                        "  order by si.InvoiceNO asc ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dtGrdvOrderDetails.DataSource = dt1;
            dtGrdvOrderDetails.DefaultCellStyle.Font = new Font("Times New Roman", 13.0F);
            dtGrdvOrderDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;



        }

        private void txtReciptNO_TextChanged(object sender, EventArgs e)
        {
            if (txtReciptNO.Text == "")
            {
                MessageBox.Show("Please Recipt NO ");
            }
            else
            {
                try
                {
                    dtGrdvOrderDetails.Refresh();
                    string sql = " SELECT  si.InvoiceNO as 'Receipt No' ,  si.itemcode,  si.itemName as 'ItemName' , IC.UOMNAME1 as  'UOM',," +
                                "  si.Qty ,   si.Total ,   si.sales_time as 'Date', si.driver, " +
                                " CASE     WHEN si.COD = 0 THEN 'Piad'   WHEN si.COD = '1' THEN 'COD'    END 'COD' ," +
                                " CASE     WHEN si.OrderStutas = 'Paid-Ready to Delivery' THEN 'Pending' WHEN si.OrderStutas = 'Not Paid Ready to Delivery' THEN 'Pending'  WHEN si.OrderStutas = 'Deliverd & Cash Recived' THEN 'Served'  WHEN si.OrderStutas = 'Deliverd' THEN 'Served'  END 'Status' " +
                                "  FROM  sales_item si " +
                                "  left join  sales_payment sp " +
                                "  ON si.sales_id = sp.sales_id " +
                                "  left join purchase p " +
                                " ON p.product_id = si.itemcode " +
                                " left join  tbl_item_uom_price tiu " +
                                " ON tiu.itemID = si.itemcode " +
                                 " inner Join ICUOM IC ON IC.UOM = si.UOM and IC.TenentID = si.TenentID " +
                                "  where si.status = 1   and  si.Qty != 0 and  si.TenentID=" + Tenent.TenentID + " and si.InvoiceNO like '%" + txtReciptNO.Text + "%'  " +
                                " group by si.sales_id,si.item_id " +
                                "  order by si.InvoiceNO asc ";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    dtGrdvOrderDetails.DataSource = dt1;
                    dtGrdvOrderDetails.DefaultCellStyle.Font = new Font("Times New Roman", 13.0F);
                    dtGrdvOrderDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;

            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in dtGrdvOrderDetails.Columns)
            {
                csv += column.HeaderText + ',';
            }

            //Add new line.
            csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow row in dtGrdvOrderDetails.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Add the Data rows.
                    csv += cell.Value.ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            //Exporting to CSV.
            //  string targetPath = "D:\\";
            string fileName = "Pending_Delivery_Report_" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ".csv";
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location: 
            // Create a new target folder, if necessary. 
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);

            }

            File.WriteAllText(destFile, csv);
            MessageBox.Show(" Successfully Exported !!!  \n Show File in Desktop Name as " + fileName + " ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtGrdvOrderDetails.RowsDefaultCellStyle.BackColor = Color.White;
                this.dtGrdvOrderDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                if (SetupThePrinting())
                {
                    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    // MyPrintPreviewDialog.ClientSize = new System.Drawing.Size(990, 630);
                    MyPrintPreviewDialog.WindowState = FormWindowState.Maximized;
                    MyPrintPreviewDialog.PrintPreviewControl.Zoom = 1.0;
                    // MyPrintPreviewDialog.UseAntiAlias = true;
                    MyPrintPreviewDialog.Document = printDocument1;
                    MyPrintPreviewDialog.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("!!! Please Print Preview or Setup Print only for First time " + exp.Message);
            }
        }

        DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            string sql3 = "select * from tbl_terminallocation where TenentID = " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);
            DateTime dt = DateTime.Now;
            string printdate = dt.ToString("MMMM dd, yyyy    hh:mm:ss tt");
            string Companyname = dt1.Rows[0]["CompanyName"].ToString();
            string branchname = dt1.Rows[0]["Branchname"].ToString();
            string Location = dt1.Rows[0]["Location"].ToString();
            string phone = dt1.Rows[0]["Phone"].ToString();
            string email = dt1.Rows[0]["Email"].ToString();
            string web = dt1.Rows[0]["Web"].ToString();

            string Header = Companyname + "\n" + Location + "." + "\n" + email + "\n" + branchname + " ph: " + phone + "\n" + printdate + "\n";

            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;


            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            printDocument1.DocumentName = "Pending_Delivery_Report_" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ".csv";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(10, 10, 20, 20);

            //  if (MessageBox.Show("Do you want the report to be centered on the page",   "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(dtGrdvOrderDetails,
            printDocument1, true, true, Header + " Pending Delivery Report \n", new Font("Baskerville Old Face", 13, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);


            return true;
        }

    }
}
