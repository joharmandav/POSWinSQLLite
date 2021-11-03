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
    public partial class Return_product : Form
    {
        public Return_product()
        {
            InitializeComponent();
            lblEmpID.Text = UserInfo.UserName;
            GETreturnID();
        }
        private void ClearForm()
        {
            txtbarcodeinputer.Text = string.Empty;

        }

        public string OrderNO
        {
            set
            {
                lblorderNO.Text = value;
            }
            get
            {
                return lblorderNO.Text;
            }
        }


        // Total VAT , and Discount Calculation
        private void total()
        {
            // // subtotal without dis vat sum 
            double totalsum = 0;
            for (int i = 0; i < dtgrdviewReturnItem.Rows.Count; ++i)
            {
                totalsum += Convert.ToDouble(dtgrdviewReturnItem.Rows[i].Cells["Total"].Value);
            }
            lblTotal.Text = totalsum.ToString();
            double total = Convert.ToDouble(totalsum.ToString());

            ////  Discount amount sum Calculation              
            double DisCount = 0.00;
            for (int i = 0; i < dtgrdviewReturnItem.Rows.Count; ++i)
            {
                DisCount += Convert.ToDouble(dtgrdviewReturnItem.Rows[i].Cells["disamt"].Value);
            }
            DisCount = Math.Round(DisCount, 2);
            lbldis.Text = DisCount.ToString();

            //Overall sold discount / counter discount calculation
            double Discountvalue = Convert.ToDouble(txtDiscountRate.Text);
            double subtotal = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(lbldis.Text); // total - item discount  100 - 5 = 95        
            double totaldiscount = (subtotal * Discountvalue) / 100;  //Counter discount  // 95 * 5 /100 = 4.75  

            double disPlusOverallDiscount = totaldiscount + Convert.ToDouble(lbldis.Text); // 4.75 + 5 = 9.75
            disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 2);
            lbloveralldiscount.Text = disPlusOverallDiscount.ToString();  // Overall discount 9.75

            double subtotalafteroveralldiscount = subtotal - totaldiscount; // 95 - 4.75 = 90.25
            subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 2);
            lblsubtotal.Text = subtotalafteroveralldiscount.ToString();


            ////VAT Calculation              
            double VAT = 0.00;
            for (int i = 0; i < dtgrdviewReturnItem.Rows.Count; ++i)
            {
                VAT += Convert.ToDouble(dtgrdviewReturnItem.Rows[i].Cells["taxamt"].Value);
            }
            VAT = Math.Round(VAT, 2);
            lblvat.Text = VAT.ToString();

            // double Subtotal = total - DisCount;
            double sum = subtotalafteroveralldiscount + VAT;
            sum = Math.Round(sum, 2);
            lblTotalReturn.Text = sum.ToString();
            txtReturnAmount.Text = lblTotalReturn.Text;
        }


        private void Return_product_Load(object sender, EventArgs e)
        {
            try
            {
                SalesRegister.Check_OpeningBalance();

                int year = DateTime.Now.Year;
                string shopid = UserInfo.Shopid;

                if (lblorderNO.Text == "-")
                {
                    txtbarcodeinputer.Text = year + "/" + shopid + "/";
                }
                else
                {
                    txtbarcodeinputer.Text = lblorderNO.Text;
                }


                dtReturnDate.Format = DateTimePickerFormat.Custom;
                dtReturnDate.CustomFormat = "yyyy-MM-dd";

                txtVATRate.Text = vatdisvalue.vat;
                //txtDisRate.Text = vatdisvalue.dis;
                // // Add new Colunm header Name
                // this.dtgrdviewReturnItem.Columns.Add("itm", "Items Name");
                // this.dtgrdviewReturnItem.Columns.Add("Am", "Price");
                // this.dtgrdviewReturnItem.Columns.Add("Qty", "Quantity");
                // this.dtgrdviewReturnItem.Columns.Add("Total", "Total");
                // this.dtgrdviewReturnItem.Columns.Add("ID", "ID");


                DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                dtgrdviewReturnItem.Columns.Add(del);
                del.HeaderText = "Del";
                del.Text = "X";
                del.Name = "del";
                del.ToolTipText = "Delete item";
                del.UseColumnTextForButtonValue = true;


                DataGridViewButtonColumn minus = new DataGridViewButtonColumn();
                dtgrdviewReturnItem.Columns.Add(minus);
                minus.HeaderText = "Dec";
                minus.Text = "-";
                minus.Name = "minus";
                minus.ToolTipText = "minus Item Qty";
                minus.UseColumnTextForButtonValue = true;

                //Return Reason select * from REFTABLE where tenentid=9000007 and reftype = 'Food' and refsubtype='ReturnReason'
                string sqlReason = "select * from REFTABLE where TenentID = " + Tenent.TenentID + " and reftype = 'Food' and refsubtype='ReturnReason'  ";
                DataTable dtReason = DataAccess.GetDataTable(sqlReason);
                comboReason.DataSource = dtReason;
                comboReason.DisplayMember = "REFNAME1";
                comboReason.ValueMember = "REFID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void disDecrease_Click(object sender, EventArgs e)  // // vat decrease
        {
            if (txtReturnAmount.Text == "")
            {
                MessageBox.Show("Please Add at least One Item");
            }
            else
            {
                double Discountvalue = Convert.ToDouble(txtDiscountRate.Text) - 1;
                txtDiscountRate.Text = Discountvalue.ToString();
                double subtotal = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(lbldis.Text); // total - item discount  100 - 5 = 95        
                double totaldiscount = (subtotal * Discountvalue) / 100;  //Counter discount  // 95 * 5 /100 = 4.75  
                double disPlusOverallDiscount = totaldiscount + Convert.ToDouble(lbldis.Text); // 4.75 + 5 = 9.75
                disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 2);
                lbloveralldiscount.Text = disPlusOverallDiscount.ToString();  // Overall discount 9.75

                double subtotalafteroveralldiscount = subtotal - totaldiscount; // 95 - 4.75 = 90.25
                subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 2);
                lblsubtotal.Text = subtotalafteroveralldiscount.ToString();

                double payable = subtotalafteroveralldiscount + Convert.ToDouble(lblvat.Text);
                payable = Math.Round(payable, 2);
                lblTotalReturn.Text = payable.ToString();

                txtReturnAmount.Text = lblTotalReturn.Text;
            }
        }

        private void disIncreasebtn_Click(object sender, EventArgs e)   // Discount Increase 
        {
            if (txtReturnAmount.Text == "")
            {
                MessageBox.Show("Please Add at least One Item");
            }
            else
            {
                double Discountvalue = Convert.ToDouble(txtDiscountRate.Text) + 1;
                txtDiscountRate.Text = Discountvalue.ToString();
                double subtotal = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(lbldis.Text); // total - item discount  100 - 5 = 95        
                double totaldiscount = (subtotal * Discountvalue) / 100;  //Counter discount  // 95 * 5 /100 = 4.75  

                double disPlusOverallDiscount = totaldiscount + Convert.ToDouble(lbldis.Text); // 4.75 + 5 = 9.75
                disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 2);
                lbloveralldiscount.Text = disPlusOverallDiscount.ToString();  // Overall discount 9.75

                double subtotalafteroveralldiscount = subtotal - totaldiscount; // 95 - 4.75 = 90.25
                subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 2);
                lblsubtotal.Text = subtotalafteroveralldiscount.ToString();

                double payable = subtotalafteroveralldiscount + Convert.ToDouble(lblvat.Text);
                payable = Math.Round(payable, 2);
                lblTotalReturn.Text = payable.ToString();

                txtReturnAmount.Text = lblTotalReturn.Text;
                //double vatvalue = Convert.ToDouble(txtVATRate.Text) + 1;
                //txtVATRate.Text = vatvalue.ToString();
                //  total();
            }
        }

        public int GETreturnID()
        {
            int return_id = 1;
            //"SELECT row  FROM table WHERE id=(    SELECT max(id) FROM table    )"
            string sqlreturn = "select distinct return_id from  return_item WHERE TenentID = " + Tenent.TenentID + " and return_id = (SELECT max(return_id) FROM return_item where TenentID = " + Tenent.TenentID + " )";
            DataAccess.ExecuteSQL(sqlreturn);
            DataTable dtsql = DataAccess.GetDataTable(sqlreturn);

            if (dtsql.Rows.Count > 0)
            {
                int Count = Convert.ToInt32(dtsql.Rows[0][0]);
                return_id = Count + 1;
                lblReturnID.Text = return_id.ToString();
            }
            else
            {
                return_id = 1;
                lblReturnID.Text = return_id.ToString();
            }
            return return_id;
        }

        /// //// Add/insert Return items  //////////////////////
        public void Return_item()
        {
            int rows = dtgrdviewReturnItem.Rows.Count;

            int return_id = GETreturnID();

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
            double disamt = Convert.ToDouble(lbloveralldiscount.Text);
            double Vat = 0;

            for (int i = 0; i < rows; i++)
            {
                //ItemName, RetailsPrice, Qty, Total , item_id

                string itemName = dtgrdviewReturnItem.Rows[i].Cells["ItemName"].Value.ToString();
                double RetailsPrice = Convert.ToDouble(dtgrdviewReturnItem.Rows[i].Cells["RetailsPrice"].Value.ToString());
                double Qty = Convert.ToDouble(dtgrdviewReturnItem.Rows[i].Cells["Qty"].Value.ToString());
                double Total = Convert.ToDouble(dtgrdviewReturnItem.Rows[i].Cells["Total"].Value.ToString());
                double vatamt = Convert.ToDouble(dtgrdviewReturnItem.Rows[i].Cells["taxamt"].Value.ToString());
                Vat = Vat + vatamt;
                string itemcode = dtgrdviewReturnItem.Rows[i].Cells["itemcode"].Value.ToString(); //itemcode
                string SoldID = dtgrdviewReturnItem.Rows[i].Cells["item_id"].Value.ToString();  //Single sales item id
                string UOMID = dtgrdviewReturnItem.Rows[i].Cells["UOM"].Value.ToString();
                string BatchNo = dtgrdviewReturnItem.Rows[i].Cells["BatchNO"].Value.ToString();

                int TenentID = Tenent.TenentID;

                int ID = DataAccess.getReturnMYid(TenentID, return_id.ToString());

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql1 = " insert into return_item (TenentID,ID, return_id,item_id, itemName, Qty, RetailsPrice, Total, return_time, custno, emp, SoldInvoiceNo, Comment, disamt , vatamt,UOM,Customer,ReturnReason,IsWastage,BatchNO,Uploadby ,UploadDate ,SynID) " +
                              " values (" + Tenent.TenentID + ",'" + ID + "'," + return_id + ", '" + itemcode + "', '" + itemName + "', '" + Qty + "', '" + RetailsPrice + "' , '" + Total + "', '" + return_time + "',   " +
                              " '" + lblCustID.Text + "', '" + emp + "' , '" + InvoiceNo + "', '" + txtComment.Text + "', '" + disamt + "', '" + vatamt + "', '" + UOMID + "' ,'" + Customer + "','" + comboReason.Text + "'," + IsWastage + ",'" + BatchNo + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                DataAccess.ExecuteSQL(sql1);

                string sql1Win = " insert into Win_return_item (TenentID,ID, return_id,item_id, itemName, Qty, RetailsPrice, Total, return_time, custno, emp, SoldInvoiceNo, Comment, disamt , vatamt,UOM,Customer,ReturnReason,IsWastage,BatchNO,Uploadby ,UploadDate ,SynID) " +
                              " values (" + Tenent.TenentID + ",'" + ID + "'," + return_id + ", '" + itemcode + "', '" + itemName + "', '" + Qty + "', '" + RetailsPrice + "' , '" + Total + "', '" + return_time + "',   " +
                              " '" + lblCustID.Text + "', '" + emp + "' , '" + InvoiceNo + "', '" + txtComment.Text + "', '" + disamt + "', '" + vatamt + "', '" + UOMID + "' ,'" + Customer + "','" + comboReason.Text + "'," + IsWastage + ",'" + BatchNo + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                Datasyncpso.insert_Live_sync(sql1Win, "Win_return_item", "INSERT");

                // Update Quantity | Increase Quantity to Purchase table 


                //string sql = " update purchase set " +
                //                " product_quantity = '" + product_quantity + "',UploadDate = null,Uploadby = null,SyncDate = null,Syncby = null  where product_id = '" + itemcode + "' ";
                //DataAccess.ExecuteSQL(sql);

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


                string sqlSalesQTY = " select returnQty from sales_item  where TenentID= " + Tenent.TenentID + " and sales_id = '" + sales_id + "' and item_id = '" + SoldID + "' and UOM = '" + UOMID + "' ";
                DataAccess.ExecuteSQL(sqlSalesQTY);
                DataTable dtSalesQTY = DataAccess.GetDataTable(sqlSalesQTY);

                double SalesQTY = Convert.ToDouble(dtSalesQTY.Rows[0].ItemArray[0].ToString()) + Qty;
                double totalsale = SalesQTY * RetailsPrice;


               

                double prodid = Convert.ToDouble(itemcode);
                bool flag = SalesRegister.IsPerishable(prodid);
                if (flag == true)
                {
                    string sqlSIstatus = " update sales_item set " +
                                     " returnQty = '" + SalesQTY + "' , returnTotal  = '" + totalsale + "'  , OrderStutas='Return', " +
                                     " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                     " where TenentID= " + Tenent.TenentID + " and sales_id = '" + sales_id + "' and item_id = '" + SoldID + "' and UOM = '" + UOMID + "' and BatchNo='" + BatchNo + "' ";

                    DataAccess.ExecuteSQL(sqlSIstatus);

                    string sqlSIstatusWin = " update Win_sales_item set " +
                                          " returnQty = '" + SalesQTY + "' , returnTotal  = '" + totalsale + "'  , OrderStutas='Return', " +
                                          " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                          " where TenentID= " + Tenent.TenentID + " and sales_id = '" + sales_id + "' and item_id = '" + SoldID + "' and UOM = '" + UOMID + "' and BatchNo='" + BatchNo + "' ";
                    Datasyncpso.insert_Live_sync(sqlSIstatusWin, "Win_sales_item", "UPDATE");

                    int UOMID1 = Convert.ToInt32(UOMID);
                    int QTY1 = Convert.ToInt32(Qty);
                    //string BatchNo = GetBatchNo(sales_id, prodid, UOMID);
                    if (chkWastage.Checked == false)
                    {
                        Update_ICIT_BR_Perishable(prodid, UOMID1, BatchNo, QTY1);
                    }
                }
                double prodidserial = Convert.ToDouble(itemcode);
                bool flagserial = SalesRegister.IsSerialize(prodidserial);
                if (flagserial == true)
                {
                    string sqlSIstatus = " update sales_item set " +
                                    " returnQty = '" + SalesQTY + "' , returnTotal  = '" + totalsale + "'  , OrderStutas='Return', " +
                                    " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 ,BatchNo='" + BatchNo + "'" +
                                    " where TenentID= " + Tenent.TenentID + " and sales_id = '" + sales_id + "' and item_id = '" + SoldID + "' and UOM = '" + UOMID + "' ";

                    DataAccess.ExecuteSQL(sqlSIstatus);

                    string sqlSIstatusWin = " update Win_sales_item set " +
                                          " returnQty = '" + SalesQTY + "' , returnTotal  = '" + totalsale + "'  , OrderStutas='Return', " +
                                          " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                          " where TenentID= " + Tenent.TenentID + " and sales_id = '" + sales_id + "' and item_id = '" + SoldID + "' and UOM = '" + UOMID + "' ";
                    Datasyncpso.insert_Live_sync(sqlSIstatusWin, "Win_sales_item", "UPDATE");

                    int UOMID1 = Convert.ToInt32(UOMID);
                    int QTY1 = Convert.ToInt32(Qty);
                    
                    if (chkWastage.Checked == false)
                    {
                        string[] SerialList = BatchNo.Split('~');
                        for (int j = 0; j < SerialList.Count(); j++)
                        {
                            Update_ICIT_BR_Serialize(prodid, UOMID1, SerialList[j].ToString().Trim(), QTY1);
                        }
                    }
                }
            }

            string Reffrance = "";
            string txtInvoice = lblsalesID.Text;
            string Comment = txtComment.Text;
            decimal returnamt = Convert.ToDecimal(txtReturnAmount.Text);
            string payment_amount = (0 - returnamt).ToString();
            string overalldisRate = txtDiscountRate.Text;
            string vatRate = txtVATRate.Text;

            int ID1 = DataAccess.getPaymentid(Tenent.TenentID, lblsalesID.Text);

            string UploadDate1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlPayment = " insert into sales_payment (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                           " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID) " +
                           "  values (" + Tenent.TenentID + "," + ID1 + ",'" + txtInvoice + "'," + return_id + ",'" + CmbPayType.Text + "','" + Reffrance + "' , '" + payment_amount + "', '" + 0 + "', " +
                           " '" + 0 + "', '" + disamt + "', '" + Vat + "', '" + return_time + "', '" + lblCustID.Text + "', " +
                           "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + InvoiceNo + "','" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate1 + "'  , 1 )";
            DataAccess.ExecuteSQL(sqlPayment);

            string sqlPaymentWin = " insert into Win_sales_payment (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                           " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID) " +
                           "  values (" + Tenent.TenentID + "," + ID1 + ",'" + txtInvoice + "'," + return_id + ",'" + CmbPayType.Text + "','" + Reffrance + "' , '" + payment_amount + "', '" + 0 + "', " +
                           " '" + 0 + "', '" + disamt + "', '" + Vat + "', '" + return_time + "', '" + lblCustID.Text + "', " +
                           "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + InvoiceNo + "','" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate1 + "'  , 1 )";
            Datasyncpso.insert_Live_sync(sqlPaymentWin, "Win_sales_payment", "INSERT");

            decimal ShiftReturn = Convert.ToDecimal(payment_amount);
            Update_ShiftReturn_DayClose(ShiftReturn);

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
        //public string GetBatchNo(int sales_id, int MyProdID, string UOM_Name)
        //{
        //    //sales_id,itemcode,UOM
        //    string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and sales_id='" + sales_id + "' and itemcode='" + MyProdID + "' and UOM='" + UOM_Name + "' ";
        //    DataAccess.ExecuteSQL(sql3);
        //    DataTable dt3 = DataAccess.GetDataTable(sql3);
        //    string BatchNo = "";
        //    if (dt3.Rows.Count > 0)
        //    {
        //        if (dt3.Rows[0]["BatchNo"] != null && dt3.Rows[0]["BatchNo"] != "")
        //        {
        //            BatchNo = dt3.Rows[0]["BatchNo"].ToString();
        //        }
        //    }
        //    return BatchNo;
        //}

        private void ClearForm2()
        {
            Return_product go = new Return_product();
            go.MdiParent = this.ParentForm;
            go.Show();
            this.Close();
        }

        private void ReturnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Complete Return ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (txtReturnAmount.Text == "" || lblInvoiceNO.Text == "-" || lblTotalReturn.Text == "0")
                {
                    MessageBox.Show("Please Insert  Product and Sold item Invoice / Receipt No ");
                }
                else
                {
                    //try
                    //{
                        //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                        //{
                            Return_item();
                            //  SubtractCredit();

                            string ActivityName = "Return Product";
                            string LogData = "Return Product with InvoiceNO = " + lblInvoiceNO + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            parameter.autoprintid = "1";
                            ReturnPrintRpt go = new ReturnPrintRpt(lblReturnID.Text);
                            go.ShowDialog();

                            MessageBox.Show("Successfully Returned Items  \n   ....... ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            ClearForm2();

                          //  scope.Complete();
                        //}
                    //}
                    //catch (Exception exp)
                    //{
                    //    MessageBox.Show(exp.Message);
                    //}
                }
            }
        }

        public void Update_ShiftReturn_DayClose(decimal ShiftReturn)
        {
            //TenentID,UserID,TrmID,ShiftID,Date,OpAMT,ShiftSales,ShiftReturn,ShiftCIH,VoucharAMT,ExpAMT,ChequeAMT,AMTDelivered,DeliveredTO,RefNO,Notes,UploadDate,
            //Uploadby,	SyncDate,Syncby,SynID

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

        //private void lblCustomerName_TextChanged(object sender, EventArgs e)
        //{
        //    CustomerID();
        //}

        public void CustomerID()
        {
            try
            {
                string sqlCmd = "Select * from  tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = '" + lblCustomerName.Text.Trim() + "'";
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);

                if (dt1.Rows.Count > 0)
                {
                    lblCustID.Text = dt1.Rows[0]["ID"].ToString();
                }
                else
                {
                    lblCustID.Text = "1";
                }
            }
            catch
            {
            }
        }

        public void salePaymentinfo()
        {
            try
            {
                string sqlCmd = " Select  sales_id , sum(change_amount) as change_amount , sum(due_amount) as due_amount , sum(dis) as dis, sum(vat) as vat , sales_time , " +
                                  " c_id, emp_id , comment , TrxType, ShopId , payment_type , sum(payment_amount) as payment_amount, sum(ovdisrate) as ovdisrate, sum(vaterate) as vaterate" +
                                  "  from  sales_payment  where TenentID = " + Tenent.TenentID + " and InvoiceNO  = '" + txtbarcodeinputer.Text + "' group by sales_id";
                DataAccess.ExecuteSQL(sqlCmd);
                DataTable dt = DataAccess.GetDataTable(sqlCmd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string paymenttype = "";
                    string sql = " Select * from sales_payment where TenentID = " + Tenent.TenentID + " and InvoiceNO  = '" + txtbarcodeinputer.Text + "'";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);

                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        string paytype = dt1.Rows[j]["payment_type"].ToString();
                        paymenttype += paytype + ",";
                    }

                    paymenttype = paymenttype.Trim();
                    paymenttype = paymenttype.TrimEnd(',');

                    DataRow dataReader = dt.Rows[i];
                    txtDiscountRate.Text = dataReader["ovdisrate"].ToString();
                    txtVATRate.Text = dataReader["vaterate"].ToString();

                    lblsalesID.Text = dataReader["sales_id"].ToString();
                    lblDue.Text = dataReader["due_amount"].ToString();
                    lblChange.Text = dataReader["change_amount"].ToString();
                    lblsalestime.Text = dataReader["sales_time"].ToString();
                    lbltrxType.Text = dataReader["TrxType"].ToString();
                    lblShopid.Text = dataReader["ShopId"].ToString();
                    lblNote.Text = dataReader["comment"].ToString();
                    // double Ovdiscount = Convert.ToDouble(dataReader["dis"].ToString());
                    // lbloveralldiscount.Text =  Math.Round(Ovdiscount, 2).ToString();
                    lblCustID.Text = dataReader["c_id"].ToString();
                    lblSalesby.Text = dataReader["emp_id"].ToString();
                    lblpaytype.Text = paymenttype;// dataReader["payment_type"].ToString();
                    double Paid = Convert.ToDouble(dataReader["payment_amount"].ToString()) - Convert.ToDouble(dataReader["due_amount"].ToString());
                    lblPaidAmount.Text = Paid.ToString();

                    //lblCustomerName.Text = dataReader["c_id"].ToString();


                }

            }
            catch
            {
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Delete items From Gridview
                if (e.ColumnIndex == dtgrdviewReturnItem.Columns["del"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row2 in dtgrdviewReturnItem.SelectedRows)
                    {
                        DialogResult result = MessageBox.Show("This Item is not returned will remain in original Invoice ,Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (result == DialogResult.Yes)
                        {
                            if (!row2.IsNewRow)
                                dtgrdviewReturnItem.Rows.Remove(row2);
                            total();
                        }
                    }
                }

                // Decrease Item Quantity  -- Add new from 8.3.2
                if (e.ColumnIndex == dtgrdviewReturnItem.Columns["minus"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dtgrdviewReturnItem.SelectedRows)
                    {
                        string itemcode = row.Cells["itemcode"].Value.ToString(); //itemcode
                        double prodid = Convert.ToInt32(itemcode);
                        bool flag = SalesRegister.IsPerishable(prodid);
                        if (flag == true)
                        {

                        }
                        if (Convert.ToDouble(row.Cells["Qty"].Value) > 1)
                        {
                            //// Decrease by 1 
                            double qtySum = Convert.ToDouble(row.Cells["Qty"].Value) - 1;
                            row.Cells["Qty"].Value = qtySum;

                            double qty = Convert.ToDouble(row.Cells["Qty"].Value);
                            double Rprice = Convert.ToDouble(row.Cells["RetailsPrice"].Value);
                            double disrate = Convert.ToDouble(row.Cells["discount"].Value);
                            double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                            //// show total price   Qty  * Rprice
                            double totalPrice = qty * Rprice;
                            row.Cells["Total"].Value = totalPrice;

                            if (Convert.ToDouble(row.Cells["discount"].Value) != 0)
                            {
                                double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                row.Cells["disamt"].Value = Disamt;
                            }

                            if (Convert.ToDouble(row.Cells["Tax"].Value) != 0)
                            {
                                double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                row.Cells["taxamt"].Value = Taxamt;
                            }

                            total();


                        }

                    }
                }



            }
            catch (Exception exp)
            {
                MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void dtgrdviewReturnItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Increase Item Quantity with Edited cell
                if (e.ColumnIndex == dtgrdviewReturnItem.Columns["Qty"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dtgrdviewReturnItem.SelectedRows)
                    {
                        //// Total Price = Qty * RetailsPrice
                        //double totalPrice = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[2].Value);
                        //row.Cells[4].Value = totalPrice;
                        string ItemName = row.Cells["ItemName"].Value.ToString().Trim();
                        string UOMName = row.Cells["UOM"].Value.ToString().Trim();
                        int itemcode = Convert.ToInt32(row.Cells["itemcode"].Value);
                        double qty = Convert.ToDouble(row.Cells["Qty"].Value);
                        int MYTRANSID = Convert.ToInt32(lblsalesID.Text);
                        double prodid = Convert.ToInt32(itemcode);
                        bool flag = SalesRegister.IsSerialize(prodid);
                        if (flag == true)
                        {
                            string Seriallist = row.Cells["BatchNO"].Value.ToString().Trim();
                            if (Application.OpenForms["SalesSerialize"] != null)
                            {
                                Application.OpenForms["SalesSerialize"].Close();
                            }

                            SalesReturnSerialize mkc1 = new SalesReturnSerialize(itemcode, ItemName, UOMName, MYTRANSID, "SRET", Seriallist);
                            mkc1.Qty = qty;
                            mkc1.Show();
                        }

                        double Rprice = Convert.ToDouble(row.Cells["RetailsPrice"].Value);
                        double disrate = Convert.ToDouble(row.Cells["discount"].Value);
                        double Taxrate = Convert.ToDouble(txtVATRate.Text); // Convert.ToDouble(vatdisvalue.vat);

                        //// show total price   Qty  * Rprice
                        double totalPrice = qty * Rprice;
                        row.Cells["Total"].Value = totalPrice;

                        if (Convert.ToDouble(row.Cells["discount"].Value) != 0) // IF discount is not zero then apply discount
                        {
                            double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                            row.Cells["disamt"].Value = Disamt;
                        }

                        if (Convert.ToDouble(row.Cells["Tax"].Value) != 0)  // IF tax is not zero then apply tax
                        {
                            double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                            row.Cells["taxamt"].Value = Taxamt;
                        }

                        total();

                    }
                }
            }
            catch
            {
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                double Taxrate = Convert.ToDouble(txtVATRate.Text); // Convert.ToDouble(vatdisvalue.vat);

                // Items rows
                // string sqlitems = " select ItemName, RetailsPrice, Qty, Total , itemcode from sales_item where sales_id = '" + txtbarcodeinputer.Text + "' ";
                string sqlitems = " Select (ItemName ||' ~ '|| UOM) as Name,ItemName,UOM, RetailsPrice, (Qty - returnQty) as 'Qty', (Total - returnTotal) as 'Total' , (((RetailsPrice * Qty ) * discount) / 100.00) as 'disamt' ,Customer,  " +
                " CASE     " +
                " WHEN taxapply = 1 THEN   ((((RetailsPrice * (Qty - returnQty) )  - (((RetailsPrice * (Qty - returnQty) ) * discount) / 100.00)) * " + Taxrate + " ) / 100.00 )  " +
                " ELSE '0.00'  " +
                " END 'taxamt', discount , taxapply as 'Tax' , itemcode, item_id,BatchNO " +
                " FROM sales_item where TenentID = " + Tenent.TenentID + " and (InvoiceNO = '" + txtbarcodeinputer.Text + "' and status = 1 and (Qty - returnQty) != 0) " +
                " or (InvoiceNO = '" + txtbarcodeinputer.Text + "' and status = 3  and (Qty - returnQty) != 0)";
                DataAccess.ExecuteSQL(sqlitems);
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
                dtgrdviewReturnItem.Columns["taxamt"].Visible = false; // taxamt         // new in 8.1 version 6
                dtgrdviewReturnItem.Columns["discount"].Visible = false; // Discount rate  // new in 8.1 version 7
                dtgrdviewReturnItem.Columns["itemcode"].Visible = false; // itemcode             // new in 8.1 version 9
                dtgrdviewReturnItem.Columns["item_id"].Visible = false; // sold_item_ID    item_id          // new in 8.3 version 10
                dtgrdviewReturnItem.Columns["Customer"].Visible = false;


                dtgrdviewReturnItem.Columns["del"].Width = 35;
                dtgrdviewReturnItem.Columns["minus"].Width = 35;
                dtgrdviewReturnItem.Columns["Name"].Width = 220;
                dtgrdviewReturnItem.Columns["Tax"].Width = 40;

                if (dtItems.Rows.Count > 0)
                {
                    lblCustomerName.Text = dtItems.Rows[0]["Customer"].ToString();
                }
                else
                {
                    lblCustomerName.Text = "Cash";
                }

                salePaymentinfo();
                total();

                //  lbloveralldiscount.Text   = "0";
                // txtDiscountRate.Text      = "0";


            }
            catch
            {
                lblCustID.Text = "10000009";
                lblTotalReturn.Text = "0";
                txtReturnAmount.Text = "0";
                lbldis.Text = "0";
                lblvat.Text = "0";
                txtComment.Text = "0";
                CmbPayType.Text = " ";
            }
        }

        //Suspen trx 
        private void Suspen_Click(object sender, EventArgs e)
        {
            try
            {
                dtgrdviewReturnItem.Rows.Clear();
                total();
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
                // System.Diagnostics.Process.Start("Calc");
                SendKeys.SendWait(lblTotal.Text);
                Process p = new Process();
                p.StartInfo.FileName = "calc.exe";
                p.Start();
                p.WaitForInputIdle();

            }
            catch
            {
            }
        }

        public string ChangeSerializeForReturn //yogesh
        {
            set
            {
                lblSerialize.Text = value;
            }
        }

        private void lblSerialize_TextChanged(object sender, EventArgs e)
        {
            if (lblSerialize.Text != "-" && lblSerialize.Text != "x")
            {
                if (Serialize.selectSerialize == true)
                {
                    string item = Serialize.item;
                    string Serial_Number = Serialize.Serial_Number;
                    if (dtgrdviewReturnItem.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dtgrdviewReturnItem.Rows)
                        {
                            string ItemsNam = row.Cells[2].Value.ToString().Trim();
                            //string ItemsNam = row.Cells[0].Value.ToString().Trim();

                            if (ItemsNam.Equals(item))
                            {
                                string[] serial = Serial_Number.Split('~');
                                int seriallistcount = Convert.ToInt32(serial.Count());
                                row.Cells["BatchNO"].Value = Serial_Number;
                                row.Cells[4].Value = seriallistcount;
                                break;
                            }
                        }

                        Serialize.selectSerialize = false;
                        Serialize.item = null;
                        Serialize.Serial_Number = null;
                        Serialize.OnHand = 0;

                        lblSerialize.Text = "-";
                    }
                }
            }
            if (lblSerialize.Text == "x")
            {
                if (dtgrdviewReturnItem.Rows.Count > 0)
                {
                    string item = Serialize.item.Trim();

                    foreach (DataGridViewRow row in dtgrdviewReturnItem.Rows)
                    {
                        string ItemsNam = row.Cells[2].Value.ToString().Trim();
                        //string ItemsNam = row.Cells[0].Value.ToString().Trim();

                        if (ItemsNam.Equals(item))
                        {
                            btnSubmit_Click(sender, e);

                        }
                    }
                    Serialize.selectSerialize = false;
                    Serialize.item = null;
                    Serialize.Serial_Number = null;
                    Serialize.OnHand = 0;
                    lblSerialize.Text = "-";
                }
            }
        }

    }
}
