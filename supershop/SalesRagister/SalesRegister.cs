using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Data.SqlClient;
using System.Transactions;
using System.Resources;
using System.Globalization;
using System.Threading.Tasks;
using System.Drawing.Printing;
using supershop.Report;

using supershop.SalesRagister;
using Microsoft.PointOfService;
using System.Threading;
using MessageBoxExample;


namespace supershop
{
    public partial class SalesRegister : Form
    {
        /// <summary>
        ///  Author : Yogesh Khandala
        ///  Email:   johar@writeme.com         ///  
        ///Web:         http://erp53.com/user/ERP53/portfolio
        ///Item Link:   http://erp53.com/item/advance-point-of-sale-system-pos/6317175
        /// </summary>
        /// <param name="aa"></param>
        /// Developed by ERP53
        // Actual size = 1188, 679

        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;

        CashDrawer myCashDrawer;
        PosExplorer explorer;
        private int _Tab=0;
        public SalesRegister()
        {
            InitializeComponent();
           // this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            PageSetting();
            dtSalesDate.Format = DateTimePickerFormat.Custom;
            dtSalesDate.CustomFormat = "yyyy-MM-dd";

            dtsaleDate.Format = DateTimePickerFormat.Custom;
            dtsaleDate.CustomFormat = "yyyy-MM-dd";

            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";
            lblStartDate.Text = dtStartDate.Value.ToString("yyyy-MM-dd");
            dtsaleDeliveryDate.Text = DateTime.Now.AddDays(1).ToString();
            dtsaleDeliveryDate.Format = DateTimePickerFormat.Custom;//laundary yogesh 030519
            dtsaleDeliveryDate.CustomFormat = "yyyy-MM-dd";

            dtDriverStartDate.Format = DateTimePickerFormat.Custom;
            dtDriverStartDate.CustomFormat = "yyyy-MM-dd";

            this.tabPageSR_Payment.Parent = null; //Hide payment tab
            // tabSRcontrol.TabPages.Remove(tabPageSR_Payment);

            this.tabPageSR_Split_Bill.Parent = null; //Hide payment tab
            //tabSRcontrol.SelectedTab = tabPageSR_Counter;

            txtBarcodeReaderBox.Focus();

            formFunctionPointer += new functioncall(Replicate); // Coin and papernotes
            currency_Shortcuts1.CoinandNotesFunctionPointer = formFunctionPointer;

            numformFunctionPointer += new numvaluefunctioncall(NumaricKeypad);
            currency_Shortcuts1.NumaricKeypad = numformFunctionPointer;

            if (UserInfo.Language == "English")
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                switch_language();
            }
            else if (UserInfo.Language == "Arabic")
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("Ar");
                switch_language();
            }
            else
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                switch_language();
            }

            //try //Yogesh 180619
            //{
            //    explorer = new PosExplorer();
            //    DeviceInfo ObjDevicesInfo = explorer.GetDevice("CashDrawer");

            //    if (ObjDevicesInfo != null)
            //    {
            //        myCashDrawer = (CashDrawer)explorer.CreateInstance(ObjDevicesInfo);
            //    }
            //    else
            //    {
            //        myCashDrawer = null;
            //    }
            //}
            //catch
            //{

            //}//Yogesh 180619
        }

        public void PageSetting()
        {
            string sql3 = "select IsBooking,IsDeliveryDt from storeconfig where TenentID = " + Tenent.TenentID + "";
            DataTable dt1 = DataAccess.GetDataTable(sql3);
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["IsBooking"].ToString() == "1")
                {
                    btnBooking.Visible = true;
                }
                else
                {
                    btnBooking.Visible = false;
                }
                if (dt1.Rows[0]["IsDeliveryDt"].ToString() == "1")
                {
                    lblDeliverydate.Visible = true;
                    dtsaleDeliveryDate.Visible = true;
                }
                else
                {
                    lblDeliverydate.Visible = false;
                    dtsaleDeliveryDate.Visible = false;
                }
            }
        }
        public void maintanace()
        {
            string SqlCmd2 = "update purchase set custitemCode = product_id where tenentid =" + Tenent.TenentID + " and  custitemCode is null";
            DataAccess.ExecuteSQL(SqlCmd2);

            string SqlCmd = "update purchase set Barcode = product_id where tenentid =" + Tenent.TenentID + " and  Barcode is null";
            DataAccess.ExecuteSQL(SqlCmd);
        }
        private void switch_language()
        {
            tabPageSR_Counter.Text = res_man.GetString("SalesRegister_tabPageSR_Counter", cul);
            tabPageSR_Payment.Text = res_man.GetString("SalesRegister_tabPageSR_Payment", cul);
            //lblBarCodeScannerSupport.Text = res_man.GetString("SalesRegister_lblBarCodeScannerSupport", cul);
            lblInsertitembarcode.Text = res_man.GetString("SalesRegister_lblInsertitembarcode", cul);
            lblOrderway.Text = res_man.GetString("SalesRegister_lblOrderway", cul);
            labelCustomerName.Text = res_man.GetString("SalesRegister_labelCustomerName", cul);
            //labelInvoiceNo.Text = res_man.GetString("SalesRegister_labelInvoiceNo", cul);
            btnSalesCredit.Text = res_man.GetString("SalesRegister_btnSalesCredit", cul);
            btnSuspend.Text = res_man.GetString("SalesRegister_btnSuspend", cul);
            labelTotal.Text = res_man.GetString("SalesRegister_labelTotal", cul);
            labelDiscount.Text = res_man.GetString("SalesRegister_labelDiscount", cul);
            labelSubTotal.Text = res_man.GetString("SalesRegister_labelSubTotal", cul);
            //labelTAXRate.Text = res_man.GetString("SalesRegister_labelTAXRate", cul);
            // labelDeliveryCharge.Text = res_man.GetString("SalesRegister_labelDeliveryCharge", cul);
            //labelTotalPayable.Text = res_man.GetString("SalesRegister_labelTotalPayable", cul);
            labelCashReceived.Text = res_man.GetString("SalesRegister_labelCashReceived", cul);
            //labelChangeamount.Text = res_man.GetString("SalesRegister_labelChangeamount", cul);
            //ItemsImage.Text = res_man.GetString("SalesRegister_Items", cul);
            btnrelateditem.Text = res_man.GetString("SalesRegister_RelatedItems", cul);
            btncategories.Text = res_man.GetString("SalesRegister_Catagories", cul);
            labelSearchItems.Text = res_man.GetString("SalesRegister_labelSearchItems", cul);
            linkLabelRefresh.Text = res_man.GetString("SalesRegister_linkLabelRefresh", cul);
            linkLabelCalculator.Text = res_man.GetString("SalesRegister_linkLabelCalculator", cul);
            helplnk.Text = res_man.GetString("SalesRegister_helplnk", cul);
            label1TotalPayable.Text = res_man.GetString("SalesRegister_label1TotalPayable", cul);
            labelPaidAmount.Text = res_man.GetString("SalesRegister_labelPaidAmount", cul);
            //lnkCustomer.Text = res_man.GetString("SalesRegister_labelCustomer", cul);
            labelInsertCustomeramount.Text = res_man.GetString("SalesRegister_labelInsertCustomeramount", cul);
            //linkLabelAddNew.Text = res_man.GetString("SalesRegister_linkLabelAddNew", cul);
            label1ChangeAmount.Text = res_man.GetString("SalesRegister_label1ChangeAmount", cul);
            labelPayby.Text = res_man.GetString("SalesRegister_labelPayby", cul);
            labelReffranceNo.Text = res_man.GetString("SalesRegister_labelReffranceNo", cul);
            labelDue.Text = res_man.GetString("SalesRegister_labelDue", cul);
            labelSalesDate.Text = res_man.GetString("SalesRegister_labelSalesDate", cul);
            //label1Optional.Text = res_man.GetString("SalesRegister_label1Optional", cul);
            labelComment.Text = res_man.GetString("SalesRegister_labelComment", cul);
            btnback.Text = res_man.GetString("SalesRegister_btnback", cul);
            btnSaveOnly.Text = res_man.GetString("SalesRegister_btnSaveOnly", cul);
            btnCompleteSalesAndPrint.Text = res_man.GetString("SalesRegister_btnCompleteSalesAndPrint", cul);
            //labelShortcuts.Text = res_man.GetString("SalesRegister_labelShortcuts", cul);

        }
        public string clearinvoice
        {
            set
            {
                lblClear.Text = value;
            }
            get
            {
                return lblClear.Text;
            }
        }
        public string AddItemgrid
        {
            set
            {
                txtBarcodeReaderBox.Text = value;
            }
            get
            {
                return txtBarcodeReaderBox.Text;
            }
        }
        public string DraftInvoiceExt
        {
            set
            {
                lblDraft.Text = value;
            }
            get
            {
                return lblDraft.Text;
            }
        }
        public string InvoceNo
        {
            set
            {
                lblInvoiceNO.Text = value;
            }
            get
            {
                return lblInvoiceNO.Text;
            }
        }
        public string Changeperishable//yogesh
        {
            set
            {
                lblPerishable.Text = value;
            }
        }
        public string ChangeSerialize //yogesh
        {
            set
            {
                lblSerialize.Text = value;
            }
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
        public string CustName
        {
            set
            {
                txtCustomer.Text = value;
                if (lblCustomerPage.Text == "AppointmentS1" || lblCustomerPage.Text == "CustomerSearch")
                {
                    customerLostFocus();
                    lblCustomerPage.Text = "-";
                    lblIsReciepe.Text = "Yes";
                }
            }
            get
            {
                return txtCustomer.Text;
            }
        }
        public string CustName4Cashier
        {
            set
            {
                txtSearchCustCode.Text = value;
                if (lblCustPage4Cashier.Text == "CustomerSearch4Cashier")
                {

                    lblCustPage4Cashier.Text = "-";

                }
            }
            get
            {
                return txtSearchCustCode.Text;
            }
        }
        public string CustomerPage
        {
            set
            {
                lblCustomerPage.Text = value;
            }
            get
            {
                return lblCustomerPage.Text;
            }
        }
        public void BindControl()
        {
            //dtGrdvOrderDetails

            if (UserInfo.usertype == "1")
            {
                chkoutput.Enabled = true;
            }
            else
            {
                chkoutput.Enabled = false;
            }

            DataGridViewButtonColumn Action = new DataGridViewButtonColumn();
            this.dtGrdvOrderDetails.Columns.Add(Action);
            Action.HeaderText = "Action";
            Action.Text = "Action عمل";
            Action.Name = "Action";
            Action.ToolTipText = "Action";
            Action.UseColumnTextForButtonValue = true;

            //datagrdReportDetails

            DataGridViewButtonColumn Assign = new DataGridViewButtonColumn();
            this.datagrdReportDetails.Columns.Add(Assign);
            Assign.HeaderText = "Action";
            Assign.Text = "Action عمل";
            Assign.Name = "Action";
            Assign.ToolTipText = "Action";
            Assign.UseColumnTextForButtonValue = true;

            //txtVATRate.Text = vatdisvalue.vat;

            this.GridPayment.Columns.Add("sales_id", "invoice");
            this.GridPayment.Columns.Add("payment_type", "Pay By");
            this.GridPayment.Columns.Add("Reffrance_NO", "Reffrance NO");
            this.GridPayment.Columns.Add("payment_amount", "Amount");

            DataGridViewButtonColumn Pay_del = new DataGridViewButtonColumn();
            this.GridPayment.Columns.Add(Pay_del);
            Pay_del.HeaderText = "Delete";
            Pay_del.Text = "Delete";
            Pay_del.Name = "Delete";
            Pay_del.ToolTipText = "Delete Payment Method";
            Pay_del.UseColumnTextForButtonValue = true;

            GridPayment.Columns[0].ReadOnly = true;
            GridPayment.Columns[1].ReadOnly = true;
            GridPayment.Columns[2].ReadOnly = true;
            GridPayment.Columns[3].ReadOnly = true;


            // dataGridPaymentSplit

            this.dataGridPaymentSplit.Columns.Add("NO", "NO");
            this.dataGridPaymentSplit.Columns.Add("Customer", "Customer");
            this.dataGridPaymentSplit.Columns.Add("Items", "Items");
            this.dataGridPaymentSplit.Columns.Add("payment_type", "Pay By");
            this.dataGridPaymentSplit.Columns.Add("Reffrance_NO", "Reffrance NO");
            this.dataGridPaymentSplit.Columns.Add("payment_amount", "Amount");

            DataGridViewButtonColumn Pay_delSplit = new DataGridViewButtonColumn();
            this.dataGridPaymentSplit.Columns.Add(Pay_delSplit);
            Pay_delSplit.HeaderText = "Edit";
            Pay_delSplit.Text = "Edit";
            Pay_delSplit.Name = "Edit";
            Pay_delSplit.ToolTipText = "Edit Payment Method";
            Pay_delSplit.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Pay_EditSplit = new DataGridViewButtonColumn();
            this.dataGridPaymentSplit.Columns.Add(Pay_EditSplit);
            Pay_EditSplit.HeaderText = "Delete";
            Pay_EditSplit.Text = "Delete";
            Pay_EditSplit.Name = "Delete";
            Pay_EditSplit.ToolTipText = "Delete Payment Method";
            Pay_EditSplit.UseColumnTextForButtonValue = true;

            dataGridPaymentSplit.Columns[0].ReadOnly = true;
            dataGridPaymentSplit.Columns[1].ReadOnly = true;
            dataGridPaymentSplit.Columns[2].ReadOnly = true;
            dataGridPaymentSplit.Columns[3].ReadOnly = true;


            // txtDiscountRate.Text    = vatdisvalue.dis;            


            this.dgrvSalesItemList.Columns.Add("itm", "Items Name");
            this.dgrvSalesItemList.Columns.Add("Am", "Price");
            this.dgrvSalesItemList.Columns.Add("Qty", "Qty");
            this.dgrvSalesItemList.Columns.Add("Total", "Total");
            this.dgrvSalesItemList.Columns.Add("ID", "ID");
            this.dgrvSalesItemList.Columns.Add("disamt", "Disamt");     // 5. new in 8.1 version
            this.dgrvSalesItemList.Columns.Add("taxamt", "taxamt");     // 6. new in 8.1 version
            this.dgrvSalesItemList.Columns.Add("dis", "Dis");           // 7. new in 8.1 version
            this.dgrvSalesItemList.Columns.Add("taxapply", "Tax");      // 8. new in 8.1 version
            this.dgrvSalesItemList.Columns.Add("kitdisplay", "KD");      // 8. new in 8.3.1 version
            this.dgrvSalesItemList.Columns.Add("BatchNo", "Batch");
            this.dgrvSalesItemList.Columns.Add("OnHand", "OnHand");
            this.dgrvSalesItemList.Columns.Add("ExpiryDate", "ExpiryDate");
            this.dgrvSalesItemList.Columns.Add("SalesID", "SalesID");
            this.dgrvSalesItemList.Columns.Add("invoice", "invoice");
            this.dgrvSalesItemList.Columns.Add("CID", "CID");
            this.dgrvSalesItemList.Columns.Add("CustItemCode", "Item Code");
            this.dgrvSalesItemList.Columns.Add("Serial_Number", "Serial");
            this.dgrvSalesItemList.Columns.Add("ItemNote", "ItemNote");

            //Hide fields
            dgrvSalesItemList.Columns[4].Visible = false; // ID             // new in 8.1 version
            dgrvSalesItemList.Columns[5].Visible = false; // Disamt         // new in 8.1 version
            dgrvSalesItemList.Columns[6].Visible = false; // taxamt         // new in 8.1 version
            dgrvSalesItemList.Columns[7].Visible = false; // Discount rate  // new in 8.1 version
            dgrvSalesItemList.Columns[8].Visible = false; // Discount rate
            dgrvSalesItemList.Columns[9].Visible = false;
            // kitdisplay    // new in 8.3.1 version
        
          


            dgrvSalesItemList.Columns[10].Visible = false; // BatchNo    
            dgrvSalesItemList.Columns[11].Visible = false; // OnHand 
            dgrvSalesItemList.Columns[12].Visible = false; // ExpiryDate 
            dgrvSalesItemList.Columns[13].Visible = false; // SalesID    
            dgrvSalesItemList.Columns[14].Visible = false; // invoice 
            dgrvSalesItemList.Columns[15].Visible = false; // CID  
            dgrvSalesItemList.Columns[16].Visible = false; // CustItemCode  
            dgrvSalesItemList.Columns[17].Visible = false; // Serial
            dgrvSalesItemList.Columns[18].Visible = false; // ItemNote
            //Font size of columns and aligmnet  // add in from version 8.3
          //  dgrvSalesItemList.Columns["itm"].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);
           // dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // dgrvSalesItemList.Columns["taxapply"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            ///// dataGridView1.Rows.Add(1);         

            DataGridViewButtonColumn inc = new DataGridViewButtonColumn();
            dgrvSalesItemList.Columns.Add(inc);
            inc.HeaderText = "+";
            inc.Text = "+";
            inc.Name = "inc";
            inc.ToolTipText = "Increase Item Qty";
            inc.UseColumnTextForButtonValue = true;
           
            DataGridViewButtonColumn minus = new DataGridViewButtonColumn();
            dgrvSalesItemList.Columns.Add(minus);
            minus.HeaderText = "-";
            minus.Text = "-";
            minus.Name = "minus";
            minus.ToolTipText = "minus Item Qty";
            minus.UseColumnTextForButtonValue = true;

            //DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
            //dgrvSalesItemList.Columns.Add(Edit);
            //Edit.HeaderText = "Edit";
            //Edit.Text = "Edit";
            //Edit.Name = "Edit";
            //Edit.ToolTipText = "Edit Only Serialize";
            //Edit.UseColumnTextForButtonValue = true;

           DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn  del = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            dgrvSalesItemList.Columns.Add(del);
            del.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            del.HeaderText = "X";
            //del.Text = "x";
            del.Name = "del";
            del.Image = Properties.Resources.crossGrid;

            del.ToolTipText = "Delete this Item";
            del.UseColumnTextForButtonValue = true;


            // this.dgrvSalesItemList.Rows[0].Cells[2].Value = "1";
            //  dgrvSalesItemList.ReadOnly = true;
            dgrvSalesItemList.Columns[0].ReadOnly = true;
            dgrvSalesItemList.Columns[1].ReadOnly = false;
            dgrvSalesItemList.Columns[2].ReadOnly = false; // false Parimal
            dgrvSalesItemList.Columns[3].ReadOnly = true;
            dgrvSalesItemList.Columns[4].ReadOnly = true;
            dgrvSalesItemList.Columns[5].ReadOnly = true;
            dgrvSalesItemList.Columns[6].ReadOnly = true;
            dgrvSalesItemList.Columns[7].ReadOnly = true;
            dgrvSalesItemList.Columns[8].ReadOnly = true;
            dgrvSalesItemList.Columns[9].ReadOnly = true;
            dgrvSalesItemList.Columns[10].ReadOnly = false;//batch
            dgrvSalesItemList.Columns[11].ReadOnly = true;
            dgrvSalesItemList.Columns[12].ReadOnly = true;
            dgrvSalesItemList.Columns[17].ReadOnly = true;
            dgrvSalesItemList.Columns[18].ReadOnly = false;

            //Qty column row color
           // dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.ForeColor = Color.Black;
           // dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.BackColor = Color.White;
           // dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.SelectionForeColor = Color.Black;
           // dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.SelectionBackColor = Color.Silver;
           // dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);



            //  Column width
            dgrvSalesItemList.Columns["itm"].Width = 225;
            dgrvSalesItemList.Columns["Del"].Width = 25;
            dgrvSalesItemList.Columns["Qty"].Width = 60;

            dgrvSalesItemList.Columns["Am"].Width = 70;
            dgrvSalesItemList.Columns["Total"].Width = 80;
            dgrvSalesItemList.Columns["inc"].Width = 0;
            //dgrvSalesItemList.Columns["Edit"].Width = 50;
            dgrvSalesItemList.Columns["minus"].Width = 0;
            dgrvSalesItemList.Columns["inc"].Visible = false;
            dgrvSalesItemList.Columns["minus"].Visible = false;
            dgrvSalesItemList.Columns["ItemNote"].Visible = false;
           
         

            // dgrvSalesItemList.Rows[0].Cells[2].Style.BackColor = Color.Red;
            // DataGridViewColumn ColQty = dgrvSalesItemList.Columns[2];
            // ColQty.Width = 45;
        }

        #region Databind
        //Default Form Load 
        private void SalesRegister_Load(object sender, EventArgs e)
        {
            //ManageInvoice();
            _Tab = 0;
          
            BindControl();
            maintanace();

           // AutoComplete();
            try
            {

                if (UserInfo.EditTransation != true)
                {

                    UserInfo.EditTransation = false;
                    UserInfo.Invoice = 0;
                    UserInfo.InvoicetransNO = null;

                    if (lblorderNO.Text != "-")
                    {
                        if (UserInfo.TranjationPerform != null)
                        {
                            string ActionEvent = UserInfo.TranjationPerform;
                            if (ActionEvent == "Draft")
                            {
                                string InvoicetransNO = lblorderNO.Text;
                                EditOrder(InvoicetransNO);
                            }
                            else if (ActionEvent == "Booking")
                            {
                                string InvoicetransNO = lblorderNO.Text;
                                EditOrder(InvoicetransNO);
                            }
                            else if (ActionEvent == "Payment")
                            {
                                string InvoicetransNO = lblorderNO.Text;
                                EditOrder(InvoicetransNO);

                                SalesCreditPayment();
                            }
                            else if (ActionEvent == "COD")
                            {
                                string InvoicetransNO = lblorderNO.Text;
                                EditOrder(InvoicetransNO);

                                CashOnDelivery();
                            }
                            else if (ActionEvent == "CashAndPrint")
                            {
                                string InvoicetransNO = lblorderNO.Text;
                                EditOrder(InvoicetransNO);

                                SaveandPrint(true);
                            }
                            else if (ActionEvent == "DriverAssign")
                            {
                               // this one . 
                                Last30daysReport(dtStartDate.Text);
                                if (dtDriverStartDate.Text != "")
                                {
                                    try
                                    {
                                        txtReciptNO.Text = "";
                                        DateTime startDate1 = Convert.ToDateTime(dtDriverStartDate.Text);
                                        Daywice(startDate1);
                                    }
                                    catch { }
                                }

                            }
                            else if (ActionEvent == "Deliverd")
                            {
                                Last30daysReport(dtStartDate.Text);
                                if (dtDriverStartDate.Text != "")
                                {
                                    try
                                    {
                                        txtReciptNO.Text = "";
                                        DateTime startDate1 = Convert.ToDateTime(dtDriverStartDate.Text);
                                        Daywice(startDate1);
                                    }
                                    catch { }
                                }
                            }
                            else { }
                            UserInfo.TranjationPerform = null;
                        }
                    }

                }

                //Check_OpeningBalance();

                BindDainingTable();
                bindOrderWay();
                CategoryList();


              //5  string CAT = Get_First_Catagory();
              
                 
                   string Catname = GetCatName();
                    lblCatagory.Text = Catname;
                    lblCatagory.Refresh();

                    if (chkWithGrid.Checked == true)
                    {
                        if (chkoutput.Checked == true)
                        {
                            ItemList_with_Catagory_Grid(Catname, "Output");
                        }
                        else
                        {
                            ItemList_with_Catagory_Grid(Catname, "");
                        }
                    }
                    else if (chkImage.Checked == true)
                    {
                        if (chkoutput.Checked == true)
                        {
                            ItemList_with_Catagory_images(Catname, "Output");
                        }
                        else
                        {
                            ItemList_with_Catagory_images(Catname, "");
                        }
                    }
                    else
                    {
                        if (chkoutput.Checked == true)
                        {
                        ItemList_with_Catagory_With_Button(Catname, "Output");
                     
                        btnItemButton_Click(null, null);
                        }
                        else
                        {
                            ItemList_with_Catagory_With_Button(Catname, "");
                        btnItemButton_Click(null, null);
                    }
                    }
          

                BindPayType();

                FirstTimeInvoiceNO();

                //bindAssignDriver();

            }
            catch (Exception ex)
            {

            }
        }
        public int SeearchNo { get; set; }
        public string searchDate { get; set; }
        public void DeliveryRefresh()
        {
            if (SeearchNo == 0)
            {
                dtStartDate.Text = searchDate;
                btnCashierRefresh_Click(null, null);

            }
            else if (SeearchNo == 1)
            {
                btnCustCode_Click(null, null);
            }
            else if (SeearchNo == 2)
            {
                btnSerchCashier_Click(null, null);
            }
        }
        private void RefrashPayby_Click(object sender, EventArgs e)
        {
            BindPayType();
        }

        public void BindPayType()
        {
            string Sql = "Select REFID,REFNAME1 from REFTABLE where TenentID = " + Tenent.TenentID + " and RefType = 'Payment' and RefSubType = 'Method' and ShortName = 'POS' And ACTIVE = 'Y'";
            DataTable dt = DataAccess.GetDataTable(Sql);
            if (dt.Rows.Count > 0)
            {
                CombPayby.DataSource = dt;
                CombPayby.ValueMember = "REFID";
                CombPayby.DisplayMember = "REFNAME1";
            }
        }

        public string get_sales_id()
        {
            string ID = "";

            string sql = "select  sales_id  from sales_item where TenentID =" + Tenent.TenentID + " order by sales_id desc";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                ID = (Convert.ToDouble(dt.Rows[0]["sales_id"].ToString()) + 1).ToString();
            }
            else
            {
                ID = "1";
            }

            return ID;
        }
        public void FirstTimeInvoiceNO()
        {
            //Load Invoice No / Receipt No for current transaction
            //txtInvoice.Text = "";
            int year = DateTime.Now.Year;
            string terminal = UserInfo.Shopid;
            if (UserInfo.EditTransation == true)
            {
                if (UserInfo.Invoice == 0)
                {
                    string Sales_ID = get_sales_id();
                    txtInvoice.Text = Sales_ID;
                    txtInvoicePAY.Text = Sales_ID;
                   //sahir edit 
                    lblInvoiceNO.Text = Sales_ID + "/" + terminal + "/" + year;
                    lblInvoiceNOPAY.Text = Sales_ID + "/" + terminal + "/" + year;
                }
                else
                {
                    txtInvoice.Text = Convert.ToString(Convert.ToInt32(UserInfo.Invoice));
                    txtInvoicePAY.Text = Convert.ToString(Convert.ToInt32(UserInfo.Invoice));
                }
            }
            else
            {
                //4176
                string Sales_ID = get_sales_id();
                txtInvoice.Text = Sales_ID;
                txtInvoicePAY.Text = Sales_ID;
                //sahir Edit
                lblInvoiceNO.Text = Sales_ID + "/" + terminal + "/" + year;
                lblInvoiceNOPAY.Text = Sales_ID + "/" + terminal + "/" + year;

            }
            //sahir Edit
            //getInvoiceno();
        }
        public string Get_First_Catagory()
        {
            string Catagory = "";
            string sql = "select   DISTINCT  category   from  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID  INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID where purchase.TenentID = " + Tenent.TenentID + " order by DisplaySort";

            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                Catagory = dt.Rows[0]["category"].ToString();
            }

            return Catagory;
        }
        public string GetCatName()
        {
            string Cat_Name = "";
            string sqlName = "select CAT_NAME1 from CAT_MST where TenentID ";
            DataTable dtName = DataAccess.GetDataTable(sqlName);
            if (dtName.Rows.Count > 0)
            {
                Cat_Name = dtName.Rows[0]["CAT_NAME1"].ToString();
            }
            else
            {
                Cat_Name = Name;
            }

            return Cat_Name;
        }
        public void BindDainingTable()
        {
            comboTable.DataSource = null;
            comboTable.Items.Clear();
            // using of * which get all field from database can cause slow performance , you need only 3 field
            //sahir Edit 
            string sqlCust = "Select TableID,TableName,SheetingCapicity from DainingTable";

            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            string First = "";

            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    string Val = dtCust.Rows[i]["TableID"] + " - " + dtCust.Rows[i]["TableName"] + " - " + dtCust.Rows[i]["SheetingCapicity"];
                    comboTable.Items.Add(Val);

                    if (First == "")
                    {
                        First = Val;
                    }
                }

                comboTable.Text = First;
            }
        }
        public void bindOrderWay()
        {
            comboSalesMan.DataSource = null;
            comboSalesMan.Items.Clear();
            // this is good 
            string sqlCust = "Select OrderWayID,Name1 from tbl_orderWay_Maintenance where TenentID = " + Tenent.TenentID + "";

            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    comboSalesMan.Items.Add(dtCust.Rows[i][0] + " - " + dtCust.Rows[i][1]);
                }
                comboSalesMan.Text = "Walk In - Walk In";
            }

        }
        //public void getInvoiceno()
        //{
        //    lblInvoiceNO.Text = "";
        //    lblInvoiceNOPAY.Text = "";

        //    if (UserInfo.EditTransation == true)
        //    {
        //        if (UserInfo.InvoicetransNO == null || UserInfo.InvoicetransNO == "")
        //        {
        //            string date = DateTime.Now.ToString("yyyy-MM-dd");
        //            //string sqlNO = "select * from sales_item where TenentID = " + Tenent.TenentID + " and sales_time like '%" + date + "%' group by sales_id";
        //            string sqlNO = "select * from sales_item where TenentID = " + Tenent.TenentID + " group by sales_id";
        //            DataTable dtNO = DataAccess.GetDataTable(sqlNO);
        //            if (dtNO.Rows.Count > 0)
        //            {
        //                int count = dtNO.Rows.Count + 1;
        //                int year = DateTime.Now.Year;
        //                string terminal = UserInfo.Shopid;
        //                int day = DateTime.Now.DayOfYear;
        //                //lblInvoiceNO.Text = count + "/" + terminal + "/" + year;
        //                //lblInvoiceNOPAY.Text = year + "/" + terminal + "/" + day + "/" + count;
        //                lblInvoiceNO.Text = count + "/" + terminal + "/" + year;
        //                lblInvoiceNOPAY.Text = count + "/" + terminal + "/" + year;
        //            }
        //            else
        //            {
        //                int count = 1;
        //                int year = DateTime.Now.Year;
        //                string terminal = UserInfo.Shopid;
        //                int day = DateTime.Now.DayOfYear;
        //                //lblInvoiceNO.Text = year + "/" + terminal + "/" + day + "/" + count;
        //                //lblInvoiceNOPAY.Text = year + "/" + terminal + "/" + day + "/" + count;
        //                lblInvoiceNO.Text = count + "/" + terminal + "/" + year;
        //                lblInvoiceNOPAY.Text = count + "/" + terminal + "/" + year;
        //            }
        //        }
        //        else
        //        {
        //            lblInvoiceNO.Text = UserInfo.InvoicetransNO.ToString();
        //            lblInvoiceNOPAY.Text = UserInfo.InvoicetransNO.ToString();
        //        }
        //    }
        //    else
        //    {
        //        string date = DateTime.Now.ToString("yyyy-MM-dd");
        //        //string sqlNO = "select * from sales_item where TenentID = " + Tenent.TenentID + " and sales_time like '%" + date + "%' group by sales_id";
        //        string sqlNO = "select * from sales_item where TenentID = " + Tenent.TenentID + " group by sales_id";
        //        DataTable dtNO = DataAccess.GetDataTable(sqlNO);
        //        if (dtNO.Rows.Count > 0)
        //        {
        //            int count = dtNO.Rows.Count + 1;
        //            int year = DateTime.Now.Year;
        //            string terminal = UserInfo.Shopid;
        //            int day = DateTime.Now.DayOfYear;
        //            //lblInvoiceNO.Text = year + "/" + terminal + "/" + day + "/" + count;
        //            //lblInvoiceNOPAY.Text = year + "/" + terminal + "/" + day + "/" + count;
        //            lblInvoiceNO.Text = count + "/" + terminal + "/" + year;
        //            lblInvoiceNOPAY.Text = count + "/" + terminal + "/" + year;
        //        }
        //        else
        //        {
        //            int count = 1;
        //            int year = DateTime.Now.Year;
        //            string terminal = UserInfo.Shopid;
        //            int day = DateTime.Now.DayOfYear;
        //            //lblInvoiceNO.Text = year + "/" + terminal + "/" + day + "/" + count;
        //            //lblInvoiceNOPAY.Text = year + "/" + terminal + "/" + day + "/" + count;
        //            lblInvoiceNO.Text = count + "/" + terminal + "/" + year;
        //            lblInvoiceNOPAY.Text = count + "/" + terminal + "/" + year;
        //        }
        //    }

        //}

        public void getInvoiceno()
        {
            lblInvoiceNO.Text = "";
            lblInvoiceNOPAY.Text = "";

            if (UserInfo.EditTransation == true)
            {
                if (UserInfo.InvoicetransNO == null || UserInfo.InvoicetransNO == "")
                {
                    string Sales_ID = get_sales_id();
                    int year = DateTime.Now.Year;
                    string terminal = UserInfo.Shopid;

                    lblInvoiceNO.Text = Sales_ID + "/" + terminal + "/" + year;
                    lblInvoiceNOPAY.Text = Sales_ID + "/" + terminal + "/" + year;
                }
                else
                {
                    lblInvoiceNO.Text = UserInfo.InvoicetransNO.ToString();
                    lblInvoiceNOPAY.Text = UserInfo.InvoicetransNO.ToString();
                }
            }
            else
            {
                string Sales_ID = get_sales_id();
                int year = DateTime.Now.Year;
                string terminal = UserInfo.Shopid;

                lblInvoiceNO.Text = Sales_ID + "/" + terminal + "/" + year;
                lblInvoiceNOPAY.Text = Sales_ID + "/" + terminal + "/" + year;
            }

        }
        //Show Products image
        public void ItemList_with_images(string value, string Output)
        {
            flowLayoutPanelItemList.Controls.Clear();

            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";

            System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);

            if (di.Exists)
            {
                img_directory = UserInfo.Img_path;
            }

            string[] files = Directory.GetFiles(img_directory, "*.jpg");
            try
            {
                int AllowMinusQty = DataAccess.checkMinus();
                string sql = "";
                if (value != "")
                {
                    if (value == "All")
                    {
                        if (AllowMinusQty == 1)
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      "  where   RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                        }
                    }
                    else
                    {
                        if (AllowMinusQty == 1)//product_name_Arabic
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and  purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name";
                            }

                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  )  OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR   (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  )  OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR   (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and  purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                        }
                    }
                }
                else
                {
                    if (AllowMinusQty == 1)
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and RecipeType = 'Output'  and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }
                        else
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and  purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }

                    }
                    else
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (( product_name like '%" + value + "%' and OnHand >= 1) OR ( product_name_Arabic like '%" + value + "%')  " +
                                  " OR ( product_id like '%" + value + "%'  and OnHand >= 1) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  " +
                                  " OR (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }
                        else
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (( product_name like '%" + value + "%' and OnHand >= 1) OR ( product_name_Arabic like '%" + value + "%')  " +
                                  " OR ( product_id like '%" + value + "%'  and OnHand >= 1) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  " +
                                  " OR (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and  purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }

                    }
                }

                DataTable dt = DataAccess.GetDataTable(sql);

                itemCount.Text = "(" + dt.Rows.Count + ")";
                itemCount.Refresh();

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    DevComponents.DotNetBar.ButtonX b = new DevComponents.DotNetBar.ButtonX();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = (dataReader["product_id"] + "~" + dataReader["UOMNAME"] + "," + dataReader["CustItemCode"]);
                    b.Click += new EventHandler(b_Click);

                    string taxapply;
                    if (dataReader["taxapply"].ToString() == "1")
                    {
                        taxapply = "YES";
                    }
                    else
                    {
                        taxapply = "NO";
                    }

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(130, 70);
                    string image = "";
                    if (dataReader["Image"] != null && dataReader["Image"].ToString() != "" && dataReader["Image"].ToString() != "item.png")
                    {
                        image = dataReader["Image"].ToString();
                        string Filename = img_directory + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["Image"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }
                    else
                    {
                        image = dataReader["imagename"].ToString();
                        string Filename = img_directory + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["imagename"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }
                    il.Images.Add(Image.FromFile(img_directory + image));
                    b.Image = il.Images[0];
                    b.Margin = new Padding(1, 1, 1, 1);

                    b.Size = new Size(142, 131);
                    b.Text.PadRight(4);

                    //  b.Text += " " + dataReader["product_id"] + "\n ";


                    if (UserInfo.Language == "English")
                    {
                        b.Text += dataReader["product_name"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        b.Text += dataReader["product_name_Arabic"].ToString();
                    }
                    else
                    {
                        b.Text += dataReader["product_name"].ToString();
                    }

                    //b.Text += dataReader["product_name"].ToString();
                    //  b.Text += "\n Buy: " + dataReader["msrp"];
                  //  b.Text += "\n ID: " + dataReader["CustItemCode"];
                    if (UserInfo.usertype == "1")
                    {
                        //if (dataReader["Rmsrp"] != null && dataReader["Rmsrp"].ToString() != "")
                        //{
                        //    b.Text += "\n R.Price: " + dataReader["Rmsrp"];
                        //}
                        //else
                        //{
                        b.Text += "\n Price: " + dataReader["msrp"];
                        //}
                    }
                    //b.Text += "\n Dis: " + dataReader["Discount"] + "% ";   //"Tax: " + taxapply;

                    string UOM = dataReader["UOMID"].ToString();
                    string UOM_Name = dataReader["UOMNAME"].ToString();

                    //  b.Text += "\n UOM: " + UOM_Name;
                    //b.Text += "\n Expiry: " + dataReader["ExpiryDate"];
                    b.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                    // b.FlatStyle = FlatStyle.Flat;
                    b.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                    b.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
                    b.TextColor = b.TextColor = Color.Black;
                    // b.text = TextImageRelation.ImageAboveText;
                    b.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
                    flowLayoutPanelItemList.Controls.Add(b);
                    //flowLayoutPanelItemList.Refresh();
                    currentImage++;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void ItemList_With_Button(string value, string Output)
        {
            flowLayoutPanelItemListButton.Controls.Clear();

            try
            {
                int AllowMinusQty = DataAccess.checkMinus();
                string sql = "";
                if (value != "")
                {
                    if (value == "All")
                    {
                        if (AllowMinusQty == 1)
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      "  where   RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }

                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                        }
                    }
                    else
                    {
                        if (AllowMinusQty == 1)//product_name_Arabic
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name";
                            }

                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  )  OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR   (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  )  OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR   (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name,CAT_MST.COLOR_NAME ";
                            }
                        }
                    }
                }
                else
                {
                    if (AllowMinusQty == 1)
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where    (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and RecipeType = 'Output'  and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }
                        else
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }

                    }
                    else
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (( product_name like '%" + value + "%' and OnHand >= 1) OR ( product_name_Arabic like '%" + value + "%')  " +
                                  " OR ( product_id like '%" + value + "%'  and OnHand >= 1) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  " +
                                  " OR (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }
                        else
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (( product_name like '%" + value + "%' and OnHand >= 1) OR ( product_name_Arabic like '%" + value + "%')  " +
                                  " OR ( product_id like '%" + value + "%'  and OnHand >= 1) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  " +
                                  " OR (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }

                    }
                }



                //" ORDER BY RANDOM() LIMIT 12 "; // Sqlite  //View vw_itemdisplay_sr   purchase
                // " ORDER BY RAND() LIMIT 12 "; // MySQL
                //  " ORDER BY NEWID() "; // SQL server and use -- top 12 after select  


                DataTable dt = DataAccess.GetDataTable(sql);

                itemCount.Text = "(" + dt.Rows.Count + ")";
                itemCount.Refresh();

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button b = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = (dataReader["product_id"] + "~" + dataReader["UOMNAME"] + "," + dataReader["CustItemCode"]);
                    b.Click += new EventHandler(btn_Click);

                    b.Margin = new Padding(1, 1, 1, 1);

                    b.Size = new Size(117, 65);
                   
                   // b.Text.PadRight(4);

                    string catname = dataReader["category"].ToString(); //Parimal
                   //   b.BackColor = GetCatagoryColor(catname);
                   //  b.Text += " " + dataReader["product_id"] + "\n ";
                    string COLORNAME = dataReader["COLOR_NAME"].ToString();
                    if (COLORNAME == string.Empty) { COLORNAME = "#ffffff"; }
                    int argb = Int32.Parse(COLORNAME.Replace("#", ""), NumberStyles.HexNumber);
                    Color clr = Color.FromArgb(argb);
                    b.BackColor = clr;



                    string PRdname = "";

                    if (UserInfo.Language == "English")
                    {
                        PRdname = dataReader["product_name"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        PRdname = dataReader["product_name_Arabic"].ToString();
                    }
                    else
                    {
                        PRdname = dataReader["product_name"].ToString();
                    }

                    string UOM = dataReader["UOMID"].ToString();
                    string UOM_Name = dataReader["UOMNAME"].ToString();
                    string PRodNamedis = dataReader["CustItemCode"] + " - " + PRdname;

                    if (PRodNamedis.Length >= 31)
                        b.Text += PRodNamedis.Substring(0, 25);
                    else
                        b.Text += PRodNamedis;

                    if (UserInfo.usertype == "1")
                    {
                        //if (dataReader["Rmsrp"] != null && dataReader["Rmsrp"].ToString() != "")//yogesh change 16 april 2019
                        //{
                        //    b.Text += "\n R.Price: " + dataReader["Rmsrp"] + " - " + UOM_Name;
                        //}
                        //else
                        //{//yogesh change 16 april 2019
                        b.Text += "\n " + dataReader["msrp"] + " - " + UOM_Name;
                        // }
                    }
                    else
                    {
                        b.Text += "\n " + UOM_Name;
                    }

                    //b.Text += "\n UOM: " + UOM_Name;
                    //b.Text += "\n Expiry: " + dataReader["ExpiryDate"];
                    b.Font = new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Pixel);
                    // b.Font = new Font("Times New Roman", 9, FontStyle.Regular, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;

                    b.FlatStyle = FlatStyle.Flat;

                    flowLayoutPanelItemListButton.Controls.Add(b);
                    //flowLayoutPanelItemListButton.Refresh();
                    currentImage++;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void ItemList_with_Grid(string value, string Output)
        {
            try
            {
                int AllowMinusQty = DataAccess.checkMinus();
                string sql = "";
                if (value != "")
                {
                    if (value == "All")
                    {
                        if (AllowMinusQty == 1)
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      "  where   RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM order by product_id,product_name ";
                            }
                            else
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                            else
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                        }
                    }
                    else
                    {
                        if (AllowMinusQty == 1)//product_name_Arabic
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name";
                            }
                            else
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name";
                            }

                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  )  OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR   (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                            else
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  )  OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR   (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                            }
                        }
                    }
                }
                else
                {
                    if (AllowMinusQty == 1)
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and RecipeType = 'Output'  and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }
                        else
                        {
                            sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (( product_name like '%" + value + "%') OR ( product_name_Arabic like '%" + value + "%') OR ( product_id like '%" + value + "%'  ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  OR  (CAT_MST.CAT_Name1 = '" + value + "')) and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0  group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }

                    }
                    else
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (( product_name like '%" + value + "%' and OnHand >= 1) OR ( product_name_Arabic like '%" + value + "%')  " +
                                  " OR ( product_id like '%" + value + "%'  and OnHand >= 1) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  " +
                                  " OR (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }
                        else
                        {
                            sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (( product_name like '%" + value + "%' and OnHand >= 1) OR ( product_name_Arabic like '%" + value + "%')  " +
                                  " OR ( product_id like '%" + value + "%'  and OnHand >= 1) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' )  " +
                                  " OR (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1)) and purchase.TenentID = " + Tenent.TenentID + "  and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_id,product_name ";
                        }

                    }
                }

               // DataTable dt = DataAccess.GetDataTable(sql);

              

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void ItemList_with_Catagory_images(string value, string Output)
        {
            flowLayoutPanelItemList.Controls.Clear();

            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";

            System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);

            if (di.Exists)
            {
                img_directory = UserInfo.Img_path;
            }

            string[] files = Directory.GetFiles(img_directory, "*.Png");
            try
            {
                int AllowMinusQty = DataAccess.checkMinus();
                string sql = "";
                if (value != "")
                {
                    if (value == "All")
                    {
                        if (AllowMinusQty == 1)
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }

                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                    }
                    else
                    {
                        if (AllowMinusQty == 1)
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "') and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "') and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                    }
                }
                else
                {
                    if (AllowMinusQty == 1)
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "') and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                        else
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "') and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_name,product_id ";
                        }
                    }
                    else
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM  order by product_name,product_id ";
                        }
                        else
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                    }
                }

                //" ORDER BY RANDOM() LIMIT 12 "; // Sqlite  //View vw_itemdisplay_sr   purchase
                // " ORDER BY RAND() LIMIT 12 "; // MySQL
                //  " ORDER BY NEWID() "; // SQL server and use -- top 12 after select  


                DataTable dt = DataAccess.GetDataTable(sql);

                itemCount.Text = "(" + dt.Rows.Count + ")";
                itemCount.Refresh();

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    DevComponents.DotNetBar.ButtonX b = new DevComponents.DotNetBar.ButtonX();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = (dataReader["product_id"] + "~" + dataReader["UOMNAME"] + "," + dataReader["CustItemCode"]);
                    b.Click += new EventHandler(b_Click);

                    string taxapply;
                    if (dataReader["taxapply"].ToString() == "1")
                    {
                        taxapply = "YES";
                    }
                    else
                    {
                        taxapply = "NO";
                    }

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(140, 80);
                    string image = "";
                    if (dataReader["Image"] != null && dataReader["Image"].ToString() != "" && dataReader["Image"].ToString() != "item.png")
                    {
                        image = dataReader["Image"].ToString();
                        string Filename = img_directory + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["Image"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }
                    else
                    {
                        image = dataReader["imagename"].ToString();
                        string Filename = img_directory + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["imagename"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }
                    il.Images.Add(Image.FromFile(img_directory + image));
                    b.Image = il.Images[0];
                    b.Margin = new Padding(1, 1, 1, 1);

                    b.Size = new Size(144, 110);
                  //  b.Text.PadRight(4);

                    //  b.Text += " " + dataReader["product_id"] + "\n ";


                    if (UserInfo.Language == "English")
                    {
                        b.Text += dataReader["product_name"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        b.Text += dataReader["product_name_Arabic"].ToString();
                    }
                    else
                    {
                        b.Text += dataReader["product_name"].ToString();
                    }

                    //b.Text += dataReader["product_name"].ToString();
                    //  b.Text += "\n Buy: " + dataReader["msrp"];
                   // b.Text += "\n ID: " + dataReader["CustItemCode"];

                    if (UserInfo.usertype == "1")
                    {
                        //if (dataReader["Rmsrp"] != null && dataReader["Rmsrp"].ToString() != "")
                        //{
                        //    b.Text += "\n R.Price: " + dataReader["Rmsrp"];
                        //}
                        //else
                        //{
                        b.Text += "\n Price: " + dataReader["msrp"];
                        //}
                    }

                    //b.Text += "\n Dis: " + dataReader["Discount"] + "% ";   //"Tax: " + taxapply;

                    string UOM = dataReader["UOMID"].ToString();
                    string UOM_Name = dataReader["UOMNAME"].ToString();

                   // b.Text += "\n UOM: " + UOM_Name;
                    //b.Text += "\n Expiry: " + dataReader["ExpiryDate"];
                    b.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                    // b.FlatStyle = FlatStyle.Flat;
                    b.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                    b.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
                    b.TextColor = Color.Black;
                    // b.text = TextImageRelation.ImageAboveText;
                    b.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
                    flowLayoutPanelItemList.Controls.Add(b);
                    //flowLayoutPanelItemList.Refresh();
                    currentImage++;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void ItemList_with_Catagory_With_Button(string value, string Output)
        {
           
            flowLayoutPanelItemListButton.SuspendLayout();
            flowLayoutPanelItemListButton.Controls.Clear();
           
           

            try
            {
                int AllowMinusQty = DataAccess.checkMinus();
                string sql = "";
                if (value != "")
                {
                    if (value == "All")
                    {
                        if (AllowMinusQty == 1)
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                    
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                    }
                    else
                    {
                        if (AllowMinusQty == 1)
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "') and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "') and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                    }
                }
                else
                {
                    if (AllowMinusQty == 1)
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "') and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                        else
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "') and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                    }
                    else
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                        else
                        {
                            sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice',CAT_MST.COLOR_NAME " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                    }
                }

                DataTable dt = DataAccess.GetDataTable(sql);

                itemCount.Text = "(" + dt.Rows.Count + ")";
                itemCount.Refresh();

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                  Button btn = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    btn.Tag = (dataReader["product_id"] + "~" + dataReader["UOMNAME"] + "," + dataReader["CustItemCode"]);
                    btn.Click += new EventHandler(btn_Click);

                    btn.Margin = new Padding(1, 1, 1, 1);

                    btn.Size = new Size(117, 65);
                   // b.Text.PadRight(4);

                    string catname = dataReader["category"].ToString(); //Parimal

                    string Name = dataReader["category"].ToString();
                    string COLORNAME = dataReader["COLOR_NAME"].ToString();
                    if (COLORNAME == string.Empty) { COLORNAME = "#ffffff"; }
                    int argb = Int32.Parse(COLORNAME.Replace("#", ""), NumberStyles.HexNumber);
                    Color clr = Color.FromArgb(argb);
                    btn.BackColor = clr;


                    string PRdname = "";

                    if (UserInfo.Language == "English")
                    {
                        PRdname = dataReader["product_name"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        PRdname = dataReader["product_name_Arabic"].ToString();
                    }
                    else
                    {
                        PRdname = dataReader["product_name"].ToString();
                    }

                    string UOM = dataReader["UOMID"].ToString();
                    string UOM_Name = dataReader["UOMNAME"].ToString();

                    string PRodNamedis = dataReader["CustItemCode"] + " - " + PRdname;
                    if (PRodNamedis.Length >= 31)
                        btn.Text += PRodNamedis.Substring(0, 25);
                    else
                        btn.Text += PRodNamedis;

                    if (UserInfo.usertype == "1")
                    {
                        //if (dataReader["Rmsrp"] != null && dataReader["Rmsrp"].ToString() != "")//yogesh change 16 april 2019
                        //{
                        //    b.Text += "\n R.Price: " + dataReader["Rmsrp"] + " - " + UOM_Name;
                        //}
                        //else
                        //{//yogesh change 16 april 2019
                        btn.Text += "\n " + dataReader["msrp"] + " - " + UOM_Name;
                        //}
                    }
                    else
                    {
                        btn.Text += "\n " + UOM_Name;
                    }

                    //b.Text += "\n UOM: " + UOM_Name;
                    //b.Text += "\n Expiry: " + dataReader["ExpiryDate"];

                    btn.Font = new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Pixel);
                    // b.Font = new Font("Times New Roman", 9, FontStyle.Regular, GraphicsUnit.Point);
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.TextImageRelation = TextImageRelation.ImageBeforeText;

                    btn.FlatStyle = FlatStyle.Flat;
        
                    flowLayoutPanelItemListButton.Controls.Add(btn);
                    flowLayoutPanelItemListButton.ResumeLayout();
                    //flowLayoutPanelItemListButton.Refresh();
                    currentImage++;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void ItemList_with_Package()
        {

           // flowLayoutPanelPackage.SuspendLayout();
           // flowLayoutPanelPackage.Controls.Clear();



            try
            {
                string sql = "select t.recNo,t.RecType,t.Receipe_English,t.Receipe_Arabic,m.itemcode,m.CostPrice,u.UOMNAME1 from tbl_Receipe t inner join Receipe_Menegement m " +
                "on t.recNo = m.recNo inner join ICUOM u on m.UOM = u.UOM where m.IOSwitch = 'Output' and u.TenentID = " + Tenent.TenentID;
                  
                DataTable dt = DataAccess.GetDataTable(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button b = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = (dataReader["itemcode"] + "~" + dataReader["UOMNAME1"] + "," + dataReader["itemcode"]);
                    b.Click += new EventHandler(P_Click);

                    b.Margin = new Padding(3, 3, 3, 3);

                    b.Size = new Size(117, 65);
                    b.Text.PadRight(4);

                    string COLORNAME = "#FFFFFF00"; 
                    int argb = Int32.Parse(COLORNAME.Replace("#", ""), NumberStyles.HexNumber);
                    Color clr = Color.FromArgb(argb);
                    b.BackColor = clr;
                    
                    string PRdname = "";

                    if (UserInfo.Language == "English")
                    {
                        PRdname = dataReader["Receipe_English"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        PRdname = dataReader["Receipe_Arabic"].ToString();
                    }
                 
                    string PRodNamedis = dataReader["itemcode"] + " - " + PRdname;
                    if (PRodNamedis.Length >= 31)
                        b.Text += PRodNamedis.Substring(0, 25);
                    else
                        b.Text += PRodNamedis;

                  
                    //b.Text += "\n UOM: " + UOM_Name;
                    //b.Text += "\n Expiry: " + dataReader["ExpiryDate"];
                    b.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    b.FlatStyle = FlatStyle.Flat;

                   // flowLayoutPanelPackage.Controls.Add(b);
                   // flowLayoutPanelPackage.ResumeLayout();
                    //flowLayoutPanelItemListButton.Refresh();
               

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void ItemList_with_Catagory_Grid(string value, string Output)
        {
            try
            {
                int AllowMinusQty = DataAccess.checkMinus();
                string sql = "";
                if (value != "")
                {
                    if (value == "All")
                    {
                        if (AllowMinusQty == 1)
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }

                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where   OnHand >= 1 and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                    }
                    else
                    {
                        if (AllowMinusQty == 1)
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "') and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "') and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                        else
                        {
                            if (Output == "Output")
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                            else
                            {
                                sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                      " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                      " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                      " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                            }
                        }
                    }
                }
                else
                {
                    if (AllowMinusQty == 1)
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "') and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                        else
                        {
                            sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "') and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                    }
                    else
                    {
                        if (Output == "Output")
                        {
                            sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where   (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                        else
                        {
                            sql = " SELECT (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name) as 'Item Name', (product_name_Arabic) as 'Item Name Arabic',(ICUOM.UOMNAME1) as 'UOM',(ICUOM.UOMNAME2) as 'UOM Arabic',case When Receipe_Menegement.Msrp is not null then printf('%.3f', Receipe_Menegement.Msrp) When Receipe_Menegement.Msrp is null then printf('%.3f',tbl_item_uom_price.msrp) End 'MSRP',category  " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                                  " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                  " where  (CAT_MST.CAT_Name1 = '" + value + "' and   OnHand >= 1) and purchase.TenentID = " + Tenent.TenentID + " and tbl_item_uom_price.msrp > 0 group by product_id,ICUOM.UOM order by product_name,product_id ";
                        }
                    }
                }

                //" ORDER BY RANDOM() LIMIT 12 "; // Sqlite  //View vw_itemdisplay_sr   purchase
                // " ORDER BY RAND() LIMIT 12 "; // MySQL
                //  " ORDER BY NEWID() "; // SQL server and use -- top 12 after select  


              

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgrvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                                                                                
        }
        private void dgrvProductList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           // foreach (DataGridViewRow Myrow in dgrvProductList.Rows)
           // {
           //     string CatID = Myrow.Cells["category"].Value.ToString();
           //     Myrow.DefaultCellStyle.BackColor = SalesRegister.GetCatagoryColor(CatID);
           // }
        }

        public void RelatedItemList_with_images(double value)
        {
            RelatedItemBind.ProdID = value;

           
            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";

            System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);

            if (di.Exists)
            {
                img_directory = UserInfo.Img_path;
            }
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg *.bmp *.jeg");
            try
            {
                int AllowMinusQty = DataAccess.checkMinus();
                string sql = "";

                if (AllowMinusQty == 1)
                {
                    sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                          " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                          " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                          " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                          " where purchase.TenentID = " + Tenent.TenentID + " and Receipe_Menegement.IOSwitch = 'Output'  and tbl_item_uom_price.msrp > 0 and  product_id in (select distinct RalatedProdID from TblProductRelated where myprodid=" + value + " or AlwaysShow='True' ) group by product_id,ICUOM.UOM  order by product_name,product_id";
                }
                else
                {
                    sql = " SELECT  Shopid,product_name,product_name_Arabic,product_name_print,category,supplier,status,taxapply,imagename,product_id,UOMID,ICUOM.UOMNAME1 as 'UOMNAME',tbl_item_uom_price.msrp as 'msrp',tbl_item_uom_price.price as 'price',Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,product_id,CustItemCode,BarCode,Receipe_Menegement.msrp as 'Rmsrp',Receipe_Menegement.CostPrice as 'RCostPrice' " +
                          " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                          " INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                          " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                          " where purchase.TenentID = " + Tenent.TenentID + " and Receipe_Menegement.IOSwitch = 'Output'  and tbl_item_uom_price.msrp > 0 and OnHand >= 1 and product_id in (select distinct RalatedProdID from TblProductRelated where myprodid=" + value + " or AlwaysShow='True' ) group by product_id,ICUOM.UOM order by product_name,product_id ";

                }
                //" ORDER BY RANDOM() LIMIT 12 "; // Sqlite  //View vw_itemdisplay_sr   purchase
                // " ORDER BY RAND() LIMIT 12 "; // MySQL
                //  " ORDER BY NEWID() "; // SQL server and use -- top 12 after select  

                DataTable dt = DataAccess.GetDataTable(sql);


                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button Rb = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    //Rb.Tag = (dataReader["product_id"] + "~" + dataReader["UOMID"]);
                    Rb.Tag = (dataReader["product_id"] + "~" + dataReader["UOMNAME"] + "," + dataReader["CustItemCode"]);
                    Rb.Click += new EventHandler(Rb_Click);

                    string taxapply;
                    if (dataReader["taxapply"].ToString() == "1")
                    {
                        taxapply = "YES";
                    }
                    else
                    {
                        taxapply = "NO";
                    }

                    string details = dataReader["product_id"] +
                     "\n Name: " + dataReader["product_name"].ToString() +
                     "\n Buy price: " + dataReader["msrp"].ToString() +
                     "\n Stock Qty: " + dataReader["OnHand"].ToString() +
                     "\n Retail price: " + dataReader["price"].ToString() +
                        //"\n Discount: " + dataReader["discount"].ToString() + yogesh
                     "\n Category: " + dataReader["category"].ToString() +
                     "\n Supplier: " + dataReader["supplier"].ToString() +
                     "\n Branch: " + dataReader["Shopid"].ToString() +
                     "\n Tax Apply: " + taxapply;
                    Rb.Name = details;
                    //toolTip1.ToolTipTitle = "Item Details";  // If you want to Show tooltip please uncomment
                    //  toolTip1.SetToolTip(b, details);          //Umncomment

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(78, 80);
                    string image = "";
                    if (dataReader["Image"] != null && dataReader["Image"].ToString() != "" && dataReader["Image"].ToString() != "item.png")
                    {
                        image = dataReader["Image"].ToString();
                        string Filename = img_directory + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["Image"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }
                    else
                    {
                        image = dataReader["imagename"].ToString();
                        string Filename = img_directory + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["imagename"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }
                    il.Images.Add(Image.FromFile(img_directory + image));
                    Rb.Image = il.Images[0];
                    Rb.Margin = new Padding(3, 3, 3, 3);

                    Rb.Size = new Size(200, 100);
                    Rb.Text.PadRight(4);

                    //  b.Text += " " + dataReader["product_id"] + "\n ";
                    if (UserInfo.Language == "English")
                    {
                        Rb.Text += dataReader["product_name"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        Rb.Text += dataReader["product_name_Arabic"].ToString();
                    }
                    else
                    {
                        Rb.Text += dataReader["product_name"].ToString();
                    }
                    //  b.Text += "\n Buy: " + dataReader["msrp"];
                    Rb.Text += "\n ID: " + dataReader["CustItemCode"];

                    if (UserInfo.usertype == "1")
                    {
                        //if (dataReader["Rmsrp"] != null && dataReader["Rmsrp"].ToString() != "")
                        //{
                        //    Rb.Text += "\n R.Price: " + dataReader["Rmsrp"];
                        //}
                        //else
                        //{
                        Rb.Text += "\n R.Price: " + dataReader["msrp"];
                        //}
                    }

                    //Rb.Text += "\n Dis: " + dataReader["Discount"] + "% ";   //"Tax: " + taxapply;
                    string UOM = dataReader["UOMID"].ToString();

                    string UOM_Name = dataReader["UOMNAME"].ToString();

                    Rb.Text += "\n UOM: " + UOM_Name;
                    //Rb.Text += "\n Expiry: " + dataReader["ExpiryDate"];
                    Rb.Font = new Font(" Trebuchet MS", 10, FontStyle.Regular, GraphicsUnit.Point);
                
                    Rb.TextAlign = ContentAlignment.MiddleLeft;
                    Rb.TextImageRelation = TextImageRelation.ImageBeforeText;
                  //  PenalRelateditems.Controls.Add(Rb);
                    currentImage++;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //Product filter by Product Name or Product ID

        private void DisplayTextItemSearch()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            //Thread.Sleep(1);

            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    DateTime Start = DateTime.Now;

                    if (txtSearchItem.Text != "" && txtSearchItem.Text != " " && txtSearchItem.Text != null)
                    {
                        if (chkWithGrid.Checked == true)
                        {

                            if (chkoutput.Checked == true)
                            {
                                ItemList_with_Grid(txtSearchItem.Text, "Output");
                            }
                            else
                            {
                                ItemList_with_Grid(txtSearchItem.Text, "");
                            }
                        }
                        else if (chkImage.Checked == true)
                        {
                            if (chkoutput.Checked == true)
                            {
                                ItemList_with_images(txtSearchItem.Text, "Output");
                            }
                            else
                            {
                                ItemList_with_images(txtSearchItem.Text, "");
                            }
                        }
                        else
                        {
                            if (chkoutput.Checked == true)
                            {
                                ItemList_With_Button(txtSearchItem.Text, "Output");
                            }
                            else
                            {
                                ItemList_With_Button(txtSearchItem.Text, "");
                            }
                        }
                    }
                    lblstart.Text = Math.Round(DateTime.Now.Subtract(Start).TotalSeconds, 3).ToString();
                    addprodtoinvoiceContainer();

                });
            }
            catch
            {

            }

            SetLoading(false);
        }
        public void addprodtoinvoiceContainer()
        {
            int Sales_id = Convert.ToInt32(txtInvoice.Text);
            bool ISPaymentCredit = CheckISPaymentCredit(Sales_id);
            if (ISPaymentCredit == true)
            {
                MessageBox.Show(" This Invoice is Creadit invoice It Not Allow to Add Item ");
                txtSearchItem.Text = "";
                return;
            }

            if (txtSearchItem.Text == "")
            {
                //  MessageBox.Show("Please Insert Product id : ");
                //textBox1.Focus();
            }
            else
            {
                try
                {
                    string product_id = "0", CustItemCode = "0";
                    int UOMID = 0;
                    string UOMName = "Piece";

                    string Sqlcheck = " select product_id,CustItemCode,UOMID  from purchase pi inner join tbl_item_uom_price iup ON pi.product_id = iup.itemID and pi.TenentID = iup.TenentID " +
                                 " where pi.TenentID = " + Tenent.TenentID + " and  pi.BarCode = '" + txtSearchItem.Text.Trim() + "'";
                    DataTable dtcheck = DataAccess.GetDataTable(Sqlcheck);
                    if (dtcheck.Rows.Count == 1)
                    {
                        CustItemCode = dtcheck.Rows[0]["CustItemCode"].ToString();
                        product_id = dtcheck.Rows[0]["product_id"].ToString();
                        UOMID = Convert.ToInt32(dtcheck.Rows[0]["UOMID"]); ;
                        UOMName = Add_Item.getuomName(UOMID);

                    }
                    else
                    {
                        return;
                    }



                    // Default tax rate 
                    double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                    //- new in 8.1 version // Default Product QTY is 1

                    int AllowMinusQty = DataAccess.checkMinus();
                    string sql = "";
                    if (AllowMinusQty == 1)
                    {
                        sql = " SELECT  product_name as Name , tbl_item_uom_price.msrp as Price , Receipe_menegement.msrp as RMSRP , 1.00  as QTY, tbl_item_uom_price.msrp  as 'Total' , " +
                              " Receipe_menegement.msrp as 'RTotal' ,  (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00) as 'disamt' , " +
                              " (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00) as 'Rdisamt' , " +
                              " CASE WHEN taxapply = 1 THEN (((tbl_item_uom_price.msrp * 1.00 ) - (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'taxamt' , " +
                              " CASE WHEN taxapply = 1 THEN (((Receipe_menegement.msrp * 1.00 ) - (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'Rtaxamt', " +
                              " product_id as ID , Discount , taxapply, status,UOMID " +
                              " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                              " LEFT JOIN Receipe_menegement ON tbl_item_uom_price.itemID = Receipe_menegement.ItemCode and tbl_item_uom_price.UOMID = Receipe_menegement.UOM and tbl_item_uom_price.TenentID = Receipe_menegement.TenentID " +
                              " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + product_id + "' and UOMID = '" + UOMID + "' and CustItemCode = '" + CustItemCode + "' ";
                    }
                    else
                    {
                        sql = " SELECT  product_name as Name , tbl_item_uom_price.msrp as Price , Receipe_menegement.msrp as RMSRP , 1.00  as QTY, tbl_item_uom_price.msrp  as 'Total' , " +
                              " Receipe_menegement.msrp as 'RTotal' ,  (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00) as 'disamt' , " +
                              " (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00) as 'Rdisamt' , " +
                              " CASE WHEN taxapply = 1 THEN (((tbl_item_uom_price.msrp * 1.00 ) - (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'taxamt' , " +
                              " CASE WHEN taxapply = 1 THEN (((Receipe_menegement.msrp * 1.00 ) - (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'Rtaxamt', " +
                              " product_id as ID , Discount , taxapply, status,UOMID " +
                              " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                              " LEFT JOIN Receipe_menegement ON tbl_item_uom_price.itemID = Receipe_menegement.ItemCode and tbl_item_uom_price.UOMID = Receipe_menegement.UOM and tbl_item_uom_price.TenentID = Receipe_menegement.TenentID " +
                              " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + product_id + "' and UOMID = '" + UOMID + "'  and CustItemCode = '" + CustItemCode + "'  and OnHand >= 1 ";
                    }

                    bool First = false;
                    double prodid = 0;
                    int QtyEn = 1;
                    string Batch = "", Serial = "";//yogesh

                    DataTable dt = DataAccess.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        int rcount = dt.Rows.Count - 1;//yogesh
                        string Itemid = dt.Rows[rcount]["ID"].ToString();
                        string ProdName = dt.Rows[rcount]["Name"].ToString();
                        string ItemsName = CustItemCode + "-" + dt.Rows[rcount]["Name"].ToString() + "~" + UOMName;
                        double Rprice = 0;
                        if (lblIsReciepe.Text == "Yes")
                        {
                            Rprice = dt.Rows[rcount]["RMSRP"] != null && dt.Rows[rcount]["RMSRP"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["RMSRP"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["Price"].ToString());
                            lblIsReciepe.Text = "-";
                        }
                        else
                        {
                            Rprice = Convert.ToDouble(dt.Rows[rcount]["Price"].ToString());
                        }
                        //Yogesh April 19 dt.Rows[rcount]["RMSRP"] != null && dt.Rows[rcount]["RMSRP"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["RMSRP"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["Price"].ToString());
                        double Qty = Convert.ToDouble(dt.Rows[rcount]["QTY"].ToString());
                        double Total = dt.Rows[rcount]["RTotal"] != null && dt.Rows[rcount]["RTotal"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["RTotal"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["Total"].ToString());
                        double Disamt = 0;//yogesh dt.Rows[0]["Rdisamt"] != null && dt.Rows[0]["Rdisamt"].ToString() != "" ? Convert.ToDouble(dt.Rows[0]["Rdisamt"].ToString()) : Convert.ToDouble(dt.Rows[0]["disamt"].ToString());       //  Total Discount amount of this item
                        double Taxamt = dt.Rows[rcount]["Rtaxamt"] != null && dt.Rows[rcount]["Rtaxamt"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["Rtaxamt"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["taxamt"].ToString());       //  Total Tax amount  of this item
                        //double Dis = Convert.ToDouble(dt.Rows[rcount]["Discount"].ToString());yogesh       //  Discount Rate
                        double Taxapply = Convert.ToDouble(dt.Rows[rcount]["taxapply"].ToString());       //  VAT/TAX/TPS/TVQ apply or not
                        int kitchendisplay = Convert.ToInt32(dt.Rows[rcount]["status"].ToString());        //  kitchen display 3= show 1= not display in kitchen 

                        prodid = Convert.ToDouble(Itemid);
                        int UOMchk = getuomid(UOMName);
                        //Add to Item list
                        // long i = 1;
                        #region PeriSer
                        bool flagperi = IsPerishable(prodid);
                        bool flagSerial = IsSerialize(prodid);
                        int n = Finditem(ItemsName, CustItemCode, flagperi, flagSerial);
                        if (n == -1)  //If new item
                        {
                            if (flagperi == true)
                            {
                                bool itemFound = BindPerishable(prodid, UOMchk);
                                if (itemFound == true)
                                {
                                    dgrvSalesItemList.ClearSelection();
                                    //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                                    dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode);
                                    int Rowcount = dgrvSalesItemList.Rows.Count - 1;
                                    dgrvSalesItemList.Rows[Rowcount].Selected = true;
                                    dgrvSalesItemList.FirstDisplayedScrollingRowIndex = Rowcount;

                                }

                            }
                            else if (flagSerial == true)//yogesh
                            {
                                bool itemFound = BindSerialize(prodid, UOMchk);
                                if (itemFound == true)
                                {
                                    dgrvSalesItemList.ClearSelection();
                                    //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                                    dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode);
                                    int Rowcount = dgrvSalesItemList.Rows.Count - 1;
                                    dgrvSalesItemList.Rows[Rowcount].Selected = true;
                                    dgrvSalesItemList.FirstDisplayedScrollingRowIndex = Rowcount;
                                }
                            }
                            else if (!flagperi && !flagSerial)
                            {
                                dgrvSalesItemList.ClearSelection();
                                //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                                dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode);
                                //dgrvSalesItemList.CellClick += new EventHandler(dgrvSalesItemList_CellClick);
                                int Rowcount = dgrvSalesItemList.Rows.Count - 1;
                                dgrvSalesItemList.Rows[Rowcount].Selected = true;
                                dgrvSalesItemList.FirstDisplayedScrollingRowIndex = Rowcount;
                            }

                        #endregion
                            QtyEn = Convert.ToInt32(Qty);
                            First = true;
                        }
                        else  // if same item Quantity increase by 1 
                        {

                            First = false;
                            //  dgrvSalesItemList.Rows[n].Cells[0].Value = ItemsName;
                            // dgrvSalesItemList.Rows[n].Cells[1].Value = Rprice;
                            #region PeriSer
                            double Prodid = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[4].Value);
                            bool flagpp = IsPerishable(Prodid);
                            bool flagss = IsSerialize(Prodid);
                            if (flagpp == true)
                            {
                                string Batch_No = "";
                                if (dgrvSalesItemList.Rows[n].Cells[10].Value != null)
                                    Batch_No = dgrvSalesItemList.Rows[n].Cells[10].Value.ToString();


                                int OnHand = 0;
                                if (dgrvSalesItemList.Rows[n].Cells[11].Value != null)
                                    OnHand = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[11].Value);


                                int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                QtyEn = (QtyInc + 1);
                                if (OnHand >= QtyEn && OnHand != 0)
                                {
                                    string MySysName = "SAL";
                                    int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                    dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                                    dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                                    //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                                    double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                    double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                                    if (disrate != 0)  // if discount has
                                    {
                                        double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                        dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                                    }

                                    if (Taxapply != 0)   // If apply  tax 
                                    {
                                        // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                                        double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                                        dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                                    }


                                    bool flagp = CheckPerishableTemp(Prodid, UOMID, Batch_No, MYTRANSID, MySysName);
                                    if (flagp == true)//Perisable yogesh
                                    {
                                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        string sql1 = "Update ICIT_BR_TMP set NewQty='" + QtyEn + "', " +
                                                      " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                                      " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                        DataAccess.ExecuteSQL(sql1);
                                        Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMP", "UPDATE");
                                    }
                                    else
                                    {
                                        if (Application.OpenForms["SalesPerishable"] != null)
                                        {
                                            Application.OpenForms["SalesPerishable"].Close();
                                        }
                                        SalesPerishable mkc1 = new SalesPerishable(Prodid, ProdName, UOMName, MYTRANSID, MySysName, "");
                                        mkc1.Qty = QtyEn;
                                        mkc1.Show();
                                    }


                                }
                                //else
                                //{

                                //    MessageBox.Show("Batch " + Batch_No + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");
                                //    First = true;
                                //    Batch = Batch_No;
                                //}
                            }
                            else if (flagss == true)
                            {
                                //    string Serial_Number = "";

                                //if (dgrvSalesItemList.Rows[n].Cells[17].Value != null)
                                //    Serial_Number = dgrvSalesItemList.Rows[n].Cells[17].Value.ToString();

                                //int OnHand = 0;
                                //if (dgrvSalesItemList.Rows[n].Cells[11].Value != null && dgrvSalesItemList.Rows[n].Cells[11].Value!="")
                                //    OnHand = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[11].Value);


                                //int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                //QtyEn = (QtyInc + 1);
                                //if (OnHand >= QtyEn && OnHand != 0)
                                //{
                                string MySysName = "SAL";
                                int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                //    dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                                //    dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                                //    //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                                //    double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                //    double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                                //if (disrate != 0)  // if discount has
                                //{
                                //    double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                //    dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                                //}

                                //if (Taxapply != 0)   // If apply  tax 
                                //{
                                //    // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                                //    double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                                //    dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                                //}                   

                                //bool flags = CheckSerializeTemp(Prodid, UOMID, Serial_Number, MYTRANSID, MySysName);
                                //if (flags)//Serialize yogesh
                                //{
                                //    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                //    string sql1 = "Update ICIT_BR_TMPSerialize set NewQty='" + QtyEn + "', " +
                                //                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                //                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                //    DataAccess.ExecuteSQL(sql1);
                                //    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "UPDATE");
                                //}
                                //else
                                if (n == -1)  //If new item
                                {
                                    if (Application.OpenForms["SalesSerialize"] != null)
                                    {
                                        Application.OpenForms["SalesSerialize"].Close();
                                    }
                                    SalesSerialize mkc1 = new SalesSerialize(Prodid, ProdName, UOMName, MYTRANSID, MySysName, "");
                                    mkc1.Qty = QtyEn;
                                    mkc1.Show();
                                }
                                else
                                {
                                    txtSearchItem.Text = "";
                                    MessageBox.Show("Already this Product in Container.");
                                    return;
                                }

                                //}

                                //else
                                //{

                                //    MessageBox.Show("Serial " + Serial_Number + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");

                                //    First = true;
                                //    Serial = Serial_Number;
                                //}

                            }
                            else
                            {
                                int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                                dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                                //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                                double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                                if (disrate != 0)  // if discount has
                                {
                                    double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                    dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                                }

                                if (Taxapply != 0)   // If apply  tax 
                                {
                                    // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                                    double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                                    dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                                }

                            }
                            #endregion
                            // dgrvSalesItemList.Rows[n].Cells[7].Value = Dis; // Discount rate
                            //  dgrvSalesItemList.Rows[n].Cells[8].Value = Taxapply;  //Tax apply
                            //  dgrvSalesItemList.Rows[n].Cells[9].Value = kitchendisplay;

                        }
                    }

                    //Hide fields
                    dgrvSalesItemList.Columns[4].Visible = false; // ID             // new in 8.1 version
                    dgrvSalesItemList.Columns[5].Visible = false; // Disamt         // new in 8.1 version
                    dgrvSalesItemList.Columns[6].Visible = false; // taxamt         // new in 8.1 version
                    // dgrvSalesItemList.Columns[7].Visible = false; // Discount rate  // new in 8.1 version yogesh
                    dgrvSalesItemList.Columns[9].Visible = false; // kitdisplay    // new in 8.3.1 version

                    dgrvSalesItemList.Columns[10].Visible = false; // BatchNo    
                    dgrvSalesItemList.Columns[11].Visible = false; // OnHand    
                    dgrvSalesItemList.Columns[12].Visible = false; // ExpiryDate

                    dgrvSalesItemList.Columns[13].Visible = false; // SalesID    
                    dgrvSalesItemList.Columns[14].Visible = false; // invoice 
                    dgrvSalesItemList.Columns[15].Visible = false; // CID  
                    dgrvSalesItemList.Columns[17].Visible = false; // SerailNo
                    dgrvSalesItemList.Columns[18].Visible = false; // SerailNo
                    txtSearchItem.Text = "";
                    txtSearchItem.Focus();

                   // btnSuspend.Enabled = true;
                   // btnCashAndPrint.Enabled = true;
                    //if (lblIsCustAdvanceAmtYN.Text == ".")
                    //    btnSalesCredit.Enabled = false;
                    //else
                    //    btnSalesCredit.Enabled = true;

                    DiscountCalculation();
                    vatcal();
                    txtDiscountRate.Text = "0";

                    if (First == true)
                    {
                        #region PeriSer
                        bool flag = IsPerishable(prodid);
                        if (flag == true)
                        {
                            string ProdName = GetProdName(prodid);
                            string MySysName = "SAL";
                            int MY_TRANS_ID = Convert.ToInt32(txtInvoice.Text);

                            if (Application.OpenForms["SalesPerishable"] != null)
                            {
                                Application.OpenForms["SalesPerishable"].Close();
                            }
                            SalesPerishable mkc1 = new SalesPerishable(prodid, ProdName, UOMName, MY_TRANS_ID, MySysName, Batch);
                            mkc1.Qty = QtyEn;
                            mkc1.Show();
                        }
                        bool flagss = IsSerialize(prodid);
                        if (flagss == true)
                        {
                            string ProdName = GetProdName(prodid);
                            string MySysName = "SAL";
                            int MY_TRANS_ID = Convert.ToInt32(txtInvoice.Text);

                            if (Application.OpenForms["SalesSerialize"] != null)
                            {
                                Application.OpenForms["SalesSerialize"].Close();
                            }
                            SalesSerialize mkc1 = new SalesSerialize(prodid, ProdName, UOMName, MY_TRANS_ID, MySysName, Serial);
                            mkc1.Qty = QtyEn;
                            mkc1.Show();
                        }
                        #endregion
                    }
                }
                catch
                {
                    // MessageBox.Show("Problem in Barcode ");
                    txtSearchItem.Text = "";
                    return;
                }

            }
        }
        public void TextItemSearch()
        {
            try
            {
                Thread threadInput = new Thread(DisplayTextItemSearch);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }

        }
        private void btnSerchItem_Click(object sender, EventArgs e)
        {
            TextItemSearch();
        }
        private void txtSearchItem_Leave(object sender, EventArgs e)
        {
            TextItemSearch();
        }
        public string GetProdName(double ProdID)
        {
            string prodName = null;
            string sql12 = " select * from purchase where TenentID = " + Tenent.TenentID + " and product_id = '" + ProdID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                prodName = dt1.Rows[0]["product_name"].ToString();
            }
            return prodName;
        }
        public double GetProdID(string prodName)
        {
            double ProdID = 0;

            prodName = prodName.Trim();
            string sql12 = " select * from purchase where TenentID = " + Tenent.TenentID + " and product_name = '" + prodName + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                ProdID = Convert.ToInt32(dt1.Rows[0]["product_id"]);
            }
            return ProdID;
        }
        #region Is PeriSer
        public static void IsPerishablesale(double ProdID,out bool peishabl,out bool serilize,out string product)
        {
            string sql12 = " select IsPerishable,IsSerialize,product_name from purchase where TenentID = " + Tenent.TenentID + " and product_id = '" + ProdID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                product = dt1.Rows[0]["product_name"].ToString();
                int Perishable = Convert.ToInt32(dt1.Rows[0]["IsPerishable"]);
                if (Perishable == 1)
                    peishabl = true;
                else
                    peishabl = false;

                int Serialize = dt1.Rows[0]["IsSerialize"].ToString() == null || dt1.Rows[0]["IsSerialize"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[0]["IsSerialize"].ToString());
                if (Serialize == 1)
                    serilize = true;
                else
                    serilize = false;

            }
            else
            {
                serilize = false;
                peishabl = false;
                product = "";
            }

        }
        public static bool IsPerishable(double ProdID)
        {
            string sql12 = " select IsPerishable from purchase where TenentID = " + Tenent.TenentID + " and product_id = '" + ProdID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                int Perishable = Convert.ToInt32(dt1.Rows[0]["IsPerishable"]);
                if (Perishable == 1)
                    return true;
                else
                    return false;

            }
            else
            {
                return false;
            }

        }
        public static bool IsSerialize(double ProdID)//yogesh
        {
            string sql12 = " select IsSerialize from purchase where TenentID = " + Tenent.TenentID + " and product_id = '" + ProdID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {

                int Serialize = dt1.Rows[0]["IsSerialize"].ToString() == null || dt1.Rows[0]["IsSerialize"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[0]["IsSerialize"].ToString());
                if (Serialize == 1)
                    return true;
                else
                    return false;

            }
            else
            {
                return false;
            }

        }
        #endregion
        //Click add to cart
        protected void b_Click(object sender, EventArgs e)
        {
            _Tab = 0;
            DevComponents.DotNetBar.ButtonX b = sender as DevComponents.DotNetBar.ButtonX;
            string s;
            s = " ID: ";
            s += b.Tag;
            s += "\n Name: ";
            s += b.Name.ToString();

            double prodid = Convert.ToDouble(b.Tag.ToString().Split('~')[0]);

            string Text = b.Tag.ToString();
            txtBarcodeReaderBox.Text = Text;

            if (RelatedItemBind.ProdID != prodid)
            {
                RelatedItemList_with_images(prodid);
            }

        }
        protected void btn_Click(object sender, EventArgs e)
        {
            _Tab = 0;
           Button b = sender as Button;
            string s;
            s = " ID: ";
            s += b.Tag;
            s += "\n Name: ";
            s += b.Name.ToString();

            double prodid = Convert.ToDouble(b.Tag.ToString().Split('~')[0]);

            string Text = b.Tag.ToString();
            txtBarcodeReaderBox.Text = Text;
         
           //if (RelatedItemBind.ProdID != prodid)
           //{
           //    RelatedItemList_with_images(prodid);
           //}

        }
        protected void P_Click(object sender, EventArgs e)
        {
            _Tab = 1;
            Button b = sender as Button;
            string s;
            s = " ID: ";
            s += b.Tag;
            s += "\n Name: ";
            s += b.Name.ToString();

            double prodid = Convert.ToDouble(b.Tag.ToString().Split('~')[0]);

            string Text = b.Tag.ToString();
            txtBarcodeReaderBox.Text = Text;

            if (RelatedItemBind.ProdID != prodid)
            {
                // RelatedItemList_with_images(prodid);
            }

        }
        protected void Rb_Click(object sender, EventArgs e)
        {
            _Tab = 0;
            Button Rb = sender as Button;
            string s;
            s = " ID: ";
            s += Rb.Tag;
            s += "\n Name: ";
            s += Rb.Name.ToString();

            double prodid = Convert.ToDouble(Rb.Tag.ToString().Split('~')[0]);

            string Text = Rb.Tag.ToString();
            txtBarcodeReaderBox.Text = Text;
        }

        //// BarCode or keyboard input  items code  || add to cart
        private void txtBarcodeReaderBox_TextChanged(object sender, EventArgs e)
        {
         
        }
        #region PeriSerBind
        public bool BindPerishable(double MyProdID, int uom)
        {
            string query = "select count(*)  from ICIT_BR_Perishable where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and OnHand>=1 ";
            DataTable dtquery = DataAccess.GetDataTable(query);
            if (dtquery.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //BatchNo,OnHand,ProdDate,ExpiryDate,LeadDays2Destroy
        }
        public bool BindSerialize(double MyProdID, int uom)
        {
            string query = "select Serial_Number,OnHand from ICIT_BR_Serialize where TenentID =" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and OnHand>=1 ";
            DataTable dtquery = DataAccess.GetDataTable(query);
            if (dtquery.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        // Check duplicate item 
        public int Finditem(string item, string CustItemCode, bool isPerisable, bool isSerialize)
        {
            int k = -1;

         
            if (dgrvSalesItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgrvSalesItemList.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item) && row.Cells[16].Value.ToString().Equals(CustItemCode))
                    {
                        k = row.Index;


                        break;
                    }
                }
            }
            return k;
        }
        public int FindPayment(string item)
        {
            int k = -1;
            if (GridPayment.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in GridPayment.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(item))
                    {
                        k = row.Index;
                        break;
                    }
                }
            }
            return k;
        }
        public string GetGrid_BatchNo(string item)
        {
            string Batch = "";
            if (dgrvSalesItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgrvSalesItemList.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item))
                    {
                        Batch = Batch + "," + row.Cells[10].Value.ToString();
                    }
                }
            }

            Batch = Batch.Trim();
            Batch = Batch.TrimStart(',');
            Batch = Batch.TrimEnd(',');

            return Batch;
        }
        public string GetGrid_Serial(string item)
        {
            string Serial = "";
            if (dgrvSalesItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgrvSalesItemList.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item))
                    {
                        Serial = Serial + "," + row.Cells[17].Value.ToString();
                    }
                }
            }

            Serial = Serial.Trim();
            Serial = Serial.TrimStart(',');
            Serial = Serial.TrimEnd(',');

            return Serial;
        }
        public int UpdateItem(string item, string BatchNo, int OnHand, string ExpiryDate)
        {
            int k = -1;
            if (dgrvSalesItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgrvSalesItemList.Rows)
                {
                    string ItemsNam = row.Cells[0].Value.ToString().Split('-')[1].Trim();
                    //string ItemsNam = row.Cells[0].Value.ToString().Trim();

                    if (ItemsNam.Equals(item))
                    {
                        k = row.Index;

                        //dgrvSalesItemList.Columns[10].Visible = false; // BatchNo    
                        //dgrvSalesItemList.Columns[11].Visible = false; // OnHand 
                        //dgrvSalesItemList.Columns[12].Visible = false; // ExpiryDate 

                        if (row.Cells[10].Value.ToString() != null && row.Cells[10].Value.ToString() != "")
                        {
                            if (row.Cells[10].Value.ToString().Equals(BatchNo))
                            {

                            }
                            else
                            {
                                string ItemsName = row.Cells[0].Value.ToString();
                                string Rprice = row.Cells[1].Value.ToString();
                                string Qty = "1";
                                string Itemid = row.Cells[4].Value.ToString();
                                string Disamt = row.Cells[5].Value.ToString();
                                string Taxamt = row.Cells[6].Value.ToString();
                                //string Dis = row.Cells[7].Value.ToString();
                                string Taxapply = row.Cells[8].Value.ToString();
                                string kitchendisplay = row.Cells[9].Value.ToString();
                                string CustItemCode = row.Cells[16].Value.ToString();
                                string grdserial = row.Cells[17].Value.ToString();
                                string ItemNote = row.Cells[18].Value.ToString();
                                //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay, BatchNo, OnHand, ExpiryDate);
                                dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, BatchNo, OnHand, ExpiryDate, "", "", "", CustItemCode, "0", grdserial, ItemNote);

                            }
                        }
                        else
                        {
                            row.Cells[10].Value = BatchNo;
                            row.Cells[11].Value = OnHand;
                            row.Cells[12].Value = ExpiryDate;
                        }

                        break;
                    }
                }
            }
            return k;
        }
        public int UpdateItemSerial(string item, string Serial_Number, int OnHand)
        {
            int k = -1;
            if (dgrvSalesItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgrvSalesItemList.Rows)
                {
                    string ItemsNam = row.Cells[0].Value.ToString().Split('-')[1].Trim();
                    //string ItemsNam = row.Cells[0].Value.ToString().Trim();

                    if (ItemsNam.Equals(item))
                    {
                        k = row.Index;

                        //dgrvSalesItemList.Columns[10].Visible = false; // BatchNo    
                        //dgrvSalesItemList.Columns[11].Visible = false; // OnHand 
                        //dgrvSalesItemList.Columns[12].Visible = false; // ExpiryDate 
                        string[] serial = Serial_Number.Split('~');
                        int seriallistcount = Convert.ToInt32(serial.Count());

                        if (row.Cells[17].Value != null && row.Cells[17].Value != "")
                        {
                            if (row.Cells[17].Value.ToString().Equals(Serial_Number))
                            {

                            }
                            else
                            {
                                string ItemsName = row.Cells[0].Value.ToString();
                                string Rprice = row.Cells[1].Value.ToString();
                                string Qty = "1";
                                string Itemid = row.Cells[4].Value.ToString();
                                string Disamt = row.Cells[5].Value.ToString();
                                string Taxamt = row.Cells[6].Value.ToString();
                                //string Dis = row.Cells[7].Value.ToString();
                                string Taxapply = row.Cells[8].Value.ToString();
                                string kitchendisplay = row.Cells[9].Value.ToString();
                                string CustItemCode = row.Cells[16].Value.ToString();
                                string grdserial = row.Cells[17].Value.ToString();
                                string ItemNote = row.Cells[18].Value.ToString();
                                //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay, BatchNo, OnHand, ExpiryDate);
                                dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "0", OnHand, "", "", "", "", CustItemCode, grdserial, ItemNote);

                            }
                        }
                        else
                        {
                            row.Cells[17].Value = Serial_Number;
                            row.Cells[11].Value = OnHand;//OnHand
                            row.Cells[2].Value = seriallistcount;
                        }

                        break;
                    }
                }
            }
            return k;
        }
        public int UpdateInvo(string item, string SalesID, string invoice, string CID)
        {
            int k = -1;
            if (dgrvSalesItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgrvSalesItemList.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item))
                    {
                        k = row.Index;

                        //dgrvSalesItemList.Columns[13].Visible = true; // SalesID    
                        //dgrvSalesItemList.Columns[14].Visible = false; // invoice 
                        //dgrvSalesItemList.Columns[15].Visible = false; // CID   


                        row.Cells[13].Value = SalesID;
                        row.Cells[14].Value = invoice;
                        row.Cells[15].Value = CID;

                    }
                }
            }
            return k;
        }

        #endregion

        #region Category Databind and click event  | Product filter by Category
        //Show Category    -- Add new from 8.3.2
        public void CategoryList()
        {
            flwLyoutCategoryPanel.Controls.Clear();

            try
            {
                string sql = "";
                if (chkoutput.Checked == true)
                {
                    //  sql = "select   DISTINCT  category   from  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID  INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                      //  " Where tbl_item_uom_price.RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  order by DisplaySort";
                   sql = "select CATID as category ,CAT_NAME1,CAT_NAME2,COLOR_NAME  FROM CAT_MST where TenentID = " + Tenent.TenentID ;
                }
                else
                {
                    //  sql = "select   DISTINCT  category   from  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID  INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID " +
                    //   " Where purchase.TenentID = " + Tenent.TenentID + " order by DisplaySort";
                    sql = "select CATID as category ,CAT_NAME1,CAT_NAME2,COLOR_NAME  FROM CAT_MST where TenentID = " + Tenent.TenentID;
                }

                DataTable dt = DataAccess.GetDataTable(sql);

               DataRow toInsert = dt.NewRow();
               toInsert[0] = "0";
               toInsert[1] = "All";
                toInsert[2] = "All";
                toInsert[3] = "FFFFFF";
                dt.Rows.InsertAt(toInsert, 0);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    //   DevComponents.DotNetBar.ButtonX category = new DevComponents.DotNetBar.ButtonX();
                    Button category = new Button();
                    category.Tag = dataReader["category"];

                    category.Margin = new Padding(1, 1, 1, 1);

                    category.Size = new Size(117, 49);
                   // category.Text.PadRight(1);

                    //Random randomGen = new Random();
                    //KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                    //KnownColor randomColorName = names[randomGen.Next(names.Length)];
                    //Color randomColor = Color.FromKnownColor(randomColorName);


                    // category.Text += " " + dataReader["product_name"];
                    string Name = dataReader["category"].ToString();
                   string COLORNAME = dataReader["COLOR_NAME"].ToString();
                    if(COLORNAME==string.Empty) { COLORNAME = "#ffffff"; }
                    int argb = Int32.Parse(COLORNAME.Replace("#", ""), NumberStyles.HexNumber);
                    Color clr = Color.FromArgb(argb);
                   // category.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
                    category.BackColor = Color.FromArgb(argb); // GetCatagoryColor(Name);

                    string Cat_Name = "";

                    if (Name != "All")
                    {
                        if (UserInfo.Language == "English")
                        {
                          //  string sqlName = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID ='" + Name + "' ";
                          //  DataTable dtName = DataAccess.GetDataTable(sqlName);
                          //  if (dtName.Rows.Count > 0)
                          //  {
                                //Cat_Name = dtName.Rows[0]["CAT_NAME1"].ToString();
                                Cat_Name = dataReader["CAT_NAME1"].ToString();
                            // }
                            //  else
                            //  {
                            //     Cat_Name = Name;
                            // }
                        }
                        else if (UserInfo.Language == "Arabic")
                        {
                            // string sqlName = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID ='" + Name + "' ";
                            // DataTable dtName = DataAccess.GetDataTable(sqlName);
                            // if (dtName.Rows.Count > 0)
                            // {
                            //     Cat_Name = dtName.Rows[0]["CAT_NAME2"].ToString();
                            // }
                            // else
                            // {
                            //     Cat_Name = Name;
                            // }
                            Cat_Name = dataReader["CAT_NAME2"].ToString();
                        }
                        else
                        {
                            // string sqlName = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID ='" + Name + "' ";
                            // DataTable dtName = DataAccess.GetDataTable(sqlName);
                            // if (dtName.Rows.Count > 0)
                            // {
                            //     Cat_Name = dtName.Rows[0]["CAT_NAME1"].ToString();
                            // }
                            // else
                            // {
                            //     Cat_Name = Name;
                            // }

                            Cat_Name = dataReader["CAT_NAME1"].ToString();
                        }
                    }
                    else
                    {
                        if (UserInfo.Language == "English")
                        {
                            Cat_Name = Name;
                        }
                        else if (UserInfo.Language == "Arabic")
                        {
                            Cat_Name = "الكل";
                        }
                        else
                        {
                            Cat_Name = Name;
                        }
                    }

                    category.Click += new EventHandler(category_Click);
                    category.Text += Cat_Name;// dataReader["category"].ToString();


                    category.Font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Point);
                   
                    category.TextImageRelation = TextImageRelation.Overlay;
                    category.FlatStyle = FlatStyle.Flat;

                    flwLyoutCategoryPanel.Controls.Add(category);
                    currentImage++;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Category_with_images()
        {
            //PanelCatagories.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";

            System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);

            if (di.Exists)
            {
                img_directory = UserInfo.Img_path;
            }
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
            try
            {
                string sql = "";

                if (chkoutput.Checked == true)
                {
                    sql = " select DISTINCT category,imagename,DefaultPic from  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID  " +
                          " Where tbl_item_uom_price.RecipeType = 'Output' and purchase.TenentID = " + Tenent.TenentID + "  group by category  order by DisplaySort";
                }
                else
                {
                    sql = "select DISTINCT category,imagename,DefaultPic from  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID INNER JOIN CAT_MST ON purchase.category = CAT_MST.CATID " +
                        " Where purchase.TenentID = " + Tenent.TenentID + " group by category  order by DisplaySort";
                }

                DataTable dt = DataAccess.GetDataTable(sql);

                DataRow toInsert = dt.NewRow();
                toInsert[0] = "All";
                dt.Rows.InsertAt(toInsert, 0);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button categoryimg = new Button();
                    // Image i4 = Image.FromFile(img_directory + dataReader["name"]);
                    categoryimg.Tag = dataReader["category"];

                    categoryimg.Click += new EventHandler(categoryimg_Click);


                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Blue;
                    il.ImageSize = new Size(105, 84);

                    string image = "category.png";

                    //DefaultPic

                    if (dataReader["DefaultPic"] != null && dataReader["DefaultPic"].ToString() != "")
                    {
                        image = dataReader["DefaultPic"].ToString();
                        string Filename = img_directory + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["DefaultPic"].ToString();
                        }
                        else
                        {
                            image = dataReader["imagename"].ToString();
                            Filename = img_directory + image;
                            if (File.Exists(Filename))
                            {
                                image = dataReader["imagename"].ToString();
                            }
                            else
                            {
                                image = "category.png";
                            }
                        }

                    }
                    else if (dataReader["imagename"] != null && dataReader["imagename"].ToString() != "")
                    {
                        image = dataReader["imagename"].ToString();
                        string Filename = img_directory + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["imagename"].ToString();
                        }
                        else
                        {
                            image = "category.png";
                        }
                    }
                    else
                    {
                        image = "category.png";
                    }
                    il.Images.Add(Image.FromFile(img_directory + image));

                    categoryimg.Image = il.Images[0];

                    string Name = dataReader["category"].ToString();

                    string Cat_Name = "";

                    if (Name != "All")
                    {
                        if (UserInfo.Language == "English")
                        {
                            string sqlName = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID ='" + Name + "' ";
                            DataTable dtName = DataAccess.GetDataTable(sqlName);
                            if (dtName.Rows.Count > 0)
                            {
                                Cat_Name = dtName.Rows[0]["CAT_NAME1"].ToString();
                            }
                            else
                            {
                                Cat_Name = Name;
                            }
                        }
                        else if (UserInfo.Language == "Arabic")
                        {
                            string sqlName = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID ='" + Name + "' ";
                            DataTable dtName = DataAccess.GetDataTable(sqlName);
                            if (dtName.Rows.Count > 0)
                            {
                                Cat_Name = dtName.Rows[0]["CAT_NAME2"].ToString();
                            }
                            else
                            {
                                Cat_Name = Name;
                            }
                        }
                        else
                        {
                            string sqlName = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID ='" + Name + "' ";
                            DataTable dtName = DataAccess.GetDataTable(sqlName);
                            if (dtName.Rows.Count > 0)
                            {
                                Cat_Name = dtName.Rows[0]["CAT_NAME1"].ToString();
                            }
                            else
                            {
                                Cat_Name = Name;
                            }
                        }
                    }
                    else
                    {
                        if (UserInfo.Language == "English")
                        {
                            Cat_Name = Name;
                        }
                        else if (UserInfo.Language == "Arabic")
                        {
                            Cat_Name = "الكل";
                        }
                        else
                        {
                            Cat_Name = Name;
                        }
                    }

                    categoryimg.Text += Cat_Name;// dataReader["category"].ToString();

                    categoryimg.Margin = new Padding(3, 3, 3, 3);

                    categoryimg.Size = new Size(115, 114);
                    categoryimg.Text.PadRight(1);

                    // category.Text += " " + dataReader["product_name"];



                    categoryimg.Font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Point);
                    categoryimg.TextAlign = ContentAlignment.MiddleCenter;
                    categoryimg.TextImageRelation = TextImageRelation.ImageAboveText;
                   // PanelCatagories.Controls.Add(categoryimg);
                    currentImage++;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static Color GetCatagoryColor(string CATID)
        {//Parimal
            try
            {
                Color ColorNAme = SystemColors.Control;

                string ColorNam = "";
                string sqlName = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID ='" + CATID + "' ";
                DataTable dtName = DataAccess.GetDataTable(sqlName);
                if (dtName.Rows.Count > 0)
                {
                    ColorNam = dtName.Rows[0]["COLOR_NAME"].ToString();
                }

                if (ColorNam != "")
                {
                    string coName = ColorNam.Trim();
                    coName = coName.Substring(2);
                    coName = "#" + coName;

                    Color c = System.Drawing.ColorTranslator.FromHtml(coName);
                    byte A = c.A;
                    byte R = c.R;
                    byte G = c.G;
                    byte B = c.B;
                    ColorNAme = Color.FromArgb(A, R, G, B);
                }
                return ColorNAme;
            }
            catch
            {
                return SystemColors.Control;
            }
        }
        //Filter Product by category   -- Add new from 8.3.2
        protected void category_Click(object sender, EventArgs e)
        {
             Button category = sender as Button;
            string s;
            s = " ID: ";
            s += category.Tag;
            s += "\n Name: ";
            s += category.Name.ToString();
            lblCatagory.Text = category.Text.ToString();
            lblCatagory.Refresh();
            txtSearchItem.Text = "";

            try
            {
                Thread threadInput = new Thread(DisplayCategoryClick);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }

        }

        protected void categoryimg_Click(object sender, EventArgs e)
        {
            Button categoryimg = sender as Button;
            string s;
            s = " ID: ";
            s += categoryimg.Tag;
            s += "\n Name: ";
            s += categoryimg.Name.ToString();
            lblCatagory.Text = categoryimg.Text.ToString();
            lblCatagory.Refresh();
            txtSearchItem.Text = "";

           if (chkImage.Checked == true)
           {
                // this.ItemsImage.Parent = this.tabControl1;
                // tabControl1.SelectedTab = ItemsImage;
              //  btnImages_Click(null, null);
           }
           else if (chkbutton.Checked == true)
           {
                //this.ItemButton.Parent = this.tabControl1;
                //tabControl1.SelectedTab = ItemButton;
              //  btnItemButton_Click(null, null);
            }
           else
           {
                //this.ItemGrid.Parent = this.tabControl1;
                //tabControl1.SelectedTab = ItemGrid;
               // btnItemGrid_Click(null, null);
            }

            try
            {
                Thread threadInput = new Thread(DisplayCategoryClick);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }

        }
        #endregion

        // Discount Calculation - Change in 8.1 version
        public void DiscountCalculation()
        {
           
                // // subtotal without dis vat sum 
                double totalsum = 0.00;
                for (int i = 0; i < dgrvSalesItemList.Rows.Count; ++i)
                {
                    totalsum += Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value);
                }
                lblTotal.Text = Math.Round(totalsum, 3).ToString();
                //lblTotalItems.Text = dgrvSalesItemList.RowCount.ToString();

                ////    Discount amount sum
                double total = Convert.ToDouble(totalsum.ToString());
                //double DisCount = 0.00;
                //for (int i = 0; i < dgrvSalesItemList.Rows.Count; ++i)
                //{
                //    DisCount += Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[5].Value);
                //}

                //DisCount = Math.Round(DisCount, 3);
                double sum = total;//- DisCount;


                double Discountvalue = txtDiscountRate.Text == "" ? 0 : Convert.ToDouble(txtDiscountRate.Text);
                double totaldiscount = (sum * Discountvalue) / 100;
                sum = sum - totaldiscount;

                sum = Math.Round(sum, 3);

                lblsubtotal.Text = sum.ToString();

                double payable = sum;// +Convert.ToDouble(lblTotalVAT.Text);
                payable = Math.Round(payable, 3);
                lblTotalPayable.Text = payable.ToString();
                lblTotalpayableAmtPY.Text = payable.ToString();
                lblTotalPayment.Text = payable.ToString();
                txtPaidAmount.Text = payable.ToString();
                txtcashRecived.Text = payable.ToString();


                //yogesh lblTotalDisCount.Text = (DisCount).ToString();
                double dica = totaldiscount;
                dica = Math.Round(dica, 3);
                lbloveralldiscount.Text = dica.ToString();
                //lblTotalDisCount.Text = DisCount.ToString();
                //lbloveralldiscount.Text = DisCount.ToString();
                // btnPayment.Text = "Pay = " + payable.ToString();

              //  tabPageSR_Counter.Text = "Terminal (" + dgrvSalesItemList.RowCount.ToString() + ")";
              //  tabPageSR_Payment.Text = "Payment (" + payable.ToString() + ")";
        
        }

        //VAT amount sum calculation - Change in 8.1 version
        public void vatcal()
        {
            int cout = dgrvSalesItemList.Rows.Count;
            if (cout >= 1)
            {
                //Subtotal = total - (discount + Globaldiscount)
                double Subtotal = Convert.ToDouble(lblsubtotal.Text);
                //double Subtotal = Convert.ToDouble(lbloveralldiscount.Text)  ;

                //VAT amount
                double VAT = 0.00;
                for (int i = 0; i < dgrvSalesItemList.Rows.Count; ++i)
                {
                    VAT += Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[6].Value);
                }

                VAT = Math.Round(VAT, 3);
                //lblTotalVAT.Text = VAT.ToString();

                double DelCharge = lblDeliveryChargis.Text != "" ? Convert.ToDouble(lblDeliveryChargis.Text) : 0;
                DelCharge = Math.Round(DelCharge, 3);

                double payable = Subtotal + VAT + DelCharge;
                payable = Math.Round(payable, 3);
                lblTotalPayable.Text = payable.ToString();
                lblTotalpayableAmtPY.Text = payable.ToString();
                lblTotalPayment.Text = payable.ToString();
                txtPaidAmount.Text = payable.ToString();
                txtcashRecived.Text = payable.ToString();
                // btnPayment.Text = "Pay = " + payable.ToString();

                ///////Pole shows Price value  | if you have pole device please UnComment   below code
                //SerialPort sp = new SerialPort();
                //sp.PortName = "COM1";  ////Insert your pole Device Port Name E.g. COM4  -- you can find  from pole device manual  
                //sp.BaudRate = 9600;     // Pole Bound Rate 
                //sp.Parity = Parity.None;
                //sp.DataBits = 8;   // Data Bits
                //sp.StopBits = StopBits.One;
                //sp.Open();                 
                //sp.WriteLine(lblTotalPayable.Text);

                //sp.Close();
                //sp.Dispose();
                //sp = null;
            }
        }
        #region PeriSer CheckTemp
        public bool CheckPerishableTemp(double MyProdID, int UOMID, string Batch_No, int MYTRANSID, string MySysName)
        {
            try
            {

                string q = "select * from ICIT_BR_TMP where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                DataTable dt1 = DataAccess.GetDataTable(q);
                if (dt1.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool CheckSerializeTemp(double MyProdID, int UOMID, string Serial_Number, int MYTRANSID, string MySysName)
        {
            try
            {

                string q = "select * from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                DataTable dt1 = DataAccess.GetDataTable(q);
                if (dt1.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
        public static int getuomid(string UOMNAME1)
        {
            int UOM = 0;
            UOMNAME1 = UOMNAME1.Trim();
            string sql12 = " select UOM from ICUOM where TenentID = " + Tenent.TenentID + " and UOMNAME1 = '" + UOMNAME1 + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                UOM = Convert.ToInt32(dt1.Rows[0]["UOM"]);
            }
            return UOM;
        }
        // Sales item   Increase , Decrease and Delete Options
        private void dgrvSalesItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Sales_id = Convert.ToInt32(txtInvoice.Text);
           
            try
            {

                // Delete items From Gridview
                if (e.ColumnIndex == dgrvSalesItemList.Columns["del"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row2 in dgrvSalesItemList.SelectedRows)
                    {
                        //  DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        //  if (result == DialogResult.Yes)                        
                        //  {

                        if (!row2.IsNewRow)
                        {
                            #region PeriSer

                            double Prodid = Convert.ToDouble(row2.Cells[4].Value);
                            bool flag1 = IsPerishable(Prodid);
                            if (flag1 == true)
                            {
                                string[] strSplit = row2.Cells[0].Value.ToString().Split('~');
                                string ProdName = strSplit[0];
                                string uom = strSplit[1];
                                int UOMID = getuomid(uom);
                                string Batch_No = "";
                                if (row2.Cells[10].Value != null)
                                    Batch_No = row2.Cells[10].Value.ToString();

                                string MySysName = "SAL";
                                int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                bool flag = CheckPerishableTemp(Prodid, UOMID, Batch_No, MYTRANSID, MySysName);

                                if (flag == true)
                                {
                                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    string sql1 = " Delete From ICIT_BR_TMP " +
                                                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                    DataAccess.ExecuteSQL(sql1);
                                    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMP", "DELETE");
                                }
                            }
                            bool flag1s = IsSerialize(Prodid);
                            if (flag1s == true)
                            {
                                string[] strSplit = row2.Cells[0].Value.ToString().Split('~');
                                string ProdName = strSplit[0];
                                string uom = strSplit[1];
                                int UOMID = getuomid(uom);
                                string Serial_Number = "";
                                if (row2.Cells[17].Value != null)
                                    Serial_Number = row2.Cells[17].Value.ToString();

                                string MySysName = "SAL";
                                int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                bool flag = CheckSerializeTemp(Prodid, UOMID, Serial_Number, MYTRANSID, MySysName);

                                if (flag == true)
                                {
                                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    string sql1 = " Delete From ICIT_BR_TMPSerialize " +
                                                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                    DataAccess.ExecuteSQL(sql1);
                                    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "DELETE");
                                }
                            }
                            #endregion
                            dgrvSalesItemList.Rows.Remove(row2);
                        }

                        DiscountCalculation();
                        vatcal();
                        txtDiscountRate.Text = "0";

                        // lbloveralldiscount.Text = "0";
                        // }
                    }
                }

                // Increase Item Quantity
                if (e.ColumnIndex == dgrvSalesItemList.Columns["inc"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgrvSalesItemList.SelectedRows)
                    {

                        //if (Convert.ToDouble(row.Cells[6].Value) <= 0)
                        //{
                        //    MessageBox.Show("You don't have sufficient item Quantity \n\n Your  Item Quantity is greater than Stock Qty");
                        //}
                        //else
                        //{

                        //dgrvSalesItemList.Columns[10].Visible = false; // BatchNo    
                        //dgrvSalesItemList.Columns[11].Visible = false; // OnHand 
                        //dgrvSalesItemList.Columns[12].Visible = false; // ExpiryDate

                        //// Increase by 1
                        #region PeriSer
                        double Prodid = Convert.ToDouble(row.Cells[4].Value);
                        bool flag1 = IsPerishable(Prodid);
                        bool flag1s = IsSerialize(Prodid);
                        if (flag1 == true)
                        {
                            string Batch_No = "";
                            if (row.Cells[10].Value != null)
                                Batch_No = row.Cells[10].Value.ToString();

                            int OnHand = 0;
                            if (row.Cells[11].Value != null)
                                OnHand = Convert.ToInt32(row.Cells[11].Value);


                            int QtyEn = Convert.ToInt32(row.Cells[2].Value) + 1;
                            if (OnHand >= QtyEn && OnHand != 0)
                            {
                                double qtySum = Convert.ToDouble(row.Cells[2].Value) + 1;
                                row.Cells[2].Value = qtySum;

                                double qty = Convert.ToDouble(row.Cells[2].Value);
                                double Rprice = Convert.ToDouble(row.Cells[1].Value);
                                double disrate = Convert.ToDouble(row.Cells[7].Value);
                                double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                                //// show total price   Qty  * Rprice
                                double totalPrice = qty * Rprice;
                                row.Cells[3].Value = totalPrice;

                                if (Convert.ToDouble(row.Cells[7].Value) != 0)
                                {
                                    double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                    row.Cells[5].Value = Disamt;
                                }

                                if (Convert.ToDouble(row.Cells[8].Value) != 0)
                                {
                                    double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                    row.Cells[6].Value = Taxamt;
                                }

                                DiscountCalculation();
                                vatcal();

                                txtDiscountRate.Text = "0";


                                string[] strSplit = row.Cells[0].Value.ToString().Split('~');
                                string ProdName = strSplit[0];
                                string uom = strSplit[1];
                                int UOMID = getuomid(uom);
                                string MySysName = "SAL";
                                int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                bool flag = CheckPerishableTemp(Prodid, UOMID, Batch_No, MYTRANSID, MySysName);

                                if (flag == true)
                                {
                                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    string sql1 = "Update ICIT_BR_TMP set NewQty='" + QtyEn + "', " +
                                                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                    DataAccess.ExecuteSQL(sql1);
                                    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMP", "UPDATE");
                                }
                                else
                                {
                                    if (Application.OpenForms["SalesPerishable"] != null)
                                    {
                                        Application.OpenForms["SalesPerishable"].Close();
                                    }
                                    SalesPerishable mkc1 = new SalesPerishable(Prodid, ProdName, uom, MYTRANSID, MySysName, "");
                                    mkc1.Qty = QtyEn;
                                    mkc1.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Batch " + Batch_No + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");

                                string[] strSplit = row.Cells[0].Value.ToString().Split('~');
                                string ProdName = strSplit[0];
                                string uom = strSplit[1];
                                int UOMID = getuomid(uom);
                                string MySysName = "SAL";
                                int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                string Batch = GetGrid_BatchNo(row.Cells[0].Value.ToString());

                                if (Application.OpenForms["SalesPerishable"] != null)
                                {
                                    Application.OpenForms["SalesPerishable"].Close();
                                }
                                SalesPerishable mkc1 = new SalesPerishable(Prodid, ProdName, uom, MYTRANSID, MySysName, Batch);//Batch_No
                                mkc1.Qty = QtyEn;
                                mkc1.Show();
                            }
                        }
                        else if (flag1s == true)
                        {
                            MessageBox.Show("You can't Increase or Minus Serialize Product.");
                            //string Serial_Number = "";
                            //if (row.Cells[17].Value != null)
                            //    Serial_Number = row.Cells[17].Value.ToString();

                            //int OnHand = 0;
                            //if (row.Cells[11].Value != null)
                            //    OnHand = Convert.ToInt32(row.Cells[11].Value);

                            //int QtyEn = Convert.ToInt32(row.Cells[2].Value) + 1;
                            //if (OnHand >= QtyEn && OnHand != 0)
                            //{
                            //    double qtySum = Convert.ToDouble(row.Cells[2].Value) + 1;
                            //    row.Cells[2].Value = qtySum;

                            //    double qty = Convert.ToDouble(row.Cells[2].Value);
                            //    double Rprice = Convert.ToDouble(row.Cells[1].Value);
                            //    double disrate = Convert.ToDouble(row.Cells[7].Value);
                            //    double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                            //    //// show total price   Qty  * Rprice
                            //    double totalPrice = qty * Rprice;
                            //    row.Cells[3].Value = totalPrice;

                            //    if (Convert.ToDouble(row.Cells[7].Value) != 0)
                            //    {
                            //        double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                            //        row.Cells[5].Value = Disamt;
                            //    }

                            //    if (Convert.ToDouble(row.Cells[8].Value) != 0)
                            //    {
                            //        double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                            //        row.Cells[6].Value = Taxamt;
                            //    }

                            //    DiscountCalculation();
                            //    vatcal();

                            //    txtDiscountRate.Text = "0";


                            //    string[] strSplit = row.Cells[0].Value.ToString().Split('~');
                            //    string ProdName = strSplit[0];
                            //    string uom = strSplit[1];
                            //    int UOMID = getuomid(uom);
                            //    string MySysName = "SAL";
                            //    int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                            //    bool flag = CheckSerializeTemp(Prodid, UOMID, Serial_Number, MYTRANSID, MySysName);

                            //    if (flag == true)
                            //    {
                            //        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            //        string sql1 = "Update ICIT_BR_TMPSerialize set NewQty='" + QtyEn + "', " +
                            //                      " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                            //                      " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                            //        DataAccess.ExecuteSQL(sql1);
                            //        Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "UPDATE");
                            //    }
                            //    else
                            //    {
                            //        if (Application.OpenForms["SalesSerialize"] != null)
                            //        {
                            //            Application.OpenForms["SalesSerialize"].Close();
                            //        }
                            //        SalesSerialize mkc1 = new SalesSerialize(Prodid, ProdName, uom, MYTRANSID, MySysName, "");
                            //        mkc1.Qty = QtyEn;
                            //        mkc1.Show();
                            //    }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Serial " + Serial_Number + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");

                            //    string[] strSplit = row.Cells[0].Value.ToString().Split('~');
                            //    string ProdName = strSplit[0];
                            //    string uom = strSplit[1];
                            //    int UOMID = getuomid(uom);
                            //    string MySysName = "SAL";
                            //    int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                            //    string Serial = GetGrid_Serial(row.Cells[0].Value.ToString());

                            //    if (Application.OpenForms["SalesSerialize"] != null)
                            //    {
                            //        Application.OpenForms["SalesSerialize"].Close();
                            //    }
                            //    SalesSerialize mkc1 = new SalesSerialize(Prodid, ProdName, uom, MYTRANSID, MySysName, Serial);//Serial
                            //    mkc1.Qty = QtyEn;
                            //    mkc1.Show();
                            //}
                        }
                        else
                        {
                            double qtySum = Convert.ToDouble(row.Cells[2].Value) + 1;
                            row.Cells[2].Value = qtySum;

                            double qty = Convert.ToDouble(row.Cells[2].Value);
                            double Rprice = Convert.ToDouble(row.Cells[1].Value);
                            double disrate = Convert.ToDouble(row.Cells[7].Value);
                            double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                            //// show total price   Qty  * Rprice
                            double totalPrice = qty * Rprice;
                            row.Cells[3].Value = totalPrice;

                            if (Convert.ToDouble(row.Cells[7].Value) != 0)
                            {
                                double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                row.Cells[5].Value = Disamt;
                            }

                            if (Convert.ToDouble(row.Cells[8].Value) != 0)
                            {
                                double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                row.Cells[6].Value = Taxamt;
                            }


                            DiscountCalculation();
                            vatcal();

                            txtDiscountRate.Text = "0";

                        }
                        #endregion
                    }
                }

                // Decrease Item Quantity  -- Add new from 8.3.2
                if (e.ColumnIndex == dgrvSalesItemList.Columns["minus"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgrvSalesItemList.SelectedRows)
                    {
                        if (Convert.ToDouble(row.Cells[2].Value) != 1)
                        {
                            //// Decrease by 1 
                            int QtyEn = Convert.ToInt32(row.Cells[2].Value) - 1;
                            double qtySum = Convert.ToDouble(row.Cells[2].Value) - 1;
                            row.Cells[2].Value = qtySum;

                            double qty = Convert.ToDouble(row.Cells[2].Value);
                            double Rprice = Convert.ToDouble(row.Cells[1].Value);
                            double disrate = Convert.ToDouble(row.Cells[7].Value);
                            double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                            //// show total price   Qty  * Rprice
                            double totalPrice = qty * Rprice;
                            row.Cells[3].Value = totalPrice;

                            if (Convert.ToDouble(row.Cells[7].Value) != 0)
                            {
                                double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                row.Cells[5].Value = Disamt;
                            }

                            if (Convert.ToDouble(row.Cells[8].Value) != 0)
                            {
                                double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                row.Cells[6].Value = Taxamt;
                            }

                            DiscountCalculation();
                            vatcal();

                            txtDiscountRate.Text = "0";
                            #region PeriSer
                            double Prodid = Convert.ToDouble(row.Cells[4].Value);
                            bool flag1 = IsPerishable(Prodid);
                            bool flag1s = IsSerialize(Prodid);
                            if (flag1 == true)
                            {
                                string[] strSplit = row.Cells[0].Value.ToString().Split('~');
                                string ProdName = strSplit[0];
                                string uom = strSplit[1];
                                int UOMID = getuomid(uom);
                                string Batch_No = row.Cells[10].Value.ToString();
                                string MySysName = "SAL";
                                int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                bool flag = CheckPerishableTemp(Prodid, UOMID, Batch_No, MYTRANSID, MySysName);

                                if (flag == true)
                                {
                                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    string sql1 = "Update ICIT_BR_TMP set NewQty='" + QtyEn + "', " +
                                                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                    DataAccess.ExecuteSQL(sql1);
                                    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMP", "UPDATE");
                                }
                                else
                                {
                                    if (Application.OpenForms["SalesPerishable"] != null)
                                    {
                                        Application.OpenForms["SalesPerishable"].Close();
                                    }
                                    SalesPerishable mkc1 = new SalesPerishable(Prodid, ProdName, uom, MYTRANSID, MySysName, "");
                                    mkc1.Qty = QtyEn;
                                    mkc1.Show();
                                }
                            }
                            if (flag1s == true)
                            {
                                MessageBox.Show("You can't Increase or Minus Serialize Product.");
                                //string[] strSplit = row.Cells[0].Value.ToString().Split('~');
                                //string ProdName = strSplit[0];
                                //string uom = strSplit[1];
                                //int UOMID = getuomid(uom);
                                //string Serial_Number = row.Cells[17].Value.ToString();
                                //string MySysName = "SAL";
                                //int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                //bool flag = CheckSerializeTemp(Prodid, UOMID, Serial_Number, MYTRANSID, MySysName);

                                //if (flag == true)
                                //{
                                //    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                //    string sql1 = "Update ICIT_BR_TMPSerialize set NewQty='" + QtyEn + "', " +
                                //                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                //                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                //    DataAccess.ExecuteSQL(sql1);
                                //    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "UPDATE");
                                //}
                                //else
                                //{
                                //    if (Application.OpenForms["SalesSerialize"] != null)
                                //    {
                                //        Application.OpenForms["SalesSerialize"].Close();
                                //    }
                                //    SalesSerialize mkc1 = new SalesSerialize(Prodid, ProdName, uom, MYTRANSID, MySysName, "");
                                //    mkc1.Qty = QtyEn;
                                //    mkc1.Show();
                                //}
                            }
                            #endregion
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Input Item Quantity 
        private void dgrvSalesItemList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           int Sales_id = Convert.ToInt32(txtInvoice.Text);
           bool ISPaymentCredit = CheckISPaymentCredit(Sales_id);
           if (ISPaymentCredit == true)
           {
               MessageBox.Show(" This Invoice is Credit invoice It Not Allow to Add Item or Update Item ");
               return;
           }

          
           changeQtypriceEfact(sender, e);
        }
        private void dgrvSalesItemList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           int Sales_id = Convert.ToInt32(txtInvoice.Text);
           bool ISPaymentCredit = CheckISPaymentCredit(Sales_id);
           if (ISPaymentCredit == true)
           {
               MessageBox.Show(" This Invoice is Credit invoice It Not Allow to Add Item or Update Item ");
               return;
           }
          
           changeQtypriceEfact(sender, e);
        }
        public void changeQtypriceEfact(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgrvSalesItemList.Columns["Am"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgrvSalesItemList.SelectedRows)
                    {
                        try
                        {
                            double Rprice_ = Convert.ToDouble(row.Cells[1].Value);
                            double qty_ = Convert.ToDouble(row.Cells[2].Value);
                        }
                        catch
                        {
                            MessageBox.Show("Please enter numeric value");
                            return;
                        }

                        double Rprice = Convert.ToDouble(row.Cells[1].Value);
                        double qty = Convert.ToDouble(row.Cells[2].Value);

                        double totalPrice = qty * Rprice;
                        row.Cells[3].Value = totalPrice;

                        DiscountCalculation();
                        vatcal();
                    }
                }

                // Increase Item Quantity with Edited cell
                if (e.ColumnIndex == dgrvSalesItemList.Columns["Qty"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgrvSalesItemList.SelectedRows)
                    {
                        try
                        {
                            double Rprice_ = Convert.ToDouble(row.Cells[1].Value);
                            double qty_ = Convert.ToDouble(row.Cells[2].Value);
                        }
                        catch
                        {
                            MessageBox.Show("Please enter numeric value");
                            return;
                        }
                        // Total Price
                        // double totalPrice = Convert.ToDouble(row.Cells[2].Value) * Convert.ToDouble(row.Cells[1].Value);
                        // row.Cells[3].Value = totalPrice;

                        double QtyEn = Convert.ToDouble(row.Cells[2].Value);
                        double qty = Convert.ToDouble(row.Cells[2].Value);
                        double Rprice = Convert.ToDouble(row.Cells[1].Value);
                        double disrate = Convert.ToDouble(row.Cells[7].Value);
                        double Taxrate = Convert.ToDouble(vatdisvalue.vat);
                        #region PeriSer
                        double Prodid = Convert.ToDouble(row.Cells[4].Value);
                        bool flag1 = IsPerishable(Prodid);
                        bool flag1s = IsSerialize(Prodid);
                        if (flag1 == true)
                        {


                            string Batch_No = "";
                            if (row.Cells[10].Value != null)
                                Batch_No = row.Cells[10].Value.ToString();

                            int OnHand = 0;
                            if (row.Cells[11].Value != null)
                                OnHand = Convert.ToInt32(row.Cells[11].Value);

                            if (OnHand >= QtyEn && OnHand != 0)
                            {

                                //// show total price   Qty  * Rprice
                                double totalPrice = qty * Rprice;
                                row.Cells[3].Value = totalPrice;

                                if (Convert.ToDouble(row.Cells[7].Value) != 0)  // IF discount is not zero then apply discount
                                {
                                    double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                    row.Cells[5].Value = Disamt;
                                }

                                if (Convert.ToDouble(row.Cells[8].Value) != 0)  // IF tax is not zero then apply tax
                                {
                                    double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                    row.Cells[6].Value = Taxamt;
                                }

                                DiscountCalculation();
                                vatcal();
                                txtDiscountRate.Text = "0";

                                string[] strSplit = row.Cells[0].Value.ToString().Split('~');
                                string ProdName = strSplit[0];
                                string uom = strSplit[1];
                                int UOMID = getuomid(uom);
                                string MySysName = "SAL";
                                int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                bool flag = CheckPerishableTemp(Prodid, UOMID, Batch_No, MYTRANSID, MySysName);

                                if (flag == true)
                                {
                                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    string sql1 = "Update ICIT_BR_TMP set NewQty='" + QtyEn + "', " +
                                                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                    DataAccess.ExecuteSQL(sql1);
                                    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMP", "UPDATE");
                                }
                                else
                                {
                                    if (Application.OpenForms["SalesPerishable"] != null)
                                    {
                                        Application.OpenForms["SalesPerishable"].Close();
                                    }
                                    SalesPerishable mkc1 = new SalesPerishable(Prodid, ProdName, uom, MYTRANSID, MySysName, "");
                                    mkc1.Qty = QtyEn;
                                    mkc1.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Batch " + Batch_No + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");
                            }
                        }
                        else if (flag1s == true)
                        {


                            string Serial_Number = "";
                            if (row.Cells[17].Value != null)
                                Serial_Number = row.Cells[17].Value.ToString();
                            string[] seriallist = Serial_Number.Split('~');
                            if (QtyEn != seriallist.Count())
                            {
                                MessageBox.Show("You can't change Serialize Item Qty.");
                                row.Cells[2].Value = seriallist.Count();
                                return;
                            }

                            for (int i = 0; i < seriallist.Count(); i++)
                            {
                                int OnHand = 0;
                                if (row.Cells[11].Value != null)
                                    OnHand = Convert.ToInt32(row.Cells[11].Value);
                                QtyEn = 1;//yogesh
                                if (OnHand >= QtyEn && OnHand != 0)
                                {

                                    //// show total price   Qty  * Rprice
                                    double totalPrice = qty * Rprice;
                                    row.Cells[3].Value = totalPrice;

                                    if (Convert.ToDouble(row.Cells[7].Value) != 0)  // IF discount is not zero then apply discount
                                    {
                                        double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                        row.Cells[5].Value = Disamt;
                                    }

                                    if (Convert.ToDouble(row.Cells[8].Value) != 0)  // IF tax is not zero then apply tax
                                    {
                                        double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                        row.Cells[6].Value = Taxamt;
                                    }

                                    DiscountCalculation();
                                    vatcal();
                                    txtDiscountRate.Text = "0";

                                    string[] strSplit = row.Cells[0].Value.ToString().Split('~');
                                    string ProdName = strSplit[0];
                                    string uom = strSplit[1];
                                    int UOMID = getuomid(uom);
                                    string MySysName = "SAL";
                                    int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                    bool flag = CheckSerializeTemp(Prodid, UOMID, seriallist[i].ToString().Trim(), MYTRANSID, MySysName);

                                    if (flag == true)
                                    {
                                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        string sql1 = "Update ICIT_BR_TMPSerialize set NewQty='" + QtyEn + "', " +
                                                      " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                                      " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and Serial_Number='" + seriallist[i].ToString().Trim() + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                        DataAccess.ExecuteSQL(sql1);
                                        Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "UPDATE");
                                    }
                                    else
                                    {
                                        if (Application.OpenForms["SalesSerialize"] != null)
                                        {
                                            Application.OpenForms["SalesSerialize"].Close();
                                        }
                                        SalesSerialize mkc1 = new SalesSerialize(Prodid, ProdName, uom, MYTRANSID, MySysName, "");
                                        mkc1.Qty = QtyEn;
                                        mkc1.Show();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Serial " + seriallist[i].ToString().Trim() + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            //// show total price   Qty  * Rprice
                            double totalPrice = qty * Rprice;
                            row.Cells[3].Value = totalPrice;

                            if (Convert.ToDouble(row.Cells[7].Value) != 0)  // IF discount is not zero then apply discount
                            {
                                double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                row.Cells[5].Value = Disamt;
                            }

                            if (Convert.ToDouble(row.Cells[8].Value) != 0)  // IF tax is not zero then apply tax
                            {
                                double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                row.Cells[6].Value = Taxamt;
                            }

                            DiscountCalculation();
                            vatcal();
                            txtDiscountRate.Text = "0";
                        }
                        #endregion
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        //Suspend Order/ Cancel transaction
        private void btnSuspend_Click(object sender, EventArgs e)
        {
            clearInvoice();
        }
        private void lblClear_TextChanged(object sender, EventArgs e)
        {
            if (lblClear.Text == ".")
            {
                clearInvoice();
                lblClear.Text = "-";
            }
        }
        public void clearInvoice()
        {
            try
            {
                lblInvoiceStatus.Text = "New";
                //  lblInvoiceStatus.ForeColor = Color.FromKnownColor(KnownColor.LimeGreen);
                dgrvSalesItemList.Rows.Clear();
                // lblTotalItems.Text = "0";
                txtDiscountRate.Text = "0";
                lbloveralldiscount.Text = "0";

                UserInfo.EditTransation = false;
                UserInfo.Invoice = 0;
                UserInfo.InvoicetransNO = null;

                dtSalesDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                dtsaleDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                dtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                dtsaleDeliveryDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                DiscountCalculation();
                vatcal();
                CombPayby.Text = "Cash";
                txtCustomer.Text = "Cash";
                //ComboCustID.Text = "Gest";
                lblCustID.Text = "1";
                chkCreditTrans.Checked = false;
                btnSalesCredit.Enabled = false;
                btnCashAndPrint.Enabled = false;
                tabPageSR_Counter.Text = "Terminal";
                this.tabPageSR_Payment.Parent = null; //Hide payment tab
                this.tabPageSR_Split_Bill.Parent = null; //Hide Split tab
                tabPageSR_Split_Billb.Visible = false;
                tabPageSR_Paymentb.Visible = false;

                txtReffrance.Text = "";
                lblTotal.Text = "0";
                lblTotalPayable.Text = "0";
                lblChangeAmt.Text = "0";
                txtcashRecived.Text = "0";
                radioCash.Checked = true;
                radiocredit.Checked = false;
                // this.AcceptButton = btnSerchItem;
                lblIsCustAdvanceAmtYN.Text = "-";
                lblmainCustwalletant.Text = lblCustCredit.Text = "0";
                txtTerminalAdvance.Text = "0";
                GridPayment.Rows.Clear();

                btnCashAndPrint.Text = "Cash / Print";
                lblIsCustAdvanceAmtYN.Text = "-";
                // btnBooking.BackColor = Color.FromKnownColor(KnownColor.Orange);
                // btnBooking.Enabled = true;
                // btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.SeaGreen);
                // btnSalesCredit.Enabled = true;
                // btnCOD.BackColor = Color.FromKnownColor(KnownColor.PaleGreen);
                // btnCOD.Enabled = true;
                // lbloveralldiscount.Enabled = txtDiscountRate.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void timerinvoiceno()
        {
            txtInvoice.Text = "";
            txtInvoicePAY.Text = "";

            if (UserInfo.EditTransation == true)
            {
                if (UserInfo.Invoice == 0)
                {
                    string Sales_ID = get_sales_id();
                    txtInvoice.Text = Sales_ID;
                    txtInvoicePAY.Text = Sales_ID;
                    int year = DateTime.Now.Year;
                    string terminal = UserInfo.Shopid;

                    lblInvoiceNO.Text = Sales_ID + "/" + terminal + "/" + year;
                    lblInvoiceNOPAY.Text = Sales_ID + "/" + terminal + "/" + year;
                }
                else
                {
                    txtInvoice.Text = Convert.ToString(Convert.ToInt32(UserInfo.Invoice));
                    txtInvoicePAY.Text = Convert.ToString(Convert.ToInt32(UserInfo.Invoice));
                }
            }
            else
            {
                string ID = get_sales_id();
                txtInvoice.Text = ID;
                txtInvoicePAY.Text = ID;
            }

            getInvoiceno();
            Application.DoEvents();
        
    }
        // Auto Invoice.No Shows 
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bool ISrun = backSyncro.isRun;
                if (ISrun != true)
                {

                    txtInvoice.Text = "";
                    txtInvoicePAY.Text = "";

                    if (UserInfo.EditTransation == true)
                    {
                        if (UserInfo.Invoice == 0)
                        {
                            string Sales_ID = get_sales_id();
                            txtInvoice.Text = Sales_ID;
                            txtInvoicePAY.Text = Sales_ID;
                            int year = DateTime.Now.Year;
                            string terminal = UserInfo.Shopid;

                            lblInvoiceNO.Text = Sales_ID + "/" + terminal + "/" + year;
                            lblInvoiceNOPAY.Text = Sales_ID + "/" + terminal + "/" + year;
                        }
                        else
                        {
                            txtInvoice.Text = Convert.ToString(Convert.ToInt32(UserInfo.Invoice));
                            txtInvoicePAY.Text = Convert.ToString(Convert.ToInt32(UserInfo.Invoice));
                        }
                    }
                    else
                    {
                        string ID = get_sales_id();
                        txtInvoice.Text = ID;
                        txtInvoicePAY.Text = ID;
                    }

                    getInvoiceno();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //  Discount
        private void txtDiscountRate_TextChanged(object sender, EventArgs e)
        {
            txtDiscountRate.Text = txtDiscountRate.Text == "" ? "0" : txtDiscountRate.Text;
            try
            {
                if (lblTotalPayable.Text == "")
                {
                    MessageBox.Show("Please Add at least One Item");
                }
                else
                {

                    double Discountvalue = txtDiscountRate.Text != "" ? Convert.ToDouble(txtDiscountRate.Text) : 0;
                    //txtDiscountRate.Text = Discountvalue.ToString();
                    double subtotal = Convert.ToDouble(lblTotal.Text); //yogesh- Convert.ToDouble(lblTotalDisCount.Text); // total - item discount  100 - 5 = 95        
                    double totaldiscount = (subtotal * Discountvalue) / 100;  //Counter discount  // 95 * 5 /100 = 4.75  
                    // double totaldiscount = Convert.ToDouble(lblTotalDisCount.Text) + Discountvalue;   // Uncomment this line if you want to discount value and comment/delete above line
                    double disPlusOverallDiscount = totaldiscount; //yogesh+ Convert.ToDouble(lblTotalDisCount.Text); // 4.75 + 5 = 9.75
                    disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 4);
                    lbloveralldiscount.Text = disPlusOverallDiscount.ToString();  // Overall discount 9.75

                    double subtotalafteroveralldiscount = subtotal - totaldiscount; // 95 - 4.75 = 90.25
                    subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 4);
                    lblsubtotal.Text = subtotalafteroveralldiscount.ToString();

                    double DelCharge = lblDeliveryChargis.Text != "" ? Convert.ToDouble(lblDeliveryChargis.Text) : 0;
                    DelCharge = Math.Round(DelCharge, 3);

                    double payable = subtotalafteroveralldiscount + DelCharge;// Convert.ToDouble(lblTotalVAT.Text) +
                    payable = Math.Round(payable, 3);
                    lblTotalPayable.Text = payable.ToString();
                    txtcashRecived.Text = payable.ToString();

                    //  btnPayment.Text = "Pay = " + payable.ToString();

                }
            }
            catch
            {
                txtDiscountRate.Text = "0";
            }

        }

        //Decrease Discount     new   8.1 version - Now not used
        private void btnDecreaseDiscount_Click(object sender, EventArgs e)
        {
            if (lblTotalPayable.Text == "")
            {
                MessageBox.Show("Please Add at least One Item");
            }
            else
            {
                double Discountvalue = Convert.ToDouble(txtDiscountRate.Text) - 1;
                txtDiscountRate.Text = Discountvalue.ToString();
                double subtotal = Convert.ToDouble(lblTotal.Text);//yogesh- Convert.ToDouble(lblTotalDisCount.Text); // total - item discount  100 - 5 = 95        
                double totaldiscount = (subtotal * Discountvalue) / 100;  //Counter discount  // 95 * 5 /100 = 4.75  
                double disPlusOverallDiscount = totaldiscount;//yogesh+ Convert.ToDouble(lblTotalDisCount.Text); // 4.75 + 5 = 9.75
                disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 4);
                lbloveralldiscount.Text = disPlusOverallDiscount.ToString();  // Overall discount 9.75

                double subtotalafteroveralldiscount = subtotal - totaldiscount; // 95 - 4.75 = 90.25
                subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 4);
                lblsubtotal.Text = subtotalafteroveralldiscount.ToString();



                double payable = subtotalafteroveralldiscount;// +Convert.ToDouble(lblTotalVAT.Text);
                payable = Math.Round(payable, 3);
                lblTotalPayable.Text = payable.ToString();

                //  btnPayment.Text = "Pay = " + payable.ToString();

                //double Discountvalue = Convert.ToDouble(txtDiscountRate.Text) - 1;
                //txtDiscountRate.Text = Discountvalue.ToString();
                //DiscountCalculation();
                //vatcal();
            }
        }
        public string getExpiryDate(string Product_id, string UOMID)
        {
            string ExpiryDate = "";
            string sql = "select * from tbl_item_uom_price where itemID = '" + Product_id + "' and UOMID='" + UOMID + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                ExpiryDate = dt.Rows[0]["ExpiryDate"].ToString();
            }

            return ExpiryDate;
        }

        public static void DeleteOrder(string salesID, bool Flag, string OrderStutas)
        {
            if (Flag == true)
            {
                DialogResult result = MessageBox.Show("Are Yor Sure? Your Sale order is Permenent Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql3 = "Delete from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + "; ";
                    string dsql = " insert into sales_payment_Log (TenentID,sales_id,Deleted,UploadDate) values (" + Tenent.TenentID + ", '" + salesID + "',1," + UploadDate + ");";
                    DataAccess.ExecuteSQL(sql3 + dsql);

                    string sqlUpdateCmdWIN = " delete from Win_sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                    Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "Win_sales_item", "DELETE");

                    if (OrderStutas == "COD-send to Kitchen")
                    {

                        string sql = "Delete from sales_payment where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                        DataAccess.ExecuteSQL(sql);

                        string sqlWIN = " delete from Win_sales_payment where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                        Datasyncpso.insert_Live_sync(sqlWIN, "Win_sales_payment", "DELETE");

                    }

                }
            }
            else
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql3 = "Delete from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + "; ";
                DataAccess.ExecuteSQL(sql3);

                string sqlUpdateCmdWIN = " delete from Win_sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "Win_sales_item", "DELETE");

                if (OrderStutas == "COD-send to Kitchen")
                {
                    string sql = "Delete from sales_payment where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                    DataAccess.ExecuteSQL(sql);

                    string sqlWIN = " delete from Win_sales_payment where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                    Datasyncpso.insert_Live_sync(sqlWIN, "Win_sales_payment", "DELETE");
                }
            }
        }

        #region
        ////////////////  Submit request - New  ////////////////////////

        /// //// Add sales item  ////////////Store into sales_item table //////////
        public bool sales_item(string salesdate, string OrderStutas, int COD, string PaymentMode, string Remarks)
        {
            DateTime DeliveryDate = DateTime.Now.AddDays(1);//Laundary change 030519
            string FDeliveryDate = DeliveryDate.ToString("yyyy-MM-dd");
            if (dtsaleDeliveryDate.Text != "")
            {
                DeliveryDate = Convert.ToDateTime(dtsaleDeliveryDate.Text);
                FDeliveryDate = DeliveryDate.ToString("yyyy-MM-dd");
            }
            else
            {
                DeliveryDate = DateTime.Now.AddDays(1);
                FDeliveryDate = DeliveryDate.ToString("yyyy-MM-dd");
            }//end Laundary change 030519

            if (salesdate != "")
            {
                DateTime sales_date = Convert.ToDateTime(salesdate);
                salesdate = sales_date.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime sales_date = DateTime.Now;
                salesdate = sales_date.ToString("yyyy-MM-dd");
            }

            string trno = txtInvoice.Text;

            int ISPaymentCredit = 0;
            if (chkCreditTrans.Checked == true)
            {
                ISPaymentCredit = 1;
            }

            string Query1 = "select sales_id from sales_item where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' ";
            DataTable dtsalesitem = DataAccess.GetDataTable(Query1);

            if (dtsalesitem.Rows.Count > 0)
            {
                if (!isAlreadyDeliveredInvoice(trno))
                    DeleteOrder(trno, false, "");
            }

            int rows = dgrvSalesItemList.Rows.Count;

            //double TotalDis = Convert.ToDouble(lbloveralldiscount.Text);
            //double PerItemDis = TotalDis / rows;
            //PerItemDis = Math.Round(PerItemDis, 3);
            //double Dif = TotalDis - (PerItemDis * rows);

            //double FirstItemDis = PerItemDis + Dif;

            for (int i = 0; i < rows; i++)
            {

                string[] CustItemSplit = dgrvSalesItemList.Rows[i].Cells[0].Value.ToString().Split('-');

                string CustItemCode1 = CustItemSplit[0];

                string[] strSplit = CustItemSplit[1].Split('~');

                //string SalesDate = dtSalesDate.Text;                  
                string invoiceNO = lblInvoiceNO.Text;
                string itemid = dgrvSalesItemList.Rows[i].Cells[4].Value.ToString();
                string itNam = strSplit[0];
                double qty = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[2].Value.ToString());
                double Rprice = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[1].Value.ToString());
                double total = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value.ToString());
                double dis = 0;// Yogesh Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[5].Value.ToString());
                double taxapply = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[8].Value.ToString());
                int kitchendisplay = Convert.ToInt32(dgrvSalesItemList.Rows[i].Cells[9].Value.ToString());
                string CustItemCode = dgrvSalesItemList.Rows[i].Cells[16].Value.ToString();
                string ItemNote = dgrvSalesItemList.Rows[i].Cells[18].Value != null && dgrvSalesItemList.Rows[i].Cells[18].Value.ToString() != "" ? dgrvSalesItemList.Rows[i].Cells[18].Value.ToString() : "";
                //if (i == 0)
                //{
                //    dis = dis + FirstItemDis;
                //}
                //else
                //{
                //    dis = dis + PerItemDis;
                //}

                double DisCRate = Convert.ToDouble(txtDiscountRate.Text);
                double ItemOverDis = ((total * DisCRate) / 100);
                ItemOverDis = Math.Round(ItemOverDis, 4);

                dis = ItemOverDis;

                double prodid = Convert.ToDouble(itemid);
                //dgrvSalesItemList.Columns[10].Visible = false; // BatchNo    
                //dgrvSalesItemList.Columns[11].Visible = false; // OnHand 
                //dgrvSalesItemList.Columns[12].Visible = false; // ExpiryDate

                string Serial_Number = "";
                string BatchNo = dgrvSalesItemList.Rows[i].Cells[10].Value != null && dgrvSalesItemList.Rows[i].Cells[10].Value.ToString() != "" ? dgrvSalesItemList.Rows[i].Cells[10].Value.ToString() : "0";
                if (BatchNo == "0" || BatchNo == null)
                {
                    Serial_Number = dgrvSalesItemList.Rows[i].Cells[17].Value != null ? dgrvSalesItemList.Rows[i].Cells[17].Value.ToString() : "0";
                    BatchNo = Serial_Number;//yogesh
                }

                string ExpiryDate = dgrvSalesItemList.Rows[i].Cells[12].Value != null ? dgrvSalesItemList.Rows[i].Cells[12].Value.ToString() : "";

                string uom = strSplit[1];
                int UOMID = getuomid(uom);

                string Customer = "";
                if (txtCustomer.Text != "")
                {
                    if (txtCustomer.Text != txtCustomer.Text)
                    {
                        getCusto();
                    }

                    string Name = txtCustomer.Text.Split('-')[0].Trim();
                    string Mobile = "";
                    if (Name != "Cash" && Name != "Gest")
                        Mobile = txtCustomer.Text.Split('-')[1].Trim();

                    Name = Name.Trim();
                    string sql = "Select ID,Name from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = '" + Name + "' and trim(Phone)  = '" + Mobile + "'";
                    DataTable dt = DataAccess.GetDataTable(sql);
                    
                    if (dt.Rows.Count > 0)
                    {
                        lblCustID.Text = dt.Rows[0]["ID"].ToString();
                        Customer = dt.Rows[0]["Name"].ToString();
                    }
                    else
                    {
                        string sql1 = "Select ID from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = 'Gest'";
                    
                        DataTable dt12 = DataAccess.GetDataTable(sql1);
                    
                        if (dt12.Rows.Count > 0)
                        {
                            lblCustID.Text = dt12.Rows[0]["ID"].ToString();
                        }
                        Customer = txtCustomer.Text;
                    }
                    //Customer = txtCustomer.Text;
                }

                // =================================Start=====  Profit calculation =============== Start ========= 
                // Discount_amount = (price * discount) / 100                    -- 49 * 3 / 100 = 1.47
                // priceAfterDiscount = price - Discount_amount           -- 49 - 1.47 = 47.53
                // Profit = (priceAfterDiscount * QTY )   - (msrp * qty);  ---( 47.53 * 1 ) - ( 45 * 1) = 2.53

                string sqlprofit = " Select tbl_item_uom_price.msrp as msrp, Discount,product_name_print,tbl_item_uom_price.price as price ,Receipe_Menegement.msrp as RMSRP , Receipe_Menegement.CostPrice as Rprice " +
                                   " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID " +
                                   " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                   " where purchase.TenentID = " + Tenent.TenentID + " and itemID = '" + itemid + "' and UOMID = '" + UOMID + "'";

                DataTable dt1 = DataAccess.GetDataTable(sqlprofit);

                string product_name_print = dt1.Rows[0]["product_name_print"].ToString();
                double PRice = dt1.Rows[0]["Rprice"] != null && dt1.Rows[0]["Rprice"].ToString() != "" ? Convert.ToDouble(dt1.Rows[0]["Rprice"].ToString()) : Convert.ToDouble(dt1.Rows[0]["price"].ToString());
                //double msrp = Convert.ToDouble(dt1.Rows[0]["msrp"].ToString());
                double discount = Convert.ToDouble(dt1.Rows[0]["Discount"].ToString());

                double Discount_amount = (PRice * discount) / 100.00;
                double priceAfterDiscount = PRice - Discount_amount;
                double Profit = Math.Round((Rprice - priceAfterDiscount), 3); // old calculation (priceAfterDiscount * qty) - (msrp * qty);

                double OrderTotal = Convert.ToDouble(lblTotalPayable.Text);
                double TerminalAdvance = txtTerminalAdvance.Text == "" ? 0 : Convert.ToDouble(txtTerminalAdvance.Text);
                if (TerminalAdvance != 0)
                    OrderTotal += TerminalAdvance;
                string OrderWay = comboSalesMan.Text;

                //string ExpiryDate = getExpiryDate(itemid,uom);

                // =================================Start=====  Profit calculation =============== Start =========  

                string Query = "select sales_id from sales_item where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and itemcode='" + itemid + "' and uom='" + UOMID + "' and BatchNo='" + BatchNo + "' ";
                DataTable dtsalesprofit = DataAccess.GetDataTable(Query);

                if (Serial_Number == "1")//yogesh
                {
                    string[] Seriallist = Serial_Number.Split('~');


                    for (int j = 0; j < Seriallist.Count(); j++)
                    {
                        string Queryserial = "select * from sales_item where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and itemcode='" + itemid + "' and uom='" + UOMID + "' and BatchNo='" + Seriallist[j].ToString().Trim() + "' ";
                        DataTable dtQueryserial = DataAccess.GetDataTable(Queryserial);
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        double item_id = DataAccess.getsalesMYid(Tenent.TenentID, trno);
                        string sql1 = "  (TenentID, sales_id,item_id,itemName,product_name_print,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, " +
                                      " status,UOM,Customer,InvoiceNO,returnQty,returnTotal,OrderStutas,SoldBy,COD,OrderTotal,PaymentMode,Shopid,c_id,BatchNo,ExpiryDate,OrderWay,Uploadby ,UploadDate ,SynID,CustItemCode,ISPaymentCredit, Remarks,DeliveryDate ,ItemNote,ShiftID ) " +
                                      " values (" + Tenent.TenentID + ",'" + trno + "','" + item_id + "', '" + itNam + "','" + product_name_print + "' , '" + 1 + "', '" + Rprice + "', '" + Rprice + "', '" + Profit + "', " +
                                      " '" + salesdate + "','" + itemid + "','" + dis + "','" + taxapply + "','" + kitchendisplay + "','" + UOMID + "','" + Customer + "','" + invoiceNO + "',0,0 ,'" + OrderStutas + "','" + UserInfo.UserName + "'," + COD + ", " +
                                      " '" + OrderTotal + "','" + PaymentMode + "','" + UserInfo.Shopid + "','" + lblCustID.Text + "','" + Seriallist[j].ToString().Trim() + "','" + ExpiryDate + "','" + OrderWay + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ,'" + CustItemCode + "','" + ISPaymentCredit + "' , '" + Remarks + "','" + FDeliveryDate + "','" + ItemNote + "','" + UserInfo.ShiftID + "');";
                        if (dtQueryserial.Rows.Count < 1)
                        {
                            int flag1 = DataAccess.ExecuteSQL("insert into sales_item" + sql1 + "insert into sales_item_Log" + sql1);

                            string sql1Win = " insert into Win_sales_item (TenentID, sales_id,item_id,itemName,product_name_print,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, " +
                                             " status,UOM,Customer,InvoiceNO,returnQty,returnTotal,OrderStutas,SoldBy,COD,OrderTotal,PaymentMode,Shopid,c_id,BatchNo,ExpiryDate,OrderWay,Uploadby ,UploadDate ,SynID,CustItemCode,ISPaymentCredit,Remarks,DeliveryDate ,ItemNote,ShiftID ) " +
                                             " values (" + Tenent.TenentID + ",'" + trno + "', '" + item_id + "', '" + itNam + "', N'" + product_name_print + "', '" + 1 + "', '" + Rprice + "', '" + Rprice + "', '" + Profit + "', " +
                                             " '" + salesdate + "','" + itemid + "','" + dis + "','" + taxapply + "','" + kitchendisplay + "','" + UOMID + "','" + Customer + "','" + invoiceNO + "',0,0 ,'" + OrderStutas + "','" + UserInfo.UserName + "'," + COD + ", " +
                                             " '" + OrderTotal + "','" + PaymentMode + "','" + UserInfo.Shopid + "','" + lblCustID.Text + "','" + Seriallist[j].ToString().Trim() + "','" + ExpiryDate + "','" + OrderWay + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ,'" + CustItemCode + "','" + ISPaymentCredit + "', '" + Remarks + "','" + FDeliveryDate + "','" + ItemNote + "','" + UserInfo.ShiftID + "')";
                            Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_item", "INSERT");

                        }
                        else
                        {

                            string sql11 = " update sales_item set  itemName='" + itNam + "',product_name_print='" + product_name_print + "' ,Qty='" + 1 + "', " +
                                          " RetailsPrice='" + Rprice + "',Total='" + Rprice + "', profit='" + Profit + "',  discount='" + dis + "', taxapply='" + taxapply + "',  " +
                                          " status='" + kitchendisplay + "',Customer='" + Customer + "',OrderStutas='" + OrderStutas + "', COD=" + COD + ",OrderTotal ='" + OrderTotal + "', " +
                                          " PaymentMode='" + PaymentMode + "',c_id='" + lblCustID.Text + "',Shopid='" + UserInfo.Shopid + "',BatchNo='" + BatchNo + "', ExpiryDate='" + ExpiryDate + "' , " +
                                          " OrderWay='" + OrderWay + "', Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2, CustItemCode = '" + CustItemCode + "',ISPaymentCredit = '" + ISPaymentCredit + "', Remarks = '" + Remarks + "' " + "', DeliveryDate = '" + FDeliveryDate + "', ItemNote = '" + ItemNote + "', ShiftID = '" + UserInfo.ShiftID + "' " +
                                          " where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and itemcode='" + itemid + "' and uom='" + UOMID + "' and BatchNo='" + Seriallist[j].ToString().Trim() + "'; ";
                            DataAccess.ExecuteSQL(sql11 + "insert into sales_item_Log" + sql1);

                            string sql1Win = " update Win_sales_item set  itemName='" + itNam + "',product_name_print= N'" + product_name_print + "' ,Qty='" + 1 + "', " +
                                          " RetailsPrice='" + Rprice + "',Total='" + Rprice + "', profit='" + Profit + "',  discount='" + dis + "', taxapply='" + taxapply + "',  " +
                                          " status='" + kitchendisplay + "',Customer='" + Customer + "',OrderStutas='" + OrderStutas + "',COD=" + COD + ",OrderTotal ='" + OrderTotal + "', " +
                                          " PaymentMode='" + PaymentMode + "',c_id='" + lblCustID.Text + "',Shopid='" + UserInfo.Shopid + "',BatchNo='" + BatchNo + "', ExpiryDate='" + ExpiryDate + "' , " +
                                          " OrderWay='" + OrderWay + "', Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2 , CustItemCode = '" + CustItemCode + "',ISPaymentCredit = '" + ISPaymentCredit + "' , Remarks = '" + Remarks + "' " + "', DeliveryDate = '" + FDeliveryDate + "', ItemNote = '" + ItemNote + "', ShiftID = '" + UserInfo.ShiftID + "' " +
                                          " where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and itemcode='" + itemid + "' and uom='" + UOMID + "' and BatchNo='" + Seriallist[j].ToString().Trim() + "' ";

                            Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_item", "UPDATE");
                        }
                    }

                }//yogesh
                else
                {
                    double item_id = DataAccess.getsalesMYid(Tenent.TenentID, trno);
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql1 = "  (TenentID, sales_id,item_id,itemName,product_name_print,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, " +
                                  " status,UOM,Customer,InvoiceNO,returnQty,returnTotal,OrderStutas,SoldBy,COD,OrderTotal,PaymentMode,Shopid,c_id,BatchNo,ExpiryDate,OrderWay,Uploadby ,UploadDate ,SynID,CustItemCode,ISPaymentCredit, Remarks,DeliveryDate ,ItemNote,ShiftID ) " +
                                  " values (" + Tenent.TenentID + ",'" + trno + "','" + item_id + "', '" + itNam + "','" + product_name_print + "' , '" + qty + "', '" + Rprice + "', '" + total + "', '" + Profit + "', " +
                                  " '" + salesdate + "','" + itemid + "','" + dis + "','" + taxapply + "','" + kitchendisplay + "','" + UOMID + "','" + Customer + "','" + invoiceNO + "',0,0 ,'" + OrderStutas + "','" + UserInfo.UserName + "'," + COD + ", " +
                                  " '" + OrderTotal + "','" + PaymentMode + "','" + UserInfo.Shopid + "','" + lblCustID.Text + "','" + BatchNo + "','" + ExpiryDate + "','" + OrderWay + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ,'" + CustItemCode + "','" + ISPaymentCredit + "' , '" + Remarks + "','" + FDeliveryDate + "','" + ItemNote + "','" + UserInfo.ShiftID + "');";
                    if (dtsalesprofit.Rows.Count < 1)
                    {


                        int flag1 = DataAccess.ExecuteSQL("insert into sales_item" + sql1 + "insert into sales_item_Log" + sql1);

                        string sql1Win = " insert into Win_sales_item (TenentID, sales_id,item_id,itemName,product_name_print,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, " +
                                         " status,UOM,Customer,InvoiceNO,returnQty,returnTotal,OrderStutas,SoldBy,COD,OrderTotal,PaymentMode,Shopid,c_id,BatchNo,ExpiryDate,OrderWay,Uploadby ,UploadDate ,SynID,CustItemCode,ISPaymentCredit,Remarks,DeliveryDate ,ItemNote,ShiftID ) " +
                                         " values (" + Tenent.TenentID + ",'" + trno + "', '" + item_id + "', '" + itNam + "', N'" + product_name_print + "', '" + qty + "', '" + Rprice + "', '" + total + "', '" + Profit + "', " +
                                         " '" + salesdate + "','" + itemid + "','" + dis + "','" + taxapply + "','" + kitchendisplay + "','" + UOMID + "','" + Customer + "','" + invoiceNO + "',0,0 ,'" + OrderStutas + "','" + UserInfo.UserName + "'," + COD + ", " +
                                         " '" + OrderTotal + "','" + PaymentMode + "','" + UserInfo.Shopid + "','" + lblCustID.Text + "','" + BatchNo + "','" + ExpiryDate + "','" + OrderWay + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ,'" + CustItemCode + "','" + ISPaymentCredit + "', '" + Remarks + "','" + FDeliveryDate + "','" + ItemNote + "','" + UserInfo.ShiftID + "')";
                        Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_item", "INSERT");

                    }
                    else
                    {

                        string sql11 = " update sales_item set  itemName='" + itNam + "',product_name_print='" + product_name_print + "' ,Qty='" + qty + "', " +
                                      " RetailsPrice='" + Rprice + "',Total='" + total + "', profit='" + Profit + "',  discount='" + dis + "', taxapply='" + taxapply + "',  " +
                                      " status='" + kitchendisplay + "',Customer='" + Customer + "',OrderStutas='" + OrderStutas + "', COD=" + COD + ",OrderTotal ='" + OrderTotal + "', " +
                                      " PaymentMode='" + PaymentMode + "',c_id='" + lblCustID.Text + "',Shopid='" + UserInfo.Shopid + "',BatchNo='" + BatchNo + "', ExpiryDate='" + ExpiryDate + "' , " +
                                      " OrderWay='" + OrderWay + "', Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2, CustItemCode = '" + CustItemCode + "',ISPaymentCredit = '" + ISPaymentCredit + "', Remarks = '" + Remarks + "', DeliveryDate = '" + FDeliveryDate + "', ItemNote = '" + ItemNote + "' " +
                                      " where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and itemcode='" + itemid + "' and uom='" + UOMID + "' and BatchNo='" + BatchNo + "'; ";
                        DataAccess.ExecuteSQL(sql11 + "insert into sales_item_Log" + sql1);

                        string sql1Win = " update Win_sales_item set  itemName='" + itNam + "',product_name_print= N'" + product_name_print + "' ,Qty='" + qty + "', " +
                                      " RetailsPrice='" + Rprice + "',Total='" + total + "', profit='" + Profit + "',  discount='" + dis + "', taxapply='" + taxapply + "',  " +
                                      " status='" + kitchendisplay + "',Customer='" + Customer + "',OrderStutas='" + OrderStutas + "',COD=" + COD + ",OrderTotal ='" + OrderTotal + "', " +
                                      " PaymentMode='" + PaymentMode + "',c_id='" + lblCustID.Text + "',Shopid='" + UserInfo.Shopid + "',BatchNo='" + BatchNo + "', ExpiryDate='" + ExpiryDate + "' , " +
                                      " OrderWay='" + OrderWay + "', Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2 , CustItemCode = '" + CustItemCode + "',ISPaymentCredit = '" + ISPaymentCredit + "' , Remarks = '" + Remarks + "', DeliveryDate = '" + FDeliveryDate + "', ItemNote = '" + ItemNote + "' " +
                                      " where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and itemcode='" + itemid + "' and uom='" + UOMID + "' and BatchNo='" + BatchNo + "' ";

                        Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_item", "UPDATE");
                    }
                }


                //update quantity Decrease from Stock Qty |  purchase Table
                if (txtInvoice.Text == "")
                {
                    MessageBox.Show("please check sales no ");
                }
                else
                {
                    if (PaymentMode != "Draft" && PaymentMode != "Booking")
                    {
                        #region PeriSer
                        bool flag, flags;
                        string productname;
                        IsPerishablesale(prodid,out flag,out flags,out productname);
                      //  bool flags = IsSerialize(prodid);
                        if (flag == true)
                        {
                            int QTY1 = Convert.ToInt32(qty);
                            Update_ICIT_BR_Perishable(prodid, UOMID, BatchNo, QTY1, false);
                        }
                        if (flags == true)
                        {
                            int QTY1 = Convert.ToInt32(qty);
                            string[] Selriallist = BatchNo.Split('~');
                            for (int j = 0; j < Selriallist.Count(); j++)
                            {
                                Update_ICIT_BR_Serialize(prodid, UOMID, Selriallist[j].ToString().Trim(), 1, false);//BatchNo=Serial_Number yogesh
                            }

                        }
                        #endregion
                        //if (kitchendisplay == 1)//yogesh 190319
                        //{
                        //    bool flagrec = KD_dialog.CheckReciepeExist(itemid, UOMID);

                        //    if (flagrec == true)
                        //    {
                        //        double Qty = Convert.ToDouble(qty);
                        //        KD_dialog.pricessReceipe(itemid, UOMID, itNam, Qty);
                        //        GetJobList(invoiceNO, itemid, UOMID, itNam, Qty);
                        //    }
                        //}

                        string itemids = dgrvSalesItemList.Rows[i].Cells[4].Value.ToString();
                        double qtyupdate = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[2].Value.ToString());

                        double PID = Convert.ToDouble(itemids);
                        int SelctUOM = UOMID;
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

                            // Update Quantity
                            string sqlupdateQty = " select OnHand  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID " +
                                                  " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + itemids + "' and UOMID = '" + ToUOM + "' ";

                            DataTable dtUqty = DataAccess.GetDataTable(sqlupdateQty);
                            double OnHand = Convert.ToDouble(dtUqty.Rows[0]["OnHand"].ToString()) - newQty;

                            DataAccess.updateSales(OnHand, newQty, itemids, ToUOM.ToString());
                        }
                    }
                    if (PaymentMode == "Draft" || PaymentMode == "Booking")
                    {
                        #region PeriSer Draft Reserved Item
                        bool flag = IsPerishable(prodid);
                        bool flags = IsSerialize(prodid);
                        if (flag == true)
                        {
                            int QTY1 = Convert.ToInt32(qty);
                            Update_ICIT_BR_Perishable(prodid, UOMID, BatchNo, QTY1, true);
                        }
                        if (flags == true)
                        {
                            int QTY1 = Convert.ToInt32(qty);
                            string[] Selriallist = BatchNo.Split('~');
                            for (int j = 0; j < Selriallist.Count(); j++)
                            {
                                Update_ICIT_BR_Serialize(prodid, UOMID, Selriallist[j].ToString().Trim(), 1, true);//BatchNo=Serial_Number yogesh
                            }

                        }
                        #endregion
                    }
                }
            }
            return true;

        }
        public bool sales_item1(string salesdate, string OrderStutas, int COD, string PaymentMode, string Remarks)
        {
            if (salesdate != "")
            {
                DateTime sales_date = Convert.ToDateTime(salesdate);
                salesdate = sales_date.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime sales_date = DateTime.Now;
                salesdate = sales_date.ToString("yyyy-MM-dd");
            }

            string trno = txtInvoice.Text;

            int ISPaymentCredit = 0;
            if (chkCreditTrans.Checked == true)
            {
                ISPaymentCredit = 1;
            }

            string Query1 = "select * from sales_item where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' ";
            DataTable dtQuery1 = DataAccess.GetDataTable(Query1);

            if (dtQuery1.Rows.Count > 0)
            {
                DeleteOrder(trno, false, "");
            }

            int rows = dgrvSalesItemList.Rows.Count;

            //double TotalDis = Convert.ToDouble(lbloveralldiscount.Text);
            //double PerItemDis = TotalDis / rows;
            //PerItemDis = Math.Round(PerItemDis, 3);
            //double Dif = TotalDis - (PerItemDis * rows);

            //double FirstItemDis = PerItemDis + Dif;

            for (int i = 0; i < rows; i++)
            {
                string[] CustItemSplit = dgrvSalesItemList.Rows[i].Cells[0].Value.ToString().Split('-');

                string CustItemCode1 = CustItemSplit[0];

                string[] strSplit = CustItemSplit[1].Split('~');

                //string SalesDate = dtSalesDate.Text; 
                string invoiceNO = lblInvoiceNO.Text;
                string itemid = dgrvSalesItemList.Rows[i].Cells[4].Value.ToString();
                string itNam = strSplit[0];
                double qty = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[2].Value.ToString());
                double Rprice = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[1].Value.ToString());
                double total = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value.ToString());
                double dis = 0; // Yogesh Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[5].Value.ToString());
                double taxapply = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[8].Value.ToString());
                int kitchendisplay = Convert.ToInt32(dgrvSalesItemList.Rows[i].Cells[9].Value.ToString());
                string CustItemCode = dgrvSalesItemList.Rows[i].Cells[16].Value.ToString();

                //if (i == 0)
                //{
                //    dis = dis + FirstItemDis;
                //}
                //else
                //{
                //    dis = dis + PerItemDis;
                //}

                double DisCRate = Convert.ToDouble(txtDiscountRate.Text);
                double ItemOverDis = ((total * DisCRate) / 100);
                ItemOverDis = Math.Round(ItemOverDis, 4);

                dis = ItemOverDis;

                double prodid = Convert.ToDouble(itemid);
                //dgrvSalesItemList.Columns[10].Visible = false; // BatchNo    
                //dgrvSalesItemList.Columns[11].Visible = false; // OnHand 
                //dgrvSalesItemList.Columns[12].Visible = false; // ExpiryDate

                //dgrvSalesItemList.Columns[13].Visible = true; // SalesID    
                //dgrvSalesItemList.Columns[14].Visible = false; // invoice 
                //dgrvSalesItemList.Columns[15].Visible = false; // CID  


                string BatchNo = dgrvSalesItemList.Rows[i].Cells[10].Value != null && dgrvSalesItemList.Rows[i].Cells[10].Value.ToString() != "" ? dgrvSalesItemList.Rows[i].Cells[10].Value.ToString() : "0";
                if (BatchNo == "0")
                {
                    string Serial_Number = dgrvSalesItemList.Rows[i].Cells[17].Value != null ? dgrvSalesItemList.Rows[i].Cells[17].Value.ToString() : "0";
                    BatchNo = Serial_Number;//yogesh
                }
                string ExpiryDate = dgrvSalesItemList.Rows[i].Cells[12].Value != null ? dgrvSalesItemList.Rows[i].Cells[12].Value.ToString() : "";



                string uom = strSplit[1];
                int UOMID = getuomid(uom);

                string Cust = dgrvSalesItemList.Rows[i].Cells[15].Value.ToString();

                string C_ID = Cust.Split('-')[0].Trim();
                string Customer = Cust.Split('-')[1].Trim();

                trno = dgrvSalesItemList.Rows[i].Cells[13].Value.ToString();
                invoiceNO = dgrvSalesItemList.Rows[i].Cells[14].Value.ToString();

                // =================================Start=====  Profit calculation =============== Start ========= 
                // Discount_amount = (price * discount) / 100                    -- 49 * 3 / 100 = 1.47
                // priceAfterDiscount = price - Discount_amount           -- 49 - 1.47 = 47.53
                // Profit = (priceAfterDiscount * QTY )   - (msrp * qty);  ---( 47.53 * 1 ) - ( 45 * 1) = 2.53

                string sqlprofit = " Select tbl_item_uom_price.msrp as msrp, Discount,product_name_print,tbl_item_uom_price.price as price ,Receipe_Menegement.msrp as RMSRP , Receipe_Menegement.CostPrice as Rprice " +
                                   " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID " +
                                   " left JOIN Receipe_Menegement ON Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID  and Receipe_Menegement.IOSwitch = 'Output' " +
                                   " where purchase.TenentID = " + Tenent.TenentID + " and itemID = '" + itemid + "' and UOMID = '" + UOMID + "'";

                DataTable dt1 = DataAccess.GetDataTable(sqlprofit);

                string product_name_print = dt1.Rows[0]["product_name_print"].ToString();
                double PRice = dt1.Rows[0]["Rprice"] != null && dt1.Rows[0]["Rprice"].ToString() != "" ? Convert.ToDouble(dt1.Rows[0]["Rprice"].ToString()) : Convert.ToDouble(dt1.Rows[0]["price"].ToString());
                //double msrp = Convert.ToDouble(dt1.Rows[0]["msrp"].ToString());
                double discount = Convert.ToDouble(dt1.Rows[0]["Discount"].ToString());

                double Discount_amount = (PRice * discount) / 100.00;
                double priceAfterDiscount = PRice - Discount_amount;
                double Profit = Math.Round((Rprice - priceAfterDiscount), 3); // old calculation (priceAfterDiscount * qty) - (msrp * qty);

                double OrderTotal = Convert.ToDouble(lblTotalPayable.Text);

                string OrderWay = comboSalesMan.Text;

                //string ExpiryDate = getExpiryDate(itemid,uom);

                // =================================Start=====  Profit calculation =============== Start ========= 


                string Query = "select * from sales_item where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and itemcode='" + itemid + "' and uom='" + UOMID + "' and BatchNo='" + BatchNo + "' ";
                DataTable dtQuery = DataAccess.GetDataTable(Query);
                double item_id = DataAccess.getsalesMYid(Tenent.TenentID, trno);

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql1 = "  (TenentID, sales_id,item_id,itemName,product_name_print,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, status, " +
                              " UOM,Customer,InvoiceNO,returnQty,returnTotal,OrderStutas,SoldBy,COD,OrderTotal,PaymentMode,Shopid,c_id,BatchNo,ExpiryDate,OrderWay,Uploadby ,UploadDate ,SynID,CustItemCode,ISPaymentCredit,Remarks,ShiftID) " +
                              " values (" + Tenent.TenentID + ",'" + trno + "','" + item_id + "', '" + itNam + "','" + product_name_print + "' , '" + qty + "', '" + Rprice + "', '" + total + "', '" + Profit + "', " +
                              " '" + salesdate + "','" + itemid + "','" + dis + "','" + taxapply + "','" + kitchendisplay + "','" + UOMID + "','" + Customer + "','" + invoiceNO + "',0,0 ,'" + OrderStutas + "','" + UserInfo.UserName + "', " +
                              " " + COD + ",'" + OrderTotal + "','" + PaymentMode + "','" + UserInfo.Shopid + "','" + C_ID + "','" + BatchNo + "','" + ExpiryDate + "','" + OrderWay + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + ISPaymentCredit + "' , '" + Remarks + "', '" + UserInfo.ShiftID + "' );";
                if (dtQuery.Rows.Count < 1)
                {


                    int flag1 = DataAccess.ExecuteSQL("insert into sales_item" + sql1 + "insert into sales_item_Log" + sql1);

                    string sql1Win = " insert into Win_sales_item (TenentID, sales_id,item_id,itemName,product_name_print,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, status, " +
                                     " UOM,Customer,InvoiceNO,returnQty,returnTotal,OrderStutas,SoldBy,COD,OrderTotal,PaymentMode,Shopid,c_id,BatchNo,ExpiryDate,OrderWay,Uploadby ,UploadDate ,SynID,CustItemCode,Remarks,ShiftID) " +
                                     " values (" + Tenent.TenentID + ",'" + trno + "', '" + item_id + "', '" + itNam + "', N'" + product_name_print + "', '" + qty + "', '" + Rprice + "', '" + total + "', '" + Profit + "', " +
                                     " '" + salesdate + "','" + itemid + "','" + dis + "','" + taxapply + "','" + kitchendisplay + "','" + UOMID + "','" + Customer + "','" + invoiceNO + "',0,0 ,'" + OrderStutas + "','" + UserInfo.UserName + "', " +
                                     " " + COD + ",'" + OrderTotal + "','" + PaymentMode + "','" + UserInfo.Shopid + "','" + C_ID + "','" + BatchNo + "','" + ExpiryDate + "','" + OrderWay + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ,'" + CustItemCode + "','" + ISPaymentCredit + "' , '" + Remarks + "', '" + UserInfo.ShiftID + "'  )";
                    Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_item", "INSERT");

                }
                else
                {

                    string sql11 = " update sales_item set  itemName='" + itNam + "',product_name_print='" + product_name_print + "' ,Qty='" + qty + "', " +
                                  " RetailsPrice='" + Rprice + "',Total='" + total + "', profit='" + Profit + "',  discount='" + dis + "', taxapply='" + taxapply + "',  " +
                                  " status='" + kitchendisplay + "',Customer='" + Customer + "',OrderStutas='" + OrderStutas + "', COD=" + COD + ",OrderTotal ='" + OrderTotal + "', " +
                                  " PaymentMode='" + PaymentMode + "',c_id='" + C_ID + "',Shopid='" + UserInfo.Shopid + "',BatchNo='" + BatchNo + "', ExpiryDate='" + ExpiryDate + "' , " +
                                  " OrderWay='" + OrderWay + "', Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2, CustItemCode = '" + CustItemCode + "', ISPaymentCredit = '" + ISPaymentCredit + "', Remarks = '" + Remarks + "', ShiftID = '" + UserInfo.ShiftID + "' " +
                                  " where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and itemcode='" + itemid + "' and uom='" + UOMID + "' and BatchNo='" + BatchNo + "'; ";
                    DataAccess.ExecuteSQL(sql11 + "insert into sales_item_Log" + sql1);

                    string sql1Win = " update Win_sales_item set  itemName='" + itNam + "',product_name_print= N'" + product_name_print + "' ,Qty='" + qty + "', " +
                                  " RetailsPrice='" + Rprice + "',Total='" + total + "', profit='" + Profit + "',  discount='" + dis + "', taxapply='" + taxapply + "',  " +
                                  " status='" + kitchendisplay + "',Customer='" + Customer + "',OrderStutas='" + OrderStutas + "',COD=" + COD + ",OrderTotal ='" + OrderTotal + "', " +
                                  " PaymentMode='" + PaymentMode + "',c_id='" + C_ID + "',Shopid='" + UserInfo.Shopid + "',BatchNo='" + BatchNo + "', ExpiryDate='" + ExpiryDate + "' , " +
                                  " OrderWay='" + OrderWay + "', Uploadby='" + UserInfo.UserName + "' ,UploadDate= '" + UploadDate + "' ,SynID=2, CustItemCode = '" + CustItemCode + "' , ISPaymentCredit = '" + ISPaymentCredit + "' , Remarks = '" + Remarks + "', ShiftID = '" + UserInfo.ShiftID + "' " +
                                  " where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and itemcode='" + itemid + "' and uom='" + UOMID + "' and BatchNo='" + BatchNo + "' ";
                    Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_item", "UPDATE");
                }

                string ActivityName = "sales Item Split Transaction";
                string LogData = "Save Sales Transaction sales_item1() as Item Split with InvoiceNO = " + invoiceNO + "and Cust_Code=" + C_ID + " and OrderTotal =" + OrderTotal + " ";
                Login.InsertUserLog(ActivityName, LogData);

                //update quantity Decrease from Stock Qty |  purchase Table
                if (txtInvoice.Text == "")
                {
                    MessageBox.Show("please check sales no ");
                }
                else
                {
                    if (PaymentMode != "Draft")
                    {
                        bool flag = IsPerishable(prodid);
                        if (flag == true)
                        {
                            int QTY1 = Convert.ToInt32(qty);
                            Update_ICIT_BR_Perishable(prodid, UOMID, BatchNo, QTY1, false);
                        }
                        bool flags = IsSerialize(prodid);
                        if (flags == true)
                        {
                            int QTY1 = Convert.ToInt32(qty);

                            string[] Selriallist = BatchNo.Split('~');
                            for (int j = 0; j < Selriallist.Count(); j++)
                            {
                                Update_ICIT_BR_Serialize(prodid, UOMID, Selriallist.ToString().Trim(), 1, false);
                            }
                        }

                        //if (kitchendisplay == 1)//yogesh 190319
                        //{
                        //    bool flagrec = KD_dialog.CheckReciepeExist(itemid, UOMID);

                        //    if (flagrec == true)
                        //    {
                        //        double Qty = Convert.ToDouble(qty);
                        //        KD_dialog.pricessReceipe(itemid, UOMID, itNam, Qty);
                        //    }
                        //}

                        string itemids = dgrvSalesItemList.Rows[i].Cells[4].Value.ToString();
                        double qtyupdate = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[2].Value.ToString());

                        double PID = Convert.ToDouble(itemids);
                        int SelctUOM = UOMID;
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

                            // Update Quantity
                            string sqlupdateQty = " select OnHand  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID " +
                                                  " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + itemids + "' and UOMID = '" + ToUOM + "' ";

                            DataTable dtUqty = DataAccess.GetDataTable(sqlupdateQty);
                            double OnHand = Convert.ToDouble(dtUqty.Rows[0]["OnHand"].ToString()) - newQty;

                            DataAccess.updateSales(OnHand, newQty, itemids, ToUOM.ToString());
                        }
                    }
                    if (PaymentMode == "Draft")
                    {
                        #region PeriSer Draft Reserved Item
                        bool flag = IsPerishable(prodid);
                        bool flags = IsSerialize(prodid);
                        if (flag == true)
                        {
                            int QTY1 = Convert.ToInt32(qty);
                            Update_ICIT_BR_Perishable(prodid, UOMID, BatchNo, QTY1, true);
                        }
                        if (flags == true)
                        {
                            int QTY1 = Convert.ToInt32(qty);
                            string[] Selriallist = BatchNo.Split('~');
                            for (int j = 0; j < Selriallist.Count(); j++)
                            {
                                Update_ICIT_BR_Serialize(prodid, UOMID, Selriallist[j].ToString().Trim(), 1, true);//BatchNo=Serial_Number yogesh
                            }

                        }
                        #endregion
                    }
                }

            }
            return true;

        }
        #region Update_ICIT_BR_ PeriSer
        public void Update_ICIT_BR_Perishable(double MyProdID, int uom, string Batch_No, int qty1, bool IsReseved)
        {
            string query = "select * from ICIT_BR_Perishable where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and BatchNo='" + Batch_No + "' ";
            DataTable dtquery = DataAccess.GetDataTable(query);
            if (dtquery.Rows.Count > 0)
            {
                int Onhandold = Convert.ToInt32(dtquery.Rows[0]["OnHand"].ToString() != "" ? dtquery.Rows[0]["OnHand"] : "0");
                int QtyOutold = Convert.ToInt32(dtquery.Rows[0]["QtyOut"].ToString() != "" ? dtquery.Rows[0]["QtyOut"] : "0");

                int OnHand = Onhandold - qty1;
                string sql1 = "";
                if (IsReseved)//Only for Draft
                {
                    int ReservedQty = qty1 + QtyOutold;
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    sql1 = "Update ICIT_BR_Perishable set OnHand='" + OnHand + "',QtyReserved='" + ReservedQty + "',  " +
                              " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                              " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and BatchNo='" + Batch_No + "'  ";
                }
                else
                {
                    int QtyOut = qty1 + QtyOutold;
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    sql1 = "Update ICIT_BR_Perishable set OnHand='" + OnHand + "',QtyOut='" + QtyOut + "',  " +
                             " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                             " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and BatchNo='" + Batch_No + "'  ";
                }
                DataAccess.ExecuteSQL(sql1);
                Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Perishable", "UPDATE");
            }
        }
        public void Update_ICIT_BR_Serialize(double MyProdID, int uom, string Serial_Number, int qty1, bool IsReseved)
        {

            string query = "select * from ICIT_BR_Serialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "' ";
            DataTable dtquery = DataAccess.GetDataTable(query);
            if (dtquery.Rows.Count > 0)
            {
                int DrafReservedQty = Convert.ToInt32(dtquery.Rows[0]["QtyReserved"].ToString() != "" ? dtquery.Rows[0]["QtyReserved"] : "0");
                int Onhandold = Convert.ToInt32(dtquery.Rows[0]["OnHand"].ToString() != "" ? dtquery.Rows[0]["OnHand"] : "0");
                int QtyOutold = Convert.ToInt32(dtquery.Rows[0]["QtyOut"].ToString() != "" ? dtquery.Rows[0]["QtyOut"] : "0");
                int OnHand = Onhandold - qty1;
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql1 = "";
                if (DrafReservedQty == 1)
                {
                    if (IsReseved == false)
                    {
                        int QtyOut = qty1 + QtyOutold;
                        int ReservedQty = 0; //Yogesh qty1 + QtyOutold;
                        sql1 = "Update ICIT_BR_Serialize set QtyOut='" + QtyOut + "',QtyReserved='" + ReservedQty + "',  " +
                                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "'  ";
                    }
                }
                else
                {

                    if (IsReseved)//Only for Draft
                    {
                        int ReservedQty = 1; //Yogesh qty1 + QtyOutold;
                        sql1 = "Update ICIT_BR_Serialize set OnHand='" + OnHand + "',QtyReserved='" + ReservedQty + "',  " +
                                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "'  ";
                    }
                    else
                    {
                        int QtyOut = qty1 + QtyOutold;
                        sql1 = "Update ICIT_BR_Serialize set OnHand='" + OnHand + "',QtyOut='" + QtyOut + "',  " +
                                " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "'  ";
                    }
                }

                DataAccess.ExecuteSQL(sql1);
                Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Serialize", "UPDATE");
            }
        }
        #endregion
        public void GetJobList(string InvoiceNO, string itemid, int UOMID, string itNam, double Qty)
        {
            string str = "select * from CRMMainActivities where TenentID = " + Tenent.TenentID + " and MyStatus = '" + InvoiceNO + "' ";
            DataTable Dt = DataAccess.GetDataTable(str);
            if (Dt.Rows.Count > 0)
            {
                bool Found = false;
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    int jobID = Convert.ToInt32(Dt.Rows[i]["MasterCODE"]);

                    string SqlselectjobReceipe = "select * from AppointmentReceipe where TenentID = " + Tenent.TenentID + " and jobID = '" + jobID + "' and IOSwitch = 'Output' and ItemCode = '" + itemid + "' and UOM = '" + UOMID + "' ";
                    DataTable Dtselect = DataAccess.GetDataTable(str);
                    if (Dtselect.Rows.Count > 0)
                    {
                        Found = true;
                        KD_dialog.Efect_Appintment_Receipe(jobID, Qty);
                    }
                }

                if (Found == false)
                {
                    KD_dialog.pricessReceipe(itemid.ToString(), UOMID, itNam, Qty);
                }
            }
            else
            {
                KD_dialog.pricessReceipe(itemid.ToString(), UOMID, itNam, Qty);
            }
        }

        /// //// Payment items Add  ///////////Store into Sales_payment table //////// 
        public void payment_item(decimal payamount, decimal changeamount, decimal dueamount, string salestype, string salesdate, string custid, string Comment, string PaymentStutas)
        {
            string FSaleDt = "";
            DateTime sales_date = Convert.ToDateTime(salesdate);
            salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime SaleDt = Convert.ToDateTime(dtsaleDate.Text);
            FSaleDt = SaleDt.ToString("yyyy-MM-dd HH:mm:ss");
            string trno = txtInvoice.Text;
            // string payamount        = lblTotalPayable.Text;
            //  string changeamount     = "0";
            //string due              =  "0";
            string vat = "0";// lblTotalVAT.Text;
            string DiscountTotal = lbloveralldiscount.Text; // Total discount = item wise discount + counter discount
            // string Comment          = "Gest";
            string overalldisRate = txtDiscountRate.Text;
            string vatRate = "0";// txtVATRate.Text;
            string InvoiceNO = lblInvoiceNO.Text;

            string Delivery_Cahrge = lblDeliveryChargis.Text != "" ? lblDeliveryChargis.Text : "0";

            string Customer = "";
           if (txtCustomer.Text != "")
           //{
           //    string Name = txtCustomer.Text.Split('-')[0];
           //    string Mobile = "";//Yogesh Change 200519
           //    if (Name != "Cash" && Name != "Gest")
           //        Mobile = txtCustomer.Text.Split('-')[1].Trim();
           //    Name = Name.Trim();
           //    //string sql = "Select ID,Name from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = '" + Name + "' and trim(Phone)  = '" + Mobile + "'";
                //
                //DataTable customerdt = DataAccess.GetDataTable(sql);
                //
                //if (customerdt.Rows.Count > 0)
                //{
                //    lblCustID.Text = customerdt.Rows[0]["ID"].ToString();
                //    Customer = customerdt.Rows[0]["Name"].ToString();
                //}
                //else
                //{
                //    string sql1 = "Select ID from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = 'Gest'";
                //
                //    DataTable dtcust = DataAccess.GetDataTable(sql1);
                //
                //    if (dtcust.Rows.Count > 0)
                //    {
                //        lblCustID.Text = dtcust.Rows[0]["ID"].ToString();
                //
                //    }
                //    Customer = txtCustomer.Text;
                //}
                Customer = txtCustomer.Text;

           // }

            if (GridPayment.Rows.Count > 0)
            {
                for (int i = 0; i < GridPayment.Rows.Count; i++)
                {
                    string payment_type = GridPayment.Rows[i].Cells[1].Value.ToString();
                    string Reffrance = GridPayment.Rows[i].Cells[2].Value.ToString();
                    decimal payment_amount = Convert.ToDecimal(GridPayment.Rows[i].Cells[3].Value);

                    int ID = getPaymentid(txtInvoice.Text);

                    string Query = "select sales_id from sales_payment where TenentID = " + Tenent.TenentID + " and sales_id='" + txtInvoice.Text + "' and payment_type='" + payment_type + "' ";
                    DataTable dtQuery = DataAccess.GetDataTable(Query);
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string sql1 = " (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                   " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,SaleDt) " +
                                   "  values (" + Tenent.TenentID + "," + ID + ",'" + txtInvoice.Text + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                                   " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + salesdate + "', '" + lblCustID.Text + "', " +
                                   "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + InvoiceNO + "','" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "','" + FSaleDt + "');";
                    if (dtQuery.Rows.Count < 1)
                    {

                        int flag1 = DataAccess.ExecuteSQL("insert into sales_payment" + sql1 + "insert into sales_payment_Log" + sql1);

                        string sqlWin = " insert into Win_sales_payment (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                       " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,SaleDt) " +
                                       "  values (" + Tenent.TenentID + "," + ID + ",'" + txtInvoice.Text + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                                       " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + salesdate + "', '" + lblCustID.Text + "', " +
                                       "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + InvoiceNO + "', N'" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "','" + FSaleDt + "')";
                        Datasyncpso.insert_Live_sync(sqlWin, "Win_sales_payment", "INSERT");

                    }
                    else
                    {
                        string Reff1 = GetPAyReff(txtInvoice.Text, payment_type);


                        Reffrance = Reffrance + "," + Reff1;
                        Reffrance = Reffrance.Trim();
                        Reffrance = Reffrance.TrimStart(',');
                        Reffrance = Reffrance.TrimEnd(',');
                        Reffrance = Reffrance.Trim();

                        string sql2 = " Update sales_payment set Reffrance = '" + Reffrance + "',payment_amount = '" + payment_amount + "',change_amount = '" + changeamount + "', " +
                        " due_amount = '" + dueamount + "', dis = '" + DiscountTotal + "', vat= '" + vat + "', PaymentStutas = '" + PaymentStutas + "' " +
                        " where TenentID = " + Tenent.TenentID + " and sales_id='" + txtInvoice.Text + "' and payment_type='" + payment_type + "'; ";
                        DataAccess.ExecuteSQL(sql2 + "insert into sales_payment_Log" + sql1);

                        string sqlWin = "  Update Win_sales_payment set Reffrance = '" + Reffrance + "',payment_amount = '" + payment_amount + "',change_amount = '" + changeamount + "', " +
                        " due_amount = '" + dueamount + "', dis = '" + DiscountTotal + "', vat= '" + vat + "', PaymentStutas = '" + PaymentStutas + "' " +
                        " where TenentID = " + Tenent.TenentID + " and sales_id='" + txtInvoice.Text + "' and payment_type='" + payment_type + "' ";
                        Datasyncpso.insert_Live_sync(sqlWin, "Win_sales_payment", "UPDATE");
                    }

                    if (PaymentStutas != "Pending")
                    {
                        if (payment_type == "Cash")
                        {
                            decimal ShiftSales = Convert.ToDecimal(payment_amount);
                            Update_ShiftSales_DayClose(ShiftSales);
                        }
                        else if (payment_type == "Gift Card")
                        {
                            decimal VoucharAMT = Convert.ToDecimal(payment_amount);
                            Update_VoucharAMT_DayClose(VoucharAMT);
                        }
                        else
                        {
                            decimal ChequeAMT = Convert.ToDecimal(payment_amount);
                            Update_ChequeAMT_DayClose(ChequeAMT);
                        }
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                string Payby = "";
                if (lblIsCustAdvanceAmtYN.Text == ".")
                    Payby = "Advance";
                else
                    Payby = CombPayby.Text.ToString().Trim();

                if (chkCreditTrans.Checked == false)
                {
                    int ID = getPaymentid(txtInvoice.Text);

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql1 = "  (TenentID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                                       " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,SaleDt) " +
                                       "  values (" + Tenent.TenentID + "," + ID + ",'" + txtInvoice.Text + "',0,'" + Payby + "', '" + payamount + "', '" + changeamount + "', " +
                                       " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + salesdate + "', '" + lblCustID.Text + "', " +
                                       "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + InvoiceNO + "','" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "','" + FSaleDt + "');";
                    int flag1 = DataAccess.ExecuteSQL("insert into sales_payment" + sql1 + "insert into sales_payment_Log" + sql1);

                    string sql1Win = " insert into Win_sales_payment (TenentID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                                      " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,SaleDt) " +
                                      "  values (" + Tenent.TenentID + "," + ID + ",'" + txtInvoice.Text + "',0,'" + Payby + "', '" + payamount + "', '" + changeamount + "', " +
                                      " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + salesdate + "', '" + lblCustID.Text + "', " +
                                      "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + InvoiceNO + "', N'" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "','" + FSaleDt + "')";
                    Datasyncpso.insert_Live_sync(sql1Win, "Win_sales_payment", "INSERT");


                    if (Payby == "Cash")
                    {
                        decimal ShiftSales = Convert.ToDecimal(payamount);
                        Update_ShiftSales_DayClose(ShiftSales);
                    }
                    else if (Payby == "Gift Card")
                    {
                        decimal VoucharAMT = Convert.ToDecimal(payamount);
                        Update_VoucharAMT_DayClose(VoucharAMT);
                    }
                    else if (Payby == "Advance")
                    {
                        labelCustomerName.BackColor = Color.FromKnownColor(KnownColor.Transparent);
                        //lblmainCustwalletant.Visible = false;
                        btnCashAndPrint.Text = "Cash / Print";
                        btnBooking.BackColor = Color.FromKnownColor(KnownColor.Orange);
                        btnBooking.Enabled = true;
                        btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.SeaGreen);
                        btnSalesCredit.Enabled = true;
                        btnCOD.BackColor = Color.FromKnownColor(KnownColor.PaleGreen);
                        btnCOD.Enabled = true;
                        radiocredit.Enabled = true;

                    }
                    else
                    {
                        decimal ChequeAMT = Convert.ToDecimal(payamount);
                        Update_ChequeAMT_DayClose(ChequeAMT);
                    }
                }
            }
        }

        public static void payment_item_Credit(int sales_ID, string InvoiceNO, int C_ID, string Customer, decimal payamount, decimal changeamount, decimal dueamount, string salesdate, string Comment, string PaymentStutas, List<PaymentDatasale> GridPayment)
        {


            DateTime sales_date = Convert.ToDateTime(salesdate);
            salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
            string trno = sales_ID.ToString();
            string vat = "0";
            string DiscountTotal = "0"; // Total discount = item wise discount + counter discount            
            string overalldisRate = "0";
            string vatRate = "0";

            string Delivery_Cahrge = "0";

            if (GridPayment.Count() > 0)
            {
                foreach (PaymentDatasale Items in GridPayment)
                {

                    string payment_type = Items.payment_type;
                    string Reffrance = Items.Reffrance_NO;
                    decimal payment_amount = Items.payment_amount;

                    int ID = getPaymentid(sales_ID.ToString());
                    int RID = getPaymentidRecivable(sales_ID.ToString());
                    string Query = "select * from sales_payment where TenentID = " + Tenent.TenentID + " and sales_id='" + sales_ID + "' and payment_type='" + payment_type + "' ";
                    DataTable dtQuery = DataAccess.GetDataTable(Query);
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql1 = "  (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                   " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,SaleDt) " +
                                   "  values (" + Tenent.TenentID + "," + ID + ",'" + sales_ID + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                                   " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + UploadDate + "', '" + C_ID + "', " +
                                   "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + InvoiceNO + "','" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "','" + salesdate + "');";
                    if (dtQuery.Rows.Count < 1)
                    {

                        string sql3 = "insert into sales_payment_Recivable (ID, sales_id, payment_type, payment_amount, due_amount, UploadDate, Uploadby, SynID, Shopid, TenentID, ShiftID) " +
                                      "  values (" + RID + ",'" + sales_ID + "','" + payment_type + "', '" + payment_amount + "', " +
                                      " '" + dueamount + "', '" + UploadDate + "', " +
                                      "  '" + UserInfo.UserName + "', 1 , '" + UserInfo.Shopid + "' , '" + Tenent.TenentID + "' , '" + UserInfo.ShiftID + "' );";
                        int flag1 = DataAccess.ExecuteSQL("insert into sales_payment" + sql1 + "insert into sales_payment_Log" + sql1 + sql3);



                        string sqlWin = " insert into Win_sales_payment (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                       " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,SaleDt) " +
                                       "  values (" + Tenent.TenentID + "," + ID + ",'" + sales_ID + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                                       " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + UploadDate + "', '" + C_ID + "', " +
                                       "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + InvoiceNO + "', N'" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "','" + salesdate + "')";
                        Datasyncpso.insert_Live_sync(sqlWin, "Win_sales_payment", "INSERT");

                    }
                    else
                    {
                        string Reff1 = GetPAyReff(sales_ID.ToString(), payment_type);


                        Reffrance = Reffrance + "," + Reff1;
                        Reffrance = Reffrance.Trim();
                        Reffrance = Reffrance.TrimStart(',');
                        Reffrance = Reffrance.TrimEnd(',');
                        Reffrance = Reffrance.Trim();

                        decimal OldPay = Convert.ToDecimal(dtQuery.Rows[0]["payment_amount"]);
                        payment_amount = payment_amount + OldPay;
                        decimal Recivablepayment_amount = payment_amount - OldPay;

                        string sql4 = " Update sales_payment set Reffrance = '" + Reffrance + "',payment_amount = '" + payment_amount + "',change_amount = '" + changeamount + "', " +
                        " due_amount = '" + dueamount + "', dis = '" + DiscountTotal + "', vat= '" + vat + "', PaymentStutas = '" + PaymentStutas + "' " +
                        " where TenentID = " + Tenent.TenentID + " and sales_id='" + sales_ID + "' and payment_type='" + payment_type + "' ;" +
                        "insert into sales_payment_Recivable (ID, sales_id, payment_type, payment_amount, due_amount, UploadDate, Uploadby, SynID, Shopid, TenentID, ShiftID) " +
                                       "  values (" + RID + ",'" + sales_ID + "','" + payment_type + "', '" + Recivablepayment_amount + "', " +
                                       " '" + dueamount + "', '" + UploadDate + "', " +
                                       "  '" + UserInfo.UserName + "', 1 , '" + UserInfo.Shopid + "' , '" + Tenent.TenentID + "' , '" + UserInfo.ShiftID + "' );";
                        DataAccess.ExecuteSQL(sql4 + "insert into sales_payment_Log" + sql1);

                        string sqlWin = "  Update Win_sales_payment set Reffrance = '" + Reffrance + "',payment_amount = '" + payment_amount + "',change_amount = '" + changeamount + "', " +
                        " due_amount = '" + dueamount + "', dis = '" + DiscountTotal + "', vat= '" + vat + "', PaymentStutas = '" + PaymentStutas + "' " +
                        " where TenentID = " + Tenent.TenentID + " and sales_id='" + sales_ID + "' and payment_type='" + payment_type + "' ";
                        Datasyncpso.insert_Live_sync(sqlWin, "Win_sales_payment", "UPDATE");
                    }

                    //if (payment_type == "Cash")
                    //{
                    //    decimal ShiftSales = Convert.ToDecimal(payment_amount);
                    //    Update_ShiftSales_DayClose(ShiftSales);
                    //}
                    //else if (payment_type == "Gift Card")
                    //{
                    //    decimal VoucharAMT = Convert.ToDecimal(payment_amount);
                    //    Update_VoucharAMT_DayClose(VoucharAMT);
                    //}
                    //else
                    //{
                    //    decimal ChequeAMT = Convert.ToDecimal(payment_amount);
                    //    Update_ChequeAMT_DayClose(ChequeAMT);
                    //}

                }
            }
        }
        public void payment_item1(decimal payamount, decimal changeamount, decimal dueamount, string salestype, string salesdate, string Comment, string PaymentStutas)
        {
            if (salesdate != "")
            {
                DateTime sales_date = Convert.ToDateTime(salesdate);
                salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                DateTime sales_date = DateTime.Now;
                salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
            }

            //string trno = txtInvoice.Text;
            // string payamount        = lblTotalPayable.Text;
            //  string changeamount     = "0";
            //string due              =  "0";
            string vat = "0";// lblTotalVAT.Text;
            string DiscountTotal = lbloveralldiscount.Text; // Total discount = item wise discount + counter discount
            // string Comment          = "Gest";
            string overalldisRate = txtDiscountRate.Text;
            string vatRate = "0";// txtVATRate.Text;
            string InvoiceNO = lblInvoiceNO.Text;

            string Delivery_Cahrge = lblDeliveryChargis.Text != "" ? lblDeliveryChargis.Text : "0";

            if (dataGridPaymentSplit.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridPaymentSplit.Rows.Count; i++)
                {
                    string FSaleDt = "";
                    DateTime SaleDt = Convert.ToDateTime(dtsaleDate.Text);
                    FSaleDt = SaleDt.ToString("yyyy-MM-dd HH:mm:ss");
                    //dataGridPaymentSplit.Rows.Add(NO, Customer,Items, payment_type, Reffrance_NO, Amt);
                    string payment_type = dataGridPaymentSplit.Rows[i].Cells[3].Value.ToString();
                    string Reffrance = dataGridPaymentSplit.Rows[i].Cells[4].Value.ToString();
                    decimal payment_amount = Convert.ToDecimal(dataGridPaymentSplit.Rows[i].Cells[5].Value);
                    string gcust = dataGridPaymentSplit.Rows[i].Cells[1].Value.ToString();
                    string ItemsNam = dataGridPaymentSplit.Rows[i].Cells[2].Value.ToString();

                    int ID = getPaymentid(txtInvoice.Text);

                    string Cust = GetSplitGridCustomer(gcust);

                    string CustID = Cust.Split('-')[0].Trim();
                    string Customer = Cust.Split('-')[1].Trim();

                    //string invoiceSub = (i + 1).ToString();
                    string Innvoicecust = InvoiceNO + "/" + CustID;

                    int sales_id = 0;
                    if (i == 0)
                    {
                        sales_id = Convert.ToInt32(txtInvoice.Text);
                    }
                    else
                    {
                        sales_id = GetSalesIDFromPAyment(Innvoicecust);

                        if (sales_id == 0)
                        {
                            sales_id = MaxSalesID();
                        }
                    }

                    UpdateInvo(ItemsNam, sales_id.ToString(), Innvoicecust, Cust);

                    string Query = "select * from sales_payment where TenentID = " + Tenent.TenentID + " and sales_id='" + sales_id + "' and payment_type='" + payment_type + "' ";
                    DataTable dtQuery = DataAccess.GetDataTable(Query);
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql1 = " (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                   " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,SaleDt) " +
                                   "  values (" + Tenent.TenentID + "," + ID + ",'" + sales_id + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                                   " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + salesdate + "', '" + CustID + "', " +
                                   "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + Innvoicecust + "','" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "','" + FSaleDt + "');";
                    if (dtQuery.Rows.Count < 1)
                    {

                        int flag1 = DataAccess.ExecuteSQL("insert into sales_payment" + sql1 + "insert into sales_payment_Log" + sql1);

                        string sqlWin = " insert into Win_sales_payment (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                       " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,SaleDt) " +
                                       "  values (" + Tenent.TenentID + "," + ID + ",'" + sales_id + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                                       " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + salesdate + "', '" + CustID + "', " +
                                       "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + Innvoicecust + "', N'" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "','" + FSaleDt + "')";
                        Datasyncpso.insert_Live_sync(sqlWin, "Win_sales_payment", "INSERT");

                    }
                    else
                    {
                        string Reff1 = GetPAyReff(sales_id.ToString(), payment_type);


                        Reffrance = Reffrance + "," + Reff1;
                        Reffrance = Reffrance.Trim();
                        Reffrance = Reffrance.TrimStart(',');
                        Reffrance = Reffrance.TrimEnd(',');
                        Reffrance = Reffrance.Trim();


                        string sql2 = " Update sales_payment set Reffrance = '" + Reffrance + "',payment_amount = '" + payment_amount + "',change_amount = '" + changeamount + "', " +
                                      " due_amount = '" + dueamount + "', dis = '" + DiscountTotal + "', vat= '" + vat + "', PaymentStutas = '" + PaymentStutas + "' " +
                                      " where TenentID = " + Tenent.TenentID + " and sales_id='" + sales_id + "' and payment_type='" + payment_type + "' ;";
                        DataAccess.ExecuteSQL(sql2 + "insert into sales_payment_Log" + sql1);

                        string sqlWin = "  Update Win_sales_payment set Reffrance = '" + Reffrance + "',payment_amount = '" + payment_amount + "',change_amount = '" + changeamount + "', " +
                                        " due_amount = '" + dueamount + "', dis = '" + DiscountTotal + "', vat= '" + vat + "', PaymentStutas = '" + PaymentStutas + "' " +
                                        " where TenentID = " + Tenent.TenentID + " and sales_id='" + sales_id + "' and payment_type='" + payment_type + "' ";
                        Datasyncpso.insert_Live_sync(sqlWin, "Win_sales_payment", "UPDATE");
                    }

                    if (PaymentStutas != "Pending")
                    {

                        if (payment_type == "Cash")
                        {
                            decimal ShiftSales = Convert.ToDecimal(payment_amount);
                            Update_ShiftSales_DayClose(ShiftSales);
                        }
                        else if (payment_type == "Gift Card")
                        {
                            decimal VoucharAMT = Convert.ToDecimal(payment_amount);
                            Update_VoucharAMT_DayClose(VoucharAMT);
                        }
                        else
                        {
                            decimal ChequeAMT = Convert.ToDecimal(payment_amount);
                            Update_ChequeAMT_DayClose(ChequeAMT);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        public void payment_AmountSplit(decimal payamount, decimal changeamount, decimal dueamount, string salestype, string salesdate, string Comment, string PaymentStutas)
        {
            if (salesdate != "")
            {
                DateTime sales_date = Convert.ToDateTime(salesdate);
                salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                DateTime sales_date = DateTime.Now;
                salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
            }

            string trno = txtInvoice.Text;
            // string payamount        = lblTotalPayable.Text;
            //  string changeamount     = "0";
            //string due              =  "0";
            string vat = "0";// lblTotalVAT.Text;
            string DiscountTotal = lbloveralldiscount.Text; // Total discount = item wise discount + counter discount
            // string Comment          = "Gest";
            string overalldisRate = txtDiscountRate.Text;
            string vatRate = "0";// txtVATRate.Text;
            string InvoiceNO = lblInvoiceNO.Text;

            string Delivery_Cahrge = lblDeliveryChargis.Text != "" ? lblDeliveryChargis.Text : "0";

            salesSplit.InvNO = null;

            if (dataGridPaymentSplit.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridPaymentSplit.Rows.Count; i++)
                {
                    //dataGridPaymentSplit.Rows.Add(NO, Customer,Items, payment_type, Reffrance_NO, Amt);
                    string FSaleDt = "";
                    DateTime SaleDt = Convert.ToDateTime(dtsaleDate.Text);
                    FSaleDt = SaleDt.ToString("yyyy-MM-dd HH:mm:ss");

                    string payment_type = dataGridPaymentSplit.Rows[i].Cells[3].Value.ToString();
                    string Reffrance = dataGridPaymentSplit.Rows[i].Cells[4].Value.ToString();
                    decimal payment_amount = Convert.ToDecimal(dataGridPaymentSplit.Rows[i].Cells[5].Value);
                    string gcust = dataGridPaymentSplit.Rows[i].Cells[1].Value.ToString();
                    string ItemsNam = dataGridPaymentSplit.Rows[i].Cells[2].Value.ToString();

                    int ID = getPaymentid(txtInvoice.Text);

                    string Cust = GetSplitGridCustomer(gcust);

                    string CustID = Cust.Split('-')[0].Trim();
                    string Customer = Cust.Split('-')[1].Trim();

                    string invoiceSub = (i + 1).ToString();
                    string Innvoicecust = InvoiceNO + "/" + invoiceSub;

                    if (salesSplit.InvNO == null)
                    {
                        salesSplit.InvNO = Innvoicecust;
                    }
                    else
                    {
                        string InvoNO = salesSplit.InvNO;
                        salesSplit.InvNO = InvoNO + "," + Innvoicecust;
                    }

                    string Query = "select * from sales_payment where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and InvoiceNO='" + Innvoicecust + "'  and payment_type='" + payment_type + "' ";
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql1 = "  (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                      " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,AmountSplit,SaleDt) " +
                                      "  values (" + Tenent.TenentID + "," + ID + ",'" + trno + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                                      " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + salesdate + "', '" + CustID + "', " +
                                      "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + Innvoicecust + "','" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "',1,'" + FSaleDt + "');";
                    DataTable dtQuery = DataAccess.GetDataTable(Query);
                    if (dtQuery.Rows.Count < 1)
                    {


                        int flag1 = DataAccess.ExecuteSQL("insert into sales_payment" + sql1 + "insert into sales_payment_Log" + sql1);

                        string sqlWin = " insert into Win_sales_payment (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                       " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,AmountSplit,SaleDt) " +
                                       "  values (" + Tenent.TenentID + "," + ID + ",'" + trno + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                                       " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + salesdate + "', '" + CustID + "', " +
                                       "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + Innvoicecust + "', N'" + Customer + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "',1,'" + FSaleDt + "')";
                        Datasyncpso.insert_Live_sync(sqlWin, "Win_sales_payment", "INSERT");

                    }
                    else
                    {
                        string Reff1 = GetPAyReff(trno.ToString(), payment_type);
                        Reffrance = Reffrance + "," + Reff1;
                        Reffrance = Reffrance.Trim();
                        Reffrance = Reffrance.TrimStart(',');
                        Reffrance = Reffrance.TrimEnd(',');
                        Reffrance = Reffrance.Trim();

                        //string sum = GetPaySum(trno.ToString(), payment_type);

                        //string[] S = sum.Split(',');

                        //decimal payment_amount1 = Convert.ToDecimal(S[0]);
                        //decimal change_amount1 = Convert.ToDecimal(S[1]);
                        //decimal due_amount1 = Convert.ToDecimal(S[2]);
                        //decimal dis1 = Convert.ToDecimal(S[3]);
                        //decimal vat1 = Convert.ToDecimal(S[4]);

                        //payment_amount = payment_amount + payment_amount1;
                        //changeamount = changeamount + change_amount1;
                        //dueamount = dueamount + due_amount1;
                        //DiscountTotal = DiscountTotal + dis1;
                        //vat = vat + vat1;

                        string sql2 = " Update sales_payment set Reffrance = '" + Reffrance + "',payment_amount = '" + payment_amount + "',change_amount = '" + changeamount + "', " +
                        " due_amount = '" + dueamount + "', dis = '" + DiscountTotal + "', vat= '" + vat + "', PaymentStutas = '" + PaymentStutas + "' " +
                        " where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and InvoiceNO='" + Innvoicecust + "' and payment_type='" + payment_type + "'; ";
                        DataAccess.ExecuteSQL(sql2 + "insert into sales_payment_Log" + sql1);

                        string sqlWin = "  Update Win_sales_payment set Reffrance = '" + Reffrance + "',payment_amount = '" + payment_amount + "',change_amount = '" + changeamount + "', " +
                        " due_amount = '" + dueamount + "', dis = '" + DiscountTotal + "', vat= '" + vat + "', PaymentStutas = '" + PaymentStutas + "' " +
                        " where TenentID = " + Tenent.TenentID + " and sales_id='" + trno + "' and InvoiceNO='" + Innvoicecust + "' and payment_type='" + payment_type + "' ";
                        Datasyncpso.insert_Live_sync(sqlWin, "Win_sales_payment", "UPDATE");
                    }

                    if (payment_type == "Cash")
                    {
                        decimal ShiftSales = Convert.ToDecimal(payment_amount);
                        Update_ShiftSales_DayClose(ShiftSales);
                    }
                    else if (payment_type == "Gift Card")
                    {
                        decimal VoucharAMT = Convert.ToDecimal(payment_amount);
                        Update_VoucharAMT_DayClose(VoucharAMT);
                    }
                    else
                    {
                        decimal ChequeAMT = Convert.ToDecimal(payment_amount);
                        Update_ChequeAMT_DayClose(ChequeAMT);
                    }
                }
            }
        }
        public static string GetPAyReff(string sales_id, string payment_type)
        {
            string Reff = "";
            string Query = "select Reffrance from sales_payment where TenentID = " + Tenent.TenentID + " and sales_id='" + sales_id + "' and payment_type='" + payment_type + "' ";
            DataTable dtQuery = DataAccess.GetDataTable(Query);

            int Count = dtQuery.Rows.Count;

            for (int i = 0; i < Count; i++)
            {
                if (dtQuery.Rows[i]["Reffrance"] != null)
                {
                    string Reff1 = dtQuery.Rows[i]["Reffrance"].ToString();
                    if (Reff1 != "")
                    {
                        Reff = Reff1 + "," + Reff;
                    }
                }
            }

            Reff = Reff.Trim();
            Reff = Reff.TrimStart(',');
            Reff = Reff.TrimEnd(',');
            return Reff;
        }
        public string GetPaySum(string sales_id, string payment_type)
        {
            string sum = "";
            string Query = "select * from sales_payment where TenentID = " + Tenent.TenentID + " and sales_id='" + sales_id + "' and payment_type='" + payment_type + "' ";
            DataTable dtQuery = DataAccess.GetDataTable(Query);

            int Count = dtQuery.Rows.Count;

            //payment_amount,change_amount,due_amount,dis,vat

            decimal payment_amount = 0;
            decimal change_amount = 0;
            decimal due_amount = 0;
            decimal dis = 0;
            decimal vat = 0;

            for (int i = 0; i < Count; i++)
            {
                decimal payment_amount1 = Convert.ToDecimal(dtQuery.Rows[i]["payment_amount"]);
                decimal change_amount1 = Convert.ToDecimal(dtQuery.Rows[i]["change_amount"]);
                decimal due_amount1 = Convert.ToDecimal(dtQuery.Rows[i]["due_amount"]);
                decimal dis1 = Convert.ToDecimal(dtQuery.Rows[i]["dis"]);
                decimal vat1 = Convert.ToDecimal(dtQuery.Rows[i]["vat"]);

                payment_amount = payment_amount + payment_amount1;
                change_amount = change_amount + change_amount1;
                due_amount = due_amount + due_amount1;
                dis = dis + dis1;
                vat = vat + vat1;
            }

            sum = payment_amount + "," + change_amount + "," + due_amount + "," + dis + "," + vat;
            return sum;
        }
        public int MaxSalesID()
        {
            int sales_id = 1;
            string sql = "select  *  from sales_payment Where TenentID=" + Tenent.TenentID + " order by sales_id desc";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                double id = Convert.ToDouble(dt.Rows[0]["sales_id"].ToString()) + 1;
                sales_id = Convert.ToInt32(id);
            }
            else
            {
                sales_id = 1;
            }
            return sales_id;
        }
        public int GetSalesIDFromPAyment(string InvoiceNO)
        {
            string sql3 = "select * from sales_payment where TenentID=" + Tenent.TenentID + " and InvoiceNO='" + InvoiceNO + "' ";

            DataTable dt3 = DataAccess.GetDataTable(sql3);
            int Salesid = 0;
            if (dt3.Rows.Count > 0)
            {
                Salesid = Convert.ToInt32(dt3.Rows[0]["sales_id"]);
            }
            else
            {
                Salesid = 0;
            }
            return Salesid;
        }
        public string GetSplitGridCustomer(string Name)
        {
            string Customer = "";
            Name = Name.Trim();
            string sql = "Select * from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = '" + Name + "'";

            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                lblCustID.Text = dt.Rows[0]["ID"].ToString();
                Customer = dt.Rows[0]["ID"].ToString() + " - " + dt.Rows[0]["Name"].ToString();
            }
            else
            {
                string sql1 = "Select * from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = 'Gest'";

                DataTable dt1 = DataAccess.GetDataTable(sql1);

                string ID = "";
                if (dt1.Rows.Count > 0)
                {
                    lblCustID.Text = dt1.Rows[0]["ID"].ToString();
                    ID = dt1.Rows[0]["ID"].ToString();
                }
                Customer = ID + " - " + "Gest";
            }
            return Customer;
        }
        public static int getPaymentid(string sales_id)
        {
            int TenentID = Tenent.TenentID;

            int ID12 = DataAccess.getPaymentid(TenentID, sales_id);
            return ID12;
        }
        public static int getPaymentidRecivable(string sales_id)
        {
            int TenentID = Tenent.TenentID;

            int ID12 = DataAccess.getPaymentidRecivable(TenentID, sales_id);
            return ID12;
        }
        //////  Update DayClose /////////////
        public static void Update_ShiftSales_DayClose(decimal ShiftSales)
        {
            //TenentID,UserID,TrmID,ShiftID,Date,OpAMT,ShiftSales,ShiftReturn,ShiftCIH,VoucharAMT,ExpAMT,ChequeAMT,AMTDelivered,DeliveredTO,RefNO,Notes,UploadDate,
            //Uploadby,	SyncDate,Syncby,SynID

            int ShiftID = UserInfo.ShiftID;

            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sql5 = "Select ShiftSales from DayClose where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                decimal ShiftSalesold = Convert.ToDecimal(dt5.Rows[0]["ShiftSales"]);
                ShiftSales = ShiftSales + ShiftSalesold;

                string sql1 = " Update DayClose set ShiftSales=" + ShiftSales + " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'  ";
                DataAccess.ExecuteSQL(sql1);

                string sqlWin = "  Update DayClose set ShiftSales=" + ShiftSales + " " +
                       " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'  ";
                Datasyncpso.insert_Live_sync(sqlWin, "DayClose", "UPDATE");

                DataAccess.Update_ShiftCIH_DayClose();

            }

        }
        public static void Update_VoucharAMT_DayClose(decimal VoucharAMT)
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
                decimal VoucharAMTold = Convert.ToDecimal(dt5.Rows[0]["VoucharAMT"]);
                VoucharAMT = VoucharAMT + VoucharAMTold;

                string sql1 = " Update DayClose set VoucharAMT=" + VoucharAMT + " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'  ";
                DataAccess.ExecuteSQL(sql1);

                string sqlWin = "  Update DayClose set VoucharAMT=" + VoucharAMT + " " +
                      " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'   ";

                Datasyncpso.insert_Live_sync(sqlWin, "DayClose", "UPDATE");

                DataAccess.Update_ShiftCIH_DayClose();
            }
        }
        public static void Update_ChequeAMT_DayClose(decimal ChequeAMT)
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
                decimal ChequeAMTold = Convert.ToDecimal(dt5.Rows[0]["ChequeAMT"]);
                ChequeAMT = ChequeAMT + ChequeAMTold;

                string sql1 = " Update DayClose set ChequeAMT=" + ChequeAMT + " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'  ";
                DataAccess.ExecuteSQL(sql1);

                string sqlWin = "  Update DayClose set  ChequeAMT=" + ChequeAMT + " " +
                      " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'    ";
                Datasyncpso.insert_Live_sync(sqlWin, "DayClose", "UPDATE");

                DataAccess.Update_ShiftCIH_DayClose();
            }
        }
        public static void Check_OpeningBalance()
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string Condition = "where TenentID=" + Tenent.TenentID + " and TrmID = '" + UserInfo.Shopid + "' and Date = '" + Date + "' and ShiftStutas = 0 "; // UserID = '" + UserInfo.Userid + "' and

            string sql5 = "Select UserID from DayClose " + Condition;

            DataTable dayDt = DataAccess.GetDataTable(sql5);
            if (dayDt.Rows.Count > 0)
            {
                string sql123 = " select MAX(ShiftID) from DayClose " + Condition;
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int shift = Convert.ToInt32(dt12.Rows[0][0]);
                    UserInfo.ShiftID = shift;
                }
                else
                {
                    if (Application.OpenForms["OpeningBalance"] != null)
                    {
                        Application.OpenForms["OpeningBalance"].BringToFront();
                    }
                    else
                    {
                        if (Opening_Balance.Falg == false)
                        {
                            //MessageBox.Show("Please Enter Opening Balance First");
                            Report.OpeningBalance go = new Report.OpeningBalance();
                            go.Show();
                            go.BringToFront();

                            Opening_Balance.Falg = true;
                        }
                        else
                        {
                            Opening_Balance.Falg = false;
                        }
                    }
                }
            }
            else
            {

                if (Application.OpenForms["OpeningBalance"] != null)
                {
                    Application.OpenForms["OpeningBalance"].BringToFront();
                }
                else
                {
                    if (Opening_Balance.Falg == false)
                    {
                        //MessageBox.Show("Please Enter Opening Balance First");
                        Report.OpeningBalance go = new Report.OpeningBalance();
                        go.Show();
                        go.BringToFront();

                        Opening_Balance.Falg = true;
                    }
                    else
                    {
                        Opening_Balance.Falg = false;
                    }
                }
            }
        }
       
        /// //// Order Way Transection Add  ///////////Store into tbl_orderWay_transection table //////// 
        public void insertCommission()
        {
            //OrderWayID,Sales_ID,name,Commission_per,Commission_Amount,Paid_Commission,Paid_Date,Paid_Reffrance,Pending_Commission,

            if (comboSalesMan.Text != "Walk In - Walk In" && comboSalesMan.Text != "")
            {

                string OrderWayID = comboSalesMan.Text.Split('-')[0].Trim();
                string name = comboSalesMan.Text.Split('-')[1].Trim();
                string sqlCmd = "Select * from tbl_orderWay_Maintenance where TenentID=" + Tenent.TenentID + " and OrderWayID='" + OrderWayID + "' and Name1='" + name + "'  "; //From view combination of tbl_customer and custcredit

                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                if (dt1.Rows.Count > 0)
                {
                    string Sales_ID = txtInvoice.Text;
                    string Name1 = dt1.Rows[0]["Name1"].ToString();
                    string Name2 = dt1.Rows[0]["Name2"].ToString();
                    decimal Commission_per = Convert.ToDecimal(dt1.Rows[0]["Commission_per"]);
                    decimal Commission_Amount = Convert.ToDecimal(dt1.Rows[0]["Commission_Amount"]);
                    decimal Paid_Commission = 0;
                    decimal payamount = Convert.ToDecimal(lblTotalPayable.Text);
                    decimal Commission = 0;
                    if (Commission_per != 0)
                    {
                        Commission = (payamount * Commission_per) / 100;
                    }
                    else
                    {
                        Commission = Commission_Amount;
                    }

                    decimal Pending_Commission = Commission;


                    if (Commission != 0)
                    {

                        int ID = DataAccess.getorderWay_transectionMYid(Tenent.TenentID, Sales_ID);

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql1 = " insert into tbl_orderWay_transection (TenentID,ID, OrderWayID,Sales_ID,Name1,Name2,Commission_per,Commission_Amount," +
                                  "Pending_Commission , Paid_Commission ,Uploadby ,UploadDate ,SynID)" +
                               "  values (" + Tenent.TenentID + "," + ID + ",'" + OrderWayID + "','" + Sales_ID + "','" + Name1 + "','" + Name2 + "'," + Commission_per + "," + Commission + "," + Pending_Commission + " , " + Paid_Commission + " ,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        int flag1 = DataAccess.ExecuteSQL(sql1);

                        string sql1Win = " insert into Win_tbl_orderWay_transection (TenentID,ID, OrderWayID,Sales_ID,Name1,Name2,Commission_per,Commission_Amount," +
                                 "Pending_Commission , Paid_Commission ,Uploadby ,UploadDate ,SynID)" +
                              "  values (" + Tenent.TenentID + "," + ID + ",'" + OrderWayID + "','" + Sales_ID + "', N'" + Name1 + "', N'" + Name2 + "'," + Commission_per + "," + Commission + "," + Pending_Commission + " , " + Paid_Commission + " ,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";

                        Datasyncpso.insert_Live_sync(sql1Win, "Win_tbl_orderWay_transection", "INSERT");

                    }

                }

            }

        }

        #endregion

        // Direct sales and print Receipt       
        public void SaveandPrint(bool isprint)
        {
            if (dgrvSalesItemList.Rows.Count==0)
            {
                MessageBox.Show("Sorry ! You don't have enough product in Item cart \n  Please Add to cart", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }

            if (comboSalesMan.Text == "")
            {
                MessageBox.Show("Sorry ! Please Select oeder Way:", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }
            else
            {
                //getInvoiceno();

                decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                decimal Payamount = Convert.ToDecimal(txtcashRecived.Text);
                decimal ChangeAmount = 0;
                decimal dueAmount = 0;


                if (TotalPayable > Payamount)
                {
                    decimal due = TotalPayable - Payamount;
                    dueAmount = due;
                }
                else if (Payamount > TotalPayable)
                {
                    decimal change = Payamount - TotalPayable;
                    ChangeAmount = change;
                }
                else
                {
                    dueAmount = 0;
                    ChangeAmount = 0;

                }

                string Invo = lblInvoiceNO.Text;

                string TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");


                payment_item(Payamount, ChangeAmount, dueAmount, "Cash", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), "1", "Gest", "Success");

                ///// save sales items one by one 
                int sales_id = Convert.ToInt32(txtInvoice.Text);
                bool creditFalg = isCreditInvoice(sales_id);
                if (creditFalg == false)
                {
                    string Payby = "PriPaid";
                    string OrderStatus = "Paid-send to Kitchen";
                    if (lblIsCustAdvanceAmtYN.Text == ".")
                    {
                        OrderStatus = "Advance Paid-Ready to Delivery";
                        Payby = "Advance";
                    }

                    sales_item(TransDate, OrderStatus, 0, Payby, txtComment.Text);

                    string ActivityName = "sales Cash Transaction";
                    string LogData = "Save Sales Transaction SaveandPrint() as Cash with InvoiceNO = " + Invo + "and Cust_Code=" + lblCustID.Text + " and OrderTotal =" + TotalPayable + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                    string OrderWayID = comboSalesMan.Text.Split('-')[0];
                    string name = comboSalesMan.Text.Split('-')[1];
                    if (OrderWayID != "Walk In - Walk In" && OrderWayID != "")
                    {
                        insertCommission();
                    }
                }
               // if (isBookingOn())
               // {
                    if (isprint == true)
                    {
                        parameter.autoprintid = "1";
                        //POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                        //go.ShowDialog();
                        string File = getPrintFile("Cash"); // Cash , Creadit , Kitchen
                        string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash"); // Cash , Credit , Kitchen
                        PRintInvoice1(txtInvoice.Text, File, DefaultPrinter);
                    }
              //  }
                if (isInvoiceWithDelivered())
                {
                    string sql1 = "update sales_item set IsDelivered=1 where sales_id=" + sales_id + "";
                    DataAccess.ExecuteSQL(sql1);
                }

                //string typr = GetStoreprintType();

                //PRintInvoice(txtInvoice.Text, typr);// Default , Short ,Split

                ////dgrvSalesItemList.Rows.Clear();yogesh change 230519
                ////txtDiscountRate.Text = "0";
                ////DiscountCalculation();
                ////vatcal();
                //Last30daysReport(dtStartDate.Text);
                ////this.tabPageSR_Payment.Parent = null; //Hide payment tab  

                ////this.tabPageSR_Split_Bill.Parent = null; //Hide Split tab
                ////tabSRcontrol.SelectedTab = tabPageSR_Counter;

                ////txtCustomer.Text = "Cash";
                //GridPayment.Rows.Clear();
                lblPaid.Text = "0";
                ////txtcashRecived.Text = "";
                ////lblChangeAmt.Text = "0";

                ////UserInfo.EditTransation = false;
                ////UserInfo.Invoice = 0;
                ////UserInfo.InvoicetransNO = null;

                //    scope.Complete();
                //}
                clearInvoice();
                manageInvoice();
            }
        }

        ///// Open Payment Tab to receive amoount
        private void btnSalesCredit_Click(object sender, EventArgs e)
        {
            getCusto();
            SalesCreditPayment();
          

        }
        public static bool isBookingOn()
        {
            string sqlIsbooking = "Select * from storeconfig where TenentID=" + Tenent.TenentID + " and IsBooking='1' "; //From view combination of tbl_customer and custcredit
            DataTable dt1 = DataAccess.GetDataTable(sqlIsbooking);
            if (dt1.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
      
        public static bool isInvoiceWithDelivered()
        {
            string sqlisInvoiceWithDelivered = "Select * from storeconfig where TenentID=" + Tenent.TenentID + " and IsInvoiceWithDelivery='1' "; //From view combination of tbl_customer and custcredit
            DataTable dt1 = DataAccess.GetDataTable(sqlisInvoiceWithDelivered);
            if (dt1.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void SalesCreditPayment()
        {
            if (lblTotalPayable.Text == "00" || lblTotalPayable.Text == "0" || lblTotalPayable.Text == string.Empty)
            {
                MessageBox.Show("Sorry ! You don't have enough product in Item cart \n  Please Add to cart", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            else if (comboSalesMan.Text == "")
            {
                MessageBox.Show("Sorry ! Please Select oeder Way:", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            else
            {

                //Payment go = new Payment(GetDataTableFromDGV(dgrvSalesItemList), lblTotal.Text, lblsubtotal.Text, lblTotalPayable.Text, lbloveralldiscount.Text, lblTotalVAT.Text, txtDiscountRate.Text, txtVATRate.Text, txtInvoice.Text, lblTotalItems.Text);
                // go.ShowDialog();  // change  lblTotalDisCount to lbloveralldiscount

                //Open New tab
                // txtPaidAmount.Text = "0.00"; //lblTotalPayable.Text;
                //tabSRcontrol.TabPages.Insert(1, tabPageSR_Payment);
                this.tabPageSR_Payment.Parent = this.tabSRcontrol; //show
                tabSRcontrol.SelectedTab = tabPageSR_Payment;
                tabPageSR_Paymentb.Visible = true;

       
                lblPaid.Text = "0";
                //dgrvSalesItemList.Rows.Clear();

                DiscountCalculation();
                vatcal();
                GridPayment.Rows.Clear();
             
              
            }
        }

        // To pass whole Datagridview - Now not used
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            ////Hide fields Open to pass payment page
            dgrvSalesItemList.Columns[4].Visible = true; // ID             // new in 8.1 version
            dgrvSalesItemList.Columns[5].Visible = true; // Disamt         // new in 8.1 version
            dgrvSalesItemList.Columns[6].Visible = true; // taxamt         // new in 8.1 version
            dgrvSalesItemList.Columns[7].Visible = true; // Discount rate  // new in 8.1 version            
            dgrvSalesItemList.Columns[9].Visible = true; // kitdisplay    // new in 8.3.1 version

            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
            
        }
    
        #region  Links
        // Call System Calculator
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
            catch (Exception ex)
            {
                MyMessageAlert.ShowBox(ex.Message, "Exception");

            }
        }
        //--  new   8.1 version
        private void helplnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            parameter.helpid = "SR";
            HelpPage go = new HelpPage();
            go.MdiParent = this.ParentForm;
            go.Show();

            //SalesRagister.Currency_Shortcuts uc = new SalesRagister.Currency_Shortcuts();
            //uc.Dock = DockStyle.None;
            //panel1.Controls.Add(uc);
            // this.Controls.Add(uc);            

        }
        ///ShortCut Keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Shift | Keys.Control | Keys.P))
            {
                DialogResult result = MessageBox.Show("Do you want to Complete this transaction?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btnCashAndPrint.PerformClick();  //Shift+P for Open Payment Page 
                }
            }
            else if (keyData == (Keys.Enter))
            {
                //if (txtSearchItem.Text != "" && txtSearchItem.Text != " ")
                //{
                //TextItemSearch();

                if (txtSearchItem.Text != "")
                {
                    txtBarcodeReaderBox.Focus();
                }

                if (txtInvoiceCash.Text != "")
                {
                    txtCas.Focus();
                }

                //}
                //CashirTestSearch();
            }
            else if (keyData == (Keys.Shift | Keys.S))
            {
                btnSuspend.PerformClick(); // Shift+S -> Suspen
            }
            else if (keyData == (Keys.Shift | Keys.Q))
            {

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Text box Validatation
        //Validation Overall Discount Rate
        private void txtDiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtDiscountRate.Text.ToString(), @"\.\d\d\d");

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Validation Paid amount
        #endregion

        #region Payment receiver tab page calculation

        public void compairePaymentAmt()
        {
            decimal PaidAmt = txtPaidAmount.Text != "" ? Convert.ToDecimal(txtPaidAmount.Text) : 0;
            decimal lblPaidAmt = Convert.ToDecimal(lblTotalpayableAmtPY.Text);
            if (PaidAmt == lblPaidAmt)
                btnCompleteSalesAndPrint.Enabled = true;
            else
            {
                btnCompleteSalesAndPrint.Enabled = false;
                if (GridPayment.Rows.Count > 0)
                {
                    btnCompleteSalesAndPrint.Enabled = true;
                }

            }

        }

        //paid amount Input Operation
        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {


            compairePaymentAmt();
            if (lblTotalPayable.Text == "" || lblTotalPayable.Text == ".")
            {
                // MessageBox.Show("please insert Amount ");
            }
            else
            {
                try
                {
                    //decimal Paid = getPaymentGridSum();
                    if (Convert.ToDouble(lblPaid.Text) >= Convert.ToDouble(lblTotalPayable.Text))
                    {
                        double changeAmt = Convert.ToDouble(lblPaid.Text) - Convert.ToDouble(lblTotalPayable.Text);
                        changeAmt = Math.Round(changeAmt, 3);
                        txtChangeAmount.Text = changeAmt.ToString();
                        txtDueAmount.Text = "0";
                        this.AcceptButton = btnCompleteSalesAndPrint;
                    }
                    if (Convert.ToDouble(lblPaid.Text) <= Convert.ToDouble(lblTotalPayable.Text))
                    {
                        double changeAmt = Convert.ToDouble(lblTotalPayable.Text) - Convert.ToDouble(lblPaid.Text);
                        changeAmt = Math.Round(changeAmt, 3);
                        txtDueAmount.Text = changeAmt.ToString();
                        txtChangeAmount.Text = "0";
                        this.AcceptButton = btnCompleteSalesAndPrint;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }
        // Sales cart page load
        private void tabPageSR_Counter_Enter(object sender, EventArgs e)
        {
            txtBarcodeReaderBox.Focus();
        }

        //Payment tab page load 
        private void tabPageSR_Payment_Enter(object sender, EventArgs e)
        {
            try
            {
                //ComboCustID.Items.Clear();

                //Customer Databind 
                string sqlCust = "select   DISTINCT  Name,EmailAddress,Phone  from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer'";

                DataTable dtCust = DataAccess.GetDataTable(sqlCust);

                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    //ComboCustID.Items.Add(dtCust.Rows[i][0] + " - " + dtCust.Rows[i][2] + " - " + dtCust.Rows[i][1]);
                    ComboSplitCustomer.Items.Add(dtCust.Rows[i][0] + " - " + dtCust.Rows[i][2] + " - " + dtCust.Rows[i][1]);
                }

                //ComboCustID.DataSource = dtCust;
                //ComboCustID.DisplayMember = "Name";
                if (txtCustomer.Text == "")
                {
                    //ComboCustID.Text = "Gest";
                    ComboSplitCustomer.Text = "Gest";
                }


                btnCompleteSalesAndPrint.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void AutoComplete()
        {
            string sqlCust = "";
            string search = "";
            if (txtCustomer.Text == "")
            {
                sqlCust = "select   DISTINCT  Name,Phone,EmailAddress  from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer'";
            }
            else
            {
                search = txtCustomer.Text.Trim();
                sqlCust = "select   DISTINCT  Name,Phone,EmailAddress  from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer' and (Name like '%" + search + "%'  or Phone like '%" + search + "%'  or EmailAddress like '%" + search + "%')";
            }


            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust != null)
            {
                AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
                foreach (DataRow rw in dtCust.Rows)
                {
                    string Val = rw["Name"] + " - " + rw["Phone"] + " - " + rw["EmailAddress"].ToString();
                    AutoItem.Add(Val);

                }
                txtCustomer.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCustomer.AutoCompleteCustomSource = AutoItem;
            }

        }
        //only save
        private void btnSaveOnly_Click(object sender, EventArgs e)
        {

            //yogesh 
            string payment_type = CombPayby.Text.ToString().Trim();
            string Reffrance_NO = txtReffrance.Text;

            if (payment_type != "Cash" && payment_type != "Credit" && Reffrance_NO == "")
            {
                txtReffrance.Focus();
                MessageBox.Show("Reffrance_NO Can Not Be Empty in " + payment_type);
                return;
            }
            if (txtPaidAmount.Text == "" || txtPaidAmount.Text == ".")
            {
                return;
            }

            decimal Totalpay = Convert.ToDecimal(lblTotalpayableAmtPY.Text);
            decimal totalPaid = Convert.ToDecimal(lblPaid.Text);

            decimal rest = (Totalpay - totalPaid);
            decimal Enter = Convert.ToDecimal(txtPaidAmount.Text);

            if (Enter > rest)
            {
                txtPaidAmount.Focus();
                txtPaidAmount.Text = (rest).ToString();
                MessageBox.Show("Plase Enter Less Than" + rest);
                return;
            }
            //yogesh 
            decimal paidatm = 0;
            if (lblPaid.Text == string.Empty)
            {
                MessageBox.Show("Please insert paid amount.", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            else
            {
                paidatm = Convert.ToDecimal(lblPaid.Text);
            }

            //if (lblPaid.Text == "00" || lblPaid.Text == "0" || lblPaid.Text == string.Empty)
            //{
            //    MessageBox.Show("Please insert paid amount. \n  If you want full due transaction \n Please insert 0.00 ", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //}


            decimal enterAmt = Convert.ToDecimal(txtPaidAmount.Text);

            if (paidatm <= 0)
            {
                if (Totalpay == enterAmt)
                {
                    lblPaid.Text = Totalpay.ToString();
                    txtDueAmount.Text = "0";
                    txtChangeAmount.Text = "0";
                    if (chkCreditTrans.Checked == true)
                    {
                        CreditInvoice(false);
                    }
                    else
                    {
                        onlysave();
                    }
                    //Last30daysReport(dtStartDate.Text);
                }
                else
                {
                    MessageBox.Show("Plase Enter paid amount Equal of Total Payable");
                    return;
                }
            }
            else
            {
                try
                {
                    if (chkCreditTrans.Checked == true)
                    {
                        CreditInvoice(false);
                    }
                    else
                    {
                        onlysave();
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }

            clearInvoice();
            manageInvoice();

        }
        public void onlysave()
        {
            decimal Totalpay = Convert.ToDecimal(lblTotalpayableAmtPY.Text);
            decimal totalPaid = Convert.ToDecimal(lblPaid.Text);

            if (Totalpay == totalPaid)
            {
                //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                //{
                //Save payment info into sales_payment table

                decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                decimal ChangeAmount = Convert.ToDecimal(txtChangeAmount.Text);
                decimal DueAmount = Convert.ToDecimal(txtDueAmount.Text);

                string Invo = lblInvoiceNO.Text;
                string Payby = CombPayby.Text.ToString().Trim();
                string TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");
                payment_item(TotalPayable, ChangeAmount, DueAmount, Payby, TransDate, lblCustID.Text, txtComment.Text, "Success");

                ///// save sales items one by one 
                int sales_id = Convert.ToInt32(txtInvoice.Text);
                bool creditFalg = isCreditInvoice(sales_id);
                if (creditFalg == false)
                {
                    sales_item(TransDate, "Paid-send to Kitchen", 0, "PriPaid", txtComment.Text);

                    string ActivityName = "sales Transaction";
                    string LogData = "Save Sales Transaction onlysave() with InvoiceNO = " + Invo + "and Cust_Code=" + lblCustID.Text + " and OrderTotal =" + TotalPayable + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                    string OrderWayID = comboSalesMan.Text.Split('-')[0];
                    string name = comboSalesMan.Text.Split('-')[1];
                    if (OrderWayID != "Walk In - Walk In" && OrderWayID != "")
                    {
                        insertCommission();
                    }
                }

                OpenCashDrawer1();

                //string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash");
                //POSPrintRptonlysave go = new POSPrintRptonlysave(txtInvoice.Text, DefaultPrinter);
                //go.ShowDialog();

                //MessageBox.Show("Successfully has been saved ");



            }
            else
            {
                MessageBox.Show("Total Payable and paid Amount not Match");
                return;
            }
        }
        public bool CheckISPaymentCredit(int Sales_id)
        {
            string sql = "select item_id from sales_item where TenentID = " + Tenent.TenentID + " and Sales_id = " + Sales_id + " and ISPaymentCredit = 1";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void btnCompleteSalesAndPrint_Click(object sender, EventArgs e)
        {

            //yogesh 
            string payment_type = CombPayby.Text.ToString().Trim();
            string Reffrance_NO = txtReffrance.Text;

            if (payment_type != "Cash" && payment_type != "Credit" && Reffrance_NO == "")
            {
                txtReffrance.Focus();
                MessageBox.Show("Reffrance_NO Can Not Be Empty in " + payment_type);
                return;
            }
            if (txtPaidAmount.Text == "" || txtPaidAmount.Text == ".")
            {
                return;
            }

            decimal Totalpay = Convert.ToDecimal(lblTotalpayableAmtPY.Text);
            decimal totalPaid = Convert.ToDecimal(lblPaid.Text);

            decimal rest = (Totalpay - totalPaid);
            decimal Enter = Convert.ToDecimal(txtPaidAmount.Text);

            if (Enter > rest)
            {
                txtPaidAmount.Focus();
                txtPaidAmount.Text = (rest).ToString();
                MessageBox.Show("Plase Enter Less Than" + rest);
                return;
            }
            //yogesh 

            if (lblPaid.Text == "00" || lblPaid.Text == "0" || lblPaid.Text == string.Empty)
            {
                //MessageBox.Show("Please insert paid amount. \n  If you want full due transaction \n Please insert 0.00 ", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (chkCreditTrans.Checked == false)
                {
                    if (Totalpay == Enter)
                    {
                        lblPaid.Text = Totalpay.ToString();
                        txtDueAmount.Text = "0";
                        txtChangeAmount.Text = "0";
                        Complate_order();
                        //Last30daysReport(dtStartDate.Text);yogesh 290619
                    }
                    else
                    {
                        MessageBox.Show("Plase Enter paid amount Equal of Total Payable");
                        return;
                    }
                }
                else
                {
                    Complate_order();
                    //Last30daysReport(dtStartDate.Text);yogesh 290619
                }
            }
            else
            {
                Complate_order();
                ///Last30daysReport(dtStartDate.Text);yogesh 290619
            }
            txtReffrance.Text = "";
            timerinvoiceno();
            tabSRcontrol.SelectedTab = tabPageSR_Counter;

            //}

        }
        public bool isCreditInvoice(int sales_id)
        {
            string Sql = "select sales_id from sales_item where TenentID = " + Tenent.TenentID + " and sales_id = " + sales_id + " and isPaymentCredit = 1";
            DataTable dt = DataAccess.GetDataTable(Sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool isAlreadyDeliveredInvoice(string sales_id)
        {
            string Sql = "select sales_id from sales_item where TenentID = " + Tenent.TenentID + " and sales_id = " + sales_id + " and IsDelivered = 1";
            DataTable dt = DataAccess.GetDataTable(Sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void Complate_order()
        {
            try
            {
                decimal Totalpay = Convert.ToDecimal(lblTotalpayableAmtPY.Text);
                decimal totalPaid = Convert.ToDecimal(lblPaid.Text);
                decimal GridPaid = getPaymentGridSum();

                if (Totalpay == totalPaid && chkCreditTrans.Checked == false)
                {
                    decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                    decimal ChangeAmount = Convert.ToDecimal(txtChangeAmount.Text);
                    decimal DueAmount = Convert.ToDecimal(txtDueAmount.Text);

                    string Invo = lblInvoiceNO.Text;
                    string Payby = CombPayby.Text.ToString().Trim();
                    string TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");
                    payment_item(TotalPayable, ChangeAmount, DueAmount, Payby, TransDate, lblCustID.Text, txtComment.Text, "Success");

                    ///// save sales items one by one
                    int sales_id = Convert.ToInt32(txtInvoice.Text);
                    bool creditFalg = isCreditInvoice(sales_id);
                    if (creditFalg == false)
                    {
                        sales_item(TransDate, "Paid-send to Kitchen", 0, "PriPaid", txtComment.Text);

                        string ActivityName = "sales Transaction";
                        string LogData = "Save Sales Transaction Complate_order() with InvoiceNO = " + Invo + "and Cust_Code=" + lblCustID.Text + " and OrderTotal =" + TotalPayable + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        string OrderWayID = comboSalesMan.Text.Split('-')[0];
                        string name = comboSalesMan.Text.Split('-')[1];
                        if (OrderWayID != "Walk In - Walk In" && OrderWayID != "")
                        {
                            insertCommission();
                        }
                    }

                    ///// // Open Print Invoice
                    parameter.autoprintid = "1";
                    //POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                    //go.ShowDialog();

                    string File = getPrintFile("Cash"); // Cash , Creadit , Kitchen
                    string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash"); // Cash , Credit , Kitchen

                    PRintInvoice1(txtInvoice.Text, File, DefaultPrinter);





                }
                else if (chkCreditTrans.Checked == true)
                {
                    CreditInvoice(true);
                }
                else
                {
                    MessageBox.Show("Total Payable and paid Amount not Match");
                    return;
                }

                clearInvoice();
                manageInvoice();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public void Complate_order1()
        {
            try
            {
                decimal Totalpay = Convert.ToDecimal(lblTotalPayment.Text);
                decimal totalPaid = Convert.ToDecimal(lblPaid1.Text);

                if (Totalpay == totalPaid)
                {
                    //Save payment info into sales_payment table

                    decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                    decimal ChangeAmount = Convert.ToDecimal(0);
                    decimal DueAmount = Convert.ToDecimal(0);
                    string Payby = CombPayby.Text.ToString().Trim();
                    string TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");
                    payment_item1(TotalPayable, ChangeAmount, DueAmount, Payby, TransDate, txtComment.Text, "Success");

                    ///// save sales items one by one 
                    int sales_id = Convert.ToInt32(txtInvoice.Text);
                    bool creditFalg = isCreditInvoice(sales_id);
                    if (creditFalg == false)
                    {
                        sales_item1(TransDate, "Paid-send to Kitchen", 0, "PriPaid", txtComment.Text);

                        string OrderWayID = comboSalesMan.Text.Split('-')[0];
                        string name = comboSalesMan.Text.Split('-')[1];
                        if (OrderWayID != "Walk In - Walk In" && OrderWayID != "")
                        {
                            insertCommission();
                        }
                    }

                    string Trno = "";

                    int rows = dgrvSalesItemList.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        if (dgrvSalesItemList.Rows[i].Cells[13].Value != null)
                        {
                            string TRAN = dgrvSalesItemList.Rows[i].Cells[13].Value.ToString();
                            bool Falg = FoundSalesID(Trno, TRAN);
                            if (Falg == false)
                            {
                                Trno = Trno + "," + TRAN;
                            }
                        }
                    }

                    if (Trno != "")
                    {
                        Trno = Trno.Trim();
                        Trno = Trno.TrimStart(',');
                        Trno = Trno.TrimEnd(',');

                        string[] Split = Trno.Split(',');
                        int Length = Split.Length;

                        for (int i = 0; i < Length; i++)
                        {
                            ///// // Open Print Invoice
                            string no = Split[i].ToString().Trim();
                            parameter.autoprintid = "1";
                            //POSPrintRpt go = new POSPrintRpt(no);
                            //go.ShowDialog();

                            string typr = GetStoreprintType();
                            PRintInvoice(no, typr);// Default , Short ,Split

                        }
                    }
                    else
                    {
                        ///// // Open Print Invoice
                        parameter.autoprintid = "1";
                        //POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                        //go.ShowDialog();

                        string typr = GetStoreprintType();
                        PRintInvoice(txtInvoice.Text, typr);// Default , Short ,Split
                    }



                    //Clean Datagridview and Back to sales cart
                    dgrvSalesItemList.Rows.Clear();
                    txtDiscountRate.Text = "0";
                    DiscountCalculation();
                    vatcal();
                    this.tabPageSR_Payment.Parent = null; //Hide payment tab
                                                          // tabSRcontrol.SelectedTab = tabPageSR_Counter;

                    this.tabPageSR_Split_Bill.Parent = null; //Hide Split tab
                                                             // tabSRcontrol.SelectedTab = tabPageSR_Counter;

                    GridPayment.Rows.Clear();
                    lblPaid.Text = "0";
                    txtCustomer.Text = "Cash";

                    txtcashRecived.Text = "";
                    lblChangeAmt.Text = "0";

                    UserInfo.EditTransation = false;
                    UserInfo.Invoice = 0;
                    UserInfo.InvoicetransNO = null;

                }
                else
                {
                    MessageBox.Show("Total Payable and paid Amount not Match");
                    return;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public void Complate_orderAmount()
        {
            try
            {
                decimal Totalpay = Convert.ToDecimal(lblTotalPayment.Text);
                decimal totalPaid = Convert.ToDecimal(lblPaid1.Text);

                if (Totalpay == totalPaid)
                {
                    //Save payment info into sales_payment table

                    decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                    decimal ChangeAmount = Convert.ToDecimal(0);
                    decimal DueAmount = Convert.ToDecimal(0);
                    string Payby = CombPayby.Text.ToString().Trim();
                    string TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");
                    payment_AmountSplit(TotalPayable, ChangeAmount, DueAmount, Payby, TransDate, txtComment.Text, "Success");

                    ///// save sales items one by one 
                    int sales_id = Convert.ToInt32(txtInvoice.Text);
                    bool creditFalg = isCreditInvoice(sales_id);
                    if (creditFalg == false)
                    {
                        sales_item(TransDate, "Paid-send to Kitchen", 0, "PriPaid", txtComment.Text);

                        string OrderWayID = comboSalesMan.Text.Split('-')[0];
                        string name = comboSalesMan.Text.Split('-')[1];
                        if (OrderWayID != "Walk In - Walk In" && OrderWayID != "")
                        {
                            insertCommission();
                        }
                    }

                    string Trno = salesSplit.InvNO;
                    if (Trno != "")
                    {
                        Trno = Trno.Trim();
                        Trno = Trno.TrimStart(',');
                        Trno = Trno.TrimEnd(',');

                        string[] Split = Trno.Split(',');
                        int Length = Split.Length;

                        for (int i = 0; i < Length; i++)
                        {
                            ///// // Open Print Invoice
                            string no = Split[i].ToString().Trim();
                            parameter.autoprintid = "1";
                            //POSPrintRptSplit go = new POSPrintRptSplit(no);
                            //go.ShowDialog();

                            string typr = "Split";
                            PRintInvoice(no, typr);// Default , Short ,Split
                        }
                    }

                    else
                    {
                        ///// // Open Print Invoice
                        parameter.autoprintid = "1";
                        //POSPrintRptSplit go = new POSPrintRptSplit(lblInvoiceNO.Text);
                        //go.ShowDialog();

                        string typr = "Split";
                        PRintInvoice(lblInvoiceNO.Text, typr);// Default , Short ,Split
                    }

                    salesSplit.InvNO = null;

                    //Clean Datagridview and Back to sales cart
                    //dgrvSalesItemList.Rows.Clear();
                    //txtDiscountRate.Text = "0";
                    //DiscountCalculation();
                    //vatcal();
                    //this.tabPageSR_Payment.Parent = null; //Hide payment tab
                    //tabSRcontrol.SelectedTab = tabPageSR_Counter;
                    //GridPayment.Rows.Clear();
                    //lblPaid.Text = "0";
                    //txtCustomer.Text = "Cash";

                    //txtcashRecived.Text = "";
                    //lblChangeAmt.Text = "0";

                    //UserInfo.EditTransation = false;
                    //UserInfo.Invoice = 0;
                    //UserInfo.InvoicetransNO = null;

                }
                else
                {
                    MessageBox.Show("Total Payable and paid Amount not Match");
                    return;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public void CreditInvoice(bool print)
        {
            decimal Totalpay = Convert.ToDecimal(lblTotalpayableAmtPY.Text);
            decimal totalPaid = Convert.ToDecimal(lblPaid.Text);
            decimal GridPaid = getPaymentGridSum();

            if (Totalpay == GridPaid && chkCreditTrans.Checked == true)
            {
                decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                decimal ChangeAmount = Convert.ToDecimal(txtChangeAmount.Text);
                decimal DueAmount = Convert.ToDecimal(txtDueAmount.Text);

                string Invo = lblInvoiceNO.Text;
                string Payby = CombPayby.Text.ToString().Trim();
                string TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");
                payment_item(TotalPayable, ChangeAmount, DueAmount, Payby, TransDate, lblCustID.Text, txtComment.Text, "Success");

                ///// save sales items one by one 
                int sales_id = Convert.ToInt32(txtInvoice.Text);
                bool creditFalg = isCreditInvoice(sales_id);
                if (creditFalg == false)
                {
                    sales_item(TransDate, "Paid-send to Kitchen", 0, "PriPaid", txtComment.Text);

                    string ActivityName = "sales Transaction";
                    string LogData = "Save Sales Transaction CreditInvoice() with InvoiceNO = " + Invo + "and Cust_Code=" + lblCustID.Text + " and OrderTotal =" + TotalPayable + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                    string OrderWayID = comboSalesMan.Text.Split('-')[0];
                    string name = comboSalesMan.Text.Split('-')[1];
                    if (OrderWayID != "Walk In - Walk In" && OrderWayID != "")
                    {
                        insertCommission();
                    }
                }

                ///// // Open Print Invoice
                parameter.autoprintid = "1";
                //POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                //go.ShowDialog();
                if (print == true)
                {
                    string File = getPrintFile("Cash"); // Cash , Creadit , Kitchen
                    string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash"); // Cash , Credit , Kitchen

                    PRintInvoice1(txtInvoice.Text, File, DefaultPrinter);
                }//yogesh
                //string typr = GetStoreprintType();

                //PRintInvoice(txtInvoice.Text, typr);// Default , Short ,Split

                //Clean Datagridview and Back to sales cart
                //dgrvSalesItemList.Rows.Clear();
                //txtDiscountRate.Text = "0";
                //DiscountCalculation();
                //vatcal();
                //this.tabPageSR_Payment.Parent = null; //Hide payment tab
                //tabSRcontrol.SelectedTab = tabPageSR_Counter;
                //this.tabPageSR_Split_Bill.Parent = null; //Hide Split tab
                //tabSRcontrol.SelectedTab = tabPageSR_Counter;

                //GridPayment.Rows.Clear();
                //lblPaid.Text = "0";
                //txtCustomer.Text = "Cash";

                //txtcashRecived.Text = "";
                //lblChangeAmt.Text = "0";

                //UserInfo.EditTransation = false;
                //UserInfo.Invoice = 0;
                //UserInfo.InvoicetransNO = null;
            }
            else
            {
                decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                decimal ChangeAmount = 0;
                decimal DueAmount = 0;

                string Invo = lblInvoiceNO.Text;
                string Payby = CombPayby.Text.ToString().Trim();
                string TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");
                payment_item(TotalPayable, ChangeAmount, DueAmount, Payby, TransDate, lblCustID.Text, txtComment.Text, "Pending");

                ///// save sales items one by one 
                int sales_id = Convert.ToInt32(txtInvoice.Text);
                bool creditFalg = isCreditInvoice(sales_id);
                if (creditFalg == false)
                {
                    sales_item(TransDate, "Credit and partial payment", 0, "Credit", txtComment.Text);

                    string ActivityName = "sales Transaction with Draft";
                    string LogData = "Save Sales Transaction CreditInvoice() with Draft with InvoiceNO = " + Invo + "and Cust_Code=" + lblCustID.Text + " and OrderTotal =" + TotalPayable + "  ";
                    Login.InsertUserLog(ActivityName, LogData);
                }
                if (print == true)//yogesh 110719
                {
                    parameter.autoprintid = "1";

                    string File = getPrintFile("Creadit"); // Cash , Creadit , Kitchen
                    string DefaultPrinter = DataAccess.USERDefaultPrinter("Credit"); // Cash , Credit , Kitchen

                    PRintInvoice1(txtInvoice.Text, File, DefaultPrinter);
                }
                //dgrvSalesItemList.Rows.Clear();
                //txtDiscountRate.Text = "0";
                //DiscountCalculation();
                //vatcal();
                //this.tabPageSR_Payment.Parent = null; //Hide payment tab
                //tabSRcontrol.SelectedTab = tabPageSR_Counter;

                //this.tabPageSR_Split_Bill.Parent = null; //Hide Split tab
                //tabSRcontrol.SelectedTab = tabPageSR_Counter;

                //GridPayment.Rows.Clear();
                //lblPaid.Text = "0";
                //txtCustomer.Text = "Cash";

                //txtcashRecived.Text = "";
                //lblChangeAmt.Text = "0";

                //Last30daysReport(dtStartDate.Text);

                //UserInfo.EditTransation = false;
                //UserInfo.Invoice = 0;
                //UserInfo.InvoicetransNO = null;

            }
        }
        public bool FoundSalesID(string Trno, string TRAN)
        {
            if (Trno != "")
            {
                string[] Split = Trno.Split(',');
                int Length = Split.Length;

                for (int i = 0; i < Length; i++)
                {
                    string tr = Split[i].ToString();
                    if (tr == TRAN)
                    {
                        return true;
                    }
                }

            }

            return false;
        }
        //Back to Sales cart tab
        private void btnback_Click(object sender, EventArgs e)
        {
            if (chkCreditTrans.Checked == false)
            {
                tabSRcontrol.SelectedTab = tabPageSR_Counter;
            }
            else
            {
                clearInvoice();
            }
        }
        //Customer filter
        private void ComboCustID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Name = txtCustomer.Text.Split('-')[0];
                string Mobile = "";
                if (Name != "Cash" && Name != "Gest")
                    Mobile = txtCustomer.Text.Split('-')[1].Trim();
                Name = Name.Trim();
                string sqlCmd = "Select * from  tbl_customer  where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer' and trim(Name)  = '" + Name + "' and trim(Phone)  = '" + Mobile + "'";

                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                if (dt1.Rows.Count > 0)
                    lblCustID.Text = dt1.Rows[0]["ID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region //////////////////   Currency shortcuts value get
        public delegate void functioncall(string currencyvalue);
        public delegate void numvaluefunctioncall(string Numvalue);

        private event functioncall formFunctionPointer;
        private event numvaluefunctioncall numformFunctionPointer;

        private void Replicate(string currencyvalue)
        {
            if (currencyvalue == "XX") // All clear
            {
                txtPaidAmount.Text = "";
            }
            else if (currencyvalue == "BXC") //Backspace
            {
                if ((String.Compare(txtPaidAmount.Text, " ") < 0))
                {
                    txtPaidAmount.Text = txtPaidAmount.Text.Substring(0, txtPaidAmount.Text.Length - 1 + 1);
                }
                else
                {
                    txtPaidAmount.Text = txtPaidAmount.Text.Substring(0, txtPaidAmount.Text.Length - 1);
                }
                txtPaidAmount.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(txtPaidAmount.Text))
                {
                    txtPaidAmount.Text = "0.00";
                    txtPaidAmount.Text = (Convert.ToDouble(txtPaidAmount.Text) + Convert.ToDouble(currencyvalue)).ToString();
                }
                else
                {
                    txtPaidAmount.Text = (Convert.ToDouble(txtPaidAmount.Text) + Convert.ToDouble(currencyvalue)).ToString();
                }
                txtPaidAmount.Focus();
            }

        }
        private void NumaricKeypad(string Numvalue)
        {
            txtPaidAmount.Text += Numvalue;
            txtPaidAmount.Focus();
        }
        #endregion
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["AddNewCustomer"] != null)
            {
                Application.OpenForms["AddNewCustomer"].BringToFront();
                Application.OpenForms["AddNewCustomer"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                UserInfo.addcustomerflag = true;
                Customer.AddNewCustomer go = new Customer.AddNewCustomer();
                go.Show();
            }
        }
        #endregion

        public void getCusto()
        {

            string sqlCust = "";
            string search = "";
            string Mobile = "";
            decimal finalTotal = 0;
            if (txtCustomer.Text != "")
            {
                try
                {
                    search = txtCustomer.Text.Split('-')[0].Trim();
                    if (search != "Cash")
                        Mobile = txtCustomer.Text.Split('-')[1].Trim();

                    sqlCust = "select  *  from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer' and Phone = '" + Mobile + "'  and (Name like '%" + search + "%'  or EmailAddress like '%" + search + "%')";
                }
                catch
                {
                    search = txtCustomer.Text.Split('-')[0].Trim();
                    sqlCust = "select  *  from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer' and (Name like '%" + search + "%'  or Phone like '%" + search + "%'  or EmailAddress like '%" + search + "%')";
                }

                DataTable dtCust = DataAccess.GetDataTable(sqlCust);

                if (dtCust.Rows.Count > 0)
                {
                    string Val = dtCust.Rows[0]["Name"] + " - " + dtCust.Rows[0]["Phone"] + " - " + dtCust.Rows[0]["EmailAddress"].ToString();
                    txtCustomer.Text = Val;

                    lblCustID.Text = dtCust.Rows[0]["ID"].ToString();
                    //ComboCustID.Text = Val;
                    decimal CustCreditAmt = payablecredit.GetCustCredit(lblCustID.Text);
                    decimal CustAdvanceAmt = Cusromer_AdvancePay.GetCustAdvance(lblCustID.Text);
                    decimal Deduct = Cusromer_AdvancePay.GetCustSaleDeduct(lblCustID.Text);
                    finalTotal = CustAdvanceAmt - Deduct;
                    lblCustCredit.Text = CustCreditAmt.ToString("N3");
                    if (finalTotal <= 0)
                    {
                        labelCustomerName.BackColor = Color.FromKnownColor(KnownColor.Transparent);
                        //lblmainCustwalletant.Visible = false;
                        lblmainCustwalletant.Text = finalTotal.ToString("N2");

                        btnCashAndPrint.Text = "Cash / Print";
                        lblIsCustAdvanceAmtYN.Text = "-";
                        btnBooking.BackColor = Color.FromKnownColor(KnownColor.Orange);
                        btnBooking.Enabled = true;
                        btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.SeaGreen);
                        btnSalesCredit.Enabled = true;
                        btnCOD.BackColor = Color.FromKnownColor(KnownColor.PaleGreen);
                        btnCOD.Enabled = true;
                        radiocredit.Enabled = true;


                    }
                    else
                    {
                        labelCustomerName.BackColor = Color.FromKnownColor(KnownColor.LimeGreen);
                        lblmainCustwalletant.Visible = true;
                        lblmainCustwalletant.Text = finalTotal.ToString("N2");
                        DialogResult result = MessageBox.Show("Are Yor Sure? Your Sale order is Continue with Advance Amount. ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            btnCashAndPrint.Text = "Prepaid/Print";
                            lblIsCustAdvanceAmtYN.Text = ".";
                            btnBooking.BackColor = Color.FromKnownColor(KnownColor.Control);
                            btnBooking.Enabled = false;
                            btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                            btnSalesCredit.Enabled = false;
                            btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                            btnCOD.Enabled = false;
                            radiocredit.Enabled = false;
                        }
                        else
                        {
                            btnCashAndPrint.Text = "Cash / Print";
                            lblIsCustAdvanceAmtYN.Text = "-";
                            btnBooking.BackColor = Color.FromKnownColor(KnownColor.Orange);
                            btnBooking.Enabled = true;
                            btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.SeaGreen);
                            btnSalesCredit.Enabled = true;
                            btnCOD.BackColor = Color.FromKnownColor(KnownColor.PaleGreen);
                            btnCOD.Enabled = true;
                            radiocredit.Enabled = true;
                        }
                    }

                }
                else
                {
                    //ComboCustID.Text = txtCustomer.Text;
                }
            }

        }
        public void customerLostFocus()
        {
            try
            {
                getCusto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AutoComplete();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public decimal getPaymentGridSum()
        {
            decimal sum = 0;
            for (int i = 0; i < GridPayment.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(GridPayment.Rows[i].Cells[3].Value);
            }
            return sum;
        }
        private void CombPayby_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void GridPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Delete items From Gridview
            if (e.ColumnIndex == GridPayment.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row2 in GridPayment.SelectedRows)
                {
                    if (!row2.IsNewRow)
                        GridPayment.Rows.Remove(row2);

                }

                decimal Totalpay = Convert.ToDecimal(lblTotalpayableAmtPY.Text);

                decimal sum = 0;
                for (int i = 0; i < GridPayment.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(GridPayment.Rows[i].Cells[3].Value);
                }

                lblPaid.Text = sum.ToString();
                txtPaidAmount.Text = (Totalpay - sum).ToString();
            }
            compairePaymentAmt();
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(DisplayCategoryClick);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }

            CategoryList();
            Category_with_images();

            if (UserInfo.Language == "English")
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                switch_language();
            }
            else if (UserInfo.Language == "Arabic")
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("Ar");
                switch_language();
            }
            else
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                switch_language();
            }
        }
        private void comboSalesMan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSalesMan.Text != "")
            {
                string OrderWayID = comboSalesMan.Text.Split('-')[0].Trim();
                string name = comboSalesMan.Text.Split('-')[1].Trim();

                string sqlCmd = "Select * from tbl_orderWay_Maintenance where TenentID = " + Tenent.TenentID + " and OrderWayID='" + OrderWayID + "' and Name1='" + name + "' and DeliveryCharges is not null "; //From view combination of tbl_customer and custcredit

                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                if (dt1.Rows.Count > 0)
                {
                    lblDeliveryChargis.Text = dt1.Rows[0]["DeliveryCharges"].ToString() != "" ? dt1.Rows[0]["DeliveryCharges"].ToString() : "0";
                    DiscountCalculation();
                    vatcal();
                }
                else
                {
                    lblDeliveryChargis.Text = "0";
                    DiscountCalculation();
                    vatcal();
                }

            }
        }
        private void lbloveralldiscount_Leave(object sender, EventArgs e)
        {
            lbloveralldiscount.Text = lbloveralldiscount.Text == "" ? "0" : lbloveralldiscount.Text;
            SetDiscPercentage();
        }

        public void SetDiscPercentage()
        {
            if (lbloveralldiscount.Text != "" && lbloveralldiscount.Text != ".")
            {
                decimal OverallDis = Convert.ToDecimal(lbloveralldiscount.Text);
                decimal Total = lblTotal.Text != "" ? Convert.ToDecimal(lblTotal.Text) : 0;
                if (Total != 0)
                {
                    decimal PER = (OverallDis * 100) / Total;
                    PER = Math.Round(PER, 4);
                    txtDiscountRate.Text = PER.ToString();
                }
                else
                {
                    txtDiscountRate.Text = "0";
                }

            }
            txtcashRecived.Focus();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CustomerSearch"] != null)
            {
                Application.OpenForms["CustomerSearch"].Close();
            }
            this.Refresh();

            CustomerSearch go = new CustomerSearch();
            go.Show();
        }
        private void btnCashAndPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(CashandPrint);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }

        }

        public void CashandPrint()
        {
            // SetLoadingForItem(true);

            // Added to see the indicator (not required)
            // Thread.Sleep();
            //getInvoiceno();
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //OpenCashDrawer1();yogesh changes 010619
                    //OpenCashDrawer();

                    if (radiocredit.Checked == true)
                    {
                        CreditInvoice(true);
                        clearInvoice();
                        manageInvoice();
                    }
                    else
                    {
                        SaveandPrint(true);
                    }
                   // timerinvoiceno();

                });
            }
            catch
            {

            }

           // SetLoadingForItem(false);
        }

        public void OpenCashDrawer1()
        {
            //try
            //{
            //    string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash");
            //    CashdrawerClass.OpenCashDrawer1(DefaultPrinter);
            //}
            //catch
            //{

            //}
        }
        public void OpenCashDrawer()
        {
            try
            {
                if (myCashDrawer != null)
                {
                    myCashDrawer.Open();
                    myCashDrawer.Claim(1000);
                    myCashDrawer.DeviceEnabled = true;
                    myCashDrawer.OpenDrawer();
                    myCashDrawer.DeviceEnabled = false;
                    myCashDrawer.Release();
                    myCashDrawer.Close();
                }
            }
            catch
            {

            }
        }
        private void txtcashRecived_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtcashRecived.Text.ToString(), @"\.\d\d\d");

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
                if (txtcashRecived.Text != "" && txtcashRecived.Text != ".")
                {
                    decimal textAMT = Convert.ToDecimal(txtcashRecived.Text);
                    decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                
                    //if (TotalPayable > textAMT)
                    //{
                    decimal change = TotalPayable - textAMT;
                    lblChangeAmt.Text = change.ToString();
                    //}
                    //else if (textAMT > TotalPayable)
                    //{
                    //    decimal change = textAMT - TotalPayable;
                    //    lblChangeAmt.Text = change.ToString();
                    //}
                    //else
                    //{
                    //    lblChangeAmt.Text = "0";
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtcashRecived_TextChanged(object sender, EventArgs e)
        {
           // if (txtcashRecived.Text != "" && txtcashRecived.Text != ".")
           // {
           //     decimal textAMT = Convert.ToDecimal(txtcashRecived.Text);
           //     decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
           //
           //     //if (TotalPayable > textAMT)
           //     //{
           //     decimal change = TotalPayable - textAMT;
           //     lblChangeAmt.Text = change.ToString();
           //     //}
           //     //else if (textAMT > TotalPayable)
           //     //{
           //     //    decimal change = textAMT - TotalPayable;
           //     //    lblChangeAmt.Text = change.ToString();
           //     //}
           //     //else
           //     //{
           //     //    lblChangeAmt.Text = "0";
           //     //}
           // }
        }
        private void btnDraft_Click(object sender, EventArgs e)
        {
            //DraftInvoice();

            try
            {
                Thread threadInput = new Thread(DraftInvoice);
                threadInput.Start();
              
            }
            catch (Exception ex)
            {
            }
        }
        private void lblDraft_TextChanged(object sender, EventArgs e)
        {
            if (lblDraft.Text == ".")
            {
                DraftInvoice();
                lblDraft.Text = "-";
            }
        }
        public void DraftInvoice()
        {
          //  SetLoadingForItem(true);

            // Added to see the indicator (not required)
            //Thread.Sleep(1);

            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (lblTotalPayable.Text == "00" || lblTotalPayable.Text == "0" || lblTotalPayable.Text == string.Empty)
                    {
                        MessageBox.Show("Sorry ! You don't have enough product in Item cart \n  Please Add to cart", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        return;
                    }

                    if (comboSalesMan.Text == "")
                    {
                        MessageBox.Show("Sorry ! Please Select oeder Way:", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        return;
                    }
                    else
                    {
                        getInvoiceno();

                        decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                        decimal Payamount = Convert.ToDecimal(txtcashRecived.Text);
                        decimal ChangeAmount = 0;
                        decimal dueAmount = 0;


                        if (TotalPayable > Payamount)
                        {
                            decimal due = TotalPayable - Payamount;
                            dueAmount = due;
                        }
                        else if (Payamount > TotalPayable)
                        {
                            decimal change = Payamount - TotalPayable;
                            ChangeAmount = change;
                        }
                        else
                        {
                            dueAmount = 0;
                            ChangeAmount = 0;

                        }

                        //payment_item(Payamount, ChangeAmount, dueAmount, "Cash", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), "10000009", "Gest");

                        ///// save sales items one by one  

                        string Invo = lblInvoiceNO.Text;

                        string TransDate = "";

                        TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");

                        int sales_id = Convert.ToInt32(txtInvoice.Text);
                        bool creditFalg = isCreditInvoice(sales_id);
                        if (creditFalg == false)
                        {
                            sales_item(TransDate, "Not Paid Order Taken", 0, "Draft", txtComment.Text);

                            string ActivityName = "sales Draft Transaction";
                            string LogData = "Save Sales Transaction DraftInvoice() as Draft with InvoiceNO = " + Invo + " ";
                            Login.InsertUserLog(ActivityName, LogData);
                        }
                        clearInvoice();
                        manageInvoice();
                        //dgrvSalesItemList.Rows.Clear();
                        //txtDiscountRate.Text = "0";
                        //DiscountCalculation();
                        //vatcal();
                        ////Last30daysReport(dtStartDate.Text);
                        //this.tabPageSR_Payment.Parent = null; //Hide payment tab 

                        //this.tabPageSR_Split_Bill.Parent = null; //Hide Split tab
                        //tabSRcontrol.SelectedTab = tabPageSR_Counter;

                        //txtCustomer.Text = "Cash";
                        //GridPayment.Rows.Clear();
                        //lblPaid.Text = "0";
                        //txtcashRecived.Text = "";
                        //lblChangeAmt.Text = "0";

                        //dtSalesDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        //dtsaleDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                        //UserInfo.EditTransation = false;
                        //UserInfo.Invoice = 0;
                        //UserInfo.InvoicetransNO = null;

                        //    scope.Complete();
                        //}
                       // timerinvoiceno();
                    }


                });

            }
            catch
            {

            }

           // SetLoadingForItem(false);
        }
        public void ShowCashierAction(string InvoiceNO, int CursorY)
        {
           // string salesID = GetSalesID(InvoiceNO);
           // string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and sales_id=" + salesID + " ";
           //
           // DataTable dt1 = DataAccess.GetDataTable(sql3);

            int cal = Cursor.Position.X;
            int CursorX = cal - 350;

           // if (dt1.Rows.Count > 0)
           // {
                if (Application.OpenForms["CashierAction"] != null)
                {
                    Application.OpenForms["CashierAction"].Close();
                }

                CashierAction mkc1 = new CashierAction(CursorX, CursorY);
                mkc1.OrderNO = InvoiceNO;
                mkc1.Show();

           // }
        }
        private void datagrdReportDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == datagrdReportDetails.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];

                    string id = row.Cells["Receipt"].Value.ToString();
                    int CursorY = Cursor.Position.Y;
                    if (e.RowIndex >= 6)
                    {
                        CursorY = 476;
                    }

                    ShowCashierAction(id, CursorY);

                }
                else
                {
                    DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];
                    string id = row.Cells["Receipt"].Value.ToString();

                    string salesID = GetSalesID(id);
                    string Stutas = row.Cells["Status"].Value.ToString();
                    string PaymentMode = GetPaymentMode(id).Trim();

                    if (Stutas == "Paid-send to Kitchen" || Stutas == "COD-send to Kitchen")
                    {
                        if (Application.OpenForms["Kitchen_display"] != null)
                        {
                            Application.OpenForms["Kitchen_display"].Close();
                        }
                        this.Refresh();
                        Kitchen_display go = new Kitchen_display();
                        go.invoiceNO = id;
                        go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                        go.Show();
                    }
                    if (Stutas == "Not Paid Order Taken")
                    {
                        string InvoicetransNO = id;
                        EditOrder(InvoicetransNO);
                    }
                    if (Stutas == "Not Paid Booking Order Taken")
                    {
                        string InvoicetransNO = id;
                        EditOrder(InvoicetransNO);
                    }
                    if (PaymentMode == "Credit")
                    {
                        bool PaymentStatus = GetPaymentstatus(id);
                        if (PaymentStatus == false)
                        {
                            string InvoicetransNO = id;
                            EditOrder(InvoicetransNO);
                        }
                    }
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }
        public void EditOrder(string InvoicetransNO)
        {
            lblInvoiceStatus.Text = "Edit";//yogesh 270619
            lblInvoiceStatus.ForeColor = Color.FromKnownColor(KnownColor.Red);
            dgrvSalesItemList.Rows.Clear();
            txtDiscountRate.Text = "0";
            string salesID = GetSalesID(InvoicetransNO);
            int sales_ID = Convert.ToInt32(salesID);

            txtInvoice.Text = salesID;
            txtInvoice.Refresh();
            txtInvoicePAY.Text = salesID;
            txtInvoicePAY.Refresh();


            lblInvoiceNO.Text = InvoicetransNO;
            lblInvoiceNO.Refresh();

            lblInvoiceNOPAY.Text = InvoicetransNO;
            lblInvoiceNOPAY.Refresh();

            string sql3 = "select paymentmode from sales_item where TenentID=" + Tenent.TenentID + " and sales_id=" + sales_ID + " and (paymentmode =='Draft' or paymentmode =='Credit' or paymentmode =='Booking' ) ";

            DataTable dt3 = DataAccess.GetDataTable(sql3);
            if (dt3.Rows.Count > 0)
            {
                UserInfo.EditTransation = true;
                UserInfo.Invoice = sales_ID;
                UserInfo.InvoicetransNO = InvoicetransNO;

                Check_OpeningBalance();

                BindDainingTable();
                bindOrderWay();

                getEditInvoice(sales_ID);

                SetDiscPercentage();

                btnSuspend.Enabled = true;
                btnCashAndPrint.Enabled = true;
                if (lblIsCustAdvanceAmtYN.Text == ".")//change yogesh 030619
                    btnSalesCredit.Enabled = false;
                else
                    btnSalesCredit.Enabled = true;

                string paymentmode = dt3.Rows[0]["paymentmode"].ToString();
                if (paymentmode == "Credit")
                {
                    this.tabPageSR_Payment.Parent = this.tabSRcontrol; //show
                    tabSRcontrol.SelectedTab = tabPageSR_Payment;
                }
                else
                {
                    if (chkImage.Checked == true)
                    {
                        // this.ItemsImage.Parent = this.tabControl1;
                        // tabControl1.SelectedTab = ItemsImage;
                        //btnImages_Click(null, null);
                    }
                    else if (chkbutton.Checked == true)
                    {
                        // this.ItemButton.Parent = this.tabControl1;
                        //tabControl1.SelectedTab = ItemButton;
                        // btnItemButton_Click(null, null);
                    }
                    else
                    {
                        // this.ItemGrid.Parent = this.tabControl1;
                        // tabControl1.SelectedTab = ItemGrid;
                        // btnItemGrid_Click(null, null);
                    }



                }
            }
            manageInvoice();
        
    }
        public string getCustWithMobile(int c_id)
        {
            string sqlCmd = "Select * from  tbl_customer  where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer' and trim(ID)  = '" + c_id + "' ";

            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            if (dt1.Rows.Count > 0)
                return dt1.Rows[0]["Name"].ToString().Trim() + "-" + dt1.Rows[0]["Phone"].ToString().Trim();
            else
                return "Gest";
        }
        public void getEditInvoice(int sales_id)
        {
            dgrvSalesItemList.Rows.Clear();
            txtDiscountRate.Text = "0";
            string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and sales_id=" + sales_id + " ";

            DataTable dt3 = DataAccess.GetDataTable(sql3);
            if (dt3.Rows.Count > 0)
            {
                string saletime = dt3.Rows[0]["sales_time"].ToString();
                string saleDeliverytime = dt3.Rows[0]["DeliveryDate"].ToString();
                dtSalesDate.Text = saletime;
                dtsaleDate.Text = saletime;
                dtsaleDeliveryDate.Text = saleDeliverytime;
                comboSalesMan.Text = dt3.Rows[0]["OrderWay"].ToString();
                int rows = dt3.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    if (i == 0)
                    {
                        int c_id = Convert.ToInt32(dt3.Rows[i]["c_id"].ToString().Trim());
                        //sales_id ,item_id,itemName,Qty,RetailsPrice,Total,profit,sales_time,itemcode,discount,taxapply,status,UOM,Customer,OnlineTransID, InvoiceNO,TenentID,product_name_print,ExpiryDate,OrderStutas, SoldBy
                        lblCustID.Text = c_id.ToString();
                        txtCustomer.Text = getCustWithMobile(c_id);
                        customerLostFocus();
                    }
                    string CustItemCode = dt3.Rows[i]["CustItemCode"].ToString();
                    int UOMID = Convert.ToInt32(dt3.Rows[i]["UOM"]);
                    string UOMname = Add_Item.getuomName(UOMID);
                    string ItemsName = CustItemCode + "-" + dt3.Rows[i]["itemName"].ToString() + "~" + UOMname;
                    double Rprice = Convert.ToDouble(dt3.Rows[i]["RetailsPrice"].ToString());
                    double Qty = Convert.ToDouble(dt3.Rows[i]["Qty"].ToString());
                    double Total = Convert.ToDouble(dt3.Rows[i]["Total"].ToString());// Yogesh * Qty;
                    string Itemid = dt3.Rows[i]["itemcode"].ToString();
                    double Disamt = Convert.ToDouble(dt3.Rows[i]["discount"].ToString());       //  Total Discount amount of this item
                    double Taxamt = 0;// Convert.ToDouble(dt3.Rows[i][5].ToString());       //  Total Tax amount  of this item
                    double Dis = 0;// Convert.ToDouble(dt3.Rows[i][7].ToString());       //  Discount Rate
                    double Taxapply = Convert.ToDouble(dt3.Rows[i]["taxapply"].ToString());       //  VAT/TAX/TPS/TVQ apply or not
                    int kitchendisplay = Convert.ToInt32(dt3.Rows[i]["status"].ToString());
                    string BatchNo = dt3.Rows[i]["BatchNo"].ToString();//BatchNo=Serialize

                    dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Total, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode, BatchNo);
                    //if (BatchNo == "" || BatchNo == "0")
                    //{

                    //    dt3.Rows[i]["inc"] = "+";
                    //    dt3.Rows[i]["minus"] = "-";
                    //    dt3.Rows[i]["Edit"] = ""; 
                    //}
                    //else
                    //{
                    //    dt3.Rows[i]["inc"] = "";
                    //    dt3.Rows[i]["minus"] = "";
                    //    dt3.Rows[i]["Edit"] = "Edit";
                    //}
                }
                DiscountCalculation();
                vatcal();

                int ISPaymentCredit = Convert.ToInt32(dt3.Rows[0]["ISPaymentCredit"]);
                if (ISPaymentCredit == 1)
                {
                    chkCreditTrans.Checked = true;
                }
            }

            string sql = "select * from sales_payment where TenentID = " + Tenent.TenentID + " and Sales_id = '" + sales_id + "' ";

            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                int rows = dt.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    string payment_type = dt.Rows[i]["payment_type"].ToString();
                    string Reffrance_NO = dt.Rows[i]["Reffrance"].ToString();
                    string payment_amount = dt.Rows[i]["payment_amount"].ToString();

                    GridPayment.Rows.Add(sales_id, payment_type, Reffrance_NO, payment_amount);
                }

                this.tabPageSR_Payment.Parent = this.tabSRcontrol; //show
                tabSRcontrol.SelectedTab = tabPageSR_Payment;

                decimal sum = 0;
                for (int i = 0; i < GridPayment.Rows.Count; ++i)
                {
                    sum += Convert.ToDecimal(GridPayment.Rows[i].Cells[3].Value);
                }

                decimal Totalpay = Convert.ToDecimal(lblTotalpayableAmtPY.Text);

                lblPaid.Text = sum.ToString();
                txtPaidAmount.Text = (Totalpay - sum).ToString();
                txtReffrance.Text = "";
            }

        }
        public static string GetSalesID(string InvoiceNO)
        {
            string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and InvoiceNO='" + InvoiceNO + "' ";

            DataTable dt3 = DataAccess.GetDataTable(sql3);
            string Salesid = "";
            if (dt3.Rows.Count > 0)
            {
                Salesid = dt3.Rows[0]["sales_id"].ToString();
            }
            return Salesid;
        }
        public static string GetPaymentMode(string InvoiceNO)
        {
            string sql3 = "select PaymentMode from sales_item where TenentID=" + Tenent.TenentID + " and InvoiceNO='" + InvoiceNO + "' ";

            DataTable dt3 = DataAccess.GetDataTable(sql3);
            string PaymentMode = "";
            if (dt3.Rows.Count > 0)
            {
                PaymentMode = dt3.Rows[0]["PaymentMode"].ToString();
            }
            return PaymentMode;
        }
        public static bool GetPaymentstatus(string InvoiceNO)
        {
            string sql3 = "select * from sales_payment where TenentID = " + Tenent.TenentID + " and InvoiceNO = '" + InvoiceNO + "' and PaymentStutas = 'Success' ";

            DataTable dt3 = DataAccess.GetDataTable(sql3);
            if (dt3.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            //Last30daysReport(dtStartDate.Text);
        }
        public void Last30daysReport(string startDate)
        {
            try
            {
                txtInvoiceCash.Text = "";
                //sql query from front end can cause slow speed , the query is too much completed because taking data from multiple table . 
                string sql = "";
                if (chkdiscredit.Checked == true)
                {
                    sql = " select  tbl_customer.ID as 'C_Code' ,  CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' , sales_item.InvoiceNO as 'Receipt' ,  " +
                          "  OrderStutas as Status, printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total' , sales_item.sales_id as id, " +
                          " case WHEN sales_item.PaymentMode = 'COD' THEN 'COD' WHEN sales_item.PaymentMode = 'PriPaid' THEN 'Pre Paid' " +
                          " WHEN sales_item.PaymentMode = 'Credit' THEN 'Credit' WHEN sales_item.PaymentMode = 'Draft' THEN 'Draft' WHEN sales_item.PaymentMode = 'Booking' THEN 'Booking' END 'Payment Mode'  " +
                          " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                          " where sales_item.TenentID=" + Tenent.TenentID + " and sales_item.PaymentMode = 'Credit'  and sales_item.sales_time Like '%" + startDate + "%' and sales_item.Deleted <> 1  group by sales_item.sales_id order by sales_item.sales_time";
                }
                else
                {
                    sql = " select  tbl_customer.ID as 'C_Code' ,  CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' , sales_item.InvoiceNO as 'Receipt' ,  " +
                          "  OrderStutas as Status,  printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total'  , sales_item.sales_id as id, " +
                          " case WHEN sales_item.PaymentMode = 'COD' THEN 'COD' WHEN sales_item.PaymentMode = 'PriPaid' THEN 'Pre Paid' " +
                          " WHEN sales_item.PaymentMode = 'Credit' THEN 'Credit' WHEN sales_item.PaymentMode = 'Draft' THEN 'Draft' WHEN sales_item.PaymentMode = 'Booking' THEN 'Booking' WHEN sales_item.PaymentMode = 'Advance' THEN 'Advance' END 'Payment Mode'  " +
                          " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                          " where sales_item.TenentID=" + Tenent.TenentID + " and sales_item.sales_time Like '%" + startDate + "%' and sales_item.Deleted <> 1  group by sales_item.sales_id order by sales_item.sales_time";
                }

                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagrdReportDetails.DataSource = dt1;
                datagrdReportDetails.Columns["id"].Visible = false;
                //datagrdReportDetails.Columns["PaymentMode"].Visible = false;
                datagrdReportDetails.Columns["C_Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns["Receipt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns["Payment Mode"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                datagrdReportDetails.Columns["Action"].DisplayIndex = 7;

            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }
        public void CashirTestSearch()
        {
            try
            {
                if (txtInvoiceCash.Text != null && txtInvoiceCash.Text != "")
                {
                    string sql = "";
                    if (chkdiscredit.Checked == true)
                    {
                        sql = " select  tbl_customer.ID as 'C_Code' ,  CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' , sales_item.InvoiceNO as 'Receipt' ,  " +
                              "  OrderStutas as Status, printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total'  , sales_item.sales_id as id, " +
                              " case WHEN sales_item.PaymentMode = 'COD' THEN 'COD' WHEN sales_item.PaymentMode = 'PriPaid' THEN 'Pre Paid' " +
                              " WHEN sales_item.PaymentMode = 'Credit' THEN 'Credit' WHEN sales_item.PaymentMode = 'Draft' THEN 'Draft' WHEN sales_item.PaymentMode = 'Booking' THEN 'Booking' END 'Payment Mode'  " +
                              " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                              " where sales_item.TenentID=" + Tenent.TenentID + " and sales_item.PaymentMode = 'Credit' and sales_item.Deleted <> 1 and ( sales_item.InvoiceNO  Like  '%" + txtInvoiceCash.Text + "%' or sales_item.customer Like '%" + txtInvoiceCash.Text + "%'  ) " +
                              " group by sales_item.sales_id order by sales_item.sales_time";
                    }
                    else
                    {
                        sql = " select  tbl_customer.ID as 'C_Code' ,  CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' , sales_item.InvoiceNO as 'Receipt' ,  " +
                              " OrderStutas as Status, printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total'  , sales_item.sales_id as id, " +
                              " case WHEN sales_item.PaymentMode = 'COD' THEN 'COD' WHEN sales_item.PaymentMode = 'PriPaid' THEN 'Pre Paid' " +
                              " WHEN sales_item.PaymentMode = 'Credit' THEN 'Credit' WHEN sales_item.PaymentMode = 'Draft' THEN 'Draft' WHEN sales_item.PaymentMode = 'Booking' THEN 'Booking' END 'Payment Mode'  " +
                              " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                              " where sales_item.TenentID=" + Tenent.TenentID + " and sales_item.Deleted <> 1 and ( sales_item.InvoiceNO  Like  '%" + txtInvoiceCash.Text + "%' or sales_item.customer Like '%" + txtInvoiceCash.Text + "%'  ) " +
                              " group by sales_item.sales_id order by sales_item.sales_time";
                    }

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns["id"].Visible = false;
                    //datagrdReportDetails.Columns["PaymentMode"].Visible = false;
                    datagrdReportDetails.Columns["C_Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Receipt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    datagrdReportDetails.Columns["Payment Mode"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    datagrdReportDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Action"].DisplayIndex = 7;
                }
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }
        public void CustCodeSearch()
        {
            try
            {
                if (txtSearchCustCode.Text != null && txtSearchCustCode.Text != "")
                {
                    string sql = "";
                    if (chkdiscredit.Checked == true)
                    {
                        sql = " select  tbl_customer.ID as 'C_Code' ,  CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' , sales_item.InvoiceNO as 'Receipt' ,  " +
                              "  OrderStutas as Status, printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total'  , sales_item.sales_id as id, " +
                              " case WHEN sales_item.PaymentMode = 'COD' THEN 'COD' WHEN sales_item.PaymentMode = 'PriPaid' THEN 'Pre Paid' " +
                              " WHEN sales_item.PaymentMode = 'Credit' THEN 'Credit' WHEN sales_item.PaymentMode = 'Draft' THEN 'Draft' WHEN sales_item.PaymentMode = 'Booking' THEN 'Booking' END 'Payment Mode'  " +
                              " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                              " where sales_item.TenentID=" + Tenent.TenentID + " and sales_item.PaymentMode = 'Credit' and  sales_item.Deleted <> 1 and ( sales_item.c_id = '" + txtSearchCustCode.Text + "'  ) " +
                              " group by sales_item.sales_id order by sales_item.sales_time";
                    }
                    else
                    {
                        sql = " select  tbl_customer.ID as 'C_Code' ,  CASE  WHEN sales_item.c_id = 1 THEN sales_item.customer WHEN sales_item.c_id != 1 THEN ( tbl_customer.Name ||' - '|| tbl_customer.NameArabic ) end 'Customer' , sales_item.InvoiceNO as 'Receipt' ,  " +
                              "  OrderStutas as Status, printf('%.3f',(SUM(total) - (case when  Sum(discount) is not null then  Sum(discount) when Sum(discount) is null then 0 End ))) as 'Total'  , sales_item.sales_id as id, " +
                              " case WHEN sales_item.PaymentMode = 'COD' THEN 'COD' WHEN sales_item.PaymentMode = 'PriPaid' THEN 'Pre Paid' " +
                              " WHEN sales_item.PaymentMode = 'Credit' THEN 'Credit' WHEN sales_item.PaymentMode = 'Draft' THEN 'Draft' WHEN sales_item.PaymentMode = 'Booking' THEN 'Booking' END 'Payment Mode'  " +
                              " from sales_item  left JOIN tbl_customer on sales_item.c_id = tbl_customer.id and  sales_item.TenentID = tbl_customer.TenentID " +
                              " where sales_item.TenentID=" + Tenent.TenentID + "  and sales_item.Deleted <> 1 and ( sales_item.c_id = '" + txtSearchCustCode.Text + "'  ) " +
                              " group by sales_item.sales_id order by sales_item.sales_time";
                    }

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;
                    datagrdReportDetails.Columns["id"].Visible = false;
                    //datagrdReportDetails.Columns["PaymentMode"].Visible = false;
                    datagrdReportDetails.Columns["C_Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Receipt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //datagrdReportDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    datagrdReportDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //datagrdReportDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    datagrdReportDetails.Columns["Payment Mode"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    datagrdReportDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    datagrdReportDetails.Columns["Action"].DisplayIndex = 7;
                }
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }
        private void txtInvoiceCash_Leave(object sender, EventArgs e)
        {
            CashirTestSearch();
        }
        private void btnCOD_Click(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(CashonDeliveryforload);
                threadInput.Start();
              
            }
            catch (Exception ex)
            {
            }
        }
        public void CashonDeliveryforload()
        {
           // SetLoadingForItem(true);

            // Added to see the indicator (not required)
            //Thread.Sleep(1);

            try
            {
                this.Invoke((MethodInvoker)delegate
                {

                    if (lblCustID.Text == "1")
                    {
                        MyMessageAlert.ShowBox("Please Select Customer Rather than Cash Or Gest .", "Alert");
                        chkCreditTrans.Checked = false;
                        radiocredit.Checked = false;
                        radioCash.Checked = true;
                        return;
                    }

                    if (radiocredit.Checked == true)
                    {
                        CreditInvoice(true);
                        clearInvoice();
                        manageInvoice();
                    }
                    else
                    {
                        CashOnDelivery();
                    }
                    manageInvoice();
                   // timerinvoiceno();
                });

            }
            catch
            {

            }

          //  SetLoadingForItem(false);
        }
        private void btnSerchCashier_Click(object sender, EventArgs e)
        {
            CashirTestSearch();
            SeearchNo = 2;
        }
        public void CashOnDelivery()
        {
            if (lblTotalPayable.Text == "00" || lblTotalPayable.Text == "0" || lblTotalPayable.Text == string.Empty)
            {
                MessageBox.Show("Sorry ! You don't have enough product in Item cart \n  Please Add to cart", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }

            if (comboSalesMan.Text == "")
            {
                MessageBox.Show("Sorry ! Please Select oeder Way:", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }
            else
            {
                getInvoiceno();

                decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                decimal Payamount = Convert.ToDecimal(txtcashRecived.Text);
                decimal ChangeAmount = 0;
                decimal dueAmount = 0;


                if (TotalPayable > Payamount)
                {
                    decimal due = TotalPayable - Payamount;
                    dueAmount = due;
                }
                else if (Payamount > TotalPayable)
                {
                    decimal change = Payamount - TotalPayable;
                    ChangeAmount = change;
                }
                else
                {
                    dueAmount = 0;
                    ChangeAmount = 0;

                }

                string Invo = lblInvoiceNO.Text;

                payment_item(Payamount, ChangeAmount, dueAmount, "Cash", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), "1", "Gest", "Pending");

                ///// save sales items one by one  
                int sales_id = Convert.ToInt32(txtInvoice.Text);
                bool creditFalg = isCreditInvoice(sales_id);
                if (creditFalg == false)
                {
                    string TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");
                    sales_item(TransDate, "COD-send to Kitchen", 1, "COD", txtComment.Text);

                    string ActivityName = "sales COD Transaction";
                    string LogData = "Save Sales Transaction CashOnDelivery() as Cash On Delivery with InvoiceNO = " + Invo + "and Cust_Code=" + lblCustID.Text + " and OrderTotal =" + TotalPayable + " ";
                    Login.InsertUserLog(ActivityName, LogData);
                }

                string OrderWayID = comboSalesMan.Text.Split('-')[0];
                string name = comboSalesMan.Text.Split('-')[1];
                if (OrderWayID != "Walk In - Walk In" && OrderWayID != "")
                {
                    insertCommission();
                }
                parameter.autoprintid = "1";
                //POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                //go.ShowDialog();

                string File = getPrintFile("Cash"); // Cash , Creadit , Kitchen//yogesh
                string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash"); // Cash , Credit , Kitchen//yogesh
                PRintInvoice1(txtInvoice.Text, File, DefaultPrinter);//yogesh
                clearInvoice();
                manageInvoice();
                //dgrvSalesItemList.Rows.Clear();
                //txtDiscountRate.Text = "0";
                //DiscountCalculation();
                //vatcal();
                ////Last30daysReport(dtStartDate.Text);
                //this.tabPageSR_Payment.Parent = null; //Hide payment tab   

                //this.tabPageSR_Split_Bill.Parent = null; //Hide Split tab
                //tabSRcontrol.SelectedTab = tabPageSR_Counter;

                //txtCustomer.Text = "Cash";
                //GridPayment.Rows.Clear();
                //lblPaid.Text = "0";
                //txtcashRecived.Text = "";
                //lblChangeAmt.Text = "0";

                //UserInfo.EditTransation = false;
                //UserInfo.Invoice = 0;
                //UserInfo.InvoicetransNO = null;

                //    scope.Complete();
                //}
            }
        }
        private void btnCashierRefresh_Click(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text);
            txtInvoiceCash.Text = "";
            SeearchNo = 0;
            searchDate = dtStartDate.Text;
        }
        public void Daywice(DateTime startDate)
        {
            string start_Date = startDate.ToString("yyyy-MM-dd");

            dtGrdvOrderDetails.Refresh();
            string sql = " SELECT  si.InvoiceNO as 'Receipt' ,  si.orderTotal as 'Order Amount' ,   si.sales_time as 'Date', " +
                         " CASE     WHEN si.driver = '0' THEN ''   WHEN si.driver != '0' THEN si.driver    END 'driver' ," +
                         " CASE     WHEN si.COD = 0 THEN 'Paid'   WHEN si.COD = '1' THEN 'COD'    END 'COD' ," +
                         " CASE " +
                         " WHEN si.OrderStutas = 'Advance Paid-Ready to Delivery' THEN 'Pending' " +
                         " WHEN si.OrderStutas = 'Paid-Ready to Delivery' THEN 'Pending' " +
                         " WHEN si.orderStutas = 'COD-Ready to Delivery' THEN 'Pending' " +
                         " WHEN si.OrderStutas = 'Paid - Delivered' THEN 'Deliverd' " +
                         " WHEN si.orderStutas = 'Deliverd & Cash Recived' THEN 'Deliverd' " +
                         " WHEN si.orderStutas = 'Deliverd' THEN 'Deliverd' " +
                         " WHEN si.orderStutas = 'Return' THEN 'Return' END 'Status' " +
                         " FROM  sales_item si " +
                         " left join  sales_payment sp " +
                         " ON si.sales_id = sp.sales_id " +
                         " left join purchase p " +
                         " ON p.product_id = si.itemcode " +
                         " left join  tbl_item_uom_price tiu " +
                         " ON tiu.itemID = si.itemcode " +
                         " where si.status = 1   and  si.Qty != 0 and  si.tenentid=" + Tenent.TenentID + " and si.paymentMode!='Draft' and si.paymentMode!='Booking' and si.sales_time Like '%" + start_Date + "%' " +
                         " group by si.sales_id " +
                         "  order by si.item_id asc ";

            DataTable dt1 = DataAccess.GetDataTable(sql);
            dtGrdvOrderDetails.DataSource = dt1;
            dtGrdvOrderDetails.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dtGrdvOrderDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns["Action"].DisplayIndex = 6;

        }
        private void dtDriverStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtDriverStartDate.Text == "")
            {
                MessageBox.Show("Please Select From Date ");
            }
            else
            {
                try
                {
                    txtReciptNO.Text = "";
                    DateTime startDate = Convert.ToDateTime(dtDriverStartDate.Text);
                    Daywice(startDate);

                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }
        private void txtReciptNO_TextChanged(object sender, EventArgs e)
        {
            if (txtReciptNO.Text == "")
            {
                MessageBox.Show("Please Recipt NO ");
            }
            else
            {
                try
                {
                    dtGrdvOrderDetails.Refresh();
                    string sql = " SELECT  si.InvoiceNO as 'Receipt' ,  si.orderTotal as 'Order Amount' ,   si.sales_time as 'Date'," +
                                 " CASE     WHEN si.driver = '0' THEN ''   WHEN si.driver != '0' THEN si.driver    END 'driver' ," +
                                 " CASE     WHEN si.COD = 0 THEN 'Paid'   WHEN si.COD = '1' THEN 'COD'    END 'COD' ," +
                                 " CASE " +
                                 " WHEN si.OrderStutas = 'Advance Paid-Ready to Delivery' THEN 'Pending' " +
                                 " WHEN si.OrderStutas = 'Paid-Ready to Delivery' THEN 'Pending' " +
                                 " WHEN si.orderStutas = 'COD-Ready to Delivery' THEN 'Pending' " +
                                 " WHEN si.OrderStutas = 'Paid - Delivered' THEN 'Deliverd' " +
                                 " WHEN si.orderStutas = 'Deliverd & Cash Recived' THEN 'Deliverd' " +
                                 " WHEN si.orderStutas = 'Deliverd' THEN 'Deliverd' END 'Status' " +
                                 " FROM  sales_item si " +
                                 " left join  sales_payment sp " +
                                 " ON si.sales_id = sp.sales_id " +
                                 " left join purchase p " +
                                 " ON p.product_id = si.itemcode " +
                                 " left join  tbl_item_uom_price tiu " +
                                 " ON tiu.itemID = si.itemcode " +
                                 " where si.status = 1   and  si.Qty != 0 and  si.tenentid=" + Tenent.TenentID + " and si.paymentMode!='Draft' and si.paymentMode!='Booking' and si.InvoiceNO like '%" + txtReciptNO.Text + "%'  " +
                                 " group by si.sales_id " +
                                 " order by si.item_id asc ";

                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    dtGrdvOrderDetails.DataSource = dt1;
                    dtGrdvOrderDetails.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
                    dtGrdvOrderDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns["Action"].DisplayIndex = 6;

                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }
        public void ShowDriverAction(string InvoiceNO, int CursorY)
        {
            string salesID = GetSalesID(InvoiceNO);
            string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and sales_id=" + salesID + " ";

            DataTable dt1 = DataAccess.GetDataTable(sql3);

            int cal = Cursor.Position.X;
            int CursorX = cal - 350;

            if (dt1.Rows.Count > 0)
            {
                if (Application.OpenForms["DriverAction"] != null)
                {
                    Application.OpenForms["DriverAction"].Close();
                }

                DriverAction mkc1 = new DriverAction(CursorX, CursorY);
                mkc1.OrderNO = InvoiceNO;
                mkc1.Show();

            }
        }
        private void dtGrdvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrdvOrderDetails.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvOrderDetails.Rows[e.RowIndex];

                    string id = row.Cells["Receipt"].Value.ToString();
                    int CursorY = Cursor.Position.Y;
                    if (e.RowIndex >= 6)
                    {
                        CursorY = 476;
                    }

                    ShowDriverAction(id, CursorY);

                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }
        private void lblorderNO_TextChanged(object sender, EventArgs e)
        {
            //CashierAction CashierAction = (CashierAction)Application.OpenForms["CashierAction"];
            // CashierAction.Close();
            if (lblorderNO.Text != "-")
            {
                if (UserInfo.TranjationPerform != null)
                {
                    string ActionEvent = UserInfo.TranjationPerform;
                    if (ActionEvent == "Draft")
                    {
                        string InvoicetransNO = lblorderNO.Text;
                        EditOrder(InvoicetransNO);
                        this.tabPageSR_Counter.Parent = this.tabSRcontrol; //show
                        tabSRcontrol.SelectedTab = tabPageSR_Counter;
                    }
                    else if (ActionEvent == "Booking")
                    {
                        string InvoicetransNO = lblorderNO.Text;
                        EditOrder(InvoicetransNO);
                        this.tabPageSR_Counter.Parent = this.tabSRcontrol; //show
                        tabSRcontrol.SelectedTab = tabPageSR_Counter;
                    }
                    else if (ActionEvent == "Payment")
                    {
                        string InvoicetransNO = lblorderNO.Text;
                        EditOrder(InvoicetransNO);

                        SalesCreditPayment();
                    }
                    else if (ActionEvent == "COD")
                    {
                        string InvoicetransNO = lblorderNO.Text;
                        EditOrder(InvoicetransNO);

                        CashOnDelivery();
                        this.tabPageSR_Counter.Parent = this.tabSRcontrol; //show
                        tabSRcontrol.SelectedTab = tabPageSR_Counter;
                        //Last30daysReport(dtStartDate.Text);
                    }
                    else if (ActionEvent == "CashAndPrint")
                    {
                        string InvoicetransNO = lblorderNO.Text;
                        EditOrder(InvoicetransNO);

                        SaveandPrint(false);
                        if (SeearchNo == 0)
                        {
                            dtStartDate.Text = searchDate;
                            btnCashierRefresh_Click(null, null);
                        }
                        else if (SeearchNo == 1)
                        {
                            btnCustCode_Click(null, null);
                        }
                        else if (SeearchNo == 2)
                        {
                            btnSerchCashier_Click(null, null);
                        }

                        //Last30daysReport(dtStartDate.Text);
                    }
                    else if (ActionEvent == "DriverAssign")
                    {
                        Last30daysReport(dtStartDate.Text);
                        if (dtDriverStartDate.Text != "")
                        {
                            try
                            {
                                txtReciptNO.Text = "";
                                DateTime startDate = Convert.ToDateTime(dtDriverStartDate.Text);
                                Daywice(startDate);
                            }
                            catch { }
                        }
                    }
                    else if (ActionEvent == "Deliverd")
                    {
                        Last30daysReport(dtStartDate.Text);
                        if (dtDriverStartDate.Text != "")
                        {
                            try
                            {
                                txtReciptNO.Text = "";
                                DateTime startDate = Convert.ToDateTime(dtDriverStartDate.Text);
                                Daywice(startDate);
                            }
                            catch { }
                        }
                    }
                    else { }
                    UserInfo.TranjationPerform = null;
                }

                lblorderNO.Text = "-";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dtDriverStartDate.Text == "")
            {
                MessageBox.Show("Please Select From Date ");
            }
            else
            {
                try
                {
                    txtReciptNO.Text = "";
                    DateTime startDate = Convert.ToDateTime(dtDriverStartDate.Text);
                    Daywice(startDate);

                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }
        private void lblPerishable_TextChanged(object sender, EventArgs e)
        {
            if (lblPerishable.Text != "-")
            {
                if (Perishable.selectPerishable == true)
                {
                    string item = Perishable.item;
                    string BatchNo = Perishable.BatchNo;
                    int OnHand = Perishable.OnHand;
                    string ExpiryDate = Perishable.ExpiryDate;

                    UpdateItem(item, BatchNo, OnHand, ExpiryDate);

                    Perishable.selectPerishable = false;
                    Perishable.item = null;
                    Perishable.BatchNo = null;
                    Perishable.OnHand = 0;
                    Perishable.ExpiryDate = null;
                    lblPerishable.Text = "-";
                }
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
                    int OnHand = Serialize.OnHand;


                    UpdateItemSerial(item, Serial_Number, OnHand);

                    Serialize.selectSerialize = false;
                    Serialize.item = null;
                    Serialize.Serial_Number = null;
                    Serialize.OnHand = 0;

                    lblSerialize.Text = "-";
                }
            }
            if (lblSerialize.Text == "x")
            {
                if (dgrvSalesItemList.Rows.Count > 0)
                {
                    string item = Serialize.item.Trim();

                    foreach (DataGridViewRow row in dgrvSalesItemList.Rows)
                    {
                        string ItemsNam = row.Cells[0].Value.ToString().Split('-')[1].Trim();
                        //string ItemsNam = row.Cells[0].Value.ToString().Trim();

                        if (ItemsNam.Equals(item))
                        {
                            if (row.Cells[17].Value == null || row.Cells[17].Value == "")
                            { dgrvSalesItemList.Rows.Remove(row); }

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

        private void chkoutput_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(DisplayCategoryClick);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }
            CategoryList();
            Category_with_images();
        }
        private void linkbtnSlpit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblTotalPayable.Text == "00" || lblTotalPayable.Text == "0" || lblTotalPayable.Text == string.Empty)
            {
                MessageBox.Show("Sorry ! You don't have enough product in Item cart \n  Please Add to cart", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }

            if (comboTable.Text != "" && comboTable.Text != "System.Data.DataRowView")
            {
                this.tabPageSR_Split_Bill.Parent = this.tabSRcontrol; //show
                tabSRcontrol.SelectedTab = tabPageSR_Split_Bill;
                tabPageSR_Split_Billb.Visible = true;
                lblPaid.Text = "0";

                //dgrvSalesItemList.Rows.Clear();

                DiscountCalculation();
                vatcal();
                GridPayment.Rows.Clear();
                dataGridPaymentSplit.Rows.Clear();
                BindCustomer();

                string no = comboTable.Text.ToString().Split('-')[2].Trim();
                //textSlpitNO.Text = no;
                int SNO = Convert.ToInt32(no);

                lblMaxNOBill.Text = no;

                textSlpitNO.Text = GetSplitGridCount().ToString();
                textSlpitNO.Enabled = false;

                decimal TotalpayAMT = Convert.ToDecimal(lblTotalPayment.Text);

                decimal Amt = TotalpayAMT / SNO;

                textSlpitAmt.Text = Amt.ToString();
                panel7.Visible = true;

                if (txtPaidAmount.Text == "" || txtPaidAmount.Text == ".")
                {
                    return;
                }

                decimal Totalpay = Convert.ToDecimal(lblTotalPayment.Text);
                decimal totalPaid = Convert.ToDecimal(lblPaid.Text);


                if (Totalpay > totalPaid)
                {
                    string sales_id = lblInvoiceNO.Text;
                    string payment_type = CombPayby.Text.ToString().Trim();
                    decimal payment_amount = Convert.ToDecimal(txtPaidAmount.Text);
                    string c_id = lblCustID.Text;
                    string Reffrance_NO = txtReffrance.Text;

                    string Customer = GetCustomer();
                    dataGridPaymentSplit.Rows.Clear();


                    int rows = dgrvSalesItemList.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        string itNam = dgrvSalesItemList.Rows[i].Cells[0].Value.ToString();

                        double Total = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value.ToString());

                        int NO = i + 1;
                        dataGridPaymentSplit.Rows.Add(NO, Customer, itNam, payment_type, Reffrance_NO, Total);
                    }

                    lblMaxNOBill.Text = rows.ToString();

                    dataGridPaymentSplit.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    dataGridPaymentSplit.Columns[2].Visible = true;
                    dataGridPaymentSplit.Columns[7].Visible = false;
                    textSlpitAmt.Enabled = false;

                    salesSplit.SplitType = "Items";
                }

            }
        }
        public string GetCustomer()
        {
            string Customer = "";
            if (txtCustomer.Text != "")
            {
                string Name = txtCustomer.Text.Split('-')[0];
                string Mobile = "";//Yogesh Change 200519
                if (Name != "Cash" && Name != "Gest")
                    Mobile = txtCustomer.Text.Split('-')[1].Trim();
                Name = Name.Trim();
                string sql = "Select * from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = '" + Name + "' and trim(Phone)  = '" + Mobile + "'";

                DataTable dt = DataAccess.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    lblCustID.Text = dt.Rows[0]["ID"].ToString();
                    Customer = dt.Rows[0]["Name"].ToString();
                }
                else
                {
                    string sql1 = "Select * from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = 'Gest'";

                    DataTable dt12 = DataAccess.GetDataTable(sql1);

                    if (dt12.Rows.Count > 0)
                    {
                        lblCustID.Text = dt12.Rows[0]["ID"].ToString();
                    }
                    Customer = txtCustomer.Text;
                }
            }

            return Customer;
        }
        public decimal GetSplitSum()
        {
            decimal sum = 0;
            int n1 = FindSplititem(textSlpitNO.Text);
            if (n1 == -1)  //If new item
            {
                for (int i = 0; i < dataGridPaymentSplit.Rows.Count; ++i)
                {
                    sum += Convert.ToDecimal(dataGridPaymentSplit.Rows[i].Cells[5].Value);
                }
            }
            else
            {
                for (int i = 0; i < dataGridPaymentSplit.Rows.Count; ++i)
                {
                    if (dataGridPaymentSplit.Rows[i].Index != n1)
                    {
                        sum += Convert.ToDecimal(dataGridPaymentSplit.Rows[i].Cells[5].Value);
                    }

                }
            }
            return sum;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string no = comboTable.Text.ToString().Split('-')[2].Trim();
            //textSlpitNO.Text = no;
            int SNO = Convert.ToInt32(no);

            int NO = GetSplitGridCount();

            if (SNO >= NO)
            {

            }
            else
            {
                int n = FindSplititem(textSlpitNO.Text);
                if (n == -1)  //If new item
                {
                    MessageBox.Show("You Allow Maximam " + SNO + " Bill");
                    return;
                }
            }

            if (textSlpitAmt.Text != "0")
            {
                if (comboPaytype.Text != "Cash" && txtSplitReffrance.Text == "")
                {
                    string payment_type = comboPaytype.Text;
                    txtSplitReffrance.Focus();
                    MessageBox.Show("Reffrance_NO Can Not Be Empty in " + payment_type);
                    return;
                }

                decimal Enter = Convert.ToDecimal(textSlpitAmt.Text);

                decimal Totalapp = Convert.ToDecimal(lblTotalPayment.Text);

                if (Totalapp < Enter)
                {
                    MessageBox.Show("Max Input Allow To " + Totalapp);
                    return;
                }
                else
                {

                    decimal sum = GetSplitSum();

                    decimal Rest = Totalapp - sum;

                    if (Rest < Enter)
                    {
                        MessageBox.Show("Max Input Allow To " + Rest);
                        return;
                    }

                }

                int n = FindSplititem(textSlpitNO.Text);
                if (n == -1)  //If new item
                {
                    string Customer = GetSplitCustomer();
                    string payment_type = comboPaytype.Text;
                    string Reffrance_NO = txtSplitReffrance.Text;
                    string Amt = textSlpitAmt.Text;

                    dataGridPaymentSplit.Rows.Add(NO, Customer, payment_type, Reffrance_NO, Amt);
                    dataGridPaymentSplit.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                else
                {
                    string Customer = GetSplitCustomer();
                    dataGridPaymentSplit.Rows[n].Cells[1].Value = Customer;
                    dataGridPaymentSplit.Rows[n].Cells[3].Value = comboPaytype.Text;
                    dataGridPaymentSplit.Rows[n].Cells[4].Value = txtSplitReffrance.Text;
                    dataGridPaymentSplit.Rows[n].Cells[5].Value = textSlpitAmt.Text;
                }

                decimal sum1 = 0;
                for (int i = 0; i < dataGridPaymentSplit.Rows.Count; ++i)
                {
                    sum1 += Convert.ToDecimal(dataGridPaymentSplit.Rows[i].Cells[5].Value);
                }

                lblPaid1.Text = sum1.ToString();

                decimal Rest1 = Totalapp - sum1;

                textSlpitAmt.Text = Rest1.ToString();

                textSlpitNO.Text = GetSplitGridCount().ToString();
            }
            tabSRcontrol.SelectedTab = tabPageSR_Counter;
        }
        public int GetSplitGridCount()
        {
            int Count = 0;

            Count = dataGridPaymentSplit.Rows.Count + 1;

            return Count;
        }
        public string GetSplitCustomer()
        {
            string Customer = "";
            if (ComboSplitCustomer.Text != "")
            {
                string Name = ComboSplitCustomer.Text.Split('-')[0];
                string Mobile = "";//Yogesh change 200519
                if (Name != "Cash" && Name != "Gest")
                    Mobile = ComboSplitCustomer.Text.Split('-')[1].Trim();
                Name = Name.Trim();
                string sql = "Select * from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = '" + Name + "' and trim(Phone)  = '" + Mobile + "'";

                DataTable dt = DataAccess.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    lblCustID.Text = dt.Rows[0]["ID"].ToString();
                    Customer = dt.Rows[0]["Name"].ToString();
                }
                else
                {
                    string sql1 = "Select * from tbl_customer  where TenentID = " + Tenent.TenentID + " and trim(Name)  = 'Gest'";

                    DataTable dt12 = DataAccess.GetDataTable(sql1);

                    if (dt12.Rows.Count > 0)
                    {
                        lblCustID.Text = dt12.Rows[0]["ID"].ToString();
                    }
                    Customer = txtCustomer.Text;
                }
            }

            return Customer;
        }
        public int FindSplititem(string item)
        {
            int k = -1;
            if (dgrvSalesItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridPaymentSplit.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item))
                    {
                        k = row.Index;
                        break;
                    }
                }
            }
            return k;
        }
        private void dataGridPaymentSplit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridPaymentSplit.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row2 in dataGridPaymentSplit.SelectedRows)
                {
                    if (!row2.IsNewRow)
                        dataGridPaymentSplit.Rows.Remove(row2);


                    decimal sum1 = 0;
                    for (int i = 0; i < dataGridPaymentSplit.Rows.Count; ++i)
                    {
                        sum1 += Convert.ToDecimal(dataGridPaymentSplit.Rows[i].Cells[5].Value);
                    }

                    decimal Totalapp = Convert.ToDecimal(lblTotalPayment.Text);
                    decimal Rest1 = Totalapp - sum1;

                    textSlpitAmt.Text = Rest1.ToString();
                    textSlpitNO.Text = GetSplitGridCount().ToString();
                }
            }

            if (e.ColumnIndex == dataGridPaymentSplit.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row2 in dataGridPaymentSplit.SelectedRows)
                {
                    textSlpitNO.Enabled = false;
                    string NO = row2.Cells[0].Value.ToString();
                    textSlpitNO.Text = NO;
                    textSlpitAmt.Text = row2.Cells[5].Value.ToString();
                    txtSplitReffrance.Text = row2.Cells[4].Value.ToString();
                }
            }
        }
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserInfo.addcustomerflag = true;
            Customer.AddNewCustomer GO = new Customer.AddNewCustomer();
            GO.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BindCustomer();
        }
        public void BindCustomer()
        {
            //ComboCustID.Items.Clear();

            //Customer Databind 
            string sqlCust = "select   DISTINCT  Name,EmailAddress,Phone  from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Customer'";

            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            for (int i = 0; i < dtCust.Rows.Count; i++)
            {
                //ComboCustID.Items.Add(dtCust.Rows[i][0] + " - " + dtCust.Rows[i][2] + " - " + dtCust.Rows[i][1]);
                ComboSplitCustomer.Items.Add(dtCust.Rows[i][0] + " - " + dtCust.Rows[i][2] + " - " + dtCust.Rows[i][1]);
            }

            //ComboCustID.DataSource = dtCust;
            //ComboCustID.DisplayMember = "Name";
            if (txtCustomer.Text == "")
            {
                //ComboCustID.Text = "Gest";
                ComboSplitCustomer.Text = "Gest";
            }
        }
        private void btnSaveSplit_Click(object sender, EventArgs e)
        {

            decimal paidatm = 0;
            if (lblPaid.Text == string.Empty)
            {
                MessageBox.Show("Please insert paid amount.", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            else
            {
                paidatm = Convert.ToDecimal(lblPaid.Text);
            }

            //if (lblPaid.Text == "00" || lblPaid.Text == "0" || lblPaid.Text == string.Empty)
            //{
            //    MessageBox.Show("Please insert paid amount. \n  If you want full due transaction \n Please insert 0.00 ", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //}
            if (paidatm <= 0)
            {
                MessageBox.Show("Please insert paid amount.", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            else
            {
                try
                {
                    decimal Totalpay = Convert.ToDecimal(lblTotalPayment.Text);
                    decimal totalPaid = Convert.ToDecimal(lblPaid1.Text);

                    if (Totalpay == totalPaid)
                    {
                        //Save payment info into sales_payment table

                        decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                        decimal ChangeAmount = Convert.ToDecimal(0);
                        decimal DueAmount = Convert.ToDecimal(0);
                        string TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");

                        salesSplit.SplitType = "Items";

                        if (salesSplit.SplitType != null && salesSplit.SplitType != "")
                        {
                            string SplitType = salesSplit.SplitType;

                            if (SplitType == "Items")
                            {
                                string Payby = CombPayby.Text.ToString().Trim();
                                payment_item1(TotalPayable, ChangeAmount, DueAmount, Payby, TransDate, txtComment.Text, "Success");

                                ///// save sales items one by one 
                                sales_item1(TransDate, "Paid-send to Kitchen", 0, "PriPaid", txtComment.Text);

                                string OrderWayID = comboSalesMan.Text.Split('-')[0];
                                string name = comboSalesMan.Text.Split('-')[1];
                                if (OrderWayID != "Walk In - Walk In" && OrderWayID != "")
                                {
                                    insertCommission();
                                }
                            }

                            if (SplitType == "Amount")
                            {
                                string Payby = CombPayby.Text.ToString().Trim();
                                payment_AmountSplit(TotalPayable, ChangeAmount, DueAmount, Payby, TransDate, txtComment.Text, "Success");

                                ///// save sales items one by one 
                                int sales_id = Convert.ToInt32(txtInvoice.Text);
                                bool creditFalg = isCreditInvoice(sales_id);
                                if (creditFalg == false)
                                {
                                    sales_item(TransDate, "Paid-send to Kitchen", 0, "PriPaid", txtComment.Text);

                                    string OrderWayID = comboSalesMan.Text.Split('-')[0];
                                    string name = comboSalesMan.Text.Split('-')[1];
                                    if (OrderWayID != "Walk In - Walk In" && OrderWayID != "")
                                    {
                                        insertCommission();
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Successfully has been saved ");

                        salesSplit.InvNO = null;
                        //dgrvSalesItemList.Rows.Clear();
                        //txtDiscountRate.Text = "0";
                        //DiscountCalculation();
                        //vatcal();

                        //salesSplit.SplitType = null;
                        //this.tabPageSR_Payment.Parent = null; //Hide payment tab
                        //tabSRcontrol.SelectedTab = tabPageSR_Counter;
                        //this.tabPageSR_Split_Bill.Parent = null; //Hide Split tab
                        //tabSRcontrol.SelectedTab = tabPageSR_Counter;

                        //GridPayment.Rows.Clear();
                        //lblPaid.Text = "0";
                        //lblPaid1.Text = "0";
                        //txtCustomer.Text = "Cash";

                        //txtcashRecived.Text = "";
                        //lblChangeAmt.Text = "0";

                        //Last30daysReport(dtStartDate.Text);

                        //UserInfo.EditTransation = false;
                        //UserInfo.Invoice = 0;
                        //UserInfo.InvoicetransNO = null;
                        clearInvoice();

                    }
                    else
                    {
                        MessageBox.Show("Total Payable and paid Amount not Match");
                        return;
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }
        private void btnSplitPrint_Click(object sender, EventArgs e)
        {
            if (lblPaid1.Text == "00" || lblPaid1.Text == "0" || lblPaid1.Text == string.Empty)
            {
                //MessageBox.Show("Please insert paid amount. \n  If you want full due transaction \n Please insert 0.00 ", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                decimal Totalpay = Convert.ToDecimal(lblTotalpayableAmtPY.Text);
                decimal enterAmt = Convert.ToDecimal(txtPaidAmount.Text);
                decimal sum = GetSplitSum();

                if (Totalpay == sum)
                {
                    lblPaid1.Text = Totalpay.ToString();
                    txtDueAmount.Text = "0";
                    txtChangeAmount.Text = "0";
                    if (salesSplit.SplitType != null && salesSplit.SplitType != "")
                    {
                        string SplitType = salesSplit.SplitType;

                        if (SplitType == "Items")
                        {
                            Complate_order1();
                        }

                        if (SplitType == "Amount")
                        {
                            Complate_orderAmount();
                        }
                    }
                    //Last30daysReport(dtStartDate.Text);

                    salesSplit.SplitType = null;
                }
                else
                {
                    MessageBox.Show("Plase Enter paid amount Equal of Total Payable");
                    return;
                }



            }
            else
            {
                if (salesSplit.SplitType != null && salesSplit.SplitType != "")
                {
                    string SplitType = salesSplit.SplitType;

                    if (SplitType == "Items")
                    {
                        Complate_order1();
                    }

                    if (SplitType == "Amount")
                    {
                        Complate_orderAmount();
                    }
                }
                //Last30daysReport(dtStartDate.Text);

                salesSplit.SplitType = null;
            }

        }
        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboTable.Text != "" && comboTable.Text != "System.Data.DataRowView")
            {
                this.tabPageSR_Split_Bill.Parent = this.tabSRcontrol; //show
                tabSRcontrol.SelectedTab = tabPageSR_Split_Bill;
                lblPaid.Text = "0";

                //dgrvSalesItemList.Rows.Clear();

                DiscountCalculation();
                vatcal();
                GridPayment.Rows.Clear();
                dataGridPaymentSplit.Rows.Clear();
                BindCustomer();

                string no = comboTable.Text.ToString().Split('-')[2].Trim();
                //textSlpitNO.Text = no;
                int SNO = Convert.ToInt32(no);

                lblMaxNOBill.Text = no;

                textSlpitNO.Text = GetSplitGridCount().ToString();
                textSlpitNO.Enabled = false;

                decimal TotalpayAMT = Convert.ToDecimal(lblTotalPayment.Text);

                decimal Amt = TotalpayAMT / SNO;

                textSlpitAmt.Text = Amt.ToString();
                panel7.Visible = true;

                if (txtPaidAmount.Text == "" || txtPaidAmount.Text == ".")
                {
                    return;
                }

                decimal Totalpay = Convert.ToDecimal(lblTotalPayment.Text);
                decimal totalPaid = Convert.ToDecimal(lblPaid.Text);


                if (Totalpay > totalPaid)
                {
                    string sales_id = lblInvoiceNO.Text;
                    string payment_type = CombPayby.Text.ToString().Trim();
                    decimal payment_amount = Convert.ToDecimal(txtPaidAmount.Text);
                    string c_id = lblCustID.Text;
                    string Reffrance_NO = txtReffrance.Text;

                    string Customer = GetCustomer();
                    dataGridPaymentSplit.Rows.Clear();


                    int rows = dgrvSalesItemList.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {

                        string itNam = dgrvSalesItemList.Rows[i].Cells[0].Value.ToString();

                        double Total = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value.ToString());

                        int NO = i + 1;
                        dataGridPaymentSplit.Rows.Add(NO, Customer, itNam, payment_type, Reffrance_NO, Total);
                    }

                    lblMaxNOBill.Text = rows.ToString();

                    dataGridPaymentSplit.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridPaymentSplit.Columns[2].Visible = true;
                    dataGridPaymentSplit.Columns[7].Visible = false;
                    textSlpitAmt.Enabled = false;

                    salesSplit.SplitType = "Items";
                }

            }
        }
        private void btnItemSplit_Click(object sender, EventArgs e)
        {
            string sales_id = lblInvoiceNO.Text;
            string payment_type = CombPayby.Text.ToString().Trim();
            decimal payment_amount = Convert.ToDecimal(txtPaidAmount.Text);
            string c_id = lblCustID.Text;
            string Reffrance_NO = txtReffrance.Text;

            string Customer = GetCustomer();
            dataGridPaymentSplit.Rows.Clear();


            int rows = dgrvSalesItemList.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                string itNam = dgrvSalesItemList.Rows[i].Cells[0].Value.ToString();

                double Total = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value.ToString());

                int NO = i + 1;
                dataGridPaymentSplit.Rows.Add(NO, Customer, itNam, payment_type, Reffrance_NO, Total);
            }

            lblMaxNOBill.Text = rows.ToString();

            dataGridPaymentSplit.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[2].Visible = true;
            dataGridPaymentSplit.Columns[7].Visible = false;
            textSlpitAmt.Enabled = false;

            textSlpitNO.Text = GetSplitGridCount().ToString();

            salesSplit.SplitType = "Items";
        }
        private void btnAmountsplit_Click(object sender, EventArgs e)
        {
            string no = comboTable.Text.ToString().Split('-')[2].Trim();
            int SNO = Convert.ToInt32(no);
            lblMaxNOBill.Text = no;

            decimal TotalpayAMT = Convert.ToDecimal(lblTotalPayment.Text);

            decimal Amt = TotalpayAMT / SNO;

            string sales_id = lblInvoiceNO.Text;
            string payment_type = CombPayby.Text.ToString().Trim();
            decimal payment_amount = Convert.ToDecimal(txtPaidAmount.Text);
            string c_id = lblCustID.Text;
            string Reffrance_NO = txtReffrance.Text;

            string Customer = GetCustomer();

            dataGridPaymentSplit.Rows.Clear();
            for (int i = 0; i < SNO; i++)
            {
                int NO = i + 1;
                dataGridPaymentSplit.Rows.Add(NO, Customer, "", payment_type, Reffrance_NO, Amt);
            }

            dataGridPaymentSplit.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[2].Visible = false;
            dataGridPaymentSplit.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridPaymentSplit.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            dataGridPaymentSplit.Columns[7].Visible = true;
            textSlpitAmt.Enabled = true;

            textSlpitNO.Text = GetSplitGridCount().ToString();

            salesSplit.SplitType = "Amount";
        }
        public static string GetStoreprintType()
        {
            string type = "Default";
            string sqlCust = "select * from storeconfig where tenentid= " + Tenent.TenentID + " and printtype is not null  ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust.Rows.Count > 0)
            {
                type = dtCust.Rows[0]["printtype"].ToString();
            }

            return type;
        }
        public static string getPrintFile(string PrintType) // Cash , Creadit , Kitchen
        {
            string type = "";

            string sqlCust = "select * from tblPrintSetup where TenentID= " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust.Rows.Count > 0)
            {
                if (PrintType == "Cash")
                    type = dtCust.Rows[0]["CashReceiptFile"].ToString();
                //else if (PrintType == "Creadit")
                //    type = dtCust.Rows[0]["CreditInvoiceFile"].ToString();//040519 yogesh 
                else if (PrintType == "Kitchen")
                    type = dtCust.Rows[0]["KitchenNoteFile"].ToString();
                else
                    type = type = dtCust.Rows[0]["CashReceiptFile"].ToString();
            }

            string File = GetFileName(type);

            return File;
        }
        public static string getFileType(string ID)
        {
            string type = "Default";

            string sqlCust = "select * from tblinvoice_PrintFile where ID = '" + ID + "'";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust.Rows.Count > 0)
            {
                type = dtCust.Rows[0]["FileDisplayName"].ToString();
            }

            return type;
        }
        public static string GetFileName(string ID)
        {
            string type = "POSPrintRpt";

            string sqlCust = "select * from tblinvoice_PrintFile where ID = '" + ID + "'";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            if (dtCust.Rows.Count > 0)
            {
                type = dtCust.Rows[0]["FileName"].ToString();
            }

            return type;
        }
        public static void PRintInvoice1(string saleno, string File, string DefaultPrinter)
        {
            if (File == "POSPrintRpt") // Default
            {
                POSPrintRpt go = new POSPrintRpt(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (File == "POSPrintRptShort") //Short
            {
                POSPrintRptShort go = new POSPrintRptShort(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (File == "POSPrintRptSplit") //Split
            {
                POSPrintRptSplit go = new POSPrintRptSplit(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (File == "POSPrintRptA4")
            {
                POSPrintRptA4 go = new POSPrintRptA4(saleno, DefaultPrinter);
                go.ShowDialog();

            }
            else if (File == "POSPrintRptA5")
            {
                POSPrintRptA5 go = new POSPrintRptA5(saleno, DefaultPrinter);
                go.ShowDialog();

            }
            else if (File == "POSPrintRptA5Laundary")
            {
                POSPrintRptA5Laundary go = new POSPrintRptA5Laundary(saleno, DefaultPrinter,0);
                go.ShowDialog();

            }
            else if (File == "POSPrintRptShortICode")
            {
                POSPrintRptShortICode go = new POSPrintRptShortICode(saleno, DefaultPrinter);
                go.ShowDialog();

            }
            else
            {
                POSPrintRpt go = new POSPrintRpt(saleno, DefaultPrinter);
                go.ShowDialog();
            }
        }
        public static void PRintInvoiceCashier(string saleno, string File, string DefaultPrinter,int customercode)
        {
            if (File == "POSPrintRpt") // Default
            {
                POSPrintRpt go = new POSPrintRpt(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (File == "POSPrintRptShort") //Short
            {
                POSPrintRptShort go = new POSPrintRptShort(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (File == "POSPrintRptSplit") //Split
            {
                POSPrintRptSplit go = new POSPrintRptSplit(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (File == "POSPrintRptA4")
            {
                POSPrintRptA4 go = new POSPrintRptA4(saleno, DefaultPrinter);
                go.ShowDialog();

            }
            else if (File == "POSPrintRptA5")
            {
                POSPrintRptA5 go = new POSPrintRptA5(saleno, DefaultPrinter);
                go.ShowDialog();

            }
            else if (File == "POSPrintRptA5Laundary")
            {
                POSPrintRptA5Laundary go = new POSPrintRptA5Laundary(saleno, DefaultPrinter,customercode);
                go.ShowDialog();

            }
            else if (File == "POSPrintRptShortICode")
            {
                POSPrintRptShortICode go = new POSPrintRptShortICode(saleno, DefaultPrinter);
                go.ShowDialog();

            }
            else
            {
                POSPrintRpt go = new POSPrintRpt(saleno, DefaultPrinter);
                go.ShowDialog();
            }
        }
        public static void PRintInvoice(string saleno, string Type)// Default , Short ,Split
        {
            string DefaultPrinter = DataAccess.GetDefaultPrinter();

            if (Type == "Default") // Default
            {
                POSPrintRpt go = new POSPrintRpt(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (Type == "Short") //Short
            {
                POSPrintRptShort go = new POSPrintRptShort(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (Type == "Split") //Split
            {
                POSPrintRptSplit go = new POSPrintRptSplit(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (Type == "POSPrintRptA4")
            {
                POSPrintRptA4 go = new POSPrintRptA4(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (Type == "POSPrintRptA5")
            {
                POSPrintRptA5 go = new POSPrintRptA5(saleno, DefaultPrinter);
                go.ShowDialog();
            }
            else if (Type == "POSPrintRptA5Laundary")
            {
                POSPrintRptA5Laundary go = new POSPrintRptA5Laundary(saleno, DefaultPrinter,0);
                go.ShowDialog();
            }
            else
            {
                POSPrintRpt go = new POSPrintRpt(saleno, DefaultPrinter);
                go.ShowDialog();
            }

        }
        public static void openKeyboard()
        {
            try
            {
                closekeyboard();

                string progFiles1 = @"C:\Program Files (x86)\FreeVK";
                string keyboardPath1 = Path.Combine(progFiles1, "FreeVK.exe");
                if (File.Exists(keyboardPath1))
                {
                    Process.Start(keyboardPath1);
                }
                else
                {
                    string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
                    string keyboardPath = Path.Combine(progFiles, "TabTip.exe");

                    if (File.Exists(keyboardPath))
                    {
                        Process.Start(keyboardPath);
                    }
                    else
                    {
                        string progFiles2 = @"C:\windows\system32\";
                        string keyboardPath2 = Path.Combine(progFiles2, "osk.exe");
                        if (File.Exists(keyboardPath2))
                        {
                            Process.Start(keyboardPath2);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public static void closekeyboard()
        {
            Process[] oskProcessArray = Process.GetProcessesByName("osk");
            foreach (Process onscreenProcess in oskProcessArray)
            {
                onscreenProcess.Kill();
                onscreenProcess.Dispose();
            }

            Process[] oskProcessArray1 = Process.GetProcessesByName("TabTip");
            foreach (Process onscreenProcess in oskProcessArray1)
            {
                onscreenProcess.Kill();
                onscreenProcess.Dispose();
            }

            Process[] oskProcessArray2 = Process.GetProcessesByName("FreeVK");
            foreach (Process onscreenProcess in oskProcessArray2)
            {
                onscreenProcess.Kill();
                onscreenProcess.Dispose();
            }
        }
        private void dgrvSalesItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgrvSalesItemList.Columns["Am"].Index && e.RowIndex >= 0)
            {
                //openKeyboard();
            }

            if (e.ColumnIndex == dgrvSalesItemList.Columns["Qty"].Index && e.RowIndex >= 0)
            {
                //openKeyboard();                
            }
        }
        private void chkCreditTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreditTrans.Checked == true)
            {
                if (lblCustID.Text == "1")
                {
                    MyMessageAlert.ShowBox("Please Select Customer Rather than Cash Or Gest .", "Alert");

                    chkCreditTrans.Checked = false;
                    radiocredit.Checked = false;
                    radioCash.Checked = true;
                    return;
                }
            }
        }
        private void btnrefrash_Click(object sender, EventArgs e)
        {
            BindCustomer();
        }
        private void chkdiscredit_CheckedChanged(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text);
            txtInvoiceCash.Text = "";
        }
        private void SalesRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            clearInvoice();
        }
        private void datagrdReportDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           // foreach (DataGridViewRow Myrow in datagrdReportDetails.Rows)
           // {
           //     string id = Myrow.Cells["Receipt"].Value.ToString();
           //     string PaymentMode = GetPaymentMode(id).Trim();
           //     if (PaymentMode == "Credit")
           //     {
           //         bool PaymentStatus = GetPaymentstatus(id);
           //         if (PaymentStatus == false)
           //         {
           //             Myrow.DefaultCellStyle.BackColor = Color.Red;
           //         }
           //     }
           // }
        }
        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Add_PaymentType"] != null)
            {
                Application.OpenForms["Add_PaymentType"].Close();
                Add_PaymentType go = new Add_PaymentType();
                go.Show();

            }
            else
            {
                Add_PaymentType go = new Add_PaymentType();
                go.Show();
            }
        }
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["CustomerSearch"] != null)
            {
                Application.OpenForms["CustomerSearch"].Close();
            }
            this.Refresh();

            CustomerSearch go = new CustomerSearch();
            go.Show();
        }
        private void radiocredit_CheckedChanged(object sender, EventArgs e)
        {
            if (radiocredit.Checked == true)
            {
                chkCreditTrans.Checked = true;
                btnCashAndPrint.Text = "Credit/Print";

            }

        }

        private void dtsaleDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtSalesDate.Text = dtsaleDate.Text;
                DateTime DeliveryDt = Convert.ToDateTime(dtsaleDate.Text);
                dtsaleDeliveryDate.Text = DeliveryDt.AddDays(1).ToString();
                dtsaleDeliveryDate.Format = DateTimePickerFormat.Custom;//laundary yogesh 030519
                dtsaleDeliveryDate.CustomFormat = "yyyy-MM-dd";
            }
            catch
            {

            }
        }

        private void SetLoadingForItem(bool displayLoader)
        {
            try
            {
                if (displayLoader)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (Application.OpenForms["Loading"] != null)
                        {
                            Application.OpenForms["Loading"].Close();
                        }
                        this.Refresh();

                        int X = this.Width / 2;
                        int Y = this.Height / 2;
                        Loading go = new Loading(X, Y);
                        go.Show();

                        this.Cursor = Cursors.WaitCursor;
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (Application.OpenForms["Loading"] != null)
                        {
                            Application.OpenForms["Loading"].Close();
                        }
                        this.Refresh();
                        this.Cursor = Cursors.Default;
                    });
                }
            }
            catch
            {

            }

        }

        private void SetLoading(bool displayLoader)
        {
            try
            {
                if (displayLoader)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (Application.OpenForms["Loading"] != null)
                        {
                            Application.OpenForms["Loading"].Close();
                        }
                        this.Refresh();

                      //  int X = 551 + (this.tabControl1.Width / 2);
                      //  int Y = 25 + (this.tabControl1.Height / 2);
                      //  Loading go = new Loading(X, Y);
                       // go.Show();

                        this.Cursor = Cursors.WaitCursor;
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (Application.OpenForms["Loading"] != null)
                        {
                            Application.OpenForms["Loading"].Close();
                        }
                        this.Refresh();
                        this.Cursor = Cursors.Default;
                    });
                }
            }
            catch
            {

            }

        }

        private void chkWithGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithGrid.Checked == true)
            {
                try
                {
                    Thread threadInput = new Thread(DisplayCategoryClick);
                    threadInput.Start();
                }
                catch (Exception ex)
                {
                }

                //  this.ItemGrid.Parent = this.tabControl1;
                // tabControl1.SelectedTab = ItemGrid;
                // btnItemGrid_Click(null, null);
             
                chkbutton.Checked = false;
                chkImage.Checked = false;

            }
        }
      

        private void chkbutton_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbutton.Checked == true)
            {
                try
                {
                    Thread threadInput = new Thread(DisplayCategoryClick);
                    threadInput.Start();
                }
                catch (Exception ex)
                {
                }

                //  this.ItemButton.Parent = this.tabControl1;
                // tabControl1.SelectedTab = ItemButton;
               
                chkWithGrid.Checked = false;
                chkImage.Checked = false;
            }
        }

        private void chkImage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkImage.Checked == true)
            {
                try
                {
                    Thread threadInput = new Thread(DisplayCategoryClick);
                   threadInput.Start();
                }
                catch (Exception ex)
                {
                }

               // this.ItemsImage.Parent = this.tabControl1;
               // tabControl1.SelectedTab = ItemsImage;
              //  btnImages_Click(null, null);
                chkWithGrid.Checked = false;
                chkbutton.Checked = false;

            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void DisplayCategoryClick()
        {
           // SetLoading(true);

            // Added to see the indicator (not required)
            //Thread.Sleep(1);

            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    DateTime Start = DateTime.Now;
                    if (txtSearchItem.Text != "")
                    {
                        TextItemSearch();
                    }
                    else
                    {
                        if (chkWithGrid.Checked == true)
                        {
                            if (chkoutput.Checked == true)
                            {
                                ItemList_with_Catagory_Grid(lblCatagory.Text, "Output");
                            }
                            else
                            {
                                ItemList_with_Catagory_Grid(lblCatagory.Text, "");
                            }
                        }
                        else if (chkImage.Checked == true)
                        {

                            if (chkoutput.Checked == true)
                            {
                                ItemList_with_Catagory_images(lblCatagory.Text, "Output");
                            }
                            else
                            {
                                ItemList_with_Catagory_images(lblCatagory.Text, "");
                            }
                        }
                        else
                        {
                            if (chkoutput.Checked == true)
                            {
                                ItemList_with_Catagory_With_Button(lblCatagory.Text, "Output");
                            }
                            else
                            {
                                ItemList_with_Catagory_With_Button(lblCatagory.Text, "");
                            }
                        }
                    }
                    lblstart.Text = Math.Round(DateTime.Now.Subtract(Start).TotalSeconds, 3).ToString();
                });
            }
            catch
            {

            }

         //   SetLoading(false);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            string Tabname = e.TabPage.Text.ToString();
            Tabname = Tabname.Trim();
            if (Tabname == "Item Grid")
            {
                _Tab = 0;
               
            }
            else if (Tabname == "Item Button")
            {
                _Tab = 0;
               
            }
            else if (Tabname == "Items  Image")
            {
                _Tab = 0;
              
            }
            else if (Tabname == "Related Items")
            {
                _Tab = 0;
               
            }
            else if (Tabname == "Catagories")
            {
                _Tab = 0;
             
            }
            else if (Tabname == "Package-Receipe")
            {
                _Tab = 1;
                ItemList_with_Package();
            }

            
            else
            {

            }

        }

        private void tabSRcontrol_Selecting(object sender, TabControlCancelEventArgs e)
        {
            string Tabname = e.TabPage.Text.ToString();
            Tabname = Tabname.Trim();

            if (Tabname == "Cashier")
            {
                this.AcceptButton = btnCustCode;
                string Today = lblStartDate.Text;
                txtInvoiceCash.Focus();
                if (Today == "")
                {
                    Today = DateTime.Now.ToString("yyyy-MM-dd");
                }
                Last30daysReport(Today);
            }
            else if (Tabname == "Delivery")
            {
                DateTime startDate = DateTime.Now;
                Daywice(startDate);
            }
        }

        private void txtDiscountRate_Enter(object sender, EventArgs e)
        {
            txtDiscountRate.Text = "";
        }

        private void lbloveralldiscount_Enter(object sender, EventArgs e)
        {
            lbloveralldiscount.Text = "";
        }

        private void txtcashRecived_Leave(object sender, EventArgs e)
        {
            btnCashAndPrint.Focus();
        }

        private void btnAppGridAdd_Click(object sender, EventArgs e)
        {


            decimal Totalpay = Convert.ToDecimal(lblTotalpayableAmtPY.Text);
            decimal totalPaid = Convert.ToDecimal(lblPaid.Text);





            if (Totalpay > totalPaid)
            {
                int sales_id = Convert.ToInt32(txtInvoice.Text);
                decimal payment_amount = Convert.ToDecimal(txtPaidAmount.Text);
                string c_id = lblCustID.Text;
                string payment_type = CombPayby.Text.ToString().Trim();
                string Reffrance_NO = txtReffrance.Text;

                int n = FindPayment(payment_type);
                if (n == -1)  //If new item
                {
                    GridPayment.Rows.Add(sales_id, payment_type, Reffrance_NO, payment_amount);
                }
                else
                {
                    decimal OldVal = Convert.ToInt32(GridPayment.Rows[n].Cells[3].Value);

                    decimal New = OldVal + payment_amount;
                    GridPayment.Rows[n].Cells[3].Value = New;

                    string Reffrance = GridPayment.Rows[n].Cells[2].Value.ToString();

                    Reffrance = Reffrance + ", " + Reffrance_NO;

                    GridPayment.Rows[n].Cells[2].Value = Reffrance;

                    //string payment_type = GridPayment.Rows[i].Cells[1].Value.ToString();
                    //string Reffrance = GridPayment.Rows[i].Cells[2].Value.ToString();
                    //decimal payment_amount = Convert.ToDecimal(GridPayment.Rows[i].Cells[3].Value);
                }

                decimal sum = 0;
                for (int i = 0; i < GridPayment.Rows.Count; ++i)
                {
                    sum += Convert.ToDecimal(GridPayment.Rows[i].Cells[3].Value);
                }

                lblPaid.Text = sum.ToString();
                txtPaidAmount.Text = (Totalpay - sum).ToString();
                //txtReffrance.Text = "";
                //if (lblPaid.Text != lblTotalpayableAmtPY.Text)//yogesh 030719
                //{
                //    if (lblPaid.Text != "0")
                //    {
                //        chkCreditTrans.Checked = true;
                //        lblPaid.Text = "0";
                //        txtPaidAmount.Text = lblTotalpayableAmtPY.Text;
                //        GridPayment.Rows.Clear();
                //        return;
                //    }
                //}

            }
            else
            {

            }
            compairePaymentAmt();
        }


        private void txtSearchItem_KeyDown_1(object sender, KeyEventArgs e)
        {
           
        }

        private void txtBarcodeReaderBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int Sales_id = Convert.ToInt32(txtInvoice.Text);
                bool ISPaymentCredit = CheckISPaymentCredit(Sales_id);
                if (ISPaymentCredit == true)
                {
                    MessageBox.Show(" This Invoice is Creadit invoice It Not Allow to Add Item ");
                    txtBarcodeReaderBox.Text = "";
                    return;
                }

                if (txtBarcodeReaderBox.Text == "")
                {
                    //  MessageBox.Show("Please Insert Product id : ");
                    //textBox1.Focus();
                }
                else
                {
                    try
                    {
                        string product_id = "0", CustItemCode = "0";
                        int UOMID = 0;
                        string UOMName = "Piece";
                        if (txtBarcodeReaderBox.Text.Contains("~"))
                        {
                            string[] CustItemSplit = txtBarcodeReaderBox.Text.Split(',');
                            CustItemCode = CustItemSplit[1];

                            string[] strSplit = CustItemSplit[0].Split('~');
                            product_id = strSplit[0].Trim();
                            UOMName = strSplit[1].Trim();

                            UOMID = getuomid(UOMName);
                        }
                        else
                        {
                            string Sqlcheck = " select product_id,CustItemCode,UOMID  from purchase pi inner join tbl_item_uom_price iup ON pi.product_id = iup.itemID and pi.TenentID = iup.TenentID " +
                                         " where pi.TenentID = " + Tenent.TenentID + " and  pi.BarCode = " + txtBarcodeReaderBox.Text.Trim();
                            DataTable dtcheck = DataAccess.GetDataTable(Sqlcheck);
                            if (dtcheck.Rows.Count == 1)
                            {
                                CustItemCode = dtcheck.Rows[0]["CustItemCode"].ToString();
                                product_id = dtcheck.Rows[0]["product_id"].ToString();
                                UOMID = Convert.ToInt32(dtcheck.Rows[0]["UOMID"]); ;
                                UOMName = Add_Item.getuomName(UOMID);

                            }
                            else if (dtcheck.Rows.Count <= 0)
                            {
                                MessageBox.Show("Invalid Barcode ... ");
                                txtBarcodeReaderBox.Text = "";
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Found Multiple Recourd for this Barcode... ");
                                txtBarcodeReaderBox.Text = "";
                                return;
                            }
                        }


                        // Default tax rate 
                        double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                        //- new in 8.1 version // Default Product QTY is 1

                        int AllowMinusQty = DataAccess.checkMinus();
                        string sql = "";
                        if (AllowMinusQty == 1)
                        {
                            sql = " SELECT  product_name as Name , tbl_item_uom_price.msrp as Price , Receipe_menegement.msrp as RMSRP , 1.00  as QTY, tbl_item_uom_price.msrp  as 'Total' , " +
                                  " Receipe_menegement.msrp as 'RTotal' ,  (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00) as 'disamt' , " +
                                  " (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00) as 'Rdisamt' , " +
                                  " CASE WHEN taxapply = 1 THEN (((tbl_item_uom_price.msrp * 1.00 ) - (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'taxamt' , " +
                                  " CASE WHEN taxapply = 1 THEN (((Receipe_menegement.msrp * 1.00 ) - (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'Rtaxamt', " +
                                  " product_id as ID , Discount , taxapply, status,UOMID " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " LEFT JOIN Receipe_menegement ON tbl_item_uom_price.itemID = Receipe_menegement.ItemCode and tbl_item_uom_price.UOMID = Receipe_menegement.UOM and tbl_item_uom_price.TenentID = Receipe_menegement.TenentID " +
                                  " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + product_id + "' and UOMID = '" + UOMID + "' and CustItemCode = '" + CustItemCode + "' ";
                        }
                        else
                        {
                            sql = " SELECT  product_name as Name , tbl_item_uom_price.msrp as Price , Receipe_menegement.msrp as RMSRP , 1.00  as QTY, tbl_item_uom_price.msrp  as 'Total' , " +
                                  " Receipe_menegement.msrp as 'RTotal' ,  (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00) as 'disamt' , " +
                                  " (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00) as 'Rdisamt' , " +
                                  " CASE WHEN taxapply = 1 THEN (((tbl_item_uom_price.msrp * 1.00 ) - (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'taxamt' , " +
                                  " CASE WHEN taxapply = 1 THEN (((Receipe_menegement.msrp * 1.00 ) - (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'Rtaxamt', " +
                                  " product_id as ID , Discount , taxapply, status,UOMID " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " LEFT JOIN Receipe_menegement ON tbl_item_uom_price.itemID = Receipe_menegement.ItemCode and tbl_item_uom_price.UOMID = Receipe_menegement.UOM and tbl_item_uom_price.TenentID = Receipe_menegement.TenentID " +
                                  " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + product_id + "' and UOMID = '" + UOMID + "'  and CustItemCode = '" + CustItemCode + "'  and OnHand >= 1 ";
                        }

                        bool First = false;
                        double prodid = 0;
                        int QtyEn = 1;
                        string Batch = "", Serial = "";//yogesh

                        DataTable dt = DataAccess.GetDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            int rcount = dt.Rows.Count - 1;//yogesh
                            string Itemid = dt.Rows[rcount]["ID"].ToString();
                            string ProdName = dt.Rows[rcount]["Name"].ToString();
                            string ItemsName = CustItemCode + "-" + dt.Rows[rcount]["Name"].ToString() + "~" + UOMName;
                            double Rprice = 0;
                            if (lblIsReciepe.Text == "Yes")
                            {
                                Rprice = dt.Rows[rcount]["RMSRP"] != null && dt.Rows[rcount]["RMSRP"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["RMSRP"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["Price"].ToString());
                                lblIsReciepe.Text = "-";
                            }
                            else
                            {
                                Rprice = Convert.ToDouble(dt.Rows[rcount]["Price"].ToString());
                            }
                            //Yogesh April 19 dt.Rows[rcount]["RMSRP"] != null && dt.Rows[rcount]["RMSRP"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["RMSRP"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["Price"].ToString());
                            double Qty = Convert.ToDouble(dt.Rows[rcount]["QTY"].ToString());
                            double Total = dt.Rows[rcount]["RTotal"] != null && dt.Rows[rcount]["RTotal"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["RTotal"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["Total"].ToString());
                            double Disamt = 0;//yogesh dt.Rows[0]["Rdisamt"] != null && dt.Rows[0]["Rdisamt"].ToString() != "" ? Convert.ToDouble(dt.Rows[0]["Rdisamt"].ToString()) : Convert.ToDouble(dt.Rows[0]["disamt"].ToString());       //  Total Discount amount of this item
                            double Taxamt = dt.Rows[rcount]["Rtaxamt"] != null && dt.Rows[rcount]["Rtaxamt"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["Rtaxamt"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["taxamt"].ToString());       //  Total Tax amount  of this item
                            //double Dis = Convert.ToDouble(dt.Rows[rcount]["Discount"].ToString());yogesh       //  Discount Rate
                            double Taxapply = Convert.ToDouble(dt.Rows[rcount]["taxapply"].ToString());       //  VAT/TAX/TPS/TVQ apply or not
                            int kitchendisplay = Convert.ToInt32(dt.Rows[rcount]["status"].ToString());        //  kitchen display 3= show 1= not display in kitchen 

                            prodid = Convert.ToDouble(Itemid);
                            int UOMchk = getuomid(UOMName);
                            //Add to Item list
                            // long i = 1;
                            #region PeriSer
                            bool flagperi = IsPerishable(prodid);
                            bool flagSerial = IsSerialize(prodid);
                            int n = Finditem(ItemsName, CustItemCode, flagperi, flagSerial);
                            if (n == -1)  //If new item
                            {
                                if (flagperi == true)
                                {
                                    bool itemFound = BindPerishable(prodid, UOMchk);
                                    if (itemFound == true)
                                    {
                                        dgrvSalesItemList.ClearSelection();
                                        //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                                        dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode);
                                        int Rowcount = dgrvSalesItemList.Rows.Count - 1;
                                        dgrvSalesItemList.Rows[Rowcount].Selected = true;
                                        dgrvSalesItemList.FirstDisplayedScrollingRowIndex = Rowcount;

                                    }

                                }
                                else if (flagSerial == true)//yogesh
                                {
                                    bool itemFound = BindSerialize(prodid, UOMchk);
                                    if (itemFound == true)
                                    {
                                        dgrvSalesItemList.ClearSelection();
                                        //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                                        dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode);
                                        int Rowcount = dgrvSalesItemList.Rows.Count - 1;
                                        dgrvSalesItemList.Rows[Rowcount].Selected = true;
                                        dgrvSalesItemList.FirstDisplayedScrollingRowIndex = Rowcount;
                                    }
                                }
                                else if (!flagperi && !flagSerial)
                                {
                                    dgrvSalesItemList.ClearSelection();
                                    //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                                    dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode);
                                    //dgrvSalesItemList.CellClick += new EventHandler(dgrvSalesItemList_CellClick);
                                    int Rowcount = dgrvSalesItemList.Rows.Count - 1;
                                    dgrvSalesItemList.Rows[Rowcount].Selected = true;
                                    dgrvSalesItemList.FirstDisplayedScrollingRowIndex = Rowcount;
                                }

                            #endregion
                                QtyEn = Convert.ToInt32(Qty);
                                First = true;
                            }
                            else  // if same item Quantity increase by 1 
                            {

                                First = false;
                                //  dgrvSalesItemList.Rows[n].Cells[0].Value = ItemsName;
                                // dgrvSalesItemList.Rows[n].Cells[1].Value = Rprice;
                                #region PeriSer
                                double Prodid = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[4].Value);
                                bool flagpp = IsPerishable(Prodid);
                                bool flagss = IsSerialize(Prodid);
                                if (flagpp == true)
                                {
                                    string Batch_No = "";
                                    if (dgrvSalesItemList.Rows[n].Cells[10].Value != null)
                                        Batch_No = dgrvSalesItemList.Rows[n].Cells[10].Value.ToString();


                                    int OnHand = 0;
                                    if (dgrvSalesItemList.Rows[n].Cells[11].Value != null)
                                        OnHand = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[11].Value);


                                    int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                    QtyEn = (QtyInc + 1);
                                    if (OnHand >= QtyEn && OnHand != 0)
                                    {
                                        string MySysName = "SAL";
                                        int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                        dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                                        dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                                        //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                                        double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                        double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                                        if (disrate != 0)  // if discount has
                                        {
                                            double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                            dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                                        }

                                        if (Taxapply != 0)   // If apply  tax 
                                        {
                                            // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                                            double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                                            dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                                        }


                                        bool flagp = CheckPerishableTemp(Prodid, UOMID, Batch_No, MYTRANSID, MySysName);
                                        if (flagp == true)//Perisable yogesh
                                        {
                                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                            string sql1 = "Update ICIT_BR_TMP set NewQty='" + QtyEn + "', " +
                                                          " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                                          " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                            DataAccess.ExecuteSQL(sql1);
                                            Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMP", "UPDATE");
                                        }
                                        else
                                        {
                                            if (Application.OpenForms["SalesPerishable"] != null)
                                            {
                                                Application.OpenForms["SalesPerishable"].Close();
                                            }
                                            SalesPerishable mkc1 = new SalesPerishable(Prodid, ProdName, UOMName, MYTRANSID, MySysName, "");
                                            mkc1.Qty = QtyEn;
                                            mkc1.Show();
                                        }


                                    }
                                    //else
                                    //{

                                    //    MessageBox.Show("Batch " + Batch_No + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");
                                    //    First = true;
                                    //    Batch = Batch_No;
                                    //}
                                }
                                else if (flagss == true)
                                {
                                    //    string Serial_Number = "";

                                    //if (dgrvSalesItemList.Rows[n].Cells[17].Value != null)
                                    //    Serial_Number = dgrvSalesItemList.Rows[n].Cells[17].Value.ToString();

                                    //int OnHand = 0;
                                    //if (dgrvSalesItemList.Rows[n].Cells[11].Value != null && dgrvSalesItemList.Rows[n].Cells[11].Value!="")
                                    //    OnHand = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[11].Value);


                                    //int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                    //QtyEn = (QtyInc + 1);
                                    //if (OnHand >= QtyEn && OnHand != 0)
                                    //{
                                    string MySysName = "SAL";
                                    int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                    //    dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                                    //    dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                                    //    //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                                    //    double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                    //    double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                                    //if (disrate != 0)  // if discount has
                                    //{
                                    //    double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                    //    dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                                    //}

                                    //if (Taxapply != 0)   // If apply  tax 
                                    //{
                                    //    // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                                    //    double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                                    //    dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                                    //}                   

                                    //bool flags = CheckSerializeTemp(Prodid, UOMID, Serial_Number, MYTRANSID, MySysName);
                                    //if (flags)//Serialize yogesh
                                    //{
                                    //    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    //    string sql1 = "Update ICIT_BR_TMPSerialize set NewQty='" + QtyEn + "', " +
                                    //                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                    //                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                    //    DataAccess.ExecuteSQL(sql1);
                                    //    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "UPDATE");
                                    //}
                                    //else
                                    if (n == -1)  //If new item
                                    {
                                        if (Application.OpenForms["SalesSerialize"] != null)
                                        {
                                            Application.OpenForms["SalesSerialize"].Close();
                                        }
                                        SalesSerialize mkc1 = new SalesSerialize(Prodid, ProdName, UOMName, MYTRANSID, MySysName, "");
                                        mkc1.Qty = QtyEn;
                                        mkc1.Show();
                                    }
                                    else
                                    {
                                        txtBarcodeReaderBox.Text = "";
                                        MessageBox.Show("Already this Product in Container.");
                                        return;
                                    }

                                    //}

                                    //else
                                    //{

                                    //    MessageBox.Show("Serial " + Serial_Number + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");

                                    //    First = true;
                                    //    Serial = Serial_Number;
                                    //}

                                }
                                else
                                {
                                    int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                    dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                                    dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                                    //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                                    double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                    double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                                    if (disrate != 0)  // if discount has
                                    {
                                        double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                        dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                                    }

                                    if (Taxapply != 0)   // If apply  tax 
                                    {
                                        // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                                        double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                                        dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                                    }

                                }
                                #endregion
                                // dgrvSalesItemList.Rows[n].Cells[7].Value = Dis; // Discount rate
                                //  dgrvSalesItemList.Rows[n].Cells[8].Value = Taxapply;  //Tax apply
                                //  dgrvSalesItemList.Rows[n].Cells[9].Value = kitchendisplay;

                            }
                        }

                        //Hide fields
                        dgrvSalesItemList.Columns[4].Visible = false; // ID             // new in 8.1 version
                        dgrvSalesItemList.Columns[5].Visible = false; // Disamt         // new in 8.1 version
                        dgrvSalesItemList.Columns[6].Visible = false; // taxamt         // new in 8.1 version
                        // dgrvSalesItemList.Columns[7].Visible = false; // Discount rate  // new in 8.1 version yogesh
                        dgrvSalesItemList.Columns[9].Visible = false; // kitdisplay    // new in 8.3.1 version

                        dgrvSalesItemList.Columns[10].Visible = false; // BatchNo    
                        dgrvSalesItemList.Columns[11].Visible = false; // OnHand    
                        dgrvSalesItemList.Columns[12].Visible = false; // ExpiryDate

                        dgrvSalesItemList.Columns[13].Visible = false; // SalesID    
                        dgrvSalesItemList.Columns[14].Visible = false; // invoice 
                        dgrvSalesItemList.Columns[15].Visible = false; // CID  
                        dgrvSalesItemList.Columns[17].Visible = true; // SerailNo
                        txtBarcodeReaderBox.Text = "";
                        txtBarcodeReaderBox.Focus();

                        btnSuspend.Enabled = true;
                        btnCashAndPrint.Enabled = true;
                        if (lblIsCustAdvanceAmtYN.Text == ".")
                            btnSalesCredit.Enabled = false;
                        else
                            btnSalesCredit.Enabled = true;

                        DiscountCalculation();
                        vatcal();
                        txtDiscountRate.Text = "0";

                        if (First == true)
                        {
                            #region PeriSer
                            bool flag = IsPerishable(prodid);
                            if (flag == true)
                            {
                                string ProdName = GetProdName(prodid);
                                string MySysName = "SAL";
                                int MY_TRANS_ID = Convert.ToInt32(txtInvoice.Text);

                                if (Application.OpenForms["SalesPerishable"] != null)
                                {
                                    Application.OpenForms["SalesPerishable"].Close();
                                }
                                SalesPerishable mkc1 = new SalesPerishable(prodid, ProdName, UOMName, MY_TRANS_ID, MySysName, Batch);
                                mkc1.Qty = QtyEn;
                                mkc1.Show();
                            }
                            bool flagss = IsSerialize(prodid);
                            if (flagss == true)
                            {
                                string ProdName = GetProdName(prodid);
                                string MySysName = "SAL";
                                int MY_TRANS_ID = Convert.ToInt32(txtInvoice.Text);

                                if (Application.OpenForms["SalesSerialize"] != null)
                                {
                                    Application.OpenForms["SalesSerialize"].Close();
                                }
                                SalesSerialize mkc1 = new SalesSerialize(prodid, ProdName, UOMName, MY_TRANS_ID, MySysName, Serial);
                                mkc1.Qty = QtyEn;
                                mkc1.Show();
                            }
                            #endregion
                        }
                    }
                    catch
                    {
                        // MessageBox.Show("Problem in Barcode ");
                        txtBarcodeReaderBox.Text = "";
                        return;
                    }

                }
            }
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(BookingInvoice);
                threadInput.Start();
         
            }
            catch (Exception ex)
            {
            }
        }


        public void BookingInvoice()
        {
          //  SetLoadingForItem(true);

            // Added to see the indicator (not required)
            //Thread.Sleep(1);

            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (lblTotalPayable.Text == "00" || lblTotalPayable.Text == "0" || lblTotalPayable.Text == string.Empty)
                    {
                        MessageBox.Show("Sorry ! You don't have enough product in Item cart \n  Please Add to cart", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        return;
                    }

                    if (comboSalesMan.Text == "")
                    {
                        MessageBox.Show("Sorry ! Please Select oeder Way:", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        return;
                    }
                    else
                    {
                        getInvoiceno();

                        decimal TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                        decimal Payamount = Convert.ToDecimal(txtcashRecived.Text);
                        decimal ChangeAmount = 0;
                        decimal dueAmount = 0;


                        if (TotalPayable > Payamount)
                        {
                            decimal due = TotalPayable - Payamount;
                            dueAmount = due;
                        }
                        else if (Payamount > TotalPayable)
                        {
                            decimal change = Payamount - TotalPayable;
                            ChangeAmount = change;
                        }
                        else
                        {
                            dueAmount = 0;
                            ChangeAmount = 0;

                        }

                        //payment_item(Payamount, ChangeAmount, dueAmount, "Cash", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), "10000009", "Gest");

                        ///// save sales items one by one  

                        string Invo = lblInvoiceNO.Text;

                        string TransDate = "";

                        TransDate = dtSalesDate.Text != "" ? dtSalesDate.Text : dtsaleDate.Text != "" ? dtsaleDate.Text : DateTime.Now.ToString("yyyy-MM-dd");

                        int sales_id = Convert.ToInt32(txtInvoice.Text);
                        bool creditFalg = isCreditInvoice(sales_id);
                        if (creditFalg == false)
                        {
                            sales_item(TransDate, "Not Paid Booking Order Taken", 0, "Booking", txtComment.Text);

                            string ActivityName = "sales Booking Transaction";
                            string LogData = "Save Sales Transaction as Booking with InvoiceNO = " + Invo + "and Cust_Code=" + lblCustID.Text + " and OrderTotal =" + TotalPayable + " ";
                            Login.InsertUserLog(ActivityName, LogData);
                        }

                        parameter.autoprintid = "1";
                        //POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                        //go.ShowDialog();
                        string salesID = txtInvoice.Text.Trim();
                        string File = SalesRegister.getPrintFile("Cash"); // Cash , Creadit , Kitchen
                        string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash"); // Cash , Credit , Kitchen
                        SalesRegister.PRintInvoice1(salesID, File, DefaultPrinter);
                        clearInvoice();
                        manageInvoice();

                        //dgrvSalesItemList.Rows.Clear();
                        //txtDiscountRate.Text = "0";
                        //DiscountCalculation();
                        //vatcal();
                        //Last30daysReport(dtStartDate.Text);
                        //this.tabPageSR_Payment.Parent = null; //Hide payment tab 

                        //this.tabPageSR_Split_Bill.Parent = null; //Hide Split tab
                        //tabSRcontrol.SelectedTab = tabPageSR_Counter;

                        //txtCustomer.Text = "Cash";
                        //GridPayment.Rows.Clear();
                        //lblPaid.Text = "0";
                        //txtcashRecived.Text = "";
                        //lblChangeAmt.Text = "0";
                        //lblCustID.Text = "1";
                        //dtSalesDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        //dtsaleDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                        //UserInfo.EditTransation = false;
                        //UserInfo.Invoice = 0;
                        //UserInfo.InvoicetransNO = null;

                        //    scope.Complete();
                        //}
                       // timerinvoiceno();
                    }



                });

            }
            catch
            {

            }

            //SetLoadingForItem(false);
        }

        private void btnCustCode_Click(object sender, EventArgs e)
        {
            CustCodeSearch();
            SeearchNo = 1;
        }

        private void txtSearchCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    CustCodeSearch();
                }
                catch (Exception ex)
                {
                }

            }
        }

        private void txtInvoiceCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    CashirTestSearch();
                }
                catch (Exception ex)
                {
                }

            }
        }

        private void txtSearchCustCode_Leave(object sender, EventArgs e)
        {
            try
            {
                CustCodeSearch();

            }
            catch (Exception ex)
            {
            }
        }

        private void radioCash_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCash.Checked == true)
            {
                chkCreditTrans.Checked = false;
                btnCashAndPrint.Text = "Cash / Print";
                radiocredit.Checked = false;

            }

        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CustomerSearch4Cashier"] != null)
            {
                Application.OpenForms["CustomerSearch4Cashier"].Close();
            }
            this.Refresh();

            CustomerSearch4Cashier go = new CustomerSearch4Cashier();
            go.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CustomerSearch4Cashier"] != null)
            {
                Application.OpenForms["CustomerSearch4Cashier"].Close();
            }
            this.Refresh();

            CustomerSearch4Cashier go = new CustomerSearch4Cashier();
            go.Show();
        }
        public void manageInvoice()
        {
            int year = DateTime.Now.Year;
            string terminal = UserInfo.Shopid;

            //lblInvoiceNO.Text = Sales_ID + "/" + terminal + "/" + year;
            //lblInvoiceNOPAY.Text = Sales_ID + "/" + terminal + "/" + year;
            string sqlCmd = "select sales_id as SI ,InvoiceNo from sales_item where sales_id || '" + "/" + terminal + "/" + year + "' <> InvoiceNo and InvoiceNo like '%" + year + "%';";

            DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
            if (dt1.Rows.Count > 0)
            {
                string sql1 = "update sales_item  set InvoiceNo=(select b.sales_id || '" + "/" + terminal + "/" + year + "' as SI from sales_item as b where b.sales_id = sales_item.sales_id and b.InvoiceNo like '%" + year + "%') where InvoiceNo like '%" + year + "%';" +
                                "update sales_payment  set InvoiceNo=(select b.sales_id || '" + "/" + terminal + "/" + year + "' as SI from sales_payment as b where b.sales_id = sales_payment.sales_id and b.InvoiceNo like '%" + year + "%') where InvoiceNo like '%" + year + "%';";
                DataAccess.GetDataTable(sql1);
                Login.InsertUserLog("Invoice Maitanance", "Invoice Maitanance for Sales_item and Sales_Payment");
            }
        }

      

        private void txtTerminalAdvance_Leave(object sender, EventArgs e)
        {
            txtTerminalAdvance.Text = txtTerminalAdvance.Text == "" ? "0" : txtTerminalAdvance.Text;
            decimal firstTotal = Convert.ToDecimal(lblTotal.Text);//first Total
            decimal txtDis = lbloveralldiscount.Text == "" ? 0 : Convert.ToDecimal(lbloveralldiscount.Text);//discount
            decimal deliverycharge = Convert.ToDecimal(lblDeliveryChargis.Text);//deliverycharge
            decimal TotalPayable = 0;


            if (txtTerminalAdvance.Text != "" && txtTerminalAdvance.Text != "0" && txtTerminalAdvance.Text != ".")
            {
                if (lblCustID.Text == "1")
                {
                    txtTerminalAdvance.Text = "0";
                    MyMessageAlert.ShowBox("Please Select Customer Rather than Cash Or Gest .", "Alert");

                    if (Application.OpenForms["CustomerSearch"] != null)
                    {
                        Application.OpenForms["CustomerSearch"].Close();
                    }
                    this.Refresh();

                    CustomerSearch go = new CustomerSearch();
                    go.Show();
                    return;

                }
                else
                {
                    lbloveralldiscount.Enabled = false;
                    txtDiscountRate.Enabled = false;
                    //txtcashRecived.Enabled = false;

                    chkCreditTrans.Checked = true;
                    radiocredit.Checked = true;
                    radioCash.Checked = false;
                }

                btnCashAndPrint.Text = "Credit/Print";
                lblIsCustAdvanceAmtYN.Text = ".";
                btnBooking.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnBooking.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnSalesCredit.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                radiocredit.Enabled = false;

                decimal TerminalAdvance = Convert.ToDecimal(txtTerminalAdvance.Text);//advance

                if (TerminalAdvance <= firstTotal)
                {
                    if (txtDis != 0)
                        TerminalAdvance += txtDis;
                    decimal change = firstTotal - TerminalAdvance;
                    lblTotalPayable.Text = change.ToString();
                }
                else
                {
                    txtTerminalAdvance.Text = "0";
                    lblTotalPayable.Text = txtcashRecived.Text = firstTotal.ToString();
                    return;
                }

            }
            else
            {
                TotalPayable = Convert.ToDecimal(lblTotalPayable.Text);
                TotalPayable = firstTotal - txtDis;
                TotalPayable -= deliverycharge;
                lblTotalPayable.Text = txtcashRecived.Text = TotalPayable.ToString("N2");
                lbloveralldiscount.Enabled = true;
                txtDiscountRate.Enabled = true;
                txtcashRecived.Enabled = true;

                btnCashAndPrint.Text = "Cash / Print";
                lblIsCustAdvanceAmtYN.Text = "-";
                btnBooking.BackColor = Color.FromKnownColor(KnownColor.Orange);
                btnBooking.Enabled = true;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.SeaGreen);
                btnSalesCredit.Enabled = true;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.PaleGreen);
                btnCOD.Enabled = true;


                chkCreditTrans.Checked = false;
                radiocredit.Checked = false;
                radioCash.Checked = true;
            }

            GridPayment.Rows.Clear();
            if (txtTerminalAdvance.Text != "" && txtTerminalAdvance.Text != "0" && txtTerminalAdvance.Text != ".")
            {
                decimal TerminalAdvance = Convert.ToDecimal(txtTerminalAdvance.Text);//advance
                string Sales_ID = get_sales_id();
                GridPayment.Rows.Add(Sales_ID, "Cash", "", TerminalAdvance);
                txtcashRecived.Focus();
            }
        }

        private void lbloveralldiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPageSR_Counter_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelItemListButton_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnItemGrid_Click(object sender, EventArgs e)
        {
         
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnItemButton_Click(object sender, EventArgs e)
        {
            chkbutton.Checked = true;
            chkWithGrid.Checked = false;
            chkImage.Checked = false;
            flowLayoutPanelItemListButton.Visible = true;

            flowLayoutPanelItemList.Visible = false;
 
        }

        private void btnrelateditem_Click(object sender, EventArgs e)
        {
          
        }

        private void btncategories_Click(object sender, EventArgs e)
        {
           
            // for package    ItemList_with_Package();
        }

        private void btnImages_Click(object sender, EventArgs e)
        {
            chkImage.Checked = true;
            chkWithGrid.Checked = false;
            chkbutton.Checked = false;
            flowLayoutPanelItemListButton.Visible = false;
          
            flowLayoutPanelItemList.Visible = true;
  
        }

        private void PanelCatagories_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextItemSearch();
        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            clearInvoice();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            if (btnimg.Text == "Show Images")
            {
                btnImages_Click(null, null);
                btnimg.Text = "Show Buttons";
   
            }
            else

            {
                btnItemButton_Click(null, null);
                btnimg.Text = "Show Images";
              
            }
        }

        private void txtSearchItem_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchItem.TextLength > 2)
            { 
            TextItemSearch();
            }
        }

        private void txtBarcodeReaderBox_TextChanged_1(object sender, EventArgs e)
        {
            if (txtBarcodeReaderBox.Text.Trim() == string.Empty) { return; }
            bool flagperi = true;
            bool flagSerial = true;
            string productname = "";
            int UOMID = 0;
            int Sales_id = Convert.ToInt32(txtInvoice.Text);
          //  bool ISPaymentCredit = CheckISPaymentCredit(Sales_id);
           // if (ISPaymentCredit == true)
           // {
           //     MessageBox.Show(" This Invoice is Creadit invoice It Not Allow to Add Item ");
           //     txtBarcodeReaderBox.Text = "";
           //     return;
           // }

          
                try
                {
                    string product_id = "0", CustItemCode = "0";

                    string UOMName = "Piece";
                    if (txtBarcodeReaderBox.Text.Contains("~"))
                    {
                        string[] CustItemSplit = txtBarcodeReaderBox.Text.Split(',');
                        CustItemCode = CustItemSplit[1];

                        string[] strSplit = CustItemSplit[0].Split('~');
                        product_id = strSplit[0].Trim();
                        UOMName = strSplit[1].Trim();

                        UOMID = getuomid(UOMName);
                    }
                    else
                    {
                        string Sqlcheck = " select product_id,CustItemCode,UOMID  from purchase pi inner join tbl_item_uom_price iup ON pi.product_id = iup.itemID and pi.TenentID = iup.TenentID " +
                                     " where pi.TenentID = " + Tenent.TenentID + " and  pi.BarCode = " + txtBarcodeReaderBox.Text.Trim();
                        DataTable dtcheck = DataAccess.GetDataTable(Sqlcheck);
                        if (dtcheck.Rows.Count == 1)
                        {
                            CustItemCode = dtcheck.Rows[0]["CustItemCode"].ToString();
                            product_id = dtcheck.Rows[0]["product_id"].ToString();
                            UOMID = Convert.ToInt32(dtcheck.Rows[0]["UOMID"]); ;
                            UOMName = Add_Item.getuomName(UOMID);

                        }
                        else if (dtcheck.Rows.Count == 0)
                        {
                            MessageBox.Show("Invalid Barcode ... ");
                            txtBarcodeReaderBox.Text = "";
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Found Multiple Recourd for this Barcode... ");
                            txtBarcodeReaderBox.Text = "";
                            return;
                        }
                    }


                    // Default tax rate 
                    double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                    //- new in 8.1 version // Default Product QTY is 1

                    int AllowMinusQty = DataAccess.checkMinus();
                    string sql = "";
                    if (_Tab == 1)
                    {
                        sql = " SELECT  product_name as Name , tbl_item_uom_price.msrp as Price , Receipe_menegement.msrp as RMSRP , 1.00  as QTY, tbl_item_uom_price.msrp  as 'Total' , " +
                             " Receipe_menegement.msrp as 'RTotal' ,  (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00) as 'disamt' , " +
                             " (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00) as 'Rdisamt' , " +
                             " CASE WHEN taxapply = 1 THEN (((tbl_item_uom_price.msrp * 1.00 ) - (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'taxamt' , " +
                             " CASE WHEN taxapply = 1 THEN (((Receipe_menegement.msrp * 1.00 ) - (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'Rtaxamt', " +
                             " product_id as ID , Discount , taxapply, status,UOMID,Receipe_menegement.IOSwitch " +
                             " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                             " LEFT JOIN Receipe_menegement ON tbl_item_uom_price.itemID = Receipe_menegement.ItemCode and tbl_item_uom_price.UOMID = Receipe_menegement.UOM and tbl_item_uom_price.TenentID = Receipe_menegement.TenentID " +
                             " where   Receipe_menegement.IOSwitch='Output' and purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + product_id + "' and UOMID = '" + UOMID + "' and CustItemCode = '" + CustItemCode + "' ";
                    }
                    else
                    {
                        if (AllowMinusQty == 1)
                        {
                            sql = " SELECT  product_name as Name , tbl_item_uom_price.msrp as Price , Receipe_menegement.msrp as RMSRP , 1.00  as QTY, tbl_item_uom_price.msrp  as 'Total' , " +
                                  " Receipe_menegement.msrp as 'RTotal' ,  (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00) as 'disamt' , " +
                                  " (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00) as 'Rdisamt' , " +
                                  " CASE WHEN taxapply = 1 THEN (((tbl_item_uom_price.msrp * 1.00 ) - (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'taxamt' , " +
                                  " CASE WHEN taxapply = 1 THEN (((Receipe_menegement.msrp * 1.00 ) - (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'Rtaxamt', " +
                                  " product_id as ID , Discount , taxapply, status,UOMID " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " LEFT JOIN Receipe_menegement ON tbl_item_uom_price.itemID = Receipe_menegement.ItemCode and tbl_item_uom_price.UOMID = Receipe_menegement.UOM and tbl_item_uom_price.TenentID = Receipe_menegement.TenentID " +
                                  " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + product_id + "' and UOMID = '" + UOMID + "' and CustItemCode = '" + CustItemCode + "' ";
                        }
                        else
                        {
                            sql = " SELECT  product_name as Name , tbl_item_uom_price.msrp as Price , Receipe_menegement.msrp as RMSRP , 1.00  as QTY, tbl_item_uom_price.msrp  as 'Total' , " +
                                  " Receipe_menegement.msrp as 'RTotal' ,  (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00) as 'disamt' , " +
                                  " (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00) as 'Rdisamt' , " +
                                  " CASE WHEN taxapply = 1 THEN (((tbl_item_uom_price.msrp * 1.00 ) - (((tbl_item_uom_price.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'taxamt' , " +
                                  " CASE WHEN taxapply = 1 THEN (((Receipe_menegement.msrp * 1.00 ) - (((Receipe_menegement.msrp * 1.00 ) * Discount) / 100.00))  * " + Taxrate + " ) / 100.00    ELSE '0.00'  END 'Rtaxamt', " +
                                  " product_id as ID , Discount , taxapply, status,UOMID " +
                                  " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                                  " LEFT JOIN Receipe_menegement ON tbl_item_uom_price.itemID = Receipe_menegement.ItemCode and tbl_item_uom_price.UOMID = Receipe_menegement.UOM and tbl_item_uom_price.TenentID = Receipe_menegement.TenentID " +
                                  " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + product_id + "' and UOMID = '" + UOMID + "'  and CustItemCode = '" + CustItemCode + "'  and OnHand >= 1 ";
                        }
                    }
                    bool First = false;
                    double prodid = 0;
                    int QtyEn = 1;
                    string Batch = "", Serial = "";//yogesh

                    DataTable dt = DataAccess.GetDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        int rcount = dt.Rows.Count - 1;//yogesh
                        string Itemid = dt.Rows[rcount]["ID"].ToString();
                        string ProdName = dt.Rows[rcount]["Name"].ToString();
                        string ItemsName = CustItemCode + "-" + dt.Rows[rcount]["Name"].ToString() + "~" + UOMName;
                        double Rprice = 0;
                        // if (lblIsReciepe.Text == "Yes")
                        if (_Tab == 1) //package price check
                        {
                            Rprice = dt.Rows[rcount]["RMSRP"] != null && dt.Rows[rcount]["RMSRP"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["RMSRP"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["Price"].ToString());
                            lblIsReciepe.Text = "-";
                        }
                        else
                        {
                            Rprice = Convert.ToDouble(dt.Rows[rcount]["Price"].ToString());
                        }
                        //Yogesh April 19 dt.Rows[rcount]["RMSRP"] != null && dt.Rows[rcount]["RMSRP"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["RMSRP"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["Price"].ToString());
                        double Qty = Convert.ToDouble(dt.Rows[rcount]["QTY"].ToString());
                        double Total = dt.Rows[rcount]["RTotal"] != null && dt.Rows[rcount]["RTotal"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["RTotal"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["Total"].ToString());
                        double Disamt = 0;//yogesh dt.Rows[0]["Rdisamt"] != null && dt.Rows[0]["Rdisamt"].ToString() != "" ? Convert.ToDouble(dt.Rows[0]["Rdisamt"].ToString()) : Convert.ToDouble(dt.Rows[0]["disamt"].ToString());       //  Total Discount amount of this item
                        double Taxamt = dt.Rows[rcount]["Rtaxamt"] != null && dt.Rows[rcount]["Rtaxamt"].ToString() != "" ? Convert.ToDouble(dt.Rows[rcount]["Rtaxamt"].ToString()) : Convert.ToDouble(dt.Rows[rcount]["taxamt"].ToString());       //  Total Tax amount  of this item
                        //double Dis = Convert.ToDouble(dt.Rows[rcount]["Discount"].ToString());yogesh       //  Discount Rate
                        double Taxapply = Convert.ToDouble(dt.Rows[rcount]["taxapply"].ToString());       //  VAT/TAX/TPS/TVQ apply or not
                        int kitchendisplay = Convert.ToInt32(dt.Rows[rcount]["status"].ToString());        //  kitchen display 3= show 1= not display in kitchen 

                        prodid = Convert.ToDouble(Itemid);
                        int UOMchk = UOMID;// getuomid(UOMName);
                                           //Add to Item list
                                           // long i = 1;
                        #region PeriSer
                        IsPerishablesale(prodid, out flagperi, out flagSerial, out productname);
                    //  bool flagSerial = IsSerialize(prodid);
                    int n =  Finditem(ItemsName, CustItemCode, flagperi, flagSerial);
                        if (n == -1)  //If new item
                        {
                            if (flagperi == true)
                            {
                                bool itemFound = BindPerishable(prodid, UOMchk);
                                if (itemFound == true)
                                {
                                    dgrvSalesItemList.ClearSelection();
                                    //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                                    dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode);
                                    int Rowcount = dgrvSalesItemList.Rows.Count - 1;
                                    dgrvSalesItemList.Rows[Rowcount].Selected = true;
                                    dgrvSalesItemList.FirstDisplayedScrollingRowIndex = Rowcount;

                                }

                            }
                            else if (flagSerial == true)//yogesh
                            {
                                bool itemFound = BindSerialize(prodid, UOMchk);
                                if (itemFound == true)
                                {
                                    dgrvSalesItemList.ClearSelection();
                                    //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                                    dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode);
                                    int Rowcount = dgrvSalesItemList.Rows.Count - 1;
                                    dgrvSalesItemList.Rows[Rowcount].Selected = true;
                                    dgrvSalesItemList.FirstDisplayedScrollingRowIndex = Rowcount;
                                }
                            }
                            else if (!flagperi && !flagSerial)
                            {
                                dgrvSalesItemList.ClearSelection();
                                //dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                                dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, "0", Taxapply, kitchendisplay, "", "", "", "", "", "", CustItemCode);
                                //dgrvSalesItemList.CellClick += new EventHandler(dgrvSalesItemList_CellClick);
                                int Rowcount = dgrvSalesItemList.Rows.Count - 1;
                                dgrvSalesItemList.Rows[Rowcount].Selected = true;
                                dgrvSalesItemList.FirstDisplayedScrollingRowIndex = Rowcount;
                            }

                            #endregion
                            QtyEn = Convert.ToInt32(Qty);
                            First = true;
                        }
                        else  // if same item Quantity increase by 1 
                        {

                            First = false;
                            //  dgrvSalesItemList.Rows[n].Cells[0].Value = ItemsName;
                            // dgrvSalesItemList.Rows[n].Cells[1].Value = Rprice;
                            #region PeriSer
                            double Prodid = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[4].Value);
                            bool flagpp = flagperi; //IsPerishable(Prodid);
                            bool flagss = flagSerial; //IsSerialize(Prodid);
                            if (flagpp == true)
                            {
                                string Batch_No = "";
                                if (dgrvSalesItemList.Rows[n].Cells[10].Value != null)
                                    Batch_No = dgrvSalesItemList.Rows[n].Cells[10].Value.ToString();


                                int OnHand = 0;
                                if (dgrvSalesItemList.Rows[n].Cells[11].Value != null)
                                    OnHand = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[11].Value);


                                int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                QtyEn = (QtyInc + 1);
                                if (OnHand >= QtyEn && OnHand != 0)
                                {
                                    string MySysName = "SAL";
                                    int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                    dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                                    dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                                    //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                                    double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                    double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                                    if (disrate != 0)  // if discount has
                                    {
                                        double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                        dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                                    }

                                    if (Taxapply != 0)   // If apply  tax 
                                    {
                                        // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                                        double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                                        dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                                    }


                                    bool flagp = CheckPerishableTemp(Prodid, UOMID, Batch_No, MYTRANSID, MySysName);
                                    if (flagp == true)//Perisable yogesh
                                    {
                                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        string sql1 = "Update ICIT_BR_TMP set NewQty='" + QtyEn + "', " +
                                                      " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                                      " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                        DataAccess.ExecuteSQL(sql1);
                                        Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMP", "UPDATE");
                                    }
                                    else
                                    {
                                        if (Application.OpenForms["SalesPerishable"] != null)
                                        {
                                            Application.OpenForms["SalesPerishable"].Close();
                                        }
                                        SalesPerishable mkc1 = new SalesPerishable(Prodid, ProdName, UOMName, MYTRANSID, MySysName, "");
                                        mkc1.Qty = QtyEn;
                                        mkc1.Show();
                                    }


                                }
                                //else
                                //{

                                //    MessageBox.Show("Batch " + Batch_No + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");
                                //    First = true;
                                //    Batch = Batch_No;
                                //}
                            }
                            else if (flagss == true)
                            {
                                //    string Serial_Number = "";

                                //if (dgrvSalesItemList.Rows[n].Cells[17].Value != null)
                                //    Serial_Number = dgrvSalesItemList.Rows[n].Cells[17].Value.ToString();

                                //int OnHand = 0;
                                //if (dgrvSalesItemList.Rows[n].Cells[11].Value != null && dgrvSalesItemList.Rows[n].Cells[11].Value!="")
                                //    OnHand = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[11].Value);


                                //int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                //QtyEn = (QtyInc + 1);
                                //if (OnHand >= QtyEn && OnHand != 0)
                                //{
                                string MySysName = "SAL";
                                int MYTRANSID = Convert.ToInt32(txtInvoice.Text);

                                //    dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                                //    dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                                //    //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                                //    double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                //    double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                                //if (disrate != 0)  // if discount has
                                //{
                                //    double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                //    dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                                //}

                                //if (Taxapply != 0)   // If apply  tax 
                                //{
                                //    // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                                //    double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                                //    dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                                //}                   

                                //bool flags = CheckSerializeTemp(Prodid, UOMID, Serial_Number, MYTRANSID, MySysName);
                                //if (flags)//Serialize yogesh
                                //{
                                //    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                //    string sql1 = "Update ICIT_BR_TMPSerialize set NewQty='" + QtyEn + "', " +
                                //                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                //                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + Prodid + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                                //    DataAccess.ExecuteSQL(sql1);
                                //    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "UPDATE");
                                //}
                                //else
                                if (n == -1)  //If new item
                                {
                                    if (Application.OpenForms["SalesSerialize"] != null)
                                    {
                                        Application.OpenForms["SalesSerialize"].Close();
                                    }
                                    SalesSerialize mkc1 = new SalesSerialize(Prodid, ProdName, UOMName, MYTRANSID, MySysName, "");
                                    mkc1.Qty = QtyEn;
                                    mkc1.Show();
                                }
                                else
                                {
                                    txtBarcodeReaderBox.Text = "";
                                    MessageBox.Show("Already this Product in Container.");
                                    return;
                                }

                                //}

                                //else
                                //{

                                //    MessageBox.Show("Serial " + Serial_Number + " Have Qty " + OnHand + " ; To Add More Qty choose a Different Batch");

                                //    First = true;
                                //    Serial = Serial_Number;
                                //}

                            }
                            else
                            {
                                int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                                dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                                //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                                double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                                double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                                if (disrate != 0)  // if discount has
                                {
                                    double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                    dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                                }

                                if (Taxapply != 0)   // If apply  tax 
                                {
                                    // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                                    double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                                    dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                                }

                            }
                            #endregion
                            // dgrvSalesItemList.Rows[n].Cells[7].Value = Dis; // Discount rate
                            //  dgrvSalesItemList.Rows[n].Cells[8].Value = Taxapply;  //Tax apply
                            //  dgrvSalesItemList.Rows[n].Cells[9].Value = kitchendisplay;

                        }
                    }

                    //Hide fields
                   // dgrvSalesItemList.Columns[4].Visible = false; // ID             // new in 8.1 version
                   // dgrvSalesItemList.Columns[5].Visible = false; // Disamt         // new in 8.1 version
                   // dgrvSalesItemList.Columns[6].Visible = false; // taxamt         // new in 8.1 version
                   // // dgrvSalesItemList.Columns[7].Visible = false; // Discount rate  // new in 8.1 version yogesh
                   // dgrvSalesItemList.Columns[9].Visible = false; // kitdisplay    // new in 8.3.1 version
                   //
                   // dgrvSalesItemList.Columns[10].Visible = false; // BatchNo    
                   // dgrvSalesItemList.Columns[11].Visible = false; // OnHand    
                   // dgrvSalesItemList.Columns[12].Visible = false; // ExpiryDate
                   //
                   // dgrvSalesItemList.Columns[13].Visible = false; // SalesID    
                   // dgrvSalesItemList.Columns[14].Visible = false; // invoice 
                   // dgrvSalesItemList.Columns[15].Visible = false; // CID  
                   // dgrvSalesItemList.Columns[17].Visible = false; // SerailNo
                   // dgrvSalesItemList.Columns[18].Visible = false; // ItemNote
                    txtBarcodeReaderBox.Text = "";
                    txtBarcodeReaderBox.Focus();

                    btnSuspend.Enabled = true;
                    btnCashAndPrint.Enabled = true;
                    if (lblIsCustAdvanceAmtYN.Text == ".")
                         btnSalesCredit.Enabled = false;
                    else
                        btnSalesCredit.Enabled = true;


                    DiscountCalculation();
                    vatcal();
                    txtDiscountRate.Text = "0";

                    if (First == true)
                    {
                        #region PeriSer
                        bool flag = flagperi;// IsPerishable(prodid);
                        if (flag == true)
                        {
                            string ProdName = productname; // GetProdName(prodid);
                            string MySysName = "SAL";
                            int MY_TRANS_ID = Convert.ToInt32(txtInvoice.Text);

                            if (Application.OpenForms["SalesPerishable"] != null)
                            {
                                Application.OpenForms["SalesPerishable"].Close();
                            }
                            SalesPerishable mkc1 = new SalesPerishable(prodid, ProdName, UOMName, MY_TRANS_ID, MySysName, Batch);
                            mkc1.Qty = QtyEn;
                            mkc1.Show();
                        }
                        bool flagss = flagSerial;// IsSerialize(prodid);
                        if (flagss == true)
                        {
                            string ProdName = productname;// GetProdName(prodid);
                            string MySysName = "SAL";
                            int MY_TRANS_ID = Convert.ToInt32(txtInvoice.Text);

                            if (Application.OpenForms["SalesSerialize"] != null)
                            {
                                Application.OpenForms["SalesSerialize"].Close();
                            }
                            SalesSerialize mkc1 = new SalesSerialize(prodid, ProdName, UOMName, MY_TRANS_ID, MySysName, Serial);
                            mkc1.Qty = QtyEn;
                            mkc1.Show();
                        }
                        #endregion
                    }
                }
                catch
                {
                    // MessageBox.Show("Problem in Barcode ");
                    txtBarcodeReaderBox.Text = "";
                    return;
                }

        }

       

        private void tabPageSR_Counterb_Click(object sender, EventArgs e)
        {
            tabSRcontrol.SelectedTab = tabPageSR_Counter;
        }

        private void tabPageSR_Paymentb_Click(object sender, EventArgs e)
        {
            tabSRcontrol.SelectedTab = tabPageSR_Payment;
        }

        private void tabPageSR_Split_Billb_Click(object sender, EventArgs e)
        {
            tabSRcontrol.SelectedTab = tabPageSR_Split_Bill;
        }

        private void tabCashierb_Click(object sender, EventArgs e)
        {
            tabSRcontrol.SelectedTab = tabCashier;
        }

        private void tabDeliveryb_Click(object sender, EventArgs e)
        {
            tabSRcontrol.SelectedTab = tabDelivery;
        }

        private void flwLyoutCategoryPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
