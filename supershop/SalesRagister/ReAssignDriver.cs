using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace supershop
{
    public partial class ReAssignDriver : Form
    {
        public ReAssignDriver()
        {
            InitializeComponent();

            DataGridViewButtonColumn Assign = new DataGridViewButtonColumn();
            this.datagrdReportDetails.Columns.Add(Assign);
            Assign.HeaderText = "Driver";
            Assign.Text = "Assign";
            Assign.Name = "Assign";
            Assign.ToolTipText = "Assign Driver";
            Assign.UseColumnTextForButtonValue = true;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
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

            datagrdReportDetails.EnableHeadersVisualStyles = false;
            datagrdReportDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            if (lblENDdate.Text == "0")
            {
                dailyReport();

            }
            else
            {
                Last30daysReport(lblStartDate.Text);
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
                    string sql = " select  InvoiceNO as 'Recipt' , Customer as 'Customer' , Driver as Driver , OrderStutas as Stutas, SUM(total) as Total , sales_item.sales_id as id  " +
                                 " from sales_item " +
                                 " where sales_item.TenentID=" + Tenent.TenentID + " and OrderStutas!='Deliverd' and OrderStutas!='Deliverd & Cash Recived' and OrderStutas!='Return' and sales_item.sales_time Like '%" + lblStartDate.Text + "%'  group by sales_item.sales_id order by sales_item.sales_time";

                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns["id"].Visible = false;
                    datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Assign"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        public void Last30daysReport(string startDate)
        {
            if (lblStartDate.Text == "")
            {
                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {
                    string sql = " select  InvoiceNO as 'Recipt' , Customer as 'Customer' , Driver as Driver , OrderStutas as Stutas, SUM(total) as Total , sales_item.sales_id as id " +
                                 " from sales_item  " +
                                 " where sales_item.TenentID=" + Tenent.TenentID + " and OrderStutas!='Deliverd' and OrderStutas!='Deliverd & Cash Recived' and OrderStutas!='Return' and sales_item.sales_time Like '" + startDate + "'  group by sales_item.sales_id order by sales_item.sales_time";


                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns["id"].Visible = false;
                    datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Assign"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


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
            string sql3 = "select * from sales_item where TenentID = " + Tenent.TenentID + " and InvoiceNO='" + InvoiceNO + "' ";
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
                if (e.ColumnIndex == datagrdReportDetails.Columns["Assign"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];

                    string id = row.Cells["Recipt"].Value.ToString();
                    string salesID = GetSalesID(id);
                    string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and sales_id=" + salesID + " ";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt1 = DataAccess.GetDataTable(sql3);

                    int windowWidth = this.datagrdReportDetails.Width;

                    int cal = Cursor.Position.X;
                    int Cal1 = windowWidth / 2;// cal - 350;
                    if (dt1.Rows.Count > 0)
                    {
                        if (Application.OpenForms["DriverAssign"] != null)
                        {
                            Application.OpenForms["DriverAssign"].Close();
                        }

                        DriverAssign mkc1 = new DriverAssign(Cal1, Cursor.Position.Y);
                        mkc1.OrderNO = row.Cells["Recipt"].Value.ToString();
                        mkc1.Show();
                    }
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void txtInvoice_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string sql = " select  InvoiceNO as 'Recipt' , Customer as 'Customer' , Driver as Driver , OrderStutas as Stutas, SUM(total) as Total, sales_item.sales_id as id  " +
                              " from sales_item  " +
                              " where sales_item.TenentID=" + Tenent.TenentID + " and OrderStutas!='Deliverd' and OrderStutas!='Deliverd & Cash Recived' and OrderStutas!='Return' and sales_item.InvoiceNO  Like  '%" + txtInvoice.Text + "%'  group by sales_item.sales_id order by sales_item.sales_time";


                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagrdReportDetails.DataSource = dt1;
                datagrdReportDetails.Columns["id"].Visible = false;
                datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns["Assign"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


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

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text);
        }

        private void btnCashierRefresh_Click(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text);
        }

    }
}
