using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Data_Manage
{
    public partial class DataReset : Form
    {
        public DataReset()
        {
            InitializeComponent();
        }

        private void btntruncate_Click(object sender, EventArgs e)
        {
            try
            {
                 DialogResult result = MessageBox.Show("Do you want Reset Database ? \n you will be loss all Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                 if (result == DialogResult.Yes)
                 {
                     if (rdbsqlite.Checked == true)
                     {
                         int TID = Tenent.TenentID;

                         string sql1 =  "DELETE FROM return_item; " +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'return_item'; " + 
                                        " DELETE FROM sales_item; " +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'sales_item'; " +
                                        " DELETE FROM sales_payment;" +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'sales_payment'; " +
                                        " DELETE FROM tbl_saleInfo;" +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'tbl_saleInfo'; " +
                                        " DELETE FROM purchase;" +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'purchase'; " +
                                        " DELETE FROM tbl_duepayment;" +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'tbl_duepayment'; " +
                                        " DELETE FROM tbl_purchase_history; " +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'tbl_purchase_history'; " +
                                        " DELETE FROM tbl_workrecords; " +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'tbl_workrecords'; " +
                                        " DELETE FROM tbl_orderWay_transection; " +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'tbl_orderWay_transection'; " +
                                        " DELETE FROM CAT_MST; " +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'CAT_MST'; " +
                                        " DELETE FROM ICUOM; " +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'ICUOM'; " +
                                        " DELETE FROM DayClose; " +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'DayClose'; " +
                                        " DELETE FROM tbl_item_uom_price; " +
                                        " UPDATE SQLITE_SEQUENCE SET seq = 0   where name = 'tbl_item_uom_price'; ";


                         DataTable dt1 = DataAccess.GetDataTable(sql1);                          
                         MessageBox.Show("Successfully truncated !!! ", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     }
                     else
                     {
                         string sql1 =  " TRUNCATE TABLE return_item ; " + 
                                        " TRUNCATE TABLE sales_item ; " +
                                        " TRUNCATE TABLE sales_payment; " +
                                        " TRUNCATE TABLE tbl_saleInfo; " +
                                        " TRUNCATE TABLE purchase; " +
                                        " TRUNCATE TABLE tbl_duepayment; " +                                        
	                                    " TRUNCATE TABLE tbl_purchase_history; " +
                                        " TRUNCATE TABLE tbl_item_uom_price; " +
                                        " TRUNCATE TABLE tbl_orderWay_transection; " +
	                                    " TRUNCATE TABLE tbl_workrecords; ";
                         DataTable dt1 = DataAccess.GetDataTable(sql1);                          
                         MessageBox.Show("Successfully truncated !!! ", "Not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     }
                 }                        
            }
            catch
            {
            }
              
        }
    }
}
