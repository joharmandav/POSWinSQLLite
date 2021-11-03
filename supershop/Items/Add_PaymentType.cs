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
    public partial class Add_PaymentType : Form
    {
        InputLanguage arabic;
        InputLanguage english;
        InputLanguage French;
        public Add_PaymentType()
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

        public string PageName
        {
            set
            {
                lblPageName.Text = value;
            }
            get
            {
                return lblPageName.Text;
            }
        }

        private void txtPayTypeArabic_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = arabic;
        }

        private void txtPayTypeArabic_LostFocus(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }
        private void txtPayTypeArabic_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public string REFID
        {
            set { lblID.Text = value; }
            get { return lblID.Text; }
        }
        public string REFNAME1
        {
            set { txtPayTypeName.Text = value; btnSave.Text = "Update"; }
            get { return txtPayTypeName.Text; }
        }

        public string REFNAME2
        {
            set { txtPayTypeArabic.Text = value; }
            get { return txtPayTypeArabic.Text; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            try
            {

                if (txtPayTypeName.Text == "")
                {
                    MessageBox.Show("Please Fill Payment Type in English");
                    txtPayTypeName.Focus();
                }
                else if (txtPayTypeArabic.Text == "")
                {
                    MessageBox.Show("Please Fill Payment Type in Arabic");
                    txtPayTypeArabic.Focus();
                }
                else
                {
                    txtPayTypeName.Text = Add_Item.voidQueryValidate(txtPayTypeName.Text);
                    txtPayTypeArabic.Text = Add_Item.voidQueryValidate(txtPayTypeArabic.Text);
                    if (lblID.Text == "-")
                    {

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); //2018-02-05 12:07:36.390  string.Format("0:yyyy-MM-dd HH:mm:ss.fff", DateTime.Now)

                        int REFID = DataAccess.getREFIDid(Tenent.TenentID);

                        string REFNAMEEng = txtPayTypeName.Text;
                        REFNAMEEng = REFNAMEEng.Trim();

                        string REFNAMEEngu = REFNAMEEng.ToUpper();

                        string sqlitemcode = "select * from REFTABLE where TenentID =" + Tenent.TenentID + " and upper(REFNAME1)='" + REFNAMEEngu + "'";
                        DataTable dtitemcode = DataAccess.GetDataTable(sqlitemcode);
                        if (dtitemcode.Rows.Count < 1)
                        {
                            string sqlCmd = " insert into REFTABLE (TenentID,REFID,REFTYPE,REFSUBTYPE,SHORTNAME,REFNAME1,REFNAME2,REFNAME3,Remarks,ACTIVE,UploadDate,Uploadby,SynID)  " +
                                            " values (" + Tenent.TenentID + "," + REFID + " , 'Payment' , 'Method' , 'POS', '" + REFNAMEEng + "','" + txtPayTypeArabic.Text + "', '" + REFNAMEEng + "','" + REFNAMEEng + "', " +
                                            " 'Y' , '" + UploadDate + "'  , '" + UserInfo.UserName + "' ,  1  )";
                            int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                            string sqlCmdWin = " insert into REFTABLE (TenentID,REFID,REFTYPE,REFSUBTYPE,SHORTNAME,REFNAME1,REFNAME2,REFNAME3,Remarks,ACTIVE,UploadDate,Uploadby,SynID)  " +
                                               " values (" + Tenent.TenentID + "," + REFID + " , 'Payment' , 'Method' , 'POS',N'" + REFNAMEEng + "', N'" + txtPayTypeArabic.Text + "',N'" + REFNAMEEng + "',N'" + REFNAMEEng + "', " +
                                               " 'Y' ,  '" + UploadDate + "'  ,'" + UserInfo.UserName + "' , 1  )";
                            Datasyncpso.insert_Live_sync(sqlCmdWin, "REFTABLE", "INSERT");

                            string ActivityName = "Add Payment Type";
                            string LogData = "Add Payment Type With REF NAME = " + REFNAMEEng + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            txtPayTypeName.Text = "";
                            txtPayTypeArabic.Text = "";
                            lblMsg.Visible = true;
                            lblMsg.Text = "Successfully saved";

                            if (lblPageName.Text == "PaymentTypeList")
                            {
                                PaymentTypeList mkc = new PaymentTypeList();
                                mkc.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                                mkc.Show();
                            }
                            this.Close();
                            //}                           
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = REFNAMEEng + " Already Exist";
                        }
                    }
                    else  //Update 
                    {
                        string REFNAMEEng = txtPayTypeName.Text;
                        REFNAMEEng = REFNAMEEng.Trim();

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        string sqlUpdateCmd = " update REFTABLE set  REFNAME1 = '" + REFNAMEEng + "' , REFNAME2 = '" + txtPayTypeArabic.Text + "', " +
                                         " REFNAME3 = '" + REFNAMEEng + "' , REMARKS = '" + REFNAMEEng + "' ,ACTIVE = 'Y' , " +
                                         " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                         " where REFID = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        DataAccess.ExecuteSQL(sqlUpdateCmd);

                        string sqlUpdateCmdWIN = " update REFTABLE set  REFNAME1 = N'" + REFNAMEEng + "' , REFNAME2 = N'" + txtPayTypeArabic.Text + "', " +
                                              " REFNAME3 = N'" + REFNAMEEng + "' , Remarks = N'" + REFNAMEEng + "' ,Active = 'Y' , " +
                                              " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                              " where REFID = '" + lblID.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "REFTABLE", "UPDATE");

                        string ActivityName = "Update Payment Type";
                        string LogData = "Update Payment Type With NAME = " + REFNAMEEng + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        if (lblPageName.Text == "PaymentTypeList")
                        {
                            PaymentTypeList mkc = new PaymentTypeList();
                            mkc.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                            mkc.Show();
                        }
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
            PaymentTypeList mkc = new PaymentTypeList();
            mkc.MdiParent = this.ParentForm;
            mkc.Show();
            this.Close();
        }

        private void txtPayTypeName_Leave(object sender, EventArgs e)
        {
            bool Internat = Login.InternetConnection();
            if (Internat == true)
            {
                txtPayTypeArabic.Text = DataAccess.Translate(txtPayTypeName.Text, "ar");
            }
            else
            {
                txtPayTypeArabic.Text = txtPayTypeName.Text;
            }
        }

        private void txtPayTypeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == '~' || e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtPayTypeArabic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == '~' || e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

    }
}
