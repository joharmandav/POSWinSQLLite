using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop.Report
{
    public partial class DateToDateDraftTransection : Form
    {
        public DateToDateDraftTransection()
        {
            InitializeComponent();

            //datagrdReportDetails
            DataGridViewButtonColumn Assign = new DataGridViewButtonColumn();
            this.datagrdReportDetails.Columns.Add(Assign);
            Assign.HeaderText = "Action";
            Assign.Text = "Action عمل";
            Assign.Name = "Action";
            Assign.ToolTipText = "Action";
            Assign.UseColumnTextForButtonValue = true;

            lblStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";
            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";
        }


        private void DateToDateDraftTransection_Load(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Now.AddDays(-7);
            DateTime EndDate = DateTime.Now;

            dtStartDate.Text = StartDate.ToString("yyyy-MM-dd");
            dtEndDate.Text = EndDate.ToString("yyyy-MM-dd");

            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }

        public void Last30daysReport(string startDate,string EndDate)
        {
            if (lblStartDate.Text == "")
            {
                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {
                    txtInvoiceCash.Text = "";
                    //string sql = "select  InvoiceNO as 'Recipt No' , Customer as 'Customer' , OrderStutas as Comments, SUM(total) as Total " +
                    //             " from sales_item where sales_time Like '" + startDate + "'  group by sales_id order by sales_time";

                    string sql = " select  InvoiceNO as 'Receipt' , CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN (tbl_customer.Name ||' - '|| tbl_customer.NameArabic) end 'Customer' , " + 
                                 " OrderWay as 'Order Way' , OrderStutas as Status, SUM(total) as Total , sales_item.sales_id as id " +
                                 " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and sales_item.TenentID = tbl_customer.TenentID " +
                                 " where sales_item.TenentID=" + Tenent.TenentID + "  and PaymentMode = 'Draft' and OrderStutas !='Return' and sales_item.sales_time between  '" + startDate + "'  and '" + EndDate + "'  group by sales_item.sales_id order by sales_item.sales_time";

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns["id"].Visible = false;
                    datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    datagrdReportDetails.Columns["Action"].DisplayIndex = 5;
                    datagrdReportDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    lblTotalSalesAmount.Text = dt1.Compute("SUM(Total)", string.Empty).ToString();                
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }

        private void btnCashierRefresh_Click(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }

        private void txtInvoiceCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = " select  InvoiceNO as 'Receipt' , (tbl_customer.Name ||' - '|| tbl_customer.NameArabic) as 'Customer'  , OrderWay as 'Order Way' , OrderStutas as Status, SUM(total) as Total, sales_item.sales_id as id  " +
                             " from sales_item   left JOIN tbl_customer on sales_item.c_id = tbl_customer.id " +
                             " where sales_item.TenentID=" + Tenent.TenentID + " and PaymentMode = 'Draft' and OrderStutas !='Return' and sales_item.InvoiceNO  Like  '%" + txtInvoiceCash.Text + "%'  group by sales_item.sales_id order by sales_item.sales_time";
                
                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagrdReportDetails.DataSource = dt1;
                datagrdReportDetails.Columns["id"].Visible = false;
                datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns["Action"].DisplayIndex = 5;
                datagrdReportDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                lblTotalSalesAmount.Text = dt1.Compute("SUM(Total)", string.Empty).ToString();

            }
            catch
            {
            }
        }

        private void datagrdReportDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == datagrdReportDetails.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];

                    string id = row.Cells["Receipt"].Value.ToString();
                    int CursorY = Cursor.Position.Y;
                    if (e.RowIndex >= 6)
                    {
                        CursorY = 476;
                    }

                    ShowCashierAction(id, CursorY);
                } 
                else
                {
                    DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];

                    string id = row.Cells["Receipt"].Value.ToString();
                    int CursorY = Cursor.Position.Y;
                    if (e.RowIndex >= 6)
                    {
                        CursorY = 476;
                    }

                    ShowCashierAction(id, CursorY);
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        public void ShowCashierAction(string InvoiceNO, int CursorY)
        {
            string salesID = SalesRegister.GetSalesID(InvoiceNO);
            string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and sales_id=" + salesID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            int cal = Cursor.Position.X;
            int CursorX = cal - 350;

            if (dt1.Rows.Count > 0)
            {
                if (Application.OpenForms["CashierAction"] != null)
                {
                    Application.OpenForms["CashierAction"].Close();
                }

                CashierAction mkc1 = new CashierAction(CursorX, CursorY);
                mkc1.OrderNO = InvoiceNO;
                mkc1.Show();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             bool ISrun = backSyncro.isRun;
             if (ISrun != true)
             {
                 if (txtInvoiceCash.Text == "")
                 {
                     Last30daysReport(dtStartDate.Text, dtEndDate.Text);
                 }
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
