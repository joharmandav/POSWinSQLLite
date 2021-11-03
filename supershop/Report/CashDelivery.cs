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
    public partial class CashDelivery : Form
    {
        public CashDelivery()
        {
            InitializeComponent();
        }

        private void CashDelivery_Load(object sender, EventArgs e)
        {
            Check_Validation();
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblTodayShiftCash.Text = getTodaycash().ToString();
            BindEmployee();
        }

        public static void Check_Validation()
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and Date = '" + Date + "' and ShiftStutas = 0 ";

            string sql5 = "Select * from DayClose " + Condition;
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                string sql123 = " select MAX(ShiftID) from DayClose " + Condition;
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int shift = Convert.ToInt32(dt12.Rows[0][0]);
                    UserInfo.ShiftID = shift;
                }
                else
                {
                    MessageBox.Show("Please Enter Opening Balance First");
                    OpeningBalance go = new OpeningBalance();
                    go.Show();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Opening Balance First");
                OpeningBalance go = new OpeningBalance();
                go.Show();
                return;
            }
        }

        public decimal getTodaycash()
        {
            decimal todayCash = 0;
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and Date = '" + Date + "' and ShiftStutas = 0 ";

            string sql = "select ((OpAMT + ShiftSales) - (ShiftReturn + VoucharAMT + ExpAMT + ChequeAMT + AMTDelivered)) as TodayCash from DayClose " + Condition;
            DataTable dt5 = DataAccess.GetDataTable(sql);
            if (dt5.Rows.Count > 0)
            {
                todayCash = Convert.ToDecimal(dt5.Rows[0][0]);
            }
            return todayCash;
        }



        public decimal getAMTDelivered()
        {
            decimal AMTDelivered = 0;
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and Date = '" + Date + "' and ShiftStutas = 0 ";

            string sql = "select  AMTDelivered from DayClose " + Condition;
            DataTable dt5 = DataAccess.GetDataTable(sql);
            if (dt5.Rows.Count > 0)
            {
                AMTDelivered = Convert.ToDecimal(dt5.Rows[0][0]);
            }
            return AMTDelivered;
        }

        public void BindEmployee()
        {
            comboDelivered.DataSource = null;
            comboDelivered.Items.Clear();

            // id,Name

            string sql5 = "Select id,Name from usermgt Where TenentID = " + Tenent.TenentID + " ";
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);

            comboDelivered.ValueMember = "id";
            comboDelivered.DisplayMember = "Name";
            comboDelivered.DataSource = dt5;

        }
        public int getEMPID()
        {
            int id = 0;
            string empname = comboDelivered.Text;

            string sql5 = "";
            sql5 = "Select * from usermgt where Name = '" + empname + "' and TenentID = " + Tenent.TenentID + " ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);

            if (dt5.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt5.Rows[0]["id"]);
            }
            return id;
        }
        public string GetEmpName(int id)
        {
            string empname = "";
            string sql5 = "";
            sql5 = "Select * from usermgt where id = " + id + " and TenentID = " + Tenent.TenentID + " ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);

            if (dt5.Rows.Count > 0)
            {
                empname = dt5.Rows[0]["Name"].ToString();
            }
            return empname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCash.Text == "")
            {
                MessageBox.Show("Please Enter Delivered Amount");
                return;
            }

            if (comboDelivered.Text != "")
            {
                int empid = getEMPID();
                if (empid != 0)
                {
                    insert_CashDelivery();
                    Update_daycloseData();

                    lblMSG.Text = "save Successfull";
                    lblTodayShiftCash.Text = getTodaycash().ToString();
                }
            }
            else
            {
                MessageBox.Show("Please select Employee");
                return;
            }

        }

        public void Update_daycloseData()
        {
            decimal TodayShiftCash = Convert.ToDecimal(lblTodayShiftCash.Text);
            string Date = lblDate.Text;
            int DeliveredTO = Convert.ToInt32(comboDelivered.SelectedValue);
            int ShiftID = UserInfo.ShiftID;
            decimal AMTDelivered = Convert.ToDecimal(txtCash.Text);
            decimal amtDeliverdold = getAMTDelivered();
            decimal Total = AMTDelivered + amtDeliverdold;

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = " update DayClose set AMTDelivered=" + Total + " , DeliveredTO=" + DeliveredTO + "," +
                         " Uploadby= '" + UserInfo.UserName + "' , UploadDate = '" + UploadDate + "' , SynID = 2 " +
                         " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataAccess.ExecuteSQL(sql);

            Datasyncpso.insert_Live_sync(sql, "DayClose", "UPDATE");

        }

        public void insert_CashDelivery()
        {
            //TenentID,UserID,TrmID,ShiftID,Date,AMTDelivered ,DeliveredTO,RefNO,Notes,UploadDate	,Uploadby,SyncDate,	Syncby,	SynID
            string Date = lblDate.Text;
            int ShiftID = UserInfo.ShiftID;
            int DeliveredTO = Convert.ToInt32(comboDelivered.SelectedValue);
            decimal AMTDelivered = Convert.ToDecimal(txtCash.Text);
            string refNO = getreffrence();

            int ID = DataAccess.getCashDeliveryMYid(Tenent.TenentID, UserInfo.Userid, UserInfo.Shopid);

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = " insert into CashDelivery (TenentID,ID,UserID,TrmID,ShiftID,Date,AMTDelivered ,DeliveredTO,RefNO,Uploadby,UploadDate,SynID) " +
                                  " values (" + Tenent.TenentID + ",'" + ID + "','" + UserInfo.Userid + "','" + UserInfo.Shopid + "'," + ShiftID + ", " +
                                  " '" + Date + "','" + AMTDelivered + "'," + DeliveredTO + ",'" + refNO + "', " +
                                  " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
            DataAccess.ExecuteSQL(sql);
            Datasyncpso.insert_Live_sync(sql, "CashDelivery", "INSERT");

            string UserName = GetUserName(DeliveredTO);
            string ActivityName = "Cash Delivery";
            string LogData = "Cash Delivery " + AMTDelivered + " to " + UserName + " ";
            Login.InsertUserLog(ActivityName, LogData);
        }

        public string GetUserName(int ID)
        {
            string UserName = "";
            string sql = "select * from usermgt where TenentID = " + Tenent.TenentID + " and id= " + ID + " ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                UserName = dt.Rows[0]["Username"].ToString();
            }

            return UserName;
        }

        public string getreffrence()
        {
            string refNO = "";
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and Date = '" + Date + "' and ShiftStutas = 0 ";

            string sql = "select RefNO from DayClose " + Condition;
            DataTable dt5 = DataAccess.GetDataTable(sql);
            if (dt5.Rows.Count > 0)
            {
                refNO = dt5.Rows[0][0].ToString();
            }
            return refNO;
        }


    }
}
