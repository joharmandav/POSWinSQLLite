using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop
{
    public partial class OrderWayMaintenance : Form
    {
        InputLanguage arabic;
        InputLanguage english;
        public OrderWayMaintenance()
        {
            InitializeComponent();

            txtCommissionper.KeyPress += new KeyPressEventHandler(txtCommissionper_KeyPress);
            txtCommissionAmount.KeyPress += new KeyPressEventHandler(txtCommissionAmount_KeyPress);
        }
        private void OrderWayMaintenance_Load(object sender, EventArgs e)
        {
            arabic = InputLanguage.CurrentInputLanguage;
            english = InputLanguage.CurrentInputLanguage;

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
            }
        }

        private void txtNameInEnglish_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = english;
        }

        private void txtNameInArabic_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = arabic;
        }

        #region getset
        public string OerderwayNameEnglish
        {
            set
            {
                txtNameInEnglish.Text = value;
            }
            get
            {
                return txtNameInEnglish.Text;
            }
        }
        public string OerderwayNameArabic
        {
            set
            {
                txtNameInArabic.Text = value;
            }
            get
            {
                return txtNameInArabic.Text;
            }
        }
        public string OerderID
        {
            set
            {
                lblID.Text = value;
            }
            get
            {
                return lblID.Text;
            }
        }

        public string OerderwayID
        {
            set
            {
                comboOrderWay.Text = value;
            }
            get
            {
                return comboOrderWay.Text;
            }
        }
        public string Commission_per
        {
            set
            {
                txtCommissionper.Text = value;
            }
            get
            {
                return txtCommissionper.Text;
            }
        }
        public string Commission_amount
        {
            set
            {
                txtCommissionAmount.Text = value;
            }
            get
            {
                return txtCommissionAmount.Text;
            }
        }

        public string DeliveryCharges
        {
            set
            {
                txtDeliveryCharges.Text = value;
            }
            get
            {
                return txtDeliveryCharges.Text;
            }
        }
        public string Commission_paid
        {
            set
            {
                txtPaidCommission.Text = value;
            }
            get
            {
                return txtPaidCommission.Text;
            }
        }
        public string Commission_Pending
        {
            set
            {
                txtPendingCommission.Text = value;
            }
            get
            {
                return txtPendingCommission.Text;
            }
        }
        #endregion

        private void bntSave_Click(object sender, EventArgs e)
        {
            if (comboOrderWay.Text == "")
            {
                MessageBox.Show("Please Select Order Way ID");
                comboOrderWay.Focus();
                return;
            }
            else
            {
                if (comboOrderWay.Text == "Walk In")
                {
                    string sqlCmd = "Select DISTINCT OrderWayID from tbl_orderWay_Maintenance where TenentID = " + Tenent.TenentID + " and OrderWayID='Walk In'"; //From view combination of tbl_customer and custcredit
                    DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                    if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show("Walk In already Exist");
                        comboOrderWay.Focus();
                        return;
                    }
                }

            }

            if (txtNameInEnglish.Text == "")
            {
                MessageBox.Show("Please Fill Name In English");
                txtNameInEnglish.Focus();
                return;
            }
            else
            {
                if (lblID.Text == "-")
                {
                    string sqlCmd = "Select * from tbl_orderWay_Maintenance where TenentID = " + Tenent.TenentID + " and Name1='" + txtNameInEnglish.Text + "'"; //From view combination of tbl_customer and custcredit
                    DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                    if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show("Name In English already Exist");
                        comboOrderWay.Focus();
                        return;
                    }
                }

            }

            if (txtNameInArabic.Text == "")
            {
                MessageBox.Show("Please Fill Name In Arabic");
                txtNameInArabic.Focus();
                return;
            }
            else
            {
                if (lblID.Text == "-")
                {
                    string sqlCmd = "Select * from tbl_orderWay_Maintenance where TenentID = " + Tenent.TenentID + " and Name2='" + txtNameInArabic.Text + "'"; //From view combination of tbl_customer and custcredit
                    DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                    if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show("Name In Arabic already Exist");
                        comboOrderWay.Focus();
                        return;
                    }
                }
            }

            if (txtCommissionper.Text == "")
            {
                MessageBox.Show("Please Fill % on Sale Amount");
                txtCommissionper.Focus();
                return;
            }
            if (txtCommissionAmount.Text == "")
            {
                MessageBox.Show("Please Fill Fix Charges on Sales Amount");
                txtCommissionAmount.Focus();
                return;
            }


            if (lblID.Text == "-")
            {

                int ID = DataAccess.getorderWay_MaintenanceMYid(Tenent.TenentID);

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlCmd = "insert into tbl_orderWay_Maintenance (TenentID,ID, OrderWayID,Name1,Name2,Commission_per,Commission_Amount,DeliveryCharges,Paid_Commission,Pending_Commission,Uploadby ,UploadDate ,SynID) " +
                " values (" + Tenent.TenentID + "," + ID + ",'" + comboOrderWay.Text + "','" + txtNameInEnglish.Text + "','" + txtNameInArabic.Text + "', '" + txtCommissionper.Text + "', " +
                " '" + txtCommissionAmount.Text + "','" + txtDeliveryCharges.Text + "' ,0,0,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                string sqlCmdWin = "insert into Win_tbl_orderWay_Maintenance (TenentID,ID, OrderWayID,Name1,Name2,Commission_per,Commission_Amount,DeliveryCharges,Paid_Commission,Pending_Commission,Uploadby ,UploadDate ,SynID) " +
                " values (" + Tenent.TenentID + "," + ID + ",'" + comboOrderWay.Text + "', N'" + txtNameInEnglish.Text + "', N'" + txtNameInArabic.Text + "', '" + txtCommissionper.Text + "', " +
                " '" + txtCommissionAmount.Text + "','" + txtDeliveryCharges.Text + "' ,0,0,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                Datasyncpso.insert_Live_sync(sqlCmdWin, "Win_tbl_orderWay_Maintenance", "UPDATE");

                string ActivityName = "insert orderWay";
                string LogData = "insert orderWay with " + comboOrderWay.Text + " - " + txtNameInEnglish.Text + " ";
                Login.InsertUserLog(ActivityName, LogData);

            }
            else
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlCmd = "update tbl_orderWay_Maintenance set Name1='" + txtNameInEnglish.Text + "', Name2='" + txtNameInArabic.Text + "' , Commission_per='" + txtCommissionper.Text + "', " +
                                " Commission_Amount='" + txtCommissionAmount.Text + "',DeliveryCharges='" + txtDeliveryCharges.Text + "' , " +
                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                "  where ID=" + lblID.Text + " and TenentID= " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sqlCmd);

                string sqlCmdwin = "update Win_tbl_orderWay_Maintenance set Name1= N'" + txtNameInEnglish.Text + "', Name2= N'" + txtNameInArabic.Text + "' , Commission_per='" + txtCommissionper.Text + "', " +
                                " Commission_Amount='" + txtCommissionAmount.Text + "',DeliveryCharges='" + txtDeliveryCharges.Text + "' , " +
                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                "  where ID=" + lblID.Text + " and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sqlCmdwin, "Win_tbl_orderWay_Maintenance", "UPDATE");

                string ActivityName = "Update orderWay";
                string LogData = "Update orderWay with " + comboOrderWay.Text + " - " + txtNameInEnglish.Text + " ";
                Login.InsertUserLog(ActivityName, LogData);

            }
            MessageBox.Show("Successfully saved");
            clearform();

        }

        public void clearform()
        {
            lblID.Text = "-";
            txtCommissionper.Text = "";
            txtCommissionAmount.Text = "";
            txtPendingCommission.Text = "";
            txtPaidCommission.Text = "";
        }

        private void lnkCustomers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OrderWayList go = new OrderWayList();
            go.Show();

        }

        private void txtCommissionper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtCommissionAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

    }
}
