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
    public partial class AppointmentS1 : Form
    {
        public AppointmentS1()
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


            //DatagridJob
            DataGridViewButtonColumn Assign1 = new DataGridViewButtonColumn();
            this.DatagridJob.Columns.Add(Assign1);
            Assign1.HeaderText = "Action";
            Assign1.Text = "Action عمل";
            Assign1.Name = "Action";
            Assign1.ToolTipText = "Action";
            Assign1.UseColumnTextForButtonValue = true;

            lblStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";
            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";

            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;

            dtStartDate.Text = StartDate.ToString("yyyy-MM-dd");
            dtEndDate.Text = EndDate.ToString("yyyy-MM-dd");
        }

        public string AppointID
        {
            set
            {
                lblApoint.Text = value;
                Last30daysJobReport();
            }
            get
            {
                return lblApoint.Text;
            }
        }
        public string AppointStartDate
        {
            set
            {
                dtStartDate.Text = value;
            }
            get
            {
                return dtStartDate.Text;
            }
        }

        private void AppointmentS_Load(object sender, EventArgs e)
        {


            if (UserInfo.usertype != "1")
            {
                button1.Visible = false;
            }

            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }

        public void Last30daysReport(string startDate, string EndDate)
        {
            try
            {

                DateTime EndDate1 = Convert.ToDateTime(EndDate);
                EndDate1 = EndDate1.AddDays(1);
                EndDate = EndDate1.ToString("yyyy-MM-dd");


                if (lblStartDate.Text == "")
                {
                    // MessageBox.Show("Please Select Date ");
                }
                else
                {
                    string sql = "";
                    if (UserInfo.usertype != "1")
                    {
                        sql = " select  Appointment.ID as 'Appointment No' , (tbl_customer.Name ||' - '|| tbl_customer.NameArabic) as 'Customer' ,Title ," +
                              " strftime('%Y-%m-%d  %H:%M',ExpStartDate) as 'Start Date and Time',Color " +
                              " from Appointment  left JOIN tbl_customer on Appointment.C_ID = tbl_customer.ID and Appointment.TenentID = tbl_customer.TenentID " +
                              " inner join CRMMainActivities on  CRMMainActivities.MyID = Appointment.ID and CRMMainActivities.TenentID = Appointment.TenentID " +
                              " where Appointment.TenentID=" + Tenent.TenentID + " and Deleted = 1 and lower(CRMMainActivities.USERNAME) = '" + UserInfo.UserName.ToLower() + "' " +
                              " and  Appointment.ExpStartDate >=  '" + startDate + "'  and Appointment.ExpStartDate <= '" + EndDate + "'  " +
                              " Group by  Appointment.ID order by Appointment.ExpStartDate, Appointment.ID ";
                    }
                    else
                    {
                        sql = " select  Appointment.ID as 'Appointment No' , (tbl_customer.Name ||' - '|| tbl_customer.NameArabic) as 'Customer' ,Title , strftime('%Y-%m-%d  %H:%M',ExpStartDate) as 'Start Date and Time',Color " +
                              " from Appointment  left JOIN tbl_customer on Appointment.C_ID = tbl_customer.ID and Appointment.TenentID = tbl_customer.TenentID   " +
                              " inner join CRMMainActivities on  CRMMainActivities.MyID = Appointment.ID and CRMMainActivities.TenentID = Appointment.TenentID " +
                              " where Appointment.TenentID=" + Tenent.TenentID + " and Deleted = 1 and  Appointment.ExpStartDate >=  '" + startDate + "'  and Appointment.ExpStartDate <= '" + EndDate + "' " +
                              " Group by  Appointment.ID order by Appointment.ExpStartDate, Appointment.ID ";
                    }

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns["Appointment No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Customer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Title"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    datagrdReportDetails.Columns["Start Date and Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Color"].Visible = false;
                    datagrdReportDetails.Columns["Action"].DisplayIndex = 5;
                    datagrdReportDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        public void Last30daysJobReport()
        {
            try
            {
                string sql = "";

                if (lblApoint.Text != "" && lblApoint.Text != "-")
                {
                    int AppointmentID = Convert.ToInt32(lblApoint.Text);
                    bool ALLJOBDONEFLAG = CheckJobAllDone(AppointmentID);
                    if (ALLJOBDONEFLAG == true)
                    {
                        btnCreateInvoice.Visible = true;
                    }
                    else
                    {
                        btnCreateInvoice.Visible = false;
                    }

                    bool Check = CheckinvoiceCreated(AppointmentID);
                    if (Check == true)
                    {
                        AddJob.Visible = false;
                    }
                    else
                    {
                        AddJob.Visible = true;
                    }

                    if (UserInfo.usertype != "1")
                    {
                        if (chkPending.Checked == true)
                        {
                            sql = " select CMA.MasterCode as 'Job ID',AP.Customer,CMA.ACTIVITYE as 'Job Title',CMA.UseReciepeName as 'Use Service Template',CMA.Remarks, " +
                              " CMA.USERNAME as 'Employee',  strftime('%Y-%m-%d  %H:%M',CA.InitialDate) as 'Start Date',strftime('%Y-%m-%d  %H:%M',CA.DeadLineDate) as 'End Date',CMA.MyStatus as 'InvoiceNO' " +
                              " from CRMMainActivities CMA " +
                              " inner join CRMActivities CA on CA.TenentID = CMA.TenentID and CA.MasterCode = CMA.MasterCode " +
                              " inner join Appointment AP on AP.ID = CMA.MyID and AP.TenentID = CMA.TenentID  " +
                              " where CMA.TenentID = " + Tenent.TenentID + " and CMA.MyID = '" + lblApoint.Text + "' and CMA.USERNAME = '" + UserInfo.UserName + "' and  (DeadLineDate =='' or DeadLineDate is null ) ";
                        }
                        else if (chkComplated.Checked == true)
                        {
                            sql = " select CMA.MasterCode as 'Job ID',AP.Customer,CMA.ACTIVITYE as 'Job Title',CMA.UseReciepeName as 'Use Service Template',CMA.Remarks, " +
                              " CMA.USERNAME as 'Employee',  strftime('%Y-%m-%d  %H:%M',CA.InitialDate) as 'Start Date',strftime('%Y-%m-%d  %H:%M',CA.DeadLineDate) as 'End Date',CMA.MyStatus as 'InvoiceNO' " +
                              " from CRMMainActivities CMA " +
                              " inner join CRMActivities CA on CA.TenentID = CMA.TenentID and CA.MasterCode = CMA.MasterCode " +
                              " inner join Appointment AP on AP.ID = CMA.MyID and AP.TenentID = CMA.TenentID  " +
                              " where CMA.TenentID = " + Tenent.TenentID + " and CMA.MyID = '" + lblApoint.Text + "' and CMA.USERNAME = '" + UserInfo.UserName + "' and  (DeadLineDate !='' or DeadLineDate is not null ) ";
                        }
                        else
                        {
                            sql = " select CMA.MasterCode as 'Job ID',AP.Customer,CMA.ACTIVITYE as 'Job Title',CMA.UseReciepeName as 'Use Service Template',CMA.Remarks, " +
                              " CMA.USERNAME as 'Employee',  strftime('%Y-%m-%d  %H:%M',CA.InitialDate) as 'Start Date',strftime('%Y-%m-%d  %H:%M',CA.DeadLineDate) as 'End Date',CMA.MyStatus as 'InvoiceNO' " +
                              " from CRMMainActivities CMA " +
                              " inner join CRMActivities CA on CA.TenentID = CMA.TenentID and CA.MasterCode = CMA.MasterCode " +
                              " inner join Appointment AP on AP.ID = CMA.MyID and AP.TenentID = CMA.TenentID  " +
                              " where CMA.TenentID = " + Tenent.TenentID + " and CMA.MyID = '" + lblApoint.Text + "' and CMA.USERNAME = '" + UserInfo.UserName + "' ";
                        }

                    }
                    else
                    {
                        if (chkPending.Checked == true)
                        {
                            sql = " select CMA.MasterCode as 'Job ID',AP.Customer,CMA.ACTIVITYE as 'Job Title',CMA.UseReciepeName as 'Use Service Template',CMA.Remarks, " +
                                   " CMA.USERNAME as 'Employee',  strftime('%Y-%m-%d  %H:%M',CA.InitialDate) as 'Start Date',strftime('%Y-%m-%d  %H:%M',CA.DeadLineDate) as 'End Date',CMA.MyStatus as 'InvoiceNO' " +
                                   " from CRMMainActivities CMA " +
                                   " inner join CRMActivities CA on CA.TenentID = CMA.TenentID and CA.MasterCode = CMA.MasterCode " +
                                   " inner join Appointment AP on AP.ID = CMA.MyID and AP.TenentID = CMA.TenentID  " +
                                   " where CMA.TenentID = " + Tenent.TenentID + " and CMA.MyID = '" + lblApoint.Text + "' and  (DeadLineDate =='' or DeadLineDate is null ) ";
                        }
                        else if (chkComplated.Checked == true)
                        {
                            sql = " select CMA.MasterCode as 'Job ID',AP.Customer,CMA.ACTIVITYE as 'Job Title',CMA.UseReciepeName as 'Use Service Template',CMA.Remarks, " +
                                  " CMA.USERNAME as 'Employee',  strftime('%Y-%m-%d  %H:%M',CA.InitialDate) as 'Start Date',strftime('%Y-%m-%d  %H:%M',CA.DeadLineDate) as 'End Date',CMA.MyStatus as 'InvoiceNO' " +
                                  " from CRMMainActivities CMA " +
                                  " inner join CRMActivities CA on CA.TenentID = CMA.TenentID and CA.MasterCode = CMA.MasterCode " +
                                  " inner join Appointment AP on AP.ID = CMA.MyID and AP.TenentID = CMA.TenentID  " +
                                  " where CMA.TenentID = " + Tenent.TenentID + " and CMA.MyID = '" + lblApoint.Text + "' and  (DeadLineDate !='' or DeadLineDate is not null ) ";
                        }
                        else
                        {
                            sql = " select CMA.MasterCode as 'Job ID',AP.Customer,CMA.ACTIVITYE as 'Job Title',CMA.UseReciepeName as 'Use Service Template',CMA.Remarks, " +
                                  " CMA.USERNAME as 'Employee',  strftime('%Y-%m-%d  %H:%M',CA.InitialDate) as 'Start Date',strftime('%Y-%m-%d  %H:%M',CA.DeadLineDate) as 'End Date',CMA.MyStatus as 'InvoiceNO' " +
                                  " from CRMMainActivities CMA " +
                                  " inner join CRMActivities CA on CA.TenentID = CMA.TenentID and CA.MasterCode = CMA.MasterCode " +
                                  " inner join Appointment AP on AP.ID = CMA.MyID and AP.TenentID = CMA.TenentID  " +
                                  " where CMA.TenentID = " + Tenent.TenentID + " and CMA.MyID = '" + lblApoint.Text + "' ";
                        }
                    }

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    DatagridJob.DataSource = dt1;
                    DatagridJob.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //DatagridJob.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //DatagridJob.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //DatagridJob.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    DatagridJob.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //DatagridJob.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    ////DatagridJob.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    DatagridJob.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //DatagridJob.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //DatagridJob.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //DatagridJob.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    DatagridJob.Columns["Action"].DisplayIndex = 9;
                    DatagridJob.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }

        }

        private void DatagridJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == DatagridJob.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    int cal = Cursor.Position.X;
                    int CursorX = cal - 400;
                    int CursorY = Cursor.Position.Y;
                    if (e.RowIndex >= 6)
                    {
                        CursorY = 325;
                    }
                    else
                    {
                        CursorY = 325;
                    }

                    DataGridViewRow row = DatagridJob.Rows[e.RowIndex];

                    string id = lblApoint.Text;
                    string Job_ID = row.Cells["Job ID"].Value.ToString();

                    if (Application.OpenForms["Job_Action"] != null)
                    {
                        Application.OpenForms["Job_Action"].Close();
                        Job_Action go = new Job_Action(CursorX, CursorY);
                        go.Appintment_id = id;
                        go.JobID = Job_ID;
                        go.Show();
                    }
                    else
                    {
                        Job_Action go = new Job_Action(CursorX, CursorY);
                        go.Appintment_id = id;
                        go.JobID = Job_ID;
                        go.Show();
                    }
                }
                else
                {
                    int cal = Cursor.Position.X;
                    int CursorX = cal - 400;
                    int CursorY = Cursor.Position.Y;

                    if (e.RowIndex >= 6)
                    {
                        CursorY = 325;
                    }
                    else
                    {
                        CursorY = 325;
                    }

                    DataGridViewRow row = DatagridJob.Rows[e.RowIndex];

                    string id = lblApoint.Text;
                    string Job_ID = row.Cells["Job ID"].Value.ToString();
                    if (Application.OpenForms["Job_Action"] != null)
                    {
                        Application.OpenForms["Job_Action"].Close();
                        Job_Action go = new Job_Action(CursorX, CursorY);
                        go.Appintment_id = id;
                        go.JobID = Job_ID;
                        go.Show();
                    }
                    else
                    {
                        Job_Action go = new Job_Action(CursorX, CursorY);
                        go.Appintment_id = id;
                        go.JobID = Job_ID;
                        go.Show();
                    }
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DashBoard"] != null)
            {
                DashBoard go = (DashBoard)Application.OpenForms["DashBoard"];
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }
            else
            {
                DashBoard go = new DashBoard();
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }
            this.Close();
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }

        private void btnCashierRefresh_Click(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }

        private void datagrdReportDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == datagrdReportDetails.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    int cal = Cursor.Position.X;
                    int CursorX = cal - 350;
                    int CursorY = Cursor.Position.Y;
                    if (e.RowIndex >= 6)
                    {
                        CursorY = 476;
                    }

                    DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];

                    string id = row.Cells["Appointment No"].Value.ToString();
                    if (Application.OpenForms["Appointment_Action"] != null)
                    {
                        Application.OpenForms["Appointment_Action"].Close();
                        Appointment_Action go = new Appointment_Action(CursorX, CursorY);
                        go.Appintment_id = id;
                        go.Show();
                    }
                    else
                    {
                        Appointment_Action go = new Appointment_Action(CursorX, CursorY);
                        go.Appintment_id = id;
                        go.Show();
                    }
                }
                else
                {
                    DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];
                    string id = row.Cells["Appointment No"].Value.ToString();
                    lblApoint.Text = id;
                    Last30daysJobReport();
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Add_Appointment"] != null)
            {
                Application.OpenForms["Add_Appointment"].BringToFront();
            }
            else
            {
                Add_Appointment go = new Add_Appointment(DateTime.Now);
                go.Show();
            }
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    bool ISrun = backSyncro.isRun;
        //    if (ISrun != true)
        //    {
        //        Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        //        Last30daysJobReport();
        //    }
        //}

        private void btnshowJobs_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ShowJobs"] != null)
            {
                Application.OpenForms["ShowJobs"].Close();
                ShowJobs go = new ShowJobs();
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }
            else
            {
                ShowJobs go = new ShowJobs();
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }
        }

        private void AddJob_Click(object sender, EventArgs e)
        {
            if (lblApoint.Text != "-")
            {
                if (Application.OpenForms["Add_Job"] != null)
                {
                    Application.OpenForms["Add_Job"].Close();
                    Add_Job go = new Add_Job();
                    go.Appintment_id = lblApoint.Text;
                    go.Show();
                }
                else
                {
                    Add_Job go = new Add_Job();
                    go.Appintment_id = lblApoint.Text;
                    go.Show();
                }
            }
            else
            {

            }

        }

        private void DatagridJob_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow Myrow in DatagridJob.Rows)
            {
                int MasterCODE = Convert.ToInt32(Myrow.Cells["Job ID"].Value);
                Myrow.DefaultCellStyle.BackColor = get_jobcolor(MasterCODE);
            }
        }

        public Color get_jobcolor(int MasterCODE)
        {
            bool flagdone = Checkjobdone(MasterCODE);
            if (flagdone == true)
            {
                return Color.Red;
            }
            else
            {
                bool flagstart = Checkjobstart(MasterCODE);
                if (flagstart == true)
                {
                    return Color.Green;
                }
                else
                {
                    return Color.Orange;
                }
            }
        }

        public bool Checkjobstart(int MasterCODE)
        {
            string sql = "select * from CRMActivities where TenentID=" + Tenent.TenentID + "  and MasterCODE = " + MasterCODE + " and  ( InitialDate =='' or InitialDate is null ) ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Checkjobdone(int MasterCODE)
        {
            string sql = "select * from CRMActivities where TenentID=" + Tenent.TenentID + "  and MasterCODE = " + MasterCODE + " and  (DeadLineDate =='' or DeadLineDate is null ) ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckJobAllDone(int AppointmentID)
        {
            string Sql1 = "select * from CRMMainActivities where TenentID = " + Tenent.TenentID + " and MyID = '" + AppointmentID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(Sql1);
            if (dt1 != null)
            {
                string sql = "select * from CRMMainActivities where TenentID = " + Tenent.TenentID + " and MyID = '" + AppointmentID + "' and jobDone = 1 and ( Mystatus is null or Mystatus = '') ";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count == dt1.Rows.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool CheckinvoiceCreated(int AppointmentID)
        {
            string sql = "select * from CRMMainActivities where TenentID = " + Tenent.TenentID + " and MyID = '" + AppointmentID + "' and ( Mystatus is not null and Mystatus != '') ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            string invoiceno = create_invoice();
            if (invoiceno != "")
            {
                if (Application.OpenForms["SalesRegister"] != null)
                {
                    SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                    mkc1.Close();
                }

                string sqlsale = "select * from sales_item where TenentID = " + Tenent.TenentID + " and InvoiceNO = '" + invoiceno + "'";
                DataTable dtsale = DataAccess.GetDataTable(sqlsale);
                if (dtsale.Rows.Count > 0)
                {
                    string sql = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + " and MyID = '" + lblApoint.Text + "' and jobDone = 1 and ( Mystatus is null or Mystatus = '') ";
                    DataTable dt = DataAccess.GetDataTable(sql);

                    if (dt.Rows.Count > 0)
                    {
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql1 = " update CRMMainActivities set MyStatus='" + invoiceno + "',  " +
                                      " UploadDate = '" + UploadDate + "', Uploadby = '" + UserInfo.UserName + "', SynID = 2 " +
                                      " where TenentID = " + Tenent.TenentID + " and MyID = '" + lblApoint.Text + "' and jobDone = 1 and ( Mystatus is null or Mystatus = '')  ";
                        DataAccess.ExecuteSQL(sql1);
                        Datasyncpso.insert_Live_sync(sql1, "CRMMainActivities", "UPDATE");
                    }

                    string sql4 = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + " and MyID = '" + lblApoint.Text + "' and JobDone = 0 ";
                    DataTable dt4 = DataAccess.GetDataTable(sql4);

                    if (dt4.Rows.Count < 1)
                    {
                        string sql2 = "select * from Appointment where TenentID=" + Tenent.TenentID + "  and LocationID=1 and ID = '" + lblApoint.Text + "' ";
                        DataTable dt2 = DataAccess.GetDataTable(sql2);

                        if (dt2.Rows.Count > 0)
                        {
                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            string sql1 = " update Appointment set JobDone='1' , " +
                                          " Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2 " +
                                          " where TenentID = " + Tenent.TenentID + "  and LocationID=1 and ID = '" + lblApoint.Text + "'  ";
                            DataAccess.ExecuteSQL(sql1);
                            Datasyncpso.insert_Live_sync(sql1, "Appointment", "UPDATE");

                            string ActivityName = "Appointment Done";
                            string LogData = "Appointment Done with Appointment no = " + lblApoint.Text + " ";
                            Login.InsertUserLog(ActivityName, LogData);
                        }
                    }

                    DialogResult result = MessageBox.Show("Your invoice has been save in Draft mode cashier \n with Invoice no [" + invoiceno + "] Do you Want To Final This ?  ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string InvoiceNO = invoiceno;

                        UserInfo.TranjationPerform = "Draft";

                        if (Application.OpenForms["SalesRegister"] != null)
                        {
                            SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                            mkc1.OrderNO = InvoiceNO;
                            mkc1.WindowState = FormWindowState.Maximized;
                            mkc1.Show();
                        }
                        else
                        {
                            SalesRegister mkc1 = new SalesRegister();
                            mkc1.OrderNO = InvoiceNO;
                            mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                            mkc1.Show();
                        }

                        this.Close();
                    }

                    bool ISrun = backSyncro.isRun;
                    if (ISrun != true)
                    {
                        Last30daysReport(dtStartDate.Text, dtEndDate.Text);
                        Last30daysJobReport();
                    }

                }
            }

        }

        public string create_invoice()
        {
            string invoiceNO = "";

            string sql3 = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + " and MyID = '" + lblApoint.Text + "' and jobDone = 1 and ( Mystatus is null or Mystatus = '')";
            DataTable dt1 = DataAccess.GetDataTable(sql3);
            if (dt1.Rows.Count > 0)
            {
                string recNostr = "";
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string recVanno = dt1.Rows[i]["UseReciepeID"].ToString();
                    int recNo = Convert.ToInt32(recVanno);
                    recNostr = recNostr + "," + recNo;
                }
                recNostr = recNostr.Trim();
                recNostr = recNostr.TrimStart(',');
                recNostr = recNostr.TrimEnd(',');

                string StrInput = " SELECT (Receipe_Menegement.ItemCode || ' - ' || product_name || ' - ' || Receipe_Menegement.UOM ) as Items,purchase.CustItemCode as 'CustItemCode', " +
                        " Receipe_Menegement.Qty" +
                        " FROM  purchase " +
                        " Inner Join Receipe_Menegement on purchase.product_id = Receipe_Menegement.ItemCode " +
                        " where purchase.TenentID=" + Tenent.TenentID + " and product_id = Receipe_Menegement.ItemCode and Receipe_Menegement.recNo in (" + recNostr + ") and Receipe_Menegement.IOSwitch = 'Output' ";
                //" and Receipe_Menegement.IOSwitch = 'Input' ";
                DataTable dtInput = DataAccess.GetDataTable(StrInput);

                if (dtInput.Rows.Count > 0)
                {
                    string CustName = getAppointmentCustomer();

                    if (Application.OpenForms["SalesRegister"] == null)
                    {
                        SalesRegister go = new SalesRegister();
                        go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                        go.CustomerPage = "AppointmentS1";
                        go.CustName = CustName;
                        go.Show();

                    }
                    else
                    {
                        SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                        mkc1.Close();

                        SalesRegister go = new SalesRegister();
                        go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                        go.CustomerPage = "AppointmentS1";
                        go.CustName = CustName;
                        go.Show();
                    }

                    for (int i = 0; i < dtInput.Rows.Count; i++)
                    {
                        string Itme = dtInput.Rows[i]["Items"].ToString();

                        string product_id = Itme.Split('-')[0].Trim();
                        string UOMID = Itme.Split('-')[2].Trim();
                        int UOM = Convert.ToInt32(UOMID);
                        string UOMNAME = Add_Item.getuomName(UOM);
                        string CustItemCode = dtInput.Rows[i]["CustItemCode"].ToString();
                        string ButtonTag = product_id + "~" + UOMNAME + "," + CustItemCode;
                        //(dataReader["product_id"] + "~" + dataReader["UOMID"] + "," + dataReader["CustItemCode"]);

                        if (Application.OpenForms["SalesRegister"] != null)
                        {
                            SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                            mkc1.AddItemgrid = ButtonTag;
                        }
                    }

                    if (Application.OpenForms["SalesRegister"] != null)
                    {
                        SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                        invoiceNO = mkc1.InvoceNo;
                        mkc1.DraftInvoiceExt = ".";
                    }

                    //if (Application.OpenForms["AppointmentS1"] != null)
                    //{
                    //    AppointmentS1 mkc1 = (AppointmentS1)Application.OpenForms["AppointmentS1"];
                    //    mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                    //    mkc1.BringToFront();
                    //    mkc1.WindowState = FormWindowState.Maximized;
                    //}

                    return invoiceNO;
                }
            }
            return invoiceNO;
        }

        public string getAppointmentCustomer()
        {
            string Customer = "Gest";
            string sql = " select * from Appointment where TenentID = " + Tenent.TenentID + " and ID = '" + lblApoint.Text + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                string ID = dt.Rows[0]["C_ID"].ToString();
                string sqlCmd = "Select ID,Name,NameArabic,EmailAddress,Phone,Address,City,PeopleType,Facebook,Twitter from  tbl_customer where TenentID=" + Tenent.TenentID + " and ID = " + ID + " ";
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                if (dt1.Rows.Count > 0)
                {
                    Customer = dt1.Rows[0]["Name"] + " - " + dt1.Rows[0]["Phone"] + " - " + dt1.Rows[0]["EmailAddress"];
                }
            }

            return Customer;
        }

        private void chkShowall_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowall.Checked == true)
            {
                chkComplated.Checked = false;
                chkPending.Checked = false;
            }
            Last30daysJobReport();
        }

        private void chkComplated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkComplated.Checked == true)
            {
                chkShowall.Checked = false;
                chkPending.Checked = false;
            }
            Last30daysJobReport();
        }

        private void chkPending_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPending.Checked == true)
            {
                chkShowall.Checked = false;
                chkComplated.Checked = false;
            }
            Last30daysJobReport();
        }

        private void btnJobRefrash_Click(object sender, EventArgs e)
        {
            bool ISrun = backSyncro.isRun;
            if (ISrun != true)
            {
                Last30daysReport(dtStartDate.Text, dtEndDate.Text);
                Last30daysJobReport();
            }
        }

    }
}
