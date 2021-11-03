using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop
{
    public partial class Add_UOM : Form
    {
        InputLanguage arabic;
        InputLanguage english;
        InputLanguage French;
        public Add_UOM()
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
        }

        private void Add_UOM_Load(object sender, EventArgs e)
        {
            if (lblID.Text != "-")
            {
                string sql = " select * from ICUOM where TenentID=" + Tenent.TenentID + " and UOM = '" + lblID.Text + "' ";
                DataTable dt1 = DataAccess.GetDataTable(sql);
                if (dt1 != null)
                {
                    txtUOMName.Text = dt1.Rows[0]["UOMNAME1"].ToString();
                    txtUOMArabic.Text = dt1.Rows[0]["UOMNAME2"].ToString();
                    chkAddMultiUOMAllow.Checked = dt1.Rows[0]["MultiUOMAllow"].ToString() == "1" ? true : false;
                    chkCalculateAspectRatio.Checked = dt1.Rows[0]["CalculateAspectRatio"].ToString() == "1" ? true : false;
                }

                if (chkAddMultiUOMAllow.Checked == true)
                {
                    string sqlselect = "select * from  purchase where TenentID=" + Tenent.TenentID + " and BaseUOM = '" + UOMID + "' ";
                    DataTable dtselect = DataAccess.GetDataTable(sqlselect);

                    if (dtselect.Rows.Count > 0)
                    {
                        chkAddMultiUOMAllow.Enabled = false;
                        chkCalculateAspectRatio.Enabled = false;
                    }
                    else
                    {
                        chkAddMultiUOMAllow.Enabled = true;
                        chkCalculateAspectRatio.Enabled = true;
                    }
                }
            }
        }
        public string UOMID
        {
            set { lblID.Text = value; }
            get { return lblID.Text; }
        }

        private void txtUOMArabic_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = arabic;
        }
        private void txtUOMArabic_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtUOMName.Text = Add_Item.voidQueryValidate(txtUOMName.Text);
                txtUOMArabic.Text = Add_Item.voidQueryValidate(txtUOMArabic.Text);
                //if (Login.InternetConnection() == false)
                //{
                //    lblMsg.Text = "Internet Connection Avalable. try again later";
                //    return;
                //}

                //bool Falg = Login.CheckDBConnection();
                //if (Falg == false)
                //{
                //    lblMsg.Text = "online Server Connection Fail. try again later";
                //    return;
                //}

                if (txtUOMName.Text == "")
                {
                    MessageBox.Show("Please Fill UOM Name");
                    txtUOMName.Focus();
                }
                else if (txtUOMArabic.Text == "")
                {
                    MessageBox.Show("Please Fill UOM Name in Arabic");
                    txtUOMArabic.Focus();
                }
                else
                {
                    int MultiUOMAllow = 0;
                    if (chkAddMultiUOMAllow.Checked == true)
                    {
                        MultiUOMAllow = 1;
                    }
                    int CalculateAspectRatio = 0;
                    if (chkCalculateAspectRatio.Checked == true)
                    {
                        CalculateAspectRatio = 1;
                    }

                    if (lblID.Text == "-")
                    {

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); //2018-02-05 12:07:36.390  string.Format("0:yyyy-MM-dd HH:mm:ss.fff", DateTime.Now)

                        int UOM = DataAccess.getUOMid(Tenent.TenentID);

                        //TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,CRUP_ID,Active,UOMNAME,UOMNAMEO,UOM_TYPE,UploadDate,Uploadby,SyncDate,Syncby,SynID

                        string UOM_Name = txtUOMName.Text;
                        UOM_Name = UOM_Name.Trim();

                        //string sqlitemcode = "select * from ICUOM where TenentID =" + Tenent.TenentID + " and UOMNAME1='" + UOM_Name + "'";
                        //DataTable dtitemcode = DataLive.GetLiveDataTable(sqlitemcode);
                        //if (dtitemcode.Rows.Count < 1)
                        //{
                        string UOMNAME1u = UOM_Name.ToUpper();
                        string sqlitemcode = "select * from ICUOM where TenentID =" + Tenent.TenentID + " and upper(UOMNAME1)='" + UOMNAME1u + "'";
                        DataTable dtitemcode = DataAccess.GetDataTable(sqlitemcode);
                        if (dtitemcode.Rows.Count < 1)
                        {
                            //string sqlCmdWin = " insert into ICUOM (TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,UOM_TYPE , Active , Uploadby ,UploadDate ,SynID)  " +
                            //   " values (" + Tenent.TenentID + "," + UOM + " , N'" + UOM_Name + "',N'" + UOM_Name + "', N'" + txtUOMArabic.Text + "',N'" + UOM_Name + "',N'" + UOM_Name + "', " +
                            //   " 'POS' , 'Y' , '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                            //int InsertFalg = DataLive.ExecuteLiveSQL(sqlCmdWin);

                            //if(InsertFalg==1)
                            //{
                            string sqlCmd = " insert into ICUOM (TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,UOM_TYPE , Active ,Uploadby ,UploadDate ,SynID,MultiUOMAllow,CalculateAspectRatio)  " +
                                            " values (" + Tenent.TenentID + "," + UOM + " , '" + UOM_Name + "', '" + UOM_Name + "','" + txtUOMArabic.Text + "', '" + UOM_Name + "','" + UOM_Name + "', " +
                                            " 'POS' , 'Y' , '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + MultiUOMAllow + "," + CalculateAspectRatio + " )";
                            int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                            string sqlCmdWin = " insert into ICUOM (TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,UOM_TYPE , Active , Uploadby ,UploadDate ,SynID,MultiUOMAllow,CalculateAspectRatio)  " +
                                               " values (" + Tenent.TenentID + "," + UOM + " , N'" + UOM_Name + "',N'" + UOM_Name + "', N'" + txtUOMArabic.Text + "',N'" + UOM_Name + "',N'" + UOM_Name + "', " +
                                               " 'POS' , 'Y' , '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + MultiUOMAllow + "," + CalculateAspectRatio + " )";
                            Datasyncpso.insert_Live_sync(sqlCmdWin, "ICUOM", "INSERT");

                            string ActivityName = "Add UOM";
                            string LogData = "Add UOM With UOM Name = " + UOM_Name + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            txtUOMName.Text = "";
                            txtUOMArabic.Text = "";
                            lblMsg.Visible = true;
                            lblMsg.Text = "Successfully saved";

                            UomList mkc = new UomList();
                            mkc.MdiParent = this.ParentForm;
                            mkc.Show();
                            this.Close();
                            //}                           
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = UOM_Name + " Already Exist";
                        }
                    }
                    else  //Update 
                    {

                        //TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,CRUP_ID,Active,UOMNAME,UOMNAMEO,UOM_TYPE,UploadDate,Uploadby,SyncDate,Syncby,SynID

                        string UOM_Name = txtUOMName.Text;
                        UOM_Name = UOM_Name.Trim();

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        //string sqlUpdateCmdWIN = " update ICUOM set  UOMNAMESHORT = N'" + UOM_Name + "',UOMNAME1 = N'" + UOM_Name + "' , UOMNAME2 = N'" + txtUOMArabic.Text + "', " +
                        //                     " UOMNAME3 = N'" + UOM_Name + "' , REMARKS = N'" + UOM_Name + "' ,Active = 'Y' , " +
                        //                     " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                        //                     " where UOM = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        //int UpdateFalg = DataLive.ExecuteLiveSQL(sqlUpdateCmdWIN);

                        //if (UpdateFalg == 1)
                        //{
                        string sqlUpdateCmd = " update ICUOM set  UOMNAMESHORT = '" + UOM_Name + "',UOMNAME1 = '" + UOM_Name + "' , UOMNAME2 = '" + txtUOMArabic.Text + "', " +
                                         " UOMNAME3 = '" + UOM_Name + "' , REMARKS = '" + UOM_Name + "' ,Active = 'Y' , " +
                                         " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 , MultiUOMAllow = " + MultiUOMAllow + " , CalculateAspectRatio = " + CalculateAspectRatio + " " +
                                         " where UOM = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        DataAccess.ExecuteSQL(sqlUpdateCmd);

                        string sqlUpdateCmdWIN = " update ICUOM set  UOMNAMESHORT = N'" + UOM_Name + "',UOMNAME1 = N'" + UOM_Name + "' , UOMNAME2 = N'" + txtUOMArabic.Text + "', " +
                                              " UOMNAME3 = N'" + UOM_Name + "' , REMARKS = N'" + UOM_Name + "' ,Active = 'Y' , " +
                                              " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 , MultiUOMAllow = " + MultiUOMAllow + " , CalculateAspectRatio = " + CalculateAspectRatio + " " +
                                              " where UOM = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "ICUOM", "UPDATE");

                        string ActivityName = "Update UOM";
                        string LogData = "Update UOM With UOM NAME = " + UOM_Name + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        UomList mkc = new UomList();
                        mkc.MdiParent = this.ParentForm;
                        mkc.Show();
                        this.Close();

                        //}
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
            UomList mkc = new UomList();
            mkc.MdiParent = this.ParentForm;
            mkc.Show();
            this.Close();
        }

        private void txtUOMName_Leave(object sender, EventArgs e)
        {
            bool Internat = Login.InternetConnection();
            if (Internat == true)
            {
                txtUOMArabic.Text = DataAccess.Translate(txtUOMName.Text, "ar");
            }
            else
            {
                txtUOMArabic.Text = txtUOMName.Text;
            }
        }

        private void chkAddMultiUOMAllow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddMultiUOMAllow.Checked == true)
            {
                chkCalculateAspectRatio.Enabled = true;
            }
            else
            {
                chkCalculateAspectRatio.Enabled = false;
                chkCalculateAspectRatio.Checked = false;
            }
        }
    }
}
