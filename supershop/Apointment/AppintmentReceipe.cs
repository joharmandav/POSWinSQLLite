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
using System.Text.RegularExpressions;


namespace supershop
{
    public partial class AppintmentReceipe : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public AppintmentReceipe()
        {
            InitializeComponent();

            //datagrdReportDetails

            this.datagrdReportDetails.Columns.Add("ItemsName", "Input");
            this.datagrdReportDetails.Columns.Add("ReceipeType", "Receipe Type");
            this.datagrdReportDetails.Columns.Add("Price", "Cost Price");
            this.datagrdReportDetails.Columns.Add("QTY", "Qty");
            this.datagrdReportDetails.Columns.Add("Total", "Total");

            //Qty column row color
            datagrdReportDetails.Columns["QTY"].DefaultCellStyle.ForeColor = Color.Black;
            datagrdReportDetails.Columns["QTY"].DefaultCellStyle.BackColor = Color.Silver;
            datagrdReportDetails.Columns["QTY"].DefaultCellStyle.SelectionForeColor = Color.Black;
            datagrdReportDetails.Columns["QTY"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            datagrdReportDetails.Columns["QTY"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            datagrdReportDetails.Columns["QTY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdReportDetails.Columns["QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            datagrdReportDetails.Columns["ReceipeType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdReportDetails.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrdReportDetails.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            datagrdReportDetails.Columns["ItemsName"].ReadOnly = true;
            datagrdReportDetails.Columns["ReceipeType"].ReadOnly = true;
            //datagrdReportDetails.Columns["Price"].ReadOnly = true;
            datagrdReportDetails.Columns["Total"].ReadOnly = true;


            DataGridViewButtonColumn Assign = new DataGridViewButtonColumn();
            this.datagrdReportDetails.Columns.Add(Assign);
            Assign.HeaderText = "Action";
            Assign.Text = "Delete";
            Assign.Name = "Delete";
            Assign.ToolTipText = "Delete";
            Assign.UseColumnTextForButtonValue = true;
            Assign.Width = 70;

        }

        bool FirstTime;
        private void AppintmentReceipe_Load(object sender, EventArgs e)
        {
            try
            {
                //Product Category  
                FirstTime = true;
                bindCatagories();

                if (combCategory.Text == "All Category")
                {
                    ItemList("");
                }

                if (combCategory.Text == "" || combCategory.Text == "System.Data.DataRowView")
                {
                    string Catagory = Get_First_Catagory();
                    ItemList(Catagory);
                }

                if (lblJobID.Text != "-")
                {
                    int JobID = Convert.ToInt32(lblJobID.Text);
                    BindEdit(JobID);
                }

                FirstTime = false;
            }
            catch
            {
            }
        }

        public string In_AppointmentID
        {
            set
            {
                lblAppointmentID.Text = value;
            }
        }

        public string in_JobID
        {
            set
            {
                lblJobID.Text = value;
            }
        }

        public string selectCatagory
        {
            set
            {
                combCategory.Text = value;
            }
        }

        #region Data bind
        //Show Products image

        public void ItemList(string Value)
        {
            string Sql = "";
            if (Value == "")
            {
                Sql = " SELECT (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic || ' - ' || ICUOM.UOMNAME1) as Items , tbl_item_uom_price.RecipeType , tbl_item_uom_price.price as 'Price', tbl_item_uom_price.msrp as 'msrp' " +
                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID " +
                      " where purchase.TenentID = " + Tenent.TenentID + " order by product_id ";
            }
            else
            {
                Sql = " SELECT (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic || ' - ' || ICUOM.UOMNAME1) as Items , tbl_item_uom_price.RecipeType , tbl_item_uom_price.price as 'Price', tbl_item_uom_price.msrp as 'msrp' " +
                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                      " INNER JOIN CAT_MST ON  purchase.category = CAT_MST.CATID and purchase.TenentID = CAT_MST.TenentID INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID " +
                      " where purchase.TenentID = " + Tenent.TenentID + " and ((CAT_MST.CAT_NAME1 = '" + Value + "') OR (category_arabic = '" + Value + "')) order by product_id ";
            }

            DataTable dt = DataAccess.GetDataTable(Sql);
            dataGridItems.DataSource = dt;
            dataGridItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridItems.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridItems.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        //Product filter by Category
        private void combCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstTime == false)
            {
                if (combCategory.Text == "All Category")
                {
                    ItemList("");
                    txtSearchItem.Text = "";
                }

                if (combCategory.Text != "" && combCategory.Text != "System.Data.DataRowView" && combCategory.Text != "All Category")
                {
                    ItemList(combCategory.Text);
                    txtSearchItem.Text = "";
                }
            }
        }

        public string Get_First_Catagory()
        {
            string Catagory = "";

            if (UserInfo.Language == "English")
            {
                string sql = "select DISTINCT CAT_NAME1 from  CAT_MST where TenentID = " + Tenent.TenentID + " order by CAT_NAME1";
                DataAccess.ExecuteSQL(sql);
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    Catagory = dt.Rows[0]["CAT_NAME1"].ToString();
                }
                return Catagory;
            }
            else if (UserInfo.Language == "Arabic")
            {
                string sql = "select DISTINCT CAT_NAME2 from  CAT_MST where TenentID = " + Tenent.TenentID + " order by CAT_NAME2";
                DataAccess.ExecuteSQL(sql);
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    Catagory = dt.Rows[0]["CAT_NAME2"].ToString();
                }
                return Catagory;
            }
            else
            {
                string sql = "select DISTINCT CAT_NAME1 from  CAT_MST where TenentID = " + Tenent.TenentID + " order by CAT_NAME1";
                DataAccess.ExecuteSQL(sql);
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    Catagory = dt.Rows[0]["CAT_NAME1"].ToString();
                }
                return Catagory;
            }
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchItem.Text != "")
            {
                ItemListSearch(txtSearchItem.Text);
            }
        }

        public void ItemListSearch(string Value)
        {
            if (combCategory.Text != "" && combCategory.Text != "System.Data.DataRowView")
            {
                string Sql = " SELECT (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic || ' - ' || ICUOM.UOMNAME1) as Items , tbl_item_uom_price.RecipeType , tbl_item_uom_price.price as 'Price', tbl_item_uom_price.msrp as 'msrp' " +
                             " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID  " +
                             " where purchase.TenentID = " + Tenent.TenentID + " and ( product_id like '%" + Value + "%' OR RecipeType like '%" + Value + "%'  OR UOMID like '%" + Value + "%' OR ((product_name like '%" + Value + "%') OR (product_name_Arabic like '%" + Value + "%')))  order by product_id ";

                DataTable dt = DataAccess.GetDataTable(Sql);
                dataGridItems.DataSource = dt;
                dataGridItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridItems.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridItems.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }
        #endregion


        public void bindCatagories()
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
            combCategory.Text = "All Category";

        }

        private void picCloseEvent_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // toolbar 
        private void lblMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   //Minimized              
        }

        private void AppintmentReceipe_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ItemList("");
        }

        public void BindEdit(int JobID)
        {
            datagrdReportDetails.Rows.Clear();

            bool Falg = CheckReceipeExist(JobID);

            if (Falg == true)
            {
                string StrInput = " SELECT (pi.product_id || ' - ' ||pi.product_name || ' - ' || pi.product_name_Arabic || ' - ' || IC.UOMNAME1 ) as Items, " +
                                  " ar.Qty as Qty , ar.CostPrice as 'Price', iup.RecipeType, ar.recNo as recNo " +
                                  " FROM  purchase pi  Inner Join AppointmentReceipe ar on pi.product_id = ar.ItemCode and pi.TenentID = ar.TenentID " +
                                  " Inner Join ICUOM IC on  ar.UOM = IC.UOM and ar.TenentID = IC.TenentID " +
                                  " Inner Join tbl_item_uom_price iup On iup.itemID = ar.ItemCode and iup.UOMID = ar.UOM  and iup.TenentID = ar.TenentID " +
                                  " where ar.TenentID = " + Tenent.TenentID + "  and ar.JobID = " + JobID + "  and ar.IOSwitch = 'Input' ";
               
                DataTable dtInput = DataAccess.GetDataTable(StrInput);

                for (int i = 0; i < dtInput.Rows.Count; i++)
                {
                    string Items = dtInput.Rows[i]["Items"].ToString();
                    string Qty = dtInput.Rows[i]["Qty"].ToString() == "0" ? "0" : dtInput.Rows[i]["Qty"].ToString();
                    string Price = dtInput.Rows[i]["Price"].ToString() == "0" ? "0" : dtInput.Rows[i]["Price"].ToString();
                    double DQty = Convert.ToDouble(Qty);
                    double DPrice = Convert.ToDouble(Price);
                    double TOTAL = DQty * DPrice;
                    string ReceipeType = dtInput.Rows[i]["RecipeType"].ToString();

                    datagrdReportDetails.Rows.Add(Items, ReceipeType, Price, Qty, TOTAL);
                    datagrdReportDetails.Columns["QTY"].Width = 50;
                    //datagrdReportDetails.Columns["percentage"].Width = 70;
                    datagrdReportDetails.Columns["Delete"].Width = 70;
                }

                lblRecNO.Text = dtInput.Rows[0]["recNo"] != null && dtInput.Rows[0]["recNo"].ToString() != "" ? dtInput.Rows[0]["recNo"].ToString() : "-";

                btnSave.Text = "Update";
                GetPriceTotal();
            }
            else
            {
                datagrdReportDetails.Rows.Clear();

                btnSave.Text = "Save";
                GetPriceTotal();
            }

        }

        public void GetPriceTotal()
        {

            double inputtotal = 0;
            for (int i = 0; i < datagrdReportDetails.Rows.Count; i++)
            {
                inputtotal += Convert.ToDouble(datagrdReportDetails.Rows[i].Cells["Total"].Value.ToString());
            }
            lblinputTotal.Text = inputtotal.ToString();

        }

        public bool CheckReceipeExist(int JobID)
        {
            string Str = "select * from AppointmentReceipe Where TenentID = " + Tenent.TenentID + " and JobID = " + JobID + "; ";
            DataTable dt = DataAccess.GetDataTable(Str);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BindCatProd()
        {
            if (combCategory.Text == "All Category")
            {
                ItemList("");
                txtSearchItem.Text = "";
            }

            if (combCategory.Text != "" && combCategory.Text != "System.Data.DataRowView" && combCategory.Text != "All Category")
            {
                ItemList(combCategory.Text);
                txtSearchItem.Text = "";
            }
        }

        private void btnCashierRefresh_Click(object sender, EventArgs e)
        {
            BindCatProd();
        }

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;

        private void dataGridItems_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dataGridItems.DoDragDrop(dataGridItems.Rows[rowIndexFromMouseDown], DragDropEffects.Copy);
                }
            }
        }

        private void dataGridItems_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = dataGridItems.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
            {
                dragBoxFromMouseDown = Rectangle.Empty;
            }

        }

        private void datagrdReportDetails_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void datagrdReportDetails_DragDrop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(DataRowView)))
            //{
            Point clientPoint = datagrdReportDetails.PointToClient(new Point(e.X, e.Y));

            if (e.Effect == DragDropEffects.Copy)
            {
                DataGridViewRow Row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                string ItemsName = Row.Cells["Items"].Value.ToString();
                string ReceipeType = Row.Cells["RecipeType"].Value.ToString();
                string Price = Row.Cells["Price"].Value.ToString();
                int n = Finditem1(ItemsName);
                if (n == -1)  //If new item
                {
                    datagrdReportDetails.Rows.Add(ItemsName, ReceipeType, Price, 1, Price);
                }
                GetPriceTotal();
            }
            //}
        }

        public int Finditem1(string item)
        {
            int k = -1;
            if (datagrdReportDetails.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in datagrdReportDetails.Rows)
                {
                    if (row.Cells["ItemsName"].Value.ToString().Equals(item))
                    {
                        k = row.Index;
                        break;
                    }
                }
            }
            return k;
        }

        private void datagrdReportDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == datagrdReportDetails.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in datagrdReportDetails.SelectedRows)
                    {
                        datagrdReportDetails.Rows.Remove(rowdel);
                    }
                    GetPriceTotal();
                }

            }
            catch
            {

            }
        }

        public void DeleteInput(int JobID)
        {
            string sql = "select * from AppointmentReceipe where TenentID= " + Tenent.TenentID + " and IOSwitch = 'Input' and JobID = '" + JobID + "'; ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                string sqldel = " delete from AppointmentReceipe  where TenentID= " + Tenent.TenentID + " and IOSwitch = 'Input' and JobID = '" + JobID + "' ";
                DataAccess.ExecuteSQL(sqldel);

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlUpdateCmdWIN = " delete from AppointmentReceipe where TenentID= " + Tenent.TenentID + " and IOSwitch = 'Input' and JobID = '" + JobID + "' ";
                Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "AppointmentReceipe", "DELETE");

            }
        }

        public static string Get_CostPrice(int TenentID, double PID, int UOM)
        {
            string sql = "select * from tbl_item_uom_price where TenentID = " + TenentID + " and itemID = " + PID + " and UOMID = " + UOM + " ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["price"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }

        public static string Get_MSRT(int TenentID, double PID, int UOM)
        {
            string sql = "select * from tbl_item_uom_price where TenentID = " + TenentID + " and itemID = " + PID + " and UOMID = " + UOM + " ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["msrp"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string SaveQty = "";

            bool Falginput = Check_inputDataQty();
            if (Falginput == false)
            {
                return;
            }

            int JobID = Convert.ToInt32(lblJobID.Text);

            DeleteInput(JobID);

            int length = datagrdReportDetails.RowCount;
            for (int i = 0; i < length; i++)
            {
                string IOSwitch = "Input";

                string InputValye = datagrdReportDetails.Rows[i].Cells["ItemsName"].Value.ToString().Trim();
                string InputItemCode = InputValye.Split('-')[0].Trim();

                
                string CostPrice = datagrdReportDetails.Rows[i].Cells["Price"].Value.ToString().Trim();

                double ItemCode = Convert.ToDouble(InputItemCode);
                string ItemName = Add_Job.getItemName(ItemCode);
                string TypeofProduct = Add_Job.getTypeOfProcuct(ItemCode);//Commission Yogesh
                string inputUOM = InputValye.Split('-')[3].Trim();
                string UOMName = inputUOM;
                int UOMID = Add_Item.getuomID(UOMName);

                string msrp = Get_MSRT(Tenent.TenentID, ItemCode, UOMID);

                double Qty = 0, aCostPrice = 0, QtyIntoCostprice=0;
                decimal Perc = 0;

                string InputQtyVal = datagrdReportDetails.Rows[i].Cells["QTY"].Value.ToString().Trim();
                double Value = Convert.ToDouble(InputQtyVal);
                Qty = Value;
                aCostPrice = Convert.ToDouble(CostPrice);
                QtyIntoCostprice = Qty * aCostPrice;
                int LocationID = 1;
                int AppointmentID = Convert.ToInt32(lblAppointmentID.Text);
                int recNo =lblRecNO.Text.Trim()=="-"? 0:Convert.ToInt32(lblRecNO.Text);

                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc,Uploadby,UploadDate,SynID

                string sql = "select * from AppointmentReceipe where TenentID= " + Tenent.TenentID + " and JobID = '" + JobID + "' and IOSwitch = '" + IOSwitch + "' and ItemCode = '" + ItemCode + "' and  UOM = '" + UOMID + "' ; ";
                DataTable dt = DataAccess.GetDataTable(sql);


                if (dt.Rows.Count < 1)
                {
                    

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string Uploadby = UserInfo.UserName;

                    string sql1 = " insert into AppointmentReceipe (TenentID, LocationID, AppointmentID, JobID, IOSwitch, ItemCode, UOM, Qty,  CostPrice, msrp,recNo,  UploadDate, Uploadby, SynID, product_name, RecipeType, EmpOperator,QtyIntoCostprice) " +
                                  " values (" + Tenent.TenentID + ",'" + LocationID + "', '" + AppointmentID + "','" + JobID + "','" + IOSwitch + "' , '" + ItemCode + "', " +
                                  " '" + UOMID + "','" + Qty + "','" + CostPrice + "','" + msrp + "', '" + recNo + "', '" + UploadDate + "','" + Uploadby + "', 1 ,'" + ItemName + "','" + TypeofProduct + "','" + GetEmpOperator(JobID) + "','" + QtyIntoCostprice + "') ";
                    int flag1 = DataAccess.ExecuteSQL(sql1);
                    Datasyncpso.insert_Live_sync(sql1, "AppointmentReceipe", "INSERT");
                }
                else
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sqlCmd = " Update AppointmentReceipe set Qty = '" + Qty + "' , CostPrice = '" + CostPrice + "' , msrp = '" + msrp + "' , Uploadby = '" + UserInfo.UserName + "',UploadDate = '" + UploadDate + "',SynID = 2 ,QtyIntoCostprice = '" + QtyIntoCostprice + "' " +
                                           " Where TenentID= " + Tenent.TenentID + " and LocationID = " + LocationID + " and AppointmentID = " + AppointmentID + " and JobID = '" + JobID + "' and IOSwitch = '" + IOSwitch + "' and ItemCode = '" + ItemCode + "' and  UOM = '" + UOMID + "' ";
                    DataAccess.ExecuteSQL(sqlCmd);
                    Datasyncpso.insert_Live_sync(sqlCmd, "AppointmentReceipe", "UPDATE");
                }
            }


            ClearGrid();

        }
        public static string GetEmpOperator(int JobID)
        {
            string q1 = "select USERNAME from CRMActivities where MasterCode=" + JobID + "";
            DataTable dtq1 = DataAccess.GetDataTable(q1);
            string EmpOperator = "";
            if (dtq1.Rows.Count > 0)
            {
                EmpOperator = dtq1.Rows[0]["USERNAME"].ToString();
            }
            return EmpOperator;
        }

        public void ClearGrid()
        {
            datagrdReportDetails.Rows.Clear();
            btnSave.Text = "Save";
            txtSearchItem.Text = "";
            this.Close();
        }

        public bool Check_inputDataQty()
        {
            int length = datagrdReportDetails.RowCount;

            if (length != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    string StrVal = datagrdReportDetails.Rows[i].Cells["QTY"].Value != null && datagrdReportDetails.Rows[i].Cells["QTY"].Value != "" ? datagrdReportDetails.Rows[i].Cells["QTY"].Value.ToString() : "";
                    if (StrVal != "" && StrVal != "0")
                    {
                        try
                        {
                            decimal qty = Convert.ToDecimal(StrVal);
                        }
                        catch
                        {
                            int RowNO = i + 1;
                            MessageBox.Show("Provide a Correct numeric value at Row  " + RowNO + " in input Item");
                            return false;
                        }
                    }
                    else
                    {
                        int RowNO = i + 1;
                        MessageBox.Show("Enter Some Qty in Row No " + RowNO + "  input Item");
                        return false;
                    }
                }

                return true;
            }
            else
            {
                MessageBox.Show("Enter Some input Item");
                return false;
            }
        }

        private void datagrdReportDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            changeintputQtypriceEfact(sender, e);
        }

        private void datagrdReportDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            changeintputQtypriceEfact(sender, e);
        }

        public void changeintputQtypriceEfact(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == datagrdReportDetails.Columns["QTY"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in datagrdReportDetails.SelectedRows)
                    {
                        double QTY = Convert.ToDouble(row.Cells["QTY"].Value);
                        double Price = Convert.ToDouble(row.Cells["Price"].Value);
                        double Total = QTY * Price;
                        row.Cells["Total"].Value = Total;
                    }
                    GetPriceTotal();
                }
            }
            catch
            {
                MessageBox.Show("Enter Valid QTY");
                return;
            }

            try
            {
                if (e.ColumnIndex == datagrdReportDetails.Columns["Price"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in datagrdReportDetails.SelectedRows)
                    {
                        double QTY = Convert.ToDouble(row.Cells["QTY"].Value);
                        double Price = Convert.ToDouble(row.Cells["Price"].Value);
                        double Total = QTY * Price;
                        row.Cells["Total"].Value = Total;
                    }
                    GetPriceTotal();
                }
            }
            catch
            {
                MessageBox.Show("Enter Valid MSRP ");
                return;
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
            go.PageName = "AppintmentReceipe";
            go.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
