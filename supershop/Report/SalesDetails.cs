using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop
{
    public partial class SalesDetails : Form
    {
        public SalesDetails(string ReceiptNo, double Discount, double subtotal, double vat, double PayAmt, double Change, double Due, string sales_ID)
        {
            InitializeComponent();
            lblSalesID.Text = sales_ID;
            lblReceiptNo.Text = ReceiptNo;
            lblDisCount.Text = Convert.ToString(Discount);
            lblVat.Text = Convert.ToString(vat);
            lblSubTotal.Text = subtotal.ToString();
            lblTotal.Text = Convert.ToString(PayAmt);
            lblChange.Text = Convert.ToString(Change);
            lblDue.Text = Convert.ToString(Due);
        }

        //Escape Closing 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Mouse Moving 
        private void MouseDown_Class_mouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }
        public void Databind()
        {
            string sqlCmd = "select  InvoiceNO as 'Receipt No' , sales_time as 'Date' ,CustItemCode as 'Item Code', itemName as 'Item Name' , UOM.UOMNAME1 As 'UOM' , " +
                            " case WHEN BatchNO ='0' THEN '' WHEN BatchNO!='0' THEN BatchNO end BatchNo , " +
                            " RetailsPrice  as 'Price' , Qty,  Total,returnQty as 'Return Qty',returnTotal as 'Return Total', Profit * Qty as 'Profit'     " +
                            " from sales_item Si Inner join ICUOM UOM on UOM.UOM = Si.UOM and UOM.TenentID = Si.TenentID Where Si.TenentID = " + Tenent.TenentID + " and sales_ID = '" + lblSalesID.Text + "' ";
            DataAccess.ExecuteSQL(sqlCmd);
            DataTable dt = DataAccess.GetDataTable(sqlCmd);
            datagrdSalesDetails.DataSource = dt;

            datagrdSalesDetails.Columns[0].Visible = false;
            datagrdSalesDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdSalesDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdSalesDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdSalesDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdSalesDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdSalesDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdSalesDetails.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdSalesDetails.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void SalesDetails_Load(object sender, EventArgs e)
        {
            Databind();
        }

        //Cross Button
        private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        public static bool SplitAmount(string InvoiceNO)
        {
            string sqlCmd = "select * from sales_payment  Where TenentID = " + Tenent.TenentID + " and InvoiceNO = '" + InvoiceNO + "' and AmountSplit=1 ";
            DataAccess.ExecuteSQL(sqlCmd);
            DataTable dt = DataAccess.GetDataTable(sqlCmd);

            int Count = dt.Rows.Count;

            if (Count > 0)
                return true;
            else
                return false;            
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            bool Falg = SplitAmount(lblReceiptNo.Text);

            if(Falg == false)
            {
                parameter.autoprintid = "2";
                //POSPrintRpt mkc = new POSPrintRpt(lblReceiptNo.Text);
                //POSPrintRpt mkc = new POSPrintRpt(lblSalesID.Text);
                //mkc.ShowDialog();

                //string typr = SalesRegister.getPrintFile("Default");  // SalesRegister.GetStoreprintType();

                //SalesRegister.PRintInvoice(lblSalesID.Text, typr);// Default , Short ,Split

                string File = SalesRegister.getPrintFile("Cash"); // Cash , Creadit , Kitchen
                string DefaultPrinter = DataAccess.USERDefaultPrinter("Cash"); // Cash , Credit , Kitchen
                SalesRegister.PRintInvoice1(lblSalesID.Text, File, DefaultPrinter);                
            }
            else
            {
                parameter.autoprintid = "2";
                //POSPrintRptSplit mkc = new POSPrintRptSplit(lblReceiptNo.Text);
                //mkc.ShowDialog();

                string typr = "Split";
                SalesRegister.PRintInvoice(lblReceiptNo.Text, typr);// Default , Short ,Split
            }

            //PrintPage mkc = new PrintPage();
            //mkc.saleno      = lblReceiptNo.Text;
            //mkc.vat         = "";
            //mkc.dis         = "";
            //mkc.paidamt     = lblTotal.Text;
            //mkc.subtotal    = lblSubTotal.Text;
            //mkc.ShowDialog();
        }

    }
}
