using MessageBoxExample;
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
    public partial class Cusromer_AdvancePay : Form
    {
        public Cusromer_AdvancePay()
        {
            InitializeComponent();
            dtDateOFAdvance.Format = DateTimePickerFormat.Custom;
            dtDateOFAdvance.CustomFormat = "yyyy-MM-dd";

            //DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            //datagridAdvanceHistory.Columns.Add(del);
            //del.HeaderText = "Delete";
            //del.Text = "Delete";
            //del.Name = "Delete";
            //del.ToolTipText = "Delete this UOM";
            //del.UseColumnTextForButtonValue = true;
            //del.Width = 100;

            //DataGridViewButtonColumn EditConv = new DataGridViewButtonColumn();
            //datagridAdvanceHistory.Columns.Add(EditConv);
            //EditConv.HeaderText = "Edit";
            //EditConv.Text = "Edit";
            //EditConv.Name = "Edit";
            //EditConv.ToolTipText = "Edit this UOM Conversion";
            //EditConv.UseColumnTextForButtonValue = true;
            //EditConv.Width = 100;
        }

        public string CustomerID
        {
            set
            {
                lblCustomerID.Text = value;
            }
            get
            {
                return lblCustomerID.Text;
            }
        }

        public string CustomerName
        {
            set
            {
                txtCustomerName.Text = value;
            }
            get
            {
                return txtCustomerName.Text;
            }
        }
        public static decimal GetCustAdvance(string CID)
        {
            string str = " and CustomerID = '" + CID + "'";
            if(CID=="")
            {
                str = " and strftime('%Y-%m-%d', date(UploadDate)) = strftime('%Y-%m-%d', date('now'))";
            }
            string sql1 = "  select printf('%.3f',SUM(Amount)) as Total from tbl_Customer_Advance  where TenentID = " + Tenent.TenentID + str + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql1);
            decimal Amt = 0;
            return Convert.ToDecimal(dt1.Rows[0]["Total"]);

        }
        public static decimal GetCustSaleDeduct(string CID)
        {
            string str = " and c_id = '" + CID + "'";
            if (CID == "")
            {
                str = " and strftime('%Y-%m-%d', date(UploadDate)) = strftime('%Y-%m-%d', date('now'))";
            }
            string sql1 = "  select printf('%.3f',SUM(payment_amount)) as Total from sales_payment  where TenentID = " + Tenent.TenentID + str + " and payment_type='Advance'";
            DataTable dt1 = DataAccess.GetDataTable(sql1);
            decimal Amt = 0;
            return Convert.ToDecimal(dt1.Rows[0]["Total"]);

        }
        private void Cusromer_AdvancePay_Load(object sender, EventArgs e)
        {
            decimal advance = GetCustAdvance(lblCustomerID.Text);
            decimal Deduct = GetCustSaleDeduct(lblCustomerID.Text);
            decimal finalTotal=advance-Deduct;
            lblAvailableBalance.Text = finalTotal.ToString("N3");
           

            string sql = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and ID = '" + lblCustomerID.Text + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    txtCustomerName.Text = dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"].ToString() != "" ? dt.Rows[0]["Name"].ToString() : "";
                }
            }
            DataBind();
        }

        public void DataBind()
        {
            string sql1 = "  select MyID as ID , DateOFAdvance as 'Date of Advance',Amount, Remark from tbl_Customer_Advance  where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "'";
            DataTable dt1 = DataAccess.GetDataTable(sql1);
            datagridAdvanceHistory.DataSource = dt1;

            //datagridAdvanceHistory.Columns["Edit"].DisplayIndex = 3;
            //datagridAdvanceHistory.Columns["Edit"].Width = 100;

            //datagridAdvanceHistory.Columns["Delete"].DisplayIndex = 3;
            //datagridAdvanceHistory.Columns["Delete"].Width = 100;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TenentID,CustomerID,MyID,DateOFAdvance,RSPHDistance,RSPHReading,RCylDistance,RCylReading,RAxisDistance,RAxisReading,
            //LPDDistance,LPDReading,LSPHDistance,LSPHReading,LCylDistance,LCylReading,LAxisDistance,LAxisReading

            //TenentID,CustomerID,MyID,DateOFAdvance,RSPHDistance,RSPHReading,RCylDistance,RCylReading,RAxisDistance,RAxisReading,
            //LPDDistance,LPDReading,LSPHDistance,LSPHReading,LCylDistance,LCylReading,LAxisDistance,LAxisReading
            if (txtAmount.Text == "" || txtAmount.Text == "0")
            {
                MyMessageAlert.ShowBox("Please Enter Amount.", "Alert");
                txtAmount.Focus();
                return;
            }
            else
            {
                string sqlCust = " select tbl_customer.ID , sales_item.InvoiceNO as Invoice " +
                             " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = '" + lblCustomerID.Text + "' " +
                             " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                             " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                             " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) and sales_item.C_id = '" + lblCustomerID.Text + "'  " +
                             " group by sales_item.C_id Order by Name";
                DataTable dtCust = DataAccess.GetDataTable(sqlCust);
                if (dtCust.Rows.Count > 0)
                {
                    string result = MyMessageBox.ShowBox("You have Credit Invoices to be closed, Would you like to received amount in Credit Invoices deduct from Advance Amount.", "Alert");
                    if (result == "1")//or 2=cancel
                      {
                          if (Application.OpenForms["payablecredit"] != null)
                          {
                              Application.OpenForms["payablecredit"].Close();
                          }
                          this.Refresh();

                          payablecredit go2 = new payablecredit();
                          //go2.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                          go2.CustomerID = lblCustomerID.Text;
                          go2.CustAdvance = txtAmount.Text;
                          go2.Show();

                          return;
                      }
                      else
                      {
                          txtRemark.Text += " Advance is accepted even though there is invoiced credit.";
                      }
                      
                }
            }
            string CustomerID = lblCustomerID.Text;
            string DateOFAdvance = dtDateOFAdvance.Text;
            decimal Amount = Convert.ToDecimal(txtAmount.Text);
            string remark = txtRemark.Text;
            int MyID = 0;

            if (lblMyID.Text == "-")
            {
                MyID = DataAccess.getCustomer_Advance_MYid(Tenent.TenentID, CustomerID);
            }
            else
            {
                MyID = Convert.ToInt32(lblMyID.Text);
            }




            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sqlselect = " select * from   tbl_Customer_Advance where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MyID + "' ";
            DataTable Dtselect = DataAccess.GetDataTable(sqlselect);

            if (Dtselect.Rows.Count < 1)
            {
                string sqlinsert = " insert into tbl_Customer_Advance ( TenentID,CustomerID,MyID,DateOFAdvance,Amount,Remark, UploadDate,Uploadby,SynID) " +
                                   " values ( " + Tenent.TenentID + " , '" + CustomerID + "' , '" + MyID + "','" + DateOFAdvance + "','" + Amount + "','" + remark + "', " +
                                   " '" + UploadDate + "' , '" + UserInfo.UserName + "',1 ) ";
                DataAccess.ExecuteSQL(sqlinsert);
                Datasyncpso.insert_Live_sync(sqlinsert, "tbl_Customer_Advance", "INSERT");

            }
            else
            {
                string SqlUpdate = " Update tbl_Customer_Advance set DateOFAdvance = '" + DateOFAdvance + "' ,Amount = '" + Amount + "' ,Remark = '" + remark + "' , " +
                                   " UploadDate = '" + UploadDate + "',Uploadby = '" + UserInfo.UserName + "',SynID = 2 " +
                                   " where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MyID + "' ";
                DataAccess.ExecuteSQL(SqlUpdate);
                Datasyncpso.insert_Live_sync(SqlUpdate, "tbl_Customer_Advance", "UPDATE");
            }

            Cusromer_AdvancePay go = new Cusromer_AdvancePay();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.CustomerID = lblCustomerID.Text;
            go.CustomerName = txtCustomerName.Text;
            go.Show();

            this.Close();
        }

        public void EditDate(int MYID)
        {
            string sqlselect = " select * from tbl_Customer_Advance where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MYID + "' ";
            DataTable Dtselect = DataAccess.GetDataTable(sqlselect);
            if (Dtselect.Rows.Count > 0)
            {
                DateTime DateOFAdvance = Convert.ToDateTime(Dtselect.Rows[0]["DateOFAdvance"]);
                dtDateOFAdvance.Text = DateOFAdvance.ToString("yyyy-MM-dd");


            }
        }

        private void datagridEyeHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridAdvanceHistory.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                //foreach (DataGridViewRow row in datagridAdvanceHistory.SelectedRows)
                //{
                //    int MYID = Convert.ToInt32(row.Cells["ID"].Value.ToString());

                //    string sqlselect = " select * from tbl_Customer_Advance where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MYID + "' ";
                //    DataTable Dtselect = DataAccess.GetDataTable(sqlselect);
                //    if (Dtselect.Rows.Count > 0)
                //    {
                //        string SqlDelete = " Delete from tbl_Customer_Advance where TenentID = " + Tenent.TenentID + " and CustomerID = '" + lblCustomerID.Text + "' and MyID = '" + MYID + "' ";

                //        DataAccess.ExecuteSQL(SqlDelete);
                //        Datasyncpso.insert_Live_sync(SqlDelete, "tbl_Customer_Advance", "DELETE");

                //        DataBind();

                //    }

                //}
            }
            else if (e.ColumnIndex == datagridAdvanceHistory.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                //foreach (DataGridViewRow row in datagridAdvanceHistory.SelectedRows)
                //{
                //    int MYID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                //    lblMyID.Text = MYID.ToString();
                //    EditDate(MYID);
                //}
            }
            else
            {
                foreach (DataGridViewRow row in datagridAdvanceHistory.SelectedRows)
                {
                    int MYID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                    lblMyID.Text = MYID.ToString();
                    EditDate(MYID);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cusromer_AdvancePay go = new Cusromer_AdvancePay();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.CustomerID = lblCustomerID.Text;
            go.CustomerName = txtCustomerName.Text;
            go.Show();

            this.Close();
        }

        private void txtLAxisReading_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'' || e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
              // if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
              // {
              //     e.Handled = true;
              //
              // }
              // else
              // {
              //     e.Handled = false;
              // }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

    }
}
