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
    public partial class DueUpdate : Form
    {
        public DueUpdate()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Data get from Duelist
        public string due
        {
            set { lbDueAmount.Text = value; }
            get { return lbDueAmount.Text; }
        }
        public string Salesid
        {
            set { lbsalesid.Text = value; }
            get { return lbsalesid.Text; }
        }
        public string salesdate
        {
            set { lbdate.Text = value; }
            get { return lbdate.Text; }
        }
        public string totalamount
        {
            set { lbtotalamt.Text = value; }
            get { return lbtotalamt.Text; }
        }
        public string paidamount
        {
            set { lbpaidamt.Text = value; }
            get { return lbDueAmount.Text; }
        }
        public string contact
        {
            set { lbcontact.Text = value; }
            get { return lbcontact.Text; }
        }
        #endregion

        private void DueUpdate_Load(object sender, EventArgs e)
        {
            dtReceiveDate.Format = DateTimePickerFormat.Custom;
            dtReceiveDate.CustomFormat = "yyyy-MM-dd";
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            DueList go = new DueList();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void DueUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        #region Request submit
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtReceive.Text == "")
            {
                // MessageBox.Show("You are Not able to Update");
                MessageBox.Show("You are Not able to Update", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (Convert.ToDouble(txtReceive.Text) <= Convert.ToDouble(lbDueAmount.Text))
                    {
                        double Receiveamt = Convert.ToDouble(lbDueAmount.Text) - Convert.ToDouble(txtReceive.Text);

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql = "UPDATE sales_payment set due_amount = '" + Receiveamt + "', " +
                                     " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                     " where TenentID= " + Tenent.TenentID + " and (sales_id = '" + lbsalesid.Text + "')";
                        DataAccess.ExecuteSQL(sql);

                        string sqlwin = "UPDATE Win_sales_payment set due_amount = '" + Receiveamt + "', " +
                                     " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                     " where TenentID= " + Tenent.TenentID + " and (sales_id = '" + lbsalesid.Text + "')";
                        Datasyncpso.insert_Live_sync(sqlwin, "Win_sales_payment", "UPDATE");

                        //Insert Due payment history
                        double remainingdeu = Convert.ToDouble(lbDueAmount.Text) - Convert.ToDouble(txtReceive.Text);

                        int ID = DataAccess.gettbl_duepaymentMYid(Tenent.TenentID, lbsalesid.Text);

                        string sqlreceivedue = " insert into tbl_duepayment (TenentID,id, receivedate, sales_id, totalamt , dueamt, receiveamt , custid,Uploadby ,UploadDate ,SynID) " +
                                                " values (" + Tenent.TenentID + "," + ID + ",'" + dtReceiveDate.Text + "' , '" + lbsalesid.Text + "', '" + lbtotalamt.Text + "', " +
                                                " '" + remainingdeu + "', '" + txtReceive.Text + "', '" + lbcontact.Text + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1) ";
                        int flag1 = DataAccess.ExecuteSQL(sqlreceivedue);

                        string sqlreceivedueWin = " insert into Win_tbl_duepayment (TenentID, receivedate, sales_id, totalamt , dueamt, receiveamt , custid,Uploadby ,UploadDate ,SynID) " +
                                                " values (" + Tenent.TenentID + ",'" + dtReceiveDate.Text + "' , '" + lbsalesid.Text + "', '" + lbtotalamt.Text + "', " +
                                                " '" + remainingdeu + "', '" + txtReceive.Text + "', '" + lbcontact.Text + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1) ";
                        Datasyncpso.insert_Live_sync(sqlreceivedueWin, "Win_tbl_duepayment", "INSERT");

                        string ActivityName = "Receive Due Payment";
                        string LogData = "Receive Due Payment with sales_id = " + lbsalesid.Text + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        MessageBox.Show("Successfully Data Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtReceive.Text = string.Empty;

                        // this.Close();
                        this.Hide();
                        DueList go = new DueList();
                        go.MdiParent = this.ParentForm;
                        go.Show();

                    }
                    else
                    {
                        MessageBox.Show("You are Not able to Update \n\n Excced Due amount ", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch
                {
                }
            }
        }

        #endregion
    }
}
