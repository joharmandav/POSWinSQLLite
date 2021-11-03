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
    public partial class ItemSummery : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public ItemSummery()
        {
            InitializeComponent();
            if (UserInfo.Language == "English")
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                switch_language();
            }
            else if (UserInfo.Language == "Arabic")
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("Ar");
                switch_language();
            }
            else
            {
                res_man = new ResourceManager("supershop.bin.x86.Debug.language.Resource", typeof(Home).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                switch_language();
            }

            DataGridViewButtonColumn SaleSummery = new DataGridViewButtonColumn();
            dgrvProductList.Columns.Add(SaleSummery);
            SaleSummery.HeaderText = "Summary";
            SaleSummery.Text = "Sale";
            SaleSummery.Name = "SaleSummery";
            SaleSummery.ToolTipText = "Sale Summary";
            SaleSummery.UseColumnTextForButtonValue = true;
           
           
           
        }

        private void switch_language()
        {
            labelSearchProduct.Text = res_man.GetString("stockItem_labelSearchProduct", cul);
            //labelSelectCategory.Text = res_man.GetString("stockItem_labelSelectCategory", cul);
            //linkLabelAllCatagory.Text = res_man.GetString("stockItem_linkLabelAllCatagory", cul);
           

        }

        bool FirstTime;

        private void Stock_List_Load(object sender, EventArgs e)
        {
            try
            {
                FirstTime = true;
                Bind_catagory();
                LoadData();
                FirstTime = false;
                combCategory.Focus();
            }
            catch
            {
            }
        }

        #region Data bind

        public string selectCatagory
        {
            set
            {
                combCategory.Text = value;
            }
        }
        public void Bind_catagory()
        {
            //Product Category 
            try
            {
                combCategory.DataSource = null;
                combCategory.Items.Clear();

                if (UserInfo.Language == "English")
                {
                    //Select CATID , CAT_NAME1 ||' - '|| CAT_NAME2 as 'Catagory' from CAT_MST where TenentID = 9000004
                    string sqlcate = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " ";
                    DataTable dtcate = DataAccess.GetDataTable(sqlcate);

                    DataRow row = dtcate.NewRow();
                    row["CATID"] = 0;
                    row["CAT_NAME1"] = "All Category";
                    dtcate.Rows.InsertAt(row, 0);

                    combCategory.DataSource = dtcate;
                    combCategory.DisplayMember = "CAT_NAME1";
                    combCategory.ValueMember = "CATID";

                }
                else if (UserInfo.Language == "Arabic")
                {
                    string sqlcate = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " ";
                    DataTable dtcate = DataAccess.GetDataTable(sqlcate);

                    DataRow row = dtcate.NewRow();
                    row["CATID"] = 0;
                    row["CAT_NAME2"] = "All Category";
                    dtcate.Rows.InsertAt(row, 0);

                    combCategory.DataSource = dtcate;
                    combCategory.DisplayMember = "CAT_NAME2";
                    combCategory.ValueMember = "CATID";

                }
                else
                {

                    string sqlcate = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " ";
                    DataTable dtcate = DataAccess.GetDataTable(sqlcate);

                    DataRow row = dtcate.NewRow();
                    row["CATID"] = 0;
                    row["CAT_NAME1"] = "All Category";
                    dtcate.Rows.InsertAt(row, 0);

                    combCategory.DataSource = dtcate;
                    combCategory.DisplayMember = "CAT_NAME1";
                    combCategory.ValueMember = "CATID";

                }

            }
            catch
            {

            }
        }

        private void DisplayLoadData()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            Thread.Sleep(10);

            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    DateTime Start = DateTime.Now;
                    if (combCategory.Text != "All Category" && (combCategory.Text != "" || combCategory.Text != "System.Data.DataRowView"))
                    {
                       
                            string Catagory = Get_First_Catagory();
                            combCategory.SelectedValue = Catagory;
                            ItemList_without_images_Catagory(combCategory.Text);
                       
                    }
                    else
                    {
                       
                            string Catagory = Get_First_Catagory();
                            combCategory.SelectedValue = Catagory;
                            ItemList_without_images_Catagory(combCategory.Text);
                       
                    }
                    lblstart.Text = Math.Round(DateTime.Now.Subtract(Start).TotalSeconds, 3).ToString();
                });
            }
            catch
            {

            }

            SetLoading(false);
        }

        public void LoadData()
        {
            try
            {
                Thread threadInput = new Thread(DisplayLoadData);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }
        }

        public string GEtUOMName(int UOM)
        {
            string UOM_Name = "";
            if (UserInfo.Language == "English")
            {
                string sqlName = "select * from ICUOM where TenentID = " + Tenent.TenentID + " and UOM ='" + UOM + "' ";
                DataTable dtName = DataAccess.GetDataTable(sqlName);
                if (dtName.Rows.Count > 0)
                {
                    UOM_Name = dtName.Rows[0]["UOMNAME1"].ToString();
                }
            }
            else if (UserInfo.Language == "Arabic")
            {
                string sqlName = "select * from ICUOM where TenentID = " + Tenent.TenentID + " and UOM ='" + UOM + "' ";
                DataTable dtName = DataAccess.GetDataTable(sqlName);
                if (dtName.Rows.Count > 0)
                {
                    UOM_Name = dtName.Rows[0]["UOMNAME2"].ToString();
                }
            }
            else
            {
                string sqlName = "select * from ICUOM where TenentID = " + Tenent.TenentID + " and UOM ='" + UOM + "' ";
                DataTable dtName = DataAccess.GetDataTable(sqlName);
                if (dtName.Rows.Count > 0)
                {
                    UOM_Name = dtName.Rows[0]["UOMNAME1"].ToString();
                }
            }

            return UOM_Name;
        }

        //Show Products image
      

        public void ItemList_without_images(string value)
        {
            

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
                lblRows.Text = "Total Rows " + dt.Rows.Count.ToString() + " Found";

                dgrvProductList.DataSource = dt;

                dgrvProductList.Columns["Item Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Item Code"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Item Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["UOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["UOM"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["Opening Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Opening Stock"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Opening Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Stock In"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock In"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock In"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Stock Out"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock Out"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock Out"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Return"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Return"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Return"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Stock In Hand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock In Hand"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock In Hand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Unit Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Unit Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Sale Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Sale Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["category"].Visible = false;


                dgrvProductList.Columns["SaleSummery"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["SaleSummery"].DisplayIndex = 0;

               

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

      

        public void ItemList_without_images_Catagory(string value)
        {
           

            try
            {
                string sql = "";
                if (value != "")
                {
                    sql = " SELECT  product_id as 'Item Code' , (product_name || '-' ||product_name_Arabic) as 'Item Name', " +
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
                lblRows.Text = "Total Rows " + dt.Rows.Count.ToString() + " Found";
                dgrvProductList.DataSource = dt;

                dgrvProductList.Columns["Item Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Item Code"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Item Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["UOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["UOM"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["Opening Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Opening Stock"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Opening Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Stock In"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock In"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock In"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Stock Out"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock Out"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock Out"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Return"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Return"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Return"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Stock In Hand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock In Hand"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock In Hand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Unit Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Unit Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Sale Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Sale Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["category"].Visible = false;
                dgrvProductList.Columns["SaleSummery"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["SaleSummery"].DisplayIndex = 0;

                
               
            }
            catch //(Exception)
            {

                //throw;
            }
        }

        //Go to Item Details page
        protected void b_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();

            if (Application.OpenForms["ItemSummaryDetails"] != null)
            {
                Application.OpenForms["ItemSummaryDetails"].Close();
            }

            ItemSummaryDetails go = new ItemSummaryDetails();
            go.itemCode = s.Trim();
            go.MdiParent = this.ParentForm;
            go.Show();

        }
        //Product filter by Category

        private void DisplayCategoryData()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            Thread.Sleep(10);
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    DateTime Start = DateTime.Now;
                    if (combCategory.Text != "" && combCategory.Text != "System.Data.DataRowView")
                    {
                        if (combCategory.Text == "All Category")
                        {
                           
                                ItemList_without_images_Catagory("");
                            
                        }
                        else
                        {
                          
                                ItemList_without_images_Catagory(combCategory.Text.ToString());
                         
                        }
                    }
                    lblstart.Text = Math.Round(DateTime.Now.Subtract(Start).TotalSeconds, 3).ToString();
                    txtItemSearchBar.Focus();
                });
            }
            catch
            {

            }

            SetLoading(false);
        }

        private void combCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstTime == false)
            {
                try
                {
                    Thread threadInput = new Thread(DisplayCategoryData);
                    threadInput.Start();
                }
                catch (Exception ex)
                {
                }
            }
        }

        //Product filter by Product Name or Product ID  

        private void DisplayItemSearchBarData()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            Thread.Sleep(10);
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    DateTime Start = DateTime.Now;
                    if (txtItemSearchBar.Text != "")
                    {
                       
                            ItemList_without_images(txtItemSearchBar.Text);
                      
                    }
                    lblstart.Text = Math.Round(DateTime.Now.Subtract(Start).TotalSeconds, 3).ToString();
                });
            }
            catch
            {

            }
            SetLoading(false);
        }
        private void txtItemSearchBar_Leave(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(DisplayItemSearchBarData);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtItemSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Thread threadInput = new Thread(DisplayItemSearchBarData);
                    threadInput.Start();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(DisplayItemSearchBarData);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }
        }


        public string Get_First_Catagory()
        {
            string Catagory = "";

            if (UserInfo.Language == "English")
            {
                string sql = "select * from  CAT_MST where TenentID = " + Tenent.TenentID + " order by CAT_NAME1";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    Catagory = dt.Rows[0]["CATID"].ToString();
                }
                return Catagory;
            }
            else if (UserInfo.Language == "Arabic")
            {
                string sql = "select * from  CAT_MST where TenentID = " + Tenent.TenentID + " order by CAT_NAME2";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    Catagory = dt.Rows[0]["CATID"].ToString();
                }
                return Catagory;
            }
            else
            {
                string sql = "select * from  CAT_MST where TenentID = " + Tenent.TenentID + " order by CAT_NAME1";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    Catagory = dt.Rows[0]["CATID"].ToString();
                }
                return Catagory;
            }
        }

        #endregion

        #region page links
      
        private void picCloseEvent_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        // toolbar 
        private void lblMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   //Minimized              
        }

        private void Stock_List_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void DisplayData()
        {
            SetLoading(true);
            // Added to see the indicator (not required)
            Thread.Sleep(10);
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    DateTime Start = DateTime.Now;
                   
                        ItemList_without_images_Catagory("");
                  
                    lblstart.Text = Math.Round(DateTime.Now.Subtract(Start).TotalSeconds, 3).ToString();
                });
            }
            catch
            {

            }

            SetLoading(false);
        }

        private void btnDeliverd_Click(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(DisplayData);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }
        }

      

       

        private void dgrvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgrvProductList.Columns["SaleSummery"].Index && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow rowEdit in dgrvProductList.SelectedRows)
                {
                    string ItemCode = rowEdit.Cells["Item Code"].Value.ToString();
                    string PID = ItemCode.Trim();

                    if (Application.OpenForms["ItemSummaryDetails"] != null)
                    {
                        Application.OpenForms["ItemSummaryDetails"].Close();
                    }

                    ItemSummaryDetails go = new ItemSummaryDetails();
                    go.itemCode = PID;
                    go.MdiParent = this.ParentForm;
                    go.Show();
                }

            }
           
        }

        private void dgrvProductList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgrvProductList.Rows)
            {
                string CatID = Myrow.Cells["category"].Value.ToString();
                Myrow.DefaultCellStyle.BackColor = SalesRegister.GetCatagoryColor(CatID);
            }
        }

        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["CatagorySearch"] != null)
            {
                Application.OpenForms["CatagorySearch"].Close();
            }
            this.Refresh();

            CatagorySearch go = new CatagorySearch();
            go.PageName = "ItemSummery";
            go.Show();
        }

    }
}
