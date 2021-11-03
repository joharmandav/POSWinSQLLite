using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace supershop.Items
{
    public partial class Purchase_History : Form
    {
        public Purchase_History()
        {
            InitializeComponent();


            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";

            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";

            dtStartDate.Text = dtStartDate.Value.AddDays(-15).ToShortDateString();
            dtEndDate.Text = dtEndDate.Value.ToShortDateString();
            string dtstart = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
            string dtend = DateTime.Now.ToString("yyyy-MM-dd");


            datagrdpurchasehistory.EnableHeadersVisualStyles = false;
            datagrdpurchasehistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrdpurchasehistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagrdpurchasehistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            BindItem();

            databind(dtstart, dtend);
        }

        public void BindItem()
        {
            comboItem.DataSource = null;
            comboItem.Items.Clear();

            string selected = "All Items";
            string sqlCust = "select (CustItemCode|| ' - '  ||pi.product_name) from purchase pi INNER join tbl_purchase_history phs ON phs.product_id = pi.product_id and  phs.TenentID = pi.TenentID " +
                            " where pi.TenentID = " + Tenent.TenentID + " group by pi.CustItemCode";
            DataAccess.ExecuteSQL(sqlCust);
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            comboItem.Items.Add(selected);
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    comboItem.Items.Add(dtCust.Rows[i][0]);
                }
            }
            comboItem.Text = "All Items";

        }

        public void databind(string dtstartvl, string dtendvl)
        {
            //try
            //{
            //string sql = " select id as ID, purchase_date as 'Date',  product_name as 'Name', msrp as 'Price', OnHand as 'Qty', " +
            //         "  ((msrp * OnHand) * 1.00) as 'Total',  category as 'Category' , supplier , Shopid , ptype as 'Status'  " +
            //         "  from tbl_purchase_history  where purchase_date   BETWEEN '" + dtstartvl + "' AND    '" + dtendvl + "' " +
            //         " and status = 1 Order  by id desc";

            string Selected = comboItem.Text.ToString().Split('-')[0].Trim();

            string Check = "";

            if (Selected == "All Items")
            {

                Check = "select * from tbl_purchase_history where TenentID = " + Tenent.TenentID + " and status = 1";
            }
            else
            {
                Check = " select * from tbl_purchase_history  phs INNER join purchase pi ON pi.product_id = phs.product_id and pi.TenentID = phs.TenentID " +
                        " where pi.TenentID = " + Tenent.TenentID + " and pi.CustItemCode == '" + Selected + "' and phs.status = 1 ";
                        
            }
            DataTable dt = DataAccess.GetDataTable(Check);

            if (dt.Rows.Count < 1)
            {
                return;
            }

            string sql = "";

            if (Selected == "All Items")
            {
                sql = " select phs.id as ID, purchase_date as 'Date', pi.CustItemCode , phs.product_name as 'Name',UOM.UOMNAME1 as 'UOM',phs.product_quantity as 'Qty' ,Cost_price as 'Cost Price',retail_price as 'Retail price', " +
                         " CAT.CAT_NAME1 as 'Category' , Cust.Name as 'supplier' , phs.Shopid , ptype as 'Product Type'  " +
                         " from tbl_purchase_history phs INNER join purchase pi ON pi.product_id = phs.product_id and pi.TenentID = phs.TenentID " +
                         " INNER join CAT_MST CAT ON CAT.CATID = phs.category and CAT.TenentID = phs.TenentID  INNER join ICUOM UOM ON UOM.UOM = phs.UOM and UOM.TenentID = phs.TenentID" +
                         " INNER join tbl_customer Cust ON Cust.ID = phs.supplier and Cust.TenentID = phs.TenentID " +
                         " where pi.TenentID = " + Tenent.TenentID + " and phs.TranStatus = 'Final' and purchase_date   BETWEEN '" + dtstartvl + "' AND    '" + dtendvl + "' " +
                         " and phs.status = 1 Order  by id desc";
            }
            else
            {
                sql = " select phs.id as ID, purchase_date as 'Date', pi.CustItemCode , phs.product_name as 'Name',UOM.UOMNAME1 as 'UOM',phs.product_quantity as 'Qty' ,Cost_price as 'Cost Price',retail_price as 'Retail price', " +
                         " CAT.CAT_NAME1 as 'Category' , Cust.Name as 'supplier' , phs.Shopid , ptype as 'Product Type'  " +
                         " from tbl_purchase_history phs INNER join purchase pi ON pi.product_id = phs.product_id and pi.TenentID = phs.TenentID " +
                         " INNER join CAT_MST CAT ON CAT.CATID = phs.category and CAT.TenentID = phs.TenentID  INNER join ICUOM UOM ON UOM.UOM = phs.UOM and UOM.TenentID = phs.TenentID" +
                         " INNER join tbl_customer Cust ON Cust.ID = phs.supplier and Cust.TenentID = phs.TenentID " +
                         " where pi.TenentID = " + Tenent.TenentID + "  and phs.TranStatus = 'Final' and purchase_date   BETWEEN '" + dtstartvl + "' AND    '" + dtendvl + "' and pi.CustItemCode == '" + Selected + "' " +
                         " and phs.status = 1 Order  by id desc";
            }



            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            datagrdpurchasehistory.DataSource = dt1;

            string sql3 = "";

            if (Selected == "All Items")
            {
                sql3 = " select SUM(phs.product_quantity) as QTY , SUM(Cost_price) AS Price , SUM(retail_price) as msrp " +
                          " from tbl_purchase_history phs INNER join purchase pi ON pi.product_id = phs.product_id and pi.TenentID = phs.TenentID " +
                          " where  pi.TenentID = " + Tenent.TenentID + " and purchase_date   BETWEEN '" + dtstartvl + "' AND    '" + dtendvl + "' " +
                          " and phs.status = 1";
            }
            else
            {
                sql3 = " select SUM(phs.product_quantity) as QTY , SUM(Cost_price) AS Price , SUM(retail_price) as msrp  " +
                          " from tbl_purchase_history phs INNER join purchase pi ON pi.product_id = phs.product_id and pi.TenentID = phs.TenentID " +
                          " where  pi.TenentID = " + Tenent.TenentID + " and purchase_date   BETWEEN '" + dtstartvl + "' AND    '" + dtendvl + "' and pi.CustItemCode == '" + Selected + "' " +
                          " and phs.status = 1";
            }

            DataAccess.ExecuteSQL(sql3);
            DataTable dt3 = DataAccess.GetDataTable(sql3);

            if (dt3.Rows.Count > 0)
            {
                DataRow dr = dt1.NewRow();
                dr[1] = " ";
                dt1.Rows.Add(dr);

                DataRow dr2 = dt1.NewRow();
                dr2[2] = "Total ";
                dr2[5] = dt3.Rows[0]["QTY"] != null ? dt3.Rows[0]["QTY"].ToString() != "" ? Convert.ToDouble(dt3.Rows[0]["QTY"].ToString()) : 0 : 0;
                //dr2[6] = dt3.Rows[0]["Price"] != null ? dt3.Rows[0]["Price"].ToString() != "" ? Convert.ToDouble(dt3.Rows[0]["Price"].ToString()) : 0 : 0;
                //dr2[7] = dt3.Rows[0]["msrp"] != null ? dt3.Rows[0]["msrp"].ToString() != "" ? Convert.ToDouble(dt3.Rows[0]["msrp"].ToString()) : 0 : 0;
                dt1.Rows.Add(dr2);

                DataRow dr7 = dt1.NewRow();
                dr7[1] = " ";
                dt1.Rows.Add(dr7);


                DataRow rep = dt1.NewRow();
                rep[1] = "Purchase Report ";
                dt1.Rows.Add(rep);

                DataRow repdt = dt1.NewRow();
                repdt[1] = "From : ";
                repdt[2] = dtstartvl;
                dt1.Rows.Add(repdt);

                DataRow repdt2 = dt1.NewRow();
                repdt2[1] = "To : ";
                repdt2[2] = dtendvl;
                dt1.Rows.Add(repdt2);
            }
            //}
            //catch
            //{
            //}

        }

        //Filter Date to Date
        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtStartDate.Text != "" && dtEndDate.Text != "")
                databind(dtStartDate.Text, dtEndDate.Text);
        }

        #region Printing
        DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            string sql3 = "select * from tbl_terminalLocation where TenentID = " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            DateTime dt = DateTime.Now;
            string printdate = dt.ToString("MMMM dd, yyyy    hh:mm:ss tt");
            string Companyname = dt1.Rows[0].ItemArray[1].ToString();
            string branchname = dt1.Rows[0].ItemArray[2].ToString();
            string Location = dt1.Rows[0].ItemArray[3].ToString();
            string phone = dt1.Rows[0].ItemArray[4].ToString();
            string email = dt1.Rows[0].ItemArray[5].ToString();
            string web = dt1.Rows[0].ItemArray[6].ToString();

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

            printDocument1.DocumentName = "Purchase Report";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(datagrdpurchasehistory,
            printDocument1, true, true, Header + " Purchase Report \n", new Font("Baskerville Old Face", 14,
            FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);


            return true;
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.datagrdpurchasehistory.RowsDefaultCellStyle.BackColor = Color.White;
                this.datagrdpurchasehistory.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                if (SetupThePrinting())
                {
                    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    MyPrintPreviewDialog.WindowState = FormWindowState.Maximized;
                    MyPrintPreviewDialog.PrintPreviewControl.Zoom = 1.0;
                    MyPrintPreviewDialog.Document = printDocument1;
                    MyPrintPreviewDialog.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("!!! Please Print Preview or Setup Print only for First time " + exp.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }
        #endregion

        private void datagrdpurchasehistory_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch
            {

            }
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboItem.Text != "")
            {
                if (dtStartDate.Text != "" && dtEndDate.Text != "")
                    databind(dtStartDate.Text, dtEndDate.Text);
            }
        }

        private void btnrefrash_Click(object sender, EventArgs e)
        {
            if (dtStartDate.Text != "" && dtEndDate.Text != "")
                databind(dtStartDate.Text, dtEndDate.Text);
        }
    }
}
