using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace supershop
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            try
            {
                //Product Category
                combCategory.DataSource = null;
                combCategory.Items.Clear();
                string sqlcate = "select CATID , CAT_NAME1 ||' - '|| CAT_NAME2 as 'Catagory' from CAT_MST where TenentID = " + Tenent.TenentID + " order By Catagory";
                DataTable dtcate = DataAccess.GetDataTable(sqlcate);
                combCategory.DataSource = dtcate;
                combCategory.ValueMember = "CATID";
                combCategory.DisplayMember = "Catagory";

                string sql5 = "select * FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID where purchase.TenentID = " + Tenent.TenentID + " and category = '" + combCategory.SelectedValue + "' ";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chart1.DataSource = dt5;
                chart1.Visible = true;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;

                chart1.Series["price"].LegendText = "Cost Price";
                chart1.Series["msrp"].LegendText = "Retail Price";

                chart1.Series["price"].XValueMember = "product_name";
                chart1.Series["price"].YValueMembers = "price";

                chart1.Series["msrp"].XValueMember = "product_name";
                chart1.Series["msrp"].YValueMembers = "msrp";
                chart1.DataBind();
            }
            catch
            {
            }

        }

        private void printGrid_Click(object sender, EventArgs e)
        {

            try
            {

                chart1.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                // Print preview chart
                chart1.Printing.PrintPreview();
            }
            catch
            {

            }
        }

        private void combCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql5 = "select * FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID where purchase.TenentID = " + Tenent.TenentID + " and category = '" + combCategory.SelectedValue + "' ";
                DataAccess.ExecuteSQL(sql5);
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                chart1.DataSource = dt5;
                chart1.Visible = true;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;

                chart1.Series["price"].LegendText = "Cost Price";
                chart1.Series["msrp"].LegendText = "Retail Price";

                chart1.Series["price"].XValueMember = "product_name";
                chart1.Series["price"].YValueMembers = "price";

                chart1.Series["msrp"].XValueMember = "product_name";
                chart1.Series["msrp"].YValueMembers = "msrp";
                chart1.DataBind();
            }
            catch
            {

            }
            
        }
    }
}
