using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Items
{
    public partial class Add_Receipe : Form
    {
        InputLanguage arabic;
        InputLanguage english;
        InputLanguage French;
        public Add_Receipe()
        {
            InitializeComponent();
            arabic = InputLanguage.CurrentInputLanguage;
            english = InputLanguage.CurrentInputLanguage;
            French = InputLanguage.CurrentInputLanguage;
            int count = InputLanguage.InstalledInputLanguages.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("Arabic"))
                {
                    arabic = InputLanguage.InstalledInputLanguages[i];
                }
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("US"))
                {
                    english = InputLanguage.InstalledInputLanguages[i];
                }
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("French"))
                {
                    French = InputLanguage.InstalledInputLanguages[i];
                }

            }

            dtstTime.Format = DateTimePickerFormat.Custom;
            dtstTime.CustomFormat = "HH:mm";
            dtstTime.ShowUpDown = true;
            dtstTime.Text = "00:00";


        }

        private void txtReceipeArabic_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = arabic;
        }

        private void txtReceipeArabic_LostFocus(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public string recNo
        {
            set { lblID.Text = value; }
            get { return lblID.Text; }
        }
        public string Receipe_English
        {
            set { txtReceipeName.Text = value; btnSave.Text = "Update"; }
            get { return txtReceipeName.Text; }
        }

        public string Receipe_Arabic
        {
            set { txtReceipeArabic.Text = value; }
            get { return txtReceipeArabic.Text; }
        }
        public string DaysinExpire
        {
            set { txtDaysinExpire.Text = value; }
            get { return txtDaysinExpire.Text; }
        }

        private void Add_Receipe_Load(object sender, EventArgs e)
        {
            if (lblID.Text != "-")
            {
                int recNo = Convert.ToInt32(lblID.Text);
                getReciepeData(recNo);
            }
        }

        public void getReciepeData(int recNo)
        {
            string sql = " select * from tbl_Receipe where TenentID=" + Tenent.TenentID + " and recNo = " + recNo + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql);
            if (dt1 != null)
            {
                if (dt1.Rows.Count > 0)
                {
                    cmbRecType.Text = dt1.Rows[0]["RecType"].ToString();
                    int Time = ReceipeMenegement.getTotalMinuteForReceipe(recNo);

                    int totalMinute = Time;
                    int Minute = 0;
                    int Hour = 0;

                    totalMinute = totalMinute % 1440;
                    Hour = totalMinute / 60;
                    Minute = totalMinute % 60;

                    dtstTime.Text = FormatTwoDigits(Hour) + ":" + FormatTwoDigits(Minute) + "";
                }
            }
        }
        private string FormatTwoDigits(Int32 i)
        {
            string functionReturnValue = null;
            if (10 > i)
            {
                functionReturnValue = "0" + i.ToString();
            }
            else
            {
                functionReturnValue = i.ToString();
            }
            return functionReturnValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtReceipeName.Text = Add_Item.voidQueryValidate(txtReceipeName.Text);
                txtReceipeArabic.Text = Add_Item.voidQueryValidate(txtReceipeArabic.Text);

                if (txtReceipeName.Text == "")
                {
                    MessageBox.Show("Please Fill Receipe Name");
                    txtReceipeName.Focus();
                }
                else if (txtReceipeArabic.Text == "")
                {
                    MessageBox.Show("Please Fill Receipe Name in Arabic");
                    txtReceipeArabic.Focus();
                }
                else if (txtDaysinExpire.Text == "")
                {
                    MessageBox.Show("Please Fill Days in Expire");
                    txtReceipeArabic.Focus();
                }
                else
                {
                    string Time = dtstTime.Text != "" ? dtstTime.Text : "00:00";

                    string[] Splitt = Time.Split(':');

                    int Temphourminute = Convert.ToInt32(Splitt[0]) * 60;

                    int Tempmin = Convert.ToInt32(Splitt[1]);

                    int Minute = Temphourminute + Tempmin;

                    //HourToComplate
                    if (lblID.Text == "-")
                    {
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); //2018-02-05 12:07:36.390  string.Format("0:yyyy-MM-dd HH:mm:ss.fff", DateTime.Now)

                        int recNo = DataAccess.getReceipeid(Tenent.TenentID);

                        // TenentID,recNo,Receipe_English,Receipe_Arabic,UploadDate,Uploadby,SyncDate,Syncby,SynID

                        string sqlCmd = " insert into tbl_Receipe (TenentID,recNo,Receipe_English,Receipe_Arabic,ExpireDays,RecType,HourToComplate,Uploadby,UploadDate,SynID)  " +
                                        " values (" + Tenent.TenentID + "," + recNo + " , '" + txtReceipeName.Text + "', '" + txtReceipeArabic.Text + "','" + txtDaysinExpire.Text + "', '" + cmbRecType.Text + "' ,'" + Minute + "' , " +
                                        " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                        int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                        string sqlCmdWin = " insert into tbl_Receipe (TenentID,recNo,Receipe_English,Receipe_Arabic,ExpireDays,RecType,HourToComplate,Uploadby,UploadDate,SynID) " +
                                               " values (" + Tenent.TenentID + "," + recNo + " , N'" + txtReceipeName.Text + "', N'" + txtReceipeArabic.Text + "', '" + txtDaysinExpire.Text + "', '" + cmbRecType.Text + "' ,'" + Minute + "' , " +
                                               " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                        Datasyncpso.insert_Live_sync(sqlCmdWin, "tbl_Receipe", "INSERT");

                        string ActivityName = "Add Receipe";
                        string LogData = "Add Receipe With Receipe Name = " + txtReceipeName.Text + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        txtReceipeName.Text = "";
                        txtReceipeArabic.Text = "";
                        lblMsg.Visible = true;
                        lblMsg.Text = "Successfully saved";
                        this.Close();

                    }
                    else  //Update 
                    {

                        // TenentID,recNo,Receipe_English,Receipe_Arabic,UploadDate,Uploadby,SyncDate,Syncby,SynID

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sqlUpdateCmd = " update tbl_Receipe set Receipe_English = '" + txtReceipeName.Text + "' , Receipe_Arabic = '" + txtReceipeArabic.Text + "', " +
                                             " ExpireDays = '" + txtDaysinExpire.Text + "', RecType = '" + cmbRecType.Text + "' , HourToComplate = '" + Minute + "' , " +
                                             " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                             " where recNo = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        DataAccess.ExecuteSQL(sqlUpdateCmd);

                        string sqlUpdateCmdWIN = " update tbl_Receipe set Receipe_English = N'" + txtReceipeName.Text + "' , Receipe_Arabic = N'" + txtReceipeArabic.Text + "', " +
                                              " ExpireDays = '" + txtDaysinExpire.Text + "', RecType = '" + cmbRecType.Text + "' , HourToComplate = '" + Minute + "' , " +
                                              " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                              " where recNo = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "tbl_Receipe", "UPDATE");

                        string ActivityName = "Update Receipe";
                        string LogData = "Update Receipe With Receipe NAME = " + txtReceipeName.Text + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        this.Close();
                    }
                }


            }
            catch (Exception exp)
            {
                MessageBox.Show("Sorry\r\n this id already added \n\n " + exp.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtReceipeName_Leave(object sender, EventArgs e)
        {
            bool Internat = Login.InternetConnection();
            if (Internat == true)
            {
                txtReceipeArabic.Text = DataAccess.Translate(txtReceipeName.Text, "ar");
            }
            else
            {
                txtReceipeArabic.Text = txtReceipeName.Text;
            }
        }

    }
}
