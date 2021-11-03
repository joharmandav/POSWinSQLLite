using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace supershop
{
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();

            dtpurchaseDate.Format = DateTimePickerFormat.Custom;
            dtpurchaseDate.CustomFormat = "yyyy-MM-dd";

            this.dgrvProductList.Columns.Add("ItemCode", "Item Code");// 0
            this.dgrvProductList.Columns.Add("ItemName", "Item Name");// 1
            this.dgrvProductList.Columns.Add("UOM", "UOMID");// 2
            this.dgrvProductList.Columns.Add("UOMNAME", "UOM");// 3
            this.dgrvProductList.Columns.Add("QTY", "QTY");// 4
            this.dgrvProductList.Columns.Add("UNITCOST", "UNIT COST");// 5
            this.dgrvProductList.Columns.Add("TotalUnitCost", "Total Cost");// 6
            this.dgrvProductList.Columns.Add("SalesPrice", "Sales Price");// 7

            dgrvProductList.Columns[0].Visible = false;
            dgrvProductList.Columns[2].Visible = false;

            dgrvProductList.Columns[1].Width = 180;
            dgrvProductList.Columns[3].Width = 170;
            dgrvProductList.Columns[4].Width = 110;
            dgrvProductList.Columns[5].Width = 110;
            dgrvProductList.Columns[6].Width = 120;
            dgrvProductList.Columns[7].Width = 130;

            DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
            dgrvProductList.Columns.Add(Edit);
            Edit.HeaderText = "Edit";
            Edit.Text = "Edit";
            Edit.Name = "Edit";
            Edit.ToolTipText = "Edit this Item";
            Edit.UseColumnTextForButtonValue = true;
            Edit.Width = 90;

            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            dgrvProductList.Columns.Add(del);
            del.HeaderText = "Delete";
            del.Text = "Delete";
            del.Name = "Delete";
            del.ToolTipText = "Delete this Item";
            del.UseColumnTextForButtonValue = true;
            del.Width = 90;

            DataGridViewButtonColumn EditDraft = new DataGridViewButtonColumn();
            DataGradDraftFransaction.Columns.Add(EditDraft);
            EditDraft.HeaderText = "Edit";
            EditDraft.Text = "Edit";
            EditDraft.Name = "Edit";
            EditDraft.ToolTipText = "Edit";
            EditDraft.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn delDraft = new DataGridViewButtonColumn();
            DataGradDraftFransaction.Columns.Add(delDraft);
            delDraft.HeaderText = "Delete";
            delDraft.Text = "Delete";
            delDraft.Name = "Delete";
            delDraft.ToolTipText = "Delete";
            delDraft.UseColumnTextForButtonValue = true;


        }
        public string itemsname
        {
            set
            {
                cmbitems.Text = value;
            }
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            lblMYTRANSID.Text = getPurchaseMYTRANSID().ToString();
            BindSupplier();
            Bind_product();
            BindUOM(0);
            BindData();
        }

        public void BindData()
        {
            string Sql = "select MYTRANSID as 'Transaction ID', TC.name as 'supplier',sum(TotalCost_price)as 'Total cost',purchase_date as 'purchase date',TranStatus as 'status',invoiceNO as 'invoice' " +
                         " from tbl_Draft_purchase_history PH inner join tbl_customer TC on PH.supplier = TC.ID and TC.TenentID = PH.TenentID " +
                         " where PH.TenentID = " + Tenent.TenentID + " and TranStatus  = 'Draft' " +
                         " Group by MYTRANSID ";
            DataTable DT = DataAccess.GetDataTable(Sql);
            DataGradDraftFransaction.DataSource = DT;

            DataGradDraftFransaction.Columns["Edit"].DisplayIndex = 7;
            DataGradDraftFransaction.Columns["Delete"].DisplayIndex = 7;

        }

        public void BindSupplier()
        {
            cmbSupplier.DataSource = null;
            cmbSupplier.Items.Clear();
            //Supplier Info
            string sqlCust = "select * from tbl_customer where TenentID = " + Tenent.TenentID + " and PeopleType = 'Supplier'";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);

            cmbSupplier.DataSource = dtCust;
            cmbSupplier.ValueMember = "ID";
            cmbSupplier.DisplayMember = "Name";
            //cmbSupplier.Text = "Unknown";
        }

        public void Bind_product()
        {
            cmbitems.DataSource = null;
            cmbitems.Items.Clear();

            string sql5 = "select product_id,product_id ||' - '|| product_name as 'ProductName' from purchase Where TenentID = " + Tenent.TenentID + " ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);

            DataRow drfirst = dt5.NewRow();
            drfirst["ProductName"] = "--Select--";
            drfirst["product_id"] = "0";
            dt5.Rows.Add(drfirst);

            DataView dv = dt5.DefaultView;
            dv.Sort = "product_id";
            DataTable sortedDT = dv.ToTable();

            cmbitems.DataSource = sortedDT;
            cmbitems.ValueMember = "product_id";
            cmbitems.DisplayMember = "ProductName";
            cmbitems.SelectedValue = "0";
        }
        //public void BindUOM()
        //{
        //    drpPurchaseHistryUOM.DataSource = null;
        //    drpPurchaseHistryUOM.Items.Clear();

        //    string sql = " select * from ICUOM where TenentID = " + Tenent.TenentID + " ";
        //    DataTable dt = DataAccess.GetDataTable(sql);

        //    DataRow drfirst = dt.NewRow();
        //    drfirst["UOMNAME1"] = "--Select--";
        //    drfirst["UOM"] = "0";
        //    dt.Rows.Add(drfirst);

        //    DataView dv = dt.DefaultView;
        //    dv.Sort = "UOM";
        //    DataTable sortedDT = dv.ToTable();

        //    drpPurchaseHistryUOM.DataSource = sortedDT;
        //    drpPurchaseHistryUOM.DisplayMember = "UOMNAME1";
        //    drpPurchaseHistryUOM.ValueMember = "UOM";
        //    drpPurchaseHistryUOM.SelectedValue = "0";
        //}

        public void BindUOM(double PID)
        {
            drpPurchaseHistryUOM.DataSource = null;
            drpPurchaseHistryUOM.Items.Clear();

            string sql = " select UOM,UOMNAME1 from tbl_item_uom_price iup inner join ICUOM IC on IC.UOM = iup.UOMID and IC.TenentID = iup.TenentID " +
                         " where iup.TenentID = " + Tenent.TenentID + " and itemID = " + PID + "   group by UOMID ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //DataRow drfirst = dt.NewRow();
                    //drfirst["UOMNAME1"] = "--Select--";
                    //drfirst["UOM"] = "0";
                    //dt.Rows.Add(drfirst);

                    drpPurchaseHistryUOM.DataSource = dt;
                    drpPurchaseHistryUOM.ValueMember = "UOM";
                    drpPurchaseHistryUOM.DisplayMember = "UOMNAME1";

                    //drpPurchaseHistryUOM.SelectedValue = "0";
                }
            }
        }

        private void cmbitems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbitems.Text != null && cmbitems.Text != "" && cmbitems.Text != "System.Data.DataRowView")
                {
                    double Productid = Convert.ToDouble(cmbitems.SelectedValue);
                    BindUOM(Productid);
                }
            }
            catch
            {

            }
        }
        private void drpPurchaseHistryUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbitems.Text != null && cmbitems.Text != "" && cmbitems.Text != "System.Data.DataRowView")
                {
                    if (drpPurchaseHistryUOM.Text != null && drpPurchaseHistryUOM.Text != "" && drpPurchaseHistryUOM.Text != "System.Data.DataRowView")
                    {
                        int UOM = Convert.ToInt32(drpPurchaseHistryUOM.SelectedValue);
                        double PID = Convert.ToDouble(cmbitems.SelectedValue);
                        BindPrice(PID, UOM);
                    }
                }
            }
            catch
            {

            }
        }

        public static decimal getCostPrice(double PID, int UOMID)
        {
            decimal CostPrice = 0;
            string sql = " select * from tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID = " + PID + " and UOMID = " + UOMID + " ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {

                CostPrice = dt.Rows[0]["price"].ToString() == null || dt.Rows[0]["price"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[0]["price"].ToString());
            }

            return CostPrice;
        }

        public static decimal getMSRP(double PID, int UOMID)
        {
            decimal MSRP = 0;
            string sql = " select * from tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID = " + PID + " and UOMID = " + UOMID + " ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {
                MSRP = dt.Rows[0]["msrp"].ToString() == null || dt.Rows[0]["msrp"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[0]["msrp"].ToString()); 
              
            }

            return MSRP;
        }

        public void BindPrice(double PID, int UOM)
        {
            string sql = " select tbl_item_uom_price.msrp as msrp ,tbl_item_uom_price.price as price , Receipe_Menegement.msrp as Rmsrp ,Receipe_Menegement.CostPrice as Rprice " +
                         " from tbl_item_uom_price left join  Receipe_Menegement on Receipe_Menegement.ItemCode = tbl_item_uom_price.itemID " +
                         " and Receipe_Menegement.UOM = tbl_item_uom_price.UOMID and Receipe_Menegement.TenentID = tbl_item_uom_price.TenentID " +
                         " where tbl_item_uom_price.TenentID = " + Tenent.TenentID + " and itemID = " + PID + " and UOMID = " + UOM + " ";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    txtPHCostPrice.Text = dt.Rows[0]["Rprice"] != null && dt.Rows[0]["Rprice"].ToString() != "" ? dt.Rows[0]["Rprice"].ToString() : dt.Rows[0]["price"].ToString();
                    txtPHSalePrice.Text = dt.Rows[0]["Rmsrp"] != null && dt.Rows[0]["Rmsrp"].ToString() != "" ? dt.Rows[0]["Rmsrp"].ToString() : dt.Rows[0]["msrp"].ToString();
                }
            }
        }

        private void btnrefsuplier_Click(object sender, EventArgs e)
        {
            BindSupplier();
        }

        private void btnProductRefrash_Click(object sender, EventArgs e)
        {
            Bind_product();
        }

        private void btnUOMrefrash_Click(object sender, EventArgs e)
        {
            BindUOM(0);
        }

        private void txtPHCostPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal Qty = Convert.ToDecimal(txtNewpQty.Text);
                decimal UnitPrice = Convert.ToDecimal(txtPHCostPrice.Text);
                decimal Total = UnitPrice * Qty;
                txtTotalCostPrice.Text = Math.Round(Total, 3).ToString();
            }
            catch
            {

            }
        }
        private void txtPHCostPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal Qty = Convert.ToDecimal(txtNewpQty.Text);
                decimal UnitPrice = Convert.ToDecimal(txtPHCostPrice.Text);
                decimal Total = UnitPrice * Qty;
                txtTotalCostPrice.Text = Math.Round(Total, 3).ToString();
            }
            catch
            {

            }
        }
        private void txtTotalCostPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal Qty = Convert.ToDecimal(txtNewpQty.Text);
                decimal UnitPrice = Convert.ToDecimal(txtTotalCostPrice.Text);
                decimal Total = UnitPrice / Qty;
                txtPHCostPrice.Text = Math.Round(Total, 3).ToString();
            }
            catch
            {

            }
        }
        private void label10_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Productsearch"] != null)
            {
                Application.OpenForms["Productsearch"].Close();
            }
            Productsearch go = new Productsearch();
            go.Show();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["AddNewCustomer"] != null)
            {
                Application.OpenForms["AddNewCustomer"].BringToFront();
                Application.OpenForms["AddNewCustomer"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                UserInfo.addSupplierflag = true;
                Customer.AddNewCustomer go = new Customer.AddNewCustomer();
                go.Show();
            }
        }

        private void linkadduom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Add_UOM"] != null)
            {
                Application.OpenForms["Add_UOM"].BringToFront();
                Application.OpenForms["Add_UOM"].WindowState = FormWindowState.Maximized;
            }
            else
            {
                Add_UOM go = new Add_UOM();
                go.MdiParent = this.ParentForm;
                go.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //ItemCode, ItemName, UOM, UOMNAME, QTY, UNITCOST, TotalUnitCost, SalesPrice

            if (cmbitems.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please select Product");
                return;
            }
            else if (drpPurchaseHistryUOM.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please select UOM");
                return;
            }
            else if (txtNewpQty.Text == "")
            {
                MessageBox.Show("Please Enter Qty");
                return;
            }
            else if (txtPHCostPrice.Text == "")
            {
                MessageBox.Show("Please Enter Unit Cost Price");
                return;
            }
            else if (txtTotalCostPrice.Text == "")
            {
                MessageBox.Show("Please Enter Total Unit Cost Price");
                return;
            }
            else if (txtPHSalePrice.Text == "")
            {
                MessageBox.Show("Please Enter Unit Sales Price");
                return;
            }
            else
            {
                double ItemCode = Convert.ToDouble(cmbitems.Text.ToString().Split('-')[0].Trim());
                string ItemName = cmbitems.Text.ToString().Split('-')[1].Trim();
                int UOM = Convert.ToInt32(drpPurchaseHistryUOM.SelectedValue);
                string UOMNAME = drpPurchaseHistryUOM.Text;
                decimal QTY = Convert.ToDecimal(txtNewpQty.Text);
                decimal UNITCOST = Convert.ToDecimal(txtPHCostPrice.Text);
                decimal TotalUnitCost = Convert.ToDecimal(txtTotalCostPrice.Text);
                decimal SalesPrice = Convert.ToDecimal(txtPHSalePrice.Text);

                int n = Finditem(ItemCode.ToString(), UOM.ToString());
                if (n == -1)  //If new item
                {
                    dgrvProductList.Rows.Add(ItemCode, ItemName, UOM, UOMNAME, QTY, UNITCOST, TotalUnitCost, SalesPrice);
                    lblTotalAmtPY.Text = GEtFinalToTAl().ToString();
                    CalculationDescount();
                    clear();
                }
                else
                {
                    if (btnAdd.Text != "Update")
                    {
                        DialogResult result = MessageBox.Show(" Item Found in List. Do you want to Update it?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            dgrvProductList.Rows[n].Cells[4].Value = QTY;
                            dgrvProductList.Rows[n].Cells[5].Value = UNITCOST;
                            dgrvProductList.Rows[n].Cells[6].Value = TotalUnitCost;
                            dgrvProductList.Rows[n].Cells[7].Value = SalesPrice;
                            lblTotalAmtPY.Text = GEtFinalToTAl().ToString();
                            CalculationDescount();
                            clear();
                        }
                    }
                    else
                    {
                        dgrvProductList.Rows[n].Cells[4].Value = QTY;
                        dgrvProductList.Rows[n].Cells[5].Value = UNITCOST;
                        dgrvProductList.Rows[n].Cells[6].Value = TotalUnitCost;
                        dgrvProductList.Rows[n].Cells[7].Value = SalesPrice;
                        lblTotalAmtPY.Text = GEtFinalToTAl().ToString();
                        CalculationDescount();
                        clear();
                    }

                }
            }

        }

        private void btnAdd_Click1(object sender, EventArgs e)
        {
            // ItemCode, ItemName, UOM, UOMNAME, QTY, UNITCOST, TotalUnitCost, SalesPrice

            if (cmbitems.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please select Product");
                return;
            }
            else if (drpPurchaseHistryUOM.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please select UOM");
                return;
            }
            else if (txtNewpQty.Text == "")
            {
                MessageBox.Show("Please Enter Qty");
                return;
            }
            else if (txtPHCostPrice.Text == "")
            {
                MessageBox.Show("Please Enter Unit Cost Price");
                return;
            }
            else if (txtTotalCostPrice.Text == "")
            {
                MessageBox.Show("Please Enter Total Unit Cost Price");
                return;
            }
            else if (txtPHSalePrice.Text == "")
            {
                MessageBox.Show("Please Enter Unit Sales Price");
                return;
            }
            else
            {
                double ItemCode = Convert.ToDouble(cmbitems.Text.ToString().Split('-')[0].Trim());
                string ItemName = cmbitems.Text.ToString().Split('-')[1].Trim();
                int UOM = Convert.ToInt32(drpPurchaseHistryUOM.SelectedValue);
                string UOMNAME = drpPurchaseHistryUOM.Text;
                decimal QTY = Convert.ToDecimal(txtNewpQty.Text);
                decimal UNITCOST = Convert.ToDecimal(txtPHCostPrice.Text);
                decimal TotalUnitCost = Convert.ToDecimal(txtTotalCostPrice.Text);
                decimal SalesPrice = Convert.ToDecimal(txtPHSalePrice.Text);

                int n = Finditem(ItemCode.ToString(), UOM.ToString());
                if (n == -1)  //If new item
                {
                    dgrvProductList.Rows.Add(ItemCode, ItemName, UOM, UOMNAME, QTY, UNITCOST, TotalUnitCost, SalesPrice);
                    lblTotalAmtPY.Text = GEtFinalToTAl().ToString();
                    CalculationDescount();
                    clear();
                }
                else
                {
                    if (btnAdd.Text != "Update")
                    {
                        DialogResult result = MessageBox.Show(" Item Found in List. Do you want to Update it?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            dgrvProductList.Rows[n].Cells[4].Value = QTY;
                            dgrvProductList.Rows[n].Cells[5].Value = UNITCOST;
                            dgrvProductList.Rows[n].Cells[6].Value = TotalUnitCost;
                            dgrvProductList.Rows[n].Cells[7].Value = SalesPrice;
                            lblTotalAmtPY.Text = GEtFinalToTAl().ToString();
                            CalculationDescount();
                            clear();
                        }
                    }
                    else
                    {
                        dgrvProductList.Rows[n].Cells[4].Value = QTY;
                        dgrvProductList.Rows[n].Cells[5].Value = UNITCOST;
                        dgrvProductList.Rows[n].Cells[6].Value = TotalUnitCost;
                        dgrvProductList.Rows[n].Cells[7].Value = SalesPrice;
                        lblTotalAmtPY.Text = GEtFinalToTAl().ToString();
                        CalculationDescount();
                        clear();
                    }

                }
            }

        }

        public void clear()
        {
            cmbitems.Enabled = true;
            drpPurchaseHistryUOM.Enabled = true;
            btnAdd.Text = "Save";

            cmbitems.SelectedValue = "0";
            drpPurchaseHistryUOM.SelectedValue = "0";
            txtNewpQty.Text = "";
            txtPHCostPrice.Text = "";
            txtTotalCostPrice.Text = "";
            txtPHSalePrice.Text = "";
        }
        public int Finditem(string item, string UOM)
        {
            int k = -1;
            if (dgrvProductList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgrvProductList.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item) && row.Cells[2].Value.ToString().Equals(UOM))
                    {
                        k = row.Index;
                        break;
                    }
                }
            }
            return k;
        }

        private void dgrvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Delete items From Gridview
                if (e.ColumnIndex == dgrvProductList.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowDelete in dgrvProductList.SelectedRows)
                    {
                        if (!rowDelete.IsNewRow)
                            dgrvProductList.Rows.Remove(rowDelete);

                        lblTotalAmtPY.Text = GEtFinalToTAl().ToString();
                        CalculationDescount();
                    }
                }

                if (e.ColumnIndex == dgrvProductList.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowEdit in dgrvProductList.SelectedRows)
                    {
                        // ItemCode, ItemName, UOM, UOMNAME, QTY, UNITCOST, TotalUnitCost, SalesPrice
                        string ItemCode = rowEdit.Cells["ItemCode"].Value.ToString().Trim();
                        string UOM = rowEdit.Cells["UOM"].Value.ToString().Trim();
                        string QTY = rowEdit.Cells["QTY"].Value.ToString().Trim();
                        string UNITCOST = rowEdit.Cells["UNITCOST"].Value.ToString().Trim();
                        string TotalUnitCost = rowEdit.Cells["TotalUnitCost"].Value.ToString().Trim();
                        string SalesPrice = rowEdit.Cells["SalesPrice"].Value.ToString().Trim();

                        cmbitems.SelectedValue = ItemCode;
                        drpPurchaseHistryUOM.SelectedValue = UOM;
                        txtNewpQty.Text = QTY;
                        txtPHCostPrice.Text = UNITCOST;
                        txtTotalCostPrice.Text = TotalUnitCost;
                        txtPHSalePrice.Text = SalesPrice;

                        cmbitems.Enabled = false;
                        drpPurchaseHistryUOM.Enabled = false;
                        btnAdd.Text = "Update";
                        CalculationDescount();
                    }
                }
            }
            catch
            {

            }
        }
        private void DataGradDraftFransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Delete items From Gridview
                if (e.ColumnIndex == DataGradDraftFransaction.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowDelete in DataGradDraftFransaction.SelectedRows)
                    {
                        int MYTRANSID = Convert.ToInt32(rowDelete.Cells["Transaction ID"].Value);
                        DeleteOldTrans(MYTRANSID);
                        Purchase go = new Purchase();
                        go.MdiParent = this.ParentForm;
                        go.Show();
                        this.Close();
                    }
                }

                if (e.ColumnIndex == DataGradDraftFransaction.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow rowEdit in DataGradDraftFransaction.SelectedRows)
                    {
                        //MYTRANSID as 'Transaction ID', TC.name as 'supplier',sum(TotalCost_price)as 'Total cost',purchase_date as 'purchase date',TranStatus as 'status',invoiceNO as 'invoice'
                        int MYTRANSID = Convert.ToInt32(rowEdit.Cells["Transaction ID"].Value);
                        string purchase_date = rowEdit.Cells["purchase date"].Value.ToString();
                        string supplier = rowEdit.Cells["supplier"].Value.ToString();
                        string invoiceNO = rowEdit.Cells["invoice"].Value.ToString();
                        cmbSupplier.Text = supplier;
                        dtpurchaseDate.Text = purchase_date;
                        txtPurInvoiceNO.Text = invoiceNO;
                        lblMYTRANSID.Text = MYTRANSID.ToString();

                        string Sql = "select * from tbl_Draft_purchase_history where TenentID = " + Tenent.TenentID + " and MytransID = " + MYTRANSID + " ";
                        DataTable dt = DataAccess.GetDataTable(Sql);

                        int rows = dt.Rows.Count;
                        for (int i = 0; i < rows; i++)
                        {
                            double ItemCode = Convert.ToDouble(dt.Rows[i]["product_id"]);
                            string ItemName = dt.Rows[i]["product_name"].ToString();
                            int UOM = Convert.ToInt32(dt.Rows[i]["UOM"]);
                            decimal QTY = Convert.ToDecimal(dt.Rows[i]["product_quantity"]);
                            decimal UNITCOST = Convert.ToDecimal(dt.Rows[i]["cost_price"]);
                            decimal TotalUnitCost = Convert.ToDecimal(dt.Rows[i]["TotalCost_price"]);
                            decimal SalesPrice = Convert.ToDecimal(dt.Rows[i]["retail_price"]);

                            string UOMNAME = Add_Item.getuomName(UOM);

                            dgrvProductList.Rows.Add(ItemCode, ItemName, UOM, UOMNAME, QTY, UNITCOST, TotalUnitCost, SalesPrice);
                            lblTotalAmtPY.Text = GEtFinalToTAl().ToString();
                            clear();
                        }
                        CalculationDescount();
                        btnFinalPurchase.Visible = true;

                    }
                }
            }
            catch
            {

            }
        }

        public int GetProductCategoryID(double product_id)
        {
            int CATID = 0;
            string sql = "select * from purchase where tenentid = " + Tenent.TenentID + " and product_id = " + product_id + " ";
            DataTable Dt = DataAccess.GetDataTable(sql);
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    CATID = Convert.ToInt32(Dt.Rows[0]["category"]);
                }
            }

            return CATID;
        }

        private void linkProductAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Add_Item"] == null)
            {
                Add_Item go = new Add_Item();
                go.MdiParent = this.ParentForm;
                go.Show();
            }
            else
            {
                Application.OpenForms["Add_Item"].BringToFront();
                Application.OpenForms["Add_Item"].WindowState = FormWindowState.Maximized;
            }
        }
        public static int getPurchaseMYTRANSID()
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_Draft_purchase_history where TenentID = " + Tenent.TenentID + " and MYTRANSID not null ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(MYTRANSID) from tbl_Draft_purchase_history where TenentID = " + Tenent.TenentID + " and MYTRANSID not null ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            else
            {
                string sql = "select * from tbl_purchase_history where TenentID = " + Tenent.TenentID + " and MYTRANSID not null ";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    string sql123 = " select MAX(MYTRANSID) from tbl_purchase_history where TenentID = " + Tenent.TenentID + " and MYTRANSID not null ";
                    DataTable dt12 = DataAccess.GetDataTable(sql123);
                    if (dt12.Rows.Count > 0)
                    {
                        int id = Convert.ToInt32(dt12.Rows[0][0]);
                        ID12 = id + 1;
                    }
                }
            }

            return ID12;
        }

        public static int getPurchasenewid()
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_Draft_purchase_history where TenentID = " + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(id) from tbl_Draft_purchase_history where TenentID = " + Tenent.TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public void insertpurchasehistoryDraft(double pid, string ProductName, int Catagory, int supplier, string ptype, int pQty, string pdate, int UOM, decimal cost, decimal TotalCostprice, decimal Msrp, int MY_TRANS_ID, string InvoiceNO, string TranStatus)
        {
            if (pQty != 0)
            {
                int ID12 = getPurchasenewid();
                string Shopid = UserInfo.Shopid;

                //`TotalCost_price`	NUMERIC,	`MYTRANSID`	INTEGER,	`InvoiceNO`	TEXT, `Remarks`	TEXT,	`TranStatus`	TEXT,

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string sql1 = " insert into tbl_Draft_purchase_history (TenentID,id, product_id, product_name, product_quantity,cost_price,retail_price, category, " +
                                " supplier, purchase_date, Shopid, ptype ,UOM,Uploadby ,UploadDate ,SynID,TotalCost_price,MYTRANSID,InvoiceNO,TranStatus) " +
                                " values (" + Tenent.TenentID + "," + ID12 + ",'" + pid + "', '" + ProductName + "', '" + pQty + "', '" + cost + "', '" + Msrp + "','" + Catagory + "', " +
                                "  '" + supplier + "', '" + pdate + "' ,'" + Shopid + "', '" + ptype + "', '" + UOM + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1, " +
                                " '" + TotalCostprice + "', '" + MY_TRANS_ID + "', '" + InvoiceNO + "','" + TranStatus + "')";
                DataAccess.ExecuteSQL(sql1);
            }

        }

        public void insertpurchasehistory(double pid, string ProductName, int Catagory, int supplier, string ptype, int pQty, string pdate, int UOM, decimal cost, decimal TotalCostprice, decimal Msrp, int MY_TRANS_ID, string InvoiceNO, string TranStatus)
        {
            if (pQty != 0)
            {
                int ID12 = Add_Item.getPurchasenewid();
                string Shopid = UserInfo.Shopid;

                //`TotalCost_price`	NUMERIC,	`MYTRANSID`	INTEGER,	`InvoiceNO`	TEXT, `Remarks`	TEXT,	`TranStatus`	TEXT,

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string sql1 = " insert into tbl_purchase_history (TenentID,id, product_id, product_name, product_quantity,cost_price,retail_price, category, " +
                                " supplier, purchase_date, Shopid, ptype ,UOM,Uploadby ,UploadDate ,SynID,TotalCost_price,MYTRANSID,InvoiceNO,TranStatus) " +
                                " values (" + Tenent.TenentID + "," + ID12 + ",'" + pid + "', '" + ProductName + "', '" + pQty + "', '" + cost + "', '" + Msrp + "','" + Catagory + "', " +
                                "  '" + supplier + "', '" + pdate + "' ,'" + Shopid + "', '" + ptype + "', '" + UOM + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1, " +
                                " '" + TotalCostprice + "', '" + MY_TRANS_ID + "', '" + InvoiceNO + "','" + TranStatus + "')";
                int Flag = DataAccess.ExecuteSQL(sql1);

                if (Flag == 1)
                {
                    string sql1Win = " insert into Win_tbl_purchase_history (TenentID,id, product_id, product_name, product_quantity,cost_price,retail_price, category, " +
                                " supplier, purchase_date, Shopid, ptype ,UOM,Uploadby ,UploadDate ,SynID,TotalCost_price,MYTRANSID,InvoiceNO,TranStatus) " +
                                " values (" + Tenent.TenentID + "," + ID12 + ",'" + pid + "', N'" + ProductName + "', '" + pQty + "','" + cost + "','" + Msrp + "', '" + Catagory + "', " +
                                "  '" + supplier + "', '" + pdate + "' ,'" + Shopid + "', '" + ptype + "', '" + UOM + "','" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1, " +
                                " '" + TotalCostprice + "', '" + MY_TRANS_ID + "', '" + InvoiceNO + "','" + TranStatus + "')";
                    Datasyncpso.insert_Live_sync(sql1Win, "Win_tbl_purchase_history", "INSERT");

                    decimal TotalPurchase = cost * pQty;
                    Add_Item.Update_ShiftPurchase_DayClose(TotalPurchase);

                    string ActivityName = "purchase Item";
                    string LogData = "purchase Item with product_id = " + pid + "and UOM = " + UOM + " ";
                    Login.InsertUserLog(ActivityName, LogData);

                    int UOMID = Convert.ToInt32(UOM);// getuomid(UOM);   //yogesh             
                    Add_Item.add_perisable(pid.ToString(), UOMID, MY_TRANS_ID);//yogesh
                    Add_Item.add_Serialize(pid.ToString(), UOMID, MY_TRANS_ID);//yogesh
                }
            }

        }

        public static string getAllUomOfproduct(double ProductID)
        {
            string UomS = "";
            string Sql = "select * from tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID = " + ProductID + " ";
            DataTable Dt1 = DataAccess.GetDataTable(Sql);
            for (int i = 0; i < Dt1.Rows.Count; i++)
            {
                UomS = UomS + "," + Dt1.Rows[i]["UOMID"].ToString();
            }

            UomS = UomS.Trim();
            UomS = UomS.TrimStart(',');
            UomS = UomS.TrimEnd(',');

            return UomS;
        }

        public static int GetBaseUOM(double Product_ID)
        {
            try
            {
                int BaseUOM = 0;

                string Sql = "select BaseUOM from purchase where TenentID = " + Tenent.TenentID + " and Product_ID = " + Product_ID + " ";
                DataTable Dt1 = DataAccess.GetDataTable(Sql);
                if (Dt1.Rows.Count > 0)
                {
                    BaseUOM = Dt1.Rows[0]["BaseUOM"] != null ? Convert.ToInt32(Dt1.Rows[0]["BaseUOM"]) : 0;
                }
                return BaseUOM;
            }
            catch
            {
                return 0;
            }

        }

        public static double getConversionBaseQty(int BaseUOM, int ToUOM, double Qty)
        {
            try
            {
                double Conv = 0;

                string Sql = "select * from IcuomConv where TenentID = " + Tenent.TenentID + " and FUOM = " + BaseUOM + " and TUOM = " + ToUOM + " ";
                DataTable Dt1 = DataAccess.GetDataTable(Sql);
                if (Dt1.Rows.Count > 0)
                {
                    Conv = Convert.ToDouble(Dt1.Rows[0]["ConvRatio"]);
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

        public static double getConversionToQty(int BaseUOM, int ToUOM, double Qty)
        {
            try
            {
                double Conv = 0;

                string Sql = "select * from IcuomConv where TenentID = " + Tenent.TenentID + " and FUOM = " + BaseUOM + " and TUOM = " + ToUOM + " ";
                DataTable Dt1 = DataAccess.GetDataTable(Sql);
                if (Dt1.Rows.Count > 0)
                {
                    Conv = Convert.ToDouble(Dt1.Rows[0]["CONVERSION"]);
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

        public void updatestockqty(double PID, int UOM, double EnterQty, decimal NewMSRP, decimal Newprice)
        {
            int SelctUOM = UOM;
            double Qty = EnterQty;

            string AllUOMConv = "";

            int BaseUOM = GetBaseUOM(PID);

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
                    AllUOMConv = getAllUomOfproduct(PID);
                }
                else
                {
                    AllUOMConv = SelctUOM.ToString();
                }
            }

            double BaseQty = Qty;
            if (SelctUOM != BaseUOM)
            {
                BaseQty = getConversionBaseQty(BaseUOM, SelctUOM, Qty);
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
                        newQty = getConversionToQty(BaseUOM, ToUOM, BaseQty);
                    }
                    price = getCostPrice(PID, ToUOM);
                    msrp = getMSRP(PID, ToUOM);
                }

                string sql2 = "select OnHand,QtyRecived from tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID = '" + PID + "' and UOMID = '" + ToUOM + "' ";
                DataTable dtterminallist = DataAccess.GetDataTable(sql2);
                if (dtterminallist != null)
                {
                    if (dtterminallist.Rows.Count > 0)
                    {
                        int rows = dtterminallist.Rows.Count;
                        string QtyDB = dtterminallist.Rows[0]["OnHand"].ToString();
                        string OldQtyRecived = dtterminallist.Rows[0]["QtyRecived"].ToString() == "" ? "0" : dtterminallist.Rows[0]["QtyRecived"].ToString();
                        double StockQty = Convert.ToDouble(QtyDB) + newQty;
                        double NewQtyRecived = Convert.ToDouble(OldQtyRecived) + newQty;

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql = " update tbl_item_uom_price set " +
                                                " OnHand = '" + StockQty + "' , QtyRecived = '" + NewQtyRecived + "' , " +
                                                " msrp= '" + msrp + "' , price = '" + price + "' ," +
                                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                                "  where TenentID= " + Tenent.TenentID + " and itemID = '" + PID + "' and UOMID = '" + ToUOM + "'";
                        DataAccess.ExecuteSQL(sql);

                        string sqlwin = " update Win_tbl_item_uom_price set " +
                                               " OnHand = '" + StockQty + "' , QtyRecived = '" + NewQtyRecived + "' , " +
                                               " msrp= '" + msrp + "' , price = '" + price + "' ," +
                                               " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                               " where TenentID= " + Tenent.TenentID + " and itemID = '" + PID + "' and UOMID = '" + ToUOM + "'";
                        Datasyncpso.insert_Live_sync(sqlwin, "Win_tbl_item_uom_price", "UPDATE");
                    }
                    else
                    {
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        int ID12 = DataAccess.getuom_priceMYid(Tenent.TenentID, PID.ToString(), ToUOM);
                        string sql1 = " insert into tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved, " +
                                             " QtyRecived,msrp,price,Deleted,minQty,MaxQty,Discount,RecipeType,Uploadby ,UploadDate ,SynID) " +
                                             " values (" + Tenent.TenentID + ", " + ID12 + ",'" + PID + "', '" + ToUOM + "', '" + newQty + "', " +
                                             " '" + newQty + "',0,0,0,0, '" + msrp + "', '" + price + "','Y'," +
                                             " '1', '5', '0', 'Output' , " +
                                             " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        DataAccess.ExecuteSQL(sql1);

                        string sql1win = " insert into Win_tbl_item_uom_price (TenentID,ID, itemID,UOMID,OpQty,OnHand,QtyOut,QtyConsumed,QtyReserved, " +
                                      " QtyRecived,msrp,price,Deleted,minQty,MaxQty,Discount,RecipeType,Uploadby ,UploadDate ,SynID) " +
                                      " values (" + Tenent.TenentID + "," + ID12 + ",'" + PID + "', '" + ToUOM + "', '" + newQty + "', " +
                                      " '" + newQty + "',0,0,0,0, '" + msrp + "', '" + price + "','Y'," +
                                      " '1', '5', '0', 'Output' , " +
                                      " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1)";
                        Datasyncpso.insert_Live_sync(sql1win, "Win_tbl_item_uom_price", "INSERT");
                    }
                }
            }
        }

        private void txtNewpQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNewpQty.Text != "")
                {
                    double ItemCode = Convert.ToDouble(cmbitems.Text.ToString().Split('-')[0].Trim());
                    double pid = ItemCode;

                    if (cmbitems.Text != null && cmbitems.Text != "" && cmbitems.Text != "System.Data.DataRowView")
                    {
                        if (drpPurchaseHistryUOM.Text != null && drpPurchaseHistryUOM.Text != "" && drpPurchaseHistryUOM.Text != "System.Data.DataRowView")
                        {
                            int UOM = Convert.ToInt32(drpPurchaseHistryUOM.SelectedValue);
                            double PID = Convert.ToDouble(cmbitems.SelectedValue);
                            BindPrice(PID, UOM);
                        }
                    }

                    decimal Qty = Convert.ToDecimal(txtNewpQty.Text);
                    decimal UnitPrice = Convert.ToDecimal(txtPHCostPrice.Text);
                    decimal Total = UnitPrice * Qty;
                    txtTotalCostPrice.Text = Math.Round(Total, 3).ToString();
                }
            }
            catch
            {

            }
        }

        private void btnFinalPurchase_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.Text == "" || cmbSupplier.Text == null || cmbSupplier.Text == "System.Data.DataRowView" || cmbSupplier.SelectedValue == "0")
            {
                MessageBox.Show("select TO Supplier");
                return;
            }
            else if (dtpurchaseDate.Text == "")
            {
                MessageBox.Show("Enter Purchase Date");
                return;
            }
            else if (txtPurInvoiceNO.Text == "")
            {
                MessageBox.Show("Enter InvoiceNO #");
                return;
            }
            else
            {
                FinalPurchase();
                Purchase go = new Purchase();
                go.MdiParent = this.ParentForm;
                go.Show();
                this.Close();
            }
        }

        public void FinalPurchase()
        {
            try
            {
                //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                //{
                    int MY_TRANS_ID = Convert.ToInt32(lblMYTRANSID.Text);
                    int rows = dgrvProductList.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        double pid = Convert.ToDouble(dgrvProductList.Rows[i].Cells[0].Value.ToString());
                        string ProductName = dgrvProductList.Rows[i].Cells[1].Value.ToString();
                        int UOM = Convert.ToInt32(dgrvProductList.Rows[i].Cells[2].Value.ToString());
                        int newQty = Convert.ToInt32(dgrvProductList.Rows[i].Cells[4].Value.ToString());
                        decimal cost = Convert.ToDecimal(dgrvProductList.Rows[i].Cells[5].Value.ToString());
                        decimal TotalCostprice = Convert.ToDecimal(dgrvProductList.Rows[i].Cells[6].Value.ToString());
                        decimal Msrp = Convert.ToDecimal(dgrvProductList.Rows[i].Cells[7].Value.ToString());

                        string InvoiceNO = txtPurInvoiceNO.Text;
                        int Catagory = GetProductCategoryID(pid);
                        int supplier = Convert.ToInt32(cmbSupplier.SelectedValue);
                        string ptype = "OLD";
                        string pdate = dtpurchaseDate.Text;
                        string TranStatus = "Final";

                        insertpurchasehistory(pid, ProductName, Catagory, supplier, ptype, newQty, pdate, UOM, cost, TotalCostprice, Msrp, MY_TRANS_ID, InvoiceNO, TranStatus);
                        updatestockqty(pid, UOM, newQty, Msrp, cost);
                    }
                    FinalDraftTRANS(MY_TRANS_ID);

                //    scope.Complete();
                //}
            }
            catch
            {

            }
        }

        public void FinalDraftTRANS(int MYTRANSID)
        {
            string sqlselect = "select * from tbl_Draft_purchase_history  where TenentID = " + Tenent.TenentID + " and MYTRANSID = " + MYTRANSID + "  ";
            DataTable Dt = DataAccess.GetDataTable(sqlselect);
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    string sql = "Update tbl_Draft_purchase_history set TranStatus = 'Final' where TenentID = " + Tenent.TenentID + " and MYTRANSID = " + MYTRANSID + "  ";
                    DataAccess.ExecuteSQL(sql);
                }
            }
        }

        private void btnDraft_Click(object sender, EventArgs e)
        {
           
            if (cmbSupplier.Text == "" || cmbSupplier.Text == null || cmbSupplier.Text == "System.Data.DataRowView" || cmbSupplier.SelectedValue == "0")
            {
                MessageBox.Show("select TO Supplier");
                return;
            }
            else if (dtpurchaseDate.Text == "")
            {
                MessageBox.Show("Enter Purchase Date");
                return;
            }
            else if (txtPurInvoiceNO.Text == "")
            {
                MessageBox.Show("Enter InvoiceNO #");
                return;
            }
            else
            {
                txtPurInvoiceNO.Text = Add_Item.voidQueryValidate(txtPurInvoiceNO.Text);
                DraftPurchase();
                Purchase go = new Purchase();
                go.MdiParent = this.ParentForm;
                go.Show();
                this.Close();
            }
        }

        public void DraftPurchase()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {

                    int MY_TRANS_ID = Convert.ToInt32(lblMYTRANSID.Text);
                    DeleteOldTrans(MY_TRANS_ID);

                    int rows = dgrvProductList.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        double pid = Convert.ToDouble(dgrvProductList.Rows[i].Cells[0].Value.ToString());
                        string ProductName = dgrvProductList.Rows[i].Cells[1].Value.ToString();
                        int UOM = Convert.ToInt32(dgrvProductList.Rows[i].Cells[2].Value.ToString());
                        int newQty = Convert.ToInt32(dgrvProductList.Rows[i].Cells[4].Value.ToString());
                        decimal cost = Convert.ToDecimal(dgrvProductList.Rows[i].Cells[5].Value.ToString());
                        decimal TotalCostprice = Convert.ToDecimal(dgrvProductList.Rows[i].Cells[6].Value.ToString());
                        decimal Msrp = Convert.ToDecimal(dgrvProductList.Rows[i].Cells[7].Value.ToString());


                        string InvoiceNO = txtPurInvoiceNO.Text;
                        int Catagory = GetProductCategoryID(pid);
                        int supplier = Convert.ToInt32(cmbSupplier.SelectedValue);
                        string ptype = "OLD";
                        string pdate = dtpurchaseDate.Text;
                        string TranStatus = "Draft";
                        insertpurchasehistoryDraft(pid, ProductName, Catagory, supplier, ptype, newQty, pdate, UOM, cost, TotalCostprice, Msrp, MY_TRANS_ID, InvoiceNO, TranStatus);
                    }
                    scope.Complete();
                }
            }
            catch
            {

            }
        }

        public decimal GEtFinalToTAl()
        {
            decimal FinalTotal = 0;
            try
            {

                int rows = dgrvProductList.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    decimal TotalCostprice = Convert.ToDecimal(dgrvProductList.Rows[i].Cells[6].Value.ToString());
                    FinalTotal = FinalTotal + TotalCostprice;
                }
                return FinalTotal;
            }
            catch
            {
                return FinalTotal;
            }
        }

        public void DeleteOldTrans(int MYTRANSID)
        {
            string sqlselect = "select * from tbl_Draft_purchase_history  where TenentID = " + Tenent.TenentID + " and MYTRANSID = " + MYTRANSID + "  ";
            DataTable Dt = DataAccess.GetDataTable(sqlselect);
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    string sql = "Delete from tbl_Draft_purchase_history where TenentID = " + Tenent.TenentID + " and MYTRANSID = " + MYTRANSID + " ";
                    DataAccess.ExecuteSQL(sql);
                }
            }
        }

        private void txtPHCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtPHCostPrice.Text.ToString(), @"\.\d\d\d");

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

        private void txtPHSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtPHSalePrice.Text.ToString(), @"\.\d\d\d");

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

        private void txtTotalCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtTotalCostPrice.Text.ToString(), @"\.\d\d\d");

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
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.' & e.KeyChar != '%')
                {
                    e.Handled = true;
                }

                base.OnKeyPress(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CalculationDescount()
        {
            try
            {
                string str = "";
                decimal DICUNT = 0;
                decimal DICUNTOTAL = 0;
                decimal FTotal = Convert.ToDecimal(lblTotalAmtPY.Text);
                if (txtDiscount.Text.Contains("%"))
                {
                    str = txtDiscount.Text.Replace('%', ' ');
                    DICUNT = Convert.ToDecimal(str);

                    DICUNTOTAL = FTotal - (FTotal * (DICUNT / 100));
                    string roundsubtotal = Math.Round(DICUNTOTAL, 3).ToString();

                    lblFinalTotal.Text = roundsubtotal;
                }
                else
                {
                    str = txtDiscount.Text;
                    DICUNT = Convert.ToDecimal(str);

                    DICUNTOTAL = FTotal - DICUNT;
                    string roundsubtotal = Math.Round(DICUNTOTAL, 3).ToString();
                    lblFinalTotal.Text = roundsubtotal;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisApply_Click(object sender, EventArgs e)
        {
            CalculationDescount();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["Productsearch"] != null)
            {
                Application.OpenForms["Productsearch"].Close();
            }
            Productsearch go = new Productsearch();
            go.Show();
        }

        private void txtNewpQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtNewpQty.Text != "")
                {
                    double ItemCode = Convert.ToDouble(cmbitems.Text.ToString().Split('-')[0].Trim());
                    double pid = ItemCode;
                  
                    bool Parisable =SalesRegister.IsPerishable(pid);
                    if (Parisable == true)
                    {
                        string UOM = drpPurchaseHistryUOM.SelectedValue.ToString();
                        int MY_TRANS_ID = Convert.ToInt32(lblMYTRANSID.Text);
                        string MySysName = "PUR";

                        Items.Perishable go = new Items.Perishable(ItemCode.ToString(), UOM, MY_TRANS_ID, MySysName);
                        go.Qty = txtNewpQty.Text;
                        go.Show();
                    }
                    bool Serialize = SalesRegister.IsSerialize(pid);//yogesh
                    if (Serialize == true)
                    {
                        string UOMID = drpPurchaseHistryUOM.SelectedValue.ToString();// drpUOM.SelectedValue.ToString();
                        int UOMIC = Convert.ToInt32(UOMID);
                        //string uom = getuomName(UOMIC);
                        int MY_TRANS_ID = Convert.ToInt32(lblMYTRANSID.Text);
                        string MySysName = "PUR";

                        Items.Serialize go = new Items.Serialize(ItemCode.ToString(), UOMID, MY_TRANS_ID, MySysName);//Constructor and nothing return
                        go.Qty = txtNewpQty.Text;
                        go.Show();
                    }

                    if (cmbitems.Text != null && cmbitems.Text != "" && cmbitems.Text != "System.Data.DataRowView")
                    {
                        if (drpPurchaseHistryUOM.Text != null && drpPurchaseHistryUOM.Text != "" && drpPurchaseHistryUOM.Text != "System.Data.DataRowView")
                        {
                            int UOM = Convert.ToInt32(drpPurchaseHistryUOM.SelectedValue);
                            double PID = Convert.ToDouble(cmbitems.SelectedValue);
                            BindPrice(PID, UOM);
                        }
                    }

                    decimal Qty = Convert.ToDecimal(txtNewpQty.Text);
                    decimal UnitPrice = Convert.ToDecimal(txtPHCostPrice.Text);
                    decimal Total = UnitPrice * Qty;
                    txtTotalCostPrice.Text = Math.Round(Total, 3).ToString();
                }
            }
            catch
            {

            }
        }


    }
}
