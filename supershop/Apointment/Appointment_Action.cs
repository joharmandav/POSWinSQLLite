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
    public partial class Appointment_Action : Form
    {
        private int desiredStartLocationX;
        private int desiredStartLocationY;

        public Appointment_Action(int x, int y)
        {
            InitializeComponent();

            this.desiredStartLocationX = x;
            this.desiredStartLocationY = y;

            Load += new EventHandler(Appointment_Action_Load);

        }

        private void Appointment_Action_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(desiredStartLocationX, desiredStartLocationY);

            int AppointMentID = Convert.ToInt32(lblAppointmentNO.Text);

            if (UserInfo.usertype == "1")
            {
                btnDeleteAppoint.Visible = true;
            }
            else
            {
                btnDeleteAppoint.Visible = false;
            }

            bool Falg = CheckAppointmentJobStart(AppointMentID);
            if (Falg == true)
            {
                btnEdit.Enabled = false; btnEdit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCalcel.Enabled = false; btnCalcel.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnEmployeeAssign.Enabled = false; btnEmployeeAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDeleteAppoint.Enabled = false; btnDeleteAppoint.BackColor = Color.FromKnownColor(KnownColor.Control);
            }

            if (UserInfo.usertype != "1")
            {
                btnEdit.Enabled = false; btnEdit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCalcel.Enabled = false; btnCalcel.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnEmployeeAssign.Enabled = false; btnEmployeeAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
            }

        }

        public bool CheckAppointmentJobStart(int AppointMentID)
        {
            string sql = " select  CA.MasterCode from CRMActivities CA inner Join CRMMainActivities CMA On CMA.MasterCode = CA.MasterCode and CMA.TenentID = CA.TenentID " +
                         " where CA.TenentID = " + Tenent.TenentID + " and CMA.MyID = '" + AppointMentID + "' and CA.InitialDate is not null ";
            DataTable Dt = DataAccess.GetDataTable(sql);
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string Appintment_id
        {
            set
            {
                lblAppointmentNO.Text = value;
            }
            get
            {
                return lblAppointmentNO.Text;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = lblAppointmentNO.Text;

            if (Application.OpenForms["Add_Appointment"] != null)
            {
                Application.OpenForms["Add_Appointment"].Close();
                Add_Appointment go = new Add_Appointment(DateTime.Now);
                go.Appointment_ID = id;
                go.Show();
            }
            else
            {
                Add_Appointment go = new Add_Appointment(DateTime.Now);
                go.Appointment_ID = id;
                go.Show();
            }
            this.Close();
        }

        private void btnEmployeeAssign_Click(object sender, EventArgs e)
        {
            int CursorY = Cursor.Position.Y;
            string AppointmentNO = lblAppointmentNO.Text;
            ShowDriverAssign(AppointmentNO, CursorY);
            this.Close();
        }

        public void ShowDriverAssign(string AppointmentNO, int CursorY)
        {
            string sql3 = "select * from Appointment where TenentID=" + Tenent.TenentID + " and LocationID=1 and ID = '" + AppointmentNO + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            int cal = Cursor.Position.X;
            int CursorX = cal - 350;

            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["Employee"] == null)
                {
                    if (Application.OpenForms["EmployeeAssign"] != null)
                    {
                        Application.OpenForms["EmployeeAssign"].Close();
                    }

                    EmployeeAssign mkc1 = new EmployeeAssign(CursorX, CursorY);
                    mkc1.Appintment_id = AppointmentNO;
                    mkc1.Show();
                }
                else
                {
                    string EmployeeName = dt1.Rows[0]["Employee"].ToString().Trim();
                    if (EmployeeName == "" || EmployeeName == "0")
                    {
                        if (Application.OpenForms["EmployeeAssign"] != null)
                        {
                            Application.OpenForms["EmployeeAssign"].Close();
                        }

                        EmployeeAssign mkc1 = new EmployeeAssign(CursorX, CursorY);
                        mkc1.Appintment_id = AppointmentNO;
                        mkc1.Show();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Employee Already assigned You Want to Reassign?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (Application.OpenForms["EmployeeAssign"] != null)
                            {
                                Application.OpenForms["EmployeeAssign"].Close();
                            }

                            EmployeeAssign mkc1 = new EmployeeAssign(CursorX, CursorY);
                            mkc1.Appintment_id = AppointmentNO;
                            mkc1.Show();
                        }
                    }
                }
            }
        }

        private void btnjobDone_Click(object sender, EventArgs e)
        {
            string sql = "select * from Appointment where TenentID=" + Tenent.TenentID + "  and LocationID=1 and ID = '" + lblAppointmentNO.Text + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql1 = " update Appointment set JobDone='1' , " +
                              " Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2 " +
                              " where TenentID = " + Tenent.TenentID + "  and LocationID=1 and ID = '" + lblAppointmentNO.Text + "'  ";
                DataAccess.ExecuteSQL(sql1);

                Datasyncpso.insert_Live_sync(sql1, "Appointment", "UPDATE");

                string ActivityName = "Employee Assign";
                string LogData = "Employee Assign with Appointment no = " + lblAppointmentNO.Text + " ";
                Login.InsertUserLog(ActivityName, LogData);
            }

            this.Close();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Calcel This Appointment ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                string sql = "select * from Appointment where TenentID=" + Tenent.TenentID + "  and LocationID=1 and ID = '" + lblAppointmentNO.Text + "' ";
                DataTable dt = DataAccess.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql1 = " update Appointment set Deleted='0' , " +
                                  " Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2 " +
                                  " where TenentID = " + Tenent.TenentID + "  and LocationID=1 and ID = '" + lblAppointmentNO.Text + "'  ";
                    DataAccess.ExecuteSQL(sql1);
                    Datasyncpso.insert_Live_sync(sql1, "Appointment", "UPDATE");

                }
            }
            this.Close();
        }

        private void btnAddjob_Click(object sender, EventArgs e)
        {
            string id = lblAppointmentNO.Text;
            if (Application.OpenForms["ShowJobs"] != null)
            {
                Application.OpenForms["ShowJobs"].Close();
                ShowJobs go = new ShowJobs();
                go.Appintment_id = id;
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }
            else
            {
                ShowJobs go = new ShowJobs();
                go.Appintment_id = id;
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }
            this.Close();
        }

        private void btnDeleteAppoint_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete This Appointment ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                string Appointmentid = lblAppointmentNO.Text;
                string sql2 = "select * from Appointment where TenentID=" + Tenent.TenentID + "  and LocationID=1 and ID = '" + Appointmentid + "' ";
                DataTable dt2 = DataAccess.GetDataTable(sql2);

                if (dt2.Rows.Count > 0)
                {
                    string sql = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + " and MyID = '" + Appointmentid + "' ";
                    DataTable dt = DataAccess.GetDataTable(sql);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string MasterCODE = dt.Rows[i]["MasterCODE"].ToString();

                            string sql3 = "Delete from CRMActivities where MasterCODE  = '" + MasterCODE + "' and TenentID= " + Tenent.TenentID + " ";
                            DataAccess.ExecuteSQL(sql3);
                            Datasyncpso.insert_Live_sync(sql3, "CRMActivities", "DELETE");

                            string sql4 = "Delete from CRMMainActivities where MasterCODE  = '" + MasterCODE + "' and TenentID= " + Tenent.TenentID + " ";
                            DataAccess.ExecuteSQL(sql4);
                            Datasyncpso.insert_Live_sync(sql4, "CRMMainActivities", "DELETE");

                            string sql5 = "Delete from AppointmentReceipe where JobID  = '" + MasterCODE + "' and TenentID= " + Tenent.TenentID + " ";
                            DataAccess.ExecuteSQL(sql5);
                            Datasyncpso.insert_Live_sync(sql5, "AppointmentReceipe", "DELETE");

                            string ActivityName1 = "Delete Job";
                            string LogData1 = "Delete Job with Appointment no = " + Appointmentid + "and JobID:" + MasterCODE + " with CRMActivities and CRMMainActivities  ";
                            Login.InsertUserLog(ActivityName1, LogData1);
                        }
                    }

                    string sqlDelete = "Delete from Appointment where TenentID=" + Tenent.TenentID + "  and LocationID=1 and ID = '" + Appointmentid + "' ";
                    DataAccess.ExecuteSQL(sqlDelete);
                    Datasyncpso.insert_Live_sync(sqlDelete, "Appointment", "DELETE");

                    string ActivityName = "Delete Appointment";
                    string LogData = "Delete Appointment with Appointment no = " + Appointmentid + " ";
                    Login.InsertUserLog(ActivityName, LogData);
                }
            }

            this.Close();
        }

    }
}
