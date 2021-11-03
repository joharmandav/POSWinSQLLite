using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syd.ScheduleControls.Data;
using Syd.ScheduleControls.Test.Dialog;
using Syd.ScheduleControls.Region;
using Syd.ScheduleControls.Events;
using Syd.ScheduleControls.Test;

namespace supershop
{
    public partial class Calander : Form
    {
        public Calander()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
            BindEmploayee();
        }



        private void Calander_Load(object sender, EventArgs e)
        {

        }
        private void comboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            //have to tell the controls to refresh appointment display
            weekView1.RefreshAppointments();
            monthView1.RefreshAppointments();
            dayView1.RefreshAppointments();
            dayView2.RefreshAppointments();
            AppointmentList appts = null;
            DateTime weekstart = DateTime.Now;
            if (comboEmployee.Text == "-- All Employee --")
            {
                appts = CreateRandomAppointments(weekstart, "all");
            }
            else if (comboEmployee.Text == "" || comboEmployee.Text == "System.Data.DataRowView")
            {
                return;
            }
            else
            {
                string Employee = comboEmployee.Text.Trim();
                appts = CreateRandomAppointments(weekstart, Employee);
            }

            weekView1.Date = weekstart;
            weekView1.Appointments = appts;
            monthView1.Date = weekstart;
            monthView1.Appointments = appts;
            dayView1.Date = weekstart;
            dayView1.Appointments = appts;
            dayView2.Date = weekstart;
            dayView2.Appointments = appts;
           
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

        private static AppointmentList CreateRandomAppointments(DateTime date, string Emp)
        {



            List<Brush> brushes = new List<Brush>();
            brushes.Add(Brushes.LimeGreen);
            brushes.Add(Brushes.PowderBlue);
            brushes.Add(Brushes.DarkGreen);
            brushes.Add(Brushes.Green);
            brushes.Add(Brushes.DimGray);
            brushes.Add(Brushes.Red);
            brushes.Add(Brushes.Yellow);
            brushes.Add(Brushes.Aquamarine);
            brushes.Add(Brushes.Plum);
            brushes.Add(Brushes.Orange);
            brushes.Add(Brushes.Pink);


            //create 7am of last monday
            DateTime timeStart = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
            DateTime timeEnd = timeStart.AddDays(31);

            var appts = new AppointmentList();
            //var rand = new Random();

            appts.Clear();

            string EmpFilter = Emp == "all" ? "" : "Employee='" + Emp + "' and";
            string sql = " select  Appointment.ID as 'Appointment No' , (tbl_customer.Name ||' - '|| tbl_customer.NameArabic) as 'Customer' ,Title , strftime('%Y-%m-%d  %H:%M',ExpStartDate) as 'Start Date and Time', strftime('%Y-%m-%d  %H:%M',ExpEndDate) as 'End Date and Time',Color,Employee " +
                            " from Appointment  left JOIN tbl_customer on Appointment.C_ID = tbl_customer.ID and Appointment.TenentID = tbl_customer.TenentID  " +
                            " where " + EmpFilter + " Appointment.TenentID=" + Tenent.TenentID + " and Deleted = 1 and  Appointment.ExpStartDate >=  '" + timeStart.ToString("yyyy-MM-dd") + "'  and Appointment.ExpStartDate <= '" + timeEnd.ToString("yyyy-MM-dd") + "' " +
                            " order by Appointment.ExpStartDate, Appointment.ID ";

            DataTable dt1 = DataAccess.GetDataTable(sql);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    DataRow dataReader = dt1.Rows[i];
                    string StartDate1 = dataReader["Start Date and Time"].ToString();
                    string EndDate1 = dataReader["End Date and Time"].ToString();
                    Brush brush = brushes[0];
                    ExtendedAppointment app = new ExtendedAppointment();
                    app.AppointNo = dataReader["Appointment No"].ToString();
                    app.ColorBlockBrush = brush;
                    app.Subject = dataReader["Employee"].ToString() + " ~ ANo." + app.AppointNo; //+ " ~ " + dataReader["Title"].ToString() + " For Customer:" + dataReader["Customer"].ToString();
                    app.DateStart = Convert.ToDateTime(StartDate1);
                    app.DateEnd = Convert.ToDateTime(EndDate1);

                    appts.Add(app);
                }

                appts.SortAppointments();
                return appts;
            }
            else
            {
                MessageBox.Show("No One Appointment for " + Emp);
                return appts;
            }
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DoubleBuffered = true;

            DateTime weekstart = DateTime.Now;
            AppointmentList appts = CreateRandomAppointments(weekstart, "all");

            weekView1.Date = weekstart;
            weekView1.Appointments = appts;
            monthView1.Date = weekstart;
            monthView1.Appointments = appts;
            dayView1.Date = weekstart;
            dayView1.Appointments = appts;
            dayView2.Date = weekstart;
            dayView2.Appointments = appts;
            

            lblApptCount.Text = "" + dayView1.Appointments.Count;
            lblCurrentDate.Text = weekstart.ToLongDateString();


            weekView1.AppointmentCreate += calendar_AppointmentAdd;
            monthView1.AppointmentCreate += calendar_AppointmentAdd;
            dayView1.AppointmentCreate += calendar_AppointmentAdd;
            dayView2.AppointmentCreate += calendar_AppointmentAdd;
           

            weekView1.AppointmentMove += calendar_AppointmentMove;
            monthView1.AppointmentMove += calendar_AppointmentMove;
            dayView1.AppointmentMove += calendar_AppointmentMove;
            dayView2.AppointmentMove += calendar_AppointmentMove;

            weekView1.AppointmentEdit += calendar_AppointmentEdit;
            monthView1.AppointmentEdit += calendar_AppointmentEdit;
            dayView1.AppointmentEdit += calendar_AppointmentEdit;
            dayView2.AppointmentEdit += calendar_AppointmentEdit;
           

        }

        /// <summary>
        /// Handles the AppointmentEdit event of the calendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syd.ScheduleControls.Events.AppointmentEditEventArgs"/> instance containing the event data.</param>
        private void calendar_AppointmentEdit(object sender, AppointmentEditEventArgs e)
        {
            try
            {


                string id = e.Appointment.AppointNo.ToString();
                if (Application.OpenForms["AppointmentS1"] != null)
                {
                    AppointmentS1 mkc1 = (AppointmentS1)Application.OpenForms["AppointmentS1"];
                    mkc1.AppointStartDate = e.Appointment.DateStart.ToString("yyyy-MM-dd");
                    mkc1.AppointID = id;
                    mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                    mkc1.BringToFront();
                    mkc1.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    AppointmentS1 go = new AppointmentS1();
                    go.AppointID = id;
                    go.AppointStartDate = e.Appointment.DateStart.ToString("yyyy-MM-dd");
                    go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                    go.WindowState = FormWindowState.Maximized;
                    go.Show();
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
            //show a dialog to edit the appointment
            //using (EditAppointment dialog = new EditAppointment())
            //{
            //    dialog.AppointmentDateStart = e.Appointment.DateStart;
            //    dialog.AppointmentDateEnd = e.Appointment.DateEnd;
            //    dialog.AppointmentTitle = e.Appointment.Subject;
            //    DialogResult result = dialog.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        //if the user clicked 'save', update the appointment dates and title
            //        e.Appointment.DateStart = dialog.AppointmentDateStart;
            //        e.Appointment.DateEnd = dialog.AppointmentDateEnd;
            //        e.Appointment.Subject = dialog.AppointmentTitle;

            //        //have to tell the controls to refresh appointment display
            //        weekView1.RefreshAppointments();
            //        monthView1.RefreshAppointments();
            //        dayView1.RefreshAppointments();
            //        dayView2.RefreshAppointments();

            //        //get the controls to repaint 
            //        weekView1.Invalidate();
            //        monthView1.Invalidate();
            //        dayView1.Invalidate();
            //        dayView2.Invalidate();
            //    }
            //}
        }


        /// <summary>
        /// Handles the AppointmentMove event of the calendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syd.ScheduleControls.Events.AppointmentMoveEventArgs"/> instance containing the event data.</param>
        private void calendar_AppointmentMove(object sender, AppointmentMoveEventArgs e)
        {
            //show a dialog to move the appointment date
            using (MoveAppointment dialog = new MoveAppointment())
            {
                dialog.AppointmentOldDateStart = e.Appointment.DateStart;
                dialog.AppointmentOldDateEnd = e.Appointment.DateEnd;
                dialog.AppointmentTitle = e.Appointment.Subject;
                if (e.NewDate != null)
                {
                    dialog.AppointmentDateStart = e.NewDate;
                    dialog.AppointmentDateEnd = new DateTime(e.NewDate.Ticks + (dialog.AppointmentOldDateEnd.Ticks - dialog.AppointmentOldDateStart.Ticks));
                }
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //if the user clicked 'save', update the appointment dates
                    e.Appointment.DateStart = dialog.AppointmentDateStart;
                    e.Appointment.DateEnd = dialog.AppointmentDateEnd;

                    //have to tell the controls to refresh appointment display
                    weekView1.RefreshAppointments();
                    monthView1.RefreshAppointments();
                    dayView1.RefreshAppointments();
                    dayView2.RefreshAppointments();

                    //get the controls to repaint 
                    weekView1.Invalidate();
                    monthView1.Invalidate();
                    dayView1.Invalidate();
                    dayView2.Invalidate();
                }
            }
        }

        /// <summary>
        /// Handles the AppointmentAdd event of the calendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syd.ScheduleControls.Events.AppointmentCreateEventArgs"/> instance containing the event data.</param>
        private void calendar_AppointmentAdd(object sender, AppointmentCreateEventArgs e)
        {
            if (e.Date.Value.Date >= DateTime.Now.Date)
            {
                if (Application.OpenForms["Add_Appointment"] != null)
                {
                    Application.OpenForms["Add_Appointment"].BringToFront();
                }
                else
                {
                    Add_Appointment go = new Add_Appointment(e.Date.Value);
                    go.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid Appointment Date. ");
                return;
            }
            ////show a dialog to add an appointment
            //using (NewAppointment dialog = new NewAppointment())
            //{
            //    if (e.Date != null)
            //    {
            //        dialog.AppointmentDateStart = e.Date.Value;
            //        dialog.AppointmentDateEnd = e.Date.Value.AddMinutes(15);
            //    }
            //    DialogResult result = dialog.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        //if the user clicked 'save', save the new appointment 
            //        string title = dialog.AppointmentTitle;
            //        DateTime dateStart = dialog.AppointmentDateStart;
            //        DateTime dateEnd = dialog.AppointmentDateEnd;
            //        e.Control.Appointments.Add(new ExtendedAppointment() { Subject = title, DateStart = dateStart, DateEnd = dateEnd });

            //        //have to tell the controls to refresh appointment display
            //        weekView1.RefreshAppointments();
            //        monthView1.RefreshAppointments();
            //        dayView1.RefreshAppointments();
            //        dayView2.RefreshAppointments();

            //        //get the controls to repaint 
            //        weekView1.Invalidate();
            //        monthView1.Invalidate();
            //        dayView1.Invalidate();
            //        dayView2.Invalidate();
            //    }
            //}
        }

        /// <summary>
        /// Handles the DateSelected event of the MonthCalendar1 control.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DateRangeEventArgs"/> instance containing the event data.</param>
        void MonthCalendar1DateSelected(object sender, DateRangeEventArgs e)
        {


            weekView1.Date = e.Start;
            monthView1.Date = e.Start;
            dayView1.Date = e.Start;
            dayView2.Date = e.Start;
           

            if (dayView1.Appointments != null)
            {
                lblApptCount.Text = "" + dayView1.Appointments.Count;
            }
            lblCurrentDate.Text = e.Start.ToLongDateString();

            weekView1.Invalidate();
            monthView1.Invalidate();
            dayView1.Invalidate();
            dayView2.Invalidate();
           
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

        private void btnWorkingHr_Click(object sender, EventArgs e)
        {
            if (txtWorkingStart.Text != "" && txtWorkingEnd.Text != "")
            {
                dayView1.WorkStartHour = Convert.ToInt32(txtWorkingStart.Text) + 1;
                dayView1.WorkEndHour = Convert.ToInt32(txtWorkingEnd.Text);
                dayView2.WorkStartHour = Convert.ToInt32(txtWorkingStart.Text) + 1;
                dayView2.WorkEndHour = Convert.ToInt32(txtWorkingEnd.Text);
               
                if (dayView1.WorkEndHour > 23)
                {
                    MessageBox.Show("Working hours must be between 1 and 23. ");
                    return;
                }
                DateTime weekstart = DateTime.Now;
                AppointmentList appts = CreateRandomAppointments(weekstart, "all");
                weekView1.Date = weekstart;
                weekView1.Appointments = appts;
                monthView1.Date = weekstart;
                monthView1.Appointments = appts;
                dayView1.Date = weekstart;
                dayView1.Appointments = appts;
                dayView2.Date = weekstart;
                dayView2.Appointments = appts;
               
            }
            else
            {
                MessageBox.Show("Working hours must be between 1 and 23. ");
                return;
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindEmploayee();
            DateTime weekstart = DateTime.Now;
            AppointmentList appts = CreateRandomAppointments(weekstart, "all");
            weekView1.Date = weekstart;
            weekView1.Appointments = appts;
            monthView1.Date = weekstart;
            monthView1.Appointments = appts;
            dayView1.Date = weekstart;
            dayView1.Appointments = appts;
            dayView2.Date = weekstart;
            dayView2.Appointments = appts;
           

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl1.TabPages[e.Index];

            if (e.Index == 0)
            {
                Color col = Color.Tomato; e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);
            }
            else if (e.Index == 1) { Color col = Color.LimeGreen; e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds); }
            else if (e.Index == 2) { Color col = Color.Orange; e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds); }
            else if (e.Index == 3) { Color col = Color.Yellow; e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds); }

            Font f;
            f = new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
            f = new Font(e.Font, FontStyle.Bold);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, f, paddedBounds, page.ForeColor);


          
        }








    }
}
