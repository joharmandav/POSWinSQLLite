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
using System.Resources;
using System.Globalization;
using System.Text.RegularExpressions;


namespace supershop
{
    public partial class CommissionPay : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public CommissionPay()
        {
            InitializeComponent();





            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";
            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";

            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;
            BindEmploayee();
            Bindfirst(StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"));

        }

        public void Bindfirst(string StartDate, string EndDate)
        {

            try
            {
                DateTime EndDate1 = Convert.ToDateTime(EndDate);
                EndDate1 = EndDate1.AddDays(1);
                EndDate = EndDate1.ToString("yyyy-MM-dd");
                string isEmployee = comboEmployee.Text == "-- All Employee --" ? "" : "and AppointmentReceipe.EmpOperator='" + comboEmployee.Text + "'";

                if (isEmployee != "")
                {




                    string StrInput1 = "select  Sum(CostPrice*Qty) as 'Total'" +
                                   "from AppointmentReceipe inner JOIN Appointment on AppointmentReceipe.AppointmentID = Appointment.ID and AppointmentReceipe.TenentID = Appointment.TenentID " +
                                   "where  AppointmentReceipe.TenentID=" + Tenent.TenentID + " and Deleted = 1 " +
                                   "and AppointmentReceipe.RecipeType='Commission' and Appointment.JobDone=1 " + isEmployee + "";
                    DataTable dtitemcode = DataAccess.GetDataTable(StrInput1);

                    double CommTotal = Convert.ToDouble(dtitemcode.Rows[0][0]);
                    lblCommTotal.Text = CommTotal.ToString("N2");
                    string q2check = "select * from CommisionPayment where TenentID=" + Tenent.TenentID + " and Employee='" + comboEmployee.Text + "'";
                    DataTable dq2check = DataAccess.GetDataTable(q2check);
                    if (dq2check.Rows.Count > 0)
                    {
                        string q2 = "select sum(PaidAmt) from CommisionPayment where TenentID=" + Tenent.TenentID + " and Employee='" + comboEmployee.Text + "'";
                        DataTable dq2 = DataAccess.GetDataTable(q2);

                        double PaidTotal = Convert.ToDouble(dq2.Rows[0][0]);
                        lblCommPaid.Text = PaidTotal.ToString("N2");
                        lblCommDue.Text = (CommTotal - PaidTotal).ToString("N2");
                    }
                    else
                    {
                        lblCommDue.Text = (CommTotal - 0).ToString("N2");
                    }

                }

                string StrInput = "select  Appointment.ID as 'App.No', AppointmentReceipe.JobID, (select ACTIVITYE  from CRMMainActivities  where MasterCode=AppointmentReceipe.JobID) as 'Title', strftime('%Y-%m-%d  %H:%M',ExpStartDate) as 'S Date', strftime('%Y-%m-%d  %H:%M',ExpEndDate) as 'E Date'," +
                                    "(100*(QtyIntoCostprice))/(Qty) as 'Job Value',Qty as '%',CostPrice*Qty as 'Amt'" +
                                    ",(select sum(PaidAmt) from CommisionPayment where CommisionPayment.TenentID=" + Tenent.TenentID + " and AppointmentReceipe.JobID=CommisionPayment.JobNo and AppointmentReceipe.ItemCode=CommisionPayment.ItemCode ) as PaidAmt," +
                                    "(QtyIntoCostprice) - (select sum(PaidAmt) from CommisionPayment where CommisionPayment.TenentID=" + Tenent.TenentID + " and AppointmentReceipe.JobID=CommisionPayment.JobNo and AppointmentReceipe.ItemCode=CommisionPayment.ItemCode ) as 'Bal',(select USERNAME from CRMActivities where MasterCode=AppointmentReceipe.JobID) as 'Emp',customer as Cust " +
                                    "from AppointmentReceipe inner JOIN Appointment on AppointmentReceipe.AppointmentID = Appointment.ID and AppointmentReceipe.TenentID = Appointment.TenentID  " +
                                    "where  AppointmentReceipe.TenentID=" + Tenent.TenentID + " and Deleted = 1 and  Appointment.ExpStartDate >=  '" + StartDate + "'  and Appointment.ExpStartDate <= '" + EndDate + "' " +
                                    "and AppointmentReceipe.RecipeType='Commission' and Appointment.JobDone=1 " + isEmployee + "";

                DataTable dtInput = DataAccess.GetDataTable(StrInput);
                if (dtInput.Rows.Count > 0)
                {
                    datagrdReportDetails.DataSource = dtInput;
                   
                    datagrdReportDetails.Columns[0].Visible = false;
                    datagrdReportDetails.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                   // datagrdReportDetails.Columns["Title"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                else
                {
                    datagrdReportDetails.DataSource = null;
                }


            }
            catch //(Exception)
            {
                datagrdReportDetails.DataSource = null; Clean();
            }
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
        private void CommissionPay_Load(object sender, EventArgs e)
        {
            try
            {
                datagrdReportDetails.EnableHeadersVisualStyles = false;
                datagrdReportDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                datagrdReportDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                datagrdReportDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
            catch
            {
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if(lblCommPaid.Text==lblCommTotal.Text)
            {
                MessageBox.Show("This Employee Payment is Up to Date.");
                return;
            }
            if (Application.OpenForms["CommissionPayment"] != null)
            {
                Application.OpenForms["CommissionPayment"].BringToFront();
            }
            else
            {
                CommissionPayment go = new CommissionPayment(comboEmployee.Text);
                go.Show();
            }


        }

        private void btnCashierRefresh_Click(object sender, EventArgs e)
        {
            Clean();
            Bindfirst(dtStartDate.Text, dtEndDate.Text);
        }

        private void comboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEmployee.Text == "-- All Employee --")
                btnSave.Visible = false;
            else
                btnSave.Visible = true;
            Clean();
            Bindfirst(dtStartDate.Text, dtEndDate.Text);
            if (lblCommPaid.Text == lblCommTotal.Text && lblCommPaid.Text!="" )
            {
                btnSave.Visible = false;
            }
        }

        private void picCloseEvent_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.datagrdReportDetails.RowsDefaultCellStyle.BackColor = Color.White;
                this.datagrdReportDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                datagrdReportDetails.Columns["Title"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
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
        DataGridViewPrinter MyDataGridViewPrinter1;
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

            printDocument1.DocumentName = "Commission Report";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter1 = new DataGridViewPrinter(datagrdReportDetails,
            printDocument1, true, true, Header + " Commission Report \n", new Font("Baskerville Old Face", 13,
            FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            // tosend = "<html><table>" + tosend + "</table></html>";
            //  mail.IsBodyHtml = true;
            //mail.Body = tosend;

            //else

            //    MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            //    printDocument1, false, true, Header + "   Sales Report   \n", new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
        public void Clean()
        {
            lblCommDue.Text = "";
            lblCommPaid.Text = "";
            lblCommTotal.Text = "";
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter1.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clean();
            Bindfirst(dtStartDate.Text, dtEndDate.Text);
        }

    }
}
