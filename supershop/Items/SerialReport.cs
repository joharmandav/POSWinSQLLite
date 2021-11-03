using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace supershop.Items
{
    public partial class rptSerialReport : Form
    {
        public rptSerialReport()
        {
            InitializeComponent();


           
            string dtstart = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
            string dtend = DateTime.Now.ToString("yyyy-MM-dd");


            datagrdReportDetails.EnableHeadersVisualStyles = false;
            datagrdReportDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            Binditemname();
            int PID = Convert.ToInt32(lblFirstProduct.Text);
            databind(PID);
        }

        public void Binditemname()
        {
            //comboEmployee

            comboitem.Items.Clear();

            string sqlCust = "select product_name || ' ~ ' || product_id as 'itemname' From purchase where TenentID=" + Tenent.TenentID + " and IsSerialize=1 ";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            string First = "";
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    string itemname = dtCust.Rows[i]["itemname"].ToString();
                    if (First == "")
                    {
                       
                        string [] PID=itemname.Split('~');
                        First = PID[1].ToString();
                        lblFirstProduct.Text = First;
                    }
                    comboitem.Items.Add(itemname);
                }
            }
            comboitem.SelectedIndex = 0;

            if (dtCust != null)
            {
                AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
                foreach (DataRow rw in dtCust.Rows)
                {
                    string Val = rw["itemname"].ToString();
                    AutoItem.Add(Val);

                }
                comboitem.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboitem.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboitem.AutoCompleteCustomSource = AutoItem;
            }

            //comboEmployee.DataSource = dtCust;
            //comboEmployee.DisplayMember = "Name";
            //comboEmployee.ValueMember = "id";
        }

        public void databind(int ProductID)
        {

            try
            {




                string StrInput = "select (select product_name || ' ~ ' || product_id as 'itemname' From purchase where TenentID=" + Tenent.TenentID + " and IsSerialize=1 and product_id=" + ProductID + " ) as 'Product Name',UOM,Serial_Number,OpQty,OnHand,QtyOut,QtyReceived,QtyReserved from ICIT_BR_Serialize where TenentID=" + Tenent.TenentID + " and MyProdID=" + ProductID + " ";
                DataTable dtInput = DataAccess.GetDataTable(StrInput);
                if (dtInput.Rows.Count > 0)
                {
                    datagrdReportDetails.DataSource = dtInput;
                }
                else
                {
                    datagrdReportDetails.DataSource = null;
                }


            }
            catch //(Exception)
            {
                datagrdReportDetails.DataSource = null;
            }
        }

        //Filter Date to Date
       

        #region Printing
        DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            string sql3 = "select * from tbl_terminalLocation where TenentID = " + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            DateTime dt = DateTime.Now;
            string printdate = dt.ToString("MMMM dd, yyyy    hh:mm:ss tt");
            string Companyname = dt1.Rows[0].ItemArray[1].ToString();
            string branchname = dt1.Rows[0].ItemArray[2].ToString();
            string Location = dt1.Rows[0].ItemArray[3].ToString();
            string phone = dt1.Rows[0].ItemArray[4].ToString();
            string email = dt1.Rows[0].ItemArray[5].ToString();
            string web = dt1.Rows[0].ItemArray[6].ToString();

            string Header = Companyname + "\n" + Location + "." + "\n" + email + "\n" + branchname + " ph: " + phone + "\n" + printdate + "\n";

            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;


            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            printDocument1.DocumentName = "Product wise Serial Reports";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            printDocument1, true, true, Header + " Product wise Serial Reports \n", new Font("Baskerville Old Face", 14,
            FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);


            return true;
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.datagrdReportDetails.RowsDefaultCellStyle.BackColor = Color.White;
                this.datagrdReportDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                if (SetupThePrinting())
                {
                    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    MyPrintPreviewDialog.WindowState = FormWindowState.Maximized;
                    MyPrintPreviewDialog.PrintPreviewControl.Zoom = 1.0;
                    MyPrintPreviewDialog.Document = printDocument1;
                    MyPrintPreviewDialog.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("!!! Please Print Preview or Setup Print only for First time " + exp.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }
        #endregion

        private void datagrdpurchasehistory_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch
            {

            }
        }

       

        private void btnrefrash_Click(object sender, EventArgs e)
        {
            Binditemname();
        }

        private void comboitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] PIDlist = comboitem.Text.Split('~');
            lblFirstProduct.Text = PIDlist[1].ToString(); 
            int PID = Convert.ToInt32(lblFirstProduct.Text);
            databind(PID);
        }

       
    }
}
