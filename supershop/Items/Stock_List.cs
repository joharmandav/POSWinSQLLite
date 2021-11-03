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
    public partial class Stock_List : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public Stock_List()
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

            DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
            dgrvProductList.Columns.Add(Edit);
            Edit.HeaderText = "Action";
            Edit.Text = "Edit";
            Edit.Name = "Edit";
            Edit.ToolTipText = "Edit this Item";
            Edit.UseColumnTextForButtonValue = true;
            Edit.Width = 100;
        }

        private void switch_language()
        {
            labelSearchProduct.Text = res_man.GetString("stockItem_labelSearchProduct", cul);
            //labelSelectCategory.Text = res_man.GetString("stockItem_labelSelectCategory", cul);
            //linkLabelAllCatagory.Text = res_man.GetString("stockItem_linkLabelAllCatagory", cul);
            btnpurchasehistory.Text = res_man.GetString("stockItem_btnpurchasehistory", cul);
            bntStock.Text = res_man.GetString("stockItem_bntStock", cul);
            btnAddNew.Text = res_man.GetString("stockItem_btnAddNew", cul);
            btnImport.Text = res_man.GetString("stockItem_btnImport", cul);
            btnChart.Text = res_man.GetString("stockItem_btnChart", cul);
            btnCreateBarcode.Text = res_man.GetString("stockItem_btnCreateBarcode", cul);

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
                        if (DisplayImage.Checked == true)
                        {
                            string Catagory = Get_First_Catagory();
                            combCategory.SelectedValue = Catagory;
                            ItemList_with_images_Catagory(combCategory.Text);
                        }
                        else
                        {
                            string Catagory = Get_First_Catagory();
                            combCategory.SelectedValue = Catagory;
                            ItemList_without_images_Catagory(combCategory.Text);
                        }
                    }
                    else
                    {
                        if (DisplayImage.Checked == true)
                        {
                            string Catagory = Get_First_Catagory();
                            combCategory.SelectedValue = Catagory;
                            ItemList_with_images_Catagory(combCategory.Text);
                        }
                        else
                        {
                            string Catagory = Get_First_Catagory();
                            combCategory.SelectedValue = Catagory;
                            ItemList_without_images_Catagory(combCategory.Text);
                        }
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
                lblRows.Text = "Total Rows " + dt.Rows.Count.ToString() + " Found";

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button b = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = dataReader["product_id"] + " - " + dataReader["UOMID"];
                    b.Click += new EventHandler(b_Click);

                    string UOM = dataReader["UOMID"].ToString();
                    int UOMIC = Convert.ToInt32(UOM);
                    string UOM_Name = GEtUOMName(UOMIC);

                    string PROdName = "";

                    if (UserInfo.Language == "English")
                    {
                        PROdName = dataReader["product_name"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        PROdName = dataReader["product_name_Arabic"].ToString();
                    }
                    else
                    {
                        PROdName = dataReader["product_name"].ToString();
                    }


                    //string taxapply;
                    //if (dataReader["taxapply"].ToString() == "1")
                    //{
                    //    taxapply = "YES";
                    //}
                    //else
                    //{
                    //    taxapply = "NO";
                    //}

                    //string KitchenDisplay;
                    //if (dataReader["status"].ToString() == "3")
                    //{
                    //    KitchenDisplay = "YES";
                    //}
                    //else
                    //{
                    //    KitchenDisplay = "NO";
                    //}

                    //string details =
                    //    "====================================" +
                    //    "\n ID: " + dataReader["product_id"] +
                    //    "\n Name: " + PROdName +// dataReader["product_name"].ToString() +
                    //    "\n Buy price: " + dataReader["msrp"].ToString() +
                    //    "\n Stock Qty: " + dataReader["OnHand"].ToString() +
                    //    "\n Retail price: " + dataReader["price"].ToString() +
                    //    "\n Discount: " + dataReader["Discount"].ToString() + "%" +
                    //    "\n Category: " + dataReader["category"].ToString() +
                    //    "\n Supplier: " + dataReader["supplier"].ToString() +
                    //    "\n Branch: " + dataReader["Shopid"].ToString() +
                    //    "\n Tax Apply: " + taxapply +
                    //    "\n Kitchen Display  : " + KitchenDisplay +
                    //     "\n UOM  : " + UOM_Name + // dataReader["UOMID"].ToString() +
                    //    "\n ====================================";
                    //b.Name = details;
                    //toolTip1.ToolTipTitle = "Item Details";
                    //toolTip1.AutoPopDelay = 32766;
                    //toolTip1.SetToolTip(b, details);

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(80, 80);
                    string image = "item.png";
                    if (dataReader["Image"] != null && dataReader["Image"].ToString() != "" && dataReader["Image"].ToString() != "item.png")
                    {
                        image = dataReader["Image"].ToString();
                        string Filename = Application.StartupPath + @"\ITEMIMAGE\" + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["Image"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }
                    else
                    {
                        image = dataReader["imagename"].ToString();
                        string Filename = Application.StartupPath + @"\ITEMIMAGE\" + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["imagename"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }

                    il.Images.Add(Image.FromFile(img_directory + image));


                    b.Image = il.Images[0];
                    b.Margin = new Padding(3, 3, 3, 3);

                    b.Size = new Size(220, 100);
                    b.Text.PadRight(4);

                    string CustItemCode = dataReader["CustItemCode"] != null ? dataReader["CustItemCode"].ToString() : "";

                    b.Text += " " + dataReader["product_id"] + " (" + CustItemCode + ") \n ";
                    if (UserInfo.Language == "English")
                    {
                        b.Text += dataReader["product_name"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        b.Text += dataReader["product_name_Arabic"].ToString();
                    }
                    else
                    {
                        b.Text += dataReader["product_name"].ToString();
                    }

                    //b.Text += dataReader["product_name"].ToString();
                    //b.Text += "\n(" + dataReader["UOMID"].ToString() + ")";
                    b.Text += "\n(" + UOM_Name + ")";
                    b.Text += "\n Stock: " + dataReader["OnHand"];

                    b.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    flowLayoutPanelUserList.Controls.Add(b);
                    //flowLayoutPanelUserList.Refresh();
                    currentImage++;
                }
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
                lblRows.Text = "Total Rows " + dt.Rows.Count.ToString() + " Found";

                dgrvProductList.DataSource = dt;

                dgrvProductList.Columns["Item Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Item Code"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Item Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["UOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["UOM"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //dgrvProductList.Columns["Opening Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Opening Stock"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Opening Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //dgrvProductList.Columns["Stock In"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock In"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock In"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //dgrvProductList.Columns["Stock Out"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock Out"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock Out"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //dgrvProductList.Columns["Stock Out"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Return"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Return"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //dgrvProductList.Columns["Stock In Hand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock In Hand"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock In Hand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Unit Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Unit Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Sale Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Sale Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["category"].Visible = false;


                dgrvProductList.Columns["Edit"].DisplayIndex = 10;
                dgrvProductList.Columns["Edit"].Width = 100;

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
                lblRows.Text = "Total Rows " + dt.Rows.Count.ToString() + " Found";

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button b = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = dataReader["product_id"] + " - " + dataReader["UOMID"];
                    b.Click += new EventHandler(b_Click);

                    string UOM = dataReader["UOMID"].ToString();
                    int UOMIC = Convert.ToInt32(UOM);
                    string UOM_Name = GEtUOMName(UOMIC);


                    string PROdName = "";

                    if (UserInfo.Language == "English")
                    {
                        PROdName = dataReader["product_name"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        PROdName = dataReader["product_name_Arabic"].ToString();
                    }
                    else
                    {
                        PROdName = dataReader["product_name"].ToString();
                    }

                    //string taxapply;
                    //if (dataReader["taxapply"].ToString() == "1")
                    //{
                    //    taxapply = "YES";
                    //}
                    //else
                    //{
                    //    taxapply = "NO";
                    //}

                    //string KitchenDisplay;
                    //if (dataReader["status"].ToString() == "3")
                    //{
                    //    KitchenDisplay = "YES";
                    //}
                    //else
                    //{
                    //    KitchenDisplay = "NO";
                    //}
                    //string details =
                    //    "====================================" +
                    //    "\n ID: " + dataReader["product_id"] +
                    //    "\n Name: " + PROdName +// dataReader["product_name"].ToString() +
                    //    "\n Buy price: " + dataReader["msrp"].ToString() +
                    //    "\n Stock Qty: " + dataReader["OnHand"].ToString() +
                    //    "\n Retail price: " + dataReader["price"].ToString() +
                    //    "\n Discount: " + dataReader["Discount"].ToString() + "%" +
                    //    "\n Category: " + dataReader["category"].ToString() +
                    //    "\n Supplier: " + dataReader["supplier"].ToString() +
                    //    "\n Branch: " + dataReader["Shopid"].ToString() +
                    //    "\n Tax Apply: " + taxapply +
                    //    "\n Kitchen Display  : " + KitchenDisplay +
                    //     "\n UOM  : " + UOM_Name + // dataReader["UOMID"].ToString() +
                    //    "\n ====================================";
                    //b.Name = details;
                    //toolTip1.ToolTipTitle = "Item Details";
                    //toolTip1.AutoPopDelay = 32766;
                    //toolTip1.SetToolTip(b, details);

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(80, 80);
                    string image = "item.png";
                    if (dataReader["Image"] != null && dataReader["Image"].ToString() != "" && dataReader["Image"].ToString() != "item.png")
                    {
                        image = dataReader["Image"].ToString();
                        string Filename = Application.StartupPath + @"\ITEMIMAGE\" + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["Image"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }
                    else
                    {
                        image = dataReader["imagename"].ToString();
                        string Filename = Application.StartupPath + @"\ITEMIMAGE\" + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["imagename"].ToString();
                        }
                        else
                        {
                            image = "item.png";
                        }
                    }

                    il.Images.Add(Image.FromFile(img_directory + image));


                    b.Image = il.Images[0];
                    b.Margin = new Padding(3, 3, 3, 3);

                    b.Size = new Size(220, 100);
                    b.Text.PadRight(4);

                    string CustItemCode = dataReader["CustItemCode"] != null ? dataReader["CustItemCode"].ToString() : "";

                    b.Text += " " + dataReader["product_id"] + " (" + CustItemCode + ") \n ";
                    if (UserInfo.Language == "English")
                    {
                        b.Text += dataReader["product_name"].ToString();
                    }
                    else if (UserInfo.Language == "Arabic")
                    {
                        b.Text += dataReader["product_name_Arabic"].ToString();
                    }
                    else
                    {
                        b.Text += dataReader["product_name"].ToString();
                    }

                    //b.Text += dataReader["product_name"].ToString();
                    //b.Text += "\n(" + dataReader["UOMID"].ToString() + ")";
                    b.Text += "\n(" + UOM_Name + ")";
                    b.Text += "\n Stock: " + dataReader["OnHand"];

                    b.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    flowLayoutPanelUserList.Controls.Add(b);
                    //flowLayoutPanelUserList.Refresh();
                    currentImage++;
                }
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
                lblRows.Text = "Total Rows " + dt.Rows.Count.ToString() + " Found";
                dgrvProductList.DataSource = dt;

                dgrvProductList.Columns["Item Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Item Code"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Item Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgrvProductList.Columns["UOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["UOM"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //dgrvProductList.Columns["Opening Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Opening Stock"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Opening Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //dgrvProductList.Columns["Stock In"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock In"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock In"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //dgrvProductList.Columns["Stock Out"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock Out"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock Out"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Return"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Return"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //dgrvProductList.Columns["Stock In Hand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Stock In Hand"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgrvProductList.Columns["Stock In Hand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Unit Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Unit Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["Sale Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgrvProductList.Columns["Sale Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgrvProductList.Columns["category"].Visible = false;

                dgrvProductList.Columns["Edit"].DisplayIndex = 10;
                dgrvProductList.Columns["Edit"].Width = 100;
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

            if (Application.OpenForms["Add_Item"] != null)
            {
                Application.OpenForms["Add_Item"].Close();
            }

            Add_Item go = new Add_Item();
            go.itemCode = s.Split('-')[0].Trim();
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
                            if (DisplayImage.Checked == true)
                            {
                                ItemList_with_images_Catagory("");
                            }
                            else
                            {
                                ItemList_without_images_Catagory("");
                            }
                        }
                        else
                        {
                            if (DisplayImage.Checked == true)
                            {
                                ItemList_with_images_Catagory(combCategory.Text.ToString());
                            }
                            else
                            {
                                ItemList_without_images_Catagory(combCategory.Text.ToString());
                            }
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
                        if (DisplayImage.Checked == true)
                        {
                            ItemList_with_images(txtItemSearchBar.Text);
                        }
                        else
                        {
                            ItemList_without_images(txtItemSearchBar.Text);
                        }
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
        private void btnCreateBarcode_Click(object sender, EventArgs e)
        {
            BarCode.Barcode_machine go = new BarCode.Barcode_machine();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            Chart g = new Chart();
            g.MdiParent = this.ParentForm;
            g.Show();
        }

        private void picCloseEvent_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import_Items go = new Import_Items();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Add_Item"] != null)
            {
                Application.OpenForms["Add_Item"].Close();
            }

            Add_Item go = new Add_Item();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void bntStock_Click(object sender, EventArgs e)
        {
            Items.StockDetails go = new Items.StockDetails();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void btnpurchasehistory_Click(object sender, EventArgs e)
        {
            Items.Purchase_History go = new Items.Purchase_History();
            go.MdiParent = this.ParentForm;
            go.Show();
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
                    if (DisplayImage.Checked == true)
                    {
                        ItemList_with_images_Catagory("");
                    }
                    else
                    {
                        ItemList_without_images_Catagory("");
                    }
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

        private void DisplayImageData()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            Thread.Sleep(10);
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    DateTime Start = DateTime.Now;
                    if (DisplayImage.Checked == true)
                    {
                        this.tabWithImage.Parent = this.tabControl1; //show
                        tabControl1.SelectedTab = tabWithImage;

                        if (combCategory.Text != "All Category" && combCategory.Text != "")
                        {
                            ItemList_with_images_Catagory(combCategory.Text);
                        }
                        else
                        {
                            ItemList_with_images_Catagory("");
                        }
                    }
                    else
                    {
                        this.tabGrid.Parent = this.tabControl1; //show
                        tabControl1.SelectedTab = tabGrid;

                        if (combCategory.Text != "All Category" && combCategory.Text != "")
                        {
                            ItemList_without_images_Catagory(combCategory.Text);
                        }
                        else
                        {
                            ItemList_without_images_Catagory("");
                        }
                    }
                    lblstart.Text = Math.Round(DateTime.Now.Subtract(Start).TotalSeconds, 3).ToString();
                });
            }
            catch
            {

            }

            SetLoading(false);
        }

        private void DisplayImage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Thread threadInput = new Thread(DisplayImageData);
                threadInput.Start();
            }
            catch (Exception ex)
            {
            }
        }

        private void dgrvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgrvProductList.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow rowEdit in dgrvProductList.SelectedRows)
                {
                    string ItemCode = rowEdit.Cells["Item Code"].Value.ToString();
                    string PID = ItemCode.Split('(')[0].Trim();

                    if (Application.OpenForms["Add_Item"] != null)
                    {
                        Application.OpenForms["Add_Item"].Close();
                    }

                    Add_Item go = new Add_Item();
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
            go.PageName = "Stock_List";
            go.Show();
        }

    }
}
