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
    public partial class CommissionReport : Form
    {
        public CommissionReport()
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


            datagrdReportDetails.EnableHeadersVisualStyles = false;
            datagrdReportDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            BindEmploayee();

            databind(dtstart, dtend);
        }

        public void BindEmploayee()
        {
            //comboEmployee

            comboEmployee.Items.Clear();
            comboEmployee.Items.Add("-- All Employee --");
            //Employee Databind 
            string sqlCust = "select * from usermgt where tenentid=" + Tenent.TenentID + " and (position = 'Spa Employee' or position = 'Admin') ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            string First = "";
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    string Emp_Name = dtCust.Rows[i]["Name"].ToString();
                    if (First == "")
                    {
                        First = Emp_Name;
                        lblFirstEmployee.Text = First;
                    }
                    comboEmployee.Items.Add(Emp_Name);
                }
            }
            comboEmployee.Text = "-- All Employee --";

            if (dtCust != null)
            {
                AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
                foreach (DataRow rw in dtCust.Rows)
                {
                    string Val = rw["Name"].ToString();
                    AutoItem.Add(Val);

                }
                comboEmployee.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboEmployee.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboEmployee.AutoCompleteCustomSource = AutoItem;
            }

            //comboEmployee.DataSource = dtCust;
            //comboEmployee.DisplayMember = "Name";
            //comboEmployee.ValueMember = "id";
        }

        public void databind(string StartDate, string EndDate)
        {

            try
            {
                DateTime EndDate1 = Convert.ToDateTime(EndDate);
                EndDate1 = EndDate1.AddDays(1);
                EndDate = EndDate1.ToString("yyyy-MM-dd");
                string isEmployee = comboEmployee.Text == "-- All Employee --" ? "" : "and AppointmentReceipe.EmpOperator='" + comboEmployee.Text + "'";



                string StrInput = "select  Appointment.ID as 'App.No', AppointmentReceipe.JobID, (select ACTIVITYE  from CRMMainActivities  where MasterCode=AppointmentReceipe.JobID) as 'Title', strftime('%Y-%m-%d  %H:%M',ExpStartDate) as 'Start Date', strftime('%Y-%m-%d  %H:%M',ExpEndDate) as 'End Date'," +
                                    "(100*(QtyIntoCostprice))/(Qty) as 'Job Value',Qty as '%',(CostPrice*Qty) as 'Amt'" +
                                    ",(select sum(PaidAmt) from CommisionPayment where CommisionPayment.TenentID=" + Tenent.TenentID + " and AppointmentReceipe.JobID=CommisionPayment.JobNo and AppointmentReceipe.ItemCode=CommisionPayment.ItemCode ) as PaidAmt," +
                                    "(QtyIntoCostprice) - (select sum(PaidAmt) from CommisionPayment where CommisionPayment.TenentID=" + Tenent.TenentID + " and AppointmentReceipe.JobID=CommisionPayment.JobNo and AppointmentReceipe.ItemCode=CommisionPayment.ItemCode ) as 'Balance',(select USERNAME from CRMActivities where MasterCode=AppointmentReceipe.JobID) as 'Employee',customer " +
                                    "from AppointmentReceipe inner JOIN Appointment on AppointmentReceipe.AppointmentID = Appointment.ID and AppointmentReceipe.TenentID = Appointment.TenentID  " +
                                    "where  AppointmentReceipe.TenentID=" + Tenent.TenentID + " and Deleted = 1 and  Appointment.ExpStartDate >=  '" + StartDate + "'  and Appointment.ExpStartDate <= '" + EndDate + "' " +
                                    "and AppointmentReceipe.RecipeType='Commission' and Appointment.JobDone=1 " + isEmployee + "";

                DataTable dtInput = DataAccess.GetDataTable(StrInput);
                if (dtInput.Rows.Count > 0)
                {
                    datagrdReportDetails.DataSource = dtInput;

                    datagrdReportDetails.Columns[0].Visible = false;
                    datagrdReportDetails.Columns[3].Visible = false;
                    datagrdReportDetails.Columns[4].Visible = false;
                    datagrdReportDetails.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Title"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                else
                {
                    datagrdReportDetails.DataSource = null;
                }


            }
            catch //(Exception)
            {
                datagrdReportDetails.DataSource = null;
            }
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

            printDocument1.DocumentName = "Commission Reports";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            printDocument1, true, true, Header + " Commission Reports \n", new Font("Baskerville Old Face", 14,
            FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);


            return true;
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

       

        private void btnrefrash_Click(object sender, EventArgs e)
        {
            if (dtStartDate.Text != "" && dtEndDate.Text != "")
                databind(dtStartDate.Text, dtEndDate.Text);
        }

        private void comboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                databind(dtStartDate.Text, dtEndDate.Text);
          
        }
    }
}
