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
    public partial class DriverAction : Form
    {
        private int desiredStartLocationX;
        private int desiredStartLocationY;
        public DriverAction(int x, int y)
        {
            InitializeComponent();

            this.desiredStartLocationX = x;
            this.desiredStartLocationY = y;

            Load += new EventHandler(DriverAction_Load);
        }

        private void DriverAction_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(desiredStartLocationX, desiredStartLocationY);
            string InvoiceNO = lblorderNO.Text;
            string salesID = GetSalesID(InvoiceNO);            

            string DriverName = GetDriver(salesID);

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

            string OrderStutas = CashierAction.GetOrderStutas(salesID);

            if (OrderStutas == "Deliverd")
            {
                btnDriverAssign.Enabled = false;
                btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
            }
            else if (OrderStutas == "Deliverd & Cash Recived")
            {
                btnDriverAssign.Enabled = false;
                btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
            }
            else if (OrderStutas == "Return")
            {
                
                btnDriverAssign.Enabled = false;
                btnDriverAssign.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnDeliverd.Enabled = false;
                btnDeliverd.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnReturn.Text = "Return";
            }
            else
            {
                btnReturn.Text = "Return";
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

            string Complate = CashierAction.GetOrderStutas(salesID);

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
            string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and sales_id=" + salesID + " ";
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
            string sql3 = "select * from sales_item where TenentID=" + Tenent.TenentID + " and InvoiceNO='" + InvoiceNO + "' ";
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
            string Complate = CashierAction.GetOrderStutas(salesID);

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

            UserInfo.TranjationPerform = "Deliverd";

            if (Application.OpenForms["SalesRegister"] != null)
            {
                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                mkc1.OrderNO = InvoiceNO;
                mkc1.Show();
            }            
            this.Close();
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

            string Complate = CashierAction.GetOrderStutas(salesID);
            if (Complate == "Return")
            {
                MessageBox.Show("Already Return this Order...");
                return;
            }

            if (btnReturn.Text == "Return")
            {
                string OrderStutas = CashierAction.GetOrderStutas(salesID);

                if (OrderStutas == "Not Paid Order Taken")
                {
                    //Delete Code
                    string sql3 = "select * from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);
                    if (dt3.Rows.Count > 0)
                    {
                        DeleteOrder(salesID);
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
                        DeleteOrder(salesID);
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
                        DeleteOrder(salesID);
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

            if (btnReturn.Text == "Delete Order")
            {
                string sql3 = "select * from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sql3);
                DataTable dt3 = DataAccess.GetDataTable(sql3);
                if (dt3.Rows.Count > 0)
                {
                    DeleteOrder(salesID);
                }
            }

            this.Close();

        }

        public void DeleteOrder(string salesID)
        {
             DialogResult result = MessageBox.Show("Are Yor Sure? Your Sale order is Permenent Delete " , "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
             { 
                 string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                 string sql3 = "Delete from sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                 DataAccess.ExecuteSQL(sql3);

                 string sqlUpdateCmdWIN = " delete from Win_sales_item where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                 Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "Win_sales_item", "DELETE");

                 string sql = "Delete from sales_payment where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                 DataAccess.ExecuteSQL(sql);

                 string sqlWIN = " delete from Win_sales_payment where sales_id  = '" + salesID + "' and TenentID= " + Tenent.TenentID + " ";
                 Datasyncpso.insert_Live_sync(sqlWIN, "Win_sales_payment", "DELETE");
             }


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

                string typr = SalesRegister.GetStoreprintType();

                SalesRegister.PRintInvoice(salesID, typr);// Default , Short ,Split
            }
            else
            {
                parameter.autoprintid = "2";
                //POSPrintRptSplit mkc = new POSPrintRptSplit(lblorderNO.Text);
                //mkc.ShowDialog();
                string typr = "Split";

                SalesRegister.PRintInvoice(lblorderNO.Text, typr);// Default , Short ,Split
            }
            this.Close();
        }


    }
}
