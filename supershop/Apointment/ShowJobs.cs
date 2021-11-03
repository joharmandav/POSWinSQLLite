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
    public partial class ShowJobs : Form
    {
        public ShowJobs()
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


        }

        public string Appintment_id
        {
            set
            {
                lblApoint.Text = value;
            }
            get
            {
                return lblApoint.Text;
            }
        }

        private void ShowJobs_Load(object sender, EventArgs e)
        {
            Bind_Appoinment();
            SelectAppoin();
            Last30daysReport();
            lblAppointmentNO.Text = ".";
        }

        public void SelectAppoin()
        {
            if (lblApoint.Text != "-")
            {
                string sqlCust = "select * from Appointment where tenentid=" + Tenent.TenentID + "  and ID =" + lblApoint.Text + "  and Deleted = 1 ";
                DataTable dtCust = DataAccess.GetDataTable(sqlCust);
                if (dtCust != null)
                {
                    if (dtCust.Rows.Count > 0)
                    {
                        comboAppoinment.Text = dtCust.Rows[0]["ID"] + " - " + dtCust.Rows[0]["customer"] + " - " + dtCust.Rows[0]["Title"]; ;

                    }
                }
            }
            else
            {
                lblApoint.Text = comboAppoinment.Text.ToString().Split('-')[0].Trim();
            }
        }

        public void Bind_Appoinment()
        {
            comboAppoinment.Items.Clear();

            //Appoinment Databind 
            string sqlCust = "select * from Appointment where tenentid=" + Tenent.TenentID + " and Deleted = 1 ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            string First = "";
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    string Combi = dtCust.Rows[i]["ID"] + " - " + dtCust.Rows[i]["customer"] + " - " + dtCust.Rows[i]["Title"];
                    if (First == "")
                    {
                        First = Combi;
                    }
                    comboAppoinment.Items.Add(Combi);
                }
            }
            comboAppoinment.Text = First;

            //comboAppoinment.DataSource = dtCust;
            //comboAppoinment.DisplayMember = "Name";
            //comboAppoinment.ValueMember = "id";

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AppointmentS"] != null)
            {
                Application.OpenForms["AppointmentS"].BringToFront();
                this.Close();
            }
            else
            {
                AppointmentS go = new AppointmentS();
                go.MdiParent = this;
                go.Show();
                this.Close();
            }
        }

        public void Last30daysReport()
        {
            try
            {
                string sql = "";
                if (UserInfo.usertype != "1")
                {
                    sql = " select CMA.MasterCode as 'Job ID',AP.Customer,CMA.ACTIVITYE as 'Job Title',CMA.UseReciepeName as 'Use Service Template',CMA.Remarks,CMA.USERNAME as 'Employee',  strftime('%Y-%m-%d  %H:%M',CA.InitialDate) as 'Start Date',strftime('%Y-%m-%d  %H:%M',CA.DeadLineDate) as 'End Date',CMA.MyStatus as 'InvoiceNO' " +
                          " from CRMMainActivities CMA " +
                          " inner join CRMActivities CA on CA.TenentID = CMA.TenentID and CA.MasterCode = CMA.MasterCode " +
                          " inner join Appointment AP on AP.ID = CMA.MyID " +
                          " where CMA.TenentID = " + Tenent.TenentID + " and CMA.MyID = '" + lblApoint.Text + "' and CMA.JobDone = 0 and CMA.USERNAME = '" + UserInfo.UserName + "' ";
                }
                else
                {
                    sql = " select CMA.MasterCode as 'Job ID',AP.Customer,CMA.ACTIVITYE as 'Job Title',CMA.UseReciepeName as 'Use Service Template',CMA.Remarks,CMA.USERNAME as 'Employee',  strftime('%Y-%m-%d  %H:%M',CA.InitialDate) as 'Start Date',strftime('%Y-%m-%d  %H:%M',CA.DeadLineDate) as 'End Date',CMA.MyStatus as 'InvoiceNO' " +
                          " from CRMMainActivities CMA " +
                          " inner join CRMActivities CA on CA.TenentID = CMA.TenentID and CA.MasterCode = CMA.MasterCode " +
                          " inner join Appointment AP on AP.ID = CMA.MyID " +
                          " where CMA.TenentID = " + Tenent.TenentID + " and CMA.MyID = '" + lblApoint.Text + "' and CMA.JobDone = 0 ";
                }

                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagrdReportDetails.DataSource = dt1;
                datagrdReportDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns["Action"].DisplayIndex = 9;
                datagrdReportDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }

        }


        private void btnCashierRefresh_Click(object sender, EventArgs e)
        {
            Last30daysReport();
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
                    int CursorX = cal - 350;
                    int CursorY = Cursor.Position.Y;
                    if (e.RowIndex >= 6)
                    {
                        CursorY = 476;
                    }

                    DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];

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

        private void AddJob_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ISrun = backSyncro.isRun;
            if (ISrun != true)
            {
                Last30daysReport();
            }
        }

        private void comboAppoinment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblAppointmentNO.Text != "-")
            {
                if (comboAppoinment.Text != "" && comboAppoinment.Text != "System.Data.DataRowView")
                {
                    lblApoint.Text = comboAppoinment.Text.Split('-')[0].Trim();
                    Last30daysReport();
                }
            }
        }


    }
}
