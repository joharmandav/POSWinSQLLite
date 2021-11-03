using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace supershop
{
    public partial class BarcodeRDLC : Form
    {
        POSWinAppEntities DB = new POSWinAppEntities(Login.BuildConnectionString());
        public BarcodeRDLC()
        {
            InitializeComponent();
        }

        private void BarcodeRDLC_Load(object sender, EventArgs e)
        {
            try
            {
                //Product Category
                string sql5 = " select DISTINCT product_id  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID " +
                              " Where purchase.TenentID = " + Tenent.TenentID + " ";
                DataTable dt5 = DataAccess.GetDataTable(sql5);
                cmbitems.DataSource = dt5;
                cmbitems.DisplayMember = "product_id";

                string sql = " Select product_name, product_id, price,UOMID  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID and purchase.TenentID = tbl_item_uom_price.TenentID  " +
                             " Where purchase.TenentID = " + Tenent.TenentID + " ";
                // string sql = " select  * from purchase a, sales_item b where a.product_id = '8940000000003' limit 11 ";
                DataTable dt = DataAccess.GetDataTable(sql);

                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dt);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
                //this.reportViewer1.ZoomPercent = 35;
                this.reportViewer1.RefreshReport();
            }
            catch
            {
            }

        }
        private void bntSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string UOMID = UOMBOX.Text.ToString();
                string sql = " select  product_name, product_id, price,UOMID  " +
                             " FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID  and purchase.TenentID = tbl_item_uom_price.TenentID " +
                             " where purchase.TenentID =" + Tenent.TenentID + " and  product_id = '" + cmbitems.Text + "' and UOMID='" + UOMID + "' limit  " + txtQuantity.Text + " ";
                DataTable dt = DataAccess.GetDataTable(sql);
                List<vw_ItemUOM> ListF = new List<vw_ItemUOM>();
                int NO = Convert.ToInt32(txtQuantity.Text);
                for (int j = 1; j <= NO; j++)
                {
                    List<vw_ItemUOM> List = new List<vw_ItemUOM>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vw_ItemUOM Items = new vw_ItemUOM();
                        Items.product_id = dt.Rows[i]["product_id"].ToString();
                        Items.product_name = dt.Rows[i]["product_name"].ToString();
                        Items.UOMID = dt.Rows[i]["UOMID"].ToString();
                        Items.price = Convert.ToDecimal(dt.Rows[i]["price"]);
                        List.Add(Items);
                    }
                    foreach (vw_ItemUOM items in List)
                    {
                        ListF.Add(items);
                    }
                }

                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", ListF);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
                // this.reportViewer1.ZoomPercent = 35;
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                // yogesh string sql = " select Top " + txtQuantity.Text + " product_name, product_id, price "+
                //              "  from purchase a, sales_item b where a.product_id = '" + cmbitems.Text + "'    ";
                //string sql = " select Top " + txtQuantity.Text + " product_name, product_id, price,UOMID " +
                //              "  FROM  purchase INNER JOIN tbl_item_uom_price ON purchase.product_id = tbl_item_uom_price.itemID where product_id = '" + cmbitems.Text + "'    ";
                //DataAccess.ExecuteSQL(sql);
                //DataTable dt = DataAccess.GetDataTable(sql);

                string product_id = cmbitems.Text.ToString();
                string UOMID = UOMBOX.Text.ToString();
                int NO = Convert.ToInt32(txtQuantity.Text);
                List<vw_ItemUOM> ListF = new List<vw_ItemUOM>();
                for (int i = 1; i <= NO; i++)
                {
                    List<vw_ItemUOM> LIST = DB.vw_ItemUOM.Where(p => p.product_id == product_id && p.UOMID == UOMID).ToList();
                    foreach (vw_ItemUOM items in LIST)
                    {
                        ListF.Add(items);
                    }
                }

                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", ListF);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
                // this.reportViewer1.ZoomPercent = 35;
                this.reportViewer1.RefreshReport();
            }
            catch
            {
            }
        }

        private void btnlink_Click(object sender, EventArgs e)
        {
            //CreateBarcode go = new CreateBarcode();
            //go.MdiParent = this.ParentForm;
            //go.Show();
            BarCode.BarcodeCreator go = new BarCode.BarcodeCreator();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void cmbitems_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql6 = "select DISTINCT UOMID  FROM  tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID='" + cmbitems.Text + "'";
            DataAccess.ExecuteSQL(sql6);
            DataTable dt6 = DataAccess.GetDataTable(sql6);
            UOMBOX.DataSource = dt6;
            UOMBOX.DisplayMember = "UOMID";
        }


    }
}
