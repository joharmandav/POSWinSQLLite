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


namespace supershop
{
    public partial class RelatedProduct : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public RelatedProduct()
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

            //datagrdReportDetails

            DataGridViewButtonColumn Assign = new DataGridViewButtonColumn();
            this.datagrdReportDetails.Columns.Add(Assign);
            Assign.HeaderText = "Action";
            Assign.Text = "Delete";
            Assign.Name = "Delete";
            Assign.ToolTipText = "Delete";
            Assign.UseColumnTextForButtonValue = true;
            //datagrdReportDetails

            DataGridViewButtonColumn ADDShow = new DataGridViewButtonColumn();
            this.datagrdReportDetails.Columns.Add(ADDShow);
            ADDShow.HeaderText = "Always Show";
            ADDShow.Text = "Add";
            ADDShow.Name = "Add";
            ADDShow.ToolTipText = "Add";
            ADDShow.UseColumnTextForButtonValue = true;

            //dataGridAlwaysShow

            DataGridViewButtonColumn Delete = new DataGridViewButtonColumn();
            this.dataGridAlwaysShow.Columns.Add(Delete);
            Delete.HeaderText = "Action";
            Delete.Text = "Delete";
            Delete.Name = "Delete";
            Delete.ToolTipText = "Delete";
            Delete.UseColumnTextForButtonValue = true;
        }

        private void switch_language()
        {
            labelSelectCategory.Text = res_man.GetString("stockItem_labelSelectCategory", cul);
            linkLabelAllCatagory.Text = res_man.GetString("stockItem_linkLabelAllCatagory", cul);
        }

        #region Data bind
        //Show Products image


        public void BindGrid()
        {
            string PID = "0";
            if (comboItem.Text != "" && comboItem.Text != "System.Data.DataRowView")
            {
                string PRoductID = comboItem.Text.ToString().Trim().Split('-')[0];
                PRoductID = PRoductID.Trim();
                PID = PRoductID;
            }

            string sql = " select MYPRODID as id, RalatedProdID as rid, (select product_id || ' - ' || product_name || ' - ' || product_name_Arabic from  purchase where TenentID=" + Tenent.TenentID + " and product_id = TblProductRelated.MYPRODID ) as 'Item name' , " +
                         " (select product_id || ' - ' || product_name || ' - ' || product_name_Arabic from purchase where TenentID=" + Tenent.TenentID + " and product_id = TblProductRelated.RalatedProdID ) as 'Related Item name'" +
                         " from TblProductRelated where TenentID=" + Tenent.TenentID + " and MYPRODID = " + PID + " ";

            DataTable dt = DataAccess.GetDataTable(sql);

            datagrdReportDetails.DataSource = dt;
            datagrdReportDetails.Columns["id"].Visible = false;
            datagrdReportDetails.Columns["rid"].Visible = false;
            datagrdReportDetails.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            datagrdReportDetails.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            datagrdReportDetails.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdReportDetails.Columns["Add"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdReportDetails.Columns["Add"].DisplayIndex = 5;

            AlwaysShow_with_images();

        }

        public void AlwaysShow_with_images()
        {
            string sql = " select Myprodid as id,RalatedProdID as rid, (select product_id || ' - ' || product_name || ' - ' || product_name_Arabic " +
                         " from purchase where TenentID = " + Tenent.TenentID + " and product_id =  TblProductRelated.RalatedProdID ) as 'Always Show Item name' " +
                         " from TblProductRelated where TenentID = " + Tenent.TenentID + " and AlwaysShow = 'True' ";

            DataTable dt = DataAccess.GetDataTable(sql);

            dataGridAlwaysShow.DataSource = dt;
            dataGridAlwaysShow.Columns["id"].Visible = false;
            dataGridAlwaysShow.Columns["rid"].Visible = false;
            dataGridAlwaysShow.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridAlwaysShow.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public void BindITEM()
        {
            string sql = "SELECT  (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic) as product_name    FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                         " where purchase.TenentID = " + Tenent.TenentID + "  group by product_name order by product_id ";

            DataTable dt = DataAccess.GetDataTable(sql);
            comboItem.DataSource = dt;
            comboItem.DisplayMember = "product_name";
        }
        public void ItemList_with_images(string value)
        {
            flowLayoutPanelUserList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg *.bmp *.jeg");
            try
            {
                string PID = "0";
                if (comboItem.Text != "" && comboItem.Text != "System.Data.DataRowView")
                {
                    string PRoductID = comboItem.Text.ToString().Trim().Split('-')[0];
                    PRoductID = PRoductID.Trim();
                    PID = PRoductID;
                }

                string sql = " SELECT  Shopid,product_name,product_name_Arabic,category,category_arabic,supplier,status,taxapply,imagename,product_id,UOMID,msrp,price,Deleted,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved,QtyRecived,minQty,MaxQty,Discount,Image,AlwaysShow  " +
                             "  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID  Left JOIN TblProductRelated ON purchase.product_id = TblProductRelated.RalatedProdID and purchase.TenentID = TblProductRelated.TenentID " +
                             " where purchase.TenentID = " + Tenent.TenentID + " and  " +
                             " product_id!='" + PID + "' and " +
                             " ((category = '" + value + "') OR (category_arabic = '" + value + "'))  and ( AlwaysShow !='True' or AlwaysShow is null ) group by product_name order by product_id ";
                //string sql = "select * from purchase where  ( product_name like '" + value + "%' ) " +
                //" OR ( product_id like '" + value + "%' ) " +
                //" OR (category = '" + value + "')  ";

                DataTable dt = DataAccess.GetDataTable(sql);
                lblRows.Text = "Total Rows " + dt.Rows.Count.ToString() + " Found";

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button b = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = dataReader["product_id"];
                    b.Click += new EventHandler(b_Click);

                    string KitchenDisplay;
                    if (dataReader["status"].ToString() == "3")
                    {
                        KitchenDisplay = "YES";
                    }
                    else
                    {
                        KitchenDisplay = "NO";
                    }

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

                    string details =
                        "====================================" +
                        "\n ID: " + dataReader["product_id"] +
                        "\n Name: " + PROdName +// dataReader["product_name"].ToString() +
                        "\n Buy price: " + dataReader["msrp"].ToString() +
                        "\n Stock Qty: " + dataReader["OnHand"].ToString() +
                        "\n Retail price: " + dataReader["price"].ToString() +
                        "\n Discount: " + dataReader["Discount"].ToString() + "%" +
                        "\n Category: " + dataReader["category"].ToString() +
                        "\n Supplier: " + dataReader["supplier"].ToString() +
                        "\n Branch: " + dataReader["Shopid"].ToString() +
                        "\n Kitchen Display  : " + KitchenDisplay +
                        "\n ====================================";
                    b.Name = details;
                    toolTip1.ToolTipTitle = "Item Details";
                    toolTip1.AutoPopDelay = 32766;
                    toolTip1.SetToolTip(b, details);

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(70, 70);
                    string image = "item.png";
                    if (dataReader["Image"] != null && dataReader["Image"].ToString() != "")
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

                    b.Size = new Size(185, 90);
                    b.Text.PadRight(4);

                    b.Text += " " + dataReader["product_id"] + " - ";
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

                    b.Text += "\n Buy: " + dataReader["msrp"];
                    b.Text += "\n R.Price: " + dataReader["price"];

                    b.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    flowLayoutPanelUserList.Controls.Add(b);
                    currentImage++;
                }
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

            string MYPRODID = "0";
            if (comboItem.Text != "" && comboItem.Text != "System.Data.DataRowView")
            {
                string PRoductID = comboItem.Text.ToString().Trim().Split('-')[0];
                PRoductID = PRoductID.Trim();
                MYPRODID = PRoductID;
            }
            string RalatedProdID = s;

            string Q = "Select * from TblProductRelated where TenentID=" + Tenent.TenentID + " and MYPRODID = " + MYPRODID + " and RalatedProdID =" + RalatedProdID + " ";
            DataTable dt = DataAccess.GetDataTable(Q);

            if (dt.Rows.Count < 1)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlinsert = " Insert into TblProductRelated (TenentID,LOCATION_ID,MYPRODID,RalatedProdID,ACTIVE,Uploadby,UploadDate,SynID) values (" + Tenent.TenentID + ", " +
                               " 1," + MYPRODID + "," + RalatedProdID + ",'Y','" + UserInfo.UserName + "','" + UploadDate + "',1)";
                int flag1 = DataAccess.ExecuteSQL(sqlinsert);

                string sqlinsertWin = " Insert into Win_TblProductRelated (TenentID,LOCATION_ID,MYPRODID,RalatedProdID,ACTIVE,Uploadby,UploadDate,SynID) values (" + Tenent.TenentID + ", " +
                                   " 1," + MYPRODID + "," + RalatedProdID + ",'True' ,'" + UserInfo.UserName + "','" + UploadDate + "',1 )";
                Datasyncpso.insert_Live_sync(sqlinsertWin, "Win_TblProductRelated", "INSERT");

                string ActivityName = "Add Related Product";
                string LogData = "Add Related Product PRODUCT ID = " + MYPRODID + " and Related Product ID = " + RalatedProdID + " ";
                Login.InsertUserLog(ActivityName, LogData);

            }

            BindGrid();

        }

        //Product filter by Category
        private void combCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combCategory.Text != "" && combCategory.Text != "System.Data.DataRowView")
            {
                //BindITEM(combCategory.Text);
                BindGrid();
                ItemList_with_images(combCategory.SelectedValue.ToString());
            }

        }

        public string Get_First_Catagory()
        {
            string Catagory = "";

            string sql = "select * from  CAT_MST where TenentID = " + Tenent.TenentID + " order by CAT_NAME1";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                Catagory = dt.Rows[0]["CATID"].ToString();
            }
            return Catagory;

        }

        private void detail_info_Load(object sender, EventArgs e)
        {
            try
            {
                //Product Category  

                if (UserInfo.Language == "English")
                {
                    string sql5 = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " ";
                    DataTable dt5 = DataAccess.GetDataTable(sql5);
                    combCategory.DataSource = dt5;
                    combCategory.DisplayMember = "CAT_NAME1";
                    combCategory.ValueMember = "CATID";
                }
                else if (UserInfo.Language == "Arabic")
                {
                    string sql5 = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " ";
                    DataTable dt5 = DataAccess.GetDataTable(sql5);
                    combCategory.DataSource = dt5;
                    combCategory.DisplayMember = "CAT_NAME2";
                    combCategory.ValueMember = "CATID";
                }
                else
                {
                    string sql5 = "select * from CAT_MST where TenentID = " + Tenent.TenentID + " ";
                    DataTable dt5 = DataAccess.GetDataTable(sql5);
                    combCategory.DataSource = dt5;
                    combCategory.DisplayMember = "CAT_NAME1";
                    combCategory.ValueMember = "CATID";
                }

                if (combCategory.Text == "" || combCategory.Text == "System.Data.DataRowView")
                {
                    string Catagory = Get_First_Catagory();
                    ItemList_with_images(Catagory);
                }

                BindITEM();
                BindGrid();
                AlwaysShow_with_images();
            }
            catch
            {
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
            this.Hide();
            Import_Items go = new Import_Items();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Item go = new Add_Item();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void bntStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            Items.StockDetails go = new Items.StockDetails();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void btnpurchasehistory_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void detail_info_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ItemList_with_images("");
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCatProd();
        }

        public void BindCatProd()
        {
            if (comboItem.Text != "" && comboItem.Text != "System.Data.DataRowView")
            {
                if (combCategory.Text != "" && combCategory.Text != "System.Data.DataRowView")
                {
                    BindGrid();
                    ItemList_with_images(combCategory.SelectedValue.ToString());
                }
            }
        }

        private void btnCashierRefresh_Click(object sender, EventArgs e)
        {
            BindCatProd();
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

                        string sql = "select * from  TblProductRelated where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "' and AlwaysShow = 'True' ";
                        DataTable dt = DataAccess.GetDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            DialogResult result = MessageBox.Show("This Item Found In Always Show. Do You Wont To Delete It ??", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                string sqldel = " delete from TblProductRelated  where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "' ";
                                DataAccess.ExecuteSQL(sqldel);

                                string sqlUpdateWin = " Update Win_TblProductRelated set ACTIVE = 'False' ,  Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2 where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "'";
                                Datasyncpso.insert_Live_sync(sqlUpdateWin, "Win_TblProductRelated", "UPDATE");

                                string ActivityName = "Delete Releted Product";
                                string LogData = "Delete Related Product PRODUCT ID = " + MYPRODID + " and Related Product ID = " + RalatedProdID + "  ";
                                Login.InsertUserLog(ActivityName, LogData);
                            }
                        }
                        else
                        {
                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            string sqldel = " delete from TblProductRelated  where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "' ";
                            DataAccess.ExecuteSQL(sqldel);

                            string sqlUpdateWin = " Update Win_TblProductRelated set ACTIVE = 'False' ,  Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2 where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "'";
                            Datasyncpso.insert_Live_sync(sqlUpdateWin, "Win_TblProductRelated", "UPDATE");

                            string ActivityName = "Delete Releted Product";
                            string LogData = "Delete Related Product PRODUCT ID = " + MYPRODID + " and Related Product ID = " + RalatedProdID + "  ";
                            Login.InsertUserLog(ActivityName, LogData);
                        }

                    }
                    BindCatProd();
                }

                if (e.ColumnIndex == datagrdReportDetails.Columns["Add"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in datagrdReportDetails.SelectedRows)
                    {
                        double MYPRODID = Convert.ToDouble(rowdel.Cells["id"].Value);
                        int RalatedProdID = Convert.ToInt32(rowdel.Cells["rid"].Value);
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sqldel = " Update TblProductRelated set AlwaysShow = 'True' ,  Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2 where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "' ";
                        DataAccess.ExecuteSQL(sqldel);

                        string sqlUpdateWin = " Update Win_TblProductRelated set AlwaysShow = 'True' ,  Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2 where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "'";
                        Datasyncpso.insert_Live_sync(sqlUpdateWin, "Win_TblProductRelated", "UPDATE");

                        string ActivityName = "Add Always Show Product";
                        string LogData = "Add Always Show Product PRODUCT ID = " + RalatedProdID + "  ";
                        Login.InsertUserLog(ActivityName, LogData);

                    }
                    BindCatProd();
                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void dataGridAlwaysShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridAlwaysShow.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in dataGridAlwaysShow.SelectedRows)
                    {
                        double MYPRODID = Convert.ToDouble(rowdel.Cells["id"].Value);
                        int RalatedProdID = Convert.ToInt32(rowdel.Cells["rid"].Value);

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sqldel = "Update TblProductRelated set AlwaysShow = 'False' ,  Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "' ";
                        DataAccess.ExecuteSQL(sqldel);

                        string sqlUpdateWin = " Update Win_TblProductRelated set AlwaysShow = 'False', Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  where Tenentid=" + Tenent.TenentID + " and MYPRODID = '" + MYPRODID + "' and RalatedProdID='" + RalatedProdID + "'";
                        Datasyncpso.insert_Live_sync(sqlUpdateWin, "Win_TblProductRelated", "UPDATE");

                        string ActivityName = "Delete Always Show Product";
                        string LogData = "Delete Always Show Product PRODUCT ID = " + RalatedProdID + "  ";
                        Login.InsertUserLog(ActivityName, LogData);

                    }
                    BindCatProd();
                }
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }


    }
}
