using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Items
{
    public partial class SRtaxcalc : Form
    {
        public SRtaxcalc()
        {
            InitializeComponent();
        }

        private void SRtaxcalc_Load(object sender, EventArgs e)
        {
            //double OnHand = 2;
            string sql = "SELECT  product_name as Name , price as Price , OnHand  as QTY, (price * OnHand) * 1.00  as 'Total'  ,  discount as 'Dis %', " +
                        " (((price * OnHand) * discount) / 100.00) as 'dis amt' , " +
                        "  (price * OnHand)  - (((price * OnHand) * discount) / 100.00)   'Total [after dis} ' , taxapply ,  " +
                        " CASE     " +
                        " WHEN taxapply = 1 THEN 15.00 " +
                        " ELSE '0.00' " +
                        " END 'Tax%' ,  " +
                        " CASE     " +
                        " WHEN taxapply = 1 THEN   (((price * OnHand)  - (((price * OnHand) * discount) / 100.00))  * 15.00) / 100.00   " +
                        " ELSE '0.00'  " +
                        " END 'tax amt' ,   " +
                        " CASE    " +
                        " WHEN taxapply = 1 THEN   (price * OnHand)  - (((price * OnHand) * discount) / 100.00)   +  ((((price * OnHand)  - (((price * OnHand) * discount) / 100.00))  * 15.00) / 100.00)  " +
                        " ELSE   (price * OnHand)  - (((price * OnHand) * discount) / 100.00)       " +
                        " END 'after tax Gross total'  , product_id as ID " +
                        " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID    where product_id in (5656,80045332,8940000000034, 89234500012 ,8940000000027)";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dgrvSalesItemList.DataSource = dt1;
            
           
            DiscountCalculation();
            vatcal();
            //dgrvSalesItemList.Columns[3].Visible = false; // Sub Total
            //dgrvSalesItemList.Columns[5].Visible = false; // dis amt
            //dgrvSalesItemList.Columns[7].Visible = false; // taxapply
            //dgrvSalesItemList.Columns[8].Visible = false; // Tax%
            //dgrvSalesItemList.Columns[9].Visible = false; // tax amt
            //dgrvSalesItemList.Columns[10].Visible = false; // after tax Gross total
        }

        // Discount Calculation
        public void DiscountCalculation()
        {
            // // subtotal without dis vat sum 
            double totalsum = 0.00;
            for (int i = 0; i < dgrvSalesItemList.Rows.Count; ++i)
            {
                totalsum += Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value);
            }
            lblTotal.Text = Math.Round(totalsum, 2).ToString();  
            lblTotalItems.Text = dgrvSalesItemList.RowCount.ToString();

            ////    Discount
            double total = Convert.ToDouble(totalsum.ToString());
            double DisCount = 0.00;             
            for (int i = 0; i < dgrvSalesItemList.Rows.Count; ++i)
            {
                DisCount += Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[5].Value);
            }
            double sum = total - DisCount;
            sum = Math.Round(sum, 2);
            DisCount = Math.Round(DisCount, 2);
            lblsubtotal.Text = sum.ToString();

            double payable = sum + Convert.ToDouble(lblTotalVAT.Text);
            lblTotalPayable.Text = payable.ToString();

            lblTotalDisCount.Text = DisCount.ToString();
           
        }

        //VAT calculation
        public void vatcal()
        {
            double Subtotal = Convert.ToDouble(lblsubtotal.Text);
            double VAT = 0.00;  
            for (int i = 0; i < dgrvSalesItemList.Rows.Count; ++i)
            {
                VAT += Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[9].Value);
            }

            VAT = Math.Round(VAT, 2);
            lblTotalVAT.Text = VAT.ToString();

            double payable = Subtotal + VAT;
            payable = Math.Round(payable, 2);

            lblTotalPayable.Text = payable.ToString();           
        }
        
    }
}
