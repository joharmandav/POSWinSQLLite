using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop.Report
{
    public partial class OpeningBalance : Form
    {
        public OpeningBalance()
        {
            InitializeComponent();
        }

        private void DayClose_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ClosePriShift();
            BindShift();
            setshift();

            ShiftOpenStatus();
            LastShiftData();
            OPTBalance();
            //lblMSG.Text = "-";

            if (lblAmount.Text != "-")
            {
                txtOpeningBalance.Text = lblAmount.Text;
            }

        }

        public void ClosePriShift()
        {
            //select * from DayClose where ShiftStutas=0 order by ID desc limit 1
            string DateNow = txtDate.Text;
            string Condition = "where TenentID=" + Tenent.TenentID + " and Date != '" + DateNow + "' and ShiftStutas = 0 order by ID desc limit 1 ";

            string sql5 = "Select * from DayClose " + Condition;
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                decimal todayCash = 0;
                string Userid = "";
                string Shopid = "";
                string ShiftID = "";
                string Date = "";

                string sql = "select ((OpAMT + ShiftSales) - (ShiftReturn + VoucharAMT + ExpAMT + ChequeAMT + AMTDelivered + Shiftpurchase  )) as TodayCash,OpAMT,ShiftSales,ChequeAMT,VoucharAMT, " +
                             " ExpAMT,ShiftReturn,Shiftpurchase,RefNO,AMTDelivered,undeliverdAMT,DeliveredTO,UserID,TrmID,ShiftID,Date  from DayClose " + Condition;
                DataTable dt6 = DataAccess.GetDataTable(sql);
                if (dt6.Rows.Count > 0)
                {
                    todayCash = Convert.ToDecimal(dt6.Rows[0]["TodayCash"]);
                    Userid = dt6.Rows[0]["UserID"].ToString();
                    Shopid = dt6.Rows[0]["TrmID"].ToString();
                    ShiftID = dt6.Rows[0]["ShiftID"].ToString();
                    Date = dt6.Rows[0]["Date"].ToString();
                }

                decimal TodayShiftCash = todayCash;
                decimal AMTDelivered = todayCash;

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlupdate = " update DayClose set ShiftCIH=" + TodayShiftCash + " , undeliverdAMT=" + AMTDelivered + ",Employee=" + UserInfo.Userid + ",ShiftStutas=1, " +
                             " Uploadby= '" + UserInfo.UserName + "' , UploadDate = '" + UploadDate + "' , SynID = 2 " +
                             " where TenentID=" + Tenent.TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = '" + ShiftID + "' and Date = '" + Date + "' ";
                DataAccess.ExecuteSQL(sqlupdate);
                Datasyncpso.insert_Live_sync(sqlupdate, "DayClose", "UPDATE");
            }
        }

        public void ShiftOpenStatus()
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and Date = '" + Date + "' and ShiftStutas = 0 ";

            string sql5 = "Select * from DayClose " + Condition;
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                ComboShift.SelectedValue = dt5.Rows[0]["ShiftID"].ToString();
                MessageBox.Show("Shift Already Open");
            }

        }

        public void BindShift()
        {
            ComboShift.DataSource = null;
            ComboShift.Items.Clear();

            if (UserInfo.Language == "English")
            {
                string sql5 = "Select ID,Shift_Name from tbl_Shift";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                ComboShift.DataSource = dt5;
                ComboShift.DisplayMember = "Shift_Name";
                ComboShift.ValueMember = "ID";
            }
            else if (UserInfo.Language == "Arabic")
            {
                string sql5 = "Select ID,Fhift_Arabic from tbl_Shift";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                ComboShift.DataSource = dt5;
                ComboShift.DisplayMember = "Fhift_Arabic";
                ComboShift.ValueMember = "ID";
            }
            else
            {
                string sql5 = "Select ID,Shift_Name from tbl_Shift";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                ComboShift.DataSource = dt5;
                ComboShift.DisplayMember = "Shift_Name";
                ComboShift.ValueMember = "ID";
            }

        }

        public void setshift()
        {
            if (DateTime.Now.Hour < 12)
            {
                ComboShift.SelectedValue = 1;
            }
            else if (DateTime.Now.Hour < 16)
            {
                ComboShift.SelectedValue = 2;
            }
            else if (DateTime.Now.Hour < 20)
            {
                ComboShift.SelectedValue = 3;
            }
            else
            {
                ComboShift.SelectedValue = 4;
            }
        }


        public int getShiftID()
        {
            int ID = 0;
            string Shifname = ComboShift.Text;

            string sql5 = "";
            if (UserInfo.Language == "English")
            {
                sql5 = "Select * from tbl_Shift where Shift_Name = '" + Shifname + "' ";
            }
            else if (UserInfo.Language == "Arabic")
            {
                sql5 = "Select * from tbl_Shift where Fhift_Arabic = '" + Shifname + "' ";
            }
            else
            {
                sql5 = "Select * from tbl_Shift where Shift_Name = '" + Shifname + "' ";
            }

            DataTable dt5 = DataAccess.GetDataTable(sql5);

            if (dt5.Rows.Count > 0)
            {
                ID = Convert.ToInt32(dt5.Rows[0]["ID"]);
            }

            return ID;
        }

        public void LastShiftData()
        {
            string sql5 = "Select * from DayClose where TenentID=" + Tenent.TenentID + " and TrmID = '" + UserInfo.Shopid + "' ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                string SQl = "SELECT * FROM DayClose where TenentID=" + Tenent.TenentID + " and TrmID = '" + UserInfo.Shopid + "' ORDER BY ID DESC LIMIT 1";
                DataTable dt = DataAccess.GetDataTable(SQl);
                if (dt.Rows.Count > 0)
                {
                    txtOpeningBalance.Text = dt.Rows[0]["undeliverdAMT"].ToString();
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TenentID,UserID,TrmID,ShiftID,Date,OpAMT,ShiftSales,ShiftReturn,ShiftCIH,VoucharAMT,ExpAMT,ChequeAMT,AMTDelivered,DeliveredTO,RefNO,Notes,UploadDate,
            //Uploadby,	SyncDate,Syncby,SynID

            if (txtOpeningBalance.Text == "")
            {
                MessageBox.Show("Please Enter Opening Balance");
                return;
            }

            if (ComboShift.Text != "")
            {
                int ValidShif = getShiftID();

                if (ValidShif == 0)
                {
                    MessageBox.Show("Please Select Valid Shift");
                    return;
                }

                int TID = Tenent.TenentID;
                string Date = txtDate.Text;
                int ShiftID = Convert.ToInt32(ComboShift.SelectedValue);
                UserInfo.ShiftID = ShiftID;
                decimal OpAMT = Convert.ToDecimal(txtOpeningBalance.Text);
                //TID / TEmrid / ddmmyyyy / ShiftID / UserName 
                string date = DateTime.Now.ToString("ddMMMyyyy");
                string refNO = TID + "/" + UserInfo.Shopid + "/" + date + "/" + ShiftID + "/" + UserInfo.UserName;

                string sql5 = "Select * from DayClose where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                if (dt5.Rows.Count < 1)
                {
                    int ID = DataAccess.getDayCloseMYid(Tenent.TenentID);

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql1 = " insert into DayClose (TenentID,ID,UserID,TrmID,ShiftID,Date,OpAMT,RefNO,Uploadby,UploadDate,SynID) " +
                                  " values (" + Tenent.TenentID + "," + ID + ",'" + UserInfo.Userid + "','" + UserInfo.Shopid + "'," + ShiftID + ", " +
                                  " '" + Date + "','" + OpAMT + "','" + refNO + "', " +
                                  " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                    int flag1 = DataAccess.ExecuteSQL(sql1);

                    Datasyncpso.insert_Live_sync(sql1, "DayClose", "INSERT");

                    lblMSG.Text = "save Successfull";
                    this.Close();
                   // logoutsys();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Opening Balance already found For " + Date + " ,terminal is " + UserInfo.Shopid + "  and Shift  " + ComboShift.Text + " You Want To Update? ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql = " update DayClose set " +
                                     " OpAMT = '" + OpAMT + "',RefNO = '" + refNO + "', " +
                                     " Uploadby= '" + UserInfo.UserName + "' , UploadDate = '" + UploadDate + "' , SynID = 2 " +
                                     " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
                        DataAccess.ExecuteSQL(sql);
                        Datasyncpso.insert_Live_sync(sql, "DayClose", "UPDATE");

                        lblMSG.Text = "Update Successfull";
                        this.Close();
                       // logoutsys();
                    }
                }

            }
            else
            {
                MessageBox.Show("Please Select Valid Shift");
                return;
            }
        }
        public void logoutsys()
        {
            workRecords();

            string ActivityName = "Log Out";
            string LogData = "User " + UserInfo.UserName + " Log out ";
            Login.InsertUserLog(ActivityName, LogData);

            string openFrm = "";

            foreach (Form Item in Application.OpenForms)
            {
                openFrm = openFrm + "," + Item.Name;
            }

            openFrm = openFrm.TrimStart(',');
            openFrm = openFrm.TrimEnd(',');

            string[] frm = openFrm.ToString().Trim().Split(',');

            for (int i = 0; i < frm.Length; i++)
            {
                string FormName = frm[i].ToString();

                if ( FormName != "Login")
                {
                    if (Application.OpenForms[FormName] != null)
                    {
                        Application.OpenForms[FormName].Close();
                    }
                }
            }

            Login go = new Login();
            go.Show();
            this.Close();
        }


        public void workRecords()
        {
            string logdate = DateTime.Now.ToString("yyyy-MM-dd");
            string logtime = DateTime.Now.ToString("HH:mm:ss");
            string logdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            int ID = DataAccess.getworkrecordsMYid(Tenent.TenentID);

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlLogIn = " insert into tbl_workrecords (TenentID,ID, Username, datatype, logdate, logtime, logdatetime,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + "," + ID + ",'" + UserInfo.UserName + "' , 'OUT' , '" + logdate + "' , " +
                                  " '" + logtime + "' , '" + logdatetime + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
            int flag = DataAccess.ExecuteSQL(sqlLogIn);

            string sqlLogWin = " insert into Win_tbl_workrecords (TenentID,ID, Username, datatype, logdate, logtime, logdatetime,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + "," + ID + ",'" + UserInfo.UserName + "' , 'OUT' , '" + logdate + "' , " +
                                  " '" + logtime + "' , '" + logdatetime + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
            Datasyncpso.insert_Live_sync(sqlLogWin, "Win_tbl_workrecords", "INSERT");
        }
        private void txtOpeningBalance_LostFocus(object sender, EventArgs e)
        {
            OPTBalance();
        }

        public void OPTBalance()
        {
            if (txtOpeningBalance.Text != "" && txtOpeningBalance.Text != "0")
            {
                lblAmount.Text = txtOpeningBalance.Text;
            }
            else
            {
                string Date = txtDate.Text;
                int ShiftID = Convert.ToInt32(ComboShift.SelectedValue);
                string sql5 = "Select * from DayClose where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftStutas = 0 and Date = '" + Date + "' ";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);

                if (dt5.Rows.Count > 0)
                {
                    lblAmount.Text = dt5.Rows[0]["OpAMT"].ToString();
                }
                else
                {
                    lblAmount.Text = "0";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
