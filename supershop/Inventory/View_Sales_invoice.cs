using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace supershop
{
    public partial class View_Sales_invoice : Form
    {
        public View_Sales_invoice(string InvoiceNo)
        {
            InitializeComponent();
            lblInvoiceNo.Text = InvoiceNo;
            // lblctype.Text = ctype;
            //if ctype 0 = customer 1 = admin
            // if 0 take payment button is not show
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void SalesPaymentInfo()
        {
            // // Sale Info
            string sqlSale = "select * from tbl_saleInfo  where TenentID = " + Tenent.TenentID + " and InvoiceNO  = '" + lblInvoiceNo.Text + "' ";
            DataAccess.ExecuteSQL(sqlSale);
            DataTable dtsqlSale = DataAccess.GetDataTable(sqlSale);
            if (dtsqlSale.Rows.Count > 0)
            {
                lblSalesDate.Text = dtsqlSale.Rows[0].ItemArray[10].ToString();
                lblShippingfee.Text = dtsqlSale.Rows[0].ItemArray[8].ToString();
                txtCondition.Text = dtsqlSale.Rows[0].ItemArray[5].ToString();
                lblcustid.Text = dtsqlSale.Rows[0].ItemArray[4].ToString();
            }


            // // Customer Info
            string sqlCmd = "select * from tbl_customer  where TenentID = " + Tenent.TenentID + " and ID  = '" + lblcustid.Text + "' ";
            DataAccess.ExecuteSQL(sqlCmd);
            DataTable dt = DataAccess.GetDataTable(sqlCmd);
            if (dt.Rows.Count > 0)
            {
                lblCustomer.Text = dt.Rows[0].ItemArray[1].ToString();
                lblCustAddress.Text = dt.Rows[0].ItemArray[4].ToString() + " , " + dt.Rows[0].ItemArray[5].ToString();
                lblEmail.Text = dt.Rows[0].ItemArray[2].ToString();
                lblPhone.Text = dt.Rows[0].ItemArray[3].ToString();
            }

        }

        private void View_Sales_invoice_Load(object sender, EventArgs e)
        {
            try
            {
                SalesPaymentInfo();

                string sql = "select  itemName 'Products' , Retailsprice 'Price' ," +
                            " Qty 'Quantity', Total  'Total'    from sales_item where TenentID = " + Tenent.TenentID + " and InvoiceNO = '" + lblInvoiceNo.Text + "' ";
                DataAccess.ExecuteSQL(sql);
                DataTable dt = DataAccess.GetDataTable(sql);
                dgrvSalesInvoice.DataSource = dt;


                string sql3 = "select SUM(total)    from sales_item  where TenentID = " + Tenent.TenentID + " and InvoiceNO = '" + lblInvoiceNo.Text + "'  ";
                DataAccess.ExecuteSQL(sql3);
                DataTable dt3 = DataAccess.GetDataTable(sql3);

                string sqltbl = "select *  from sales_payment where TenentID = " + Tenent.TenentID + " and InvoiceNO = '" + lblInvoiceNo.Text + "' and  TrxType = 'Inventory' ";
                DataAccess.ExecuteSQL(sqltbl);
                DataTable dttbl = DataAccess.GetDataTable(sqltbl);

                DataRow dr = dt.NewRow();
                dr[0] = " ";
                dt.Rows.Add(dr);

                DataRow SubTotal = dt.NewRow();
                SubTotal[0] = "Sub Total ";
                SubTotal[3] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                dt.Rows.Add(SubTotal);

                DataRow dis = dt.NewRow();
                dis[0] = "Discount ";
                dis[3] = Convert.ToDouble(dttbl.Rows[0].ItemArray[5].ToString());
                dt.Rows.Add(dis);

                DataRow VAT = dt.NewRow();
                VAT[0] = "VAT ";
                VAT[3] = Convert.ToDouble(dttbl.Rows[0].ItemArray[6].ToString());
                dt.Rows.Add(VAT);

                DataRow dr87 = dt.NewRow();
                dr87[0] = "------------------------------ ";

                dt.Rows.Add(dr87);

                DataRow Total = dt.NewRow();
                Total[0] = "Grand Total";
                Total[3] = Convert.ToDouble(dttbl.Rows[0].ItemArray[2].ToString());
                dt.Rows.Add(Total);

                //DataRow Paid = dt.NewRow();
                //Paid[0] = "Total Paid";
                //Paid[3] = Convert.ToDouble(dttbl.Rows[0].ItemArray[2].ToString()) + Convert.ToDouble(dttbl.Rows[0].ItemArray[3].ToString());
                //dt.Rows.Add(Paid);

                DataRow due = dt.NewRow();
                due[0] = "Due";
                due[3] = Convert.ToDouble(dttbl.Rows[0].ItemArray[4].ToString());
                dt.Rows.Add(due);

                DataRow ShippingFee = dt.NewRow();
                ShippingFee[0] = "Shipping Fee";
                ShippingFee[3] = Convert.ToDouble(lblShippingfee.Text);
                dt.Rows.Add(ShippingFee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDue_Click(object sender, EventArgs e)
        {
            //Sales.TakePayment go = new Sales.TakePayment(lblInvoiceNo.Text);
            //go.ShowDialog(); 
            //this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sql3 = "select * from tbl_terminalLocation where TenentID = " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            DateTime dt = DateTime.Now;
            string printdate = dt.ToString("MMM-dd, yyyy HH:mm:ss");
            string Companyname = dt1.Rows[0].ItemArray[1].ToString();
            string branchname = dt1.Rows[0].ItemArray[2].ToString();
            string Location = dt1.Rows[0].ItemArray[3].ToString();
            string phone = dt1.Rows[0].ItemArray[4].ToString();
            string email = dt1.Rows[0].ItemArray[5].ToString();
            string web = dt1.Rows[0].ItemArray[6].ToString();

            string Header = Location + "." + "\n" + email + "\n" + branchname + " ph: " + phone + "\n" + printdate + "\n";
            string Sellerinfo = Location + "." + "\n" + email + "\n" + phone + "\n" + printdate + "\n";
            // string hd           = address + "\n" + phone + "\n" + vatno + "\n" + web;
            // var result = web.Insert(7, "</b>").Insert(6 - 1, "<b>");

            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("InvoicePdf\\SalesInvoice.pdf", FileMode.Create));
            doc.Open();//Open Document to write

            //// Invoice Header 
            iTextSharp.text.Font InvoiceFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
            iTextSharp.text.Font HeaderFont = FontFactory.GetFont("Times New Roman", 11, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY);
            iTextSharp.text.Font HeaderFont2 = FontFactory.GetFont("Times New Roman", 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            Paragraph Invoice = new Paragraph("Invoice", InvoiceFont);
            Paragraph Header1 = new Paragraph(Companyname, HeaderFont);
            Paragraph Header2 = new Paragraph(Header, HeaderFont2);
            Invoice.IndentationLeft = 455f;
            Header2.IndentationLeft = 55f;
            Header1.IndentationLeft = 55f;
            doc.Add(Invoice);
            doc.Add(Header1);
            doc.Add(Header2);

            //// Bill to and ship to information
            iTextSharp.text.Font fontTable2 = FontFactory.GetFont("Arial", 2, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
            PdfPTable table2 = new PdfPTable(3);
            table2.SpacingBefore = 45f;
            table2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            table2.DefaultCell.Padding = 3;

            //table2.AddCell(cell);
            table2.TotalWidth = 800;
            table2.SetTotalWidth(new float[] { 300f, 300f, 250f });
            table2.DefaultCell.Phrase = new Phrase() { Font = HeaderFont };

            table2.AddCell("Bill To" + "\n ----------");
            table2.AddCell("Ship To" + "\n ----------");
            table2.AddCell("Invoice" + "\n ----------");

            // table2.AddCell("");
            //   table2.AddCell("Invoice #: " + lblInvoiceNo.Text);  

            //Seller info  
            table2.AddCell(Companyname + "\n" + Sellerinfo);
            table2.AddCell(lblCustomer.Text + "\n" + lblEmail.Text + "\n" + lblPhone.Text + "\n" + lblCustAddress.Text);
            table2.AddCell("Invoice #: " + lblInvoiceNo.Text + "\n" + "Date: " + lblSalesDate.Text);
            doc.Add(table2);


            //// Get datagridview Data
            iTextSharp.text.Font fontTable = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            PdfPTable table = new PdfPTable(dgrvSalesInvoice.Columns.Count);
            table.SpacingBefore = 45f;
            table.TotalWidth = 300;
            table.DefaultCell.Phrase = new Phrase() { Font = fontTable };

            for (int j = 0; j < dgrvSalesInvoice.Columns.Count; j++)
            {
                if (dgrvSalesInvoice.Columns[j].Name == "Something")
                {
                    continue;
                }
                table.AddCell(new Phrase(dgrvSalesInvoice.Columns[j].HeaderText));

            }

            table.HeaderRows = 1;

            for (int i = 0; i < dgrvSalesInvoice.Rows.Count; i++)
            {
                for (int k = 0; k < dgrvSalesInvoice.Columns.Count; k++)
                {
                    if (dgrvSalesInvoice.Columns[k].Name == "Something")
                    {
                        continue;
                    }
                    if (dgrvSalesInvoice[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dgrvSalesInvoice[k, i].Value.ToString(), fontTable));
                    }
                }
            }
            doc.Add(table);


            //// Condition
            iTextSharp.text.Font ConditionFont2 = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.UNDERLINE, BaseColor.BLACK);
            iTextSharp.text.Font ConditionFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            Paragraph Condition2 = new Paragraph("Special Notes and Instuctions", ConditionFont2);
            Paragraph Condition = new Paragraph(txtCondition.Text, ConditionFont);
            Condition2.IndentationLeft = 55f;
            Condition.IndentationLeft = 55f;
            doc.Add(Condition2);
            doc.Add(Condition);



            string printtime = DateTime.Now.ToString("yyyy-MMMM-dd HH:mm:ss");
            //// Invoice Footer 
            iTextSharp.text.Font FooterFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);
            Paragraph Footer1 = new Paragraph("____________________________________________________________________________________");
            Paragraph Footer2 = new Paragraph("This is a computer generated copy.   " + "\n Print: " + printtime, FooterFont);
            Footer2.IndentationLeft = 200f;
            doc.Add(Footer1);
            doc.Add(Footer2);


            ///--------------------------------///

            //RomanList rl = new RomanList(false,20);
            //rl.IndentationLeft = 260f;
            //rl.Add(new ListItem("Company limited inc."));         
            //doc.Add(rl);


            //List lst = new List(List.UNORDERED);
            //lst.Add(new ListItem("T"));            
            //doc.Add(lst);

            ////Create table by setting table value datagridview

            ///--------------------------------///

            //
            //MessageBox.Show("PDF Created!");
            doc.Close();

            Inventory.InvoicePrintCopy go = new Inventory.InvoicePrintCopy();
            go.ShowDialog();
        }
    }
}
