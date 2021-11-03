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
    public partial class Add_Appointment : Form
    {
        public Add_Appointment(DateTime currentDt)
        {
           
            InitializeComponent();
            dtstTime.Format = DateTimePickerFormat.Custom;
            dtstTime.CustomFormat = "hh:mm tt";
            dtstTime.ShowUpDown = true;

            //dtendTime.Format = DateTimePickerFormat.Custom;
            //dtendTime.CustomFormat = "hh:mm tt"; ;
            //dtendTime.ShowUpDown = true;

            this.GridAppintment.Columns.Add("Receipe", "Service Template"); // 0 Receipe
            this.GridAppintment.Columns.Add("Employee", "Employee");        // 1 Employee
            this.GridAppintment.Columns.Add("StartDate", "Start Date");     // 2 StartDate
            this.GridAppintment.Columns.Add("Title", "Title");              // 3 Title
            this.GridAppintment.Columns.Add("Remark", "Remark");            // 4 Remark
            this.GridAppintment.Columns.Add("Minute", "Minute");            // 5 Minute

            DataGridViewButtonColumn Pay_del = new DataGridViewButtonColumn();
            this.GridAppintment.Columns.Add(Pay_del);
            Pay_del.HeaderText = "Action";
            Pay_del.Text = "Delete";
            Pay_del.Name = "Delete";
            Pay_del.ToolTipText = "Delete";
            Pay_del.UseColumnTextForButtonValue = true;

            GridAppintment.Columns[0].ReadOnly = true;
            GridAppintment.Columns[1].ReadOnly = true;
            GridAppintment.Columns[2].ReadOnly = true;
            GridAppintment.Columns[3].ReadOnly = true;
            GridAppintment.Columns[4].ReadOnly = true;
            GridAppintment.Columns[5].ReadOnly = true;

            GridAppintment.Columns[5].Visible = false;

            dateFrom.Value = currentDt;
            dateFrom.Format = DateTimePickerFormat.Custom;
            dateFrom.CustomFormat = "yyyy-MMM-dd";

            //dateTO.Format = DateTimePickerFormat.Custom;
            //dateTO.CustomFormat = "yyyy-MMM-dd";
        }

        bool Reciflag = false;

        private void Add_Appointment_Load(object sender, EventArgs e)
        {
            GridAppintment.Rows.Clear();

            BindReceipe();
            BindEmploayee();
            Bind_Customer();
            binddata();
            Reciflag = true;
        }

        public string Appointment_ID
        {
            set
            {
                lblAppintmentID.Text = value;
            }
            get
            {
                return lblAppintmentID.Text;
            }
        }

        public string CustName
        {
            set
            {
                comboCustomer.Text = value;
            }
            get
            {
                return comboCustomer.Text;
            }
        }

        public string ServiceTemplate
        {
            set
            {
                comboReciepe.Text = value;
            }
            get
            {
                return comboReciepe.Text;
            }
        }

        public void SelectReceipe(int recNo)
        {
            string sqlCust = "SELECT * FROM tbl_Receipe where TenentID = " + Tenent.TenentID + " and recNo = " + recNo + " ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust.Rows.Count > 0)
            {
                comboReciepe.Text = dtCust.Rows[0]["Receipe_English"] + " ~ " + dtCust.Rows[0]["recNo"] + " ~ " + dtCust.Rows[0]["Receipe_Arabic"];
                comboReciepe.Enabled = false;
            }
        }

        public void binddata()
        {
            string ID = lblAppintmentID.Text;
            string sqlCust = "select Title,Employee,customer,status,ExpStartDate,ExpEndDate,C_ID from Appointment where tenentid=" + Tenent.TenentID + " and LocationID=1 and ID = '" + ID + "' ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            if (dtCust.Rows.Count > 0)
            {
                txtAPOtitle.Text = dtCust.Rows[0]["Title"].ToString();
                comboEmployee.Text = dtCust.Rows[0]["Employee"].ToString();
                comboCustomer.Text = GetCustomer(dtCust.Rows[0]["customer"].ToString(), dtCust.Rows[0]["C_ID"].ToString());
                comboCustomer.Enabled = false;
                combostatus.Text = dtCust.Rows[0]["status"].ToString();
                dateFrom.Value = Convert.ToDateTime(dtCust.Rows[0]["ExpStartDate"]);
                //dateTO.Value = Convert.ToDateTime(dtCust.Rows[0]["ExpEndDate"]);
                dtstTime.Value = Convert.ToDateTime(dtCust.Rows[0]["ExpStartDate"]);
                //dtendTime.Value = Convert.ToDateTime(dtCust.Rows[0]["ExpEndDate"]);

                string sql = "select * from CRMMainActivities where tenentid=" + Tenent.TenentID + "  and MyID = '" + ID + "' ";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt != null)
                {
                    int recNo = 0;
                    if (dt.Rows.Count > 0)
                    {
                        recNo = dt.Rows[0]["UseReciepeID"] != null ? Convert.ToInt32(dt.Rows[0]["UseReciepeID"]) : 0;
                        SelectReceipe(recNo);
                        txtremark.Text = dt.Rows[0]["Remarks"] != null ? dt.Rows[0]["Remarks"].ToString() : "";
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string UseReciepe = "";
                        string Employee = dt.Rows[i]["USERNAME"] != null ? dt.Rows[0]["USERNAME"].ToString() : "";
                        string sDate = dateFrom.Value.ToString();
                        string Title = dt.Rows[i]["ACTIVITYE"] != null ? dt.Rows[0]["ACTIVITYE"].ToString() : "";
                        string remark = dt.Rows[i]["Remarks"] != null ? dt.Rows[0]["Remarks"].ToString() : "";
                        int minuteTo = 0;

                        string sqlCust1 = "SELECT * FROM tbl_Receipe where TenentID = " + Tenent.TenentID + " and recNo = " + recNo + " ";
                        DataTable dtrec = DataAccess.GetDataTable(sqlCust1);
                        if (dtrec.Rows.Count > 0)
                        {
                            UseReciepe = dtrec.Rows[0]["Receipe_English"] + " ~ " + dtrec.Rows[0]["recNo"] + " ~ " + dtrec.Rows[0]["Receipe_Arabic"];
                            int UseReciepeID = Convert.ToInt32(UseReciepe.Split('~')[1].Trim());
                            minuteTo = ReceipeMenegement.getTotalMinuteForReceipe(UseReciepeID);
                        }

                        GridAppintment.Rows.Add(UseReciepe, Employee, sDate, Title, remark, minuteTo);
                    }
                }

                btnCustomerAdd.Visible = false;
                btnAppGridAdd.Visible = false;
                GridAppintment.Visible = false;
            }
        }

        public void BindEmploayee()
        {
            //comboEmployee

            comboEmployee.Items.Clear();

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
            comboEmployee.Text = First;

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
        public void BindReceipe()
        {
            string sql = "SELECT  ( TR.Receipe_English || ' ~ ' || TR.recNo || ' ~ ' || TR.Receipe_Arabic) as Receipe " +
                         " FROM tbl_Receipe TR inner join Receipe_Menegement RM on RM.recNo = TR.recNo and RM.TenentID = TR.TenentID " +
                         " where RM.TenentID = " + Tenent.TenentID + " group by RM.recNo ";

            DataTable dt = DataAccess.GetDataTable(sql);
            //comboReceipe.DataSource = dt;
            //comboReceipe.DisplayMember = "Receipe";

            comboReciepe.Items.Clear();

            comboReciepe.Items.Add("-- select Receipe / Package --");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboReciepe.Items.Add(dt.Rows[i][0]);
                }
            }
            comboReciepe.Text = "-- select Receipe / Package --";

            if (dt != null)
            {
                AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
                foreach (DataRow rw in dt.Rows)
                {
                    string Val = rw["Receipe"].ToString();
                    AutoItem.Add(Val);

                }
                comboReciepe.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboReciepe.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboReciepe.AutoCompleteCustomSource = AutoItem;
            }

        }

        public string GetCustomer(string Name, string ID)
        {
            string Customer = "";
            string sqlCust = "select * from tbl_customer where tenentid=" + Tenent.TenentID + " and ID = '" + ID + "' and trim(Name) = '" + Name + "'  and peopleType = 'Customer' ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            if (dtCust.Rows.Count > 0)
            {
                Customer = dtCust.Rows[0]["Name"] + " ~ " + dtCust.Rows[0]["ID"] + " ~ " + dtCust.Rows[0]["Phone"];
            }
            else
            {
                Customer = ID + " ~ " + Name;
            }

            return Customer;
        }

        public void Bind_Customer()
        {
            //Customer Databind

            comboCustomer.Items.Clear();

            string sqlCust = "select * from tbl_customer where tenentid=" + Tenent.TenentID + "  and peopleType = 'Customer' ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            string First = "";
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    string add = dtCust.Rows[i]["Name"] + " ~ " + dtCust.Rows[i]["ID"] + " ~ " + dtCust.Rows[i]["Phone"];
                    if (First == "")
                    {
                        First = add;
                    }
                    comboCustomer.Items.Add(add);
                }
            }
            comboCustomer.Text = First;


            if (dtCust != null)
            {
                AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
                foreach (DataRow rw in dtCust.Rows)
                {
                    string Val = rw["Name"] + " ~ " + rw["ID"] + " ~ " + rw["Phone"].ToString();
                    AutoItem.Add(Val);

                }
                comboCustomer.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboCustomer.AutoCompleteCustomSource = AutoItem;
            }
            //comboCustomer.DataSource = dtCust;
            //comboCustomer.DisplayMember = "Name";
            //comboCustomer.ValueMember = "ID";
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int GetGridMinute()
        {
            int Minute = 0;
            for (int i = 0; i < GridAppintment.Rows.Count; i++)
            {
                Minute = Convert.ToInt32(GridAppintment.Rows[i].Cells[5].Value);
            }
            return Minute;
        }

        public int GetGridEmployeeMinute(string Employee)
        {
            int Minute = 0;
            for (int i = 0; i < GridAppintment.Rows.Count; i++)
            {
                string gridEmp = GridAppintment.Rows[i].Cells[1].Value.ToString();
                if (gridEmp.ToLower().Trim() == Employee.ToLower().Trim())
                {
                    Minute = Convert.ToInt32(GridAppintment.Rows[i].Cells[5].Value);
                }
            }
            return Minute;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (comboReciepe.Text == "-- select Receipe / Package --" || comboReciepe.Text == "" || comboReciepe.Text == "System.Data.DataRowView")
            //{
            //    MessageBox.Show("select Receipe Required ");
            //    txtAPOtitle.Focus();
            //}
            //else if (txtAPOtitle.Text == "")
            //{
            //    MessageBox.Show("Title Required");
            //    txtAPOtitle.Focus();
            //}
            //else if (comboCustomer.Text == "" || comboCustomer.Text == "System.Data.DataRowView")
            //{
            //    MessageBox.Show("Customer Required");
            //    comboCustomer.Focus();
            //}
            //else if (comboEmployee.Text == "" || comboEmployee.Text == "System.Data.DataRowView")
            //{
            //    MessageBox.Show("Employee Required");
            //    comboEmployee.Focus();
            //}
            //else if (combostatus.Text == "" || combostatus.Text == "System.Data.DataRowView")
            //{
            //    MessageBox.Show("Status Required");
            //    combostatus.Focus();
            //}
            //else if (dtstTime.Text == "")
            //{
            //    MessageBox.Show("Start Time Required");
            //    dtstTime.Focus();
            //}
            //else if (dtendTime.Text == "")
            //{
            //    MessageBox.Show("End Time Required");
            //    dtendTime.Focus();
            //}
            //else if (dateFrom.Text == "")
            //{
            //    MessageBox.Show("Start Date Required");
            //    dateFrom.Focus();
            //}
            //else if (dateTO.Text == "")
            //{
            //    MessageBox.Show("End Date Required");
            //    dateTO.Focus();
            //}

            if (GridAppintment.Rows.Count < 1)
            {
                if (lblAppintmentID.Text == "-")
                {
                    MessageBox.Show("Please Add Atlest One Job in Grid");
                    return;
                }
                else
                {
                    AddAppointment();
                }
            }
            else
            {
                int C_ID = Convert.ToInt32(comboCustomer.Text.Split('~')[1].Trim());
                string customer = comboCustomer.Text.Split('~')[0].Trim();

                string Remark = "";
                if (GridAppintment.Rows.Count > 0)
                {
                    Remark = GridAppintment.Rows[0].Cells[4].Value.ToString();
                    if (lblCustomerAddFLag.Text == "1")
                    {
                        Customer.AddNewCustomer.updateCustomerRemark(C_ID, customer, Remark);
                    }
                }

                AddAppointment();
            }
        }

        public void AddAppointment()
        {
            //`TenentID` INTEGER, `LocationID` INTEGER, `ShopID` TEXT `ID` INTEGER, `Title` nvarchar ( 100 ), `StartDt` datetime,  `EndDt` datetime,
            //`Employee` TEXT, `customer` TEXT, `status` nvarchar ( 100 ), `JobDone` INTEGER DEFAULT 0, `Createby` TEXT,  `DateTime` datetime,  `Active` INTEGER, 
            //`Deleted` INTEGER,`UploadDate` TEXT, `Uploadby` NVARCHAR ( 50 ), `SyncDate` TEXT, `Syncby` NVARCHAR ( 50 ), `SynID` int

            int TenentID = Tenent.TenentID;
            int LocationID = 1;
            string ShopID = UserInfo.Shopid;

            string C_ID = comboCustomer.Text.Split('~')[1].Trim();
            string customer = comboCustomer.Text.Split('~')[0].Trim();
            string status = combostatus.Text;
            string Color = get_colorfromstatus(status).ToLower();
            int JobDone = 0;
            string Createby = UserInfo.Userid.ToString();
            string DateAdd = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            int Active = 1;
            int Deleted = 1;
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string Uploadby = UserInfo.UserName;

            if (lblAppintmentID.Text == "-")
            {
                string Title = "";
                string Employee = "";

                string Receipe = GridAppintment.Rows[0].Cells[0].Value.ToString();
                int UseReciepeID = Convert.ToInt32(Receipe.Split('~')[1].Trim());

                string sDate = GridAppintment.Rows[0].Cells[2].Value.ToString();// dateFrom.Value.ToString("yyyy-MMM-dd") + " " + dtstTime.Value.ToString("hh:mm:ss tt");
                //string Edate = dateTO.Value.ToString("yyyy-MMM-dd") + " " + dtendTime.Value.ToString("hh:mm:ss tt");

                DateTime StartDt = Convert.ToDateTime(sDate);
                int minuteTo = GetGridMinute();// ReceipeMenegement.getTotalMinuteForReceipe(UseReciepeID);
                DateTime EndDt = StartDt.AddMinutes(minuteTo); //Convert.ToDateTime(Edate);

                string ExpStartDate = StartDt.ToString("yyyy-MM-dd HH:mm:ss");
                string ExpEndDate = EndDt.ToString("yyyy-MM-dd HH:mm:ss");

                Title = GridAppintment.Rows[0].Cells[3].Value.ToString();// txtAPOtitle.Text;
                Employee = GridAppintment.Rows[0].Cells[1].Value.ToString();// comboEmployee.Text;                

                int ID = DataAccess.getAppointmentMaxID(TenentID, LocationID);

                string sql1 = " insert into Appointment (TenentID, LocationID, ID, Title, ExpStartDate, ExpEndDate,Employee,customer,C_ID, status,Color, JobDone, Createby,  DateTime,  Active,Deleted,UploadDate, Uploadby, SynID) " +
                                " values (" + TenentID + ",'" + LocationID + "', '" + ID + "','" + Title + "' , '" + ExpStartDate + "', '" + ExpEndDate + "','" + Employee + "','" + customer + "','" + C_ID + "', " +
                                " '" + status + "','" + Color + "','" + JobDone + "','" + Createby + "','" + DateAdd + "','" + Active + "','" + Deleted + "','" + UploadDate + "','" + Uploadby + "', 1 )";
                int flag1 = DataAccess.ExecuteSQL(sql1);
                Datasyncpso.insert_Live_sync(sql1, "Appointment", "INSERT");

                string ActivityName = "Add Appointment";
                string LogData = "Add Appointment with Appointment no = " + ID + " ";
                Login.InsertUserLog(ActivityName, LogData);

                for (int i = 0; i < GridAppintment.Rows.Count; i++)
                {
                    // 0 Service Template
                    // 1 Employee
                    // 2 Start Date
                    // 3 Title
                    // 4 Remark

                    StartDt = Convert.ToDateTime(GridAppintment.Rows[i].Cells[2].Value.ToString());
                    ExpStartDate = StartDt.ToString("yyyy-MM-dd HH:mm:ss");                    

                    Title = GridAppintment.Rows[i].Cells[3].Value.ToString();// txtAPOtitle.Text;
                    Employee = GridAppintment.Rows[i].Cells[1].Value.ToString();// comboEmployee.Text;
                    Receipe = GridAppintment.Rows[i].Cells[0].Value.ToString();
                    UseReciepeID = Convert.ToInt32(Receipe.Split('~')[1].Trim());
                    string UseReciepeName = Receipe.Split('~')[0].Trim();
                    string Remarks = GridAppintment.Rows[i].Cells[4].Value.ToString();

                    AddFirstJob(TenentID, LocationID, ID, Employee, Title, Remarks, UseReciepeName, UseReciepeID, StartDt);
                }

            }
            else
            {
                bool flg = ValidData();
                if (flg == false)
                {
                    return;
                }

                string Title = txtAPOtitle.Text;
                int UseReciepeID = Convert.ToInt32(comboReciepe.Text.Split('~')[1].Trim());
                string sDate = dateFrom.Value.ToString("yyyy-MMM-dd") + " " + dtstTime.Value.ToString("hh:mm:ss tt");
                DateTime StartDt = Convert.ToDateTime(sDate);
                int minuteTo = GetGridMinute();// ReceipeMenegement.getTotalMinuteForReceipe(UseReciepeID);
                DateTime EndDt = StartDt.AddMinutes(minuteTo);

                string ExpStartDate = StartDt.ToString("yyyy-MM-dd HH:mm:ss");
                string ExpEndDate = EndDt.ToString("yyyy-MM-dd HH:mm:ss");

                string Employee = comboEmployee.Text;

                string sql1 = " update Appointment set Title = '" + Title + "', ExpStartDate = '" + ExpStartDate + "', ExpEndDate = '" + ExpEndDate + "', Employee = '" + Employee + "' , customer =  '" + customer + "',C_ID = '" + C_ID + "', " +
                              " status = '" + status + "',Color = '" + Color + "', JobDone = '" + JobDone + "', Createby = '" + Createby + "',  DateTime = '" + DateAdd + "',  Active = '" + Active + "', " +
                              " Deleted = '" + Deleted + "',UploadDate = '" + UploadDate + "', Uploadby = '" + Uploadby + "', SynID = 2 " +
                              " where TenentID = " + TenentID + " and LocationID = " + LocationID + " and ID= '" + lblAppintmentID.Text + "' ";
                int flag1 = DataAccess.ExecuteSQL(sql1);

                Datasyncpso.insert_Live_sync(sql1, "Appointment", "UPDATE");

                string ActivityName = "Update Appointment";
                string LogData = "Update Appointment with Appointment no = " + lblAppintmentID.Text + " ";
                Login.InsertUserLog(ActivityName, LogData);
            }

            this.Close();

        }

        public static void AddFirstJob(int TenentID, int LocationID, int AppointmentID, string Employee, string Title, string Remarks, string UseReciepeName, int UseReciepeID,DateTime StartDt)
        {
            int COMPID = 826667;
            //string appointmentID = ID.ToString();
            int TRID = Convert.ToInt32(AppointmentID);
            int RouteID = 1;
            int USERCODE = 0;
            string ACTIVITYE = Title;
            string Username = Employee;
            int ModuleID = 0;
            int Activityid = 0;
            string activityname = Title;
            string CampynName = null;
            string Description = Title;
            int DocNO = 0;
            int LinkMasterCODE = 1;
            int GROUPCODE = 1;

            int JobID = Add_Job.InserActivityMain(TenentID, COMPID, LocationID, TRID, RouteID, USERCODE, ACTIVITYE, Username, ModuleID, Activityid, activityname, CampynName, Description, DocNO, LinkMasterCODE, GROUPCODE, true, Remarks, UseReciepeName, UseReciepeID, StartDt);
        }

        public static string get_colorfromstatus(string status)
        {
            if (status == "Not Confirmed") { return "Red"; }
            else if (status == "Confirmed") { return "Green"; }
            else if (status == "No Answer") { return "Blue"; }
            else if (status == "In Waiting") { return "Yellow"; }
            else if (status == "Visited") { return "Purple"; }
            else if (status == "Closed") { return "Gray"; }
            else if (status == "Canceled") { return "Indigo"; }
            else if (status == "No Status") { return "Aqua"; }
            else { return ""; }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (Application.OpenForms["AddNewCustomer"] != null)
            {
                Application.OpenForms["AddNewCustomer"].BringToFront();
                Application.OpenForms["AddNewCustomer"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                UserInfo.addcustomerflag = true;
                Customer.AddNewCustomer go = new Customer.AddNewCustomer();
                go.Show();
            }
        }

        private void Add_Appointment_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void btnCashierRefresh_Click(object sender, EventArgs e)
        {
            Bind_Customer();
        }

        private void txtAPOtitle_Enter(object sender, EventArgs e)
        {
            if (comboReciepe.Text != "-- select Receipe / Package --" && comboReciepe.Text != "System.Data.DataRowView")
            {
                if (comboCustomer.Text != "" || comboCustomer.Text != "System.Data.DataRowView")
                {
                    //ReciepeNAme_CustomerName_DDMMYY_05:24
                    string Reciepename = comboReciepe.Text.Split('~')[0].Trim();
                    string CutomerName = comboCustomer.Text.Split('~')[0].Trim();

                    string sDate = dateFrom.Value.ToString("yyyy-MMM-dd") + " " + dtstTime.Value.ToString("hh:mm:ss tt");
                    DateTime StartDt = Convert.ToDateTime(sDate);
                    string ExpStartDate = StartDt.ToString("ddMMyy_HH:mm");
                    txtAPOtitle.Text = Reciepename + "_" + CutomerName + "_" + ExpStartDate;
                }
                overlap();
            }
        }

        private void comboReciepe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Reciflag == true)
            {
                if (comboReciepe.Text != "-- select Receipe / Package --" && comboReciepe.Text != "System.Data.DataRowView")
                {
                    string remark = "";
                    if (txtremark.Text != "")
                    {
                        remark = txtremark.Text;
                    }

                    string RecValye = comboReciepe.Text.Trim();
                    string recVanno = RecValye.Split('~')[1].Trim();
                    int recNo = Convert.ToInt32(recVanno);

                    string StrInput = " SELECT (product_name || ' - ' || ICUOM.UOMNAME1 ) as Items, " +
                            " Receipe_Menegement.Qty" +
                            " FROM  purchase " +
                            " Inner Join Receipe_Menegement on purchase.product_id = Receipe_Menegement.ItemCode and purchase.TenentID = Receipe_Menegement.TenentID " +
                            " Inner Join ICUOM  ON  Receipe_Menegement.UOM = ICUOM.UOM and Receipe_Menegement.TenentID = ICUOM.TenentID " +
                            " where purchase.TenentID = " + Tenent.TenentID + " and product_id = Receipe_Menegement.ItemCode and Receipe_Menegement.recNo = " + recNo + "  "; // and Receipe_Menegement.IOSwitch = 'Output'
                    //" and Receipe_Menegement.IOSwitch = 'Input' ";
                    DataTable dtInput = DataAccess.GetDataTable(StrInput);

                    if (dtInput.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtInput.Rows.Count; i++)
                        {
                            string Items = dtInput.Rows[i][0].ToString();
                            string Qty = dtInput.Rows[i][1].ToString() == "0" ? "" : dtInput.Rows[i][1].ToString();
                            remark = Items + "  Qty =  " + Qty + ",";
                        }
                    }

                    txtremark.Text = remark;
                }
            }
        }

        private void comboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            overlap();
        }

        public void overlap()
        {
            if (comboReciepe.Text == "-- select Receipe / Package --" || comboReciepe.Text == "" || comboReciepe.Text == "System.Data.DataRowView")
            {
            }
            else if (comboEmployee.Text == "" || comboEmployee.Text == "System.Data.DataRowView")
            {
            }
            else if (dateFrom.Text == "")
            {
            }
            else if (dtstTime.Text == "")
            {
            }
            else
            {
                string Employee = comboEmployee.Text;
                string RecValye = comboReciepe.Text.Trim();
                string recVanno = RecValye.Split('~')[1].Trim();
                int recNo = Convert.ToInt32(recVanno);
                //int minuteTo = 0;
                //if (GridAppintment.Rows.Count > 0)
                //{
                //    int GridMinute = GetGridEmployeeMinute(Employee);
                //    minuteTo = GridMinute + ReceipeMenegement.getTotalMinuteForReceipe(recNo);
                //}
                //else
                //{
                //    minuteTo = ReceipeMenegement.getTotalMinuteForReceipe(recNo);
                //}

                int minuteTo = ReceipeMenegement.getTotalMinuteForReceipe(recNo);

                string sDate = dateFrom.Value.ToString("yyyy-MMM-dd") + " " + dtstTime.Value.ToString("hh:mm:ss tt");

                DateTime StartDt = Convert.ToDateTime(sDate);

                DateTime StartDate = StartDt;
                DateTime EndDate = StartDate.AddMinutes(minuteTo);

                getExistAppoinmentinGrid(Employee, StartDate, EndDate);

                sDate = dateFrom.Value.ToString("yyyy-MMM-dd") + " " + dtstTime.Value.ToString("hh:mm:ss tt");

                StartDt = Convert.ToDateTime(sDate);

                int AppintmentID = 0;
                if (lblAppintmentID.Text != "-")
                {
                    AppintmentID = Convert.ToInt32(lblAppintmentID.Text);
                }

                int AppintMentID = getExistAppoinment(AppintmentID, Employee, StartDate, EndDate);
                if (AppintMentID != 0)
                {
                    string StTime = StartDt.ToString("yyyy-MMM-dd hh:mm tt");
                    string Till = EndDate.ToString("yyyy-MMM-dd hh:mm tt");
                    DialogResult result = MessageBox.Show(" '" + Employee + "'  Time  " + StTime + " overlap till " + Till + " Do you Want To Add After " + Till + " ? ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EndDate = EndDate.AddMinutes(1);
                        dtstTime.Value = EndDate;
                    }
                }
            }
        }

        public int getExistAppoinment(int AppintmentID, string Employee, DateTime StartDate, DateTime EndDate)
        {
            string StartDate1 = StartDate.ToString("yyyy-MM-dd HH:mm:ss");
            string EndDate1 = EndDate.ToString("yyyy-MM-dd HH:mm:ss");

            int MasterAppointID = 0;
            //string Sql1 = " select * from Appointment where TenentID = " + Tenent.TenentID + " and Employee = '" + Employee + "' and JobDone = 0 " +
            //              " and ((ExpstartDate between '" + StartDate1 + "' and '" + EndDate1 + "') or (ExpEndDate between '" + StartDate1 + "' and '" + EndDate1 + "')) and ID not in (" + AppintmentID + ") ";

            //string Sql1 = " select * from Appointment where TenentID = " + Tenent.TenentID + " and ID not in (" + AppintmentID + ") and Employee = '" + Employee + "' and JobDone = 0 " +
            //              " and  ExpstartDate < '" + StartDate1 + "' and  ExpEndDate > '" + StartDate1 + "' and " +
            //              " (ExpstartDate <> '" + EndDate1 + "' or ExpEndDate <> '" + EndDate1 + "') ";

            string Sql1 = " select ID from CRMActivities CA  inner join CRMMainActivities CMA on CMA.TenentID = CA.TenentID and CMA.MasterCODE = CA.MasterCODE " +
                          " inner join Appointment Appo on  CMA.TenentID = Appo.TenentID and CMA.MyID = Appo.ID " +
                          " where CA.TenentID = " + Tenent.TenentID + " and Appo.ID not in (" + AppintmentID + ") and CA.USERNAME = '" + Employee + "' and Appo.JobDone = 0  " +
                          " and  CA.ExpstartDate < '" + StartDate1 + "' and  CA.ExpEndDate > '" + StartDate1 + "' and  " +
                          " (CA.ExpstartDate <> '" + EndDate1 + "' or CA.ExpEndDate <> '" + EndDate1 + "') ";


            DataTable Dt = DataAccess.GetDataTable(Sql1);

            if (Dt.Rows.Count > 0)
            {
                MasterAppointID = Convert.ToInt32(Dt.Rows[0]["ID"]);
                return MasterAppointID;
            }
            else
            {
                return MasterAppointID;
            }
        }

        // 0 Receipe
        // 1 Employee
        // 2 StartDate
        // 3 Title
        // 4 Remark
        // 5 Minute

        public int getExistAppoinmentinGrid(string Employee, DateTime StartDate, DateTime EndDate)
        {
            int MasterAppointID = -1;

            if (GridAppintment.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in GridAppintment.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(Employee))
                    {
                        DateTime RowstartDate = Convert.ToDateTime(row.Cells[2].Value);
                        int Minute = Convert.ToInt32(row.Cells[5].Value);
                        DateTime RowEndDate = RowstartDate.AddMinutes(Minute);

                        if (RowstartDate <= StartDate && RowEndDate >= StartDate)
                        {
                            if (RowstartDate < EndDate || RowEndDate > EndDate)
                            {
                                MasterAppointID = row.Index;
                                string StTime = StartDate.ToString("yyyy-MMM-dd hh:mm tt");
                                string Till = RowEndDate.ToString("yyyy-MMM-dd hh:mm tt");
                                DialogResult result = MessageBox.Show(" '" + Employee + "'  Time  " + StTime + " overlap till " + Till + " Do you Want To Add After " + Till + " ? ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {
                                    RowEndDate = RowEndDate.AddMinutes(1);
                                    dtstTime.Value = EndDate;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            return MasterAppointID;
        }

        public DateTime getExistAppoinmentTime(int ID)
        {
            DateTime StartDate = DateTime.Now;
            string Sql1 = "select * from Appointment where TenentID = " + Tenent.TenentID + " and ID = " + ID + " ";
            DataTable Dt = DataAccess.GetDataTable(Sql1);

            if (Dt.Rows.Count > 0)
            {
                StartDate = Convert.ToDateTime(Dt.Rows[0]["ExpStartDate"]);
            }
            return StartDate;
        }

        public int getExistJobReciepe(int AppintMentID)
        {
            int ReceiepeID = 0;
            string Sql1 = "select * from CRMMainActivities where TenentID = " + Tenent.TenentID + " and MyID = " + AppintMentID + " ";
            DataTable Dt = DataAccess.GetDataTable(Sql1);

            if (Dt.Rows.Count > 0)
            {
                ReceiepeID = Convert.ToInt32(Dt.Rows[0]["UseReciepeID"]);
            }
            return ReceiepeID;
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            overlap();
        }

        private void dtstTime_ValueChanged(object sender, EventArgs e)
        {
            if (fagDateSave==false)
            {
                overlap();
            }
            else
            {
                fagDateSave = false;
            }            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["AppointCustomerSearch"] != null)
            {
                Application.OpenForms["AppointCustomerSearch"].Close();
            }
            this.Refresh();

            AppointCustomerSearch go = new AppointCustomerSearch();
            go.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["AppointServiceTemplateSearch"] != null)
            {
                Application.OpenForms["AppointServiceTemplateSearch"].Close();
            }
            this.Refresh();

            AppointServiceTemplateSearch go = new AppointServiceTemplateSearch();
            go.PageName = "Add_Appointment";
            go.Show();
        }

        private void linkCustomerHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["CustomerJobHistory"] != null)
            {
                Application.OpenForms["CustomerJobHistory"].Close();
            }
            this.Refresh();

            CustomerJobHistory go = new CustomerJobHistory();
            go.PageName = "Add_Appointment";
            go.Customer = comboCustomer.Text;
            go.Show();
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            comboCustomer.Text = Add_Item.voidQueryValidate(comboCustomer.Text);
            if (comboCustomer.Text != "")
            {
                string customer = "";
                if (comboCustomer.Text.Contains('~'))
                {
                    string C_ID = comboCustomer.Text.Split('~')[1].Trim();
                    customer = comboCustomer.Text.Split('~')[0].Trim();
                }
                else
                {
                    customer = comboCustomer.Text.Trim();
                }

                bool isfound = CheckCustomerExist(customer);
                if (isfound == false)
                {
                    int ID = Customer.AddNewCustomer.AddCustomer(customer);
                    lblCustomerAddFLag.Text = "1";
                    comboCustomer.Text = customer + " ~ " + ID + " ~ ";
                }
                else
                {
                    MessageBox.Show("Customer Allready Exist");
                }
            }
            else
            {
                MessageBox.Show("Fill Customer Name");
            }

        }

        public bool CheckCustomerExist(string CustomerName)
        {
            string ExistName = CustomerName.Trim().ToUpper();
            ExistName = ExistName.Replace("-", "");
            string sql = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer' and upper(trim(Name)) = '" + ExistName + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        private void comboCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == '~' || e.KeyChar == '.' || e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtAPOtitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void btnAppGridAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtremark.Text = Add_Item.voidQueryValidate(txtremark.Text);
                txtAPOtitle.Text = Add_Item.voidQueryValidate(txtAPOtitle.Text);
                if (comboReciepe.Text == "-- select Receipe / Package --" || comboReciepe.Text == "" || comboReciepe.Text == "System.Data.DataRowView")
                {
                    MessageBox.Show("select Receipe Required ");
                    txtAPOtitle.Focus();
                }
                else if (txtAPOtitle.Text == "")
                {
                    MessageBox.Show("Title Required");
                    txtAPOtitle.Focus();
                }
                else if (comboCustomer.Text == "" || comboCustomer.Text == "System.Data.DataRowView")
                {
                    MessageBox.Show("Customer Required");
                    comboCustomer.Focus();
                }
                else if (!comboCustomer.Text.Contains("~") )
                {
                    MessageBox.Show("Invalid Customer.");
                    comboCustomer.Focus();
                }
                else if (comboEmployee.Text == "" || comboEmployee.Text == "System.Data.DataRowView")
                {
                    MessageBox.Show("Employee Required");
                    comboEmployee.Focus();
                }
                else if (combostatus.Text == "" || combostatus.Text == "System.Data.DataRowView")
                {
                    MessageBox.Show("Status Required");
                    combostatus.Focus();
                }
                else if (dtstTime.Text == "")
                {
                    MessageBox.Show("Start Time Required");
                    dtstTime.Focus();
                }
                else
                {
                    string Title = txtAPOtitle.Text;
                    string Employee = comboEmployee.Text;
                    string UseReciepe = comboReciepe.Text.Trim();
                    int UseReciepeID = Convert.ToInt32(UseReciepe.Split('~')[1].Trim());
                    string remark = txtremark.Text;
                    string sDate = dateFrom.Value.ToString("yyyy-MMM-dd") + " " + dtstTime.Value.ToString("hh:mm:ss tt");
                    int minuteTo = ReceipeMenegement.getTotalMinuteForReceipe(UseReciepeID);

                    int n = Finditem(UseReciepe, Employee);
                    if (n == -1)  //If new item
                    {
                        GridAppintment.Rows.Add(UseReciepe, Employee, sDate, Title, remark, minuteTo);
                    }
                    else
                    {
                        GridAppintment.Rows[n].Cells[2].Value = sDate;
                        GridAppintment.Rows[n].Cells[3].Value = Title;
                        GridAppintment.Rows[n].Cells[4].Value = remark;
                        GridAppintment.Rows[n].Cells[5].Value = minuteTo;
                    }

                    int GridEmpMinute = GetGridMinute();
                    GridEmpMinute = GridEmpMinute + 1;
                    DateTime NextDate = Convert.ToDateTime(sDate);
                    fagDateSave = true;
                    dtstTime.Value = NextDate.AddMinutes(GridEmpMinute);


                    Clear();
                }
            }
            catch { }
        }

        bool fagDateSave = false;

        public bool ValidData()
        {
            if (comboReciepe.Text == "-- select Receipe / Package --" || comboReciepe.Text == "" || comboReciepe.Text == "System.Data.DataRowView")
            {
                MessageBox.Show("select Receipe Required ");
                txtAPOtitle.Focus();
                return false;
            }
            else if (txtAPOtitle.Text == "")
            {
                MessageBox.Show("Title Required");
                txtAPOtitle.Focus();
                return false;
            }
            else if (comboCustomer.Text == "" || comboCustomer.Text == "System.Data.DataRowView")
            {
                MessageBox.Show("Customer Required");
                comboCustomer.Focus();
                return false;
            }
            else if (comboEmployee.Text == "" || comboEmployee.Text == "System.Data.DataRowView")
            {
                MessageBox.Show("Employee Required");
                comboEmployee.Focus();
                return false;
            }
            else if (combostatus.Text == "" || combostatus.Text == "System.Data.DataRowView")
            {
                MessageBox.Show("Status Required");
                combostatus.Focus();
                return false;
            }
            else if (dtstTime.Text == "")
            {
                MessageBox.Show("Start Time Required");
                dtstTime.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Clear()
        {
            txtAPOtitle.Text = "";
            txtremark.Text = "";
            comboReciepe.Text = "-- select Receipe / Package --";
            if (lblFirstEmployee.Text != "-")
            {
                comboEmployee.Text = lblFirstEmployee.Text;
            }

        }

        public int Finditem(string UseReciepe, string Employee)
        {
            int k = -1;
            if (GridAppintment.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in GridAppintment.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(UseReciepe) && row.Cells[1].Value.ToString().Equals(Employee))
                    {
                        k = row.Index;
                        break;
                    }
                }
            }
            return k;
        }

        private void GridAppintment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GridAppintment.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row2 in GridAppintment.SelectedRows)
                {
                    if (!row2.IsNewRow)
                        GridAppintment.Rows.Remove(row2);

                }
            }
        }

    }
}
