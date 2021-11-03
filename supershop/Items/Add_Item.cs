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
using supershop.Items;

namespace supershop
{
    public partial class Add_Item : Form
    {
        public Add_Item()
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
                         " QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,UOM,category_arabic,IsPerishable,IsSerialize,custitemCode,Barcode,RecipeType,product_name_Arabic,product_name_print,BaseUOM " +
                         " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                         " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + lblItemcode.Text + "' ";
            //string sql = " SELECT  Shopid,product_name,category,supplier,status,taxapply,imagename,product_id,UOMID,msrp,price,Deleted,OpQty,OnHand,QtyOut, " +
            //            " QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,UOM,category_arabic,IsPerishable,custitemCode,Barcode,RecipeType,product_name_Arabic,product_name_print,BaseUOM " +
            //            " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
            //            " where purchase.TenentID = " + Tenent.TenentID + " and product_id = '" + lblItemcode.Text + "' ";//Yogesh
            DataTable dt1 = DataAccess.GetDataTable(sql);

            if (dt1.Rows.Count > 0)
            {
                string isuom = dt1.Rows[0]["UOM"].ToString();

                string PID = lblItemcode.Text;

                int BaseUOM = dt1.Rows[0]["BaseUOM"] != null && dt1.Rows[0]["BaseUOM"].ToString() != "" ? Convert.ToInt32(dt1.Rows[0]["BaseUOM"]) : 0;

                if (isuom == "Y")
                {

                    chMultiUOM.Checked = true;
                    //chMultiUOM.Enabled = false;
                    btnUomAdd.Visible = true;
                    dgrvMultiUomList.Visible = true;

                    string sql2 = "select UOMID,UOMNAME1,OpQty,OnHand,msrp,price from tbl_item_uom_price iup inner join ICUOM IC on IC.UOM = iup.UOMID and IC.TenentID = iup.TenentID " +
                        " where iup.TenentID = " + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y'";

                    DataTable dtterminallist = DataAccess.GetDataTable(sql2);

                    int rows = dtterminallist.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        if (BaseUOM == 0)
                        {
                            BaseUOM = Convert.ToInt32(dtterminallist.Rows[i]["UOMID"]);
                        }

                        string uomname = dtterminallist.Rows[i]["UOMNAME1"].ToString();
                        string UnitCost = dtterminallist.Rows[i]["price"].ToString();
                        string Qty = dtterminallist.Rows[i]["OpQty"].ToString();
                        string SalePrice = dtterminallist.Rows[i]["msrp"].ToString();
                        dgrvMultiUomList.Rows.Add(uomname, Qty, UnitCost, SalePrice);
                    }

                    bool Allow_OpQty = EditAllow_OpQty(PID);
                    if (Allow_OpQty == true)
                    {

                    }
                    else
                    {
                        string uomname1 = getuomName(BaseUOM);
                        EditUOM(uomname1);
                    }

                }
                else
                {
                    chMultiUOM.Checked = false;

                    string sql2 = "select UOMID,UOMNAME1,OpQty,OnHand,msrp,price from tbl_item_uom_price iup inner join ICUOM IC on IC.UOM = iup.UOMID and IC.TenentID = iup.TenentID " +
                       " where iup.TenentID = " + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' ";

                    DataTable dtterminallist = DataAccess.GetDataTable(sql2);
                    int rows = dtterminallist.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        string uomname = dtterminallist.Rows[i]["UOMNAME1"].ToString();
                        if (BaseUOM == 0)
                        {
                            BaseUOM = Convert.ToInt32(dtterminallist.Rows[i]["UOMID"]);
                        }
                        string UnitCost = dtterminallist.Rows[i]["price"].ToString();
                        string Qty = dtterminallist.Rows[i]["OpQty"].ToString();
                        string SalePrice = dtterminallist.Rows[i]["msrp"].ToString();
                        dgrvMultiUomList.Rows.Add(uomname, Qty, UnitCost, SalePrice);
                    }

                    string uomname1 = dtterminallist.Rows[0]["UOMNAME1"].ToString();
                    EditUOM(uomname1);
                }

                string uom_name = getuomName(BaseUOM);
                selectuom(uom_name);

                GetTransetionCount(PID);

                txtProductCode.Enabled = false;
                txtProductCode.Text = dt1.Rows[0]["product_id"] != null && dt1.Rows[0]["product_id"].ToString() != "" ? dt1.Rows[0]["product_id"].ToString() : "";
                txtProductName.Text = dt1.Rows[0]["product_name"] != null && dt1.Rows[0]["product_name"].ToString() != "" ? dt1.Rows[0]["product_name"].ToString() : "";
                txtNameArabic.Text = dt1.Rows[0]["product_name_Arabic"] != null && dt1.Rows[0]["product_name_Arabic"].ToString() != "" ? dt1.Rows[0]["product_name_Arabic"].ToString() : "";
                txtproduct_name_print.Text = dt1.Rows[0]["product_name_print"] != null && dt1.Rows[0]["product_name_print"].ToString() != "" ? dt1.Rows[0]["product_name_print"].ToString() : "";

                txtProductQty.Text = dt1.Rows[0]["OpQty"] != null && dt1.Rows[0]["OpQty"].ToString() != "" ? dt1.Rows[0]["OpQty"].ToString() : "";
                txtCostPrice.Text = dt1.Rows[0]["price"] != null && dt1.Rows[0]["price"].ToString() != "" ? dt1.Rows[0]["price"].ToString() : "";
                txtSalesPrice.Text = dt1.Rows[0]["msrp"] != null && dt1.Rows[0]["msrp"].ToString() != "" ? dt1.Rows[0]["msrp"].ToString() : "";
                calcu();
                //ComboCategory.Text = (dt1.Rows[0]["category"] + " - " + dt1.Rows[0]["category_arabic"]).ToString();
                string ca = dt1.Rows[0]["category"] != null && dt1.Rows[0]["category"].ToString() != "" ? dt1.Rows[0]["category"].ToString() : "0";
                int CatID = Convert.ToInt32(ca);
                string CatNAme = GetCat_Name(CatID);
                //CmbCategory.SelectedValue = CatID;
                lblCategory.Text = CatID.ToString();
                CmbCategory.Text = CatNAme;


                if (dt1.Rows[0]["supplier"] != null && dt1.Rows[0]["supplier"].ToString() != "")
                {
                    cmbSupplier.SelectedValue = dt1.Rows[0]["supplier"].ToString();
                }

                lblimagename.Text = dt1.Rows[0]["imagename"] != null && dt1.Rows[0]["imagename"].ToString() != "" ? dt1.Rows[0]["imagename"].ToString() : "item.png";

                txtCustItemCode.Text = dt1.Rows[0]["custitemCode"] != null && dt1.Rows[0]["custitemCode"].ToString() != "" ? dt1.Rows[0]["custitemCode"].ToString() : "";
                txtBarcode.Text = dt1.Rows[0]["Barcode"] != null && dt1.Rows[0]["Barcode"].ToString() != "" ? dt1.Rows[0]["Barcode"].ToString() : "";
                comboRecipeType.Text = dt1.Rows[0]["RecipeType"] != null && dt1.Rows[0]["RecipeType"].ToString() != "" ? dt1.Rows[0]["RecipeType"].ToString() : "";


                string path = Application.StartupPath + @"\ITEMIMAGE\" + lblimagename.Text + "";

                if (File.Exists(path))
                {
                    picItemimage.ImageLocation = path;
                    picItemimage.InitialImage.Dispose();
                    //picItemUOMimage.ImageLocation = path;
                    //picItemUOMimage.InitialImage.Dispose();
                }
                else
                {
                    picItemimage.ImageLocation = Application.StartupPath + @"\ITEMIMAGE\item.png";
                    picItemimage.InitialImage.Dispose();
                    //picItemUOMimage.ImageLocation = Application.StartupPath + @"\ITEMIMAGE\item.png";
                    //picItemUOMimage.InitialImage.Dispose();
                }


                //txtdiscount.Text = dt1.Rows[0]["Discount"] != null && dt1.Rows[0]["Discount"].ToString() != "" ? dt1.Rows[0]["Discount"].ToString() : "0";yogesh
                if (dt1.Rows[0]["Shopid"] != null && dt1.Rows[0]["Shopid"].ToString() != "")
                {
                    cmboShopid.SelectedValue = dt1.Rows[0]["Shopid"].ToString();
                }
                int Perishable = 0, Serialize = 0;
                if (dt1.Rows[0]["IsPerishable"] != null && dt1.Rows[0]["IsPerishable"].ToString() != "")
                {
                    Perishable = Convert.ToInt32(dt1.Rows[0]["IsPerishable"]);
                }
                if (dt1.Rows[0]["IsSerialize"] != null && dt1.Rows[0]["IsSerialize"].ToString() != "")
                {
                    Serialize = Convert.ToInt32(dt1.Rows[0]["IsSerialize"]);
                }
                checkPerishable.Checked = Perishable == 1 ? true : false;
                checkSerialize.Checked = Serialize == 1 ? true : false;





                if (dt1.Rows[0]["taxapply"] != null && dt1.Rows[0]["taxapply"].ToString() == "1")
                {
                    chktaxapply.Checked = true;
                }
                else
                {
                    chktaxapply.Checked = false;
                }

                if (dt1.Rows[0]["status"] != null && dt1.Rows[0]["status"].ToString() == "3")  // 3 = show kitchen display 
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

        bool FlagLoad;

        private void Add_Item_Load(object sender, EventArgs e)
        {
            try
            {
                FlagLoad = true;
                if (UserInfo.usertype == "1")
                {
                    lnkStocklist.Visible = true;
                }
                else
                {
                    lnkStocklist.Visible = false;
                }
                //Delete  tbl_item_uom_price where Deleted='N'

                string sql1 = "Delete from tbl_item_uom_price where Deleted='N' and TenentID= " + Tenent.TenentID + "";
                DataAccess.ExecuteSQL(sql1);

                string sqlUpdateCmdWIN = " delete from Win_tbl_item_uom_price  where Deleted='N' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "Win_tbl_item_uom_price", "DELETE");

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
                this.dgrvMultiUomList.Columns.Add("cPrc", "Cost Price");
                this.dgrvMultiUomList.Columns.Add("sPrc", "Sale Price");

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
                chMultiUOM.Checked = false;
                FlagLoad = false;
                this.grdSerial.Columns.Add("Serial", "Serial");
                this.grdSerial.Columns.Add("OnHand", "OnHand");
                grdSerial.Columns["Serial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSerial.Columns["Serial"].DefaultCellStyle.ForeColor = Color.Black;
                grdSerial.Columns["Serial"].DefaultCellStyle.BackColor = Color.Silver;
                grdSerial.Columns["Serial"].DefaultCellStyle.SelectionForeColor = Color.Black;
                grdSerial.Columns["Serial"].DefaultCellStyle.SelectionBackColor = Color.Silver;
                grdSerial.Columns["Serial"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

                grdSerial.Columns["Serial"].Width = 200;
                grdSerial.Columns["OnHand"].Width = 100;


                //Update data | If user id has
                if (lblItemcode.Text != "-")
                {
                    loadData();
                    txtProductCode.ReadOnly = true;
                    btnSave.Text = "Update";
                    lnkDelete.Visible = true;
                    checkSerialize.Enabled = true;
                    if (checkSerialize.Checked)
                    {
                        btnShowSerial.Visible = false;
                        grdSerial.Visible = true;
                        txtProductQty.Enabled = false;
                        string q = "select * from ICIT_BR_Serialize where tenentid=" + Tenent.TenentID + " and  MyProdID=" + txtProductCode.Text + "";
                        DataTable dt1 = DataAccess.GetDataTable(q);
                        if (dt1.Rows.Count >= 1)
                        {
                            string Serial = "";
                            int OnHand = 0;
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                Serial = dt1.Rows[i]["Serial_Number"].ToString().Trim();
                                OnHand = Convert.ToInt32(dt1.Rows[i]["OnHand"].ToString());
                                grdSerial.Rows.Add(Serial, OnHand);
                            }
                        }
                    }
                    else
                    {
                        btnShowSerial.Visible = false;
                        grdSerial.Visible = false;
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        public string selectSupplier
        {
            set
            {
                cmbSupplier.SelectedValue = value;
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

        public void ProductSave(string SaveMode) // Save , Update
        {
            string pid = txtProductCode.Text;
            string pname = txtProductName.Text;
            //double quan = Convert.ToDouble(txtProductQty.Text);
            //double cprice = Convert.ToDouble(txtCostPrice.Text);
            //double sprice = Convert.ToDouble(txtSalesPrice.Text);

            //double ctotalpri = quan * cprice;
            //double rtotalpri = quan * sprice;
            //double discount = txtdiscount.Text != "" ? Convert.ToDouble(txtdiscount.Text) : 0;

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
            if (SaveMode == "Save")
            {
                if (lblItemcode.Text == "-")
                {
                    string imageName = pid + lblFileExtension.Text;

                 

                    string product_name_print = txtproduct_name_print.Text;
                    string product_name_Arabic = txtNameArabic.Text;
                    //string catagory_Eng = ComboCategory.Text.Split('-')[0].Trim();  
                    string catagory_Eng = lblCategory.Text; // CmbCategory.SelectedValue.ToString();

                    //string category_arabic = getCatagory_Arabic(catagory_Eng);
                    string category_arabic = getCatagory_Arabic(CmbCategory.Text.Split('-')[0].Trim());

                    int IsPerishable = checkPerishable.Checked == true ? 1 : 0;
                    int IsSerialize = checkSerialize.Checked == true ? 1 : 0;//yogesh

                    string CustItemCode = txtCustItemCode.Text != "" ? txtCustItemCode.Text : pid;
                    string BarCode = txtBarcode.Text != "" ? txtBarcode.Text : pid;
                    string Base1 = lblUOM.Text.ToString();// drpUOM.SelectedValue.ToString();
                    int BaseUOM = Convert.ToInt32(Base1);

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string path = Application.StartupPath + @"\ITEMIMAGE\";

                    System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);
                    if (di.Exists)
                    {
                        path = UserInfo.Img_path;
                    }
                    System.IO.File.Delete(path + @"\" + imageName);
                    if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(path);
                    string filename = path + @"\" + imageName;
                    picItemimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                    System.IO.File.Move(path + @"\" + imageName, path + @"\" + imageName);

                    //string sqlWin_purchase = " insert into Win_purchase (TenentID, product_id, product_name,product_name_Arabic,product_name_print," +
                    //               " category,category_arabic, supplier , imagename, taxapply, Shopid , status,UOM,IsPerishable,Uploadby ,UploadDate ,SynID,CustItemCode,BarCode) " +
                    //               " values (" + Tenent.TenentID + ",'" + pid + "', '" + pname + "', N'" + product_name_Arabic + "', N'" + product_name_print + "'," +
                    //               " '" + catagory_Eng + "', N'" + category_arabic + "', '" + cmbSupplier.SelectedValue + "' , '" + imageName + "', " +
                    //               " '" + taxapply + "' , '" + cmboShopid.SelectedValue + "' , '" + kitchenDisplaythisitem + "' , '" + isuomupdate + "'," + IsPerishable + " , '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + BarCode + "' )";
                    //int InsertFlag = DataLive.ExecuteLiveSQL(sqlWin_purchase);

                    //if (InsertFlag == 1)
                    //{
                    string sql1 = " insert into purchase (TenentID, product_id, product_name,product_name_Arabic,product_name_print," +
                                  " category,category_arabic, supplier , imagename, taxapply, Shopid , status,UOM,IsPerishable,IsSerialize, " +
                                  " Uploadby ,UploadDate ,SynID,CustItemCode,BarCode,BaseUOM) " +
                                  " values (" + Tenent.TenentID + ",'" + pid + "', '" + pname + "','" + product_name_Arabic + "','" + product_name_print + "'," +
                                  " '" + catagory_Eng + "','" + category_arabic + "', '" + cmbSupplier.SelectedValue + "' , '" + imageName + "', " +
                                  " '" + taxapply + "' , '" + cmboShopid.SelectedValue + "' , '" + kitchenDisplaythisitem + "' , '" + isuomupdate + "'," + IsPerishable + " ," + IsSerialize + " , " +
                                  " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + BarCode + "', '" + BaseUOM + "' )";
                    int flag1 = DataAccess.ExecuteSQL(sql1);

                    string sqlWin_purchase = " insert into Win_purchase (TenentID, product_id, product_name,product_name_Arabic,product_name_print," +
                                   " category,category_arabic, supplier , imagename, taxapply, Shopid , status,UOM,IsPerishable,IsSerialize, " +
                                   " Uploadby ,UploadDate ,SynID,CustItemCode,BarCode,BaseUOM) " +
                                   " values (" + Tenent.TenentID + ",'" + pid + "', '" + pname + "', N'" + product_name_Arabic + "', N'" + product_name_print + "'," +
                                   " '" + catagory_Eng + "', N'" + category_arabic + "', '" + cmbSupplier.SelectedValue + "' , '" + imageName + "', " +
                                   " '" + taxapply + "' , '" + cmboShopid.SelectedValue + "' , '" + kitchenDisplaythisitem + "' , '" + isuomupdate + "'," + IsPerishable + " ," + IsSerialize + " , " +
                                   " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + BarCode + "', '" + BaseUOM + "')";
                    Datasyncpso.insert_Live_sync(sqlWin_purchase, "Win_purchase", "INSERT");

                    string ActivityName = "Add Product";
                    string LogData = "Add Product with product id = " + pid + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                    UpdateRecipeType(pid);

                    //lblItemcode.Text = pid;

                    //btnUomAdd_Click(sender, e);

                    /////////////////////////////////// add Item UOM Price /////////////////////////////////////////////////

                    //picture upload  /////////////////
                    //  if (openFileDialog1.FileName != string.Empty)
                    // {

                  
                    //   }

                    btnUomAdd.Enabled = true;
                    // ClearForm();
                    //}
                }
            }

            if (SaveMode == "Update") //Update
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
                string catagory_Eng = lblCategory.Text;// CmbCategory.SelectedValue.ToString();

                //string category_arabic = getCatagory_Arabic(catagory_Eng);
                string category_arabic = getCatagory_Arabic(CmbCategory.Text.Split('-')[0].Trim());

                int IsPerishable = checkPerishable.Checked == true ? 1 : 0;
                int IsSerialize = checkSerialize.Checked == true ? 1 : 0;


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
                        " Shopid = '" + cmboShopid.SelectedValue + "' , status =  '" + kitchenDisplaythisitem + "' , UOM =  '" + isuomupdate + "',IsPerishable = " + IsPerishable + ",IsSerialize = " + IsSerialize + ", " +
                        " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' , CustItemCode = '" + CustItemCode + "', BarCode = '" + BarCode + "', SynID = 2 " +
                        "  where product_id = '" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sql);

                string sqlwin = " update Win_purchase set product_name = '" + txtProductName.Text + "',product_name_print = N'" + product_name_print + "' ,product_name_Arabic = N'" + product_name_Arabic + "', " +
                            " category = '" + catagory_Eng + "',category_arabic = N'" + category_arabic + "', supplier = '" + cmbSupplier.SelectedValue + "',  " +
                            " imagename = '" + imageName + "' , taxapply = '" + taxapply + "' , " +
                            " Shopid = '" + cmboShopid.SelectedValue + "' , status =  '" + kitchenDisplaythisitem + "' , UOM =  '" + isuomupdate + "', IsPerishable = " + IsPerishable + ",IsSerialize = " + IsSerialize + ", " +
                            " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' , CustItemCode = '" + CustItemCode + "', BarCode = '" + BarCode + "', SynID = 2 " +
                            "  where product_id = '" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sqlwin, "Win_purchase", "UPDATE");

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
            }
        }

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

            bool Valid = CheckValidation();
            if (Valid == false)
            {
                return;
            }

            if (btnSave.Text == "Save")
            {
                string q = "select * from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + txtProductCode.Text + "  and UOM=" + lblUOM.Text + " and MYTRANSID=" + txtProductCode.Text + " ";
                DataTable dt1 = DataAccess.GetDataTable(q);
                if (checkSerialize.Checked)
                {
                    if (dt1.Rows.Count <= 0)
                    {

                        if (txtProductQty.Text != "0" && txtProductQty.Text != "")
                        {

                            MessageBox.Show(txtProductQty.Text + " Serial Must be Required.");
                            string UOMID = lblUOM.Text.ToString();// drpUOM.SelectedValue.ToString();
                            int UOMIC = Convert.ToInt32(UOMID);
                            //string uom = getuomName(UOMIC);
                            string MySysName = "PUR";
                            btnShowSerial.Visible = true;
                            Items.Serialize go = new Items.Serialize(txtProductCode.Text, UOMID, Convert.ToDouble(txtProductCode.Text), MySysName);//Constructor and nothing return
                            go.Qty = txtProductQty.Text;
                            go.Show();
                        }
                        return;
                    }
                }

                if (chMultiUOM.Checked == true)
                {
                    int Count = dgrvMultiUomList.RowCount;
                    if (Count == 0)
                    {
                        MessageBox.Show("Add Atleast One Uom");
                        return;
                    }
                }

                ProductSave("Save"); // Save , Update

                SaveSingleUOM();

                MessageBox.Show("Successfully Data Save!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            else
            {
                ProductSave("Update"); // Save , Update
                if (chMultiUOM.Checked == false)
                {
                    int BaseUOM = Convert.ToInt32(lblUOM.Text);
                    DeletesingleUOMItem(BaseUOM);
                }

                SaveSingleUOM();

                MessageBox.Show("Successfully Data Updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }

        public void DeletesingleUOMItem(int BaseUOM)
        {
            string sqlselect = "select * from tbl_item_uom_price where TenentID= " + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and UOMID='" + BaseUOM + "' ";
            DataTable DTSelect = DataAccess.GetDataTable(sqlselect);

            if (DTSelect.Rows.Count < 1)
            {
                DeleteProductUOM();
                ChangeBaseUOM(BaseUOM);
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
            Datasyncpso.insert_Live_sync(sql2win, "win_tbl_item_uom_price", "UPDATE");

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
               // lblimagename.Text = System.IO.Path.GetFileName(openFileDialog1.FileName); 
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
                        string sqlRecipeSelect = "select * from Receipe_Menegement  where TenentID = " + Tenent.TenentID + " and ItemCode = '" + lblItemcode.Text + "' ";
                        DataTable dtRecipe = DataAccess.GetDataTable(sqlRecipeSelect);

                        string sqlpurchaseSelect = "select * from tbl_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + lblItemcode.Text + "' ";
                        DataTable dtpur = DataAccess.GetDataTable(sqlpurchaseSelect);

                        string sqldpurchaseSelect = "select * from tbl_Draft_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + lblItemcode.Text + "' ";
                        DataTable dtdpur = DataAccess.GetDataTable(sqldpurchaseSelect);

                        string sqlSelect = "select * from sales_item  where TenentID = " + Tenent.TenentID + " and itemcode = '" + lblItemcode.Text + "' ";
                        DataTable dt = DataAccess.GetDataTable(sqlSelect);
                        if (dt.Rows.Count > 0)
                        {
                            int Count = dt.Rows.Count;
                            MessageBox.Show(" This Item Used in Sales Transaction " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        else if (dtpur.Rows.Count > 0)
                        {
                            int Count = dtpur.Rows.Count;
                            MessageBox.Show(" This Item Used in Purchase Transaction " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        else if (dtdpur.Rows.Count > 0)
                        {
                            int Count = dtdpur.Rows.Count;
                            MessageBox.Show(" This Item Used in Draft Purchase Transaction " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        else if (dtRecipe.Rows.Count > 0)
                        {
                            int Count = dtRecipe.Rows.Count;
                            MessageBox.Show(" This Item Used in Receipe Menegement  " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            return;
                        }
                        else
                        {
                            string sql = "delete from purchase where product_id ='" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + "";
                            DataAccess.ExecuteSQL(sql);

                            string sqlUpdateCmdWIN = " delete From Win_purchase  where product_id ='" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + " ";
                            Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "Win_purchase", "DELETE");

                            string sqlDelete = "Delete from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' ";
                            DataAccess.ExecuteSQL(sqlDelete);

                            string sqlLive = "Delete from Win_tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' ";
                            Datasyncpso.insert_Live_sync(sqlLive, "Win_tbl_item_uom_price", "DELETE");

                            string ActivityName = "Delete Product";
                            string LogData = "Delete Product with product id = " + lblItemcode.Text + " ";
                            Login.InsertUserLog(ActivityName, LogData);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Purchase history Qty

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
        private void txtTotalUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtTotalUnitPrice.Text.ToString(), @"\.\d\d\d");

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


        public string selectCatagory
        {
            set
            {
                CmbCategory.Text = value;
                lblCategory.Text = GetCATID(CmbCategory.Text).ToString();
            }
        }

        public void Bind_Catagory()
        {
            CmbCategory.DataSource = null;
            CmbCategory.Items.Clear();

            //Select CATID , CAT_NAME1 ||' - '|| CAT_NAME2 as 'Catagory' from CAT_MST where TenentID = 9000004
            //string sqlcate = "select CATID , CAT_NAME1 ||' - '|| CAT_NAME2 as 'Catagory' from CAT_MST where TenentID = " + Tenent.TenentID + " ";
            string sqlcate = "select CATID , CAT_NAME1 ||' - '|| CAT_NAME2 as 'Catagory' from CAT_MST where TenentID = " + Tenent.TenentID + " order By Catagory";
            DataTable dtcate = DataAccess.GetDataTable(sqlcate);

            CmbCategory.DataSource = dtcate;
            CmbCategory.ValueMember = "CATID";
            CmbCategory.DisplayMember = "Catagory";

        }

        public void bind_UOM()
        {
            drpUOM.DataSource = null;
            drpUOM.Items.Clear();

            string sqluom = "";

            if (chMultiUOM.Checked == true)
            {
                sqluom = " select UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM " +
                         " inner join ICUOMCONV on ICUOMCONV.TenentID = ICUOM.TenentID and ICUOMCONV.FUOM = ICUOM.UOM " +
                         " where ICUOM.TenentID= " + Tenent.TenentID + " Group by ICUOMCONV.FUOM ";
                //sqluom = "select  UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM where TenentID=" + Tenent.TenentID + " ";
            }
            else
            {
                sqluom = "select  UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM where TenentID=" + Tenent.TenentID + " and UOM not in (select Fuom from ICUOMCONV where TenentID = ICUOM.TenentID) ";
            }

            DataTable dtuom = DataAccess.GetDataTable(sqluom);

            drpUOM.DataSource = dtuom;
            drpUOM.ValueMember = "UOM";
            drpUOM.DisplayMember = "UOMNAME";


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
            string sql12 = " select UOMNAME1 from ICUOM where TenentID = " + Tenent.TenentID + " and UOM = '" + UOM + "'  ";
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
                Datasyncpso.insert_Live_sync(sqlWin, "DayClose", "UPDATE");

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
                double MyProdID = Convert.ToDouble(productid);
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
                    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Perishable", "INSERT");
                }
                else
                {
                    //int Onhandold = Convert.ToInt32(dtquery.Rows[0]["OnHand"]);
                    //int QtyReceivedold = Convert.ToInt32(dtquery.Rows[0]["QtyReceived"]);

                    //int OnHand = qty1 + Onhandold;
                    //int QtyReceived = qty1 + QtyReceivedold;

                    string sql1 = "Update ICIT_BR_Perishable set OnHand='" + 1 + "',QtyReceived='" + 1 + "', ProdDate='" + ProdDate1 + "' ,ExpiryDate='" + ExpiryDate1 + "' ,LeadDays2Destroy = '" + LeadDays2Destroy1 + "',  " +
                              " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                              " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and BatchNo='" + Batch_No + "'  ";
                    DataAccess.ExecuteSQL(sql1);
                    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Perishable", "UPDATE");
                }
                string dq = "delete from ICIT_BR_TMP where TenentID=" + Tenent.TenentID + " and MyProdID =" + productid + "  and UOM=" + uom + " and MYTRANSID=" + MY_TRANS_ID + " ";
                DataAccess.ExecuteSQL(dq);
            }

        }

        public static void add_Serialize(string productid, int uom, int MY_TRANS_ID)
        {
            //incoplate

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string q = "select * from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + productid + "  and UOM=" + uom + " and MYTRANSID=" + MY_TRANS_ID + " ";
            DataTable dt1 = DataAccess.GetDataTable(q);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    double MyProdID = Convert.ToDouble(productid);
                    string period_code = "201801";
                    string MySysName = "PUR";
                    int LocationID = 0;
                    int MYTRANSID = MY_TRANS_ID;
                    string Serial_Number = dt1.Rows[i]["Serial_Number"].ToString();


                    int qty1 = Convert.ToInt32(dt1.Rows[i]["NewQty"]);


                    string query = "select * from ICIT_BR_Serialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "' ";
                    DataTable dtquery = DataAccess.GetDataTable(query);
                    if (dtquery.Rows.Count < 1)
                    {
                        int Onhandold = 0;
                        int QtyReceivedold = 0;

                        int OnHand = qty1 + Onhandold;
                        int QtyReceived = qty1 + QtyReceivedold;

                        string sql1 = "insert into ICIT_BR_Serialize (TenentID, MyProdID,period_code,MySysName,UOM,Serial_Number,LocationID,MYTRANSID, " +
                                      " OnHand,QtyReceived,Active, Uploadby ,UploadDate ,SynID)" +
                                      " values (" + Tenent.TenentID + "," + MyProdID + " ,'" + period_code + "' ,'" + MySysName + "' , " + uom + ", " +
                                      " '" + Serial_Number + "','" + LocationID + "','" + MYTRANSID + "', " + OnHand + "," + QtyReceived + ", 'Y' , " +
                                      " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                        DataAccess.ExecuteSQL(sql1);
                        Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Serialize", "INSERT");
                    }
                    else
                    {
                        int Onhandold = Convert.ToInt32(dtquery.Rows[i]["OnHand"]);
                        int QtyReceivedold = Convert.ToInt32(dtquery.Rows[i]["QtyReceived"]);

                        //int OnHand = qty1 + Onhandold;
                        //int QtyReceived = qty1 + QtyReceivedold;

                        string sql1 = "Update ICIT_BR_Serialize set  " +
                                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "'  ";
                        DataAccess.ExecuteSQL(sql1);
                        Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Serialize", "UPDATE");
                    }

                }
                string dq = "delete from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + productid + "  and UOM=" + uom + " and MYTRANSID=" + MY_TRANS_ID + " ";
                DataAccess.ExecuteSQL(dq);
            }


        }
        public void add_perisable_Opening(string productid, int uom, double MY_TRANS_ID)
        {


            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string q = "select * from ICIT_BR_TMP where TenentID=" + Tenent.TenentID + " and MyProdID =" + productid + "  and UOM=" + uom + " and MYTRANSID=" + MY_TRANS_ID + " ";
            DataTable dt1 = DataAccess.GetDataTable(q);
            if (dt1.Rows.Count > 0)
            {
                double MyProdID = Convert.ToDouble(productid);
                string period_code = "201801";
                string MySysName = "PUR";
                int LocationID = 0;

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
                                  " '" + Batch_No + "','" + LocationID + "','" + MY_TRANS_ID + "', " + OnHand + "," + QtyReceived + ", '" + ProdDate1 + "','" + ExpiryDate1 + "' , '" + LeadDays2Destroy1 + "' , 'Y' , " +
                                  " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                    DataAccess.ExecuteSQL(sql1);
                    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Perishable", "INSERT");
                }
                else
                {


                    //int OnHand = qty1;
                    //int QtyReceived = qty1;

                    string sql1 = "Update ICIT_BR_Perishable set ProdDate='" + ProdDate1 + "' ,ExpiryDate='" + ExpiryDate1 + "' ,LeadDays2Destroy = '" + LeadDays2Destroy1 + "',  " +
                              " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                              " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and BatchNo='" + Batch_No + "'  ";
                    DataAccess.ExecuteSQL(sql1);
                    Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Perishable", "UPDATE");
                }
                string dq = "delete from ICIT_BR_TMP where TenentID=" + Tenent.TenentID + " and MyProdID =" + productid + "  and UOM=" + uom + " and MYTRANSID=" + MY_TRANS_ID + " ";
                DataAccess.ExecuteSQL(dq);
            }

        }
        public void add_Serialize_Opening(string productid, int uom, double MY_TRANS_ID)
        {


            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string q = "select * from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + productid + "  and UOM=" + uom + " and MYTRANSID=" + MY_TRANS_ID + " ";
            DataTable dt1 = DataAccess.GetDataTable(q);

            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {



                    double MyProdID = Convert.ToDouble(productid);
                    string period_code = "201801";
                    string MySysName = "PUR";
                    int LocationID = 0;

                    string Serial_Number = dt1.Rows[i]["Serial_Number"].ToString();
                    int qty1 = Convert.ToInt32(dt1.Rows[i]["NewQty"]);
                    //string ProdDate1 = dt1.Rows[0]["ProdDate"].ToString();
                    //string ExpiryDate1 = dt1.Rows[0]["ExpiryDate"].ToString();
                    //string LeadDays2Destroy1 = dt1.Rows[0]["LeadDays2Destroy"].ToString();

                    string query = "select * from ICIT_BR_Serialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "' ";
                    DataTable dtquery = DataAccess.GetDataTable(query);
                    if (dtquery.Rows.Count < 1)
                    {
                        int Onhandold = 0;
                        int QtyReceivedold = 0;

                        int OnHand = qty1 + Onhandold;
                        int QtyReceived = qty1 + QtyReceivedold;

                        string sql1 = "insert into ICIT_BR_Serialize (TenentID, MyProdID,period_code,MySysName,UOM,Serial_Number,LocationID,MYTRANSID, " +
                                      " OnHand,OpQty,Active, Uploadby ,UploadDate ,SynID)" +
                                      " values (" + Tenent.TenentID + "," + MyProdID + " ,'" + period_code + "' ,'" + MySysName + "' , " + uom + ", " +
                                      " '" + Serial_Number + "','" + LocationID + "','" + MY_TRANS_ID + "', " + OnHand + "," + QtyReceived + ", 'Y' , " +
                                      " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                        DataAccess.ExecuteSQL(sql1);
                        Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Serialize", "INSERT");
                    }
                    else
                    {


                        //int OnHand = qty1;
                        //int QtyReceived = qty1;

                        string sql1 = "Update ICIT_BR_Serialize set " +
                                  " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                  " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and Serial_Number='" + Serial_Number + "'  ";
                        DataAccess.ExecuteSQL(sql1);
                        Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_Serialize", "UPDATE");
                    }
                }
                string dq = "delete from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + productid + "  and UOM=" + uom + " and MYTRANSID=" + MY_TRANS_ID + " ";
                DataAccess.ExecuteSQL(dq);
            }


        }
        #endregion

        private void chMultiUOM_CheckedChanged(object sender, EventArgs e)
        {
            if (Application.OpenForms["UOMSearch"] != null)
            {
                Application.OpenForms["UOMSearch"].Close();
            }
            this.Refresh();

            int BaseUOM = 0;

            if (chMultiUOM.Checked)
            {
                bind_UOM();

                btnUomAdd.Visible = true;
                dgrvMultiUomList.Visible = true;

                if (lblItemcode.Text != "-")
                {
                    double PID = Convert.ToDouble(lblItemcode.Text);

                    string sql2 = "select UOMID,UOMNAME1,OnHand,msrp,price from tbl_item_uom_price iup inner join ICUOM IC on IC.UOM = iup.UOMID and IC.TenentID = iup.TenentID " +
                                            " where iup.TenentID = " + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y'";

                    DataTable dtterminallist = DataAccess.GetDataTable(sql2);

                    int rows = dtterminallist.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        if (BaseUOM == 0)
                        {
                            BaseUOM = Convert.ToInt32(dtterminallist.Rows[i]["UOMID"]);
                        }

                    }

                    if (BaseUOM != 0)
                    {
                        bool flagallow = false;

                        string sqlRecipeSelect = "select * from Receipe_Menegement  where TenentID = " + Tenent.TenentID + " and ItemCode = '" + PID + "' and UOM = '" + BaseUOM + "' ";
                        DataTable dtRecipe = DataAccess.GetDataTable(sqlRecipeSelect);

                        string sqlpurchaseSelect = "select * from tbl_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + PID + "' and UOM = '" + BaseUOM + "' ";
                        DataTable dtpur = DataAccess.GetDataTable(sqlpurchaseSelect);

                        string sqldpurchaseSelect = "select * from tbl_Draft_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + PID + "' and UOM = '" + BaseUOM + "' ";
                        DataTable dtdpur = DataAccess.GetDataTable(sqldpurchaseSelect);

                        string sqlSelect = "select * from sales_item  where TenentID = " + Tenent.TenentID + " and itemcode = '" + PID + "' and UOM = '" + BaseUOM + "' ";
                        DataTable dt = DataAccess.GetDataTable(sqlSelect);
                        if (dt.Rows.Count > 0)
                        {
                            flagallow = false;
                        }
                        else if (dtpur.Rows.Count > 0)
                        {
                            flagallow = false;
                        }
                        else if (dtdpur.Rows.Count > 0)
                        {
                            flagallow = false;
                        }
                        else if (dtRecipe.Rows.Count > 0)
                        {
                            flagallow = false;
                        }
                        else
                        {
                            flagallow = true;
                        }

                        if (flagallow == true)
                        {
                            AddUOMItem();
                        }
                        else
                        {
                            string uomname1 = getuomName(BaseUOM);
                            EditUOM(uomname1);
                        }
                    }
                }
            }
            else
            {
                bind_UOM();

                string sql2 = "select * from purchase where TenentID = " + Tenent.TenentID + " and Product_ID = '" + lblItemcode.Text + "' ";

                DataTable dtterminallist = DataAccess.GetDataTable(sql2);
                if (dtterminallist.Rows.Count > 0)
                {
                    BaseUOM = Convert.ToInt32(dtterminallist.Rows[0]["BaseUOM"]);
                }

                if (BaseUOM != 0)
                {
                    bool flagallow = false;

                    string uomname1 = getuomName(BaseUOM);
                    EditUOM(uomname1);

                }

                btnUomAdd.Visible = false;
                dgrvMultiUomList.Visible = false;
            }
        }
        private void dgrvMultiUomList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Delete items From Gridview
                if (e.ColumnIndex == dgrvMultiUomList.Columns["del"].Index && e.RowIndex >= 0)
                {
                    string sql = "select * from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "'";
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
                            double OnhandQty = Convert.ToDouble(row2.Cells[1].Value);

                            //string sql2 = " select product_id,UOMID,OpQty from purchase " +
                            //              " inner join tbl_item_uom_price on purchase.TenentID = tbl_item_uom_price.TenentID and purchase.product_id = tbl_item_uom_price.itemID " +
                            //              " where purchase.Tenentid= " + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and tbl_item_uom_price.UOMID != purchase.BaseUOM and UOMID = '" + UOM + "' ";

                            //DataTable dtterminallist = DataAccess.GetDataTable(sql2);

                            //int rows = dtterminallist.Rows.Count;
                            //if (rows > 0)
                            //{

                            string sqlRecipeSelect = "select * from Receipe_Menegement  where TenentID = " + Tenent.TenentID + " and ItemCode = '" + lblItemcode.Text + "' and UOM = '" + UOM + "' ";
                            DataTable dtRecipe = DataAccess.GetDataTable(sqlRecipeSelect);

                            string sqlpurchaseSelect = "select * from tbl_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + lblItemcode.Text + "' and UOM = '" + UOM + "' ";
                            DataTable dtpur = DataAccess.GetDataTable(sqlpurchaseSelect);

                            string sqldpurchaseSelect = "select * from tbl_Draft_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + lblItemcode.Text + "' and UOM = '" + UOM + "' ";
                            DataTable dtdpur = DataAccess.GetDataTable(sqldpurchaseSelect);

                            string sqlSelect = "select * from sales_item  where TenentID = " + Tenent.TenentID + " and itemcode = '" + lblItemcode.Text + "' and UOM = '" + UOM + "' ";
                            DataTable dt = DataAccess.GetDataTable(sqlSelect);
                            if (dt.Rows.Count > 0)
                            {
                                int Count = dt.Rows.Count;
                                MessageBox.Show(" This Item Used in Sales Transaction " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                return;
                            }
                            else if (dtpur.Rows.Count > 0)
                            {
                                int Count = dtpur.Rows.Count;
                                MessageBox.Show(" This Item Used in Purchase Transaction " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                return;
                            }
                            else if (dtdpur.Rows.Count > 0)
                            {
                                int Count = dtdpur.Rows.Count;
                                MessageBox.Show(" This Item Used in Draft Purchase Transaction " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                return;
                            }
                            else if (dtRecipe.Rows.Count > 0)
                            {
                                int Count = dtRecipe.Rows.Count;
                                MessageBox.Show(" This Item Used in Receipe Menegement  " + Count + " Times therefore we can not Delete ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                return;
                            }
                            else
                            {

                                //double opaningQty = Convert.ToDouble(dtlist.Rows[0]["OpQty"].ToString());

                                //if (OnhandQty == opaningQty)
                                //{
                                if (!row2.IsNewRow)
                                    dgrvMultiUomList.Rows.Remove(row2);

                                string sqlDelete = "Delete from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";
                                DataAccess.ExecuteSQL(sqlDelete);

                                string sqlLive = "Delete from Win_tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";
                                Datasyncpso.insert_Live_sync(sqlLive, "Win_tbl_item_uom_price", "DELETE");
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Aready Use this UOM so you can't delete ....");
                                //}
                            }

                            //}
                            //else
                            //{
                            //    MessageBox.Show("This UOM Is Base so you can't delete ....");
                            //}
                        }
                    }
                }
                // Edit items From Gridview
                else if (e.ColumnIndex == dgrvMultiUomList.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgrvMultiUomList.SelectedRows)
                    {
                        string uomname = row.Cells[0].Value.ToString().Trim();
                        EditUOM(uomname);
                        drpUOM.Enabled = false;
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgrvMultiUomList.SelectedRows)
                    {
                        string uomname = row.Cells[0].Value.ToString().Trim();
                        int UOM = getuomID(uomname);
                        // string sql2 = "select Image,OpQty,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,RecipeType,recNo,msrp,price,OnHand,UOMID from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";yogesh
                        string sql2 = "select Image,OpQty,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,RecipeType,recNo,msrp,price,OnHand,UOMID from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";
                        DataTable dtterminallist = DataAccess.GetDataTable(sql2);
                        int rows = dtterminallist.Rows.Count;
                        if (rows == 1)
                        {
                            string uom = Get_uom_EnglisArabic(uomname);

                            lblOpeniongQty.Text = dtterminallist.Rows[0]["OpQty"].ToString();
                            lblOnhandqty.Text = dtterminallist.Rows[0]["OnHand"].ToString();
                            lblSaleQty.Text = dtterminallist.Rows[0]["QtyOut"].ToString();
                            lblPurchaseQty.Text = dtterminallist.Rows[0]["QtyRecived"].ToString();
                            lblConsumedQty.Text = dtterminallist.Rows[0]["QtyConsumed"].ToString();
                            lblReservedQty.Text = dtterminallist.Rows[0]["QtyReserved"].ToString();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string selectUOM
        {
            set
            {
                string uomname = value;
                selectuom(uomname);
            }
        }

        public void selectuom(string uomname)
        {
            int UOM = getuomID(uomname);
            lblUOM.Text = UOM.ToString();
            drpUOM.Text = uomname;
            drpUOM.SelectedValue = UOM;
        }

        public void EditUOM(string uomname)
        {
            int UOM = getuomID(uomname);
            lblUOM.Text = UOM.ToString();
            drpUOM.Text = uomname;

            if (lblItemcode.Text == "-")
            {
                lblItemcode.Text = txtProductCode.Text;
            }

            //string sql2 = "select Image,OpQty,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,RecipeType,recNo,msrp,price,OnHand,UOMID from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";
            string sql2 = "select Image,OpQty,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,RecipeType,recNo,msrp,price,OnHand,UOMID from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOM + "'";
            DataTable dtterminallist = DataAccess.GetDataTable(sql2);
            int rows = dtterminallist.Rows.Count;
            if (rows > 0)
            {
                string PID = lblItemcode.Text;
                string uom = Get_uom_EnglisArabic(uomname);
                //drpUOM.SelectedValue = dtterminallist.Rows[0]["UOMID"].ToString();
                txtProductQty.Text = dtterminallist.Rows[0]["OpQty"].ToString();
                txtCostPrice.Text = dtterminallist.Rows[0]["price"].ToString();
                txtSalesPrice.Text = dtterminallist.Rows[0]["msrp"].ToString();

                lblOpeniongQty.Text = dtterminallist.Rows[0]["OpQty"].ToString();
                lblOnhandqty.Text = dtterminallist.Rows[0]["OnHand"].ToString();
                //yogesh  txtdiscount.Text = dtterminallist.Rows[0]["Discount"].ToString() != "" && dtterminallist.Rows[0]["Discount"].ToString() != null ? dtterminallist.Rows[0]["Discount"].ToString() : "0";
                txtMaxQty.Text = dtterminallist.Rows[0]["MaxQty"].ToString();
                txtMinQty.Text = dtterminallist.Rows[0]["minQty"].ToString();
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
                calcu();


                bool Allow_OpQty = EditAllow_OpQty(PID);
                if (Allow_OpQty == true)
                {
                    drpUOM.Enabled = true;
                    txtProductQty.Enabled = true;
                }
                else
                {
                    drpUOM.Enabled = false;
                    txtProductQty.Enabled = false;
                }

                btnUomAdd.Text = "Update";
            }
            //else
            //{
            //    MessageBox.Show("Multiple Records Exit , Please contact to Admistrator.");
            //}
        }

        public bool EditAllow_OpQty(string PID)
        {
            string sqlRecipeSelect = "select * from Receipe_Menegement  where TenentID = " + Tenent.TenentID + " and ItemCode = '" + PID + "' ";
            DataTable dtRecipe = DataAccess.GetDataTable(sqlRecipeSelect);

            string sqlpurchaseSelect = "select * from tbl_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + PID + "' ";
            DataTable dtpur = DataAccess.GetDataTable(sqlpurchaseSelect);

            string sqldpurchaseSelect = "select * from tbl_Draft_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + PID + "'  ";
            DataTable dtdpur = DataAccess.GetDataTable(sqldpurchaseSelect);

            string sqlSelect = "select * from sales_item  where TenentID = " + Tenent.TenentID + " and itemcode = '" + PID + "' ";
            DataTable dt = DataAccess.GetDataTable(sqlSelect);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else if (dtpur.Rows.Count > 0)
            {
                return false;
            }
            else if (dtdpur.Rows.Count > 0)
            {
                return false;
            }
            else if (dtRecipe.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void GetTransetionCount(string PID)
        {
            int SalesTransation = 0;
            int PurchaseTransation = 0;
            int ReceipeTrans = 0;

            string sqlRecipeSelect = "select * from Receipe_Menegement  where TenentID = " + Tenent.TenentID + " and ItemCode = '" + PID + "' ";
            DataTable dtRecipe = DataAccess.GetDataTable(sqlRecipeSelect);
            if (dtRecipe.Rows.Count > 0)
            {
                ReceipeTrans = dtRecipe.Rows.Count;
            }

            string sqlpurchaseSelect = "select * from tbl_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + PID + "' ";
            DataTable dtpur = DataAccess.GetDataTable(sqlpurchaseSelect);
            if (dtpur.Rows.Count > 0)
            {
                PurchaseTransation += dtpur.Rows.Count;
            }

            string sqldpurchaseSelect = "select * from tbl_Draft_purchase_history  where TenentID = " + Tenent.TenentID + " and product_id = '" + PID + "'  ";
            DataTable dtdpur = DataAccess.GetDataTable(sqldpurchaseSelect);
            if (dtdpur.Rows.Count > 0)
            {
                PurchaseTransation += dtdpur.Rows.Count;
            }

            string sqlSelect = "select * from sales_item  where TenentID = " + Tenent.TenentID + " and itemcode = '" + PID + "' ";
            DataTable dt = DataAccess.GetDataTable(sqlSelect);
            if (dt.Rows.Count > 0)
            {
                SalesTransation = dt.Rows.Count;
            }

            lblSalesTransection.Text = SalesTransation.ToString();
            lblPurchaseTransection.Text = PurchaseTransation.ToString();
            lblReceipeTransation.Text = ReceipeTrans.ToString();

        }

        public void calcu()
        {
            try
            {
                if (txtProductQty.Text != "0")
                {
                    decimal Qty = Convert.ToDecimal(txtProductQty.Text);
                    decimal UnitPrice = Convert.ToDecimal(txtCostPrice.Text);
                    decimal Total = UnitPrice * Qty;
                    txtTotalUnitPrice.Text = Total.ToString();
                }
                else
                {
                    txtTotalUnitPrice.Text = txtCostPrice.Text;
                }
            }
            catch
            {

            }
        }

        public static string voidQueryValidate(string str)
        {
            return str.Replace("-", "_").Replace("'", "").Replace("\"", "").Replace("~", "");
        }
        public bool CheckValidation()
        {
            txtProductName.Text = voidQueryValidate(txtProductName.Text);
            txtNameArabic.Text = voidQueryValidate(txtNameArabic.Text);
            txtproduct_name_print.Text = voidQueryValidate(txtproduct_name_print.Text);
            txtBarcode.Text = voidQueryValidate(txtBarcode.Text);
            txtCustItemCode.Text = voidQueryValidate(txtCustItemCode.Text);

            if (btnSave.Text == "Save")
            {
                if (txtProductCode.Text == "")
                {
                    MessageBox.Show("Please Insert Product Code/ Item Bar-code");
                    txtProductCode.Focus();
                    return false;
                }
                else if (txtProductName.Text == "")
                {
                    MessageBox.Show("Please Insert  Product Name");
                    txtProductName.Focus();
                    return false;
                }
                //else if (txtdiscount.Text == "")//yogesh
                //{
                //    txtdiscount.Text = "0";
                //    txtdiscount.Focus();
                //    return false;
                //}
                else if (txtProductQty.Text == "")
                {
                    MessageBox.Show("Please Insert Product Quantity");
                    txtProductQty.Focus();
                    return false;
                }
                else if (txtCostPrice.Text == "")
                {
                    MessageBox.Show("Please Insert Product Cost Price / Buy price ");
                    txtCostPrice.Focus();
                    return false;
                }

                else if (txtSalesPrice.Text == "")
                {
                    MessageBox.Show("Please Insert Product  Sales Price");
                    txtSalesPrice.Focus();
                    return false;
                }
                else if (CmbCategory.Text == "")
                {
                    MessageBox.Show("Please Insert Product Category");
                    CmbCategory.Focus();
                    return false;
                }
                else if (cmboShopid.Text == "")
                {
                    MessageBox.Show("Please Select Branch name ");
                    cmboShopid.Focus();
                    return false;
                }
                else if (cmbSupplier.Text == "")
                {
                    MessageBox.Show("Please Select Supplier Name");
                    cmbSupplier.Focus();
                    return false;
                }

                else
                {
                    return true;
                }
            }
            else
            {
                if (txtProductCode.Text == "")
                {
                    MessageBox.Show("Please Insert Product Code/ Item Bar-code");
                    txtProductCode.Focus();
                    return false;
                }
                else if (txtProductName.Text == "")
                {
                    MessageBox.Show("Please Insert  Product Name");
                    txtProductName.Focus();
                    return false;
                }
                else if (CmbCategory.Text == "")
                {
                    MessageBox.Show("Please Insert Product Category");
                    CmbCategory.Focus();
                    return false;
                }
                else if (cmboShopid.Text == "")
                {
                    MessageBox.Show("Please Select Branch name ");
                    cmboShopid.Focus();
                    return false;
                }
                else if (cmbSupplier.Text == "")
                {
                    MessageBox.Show("Please Select Supplier Name");
                    cmbSupplier.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }





        }

        public static bool Check_CalculateAspectRatio_allow(int BaseUOM)
        {
            bool CalculateAspectRatio = false;
            string Sql = "Select CalculateAspectRatio from ICUOM where TenentID = " + Tenent.TenentID + " and UOM = " + BaseUOM + " ";
            DataTable Dt = DataAccess.GetDataTable(Sql);
            if (Dt.Rows.Count > 0)
            {
                int CK = Dt.Rows[0]["CalculateAspectRatio"].ToString() != null && Dt.Rows[0]["CalculateAspectRatio"].ToString() != "" ? Convert.ToInt32(Dt.Rows[0]["CalculateAspectRatio"].ToString()) : 0;
                CalculateAspectRatio = CK == 1 ? true : false;
            }
            return CalculateAspectRatio;
        }

        public string getItemUOMWithIcconversion(int BaseUom)
        {
            bool LoopFlag = true;
            string UOMAll = BaseUom.ToString();

            string Sql = "select * from IcuomConv where TenentID = " + Tenent.TenentID + " and FUOM = " + BaseUom + " ";
            DataTable Dt = DataAccess.GetDataTable(Sql);
            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    int ToUOM = Convert.ToInt32(Dt.Rows[i]["TUOM"]);
                    UOMAll = UOMAll + "," + ToUOM;
                }
            }

            UOMAll = UOMAll.Trim();
            UOMAll = UOMAll.TrimStart(',');
            UOMAll = UOMAll.TrimEnd(',');

            return UOMAll;
        }

        public decimal getQtyUsingConv(decimal Qty, int BaseUOM, int ToUOM)
        {
            try
            {
                decimal Conv = 0;

                string Sql = "select * from IcuomConv where TenentID = " + Tenent.TenentID + " and FUOM = " + BaseUOM + " and TUOM = " + ToUOM + " ";
                DataTable Dt1 = DataAccess.GetDataTable(Sql);
                if (Dt1.Rows.Count > 0)
                {
                    Conv = Convert.ToDecimal(Dt1.Rows[0]["CONVERSION"]);
                    Qty = Qty * Conv;
                    Qty = Math.Round(Qty, 3);
                    return Qty;
                }
                return Qty;
            }
            catch
            {
                return 0;
            }
        }

        public decimal getPriceUsingConv(decimal Price, int BaseUOM, int ToUOM)
        {
            try
            {
                decimal Conv = 0;

                string Sql = "select * from IcuomConv where TenentID = " + Tenent.TenentID + " and FUOM = " + BaseUOM + " and TUOM = " + ToUOM + " ";
                DataTable Dt1 = DataAccess.GetDataTable(Sql);
                if (Dt1.Rows.Count > 0)
                {
                    Conv = Convert.ToDecimal(Dt1.Rows[0]["CONVERSION"]);
                    Price = Price / Conv;
                    Price = Math.Round(Price, 3);
                    return Price;
                }
                return Price;
            }
            catch
            {
                return 0;
            }
        }

        public void DeleteProductUOM()
        {
            string Sql = " select * from tbl_item_uom_price where TenentID=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "'  ";
            DataTable dt = DataAccess.GetDataTable(Sql);

            if (dt.Rows.Count > 0)
            {
                string sqlDelete = "Delete from tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' ";
                DataAccess.ExecuteSQL(sqlDelete);

                string sqlLive = "Delete from Win_tbl_item_uom_price where Tenentid=" + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' ";
                Datasyncpso.insert_Live_sync(sqlLive, "Win_tbl_item_uom_price", "DELETE");

                dgrvMultiUomList.Rows.Clear();
            }
        }

        public void ChangeBaseUOM(int BaseUOM)
        {
            string Sql = " select * from purchase where TenentID=" + Tenent.TenentID + " and product_id = '" + lblItemcode.Text + "'  ";
            DataTable dt = DataAccess.GetDataTable(Sql);

            if (dt.Rows.Count > 0)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string sql = " update purchase set BaseUOM = " + BaseUOM + ", " +
                            " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "', SynID = 2 " +
                            "  where product_id = '" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sql);

                string sqlwin = " update Win_purchase set BaseUOM = " + BaseUOM + ", " +
                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' , SynID = 2 " +
                                "  where product_id = '" + lblItemcode.Text + "' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sqlwin, "Win_purchase", "UPDATE");
            }
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
                bool Valid = CheckValidation();
                if (Valid == false)
                {
                    return;
                }

                if (btnSave.Text != "Update")
                {
                    ProductSave("Save"); // Save , Update 
                    btnSave.Text = "Update";
                    if (checkSerialize.Checked)
                    {
                        btnShowSerial.Visible = false;
                        grdSerial.Visible = true;
                        txtProductQty.Enabled = false;
                        string q = "select * from ICIT_BR_Serialize where tenentid=" + Tenent.TenentID + " and  MyProdID=" + txtProductCode.Text + "";
                        DataTable dt1 = DataAccess.GetDataTable(q);
                        if (dt1.Rows.Count >= 1)
                        {
                            string Serial = "";
                            int OnHand = 0;
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                Serial = dt1.Rows[i]["Serial_Number"].ToString().Trim();
                                OnHand = Convert.ToInt32(dt1.Rows[i]["OnHand"].ToString());
                                grdSerial.Rows.Add(Serial, OnHand);
                            }
                        }
                    }
                    else
                    {
                        btnShowSerial.Visible = false;
                        grdSerial.Visible = false;
                    }
                }

                string UOMID1 = lblUOM.Text.ToString(); // drpUOM.SelectedValue.ToString();
                int UOMIC1 = Convert.ToInt32(UOMID1);
                string uomname1 = getuomName(UOMIC1);

                if (btnUomAdd.Text == "Add")
                {
                    DeleteProductUOM();

                    ChangeBaseUOM(UOMIC1);

                    bool ChkAspectRasio = Check_CalculateAspectRatio_allow(UOMIC1);
                    string AllUOMConv = getItemUOMWithIcconversion(UOMIC1);
                    string[] ListUOM = AllUOMConv.Split(',');

                    for (int j = 0; j < ListUOM.Length; j++)
                    {
                        string UOMID = ListUOM[j].ToString();
                        int UOMIC = Convert.ToInt32(ListUOM[j]);
                        string uomname = getuomName(UOMIC);
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

                        string ProductQty = txtProductQty.Text;
                        string CostPrice = txtCostPrice.Text;
                        string SalesPrice = txtSalesPrice.Text;

                        if (UOMID != UOMID1)
                        {
                            decimal TxQty = Convert.ToDecimal(txtProductQty.Text);
                            decimal TxCoPrice = Convert.ToDecimal(txtCostPrice.Text);
                            decimal Txsaprice = Convert.ToDecimal(txtSalesPrice.Text);

                            decimal Qty = getQtyUsingConv(TxQty, UOMIC1, UOMIC);
                            decimal CoPrice = getPriceUsingConv(TxCoPrice, UOMIC1, UOMIC);
                            decimal saprice = getPriceUsingConv(Txsaprice, UOMIC1, UOMIC);
                            if (ChkAspectRasio == true)
                            {
                                ProductQty = Qty.ToString();
                                CostPrice = CoPrice.ToString();
                                SalesPrice = saprice.ToString();
                            }
                            else
                            {
                                ProductQty = "0";
                                CostPrice = CoPrice.ToString();
                                SalesPrice = saprice.ToString();
                            }

                        }


                        int rows = dgrvMultiUomList.Rows.Count;

                        if (rows > 0)
                        {
                            if (drpUOM.SelectedItem != null && CostPrice != "" && txtProductCode.Text != "" && SalesPrice != "" && ProductQty != "")
                            {
                                for (int i = 0; i < rows; i++)
                                {
                                    string grduomname = dgrvMultiUomList.Rows[i].Cells[0].Value.ToString();

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

                                dgrvMultiUomList.Rows.Add(uomname, ProductQty, CostPrice, SalesPrice);


                                int quan = Convert.ToInt32(ProductQty);

                                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                string Discount = txtdiscount.Text != "" ? txtdiscount.Text : "0";

                                int ID12 = DataAccess.getuom_priceMYid(Tenent.TenentID, txtProductCode.Text, UOMIC);

                                //string sql1win = " insert into Win_tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved, " +
                                //              " QtyRecived,msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                //              " values (" + Tenent.TenentID + "," + ID12 + ",'" + txtProductCode.Text + "', '" + UOMID + "', '" + ProductQty + "', " +
                                //              " '" + ProductQty + "',0,0,0,0, '" + SalesPrice + "', '" + CostPrice + "','Y'," +
                                //              " '" + txtMinQty.Text + "', '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                //              " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                                //int insertFalg = DataLive.ExecuteLiveSQL(sql1win);

                                //if (insertFalg == 1)
                                //{
                                string sql1 = " insert into tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved, " +
                                          " QtyRecived,msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                          " values (" + Tenent.TenentID + ", " + ID12 + ",'" + txtProductCode.Text + "', '" + UOMID + "', '" + ProductQty + "', " +
                                          " '" + ProductQty + "',0,0,0,0, '" + SalesPrice + "', '" + CostPrice + "','Y'," +
                                          " '" + txtMinQty.Text + "', '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                          " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                                DataAccess.ExecuteSQL(sql1);

                                string sql1win = " insert into Win_tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved, " +
                                              " QtyRecived,msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                              " values (" + Tenent.TenentID + "," + ID12 + ",'" + txtProductCode.Text + "', '" + UOMID + "', '" + ProductQty + "', " +
                                              " '" + ProductQty + "',0,0,0,0, '" + SalesPrice + "', '" + CostPrice + "','Y'," +
                                              " '" + txtMinQty.Text + "', '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                              " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                                Datasyncpso.insert_Live_sync(sql1win, "Win_tbl_item_uom_price", "INSERT");

                                string ActivityName = "Add Product With UOM";
                                string LogData = "Add Product With UOM product id = " + txtProductCode.Text + " UOM " + uomname + " ";
                                Login.InsertUserLog(ActivityName, LogData);

                                //Add to purchase history - New item history

                                decimal cost = Convert.ToDecimal(CostPrice);
                                decimal Msrp = Convert.ToDecimal(SalesPrice);

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
                            dgrvMultiUomList.Rows.Add(uomname, ProductQty, CostPrice, SalesPrice);

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

                            int quan = Convert.ToInt32(ProductQty);

                            string Discount = txtdiscount.Text != "" ? txtdiscount.Text : "0";
                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            int ID12 = DataAccess.getuom_priceMYid(Tenent.TenentID, txtProductCode.Text, UOMIC);

                            //string sql1Win = " insert into Win_tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                            //                " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                            //                " values (" + Tenent.TenentID + "," + ID12 + " , '" + txtProductCode.Text + "', '" + UOMID + "', '" + ProductQty + "', " +
                            //                " '" + ProductQty + "',0,0,0,0, '" + SalesPrice + "', '" + CostPrice + "','Y', '" + txtMinQty.Text + "', " +
                            //                " '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                            //                " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            //int insertFlag = DataLive.ExecuteLiveSQL(sql1Win);

                            //if (insertFlag == 1)
                            //{
                            string sql1 = " insert into tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                                      " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                      " values (" + Tenent.TenentID + "," + ID12 + " ,'" + txtProductCode.Text + "', '" + UOMID + "', '" + ProductQty + "', " +
                                      " '" + ProductQty + "',0,0,0,0, '" + SalesPrice + "', '" + CostPrice + "','Y', '" + txtMinQty.Text + "', " +
                                      " '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                      " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            DataAccess.ExecuteSQL(sql1);

                            string sql1Win = " insert into Win_tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                                             " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                             " values (" + Tenent.TenentID + "," + ID12 + " , '" + txtProductCode.Text + "', '" + UOMID + "', '" + ProductQty + "', " +
                                             " '" + ProductQty + "',0,0,0,0, '" + SalesPrice + "', '" + CostPrice + "','Y', '" + txtMinQty.Text + "', " +
                                             " '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                             " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            Datasyncpso.insert_Live_sync(sql1Win, "Win_tbl_item_uom_price", "INSERT");

                            string ActivityName = "Add Product With UOM";
                            string LogData = "Add Product With UOM product id = " + txtProductCode.Text + " UOM " + uomname + " ";
                            Login.InsertUserLog(ActivityName, LogData);

                            //Add to purchase history - New item history

                            decimal cost = Convert.ToDecimal(CostPrice);
                            decimal Msrp = Convert.ToDecimal(SalesPrice);

                            //insertpurchasehistory("NEW", quan, DateTime.Now.ToString("yyyy-MM-dd"), UOMID, cost, Msrp);
                            //}
                        }
                    }

                    Add_Item go = new Add_Item();
                    go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                    go.itemCode = txtProductCode.Text;
                    go.Show();

                    this.Close();

                }
                else if (btnUomAdd.Text == "Update")
                {
                    string imageName;
                    if (lblUOMFileExtension.Text == "item.png") //if not select image
                    {
                        imageName = lblimagename.Text;
                    }
                    else  // select image
                    {
                        string UOMEng = getuomName(UOMIC1);
                        if (lblItemcode.Text == "-")
                        {
                            imageName = txtProductCode.Text + UOMEng + lblUOMFileExtension.Text;
                        }
                        else
                        {
                            imageName = lblItemcode.Text + UOMEng + lblUOMFileExtension.Text;
                        }

                    }

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

                    //string Discount = txtdiscount.Text != "" ? txtdiscount.Text : "0";//yogesh
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    //string sql2win = " Update win_tbl_item_uom_price set price = '" + txtCostPrice.Text + "', msrp= '" + txtSalesPrice.Text + "', Discount= '" + Discount + "', " +
                    //                 " minQty= '" + txtMinQty.Text + "', MaxQty= '" + txtMaxQty.Text + "' , Image='" + imageName + "' , RecipeType = '" + RecipeType + "', recNo = " + recNo + " , " +
                    //                 " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                    //                 " where itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOMID + "' and TenentID= " + Tenent.TenentID + " ";
                    //int updateflag = DataLive.ExecuteLiveSQL(sql2win);

                    //if (updateflag == 1)
                    //{
                    //string sql2 = " Update tbl_item_uom_price set OpQty = '" + txtProductQty.Text + "', price = '" + txtCostPrice.Text + "', msrp= '" + txtSalesPrice.Text + "', Discount= '" + Discount + "', " +
                    //          " minQty= '" + txtMinQty.Text + "', MaxQty= '" + txtMaxQty.Text + "' , Image='" + imageName + "' , RecipeType = '" + RecipeType + "', recNo = " + recNo + " , " +
                    //          " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                    //          " where itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOMID1 + "' and TenentID= " + Tenent.TenentID + " ";
                    //DataAccess.ExecuteSQL(sql2);

                    //string sql2win = " Update win_tbl_item_uom_price set OpQty = '" + txtProductQty.Text + "', price = '" + txtCostPrice.Text + "', msrp= '" + txtSalesPrice.Text + "', Discount= '" + Discount + "', " +
                    //                 " minQty= '" + txtMinQty.Text + "', MaxQty= '" + txtMaxQty.Text + "' , Image='" + imageName + "' , RecipeType = '" + RecipeType + "', recNo = " + recNo + " , " +
                    //                 " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                    //                 " where itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOMID1 + "' and TenentID= " + Tenent.TenentID + " ";
                    //Datasyncpso.insert_Live_sync(sql2win, "win_tbl_item_uom_price", "UPDATE");

                    //string ActivityName = "Update Product With UOM";
                    //string LogData = "Update Product With UOM product id = " + lblItemcode.Text + " and UOM = " + uomname1 + " ";
                    //Login.InsertUserLog(ActivityName, LogData);

                    //foreach (DataGridViewRow row2 in dgrvMultiUomList.SelectedRows)
                    //{
                    //    if (!row2.IsNewRow)
                    //        dgrvMultiUomList.Rows.Remove(row2);
                    //}
                    //dgrvMultiUomList.Rows.Add(uomname1, txtProductQty.Text, txtCostPrice.Text, txtSalesPrice.Text);

                    double PID = Convert.ToDouble(lblItemcode.Text);
                    int UOM = Convert.ToInt32(UOMID1);
                    double EnterQty = Convert.ToDouble(txtProductQty.Text);
                    decimal NewMSRP = Convert.ToDecimal(txtSalesPrice.Text);
                    decimal Newprice = Convert.ToDecimal(txtCostPrice.Text);

                    //updatestockqty(PID, UOM, EnterQty, NewMSRP, Newprice, Discount);//yogesh
                    updatestockqty(PID, UOM, EnterQty, NewMSRP, Newprice, "0");

                    ClearUpdate();

                    MessageBox.Show("Update Successfully..", "Update Successfully..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    Add_Item go = new Add_Item();
                    go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                    go.itemCode = lblItemcode.Text;
                    go.Show();

                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updatestockqty(double PID, int UOM, double EnterQty, decimal NewMSRP, decimal Newprice, string Discount)
        {
            int SelctUOM = UOM;
            double Qty = EnterQty;

            string AllUOMConv = "";

            int BaseUOM = Purchase.GetBaseUOM(PID);

            if (BaseUOM == 0)
            {
                BaseUOM = SelctUOM;
                AllUOMConv = SelctUOM.ToString();
            }
            else
            {
                bool Check = Add_Item.Check_CalculateAspectRatio_allow(BaseUOM);
                if (Check == true)
                {
                    AllUOMConv = Purchase.getAllUomOfproduct(PID);
                }
                else
                {
                    AllUOMConv = SelctUOM.ToString();
                }
            }

            double BaseQty = Qty;
            if (SelctUOM != BaseUOM)
            {
                BaseQty = Purchase.getConversionBaseQty(BaseUOM, SelctUOM, Qty);
            }

            string[] ListUOM = AllUOMConv.Split(',');

            for (int j = 0; j < ListUOM.Length; j++)
            {
                double newQty = Qty;
                decimal msrp = NewMSRP;
                decimal price = Newprice;

                int ToUOM = Convert.ToInt32(ListUOM[j]);
                string UOMNAme = Add_Item.getuomName(ToUOM);
                if (ToUOM != SelctUOM)
                {
                    if (ToUOM == BaseUOM)
                    {
                        newQty = BaseQty;
                    }
                    else
                    {
                        newQty = Purchase.getConversionToQty(BaseUOM, ToUOM, BaseQty);
                    }
                    price = Purchase.getCostPrice(PID, ToUOM);
                    msrp = Purchase.getMSRP(PID, ToUOM);
                }

                string sql2 = "select * from tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID = '" + PID + "' and UOMID = '" + ToUOM + "' ";
                DataTable dtterminallist = DataAccess.GetDataTable(sql2);
                if (dtterminallist != null)
                {
                    if (dtterminallist.Rows.Count > 0)
                    {
                        double newOnHand = 0;
                        double OldOnHand = Convert.ToDouble(dtterminallist.Rows[0]["OnHand"]);

                        double OldOpQty = Convert.ToDouble(dtterminallist.Rows[0]["OpQty"]);
                        if (OldOpQty > newQty)
                        {
                            double Difer = OldOpQty - newQty;
                            newOnHand = OldOnHand - Difer;
                        }
                        else
                        {
                            double Difer = newQty - OldOpQty;
                            newOnHand = OldOnHand + Difer;
                        }

                        string Dis = "0";
                        //if (ToUOM != SelctUOM)
                        //{
                        //    Dis = dtterminallist.Rows[0]["Discount"].ToString();
                        //}
                        //else
                        //{
                        //    Dis = Discount;
                        //}

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql = " update tbl_item_uom_price set OpQty = '" + newQty + "', OnHand = '" + newOnHand + "', " +
                                     " msrp= '" + msrp + "' , price = '" + price + "' , Discount= '" + Dis + "'," +
                                     " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                     "  where TenentID= " + Tenent.TenentID + " and itemID = '" + PID + "' and UOMID = '" + ToUOM + "'";
                        DataAccess.ExecuteSQL(sql);

                        string sqlwin = " update Win_tbl_item_uom_price set OpQty = '" + newQty + "', OnHand = '" + newOnHand + "', " +
                                        " msrp= '" + msrp + "' , price = '" + price + "' , Discount= '" + Dis + "'," +
                                        " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                        " where TenentID= " + Tenent.TenentID + " and itemID = '" + PID + "' and UOMID = '" + ToUOM + "'";
                        Datasyncpso.insert_Live_sync(sqlwin, "Win_tbl_item_uom_price", "UPDATE");

                        string ActivityName = "Update Product With UOM";
                        string LogData = "Update Product With UOM product id = " + lblItemcode.Text + " and UOM = " + UOMNAme + " ";
                        Login.InsertUserLog(ActivityName, LogData);
                    }
                }
            }
        }

        public void SaveSingleUOM()
        {
            string UOMID = lblUOM.Text.ToString(); // drpUOM.SelectedValue.ToString();
            int UOMIC = Convert.ToInt32(UOMID);
            string uomname = getuomName(UOMIC);

            string ProductQty = txtProductQty.Text;
            string CostPrice = txtCostPrice.Text;
            string SalesPrice = txtSalesPrice.Text;

            string sqlselect = "select * from tbl_item_uom_price where TenentID= " + Tenent.TenentID + " and itemID = '" + lblItemcode.Text + "' and UOMID='" + UOMID + "' ";
            DataTable DTSelect = DataAccess.GetDataTable(sqlselect);

            string pid = lblItemcode.Text;//yogesh

            if (DTSelect.Rows.Count < 1)
            {
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
                    string filename = path + @"\" + imageName;
                    picItemUOMimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                    System.IO.File.Move(path + @"\" + imageName, path + @"\" + imageName);
                }

                string RecipeType = "";
                int recNo = 0;

                //if (chkkitchenDisplay.Checked == true)
                //{
                RecipeType = comboRecipeType.Text;
                //}

                int quan = Convert.ToInt32(ProductQty);

                string Discount = txtdiscount.Text != "" ? txtdiscount.Text : "0";
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                int ID12 = DataAccess.getuom_priceMYid(Tenent.TenentID, txtProductCode.Text, UOMIC);

                string sql1 = " insert into tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                          " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                          " values (" + Tenent.TenentID + "," + ID12 + " ,'" + txtProductCode.Text + "', '" + UOMID + "', '" + ProductQty + "', " +
                          " '" + ProductQty + "',0,0,0,0, '" + SalesPrice + "', '" + CostPrice + "','Y', '" + txtMinQty.Text + "', " +
                          " '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                          " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                DataAccess.ExecuteSQL(sql1);

                string sql1Win = " insert into Win_tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                                 " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                                 " values (" + Tenent.TenentID + "," + ID12 + " , '" + txtProductCode.Text + "', '" + UOMID + "', '" + ProductQty + "', " +
                                 " '" + ProductQty + "',0,0,0,0, '" + SalesPrice + "', '" + CostPrice + "','Y', '" + txtMinQty.Text + "', " +
                                 " '" + txtMaxQty.Text + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                                 " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                Datasyncpso.insert_Live_sync(sql1Win, "Win_tbl_item_uom_price", "INSERT");



                if (checkPerishable.Checked)//Check Perisable yogesh
                    add_perisable_Opening(txtProductCode.Text, Convert.ToInt32(UOMID), Convert.ToDouble(txtProductCode.Text));
                else if (checkSerialize.Checked)//Check Serialize yogesh
                    add_Serialize_Opening(txtProductCode.Text, Convert.ToInt32(UOMID), Convert.ToDouble(txtProductCode.Text));
                string ActivityName = "Add Product With UOM";
                string LogData = "Add Product With UOM product id = " + txtProductCode.Text + " UOM " + uomname + " ";
                Login.InsertUserLog(ActivityName, LogData);

            }
            else
            {
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

                double newQty = Convert.ToDouble(txtProductQty.Text);

                double newOnHand = 0;
                double OldOnHand = Convert.ToDouble(DTSelect.Rows[0]["OnHand"]);

                double OldOpQty = Convert.ToDouble(DTSelect.Rows[0]["OpQty"]);
                if (OldOpQty > newQty)
                {
                    double Difer = OldOpQty - newQty;
                    newOnHand = OldOnHand - Difer;
                }
                else
                {
                    double Difer = newQty - OldOpQty;
                    newOnHand = OldOnHand + Difer;
                }

                string sql2 = " Update tbl_item_uom_price set OpQty = '" + newQty + "', OnHand = '" + newOnHand + "', price = '" + txtCostPrice.Text + "', msrp= '" + txtSalesPrice.Text + "', Discount= '" + Discount + "', " +
                          " minQty= '" + txtMinQty.Text + "', MaxQty= '" + txtMaxQty.Text + "' , Image='" + imageName + "' , RecipeType = '" + RecipeType + "', recNo = " + recNo + " , " +
                          " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                          " where itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOMID + "' and TenentID= " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sql2);

                string sql2win = " Update win_tbl_item_uom_price set OpQty = '" + newQty + "', OnHand = '" + newOnHand + "', price = '" + txtCostPrice.Text + "', msrp= '" + txtSalesPrice.Text + "', Discount= '" + Discount + "', " +
                                 " minQty= '" + txtMinQty.Text + "', MaxQty= '" + txtMaxQty.Text + "' , Image='" + imageName + "' , RecipeType = '" + RecipeType + "', recNo = " + recNo + " , " +
                                 " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                 " where itemID = '" + lblItemcode.Text + "' and Deleted='Y' and UOMID='" + UOMID + "' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sql2win, "win_tbl_item_uom_price", "UPDATE");

                if (checkPerishable.Checked)//Check Perisable yogesh
                    add_perisable_Opening(pid, Convert.ToInt32(UOMID), Convert.ToDouble(pid));
                else if (checkSerialize.Checked)//Check Serialize yogesh
                    add_Serialize_Opening(pid, Convert.ToInt32(UOMID), Convert.ToDouble(pid));

                string ActivityName = "Update Product With UOM";
                string LogData = "Update Product With UOM product id = " + lblItemcode.Text + " UOM " + uomname + " ";
                Login.InsertUserLog(ActivityName, LogData);
            }

        }

        public static void SaveConvertionUOM(double ProductID, int UOM, string RecipeType, double OpQty, double OnHand, double QtyOut, double QtyConsumed, double QtyReserved, double QtyRecived, double SalesPrice, double CostPrice, int minQty, int MaxQty)
        {
            string uomname = Add_Item.getuomName(UOM);
            string itemID = ProductID.ToString();
            string imageName = "item.png";
            int recNo = 0;

            string Discount = "0";
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            int ID12 = DataAccess.getuom_priceMYid(Tenent.TenentID, itemID, UOM);

            string sql1 = " insert into tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                          " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                          " values (" + Tenent.TenentID + "," + ID12 + " ,'" + ProductID + "', '" + UOM + "', '" + OpQty + "', '" + OnHand + "','" + QtyOut + "', " +
                          " '" + QtyConsumed + "','" + QtyReserved + "','" + QtyRecived + "', '" + SalesPrice + "', '" + CostPrice + "','Y', '" + minQty + "', " +
                          " '" + MaxQty + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                          " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
            DataAccess.ExecuteSQL(sql1);

            string sql1Win = " insert into Win_tbl_item_uom_price (TenentID, ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived, " +
                             " msrp,price,Deleted,minQty,MaxQty,Discount,Image,RecipeType,recNo,Uploadby ,UploadDate ,SynID) " +
                             " values (" + Tenent.TenentID + "," + ID12 + " , '" + ProductID + "', '" + UOM + "', '" + OpQty + "','" + OnHand + "','" + QtyOut + "', " +
                             " '" + QtyConsumed + "','" + QtyReserved + "','" + QtyRecived + "', '" + SalesPrice + "', '" + CostPrice + "','Y', '" + minQty + "', " +
                             " '" + MaxQty + "', '" + Discount + "','" + imageName + "', '" + RecipeType + "' , " + recNo + " , " +
                             " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
            Datasyncpso.insert_Live_sync(sql1Win, "Win_tbl_item_uom_price", "INSERT");

            string ActivityName = "Add Product With UOM";
            string LogData = "Add Product With UOM product id = " + ProductID + " UOM " + uomname + " ";
            Login.InsertUserLog(ActivityName, LogData);
        }

        public void ClearUpdate()
        {
            btnUomAdd.Text = "Add";
            drpUOM.Enabled = true;
            txtSalesPrice.Text = "";
            txtCostPrice.Text = "";
            txtTotalUnitPrice.Text = "";
            txtdiscount.Text = "0";
            txtMinQty.Text = "";
            txtMaxQty.Text = "";
            txtProductQty.Text = "0";
            txtProductQty.Enabled = true;
            lblConsumedQty.Text = "0";
            lblOpeniongQty.Text = "0";
            lblOnhandqty.Text = "0";
            lblPurchaseQty.Text = "0";
            lblReservedQty.Text = "0";
            lblSaleQty.Text = "0";
        }

        public void Default()
        {
            txtProductQty.Text = "0";
            txtSalesPrice.Text = "";
            txtCostPrice.Text = "";
            txtTotalUnitPrice.Text = "";

            txtdiscount.Text = "0";
            txtMinQty.Text = "1";
            txtMaxQty.Text = "5";
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
        public bool IsSerialize(string product_id)//Yogesh
        {
            if (checkSerialize.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void BindGrid()
        {
            try
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
            catch
            {

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
                        double MYPRODID = Convert.ToDouble(rowdel.Cells["id"].Value);
                        int RalatedProdID = Convert.ToInt32(rowdel.Cells["rid"].Value);

                        string sqldel = " delete from TblProductRelated  where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "' ";
                        DataAccess.ExecuteSQL(sqldel);

                        string sqlUpdateCmdWIN = " delete from Win_TblProductRelated  where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "'";
                        Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "TblProductRelated", "DELETE");
                    }
                    BindGrid();
                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
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
        private void LinkProductSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
        private void txtProductQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductQty.Text != "")
                {
                    string pid = txtProductCode.Text;
                    bool Parisable = IsParisable(pid);
                    if (Parisable == true)
                    {
                        string UOMID = lblUOM.Text.ToString();// drpUOM.SelectedValue.ToString();
                        int UOMIC = Convert.ToInt32(UOMID);
                        //string uom = getuomName(UOMIC);
                        double MY_TRANS_ID = Convert.ToDouble(pid);//getPurchasenewid();yogesh
                        string MySysName = "PUR";
                        btnShowSerial.Text = "Show Batch";
                        btnShowSerial.Visible = true;
                        Items.Perishable go = new Items.Perishable(txtProductCode.Text, UOMID, MY_TRANS_ID, MySysName);//Constructor and nothing return
                        go.Qty = txtProductQty.Text;
                        go.Show();
                    }
                    bool Serialize = IsSerialize(pid);
                    if (Serialize == true)
                    {
                        string UOMID = lblUOM.Text.ToString();// drpUOM.SelectedValue.ToString();
                        int UOMIC = Convert.ToInt32(UOMID);
                        //string uom = getuomName(UOMIC);
                        double MY_TRANS_ID = Convert.ToDouble(pid);//getPurchasenewid();yogesh
                        string MySysName = "PUR";
                        btnShowSerial.Visible = true;
                        Items.Serialize go = new Items.Serialize(txtProductCode.Text, UOMID, MY_TRANS_ID, MySysName);//Constructor and nothing return
                        go.Qty = txtProductQty.Text;
                        go.Show();
                    }
                    decimal Qty = Convert.ToDecimal(txtProductQty.Text);
                    decimal UnitPrice = Convert.ToDecimal(txtCostPrice.Text);
                    decimal Total = UnitPrice * Qty;
                    txtTotalUnitPrice.Text = Total.ToString();
                }
            }
            catch
            {

            }
        }

        private void txtCostPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductQty.Text != "0")
                {
                    decimal Qty = Convert.ToDecimal(txtProductQty.Text);
                    decimal UnitPrice = Convert.ToDecimal(txtCostPrice.Text);
                    decimal Total = UnitPrice * Qty;
                    txtTotalUnitPrice.Text = Total.ToString();
                }
                else
                {
                    txtTotalUnitPrice.Text = txtCostPrice.Text;
                }
            }
            catch
            {

            }
        }

        private void txtTotalUnitPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductQty.Text != "0")
                {
                    decimal Qty = Convert.ToDecimal(txtProductQty.Text);
                    decimal Total = Convert.ToDecimal(txtTotalUnitPrice.Text);
                    decimal UnitPrice = Total / Qty;
                    txtCostPrice.Text = UnitPrice.ToString();
                }
                else
                {
                    txtCostPrice.Text = txtTotalUnitPrice.Text;
                }
            }
            catch
            {

            }
        }

        private void drpUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpUOM.Text != null && drpUOM.Text != "" && drpUOM.Text != "System.Data.DataRowView")
                {
                    string uomn = drpUOM.SelectedValue.ToString();
                    lblUOM.Text = uomn;
                    if (FlagLoad == false)
                    {
                        if (lblItemcode.Text != "-")
                        {
                            MessageBox.Show("Please ReEnter Opening Qty, Unit Cost Price,Unit sale Price ");
                            Default();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public void AddUOMItem()
        {
            ClearUpdate();
            Default();
        }

        private void lnkbuttonUOM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string MultiUOM = chMultiUOM.Checked == true ? "YES" : "NO";

            if (Application.OpenForms["UOMSearch"] != null)
            {
                Application.OpenForms["UOMSearch"].Close();
            }
            this.Refresh();

            UOMSearch go = new UOMSearch();
            go.MultiUOM = MultiUOM;
            go.Show();

        }

        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["CatagorySearch"] != null)
            {
                Application.OpenForms["CatagorySearch"].Close();
            }
            this.Refresh();

            CatagorySearch go = new CatagorySearch();
            go.PageName = "Add_Item";
            go.Show();
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbCategory.Text != null && CmbCategory.Text != "" && CmbCategory.Text != "System.Data.DataRowView")
                {
                    string Category = CmbCategory.SelectedValue.ToString();
                    lblCategory.Text = Category;
                }
            }
            catch
            {

            }

        }

        private void lnkSupper_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["SupplerSearch"] != null)
            {
                Application.OpenForms["SupplerSearch"].Close();
            }
            this.Refresh();

            SupplerSearch go = new SupplerSearch();
            go.Show();
        }

        private void btnShowSerial_Click(object sender, EventArgs e)
        {
            string Base1 = lblUOM.Text.ToString();// drpUOM.SelectedValue.ToString();
            int BaseUOM = Convert.ToInt32(Base1);
            string q = "select * from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + txtProductCode.Text + "  and UOM=" + BaseUOM + " and MYTRANSID=" + txtProductCode.Text + " and MySysName='PUR' and RecodName='Serialize' ";
            DataTable dt1 = DataAccess.GetDataTable(q);
            if (dt1.Rows.Count == 1)
            {

            }
            else
            {

                Items.Serialize go = new Items.Serialize(txtProductCode.Text, Base1, Convert.ToDouble(txtProductCode.Text), "PUR");//Constructor and nothing return
                go.Qty = txtProductQty.Text;
                go.Show();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["rptSerialReport"] != null)
            {
                Application.OpenForms["rptSerialReport"].BringToFront();
                Application.OpenForms["rptSerialReport"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                rptSerialReport go = new rptSerialReport();
                go.MdiParent = this.ParentForm;
                go.Show();
            }
        }

        private void checkSerialize_CheckedChanged(object sender, EventArgs e)
        {
            if (lblItemcode.Text == "-")
            {
                if (checkSerialize.Checked)
                {
                    checkPerishable.Enabled = false;
                    if (txtProductQty.Text != "0" && txtProductQty.Text != "")
                    {
                        string q = "select * from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + txtProductCode.Text + "  and UOM=" + lblUOM.Text + " and MYTRANSID=" + txtProductCode.Text + " ";
                        DataTable dt1 = DataAccess.GetDataTable(q);

                        if (dt1.Rows.Count <= 0)
                        {

                            MessageBox.Show(txtProductQty.Text + " Serial Must be Required.");
                            string UOMID = lblUOM.Text.ToString();// drpUOM.SelectedValue.ToString();
                            int UOMIC = Convert.ToInt32(UOMID);
                            //string uom = getuomName(UOMIC);
                            string MySysName = "PUR";
                            btnShowSerial.Visible = true;
                            Items.Serialize go = new Items.Serialize(txtProductCode.Text, UOMID, Convert.ToDouble(txtProductCode.Text), MySysName);//Constructor and nothing return
                            go.Qty = txtProductQty.Text;
                            go.Show();
                        }
                    }
                }
                else
                {
                    checkPerishable.Enabled = true;
                }
            }
        }





    }
}
