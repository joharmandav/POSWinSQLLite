using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using supershop.Report;

namespace supershop
{
    public partial class salesreport : Form
    {
        public salesreport()
        {
            InitializeComponent();

            string Path = UserInfo.LOGO;
            if (File.Exists(Path))
            {
                pictureLogo.Image = Image.FromFile(Path);
            }
            else
            {
                Path = Application.StartupPath + @"\LOGO\POS53.png";
                pictureLogo.Image = Image.FromFile(Path);
            }


        }

        DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            string sql3 = "select * from tbl_terminallocation where TenentID = " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
            DataTable dt1 = DataAccess.GetDataTable(sql3);
            DateTime dt = DateTime.Now;
            string printdate = dt.ToString("MMMM dd, yyyy    HH:mm:ss tt");
            string Companyname = dt1.Rows[0]["CompanyName"].ToString();
            string branchname = dt1.Rows[0]["Branchname"].ToString();
            string Location = dt1.Rows[0]["Location"].ToString();
            string phone = dt1.Rows[0]["Phone"].ToString();
            string email = dt1.Rows[0]["Email"].ToString();
            string web = dt1.Rows[0]["Web"].ToString();
            string Reportname = lblReportName.Text;
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

            printDocument1.DocumentName = Reportname.Replace(' ', '_') + "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".csv";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(10, 10, 20, 20);

            //  if (MessageBox.Show("Do you want the report to be centered on the page",   "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(dtgrdViewSalesReport,
            printDocument1, true, true, Header + " " + Reportname + " \n", new Font("Baskerville Old Face", 13, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);


            //else

            //    MyDataGridViewPrinter = new DataGridViewPrinter(dtgrdViewSalesReport,
            //    printDocument1, false, true, Header + "   Sales Report   \n", new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        // Daily payment Report with retun item

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);

            //this.dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            //e.Graphics.DrawImage(bm, 0, 0);

            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        public void Dateformat()
        {
            dateFrom.Format = DateTimePickerFormat.Custom;
            dateFrom.CustomFormat = "yyyy-MM-dd";

            dateTO.Format = DateTimePickerFormat.Custom;
            dateTO.CustomFormat = "yyyy-MM-dd";

            DateTime dt = DateTime.Now;
        }

        bool FirstTime;

        private void salesreport_Load(object sender, EventArgs e)
        {
            FirstTime = true;
            Dateformat();
            dtgrdViewSalesReport.EnableHeadersVisualStyles = false;
            dtgrdViewSalesReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgrdViewSalesReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgrdViewSalesReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            Bind_Customer();
            Bind_salesMen();
            Bind_Product();
            Bind_Catagory();
            bindOrderWay();

            FirstTime = false;
            isreturn = false;
            lbleventname.Text = "DttodPaymentReport";
            //DttodPaymentReport();
            //lbleventname.Text = "DatoDateSalesReport";
            //DatoDateSalesReport();
        }

        public string OrderWay
        {
            set
            {
                comboOrderWay.Text = value;
            }
            get
            {
                return comboOrderWay.Text;
            }
        }

        public void bindOrderWay()
        {
            comboOrderWay.DataSource = null;
            comboOrderWay.Items.Clear();

            string sqlCust = "select OrderWay from sales_item Where TenentID = " + Tenent.TenentID + " group by OrderWay ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            comboOrderWay.Items.Add("-–None--");
            comboOrderWay.Items.Add("All Order Way");
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    comboOrderWay.Items.Add(dtCust.Rows[i][0]);
                }
            }
            comboOrderWay.Text = "-–None--";

        }

        public string Customer
        {
            set
            {
                ComboCustomer.Text = value;
            }
            get
            {
                return ComboCustomer.Text;
            }
        }

        public void Bind_Customer()
        {
            //Customer Databind 
            string sqlCust = "select ID,name from  tbl_customer where PeopleType='Customer' and TenentID=" + Tenent.TenentID + " ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            //  ComboCustomer.Items.Add("-–None--");
            // ComboCustomer.Items.Add("All Customer");
            //  if (dtCust.Rows.Count > 0)
            //  {
            //      for (int i = 0; i < dtCust.Rows.Count; i++)
            //      {
            //          ComboCustomer.Items.Add(dtCust.Rows[i][0]);
            //      }
            //  }
            //  ComboCustomer.Text = "-–None--";
            ComboCustomer.DataSource = dtCust;
            ComboCustomer.DisplayMember = "name";
            ComboCustomer.ValueMember = "ID";

            //ComboCustomer.DataSource = dtCust;
            //ComboCustomer.DisplayMember = "Customer";
        }

        public string salesMen
        {
            set
            {
                comboSalesman.Text = value;
            }
            get
            {
                return comboSalesman.Text;
            }
        }

        public void Bind_salesMen()
        {
            //Customer Databind 
            string sqlCust = "select distinct SoldBy From sales_item where TenentID = " + Tenent.TenentID + " ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            comboSalesman.Items.Add("-–None--");
            comboSalesman.Items.Add("All SalesMan");
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    comboSalesman.Items.Add(dtCust.Rows[i][0]);
                }
            }
            comboSalesman.Text = "-–None--";

            //comboSalesman.DataSource = dtCust;
            //comboSalesman.DisplayMember = "SoldBy";
        }

        public string ItemName
        {
            set
            {
                comboItem.Text = value;
            }
            get
            {
                return comboItem.Text;
            }
        }

        public void Bind_Product()
        {
            //Customer Databind 
            string sqlCust = "select distinct itemname From sales_item where TenentID=" + Tenent.TenentID + " and Deleted <> 1 ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            comboItem.Items.Add("-–None--");
            comboItem.Items.Add("All items");
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    comboItem.Items.Add(dtCust.Rows[i][0]);
                }
            }
            comboItem.Text = "-–None--";

            //comboItem.DataSource = dtCust;
            //comboItem.DisplayMember = "itemname";
        }

        public string setcategory
        {
            set
            {
                comboCatagory.Text = value;
            }
            get
            {
                return comboCatagory.Text;
            }
        }

        public void Bind_Catagory()
        {
            string sqlCust = "select * From CAT_MST Where TenentID = " + Tenent.TenentID + " ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            comboCatagory.Items.Add("-–None--");
            comboCatagory.Items.Add("All category");
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    comboCatagory.Items.Add(dtCust.Rows[i]["CAT_NAME1"]);
                }
            }
            comboCatagory.Text = "-–None--";

            //comboCatagory.DataSource = dtCust;
            //comboCatagory.DisplayMember = "category";
        }

        // Search by Sales ID/ Invoice No , Item Name

        public void ItemSearchBox()
        {
            if (txtItemSearchBox.Text == "")
            {
                //MessageBox.Show("Please Type product Name");
            }
            else
            {
                try
                {
                    string sql = "select  InvoiceNO as 'Inv #' , sales_time as Date, item_id as 'Item ID', itemName as 'Item Name' , " +
                                 " RetailsPrice as 'Retails Price' ,Qty as 'QTY' , Total as '-Total-',  profit * Qty as 'Profit'  " +
                                 " from sales_item where TenentID = " + Tenent.TenentID + " and Deleted <> 1 and  itemName   like  '%" + txtItemSearchBox.Text + "%' " +
                                 " or InvoiceNO Like  '%" + txtItemSearchBox.Text + "%' " +
                                 " and (status = 1 or status = 3)  order by sales_time";

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    dtgrdViewSalesReport.DataSource = dt1;
                    dtgrdViewSalesReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //dtgrdViewSalesReport.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                }
                catch
                {
                    //MessageBox.Show("Sorry\r\n" + exp.Message);
                }
            }
        }
        private void txtItemSearchBox_TextChanged(object sender, EventArgs e)  // /Product name 
        {
            lbleventname.Text = "ItemSearchBox";
            ItemSearchBox();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtgrdViewSalesReport.RowsDefaultCellStyle.BackColor = Color.White;
                this.dtgrdViewSalesReport.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

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

        public void DatoDateSalesReport()
        {
            if (dateTO.Text == "")
            {

                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {
                    lblReportName.Text = "Item Wise Report ";

                    dtgrdViewSalesReport.Columns.Clear();

                    string sql = " select  sales_item.InvoiceNO as 'Inv #' ," +
                                  " sales_item.sales_time as 'Date' ," +
                                  "  itemName as 'Item Description'," +
                                  " ICUOM.UOMNAME1 as 'UOM', " +
                                 " printf('%.3f',RetailsPrice)  as 'Unit Sale Price'," +
                                 " Qty, printf('%.3f',sales_item.Total) as 'Total Sale Price'," +
                                  " printf('%.3f',sales_item.discount) as 'Discount'," +
                        // " case when sales_payment.dis is not null Then sales_payment.dis when sales_payment.dis is null then '0.0'  End 'Dis' ," +
                                 "printf('%.3f',((Qty * RetailsPrice)- sales_item.discount)) as 'Balance' ," +
                                 " printf('%.3f',((profit * Qty) * 1.00)) as 'Profit'   , " +
                                 "  sales_item.Customer as 'Customer' " +
                                 " from sales_item INNER JOIN ICUOM ON ICUOM.UOM = sales_item.UOM and ICUOM.TenentID = sales_item.TenentID " +
                                 " Left Join sales_payment ON sales_item.TenentID = sales_payment.TenentID and sales_item.sales_id = sales_payment.sales_id and sales_payment.Deleted <> 1 " +
                                 " where sales_item.TenentID = " + Tenent.TenentID + " and sales_item.Deleted <> 1 and sales_item.sales_time BETWEEN '" + dateFrom.Text + "' AND    '" + dateTO.Text + "' " +
                                 " and status != 2  Order  by sales_item.sales_time, sales_item.InvoiceNO";//yogesh

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    dtgrdViewSalesReport.DataSource = dt1;
                    dtgrdViewSalesReport.DefaultCellStyle.Font = new Font("Trebuchet MS", 12.0F);
                    dtgrdViewSalesReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //dtgrdViewSalesReport.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;




                    decimal sumSubTotal = 0, SumDic = 0, sumBalance = 0, SumProfit = 0;
                    for (int i = 0; i < dtgrdViewSalesReport.Rows.Count; ++i)
                    {
                        sumSubTotal += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[6].Value);
                        SumDic += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[7].Value);
                        sumBalance += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[8].Value);
                        SumProfit += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[9].Value);
                    }
                    //string Sql4 = " select  SUM(dis) as dis  from sales_payment  " +
                    //              " where TenentID = " + Tenent.TenentID + " and sales_time BETWEEN '" + dateFrom.Text + "' AND    '" + dateTO.Text + "'  Order  by sales_time ";//yogesh
                    // DataTable dt4 = DataAccess.GetDataTable(Sql4);


                    //DataRow drTotal = dt1.NewRow();
                    //drTotal[0] = "Total ";
                    //drTotal[5] = Qty;
                    //drTotal[6] = Total;
                    //drTotal[7] = Dis;
                    //drTotal[8] = AfterDisTotal;
                    //drTotal[9] = Profit;
                    //dt1.Rows.Add(drTotal);


                    DataRow dr = dt1.NewRow();
                    dr[1] = " ";
                    dt1.Rows.Add(dr);

                    /// Sub total = total - Discount
                    DataRow dr2 = dt1.NewRow();
                    dr2[1] = "Total Sale :";
                    dr2[2] = sumSubTotal.ToString("N3");
                    // dr2[4] = dt3.Rows[0].ItemArray[2].ToString();
                    dt1.Rows.Add(dr2);

                    DataRow discount = dt1.NewRow();
                    discount[1] = "(-)Discount :";
                    discount[2] = SumDic.ToString("N3");
                    dt1.Rows.Add(discount);


                    DataRow Balance = dt1.NewRow();
                    Balance[1] = "Balance :";
                    Balance[2] = sumBalance.ToString("N3");
                    dt1.Rows.Add(Balance);

                    DataRow Profit = dt1.NewRow();
                    Profit[1] = "Profit :";
                    Profit[2] = SumProfit.ToString("N3");
                    dt1.Rows.Add(Profit);

                    DataRow dr17 = dt1.NewRow();
                    dr17[1] = " ";
                    dt1.Rows.Add(dr17);



                    DataRow rep = dt1.NewRow();
                    rep[1] = "Item Wise Report  ";
                    rep[2] = dateFrom.Text;
                    rep[3] = dateTO.Text;
                    dt1.Rows.Add(rep);
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        private void DatetoDateSalesReport_Click(object sender, EventArgs e)
        {
            if (FirstTime == false)
            {
                isreturn = false;
                lbleventname.Text = "DatoDateSalesReport";
                DatoDateSalesReport();
            }
        }

        public void DttodPaymentReport()
        {
            if (dateTO.Text == "")
            {

                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {
                    DateTime end = Convert.ToDateTime(dateTO.Text);
                    //end = end.AddDays(1);

                    string EndDate = end.ToString("yyyy-MM-dd");

                    lblReportName.Text = "Sales Cash Report ";
                    dtgrdViewSalesReport.Refresh();
                    string sql = "select  sales_item.InvoiceNO as 'Invoice NO' ,sales_item.sales_time as 'Date' ," +
  "CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' ," +
  "printf('%.3f',(SUM(total))) as 'InvoiceAmount'," +
  "printf('%.3f',(SUM(discount))) as 'Discount'," +
  "printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Balance'  ," +
  "case WHEN sales_item.PaymentMode = 'COD' THEN 'COD' WHEN sales_item.PaymentMode = 'Advance' THEN 'Advance' WHEN sales_item.PaymentMode = 'PriPaid' THEN 'Pre Paid' WHEN sales_item.PaymentMode = 'Credit' THEN 'Credit'  WHEN sales_item.PaymentMode = 'Booking' THEN 'Booking' END 'PaymentMode' ," +
  "Remarks as 'Comment'  " +
  "from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID  and sales_item.PaymentMode <> 'Draft'" +
  "where sales_item.TenentID = " + Tenent.TenentID + " and  sales_item.sales_time between '" + dateFrom.Text + "' AND    '" + EndDate + "' and sales_item.Deleted <> 1  and sales_item.PaymentMode <> 'Draft' " +
  "group by sales_item.sales_id order by sales_item.sales_time";

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    dtgrdViewSalesReport.DataSource = dt1;
                    dtgrdViewSalesReport.DefaultCellStyle.Font = new Font("Times New Roman", 8.5F);
                    decimal sumSubTotal = 0, SumDic = 0, sumBalance = 0;
                    for (int i = 0; i < dtgrdViewSalesReport.Rows.Count; ++i)
                    {
                        sumSubTotal += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[3].Value);
                        SumDic += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[4].Value);
                        sumBalance += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[5].Value);
                    }
                 
                    DataRow dr = dt1.NewRow();
                    dr[1] = " ";
                    dt1.Rows.Add(dr);

                    /// Sub total = total - Discount
                    DataRow dr2 = dt1.NewRow();
                    dr2[1] = "Total Sale :";
                    dr2[2] = sumSubTotal.ToString();
                    // dr2[4] = dt3.Rows[0].ItemArray[2].ToString();
                    dt1.Rows.Add(dr2);

                    DataRow discount = dt1.NewRow();
                    discount[1] = "(-)Discount :";
                    discount[2] = SumDic.ToString();
                    dt1.Rows.Add(discount);


                    DataRow profit = dt1.NewRow();
                    profit[1] = "Balance :";
                    profit[2] = sumBalance.ToString();
                    dt1.Rows.Add(profit);

                    DataRow dr17 = dt1.NewRow();
                    dr17[1] = " ";
                    dt1.Rows.Add(dr17);



                    DataRow rep = dt1.NewRow();
                    rep[1] = "Sales Cash Report  ";
                    rep[3] = dateFrom.Text;
                    rep[4] = EndDate.ToString();
                    dt1.Rows.Add(rep);
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date"); dateFrom.Text + "'  AND    '" + EndDate
                }
            }
        }

        private void DtodPaymentReport_Click(object sender, EventArgs e)
        {
            if (FirstTime == false)
            {
                isreturn = false;
                lbleventname.Text = "DttodPaymentReport";
                DttodPaymentReport();
            }
        }


        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch
            {

            }

        }
        bool isreturn = false;
        public void ReturnReport()
        {
            if (dateTO.Text == "")
            {

                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {
                    DateTime end = Convert.ToDateTime(dateTO.Text);
                    //end = end.AddDays(1);

                    string EndDate = end.ToString("yyyy-MM-dd");

                    lblReportName.Text = "Return Report";

                    dtgrdViewSalesReport.Refresh();
                    string sql = "select  return_time as 'Date' , itemName as 'itemName',UOM, sum(RetailsPrice)  as 'Price', Sum(Qty) as Qty,  (sum(RetailsPrice))*(Sum(Qty)) as Total , Customer as 'Customer', " +
                                " SoldInvoiceNo as 'Inv #' , emp as 'Return by',return_id  from return_item where TenentID = " + Tenent.TenentID + " and  return_time " +
                                " BETWEEN '" + dateFrom.Text + "' AND    '" + EndDate + "' group by SoldInvoiceNo,item_id,UOM,BatchNO Order  by return_time";

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    dtgrdViewSalesReport.DataSource = dt1;
                    dtgrdViewSalesReport.DefaultCellStyle.Font = new Font("Times New Roman", 13.0F);
                    dtgrdViewSalesReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtgrdViewSalesReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //dtgrdViewSalesReport.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //dtgrdViewSalesReport.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //dtgrdViewSalesReport.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //dtgrdViewSalesReport.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;



                    string sql3 = "select Sum(Qty) as Qty, SUM(Total) as Total, SUM(disamt) as Discount , SUM(vatamt) as vat from return_item " +
                                  " where TenentID = " + Tenent.TenentID + " and return_time  BETWEEN '" + dateFrom.Text + "' AND    '" + EndDate + "' ";

                    DataTable dt3 = DataAccess.GetDataTable(sql3);

                    DataRow dr = dt1.NewRow();
                    dr[0] = " ";
                    dt1.Rows.Add(dr);

                    if (dt3.Rows.Count > 0)
                    {

                        DataRow dr4 = dt1.NewRow();
                        dr4[0] = "Total  :";
                        dr4[4] = Convert.ToInt32(dt3.Rows[0].ItemArray[0].ToString());
                        dr4[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                        dt1.Rows.Add(dr4);

                        //DataRow dr6 = dt1.NewRow();
                        //dr6[0] = " ";
                        //dt1.Rows.Add(dr6);

                        DataRow dr5 = dt1.NewRow();
                        dr5[0] = "Total Discount :";
                        dr5[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                        dt1.Rows.Add(dr5);

                        DataRow drvat = dt1.NewRow();
                        drvat[0] = "Total TAX :";
                        drvat[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                        dt1.Rows.Add(drvat);

                        DataRow drtotalreturned = dt1.NewRow();
                        drtotalreturned[0] = "Total Returned :";
                        drtotalreturned[5] = (Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString())) + Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                        dt1.Rows.Add(drtotalreturned);

                        DataRow dr7 = dt1.NewRow();
                        dr7[0] = " ";
                        dt1.Rows.Add(dr7);

                        DataRow rep = dt1.NewRow();
                        rep[0] = "Sales From ";
                        rep[1] = "Sales To ";
                        dt1.Rows.Add(rep);

                        DataRow repdt = dt1.NewRow();
                        repdt[0] = dateFrom.Text;
                        repdt[1] = dateTO.Text;
                        dt1.Rows.Add(repdt);
                        isreturn = true;
                    }
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }
        private void btnReturnReport_Click(object sender, EventArgs e)
        {
            if (FirstTime == false)
            {
                lbleventname.Text = "ReturnReport";
                ReturnReport();
            }
        }


        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            // saveFileDialog1.Title = "Save text Files";
            // saveFileDialog1.CheckFileExists = true;
            // saveFileDialog1.CheckPathExists = true;
            //// saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.FileName = "SalesReport_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".csv";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;

            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in dtgrdViewSalesReport.Columns)
            {
                csv += column.HeaderText + ',';
            }

            //Add new line.
            csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow row in dtgrdViewSalesReport.Rows)
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
            string fileName = "SalesReport_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".csv";
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location: 
            // Create a new target folder, if necessary. 
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);

            }

            // Get file name.
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, csv);
            //  MessageBox.Show(" Successfully Exported !!! ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public int GetCatID(string CAT_NAME1)
        {
            int CATID = 0;
            string sql5 = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " and CAT_NAME1 = '" + CAT_NAME1 + "' ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5 != null)
            {
                if (dt5.Rows.Count > 0)
                {
                    CATID = Convert.ToInt32(dt5.Rows[0]["CATID"]);
                }
            }
            return CATID;
        }

        public void prisatdis()
        {
            try
            {
                lblReportName.Text = "Cash Sales Report  ";

                dtgrdViewSalesReport.Columns.Clear();

                string sql = " select  si.InvoiceNO as 'Inv #' , si.sales_time as 'Date' , si.itemName as 'Item Name',IC.UOMNAME1 as 'UOM', si.RetailsPrice  as 'Price', si.Qty,  Total, " +
                             "  ((si.profit * si.Qty) * 1.00) as 'Profit'   , si.discount as 'Dis %', " +
                             "  si.Customer " +
                             "  from sales_item si Inner join ICUOM IC on IC.UOM = si.UOM and IC.TenentID = si.TenentID " +
                             "  where si.TenentID = " + Tenent.TenentID + " and si.sales_time BETWEEN '" + dateFrom.Text + "'  AND    '" + dateTO.Text + "' " +
                             "  and si.Deleted <> 1 and si.status != 2   and si.discount!=0 " +
                             " group by si.InvoiceNO,si.itemName,si.UOM " +
                             "  Order  by si.sales_time ";

                DataTable dt1 = DataAccess.GetDataTable(sql);
                dtgrdViewSalesReport.DataSource = dt1;
                dtgrdViewSalesReport.DefaultCellStyle.Font = new Font("Trebuchet MS", 12.0F);
                dtgrdViewSalesReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dtgrdViewSalesReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //dtgrdViewSalesReport.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //dtgrdViewSalesReport.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //dtgrdViewSalesReport.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //dtgrdViewSalesReport.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                string sql3 = " select SUM(si.Total) , SUM(si.profit * si.Qty) as Profit , SUM(si.discount),SUM(si.QTY) " +
                              " from sales_item si " +
                              " where  si.TenentID = " + Tenent.TenentID + "  and si.Deleted <> 1 and si.sales_time BETWEEN '" + dateFrom.Text + "' AND    '" + dateTO.Text + "' " +

                              " and si.status != 2 and si.discount!=0 Order  by si.sales_time";

                DataTable dt3 = DataAccess.GetDataTable(sql3);

                DataRow drfirst = dt1.NewRow();
                drfirst[0] = " ";
                dt1.Rows.Add(drfirst);


                DataRow drTotal = dt1.NewRow();
                drTotal[0] = "Total ";
                drTotal[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                drTotal[6] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                dt1.Rows.Add(drTotal);


                DataRow dr = dt1.NewRow();
                dr[0] = " ";
                dt1.Rows.Add(dr);

                DataRow dr6 = dt1.NewRow();
                dr6[0] = " ";
                dt1.Rows.Add(dr6);

                //Totla Profit
                DataRow dr5 = dt1.NewRow();
                dr5[0] = "Total Profit :";
                dr5[7] = Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString()); //Convert.ToDouble(sum.ToString()); //
                dt1.Rows.Add(dr5);

                DataRow dr7 = dt1.NewRow();
                dr7[0] = "______ ";
                dt1.Rows.Add(dr7);

                DataRow rep = dt1.NewRow();
                rep[0] = "Sales From ";
                rep[1] = "Sales To ";
                dt1.Rows.Add(rep);

                DataRow repdt = dt1.NewRow();
                repdt[0] = dateFrom.Text;
                repdt[1] = dateTO.Text;
                dt1.Rows.Add(repdt);
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        private void btnprisatdis_Click(object sender, EventArgs e)
        {
            if (FirstTime == false)
            {
                isreturn = false;
                lbleventname.Text = "prisatdis";
                prisatdis();
            }
        }

        private void dtgrdViewSalesReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dtgrdViewSalesReport.Rows[e.RowIndex];
                string id = row.Cells[1].Value.ToString();
                if (isreturn)
                {

                    string rid = row.Cells["return_id"].Value.ToString();
                    parameter.autoprintid = "1";
                    ReturnPrintRpt go = new ReturnPrintRpt(rid);
                    go.ShowDialog();
                }
                if (id != "")
                {
                    string sql = "select  InvoiceNO as 'Inv #' , SaleDt as Date , sum(payment_amount) as Total , emp_id as 'Sold by',  " +
                                    " sum(dis) as Discount , sum(vat) as TAX ,sum(change_amount) as 'changeamount',sum(due_amount) as Due,Comment as Comments " +
                                    " from sales_payment where TenentID = " + Tenent.TenentID + " and sales_payment.Deleted <> 1 and   InvoiceNO='" + id + "' and PaymentStutas='Success' group by sales_id order by sales_time";

                    DataTable dt1 = DataAccess.GetDataTable(sql);

                    double Payamt = 0;
                    double vat = 0;
                    double subtotal = 0;
                    double dis = 0;
                    double Change = 0;
                    double Due = 0;
                    string Comments = "";


                    if (dt1.Rows.Count > 0)
                    {
                        Payamt = Convert.ToDouble(dt1.Rows[0]["Total"].ToString());
                        vat = Convert.ToDouble(dt1.Rows[0]["TAX"].ToString());
                        Change = Convert.ToDouble(dt1.Rows[0]["changeamount"].ToString());
                        Due = Convert.ToDouble(dt1.Rows[0]["Due"].ToString());

                        subtotal = Convert.ToDouble(dt1.Rows[0]["Total"].ToString()) - Convert.ToDouble(vat) - Convert.ToDouble(Change);
                        dis = Convert.ToDouble(dt1.Rows[0]["Discount"].ToString());
                        Comments = dt1.Rows[0]["Comments"].ToString();
                    }
                    string salesID = ShortCutReport.GetSalesID(id);

                    if (salesID == "")
                    {
                        return;
                    }



                    if (Comments == "Invoice")
                    {
                        // Inventory.InvoicePrint go = new Inventory.InvoicePrint(id);
                        View_Sales_invoice go = new View_Sales_invoice(id);
                        go.ShowDialog();
                    }
                    else
                    {
                        SalesDetails go = new SalesDetails(id, dis, subtotal, vat, Payamt, Change, Due, salesID);
                        go.ShowDialog();
                    }
                }


            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        public void Refrash()
        {
            if (FirstTime == false)
            {
                if (lbleventname.Text == "DatoDateSalesReport")
                {
                    DatoDateSalesReport();
                }
                else if (lbleventname.Text == "DttodPaymentReport")
                {
                    DttodPaymentReport();
                }
                else if (lbleventname.Text == "ReturnReport")
                {
                    ReturnReport();
                }
                else if (lbleventname.Text == "ReturnReport")
                {
                    ReturnReport();
                }
                else if (lbleventname.Text == "prisatdis")
                {
                    prisatdis();
                }
                else if (lbleventname.Text == "ItemSearchBox")
                {
                    ItemSearchBox();
                }
                else
                {

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ISrun = backSyncro.isRun;
            if (ISrun != true)
            {
              //  Refrash();
            }
        }

        private void btnRefrash_Click(object sender, EventArgs e)
        {
            bool ISrun = backSyncro.isRun;
            if (ISrun != true)
            {
                Refrash();
            }
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            bool ISrun = backSyncro.isRun;
            if (ISrun != true)
            {
                Refrash();
            }
        }

        private void LinkSalesByItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["ItemSearch"] != null)
            {
                Application.OpenForms["ItemSearch"].Close();
            }
            this.Refresh();

            ItemSearch go = new ItemSearch();
            go.PageName = "salesreport";
            go.Show();
        }

        private void linkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["CatagorySearch"] != null)
            {
                Application.OpenForms["CatagorySearch"].Close();
            }
            this.Refresh();

            CatagorySearch go = new CatagorySearch();
            go.PageName = "salesreport";
            go.Show();
        }

        private void linksalesman_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["SalesMenSearch"] != null)
            {
                Application.OpenForms["SalesMenSearch"].Close();
            }
            this.Refresh();

            SalesMenSearch go = new SalesMenSearch();
            go.PageName = "salesreport";
            go.Show();
        }

        private void linkOrderWay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["OrderwaySearch"] != null)
            {
                Application.OpenForms["OrderwaySearch"].Close();
            }
            this.Refresh();

            OrderwaySearch go = new OrderwaySearch();
            go.PageName = "salesreport";
            go.Show();
        }

        private void linkcustomersearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["ReportCustomerSearch"] != null)
            {
                Application.OpenForms["ReportCustomerSearch"].Close();
            }
            this.Refresh();

            ReportCustomerSearch go = new ReportCustomerSearch();
            go.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            isreturn = false;
            string SCustname = ComboCustomer.Text != "All Customer" && ComboCustomer.Text != "-–None--" ? ComboCustomer.Text : "";
            string SItemName = comboItem.Text != "All items" && comboItem.Text != "-–None--" ? comboItem.Text : "";
            string SCategory = comboCatagory.Text != "All category" && comboCatagory.Text != "-–None--" ? comboCatagory.Text : "";
            string SSalesman = comboSalesman.Text != "All SalesMan" && comboSalesman.Text != "-–None--" ? comboSalesman.Text : "";
            string SOederWay = comboOrderWay.Text != "All Order Way" && comboOrderWay.Text != "-–None--" ? comboOrderWay.Text : "";

            if (SCustname != "" && SItemName == "" && SCategory == "" && SSalesman == "" && SOederWay == "")
            {
                lblReportName.Text = "Sales Cash Of \n" + SCustname + " ";
                lbleventname.Text = "serchCustomerReport";
                serchCustomerReport(SCustname);
            }
            else
            {
                lbleventname.Text = "serchReport";
                serchReport();
            }
        }

        public void serchReport()
        {
            try
            {
                lblReportName.Text = "Cash Sales Report ";

                dtgrdViewSalesReport.Columns.Clear();

                string sql = "";
                string sql3 = "";

                string SCustname = ComboCustomer.Text != "All Customer" && ComboCustomer.Text != "-–None--" ? ComboCustomer.Text : "";
                string SItemName = comboItem.Text != "All items" && comboItem.Text != "-–None--" ? comboItem.Text : "";
                string SCategory = comboCatagory.Text != "All category" && comboCatagory.Text != "-–None--" ? comboCatagory.Text : "";
                string SSalesman = comboSalesman.Text != "All SalesMan" && comboSalesman.Text != "-–None--" ? comboSalesman.Text : "";
                string SOederWay = comboOrderWay.Text != "All Order Way" && comboOrderWay.Text != "-–None--" ? comboOrderWay.Text : "";

                sql = " select    sales_item.sales_time as 'Date' ," +
                "sales_item.InvoiceNO as 'Inv #'," +
                "sales_item.PaymentMode as 'Type'," +
                    " itemName as 'Description'," +
                      " RetailsPrice  as 'Sale Price'," +
                      " Qty," +
                      " sales_item.Total as 'Total'," +
                       " sales_item.discount as 'Dis'," +
                       "((Qty * RetailsPrice)- sales_item.discount) as 'Final Total' ," +
                      " ((profit * Qty) * 1.00) as 'Profit'    " +
                    //" case when sales_payment.dis is not null Then sales_payment.dis when sales_payment.dis is null then '0.0'  End 'Dis'  " + yogesh
                      " from sales_item Inner join ICUOM on ICUOM.UOM = sales_item.UOM and ICUOM.TenentID = sales_item.TenentID  " +
                      " inner join Purchase on purchase.product_id = sales_item.itemcode and sales_item.Deleted <> 1 and purchase.TenentID = sales_item.TenentID  " +
                      " inner join CAT_MST on purchase.category = CAT_MST.catid and purchase.TenentID = CAT_MST.TenentID  " +
                       " inner join tbl_item_uom_price on purchase.product_id = tbl_item_uom_price.itemID and tbl_item_uom_price.TenentID = purchase.TenentID " +
                      " Left Join sales_payment ON sales_item.TenentID = sales_payment.TenentID and sales_payment.Deleted <> 1 and sales_item.sales_id = sales_payment.sales_id " +
                      " where  sales_item.TenentID = " + Tenent.TenentID + " and sales_item.sales_time BETWEEN '" + dateFrom.Text + "' AND  '" + dateTO.Text + "' " +
                      " and sales_item.Customer like '%" + SCustname + "%' and itemname like '%" + SItemName + "%' and SoldBy like '%" + SSalesman + "%' and OrderWay like '%" + SOederWay + "%' " +
                      " and CAT_MST.CAT_NAME1 Like '%" + SCategory + "%'  and sales_item.status != 2 group by sales_item.itemcode,sales_item.UOM Order  by sales_item.sales_time ";

                sql3 = " select SUM(sales_item.Total) as 'Total' ," +
                    " SUM(profit * Qty) as 'Profit' ," +
                    " SUM(discount) as 'Dis'," +
                    " SUM(QTY) as 'Qty' " +
                       " from sales_item Inner join ICUOM on ICUOM.UOM = sales_item.UOM and ICUOM.TenentID = sales_item.TenentID " +
                       " inner join Purchase on purchase.product_id = sales_item.itemcode and purchase.TenentID = sales_item.TenentID  and sales_item.Deleted <> 1 " +
                       " inner join CAT_MST on purchase.category = CAT_MST.catid and purchase.TenentID = CAT_MST.TenentID " +
                       " inner join tbl_item_uom_price on purchase.product_id = tbl_item_uom_price.itemID and tbl_item_uom_price.TenentID = purchase.TenentID " +
                       " Left Join sales_payment ON sales_item.TenentID = sales_payment.TenentID and sales_payment.Deleted <> 1 and sales_item.sales_id = sales_payment.sales_id " +
                       " where sales_item.TenentID = " + Tenent.TenentID + " and sales_item.sales_time BETWEEN '" + dateFrom.Text + "' AND    '" + dateTO.Text + "' " +
                       " and sales_item.Customer like '%" + SCustname + "%' and itemname like '%" + SItemName + "%' and SoldBy like '%" + SSalesman + "%' and OrderWay like '%" + SOederWay + "%'  " +
                       " and CAT_MST.CAT_NAME1 Like '%" + SCategory + "%'  and sales_item.status != 2 ";

                DataTable dt1 = DataAccess.GetDataTable(sql);
                dtgrdViewSalesReport.DataSource = dt1;
                dtgrdViewSalesReport.DefaultCellStyle.Font = new Font("Trebuchet MS", 12.0F);
                dtgrdViewSalesReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dtgrdViewSalesReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //dtgrdViewSalesReport.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                DataTable dt3 = DataAccess.GetDataTable(sql3);

                DataRow drfirst = dt1.NewRow();
                drfirst[0] = " ";
                dt1.Rows.Add(drfirst);

                //string Sql4 = " select  SUM(dis) as dis  from sales_payment  " +
                //                   " where TenentID = " + Tenent.TenentID + " and sales_time BETWEEN '" + dateFrom.Text + "' AND    '" + dateTO.Text + "'  Order  by sales_time ";
                //DataTable dt4 = DataAccess.GetDataTable(Sql4);

                //double Qty = Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                //double Total = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                //double Profit = Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                //double Dis = Convert.ToDouble(dt4.Rows[0].ItemArray[0] != null && dt4.Rows[0].ItemArray[0].ToString() != "" ? dt4.Rows[0].ItemArray[0].ToString() : "0");
                //double AfterDisTotal = Total - Dis;

                double Qty = Convert.ToDouble(dt3.Rows[0]["Qty"].ToString());
                double Total = Convert.ToDouble(dt3.Rows[0]["Total"].ToString());
                double Profit = Convert.ToDouble(dt3.Rows[0]["Profit"].ToString());
                double Dis = Convert.ToDouble(dt3.Rows[0]["Dis"] != null && dt3.Rows[0]["Dis"].ToString() != "" ? dt3.Rows[0]["Dis"].ToString() : "0");
                double AfterDisTotal = Total - Dis;

                //DataRow drTotal = dt1.NewRow();
                //drTotal[0] = "Total ";
                //drTotal[5] = Qty;
                //drTotal[6] = Total;
                //drTotal[7] = Profit;
                ////drTotal[8] = Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                //dt1.Rows.Add(drTotal);

                DataRow drTotal = dt1.NewRow();
                drTotal[0] = "Total ";
                drTotal[5] = Qty;
                drTotal[6] = Total;
                drTotal[7] = Dis;
                drTotal[8] = AfterDisTotal;
                drTotal[9] = Profit;
                dt1.Rows.Add(drTotal);


                DataRow dr = dt1.NewRow();
                dr[0] = " ";
                dt1.Rows.Add(dr);


                DataRow dr6 = dt1.NewRow();
                dr6[0] = " Final Total : (Total - Discount) ";
                dr6[1] = AfterDisTotal;
                dt1.Rows.Add(dr6);

                DataRow dr8 = dt1.NewRow();
                dr8[0] = " Total Discount: ";
                dr8[1] = Dis;
                dt1.Rows.Add(dr8);

                //Totla Profit
                DataRow dr5 = dt1.NewRow();
                dr5[0] = "Total Profit :";
                dr5[1] = Profit;
                dt1.Rows.Add(dr5);

                DataRow dr7 = dt1.NewRow();
                dr7[0] = "______ ";
                dt1.Rows.Add(dr7);

                DataRow rep = dt1.NewRow();
                rep[0] = "Sales From ";
                rep[1] = "Sales To ";
                dt1.Rows.Add(rep);



                DataRow repdt = dt1.NewRow();
                repdt[0] = dateFrom.Text;
                repdt[1] = dateTO.Text;
                dt1.Rows.Add(repdt);
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        public void serchCustomerReport(string Customer)
        {
            try
            {
                dtgrdViewSalesReport.Columns.Clear();

                string Sql = " select sales_item.sales_time as Date , sales_item.InvoiceNo as 'Inv #'," +
                " case When sales_item.PaymentMode = 'PriPaid' then 'Pre Paid' when sales_item.PaymentMode is not null then sales_item.PaymentMode End as 'Type'," +
                " case When sales_payment.payment_type is null then 'Credit' when sales_payment.payment_type='Advance' then 'Advance' when sales_payment.payment_type is not null then 'Sales Invoice' End as 'Discription' ," +
                " case When sales_payment.payment_type is null then '0.000' when sales_payment.payment_type is not null then printf('%.3f',payment_amount) End as 'Paid'," +
                " printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) + (select sales_payment.payment_amount from sales_payment where sales_payment.sales_id=sales_item.sales_id) when Sum(discount) is null then 0 + (select sales_payment.payment_amount from sales_payment where sales_payment.sales_id=sales_item.sales_id) End ))) as 'Due'," +
                " printf('%.3f',( sales_item.OrderTotal + (case when sales_payment.dis is not null then sales_payment.dis when sales_payment.dis is null then 0 End ))) as 'Invoice Amount' ," +
                " Comment as 'Comment' from sales_item left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID" +
                " where sales_item.TenentID  = " + Tenent.TenentID + " and sales_item.Deleted <> 1 and sales_payment.Deleted <> 1 and sales_item.Customer = '" + Customer + "' group by sales_item.sales_id  order by  sales_item.sales_id ;";

                //string Sql = " select  sales_item.InvoiceNO as 'Inv #', sales_item.sales_time as 'Date' , " +
                //             " case WHEN sales_item.PaymentMode = 'COD' THEN 'COD' WHEN sales_item.PaymentMode = 'PriPaid' THEN 'Pre Paid' " +
                //             " WHEN sales_item.PaymentMode = 'Credit' and (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) THEN 'Credit'  " +
                //             " WHEN sales_item.PaymentMode = 'Credit' THEN 'Receivable' WHEN sales_item.PaymentMode = 'Draft' THEN 'Draft' END 'Discription', " +
                //              " (sales_item.OrderTotal - (sales_item.OrderTotal - (case when  sales_payment.payment_amount is not null then  sales_payment.payment_amount when sales_payment.payment_amount is null then 0 End )) ) as 'Credit', " +
                //             " (sales_item.OrderTotal - (case when  sales_payment.payment_amount is not null then  sales_payment.payment_amount when sales_payment.payment_amount is null then 0 End )) as 'Debit', " +                            
                //             " ( (sales_item.OrderTotal - (sales_item.OrderTotal - (case when  sales_payment.payment_amount is not null then  sales_payment.payment_amount when sales_payment.payment_amount is null then 0 End )) ) " +
                //             "  - (sales_item.OrderTotal - (case when  sales_payment.payment_amount is not null then  sales_payment.payment_amount when sales_payment.payment_amount is null then 0 End )) ) as 'Balance', " +
                //             " sales_payment.comment as Remarks "+                             
                //             " from sales_item Inner join ICUOM on ICUOM.UOM = sales_item.UOM and ICUOM.TenentID = sales_item.TenentID " +
                //             " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                //             " where  sales_item.TenentID  = " + Tenent.TenentID + " and sales_item.sales_time BETWEEN '" + dateFrom.Text + "' AND  '" + dateTO.Text + "' " +
                //             " and sales_item.Customer = '" + Customer + "' and status != 2 " +
                //             " Order  by sales_item.sales_time ";

                DataTable dt2 = DataAccess.GetDataTable(Sql);
                dtgrdViewSalesReport.DataSource = dt2;
                dtgrdViewSalesReport.DefaultCellStyle.Font = new Font("Trebuchet MS", 12.0F);
                



                decimal sumSubTotal = 0, SumPaid = 0, sumBalance = 0;
                for (int i = 0; i < dtgrdViewSalesReport.Rows.Count; ++i)
                {
                    
                    SumPaid += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[4].Value);
                    sumBalance += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[5].Value);
                    sumSubTotal += Convert.ToDecimal(dtgrdViewSalesReport.Rows[i].Cells[6].Value);
                }

                DataRow dr = dt2.NewRow();
                dr[1] = " ";
                dt2.Rows.Add(dr);

                /// Sub total = total - Discount
                DataRow dr2 = dt2.NewRow();
                dr2[1] = "Total Sale :";
                dr2[2] = sumSubTotal.ToString();
                // dr2[4] = dt3.Rows[0].ItemArray[2].ToString();
                dt2.Rows.Add(dr2);

                DataRow discount = dt2.NewRow();
                discount[1] = "Paid :";
                discount[2] = SumPaid.ToString();
                dt2.Rows.Add(discount);


                DataRow profit = dt2.NewRow();
                profit[1] = "Due :";
                profit[2] = sumBalance.ToString();
                dt2.Rows.Add(profit);

                DataRow dr17 = dt2.NewRow();
                dr17[1] = " ";
                dt2.Rows.Add(dr17);



                DataRow rep = dt2.NewRow();
                rep[1] = "Customer Cash Report  ";
                rep[3] = dateFrom.Text;
                rep[4] = dateTO.Text;
                dt2.Rows.Add(rep);
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        private void Report_Click(object sender, EventArgs e)
        {
            DateTime end = Convert.ToDateTime(dateTO.Text);
            //end = end.AddDays(1);

            string EndDate = end.ToString("yyyy-MM-dd");
            string opening;
            lblReportName.Text = "Sales Cash Report ";
            dtgrdViewSalesReport.Refresh();
            string openingbalance = "select ifnuLL( (SUM(TOTAL) - Sum(discount)) - ifnull((select  payment_amount  from sales_payment where sales_id = sales_item.sales_id),0),0)" +
             " as openingbalance from sales_item" +
             " where sales_item.TenentID = " + Tenent.TenentID + " and  sales_item.sales_time < '" + dateFrom.Text + "'  and sales_item.Deleted <> 1  and sales_item.PaymentMode <> 'Draft' and sales_item.c_id = " + int.Parse(ComboCustomer.SelectedValue.ToString()) + " " +
"group by sales_item.sales_id ";


            DataTable openingbalanc = DataAccess.GetDataTable(openingbalance);
            decimal sum = 0;
            for (int i = 0; i < openingbalanc.Rows.Count; i++)
            {
                sum += decimal.Parse(openingbalanc.Rows[i]["openingbalance"].ToString());
            }
           
          

            string sql = "select  sales_item.InvoiceNO as 'InvoiceNO' ,sales_item.sales_time as 'Date' ," +
"CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' ," +
"printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'InvoiceAmount'  ," +
"printf('%.3f',(SUM(discount))) as 'Discount'," +
"printf('%.3f',(p.payment_amount)) as 'Balance'," +
"case WHEN sales_item.PaymentMode = 'COD' THEN 'COD' WHEN sales_item.PaymentMode = 'Advance' THEN 'Advance' WHEN sales_item.PaymentMode = 'PriPaid' THEN 'Pre Paid' WHEN sales_item.PaymentMode = 'Credit' THEN 'Credit'  WHEN sales_item.PaymentMode = 'Booking' THEN 'Booking' END 'PaymentMode' ," +
"Remarks as 'Comment'  " +
"from sales_item left outer join sales_payment p on sales_item.sales_id = p.sales_id  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID  and sales_item.PaymentMode <> 'Draft'" +
"where sales_item.TenentID = " + Tenent.TenentID + " and  sales_item.sales_time between '" + dateFrom.Text + "' AND    '" + EndDate + "' and sales_item.Deleted <> 1  and sales_item.PaymentMode <> 'Draft' and sales_item.c_id = " + int.Parse(ComboCustomer.SelectedValue.ToString()) +  " " +
"group by sales_item.sales_id order by sales_item.sales_time";

            DataTable dt1 = DataAccess.GetDataTable(sql);
          
            Report.SaleReportViewer form = new Report.SaleReportViewer(dt1, sum);
            form.ShowDialog();
        }
    }
}
