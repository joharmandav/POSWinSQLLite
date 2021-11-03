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
    public partial class AppointmentS : Form
    {
        public AppointmentS()
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

        private void AppointmentS_Load(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;

            dtStartDate.Text = StartDate.ToString("yyyy-MM-dd");
            dtEndDate.Text = EndDate.ToString("yyyy-MM-dd");

            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }

        public void Last30daysReport(string startDate, string EndDate)
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
                try
                {
                    string sql = " select  Appointment.ID as 'Appointment No' , (tbl_customer.Name ||' - '|| tbl_customer.NameArabic) as 'Customer' ,Title , strftime('%Y-%m-%d  %H:%M',ExpStartDate) as 'Start Date and Time',Color " +
                                 " from Appointment  left JOIN tbl_customer on Appointment.customer = tbl_customer.Name  " +
                                 " where Appointment.TenentID=" + Tenent.TenentID + " and Deleted = 1 and JobDone = 0  and Appointment.ExpStartDate >=  '" + startDate + "'  and Appointment.ExpStartDate <= '" + EndDate + "' " +
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
                    if (Application.OpenForms["AppointmentS1"] != null)
                    {
                        AppointmentS1 go = new AppointmentS1();
                        go.AppointID = id;
                        go.Show();
                    }
                    else
                    {
                        AppointmentS1 go = new AppointmentS1();
                        go.AppointID = id;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ISrun = backSyncro.isRun;
            if (ISrun != true)
            {
                Last30daysReport(dtStartDate.Text, dtEndDate.Text);
            }
        }

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
        
    }
}
