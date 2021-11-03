using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace supershop
{
    public partial class CommissionPayment : Form
    {
        public CommissionPayment(string Emp)
        {
            InitializeComponent();
            dtpaymentDate.Format = DateTimePickerFormat.Custom;
            dtpaymentDate.CustomFormat = "yyyy-MM-dd";
            //dgrvSalesItemList.DataSource = dataSource;
            lblEmp.Text = Emp;
            txtRemark.Text = "Payment To " + Emp;
            checkTotal(Emp);
            txtPaidAmount.Focus();
        }


        private void Payment_Load(object sender, EventArgs e)
        {

            try
            {

            }
            catch
            {
            }
        }

        public void checkTotal(string Emp)
        {
            string isEmployee = Emp == "-- All Employee --" ? "" : "and AppointmentReceipe.EmpOperator='" + Emp + "'";
            string StrInput1 = "select  Sum(CostPrice*Qty) as 'Total'" +
                                     "from AppointmentReceipe inner JOIN Appointment on AppointmentReceipe.AppointmentID = Appointment.ID and AppointmentReceipe.TenentID = Appointment.TenentID " +
                                     "where  AppointmentReceipe.TenentID=" + Tenent.TenentID + " and Deleted = 1 " +
                                     "and AppointmentReceipe.RecipeType='Commission' and Appointment.JobDone=1 " + isEmployee + "";
            DataTable dtitemcode = DataAccess.GetDataTable(StrInput1);


            double CommTotal = Convert.ToDouble(dtitemcode.Rows[0]["Total"]);
            string CT = CommTotal.ToString("N2");
            double DCT = Convert.ToDouble(CT);
            string q2check = "select * from CommisionPayment where TenentID=" + Tenent.TenentID + " and Employee='" + Emp + "'";
            DataTable dq2check = DataAccess.GetDataTable(q2check);
            if (dq2check.Rows.Count > 0)
            {
                string q2 = "select sum(PaidAmt) from CommisionPayment where TenentID=" + Tenent.TenentID + " and Employee='" + Emp + "'";
                DataTable dq2 = DataAccess.GetDataTable(q2);

                double PaidTotal = Convert.ToDouble(dq2.Rows[0][0]);
                PaidTotal = Convert.ToDouble(PaidTotal.ToString("N2"));
                lblCommPaid.Text = PaidTotal.ToString("N2");
                lblCommDue.Text = (DCT - PaidTotal).ToString("N2");
                txtPaidAmount.Text = lblCommDue.Text;
            }
            else
            {

                lblCommDue.Text = (DCT - 0).ToString("N2");
                txtPaidAmount.Text = lblCommDue.Text;
            }
        }



        private void btnCompleteSalesAndPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveOnly_Click(object sender, EventArgs e)
        {
            txtrefrence.Text=Add_Item.voidQueryValidate(txtrefrence.Text);
            txtRemark.Text=Add_Item.voidQueryValidate(txtRemark.Text);
            if (txtPaidAmount.Text != "" || txtPaidAmount.Text == "0")
            {
                double paidAmt = Convert.ToDouble(txtPaidAmount.Text);
                double dueamt = Convert.ToDouble(lblCommDue.Text);

                string StrInput1 = "select  Appointment.ID as 'App.No', AppointmentReceipe.JobID as JobID, IOSwitch,ItemCode,UOM,recNo," +
                                        "(100 * QtyIntoCostprice)/(Qty) as 'JobValue',Qty as 'percent',(CostPrice*Qty) as 'Amt'" +
                                        ",(select sum(PaidAmt) from CommisionPayment where CommisionPayment.TenentID=" + Tenent.TenentID + " and AppointmentReceipe.JobID=CommisionPayment.JobNo and AppointmentReceipe.ItemCode=CommisionPayment.ItemCode ) as PaidAmt," +
                                        "QtyIntoCostprice - (select sum(PaidAmt) from CommisionPayment where CommisionPayment.TenentID=" + Tenent.TenentID + " and AppointmentReceipe.JobID=CommisionPayment.JobNo and AppointmentReceipe.ItemCode=CommisionPayment.ItemCode ) as 'Balance',(select USERNAME from CRMActivities where MasterCode=AppointmentReceipe.JobID) as 'Employee',customer " +
                                        "from AppointmentReceipe inner JOIN Appointment on AppointmentReceipe.AppointmentID = Appointment.ID and AppointmentReceipe.TenentID = Appointment.TenentID " +
                                        "where  AppointmentReceipe.TenentID=" + Tenent.TenentID + " and Deleted = 1 " +
                                        "and AppointmentReceipe.RecipeType='Commission' and Appointment.JobDone=1  and AppointmentReceipe.EmpOperator='" + lblEmp.Text + "'	;";
                DataTable dtitemcode = DataAccess.GetDataTable(StrInput1);
                if (dtitemcode.Rows.Count > 0)
                {
                    double TotalAmt = 0;

                    string oldJobID = "", NewjobID = "";
                    bool DueFlag = true;
                    for (int i = 0; i < dtitemcode.Rows.Count; i++)
                    {
                        int PaymentSerial = 1;
                        if (DueFlag)
                        {
                            string Balance = dtitemcode.Rows[i]["Balance"].ToString() == "" ? "0" : dtitemcode.Rows[i]["Balance"].ToString();//6.5
                            double DBalance = Convert.ToDouble(Balance);//6.5
                            if (DBalance != 0 || dtitemcode.Rows[i]["Balance"].ToString() == "")
                            {
                                string JobID = dtitemcode.Rows[i]["JobID"].ToString();
                                string IOSwitch = dtitemcode.Rows[i]["IOSwitch"].ToString();
                                string ItemCode = dtitemcode.Rows[i]["ItemCode"].ToString();
                                string UOM = dtitemcode.Rows[i]["UOM"].ToString();
                                string recNo = dtitemcode.Rows[i]["recNo"].ToString();
                                string CommPercent = dtitemcode.Rows[i]["percent"].ToString() == "" ? "0" : dtitemcode.Rows[i]["percent"].ToString();//15
                                string jobvalue = dtitemcode.Rows[i]["JobValue"].ToString() == "" ? "0" : dtitemcode.Rows[i]["JobValue"].ToString();//110
                                string Amt = dtitemcode.Rows[i]["Amt"].ToString() == "" ? "0" : dtitemcode.Rows[i]["Amt"].ToString();//16.5
                                string gPaidAmt = dtitemcode.Rows[i]["PaidAmt"].ToString() == "" ? "0" : dtitemcode.Rows[i]["PaidAmt"].ToString();//10                             
                                double DPaidAmt = Convert.ToDouble(gPaidAmt);
                                DPaidAmt = Convert.ToDouble(DPaidAmt.ToString("N2"));
                                double DQty = Convert.ToDouble(CommPercent);//15
                                DQty = Convert.ToDouble(DQty.ToString("N2"));//15
                                double DAmt = Convert.ToDouble(Amt);//16.5
                                DAmt = Convert.ToDouble(DAmt.ToString("N2"));//16.5
                                double Djobvalue = Convert.ToDouble(jobvalue);//110
                                Djobvalue = Convert.ToDouble(Djobvalue.ToString("N2"));//110

                                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                string Uploadby = UserInfo.UserName;
                                string q3 = "select * from CommisionPayment where TenentID=" + Tenent.TenentID + " and LocationID=1 and recNo=" + recNo + " and IOSwitch='" + IOSwitch + "' and ItemCode=" + ItemCode + " and UOM=" + UOM + " and JobNo=" + JobID + "";
                                DataTable dtq3 = DataAccess.GetDataTable(q3);
                                if (dtq3.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dtq3.Rows.Count; j++)
                                    {
                                        PaymentSerial++;
                                        if (j == 0)
                                        {
                                            if (lblCommDue.Text != txtPaidAmount.Text)
                                            {
                                                DAmt = DAmt - DPaidAmt;
                                            }
                                            else
                                            {
                                                if (Balance != "")
                                                    DAmt = DBalance;
                                                else if (paidAmt > DAmt)//26.40
                                                    DAmt = paidAmt;
                                                else if (paidAmt < DAmt)
                                                    DAmt = DAmt - DPaidAmt;


                                            }
                                        }
                                    }
                                }
                                if (lblCommDue.Text == txtPaidAmount.Text)
                                {

                                    string sql1 = " insert into CommisionPayment (TenentID, LocationID, recNo, IOSwitch, ItemCode, UOM, PaymentSerial,  JobNo, PaidAmt,PaidDate,  FinaRef, Status, UploadDate, Uploadby, SynID, Remark, Employee) " +
                                                        " values (" + Tenent.TenentID + ",'1', '" + recNo + "','" + IOSwitch + "','" + ItemCode + "' , '" + UOM + "', " +
                                                        " '" + PaymentSerial + "','" + JobID + "','" + DAmt + "','" + dtpaymentDate.Text + "', '" + txtrefrence.Text + "', '" + "Paid" + "','" + dtpaymentDate.Text + "' , '" + Uploadby + "','1','" + txtRemark.Text + "','" + lblEmp.Text + "') ";
                                    int flag1 = DataAccess.ExecuteSQL(sql1);
                                    Datasyncpso.insert_Live_sync(sql1, "CommisionPayment", "INSERT");
                                }
                                else
                                {
                                    if (paidAmt < DAmt)
                                    {

                                        string sql1 = " insert into CommisionPayment (TenentID, LocationID, recNo, IOSwitch, ItemCode, UOM, PaymentSerial,  JobNo, PaidAmt,PaidDate,  FinaRef, Status, UploadDate, Uploadby, SynID, Remark, Employee) " +
                                                       " values (" + Tenent.TenentID + ",'1', '" + recNo + "','" + IOSwitch + "','" + ItemCode + "' , '" + UOM + "', " +
                                                       " '" + PaymentSerial + "','" + JobID + "','" + paidAmt + "','" + dtpaymentDate.Text + "', '" + txtrefrence.Text + "', '" + "Due" + "','" + dtpaymentDate.Text + "' , '" + Uploadby + "','1','" + txtRemark.Text + "','" + lblEmp.Text + "') ";
                                        int flag1 = DataAccess.ExecuteSQL(sql1);
                                        Datasyncpso.insert_Live_sync(sql1, "CommisionPayment", "INSERT");
                                        DueFlag = false;
                                    }
                                    if (paidAmt >= DAmt)
                                    {

                                        string sql1 = " insert into CommisionPayment (TenentID, LocationID, recNo, IOSwitch, ItemCode, UOM, PaymentSerial,  JobNo, PaidAmt,PaidDate,  FinaRef, Status, UploadDate, Uploadby, SynID, Remark, Employee) " +
                                                       " values (" + Tenent.TenentID + ",'1', '" + recNo + "','" + IOSwitch + "','" + ItemCode + "' , '" + UOM + "', " +
                                                       " '" + PaymentSerial + "','" + JobID + "','" + DAmt + "','" + dtpaymentDate.Text + "', '" + txtrefrence.Text + "', '" + "Paid" + "','" + dtpaymentDate.Text + "' , '" + Uploadby + "','1','" + txtRemark.Text + "','" + lblEmp.Text + "') ";
                                        int flag1 = DataAccess.ExecuteSQL(sql1);
                                        Datasyncpso.insert_Live_sync(sql1, "CommisionPayment", "INSERT");
                                        paidAmt = paidAmt - DAmt;
                                    }

                                }
                            }

                        }
                    }
                    MessageBox.Show("Data Save Successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Amount.");
                }



            }

        }

        private void txtPaidAmount_Leave(object sender, EventArgs e)
        {
            double paidAmt = Convert.ToDouble(txtPaidAmount.Text);
            double dueamt = Convert.ToDouble(lblCommDue.Text);
            if (paidAmt > dueamt)
            {
                MessageBox.Show("Amount is greter than Due Amount.");
                return;
            }
        }


    }
}
