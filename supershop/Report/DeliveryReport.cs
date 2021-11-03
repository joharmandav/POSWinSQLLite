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
    public partial class DeliveryReport : Form
    {
        public string CustName4deliver
        {
            set
            {
                txtSearchCustCode.Text = value;
                if (lblCustomerPage.Text == "DeleveryReportCustSearch")
                {

                    lblCustomerPage.Text = "-";
                }
            }
            get
            {
                return txtSearchCustCode.Text;
            }
        }
        public string CustomerPage4deliver
        {
            set
            {
                lblCustomerPage.Text = value;
            }
            get
            {
                return lblCustomerPage.Text;
            }
        }
        public DeliveryReport()
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
            string sql3 = "select * from tbl_terminalLocation where Tenentid=" + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
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

            printDocument1.DocumentName = "Sales Delivery Report";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            printDocument1, true, true, Header + " Sales Delivery Report \n", new Font("Baskerville Old Face", 13,
            FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            // tosend = "<html><table>" + tosend + "</table></html>";
            //  mail.IsBodyHtml = true;
            //mail.Body = tosend;

            //else

            //    MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            //    printDocument1, false, true, Header + "   Sales Report   \n", new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        public void Bind_Customer()
        {

            comboCustomer.Items.Clear();

            string sqlCust = "select * from tbl_customer where tenentid=" + Tenent.TenentID + "  and peopleType = 'Customer' order by  Name";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            string First = "";
            if (dtCust.Rows.Count > 0)
            {
                comboCustomer.Items.Add("All");
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    string add = dtCust.Rows[i]["Name"] + " ~ " + dtCust.Rows[i]["ID"] + " ~ " + dtCust.Rows[i]["Phone"];
                    //if (First == "")
                    //{
                    //    First = add;
                    //}
                    comboCustomer.Items.Add(add);
                }
            }
            //comboCustomer.Text = First;


            if (dtCust != null)
            {
                AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
                AutoItem.Add("All");
                foreach (DataRow rw in dtCust.Rows)
                {
                    string Val = rw["Name"] + " ~ " + rw["ID"] + " ~ " + rw["Phone"].ToString();
                    AutoItem.Add(Val);

                }
                comboCustomer.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboCustomer.AutoCompleteCustomSource = AutoItem;
            }
            //comboCustomer.DataSource = dtCust;
            //comboCustomer.DisplayMember = "Name";
            //comboCustomer.ValueMember = "ID";
        }
        private void ShortCutReport_Load(object sender, EventArgs e)
        {
            Bind_Customer();
            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";

            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";

            datagrdReportDetails.EnableHeadersVisualStyles = false;
            datagrdReportDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            comboCustomer.Text = "All";
            Last30daysReport(dtStartDate.Text, dtEndDate.Text, 0);
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
                DateTime DT = Convert.ToDateTime(lblStartDate.Text);
                dtStartDate.Value = DT;
            }
            get
            {
                return lblStartDate.Text;
            }
        }






        public void Last30daysReport(string startDate, string endDate, int CustCode)
        {
            txtReciptNO.Text = "";
            if (lblStartDate.Text == "")
            {
                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {

                    //string Rno = txtReciptNO.Text != "" ? " and sales_item.InvoiceNO like '%" + txtReciptNO.Text + "%'  " : "";
                    txtSearchCustCode.Text = CustCode.ToString();
                    string Custcode4q = CustCode == 0 ? "" : " and sales_item.c_id=" + CustCode.ToString();
                    DateTime end = Convert.ToDateTime(endDate);
                    end = end.AddDays(1);
                    endDate = end.ToString("yyyy-MM-dd");
                    string sql = " select  sales_item.UploadDate as DateTime,tbl_customer.ID as 'C_Code' , CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' ,  " +
                          "  sales_item.InvoiceNO as 'Receipt' ,  printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total', (case when  sales_item.PaymentMode == 'PriPaid' then  'PrePaid' when sales_item.PaymentMode is not null then sales_item.PaymentMode End) as 'Payment Mode',sales_item.Driver  " +
                          " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                          " where sales_item.TenentID=" + Tenent.TenentID + " and sales_item.UploadDate BETWEEN '" + startDate + "' AND    '" + endDate + "'  and sales_item.Deleted <> 1 and sales_item.IsDelivered='1'  " + Custcode4q +  "  group by sales_item.sales_id order by sales_item.UploadDate";

                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        public static string GetSalesID(string InvoiceNO)
        {
            string sql3 = "select * from sales_item where Tenentid=" + Tenent.TenentID + " and Deleted <> 1 and  InvoiceNO='" + InvoiceNO + "' ";
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
                string id = row.Cells[3].Value.ToString();

                if (id != "")
                {


                    string sql = "select  InvoiceNO as 'Recipt No' , sales_time as Date , OrderTotal as Total " +
                                    " from sales_item where Tenentid=" + Tenent.TenentID + " and Deleted <> 1 and    InvoiceNO='" + id + "'  group by sales_id ";
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
                    }
                    string salesID = GetSalesID(id);
                    parameter.autoprintid = "2";
                    string File = SalesRegister.getPrintFile("Cash"); // Cash , Creadit , Kitchen
                    string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash"); // Cash , Credit , Kitchen
                    SalesRegister.PRintInvoice1(salesID, File, DefaultPrinter);

                    //SalesDetails4Delivery go = new SalesDetails4Delivery(id, Payamt, salesID);
                    //go.ShowDialog();

                }


            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (comboCustomer.Text == "All")
                Last30daysReport(dtStartDate.Text, dtEndDate.Text, 0);
            else
                Last30daysReport(dtStartDate.Text, dtEndDate.Text, Convert.ToInt32(comboCustomer.Text.Split('~')[1].Trim()));
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

        private void comboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                //string Rno = txtReciptNO.Text != "" ? "and sales_item.InvoiceNO like '%" + txtReciptNO.Text + "%'  " : "";
                int CID = Convert.ToInt32(comboCustomer.Text.Split('~')[1].Trim());
                string Custcode4q = CID == 0 ? "" : "and sales_item.c_id=" + CID.ToString();

                string sql = " select  sales_item.UploadDate as DateTime,tbl_customer.ID as 'C_Code' , CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' ,  " +
                      "  sales_item.InvoiceNO as 'Receipt' ,  printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total', (case when  sales_item.PaymentMode == 'PriPaid' then  'PrePaid' when sales_item.PaymentMode is not null then sales_item.PaymentMode End) as 'Payment Mode',sales_item.Driver  " +
                      " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                      " where sales_item.TenentID=" + Tenent.TenentID + "   and sales_item.Deleted <> 1 and sales_item.IsDelivered='1'  " + Custcode4q + "  group by sales_item.sales_id order by sales_item.UploadDate";

                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagrdReportDetails.DataSource = dt1;
                datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["DeleveryReportCustSearch"] != null)
            {
                Application.OpenForms["DeleveryReportCustSearch"].Close();
            }
            this.Refresh();

            DeleveryReportCustSearch go = new DeleveryReportCustSearch();
            go.Show();
        }

        private void txtSearchCustCode_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchCustCode.Text != "")
            {
                int CID = Convert.ToInt32(txtSearchCustCode.Text);
                Last30daysReport(dtStartDate.Text, dtEndDate.Text, CID);
                string sqlCust = "select * from tbl_customer where tenentid=" + Tenent.TenentID + "  and peopleType = 'Customer' and ID=" + CID + "";
                DataTable dtCust = DataAccess.GetDataTable(sqlCust);
                if (dtCust.Rows.Count > 0)
                {
                    comboCustomer.Text = dtCust.Rows[0]["Name"] + " ~ " + dtCust.Rows[0]["ID"] + " ~ " + dtCust.Rows[0]["Phone"];
                }
            }
        }

        private void txtReciptNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboCustomer.Text == "All")
                Last30daysReport(dtStartDate.Text, dtEndDate.Text, 0);
            else
                Last30daysReport(dtStartDate.Text, dtEndDate.Text, Convert.ToInt32(comboCustomer.Text.Split('~')[1].Trim()));
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //string Rno = txtReciptNO.Text != "" ? "and sales_item.InvoiceNO like '%" + txtReciptNO.Text + "%'  " : "";
                int CID = Convert.ToInt32(txtSearchCustCode.Text);
                string Custcode4q = CID == 0 ? "" : "and sales_item.c_id=" + CID.ToString();

                string sql = " select  sales_item.UploadDate as DateTime,tbl_customer.ID as 'C_Code' , CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' ,  " +
                      "  sales_item.InvoiceNO as 'Receipt' ,  printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total', (case when  sales_item.PaymentMode == 'PriPaid' then  'PrePaid' when sales_item.PaymentMode is not null then sales_item.PaymentMode End) as 'Payment Mode',sales_item.Driver  " +
                      " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                      " where sales_item.TenentID=" + Tenent.TenentID + "   and sales_item.Deleted <> 1 and sales_item.IsDelivered='1'  " + Custcode4q + "  group by sales_item.sales_id order by sales_item.UploadDate";

                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagrdReportDetails.DataSource = dt1;
                datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        private void btnSearchReceipt_Click(object sender, EventArgs e)
        {
            if (txtReciptNO.Text == "")
            {
                MessageBox.Show("Please Recipt NO ");
            }
            else
            {

                try
                {
                    string Rno = txtReciptNO.Text != "" ? "and sales_item.InvoiceNO like '%" + txtReciptNO.Text + "%'  " : "";
                    string sql = " select  sales_item.UploadDate as DateTime,tbl_customer.ID as 'C_Code' , CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' ,  " +
                          "  sales_item.InvoiceNO as 'Receipt' ,  printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total', (case when  sales_item.PaymentMode == 'PriPaid' then  'PrePaid' when sales_item.PaymentMode is not null then sales_item.PaymentMode End) as 'Payment Mode',sales_item.Driver  " +
                          " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                          " where sales_item.TenentID=" + Tenent.TenentID + "   and sales_item.Deleted <> 1 and sales_item.IsDelivered='1'  " + Rno + "  group by sales_item.sales_id order by sales_item.UploadDate";

                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }

        }


    }
}
