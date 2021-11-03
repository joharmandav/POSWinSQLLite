using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace supershop
{
    public partial class Add_ItemOLD : Form
    {
        public Add_ItemOLD()
        {
            InitializeComponent();

            //datagrdReportDetails

            DataGridViewButtonColumn Assign = new DataGridViewButtonColumn();
            this.datagrdReportDetails.Columns.Add(Assign);
            Assign.HeaderText = "Action";
            Assign.Text = "Delete";
            Assign.Name = "Delete";
            Assign.ToolTipText = "Delete";
            Assign.UseColumnTextForButtonValue = true;
        }

        // Get Item bar-code from Stock List form
        public string itemCode
        {
            set { lblItemcode.Text = value; }
            get { return lblItemcode.Text; }
        }

        public string EditItem
        {
            set
            { 
                lblItemcode.Text = value;
                EditLoad();
            }
            get 
            { 
                return lblItemcode.Text;
            }
        }

        public string UOM
        {
            set { lbl_UOM.Text = value; }
            get { return lbl_UOM.Text; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region DataBind
        private void loadData()
        {
            string sql = " SELECT  Shopid,product_name,category,supplier,status,taxapply,imagename,product_id,UOMID,msrp,price,Deleted,OpQty,OnHand,QtyOut, " +
                         " QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,UOM,category_arabic,IsPerishable,custitemCode,Barcode,RecipeType,product_name_Arabic,product_name_print " +
                         " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID" +
                         " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + lblItemcode.Text + "' ";

            DataTable dt1 = DataAccess.GetDataTable(sql);

            txtProductCode.Text = dt1.Rows[0]["product_id"].ToString();
            txtProductName.Text = dt1.Rows[0]["product_name"].ToString();
            txtNameArabic.Text = dt1.Rows[0]["product_name_Arabic"].ToString();
            txtproduct_name_print.Text = dt1.Rows[0]["product_name_print"].ToString();

            txtProductQty.Text = dt1.Rows[0]["OnHand"].ToString();
            txtCostPrice.Text = dt1.Rows[0]["price"].ToString();
            txtSalesPrice.Text = dt1.Rows[0]["msrp"].ToString();

            //ComboCategory.Text = (dt1.Rows[0]["category"] + " - " + dt1.Rows[0]["category_arabic"]).ToString();
            int CatID = Convert.ToInt32(dt1.Rows[0]["category"]);
            string CatNAme = GetCat_Name(CatID);
            CmbCategory.SelectedValue = CatID;
            // CmbCategory.SelectedIndex = CmbCategory.FindString(CatNAme);
            //ComboCategory.SelectedItem = CatID;

            cmbSupplier.SelectedValue = dt1.Rows[0]["supplier"].ToString();
            lblimagename.Text = dt1.Rows[0]["imagename"].ToString();

            txtCustItemCode.Text = dt1.Rows[0]["custitemCode"].ToString();
            txtBarcode.Text = dt1.Rows[0]["Barcode"].ToString();
            comboRecipeType.Text = dt1.Rows[0]["RecipeType"].ToString();

            string isuom = dt1.Rows[0]["UOM"].ToString();
            string path = Application.StartupPath + @"\ITEMIMAGE\" + dt1.Rows[0]["imagename"].ToString() + "";

            if (File.Exists(path))
            {
                picItemimage.ImageLocation = path;
                picItemimage.InitialImage.Dispose();
                picItemUOMimage.ImageLocation = path;
                picItemUOMimage.InitialImage.Dispose();
            }
            else
            {
                picItemimage.ImageLocation = Application.StartupPath + @"\ITEMIMAGE\item.png";
                picItemimage.InitialImage.Dispose();
                picItemUOMimage.ImageLocation = Application.StartupPath + @"\ITEMIMAGE\item.png";
                picItemUOMimage.InitialImage.Dispose();
            }


            txtdiscount.Text = dt1.Rows[0]["Discount"].ToString();
            cmboShopid.SelectedValue = dt1.Rows[0]["Shopid"].ToString();
            int Perishable = Convert.ToInt32(dt1.Rows[0]["IsPerishable"]);
            if (Perishable == 1)
                checkPerishable.Checked = true;
            else
                checkPerishable.Checked = false;

            if (isuom == "Y")
            {

                chMultiUOM.Checked = true;
                btnUomAdd.Visible = dgrvMultiUomList.Visible = true;

                string sql2 = "select UOMID,UOMNAME1,OnHand,msrp,price from tbl_item_uom_price iup inner join ICUOM IC on IC.UOM = iup.UOMID and IC.TenentID = iup.TenentID " +
                    " where iup.TenentID = " + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y'";

                DataTable dtterminallist = DataAccess.GetDataTable(sql2);

                int rows = dtterminallist.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    string uomname = dtterminallist.Rows[i]["UOMNAME1"].ToString();
                    string uomcost = dtterminallist.Rows[i]["price"].ToString();
                    string Qty = dtterminallist.Rows[i]["OnHand"].ToString();
                    string SalePrice = dtterminallist.Rows[i]["msrp"].ToString();
                    dgrvMultiUomList.Rows.Add(uomname, Qty, SalePrice, uomcost);
                }
                //Purchase Histry UOM Info
                drpPurchaseHistryUOM.DataSource = dtterminallist;
                drpPurchaseHistryUOM.DisplayMember = "UOMNAME1";
                drpPurchaseHistryUOM.ValueMember = "UOMID";

                txtPHSalePrice.Text = dtterminallist.Rows[0]["msrp"].ToString();
                txtPHCostPrice.Text = dtterminallist.Rows[0]["price"].ToString();

            }
            if (dt1.Rows[0]["taxapply"].ToString() == "1")
            {
                chktaxapply.Checked = true;
            }
            else
            {
                chktaxapply.Checked = false;
            }

            if (dt1.Rows[0]["status"].ToString() == "3")  // 3 = show kitchen display 
            {
                chkkitchenDisplay.Checked = true;
            }
            else
            {
                chkkitchenDisplay.Checked = false;
            }

            //if (lbl_UOM.Text != "-")
            //{
            //    EditUOM(lbl_UOM.Text);
            //}

            BindGrid();
        }

        public string GetCat_Name(int CATID)
        {
            string Category = "";
            string sql5 = "select  *  from CAT_MST where TenentID = " + Tenent.TenentID + " and CATID = " + CATID + " ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5 != null)
            {
                if (dt5.Rows.Count > 0)
                {
                    Category = dt5.Rows[0]["CAT_NAME1"].ToString();
                }
            }
            return Category;
        }

        public static int GetCATID(string CAT_NAME1)
        {
            int CATID = 0;
            CAT_NAME1 = CAT_NAME1.ToUpper();
            string sql5 = "select  *  from CAT_MST where TenentID = " + Tenent.TenentID + " and upper(CAT_NAME1) = '" + CAT_NAME1 + "' ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5 != null)
            {
                if (dt5.Rows.Count > 0)
                {
                    CATID = Convert.ToInt32(dt5.Rows[0]["CATID"]);
                }
            }
            return CATID;
        }


        public void Bindshopbranch()
        {
            string sql5 = "select   BranchName , Shopid from tbl_terminalLocation where TenentID = " + Tenent.TenentID + " ";

            DataTable dt5 = DataAccess.GetDataTable(sql5);
            cmboShopid.DataSource = dt5;
            cmboShopid.DisplayMember = "Branchname";
            cmboShopid.ValueMember = "Shopid";

        }

        private void Add_Item_Load(object sender, EventArgs e)
        {
            try
            {
                if (UserInfo.usertype == "1")
                {
                    lnkStocklist.Visible = true;
                }
                else
                {
                    lnkStocklist.Visible = false;
                }
                dtpurchaseDate.Format = DateTimePickerFormat.Custom;
                dtpurchaseDate.CustomFormat = "yyyy-MM-dd";
                //Delete  tbl_item_uom_price where Deleted='N'

                string sql1 = "Delete from tbl_item_uom_price where Deleted='N' and TenentID= " + Tenent.TenentID + "";
                DataAccess.ExecuteSQL(sql1);

                string sqlUpdateCmdWIN = " delete from Win_tbl_item_uom_price  where Deleted='N' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.Delete_Live_sync_Delete_Query(sqlUpdateCmdWIN, "Win_tbl_item_uom_price");

                //Supplier Info
                BindSupplier();


                //UMO Info
                bind_UOM();

                //Category list
                Bind_Catagory();

                Bindshopbranch();
                //Yogesh
                this.dgrvMultiUomList.Columns.Add("uomn", "UOM Name");
                this.dgrvMultiUomList.Columns.Add("Qty", "Qty");
                this.dgrvMultiUomList.Columns.Add("sPrc", "Sale Price");
                this.dgrvMultiUomList.Columns.Add("cPrc", "Cost Price");

                DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
                dgrvMultiUomList.Columns.Add(edit);
                edit.HeaderText = "Edit";
                edit.Text = "Edit";
                edit.Name = "Edit";
                edit.ToolTipText = "Edit this uom";
                edit.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                dgrvMultiUomList.Columns.Add(del);
                del.HeaderText = "Del";
                del.Text = "x";
                del.Name = "del";
                del.ToolTipText = "Delete this uom";
                del.UseColumnTextForButtonValue = true;


                dgrvMultiUomList.Columns[0].ReadOnly = true;
                dgrvMultiUomList.Columns[1].ReadOnly = true;
                dgrvMultiUomList.Columns[2].ReadOnly = true;
                dgrvMultiUomList.Columns[3].ReadOnly = true;
                dgrvMultiUomList.Columns[4].ReadOnly = false;
                dgrvMultiUomList.Columns[5].ReadOnly = false;

                dgrvMultiUomList.Columns["uomn"].Width = 200;
                dgrvMultiUomList.Columns["Qty"].Width = 60;
                dgrvMultiUomList.Columns["sPrc"].Width = 100;
                dgrvMultiUomList.Columns["cPrc"].Width = 100;

                panel1.Visible = false;
                //Update data | If user id has
                if (lblItemcode.Text != "-")
                {
                    loadData();
                    txtProductCode.ReadOnly = true;
                    btnSave.Text = "Update";
                    lnkDelete.Visible = true;
                    grpboxPurchasehistory.Visible = true;
                }
                else
                {
                    btnUomAdd.Enabled = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        public void EditLoad()
        {
            if (lblItemcode.Text != "-")
            {
                loadData();
                txtProductCode.ReadOnly = true;
                btnSave.Text = "Update";
                lnkDelete.Visible = true;
                grpboxPurchasehistory.Visible = true;
            }
            else
            {
                btnUomAdd.Enabled = false;
            }
        }

        public void BindSupplier()
        {
            //Supplier Info
            string sqlCust = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Supplier'";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            cmbSupplier.DataSource = dtCust;
            cmbSupplier.ValueMember = "ID";
            cmbSupplier.DisplayMember = "Name";
            //cmbSupplier.Text = "Unknown";
        }

        #region Insert , Update and delete Item

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (Login.InternetConnection() == false)
            //{
            //    MessageBox.Show("Internet Connection Not Avalable. try again later");
            //    return;
            //}

            //bool Falg = Login.CheckDBConnection();
            //if (Falg == false)
            //{
            //    MessageBox.Show("online Server Connection Fail. try again later");
            //    return;
            //}

            if (txtProductCode.Text == "")
            {
                MessageBox.Show("Please Insert Product Code/ Item Bar-code");
                txtProductCode.Focus();
            }
            else if (txtProductName.Text == "")
            {
                MessageBox.Show("Please Insert  Product Name");
                txtProductName.Focus();
            }
            else if (txtdiscount.Text == "")
            {
                txtdiscount.Text = "0";
                txtdiscount.Focus();
            }
            else if (txtProductQty.Text == "")
            {
                MessageBox.Show("Please Insert Product Quantity");
                txtProductQty.Focus();
            }
            else if (txtCostPrice.Text == "")
            {
                MessageBox.Show("Please Insert Product Cost Price / Buy price ");
                txtCostPrice.Focus();
            }

            else if (txtSalesPrice.Text == "")
            {
                MessageBox.Show("Please Insert Product  Sales Price");
                txtSalesPrice.Focus();
            }
            else if (CmbCategory.Text == "")
            {
                MessageBox.Show("Please Insert Product Category");
                CmbCategory.Focus();
            }
            else if (cmboShopid.Text == "")
            {
                MessageBox.Show("Please Select Branch name ");
                cmboShopid.Focus();
            }
            else if (cmbSupplier.Text == "")
            {
                MessageBox.Show("Please Select Supplier Name");
                cmbSupplier.Focus();
            }
            else
            {
                //try
                //{
                string pid = txtProductCode.Text;
                string pname = txtProductName.Text;
                double quan = Convert.ToDouble(txtProductQty.Text);
                double cprice = Convert.ToDouble(txtCostPrice.Text);
                double sprice = Convert.ToDouble(txtSalesPrice.Text);

                double ctotalpri = quan * cprice;
                double rtotalpri = quan * sprice;
                double discount = txtdiscount.Text != "" ? Convert.ToDouble(txtdiscount.Text) : 0;

                int taxapply;
                if (chktaxapply.Checked)
                {
                    taxapply = 1;  //1 = Tax apply
                }
                else
                {
                    taxapply = 0; // 0 = Tax not apply
                }

                int kitchenDisplaythisitem;
                if (chkkitchenDisplay.Checked)
                {
                    kitchenDisplaythisitem = 3; // 3 = It's show display on kitchen display
                }
                else
                {
                    kitchenDisplaythisitem = 1; // 1 = it's not show on ditcken display.
                }
                string isuomupdate = "N";
                if (chMultiUOM.Checked)
                {
                    isuomupdate = "Y";
                }
                //New Insert / New Entry
                if (lblItemcode.Text == "-")
                {
                    string imageName = pid + lblFileExtension.Text;

                    string product_name_print = txtproduct_name_print.Text;
                    string product_name_Arabic = txtNameArabic.Text;
                    //string catagory_Eng = ComboCategory.Text.Split('-')[0].Trim();  
                    string catagory_Eng = CmbCategory.SelectedValue.ToString();

                    //string category_arabic = getCatagory_Arabic(catagory_Eng);
                    string category_arabic = getCatagory_Arabic(CmbCategory.SelectedText.Split('-')[0].Trim());

                    int IsPerishable = 0;
                    if (checkPerishable.Checked == true)
                    {
                        IsPerishable = 1;
                    }
                    else
                    {
                        IsPerishable = 0;
                    }

                    string CustItemCode = txtCustItemCode.Text != "" ? txtCustItemCode.Text : pid;
                    string BarCode = txtBarcode.Text != "" ? txtBarcode.Text : pid;

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    //string sqlWin_purchase = " insert into Win_purchase (TenentID, product_id, product_name,product_name_Arabic,product_name_print," +
                    //               " category,category_arabic, supplier , imagename, taxapply, Shopid , status,UOM,IsPerishable,Uploadby ,UploadDate ,SynID,CustItemCode,BarCode) " +
                    //               " values (" + Tenent.TenentID + ",'" + pid + "', '" + pname + "', N'" + product_name_Arabic + "', N'" + product_name_print + "'," +
                    //               " '" + catagory_Eng + "', N'" + category_arabic + "', '" + cmbSupplier.SelectedValue + "' , '" + imageName + "', " +
                    //               " '" + taxapply + "' , '" + cmboShopid.SelectedValue + "' , '" + kitchenDisplaythisitem + "' , '" + isuomupdate + "'," + IsPerishable + " , '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + BarCode + "' )";
                    //int InsertFlag = DataLive.ExecuteLiveSQL(sqlWin_purchase);

                    //if (InsertFlag == 1)
                    //{
                        string sql1 = " insert into purchase (TenentID, product_id, product_name,product_name_Arabic,product_name_print," +
                                        " category,category_arabic, supplier , imagename, taxapply, Shopid , status,UOM,IsPerishable,Uploadby ,UploadDate ,SynID,CustItemCode,BarCode) " +
                                        " values (" + Tenent.TenentID + ",'" + pid + "', '" + pname + "','" + product_name_Arabic + "','" + product_name_print + "'," +
                                        " '" + catagory_Eng + "','" + category_arabic + "', '" + cmbSupplier.SelectedValue + "' , '" + imageName + "', " +
                                        " '" + taxapply + "' , '" + cmboShopid.SelectedValue + "' , '" + kitchenDisplaythisitem + "' , '" + isuomupdate + "'," + IsPerishable + " , '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + BarCode + "' )";
                        int flag1 = DataAccess.ExecuteSQL(sql1);

                        string sqlWin_purchase = " insert into Win_purchase (TenentID, product_id, product_name,product_name_Arabic,product_name_print," +
                                       " category,category_arabic, supplier , imagename, taxapply, Shopid , status,UOM,IsPerishable,Uploadby ,UploadDate ,SynID,CustItemCode,BarCode) " +
                                       " values (" + Tenent.TenentID + ",'" + pid + "', '" + pname + "', N'" + product_name_Arabic + "', N'" + product_name_print + "'," +
                                       " '" + catagory_Eng + "', N'" + category_arabic + "', '" + cmbSupplier.SelectedValue + "' , '" + imageName + "', " +
                                       " '" + taxapply + "' , '" + cmboShopid.SelectedValue + "' , '" + kitchenDisplaythisitem + "' , '" + isuomupdate + "'," + IsPerishable + " , '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + BarCode + "' )";
                        Datasyncpso.insert_Live_sync_insert_Query(sqlWin_purchase, "Win_purchase");

                        string ActivityName = "Add Product";
                        string LogData = "Add Product with product id = " + pid + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        UpdateRecipeType(pid);


                        btnUomAdd_Click(sender, e);

                        /////////////////////////////////// add Item UOM Price /////////////////////////////////////////////////

                        //picture upload  /////////////////
                        //  if (openFileDialog1.FileName != string.Empty)
                        // {

                        string path = Application.StartupPath + @"\ITEMIMAGE\";

                        System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);
                        if (di.Exists)
                        {
                            path = UserInfo.Img_path;
                        }
                        System.IO.File.Delete(path + @"\" + imageName);
                        if (!System.IO.Directory.Exists(path))
                            System.IO.Directory.CreateDirectory(path);
                        string filename = path + @"\" + openFileDialog1.SafeFileName;
                        picItemimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                        //   }

                        MessageBox.Show("Item hase been saved Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (UserInfo.usertype == "1")
                        {
                            Add_Item go = new Add_Item();
                            go.MdiParent = this.ParentForm;
                            go.Show();
                            this.Close();
                        }
                        else
                        {
                            // btnItemLink.Visible = false;
                        }

                        btnUomAdd.Enabled = true;
                        // ClearForm();
                    //}
                }
                else  //Update
                {

                    string imageName;
                    if (lblFileExtension.Text == "item.png") //if not select image
                    {
                        imageName = lblimagename.Text;
                    }
                    else  // select image
                    {
                        imageName = lblItemcode.Text + lblFileExtension.Text;
                    }

                    string product_name_print = txtproduct_name_print.Text;
                    string product_name_Arabic = txtNameArabic.Text;

                    //string catagory_Eng = ComboCategory.Text.Split('-')[0].Trim();  
                    string catagory_Eng = CmbCategory.SelectedValue.ToString();

                    //string category_arabic = getCatagory_Arabic(catagory_Eng);
                    string category_arabic = getCatagory_Arabic(CmbCategory.SelectedText.Split('-')[0].Trim());

                    int IsPerishable = 0;
                    if (checkPerishable.Checked == true)
                    {
                        IsPerishable = 1;
                    }
                    else
                    {
                        IsPerishable = 0;
                    }

                    string CustItemCode = txtCustItemCode.Text != "" ? txtCustItemCode.Text : pid;
                    string BarCode = txtBarcode.Text != "" ? txtBarcode.Text : pid;

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    //string sqlwin = " update Win_purchase set product_name = '" + txtProductName.Text + "',product_name_print = N'" + product_name_print + "' ,product_name_Arabic = N'" + product_name_Arabic + "', " +
                    //           " category = '" + catagory_Eng + "',category_arabic = N'" + category_arabic + "', supplier = '" + cmbSupplier.SelectedValue + "',  " +
                    //           " imagename = '" + imageName + "' , taxapply = '" + taxapply + "' , " +
                    //           " Shopid = '" + cmboShopid.SelectedValue + "' , status =  '" + kitchenDisplaythisitem + "' , UOM =  '" + isuomupdate + "', IsPerishable = " + IsPerishable + "," +
                    //           " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' , CustItemCode = '" + CustItemCode + "', BarCode = '" + BarCode + "', SynID = 2 " +
                    //           "  where product_id = '" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + " ";
                    //int UpdateFlag = DataLive.ExecuteLiveSQL(sqlwin);

                    //if (UpdateFlag == 1)
                    //{
                        string sql = " update purchase set product_name = '" + txtProductName.Text + "',product_name_print = '" + product_name_print + "' ,product_name_Arabic = '" + product_name_Arabic + "', " +
                                " category = '" + catagory_Eng + "', category_arabic = '" + category_arabic + "', supplier = '" + cmbSupplier.SelectedValue + "',  " +
                                " imagename = '" + imageName + "' , taxapply = '" + taxapply + "' , " +
                                " Shopid = '" + cmboShopid.SelectedValue + "' , status =  '" + kitchenDisplaythisitem + "' , UOM =  '" + isuomupdate + "',IsPerishable = " + IsPerishable + ", " +
                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' , CustItemCode = '" + CustItemCode + "', BarCode = '" + BarCode + "', SynID = 2 " +
                                "  where product_id = '" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        DataAccess.ExecuteSQL(sql);

                        string sqlwin = " update Win_purchase set product_name = '" + txtProductName.Text + "',product_name_print = N'" + product_name_print + "' ,product_name_Arabic = N'" + product_name_Arabic + "', " +
                                    " category = '" + catagory_Eng + "',category_arabic = N'" + category_arabic + "', supplier = '" + cmbSupplier.SelectedValue + "',  " +
                                    " imagename = '" + imageName + "' , taxapply = '" + taxapply + "' , " +
                                    " Shopid = '" + cmboShopid.SelectedValue + "' , status =  '" + kitchenDisplaythisitem + "' , UOM =  '" + isuomupdate + "', IsPerishable = " + IsPerishable + "," +
                                    " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' , CustItemCode = '" + CustItemCode + "', BarCode = '" + BarCode + "', SynID = 2 " +
                                    "  where product_id = '" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + " ";
                        Datasyncpso.Update_Live_sync_Update_Query(sqlwin, "Win_purchase");

                        string ActivityName = "Update Product";
                        string LogData = "Update Product with product id = " + lblItemcode.Text + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        UpdateRecipeType(pid);

                        //btnUomAdd_Click(sender, e);

                        /////////////////////////////////// Update Item UOM Price /////////////////////////////////////////////////

                        /////////////////////////////////////////////Update image //////////////////////////////////////////////////////
                        if (lblFileExtension.Text != "item.png") // if select image
                        {
                            picItemimage.InitialImage.Dispose();
                            string path = Application.StartupPath + @"\ITEMIMAGE\";
                            System.IO.File.Delete(path + @"\" + imageName);
                            if (!System.IO.Directory.Exists(path))
                                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\ITEMIMAGE\");
                            string filename = path + @"\" + openFileDialog1.SafeFileName;
                            picItemimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);

                            //if (System.IO.File.Exists(filename))
                            //    System.IO.File.Delete(filename);
                            System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                        }


                        MessageBox.Show("Successfully Data Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //loadData();    
                        if (UserInfo.usertype == "1")
                        {
                            Add_Item go = new Add_Item();
                            go.MdiParent = this.ParentForm;
                            go.Show();
                            this.Close();
                        }
                        else
                        {
                            // btnItemLink.Visible = false;
                        }
                    //}
                }

                //}
                //catch (Exception exp)
                //{
                //    MessageBox.Show("Sorry\r\n this id already added \n" + exp.Message);
                //}
            }    
        }

        public void UpdateRecipeType(string productID)
        {
            string RecipeType = "Output";
            RecipeType = comboRecipeType.Text;
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sql2 = " Update tbl_item_uom_price set RecipeType = '" + RecipeType + "', " +
                                  " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                  " where itemID = '" + productID + "' and TenentID= " + Tenent.TenentID + " ";
            DataAccess.ExecuteSQL(sql2);

            string sql2win = " Update win_tbl_item_uom_price set RecipeType = '" + RecipeType + "', " +
                             " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                             " where itemID = '" + productID + "' and TenentID= " + Tenent.TenentID + " ";
            Datasyncpso.Update_Live_sync_Update_Query(sql2win, "win_tbl_item_uom_price");

        }

        public string getCatagory_Arabic(string Eng_Catagory)
        {
            string Catagory = "";
            Eng_Catagory = Eng_Catagory.Trim();
            string sql = "select DISTINCT CAT_NAME2 from  CAT_MST where TenentID = " + Tenent.TenentID + " and CAT_NAME1 = '" + Eng_Catagory + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                Catagory = dt.Rows[0]["CAT_NAME2"].ToString();
            }
            return Catagory;
        }

        private void ClearForm()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductQty.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtSalesPrice.Text = string.Empty;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //  openFileDialog1.InitialDirectory = @"C:\";
            //  openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = ".jpg";
            // openFileDialog1.Filter = "GIF files (*.gif)|*.gif| jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png| All files (*.*)|*.*";
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png";

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;


            //openFileDialog1.ReadOnlyChecked = true;
            //openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox1.Text = openFileDialog1.FileName;
                picItemimage.Image = new Bitmap(openFileDialog1.FileName);
                lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
                //picItemUOMimage.ImageLocation = openFileDialog1.FileName;
                //lblUOMFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            }
        }

        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (lblItemcode.Text == "-")
                {
                    // MessageBox.Show("You are Not able to Update");
                    MessageBox.Show("You are Not able to Delete", "Button3 Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        string sqlSelect = "select * from sales_item  where TenentID = " + Tenent.TenentID + " and itemcode = '" + lblItemcode.Text + "' ";
                        DataTable dt = DataAccess.GetDataTable(sqlSelect);
                        if (dt.Rows.Count > 0)
                        {
                            int Count = dt.Rows.Count;
                            MessageBox.Show(" This Item Used in Sales You Not Able To Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        else
                        {
                            string sql = "delete from purchase where product_id ='" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + "";
                            DataAccess.ExecuteSQL(sql);

                            string sqlUpdateCmdWIN = " delete From Win_purchase  where product_id ='" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + " ";
                            Datasyncpso.Delete_Live_sync_Delete_Query(sqlUpdateCmdWIN, "Win_purchase");

                            string sqlDelete = "Delete from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' ";
                            DataAccess.ExecuteSQL(sqlDelete);

                            string sqlLive = "Delete from Win_tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' ";
                            Datasyncpso.Delete_Live_sync_Delete_Query(sqlLive, "Win_tbl_item_uom_price");

                        }

                        //picItemimage.InitialImage.Dispose();
                        //string path = Application.StartupPath + @"\ITEMIMAGE\";
                        //System.IO.File.Delete(path + @"\" + lblimagename.Text);
                        MessageBox.Show("Successfully Data Delete !", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Stock_List go = new Stock_List();
                        go.MdiParent = this.ParentForm;
                        go.Show();
                        this.Close();
                        ClearForm();

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Sorry\r\n You have to Check the Data" + exp.Message);
                    }
                }
            }
        }

        #endregion

        #region   Accept Decimal Value Validation
        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //bool ignoreKeyPress = false;

                ////bool matchString = Regex.IsMatch(txtProductCode.Text.ToString(), @"\d\d\d");^\d$

                //bool matchString = Regex.IsMatch(txtProductCode.Text.ToString(), @"^\d$");

                //if (e.KeyChar == '\b') // Always allow a Backspace
                //    ignoreKeyPress = false;
                //else if (matchString)
                //    ignoreKeyPress = true;
                //else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                //    ignoreKeyPress = true;
                //else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                //    ignoreKeyPress = true;

                //e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void txtMinQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void txtMaxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == '~' || e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtCustItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == '~' || e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtProductQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }

                //bool ignoreKeyPress = false;

                //bool matchString = Regex.IsMatch(txtProductQty.Text.ToString(), @"\.\d\d\d");

                //if (e.KeyChar == '\b') // Always allow a Backspace
                //    ignoreKeyPress = false;
                //else if (matchString)
                //    ignoreKeyPress = true;
                //else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                //    ignoreKeyPress = true;
                //else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                //    ignoreKeyPress = true;

                //e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Purchase history Qty
        private void txtNewpQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }

                //bool ignoreKeyPress = false;

                //bool matchString = Regex.IsMatch(txtNewpQty.Text.ToString(), @"\.\d\d\d");

                //if (e.KeyChar == '\b') // Always allow a Backspace
                //    ignoreKeyPress = false;
                //else if (matchString)
                //    ignoreKeyPress = true;
                //else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                //    ignoreKeyPress = true;
                //else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                //    ignoreKeyPress = true;

                //e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtCostPrice.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSalesPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtSalesPrice.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtdiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtdiscount.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        public void Bind_Catagory()
        {
            CmbCategory.DataSource = null;
            CmbCategory.Items.Clear();

            //Select CATID , CAT_NAME1 ||' - '|| CAT_NAME2 as 'Catagory' from CAT_MST where TenentID = 9000004
            //string sqlcate = "select CATID , CAT_NAME1 ||' - '|| CAT_NAME2 as 'Catagory' from CAT_MST where TenentID = " + Tenent.TenentID + " ";
            string sqlcate = "select CATID , CAT_NAME1 ||' - '|| CAT_NAME2 as 'Catagory' from CAT_MST where TenentID = " + Tenent.TenentID + " order By Catagory";
            DataTable dtcate = DataAccess.GetDataTable(sqlcate);

            //List<CATMST> ListCat = new List<CATMST>();

            //for (int i = 0; i < dtcate.Rows.Count; i++)
            //{
            //    CATMST obj = new CATMST();

            //    obj.TenentID = Convert.ToInt32(dtcate.Rows[i]["TenentID"]);
            //    obj.CATID = Convert.ToInt32(dtcate.Rows[i]["CATID"]);
            //    obj.PARENT_CATID = Convert.ToInt32(dtcate.Rows[i]["PARENT_CATID"]);
            //    obj.SHORT_NAME = dtcate.Rows[i]["SHORT_NAME"].ToString();
            //    obj.CAT_NAME1 = dtcate.Rows[i]["CAT_NAME1"].ToString();
            //    obj.CAT_NAME2 = dtcate.Rows[i]["CAT_NAME2"].ToString();
            //    obj.CAT_NAME3 = dtcate.Rows[i]["CAT_NAME3"].ToString();               

            //    ListCat.Add(obj);
            //}

            CmbCategory.DataSource = dtcate;// ListCat.Where(p => p.TenentID == Tenent.TenentID).ToList();
            CmbCategory.ValueMember = "CATID";
            CmbCategory.DisplayMember = "Catagory";




            //ComboboxItem item = new ComboboxItem();
            //item.Text = "-- Select Category --";
            //item.Value = 0;

            //ComboCategory.Items.Add(item);
            //ComboCategory.SelectedIndex = 0;

            //if (dtcate.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtcate.Rows.Count; i++)
            //    {
            //        ComboCategory.Items.Add(dtcate.Rows[i]["CAT_NAME1"] + " - " + dtcate.Rows[i]["CAT_NAME2"]);
            //    }
            //}
        }

        public void bind_UOM()
        {
            drpUOM.DataSource = null;
            drpUOM.Items.Clear();

            string sqluom = "select  UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM where TenentID=" + Tenent.TenentID + " ";
            DataTable dtuom = DataAccess.GetDataTable(sqluom);

            drpUOM.DataSource = dtuom;
            drpUOM.DisplayMember = "UOMNAME";
            drpUOM.ValueMember = "UOM";

            //string sqluom = "select   DISTINCT UOMNAME1,UOMNAME2  from ICUOM where TenentID=" + Tenent.TenentID + " ";
            //DataTable dtuom = DataAccess.GetDataTable(sqluom);
            //drpUOM.DataSource = dtuom;
            //drpUOM.DisplayMember = "UOMNAME1";

            //if (dtuom.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtuom.Rows.Count; i++)
            //    {
            //        drpUOM.Items.Add(dtuom.Rows[i][0] + " - " + dtuom.Rows[i][1]);
            //    }
            //}
        }

        public static int getuomID(string UOMNAME1)
        {
            int UOM = 0;
            UOMNAME1 = UOMNAME1.Trim().ToUpper();
            string sql12 = " select * from ICUOM where TenentID = " + Tenent.TenentID + " and upper(UOMNAME1) = '" + UOMNAME1 + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                UOM = Convert.ToInt32(dt1.Rows[0]["UOM"]);
            }
            return UOM;
        }
        public static string getuomName(int UOM)
        {
            string UOMNAME1 = "";
            string sql12 = " select * from ICUOM where TenentID = " + Tenent.TenentID + " and UOM = '" + UOM + "'  ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                UOMNAME1 = dt1.Rows[0]["UOMNAME1"].ToString();
            }
            return UOMNAME1;
        }

        public string Get_uom_EnglisArabic(string UOMEng)
        {
            UOMEng = UOMEng.Trim();
            string UOM = "";
            string sqluom = "select   DISTINCT UOMNAME1,UOMNAME2  from ICUOM where TenentID=" + Tenent.TenentID + " and UOMNAME1 = '" + UOMEng + "' ";
            DataTable dtuom = DataAccess.GetDataTable(sqluom);
            if (dtuom.Rows.Count > 0)
            {
                UOM = (dtuom.Rows[0][0] + " - " + dtuom.Rows[0][1]).ToString();
            }

            return UOM;
        }

        //Check item code verfication
        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sqlitemcode = " select  product_id from   purchase where TenentID = " + Tenent.TenentID + " and product_id = '" + txtProductCode.Text + "' ";
                DataTable dtitemcode = DataAccess.GetDataTable(sqlitemcode);
                if (dtitemcode.Rows.Count > 0)
                {
                    lblValidmsg.ForeColor = System.Drawing.Color.Red;
                    lblValidmsg.Text = "Duplicate item code";
                    if (lblItemcode.Text == "-")
                    {
                        // MessageBox.Show("Warning: Duplicate item code \n Item code already used for another product", "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblprodmsg.Text = "Duplicate Found";
                        txtProductCode.ForeColor = Color.Red;
                        txtProductCode.Focus();
                        btnSave.Enabled = false;
                    }
                }
                else
                {
                    lblValidmsg.ForeColor = System.Drawing.Color.Black;
                    txtProductCode.ForeColor = Color.Black;
                    lblValidmsg.Text = "Valid code";
                    lblprodmsg.Text = "-";

                    txtBarcode.Text = txtProductCode.Text;
                    txtCustItemCode.Text = txtProductCode.Text;
                    btnSave.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Page links
        private void lnkbulkitems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Import_Items"] != null)
            {
                Application.OpenForms["Import_Items"].Close();
                Import_Items go = new Import_Items();
                go.MdiParent = this.ParentForm;
                go.Show();
                this.Close();
            }
            else
            {
                Import_Items go = new Import_Items();
                go.MdiParent = this.ParentForm;
                go.Show();
                this.Close();
            }
            
        }

        private void lnkStocklist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Stock_List"] != null)
            {
                Application.OpenForms["Stock_List"].BringToFront();
                Application.OpenForms["Stock_List"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Stock_List go = new Stock_List();
                go.MdiParent = this.ParentForm;
                go.Show(); 
            }                       
        }

        private void lnkcategories_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Categories"] != null)
            {
                Application.OpenForms["Categories"].BringToFront();
                Application.OpenForms["Categories"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Categories go = new Categories();
                go.MdiParent = this.ParentForm;
                go.Show();
            }
            
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["CustomerDetails"] != null)
            {
                Application.OpenForms["CustomerDetails"].BringToFront();
                Application.OpenForms["CustomerDetails"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                parameter.peopleid = "SUP";
                Customer.CustomerDetails go = new Customer.CustomerDetails();
                go.MdiParent = this.ParentForm;
                go.Show();
            }            
        }

        #endregion

        #region Purchase history

        public static int getPurchasenewid()
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_purchase_history where TenentID = " + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(id) from tbl_purchase_history where TenentID = " + Tenent.TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }
        public void insertpurchasehistory(string ptype, int pQty, string pdate, string UOM, decimal cost, decimal Msrp)
        {
            if (pQty != 0)
            {
                int ID12 = getPurchasenewid();

                string pid = txtProductCode.Text;
                string pname = txtProductName.Text;


                string Catagory = CmbCategory.SelectedValue.ToString();

                //string Catagory = ComboCategory.Text.Split('-')[0].Trim();

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string sql1 = " insert into tbl_purchase_history (TenentID,id, product_id, product_name, product_quantity,cost_price,retail_price, category, " +
                                " supplier, purchase_date, Shopid, ptype ,UOM,Uploadby ,UploadDate ,SynID) " +
                                " values (" + Tenent.TenentID + "," + ID12 + ",'" + pid + "', '" + pname + "', '" + pQty + "', '" + cost + "', '" + Msrp + "','" + Catagory + "', " +
                                "  '" + cmbSupplier.SelectedValue + "', '" + pdate + "' ,'" + cmboShopid.SelectedValue + "', '" + ptype + "', '" + UOM + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                DataAccess.ExecuteSQL(sql1);

                string sql1Win = " insert into Win_tbl_purchase_history (TenentID,id, product_id, product_name, product_quantity,cost_price,retail_price, category, " +
                                " supplier, purchase_date, Shopid, ptype ,UOM,Uploadby ,UploadDate ,SynID) " +
                                " values (" + Tenent.TenentID + "," + ID12 + ",'" + pid + "', N'" + pname + "', '" + pQty + "','" + cost + "','" + Msrp + "', '" + Catagory + "', " +
                                "  '" + cmbSupplier.SelectedValue + "', '" + pdate + "' ,'" + cmboShopid.SelectedValue + "', '" + ptype + "', '" + UOM + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                Datasyncpso.insert_Live_sync_insert_Query(sql1Win, "Win_tbl_purchase_history");

                decimal TotalPurchase = cost * pQty;
                Update_ShiftPurchase_DayClose(TotalPurchase);

                string ActivityName = "purchase Item";
                string LogData = "purchase Item with product_id = " + pid + "and UOM = " + UOM + " ";
                Login.InsertUserLog(ActivityName, LogData);

                int UOMID = Convert.ToInt32(UOM);// getuomid(UOM);

                add_perisable(pid, UOMID, ID12);
            }

        }

        public static void Update_ShiftPurchase_DayClose(decimal ShiftPurchase)
        {
            //TenentID,UserID,TrmID,ShiftID,Date,OpAMT,ShiftSales,ShiftReturn,ShiftCIH,VoucharAMT,ExpAMT,ChequeAMT,AMTDelivered,DeliveredTO,RefNO,Notes,UploadDate,
            //Uploadby,	SyncDate,Syncby,SynID

            int ShiftID = UserInfo.ShiftID;

            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sql5 = "Select * from DayClose where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                decimal ShiftSalesold = Convert.ToDecimal(dt5.Rows[0]["ShiftPurchase"]);
                ShiftPurchase = ShiftPurchase + ShiftSalesold;

                string sql1 = " Update DayClose set ShiftPurchase=" + ShiftPurchase + " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'  ";
                DataAccess.ExecuteSQL(sql1);

                string sqlWin = "  Update DayClose set ShiftPurchase=" + ShiftPurchase + " " +
                       " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'  ";
                Datasyncpso.Update_Live_sync_Update_Query(sqlWin, "DayClose");

                DataAccess.Update_ShiftCIH_DayClose();

            }

        }

        public static void add_perisable(string productid, int uom, int MY_TRANS_ID)
        {
            //incoplate

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string q = "select * from ICIT_BR_TMP where TenentID=" + Tenent.TenentID + " and MyProdID =" + productid + "  and UOM=" + uom + " and MYTRANSID=" + MY_TRANS_ID + " ";
            DataTable dt1 = DataAccess.GetDataTable(q);
            if (dt1.Rows.Count > 0)
            {
                int MyProdID = Convert.ToInt32(productid);
                string period_code = "201801";
                string MySysName = "PUR";
                int LocationID = 0;
                int MYTRANSID = MY_TRANS_ID;
                string Batch_No = dt1.Rows[0]["BatchNo"].ToString();


                int qty1 = Convert.ToInt32(dt1.Rows[0]["NewQty"]);
                string ProdDate1 = dt1.Rows[0]["ProdDate"].ToString();
                string ExpiryDate1 = dt1.Rows[0]["ExpiryDate"].ToString();
                string LeadDays2Destroy1 = dt1.Rows[0]["LeadDays2Destroy"].ToString();

                string query = "select * from ICIT_BR_Perishable where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and BatchNo='" + Batch_No + "' ";
                DataTable dtquery = DataAccess.GetDataTable(query);
                if (dtquery.Rows.Count < 1)
                {
                    int Onhandold = 0;
                    int QtyReceivedold = 0;

                    int OnHand = qty1 + Onhandold;
                    int QtyReceived = qty1 + QtyReceivedold;

                    string sql1 = "insert into ICIT_BR_Perishable (TenentID, MyProdID,period_code,MySysName,UOM,BatchNo,LocationID,MYTRANSID, " +
                                  " OnHand,QtyReceived,ProdDate,ExpiryDate,LeadDays2Destroy,Active, Uploadby ,UploadDate ,SynID)" +
                                  " values (" + Tenent.TenentID + "," + MyProdID + " ,'" + period_code + "' ,'" + MySysName + "' , " + uom + ", " +
                                  " '" + Batch_No + "','" + LocationID + "','" + MYTRANSID + "', " + OnHand + "," + QtyReceived + ", '" + ProdDate1 + "','" + ExpiryDate1 + "' , '" + LeadDays2Destroy1 + "' , 'Y' , " +
                                  " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                    DataAccess.ExecuteSQL(sql1);
                    Datasyncpso.insert_Live_sync_insert_Query(sql1, "ICIT_BR_Perishable");
                }
                else
                {
                    int Onhandold = Convert.ToInt32(dtquery.Rows[0]["OnHand"]);
                    int QtyReceivedold = Convert.ToInt32(dtquery.Rows[0]["QtyReceived"]);

                    int OnHand = qty1 + Onhandold;
                    int QtyReceived = qty1 + QtyReceivedold;

                    string sql1 = "Update ICIT_BR_Perishable set OnHand='" + OnHand + "',QtyReceived='" + QtyReceived + "', ProdDate='" + ProdDate1 + "' ,ExpiryDate='" + ExpiryDate1 + "' ,LeadDays2Destroy = '" + LeadDays2Destroy1 + "',  " +
                              " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                              " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and BatchNo='" + Batch_No + "'  ";
                    DataAccess.ExecuteSQL(sql1);
                    Datasyncpso.Update_Live_sync_Update_Query(sql1, "ICIT_BR_Perishable");
                }
            }

        }

        public void updatestockqty()
        {
            string pid = txtProductCode.Text;
            string UOMstr = drpPurchaseHistryUOM.Text;
            int UOM = Convert.ToInt32(drpPurchaseHistryUOM.SelectedValue);
            string sql2 = "select OnHand,QtyRecived from tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID = '" + pid + "' and UOMID = '" + UOM + "'  and Deleted='Y' ";
            DataTable dtterminallist = DataAccess.GetDataTable(sql2);
            int rows = dtterminallist.Rows.Count;
            string Qty = dtterminallist.Rows[0]["OnHand"].ToString();
            string OldQtyRecived = dtterminallist.Rows[0]["QtyRecived"].ToString() == "" ? "0" : dtterminallist.Rows[0]["QtyRecived"].ToString();
            double StockQty = Convert.ToDouble(Qty) + Convert.ToDouble(txtNewpQty.Text);
            double NewQtyRecived = Convert.ToDouble(OldQtyRecived) + Convert.ToDouble(txtNewpQty.Text);

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = " update tbl_item_uom_price set " +
                                    " OnHand = '" + StockQty + "' , " +
                                    " QtyRecived = '" + NewQtyRecived + "' , " +
                                    " msrp= '" + txtPHSalePrice.Text + "' , " +
                                    " price = '" + txtPHCostPrice.Text + "' ," +
                                    " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    "  where TenentID= " + Tenent.TenentID + " and itemID = '" + pid + "' and UOMID = '" + UOM + "'";
            DataAccess.ExecuteSQL(sql);

            string sqlwin = " update Win_tbl_item_uom_price set " +
                                   " OnHand = '" + StockQty + "' , " +
                                   " QtyRecived = '" + NewQtyRecived + "' , " +
                                   " msrp= '" + txtPHSalePrice.Text + "' , " +
                                   " price = '" + txtPHCostPrice.Text + "' ," +
                                   " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                   " where TenentID= " + Tenent.TenentID + " and itemID = '" + pid + "' and UOMID = '" + UOM + "'";
            Datasyncpso.Update_Live_sync_Update_Query(sqlwin, "Win_tbl_item_uom_price");
        }

        private void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewpQty.Text == "")
                {
                    MessageBox.Show("Please Insert Purchase Quantity");
                    txtNewpQty.Focus();
                }
                else
                {
                    //string UOM = drpPurchaseHistryUOM.Text;
                    string UOM = drpPurchaseHistryUOM.SelectedValue.ToString();

                    decimal cost = Convert.ToDecimal(txtPHCostPrice.Text);
                    decimal Msrp = Convert.ToDecimal(txtPHSalePrice.Text);

                    insertpurchasehistory("OLD", Convert.ToInt32(txtNewpQty.Text), dtpurchaseDate.Text, UOM, cost, Msrp);
                    updatestockqty();

                    DialogResult result = MessageBox.Show("Purchase history hase been saved Successfully. \n\n Do you want to see Purchase history?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Yes)
                    {
                        Items.Purchase_History go = new Items.Purchase_History();
                        go.MdiParent = this.ParentForm;
                        go.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //btnPurchaseHistory.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        private void chMultiUOM_CheckedChanged(object sender, EventArgs e)
        {
            if (chMultiUOM.Checked)
                btnUomAdd.Visible = dgrvMultiUomList.Visible = true;
            else
                btnUomAdd.Visible = dgrvMultiUomList.Visible = false;
        }
        private void dgrvMultiUomList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Delete items From Gridview
                if (e.ColumnIndex == dgrvMultiUomList.Columns["del"].Index && e.RowIndex >= 0)
                {
                    string sql = "select OpQty from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "'";
                    DataTable dtlist = DataAccess.GetDataTable(sql);

                    int rows1 = dtlist.Rows.Count;
                    if (rows1 == 1)
                    {
                        MessageBox.Show("Atleast One UOM Required ");
                        return;
                    }
                    else
                    {
                        foreach (DataGridViewRow row2 in dgrvMultiUomList.SelectedRows)
                        {
                            string uomname = row2.Cells[0].Value.ToString().Trim();
                            int UOM = getuomID(uomname);
                            int OnhandQty = Convert.ToInt32(row2.Cells[1].Value);

                            string sql2 = "select OpQty from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";
                            DataTable dtterminallist = DataAccess.GetDataTable(sql2);

                            int rows = dtterminallist.Rows.Count;
                            if (rows == 1)
                            {
                                int opaningQty = Convert.ToInt32(dtterminallist.Rows[0]["OpQty"].ToString());
                                if (OnhandQty == opaningQty)
                                {
                                    if (!row2.IsNewRow)
                                        dgrvMultiUomList.Rows.Remove(row2);

                                    string sqlDelete = "Delete from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";
                                    DataAccess.ExecuteSQL(sqlDelete);

                                    string sqlLive = "Delete from Win_tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";
                                    Datasyncpso.Delete_Live_sync_Delete_Query(sqlLive, "Win_tbl_item_uom_price");
                                }
                                else
                                {
                                    MessageBox.Show("Aready Use this UOM so you can't delete ....");
                                }

                            }

                        }
                    }                    
                }
                // Edit items From Gridview
                if (e.ColumnIndex == dgrvMultiUomList.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgrvMultiUomList.SelectedRows)
                    {

                        string uomname = row.Cells[0].Value.ToString().Trim();
                        double cprice = Convert.ToDouble(row.Cells[3].Value);
                        double sprice = Convert.ToDouble(row.Cells[2].Value);
                        int OnhandQty = Convert.ToInt32(row.Cells[1].Value);

                        EditUOM(uomname);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EditUOM(string uomname)
        {
            int UOM = getuomID(uomname);
            string sql2 = "select Image,OpQty,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,RecipeType,recNo,msrp,price,OnHand,UOMID from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";
            DataTable dtterminallist = DataAccess.GetDataTable(sql2);
            int rows = dtterminallist.Rows.Count;
            if (rows == 1)
            {
                string uom = Get_uom_EnglisArabic(uomname);
                drpUOM.SelectedValue = dtterminallist.Rows[0]["UOMID"].ToString();
                txtCostPrice.Text = dtterminallist.Rows[0]["price"].ToString();
                txtSalesPrice.Text = dtterminallist.Rows[0]["msrp"].ToString();
                lblOnhandqty.Text = dtterminallist.Rows[0]["OnHand"].ToString();
                txtdiscount.Text = dtterminallist.Rows[0]["Discount"].ToString() != "" && dtterminallist.Rows[0]["Discount"].ToString() != null ? dtterminallist.Rows[0]["Discount"].ToString() : "0";
                txtMaxQty.Text = dtterminallist.Rows[0]["MaxQty"].ToString();
                txtMinQty.Text = dtterminallist.Rows[0]["minQty"].ToString();
                txtProductQty.Text = dtterminallist.Rows[0]["OpQty"].ToString();
                lblSaleQty.Text = dtterminallist.Rows[0]["QtyOut"].ToString();
                lblPurchaseQty.Text = dtterminallist.Rows[0]["QtyRecived"].ToString();
                lblConsumedQty.Text = dtterminallist.Rows[0]["QtyConsumed"].ToString();
                lblReservedQty.Text = dtterminallist.Rows[0]["QtyReserved"].ToString();
                string path = Application.StartupPath + @"\ITEMIMAGE\" + dtterminallist.Rows[0]["Image"].ToString() + "";
                if (File.Exists(path))
                {
                    picItemUOMimage.ImageLocation = path;
                    picItemUOMimage.InitialImage.Dispose();
                }
                else
                {
                    picItemUOMimage.ImageLocation = Application.StartupPath + @"\ITEMIMAGE\item.png";
                    picItemUOMimage.InitialImage.Dispose();
                }

                if (dtterminallist.Rows[0]["RecipeType"] != null)
                {
                    comboRecipeType.Text = dtterminallist.Rows[0]["RecipeType"].ToString();
                }

                drpUOM.Enabled = txtProductQty.Enabled = false;
                btnUomAdd.Text = "Update";
            }
            else
            {
                MessageBox.Show("Multiple Records Exit , Please contact to Admistrator.");
            }
        }

        public string get_FullRecipeName(int recNo)
        {
            string RecipeName = "";
            string sql = "SELECT  (recNo || ' - ' ||Receipe_English || ' - ' || Receipe_Arabic) as Receipe    FROM tbl_Receipe where TenentID = " + Tenent.TenentID + " and recNo = " + recNo + " ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                RecipeName = dt.Rows[0][0].ToString();
            }

            return RecipeName;
        }

        private void btnUomAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Login.InternetConnection() == false)
                //{
                //    MessageBox.Show("Internet Connection Not Avalable. try again later");
                //    return;
                //}

                //bool Falg = Login.CheckDBConnection();
                //if (Falg == false)
                //{
                //    MessageBox.Show("online Server Connection Fail. try again later");
                //    return;
                //}

                string UOMID = drpUOM.SelectedValue.ToString();
                int UOMIC = Convert.ToInt32(UOMID);
                string imageName;
                if (lblUOMFileExtension.Text == "item.png") //if not select image
                {
                    imageName = lblimagename.Text;
                }
                else  // select image
                {
                    string UOMEng = getuomName(UOMIC);
                    if (lblItemcode.Text == "-")
                    {
                        imageName = txtProductCode.Text + UOMEng + lblUOMFileExtension.Text;
                    }
                    else
                    {
                        imageName = lblItemcode.Text + UOMEng + lblUOMFileExtension.Text;
                    }

                }
                string uomname = getuomName(UOMIC); ;
                if (btnUomAdd.Text == "Add")
                {
                    int rows = dgrvMultiUomList.Rows.Count;

                    if (rows > 0)
                    {
                        if (drpUOM.SelectedItem != null && txtCostPrice.Text != "" && txtProductCode.Text != "" && txtSalesPrice.Text != "" && txtProductQty.Text != "")
                        {
                            for (int i = 0; i < rows; i++)
                            {
                                string grduomname = dgrvMultiUomList.Rows[i].Cells[0].Value.ToString();
                                //string grdCostPrice = dgrvMultiUomList.Rows[i].Cells[1].Value.ToString();
                                //string grdqty = dgrvMultiUomList.Rows[i].Cells[2].Value.ToString();
                                //string grdSalePrice = dgrvMultiUomList.Rows[i].Cells[3].Value.ToString();
                                if (grduomname == uomname)
                                {
                                    MessageBox.Show("", "Already There..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            if (lblimagename.Text != "item.png") // if select image
                            {
                                picItemUOMimage.InitialImage.Dispose();
                                string path = Application.StartupPath + @"\ITEMIMAGE\";

                                System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);
                                if (di.Exists)
                                {
                                    path = UserInfo.Img_path;
                                }
                                System.IO.File.Delete(path + @"\" + imageName);
                                if (!System.IO.Directory.Exists(path))
                                    System.IO.Directory.CreateDirectory(path);
                                string filename = path + @"\" + openFileDialog1.SafeFileName;
                                picItemUOMimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                                System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                            }

                            string RecipeType = "Output";
                            int recNo = 0;

                            //if (chkkitchenDisplay.Checked == true)
                            //{
                            RecipeType = comboRecipeType.Text;
                            //}

                            dgrvMultiUomList.Rows.Add(uomname, txtProductQty.Text, txtSalesPrice.Text, txtCostPrice.Text);


                            int quan = Convert.ToInt32(txtProductQty.Text);

                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            string Discount = txtdiscount.Text != "" ? txtdiscount.Text : "0";

                            int ID12 = DataAccess.getuom_priceMYid(Tenent.TenentID, txtProductCode.Text, UOMIC);

                            //string sql1win = " insert into Win_tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved, " +
                            //              " QtyRecived,msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                            //              " values (" + Tenent.TenentID + "," + ID12 + ",'" + txtProductCode.Text + "', '" + UOMID + "', '" + txtProductQty.Text + "', " +
                            //              " '" + txtProductQty.Text + "',0,0,0,0, '" + txtSalesPrice.Text + "', '" + txtCostPrice.Text + "','Y'," +
                            //              " '" + txtMinQty.Text + "', '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                            //              " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            //int insertFalg = DataLive.ExecuteLiveSQL(sql1win);

                            //if (insertFalg == 1)
                            //{
                                string sql1 = " insert into tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved, " +
                                          " QtyRecived,msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                          " values (" + Tenent.TenentID + ", " + ID12 + ",'" + txtProductCode.Text + "', '" + UOMID + "', '" + txtProductQty.Text + "', " +
                                          " '" + txtProductQty.Text + "',0,0,0,0, '" + txtSalesPrice.Text + "', '" + txtCostPrice.Text + "','Y'," +
                                          " '" + txtMinQty.Text + "', '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                          " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                                DataAccess.ExecuteSQL(sql1);

                                string sql1win = " insert into Win_tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved, " +
                                              " QtyRecived,msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                              " values (" + Tenent.TenentID + "," + ID12 + ",'" + txtProductCode.Text + "', '" + UOMID + "', '" + txtProductQty.Text + "', " +
                                              " '" + txtProductQty.Text + "',0,0,0,0, '" + txtSalesPrice.Text + "', '" + txtCostPrice.Text + "','Y'," +
                                              " '" + txtMinQty.Text + "', '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                              " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                                Datasyncpso.insert_Live_sync_insert_Query(sql1win, "Win_tbl_item_uom_price");

                                string ActivityName = "Add Product With UOM";
                                string LogData = "Add Product With UOM product id = " + txtProductCode.Text + " UOM " + uomname + " ";
                                Login.InsertUserLog(ActivityName, LogData);

                                //Add to purchase history - New item history

                                decimal cost = Convert.ToDecimal(txtCostPrice.Text);
                                decimal Msrp = Convert.ToDecimal(txtSalesPrice.Text);

                                //insertpurchasehistory("NEW", quan, DateTime.Now.ToString("yyyy-MM-dd"), UOMID, cost, Msrp);

                            //}
                        }
                        else
                        {
                            MessageBox.Show("Cost Price,Sale Price and Product must be Reqiuted..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        dgrvMultiUomList.Rows.Clear();
                        dgrvMultiUomList.Rows.Add(uomname, txtProductQty.Text, txtSalesPrice.Text, txtCostPrice.Text);

                        if (lblimagename.Text != "item.png") // if select image
                        {
                            picItemUOMimage.InitialImage.Dispose();
                            string path = Application.StartupPath + @"\ITEMIMAGE\";

                            System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);
                            if (di.Exists)
                            {
                                path = UserInfo.Img_path;
                            }
                            System.IO.File.Delete(path + @"\" + imageName);
                            if (!System.IO.Directory.Exists(path))
                                System.IO.Directory.CreateDirectory(path);
                            string filename = path + @"\" + openFileDialog1.SafeFileName;
                            picItemUOMimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                            System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                        }

                        string RecipeType = "";
                        int recNo = 0;

                        //if (chkkitchenDisplay.Checked == true)
                        //{
                        RecipeType = comboRecipeType.Text;
                        //}

                        int quan = Convert.ToInt32(txtProductQty.Text);

                        string Discount = txtdiscount.Text != "" ? txtdiscount.Text : "0";
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        int ID12 = DataAccess.getuom_priceMYid(Tenent.TenentID, txtProductCode.Text, UOMIC);

                        //string sql1Win = " insert into Win_tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                        //                " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                        //                " values (" + Tenent.TenentID + "," + ID12 + " , '" + txtProductCode.Text + "', '" + UOMID + "', '" + txtProductQty.Text + "', " +
                        //                " '" + txtProductQty.Text + "',0,0,0,0, '" + txtSalesPrice.Text + "', '" + txtCostPrice.Text + "','Y', '" + txtMinQty.Text + "', " +
                        //                " '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                        //                " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        //int insertFlag = DataLive.ExecuteLiveSQL(sql1Win);

                        //if (insertFlag == 1)
                        //{
                            string sql1 = " insert into tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                                      " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                      " values (" + Tenent.TenentID + "," + ID12 + " ,'" + txtProductCode.Text + "', '" + UOMID + "', '" + txtProductQty.Text + "', " +
                                      " '" + txtProductQty.Text + "',0,0,0,0, '" + txtSalesPrice.Text + "', '" + txtCostPrice.Text + "','Y', '" + txtMinQty.Text + "', " +
                                      " '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                      " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            DataAccess.ExecuteSQL(sql1);

                            string sql1Win = " insert into Win_tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                                             " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                             " values (" + Tenent.TenentID + "," + ID12 + " , '" + txtProductCode.Text + "', '" + UOMID + "', '" + txtProductQty.Text + "', " +
                                             " '" + txtProductQty.Text + "',0,0,0,0, '" + txtSalesPrice.Text + "', '" + txtCostPrice.Text + "','Y', '" + txtMinQty.Text + "', " +
                                             " '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                             " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            Datasyncpso.insert_Live_sync_insert_Query(sql1Win, "Win_tbl_item_uom_price");

                            string ActivityName = "Add Product With UOM";
                            string LogData = "Add Product With UOM product id = " + txtProductCode.Text + " UOM " + uomname + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            //Add to purchase history - New item history

                            decimal cost = Convert.ToDecimal(txtCostPrice.Text);
                            decimal Msrp = Convert.ToDecimal(txtSalesPrice.Text);

                            //insertpurchasehistory("NEW", quan, DateTime.Now.ToString("yyyy-MM-dd"), UOMID, cost, Msrp);
                        //}
                    }
                }
                else if (btnUomAdd.Text == "Update")
                {
                    if (lblimagename.Text != "item.png") // if select image
                    {
                        picItemUOMimage.InitialImage.Dispose();
                        string path = Application.StartupPath + @"\ITEMIMAGE\";

                        if (File.Exists(path + @"\" + imageName))
                            System.IO.File.Delete(path + @"\" + imageName);
                        if (!System.IO.Directory.Exists(path))
                            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\ITEMIMAGE\");
                        string filename = path + @"\" + openFileDialog1.SafeFileName;
                        picItemUOMimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                    }

                    string RecipeType = "";
                    int recNo = 0;

                    //if (chkkitchenDisplay.Checked == true)
                    //{
                    RecipeType = comboRecipeType.Text;
                    //}

                    string Discount = txtdiscount.Text != "" ? txtdiscount.Text : "0";
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    //string sql2win = " Update win_tbl_item_uom_price set price = '" + txtCostPrice.Text + "', msrp= '" + txtSalesPrice.Text + "', Discount= '" + Discount + "', " +
                    //                 " minQty= '" + txtMinQty.Text + "', MaxQty= '" + txtMaxQty.Text + "' , Image='" + imageName + "' , RecipeType = '" + RecipeType + "', recNo = " + recNo + " , " +
                    //                 " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                    //                 " where itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOMID + "' and TenentID= " + Tenent.TenentID + " ";
                    //int updateflag = DataLive.ExecuteLiveSQL(sql2win);

                    //if (updateflag == 1)
                    //{
                        string sql2 = " Update tbl_item_uom_price set price = '" + txtCostPrice.Text + "', msrp= '" + txtSalesPrice.Text + "', Discount= '" + Discount + "', " +
                                  " minQty= '" + txtMinQty.Text + "', MaxQty= '" + txtMaxQty.Text + "' , Image='" + imageName + "' , RecipeType = '" + RecipeType + "', recNo = " + recNo + " , " +
                                  " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                  " where itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOMID + "' and TenentID= " + Tenent.TenentID + " ";
                        DataAccess.ExecuteSQL(sql2);

                        string sql2win = " Update win_tbl_item_uom_price set price = '" + txtCostPrice.Text + "', msrp= '" + txtSalesPrice.Text + "', Discount= '" + Discount + "', " +
                                         " minQty= '" + txtMinQty.Text + "', MaxQty= '" + txtMaxQty.Text + "' , Image='" + imageName + "' , RecipeType = '" + RecipeType + "', recNo = " + recNo + " , " +
                                         " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                         " where itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOMID + "' and TenentID= " + Tenent.TenentID + " ";
                        Datasyncpso.Update_Live_sync_Update_Query(sql2win, "win_tbl_item_uom_price");

                        string ActivityName = "Update Product With UOM";
                        string LogData = "Update Product With UOM product id = " + lblItemcode.Text + " UOM " + uomname + " ";
                        Login.InsertUserLog(ActivityName, LogData);

                        foreach (DataGridViewRow row2 in dgrvMultiUomList.SelectedRows)
                        {
                            if (!row2.IsNewRow)
                                dgrvMultiUomList.Rows.Remove(row2);
                        }
                        dgrvMultiUomList.Rows.Add(uomname, txtProductQty.Text, txtSalesPrice.Text, txtCostPrice.Text);
                        ClearUpdate();
                        MessageBox.Show("Update Successfully..", "Update Successfully..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearUpdate()
        {
            btnUomAdd.Text = "Add";
            drpUOM.Enabled = true;
            txtSalesPrice.Text = "";
            txtCostPrice.Text = "";
            txtdiscount.Text = "";
            txtMinQty.Text = "";
            txtMaxQty.Text = "";
            lblConsumedQty.Text = "";
            lblOnhandqty.Text = "";
            lblPurchaseQty.Text = "";
            lblReservedQty.Text = "";
            lblSaleQty.Text = "";
        }

        private void btnUOMBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //  openFileDialog1.InitialDirectory = @"C:\";
            //  openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = ".jpg";
            // openFileDialog1.Filter = "GIF files (*.gif)|*.gif| jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png| All files (*.*)|*.*";
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png";

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            //openFileDialog1.ReadOnlyChecked = true;
            //openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //textBox1.Text = openFileDialog1.FileName;
                //picItemimage.ImageLocation = openFileDialog1.FileName;
                //lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
                picItemUOMimage.Image = new Bitmap(openFileDialog1.FileName);
                //picItemUOMimage.ImageLocation = openFileDialog1.FileName;
                lblUOMFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            }
        }

        private void drpPurchaseHistryUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string sql2 = "select UOMID,OnHand,price,msrp from tbl_item_uom_price " +
                //              " where TenentID = " + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and UOMID = '" + drpPurchaseHistryUOM.Text + "' and Deleted='Y'";
                string sql2 = "select UOMID,OnHand,price,msrp from tbl_item_uom_price " +
                              " where TenentID = " + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and UOMID = '" + drpPurchaseHistryUOM.SelectedValue + "' and Deleted='Y'";
                DataTable dtterminallist = DataAccess.GetDataTable(sql2);
                int rows = dtterminallist.Rows.Count;
                if (rows > 0)
                {
                    txtPHSalePrice.Text = dtterminallist.Rows[0]["msrp"].ToString();//msrp
                    txtPHCostPrice.Text = dtterminallist.Rows[0]["price"].ToString(); //price
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            string Name = txtProductName.Text;
            string arabic = "";

            bool Internat = Login.InternetConnection();
            if (Internat == true)
            {
                arabic = DataAccess.Translate(txtProductName.Text, "ar");
            }
            else
            {
                arabic = txtProductName.Text;
            }

            txtNameArabic.Text = arabic;
            txtproduct_name_print.Text = Name + " - " + arabic;
        }


        public bool IsParisable(string product_id)
        {
            if (checkPerishable.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtNewpQty_TextChanged(object sender, EventArgs e)
        {
            if (txtNewpQty.Text != "")
            {
                string pid = txtProductCode.Text;
                bool Parisable = IsParisable(pid);
                if (Parisable == true)
                {
                    string UOM = drpPurchaseHistryUOM.SelectedValue.ToString();
                    int MY_TRANS_ID = getPurchasenewid();
                    string MySysName = "PUR";

                    Items.Perishable go = new Items.Perishable(txtProductCode.Text, UOM, MY_TRANS_ID, MySysName);
                    go.Qty = txtNewpQty.Text;
                    go.Show();
                }
            }
        }

        private void txtProductQty_TextChanged(object sender, EventArgs e)
        {
            if (txtProductQty.Text != "")
            {
                string pid = txtProductCode.Text;
                bool Parisable = IsParisable(pid);
                if (Parisable == true)
                {
                    string UOMID = drpUOM.SelectedValue.ToString();
                    int UOMIC = Convert.ToInt32(UOMID);
                    //string uom = getuomName(UOMIC);
                    int MY_TRANS_ID = getPurchasenewid();
                    string MySysName = "PUR";

                    Items.Perishable go = new Items.Perishable(txtProductCode.Text, UOMID, MY_TRANS_ID, MySysName);
                    go.Qty = txtProductQty.Text;
                    go.Show();
                }
            }
        }

        public void BindGrid()
        {
            string PID = "0";
            if (txtProductCode.Text != "")
            {
                string PRoductID = txtProductCode.Text.ToString();
                PRoductID = PRoductID.Trim();
                PID = PRoductID;
            }

            string sql = " select MYPRODID as id, RalatedProdID as rid, (select product_id || ' - ' || product_name || ' - ' || product_name_Arabic from purchase where TenentID=" + Tenent.TenentID + " and product_id = TblProductRelated.MYPRODID ) as 'Item name' , " +
                         " (select product_id || ' - ' || product_name || ' - ' || product_name_Arabic from purchase where TenentID=" + Tenent.TenentID + " and product_id = TblProductRelated.RalatedProdID ) as 'Related Item name'" +
                         " from TblProductRelated where TenentID=" + Tenent.TenentID + " and MYPRODID = " + PID + " ";

            DataTable dt = DataAccess.GetDataTable(sql);

            int Count = GEtRelatedCount(PID);
            if (Count > 0)
            {
                panel1.Visible = true;
                datagrdReportDetails.DataSource = dt;
                datagrdReportDetails.Columns["id"].Visible = false;
                datagrdReportDetails.Columns["rid"].Visible = false;
                datagrdReportDetails.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                datagrdReportDetails.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        public int GEtRelatedCount(string PID)
        {
            string sql = " select * from TblProductRelated where tenentid=" + Tenent.TenentID + " and MYPRODID = " + PID + " ";
            DataTable dt = DataAccess.GetDataTable(sql);
            return dt.Rows.Count;
        }

        private void datagrdReportDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == datagrdReportDetails.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in datagrdReportDetails.SelectedRows)
                    {
                        int MYPRODID = Convert.ToInt32(rowdel.Cells["id"].Value);
                        int RalatedProdID = Convert.ToInt32(rowdel.Cells["rid"].Value);

                        string sqldel = " delete from TblProductRelated  where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "' ";
                        DataAccess.ExecuteSQL(sqldel);

                        string sqlUpdateCmdWIN = " delete from Win_TblProductRelated  where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "'";
                        Datasyncpso.Delete_Live_sync_Delete_Query(sqlUpdateCmdWIN, "TblProductRelated");
                    }
                    BindGrid();
                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void comboRecipeType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnrefsuplier_Click(object sender, EventArgs e)
        {
            BindSupplier();
        }

        private void btnrefuom_Click(object sender, EventArgs e)
        {
            bind_UOM();
        }

        private void btnRefCategory_Click(object sender, EventArgs e)
        {
            Bind_Catagory();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ItemSearch"] != null)
            {
                Application.OpenForms["ItemSearch"].Close();
            }
            this.Refresh();

            ItemSearch go = new ItemSearch();
            go.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_Item go = new Add_Item();
            go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
            go.Show();
            this.Close();
        }
        
    }

    public class CATMST
    {
        public int TenentID { get; set; }
        public int CATID { get; set; }
        public int PARENT_CATID { get; set; }
        public string DefaultPic { get; set; }
        public string SHORT_NAME { get; set; }
        public string CAT_NAME1 { get; set; }
        public string CAT_NAME2 { get; set; }
        public string CAT_NAME3 { get; set; }
        public string CAT_DESCRIPTION { get; set; }
        public string CAT_TYPE { get; set; }
        public string WARRANTY { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public string Active { get; set; }
        public Nullable<decimal> SupplierPercent { get; set; }
        public string switch1 { get; set; }
        public string switch2 { get; set; }
        public string switch3 { get; set; }
        public string DisplaySort { get; set; }
        public string AlwaysShow { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
        public string COLOR_NAME { get; set; }
    }
}
