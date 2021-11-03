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
    public partial class PendingKitchen : Form
    {
        public PendingKitchen()
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

                if (UserInfo.usertype == "1")
                {
                    btnReset.Visible = true;
                }
                else
                {
                    btnReset.Visible = false;
                }
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
            string sql = "SELECT  si.InvoiceNO, si.sales_time as 'Date',   sp.emp_id , " +
                         " CASE  WHEN si.status = 3 THEN 'Pending'  WHEN si.status = 1 THEN 'Served'   END 'Status' " +
                         " FROM  sales_item si left join  sales_payment sp  ON si.sales_id = sp.sales_id and si.TenentID = sp.TenentID " +
                         " left join purchase p ON p.product_id = si.itemcode and p.TenentID = si.TenentID " +
                         " left join  tbl_item_uom_price tiu  ON tiu.itemID = si.itemcode and tiu.TenentID = si.TenentID " +
                         " where si.status = 3 and si.sales_time between '" + startDate + "' and '" + EndDate + "'  and  si.Qty != 0 and si.paymentmode !='Draft' and si.TenentID=" + Tenent.TenentID + " " +
                         " group by si.sales_id order by si.item_id asc ";

            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dtGrdvOrderDetails.DataSource = dt1;
            dtGrdvOrderDetails.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dtGrdvOrderDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtGrdvOrderDetails.Columns["Action"].DisplayIndex = 4;

        }

        public void ShowKitchen(string id)
        {
            if (UserInfo.usertype == "1")
            {
                if (Application.OpenForms["Kitchen_display"] != null)
                {
                    Application.OpenForms["Kitchen_display"].Close();
                }
                this.Refresh();
                Kitchen_display go = new Kitchen_display();
                go.invoiceNO = id;
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }
            if (UserInfo.usertype == "2")
            {
                if (Application.OpenForms["Kitchen_display"] != null)
                {
                    Application.OpenForms["Kitchen_display"].Close();
                }
                this.Refresh();
                Kitchen_display go = new Kitchen_display();
                go.invoiceNO = id;
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }
            if (UserInfo.usertype == "4")
            {
                if (Application.OpenForms["Kitchen_display"] != null)
                {
                    Application.OpenForms["Kitchen_display"].Close();
                }
                this.Refresh();
                Kitchen_display go = new Kitchen_display();
                go.invoiceNO = id;
                go.MdiParent = Application.OpenForms[UserInfo.MDiPerent];
                go.Show();
            }

        }

        private void dtGrdvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrdvOrderDetails.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtGrdvOrderDetails.Rows[e.RowIndex];

                    string id = row.Cells["InvoiceNO"].Value.ToString();

                    ShowKitchen(id);
                }
                else
                {
                    DataGridViewRow row = dtGrdvOrderDetails.Rows[e.RowIndex];

                    string id = row.Cells["InvoiceNO"].Value.ToString();

                    ShowKitchen(id);
                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
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
                    string sql = "SELECT  si.InvoiceNO, si.sales_time as 'Date',   sp.emp_id , " +
                         " CASE  WHEN si.status = 3 THEN 'Pending'  WHEN si.status = 1 THEN 'Served'   END 'Status' " +
                         " FROM  sales_item si left join  sales_payment sp  ON si.sales_id = sp.sales_id and si.TenentID = sp.TenentID " +
                         " left join purchase p ON p.product_id = si.itemcode and p.TenentID = si.TenentID " +
                         " left join  tbl_item_uom_price tiu  ON tiu.itemID = si.itemcode and tiu.TenentID = si.TenentID " +
                         " where si.status = 3 and  si.Qty != 0 and si.paymentmode !='Draft' and si.TenentID=" + Tenent.TenentID + " and si.InvoiceNO like '%" + txtReciptNO.Text + "%' " +
                         " group by si.sales_id order by si.item_id asc ";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    dtGrdvOrderDetails.DataSource = dt1;
                    dtGrdvOrderDetails.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
                    dtGrdvOrderDetails.Columns["Action"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dtGrdvOrderDetails.Columns["Action"].DisplayIndex = 4;
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
            if (UserInfo.usertype == "1")
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
            }            
            
            this.Close();
        }
    }
}
