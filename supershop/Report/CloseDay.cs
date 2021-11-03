using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace supershop.Report
{
    public partial class CloseDay : Form
    {
        public CloseDay()
        {
            InitializeComponent();
        }

        private void CloseDay_Load(object sender, EventArgs e)
        {
            enabled();
            Check_Validation();
            BindShift();
            BindEmployee();
            LastShiftOpen();
            BindGrid();

            //lblTodayShiftCash.Text = (getTodaycash()).ToString();
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ComboShift.Text == "")
            {
                MessageBox.Show("Please Select Valid Shift");
                return;
            }

            if (txtDaycloseBalance.Text == "")
            {
                MessageBox.Show("Please Enter Day Close Balance");
                return;
            }

            int ValidShif = getShiftID();
            if (ValidShif == 0)
            {
                MessageBox.Show("Please Select Valid Shift");
                return;
            }

            decimal TodayShiftCash = Convert.ToDecimal(lblTodayShiftCash.Text);
            string Date = lblDate.Text;
            int ShiftID = Convert.ToInt32(ComboShift.SelectedValue);
            decimal AMTDelivered = Convert.ToDecimal(txtDaycloseBalance.Text);
            decimal AdvanceAmt = Convert.ToDecimal(lblAdvance.Text);//Collect Cash
            decimal ReceivableAmt = Convert.ToDecimal(lblReceivable.Text);
            decimal CreditAmt = Convert.ToDecimal(lblCreditsale.Text);

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = " update DayClose set ShiftCIH=" + TodayShiftCash + " , undeliverdAMT=" + AMTDelivered + ",Employee=" + UserInfo.Userid + ",ShiftStutas=1,AdvanceAmt=" + AdvanceAmt + ",ReceivableAmt=" + ReceivableAmt + ",CreditAmt=" + CreditAmt + ", " +
                         " Uploadby= '" + UserInfo.UserName + "' , UploadDate = '" + UploadDate + "' , SynID = 2 " +
                         " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataAccess.ExecuteSQL(sql);
            Datasyncpso.insert_Live_sync(sql, "DayClose", "UPDATE");
            lblMSG.Text = "save Successfull";

        }

        public decimal getTodaycash()
        {
            decimal todayCash = 0;
            string ShiftID = ComboShift.SelectedValue.ToString();
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = '" + ShiftID + "' and Date = '" + Date + "' ";

            string sql = "select ((OpAMT + ShiftSales) - (ShiftReturn + VoucharAMT + ExpAMT + ChequeAMT + AMTDelivered + Shiftpurchase  )) as TodayCash from DayClose " + Condition;
            DataTable dt5 = DataAccess.GetDataTable(sql);
            if (dt5.Rows.Count > 0)
            {
                todayCash = Convert.ToDecimal(dt5.Rows[0][0]);
            }
            return todayCash;
        }

        public void BindGrid()
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and TrmID = '" + UserInfo.Shopid + "' and Date = '" + Date + "' ";
            string sql = "select Date,(Select shift_name from tbl_Shift where id=DayClose.ShiftID) as Shift, OpAMT as 'Opening Balance', ((OpAMT + ShiftSales) - (ShiftReturn + VoucharAMT + ExpAMT + ChequeAMT + AMTDelivered + Shiftpurchase  )) as 'Today Cash',AMTDelivered as 'Amount Deliverd' , undeliverdAMT as 'Undeliverd AMT' , (select Name from usermgt where id = DayClose.Employee and TenentID = " + Tenent.TenentID + " ) as Employee from DayClose " + Condition;
            DataTable dt5 = DataAccess.GetDataTable(sql);
            if (dt5.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt5;
            }
        }

        public void getcashdata()
        {
            decimal todayCash = 0;
            decimal OpAMT = 0;
            decimal ShiftSales = 0;
            decimal ChequeAMT = 0;
            decimal VoucharAMT = 0;
            decimal ExpAMT = 0;
            decimal ShiftReturn = 0;
            decimal Shiftpurchase = 0;
            decimal AMTDelivered = 0;
            decimal undeliverdAMT = 0;
            decimal Advance = 0;
            decimal Receivable = 0;
            decimal Creditsale = 0;
            decimal TotalIncome = 0;
            decimal TotalOutging = 0;
            decimal Cashonhand = 0;
            decimal TotalSale = 0;
            decimal CollactCash = 0;
            decimal Discount = 0;
            int DeliveredTO = 0;
           

            string RefNO = "";
            int ValidShif = getShiftID();
            if (ValidShif == 0)
            {
                MessageBox.Show("Please Select Valid Shift");
                return;
            }

            string ShiftID = ComboShift.SelectedValue.ToString();
            string Date = DateTime.Now.ToString("yyyy-MM-dd");

            //Total Receivable( Means Credit Receivable)
            string sqlReceivable = "select printf('%.3f', sum(payment_amount))  as Total from sales_payment_Recivable where strftime('%Y-%m-%d', date(UploadDate)) = strftime('%Y-%m-%d', date('now'))  and ShiftID ='" + UserInfo.ShiftID + "' ";
            DataTable dtReceivable = DataAccess.GetDataTable(sqlReceivable);
            if (dtReceivable.Rows.Count > 0)
            {
                Receivable = Convert.ToDecimal(dtReceivable.Rows[0]["Total"]);

            }


            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = '" + ShiftID + "' and Date = '" + Date + "' ";

            string sql = "select ((OpAMT + ShiftSales) - (ShiftReturn + VoucharAMT + ExpAMT + ChequeAMT + AMTDelivered + Shiftpurchase  )) as TodayCash,OpAMT,ShiftSales,ChequeAMT,VoucharAMT,ExpAMT,ShiftReturn,Shiftpurchase,RefNO,AMTDelivered,undeliverdAMT,DeliveredTO,AdvanceAmt,ReceivableAmt,CreditAmt from DayClose " + Condition;
            DataTable dt5 = DataAccess.GetDataTable(sql);
            if (dt5.Rows.Count > 0)
            {
                todayCash = Convert.ToDecimal(dt5.Rows[0]["TodayCash"]);
                OpAMT = Convert.ToDecimal(dt5.Rows[0]["OpAMT"]);
                ShiftSales = Convert.ToDecimal(dt5.Rows[0]["ShiftSales"]);
                ChequeAMT = Convert.ToDecimal(dt5.Rows[0]["ChequeAMT"]);
                VoucharAMT = Convert.ToDecimal(dt5.Rows[0]["VoucharAMT"]);
                ExpAMT = Convert.ToDecimal(dt5.Rows[0]["ExpAMT"]);
                ShiftReturn = Convert.ToDecimal(dt5.Rows[0]["ShiftReturn"]);
                ShiftReturn = Math.Abs(ShiftReturn);
                Shiftpurchase = Convert.ToDecimal(dt5.Rows[0]["Shiftpurchase"]);
                RefNO = dt5.Rows[0]["RefNO"].ToString();
                AMTDelivered = Convert.ToDecimal(dt5.Rows[0]["AMTDelivered"]);
                Advance = Cusromer_AdvancePay.GetCustAdvance(""); ;//Convert.ToDecimal(dt5.Rows[0]["AdvanceAmt"]);
                // Receivable = Convert.ToDecimal(dt5.Rows[0]["ReceivableAmt"]);
                Creditsale = Cusromer_AdvancePay.GetCustSaleDeduct(""); ; //Convert.ToDecimal(dt5.Rows[0]["CreditAmt"]);
                undeliverdAMT = Convert.ToDecimal(dt5.Rows[0]["undeliverdAMT"]);
                if (dt5.Rows[0]["DeliveredTO"] != DBNull.Value)
                    DeliveredTO = Convert.ToInt32(dt5.Rows[0]["DeliveredTO"]);
                TotalIncome = ShiftSales + Advance + Receivable + Creditsale;
                TotalOutging = ChequeAMT + VoucharAMT + ExpAMT + ShiftReturn + Shiftpurchase;
                Cashonhand = OpAMT + (TotalIncome - TotalOutging);

            }
            //Total Sale
            string sqlTotalsale = "select printf('%.3f', sum(Total) - sum(discount))  as Total from sales_item where sales_time = date('now') and PaymentMode <> 'Draft' and ShiftID ='" + UserInfo.ShiftID + "' and Deleted=0  ";
            DataTable dtTotalsale = DataAccess.GetDataTable(sqlTotalsale);
            if (dtTotalsale.Rows.Count > 0)
            {
                TotalSale = Convert.ToDecimal(dtTotalsale.Rows[0]["Total"]);

            }
            //Cash Collect
            string sqlCollect = "select printf('%.3f',  Sum(Total) - sum(discount)) as Total from sales_item where  strftime('%Y-%m-%d', date(UploadDate)) = strftime('%Y-%m-%d', date('now')) and sales_time<>date('now') and ShiftID ='" + UserInfo.ShiftID + "' and PaymentMode='PriPaid' and Deleted=0";
            DataTable dtCollect = DataAccess.GetDataTable(sqlCollect);
            if (dtCollect.Rows.Count > 0)
            {
                CollactCash = Convert.ToDecimal(dtCollect.Rows[0]["Total"]);

            }

            lblOpeningamt.Text = OpAMT.ToString("N3");
            lblTodayShiftCash.Text = TotalSale.ToString("N3");
            //Total Income
            lblCashAmt.Text = ShiftSales.ToString("N3");
            lblReceivable.Text = Receivable.ToString("N3");
            lblCollectCash.Text = CollactCash.ToString("N3");
            lblAdvance.Text = Advance.ToString("N3");
            lblCreditsale.Text = Creditsale.ToString("N3");
            //Total Outgoing
            lblChequeAmt.Text = ChequeAMT.ToString("N3");
            lblVouchar.Text = VoucharAMT.ToString("N3");
            lblExpense.Text = ExpAMT.ToString("N3");
            lblReturnAmt.Text = ShiftReturn.ToString("N3");
            lblShiftPurchase.Text = Shiftpurchase.ToString("N3");
            //Other
            lblReference.Text = RefNO;

            lblTotalincome.Text = TotalIncome.ToString("N3");
            lblTotalOutgoing.Text = TotalOutging.ToString("N3");
            lblCashonhand.Text = Cashonhand.ToString("N3");
            //lblshift.Text = ComboShift.Text;
            ////string EmpName = GetEmpName(DeliveredTO);
            ////lblEmployee.Text = EmpName!="" ?EmpName:"-";
            //lblDeliverdAmt.Text = AMTDelivered.ToString();
            //lblrestAmt.Text = undeliverdAMT.ToString();
        }

        public void BindEmployee()
        {
            //comboDelivered.DataSource = null;
            //comboDelivered.Items.Clear();

            //// id,Name

            //string sql5 = "Select id,Name from usermgt";
            //DataAccess.ExecuteSQL(sql5);
            //DataTable dt5 = DataAccess.GetDataTable(sql5);

            //comboDelivered.ValueMember = "id";
            //comboDelivered.DisplayMember = "Name";
            //comboDelivered.DataSource = dt5;

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

                ComboShift.ValueMember = "ID";
                ComboShift.DisplayMember = "Shift_Name";
                ComboShift.DataSource = dt5;

            }
            else if (UserInfo.Language == "Arabic")
            {
                string sql5 = "Select ID,Fhift_Arabic from tbl_Shift";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);

                ComboShift.ValueMember = "ID";
                ComboShift.DisplayMember = "Fhift_Arabic";
                ComboShift.DataSource = dt5;
            }
            else
            {
                string sql5 = "Select ID,Shift_Name from tbl_Shift";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                ComboShift.ValueMember = "ID";
                ComboShift.DisplayMember = "Shift_Name";
                ComboShift.DataSource = dt5;
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

        //public int getEMPID()
        //{
        //    int id = 0;
        //    string empname = comboDelivered.Text;

        //    string sql5 = "";
        //    sql5 = "Select * from usermgt where Name = '" + empname + "' ";
        //    DataTable dt5 = DataAccess.GetDataTable(sql5);

        //    if (dt5.Rows.Count > 0)
        //    {
        //        id = Convert.ToInt32(dt5.Rows[0]["id"]);
        //    }
        //    return id;
        //}

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

        public void LastShiftOpen()
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and Date = '" + Date + "' and ShiftStutas = 0 ";

            string sql5 = "Select * from DayClose " + Condition;
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                string sql123 = " select ShiftID from DayClose " + Condition;
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int shift = Convert.ToInt32(dt12.Rows[0][0]);
                    UserInfo.ShiftID = shift;
                    ComboShift.SelectedValue = shift;
                    getcashdata();

                    enabled();

                }
                else
                {
                    getcashdata();
                    disaable();
                    MessageBox.Show("Shift already Close or Shift not Open");
                    this.Close();
                }
            }
            else
            {
                getcashdata();
                disaable();
                MessageBox.Show("Shift already Close or Shift not Open");
                return;
            }
        }

        public void disaable()
        {
            //comboDelivered.Enabled = false;
            ComboShift.Enabled = false;
            txtDaycloseBalance.Enabled = false;
            btnSave.Enabled = false;
        }

        public void enabled()
        {
            //comboDelivered.Enabled = true;
            ComboShift.Enabled = true;
            txtDaycloseBalance.Enabled = true;
            btnSave.Enabled = true;
        }

        public void Check_Validation()
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and Date = '" + Date + "' ";

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
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ShiftID = Convert.ToInt32(ComboShift.SelectedValue);
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' and DeliveredTO is null ";

            string sql5 = "Select * from DayClose " + Condition;
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                getcashdata();
            }

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            btnSave.Visible = BtnPrint.Visible = button1.Visible = false;
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            btnSave.Visible = BtnPrint.Visible = button1.Visible = true;
        }
        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void lblTodayShiftCash_Click(object sender, EventArgs e)
        {

        }



        //private void txtDaycloseBalance_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtDaycloseBalance.Text != "" && lblTodayShiftCash.Text!="")
        //    {
        //        decimal Enter = Convert.ToDecimal(txtDaycloseBalance.Text);
        //        decimal TodayCash = Convert.ToDecimal(lblTodayShiftCash.Text);

        //        if (Enter <= TodayCash)
        //        {   }
        //        else
        //        {
        //            MessageBox.Show("Enter Day close Balance less than or equal to " + TodayCash);                    
        //        }
        //    }  
        //}


    }
}
