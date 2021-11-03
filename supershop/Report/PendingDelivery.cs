using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop.Report
{
    public partial class PendingDelivery : Form
    {
        public PendingDelivery()
        {
            InitializeComponent();

            //dtGrdvOrderDetails
            DataGridViewButtonColumn Action = new DataGridViewButtonColumn();
            this.dtGrdvOrderDetails.Columns.Add(Action);
            Action.HeaderText = "Action";
            Action.Text = "Action عمل";
            Action.Name = "Action";
            Action.ToolTipText = "Action";
            Action.UseColumnTextForButtonValue = true;

            dtDriverStartDate.Format = DateTimePickerFormat.Custom;
            dtDriverStartDate.CustomFormat = "yyyy-MM-dd";
            dtDriverEndDate.Format = DateTimePickerFormat.Custom;
            dtDriverEndDate.CustomFormat = "yyyy-MM-dd";
        }

        private void PendingDelivery_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime StartDate = DateTime.Now.AddDays(-7);
                DateTime EndDate = DateTime.Now;

                dtDriverStartDate.Text = StartDate.ToString("yyyy-MM-dd");
                dtDriverEndDate.Text = EndDate.ToString("yyyy-MM-dd");

                txtReciptNO.Text = "";
                Daywice(dtDriverStartDate.Text, dtDriverEndDate.Text);
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtDriverStartDate.Text == "")
            {
                MessageBox.Show("Please Select From Date ");
            }
            else if (dtDriverEndDate.Text == "")
            {
                MessageBox.Show("Please Select To Date ");
            }
            else
            {
                try
                {
                    txtReciptNO.Text = "";
                    Daywice(dtDriverStartDate.Text, dtDriverEndDate.Text);
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        private void dtDriverStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtDriverStartDate.Text == "")
            {
                MessageBox.Show("Please Select From Date ");
            }
            else if (dtDriverEndDate.Text == "")
            {
                MessageBox.Show("Please Select To Date ");
            }
            else
            {
                try
                {
                    txtReciptNO.Text = "";
                    Daywice(dtDriverStartDate.Text, dtDriverEndDate.Text);

                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        public void Daywice(string startDate, string EndDate)
        {
            dtGrdvOrderDetails.Refresh();
            string sql = " SELECT  si.InvoiceNO as 'Receipt' ,  si.orderTotal as 'Order Amount' ,   si.sales_time as 'Date'," +
                         " CASE     WHEN si.driver = '0' THEN ''   WHEN si.driver != '0' THEN si.driver    END 'driver' ," +
                         " CASE     WHEN si.COD = 0 THEN 'Paid'   WHEN si.COD = '1' THEN 'COD'    END 'COD' ," +
                         " CASE " +
                         " WHEN si.OrderStutas = 'Paid-Ready to Delivery' THEN 'Pending' " +                         
                         " WHEN si.orderStutas = 'COD-Ready to Delivery' THEN 'Pending' " +
                         " WHEN si.OrderStutas = 'Paid - Delivered' THEN 'Deliverd' " +
                         " WHEN si.orderStutas = 'Deliverd & Cash Recived' THEN 'Deliverd' " +
                         " WHEN si.orderStutas = 'Deliverd' THEN 'Deliverd' " +
                         " WHEN si.orderStutas = 'Return' THEN 'Return' END 'Status' " +
                         " FROM  sales_item si " +
                         " left join  sales_payment sp " +
                         " ON si.sales_id = sp.sales_id and si.TenentID = sp.TenentID " +
                         " left join purchase p " +
                         " ON p.product_id = si.itemcode and p.TenentID = si.TenentID " +
                         " left join  tbl_item_uom_price tiu " +
                         " ON tiu.itemID = si.itemcode and tiu.TenentID = si.TenentID " +
                         " where si.status = 1 and si.paymentMode!='Draft'  and (si.orderStutas !='Deliverd' and si.orderStutas !='Return' and si.orderStutas !='Deliverd & Cash Recived')  and  si.Qty != 0 and  si.TenentID=" + Tenent.TenentID + " and si.sales_time between  '" + startDate + "'  and '" + EndDate + "' " +
                         " group by si.sales_id " +
                         "  order by si.sales_time asc ";           
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dtGrdvOrderDetails.DataSource = dt1;
            dtGrdvOrderDetails.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dtGrdvOrderDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns["Action"].DisplayIndex = 6;

        }

        private void dtGrdvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrdvOrderDetails.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvOrderDetails.Rows[e.RowIndex];

                    string id = row.Cells["Receipt"].Value.ToString();
                    int CursorY = Cursor.Position.Y;
                    if (e.RowIndex >= 6)
                    {
                        CursorY = 476;
                    }

                    ShowDriverAction(id, CursorY);
                }
                else
                {
                    DataGridViewRow row = dtGrdvOrderDetails.Rows[e.RowIndex];

                    string id = row.Cells["Receipt"].Value.ToString();
                    int CursorY = Cursor.Position.Y;
                    if (e.RowIndex >= 6)
                    {
                        CursorY = 476;
                    }

                    ShowDriverAction(id, CursorY);
                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        public void ShowDriverAction(string InvoiceNO, int CursorY)
        {
            string salesID = SalesRegister.GetSalesID(InvoiceNO);
            string sql3 = "select * from sales_item where TenentID =" + Tenent.TenentID + " and sales_id=" + salesID + " ";           
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            int cal = Cursor.Position.X;
            int CursorX = cal - 350;

            if (dt1.Rows.Count > 0)
            {
                if (Application.OpenForms["DriverAction"] != null)
                {
                    Application.OpenForms["DriverAction"].Close();
                }

                DriverAction mkc1 = new DriverAction(CursorX, CursorY);
                mkc1.OrderNO = InvoiceNO;
                mkc1.Show();

            }
        }

        private void txtReciptNO_TextChanged(object sender, EventArgs e)
        {
            if (txtReciptNO.Text == "")
            {
                MessageBox.Show("Please Recipt NO ");
            }
            else
            {
                try
                {
                    dtGrdvOrderDetails.Refresh();
                    string sql = " SELECT  si.InvoiceNO as 'Receipt' ,  si.orderTotal as 'Order Amount' ,   si.sales_time as 'Date', " +
                                 " CASE     WHEN si.driver = '0' THEN ''   WHEN si.driver != '0' THEN si.driver    END 'driver' ," +
                                 " CASE     WHEN si.COD = 0 THEN 'Paid'   WHEN si.COD = '1' THEN 'COD'    END 'COD' ," +
                                 " CASE " +
                                 " WHEN si.OrderStutas = 'Paid-Ready to Delivery' THEN 'Pending' " +                                 
                                 " WHEN si.orderStutas = 'COD-Ready to Delivery' THEN 'Pending' " +
                                 " WHEN si.OrderStutas = 'Paid - Delivered' THEN 'Deliverd' " +
                                 " WHEN si.orderStutas = 'Deliverd & Cash Recived' THEN 'Deliverd' " +
                                 " WHEN si.orderStutas = 'Deliverd' THEN 'Deliverd' END 'Status' " +
                                 " FROM  sales_item si " +
                                 " left join  sales_payment sp " +
                                 " ON si.sales_id = sp.sales_id and si.TenentID = sp.TenentID " +
                                 " left join purchase p " +
                                 " ON p.product_id = si.itemcode and p.TenentID = si.TenentID " +
                                 " left join  tbl_item_uom_price tiu " +
                                 " ON tiu.itemID = si.itemcode and tiu.TenentID = si.TenentID " +
                                 " where si.status = 1 and si.paymentMode!='Draft'  and (si.orderStutas !='Deliverd' and si.orderStutas !='Return' and si.orderStutas !='Deliverd & Cash Recived') and si.Qty != 0 and  si.TenentID=" + Tenent.TenentID + " and si.InvoiceNO like '%" + txtReciptNO.Text + "%'  " +
                                 " group by si.sales_id " +
                                 " order by si.item_id asc ";                   
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    dtGrdvOrderDetails.DataSource = dt1;
                    dtGrdvOrderDetails.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
                    dtGrdvOrderDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns["Action"].DisplayIndex = 6;


                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             bool ISrun = backSyncro.isRun;
             if (ISrun != true)
             {
                 if (txtReciptNO.Text == "")
                 {
                     if (dtDriverStartDate.Text == "")
                     {
                         MessageBox.Show("Please Select From Date ");
                     }
                     else if (dtDriverEndDate.Text == "")
                     {
                         MessageBox.Show("Please Select To Date ");
                     }
                     else
                     {
                         try
                         {
                             txtReciptNO.Text = "";
                             Daywice(dtDriverStartDate.Text, dtDriverEndDate.Text);
                         }
                         catch
                         {
                             // MessageBox.Show("There is no Data in this date");
                         }
                     }
                 }
             }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DashBoard"] != null)
            {
                DashBoard go = (DashBoard)Application.OpenForms["DashBoard"];
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent]; ;
                go.Show();
            }
            else
            {
                DashBoard go = new DashBoard();
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent]; ;
                go.Show();
            }
            this.Close();
        }
    }
}
