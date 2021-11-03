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
    public partial class Payment : Form
    {
        public Payment(object dataSource, string total, string subtotal, string TotalAmount, string discount, string vat, string DiscountRate, string VatRate, string invoiceNo, string totalitems)
        {
            InitializeComponent();
            dgrvSalesItemList.DataSource = dataSource;
            lblTotalPayable.Text = TotalAmount;
            lblTotal.Text = total;
            lblsubtotal.Text = subtotal;
            lblTotalPayable.Text = TotalAmount;
            lblTotalDisCount.Text = discount;
            lblTotalVAT.Text = vat;
            txtDiscountRate.Text = DiscountRate;
            txtVATRate.Text = VatRate;
            txtPaidAmount.Text = TotalAmount;
            txtInvoice.Text = invoiceNo;
            lblTotalItems.Text = totalitems;
            lbluser.Text = UserInfo.UserName;
            txtPaidAmount.Focus();
        }


        private void Payment_Load(object sender, EventArgs e)
        {
            dtSalesDate.Format = DateTimePickerFormat.Custom;
            dtSalesDate.CustomFormat = "yyyy-MM-dd";
            try
            {
                //Customer Info
                string sqlCust = "select   DISTINCT  *   from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer'";
                DataAccess.ExecuteSQL(sqlCust);
                DataTable dtCust = DataAccess.GetDataTable(sqlCust);
                ComboCustID.DataSource = dtCust;
                ComboCustID.DisplayMember = "Name";
                ComboCustID.Text = "Guest";

                //this.dgrvSalesItemList.Columns.Add("itm", "Items Name");
                //this.dgrvSalesItemList.Columns.Add("Am", "Price");
                //this.dgrvSalesItemList.Columns.Add("Qty", "Qty");
                //this.dgrvSalesItemList.Columns.Add("Total", "Total");
                //this.dgrvSalesItemList.Columns.Add("ID", "ID");
            }
            catch
            {
            }
        }

        //paid amount Input Operation
        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (lblTotalPayable.Text == "")
            {
                // MessageBox.Show("please insert Amount ");
            }
            else
            {
                try
                {
                    if (Convert.ToDouble(txtPaidAmount.Text) >= Convert.ToDouble(lblTotalPayable.Text))
                    {
                        double changeAmt = Convert.ToDouble(txtPaidAmount.Text) - Convert.ToDouble(lblTotalPayable.Text);
                        changeAmt = Math.Round(changeAmt, 2);
                        txtChangeAmount.Text = changeAmt.ToString();
                        txtDueAmount.Text = "0";
                    }
                    if (Convert.ToDouble(txtPaidAmount.Text) <= Convert.ToDouble(lblTotalPayable.Text))
                    {
                        double changeAmt = Convert.ToDouble(lblTotalPayable.Text) - Convert.ToDouble(txtPaidAmount.Text);
                        changeAmt = Math.Round(changeAmt, 2);
                        txtDueAmount.Text = changeAmt.ToString();
                        txtChangeAmount.Text = "0";
                    }

                }
                catch //(Exception exp)
                {
                    // MessageBox.Show(exp.Message);
                }

            }
        }

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtPaidAmount.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch
            {
            }
        }

        #region Data save
        /// //// Add sales item  ////////////Store into sales_item table //////////
        public bool sales_item()
        {
            int rows = dgrvSalesItemList.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                string SalesDate = dtSalesDate.Text;
                string trno = txtInvoice.Text;
                string itemid = dgrvSalesItemList.Rows[i].Cells[4].Value.ToString();
                string itNam = dgrvSalesItemList.Rows[i].Cells[0].Value.ToString();
                double qty = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[2].Value.ToString());
                double Rprice = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[1].Value.ToString());
                double total = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value.ToString());
                double dis = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[7].Value.ToString()); //discount rate
                double taxapply = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[8].Value.ToString());
                int kitchendisplay = Convert.ToInt32(dgrvSalesItemList.Rows[i].Cells[9].Value.ToString());
                string uom = dgrvSalesItemList.Rows[i].Cells[10].Value.ToString();


                // =================================Start=====  Profit calculation =============== Start ========= 
                // Discount_amount = (price * discount) / 100                    -- 49 * 3 / 100 = 1.47
                // priceAfterDiscount = price - Discount_amount           -- 49 - 1.47 = 47.53
                // Profit = (priceAfterDiscount * QTY )   - (msrp * qty);  ---( 47.53 * 1 ) - ( 45 * 1) = 2.53

                string sqlprofit = "Select msrp , discount  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID  where product_id  = '" + itemid + "' and UOMID = '" + uom + "'";
                DataAccess.ExecuteSQL(sqlprofit);
                DataTable dt1 = DataAccess.GetDataTable(sqlprofit);

                double msrp = Convert.ToDouble(dt1.Rows[0].ItemArray[0].ToString());
                double discount = Convert.ToDouble(dt1.Rows[0].ItemArray[1].ToString());

                double Discount_amount = (Rprice * discount) / 100.00;
                double priceAfterDiscount = Rprice - Discount_amount;
                double Profit = Math.Round((priceAfterDiscount - msrp), 2); // old calculation (priceAfterDiscount * qty) - (msrp * qty);
                // =================================Start=====  Profit calculation =============== Start =========  

                double item_id = DataAccess.getsalesMYid(Tenent.TenentID, trno);

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
                string sql1 = "  (TenentID, sales_id,item_id,itemName,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, status,UOM,Uploadby ,UploadDate ,SynID) " +
                              " values (" + Tenent.TenentID + ",'" + trno + "','" + item_id + "', '" + itNam + "', '" + qty + "', '" + Rprice + "', '" + total + "', '" + Profit + "', " +
                              " '" + SalesDate + "','" + itemid + "','" + dis + "','" + taxapply + "','" + kitchendisplay + "','" + uom + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1);";
                int flag1 = DataAccess.ExecuteSQL("insert into sales_item" + sql1 + "insert into sales_item_Log" + sql1);
                
                    string sql1Win = " insert into Win_sales_item (TenentID, sales_id,item_id,itemName,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, status,UOM,Uploadby ,UploadDate ,SynID) " +
                                  " values (" + Tenent.TenentID + ",'" + trno + "','" + item_id + "', '" + itNam + "', '" + qty + "', '" + Rprice + "', '" + total + "', '" + Profit + "', " +
                                  " '" + SalesDate + "','" + itemid + "','" + dis + "','" + taxapply + "','" + kitchendisplay + "','" + uom + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                    Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_item", "INSERT");
               
                //update quantity Decrease from Stock Qty |  purchase Table
                if (txtInvoice.Text == "")
                {
                    MessageBox.Show("please check sales no ");
                }
                else
                {

                    string itemids = dgrvSalesItemList.Rows[i].Cells[4].Value.ToString();

                    double qtyupdate = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[2].Value.ToString());

                    // Update Quantity
                    string sqlupdateQty = "select OnHand  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID where product_id = '" + itemids + "' and UOMID = '" + uom + "'";
                    DataAccess.ExecuteSQL(sqlupdateQty);
                    DataTable dtUqty = DataAccess.GetDataTable(sqlupdateQty);
                    double OnHand = Convert.ToDouble(dtUqty.Rows[0].ItemArray[0].ToString()) - qtyupdate;


                    string sql = " update tbl_item_uom_price set " +
                                    " OnHand = '" + OnHand + "', " +
                                    " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where TenentID= " + Tenent.TenentID + " and itemID = '" + itemids + "' and UOMID = '" + uom + "'";
                    DataAccess.ExecuteSQL(sql);

                    string sqlwin = " update Win_tbl_item_uom_price set " +
                                    " OnHand = '" + OnHand + "', " +
                                    " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where TenentID= " + Tenent.TenentID + " and itemID = '" + itemids + "' and UOMID = '" + uom + "'";
                    Datasyncpso.insert_Live_sync(sqlwin, "Win_tbl_item_uom_price", "UPDATE");
                }

            }
            return true;

        }

        /// //// Payment items Add  ///////////Store into Sales_payment table //////// 
        public void payment_item()
        {
            string trno = txtInvoice.Text;
            string payamount = lblTotalPayable.Text;
            string changeamount = txtChangeAmount.Text;
            string due = txtDueAmount.Text;
            string vat = lblTotalVAT.Text;
            string DiscountTotal = lblTotalDisCount.Text;
            string Comment = ComboCustID.Text + "  " + txtCustName.Text;
            string overalldisRate = txtDiscountRate.Text;
            string vatRate = txtVATRate.Text;

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
            string sql1 = "  (TenentID, sales_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                            " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,Uploadby ,UploadDate ,SynID,SaleDt ) " +
                            "  values (" + Tenent.TenentID + ",'" + txtInvoice.Text + "','" + CombPayby.Text + "', '" + payamount + "', '" + changeamount + "', " +
                            " '" + due + "', '" + DiscountTotal + "', '" + vat + "', '" + UploadDate + "', '" + lblCustID.Text + "', " +
                            "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 , '" + dtSalesDate.Text + "');";
            DataAccess.ExecuteSQL("insert into sales_payment" + sql1 + "insert into sales_payment_Log" + sql1);
           
            string sql1Win = " insert into Win_sales_payment (TenentID, sales_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                           " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,Uploadby ,UploadDate ,SynID,SaleDt ) " +
                           "  values (" + Tenent.TenentID + ",'" + txtInvoice.Text + "','" + CombPayby.Text + "', '" + payamount + "', '" + changeamount + "', " +
                           " '" + due + "', '" + DiscountTotal + "', '" + vat + "', '" + UploadDate + "', '" + lblCustID.Text + "', " +
                           "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 , '" + dtSalesDate.Text + "')";
            Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_payment", "INSERT");
        }

        private void btnCompleteSalesAndPrint_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do you want to Complete Sale and Print?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            // if (result == DialogResult.Yes)
            //   {
            if (txtPaidAmount.Text == "00" || txtPaidAmount.Text == "0" || txtPaidAmount.Text == string.Empty)
            {
                MessageBox.Show("Sorry ! You don't have enough product in Item cart \n  Please Add to cart", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            //  else if (Convert.ToInt32(txtInvoice.Text) >= 53)
            // {
            //   MessageBox.Show("Sorry ! Demo version has limited transaction \n Please buy it \n contact at : johar@writeme.com  \n https://goo.gl/Hs7XsD", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //  }
            else
            {
                try
                {
                    //Save payment info into sales_payment table
                    payment_item();

                    ///// save single item 
                    sales_item();

                    btnCompleteSalesAndPrint.Enabled = false;
                    btnSaveOnly.Enabled = false;

                    ///// // Open Print Invoice
                    parameter.autoprintid = "1";
                    //POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                    //go.ShowDialog();

                    string typr = SalesRegister.GetStoreprintType();

                    SalesRegister.PRintInvoice(txtInvoice.Text, typr);// Default , Short ,Split

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            //}
        }

        private void btnSaveOnly_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Complete this transaction?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (txtPaidAmount.Text == "00" || txtPaidAmount.Text == "0" || txtPaidAmount.Text == string.Empty)
                {
                    MessageBox.Show("Sorry ! You don't have enough product in Item cart \n  Please Add to cart", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                }
                //else if (Convert.ToInt32(txtInvoice.Text) >= 53)
                //{
                //    MessageBox.Show("Sorry ! Demo version has limited transaction \n Please buy it \n contact at : johar@writeme.com  \n https://goo.gl/Hs7XsD", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                //}
                else
                {
                    try
                    {

                        //Save payment info into sales_payment table
                        payment_item();

                        ///// save single item 
                        sales_item();


                        btnCompleteSalesAndPrint.Enabled = false;
                        btnSaveOnly.Text = "Done";
                        btnSaveOnly.Enabled = false;
                        //MessageBox.Show("Successfully Done");

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }
        #endregion

        private void ComboCustID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sqlCmd = "Select ID from  tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = '" + ComboCustID.Text.Trim() + "'";
                DataAccess.ExecuteSQL(sqlCmd);
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                lblCustID.Text = dt1.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
            }
        }

        //Invoice Id Auto increment
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bool ISrun = backSyncro.isRun;
                if (ISrun != true)
                {
                    string sql = "select  sales_id  from sales_payment where TenentID = " + Tenent.TenentID + " and order by sales_id desc";
                    DataTable dt = DataAccess.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        double id = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString()) + 1;
                        txtInvoice.Text = Convert.ToString(Convert.ToInt32(id));
                        //
                    }
                    else
                    {
                        double id = 1;
                        txtInvoice.Text = Convert.ToString(Convert.ToInt32(id));
                        //  prgressbar();
                    }
                }
            }
            catch
            {

            }
        }





    }
}
