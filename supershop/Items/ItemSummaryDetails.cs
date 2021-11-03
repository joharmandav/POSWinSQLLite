using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Resources;
using System.Globalization;
using System.Threading;


namespace supershop
{
    public partial class ItemSummaryDetails : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public ItemSummaryDetails()
        {
            InitializeComponent();
        }

       

        bool FirstTime;

        private void Stock_List_Load(object sender, EventArgs e)
        {
            try
            {
               if(lblItemcode.Text!="")
               {

               }
               
            }
            catch
            {
            }
        }
        public string itemCode
        {
            set { lblItemcode.Text = value; }
            get { return lblItemcode.Text; }
        }
        #region Data bind

       

      
     

      

        //Show Products image
        public void ItemList_with_images(string value)
        {
            flowLayoutPanelUserList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg *.bmp *.jeg");
            try
            {
                string sql = "SELECT  Shopid,product_name,product_name_Arabic,category,CAT.CAT_NAme1 As 'category_Eng' ,category_arabic,supplier,status,taxapply,imagename,product_id,UOMID,IC.UOMNAME1 as 'UOMNAME', " +
                    " msrp,price,Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,CustItemCode,BarCode " +
                    " FROM  purchase PI INNER JOIN tbl_item_uom_price iup ON PI.product_id = iup.itemID and PI.TenentID = iup.TenentID " +
                    " INNER JOIN CAT_MST CAT ON PI.category = CAT.CATID and PI.TenentID = CAT.TenentID INNER JOIN ICUOM IC ON iup.UOMID = IC.UOM and iup.TenentID = IC.TenentID  " +
                    " where PI.TenentID = " + Tenent.TenentID + " and (( product_name like '%" + value + "%' ) OR (product_name_Arabic like '%" + value + "%' ) " +
                    " OR ( product_id like '%" + value + "%' ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' ) " +
                    " OR (CAT.CAT_NAme1 = '" + value + "') OR (category_arabic = '" + value + "')) order by product_id ";

                DataTable dt = DataAccess.GetDataTable(sql);
               

                
               
            }
            catch //(Exception)
            {
                //throw;
            }
        }

        public void ItemList_without_images(string value)
        {
            flowLayoutPanelUserList.Controls.Clear();

            try
            {
                string sql = " SELECT  (product_id || ' (' || CustItemCode ||')') as 'Item Code' , (product_name || '-' ||product_name_Arabic) as 'Item Name', " +
                             " (IC.UOMNAME1 || ' -' || IC.UOMNAME2) as 'UOM', printf('%.3f', OpQty) as 'Opening Stock' ,printf('%.3f', QtyRecived) as 'Stock In',printf('%.3f', QtyOut) as 'Stock Out',printf('%.3f', ir.Qty) as 'Return', printf('%.3f', OnHand)  as 'Stock In Hand'," +
                             " price as 'Unit Price', msrp as 'Sale Price' ,category " +
                             " FROM  purchase PI INNER JOIN tbl_item_uom_price iup ON PI.product_id = iup.itemID and PI.TenentID = iup.TenentID " +
                             " left JOIN return_item ir ON  PI.product_id = ir.item_id and PI.TenentID = ir.TenentID INNER JOIN CAT_MST CAT ON PI.category = CAT.CATID and PI.TenentID = CAT.TenentID INNER JOIN ICUOM IC ON iup.UOMID = IC.UOM and iup.TenentID = IC.TenentID  " +
                             " where PI.TenentID = " + Tenent.TenentID + " and (( product_name like '%" + value + "%' ) OR (product_name_Arabic like '%" + value + "%' ) " +
                             " OR ( product_id like '%" + value + "%' ) OR ( CustItemCode like '%" + value + "%' ) OR ( BarCode like '%" + value + "%' ) " +
                             " OR (CAT.CAT_NAme1 = '" + value + "') OR (category_arabic = '" + value + "')) group by product_id order by product_id ";

                DataTable dt = DataAccess.GetDataTable(sql);
               

                dgrvProductList.DataSource = dt;

                

            }
            catch //(Exception)
            {
                //throw;
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

                        int X = (this.tabControl1.Width / 2);
                        int Y = (this.tabControl1.Height / 2);
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

        public void ItemList_with_images_Catagory(string value)
        {
            flowLayoutPanelUserList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg *.bmp *.jeg");
            try
            {
                string sql = "";
                if (value != "")
                {
                    sql = "SELECT  Shopid,product_name,product_name_Arabic,category,CAT.CAT_NAme1 As 'category_Eng' ,category_arabic,supplier,status,taxapply,imagename,product_id,UOMID,IC.UOMNAME1 as 'UOMNAME', " +
                        " msrp,price,Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,CustItemCode,BarCode " +
                        " FROM  purchase PI INNER JOIN tbl_item_uom_price iup ON PI.product_id = iup.itemID and PI.TenentID = iup.TenentID " +
                        " INNER JOIN CAT_MST CAT ON PI.category = CAT.CATID and PI.TenentID = CAT.TenentID INNER JOIN ICUOM IC ON iup.UOMID = IC.UOM and iup.TenentID = IC.TenentID  " +
                        " where PI.TenentID =" + Tenent.TenentID + " and (CAT.CAT_NAme1 = '" + value + "') OR (category_arabic = '" + value + "') order by product_id ";
                }
                else
                {
                    sql = "SELECT  Shopid,product_name,product_name_Arabic,category,CAT.CAT_NAme1 As 'category_Eng' ,category_arabic,supplier,status,taxapply,imagename,product_id,UOMID,IC.UOMNAME1 as 'UOMNAME', " +
                        " msrp,price,Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,CustItemCode,BarCode " +
                        " FROM  purchase PI INNER JOIN tbl_item_uom_price iup ON PI.product_id = iup.itemID and PI.TenentID = iup.TenentID  " +
                        " INNER JOIN CAT_MST CAT ON PI.category = CAT.CATID and PI.TenentID = CAT.TenentID INNER JOIN ICUOM IC ON iup.UOMID = IC.UOM and iup.TenentID = IC.TenentID  " +
                        " where PI.TenentID =" + Tenent.TenentID + " order by product_id ";
                }

                DataTable dt = DataAccess.GetDataTable(sql);
               

               

                    
                
            }
            catch //(Exception)
            {

                //throw;
            }
        }

        public void ItemList_without_images_Catagory(string value)
        {
            flowLayoutPanelUserList.Controls.Clear();

            try
            {
                string sql = "";
                if (value != "")
                {
                    sql = " SELECT  (product_id || ' (' || CustItemCode || ')') as 'Item Code' , (product_name || '-' ||product_name_Arabic) as 'Item Name', " +
                          " (IC.UOMNAME1 || ' -' || IC.UOMNAME2) as 'UOM', printf('%.3f', OpQty) as 'Opening Stock' ,printf('%.3f', QtyRecived) as 'Stock In',printf('%.3f', QtyOut) as 'Stock Out',printf('%.3f', ir.Qty) as 'Return', printf('%.3f', OnHand)  as 'Stock In Hand'," +
                          " price as 'Unit Price', msrp as 'Sale Price' ,category " +
                          " FROM  purchase PI INNER JOIN tbl_item_uom_price iup ON PI.product_id = iup.itemID and PI.TenentID = iup.TenentID " +
                          "  left JOIN return_item ir ON  PI.product_id = ir.item_id and PI.TenentID = ir.TenentID  INNER JOIN CAT_MST CAT ON PI.category = CAT.CATID and PI.TenentID = CAT.TenentID INNER JOIN ICUOM IC ON iup.UOMID = IC.UOM and iup.TenentID = IC.TenentID  " +
                          " where PI.TenentID = " + Tenent.TenentID + " and (CAT.CAT_Name1 = '" + value + "') OR (category_arabic = '" + value + "') group by product_id order by product_id ";
                }
                else
                {
                    sql = " SELECT  (product_id || ' (' || CustItemCode ||')') as 'Item Code' , (product_name || '-' ||product_name_Arabic) as 'Item Name', " +
                          " (IC.UOMNAME1 || ' -' || IC.UOMNAME2) as 'UOM', printf('%.3f', OpQty) as 'Opening Stock' ,printf('%.3f', QtyRecived) as 'Stock In',printf('%.3f', QtyOut) as 'Stock Out',printf('%.3f', ir.Qty) as 'Return', printf('%.3f', OnHand)  as 'Stock In Hand'," +
                          " price as 'Unit Price', msrp as 'Sale Price' ,category " +
                          " FROM  purchase PI INNER JOIN tbl_item_uom_price iup ON PI.product_id = iup.itemID and PI.TenentID = iup.TenentID " +
                          " left JOIN return_item ir ON  PI.product_id = ir.item_id and PI.TenentID = ir.TenentID INNER JOIN CAT_MST CAT ON PI.category = CAT.CATID and PI.TenentID = CAT.TenentID INNER JOIN ICUOM IC ON iup.UOMID = IC.UOM and iup.TenentID = IC.TenentID  " +
                          " where PI.TenentID = " + Tenent.TenentID + " group by product_id order by product_id ";

                }

                DataTable dt = DataAccess.GetDataTable(sql);
                
                dgrvProductList.DataSource = dt;

               
            }
            catch //(Exception)
            {

                //throw;
            }
        }
        #endregion

       

      




       

    }
}
