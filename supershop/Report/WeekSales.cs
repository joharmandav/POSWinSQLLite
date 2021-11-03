using System;
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
    public partial class WeekSales : Form
    {
        public WeekSales()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            string sql3 = "select * from tbl_terminalLocation where TenentID = " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            DateTime dt = DateTime.Now;
            string printdate = dt.ToString("MMMM dd, yyyy    HH:mm:ss tt");
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

            printDocument1.DocumentName = "Sales Report";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            printDocument1, true, true, Header + " Sales Report \n", new Font("Baskerville Old Face", 13,
            FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            // tosend = "<html><table>" + tosend + "</table></html>";
            //  mail.IsBodyHtml = true;
            //mail.Body = tosend;

            //else

            //    MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            //    printDocument1, false, true, Header + "   Sales Report   \n", new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            return true;
        }


        private void ShortCutReport_Load(object sender, EventArgs e)
        {
            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";

            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";

            datagrdReportDetails.EnableHeadersVisualStyles = false;
            datagrdReportDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            lblStartDate.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            dtStartDate.Value = DateTime.Now.AddDays(-7);

            lblENDdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dtEndDate.Value = DateTime.Now;

            if (lblENDdate.Text == "0")
            {
                dailyReport();

            }
            else
            {
                Last30daysReport(lblStartDate.Text, lblENDdate.Text);
            }
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

        public string DTtoday
        {
            set
            {
                lblStartDate.Text = value;
            }
            get
            {
                return lblStartDate.Text;
            }
        }

        public string last30salesStartDate
        {
            set
            {
                lblStartDate.Text = value;
            }
            get
            {
                return lblStartDate.Text;
            }
        }

        public string last30salesENDDate
        {
            set
            {
                lblENDdate.Text = value;
            }
            get
            {
                return lblENDdate.Text;
            }
        }


        public void dailyReport()
        {
            if (lblStartDate.Text == "")
            {

                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {

                    //  string sql = "select   [sales_time] as [Date] , SUM(payment_amount) as [Total] , SUM(dis) as [Discount] , SUM(vat) as [VAT]  ,  SUM(due_amount)  as [Due]  from sales_payment where sales_time BETWEEN '" + lblShowValue.Text + "' AND    '" + lblShowValue.Text + "' GROUP BY  sales_time  Order  by sales_time"; //order by salesdate
                    string sql = "select sales_id as 'Sales ID', InvoiceNO as 'Recipt No' , sales_time as Date , SUM(payment_amount) as Total , emp_id as 'Sold by',  " +
                        " SUM(dis) as Discount , SUM(vat) as TAX ,sum(change_amount) as 'change amount', SUM(due_amount) as Due, Comment as Comments " +
                        " from sales_payment where TenentID = " + Tenent.TenentID + " and sales_time   like  '%" + lblStartDate.Text + "%'  and return_id=0 and PaymentStutas='Success' group by InvoiceNO order by sales_id";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;

                    datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    string sql3 = "select SUM(payment_amount), SUM(vat) , SUM(due_amount), SUM(dis) " +
                        " from sales_payment where TenentID = " + Tenent.TenentID + " and sales_time like  '%" + lblStartDate.Text + "%' and PaymentStutas='Success'";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);


                    DataRow dr = dt1.NewRow();
                    dr[2] = " ";
                    dt1.Rows.Add(dr);

                    DataRow dr2 = dt1.NewRow();
                    dr2[2] = "Sub Total";
                    dr2[3] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                    dt1.Rows.Add(dr2);


                    DataRow discount = dt1.NewRow();
                    discount[2] = "Total Discount";
                    discount[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                    dt1.Rows.Add(discount);



                    DataRow dr4 = dt1.NewRow();
                    dr4[2] = "Total TAX ";
                    dr4[6] = Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                    dt1.Rows.Add(dr4);

                    DataRow dr6 = dt1.NewRow();
                    dr6[2] = " ";
                    dt1.Rows.Add(dr6);

                    DataRow dr5 = dt1.NewRow();
                    dr5[2] = "Total Sales+TAX ";
                    dr5[3] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                    dt1.Rows.Add(dr5);

                    DataRow dr8 = dt1.NewRow();
                    dr8[2] = "Total Due ";
                    dr8[8] = Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                    dt1.Rows.Add(dr8);

                    DataRow dr17 = dt1.NewRow();
                    dr17[2] = " ";
                    dt1.Rows.Add(dr17);

                    //DataRow dr9 = dt1.NewRow();
                    //dr9[1] = "Total in Cash ";
                    //dr9[2] = (Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString())) - Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                    //dt1.Rows.Add(dr9);

                    DataRow dr7 = dt1.NewRow();
                    dr7[2] = " ";
                    dt1.Rows.Add(dr7);


                    DataRow rep = dt1.NewRow();
                    rep[2] = "Payment Report ";
                    // rep[3] = dateTimePicker1.Text;                  
                    dt1.Rows.Add(rep);

                    DataRow repdt = dt1.NewRow();
                    // rep[3] = "Daily Report For ";
                    repdt[2] = "From : " + lblStartDate.Text;
                    //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                    dt1.Rows.Add(repdt);

                    DataRow repdt2 = dt1.NewRow();
                    // rep[3] = "Daily Report For ";
                    repdt2[2] = "To : " + lblStartDate.Text;
                    //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                    dt1.Rows.Add(repdt2);
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        public void Last30daysReport(string startDate, string endDate)
        {
            if (lblStartDate.Text == "")
            {
                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {
                    //string sql = "select   sales_time as Date , SUM(payment_amount) as 'Total' , SUM(dis) as 'Discount' , SUM(vat) as 'VAT'  ,  SUM(due_amount)  as 'Due'" + 
                    //            "  from sales_payment where sales_time BETWEEN '" + startDate + "' AND    '" + endDate + "'    Order  by sales_time"; //order by salesdate
                    //DataAccess.ExecuteSQL(sql);
                    //DataTable dt1 = DataAccess.GetDataTable(sql);
                    //datagrdReportDetails.DataSource = dt1;

                    //string sql3 = "select SUM(payment_amount), SUM(vat) , SUM(due_amount), SUM(dis)  " +
                    //    " from sales_payment  where sales_time   >='" + startDate + "' AND  sales_time <='" + endDate + "' ";
                    //DataAccess.ExecuteSQL(sql3);
                    //DataTable dt3 = DataAccess.GetDataTable(sql3);
                    //sales_id

                    DateTime end = Convert.ToDateTime(endDate);
                    end = end.AddDays(1);
                    endDate = end.ToString("yyyy-MM-dd");

                    string sql = "select sales_id as 'Sales ID', InvoiceNO as 'Recipt No' , sales_time as Date , SUM(payment_amount) as Total , emp_id as 'Sold by', " +
                        " sum(dis) as Discount , sum(vat) as TAX , sum(change_amount) as 'change amount', sum(due_amount) as Due, Comment as Comments " +
                        "  from sales_payment where TenentID = " + Tenent.TenentID + " and SaleDt BETWEEN '" + startDate + "' AND    '" + endDate + "' and return_id=0 and PaymentStutas='Success'  group by InvoiceNO  Order  by sales_id";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    string sql3 = "select SUM(payment_amount), SUM(vat) , sum(change_amount), SUM(dis)  " +
                                "  from sales_payment where TenentID = " + Tenent.TenentID + " and SaleDt BETWEEN '" + startDate + "' AND    '" + endDate + "' and return_id=0 and PaymentStutas='Success' Order  by sales_id";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);

                    DataRow dr = dt1.NewRow();
                    dr[2] = " ";
                    dt1.Rows.Add(dr);

                    DataRow dr2 = dt1.NewRow();
                    dr2[2] = "Sub Total";
                    dr2[3] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                    dt1.Rows.Add(dr2);


                    DataRow discount = dt1.NewRow();
                    discount[2] = "Total Discount";
                    discount[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                    dt1.Rows.Add(discount);



                    DataRow dr4 = dt1.NewRow();
                    dr4[2] = "Total TAX ";
                    dr4[6] = Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                    dt1.Rows.Add(dr4);

                    DataRow dr6 = dt1.NewRow();
                    dr6[2] = " ";
                    dt1.Rows.Add(dr6);

                    DataRow dr5 = dt1.NewRow();
                    dr5[2] = "Total Sales+ TAX ";
                    dr5[3] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                    dt1.Rows.Add(dr5);

                    DataRow dr8 = dt1.NewRow();
                    dr8[2] = "Total Due ";
                    dr8[8] = Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                    dt1.Rows.Add(dr8);

                    DataRow dr17 = dt1.NewRow();
                    dr17[2] = " ";
                    dt1.Rows.Add(dr17);

                    //DataRow dr9 = dt1.NewRow();
                    //dr9[1] = "Total in Cash ";
                    //dr9[2] = (Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString())) - Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                    //dt1.Rows.Add(dr9);

                    DataRow dr7 = dt1.NewRow();
                    dr7[2] = " ";
                    dt1.Rows.Add(dr7);


                    DataRow rep = dt1.NewRow();
                    rep[2] = "Payment Report ";
                    // rep[3] = dateTimePicker1.Text;                  
                    dt1.Rows.Add(rep);

                    DataRow repdt = dt1.NewRow();
                    // rep[3] = "Daily Report For ";
                    repdt[1] = "From : " + startDate;
                    //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                    dt1.Rows.Add(repdt);

                    DataRow repdt2 = dt1.NewRow();
                    // rep[3] = "Daily Report For ";
                    repdt2[1] = "To : " + endDate;
                    //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                    dt1.Rows.Add(repdt2);
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.datagrdReportDetails.RowsDefaultCellStyle.BackColor = Color.White;
                this.datagrdReportDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                if (SetupThePrinting())
                {
                    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    MyPrintPreviewDialog.WindowState = FormWindowState.Maximized;
                    MyPrintPreviewDialog.PrintPreviewControl.Zoom = 1.0;
                    MyPrintPreviewDialog.Document = printDocument1;
                    MyPrintPreviewDialog.ShowDialog();

                    //PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    //MyPrintPreviewDialog.Document = printDocument1;
                    //MyPrintPreviewDialog.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("!!! Please Print Preview or Setup Print only for First time " + exp.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        public string GetSalesID(string InvoiceNO)
        {
            string sql3 = "select * from sales_payment where TenentID = " + Tenent.TenentID + " and InvoiceNO='" + InvoiceNO + "' ";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt3 = DataAccess.GetDataTable(sql3);
            string Salesid = "";
            if (dt3.Rows.Count > 0)
            {
                Salesid = dt3.Rows[0]["sales_id"].ToString();
            }
            else
            {
                Salesid = "";
            }
            return Salesid;
        }

        // Variable pass for Salesdetails 
        private void datagrdReportDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];
                string id = row.Cells[1].Value.ToString();

                string sql = "select  InvoiceNO as 'Recipt No' , sales_time as Date , sum(payment_amount) as Total , emp_id as 'Sold by',  " +
                                " sum(dis) as Discount , sum(vat) as TAX ,sum(change_amount) as 'changeamount',sum(due_amount) as Due,Comment as Comments " +
                                " from sales_payment where  TenentID = " + Tenent.TenentID + " and  InvoiceNO='" + id + "' and PaymentStutas='Success' group by sales_id order by sales_time";
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);

                double Payamt = 0;
                double vat = 0;
                double subtotal = 0;
                double dis = 0;
                double Change = 0;
                double Due = 0;


                if (dt1.Rows.Count > 0)
                {
                    Payamt = Convert.ToDouble(dt1.Rows[0]["Total"].ToString());
                    vat = Convert.ToDouble(dt1.Rows[0]["TAX"].ToString());
                    Change = Convert.ToDouble(dt1.Rows[0]["changeamount"].ToString());
                    Due = Convert.ToDouble(dt1.Rows[0]["Due"].ToString());

                    subtotal = Convert.ToDouble(dt1.Rows[0]["Total"].ToString()) - Convert.ToDouble(vat) - Convert.ToDouble(Change);
                    dis = Convert.ToDouble(dt1.Rows[0]["Discount"].ToString());
                }
                string salesID = GetSalesID(id);

                if (row.Cells[8].Value.ToString() == "Invoice")
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
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }

        private void txtInvoice_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //  string sql = "select  sales_id,  [sales_time] as [Date] , SUM(payment_amount) as [Total] , SUM(dis) as [Discount] , SUM(vat) as [VAT]  ,  SUM(due_amount)  as [Due]  from sales_payment where sales_time BETWEEN '" + lblShowValue.Text + "' AND    '" + lblShowValue.Text + "' GROUP BY  sales_time  Order  by sales_time"; //order by salesdate
                string sql = "select sales_id as 'Sales ID', InvoiceNO as 'Recipt No' , sales_time as Date , sum(payment_amount) as Total , emp_id as 'Sold by',  " +
                    " sum(dis) as Discount , sum(vat) as TAX , sum(change_amount) as 'change amount', sum(due_amount) as Due, Comment as Comments " +
                    " from sales_payment where TenentID = " + Tenent.TenentID + " and   InvoiceNO  Like  '%" + txtInvoice.Text + "%' and PaymentStutas='Success' group by InvoiceNO order by sales_id";
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagrdReportDetails.DataSource = dt1;
                datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                string sql3 = "select SUM(payment_amount), SUM(vat) , SUM(due_amount), SUM(dis) " +
                    " from sales_payment  where TenentID = " + Tenent.TenentID + " and sales_id  = '" + txtInvoice.Text + "' and PaymentStutas='Success' ";
                DataAccess.ExecuteSQL(sql3);
                DataTable dt3 = DataAccess.GetDataTable(sql3);


                DataRow dr = dt1.NewRow();
                dr[2] = " ";
                dt1.Rows.Add(dr);

                DataRow dr2 = dt1.NewRow();
                dr2[2] = "Sub Total";
                dr2[3] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                dt1.Rows.Add(dr2);


                DataRow discount = dt1.NewRow();
                discount[2] = "Total Discount";
                discount[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                dt1.Rows.Add(discount);



                DataRow dr4 = dt1.NewRow();
                dr4[2] = "Total TAX ";
                dr4[6] = Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                dt1.Rows.Add(dr4);

                DataRow dr6 = dt1.NewRow();
                dr6[2] = " ";
                dt1.Rows.Add(dr6);

                DataRow dr5 = dt1.NewRow();
                dr5[2] = "Total Sales+TAX ";
                dr5[3] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                dt1.Rows.Add(dr5);

                DataRow dr8 = dt1.NewRow();
                dr8[2] = "Total Due ";
                dr8[6] = Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                dt1.Rows.Add(dr8);

                DataRow dr17 = dt1.NewRow();
                dr17[2] = " ";
                dt1.Rows.Add(dr17);

                //DataRow dr9 = dt1.NewRow();
                //dr9[1] = "Total in Cash ";
                //dr9[2] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                //dt1.Rows.Add(dr9);

                DataRow dr7 = dt1.NewRow();
                dr7[2] = " ";
                dt1.Rows.Add(dr7);


                DataRow rep = dt1.NewRow();
                rep[2] = "Payment Report ";
                // rep[3] = dateTimePicker1.Text;                  
                dt1.Rows.Add(rep);

                DataRow repdt = dt1.NewRow();
                // rep[3] = "Daily Report For ";
                repdt[2] = "From : " + lblStartDate.Text;
                //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                dt1.Rows.Add(repdt);

                DataRow repdt2 = dt1.NewRow();
                // rep[3] = "Daily Report For ";
                repdt2[2] = "To : " + lblStartDate.Text;
                //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                dt1.Rows.Add(repdt2);
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        private void helplnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            parameter.helpid = "INV";
            HelpPage go = new HelpPage();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void datagrdReportDetails_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch
            {

            }
        }

    }
}
