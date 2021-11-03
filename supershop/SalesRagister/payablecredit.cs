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
    public partial class payablecredit : Form
    {
        public payablecredit()
        {
            InitializeComponent();
            dtReceiveDate.Format = DateTimePickerFormat.Custom;
            dtReceiveDate.CustomFormat = "yyyy-MM-dd";

            //GridList


            this.dataGridView1.Columns.Add("Invoice", "Invoice");
            dataGridView1.Columns["Invoice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Invoice"].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns["Invoice"].DefaultCellStyle.BackColor = Color.Silver;
            dataGridView1.Columns["Invoice"].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns["Invoice"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView1.Columns["Invoice"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView1.Columns["Invoice"].Width = 100;
            dataGridView1.Columns["Invoice"].ReadOnly = true;



            this.dataGridView1.Columns.Add("SaleDate", "SaleDate");
            dataGridView1.Columns["SaleDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["SaleDate"].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns["SaleDate"].DefaultCellStyle.BackColor = Color.Silver;
            dataGridView1.Columns["SaleDate"].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns["SaleDate"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView1.Columns["SaleDate"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView1.Columns["SaleDate"].ReadOnly = true;
            dataGridView1.Columns["SaleDate"].Width = 100;

            this.dataGridView1.Columns.Add("Amount", "Amount");
            dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Amount"].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns["Amount"].DefaultCellStyle.BackColor = Color.Silver;
            dataGridView1.Columns["Amount"].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns["Amount"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView1.Columns["Amount"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView1.Columns["Amount"].ReadOnly = true;
            dataGridView1.Columns["Amount"].Width = 75;

            this.dataGridView1.Columns.Add("Pay", "Pay");
            dataGridView1.Columns["Pay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Pay"].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns["Pay"].DefaultCellStyle.BackColor = Color.Silver;
            dataGridView1.Columns["Pay"].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns["Pay"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView1.Columns["Pay"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView1.Columns["Pay"].ReadOnly = true;
            dataGridView1.Columns["Pay"].Width = 75;

            this.dataGridView1.Columns.Add("Balance", "Balance");
            dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns["Balance"].DefaultCellStyle.BackColor = Color.Silver;
            dataGridView1.Columns["Balance"].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns["Balance"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView1.Columns["Balance"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView1.Columns["Balance"].ReadOnly = true;
            dataGridView1.Columns["Balance"].Width = 75;

            this.dataGridView1.Columns.Add("Due", "Due");
            dataGridView1.Columns["Due"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Due"].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns["Due"].DefaultCellStyle.BackColor = Color.Silver;
            dataGridView1.Columns["Due"].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.Columns["Due"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView1.Columns["Due"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridView1.Columns["Due"].ReadOnly = true;
            dataGridView1.Columns["Due"].Width = 75;
            dataGridView1.Columns["Due"].Visible = false;
            //BindData();

            //DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            //dataGridView1.Columns.Add(del);
            //del.HeaderText = "X";
            //del.Text = "x";
            //del.Name = "del";
            //del.ToolTipText = "Delete this Item";
            //del.UseColumnTextForButtonValue = true;
            //dataGridView1.Columns["Del"].Width = 40;

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
        public string CustAdvance
        {
            set
            {
                lblCustAdvance.Text = value;
            }
            get
            {
                return lblCustAdvance.Text;
            }
        }
        public string CustName
        {
            set
            {
                ComboCustID.Text = value;
            }
            get
            {
                return ComboCustID.Text;
            }
        }

        bool FlagLoad;
        private void payablecredit_Load(object sender, EventArgs e)
        {
            FlagLoad = true;
            bindCostomer();
            BindPayType();

            //firstbind();


            if (lblCustomerID.Text != "-" && lblCustomerID.Text != "")
            {
                string sql = "select ( Name || ' - ' || Phone || ' - ' || EmailAddress ) as 'Name', ID  from tbl_customer where TenentID = " + Tenent.TenentID + " and ID = '" + lblCustomerID.Text + "' ";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ComboCustID.Text = dt.Rows[0]["Name"] != null && dt.Rows[0]["Name"].ToString() != "" ? dt.Rows[0]["Name"].ToString() : "";
                    }
                }

                //DataBind();
                ComboCustID.Enabled = false;
            }

            fistBindGrid();
            if (lblCustAdvance.Text != "0" && lblCustAdvance.Text != "" && lblCustAdvance.Text != "-")
            {
                txtReceive.Text = lblCustAdvance.Text;
                calc();
            }
            FlagLoad = false;
            lblload.Text = ".";

        }

        public void BindPayType()
        {
            string Sql = "Select * from REFTABLE where TenentID = " + Tenent.TenentID + " and RefType = 'Payment' and RefSubType = 'Method' and ShortName = 'POS' And ACTIVE = 'Y'";
            DataTable dt = DataAccess.GetDataTable(Sql);
            if (dt.Rows.Count > 0)
            {
                CombPayby.DataSource = dt;
                CombPayby.ValueMember = "REFID";
                CombPayby.DisplayMember = "REFNAME1";
            }
        }

        public void bindCostomer()
        {
            string sqlCust = " select ( Name || ' - ' || Phone || ' - ' || EmailAddress ) as 'Name',tbl_customer.ID , sales_item.InvoiceNO as Invoice " +
                             " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = tbl_customer.ID " +
                             " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                             " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                             " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) " +
                             " group by sales_item.C_id Order by Name";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            if (dtCust.Rows.Count > 0)
            {
                ComboCustID.DataSource = dtCust;
                ComboCustID.DisplayMember = "Name";
                ComboCustID.ValueMember = "ID";

                // getInvoice(ComboCustID.SelectedValue.ToString());

            }
        }

        //public void getInvoice(string CID)
        //{
        //    string sqlCust = " select tbl_customer.ID , sales_item.InvoiceNO as Invoice " +
        //                     " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = '" + CID + "' " +
        //                     " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
        //                     " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
        //                     " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) and sales_item.C_id = '" + CID + "'  " +
        //                     " group by sales_item.InvoiceNO ;";
        //    DataTable dtCust = DataAccess.GetDataTable(sqlCust);
        //    ComboInvoice.DataSource = dtCust;
        //    ComboInvoice.DisplayMember = "Invoice";
        //    ComboInvoice.ValueMember = "Invoice";


        //}
        CheckBox headerCheckBox = new CheckBox();
        public void fistBindGrid()
        {
            dataGridView1.Rows.Clear();

            //dataGridView1.Visible = true;
            if (ComboCustID.Text != null && ComboCustID.Text != "" && ComboCustID.Text != "System.Data.DataRowView")
            {
                int Cid = Convert.ToInt32(ComboCustID.SelectedValue);
                string sqlCust = " select tbl_customer.ID , sales_item.InvoiceNO as Invoice ,round((sales_item.OrderTotal) - (case when  sales_payment.payment_amount is not null then  sales_payment.payment_amount when sales_payment.payment_amount is null then 0 End ),2) as Total ,sales_item.sales_time as SaleDate,sales_payment.due_amount as Due " +
                                 " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = '" + Cid + "' " +
                                 " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                                 " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                                 " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) and sales_item.C_id = '" + Cid + "'  " +
                                 " group by sales_item.InvoiceNO ;";
                DataTable dtCust = DataAccess.GetDataTable(sqlCust);
                int Countrow = dtCust.Rows.Count;
                if (Countrow > 0)
                {
                   
                
                    decimal totalpayable = 0;
                    decimal Enter = Convert.ToDecimal(txtReceive.Text);
                    decimal DueAmt = 0;
                    for (int i = 0; i < Countrow; i++)
                    {
                      
                        DueAmt = dtCust.Rows[i]["Due"].ToString().Trim() != "" ? Convert.ToDecimal(dtCust.Rows[i]["Due"].ToString().Trim()) : 0;
                        string Invoice = dtCust.Rows[i]["Invoice"].ToString().Trim();
                        decimal Amount = DueAmt != 0 ? DueAmt : Convert.ToDecimal(dtCust.Rows[i]["Total"]);
                        decimal Pay = DueAmt != 0 ? (Convert.ToDecimal(dtCust.Rows[i]["Total"]) - DueAmt) : 0;
                        string SaleDt = dtCust.Rows[i]["SaleDate"].ToString().Trim();
                        if (FlagLoad == true)
                            dataGridView1.Rows.Add(Invoice, SaleDt, Convert.ToDecimal(dtCust.Rows[i]["Total"]), Pay, Amount, DueAmt);
                        else
                            dataGridView1.Rows.Add(false, Invoice, SaleDt, Convert.ToDecimal(dtCust.Rows[i]["Total"]), Pay, Amount, DueAmt);
                        //int Rowcount = dataGridView1.Rows.Count - 1;
                        //dataGridView1.Rows[Rowcount].Selected = true;
                        //dataGridView1.FirstDisplayedScrollingRowIndex = Rowcount;
                        totalpayable += Amount;
                    }

                    lblTotalPayable.Text = DueAmt != 0 ? DueAmt.ToString("N3") : totalpayable.ToString("N3");
                    calc();

                    if (FlagLoad == true)
                    {
                        //Grid Checkbox
                        lblParsialTotal.Text = "0.000";
                        //Find the Location of Header Cell.
                        Point headerCellLocation = this.dataGridView1.GetCellDisplayRectangle(0, -1, true).Location;

                        //Place the Header CheckBox in the Location of the Header Cell.
                        headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
                        headerCheckBox.BackColor = Color.White;
                        headerCheckBox.Size = new Size(18, 18);

                        //Assign Click event to the Header CheckBox.
                        headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
                        dataGridView1.Controls.Add(headerCheckBox);


                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                        checkBoxColumn.HeaderText = "";
                        checkBoxColumn.Width = 30;
                        checkBoxColumn.Name = "checkBoxColumn";
                        dataGridView1.Columns.Insert(0, checkBoxColumn);
                        //Assign Click event to the DataGridView Cell.
                        dataGridView1.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);

                    }
                    headerCheckBox.Checked = false;


                }

            }
        }



        public void firstbind()
        {

            if (ComboCustID.Text != null && ComboCustID.Text != "" && ComboCustID.Text != "System.Data.DataRowView")
            {
                string Cid = ComboCustID.SelectedValue.ToString();


                decimal Total_Payble = GetCustCredit(Cid);
                if (Total_Payble != null)
                {

                    lblTotalPayable.Text = Total_Payble.ToString();
                    txtReceive.Text = "0";
                    lblTotalPayable.Text = Total_Payble.ToString();
                }
                else
                {
                    lblTotalPayable.Text = "0";
                    txtReceive.Text = "0";
                    lblafterpaid.Text = "0";
                }


            }
            else
            {
                lblTotalPayable.Text = "0";
                txtReceive.Text = "0";
                lblafterpaid.Text = "0";
            }
        }
        public static decimal GetCustCredit(string CID)
        {


            string sqlCust = " select tbl_customer.ID , sales_item.InvoiceNO as Invoice ,round((sales_item.OrderTotal) - (case when  sales_payment.payment_amount is not null then  sales_payment.payment_amount when sales_payment.payment_amount is null then 0 End ),2) as Total ,sales_item.sales_time as SaleDate,sales_payment.due_amount as Due " +
                                      " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = '" + CID + "' " +
                                      " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                                      " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                                      " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) and sales_item.C_id = '" + CID + "'  " +
                                      " group by sales_item.InvoiceNO ;";
            DataTable dt1 = DataAccess.GetDataTable(sqlCust);
           
            decimal totalpayable = 0;
            if (dt1.Rows.Count > 0)
            {
                decimal DueAmt = 0;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DueAmt = dt1.Rows[i]["Due"].ToString().Trim() != "" ? Convert.ToDecimal(dt1.Rows[i]["Due"].ToString().Trim()) : 0;
                    decimal Amount = DueAmt != 0 ? DueAmt : Convert.ToDecimal(dt1.Rows[i]["Total"]);
                    totalpayable += Amount;
                }
                return  totalpayable;
            }
            else
                return 0;


        }
        private void ComboCustID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FlagLoad == false)
            {
                //getInvoice(ComboCustID.SelectedValue.ToString());
                fistBindGrid();
                calc();
                lblBalance.Text = "0.000";
            }
        }

        private void txtReceive_Leave(object sender, EventArgs e)
        {
            try
            {

                calc();
                GridRefresh();

            }
            catch
            {

            }
        }

        public void calc()
        {
            txtReceive.Text = txtReceive.Text != "" ? txtReceive.Text : "0";
            decimal Total_Payble = Convert.ToDecimal(lblTotalPayable.Text);
            decimal Enter = Convert.ToDecimal(txtReceive.Text);

            decimal rest = Total_Payble - Enter;
            decimal advance = 0;

            if (rest <= 0)
            {
                headerCheckBox.Visible = true;
                advance = Enter - Total_Payble;
                lblAdvance.Text = advance.ToString("N3");
                lblafterpaid.Text = "0.000";
                //lblMsg.Text = "Not Allow To More Than " + Total_Payble + " Amount";
                //btnSave.Enabled = false;
            }
            else
            {
                headerCheckBox.Visible = false;
                lblafterpaid.Text = (Math.Round(rest, 3)).ToString();
                btnSave.Enabled = true;
                lblAdvance.Text = "0.000";
            }
        }
        private void txtReceive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    calc();
                    GridRefresh();

                }
                catch
                {

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           

            if (dataGridView1.Rows.Count > 0)
            {
                #region Single
                string payment_type = CombPayby.Text;
                if (payment_type.ToUpper() != "CASH" && txtRefrance.Text == "")
                {
                    MyMessageAlert.ShowBox("Please Enter Reference #", "Alert");
                    return;
                }

                decimal Total_Payble = Convert.ToDecimal(lblTotalPayable.Text);
                decimal Enter = Convert.ToDecimal(txtReceive.Text);

                decimal rest = Total_Payble - Enter;
                decimal advance = 0;
                int C_ID = Convert.ToInt32(ComboCustID.SelectedValue);
                string Customer = ComboCustID.Text.ToString().Split('-')[0].Trim();
                if (Enter == 0)
                {
                    MyMessageAlert.ShowBox("Please Enter Paid Amount.", "Alert");
                    btnSave.Enabled = false;
                    txtReceive.Focus();
                    return;
                }
                else if (rest < 0)
                {
                    advance = Enter - Total_Payble;
                    lblAdvance.Text = advance.ToString("N3");
                    lblafterpaid.Text = "0.000";
                    AdvancePayment(C_ID, advance, "Advance Payment Accept from Credit Payble");

                }
                else
                {
                    btnSave.Enabled = true;
                }
                //string Sql = " select sales_item.sales_id as 'sales_id',sales_item.InvoiceNO as 'InvoiceNO', (sum(sales_item.total) - (case when  sales_payment.payment_amount is not null then  sales_payment.payment_amount when sales_payment.payment_amount is null then 0 End )) as Total " +
                //             " from sales_item left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                //             " where sales_item.TenentID=" + Tenent.TenentID + " and sales_item.PaymentMode = 'Credit' and " +
                //             " sales_item.C_id = " + C_ID + " and (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' )" +
                //             " group by sales_item.sales_id";
                //DataTable dt = DataAccess.GetDataTable(Sql);

                decimal PayRest = Enter;

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool ischeck = Convert.ToBoolean(row.Cells[0].Value);
                    if (ischeck == true)
                    {
                        string InvoiceNO = row.Cells["Invoice"].Value.ToString();
                        string[] str = InvoiceNO.Split('/');
                        int sales_ID = Convert.ToInt32(str[0].Trim());
                        decimal Due = Convert.ToDecimal(row.Cells["Due"].Value);
                        decimal Pay = Convert.ToDecimal(row.Cells["Pay"].Value);
                        decimal Total = Convert.ToDecimal(row.Cells["Amount"].Value);

                        decimal payamount = 0;
                        decimal changeamount = 0;
                        decimal dueamount = 0;
                        string salesdate = dtReceiveDate.Text;
                        string Comment = Customer;
                        string PaymentStutas = "";




                        if (PayRest == Total)
                        {
                            payamount = Total;
                            PaymentStutas = "Success";
                        }
                        else if (PayRest == Due)
                        {
                            payamount = Due;
                            PaymentStutas = "Success";
                        }
                        else if (PayRest > Total)
                        {
                            payamount = Total;
                            PaymentStutas = "Success";
                        }
                        else
                        {
                            payamount = PayRest;
                            PaymentStutas = "Pending";
                            dueamount = Due;
                        }

                        List<PaymentDatasale> GridPayment = new List<PaymentDatasale>();

                        PaymentDatasale Obj = new PaymentDatasale();

                        Obj.invoice = sales_ID.ToString();
                        Obj.Reffrance_NO = txtRefrance.Text;
                        Obj.payment_type = payment_type;
                        Obj.payment_amount = payamount;

                        GridPayment.Add(Obj);

                        if (PayRest > 0)
                        {
                            SalesRegister.payment_item_Credit(sales_ID, InvoiceNO, C_ID, Customer, payamount, changeamount, dueamount, salesdate, Comment, PaymentStutas, GridPayment);


                            PayRest = PayRest - Total;
                        }
                        else
                        {
                            PayRest = PayRest - Total;
                        }

                    }

                }


                this.Close();
                #endregion
            }

        }
        public void AdvancePayment(int Cid, decimal Amount, string remark)
        {
            int MyID = 0;

            MyID = DataAccess.getCustomer_Advance_MYid(Tenent.TenentID, CustomerID);
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Cid = Convert.ToInt32(ComboCustID.SelectedValue);
            string sqlselect = " select * from tbl_Customer_Advance where TenentID = " + Tenent.TenentID + " and CustomerID = '" + Cid + "' and MyID = '" + MyID + "' ";
            DataTable Dtselect = DataAccess.GetDataTable(sqlselect);

            if (Dtselect.Rows.Count < 1)
            {
                string sqlinsert = " insert into tbl_Customer_Advance ( TenentID,CustomerID,MyID,DateOFAdvance,Amount,Remark, UploadDate,Uploadby,SynID) " +
                                   " values ( " + Tenent.TenentID + " , '" + Cid + "' , '" + MyID + "','" + UploadDate + "','" + Amount + "','" + remark + "', " +
                                   " '" + UploadDate + "' , '" + UserInfo.UserName + "',1 ) ";
                DataAccess.ExecuteSQL(sqlinsert);
                Datasyncpso.insert_Live_sync(sqlinsert, "tbl_Customer_Advance", "INSERT");

            }
            else
            {
                string SqlUpdate = " Update tbl_Customer_Advance set DateOFAdvance = '" + UploadDate + "' ,Amount = '" + Amount + "' ,Remark = '" + remark + "' , " +
                                   " UploadDate = '" + UploadDate + "',Uploadby = '" + UserInfo.UserName + "',SynID = 2 " +
                                   " where TenentID = " + Tenent.TenentID + " and CustomerID = '" + Cid + "' and MyID = '" + MyID + "' ";
                DataAccess.ExecuteSQL(SqlUpdate);
                Datasyncpso.insert_Live_sync(SqlUpdate, "tbl_Customer_Advance", "UPDATE");
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void RefrashPayby_Click(object sender, EventArgs e)
        {
            BindPayType();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["CreditCustomerSearch"] != null)
            {
                Application.OpenForms["CreditCustomerSearch"].Close();
            }
            this.Refresh();

            CreditCustomerSearch go = new CreditCustomerSearch();
            go.Show();
        }

        private void payablecredit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txtReceive_Leave(sender, e);

                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void ComboInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //firstbind();
            // bindgrid();
        }
        //public void bindgrid()
        //{
        //    if (lblload.Text != "-")
        //    {
        //        if (ComboInvoice.Text != null && ComboInvoice.Text != "" && ComboInvoice.Text != "System.Data.DataRowView")
        //        {
        //            string Invoice = ComboInvoice.Text.Trim();
        //            decimal Amount = Convert.ToDecimal(txttotalamt.Text);
        //            if (dataGridView1.Rows.Count > 1)
        //            {
        //                for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //                {

        //                    if (dataGridView1.Rows[i].Cells[1].Value.ToString().Trim().Equals(Invoice))
        //                    {
        //                        MessageBox.Show("Duplicate Invoice No.");
        //                        return;
        //                    }

        //                }

        //                dataGridView1.Rows.Add(Invoice, DateTime.Now.ToShortDateString(), Amount);
        //                int Rowcount = dataGridView1.Rows.Count - 1;
        //                dataGridView1.Rows[Rowcount].Selected = true;
        //                dataGridView1.FirstDisplayedScrollingRowIndex = Rowcount;
        //            }
        //            else
        //            {
        //                dataGridView1.Rows.Add(Invoice, DateTime.Now.ToShortDateString(), Amount);
        //                int Rowcount = dataGridView1.Rows.Count - 1;
        //                dataGridView1.Rows[Rowcount].Selected = true;
        //                dataGridView1.FirstDisplayedScrollingRowIndex = Rowcount;
        //            }
        //            ComboInvoice.Focus();
        //        }
        //    }
        //}

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            if (txtReceive.Text == "0")
            {
                MyMessageAlert.ShowBox("Please Enter Paid Amount.", "Alert");

                btnSave.Enabled = false;

                if (headerCheckBox.Checked == true)
                {
                    headerCheckBox.Checked = false;
                }
                else
                {
                    headerCheckBox.Checked = true;
                }
                txtReceive.Focus();
                return;
            }
            else
            {
                btnSave.Enabled = true;
            }

            dataGridView1.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;

                if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                {
                    row.Cells["Balance"].Value = Convert.ToDecimal(row.Cells["Amount"].Value);
                    row.Cells["Pay"].Value = "0";
                }
                else
                {
                    row.Cells["Pay"].Value = Convert.ToDecimal(row.Cells["Amount"].Value);
                    row.Cells["Balance"].Value = "0";
                }
            }
            if (headerCheckBox.Checked)
            {
                lblParsialTotal.Text = lblTotalPayable.Text;
                lblBalance.Text = "0.000";
            }
            else
            {
                lblParsialTotal.Text = "0.000";
                if (lblAdvance.Text != "0.000" && lblAdvance.Text != "0")
                    lblBalance.Text = lblTotalPayable.Text;
                else
                    lblBalance.Text = txtReceive.Text;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtReceive.Text == "0")
            {
                MyMessageAlert.ShowBox("Please Enter Paid Amount.", "Alert");
                btnSave.Enabled = false;
                txtReceive.Focus();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                    checkBox.Value = false;
                }
                return;
            }
            else
            {
                btnSave.Enabled = true;

                //Check to ensure that the row CheckBox is clicked.
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    decimal Enter = Convert.ToDecimal(txtReceive.Text);
                    decimal afterPaid = Convert.ToDecimal(lblafterpaid.Text);
                    decimal Amount = 0, Balance = 0;
                    decimal Total_Payble = Convert.ToDecimal(lblTotalPayable.Text);
                    decimal rest = Total_Payble - Enter;
                    if (dataGridView1.Rows.Count == 1)//Single
                    {
                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {

                            //decimal Due = row.Cells["Due"].Value.ToString() != "" ? Convert.ToDecimal(row.Cells["Due"].Value) : 0;
                            //if (Due == 0)
                            //{
                            if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                            {
                                //calc between Balance and Enter

                                row.Cells["Balance"].Value = Convert.ToDecimal(row.Cells["Amount"].Value);
                                row.Cells["Pay"].Value = "0";

                                Balance = lblAdvance.Text != "" ? Total_Payble > Enter ? Enter : Total_Payble : Convert.ToDecimal(txtReceive.Text);

                                isChecked = false;
                                break;

                            }
                            else
                            {
                                if (Balance == Enter)
                                {
                                    row.Cells["Pay"].Value = Convert.ToDecimal(row.Cells["Amount"].Value);
                                    row.Cells["Balance"].Value = "0";
                                    Amount += Convert.ToDecimal(row.Cells["Amount"].Value);
                                }
                                else if (rest < 0)//advance
                                {
                                    row.Cells["Pay"].Value = Convert.ToDecimal(row.Cells["Amount"].Value);
                                    row.Cells["Balance"].Value = "0";
                                    Amount += Convert.ToDecimal(row.Cells["Amount"].Value);
                                }
                                else
                                {
                                    row.Cells["Balance"].Value = afterPaid.ToString("N3");
                                    row.Cells["Pay"].Value = Enter.ToString("N3");
                                    Balance += Convert.ToDecimal(row.Cells["Balance"].Value);
                                    Amount = Total_Payble - Balance;
                                }
                            }
                            //} 
                        }
                        lblBalance.Text = Balance.ToString("N3");
                        lblParsialTotal.Text = Amount.ToString("N3");
                        headerCheckBox.Checked = isChecked;
                    }//End Single
                    else// Multiple
                    {
                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;
                        Balance = lblAdvance.Text != "" ? Total_Payble > Enter ? Enter : Total_Payble : Convert.ToDecimal(txtReceive.Text);
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                            if (Convert.ToBoolean(checkBox.EditedFormattedValue) == true)
                            {
                                row.Cells["Pay"].Value = Convert.ToDecimal(row.Cells["Amount"].Value);
                                row.Cells["Balance"].Value = "0";
                                Amount += Convert.ToDecimal(row.Cells["Amount"].Value);
                            }
                            else
                            {

                                row.Cells["Balance"].Value = Convert.ToDecimal(row.Cells["Amount"].Value);
                                row.Cells["Pay"].Value = "0";
                                Balance -= Convert.ToDecimal(row.Cells["Balance"].Value);
                            }

                        }
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                            {
                                isChecked = false;
                                break;
                            }
                        }
                        lblBalance.Text = Balance.ToString("N3");
                        lblParsialTotal.Text = Amount.ToString("N3");
                        headerCheckBox.Checked = isChecked;
                    }//End Multiple
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Select
            //if (e.ColumnIndex == dataGridView1.Columns["del"].Index && e.RowIndex >= 0)
            //{
            //    //foreach (DataGridViewRow row2 in dtPerishableSalesTemp.SelectedRows)
            //    //{
            //    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //    if (!row.IsNewRow)
            //    {
            //        dataGridView1.Rows.Remove(row);
            //    }

            //    //}

            //    ComboInvoice.Focus();
            //}
        }
        public void GridRefresh()
        {
            dataGridView1.Rows.Clear();

            int Cid = Convert.ToInt32(ComboCustID.SelectedValue);
            string sqlCust = " select tbl_customer.ID , sales_item.InvoiceNO as Invoice , ((sales_item.OrderTotal) - (case when  sales_payment.payment_amount is not null then  sales_payment.payment_amount when sales_payment.payment_amount is null then 0 End )) as Total ,sales_item.sales_time as SaleDate,sales_payment.due_amount as Due " +
                             " from tbl_customer inner join sales_item on sales_item.TenentID = tbl_customer.TenentID and sales_item.C_id = '" + Cid + "' " +
                             " left join sales_payment on sales_item.sales_id = sales_payment.sales_id and sales_item.TenentID = sales_payment.TenentID " +
                             " where tbl_customer.TenentID = " + Tenent.TenentID + " and tbl_customer.PeopleType = 'Customer' and sales_item.ISPaymentCredit = 1 and " +
                             " (sales_payment.PaymentStutas is null or sales_payment.PaymentStutas = 'Pending' ) and sales_item.C_id = '" + Cid + "'  " +
                             " group by sales_item.InvoiceNO ;";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            int Countrow = dtCust.Rows.Count;
            if (Countrow > 0)
            {
                decimal totalpayable = Convert.ToDecimal(lblTotalPayable.Text);
                decimal Enter = Convert.ToDecimal(txtReceive.Text);
                decimal Partial = 0;
                decimal DueAmt = 0;
                if (lblAdvance.Text != "0" && lblAdvance.Text != "0.000" && lblAdvance.Text != "")//Advance
                {

                    for (int i = 0; i < Countrow; i++)
                    {
                        DueAmt = dtCust.Rows[i]["Due"].ToString().Trim() != "" ? Convert.ToDecimal(dtCust.Rows[i]["Due"].ToString().Trim()) : 0;
                        string Invoice = dtCust.Rows[i]["Invoice"].ToString().Trim();
                        decimal Amount = DueAmt != 0 ? DueAmt : Convert.ToDecimal(dtCust.Rows[i]["Total"]);
                        decimal Pay = DueAmt != 0 ? (Convert.ToDecimal(dtCust.Rows[i]["Total"]) - DueAmt) : 0;
                        string SaleDt = dtCust.Rows[i]["SaleDate"].ToString().Trim();
                        dataGridView1.Rows.Add(true, Invoice, SaleDt, Convert.ToDecimal(dtCust.Rows[i]["Total"]), Convert.ToDecimal(dtCust.Rows[i]["Total"]), 0, DueAmt);


                    }
                    lblParsialTotal.Text = totalpayable.ToString("N3");
                    lblBalance.Text = "0.000";


                    headerCheckBox.Checked = true;

                }
                else if (Enter.ToString("N3") == totalpayable.ToString("N3"))//Equal
                {

                    for (int i = 0; i < Countrow; i++)
                    {
                        DueAmt = dtCust.Rows[i]["Due"].ToString().Trim() != "" ? Convert.ToDecimal(dtCust.Rows[i]["Due"].ToString().Trim()) : 0;
                        string Invoice = dtCust.Rows[i]["Invoice"].ToString().Trim();
                        decimal Amount = DueAmt != 0 ? DueAmt : Convert.ToDecimal(dtCust.Rows[i]["Total"]);
                        decimal Pay = DueAmt != 0 ? (Convert.ToDecimal(dtCust.Rows[i]["Total"]) - DueAmt) : 0;
                        string SaleDt = dtCust.Rows[i]["SaleDate"].ToString().Trim();
                        dataGridView1.Rows.Add(true, Invoice, SaleDt, Convert.ToDecimal(dtCust.Rows[i]["Total"]), Convert.ToDecimal(dtCust.Rows[i]["Total"]), 0, DueAmt);


                    }
                    lblParsialTotal.Text = totalpayable.ToString("N3");
                    lblBalance.Text = "0.000";


                    headerCheckBox.Checked = true;
                }
                else//AfterPaid
                {

                    for (int i = 0; i < Countrow; i++)
                    {
                        DueAmt = dtCust.Rows[i]["Due"].ToString().Trim() != "" ? Convert.ToDecimal(dtCust.Rows[i]["Due"].ToString().Trim()) : 0;
                        string Invoice = dtCust.Rows[i]["Invoice"].ToString().Trim();
                        decimal Amount = DueAmt != 0 ? DueAmt : Convert.ToDecimal(dtCust.Rows[i]["Total"]);
                        decimal Pay = DueAmt != 0 ? (Convert.ToDecimal(dtCust.Rows[i]["Total"]) - DueAmt) : 0;
                        string SaleDt = dtCust.Rows[i]["SaleDate"].ToString().Trim();
                        if (Enter == 0)
                        {
                            dataGridView1.Rows.Add(false, Invoice, SaleDt, Amount, 0, Amount, DueAmt);
                        }
                        else
                        {
                            if (Enter >= Amount)
                            {
                                dataGridView1.Rows.Add(true, Invoice, SaleDt, Amount, Amount, 0, DueAmt);
                                Enter -= Amount;
                                Partial += Amount;
                            }
                            else if (Enter <= Amount)
                            {
                                dataGridView1.Rows.Add(true, Invoice, SaleDt, Amount, Enter, (Amount - Enter), (Amount - Enter));
                                Partial += Enter;
                                Enter = 0;
                            }

                        }



                    }
                    lblParsialTotal.Text = Partial.ToString("N3");
                    lblBalance.Text = txtReceive.Text;


                    headerCheckBox.Checked = false;
                }



            }
        }
        private void BtnPaidRefresh_Click(object sender, EventArgs e)
        {

            GridRefresh();

        }

    }
}
