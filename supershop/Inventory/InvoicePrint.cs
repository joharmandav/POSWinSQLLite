using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace supershop.Inventory
{
    public partial class InvoicePrint : Form
    {
        public InvoicePrint(string InvoiceNo)
        {
            InitializeComponent();
            lblInvoiceNo.Text = InvoiceNo;
        }

        #region Invoice Setup Printing

        DataGridViewPrinter MyDataGridViewPrinter;
        private bool SetupThePrinting()
        {
            string sql3 = "select * from tbl_terminalLocation where TenentID = " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            DateTime dt = DateTime.Now;
            string printdate = dt.ToString("MMMM dd, yyyy    hh:mm:ss tt");
            string Companyname = dt1.Rows[0].ItemArray[1].ToString();
            string branchname = dt1.Rows[0].ItemArray[2].ToString();
            string Location = dt1.Rows[0].ItemArray[3].ToString();
            string phone = dt1.Rows[0].ItemArray[4].ToString();
            string email = dt1.Rows[0].ItemArray[5].ToString();
            string web = dt1.Rows[0].ItemArray[6].ToString();



            // // Biller Info
            string sqlCmd = "select * from tbl_saleInfo where TenentID = " + Tenent.TenentID + " and InvoiceNo = '" + lblInvoiceNo.Text + "' ";
            DataAccess.ExecuteSQL(sqlCmd);
            DataTable dtSP = DataAccess.GetDataTable(sqlCmd);
            string Bnam = "Bill To \n" + dtSP.Rows[0].ItemArray[3].ToString();

            //  string Header = Companyname + "\n" + Location + "." + "\n" + email + "\n" + branchname + " ph: " + phone + "\n" + printdate + "\n";
            //cname.Font = new System.Drawing.Font("Tahoma", 12.0F);
            string TitleText = Companyname + "\n" + Location + "." + "\n" + email + "\n" + printdate + "\n\n" + Bnam + "\n\n" + "Invoice No: " + lblInvoiceNo.Text + "\n\n";

            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;


            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            printDocument1.DocumentName = "Invoice";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);


            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            //    MyDataGridViewPrinter = new DataGridViewPrinter(datagrdSalesInvoice,
            //    printDocument1, true, true, TitleText, new Font("Tahoma", 10,
            //    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            //else

            MyDataGridViewPrinter = new DataGridViewPrinter(datagrdSalesInvoice,
             printDocument1, false, true, TitleText, new Font("Times New Roman", 13, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
            return true;
        }

        #endregion Invoice Setup Printing

        //Cross Button
        private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            //bool more2 = MyDataGridViewPrinter2.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
            //else  if (more2 == true)
            //    e.HasMorePages = false;
        }

        #region Invoice DataBind
        public void InvoiceDataBind()
        {
            if (lblInvoiceNo.Text == "")
            {
                MessageBox.Show("Please add atleast one item");
            }
            else
            {
                try
                {
                    string InvoiceNo = lblInvoiceNo.Text;
                    string sql = "select itemName as Items ,  RetailsPrice as Price , Qty  , Total   from sales_item where TenentID = " + Tenent.TenentID + " and (sales_id = '" + InvoiceNo + "')";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdSalesInvoice.DataSource = dt1;

                    //Total calculation
                    string sql3 = "select SUM(Total)   from sales_item  where TenentID = " + Tenent.TenentID + " and sales_id = '" + InvoiceNo + "'";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);
                    /////label5.Text = "Total : " + dt3.Rows[0].ItemArray[0].ToString();

                    string sql6 = "select * from sales_payment  where TenentID = " + Tenent.TenentID + " and (sales_id = '" + InvoiceNo + "')";
                    DataAccess.ExecuteSQL(sql6);
                    DataTable dt6 = DataAccess.GetDataTable(sql6);

                    //Invoice  Shippingfee 
                    string sqlSaleinfo = "select ShippingFee from tbl_saleInfo  where TenentID = " + Tenent.TenentID + " and (InvoiceNo = '" + InvoiceNo + "')";
                    DataAccess.ExecuteSQL(sqlSaleinfo);
                    DataTable dtSaleinfo = DataAccess.GetDataTable(sqlSaleinfo);


                    // Header info
                    string sqlTitle = "select * from tbl_terminalLocation where TenentID = " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
                    DataAccess.ExecuteSQL(sqlTitle);
                    DataTable dtTitle = DataAccess.GetDataTable(sqlTitle);
                    string Ph = dtTitle.Rows[0].ItemArray[4].ToString();
                    string web = dtTitle.Rows[0].ItemArray[6].ToString();

                    DataRow dr = dt1.NewRow();
                    dr[0] = "";
                    dt1.Rows.Add(dr);

                    /// Sub total = total - Discount
                    DataRow Total = dt1.NewRow();
                    Total[0] = "Total Amount: ";
                    Total[3] = dt3.Rows[0].ItemArray[0].ToString();
                    dt1.Rows.Add(Total);

                    DataRow dis = dt1.NewRow();
                    dis[0] = "Discount Amount: ";
                    dis[3] = dt6.Rows[0].ItemArray[5].ToString();
                    dt1.Rows.Add(dis);

                    DataRow dotlineSubtotal = dt1.NewRow();
                    dotlineSubtotal[0] = "___________________________________________________________________";
                    //dotlineSubtotal[3] = 9898988.99;
                    dt1.Rows.Add(dotlineSubtotal);

                    /// Sub total = total - Discount
                    DataRow Subtotal = dt1.NewRow();
                    Subtotal[0] = "Sub total : ";
                    Subtotal[3] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt6.Rows[0].ItemArray[5].ToString());
                    dt1.Rows.Add(Subtotal);

                    DataRow dr0 = dt1.NewRow();
                    dr0[0] = "Invoice Tax :";
                    dr0[3] = dt6.Rows[0].ItemArray[6].ToString();
                    dt1.Rows.Add(dr0);

                    DataRow dotline = dt1.NewRow();
                    dotline[0] = "___________________________________________________________________";
                    dt1.Rows.Add(dotline);

                    //Shipping Fee
                    DataRow dr20 = dt1.NewRow();
                    dr20[0] = "Shipping Fee :";
                    dr20[3] = dtSaleinfo.Rows[0].ItemArray[0].ToString();
                    dt1.Rows.Add(dr20);

                    DataRow dotline2 = dt1.NewRow();
                    dotline2[0] = "___________________________________________________________________";
                    dt1.Rows.Add(dotline2);

                    // Net Amount = Sub total + VAT
                    DataRow dr2 = dt1.NewRow();
                    dr2[0] = "Net Amount :  ";
                    dr2[3] = dt6.Rows[0].ItemArray[2].ToString();
                    dt1.Rows.Add(dr2);


                    DataRow dr6 = dt1.NewRow();
                    dr6[0] = "\n\n";
                    dt1.Rows.Add(dr6);

                    DataRow dr7 = dt1.NewRow();
                    dr7[0] = "|||| ||| |||||||| This is computer generated invoice printed copy. | Contact: " + Ph;
                    dt1.Rows.Add(dr7);

                    DataRow dr9 = dt1.NewRow();
                    dr9[0] = "|||| ||| |||||||| Web: " + web;
                    dt1.Rows.Add(dr9);

                    //DataRow emp = dt1.NewRow();
                    //emp[0] = "Served by: " + dt6.Rows[0].ItemArray[9].ToString();
                    //dt1.Rows.Add(emp);

                    //DataRow dr8 = dt1.NewRow();
                    //dr8[0] = "Recipt No : " + dt6.Rows[0].ItemArray[0].ToString();
                    //dt1.Rows.Add(dr8);

                    //DataRow credit = dt1.NewRow();
                    //credit[0] = "johar@writeme.com ";
                    //dt1.Rows.Add(credit);

                    //label4.Text = dt6.Rows[0].ItemArray[9].ToString();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Sorry !!!! !! \r\n" + exp.Message);
                }
            }
        }
        #endregion

        private void InvoicePrint_Load(object sender, EventArgs e)
        {
            InvoiceDataBind();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetupThePrinting())
                {
                    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    MyPrintPreviewDialog.Document = printDocument1;
                    MyPrintPreviewDialog.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Sorry\r\n You have to Check the Data " + exp.Message);
            }

        }

    }
}
