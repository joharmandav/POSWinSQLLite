using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Transactions;


namespace supershop
{
    public partial class Delete_Invoice : Form
    {
        public Delete_Invoice()
        {
            InitializeComponent();
            lblEmpID.Text = UserInfo.UserName;
        }

        public string OrderNO
        {
            set
            {
                txtbarcodeinputer.Text = value;
                btnSearch();
            }
            get
            {
                return txtbarcodeinputer.Text;
            }
        }

        private void Delete_Invoice_Load(object sender, EventArgs e)
        {
            if (UserInfo.usertype != "1")
            {
                MessageBox.Show("you are not authorized Allow Delete invoice ");
                this.Close();
            }

            try
            {
                SalesRegister.Check_OpeningBalance();

                int year = DateTime.Now.Year;
                string shopid = UserInfo.Shopid;

                if (lblorderNO.Text == "-")
                {

                }
                else
                {
                    txtbarcodeinputer.Text = lblorderNO.Text;
                }


                dtReturnDate.Format = DateTimePickerFormat.Custom;
                dtReturnDate.CustomFormat = "yyyy-MM-dd";

                //txtDisRate.Text = vatdisvalue.dis;
                // // Add new Colunm header Name
                // this.dtgrdviewReturnItem.Columns.Add("itm", "Items Name");
                // this.dtgrdviewReturnItem.Columns.Add("Am", "Price");
                // this.dtgrdviewReturnItem.Columns.Add("Qty", "Quantity");
                // this.dtgrdviewReturnItem.Columns.Add("Total", "Total");
                // this.dtgrdviewReturnItem.Columns.Add("ID", "ID");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// //// Add/insert Return items  //////////////////////
        public void DeleteInvoice()
        {
            int rows = dtgrdviewReturnItem.Rows.Count;

            int IsWastage = 0;
            if (chkWastage.Checked == true)
            {
                IsWastage = 1;
            }
            else
            {
                IsWastage = 0;
            }

            string return_time = dtReturnDate.Text;
            DateTime return_time1 = Convert.ToDateTime(return_time);
            return_time = return_time1.ToString("yyyy-MM-dd HH:mm:ss");

            string InvoiceNo = lblInvoiceNO.Text;
            string sales_id = lblsalesID.Text;
            string emp = lblEmpID.Text;
            string Customer = lblCustomerName.Text;
            double Vat = 0;

            string sqlsele = "Select * from sales_item where sales_id  = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
            DataTable DtSele = DataAccess.GetDataTable(sqlsele);

            if (DtSele.Rows.Count > 0)
            {
                string PaymentMode = DtSele.Rows[0]["PaymentMode"].ToString();

                if (PaymentMode != "Draft")
                {
                    for (int i = 0; i < rows; i++)
                    {
                        
                        double Qty = Convert.ToDouble(dtgrdviewReturnItem.Rows[i].Cells["Qty"].Value.ToString());                                               
                        string itemcode = dtgrdviewReturnItem.Rows[i].Cells["itemcode"].Value.ToString(); //itemcode
                        string UOMID = dtgrdviewReturnItem.Rows[i].Cells["UOM"].Value.ToString();
                        string BatchNo = dtgrdviewReturnItem.Rows[i].Cells["BatchNO"].Value.ToString();

                        int TenentID = Tenent.TenentID;

                        if (chkWastage.Checked == false)
                        {
                            string itemids = itemcode.ToString();
                            double qtyupdate = Convert.ToDouble(Qty);

                            double PID = Convert.ToDouble(itemids);
                            int SelctUOM = Convert.ToInt32(UOMID);
                            double QtyConv = qtyupdate;

                            string AllUOMConv = "";

                            int BaseUOM = Purchase.GetBaseUOM(PID);

                            if (BaseUOM == 0)
                            {
                                BaseUOM = SelctUOM;
                                AllUOMConv = SelctUOM.ToString();
                            }
                            else
                            {
                                bool Check = Add_Item.Check_CalculateAspectRatio_allow(BaseUOM);
                                if (Check == true)
                                {
                                    AllUOMConv = Purchase.getAllUomOfproduct(PID);
                                }
                                else
                                {
                                    AllUOMConv = SelctUOM.ToString();
                                }
                            }

                            double BaseQty = QtyConv;
                            if (SelctUOM != BaseUOM)
                            {
                                BaseQty = Purchase.getConversionBaseQty(BaseUOM, SelctUOM, QtyConv);
                            }

                            string[] ListUOM = AllUOMConv.Split(',');

                            for (int j = 0; j < ListUOM.Length; j++)
                            {
                                double newQty = QtyConv;

                                int ToUOM = Convert.ToInt32(ListUOM[j]);
                                string UOMNAme = Add_Item.getuomName(ToUOM);
                                if (ToUOM != SelctUOM)
                                {
                                    if (ToUOM == BaseUOM)
                                    {
                                        newQty = BaseQty;
                                    }
                                    else
                                    {
                                        newQty = Purchase.getConversionToQty(BaseUOM, ToUOM, BaseQty);
                                    }
                                }

                                string sqlupdateQty1 = "select *  FROM  tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID = '" + itemcode + "' and UOMID='" + ToUOM + "' ";
                                DataTable dtUqty1 = DataAccess.GetDataTable(sqlupdateQty1);

                                double product_quantity = Convert.ToDouble(dtUqty1.Rows[0]["OnHand"].ToString()) + newQty;
                                double QtyOut = Convert.ToDouble(dtUqty1.Rows[0]["QtyOut"].ToString()) - newQty;
                                double QtyRecived = Convert.ToDouble(dtUqty1.Rows[0]["QtyRecived"].ToString()) + newQty;

                                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                string sql = " update tbl_item_uom_price set " +
                                           " OnHand = '" + product_quantity + "',QtyOut='" + QtyOut + "',QtyRecived='" + QtyRecived + "', " +
                                          " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                           " where TenentID= " + Tenent.TenentID + " and itemID = '" + itemcode + "' and UOMID='" + ToUOM + "' ";
                                DataAccess.ExecuteSQL(sql);

                                string sqlwin = " update Win_tbl_item_uom_price set " +
                                             " OnHand = '" + product_quantity + "',QtyOut='" + QtyOut + "',QtyRecived='" + QtyRecived + "', " +
                                            " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                             " where TenentID= " + Tenent.TenentID + " and itemID = '" + itemcode + "' and UOMID='" + ToUOM + "' ";
                                Datasyncpso.insert_Live_sync(sqlwin, "Win_tbl_item_uom_price", "UPDATE");
                            }
                        }

                        double prodid = Convert.ToDouble(itemcode);
                        bool flag = SalesRegister.IsPerishable(prodid);
                        if (flag == true)
                        {
                            int UOMID1 = Convert.ToInt32(UOMID);
                            int QTY1 = Convert.ToInt32(Qty);
                            //string BatchNo = GetBatchNo(sales_id, prodid, UOMID);
                            if (chkWastage.Checked == false)
                            {
                                Update_ICIT_BR_Perishable(prodid, UOMID1, BatchNo, QTY1);
                            }
                        }
                        bool flags = SalesRegister.IsSerialize(prodid);
                        if (flags == true)
                        {
                            int UOMID1 = Convert.ToInt32(UOMID);
                            int QTY1 = Convert.ToInt32(Qty);
                            //string BatchNo = GetBatchNo(sales_id, prodid, UOMID);
                            if (chkWastage.Checked == false)
                            {
                                string[] SerialList = BatchNo.Split('~');
                                for (int j = 0; j < SerialList.Count();j++ )
                                {
                                    Update_ICIT_BR_Serialize(prodid, UOMID1, SerialList[j].ToString().Trim(), QTY1);
                                }
                                    
                            }
                        }
                    }

                    decimal ShiftReturn = Convert.ToDecimal(lblPaidAmount.Text);
                    Update_ShiftReturn_DayClose(ShiftReturn);
                }

                //string sql3 = "Delete from sales_item where sales_id  = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
                string sql3 = "update sales_item set Deleted=1 where sales_id  = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sql3);

                //string sqlUpdateCmdWIN = " delete from Win_sales_item where sales_id  = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
                string sqlUpdateCmdWIN = " update Win_sales_item set Deleted=1 where sales_id  = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "Win_sales_item", "DELETE");

                //string sqlDeletePayment = "Delete from sales_payment where sales_id  = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
                string sqlDeletePayment = "update sales_payment set Deleted=1 where sales_id  = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sqlDeletePayment);

                //string sqlWIN = " delete from Win_sales_payment where sales_id  = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
                string sqlWIN = " update Win_sales_payment set Deleted=1 where sales_id  = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sqlWIN, "Win_sales_payment", "DELETE");

               
            }

        }

        public void Update_ICIT_BR_Perishable(double MyProdID, int uom, string Batch_No, int qty1)
        {
            string query = "select * from ICIT_BR_Perishable where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and BatchNo='" + Batch_No + "' ";
            DataTable dtquery = DataAccess.GetDataTable(query);
            if (dtquery.Rows.Count > 0)
            {
                int Onhandold = Convert.ToInt32(dtquery.Rows[0]["OnHand"]);
                int QtyReceivedold = Convert.ToInt32(dtquery.Rows[0]["QtyReceived"]);

                int OnHand = Onhandold + qty1;
                int QtyReceived = qty1 + QtyReceivedold;

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql1 = "Update ICIT_BR_Perishable set OnHand='" + OnHand + "',QtyReceived='" + QtyReceived + "',  " +
                          " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                          " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and BatchNo='" + Batch_No + "'  ";
                DataAccess.ExecuteSQL(sql1);
                Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Perishable", "UPDATE");
            }
        }
        public void Update_ICIT_BR_Serialize(double MyProdID, int uom, string Serial_Number, int qty1)
        {
            string query = "select * from ICIT_BR_Serialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "' ";
            DataTable dtquery = DataAccess.GetDataTable(query);
            if (dtquery.Rows.Count > 0)
            {
                int Onhandold = Convert.ToInt32(dtquery.Rows[0]["OnHand"]);
                int QtyReceivedold = Convert.ToInt32(dtquery.Rows[0]["QtyReceived"]);

                int OnHand = Onhandold + qty1;
                int QtyReceived = qty1 + QtyReceivedold;

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql1 = "Update ICIT_BR_Serialize set OnHand='" + 1 + "',QtyReceived='" + 1 + "',  " +
                          " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                          " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "'  ";
                DataAccess.ExecuteSQL(sql1);
                Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Serialize", "UPDATE");
            }
        }

        private void ClearForm2()
        {
            Delete_Invoice go = new Delete_Invoice();
            go.MdiParent = this.ParentForm;
            go.Show();
            this.Close();
        }

        private void ReturnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete This Transation ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteInvoice();

                    string ActivityName = "Delete Invoice";
                    string LogData = "Delete Invoice with InvoiceNO = " + lblInvoiceNO.Text + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                    MessageBox.Show("Successfully Delete Invoice \n   ....... ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ClearForm2();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        public void Update_ShiftReturn_DayClose(decimal ShiftReturn)
        {
            int ShiftID = UserInfo.ShiftID;

            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sql5 = "Select * from DayClose where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                decimal ShiftReturnold = Convert.ToDecimal(dt5.Rows[0]["ShiftReturn"]);
                ShiftReturn = ShiftReturn + ShiftReturnold;

                string sql1 = " Update DayClose set ShiftReturn=" + ShiftReturn + " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'  ";
                DataAccess.ExecuteSQL(sql1);

                string sqlWin = "  Update DayClose set ShiftReturn=" + ShiftReturn + " " +
                      " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'  ";
                Datasyncpso.insert_Live_sync(sqlWin, "DayClose", "UPDATE");

                DataAccess.Update_ShiftCIH_DayClose();
            }

        }

        public void salePaymentinfo()
        {
            try
            {
                string sqlCmd = " Select  si.sales_id , sum(change_amount) as change_amount , sum(due_amount) as due_amount , sum(dis) as dis, sum(vat) as vat , " +
                                " si.sales_time , si.c_id, emp_id , comment , si.ShopId , payment_type , sum(payment_amount) as payment_amount, " +
                                " sum(ovdisrate) as ovdisrate, sum(vaterate) as vaterate " +
                                " from  sales_item si left join sales_payment sp on si.TenentID = sp.TenentID and  si.sales_id = sp.sales_id " +
                                " where si.TenentID = " + Tenent.TenentID + " and  lower(si.InvoiceNO) = '" + txtbarcodeinputer.Text.ToLower() + "' " +
                                " group by si.sales_id";
               
                DataTable dt = DataAccess.GetDataTable(sqlCmd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string paymenttype = "";
                    string sql = " Select * from sales_payment where TenentID = " + Tenent.TenentID + " and InvoiceNO  = '" + txtbarcodeinputer.Text + "'";                    
                    DataTable dt1 = DataAccess.GetDataTable(sql);

                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        string paytype = dt1.Rows[j]["payment_type"].ToString();
                        paymenttype += paytype + ",";
                    }

                    paymenttype = paymenttype.Trim();
                    paymenttype = paymenttype.TrimEnd(',');

                    lblpaytype.Text = paymenttype != "" ? paymenttype : "Draft";

                    DataRow dataReader = dt.Rows[i];

                    lblsalesID.Text = dataReader["sales_id"].ToString();
                    lblDue.Text =  dataReader["due_amount"]!=null &&  dataReader["due_amount"].ToString()!=""? dataReader["due_amount"].ToString():"0";
                    lblChange.Text = dataReader["change_amount"]!=null && dataReader["change_amount"].ToString()!=""? dataReader["change_amount"].ToString():"0";
                    lblsalestime.Text = dataReader["sales_time"].ToString();                    
                    lblShopid.Text = dataReader["ShopId"].ToString();                    
                    lblCustID.Text = dataReader["c_id"].ToString();                    
                    double Paid = Convert.ToDouble(dataReader["payment_amount"].ToString()) - Convert.ToDouble(dataReader["due_amount"].ToString());
                    lblPaidAmount.Text = Paid.ToString();

                }

            }
            catch
            {
            }
        }

        public void btnSearch()
        {
            try
            {
                double Taxrate = 0;// Convert.ToDouble(txtVATRate.Text); // Convert.ToDouble(vatdisvalue.vat);

                // Items rows
                // string sqlitems = " select ItemName, RetailsPrice, Qty, Total , itemcode from sales_item where sales_id = '" + txtbarcodeinputer.Text + "' ";
                string sqlitems = " Select (ItemName ||' ` '|| UOM) as Name,ItemName,UOM, RetailsPrice, Qty as 'Qty',Total as 'Total' , (((RetailsPrice * Qty ) * discount) / 100.00) as 'disamt'," +
                                  " Customer,discount , itemcode, item_id,BatchNO " +
                                  " FROM sales_item where TenentID = " + Tenent.TenentID + " and lower(InvoiceNO) = '" + txtbarcodeinputer.Text.ToLower() + "' and ((status = 1 and Qty != 0) " +
                                  " or (status = 3  and Qty != 0))";

                DataTable dtItems = DataAccess.GetDataTable(sqlitems);
                dtgrdviewReturnItem.DataSource = dtItems;

                if (dtItems.Rows.Count > 0)
                {
                    lblInvoiceNO.Text = txtbarcodeinputer.Text;
                }

                ////Hide fields 
                dtgrdviewReturnItem.Columns["ItemName"].Visible = false;
                dtgrdviewReturnItem.Columns["UOM"].Visible = false;
                dtgrdviewReturnItem.Columns["disamt"].Visible = false; // Disamt         // new in 8.1 version 5                
                dtgrdviewReturnItem.Columns["discount"].Visible = false; // Discount rate  // new in 8.1 version 7
                dtgrdviewReturnItem.Columns["itemcode"].Visible = false; // itemcode             // new in 8.1 version 9
                dtgrdviewReturnItem.Columns["item_id"].Visible = false; // sold_item_ID    item_id          // new in 8.3 version 10
                dtgrdviewReturnItem.Columns["Customer"].Visible = false;

                //dtgrdviewReturnItem.Columns["Name"].Width = 220;

                if (dtItems.Rows.Count > 0)
                {
                    lblCustomerName.Text = dtItems.Rows[0]["Customer"].ToString();
                }
                else
                {
                    lblCustomerName.Text = "Cash";
                }

                salePaymentinfo();

            }
            catch
            {
                lblCustID.Text = "10000009";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSearch();
        }

        //Suspen trx 
        private void Suspen_Click(object sender, EventArgs e)
        {
            try
            {
                dtgrdviewReturnItem.Rows.Clear();
            }
            catch
            {
            }
        }

        //Call system Calculator
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "calc.exe";
                p.Start();
                p.WaitForInputIdle();

            }
            catch
            {
            }
        }

    }
}
