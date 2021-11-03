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
    public partial class Add_Job : Form
    {
        public Add_Job()
        {
            InitializeComponent();
            //dtstTime.Format = DateTimePickerFormat.Custom;
            //dtstTime.CustomFormat = "hh:mm tt";
            //dtstTime.ShowUpDown = true;

            //dtendTime.Format = DateTimePickerFormat.Custom;
            //dtendTime.CustomFormat = "hh:mm tt"; ;
            //dtendTime.ShowUpDown = true;

            //dateFrom.Format = DateTimePickerFormat.Custom;
            //dateFrom.CustomFormat = "yyyy-MMM-dd";

            //dateTO.Format = DateTimePickerFormat.Custom;
            //dateTO.CustomFormat = "yyyy-MMM-dd";
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

        bool Reciflag = false;

        private void Add_Job_Load(object sender, EventArgs e)
        {
            Bind_Appoinment();
            BindReceipe();
            SelectAppoin();
            if (MasterCODE.Text != "-")
            {
                Bind_Job();
            }
            Reciflag = true;
        }

        public void SelectAppoin()
        {
            if (lblAppointmentNO.Text != "" && lblAppointmentNO.Text != null)
            {
                string sqlCust = "select * from Appointment where tenentid=" + Tenent.TenentID + "  and ID =" + lblAppointmentNO.Text + "  and Deleted = 1";
                DataTable dtCust = DataAccess.GetDataTable(sqlCust);
                if (dtCust.Rows.Count > 0)
                {
                    comboAppoinment.Text = dtCust.Rows[0]["ID"] + " ~ " + dtCust.Rows[0]["customer"] + " ~ " + dtCust.Rows[0]["Title"]; ;
                    comboAppoinment.Enabled = false;
                    int C_ID = Convert.ToInt32(dtCust.Rows[0]["C_ID"]);
                    string Custoname = dtCust.Rows[0]["customer"].ToString();
                }
            }
        }


        public void Bind_Job()
        {
            string sqlCust = "select * from CRMMainActivities where tenentid=" + Tenent.TenentID + "  and MasterCODE =" + MasterCODE.Text + " and MyID = '" + lblAppointmentNO.Text + "' ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust != null)
            {
                if (dtCust.Rows.Count > 0)
                {
                    txtjobtitle.Text = dtCust.Rows[0]["ACTIVITYE"] != null ? dtCust.Rows[0]["ACTIVITYE"].ToString() : "";
                    txtremark.Text = dtCust.Rows[0]["Remarks"] != null ? dtCust.Rows[0]["Remarks"].ToString() : "";
                    int recNo = dtCust.Rows[0]["UseReciepeID"] != null ? Convert.ToInt32(dtCust.Rows[0]["UseReciepeID"]) : 0;
                    if (recNo != 0)
                    {
                        SelectReceipe(recNo);
                    }

                }
            }

        }

        public void Bind_Appoinment()
        {
            comboAppoinment.Items.Clear();

            //Appoinment Databind 
            string sqlCust = "select * from Appointment where TenentID=" + Tenent.TenentID + " and Deleted = 1 ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            string First = "";
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    string Combi = dtCust.Rows[i]["ID"] + " ~ " + dtCust.Rows[i]["customer"] + " ~ " + dtCust.Rows[i]["Title"];
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
        public void BindReceipe()
        {
            string sql = "SELECT  (Receipe_English || ' ~ ' ||recNo || ' ~ ' || Receipe_Arabic) as Receipe    FROM tbl_Receipe where TenentID = " + Tenent.TenentID + " ";

            DataAccess.ExecuteSQL(sql);
            DataTable dt = DataAccess.GetDataTable(sql);
            //comboReceipe.DataSource = dt;
            //comboReceipe.DisplayMember = "Receipe";

            comboReciepe.Items.Clear();

            comboReciepe.Items.Add("---- select Receipe ----");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboReciepe.Items.Add(dt.Rows[i][0]);
                }
            }
            comboReciepe.Text = "---- select Receipe ----";


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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtjobtitle.Text = Add_Item.voidQueryValidate(txtjobtitle.Text);
            txtremark.Text = Add_Item.voidQueryValidate(txtremark.Text);
            if (comboAppoinment.Text == "" || comboAppoinment.Text == "System.Data.DataRowView")
            {
                MessageBox.Show("Select Appointment");
                return;
            }

            if (txtjobtitle.Text == "")
            {
                txtjobtitle.Focus();
                MessageBox.Show("Fill Job Title");
                return;
            }

            if (comboReciepe.Text == "---- select Receipe ----" || comboReciepe.Text == "System.Data.DataRowView")
            {
                MessageBox.Show("Select Receipe");
                return;
            }

            int TenentID = Tenent.TenentID;
            int COMPID = 826667;
            int LocationID = 1;
            string appointmentID = comboAppoinment.Text.Split('~')[0].Trim();
            int TRID = Convert.ToInt32(appointmentID);
            int RouteID = 1;
            int USERCODE = 0;
            string ACTIVITYE = txtjobtitle.Text;
            string Username = null;
            int ModuleID = 0;
            int Activityid = 0;
            string activityname = txtjobtitle.Text;
            string CampynName = null;
            string Description = txtjobtitle.Text;
            int DocNO = 0;
            int LinkMasterCODE = 1;
            int GROUPCODE = 1;
            bool Active = true;
            string Remarks = txtremark.Text;
            string UseReciepeName = comboReciepe.Text.Split('~')[0].Trim();
            int UseReciepeID = Convert.ToInt32(comboReciepe.Text.Split('~')[1].Trim());

            if (MasterCODE.Text != "-")
            {
                int Mster = Convert.ToInt32(MasterCODE.Text);
                update_Activity(Mster, appointmentID, ACTIVITYE, Description, Remarks, UseReciepeName, UseReciepeID);
                this.Close();
            }
            else
            {
                DateTime ExpStartDate1 = DateTime.Now;
                int Flag = InserActivityMain(TenentID, COMPID, LocationID, TRID, RouteID, USERCODE, ACTIVITYE, Username, ModuleID, Activityid, activityname, CampynName, Description, DocNO, LinkMasterCODE, GROUPCODE, Active, Remarks, UseReciepeName, UseReciepeID, ExpStartDate1);
                if (Flag != 0)
                {
                    this.Close();
                }
            }
        }

        private void Add_Job_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }


        public static int getActivityCode(int TenentID)
        {
            // DB.CRMMainActivities.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.CRMMainActivities.Where(p => p.TenentID == TID).Max(p => p.MasterCODE) + 1) : 1;

            int ID12 = 1;
            string sql12 = "select * from CRMMainActivities where TenentID=" + TenentID + "  ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(MasterCODE) from CRMMainActivities where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int update_Activity(int MasterCODE, string MyID, string ACN1, string Description1, string Remarks, string UseReciepeName = "", int UseReciepeID = 0)
        {
            string ACTIVITYE = ACN1;
            string ACTIVITYA = ACN1;
            string ACTIVITYA2 = ACN1;
            string Description = Description1;

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlMain = " Update CRMMainActivities set ACTIVITYE = '" + ACTIVITYE + "', ACTIVITYA = '" + ACTIVITYA + "', ACTIVITYA2 = '" + ACTIVITYA2 + "', Remarks = '" + Remarks + "' , " +
                             " UploadDate = '" + UploadDate + "', Uploadby = '" + UserInfo.UserName + "', SynID = 2, UseReciepeName = '" + UseReciepeName + "', UseReciepeID = " + UseReciepeID + " , " +
                             " Description = '" + Description + "' where TenentID = " + Tenent.TenentID + " and MasterCODE = " + MasterCODE + " and MyID = '" + MyID + "' ";

            int flag1 = DataAccess.ExecuteSQL(sqlMain);
            Datasyncpso.insert_Live_sync(sqlMain, "CRMMainActivities", "UPDATE");

            string sqlupdate = " update CRMActivities set ACTIVITYTYPE = '" + ACN1 + "' ,REFTYPE = '" + ACN1 + "',REFSUBTYPE = '" + ACN1 + "',RouteID = '" + ACN1 + "', " +
                               " UploadDate = '" + UploadDate + "', Uploadby = '" + UserInfo.UserName + "', SynID = 2 " +
                               " where TenentID = " + Tenent.TenentID + " and MasterCODE = " + MasterCODE + " ";

            int flagupdate = DataAccess.ExecuteSQL(sqlupdate);
            Datasyncpso.insert_Live_sync(sqlupdate, "CRMActivities", "UPDATE");

            return 1;
        }


        public static int InserActivityMain(int TID = 0, int CID = 0, int LID = 0, int TRID = 0, int RID = 0, int UID = 0, string ACN1 = null, string Username = null, int MUID = 0, int Activityid = 0, string activityname = null, string CampynName = null, string Description1 = null, int DocNO = 0, int LinkMasterCODE1 = 1, int GROUPCODE = 1, bool Active1 = true, string Remarks = "", string UseReciepeName = "", int UseReciepeID = 0, DateTime? ExpStartDate1 = null)
        {
            int ActivityCode = getActivityCode(TID);
            string REFNO = ACN1 + "_" + ActivityCode + "_" + TRID;
            int TenentID = TID;
            int COMPID = CID;
            int MasterCODE = ActivityCode;
            int LinkMasterCODE = LinkMasterCODE1;
            int LocationID = LID;
            int MyID = TRID;
            int RouteID = RID;
            int USERCODE = UID;
            string ACTIVITYE = ACN1;
            string ACTIVITYA = ACN1;
            string ACTIVITYA2 = ACN1;
            string Reference = REFNO;
            bool AMIGLOBAL = true;
            bool MYPERSONNEL = true;
            int INTERVALDAYS = 3;
            bool REPEATFOREVER = false;
            DateTime REPEATTILL1 = DateTime.Now;
            string REPEATTILL = REPEATTILL1.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string REMINDERNOTE = "Your Transaction is Pading";
            int ESTCOST = 1;
            int GROUPCODE1 = GROUPCODE;
            string USERCODEENTERED = "";
            DateTime UPDTTIME1 = DateTime.Now;
            string UPDTTIME = UPDTTIME1.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string USERNAME = Username;
            int CRUP_ID = 0;
            string Version = "";
            int Type = 0;
            string MyStatus = "";
            int MainID = 0;
            int ModuleID = MUID;
            string DisplayFDName = CampynName;
            string Description = Description1;
            bool Active = Active1;

            if (UserInfo.usertype != "1")
            {
                USERNAME = UserInfo.UserName;

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = " insert into CRMMainActivities (TenentID, COMPID, MasterCODE,LinkMasterCODE, LocationID, MyID, RouteID, USERCODE, ACTIVITYE, ACTIVITYA, ACTIVITYA2, Reference, AMIGLOBAL, MYPERSONNEL, INTERVALDAYS, REPEATFOREVER, REPEATTILL, REMINDERNOTE, ESTCOST, " +
                             " GROUPCODE, USERCODEENTERED, UPDTTIME, USERNAME, Remarks, CRUP_ID, Version, Type, MyStatus, MainID, ModuleID, DisplayFDName, Description, Active,Uploadby ,UploadDate ,SynID,UseReciepeName,UseReciepeID) " +
                             " Values ( " + TenentID + " , '" + COMPID + "', '" + MasterCODE + "', '" + LinkMasterCODE + "', '" + LocationID + "', '" + MyID + "', '" + RouteID + "', '" + USERCODE + "', '" + ACTIVITYE + "', '" + ACTIVITYA + "', '" + ACTIVITYA2 + "', '" + Reference + "', " +
                             " '" + AMIGLOBAL + "', '" + MYPERSONNEL + "', '" + INTERVALDAYS + "', '" + REPEATFOREVER + "','" + REPEATTILL + "','" + REMINDERNOTE + "','" + ESTCOST + "' , " +
                             " '" + GROUPCODE + "','" + USERCODEENTERED + "','" + UPDTTIME + "','" + USERNAME + "' ,'" + Remarks + "' ,'" + CRUP_ID + "' ,'" + Version + "' ,'" + Type + "' ,'" + MyStatus + "' ,'" + MainID + "' ,'" + ModuleID + "' ,'" + DisplayFDName + "','" + Description + "', " +
                             " '" + Active + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ,'" + UseReciepeName + "'," + UseReciepeID + ") ";
                int flag1 = DataAccess.ExecuteSQL(sql);
                Datasyncpso.insert_Live_sync(sql, "CRMMainActivities", "INSERT");

                if (flag1 == 1)
                {
                    add_appintmentReceipe(TenentID, LocationID, MyID, MasterCODE, UseReciepeID, Username);

                    string GROUPCODE2 = GROUPCODE.ToString();
                    int LinkMasterCode = InsertActivity(TID, LID, CID, MasterCODE, REFNO, Username, ACN1, Activityid, activityname, DocNO, 0, "Y", GROUPCODE2,UseReciepeID , ExpStartDate1);
                    return LinkMasterCode;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = " insert into CRMMainActivities (TenentID, COMPID, MasterCODE,LinkMasterCODE, LocationID, MyID, RouteID, USERCODE, ACTIVITYE, ACTIVITYA, ACTIVITYA2, Reference, AMIGLOBAL, MYPERSONNEL, INTERVALDAYS, REPEATFOREVER, REPEATTILL, REMINDERNOTE, ESTCOST, " +
                             " GROUPCODE, USERCODEENTERED, UPDTTIME, USERNAME, Remarks, CRUP_ID, Version, Type, MyStatus, MainID, ModuleID, DisplayFDName, Description, Active,Uploadby ,UploadDate ,SynID,UseReciepeName,UseReciepeID ) " +
                             " Values ( " + TenentID + " , '" + COMPID + "', '" + MasterCODE + "', '" + LinkMasterCODE + "', '" + LocationID + "', '" + MyID + "', '" + RouteID + "', '" + USERCODE + "', '" + ACTIVITYE + "', '" + ACTIVITYA + "', '" + ACTIVITYA2 + "', '" + Reference + "', " +
                             " '" + AMIGLOBAL + "', '" + MYPERSONNEL + "', '" + INTERVALDAYS + "', '" + REPEATFOREVER + "','" + REPEATTILL + "','" + REMINDERNOTE + "','" + ESTCOST + "' , " +
                             " '" + GROUPCODE + "','" + USERCODEENTERED + "','" + UPDTTIME + "','" + USERNAME + "' ,'" + Remarks + "' ,'" + CRUP_ID + "' ,'" + Version + "' ,'" + Type + "' ,'" + MyStatus + "' ,'" + MainID + "' ,'" + ModuleID + "' ,'" + DisplayFDName + "','" + Description + "','" + Active + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ,'" + UseReciepeName + "'," + UseReciepeID + "  ) ";
                int flag1 = DataAccess.ExecuteSQL(sql);
                Datasyncpso.insert_Live_sync(sql, "CRMMainActivities", "INSERT");

                if (flag1 == 1)
                {
                    add_appintmentReceipe(TenentID, LocationID, MyID, MasterCODE, UseReciepeID, Username);
                    string GROUPCODE2 = GROUPCODE.ToString();
                    int LinkMasterCode = InsertActivity(TID, LID, CID, MasterCODE, REFNO, Username, ACN1, Activityid, activityname, DocNO, 0, "Y", GROUPCODE2, UseReciepeID, ExpStartDate1);
                    return MasterCODE;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static void add_appintmentReceipe(int TenentID, int LocationID, int AppointmentID, int JobID, int ReceipeNO,string EmpOperator)
        {
            // TenentID, AppointmentID, JobID, IOSwitch, ItemCode, UOM, Qty,  CostPrice, msrp,  UploadDate, Uploadby, SynID

            string Strselect = " select * from Receipe_Menegement where TenentID = " + Tenent.TenentID + " and recNo = " + ReceipeNO + " ";

            DataTable dt = DataAccess.GetDataTable(Strselect);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string IOSwitch = dt.Rows[i]["IOSwitch"].ToString();
                    double ItemCode = Convert.ToDouble(dt.Rows[i]["ItemCode"]);
                    string ItemName = getItemName(ItemCode);
                    string TypeofProduct = getTypeOfProcuct(ItemCode);//Commission Yogesh
                    int UOM = Convert.ToInt32(dt.Rows[i]["UOM"]);
                    double Qty = Convert.ToDouble(dt.Rows[i]["Qty"]);
                    double CostPrice = Convert.ToDouble(dt.Rows[i]["CostPrice"]);
                    double msrp = Convert.ToDouble(dt.Rows[i]["msrp"]);
                    double QtyIntoCostprice = Qty * CostPrice;
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string Uploadby = UserInfo.UserName;

                    string sql1 = " insert into AppointmentReceipe (TenentID, LocationID, AppointmentID, JobID, IOSwitch, ItemCode, UOM, Qty,  CostPrice, msrp, recNo, UploadDate, Uploadby, SynID, product_name, RecipeType, EmpOperator,QtyIntoCostprice) " +
                                  " values (" + TenentID + ",'" + LocationID + "', '" + AppointmentID + "','" + JobID + "','" + IOSwitch + "' , '" + ItemCode + "', " +
                                  " '" + UOM + "','" + Qty + "','" + CostPrice + "','" + msrp + "','" + ReceipeNO + "', '" + UploadDate + "','" + Uploadby + "', 1 ,'" + ItemName + "','" + TypeofProduct + "', '" + EmpOperator + "', '" + QtyIntoCostprice + "') ";
                    int flag1 = DataAccess.ExecuteSQL(sql1);
                    Datasyncpso.insert_Live_sync(sql1, "AppointmentReceipe", "INSERT");
                }
            }
        }
       
        public static string getItemName(double ItemCode)//Yogesh
        {
            string ItemNAME1 = "";
            string sql12 = " select * from purchase where TenentID = " + Tenent.TenentID + " and product_id = '" + ItemCode + "'  ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                ItemNAME1 = dt1.Rows[0]["product_name"].ToString();
            }
            return ItemNAME1;
        }
        public static string getTypeOfProcuct(double ItemCode)//Yogesh
        {
            string RecipeType1 = "";
            string sql12 = " select * from tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID = '" + ItemCode + "'  ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                RecipeType1 = dt1.Rows[0]["RecipeType"].ToString();
            }
            return RecipeType1;
        }
        public static void DeActive(int TID, int CID, int MCID)
        {
            string sqlselect = "select * from CRMActivities where TenentID = " + TID + " and COMPID = " + CID + " and MasterCODE = " + MCID + " and Active = 'Y' ";
            DataTable dt1 = DataAccess.GetDataTable(sqlselect);

            int Count = dt1.Rows.Count;
            if (Count > 0)
            {
                int TenentID = Convert.ToInt32(dt1.Rows[0]["TenentID"]);
                int COMPID = Convert.ToInt32(dt1.Rows[0]["COMPID"]);
                int MasterCODE = Convert.ToInt32(dt1.Rows[0]["MasterCODE"]);

                string sqlupdate = " update CRMActivities set Active = 'N' where TenentID = " + TID + " and COMPID = " + CID + " and MasterCODE = " + MCID + " and  Active = 'Y'";
                int flag1 = DataAccess.ExecuteSQL(sqlupdate);
                Datasyncpso.insert_Live_sync(sqlupdate, "CRMActivities", "UPDATE");
            }

            //var List = DB.CRMActivities.Where(p => p.TenentID == TID && p.COMPID == CID && p.MasterCODE == MCID && p.Active == "Y").ToList();
            //for (int i = 0; i < List.Count(); i++)
            //{
            //    int TenentID = Convert.ToInt32(List[i].TenentID);
            //    int COMPID = Convert.ToInt32(List[i].COMPID);
            //    int MasterCODE = Convert.ToInt32(List[i].MasterCODE);
            //    CRMActivity objCRMActivity = DB.CRMActivities.Single(p => p.TenentID == TID && p.COMPID == CID && p.MasterCODE == MCID && p.Active == "Y");
            //    objCRMActivity.Active = "N";
            //    DB.SaveChanges();
            //}
        }

        public static int getLinkMasterCODE(int TenentID)
        {
            // DB.CRMActivities.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Where(p => p.TenentID == TID).Max(p => p.LinkMasterCODE) + 1) : 1;

            int ID12 = 1;
            string sql12 = "select * from CRMActivities where TenentID=" + TenentID + "  ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(LinkMasterCODE) from CRMActivities where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getMyLineNo(int TenentID)
        {
            //DB.CRMActivities.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Where(p => p.TenentID == TID).Max(p => p.MyLineNo) + 1) : 1;
            int ID12 = 1;
            string sql12 = "select * from CRMActivities where TenentID=" + TenentID + "  ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(MyLineNo) from CRMActivities where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int InsertActivity(int TenentID = 0, int LocationID = 0, int COMPID = 0, int MasterCODE = 0, string PerfReferenceNo = null, string USERNAME = null, string RouteID = null, int Activityid = 0, string activityname = null, int DocID = 0, int Type = 0, string Active = "Y", string GROUPCODE1 = "", int UseReciepeID = 0, DateTime? ExpStartDate1 = null)
        {
            DeActive(TenentID, COMPID, MasterCODE);

            int MyLineNo = getMyLineNo(TenentID);
            int LinkMasterCODE = getLinkMasterCODE(TenentID);
            int MenuID = 0;
            int ActivityID = Activityid;
            string ACTIVITYTYPE = activityname;
            string REFTYPE = activityname;
            string REFSUBTYPE = activityname;
            string EarlierRefNo = PerfReferenceNo;
            string NextUser = "";
            string NextRefNo = "";
            string AMIGLOBAL = "";
            string MYPERSONNEL = "";
            string ActivityPerform = "";
            string REMINDERNOTE = "";
            int ESTCOST = Activityid + 1;
            string GROUPCODE = GROUPCODE1;
            string USERCODEENTERED = "";
            DateTime UPDTTIME1 = DateTime.Now;
            string UPDTTIME = UPDTTIME1.ToString("yyyy-MM-dd HH:mm:ss.fff");

            int CRUP_ID = 0;
            string Version = "";
            string MyStatus = "";
            string GroupBy = "";
            int ToColumn = 0;
            int FromColumn = 0;
            int MainSubRefNo = 0;
            string UrlRedirct = "";

            DateTime StartDate = ExpStartDate1 != null ? Convert.ToDateTime(ExpStartDate1) : DateTime.Now;
            string ExpStartDate = StartDate.ToString("yyyy-MM-dd HH:mm:ss");

            int minuteTo = ReceipeMenegement.getTotalMinuteForReceipe(UseReciepeID);
            DateTime EndDt = StartDate.AddMinutes(minuteTo); //Convert.ToDateTime(Edate);
            string ExpEndDate = EndDt.ToString("yyyy-MM-dd HH:mm:ss");

            //TenentID,LocationID,COMPID,MasterCODE,LinkMasterCODE,MenuID,ActivityID,ACTIVITYTYPE,REFTYPE,REFSUBTYPE,PerfReferenceNo,EarlierRefNo,NextUser,NextRefNo,
            //AMIGLOBAL,MYPERSONNEL,ActivityPerform,REMINDERNOTE,ESTCOST,GROUPCODE,USERCODEENTERED,UPDTTIME,USERNAME,CRUP_ID,InitialDate,DeadLineDate,RouteID,Version,Type,MyStatus,GroupBy,DocID,ToColumn,FromColumn,Active,MainSubRefNo,UrlRedirct

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlinsert = " insert into CRMActivities (TenentID,LocationID,COMPID,MasterCODE,MyLineNo,LinkMasterCODE,MenuID,ActivityID,ACTIVITYTYPE,REFTYPE,REFSUBTYPE,PerfReferenceNo, " +
                               " EarlierRefNo,NextUser,NextRefNo,AMIGLOBAL,MYPERSONNEL,ActivityPerform,REMINDERNOTE,ESTCOST,GROUPCODE,USERCODEENTERED,UPDTTIME,USERNAME,CRUP_ID, " +
                               " RouteID,Version,Type,MyStatus,GroupBy,DocID,ToColumn,FromColumn,Active,MainSubRefNo,UrlRedirct,Uploadby ,UploadDate ,SynID,ExpStartDate,ExpEndDate ) " +
                               " Values ( " + TenentID + "," + LocationID + "," + COMPID + "," + MasterCODE + "," + MyLineNo + "," + LinkMasterCODE + "," + MenuID + "," + ActivityID + ",'" + ACTIVITYTYPE + "', " +
                               " '" + REFTYPE + "','" + REFSUBTYPE + "','" + PerfReferenceNo + "', '" + EarlierRefNo + "','" + NextUser + "','" + NextRefNo + "','" + AMIGLOBAL + "', " +
                               " '" + MYPERSONNEL + "','" + ActivityPerform + "','" + REMINDERNOTE + "','" + ESTCOST + "','" + GROUPCODE + "','" + USERCODEENTERED + "','" + UPDTTIME + "','" + USERNAME + "', " +
                               " '" + CRUP_ID + "', '" + RouteID + "','" + Version + "','" + Type + "','" + MyStatus + "','" + GroupBy + "','" + DocID + "','" + ToColumn + "', " +
                               " '" + FromColumn + "','" + Active + "','" + MainSubRefNo + "','" + UrlRedirct + "' ,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 , '" + ExpStartDate + "','" + ExpEndDate + "' )  ";

            int flag1 = DataAccess.ExecuteSQL(sqlinsert);
            Datasyncpso.insert_Live_sync(sqlinsert, "CRMActivities", "INSERT");
            //DB.CRMActivities.AddObject(obj);
            //DB.SaveChanges();

            if (flag1 == 1)
            {
                int MMID = Convert.ToInt32(LinkMasterCODE);
                return MMID;
            }
            else
            {
                return 0;
            }


        }

        private void comboReciepe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Reciflag == true)
            {
                if (comboReciepe.Text != "---- select Receipe ----" && comboReciepe.Text != "System.Data.DataRowView")
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
                            " where purchase.TenentID = " + Tenent.TenentID + " and product_id = Receipe_Menegement.ItemCode and Receipe_Menegement.recNo = " + recNo + "  "; //and Receipe_Menegement.IOSwitch = 'Output'
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

        private void txtjobtitle_Enter(object sender, EventArgs e)
        {
            if (comboReciepe.Text != "-- select Receipe / Package --" && comboReciepe.Text != "System.Data.DataRowView")
            {
                //ReciepeNAme_CustomerName_DDMMYY_05:24
                string Reciepename = comboReciepe.Text.Split('~')[0].Trim();
                txtjobtitle.Text = Reciepename;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["AppointServiceTemplateSearch"] != null)
            {
                Application.OpenForms["AppointServiceTemplateSearch"].Close();
            }
            this.Refresh();

            AppointServiceTemplateSearch go = new AppointServiceTemplateSearch();
            go.PageName = "Add_Job";
            go.Show();
        }

    }
}
