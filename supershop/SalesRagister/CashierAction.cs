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
    public partial class CashierAction : Form
    {
        private int desiredStartLocationX;
        private int desiredStartLocationY;
        public CashierAction(int x, int y)
        {
            InitializeComponent();

            this.desiredStartLocationX = x;
            this.desiredStartLocationY = y;

           // Load += new EventHandler(CashierAction_Load);
        }

        private void CashierAction_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(desiredStartLocationX, desiredStartLocationY);
            string InvoiceNO = lblorderNO.Text;
            string salesID = "";
            string DriverNameO = "";

                GetSalesIDCashier(InvoiceNO,out salesID,out DriverNameO);

            if (UserInfo.usertype == "1")
            {
                btnDeleteInvoice.Visible = true;
            }
            else
            {
                btnDeleteInvoice.Visible = false;
            }

            // string DriverName = GetDriver(salesID);
            string DriverName = DriverNameO;

            if (DriverName == null)
            {
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else if (DriverName == "")
            {
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else
            {
                btnDeliverd.Enabled = true;
            }

            string OrderStutas = GetOrderStutas(salesID);

            if (OrderStutas == "Not Paid Order Taken")
            {
                if (SalesRegister.isBookingOn())
                {
                    btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                    btnDriverAssign.Enabled = false;
                }
                btnSalesCredit.Enabled = true;
                btnCashprint.Enabled = true;
                btnedit.Visible = true;
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnedit.Enabled = true;
                btnCOD.Enabled = true;
                //btnPrint.Enabled = false;
                //btnPrint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Enabled = false;//.Text = "Delete Order"; yogesh 18 april 19
                btnReturn.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            if (OrderStutas == "Not Paid Booking Order Taken")
            {
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnBookingEdit.Visible = true;
                btnBookingEdit.Enabled = true;
                btnBookingDelivered.Visible = true;
                btnBookingDelivered.Enabled = true;
                btnedit.Visible = false;
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                //btnPrint.Enabled = false;
                //btnPrint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Enabled = false;//.Text = "Delete Order"; yogesh 18 april 19
                btnReturn.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDriverAssign.Enabled = false;
                btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);

            }
            else if (OrderStutas == "Booking Order Deliverd")
            {

                btnSalesCredit.Enabled = true;
                btnCashprint.Enabled = true;
                btnBookingEdit.Visible = true;
                btnBookingEdit.Enabled = false;
                btnBookingEdit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnBookingDelivered.Visible = true;
                btnBookingDelivered.Enabled = false;
                btnBookingDelivered.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Visible = false;
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                //btnPrint.Enabled = false;
                //btnPrint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Enabled = false;//.Text = "Delete Order"; yogesh 18 april 19
                btnReturn.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDriverAssign.Enabled = false;
                btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else if (OrderStutas == "COD-send to Kitchen")
            {
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
            }
            else if (OrderStutas == "Paid-send to Kitchen")
            {
                if (SalesRegister.isBookingOn())
                {
                    btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                    btnDriverAssign.Enabled = false;
                }

                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
                if (!SalesRegister.isInvoiceWithDelivered())
                {
                    if (!SalesRegister.isAlreadyDeliveredInvoice(salesID))
                    {
                        btnBookingDelivered.Visible = true;
                    }
                    else
                    {
                        btnBookingDelivered.Visible = true;
                        btnBookingDelivered.Enabled = false;
                        btnBookingDelivered.BackColor = Color.FromKnownColor(KnownColor.Control);
                    }
                }
            }

            else if (OrderStutas == "COD-Ready to Delivery")
            {
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
            }
            else if (OrderStutas == "Paid-Ready to Delivery")
            {
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
                
            }
            else if (OrderStutas == "Advance Paid-Ready to Delivery")
            {
                btnBookingDelivered.Visible = true;//100719 yogesh
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
            }
            else if (OrderStutas == "Deliverd")
            {
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDriverAssign.Enabled = false;
                btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
            }
            else if (OrderStutas == "Deliverd & Cash Recived")
            {
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDriverAssign.Enabled = false;
                btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
            }
            else if (OrderStutas == "Return")
            {
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDriverAssign.Enabled = false;
                btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
            }
            else if (OrderStutas == "Credit and partial payment")//Credit
            {

                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = true;
                btnSalesCredit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                if (SalesRegister.isBookingOn())
                {
                    btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                    btnDriverAssign.Enabled = false;
                }
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
                //btnSalesCredit.Enabled = true;
                //btnCashprint.Enabled = true;
                //btnedit.Enabled = true;
                //btnCOD.Enabled = true;
                ////btnPrint.Enabled = false;
                ////btnPrint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Enabled = false;//.Text = "Delete Order";yogesh 18 april 19
                btnReturn.BackColor = Color.FromKnownColor(KnownColor.Control);
                if (SalesRegister.isAlreadyDeliveredInvoice(salesID))
                {
                    btnBookingDelivered.Visible = true;
                    btnBookingDelivered.Enabled = false;
                    btnBookingDelivered.BackColor = Color.FromKnownColor(KnownColor.Control);
                }
            }
            else if (OrderStutas == "Delivered Credit and partial payment")//Credit
            {
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = true;
                btnBookingDelivered.Enabled = false;
                btnBookingDelivered.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnSalesCredit.Enabled = false;
                btnedit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnedit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                if (SalesRegister.isBookingOn())
                {
                    btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                    btnDriverAssign.Enabled = false;
                }
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
                //btnSalesCredit.Enabled = true;
                //btnCashprint.Enabled = true;
                //btnedit.Enabled = true;
                //btnCOD.Enabled = true;
                ////btnPrint.Enabled = false;
                ////btnPrint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Enabled = false;//.Text = "Delete Order";yogesh 18 april 19
                btnReturn.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else
            {
                btnBookingEdit.Visible = false;
                btnBookingDelivered.Visible = false;
                btnSalesCredit.Enabled = false;
                btnSalesCredit.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCashprint.Enabled = false;
                btnCashprint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnCOD.Enabled = false;
                btnCOD.BackColor = Color.FromKnownColor(KnownColor.Control);
                if (SalesRegister.isBookingOn())
                {
                    btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                    btnDriverAssign.Enabled = false;
                }
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
                //btnSalesCredit.Enabled = true;
                //btnCashprint.Enabled = true;
                //btnedit.Enabled = true;
                //btnCOD.Enabled = true;
                ////btnPrint.Enabled = false;
                ////btnPrint.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Enabled = false;//.Text = "Delete Order";yogesh 18 april 19
                btnReturn.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
           

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
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

        private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnDriverAssign_Click(object sender, EventArgs e)
        {
            int CursorY = Cursor.Position.Y;
            string InvoiceNO = lblorderNO.Text;
            ShowDriverAssign(InvoiceNO, CursorY);
            this.Close();

        }

        public void ShowDriverAssign(string InvoiceNO, int CursorY)
        {
            string salesID = GetSalesID(InvoiceNO);

            string Complate = GetOrderStutas(salesID);

            if (Complate == "Deliverd & Cash Recived")
            {
                MessageBox.Show("Already Deliverd this Order...Not Able To Driver Assign");
                return;
            }
            else if (Complate == "Deliverd")
            {
                MessageBox.Show("Already Deliverd this Order...Not Able To Driver Assign");
                return;
            }
            else if (Complate == "Return")
            {
                MessageBox.Show("Already Deliverd this Order...Not Able To Driver Assign");
                return;
            }
            else
            {

            }

            string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and sales_id=" + salesID + " ";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            int cal = Cursor.Position.X;
            int CursorX = cal - 350;

            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["Driver"] == null)
                {
                    if (Application.OpenForms["DriverAssign"] != null)
                    {
                        Application.OpenForms["DriverAssign"].Close();
                    }

                    DriverAssign mkc1 = new DriverAssign(CursorX, CursorY);
                    mkc1.OrderNO = InvoiceNO;
                    mkc1.Show();
                }
                else
                {
                    string DriverName = dt1.Rows[0]["Driver"].ToString().Trim();
                    if (DriverName == "" || DriverName == "0")
                    {
                        if (Application.OpenForms["DriverAssign"] != null)
                        {
                            Application.OpenForms["DriverAssign"].Close();
                        }

                        DriverAssign mkc1 = new DriverAssign(CursorX, CursorY);
                        mkc1.OrderNO = InvoiceNO;
                        mkc1.Show();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Driver Already assigned You Want to Reassign?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (Application.OpenForms["DriverAssign"] != null)
                            {
                                Application.OpenForms["DriverAssign"].Close();
                            }

                            DriverAssign mkc1 = new DriverAssign(CursorX, CursorY);
                            mkc1.OrderNO = InvoiceNO;
                            mkc1.Show();
                        }
                    }
                }
            }
        }

        public string GetDriver(string salesID)
        {
            string DriverName = null;
            string sql3 = "select Driver from sales_item where TenentID=" + Tenent.TenentID + " and sales_id=" + salesID + " ";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["Driver"] != null)
                {
                    string DriverName1 = dt1.Rows[0]["Driver"].ToString().Trim();
                    if (DriverName1 != "")
                    {
                        DriverName = dt1.Rows[0]["Driver"].ToString();
                    }
                    else
                    {
                        DriverName = "";
                    }
                }
                else
                {
                    DriverName = "";
                }
            }

            return DriverName;
        }

        public string GetSalesID(string InvoiceNO)
        {
            string sql3 = "select sales_id,c_id from sales_item where TenentID=" + Tenent.TenentID + " and InvoiceNO='" + InvoiceNO + "' ";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt3 = DataAccess.GetDataTable(sql3);
            string Salesid = "";
            if (dt3.Rows.Count > 0)
            {
                Salesid = dt3.Rows[0]["sales_id"].ToString();
            }
            else
            {
                Salesid = "";
            }
            return Salesid;
        }
        public void GetSalesIDCashier(string InvoiceNO,out string SalesID,out string driver)
        {
            string sql3 = "select sales_id,Driver from sales_item where TenentID=" + Tenent.TenentID + " and InvoiceNO='" + InvoiceNO + "' ";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt3 = DataAccess.GetDataTable(sql3);
   
            if (dt3.Rows.Count > 0)
            {
                SalesID = dt3.Rows[0]["sales_id"].ToString();
                driver = dt3.Rows[0]["Driver"].ToString();
            }
            else
            {
                SalesID = "";
                driver = "";
            }
    

        }

        private void btnDeliverd_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;
            string salesID = GetSalesID(InvoiceNO);

            string DriverName = GetDriver(salesID);

            if (DriverName == null)
            {
                MessageBox.Show("Driver Assign First..");
                return;
            }
            else if (DriverName == "")
            {
                MessageBox.Show("Driver Assign First..");
                return;
            }
            else
            {

            }

            string OrderStutas = SetOrderStutas(salesID);
            string Complate = GetOrderStutas(salesID);

            if (Complate == "Deliverd & Cash Recived")
            {
                MessageBox.Show("Already Deliverd this Order...");
                return;
            }
            else if (Complate == "Deliverd")
            {
                MessageBox.Show("Already Deliverd this Order...");
                return;
            }
            else if (Complate == "Return")
            {
                MessageBox.Show("Already Deliverd this Order...");
                return;
            }
            else
            {

            }

            if (OrderStutas == "Deliverd & Cash Recived")
            {
                DataAccess.PaymentStstusUpdate(salesID, "Success");
                DataAccess.OrderDeliverd(salesID, OrderStutas, InvoiceNO);

            }
            else if (OrderStutas == "Deliverd")
            {
                DataAccess.OrderDeliverd(salesID, OrderStutas, InvoiceNO);

            }
            else
            {

            }
            string sql1 = "update sales_item set IsDelivered=1 where sales_id=" + salesID + "";
            DataAccess.ExecuteSQL(sql1);
            UserInfo.TranjationPerform = "Deliverd";
            if (Application.OpenForms["SalesRegister"] != null)
            {
                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                mkc1.OrderNO = InvoiceNO;
               // mkc1.Show();
            }
            this.Close();
        }

        public static string GetOrderStutas(string sales_ID)
        {
            string OrderStutas = null;
            string sql3 = "select OrderStutas from sales_item where sales_id  = '" + sales_ID + "' and TenentID= " + Tenent.TenentID + " and OrderStutas != 'Return' ";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt3 = DataAccess.GetDataTable(sql3);
            if (dt3.Rows.Count > 0)
            {
                OrderStutas = dt3.Rows[0]["OrderStutas"].ToString();
            }
            else
            {
                OrderStutas = "Return";
            }
            return OrderStutas;
        }

        public string SetOrderStutas(string sales_ID)
        {
            string OrderStutas = null;
            string sql3 = "select * from sales_item where sales_id  = '" + sales_ID + "' and TenentID= " + Tenent.TenentID + " ";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt3 = DataAccess.GetDataTable(sql3);
            if (dt3.Rows.Count > 0)
            {
                int COD = Convert.ToInt32(dt3.Rows[0]["COD"]);
                if (COD == 1)
                {
                    OrderStutas = "Deliverd & Cash Recived";
                }
                else if (COD == 0)
                {
                    OrderStutas = "Deliverd";
                }
                else
                {
                    OrderStutas = "Deliverd";
                }
            }

            return OrderStutas;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;
            string salesID = GetSalesID(InvoiceNO);

            string Complate = GetOrderStutas(salesID);
            if (Complate == "Return")
            {
                MessageBox.Show("Already Return this Order...");
                return;
            }

            if (btnReturn.Text == "Return")
            {
                string OrderStutas = GetOrderStutas(salesID);

                if (OrderStutas == "Not Paid Order Taken")
                {
                    //Delete Code
                    string sql3 = "select * from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);
                    if (dt3.Rows.Count > 0)
                    {
                        SalesRegister.DeleteOrder(salesID, true, OrderStutas);
                    }

                }
                if (OrderStutas == "Not Paid Booking Order Taken")
                {
                    //Delete Code
                    string sql3 = "select * from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);
                    if (dt3.Rows.Count > 0)
                    {
                        SalesRegister.DeleteOrder(salesID, true, OrderStutas);
                    }

                }
                if (OrderStutas == "Booking Order Deliverd")
                {
                    string sql3 = "select * from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);
                    if (dt3.Rows.Count > 0)
                    {
                        SalesRegister.DeleteOrder(salesID, true, OrderStutas);
                    }
                }
                if (OrderStutas == "COD-send to Kitchen")
                {
                    //Delete Code

                    string sql3 = "select * from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);
                    if (dt3.Rows.Count > 0)
                    {
                        SalesRegister.DeleteOrder(salesID, true, OrderStutas);
                    }
                }

                if (OrderStutas == "Paid-send to Kitchen")
                {
                    Return_product go = new Return_product();
                    go.OrderNO = InvoiceNO;
                    go.Show();
                }

                if (OrderStutas == "COD-Ready to Delivery")
                {
                    Return_product go = new Return_product();
                    go.OrderNO = InvoiceNO;
                    go.Show();
                }

                if (OrderStutas == "Paid-Ready to Delivery")
                {
                    Return_product go = new Return_product();
                    go.OrderNO = InvoiceNO;
                    go.Show();
                }
                if (OrderStutas == "Advance Paid-Ready to Delivery")
                {
                    Return_product go = new Return_product();
                    go.OrderNO = InvoiceNO;
                    go.Show();
                }
                if (OrderStutas == "Deliverd")
                {
                    Return_product go = new Return_product();
                    go.OrderNO = InvoiceNO;
                    go.Show();
                }

                if (OrderStutas == "Deliverd & Cash Recived")
                {
                    Return_product go = new Return_product();
                    go.OrderNO = InvoiceNO;
                    go.Show();
                }
            }

            //if (btnReturn.Text == "Delete Order")Yogesh 18 april 19
            //{
            //    string sql3 = "select * from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
            //    DataAccess.ExecuteSQL(sql3);
            //    DataTable dt3 = DataAccess.GetDataTable(sql3);
            //    if (dt3.Rows.Count > 0)
            //    {
            //        SalesRegister.DeleteOrder(salesID, true,"");
            //    }
            //}Yogesh 18 april 19

            this.Close();

        }


        private void btnSalesCredit_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;

            UserInfo.TranjationPerform = "Payment";

            if (Application.OpenForms["SalesRegister"] != null)
            {
                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                mkc1.OrderNO = InvoiceNO;
                mkc1.WindowState = FormWindowState.Maximized;
                mkc1.Show();
            }
            else
            {
                SalesRegister mkc1 = new SalesRegister();
                mkc1.OrderNO = InvoiceNO;
                mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                mkc1.Show();
            }

            this.Close();
        }

        private void btnCOD_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;

            UserInfo.TranjationPerform = "COD";

            if (Application.OpenForms["SalesRegister"] != null)
            {
                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
               
                mkc1.OrderNO = InvoiceNO;
                mkc1.Show();
            }
            else
            {
                SalesRegister mkc1 = new SalesRegister();
                mkc1.OrderNO = InvoiceNO;
                mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                mkc1.Show();
            }
            this.Close();
        }

        private void btnCashprint_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;

            UserInfo.TranjationPerform = "CashAndPrint";
           
            if (Application.OpenForms["SalesRegister"] != null)
            {
                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                mkc1.OrderNO = InvoiceNO;
                mkc1.Show();
            }
            else
            {
                SalesRegister mkc1 = new SalesRegister();
                mkc1.OrderNO = InvoiceNO;
                mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                mkc1.Show();
            }
            this.Close();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;
            string salesID = GetSalesID(InvoiceNO);
            bool Falg = SalesDetails.SplitAmount(lblorderNO.Text);

            if (Falg == false)
            {
                parameter.autoprintid = "2";
                //POSPrintRpt mkc = new POSPrintRpt(lblReceiptNo.Text);
                //POSPrintRpt mkc = new POSPrintRpt(salesID);
                //mkc.ShowDialog();

                parameter.autoprintid = "1";
                //POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                //go.ShowDialog();

                string File = SalesRegister.getPrintFile("Cash"); // Cash , Creadit , Kitchen
                string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash"); // Cash , Credit , Kitchen
                SalesRegister.PRintInvoice1(salesID, File, DefaultPrinter);
                //string typr = SalesRegister.GetStoreprintType();

                //SalesRegister.PRintInvoice(salesID, typr);// Default , Short ,Split
            }
            else
            {
                parameter.autoprintid = "2";
                //POSPrintRptSplit mkc = new POSPrintRptSplit(lblorderNO.Text);
                //mkc.ShowDialog();
                string typr = "Split";

                SalesRegister.PRintInvoice(salesID, typr);// Default , Short ,Split
            }
            this.Close();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;

            UserInfo.TranjationPerform = "Draft";

            if (Application.OpenForms["SalesRegister"] != null)
            {
                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                mkc1.OrderNO = InvoiceNO;
                mkc1.WindowState = FormWindowState.Maximized;
                mkc1.Show();
            }
            else
            {
                SalesRegister mkc1 = new SalesRegister();
                mkc1.OrderNO = InvoiceNO;
                mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                mkc1.Show();
            }

            this.Close();
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;

            if (Application.OpenForms["Delete_Invoice"] != null)
            {
                Application.OpenForms["Delete_Invoice"].BringToFront();
            }
            else
            {
                Delete_Invoice go = new Delete_Invoice();
                go.OrderNO = InvoiceNO;
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }

            this.Close();
        }

       
        private void btnBookingDelivered_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;
            string salesID = GetSalesID(InvoiceNO);
            string OrderStutas = GetOrderStutas(salesID);
            string message = "";
            if (OrderStutas == "Credit and partial payment")
            {
                message = "Credit Order Delivered for Invoice ID: " + salesID + "";
                DataAccess.BookingOrderDeliverd(salesID, "Delivered Credit and partial payment");
            }
            else if (OrderStutas == "Not Paid Booking Order Taken")
            {
                message = "Booking Order Deliverd for Invoice ID: " + salesID + "";
                DataAccess.BookingOrderDeliverd(salesID, "Booking Order Deliverd");
            }

            string sql1 = "update sales_item set IsDelivered=1 where sales_id=" + salesID + "";
            DataAccess.ExecuteSQL(sql1);
            //MyMessageAlert.ShowBox(message, "Success");
            if (Application.OpenForms["SalesRegister"] != null)
            {
                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                mkc1.DeliveryRefresh();
              
            }
            this.Close();
        }

        private void btnBookingEdit_Click(object sender, EventArgs e)
        {
            string InvoiceNO = lblorderNO.Text;

            UserInfo.TranjationPerform = "Booking";

            if (Application.OpenForms["SalesRegister"] != null)
            {
                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                mkc1.OrderNO = InvoiceNO;
                
                mkc1.WindowState = FormWindowState.Maximized;
                mkc1.Show();
            }
            else
            {
                SalesRegister mkc1 = new SalesRegister();
                mkc1.OrderNO = InvoiceNO;
                mkc1.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                mkc1.Show();
            }

            this.Close();
        }
    }
}
