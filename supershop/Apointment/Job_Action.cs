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
    public partial class Job_Action : Form
    {
        private int desiredStartLocationX;
        private int desiredStartLocationY;

        public Job_Action(int x, int y)
        {
            InitializeComponent();

            this.desiredStartLocationX = x;
            this.desiredStartLocationY = y;

            Load += new EventHandler(Job_Action_Load);

        }

        private void Job_Action_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(desiredStartLocationX, desiredStartLocationY);

            SelectAppoin();

            bool flagEmployee = CheckassignEmp();
            if (flagEmployee == true)
            {
                bool flagjobstart = Checkjobstart();
                if (flagjobstart == true)
                {
                    //bool flagcheckinvo = CheckinvoiceAssing();
                    //if (flagcheckinvo == true)
                    //{
                    Checkjobdone();
                    //}
                }
            }

            if (UserInfo.usertype != "1")
            {
                btnEdit.Enabled = false;
                btnEdit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCalcel.Enabled = false;
                btnCalcel.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnEmployeeAssign.Enabled = false;
                btnEmployeeAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        public bool CheckassignEmp()
        {
            string sql = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + "  and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "' and (username is null or username ='')  ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                btnEdit.Enabled = true; btnEdit.BackColor = Color.FromKnownColor(KnownColor.LimeGreen);
                btnCalcel.Enabled = true; btnCalcel.BackColor = Color.FromKnownColor(KnownColor.Red);
                btnEmployeeAssign.Enabled = true; btnEmployeeAssign.BackColor = Color.FromKnownColor(KnownColor.LightSalmon);

                btnstart.Enabled = false;btnstart.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnInvoiceAssing.Enabled = false; btnInvoiceAssing.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnAddInputitem.Enabled = false; btnAddInputitem.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnJobDone.Enabled = false; btnJobDone.BackColor = Color.FromKnownColor(KnownColor.Control);
                return false;
            }
            else
            {
                btnstart.Enabled = false; btnstart.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnInvoiceAssing.Enabled = false; btnInvoiceAssing.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnAddInputitem.Enabled = false; btnAddInputitem.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnJobDone.Enabled = false; btnJobDone.BackColor = Color.FromKnownColor(KnownColor.Control);
                return true;
            }
        }

        public bool Checkjobstart()
        {
            string sql = "select * from CRMActivities where TenentID=" + Tenent.TenentID + "  and MasterCODE = " + MasterCODE.Text + " and  ( InitialDate =='' or InitialDate is null ) ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                btnEdit.Enabled = true; btnEdit.BackColor = Color.FromKnownColor(KnownColor.LimeGreen);
                btnCalcel.Enabled = true; btnCalcel.BackColor = Color.FromKnownColor(KnownColor.Red);
                btnEmployeeAssign.Enabled = true; btnEmployeeAssign.BackColor = Color.FromKnownColor(KnownColor.LightSalmon); 
                btnstart.Enabled = true; btnstart.BackColor = Color.FromKnownColor(KnownColor.DarkOrange);

                btnInvoiceAssing.Enabled = false; btnInvoiceAssing.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnAddInputitem.Enabled = false; btnAddInputitem.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnJobDone.Enabled = false; btnJobDone.BackColor = Color.FromKnownColor(KnownColor.Control);
                return false;
            }
            else
            {
                btnEdit.Enabled = false; btnEdit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCalcel.Enabled = false; btnCalcel.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnEmployeeAssign.Enabled = false; btnEmployeeAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnInvoiceAssing.Enabled = false; btnInvoiceAssing.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnAddInputitem.Enabled = false; btnAddInputitem.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnJobDone.Enabled = false; btnJobDone.BackColor = Color.FromKnownColor(KnownColor.Control);
                return true;
            }
        }

        public bool Checkjobdone()
        {
            string sql = "select * from CRMActivities where TenentID=" + Tenent.TenentID + "  and MasterCODE = " + MasterCODE.Text + " and  (DeadLineDate =='' or DeadLineDate is null ) ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                btnEdit.Enabled = false; btnEdit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCalcel.Enabled = false; btnCalcel.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnEmployeeAssign.Enabled = false; btnEmployeeAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnstart.Enabled = false; btnstart.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnInvoiceAssing.Enabled = false; btnInvoiceAssing.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnAddInputitem.Enabled = true; btnAddInputitem.BackColor = Color.FromKnownColor(KnownColor.Yellow);
                btnJobDone.Enabled = true; btnJobDone.BackColor = Color.FromKnownColor(KnownColor.Green);
                return false;
            }
            else
            {
                btnEdit.Enabled = false; btnEdit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCalcel.Enabled = false; btnCalcel.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnEmployeeAssign.Enabled = false; btnEmployeeAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnstart.Enabled = false; btnstart.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnInvoiceAssing.Enabled = false; btnInvoiceAssing.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnAddInputitem.Enabled = false; btnAddInputitem.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnJobDone.Enabled = false; btnJobDone.BackColor = Color.FromKnownColor(KnownColor.Control);
                return true;
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

        public string JobID
        {
            set
            {
                MasterCODE.Text = value;
            }
            get
            {
                return MasterCODE.Text;
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
        private void panel1_MouseDown(object sender, MouseEventArgs e)
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

            if (Application.OpenForms["Add_Job"] != null)
            {
                Application.OpenForms["Add_Job"].Close();
                Add_Job go = new Add_Job();
                go.Appintment_id = id;
                go.JobID = MasterCODE.Text;
                go.Show();
            }
            else
            {
                Add_Job go = new Add_Job();
                go.Appintment_id = id;
                go.JobID = MasterCODE.Text;
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
            string sql3 = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + " and LocationID=1 and MasterCODE = " + MasterCODE.Text + " and MyID = '" + AppointmentNO + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            int cal = Cursor.Position.X;
            int CursorX = cal - 350;

            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["USERNAME"] == null)
                {
                    if (Application.OpenForms["JobEmployeeAssign"] != null)
                    {
                        Application.OpenForms["JobEmployeeAssign"].Close();
                    }

                    JobEmployeeAssign mkc1 = new JobEmployeeAssign(CursorX, CursorY);
                    mkc1.Appintment_id = AppointmentNO;
                    mkc1.JobID = MasterCODE.Text;
                    mkc1.Show();
                }
                else
                {
                    string EmployeeName = dt1.Rows[0]["USERNAME"].ToString().Trim();
                    if (EmployeeName == "" || EmployeeName == "0")
                    {
                        if (Application.OpenForms["JobEmployeeAssign"] != null)
                        {
                            Application.OpenForms["JobEmployeeAssign"].Close();
                        }

                        JobEmployeeAssign mkc1 = new JobEmployeeAssign(CursorX, CursorY);
                        mkc1.Appintment_id = AppointmentNO;
                        mkc1.JobID = MasterCODE.Text;
                        mkc1.Show();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Employee Already assigned You Want to Reassign?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (Application.OpenForms["JobEmployeeAssign"] != null)
                            {
                                Application.OpenForms["JobEmployeeAssign"].Close();
                            }

                            JobEmployeeAssign mkc1 = new JobEmployeeAssign(CursorX, CursorY);
                            mkc1.Appintment_id = AppointmentNO;
                            mkc1.JobID = MasterCODE.Text;
                            mkc1.Show();
                        }
                    }
                }
            }
        }

        private void btnJobDone_Click(object sender, EventArgs e)
        {
            string sql3 = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            if (dt1.Rows.Count > 0)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql1 = " update CRMMainActivities set JobDone='1',  " +
                              " UploadDate = '" + UploadDate + "', Uploadby = '" + UserInfo.UserName + "', SynID = 2 " +
                              " where TenentID=" + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "'   ";
                DataAccess.ExecuteSQL(sql1);
                Datasyncpso.insert_Live_sync(sql1, "CRMMainActivities", "UPDATE");

                string DeadLineDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = " update CRMActivities set DeadLineDate= '" + DeadLineDate + "',  " +
                             " UploadDate = '" + UploadDate + "', Uploadby = '" + UserInfo.UserName + "', SynID = 2 " +
                             " where TenentID=" + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + " ";
                DataAccess.ExecuteSQL(sql);
                Datasyncpso.insert_Live_sync(sql, "CRMActivities", "UPDATE");

                string ActivityName = "Job Done";
                string LogData = "Job Done with Job no = " + MasterCODE.Text + " ";
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
            string sql = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + "  and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                string sql1 = " Delete from CRMMainActivities where TenentID = " + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "'  ";
                DataAccess.ExecuteSQL(sql1);
                Datasyncpso.insert_Live_sync(sql1, "CRMMainActivities", "DELETE");

                string sql12 = " Delete from CRMActivities where TenentID = " + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + " ";
                DataAccess.ExecuteSQL(sql12);
                Datasyncpso.insert_Live_sync(sql12, "CRMActivities", "DELETE");

                string ActivityName = "Delete JOB";
                string LogData = "Delete JOB with Appointment no = " + MasterCODE.Text + " ";
                Login.InsertUserLog(ActivityName, LogData);

            }
            this.Close();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            string sql3 = "select * from CRMActivities where TenentID=" + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            if (dt1.Rows.Count > 0)
            {
                string InitialDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql1 = " update CRMActivities set InitialDate= '" + InitialDate + "', " +
                              " UploadDate = '" + UploadDate + "', Uploadby = '" + UserInfo.UserName + "', SynID = 2 " +
                              " where TenentID=" + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + " ";
                DataAccess.ExecuteSQL(sql1);
                Datasyncpso.insert_Live_sync(sql1, "CRMActivities", "UPDATE");
            }

            this.Close();
        }

        public void SelectAppoin()
        {
            string sqlCust = "select * from Appointment where tenentid=" + Tenent.TenentID + "  and ID =" + lblAppointmentNO.Text + "  and Deleted = 1 ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust.Rows.Count > 0)
            {
                int C_ID = Convert.ToInt32(dtCust.Rows[0]["C_ID"]);
                string Custoname = dtCust.Rows[0]["customer"].ToString();
                Selectcustom(C_ID, Custoname);
            }
        }
        public void Selectcustom(int ID, string Name)
        {
            string sqlCust = "select * from tbl_customer where tenentid = " + Tenent.TenentID + " and ID = " + ID + " and trim(Name) = '" + Name + "'";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust.Rows.Count > 0)
            {
                lblCutomer.Text = dtCust.Rows[0]["Name"] + " - " + dtCust.Rows[0]["Phone"] + " - " + dtCust.Rows[0]["EmailAddress"];
            }
        }

        public string create_invoice()
        {
            string invoiceNO = "";

            string sql3 = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + " and LocationID=1 and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "' ";

            DataTable dt1 = DataAccess.GetDataTable(sql3);

            if (dt1.Rows.Count > 0)
            {
                string recVanno = dt1.Rows[0]["UseReciepeID"].ToString();
                int recNo = Convert.ToInt32(recVanno);

                string StrInput = " SELECT (Receipe_Menegement.ItemCode || ' - ' || product_name || ' - ' || Receipe_Menegement.UOM ) as Items,purchase.CustItemCode as 'CustItemCode', " +
                        " Receipe_Menegement.Qty" +
                        " FROM  purchase " +
                        " Inner Join Receipe_Menegement on purchase.product_id = Receipe_Menegement.ItemCode " +
                        " where purchase.TenentID=" + Tenent.TenentID + " and product_id = Receipe_Menegement.ItemCode and Receipe_Menegement.recNo = " + recNo + " and Receipe_Menegement.IOSwitch = 'Output' ";
                //" and Receipe_Menegement.IOSwitch = 'Input' ";
                DataTable dtInput = DataAccess.GetDataTable(StrInput);

                if (dtInput.Rows.Count > 0)
                {
                    if (Application.OpenForms["SalesRegister"] == null)
                    {
                        SalesRegister go = new SalesRegister();
                        go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                        go.Show();

                    }

                    if (Application.OpenForms["AppointmentS1"] != null)
                    {
                        AppointmentS1 mkc1 = (AppointmentS1)Application.OpenForms["AppointmentS1"];
                        mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                        mkc1.BringToFront();
                        mkc1.WindowState = FormWindowState.Maximized;
                    }

                    if (Application.OpenForms["SalesRegister"] != null)
                    {
                        SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                        mkc1.clearinvoice = ".";
                    }

                    if (Application.OpenForms["SalesRegister"] != null)
                    {
                        SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                        mkc1.CustName = lblCutomer.Text;
                    }

                    for (int i = 0; i < dtInput.Rows.Count; i++)
                    {
                        string Itme = dtInput.Rows[i]["Items"].ToString();

                        string product_id = Itme.Split('-')[0].Trim();
                        string UOMID = Itme.Split('-')[2].Trim();
                        string CustItemCode = dtInput.Rows[i]["CustItemCode"].ToString();
                        string ButtonTag = product_id + "~" + UOMID + "," + CustItemCode;
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

                    return invoiceNO;
                }
            }
            return invoiceNO;

        }
        private void btnInvoiceAssing_Click(object sender, EventArgs e)
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
                    string sql = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + "  and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "' ";
                    DataTable dt = DataAccess.GetDataTable(sql);

                    if (dt.Rows.Count > 0)
                    {
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql1 = " update CRMMainActivities set MyStatus='" + invoiceno + "',  " +
                                      " UploadDate = '" + UploadDate + "', Uploadby = '" + UserInfo.UserName + "', SynID = 2 " +
                                      " where TenentID = " + Tenent.TenentID + " and MasterCODE = " + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "'  ";
                        DataAccess.ExecuteSQL(sql1);
                        Datasyncpso.insert_Live_sync(sql1, "CRMMainActivities", "UPDATE");
                    }
                }
            }

            this.Close();

            //int CursorY = Cursor.Position.Y;
            //string AppointmentNO = lblAppointmentNO.Text;
            //ShowinvoiceAssign(AppointmentNO, CursorY);
            //this.Close();
        }

        public void ShowinvoiceAssign(string AppointmentNO, int CursorY)
        {
            string sql3 = "select * from CRMMainActivities where TenentID=" + Tenent.TenentID + " and LocationID=1 and MasterCODE = " + MasterCODE.Text + " and MyID = '" + AppointmentNO + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            int cal = Cursor.Position.X;
            int CursorX = cal - 350;

            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["MyStatus"] == null)
                {
                    if (Application.OpenForms["invoiceAssing"] != null)
                    {
                        Application.OpenForms["invoiceAssing"].Close();
                    }

                    invoiceAssing mkc1 = new invoiceAssing(CursorX, CursorY);
                    mkc1.Appintment_id = AppointmentNO;
                    mkc1.JobID = MasterCODE.Text;
                    mkc1.Show();
                }
                else
                {
                    string EmployeeName = dt1.Rows[0]["MyStatus"].ToString().Trim();
                    if (EmployeeName == "" || EmployeeName == "0")
                    {
                        if (Application.OpenForms["invoiceAssing"] != null)
                        {
                            Application.OpenForms["invoiceAssing"].Close();
                        }

                        invoiceAssing mkc1 = new invoiceAssing(CursorX, CursorY);
                        mkc1.Appintment_id = AppointmentNO;
                        mkc1.JobID = MasterCODE.Text;
                        mkc1.Show();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("invoice Already assigned You Want to Reassign?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (Application.OpenForms["invoiceAssing"] != null)
                            {
                                Application.OpenForms["invoiceAssing"].Close();
                            }

                            invoiceAssing mkc1 = new invoiceAssing(CursorX, CursorY);
                            mkc1.Appintment_id = AppointmentNO;
                            mkc1.JobID = MasterCODE.Text;
                            mkc1.Show();
                        }
                    }
                }
            }
        }

        private void btnAddInputitem_Click(object sender, EventArgs e)
        {
            string AppointmentNO = lblAppointmentNO.Text;
            if (Application.OpenForms["AppintmentReceipe"] != null)
            {
                Application.OpenForms["AppintmentReceipe"].Close();
            }

            AppintmentReceipe mkc1 = new AppintmentReceipe();
            mkc1.In_AppointmentID = AppointmentNO;
            mkc1.in_JobID = MasterCODE.Text;
            mkc1.Show();

            this.Close();
        }

    }
}
