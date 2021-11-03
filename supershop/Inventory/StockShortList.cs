using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Inventory
{
    public partial class StockShortList : Form
    {
        public StockShortList()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
               this.Close();            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void StockShortList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }
        

        private void loadData()
        {
            string sql = "select product_id as 'Code/ID', product_name as 'Item Name' , OnHand as 'Qty/Stock-Item' ," +
               "  price as 'Sale Price' , category as 'Category' , supplier as 'Supplier'  ,UOM as UOM  " +
               "  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
               " Where purchase.TenentID = " + Tenent.TenentID + " ";
           
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dtgrdViewStockItem.DataSource = dt1;
            dtgrdViewStockItem.Columns[0].ReadOnly = false;
            dtgrdViewStockItem.Columns[1].ReadOnly = true;
            dtgrdViewStockItem.Columns[2].ReadOnly = true;
            dtgrdViewStockItem.Columns[3].ReadOnly = true;
            dtgrdViewStockItem.Columns[4].ReadOnly = true;
            dtgrdViewStockItem.Columns[5].ReadOnly = true;
            dtgrdViewStockItem.Columns[6].ReadOnly = true;
            dtgrdViewStockItem.Columns[0].ToolTipText = " Click on Code/ID row it's automatically copied ";
            dtgrdViewStockItem.Rows[0].Cells[0].ToolTipText = " Click on Code/ID row it's automatically copied ";

            DataGridViewColumn ColName = dtgrdViewStockItem.Columns[1];
            ColName.Width = 151;
        }
        private void txtItemSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (txtItemSearchBar.Text == "")
            {
                //MessageBox.Show("Please Type product id ");
            }
            else
            {
                try
                {

                    string sql = "select product_id as 'Code/ID', product_name as 'Item Name' , OnHand as 'Qty/Stock-Item' , " +
                                   "  msrp as 'Cost Price' , price as 'Sale Price' , category as 'Category' , supplier as 'Supplier',UOM as UOM   " +
                                   "   FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " + 
                                   " where purchase.TenentID = " + Tenent.TenentID + " and ( product_id like  '%" + txtItemSearchBar.Text + "%' or " + 
                                   "  product_name like '%" + txtItemSearchBar.Text + "%'or category like '%" + txtItemSearchBar.Text + "%' " + 
                                    "  or supplier like '%" + txtItemSearchBar.Text + "%') ";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    dtgrdViewStockItem.DataSource = dt1;

                    //string sql3 = "select SUM(total_msrp)   FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID  where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + txtItemSearchBar.Text + "'";
                    //DataAccess.ExecuteSQL(sql3);
                    //DataTable dt3 = DataAccess.GetDataTable(sql3);


                    //string sql5 = "select SUM(total_price) FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + txtItemSearchBar.Text + "'";
                    //DataAccess.ExecuteSQL(sql5);
                    //DataTable dt5 = DataAccess.GetDataTable(sql3);

                    
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Sorry\r\n" + exp.Message);
                }
            }
        }

        private void StockShortList_Load(object sender, EventArgs e)
        {
            
          //  dtgrdViewStockItem.DataSource = vatdisvalue.vat;
             loadData();
        }

        private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void dtgrdViewStockItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dtgrdViewStockItem.Rows[e.RowIndex];
                // /UserInfo.invoiceNo = row.Cells[0].Value.ToString(); //barcode number
                Clipboard.SetText(row.Cells[0].Value.ToString());
                //this.Hide();
                //Inventory.Add_Sales go = new Inventory.Add_Sales(UserInfo.UserName);
                //go.MdiParent = this.ParentForm;
                //go.Show();
            }
            catch
            {
            }
        
        }

        private void dtgrdViewStockItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.F5))
            {
              //  DataGridViewRow row = dtgrdViewStockItem.Rows[ee.RowIndex];                
               // Clipboard.SetText(row.Cells[0].Value.ToString());
            }
        }
    }
}
