using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;

namespace supershop
{
    public partial class Import_Items : Form
    {
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        // private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.8.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel10ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        public Import_Items()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            string extension = Path.GetExtension(filePath);
            string header = rbHeaderYes.Checked ? "YES" : "NO";
            string conStr, sheetName;

            conStr = string.Empty;
            switch (extension)
            {

                case ".xls": //Excel 97-03
                    conStr = string.Format(Excel03ConString, filePath, header);
                    break;

                case ".xlsx": //Excel 07
                    conStr = string.Format(Excel10ConString, filePath, header);
                    break;

                case ".csv": //Excel 07
                    conStr = string.Format(Excel10ConString, filePath, header);
                    break;
            }

            //Get the name of the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = "items$";// dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    con.Close();
                }
            }

            //Read Data from the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandText = "SELECT * From [" + sheetName + "]";
                        cmd.Connection = con;
                        con.Open();
                        oda.SelectCommand = cmd;
                        oda.Fill(dt);
                        con.Close();

                        //Populate DataGridView.
                        dtgridviewImportPreview.DataSource = dt;
                        btnSave.Enabled = true;
                    }
                }
            }
        }

        private void btnImportPreview_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            lblRows.Text = "Total ID = " + dtgridviewImportPreview.RowCount.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblwaiting.Text = "Please Wait ...";

            bool Flage = true;
            int rows = dtgridviewImportPreview.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                try
                {
                    if (dtgridviewImportPreview.Rows[i].Cells[0].Value.ToString() != "" && dtgridviewImportPreview.Rows[i].Cells[0].Value.ToString() != null && dtgridviewImportPreview.Rows[i].Cells[10].Value.ToString() != "")
                    {
                        string product_id = dtgridviewImportPreview.Rows[i].Cells[0].Value.ToString().Trim();
                        product_id = Add_Item.voidQueryValidate(product_id);

                        string umo = dtgridviewImportPreview.Rows[i].Cells[1].Value.ToString().Trim();
                        umo = Add_Item.voidQueryValidate(umo);

                        string uom_Arabic = dtgridviewImportPreview.Rows[i].Cells[2].Value.ToString().Trim();
                        uom_Arabic = Add_Item.voidQueryValidate(uom_Arabic);

                        string product_name = dtgridviewImportPreview.Rows[i].Cells[4].Value.ToString().Trim();
                        product_name = Add_Item.voidQueryValidate(product_name);
                        
                       
                        string product_name_Arabic = dtgridviewImportPreview.Rows[i].Cells[3].Value.ToString().Trim() != "" ? dtgridviewImportPreview.Rows[i].Cells[3].Value.ToString().Trim() : product_name;
                        product_name_Arabic = Add_Item.voidQueryValidate(product_name_Arabic);
                        //if (product_name_Arabic.Contains("-"))
                        //{
                        //    string Temp = "";
                        //    string[] ap = product_name.Split('-');
                        //    int len = ap.Length;
                        //    for (int j = 0; j < len; j++)
                        //    {
                        //        Temp = Temp + " " + ap[j];
                        //    }
                        //    Temp = Temp.Trim();
                        //    product_name_Arabic = Temp;
                        //}

                        string product_name_print = dtgridviewImportPreview.Rows[i].Cells[5].Value.ToString().Trim() != "" ? dtgridviewImportPreview.Rows[i].Cells[5].Value.ToString().Trim() : product_name + " - " + product_name_Arabic;
                        product_name_print = Add_Item.voidQueryValidate(product_name_print);

                        int OnHand = dtgridviewImportPreview.Rows[i].Cells[6].Value.ToString().Trim() != "" ? Convert.ToInt32(dtgridviewImportPreview.Rows[i].Cells[6].Value.ToString().Trim()) : 0;
                        double price = dtgridviewImportPreview.Rows[i].Cells[7].Value.ToString().Trim() != "" ? Convert.ToDouble(dtgridviewImportPreview.Rows[i].Cells[7].Value.ToString().Trim()) : 0;
                        double msrp = dtgridviewImportPreview.Rows[i].Cells[8].Value.ToString().Trim() != "" ? Convert.ToDouble(dtgridviewImportPreview.Rows[i].Cells[8].Value.ToString().Trim()) : 0;
                        double total_msrp = msrp * OnHand;
                        double total_price = price * OnHand;

                        string category = dtgridviewImportPreview.Rows[i].Cells[10].Value.ToString().Trim();
                        category = Add_Item.voidQueryValidate(category);

                        string category_Arabic = dtgridviewImportPreview.Rows[i].Cells[9].Value.ToString().Trim() != "" ? dtgridviewImportPreview.Rows[i].Cells[9].Value.ToString().Trim() : category;
                        category_Arabic = Add_Item.voidQueryValidate(category_Arabic);

                        string supplier = dtgridviewImportPreview.Rows[i].Cells[11].Value.ToString() != "" ? dtgridviewImportPreview.Rows[i].Cells[11].Value.ToString().Trim() : "";
                        supplier = Add_Item.voidQueryValidate(supplier);
                        


                        double discount = dtgridviewImportPreview.Rows[i].Cells[12].Value.ToString().Trim() != "" ? Convert.ToDouble(dtgridviewImportPreview.Rows[i].Cells[12].Value.ToString().Trim()) : 0;
                        int taxapply = dtgridviewImportPreview.Rows[i].Cells[13].Value.ToString().Trim() != "" ? Convert.ToInt32(dtgridviewImportPreview.Rows[i].Cells[13].Value.ToString().Trim()) : 0;

                        string Shopid = UserInfo.Shopid;// dtgridviewImportPreview.Rows[i].Cells[14].Value.ToString();
                        string kitchendisplay1 = dtgridviewImportPreview.Rows[i].Cells[15].Value.ToString().Trim() != "" ? dtgridviewImportPreview.Rows[i].Cells[15].Value.ToString().Trim() : "NO";
                        string imagename = dtgridviewImportPreview.Rows[i].Cells[16].Value.ToString().Trim() != "" ? dtgridviewImportPreview.Rows[i].Cells[16].Value.ToString().Trim() : "item.png";// product_id + ".png";

                        string CustItemCode = dtgridviewImportPreview.Rows[i].Cells[17].Value.ToString().Trim() != "" ? dtgridviewImportPreview.Rows[i].Cells[17].Value.ToString().Trim() : product_id;
                        CustItemCode = Add_Item.voidQueryValidate(CustItemCode);

                        string BarCode = dtgridviewImportPreview.Rows[i].Cells[18].Value.ToString().Trim() != "" ? dtgridviewImportPreview.Rows[i].Cells[17].Value.ToString().Trim() : product_id;
                        BarCode = Add_Item.voidQueryValidate(BarCode);

                        string RecipeType = dtgridviewImportPreview.Rows[i].Cells[19].Value.ToString().Trim() != "" ? dtgridviewImportPreview.Rows[i].Cells[19].Value.ToString().Trim() : "Output";

                        string[] _RecipeType = { "Raw Material", "Base Unit", "Machinery", "Service", "Resource Hours", "Amount", "Output" };

                        bool Rflag = false;
                        foreach (string s in _RecipeType)
                        {
                            if (RecipeType.ToUpper() == s.ToUpper())
                            {
                                Rflag = true;
                                break;
                            }
                        }

                        if (Rflag == false)
                        {
                            RecipeType = "Output";
                        }
                        int kitchendisplay = 1;
                        if (kitchendisplay1.ToLower() == "yes")
                        {
                            kitchendisplay = 3;
                        }

                        double PID = Convert.ToDouble(product_id);

                        string Shopidex = Shopid;

                        bool Shpflag = checkShopID(Shopid);
                        if (Shpflag == false)
                        {
                            Shopid = getShop();
                            if (Shopid == "")
                            {
                                Shopid = Shopidex;
                            }
                        }

                        if (CustItemCode == "0")
                        {
                            CustItemCode = product_id;
                        }

                        //if(ExpiryDate!="")
                        //{
                        //    DateTime EXPDAte = Convert.ToDateTime(ExpiryDate);
                        //    ExpiryDate = EXPDAte.ToString("yyyy-MM-dd");
                        //}                       

                        category = category.Trim();

                        AddSupplier(supplier);

                        string CAT_NAME1 = category.ToUpper();
                        string sqlCAT = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " and upper(Cat_Name1)='" + CAT_NAME1 + "'";
                        DataTable dtCAT = DataAccess.GetDataTable(sqlCAT);
                        if (dtCAT.Rows.Count < 1)
                        {
                            int CATID = DataAccess.getCAT_MSTMYid(Tenent.TenentID);

                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            //string sqlCmdWin = " insert into CAT_MST (TenentID,CATID,PARENT_CATID, SHORT_NAME,CAT_NAME1,CAT_NAME2,CAT_NAME3,DefaultPic,CAT_TYPE,Active,Uploadby ,UploadDate ,SynID)  values (" + Tenent.TenentID + "," + CATID + " , 0 ,'" + category + "','" + category + "',N'" + category_Arabic + "','" + category + "','" + imagename + "','WEBSALE','1','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                            //int InsertFalg = DataLive.ExecuteLiveSQL(sqlCmdWin);

                            //if (InsertFalg == 1)
                            //{
                                string sqlCmd = " insert into CAT_MST (TenentID,CATID,PARENT_CATID, SHORT_NAME,CAT_NAME1,CAT_NAME2,CAT_NAME3,DefaultPic,CAT_TYPE,Active,Uploadby ,UploadDate ,SynID)  values (" + Tenent.TenentID + "," + CATID + " , 0 ,'" + category + "','" + category + "','" + category_Arabic + "','" + category + "','" + imagename + "','WEBSALE','1','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                                int flag = DataAccess.ExecuteSQL(sqlCmd);


                                string sqlCmdWin = " insert into CAT_MST (TenentID,CATID,PARENT_CATID, SHORT_NAME,CAT_NAME1,CAT_NAME2,CAT_NAME3,DefaultPic,CAT_TYPE,Active,Uploadby ,UploadDate ,SynID)  values (" + Tenent.TenentID + "," + CATID + " , 0 ,'" + category + "','" + category + "',N'" + category_Arabic + "','" + category + "','" + imagename + "','WEBSALE','1','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                                Datasyncpso.insert_Live_sync(sqlCmdWin, "CAT_MST", "INSERT");

                                string ActivityName = "Add Catagory";
                                string LogData = "Add Catagory With CatID = " + CATID + " and Name  = " + category + " ";
                                Login.InsertUserLog(ActivityName, LogData);
                            //}
                        }

                        string UOMNAME1 = umo.ToUpper();
                        string sqlUOM = "select * from ICUOM where upper(UOMNAME1)='" + UOMNAME1 + "' and TenentID=" + Tenent.TenentID + " ";
                        DataTable dtUOM = DataAccess.GetDataTable(sqlUOM);
                        if (dtUOM.Rows.Count < 1)
                        {
                            int UOM = DataAccess.getUOMid(Tenent.TenentID);

                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            //string sqlCmdWin = " insert into ICUOM (TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,UOM_TYPE ,Active,Uploadby ,UploadDate ,SynID)  " +
                            //    " values (" + Tenent.TenentID + "," + UOM + " , N'" + umo + "',N'" + umo + "', N'" + uom_Arabic + "',N'" + umo + "',N'" + umo + "', " +
                            //    " 'POS' , 'Y', '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                            //int insertFlag = DataLive.ExecuteLiveSQL(sqlCmdWin);

                            //if (insertFlag == 1)
                            //{
                                string sqlCmd = " insert into ICUOM (TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,UOM_TYPE ,Active  ,Uploadby ,UploadDate ,SynID)  " +
                                                " values (" + Tenent.TenentID + "," + UOM + " , '" + umo + "', '" + umo + "','" + uom_Arabic + "', '" + umo + "','" + umo + "', " +
                                                " 'POS' ,'Y', '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                                int flag = DataAccess.ExecuteSQL(sqlCmd);

                                string sqlCmdWin = " insert into ICUOM (TenentID,UOM,UOMNAMESHORT,UOMNAME1,UOMNAME2,UOMNAME3,REMARKS,UOM_TYPE ,Active,Uploadby ,UploadDate ,SynID)  " +
                                                   " values (" + Tenent.TenentID + "," + UOM + " , N'" + umo + "',N'" + umo + "', N'" + uom_Arabic + "',N'" + umo + "',N'" + umo + "', " +
                                                   " 'POS' , 'Y', '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                                Datasyncpso.insert_Live_sync(sqlCmdWin, "ICUOM", "INSERT");

                                string ActivityName = "Add UOM";
                                string LogData = "Add UOM With UOM NAME = " + umo + " ";
                                Login.InsertUserLog(ActivityName, LogData);
                            //}
                        }

                        int CAT_ID = Add_Item.GetCATID(category);
                        int UOMID = Add_Item.getuomID(umo);
                        int SupplierID = GetSuplierID(supplier);

                        string sqlNO = "select * from purchase where TenentID = " + Tenent.TenentID + " and product_id='" + product_id + "'";
                        DataTable dtNO = DataAccess.GetDataTable(sqlNO);
                        if (dtNO.Rows.Count < 1)
                        {
                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            //string sqlCmdWin = " insert into Win_purchase (TenentID, product_id ,UOM, product_name ,product_name_print," +
                            //                " category , supplier , imagename, taxapply, Shopid, status,product_name_Arabic,category_arabic,Uploadby ,UploadDate ,SynID,CustItemCode,BarCode) " +
                            //                "  values (" + Tenent.TenentID + ",'" + product_id + "' ,'Y' , '" + product_name + "', N'" + product_name_print + "', " +
                            //                " '" + CAT_ID + "', '" + SupplierID + "', '" + imagename + "' , " +
                            //                " '" + taxapply + "' , '" + Shopid + "', '" + kitchendisplay + "', N'" + product_name_Arabic + "', N'" + category_Arabic + "', '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + BarCode + "' )";
                            //int insertFlag = DataLive.ExecuteLiveSQL(sqlCmdWin);

                            //if (insertFlag == 1)
                            //{

                            int BaseUOM = UOMID;
                                string sqlCmd = " insert into purchase (TenentID, product_id ,UOM, product_name ,product_name_print," +
                                           " category , supplier , imagename, taxapply, Shopid, status,product_name_Arabic,category_arabic,Uploadby ,UploadDate ,SynID,CustItemCode,BarCode,BaseUOM) " +
                                           "  values (" + Tenent.TenentID + ",'" + product_id + "' ,'N' , '" + product_name + "', '" + product_name_print + "', " +
                                           " '" + CAT_ID + "', '" + SupplierID + "', '" + imagename + "' , " +
                                           " '" + taxapply + "' , '" + Shopid + "', '" + kitchendisplay + "', '" + product_name_Arabic + "', '" + category_Arabic + "',  '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + BarCode + "','" + BaseUOM + "' )";
                                int flag = DataAccess.ExecuteSQL(sqlCmd);

                                string sqlCmdWin = " insert into Win_purchase (TenentID, product_id ,UOM, product_name ,product_name_print," +
                                                " category , supplier , imagename, taxapply, Shopid, status,product_name_Arabic,category_arabic,Uploadby ,UploadDate ,SynID,CustItemCode,BarCode,BaseUOM) " +
                                                "  values (" + Tenent.TenentID + ",'" + product_id + "' ,'N' , '" + product_name + "', N'" + product_name_print + "', " +
                                                " '" + CAT_ID + "', '" + SupplierID + "', '" + imagename + "' , " +
                                                " '" + taxapply + "' , '" + Shopid + "', '" + kitchendisplay + "', N'" + product_name_Arabic + "', N'" + category_Arabic + "', '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + CustItemCode + "','" + BarCode + "','" + BaseUOM + "'  )";
                                Datasyncpso.insert_Live_sync(sqlCmdWin, "Win_purchase", "INSERT");

                                string ActivityName = "Add Product";
                                string LogData = "Add Product with product id = " + product_id + " ";
                                Login.InsertUserLog(ActivityName, LogData);
                            //}

                        }
                        else
                        {
                            //string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            ////string sqlCmdwin = "update Win_purchase set product_name='" + product_name + "' ,product_name_print= N'" + product_name_print + "' , category='" + CAT_ID + "' , " +
                            ////               " supplier='" + SupplierID + "' , imagename='" + imagename + "' , taxapply='" + taxapply + "' , Shopid='" + Shopid + "' , " +
                            ////               " status='" + kitchendisplay + "' , product_name_Arabic= N'" + product_name_Arabic + "' , category_arabic= N'" + category_Arabic + "' , " +
                            ////               " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "', CustItemCode = '" + CustItemCode + "', BarCode = '" + BarCode + "' ,SynID = 2 " +
                            ////               " where product_id='" + product_id + "' and TenentID = " + Tenent.TenentID + " ";
                            ////int updateFlag = DataLive.ExecuteLiveSQL(sqlCmdwin);

                            ////if (updateFlag == 1)
                            ////{
                            //    string sqlCmd = "update purchase set product_name='" + product_name + "',product_name_print='" + product_name_print + "' , category='" + CAT_ID + "' , " +
                            //                " supplier='" + SupplierID + "' , imagename='" + imagename + "' , taxapply='" + taxapply + "' , Shopid='" + Shopid + "' , " +
                            //                " status='" + kitchendisplay + "' , product_name_Arabic='" + product_name_Arabic + "' , category_arabic='" + category_Arabic + "' , " +
                            //                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' , CustItemCode = '" + CustItemCode + "', BarCode = '" + BarCode + "',SynID = 2 " +
                            //                " where product_id='" + product_id + "' and TenentID = " + Tenent.TenentID + " ";
                            //    DataAccess.ExecuteSQL(sqlCmd);

                            //    string sqlCmdwin = "update Win_purchase set product_name='" + product_name + "' ,product_name_print= N'" + product_name_print + "' , category='" + CAT_ID + "' , " +
                            //                   " supplier='" + SupplierID + "' , imagename='" + imagename + "' , taxapply='" + taxapply + "' , Shopid='" + Shopid + "' , " +
                            //                   " status='" + kitchendisplay + "' , product_name_Arabic= N'" + product_name_Arabic + "' , category_arabic= N'" + category_Arabic + "' , " +
                            //                   " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "', CustItemCode = '" + CustItemCode + "', BarCode = '" + BarCode + "' ,SynID = 2 " +
                            //                   " where product_id='" + product_id + "' and TenentID = " + Tenent.TenentID + " ";
                            //    Datasyncpso.insert_Live_sync(sqlCmdwin, "Win_purchase", "UPDATE");

                            //    string ActivityName = "Update Product";
                            //    string LogData = "Update Product with product id = " + product_id + " ";
                            //    Login.InsertUserLog(ActivityName, LogData);
                            //}
                        }


                        string sql = "select * from tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID='" + product_id + "' and UOMID='" + UOMID + "' ";
                        DataTable dt = DataAccess.GetDataTable(sql);
                        if (dt.Rows.Count < 1)
                        {
                            int ID12 = DataAccess.getuom_priceMYid(Tenent.TenentID, product_id, UOMID);

                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            //string sql1Win = " insert into Win_tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,price,msrp,Deleted,minQty,MaxQty,Discount,Uploadby ,UploadDate ,SynID,RecipeType) " +
                            //                 " values (" + Tenent.TenentID + "," + ID12 + ",'" + product_id + "', '" + UOMID + "', '" + OnHand + "', '" + OnHand + "',0,0,0,0, '" + price + "', '" + msrp + "','Y', '" + 1 + "', '" + 5 + "', '" + discount + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + RecipeType + "')";
                            //int InsertFlag = DataLive.ExecuteLiveSQL(sql1Win);
                            //if (InsertFlag == 1)
                            //{
                                string sql1 = " insert into tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,price,msrp,Deleted,minQty,MaxQty,Discount,Uploadby ,UploadDate ,SynID,RecipeType) " +
                                             " values (" + Tenent.TenentID + "," + ID12 + ",'" + product_id + "', '" + UOMID + "', '" + OnHand + "', '" + OnHand + "',0,0,0,0, '" + price + "', '" + msrp + "','Y', '" + 1 + "', '" + 5 + "', '" + discount + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + RecipeType + "')";
                                int flag = DataAccess.ExecuteSQL(sql1);


                                string sql1Win = " insert into Win_tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,price,msrp,Deleted,minQty,MaxQty,Discount,Uploadby ,UploadDate ,SynID,RecipeType) " +
                                                 " values (" + Tenent.TenentID + "," + ID12 + ",'" + product_id + "', '" + UOMID + "', '" + OnHand + "', '" + OnHand + "',0,0,0,0, '" + price + "', '" + msrp + "','Y', '" + 1 + "', '" + 5 + "', '" + discount + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1,'" + RecipeType + "')";
                                Datasyncpso.insert_Live_sync(sql1Win, "Win_tbl_item_uom_price", "INSERT");

                                string ActivityName = "Add Product With UOM";
                                string LogData = "Add Product With UOM product id = " + product_id + " UOM " + umo + " ";
                                Login.InsertUserLog(ActivityName, LogData);

                                //insertpurchasehistory(product_id, product_name, OnHand, msrp, price, CAT_ID, SupplierID, Shopid, UOMID);
                            //}

                        }
                        else
                        {
                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            //string sql1win = "update Win_tbl_item_uom_price set price='" + price + "' , msrp='" + msrp + "' , RecipeType = '" + RecipeType + "', " +
                            //              " Discount='" + discount + "' , " +
                            //              " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                            //              " where itemID='" + product_id + "' and UOMID='" + UOMID + "' and TenentID= " + Tenent.TenentID + " ";
                            //int UpdateFlag = DataLive.ExecuteLiveSQL(sql1win);

                            //if (UpdateFlag == 1)
                            //{
                                string sql1 = "update tbl_item_uom_price set price='" + price + "' , msrp='" + msrp + "' , RecipeType = '" + RecipeType + "', " +
                                           " Discount='" + discount + "' , " +
                                           " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                           " where itemID='" + product_id + "' and UOMID='" + UOMID + "' and TenentID= " + Tenent.TenentID + " ";
                                DataAccess.ExecuteSQL(sql1);

                                string sql1win = "update Win_tbl_item_uom_price set price='" + price + "' , msrp='" + msrp + "' , RecipeType = '" + RecipeType + "', " +
                                               " Discount='" + discount + "' , " +
                                               " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                               " where itemID='" + product_id + "' and UOMID='" + UOMID + "' and TenentID= " + Tenent.TenentID + " ";
                                Datasyncpso.insert_Live_sync(sql1win, "Win_tbl_item_uom_price", "UPDATE");

                                string ActivityName = "Update Product With UOM";
                                string LogData = "Update Product With UOM product id = " + product_id + " UOM " + umo + " ";
                                Login.InsertUserLog(ActivityName, LogData);
                            //}
                        }

                        //Same time Purchase history insert



                        lblwaiting.Text = i + " row import ";
                        lblwaiting.Refresh();

                        //Serial image upload
                        //string path = Application.StartupPath + @"\ITEMIMAGE\";
                        //string filename = path + @"\" + picItemimage.Image;
                        //if (System.IO.File.Exists(filename))
                        //{

                        //}
                        //else
                        //{
                        //    //picItemimage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        //    //System.IO.File.Move(path + @"\" + picItemimage.Image, path + @"\" + imagename);
                        //}


                        ///  MessageBox.Show("Successfully Added ");

                    }
                }
                catch (Exception exp)
                {
                    Flage = false;
                    MessageBox.Show(exp.Message);
                }
            }

            if (Flage == true)
            {
                btnSave.Enabled = false;
                lblmsg.Text = "Successfully Added Bulk items and purchase history record";
                lblwaiting.Visible = false;
            }

            DialogResult result = MessageBox.Show(" Successfully Added Bulk items and purchase history record \n You Want To Close It ? ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }


        }

        public static bool checkShopID(string Shopid)
        {
            Shopid = Shopid.ToLower();
            string sql5 = "select * from tbl_terminallocation where TenentID = " + Tenent.TenentID + " and lower(Shopid) = '" + Shopid + "' ";
            DataAccess.ExecuteSQL(sql5);
            DataTable dt5 = DataAccess.GetDataTable(sql5);

            if (dt5.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        public static string getShop()
        {
            string sql5 = "select * from tbl_terminallocation where TenentID = " + Tenent.TenentID + " ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);

            if (dt5.Rows.Count > 0)
            {
                return dt5.Rows[0]["Shopid"].ToString();
            }
            return "";
        }

        public int GetSuplierID(string Name)
        {
            int SupplierID = 0;
            Name = Name.ToUpper();
            string sql5 = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and Peopletype = 'Supplier' and upper(Name) = '" + Name + "'";
            DataTable dt5 = DataAccess.GetDataTable(sql5);

            if (dt5.Rows.Count > 0)
            {
                SupplierID = Convert.ToInt32(dt5.Rows[0]["ID"]);
            }
            return SupplierID;

        }

        public void AddSupplier(string CustomerName)
        {
            // if (txtPeopleID.Text == "") { MessageBox.Show("Please Fill ID"); txtPeopleID.Focus(); } else
            if (CustomerName == "" || CustomerName == null)
            {
            }
            else
            {
                string CustomerName1 = CustomerName.ToUpper();
                string sql = "select *  from tbl_customer where TenentID=" + Tenent.TenentID + " and upper(Name)='" + CustomerName1 + "' ";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count < 1)
                {
                    int ID = DataAccess.getCustomerMYid(Tenent.TenentID);

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    //string sqlCmdWin = "insert into Win_tbl_customer (TenentID,ID, Name,NameArabic, Phone, address, City, PeopleType,Uploadby ,UploadDate ,SynID )  " +
                    //                  " values (" + Tenent.TenentID + ",'" + ID + "', N'" + CustomerName + "', N'" + CustomerName + "', '12345678', N'Kuwait', N'Kuwait', 'Supplier','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                    //int InsertFag = DataLive.ExecuteLiveSQL(sqlCmdWin);
                    //if (InsertFag == 1)
                    //{
                        string sqlCmd = "insert into tbl_customer (TenentID,ID, Name,NameArabic, Phone, address, City, PeopleType,Uploadby ,UploadDate ,SynID ) " +
                                   "  values (" + Tenent.TenentID + ",'" + ID + "','" + CustomerName + "','" + CustomerName + "', '12345678', 'Kuwait', 'Kuwait', 'Supplier','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        int flag1 = DataAccess.ExecuteSQL(sqlCmd);

                        string sqlCmdWin = "insert into Win_tbl_customer (TenentID,ID, Name,NameArabic, Phone, address, City, PeopleType,Uploadby ,UploadDate ,SynID )  " +
                                           " values (" + Tenent.TenentID + ",'" + ID + "', N'" + CustomerName + "', N'" + CustomerName + "', '12345678', N'Kuwait', N'Kuwait', 'Supplier','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        Datasyncpso.insert_Live_sync(sqlCmdWin, "Win_tbl_customer", "INSERT");

                        string ActivityName = "add Supplier ";
                        string LogData = "add Supplier with Name = " + CustomerName + " ";
                        Login.InsertUserLog(ActivityName, LogData);
                    //}
                }
            }

        }

        public void insertpurchasehistory(string pid, string pname, double pQty, double msrp, double price, int category, int supplier, string shopid, int uom)
        {
            if (pQty != 0)
            {
                int ID12 = 1;
                string sql12 = " select * from tbl_purchase_history where TenentID = " + Tenent.TenentID + " ";
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


                string pdate = DateTime.Now.ToString("yyyy-MM-dd");
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string sql1Win = " insert into Win_tbl_purchase_history (TenentID , id, product_id, product_name,product_quantity,  retail_price, cost_price, category, " +
                                " supplier, purchase_date, Shopid, ptype,uom ,Uploadby ,UploadDate ,SynID) " +
                                " values (" + Tenent.TenentID + "," + ID12 + ",'" + pid + "', N'" + pname + "','" + pQty + "' , '" + msrp + "', '" + price + "', '" + category + "', " +
                                "  '" + supplier + "', '" + pdate + "' ,'" + shopid + "', 'NEW','" + uom + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                int insertFlag = DataLive.ExecuteLiveSQL(sql1Win);

                if (insertFlag == 1)
                {
                    string sql1 = " insert into tbl_purchase_history (TenentID,id, product_id, product_name,product_quantity,  retail_price, cost_price, category, " +
                                " supplier, purchase_date, Shopid, ptype,uom ,Uploadby ,UploadDate ,SynID) " +
                                " values (" + Tenent.TenentID + "," + ID12 + ",'" + pid + "', '" + pname + "','" + pQty + "' ,'" + msrp + "', '" + price + "', '" + category + "', " +
                                "  '" + supplier + "', '" + pdate + "' ,'" + shopid + "', 'NEW','" + uom + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                    int flag = DataAccess.ExecuteSQL(sql1);


                    //string sql1Win = " insert into Win_tbl_purchase_history (TenentID , id, product_id, product_name,product_quantity,  retail_price, cost_price, category, " +
                    //                " supplier, purchase_date, Shopid, ptype,uom ,Uploadby ,UploadDate ,SynID) " +
                    //                " values (" + Tenent.TenentID + "," + ID12 + ",'" + pid + "', N'" + pname + "','" + pQty + "' , '" + msrp + "', '" + price + "', '" + category + "', " +
                    //                "  '" + supplier + "', '" + pdate + "' ,'" + shopid + "', 'NEW','" + uom + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                    //Datasyncpso.insert_Live_sync(sql1Win, "Win_tbl_purchase_history");

                    string ActivityName = "purchase Item";
                    string LogData = "purchase Item with product_id = " + pid + "and UOM = " + uom + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // System.Diagnostics.Process.Start("Calc");
                // SendKeys.SendWait(lblTotal.Text);
                Process p = new Process();
                p.StartInfo.FileName = "items.xls";
                p.Start();
                p.WaitForInputIdle();

            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath + @"\ITEMIMAGE\";

                System.IO.DirectoryInfo di = new DirectoryInfo(UserInfo.Img_path);

                if (di.Exists)
                {
                    path = UserInfo.Img_path;
                }

                //FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                //folderDlg.ShowNewFolderButton = true;
                //// Show the FolderBrowserDialog.
                //DialogResult result = folderDlg.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                //    string BackupSource = folderDlg.SelectedPath;
                //    Environment.SpecialFolder root = folderDlg.RootFolder;
                //    foreach (string newPath in Directory.GetFiles(BackupSource, "*.*", SearchOption.AllDirectories))
                //        File.Copy(newPath, newPath.Replace(BackupSource, path), true);
                //}


                var o = new OpenFileDialog();
                o.Multiselect = true;
                if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    o.FileNames.ToList().ForEach(file =>
                    {
                        System.IO.File.Copy(file, System.IO.Path.Combine(path, System.IO.Path.GetFileName(file)));
                    });
                }
                //MessageBox.Show("Image Uploaded");
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error: " + EX.ToString());
            }
        }

    }
}
