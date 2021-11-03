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
    public partial class ReceipeMenegement : Form
    {
        ResourceManager res_man;
        // ResourceManager res_man1; // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public ReceipeMenegement()
        {
            InitializeComponent();

            //datagrdReportDetails

            this.datagrdReportDetails.Columns.Add("ItemsName", "Input");
            this.datagrdReportDetails.Columns.Add("ReceipeType", "Receipe Type");
            this.datagrdReportDetails.Columns.Add("Price", "Cost Price");
            this.datagrdReportDetails.Columns.Add("QTY", "Qty");
            this.datagrdReportDetails.Columns.Add("Total", "Total");
            //this.datagrdReportDetails.Columns.Add("percentage", "%");

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

            //percentage column row color
            //datagrdReportDetails.Columns["percentage"].DefaultCellStyle.ForeColor = Color.Black;
            //datagrdReportDetails.Columns["percentage"].DefaultCellStyle.BackColor = Color.Silver;
            //datagrdReportDetails.Columns["percentage"].DefaultCellStyle.SelectionForeColor = Color.Black;
            //datagrdReportDetails.Columns["percentage"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            //datagrdReportDetails.Columns["percentage"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            //datagrdReportDetails.Columns["percentage"].Width = 70;
            //datagrdReportDetails.Columns["percentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

            //dataGridAlwaysShow

            this.dataGridAlwaysShow.Columns.Add("ItemsName", "OutPut");
            this.dataGridAlwaysShow.Columns.Add("ReceipeType", "Receipe Type");
            this.dataGridAlwaysShow.Columns.Add("Price", "MSRP");
            this.dataGridAlwaysShow.Columns.Add("QTY", "Qty");
            this.dataGridAlwaysShow.Columns.Add("Total", "Total");
            //this.dataGridAlwaysShow.Columns.Add("percentage", "%");

            //Qty column row color
            dataGridAlwaysShow.Columns["QTY"].DefaultCellStyle.ForeColor = Color.Black;
            dataGridAlwaysShow.Columns["QTY"].DefaultCellStyle.BackColor = Color.Silver;
            dataGridAlwaysShow.Columns["QTY"].DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridAlwaysShow.Columns["QTY"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridAlwaysShow.Columns["QTY"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dataGridAlwaysShow.Columns["QTY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridAlwaysShow.Columns["QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridAlwaysShow.Columns["ReceipeType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridAlwaysShow.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridAlwaysShow.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //percentage column row color
            //dataGridAlwaysShow.Columns["percentage"].DefaultCellStyle.ForeColor = Color.Black;
            //dataGridAlwaysShow.Columns["percentage"].DefaultCellStyle.BackColor = Color.Silver;
            //dataGridAlwaysShow.Columns["percentage"].DefaultCellStyle.SelectionForeColor = Color.Black;
            //dataGridAlwaysShow.Columns["percentage"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            //dataGridAlwaysShow.Columns["percentage"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            //dataGridAlwaysShow.Columns["percentage"].Width = 70;
            //dataGridAlwaysShow.Columns["percentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridAlwaysShow.Columns["ItemsName"].ReadOnly = true;
            dataGridAlwaysShow.Columns["ReceipeType"].ReadOnly = true;
            //dataGridAlwaysShow.Columns["Price"].ReadOnly = true;
            dataGridAlwaysShow.Columns["Total"].ReadOnly = true;


            DataGridViewButtonColumn Delete = new DataGridViewButtonColumn();
            this.dataGridAlwaysShow.Columns.Add(Delete);
            Delete.HeaderText = "Action";
            Delete.Text = "Delete";
            Delete.Name = "Delete";
            Delete.ToolTipText = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            Delete.Width = 70;
        }

        public string ServiceTemplate
        {
            set
            {
                comboReceipe.Text = value;
            }
            get
            {
                return comboReceipe.Text;
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

        public void BindReceipe(string RecType)
        {
            string sql = "SELECT  (recNo || ' - ' ||Receipe_English || ' - ' || Receipe_Arabic) as Receipe    FROM tbl_Receipe where TenentID = " + Tenent.TenentID + " and RecType = '" + RecType + "' ";

            DataAccess.ExecuteSQL(sql);
            DataTable dt = DataAccess.GetDataTable(sql);
            //comboReceipe.DataSource = dt;
            //comboReceipe.DisplayMember = "Receipe";

            comboReceipe.Items.Clear();

            comboReceipe.Items.Add("---- select Receipe ----");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboReceipe.Items.Add(dt.Rows[i][0]);
                }
            }
            comboReceipe.Text = "---- select Receipe ----";

        }

        public void ItemList(string Value)
        {
            string Sql = "";
            if (Value == "")
            {
                Sql = " SELECT (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic || ' - ' || ICUOM.UOMNAME1) as Items , RecipeType , tbl_item_uom_price.price as 'Price', tbl_item_uom_price.msrp as 'msrp' " +
                      " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID " +
                      " where purchase.TenentID = " + Tenent.TenentID + " order by product_id ";
            }
            else
            {
                Sql = " SELECT (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic || ' - ' || ICUOM.UOMNAME1) as Items , RecipeType , tbl_item_uom_price.price as 'Price', tbl_item_uom_price.msrp as 'msrp' " +
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
                string Sql = " SELECT (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic || ' - ' || ICUOM.UOMNAME1) as Items , RecipeType , tbl_item_uom_price.price as 'Price', tbl_item_uom_price.msrp as 'msrp' " +
                             " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID INNER JOIN ICUOM ON tbl_item_uom_price.UOMID = ICUOM.UOM and tbl_item_uom_price.TenentID = ICUOM.TenentID  " +
                             " where purchase.TenentID = " + Tenent.TenentID + " and ( product_id like '%" + Value + "%' OR RecipeType like '%" + Value + "%'  OR UOMID like '%" + Value + "%' OR ((product_name like '%" + Value + "%') OR (product_name_Arabic like '%" + Value + "%')))  order by product_id ";

                DataTable dt = DataAccess.GetDataTable(Sql);
                dataGridItems.DataSource = dt;
                dataGridItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridItems.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridItems.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        bool FirstTime;
        private void ReceipeMenegement_Load(object sender, EventArgs e)
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

                BindReceipe(cmbRectype.Text);
                FirstTime = false;
            }
            catch
            {
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
            ItemList("");
        }

        private void comboReceipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboReceipe.Text != "" && comboReceipe.Text != "System.Data.DataRowView" && comboReceipe.Text != "---- select Receipe ----")
            {
                string RecValye = comboReceipe.Text.Trim();

                string recVanno = RecValye.Split('-')[0].Trim();

                int recNo = Convert.ToInt32(recVanno);
                ComplateTime(recNo);
                BindEdit(recNo);
            }
            else
            {
                ClearGrid();
            }

        }

        public void ComplateTime(int recNo)
        {
            int Time = getTotalMinuteForReceipe(recNo);

            int totalMinute = Time;
            int Minute = 0;
            int Hour = 0;

            totalMinute = totalMinute % 1440;
            Hour = totalMinute / 60;
            Minute = totalMinute % 60;

            lblComplateTime.Text = FormatTwoDigits(Hour) + " Hour and  " + FormatTwoDigits(Minute) + " Minute  ";

        }

        public static int getTotalMinuteForReceipe(int recNo)
        {
            int Time = 0;
            string Str = "select * from tbl_Receipe Where TenentID = " + Tenent.TenentID + " and recNo = " + recNo + " and HourToComplate is not null ; ";
            DataTable dt = DataAccess.GetDataTable(Str);
            if (dt.Rows.Count > 0)
            {
                Time = Convert.ToInt32(dt.Rows[0]["HourToComplate"]);
            }
            return Time;
        }

        private static string FormatTwoDigits(Int32 i)
        {
            string functionReturnValue = null;
            if (10 > i)
            {
                functionReturnValue = "0" + i.ToString();
            }
            else
            {
                functionReturnValue = i.ToString();
            }
            return functionReturnValue;
        }

        public void BindEdit(int recNo)
        {
            datagrdReportDetails.Rows.Clear();
            dataGridAlwaysShow.Rows.Clear();

            bool Falg = CheckReceipeExist(recNo);

            if (Falg == true)
            {
                string StrInput = " SELECT (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic || ' - ' || ICUOM.UOMNAME1 ) as Items, " +
                                  " Receipe_Menegement.Qty , Receipe_Menegement.Perc as Perc , Receipe_Menegement.CostPrice as 'Price' , RecipeType " +
                                  " FROM  purchase " +
                                  " Inner Join Receipe_Menegement on purchase.product_id = Receipe_Menegement.ItemCode and purchase.TenentID = Receipe_Menegement.TenentID " +
                                  " Inner Join ICUOM on  Receipe_Menegement.UOM = ICUOM.UOM and Receipe_Menegement.TenentID = ICUOM.TenentID " +
                                  " Inner Join tbl_item_uom_price On tbl_item_uom_price.itemID = Receipe_Menegement.ItemCode and tbl_item_uom_price.UOMID = Receipe_Menegement.UOM and tbl_item_uom_price.TenentID = Receipe_Menegement.TenentID " +
                                  " where Receipe_Menegement.TenentID = " + Tenent.TenentID + " and product_id = Receipe_Menegement.ItemCode and Receipe_Menegement.recNo = " + recNo + " " +
                                  " and Receipe_Menegement.IOSwitch = 'Input' ";
                DataTable dtInput = DataAccess.GetDataTable(StrInput);

                for (int i = 0; i < dtInput.Rows.Count; i++)
                {
                    string Items = dtInput.Rows[i][0].ToString();
                    string Qty = dtInput.Rows[i][1].ToString() == "0" ? "0" : dtInput.Rows[i][1].ToString();
                    string Perc = dtInput.Rows[i][2].ToString() == "0" ? "0" : dtInput.Rows[i][2].ToString();
                    string Price = dtInput.Rows[i][3].ToString() == "0" ? "0" : dtInput.Rows[i][3].ToString();
                    double DQty = Convert.ToDouble(Qty);
                    double DPrice = Convert.ToDouble(Price);
                    double TOTAL = DQty * DPrice;
                    string ReceipeType = dtInput.Rows[i][4].ToString();

                    datagrdReportDetails.Rows.Add(Items, ReceipeType, Price, Qty, TOTAL);
                    datagrdReportDetails.Columns["QTY"].Width = 50;
                    //datagrdReportDetails.Columns["percentage"].Width = 70;
                    datagrdReportDetails.Columns["Delete"].Width = 70;
                }

                string StrOutput = " SELECT (product_id || ' - ' ||product_name || ' - ' || product_name_Arabic || ' - ' || ICUOM.UOMNAME1 ) as Items, " +
                                   " Receipe_Menegement.Qty , Receipe_Menegement.Perc as Perc , Receipe_Menegement.msrp as 'Price' , RecipeType " +
                                   " FROM  purchase " +
                                   " Inner Join Receipe_Menegement on purchase.product_id = Receipe_Menegement.ItemCode and purchase.TenentID = Receipe_Menegement.TenentID " +
                                   " Inner Join ICUOM on  Receipe_Menegement.UOM = ICUOM.UOM and Receipe_Menegement.TenentID = ICUOM.TenentID " +
                                   " Inner Join tbl_item_uom_price On tbl_item_uom_price.itemID = Receipe_Menegement.ItemCode and tbl_item_uom_price.UOMID = Receipe_Menegement.UOM and tbl_item_uom_price.TenentID = Receipe_Menegement.TenentID " +
                                   " where  Receipe_Menegement.TenentID = " + Tenent.TenentID + " and  product_id = Receipe_Menegement.ItemCode and Receipe_Menegement.recNo = " + recNo + " " +
                                   " and Receipe_Menegement.IOSwitch = 'Output' ";
                DataTable dtOutput = DataAccess.GetDataTable(StrOutput);

                for (int i = 0; i < dtOutput.Rows.Count; i++)
                {
                    string Items = dtOutput.Rows[i][0].ToString();
                    string Qty = dtOutput.Rows[i][1].ToString() == "0" ? "0" : dtOutput.Rows[i][1].ToString();
                    string Perc = dtOutput.Rows[i][2].ToString() == "0" ? "0" : dtOutput.Rows[i][2].ToString();
                    string msrp = dtOutput.Rows[i][3].ToString() == "0" ? "0" : dtOutput.Rows[i][3].ToString();
                    double DQty = Convert.ToDouble(Qty);
                    double Dmsrp = Convert.ToDouble(msrp);
                    double TOTAL = DQty * Dmsrp;
                    string ReceipeType = dtOutput.Rows[i][4].ToString();

                    dataGridAlwaysShow.Rows.Add(Items, ReceipeType, msrp, Qty, TOTAL);
                    dataGridAlwaysShow.Columns["QTY"].Width = 50;
                    //dataGridAlwaysShow.Columns["percentage"].Width = 70;
                    dataGridAlwaysShow.Columns["Delete"].Width = 70;
                }

                cmbRectype.Enabled = false;
                btnSave.Text = "Update";
                btnDelete.Visible = true;
                GetPriceTotal();
            }
            else
            {
                datagrdReportDetails.Rows.Clear();
                dataGridAlwaysShow.Rows.Clear();

                cmbRectype.Enabled = false;
                btnSave.Text = "Save";
                btnDelete.Visible = false;
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

            double outputtotal = 0;
            for (int i = 0; i < dataGridAlwaysShow.Rows.Count; i++)
            {
                outputtotal += Convert.ToDouble(dataGridAlwaysShow.Rows[i].Cells["Total"].Value.ToString());
            }
            lbloutputTotal.Text = outputtotal.ToString();

        }

        public bool CheckReceipeExist(int recNo)
        {
            string Str = "select * from Receipe_Menegement Where TenentID = " + Tenent.TenentID + " and recNo = " + recNo + "; ";
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

        private void btnRefreshReceipe_Click(object sender, EventArgs e)
        {
            BindReceipe(cmbRectype.Text);
        }

        private void AddNewReceipe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Add_Receipe"] != null)
            {
                Application.OpenForms["Add_Receipe"].Close();
            }
            Items.Add_Receipe go = new Items.Add_Receipe();
            go.Show();
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

        private void dataGridAlwaysShow_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridAlwaysShow_DragDrop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(DataRowView)))
            //{
            if (comboReceipe.Text == "" || comboReceipe.Text == "System.Data.DataRowView" || comboReceipe.Text == "---- select Receipe ----")
            {
                MessageBox.Show("please select Receipe");
                return;
            }
            Point clientPoint = dataGridAlwaysShow.PointToClient(new Point(e.X, e.Y));

            if (e.Effect == DragDropEffects.Copy)
            {
                DataGridViewRow Row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                string ItemsName = Row.Cells["Items"].Value.ToString();
                string ReceipeType = Row.Cells["RecipeType"].Value.ToString();
                string MSRP = Row.Cells["msrp"].Value.ToString();

                int K = FindOutputItem(ItemsName);
                if (K == 1)
                {
                    int n = Finditem(ItemsName);
                    if (n == -1)  //If new item
                    {
                        dataGridAlwaysShow.Rows.Add(ItemsName, ReceipeType, MSRP, 1, MSRP);
                    }
                    GetPriceTotal();
                }
            }

            //}
        }

        public int Finditem(string item)
        {
            int k = -1;
            if (dataGridAlwaysShow.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridAlwaysShow.Rows)
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

        public int FindOutputItem(string item)
        {
            int k = -1;

            string ItemCode = item.Split('-')[0].ToString().Trim();
            string UOM = item.Split('-')[3].ToString().Trim();
            int UOMID = Add_Item.getuomID(UOM);
            string sql3 = "select * from tbl_item_uom_price where TenentID=" + Tenent.TenentID + " and itemID = '" + ItemCode + "' and UOMID ='" + UOMID + "' and ( RecipeType ='Output' or RecipeType = 'Service') ";
            // select * from tbl_item_uom_price where TenentID=9000007 and itemID = 1 and UOMID = 'Small' and RecipeType ='Output'
            DataAccess.ExecuteSQL(sql3);
            DataTable dt3 = DataAccess.GetDataTable(sql3);
            if (dt3.Rows.Count > 0)
            {
                k = 1;
            }
            return k;
        }

        private void datagrdReportDetails_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void datagrdReportDetails_DragDrop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(DataRowView)))
            //{
            if (comboReceipe.Text == "" || comboReceipe.Text == "System.Data.DataRowView" || comboReceipe.Text == "---- select Receipe ----")
            {
                MessageBox.Show("please select Receipe");
                return;
            }
            Point clientPoint = datagrdReportDetails.PointToClient(new Point(e.X, e.Y));

            if (e.Effect == DragDropEffects.Copy)
            {
                DataGridViewRow Row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));


                string ItemsName = Row.Cells["Items"].Value.ToString();
                string ReceipeType = Row.Cells["RecipeType"].Value.ToString();
                double InputQty = 1;
                double InputPrice = Convert.ToDouble(Row.Cells["Price"].Value.ToString());
                double OutputTotal = Convert.ToDouble(lbloutputTotal.Text);
                double InputCostPrice = 0;
                if (ReceipeType == "Commission")//yogesh
                {
                    InputQty = 10;
                    int length1 = dataGridAlwaysShow.RowCount;
                    if (length1 >= 1)
                    {
                        int n = Finditem1(ItemsName);
                        if (n == -1)  //If new item
                        {
                            //Yogesh 

                            InputPrice = (InputQty * OutputTotal) / 100;
                            InputCostPrice = InputPrice / InputQty;
                            datagrdReportDetails.Rows.Add(ItemsName, ReceipeType, InputCostPrice, InputQty, InputPrice);
                        }
                        GetPriceTotal();
                    }
                    else
                    {
                        MessageBox.Show("Kindly please place one output item first to calculate the Commission.");
                        return;
                    }

                }
                else
                {
                    int n = Finditem1(ItemsName);
                    if (n == -1)  //If new item
                    {
                        datagrdReportDetails.Rows.Add(ItemsName, ReceipeType, InputPrice, InputQty, InputPrice);
                    }
                    GetPriceTotal();
                }

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
                if (comboReceipe.Text == "" || comboReceipe.Text == "System.Data.DataRowView" || comboReceipe.Text == "---- select Receipe ----")
                {
                    MessageBox.Show("please select Receipe");
                    return;
                }


                if (e.ColumnIndex == datagrdReportDetails.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in datagrdReportDetails.SelectedRows)
                    {
                        string RecValye = comboReceipe.Text.Trim();

                        string recVanno = RecValye.Split('-')[0].Trim();

                        int recNo = Convert.ToInt32(recVanno);

                        string InputValye = rowdel.Cells["ItemsName"].Value.ToString().Trim();
                        string InputItemCode = InputValye.Split('-')[0].Trim();

                        double ItemCode = Convert.ToDouble(InputItemCode);

                        string inputUOM = InputValye.Split('-')[3].Trim();
                        string UOM = inputUOM;

                        string IOSwitch = "Input";

                        //DeleteInput(recNo, IOSwitch, ItemCode, UOM);


                        datagrdReportDetails.Rows.Remove(rowdel);
                    }
                    GetPriceTotal();
                }

            }
            catch
            {

            }
        }

        public void DeleteInput(int recNo)
        {
            string sql = "select * from Receipe_Menegement where TenentID= " + Tenent.TenentID + " and recNo = '" + recNo + "'; ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                string sqldel = " delete from Receipe_Menegement  where TenentID= " + Tenent.TenentID + " and recNo = '" + recNo + "' ";
                DataAccess.ExecuteSQL(sqldel);

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlUpdateCmdWIN = " delete from Receipe_Menegement where TenentID= " + Tenent.TenentID + " and recNo = '" + recNo + "' ";
                Datasyncpso.insert_Live_sync(sqlUpdateCmdWIN, "Receipe_Menegement", "DELETE");

            }
        }

        private void dataGridAlwaysShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (comboReceipe.Text == "" || comboReceipe.Text == "System.Data.DataRowView" || comboReceipe.Text == "---- select Receipe ----")
                {
                    MessageBox.Show("please select Receipe");
                    return;
                }

                if (e.ColumnIndex == dataGridAlwaysShow.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowdel in dataGridAlwaysShow.SelectedRows)
                    {

                        string RecValye = comboReceipe.Text.Trim();

                        string recVanno = RecValye.Split('-')[0].Trim();

                        int recNo = Convert.ToInt32(recVanno);

                        string InputValye = rowdel.Cells["ItemsName"].Value.ToString().Trim();
                        string InputItemCode = InputValye.Split('-')[0].Trim();

                        double ItemCode = Convert.ToDouble(InputItemCode);

                        string inputUOM = InputValye.Split('-')[3].Trim();
                        string UOM = inputUOM;

                        string IOSwitch = "Output";

                        //DeleteInput(recNo, IOSwitch, ItemCode, UOM);

                        dataGridAlwaysShow.Rows.Remove(rowdel);
                    }
                    GetPriceTotal();
                }

            }
            catch
            {

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
            if (cmbRectype.Text == "" || cmbRectype.Text == "System.Data.DataRowView")
            {
                MessageBox.Show("please select Receipe Type");
                return;
            }
            if (comboReceipe.Text == "" || comboReceipe.Text == "System.Data.DataRowView" || comboReceipe.Text == "---- select Receipe ----")
            {
                MessageBox.Show("please select Receipe");
                return;
            }

            string SaveQty = "";

            //InputBox.SetLanguage(InputBox.Language.English);

            //DialogResult res = InputBox.ShowDialog("Which Calculation to be used Qty or Percentage ?", "Combo InputBox", InputBox.Icon.Question,
            //    InputBox.Buttons.OkCancel, InputBox.Type.ComboBox, new string[] { "Qty", "percentage"}, true, new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));


            //if (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)
            //    SaveQty = InputBox.ResultValue;


            if (SaveQty == "percentage")
            {
                bool Falginput = Check_inputDataPerc();
                if (Falginput == false)
                {
                    return;
                }

                bool FalgOutput = Check_outputDataPerc();
                if (FalgOutput == false)
                {
                    return;
                }
            }
            else
            {
                bool Falginput = Check_inputDataQty();
                if (Falginput == false)
                {
                    return;
                }

                bool FalgOutput = Check_outputDataQty();
                if (FalgOutput == false)
                {
                    return;
                }
            }

            string RecValye = comboReceipe.Text.Trim();

            string recVanno = RecValye.Split('-')[0].Trim();

            int recNo = Convert.ToInt32(recVanno);

            DeleteInput(recNo);

            int length = datagrdReportDetails.RowCount;
            for (int i = 0; i < length; i++)
            {
                string IOSwitch = "Input";

                string InputValye = datagrdReportDetails.Rows[i].Cells["ItemsName"].Value.ToString().Trim();
                string InputItemCode = InputValye.Split('-')[0].Trim();
                string CostPrice = datagrdReportDetails.Rows[i].Cells["Price"].Value.ToString().Trim();

                double ItemCode = Convert.ToDouble(InputItemCode);

                string inputUOM = InputValye.Split('-')[3].Trim();
                string UOM = inputUOM;
                int UOMID = Add_Item.getuomID(UOM);

                string msrp = Get_MSRT(Tenent.TenentID, ItemCode, UOMID);

                decimal Qty = 0;
                decimal Perc = 0;

                if (SaveQty == "percentage")
                {
                    string InputQtyVal = datagrdReportDetails.Rows[i].Cells[4].Value.ToString().Trim();
                    string val = InputQtyVal.Replace("%", "");
                    decimal Value = Convert.ToDecimal(val);
                    Perc = Value;
                }
                else
                {
                    string InputQtyVal = datagrdReportDetails.Rows[i].Cells["QTY"].Value.ToString().Trim();
                    string val = InputQtyVal;
                    decimal Value = Convert.ToDecimal(val);
                    Qty = Value;
                }

                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc,Uploadby,UploadDate,SynID

                string sql = "select * from Receipe_Menegement where TenentID= " + Tenent.TenentID + " and recNo = '" + recNo + "' and IOSwitch = '" + IOSwitch + "' and ItemCode = '" + ItemCode + "' and  UOM = '" + UOMID + "' ; ";
                DataTable dt = DataAccess.GetDataTable(sql);

                if (dt.Rows.Count < 1)
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sqlCmd = " insert into Receipe_Menegement (TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc,RecType,CostPrice,msrp,Uploadby,UploadDate,SynID)  " +
                                            " values (" + Tenent.TenentID + "," + recNo + " , '" + IOSwitch + "', '" + ItemCode + "','" + UOMID + "', '" + Qty + "','" + Perc + "', '" + cmbRectype.Text + "' , '" + CostPrice + "' , '" + msrp + "' , " +
                                            " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                    DataAccess.ExecuteSQL(sqlCmd);

                    //string sqlCmdWin = " insert into Receipe_Menegement (TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc,RecType,Uploadby,UploadDate,SynID,CostPrice) " +
                    //                   " values (" + Tenent.TenentID + "," + recNo + " , '" + IOSwitch + "', '" + ItemCode + "',N'" + UOMID + "', '" + Qty + "','" + Perc + "', '" + cmbRectype.Text + "' , " +
                    //                       " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 , '" + CostPrice + "' )";
                    Datasyncpso.insert_Live_sync(sqlCmd, "Receipe_Menegement", "INSERT");
                }
                else
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sqlCmd = " Update Receipe_Menegement set Qty = '" + Qty + "' ,Perc = '" + Perc + "', RecType = '" + cmbRectype.Text + "' , CostPrice = '" + CostPrice + "' , msrp = '" + msrp + "' , Uploadby = '" + UserInfo.UserName + "',UploadDate = '" + UploadDate + "',SynID = 2  " +
                                           " Where TenentID= " + Tenent.TenentID + " and recNo = '" + recNo + "' and IOSwitch = '" + IOSwitch + "' and ItemCode = '" + ItemCode + "' and  UOM = '" + UOMID + "' ";
                    DataAccess.ExecuteSQL(sqlCmd);

                    //string sql1 = " Update Receipe_Menegement set Qty = '" + Qty + "' ,Perc = '" + Perc + "', RecType = '" + cmbRectype.Text + "' , Uploadby = '" + UserInfo.UserName + "',UploadDate = '" + UploadDate + "',SynID = 2  " +
                    //                       " Where TenentID= " + Tenent.TenentID + " and recNo = '" + recNo + "' and IOSwitch = '" + IOSwitch + "' and ItemCode = '" + ItemCode + "' and  UOM = '" + UOMID + "' ";
                    //DataAccess.ExecuteSQL(sqlCmd);

                    Datasyncpso.insert_Live_sync(sqlCmd, "Receipe_Menegement", "UPDATE");
                }

            }

            int length1 = dataGridAlwaysShow.RowCount;
            for (int i = 0; i < length1; i++)
            {
                string IOSwitch = "Output";

                string InputValye = dataGridAlwaysShow.Rows[i].Cells["ItemsName"].Value.ToString().Trim();
                string InputItemCode = InputValye.Split('-')[0].Trim();
                string msrp = dataGridAlwaysShow.Rows[i].Cells["Price"].Value.ToString().Trim();

                double ItemCode = Convert.ToDouble(InputItemCode);

                string inputUOM = InputValye.Split('-')[3].Trim();
                string UOM = inputUOM;
                int UOMID = Add_Item.getuomID(UOM);

                string CostPrice = lblinputTotal.Text; //Get_CostPrice(ItemCode, UOMID);

                decimal Qty = 0;
                decimal Perc = 0;

                if (SaveQty == "percentage")
                {
                    string InputQtyVal = dataGridAlwaysShow.Rows[i].Cells[4].Value.ToString().Trim();
                    string val = InputQtyVal.Replace("%", "");
                    decimal Value = Convert.ToDecimal(val);
                    Perc = Value;
                }
                else
                {
                    string InputQtyVal = dataGridAlwaysShow.Rows[i].Cells["QTY"].Value.ToString().Trim();
                    string val = InputQtyVal;
                    decimal Value = Convert.ToDecimal(val);
                    Qty = Value;
                }

                // TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc,Uploadby,UploadDate,SynID

                string sql = "select * from Receipe_Menegement where TenentID= " + Tenent.TenentID + " and recNo = '" + recNo + "' and IOSwitch = '" + IOSwitch + "' and ItemCode = '" + ItemCode + "' and  UOM = '" + UOMID + "' ; ";
                DataTable dt = DataAccess.GetDataTable(sql);

                if (dt.Rows.Count < 1)
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sqlCmd = " insert into Receipe_Menegement (TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc,RecType,CostPrice,msrp,Uploadby,UploadDate,SynID)  " +
                                           " values (" + Tenent.TenentID + "," + recNo + " , '" + IOSwitch + "', '" + ItemCode + "','" + UOMID + "', '" + Qty + "','" + Perc + "',  '" + cmbRectype.Text + "' , '" + CostPrice + "', '" + msrp + "', " +
                                           " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                    DataAccess.ExecuteSQL(sqlCmd);

                    //string sqlCmdWin = " insert into Receipe_Menegement (TenentID,recNo,IOSwitch,ItemCode,UOM,Qty,Perc,RecType,msrp,Uploadby,UploadDate,SynID) " +
                    //                   " values (" + Tenent.TenentID + "," + recNo + " , '" + IOSwitch + "', '" + ItemCode + "',N'" + UOMID + "', '" + Qty + "','" + Perc + "',  '" + cmbRectype.Text + "' , " +
                    //                       " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1  )";
                    Datasyncpso.insert_Live_sync(sqlCmd, "Receipe_Menegement", "INSERT");
                }
                else
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sqlCmd = " Update Receipe_Menegement set Qty = '" + Qty + "' ,Perc = '" + Perc + "', RecType = '" + cmbRectype.Text + "' , CostPrice = '" + CostPrice + "' , msrp = '" + msrp + "' , Uploadby = '" + UserInfo.UserName + "',UploadDate = '" + UploadDate + "',SynID = 2  " +
                                           " Where TenentID= " + Tenent.TenentID + " and recNo = '" + recNo + "' and IOSwitch = '" + IOSwitch + "' and ItemCode = '" + ItemCode + "' and  UOM = '" + UOMID + "' ";
                    DataAccess.ExecuteSQL(sqlCmd);

                    //string sql1 = " Update Receipe_Menegement set Qty = '" + Qty + "' ,Perc = '" + Perc + "', RecType = '" + cmbRectype.Text + "' , Uploadby = '" + UserInfo.UserName + "',UploadDate = '" + UploadDate + "',SynID = 2  " +
                    //                       " Where TenentID= " + Tenent.TenentID + " and recNo = '" + recNo + "' and IOSwitch = '" + IOSwitch + "' and ItemCode = '" + ItemCode + "' and  UOM = '" + UOMID + "' ";
                    //DataAccess.ExecuteSQL(sqlCmd);

                    Datasyncpso.insert_Live_sync(sqlCmd, "Receipe_Menegement", "UPDATE");
                }

            }

            ClearGrid();

        }

        public void ClearGrid()
        {
            datagrdReportDetails.Rows.Clear();
            dataGridAlwaysShow.Rows.Clear();
            comboReceipe.Text = "---- select Receipe ----";
            cmbRectype.Enabled = true;
            btnSave.Text = "Save";
            btnDelete.Visible = false;
            txtSearchItem.Text = "";
        }

        public bool Check_inputDataPerc()
        {
            int length = datagrdReportDetails.RowCount;

            int PerCount = 0;

            decimal SumPer = 0;

            if (length != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    string StrVal = datagrdReportDetails.Rows[i].Cells["QTY"].Value != null && datagrdReportDetails.Rows[i].Cells["QTY"].Value != "" ? datagrdReportDetails.Rows[i].Cells["QTY"].Value.ToString() : "";
                    if (StrVal != "")
                    {
                        try
                        {
                            if (StrVal.Contains("%") == true)
                            {
                                PerCount++;
                                string val = StrVal.Replace("%", "");
                                decimal Value = Convert.ToDecimal(val);
                                SumPer = SumPer + Value;
                            }
                            else
                            {
                                PerCount++;
                                decimal Value = Convert.ToDecimal(StrVal);
                                SumPer = SumPer + Value;
                            }
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
                        MessageBox.Show("Enter Some Percentage in Row No " + RowNO + "  input Item");
                        return false;
                    }
                }

                if (length == PerCount)
                {
                    if (SumPer == 100)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Total Input must be completed as 100% , \n Total of Grid Are " + SumPer + "");
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Enter Percentage Of Qty in All Row input Item");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("Enter Some input Item");
                return false;
            }
        }

        public bool Check_outputDataPerc()
        {
            int length = dataGridAlwaysShow.RowCount;

            int PerCount = 0;

            decimal SumPer = 0;

            if (length != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    string StrVal = dataGridAlwaysShow.Rows[i].Cells["QTY"].Value != null && dataGridAlwaysShow.Rows[i].Cells["QTY"].Value != "" ? dataGridAlwaysShow.Rows[i].Cells["QTY"].Value.ToString() : "";
                    if (StrVal != "")
                    {
                        if (StrVal.Contains("%") == true)
                        {
                            PerCount++;
                            string val = StrVal.Replace("%", "");
                            decimal Value = Convert.ToDecimal(val);
                            SumPer = SumPer + Value;
                        }
                        else
                        {
                            PerCount++;
                            decimal Value = Convert.ToDecimal(StrVal);
                            SumPer = SumPer + Value;
                        }
                    }
                    else
                    {
                        int RowNO = i + 1;
                        MessageBox.Show("Provide a Correct numeric value at Row  " + RowNO + " in output Item");
                        return false;
                    }
                }

                if (length == PerCount)
                {
                    if (SumPer == 100)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Total Input must be completed as 100% , \n Total of Grid Are " + SumPer + "");
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Enter Percentage Of Qty in All Row Output Item");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("Enter Some Output Item");
                return false;
            }
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

        public bool Check_outputDataQty()
        {
            int length = dataGridAlwaysShow.RowCount;

            if (length != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    string StrVal = dataGridAlwaysShow.Rows[i].Cells["QTY"].Value != null && dataGridAlwaysShow.Rows[i].Cells["QTY"].Value != "" ? dataGridAlwaysShow.Rows[i].Cells["QTY"].Value.ToString() : "";
                    if (StrVal != "" && StrVal != "0")
                    {
                        try
                        {
                            decimal qty = Convert.ToDecimal(StrVal);
                        }
                        catch
                        {
                            int RowNO = i + 1;
                            MessageBox.Show("Provide a Correct numeric value at Row  " + RowNO + " in Output Item");
                            return false;
                        }
                    }
                    else
                    {
                        int RowNO = i + 1;
                        MessageBox.Show("Enter Some Qty in Row No " + RowNO + "  Output Item");
                        return false;
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("Enter Some Output Item");
                return false;
            }
        }

        private void cmbRectype_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindReceipe(cmbRectype.Text);
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

        private void dataGridAlwaysShow_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            changeoutputQtypriceEfact(sender, e);
        }

        private void dataGridAlwaysShow_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            changeoutputQtypriceEfact(sender, e);
        }

        public void changeoutputQtypriceEfact(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridAlwaysShow.Columns["QTY"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dataGridAlwaysShow.SelectedRows)
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
                if (e.ColumnIndex == dataGridAlwaysShow.Columns["Price"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dataGridAlwaysShow.SelectedRows)
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
                MessageBox.Show("Enter Valid Cost Price");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboReceipe.Text == "" || comboReceipe.Text == "System.Data.DataRowView" || comboReceipe.Text == "---- select Receipe ----")
                {
                    MessageBox.Show("please select Receipe");
                    return;
                }

                string RecValye = comboReceipe.Text.Trim();

                string recVanno = RecValye.Split('-')[0].Trim();

                int recNo = Convert.ToInt32(recVanno);

                string sql = "select * from CRMMainActivities where TenentID = " + Tenent.TenentID + " and UseReciepeID = " + recNo + " and (Mystatus!='' or Mystatus!=null)";
                DataTable DT = DataAccess.GetDataTable(sql);
                if (DT != null)
                {
                    if (DT.Rows.Count < 1)
                    {
                        DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (result == DialogResult.Yes)
                        {
                            DeleteInput(recNo);
                        }
                    }
                    else
                    {
                        MessageBox.Show("It is Use in Appointment or Invoice it not able to Delete");
                    }
                }
            }
            catch
            {

            }
        }

        private void lnkReceipeSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["ReceipeSearch"] != null)
            {
                Application.OpenForms["ReceipeSearch"].Close();
            }
            this.Refresh();

            ReceipeSearch go = new ReceipeSearch();
            go.ReceipeType = cmbRectype.Text;
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
            go.PageName = "ReceipeMenegement";
            go.Show();
        }

        private void lbloutputTotal_TextChanged(object sender, EventArgs e)
        {
            double OutputTotal = Convert.ToDouble(lbloutputTotal.Text);
            if (OutputTotal > 0)
            {
               // double InputQty = 10;
                for (int i = 0; i < datagrdReportDetails.Rows.Count; i++)//Yogesh Check In Input Commission item
                {
                    string InputReceipeType = datagrdReportDetails.Rows[i].Cells["ReceipeType"].Value.ToString();
                    double InputRowQty = Convert.ToDouble(datagrdReportDetails.Rows[i].Cells["QTY"].Value.ToString());
                    //InputQty = InputRowQty >= InputQty ? InputRowQty : InputQty;
                    if (InputReceipeType == "Commission")
                    {
                        double  InputPrice = 0, InputCostPrice = 0;
                        InputPrice = (InputRowQty * OutputTotal) / 100;
                        InputCostPrice = InputPrice / InputRowQty;
                        datagrdReportDetails.Rows[i].Cells["Price"].Value = InputCostPrice;
                        datagrdReportDetails.Rows[i].Cells["QTY"].Value = InputRowQty;
                        datagrdReportDetails.Rows[i].Cells["Total"].Value = InputPrice;
                    }
                   
                }
            }
        }

    }
}
