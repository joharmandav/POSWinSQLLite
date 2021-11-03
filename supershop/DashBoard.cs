using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class DashBoard : Form
    {
        private static int[] RGB_TRANS_MASK = { 230, 240, 250 };
        public DashBoard()
        {
            InitializeComponent();
            this.SuspendLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
            //dtyearmonth.Format = DateTimePickerFormat.Custom;
            //dtyearmonth.CustomFormat = "yyyy-MM";
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.FromArgb(RGB_TRANS_MASK[0], RGB_TRANS_MASK[1],
                    RGB_TRANS_MASK[2]);
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "yyyy-MM-dd";

            DTTO.Format = DateTimePickerFormat.Custom;
            DTTO.CustomFormat = "yyyy-MM-dd";

            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            DTTO.Text = date;


            DateTime STdt = DateTime.Now.AddDays(-7);
            string Stdate = STdt.ToString("yyyy-MM-dd");
            dtDate.Text = Stdate;
        }
      

        //private void timer1_Tick(object sender, EventArgs e)yogesh 280619
        //{
        //    //BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        //    //backgroundWorker1.RunWorkerAsync();
        //    //backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        //    //backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        //    //backgroundWorker1.WorkerReportsProgress = true;

        //    bool ISrun = backSyncro.isRun;
        //    if (ISrun != true)
        //    {
        //        BindData();
        //        ChartBind();
        //        BindUserLog();
        //        string startDate = dtDate.Text;
        //        string EndDate = DTTO.Text;
        //        Last30daysReport(startDate, EndDate);
        //    }

        //}

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //BindData();
            //ChartBind();
            //BindUserLog();      
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

     protected override CreateParams CreateParams
     {
         get
         {
             CreateParams cp = base.CreateParams;
             cp.ExStyle |= 0x02000000;
             return cp;
         }
     }
 
        private void timer2_Tick(object sender, EventArgs e)
        {
            bool ISrun = backSyncro.isRun;
            if (ISrun != true)
            {
                SalesRegister.Check_OpeningBalance();
            }

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
           
            BindData();
            ChartBind();
            BindUserLog();
            string startDate = dtDate.Text;
            string EndDate = DTTO.Text;            
            Last30daysReport(startDate, EndDate);
            //SalesRegister.Check_OpeningBalance();
        }

        public void BindUserLog()
        {
            try
            {
                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                string sql5 = " select ActivityName,Log_data,Logdatetime from Win_tbl_UserLog where TenentID = " + Tenent.TenentID + " and username = '" + UserInfo.UserName + "' and logdate Like '%" + Date + "%' order by Logdatetime desc ";
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                datagrdUserLog.DataSource = dt5;
                datagrdUserLog.Columns[0].Visible = false;
                datagrdUserLog.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch
            {

            }

        }

        public void BindData()
        {
            DateTime ToDay = DateTime.Now;

            decimal today = GetSaleAmt(ToDay, ToDay);
            today = Math.Round(today, 3);
            ToDaySales.Text = "Today Sale\n" + today + " KD ";

            DateTime startDate = DateTime.Now.AddDays(-7);
            DateTime endDate = DateTime.Now;

            decimal Weekse = GetSaleAmt(startDate, endDate);
            Weekse = Math.Round(Weekse, 3);
            btnWeekSales.Text = "Week Sale\n" + Weekse + " KD ";

            DateTime startDatem = DateTime.Now.AddMonths(-1);
            DateTime endDatem = DateTime.Now;

            decimal MonthSe = GetSaleAmt(startDatem, endDatem);
            MonthSe = Math.Round(MonthSe, 3);
            btnMonthSale.Text = "Monthly Sale\n" + MonthSe + " KD ";

            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime endDatey = DateTime.Now;

            decimal Yearse = GetSaleAmt(firstDay, endDatey);
            Yearse = Math.Round(Yearse, 3);
            btnYtDsale.Text = "YTD Sale\n" + Yearse + " KD ";

        }

        public decimal GetSaleAmt(DateTime startDate1, DateTime endDate1)
        {
            string startDate = startDate1.ToString("yyyy-MM-dd");
            string endDate = endDate1.AddDays(1).ToString("yyyy-MM-dd");

            decimal Totalweek = 0;
            string sql = "select * from sales_payment where TenentID = " + Tenent.TenentID + " and SaleDt BETWEEN '" + startDate + "' AND    '" + endDate + "' and return_id=0 and PaymentStutas='Success' Order  by sales_id";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                string sql4 = "select SUM(payment_amount), SUM(vat) , sum(change_amount), SUM(dis)  " +
                              "  from sales_payment where TenentID = " + Tenent.TenentID + " and SaleDt BETWEEN '" + startDate + "' AND    '" + endDate + "' and return_id=0 and PaymentStutas='Success' Order  by sales_id";
               DataTable dt4 = DataAccess.GetDataTable(sql4);

                Totalweek = Convert.ToDecimal(dt4.Rows[0].ItemArray[0].ToString()) - Convert.ToDecimal(dt4.Rows[0].ItemArray[1].ToString());
            }

            return Totalweek;
        }

        private void btnWeekSales_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ShortCutReport"] != null)
            {
                Application.OpenForms["ShortCutReport"].Close();
            }
            this.Refresh();
            Report.ShortCutReport go = new Report.ShortCutReport();
            go.ReportName = "Week Sales Report";
            go.last30salesStartDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            go.last30salesENDDate = DateTime.Now.ToString("yyyy-MM-dd");
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        private void btnMonthSale_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ShortCutReport"] != null)
            {
                Application.OpenForms["ShortCutReport"].Close();
            }
            this.Refresh();
            Report.ShortCutReport go = new Report.ShortCutReport();
            go.ReportName = "Last 30 Day Report";
            go.last30salesStartDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            go.last30salesENDDate = DateTime.Now.ToString("yyyy-MM-dd");
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        private void btnYtDsale_Click(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);

            if (Application.OpenForms["ShortCutReport"] != null)
            {
                Application.OpenForms["ShortCutReport"].Close();
            }
            this.Refresh();
            Report.ShortCutReport go = new Report.ShortCutReport();
            go.ReportName = "Year TO Day Report";
            go.last30salesStartDate = firstDay.ToString("yyyy-MM-dd");
            go.last30salesENDDate = DateTime.Now.ToString("yyyy-MM-dd");
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        private void ToDaySales_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ShortCutReport"] != null)
            {
                Application.OpenForms["ShortCutReport"].Close();
            }
            this.Refresh();
            Report.ShortCutReport go = new Report.ShortCutReport();
            go.DTtoday = DateTime.Now.ToString("yyyy-MM-dd");
            go.ReportName = "Daily Report";
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        private void btnTop10Product_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Top10Product"] != null)
            {
                Application.OpenForms["Top10Product"].Close();
            }
            this.Refresh();
            Report.Top10Product go = new Report.Top10Product();
            go.ReportName = "Top Sold Items";
            go.Limit = "10";
            go.OrderBY = "desc";
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }


        private void btnTop10Catagory_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Top10Catagory"] != null)
            {
                Application.OpenForms["Top10Catagory"].Close();
            }
            this.Refresh();
            Report.Top10Catagory go = new Report.Top10Catagory();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }


        private void btnTop10Customer_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TopCustomer"] != null)
            {
                Application.OpenForms["TopCustomer"].Close();
            }
            this.Refresh();
            Report.TopCustomer go = new Report.TopCustomer();
            go.ReportName = "Top 10 Customer";
            go.Limit = "10";
            go.last30salesStartDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            go.last30salesENDDate = DateTime.Now.ToString("yyyy-MM-dd");
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        public void ChartBind()
        {
            try
            {
                //Profit Chart
                string sql5 = " select sales_time, SUM(profit * Qty) as Profit from sales_item " + 
                                " where TenentID = " + Tenent.TenentID + " and sales_time   BETWEEN  '" + dtDate.Text + "' AND    '" + DTTO.Text + "' and (status = 1  or status = 3) GROUP BY  sales_time ";
               DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartbarProfit.DataSource = dt5;
                chartbarProfit.Visible = true;
                chartbarProfit.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartbarProfit.Series["Profit"].XValueMember = "sales_time";
                chartbarProfit.Series["Profit"].YValueMembers = "Profit";
                chartbarProfit.DataBind();

                //Profit Pie chart 
                string sql2 = "select  SUM(profit * Qty) as Profit , sales_time from sales_item " +
                            " where TenentID = " + Tenent.TenentID + " and sales_time   BETWEEN  '" + dtDate.Text + "' AND    '" + DTTO.Text + "'and (status = 1  or status = 3)  GROUP BY  sales_time ";
                DataTable dt2 = DataAccess.GetDataTable(sql2);
                chartPieProfit.DataSource = dt2;
                chartPieProfit.Visible = true;
                chartPieProfit.Series["Profit"].XValueMember = "sales_time";
                chartPieProfit.Series["Profit"].YValueMembers = "Profit";
                chartPieProfit.DataBind();
                chartPieProfit.Series["Profit"]["PieLabelStyle"] = "Disabled";

                // Sales Pie chart
                string sql3 = " select sales_time, SUM(total) as Total from sales_item where TenentID = " + Tenent.TenentID + " and sales_time " +
                                "  BETWEEN  '" + dtDate.Text + "' AND    '" + DTTO.Text + "' and (status = 1  or status = 3)  GROUP BY  sales_time ";
               DataTable dt3 = DataAccess.GetDataTable(sql3);
                chartPieSales.DataSource = dt3;
                chartPieSales.Visible = true;
                chartPieSales.Series["Total"].XValueMember = "sales_time";
                chartPieSales.Series["Total"].YValueMembers = "Total";
                chartPieSales.DataBind();
                chartPieSales.Series["Total"]["PieLabelStyle"] = "Disabled";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //}
        }

        //private void dtyearmonth_ValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string sql5 = " select sales_time,  SUM(profit * Qty) as Profit from sales_item " +
        //                       " where sales_time   like  '%" + dtyearmonth.Text + "%' and (status = 1  or status = 3) GROUP BY  sales_time";
        //        DataAccess.ExecuteSQL(sql5);
        //        DataTable dt5 = DataAccess.GetDataTable(sql5);
        //        chartbarProfit.DataSource = dt5;
        //        chartbarProfit.Visible = true;
        //        chartbarProfit.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
        //        chartbarProfit.Series["Profit"].XValueMember = "sales_time";
        //        chartbarProfit.Series["Profit"].YValueMembers = "Profit";
        //        chartbarProfit.DataBind();
        //        chartPieProfit.Series["Profit"]["PieLabelStyle"] = "Disabled";

        //        //Profit Pie chart 
        //        string sql2 = "select  SUM(profit * Qty) as Profit , sales_time from sales_item " +
        //                    " where sales_time like  '%" + dtyearmonth.Text + "%'  and (status = 1  or status = 3)  GROUP BY  sales_time ";
        //        DataTable dt2 = DataAccess.GetDataTable(sql2);
        //        chartPieProfit.DataSource = dt2;
        //        chartPieProfit.Visible = true;
        //        chartPieProfit.Series["Profit"].XValueMember = "sales_time";
        //        chartPieProfit.Series["Profit"].YValueMembers = "Profit";
        //        chartPieProfit.DataBind();


        //        // Sales Pie chart
        //        string sql3 = " select sales_time, SUM(total) as Total from sales_item where sales_time " +
        //                        "  like  '%" + dtyearmonth.Text + "%' and (status = 1  or status = 3)  GROUP BY  sales_time ";
        //        DataTable dt3 = DataAccess.GetDataTable(sql3);
        //        chartPieSales.DataSource = dt3;
        //        chartPieSales.Visible = true;
        //        chartPieSales.Series["Total"].XValueMember = "sales_time";
        //        chartPieSales.Series["Total"].YValueMembers = "Total";
        //        chartPieSales.DataBind();
        //        chartPieSales.Series["Total"]["PieLabelStyle"] = "Disabled";

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "yyyy-MM-dd";

            DTTO.Format = DateTimePickerFormat.Custom;
            DTTO.CustomFormat = "yyyy-MM-dd";

            try
            {
                string sql5 = " select sales_time,  SUM(profit * Qty) as Profit from sales_item " +
                               " where TenentID = " + Tenent.TenentID + " and sales_time   BETWEEN  '" + dtDate.Text + "' AND    '" + DTTO.Text + "' and (status = 1  or status = 3) GROUP BY  sales_time";
               DataTable dt5 = DataAccess.GetDataTable(sql5);
                chartbarProfit.DataSource = dt5;
                chartbarProfit.Visible = true;
                chartbarProfit.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartbarProfit.Series["Profit"].XValueMember = "sales_time";
                chartbarProfit.Series["Profit"].YValueMembers = "Profit";
                chartbarProfit.DataBind();

                //Profit Pie chart 
                string sql2 = "select  SUM(profit * Qty) as Profit , sales_time from sales_item " +
                            " where TenentID = " + Tenent.TenentID + " and sales_time   BETWEEN  '" + dtDate.Text + "' AND    '" + DTTO.Text + "'and (status = 1  or status = 3)  GROUP BY  sales_time ";
                DataTable dt2 = DataAccess.GetDataTable(sql2);
                chartPieProfit.DataSource = dt2;
                chartPieProfit.Visible = true;
                chartPieProfit.Series["Profit"].XValueMember = "sales_time";
                chartPieProfit.Series["Profit"].YValueMembers = "Profit";
                chartPieProfit.DataBind();
                chartPieProfit.Series["Profit"]["PieLabelStyle"] = "Disabled";

                // Sales Pie chart
                string sql3 = " select sales_time, SUM(total) as Total from sales_item where TenentID = " + Tenent.TenentID + " and sales_time " +
                                "  BETWEEN  '" + dtDate.Text + "' AND    '" + DTTO.Text + "' and (status = 1  or status = 3)  GROUP BY  sales_time ";
                DataAccess.ExecuteSQL(sql3);
                DataTable dt3 = DataAccess.GetDataTable(sql3);
                chartPieSales.DataSource = dt3;
                chartPieSales.Visible = true;
                chartPieSales.Series["Total"].XValueMember = "sales_time";
                chartPieSales.Series["Total"].YValueMembers = "Total";
                chartPieSales.DataBind();
                chartPieSales.Series["Total"]["PieLabelStyle"] = "Disabled";


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
                chartbarProfit.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                chartbarProfit.Printing.PrintPreview();

                chartPieProfit.Dock = DockStyle.Fill;
                chartPieSales.Dock = DockStyle.Fill;

                chartPieSales.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                chartPieSales.Printing.PrintPreview();

                chartPieProfit.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                chartPieProfit.Printing.PrintPreview();

            }
            catch
            {

            }
        }

        private void btnTopArea_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Top10Area"] != null)
            {
                Application.OpenForms["Top10Area"].Close();
            }
            this.Refresh();
            Report.Top10Area go = new Report.Top10Area();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        private void btnDraftTransaction_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DateToDateDraftTransection"] != null)
            {
                Application.OpenForms["DateToDateDraftTransection"].Close();
            }
            this.Refresh();
            Report.DateToDateDraftTransection go = new Report.DateToDateDraftTransection();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        private void btnPendingDelevery_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DeliveryReport"] != null)
            {
                Application.OpenForms["DeliveryReport"].Close();
            }
            this.Refresh();
            Report.DeliveryReport go = new Report.DeliveryReport();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        private void pendingKitchen_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PendingKitchen"] != null)
            {
                Application.OpenForms["PendingKitchen"].Close();
            }
            this.Refresh();
            Report.PendingKitchen go = new Report.PendingKitchen();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        private void btnSlowmovingProduct_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Top10Product"] != null)
            {
                Application.OpenForms["Top10Product"].Close();
            }
            this.Refresh();
            Report.Top10Product go = new Report.Top10Product();
            go.ReportName = "Top Slow moving Product";
            go.Limit = "10";
            go.OrderBY = "asc";
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
        }

        public void Last30daysReport(string startDate, string EndDate)
        {
            DateTime EndDate1 = Convert.ToDateTime(EndDate);
            EndDate1 = EndDate1.AddDays(1);
            EndDate = EndDate1.ToString("yyyy-MM-dd");

            try
            {
                string sql = " select  Appointment.ID as 'Appointment No' , (tbl_customer.Name ||' - '|| tbl_customer.NameArabic) as 'Customer' ,Title , strftime('%Y-%m-%d  %H:%M',ExpStartDate) as 'Start Date and Time',Color " +
                             " from Appointment  left JOIN tbl_customer on Appointment.C_ID = tbl_customer.ID and Appointment.TenentID = tbl_customer.TenentID  " +
                             " where Appointment.TenentID=" + Tenent.TenentID + " and Deleted = 1 and  Appointment.ExpStartDate >=  '" + startDate + "'  and Appointment.ExpStartDate <= '" + EndDate + "' " +
                             " order by Appointment.ExpStartDate, Appointment.ID ";

                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagrdReportDetails.DataSource = dt1;
                datagrdReportDetails.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns["Color"].Visible = false;
                datagrdReportDetails.Columns["Action"].DisplayIndex = 5;
                datagrdReportDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        private void datagrdReportDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];
                string id = row.Cells["Appointment No"].Value.ToString();
                if (Application.OpenForms["AppointmentS1"] != null)
                {
                    AppointmentS1 mkc1 = (AppointmentS1)Application.OpenForms["AppointmentS1"];
                    mkc1.AppointID = id;
                    mkc1.AppointStartDate = dtDate.Value.ToString("yyyy-MM-dd");
                    mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                    mkc1.BringToFront();
                    mkc1.WindowState = FormWindowState.Maximized;                    
                }
                else
                {
                    AppointmentS1 go = new AppointmentS1();
                    go.AppointID = id;
                    go.AppointStartDate = dtDate.Value.ToString("yyyy-MM-dd");
                    go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                    go.WindowState = FormWindowState.Maximized;
                    go.Show();
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

    }
}
