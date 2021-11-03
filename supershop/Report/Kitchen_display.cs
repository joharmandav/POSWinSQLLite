using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace supershop
{
    public partial class Kitchen_display : Form
    {
        string invoiceNOset = null;

        public Kitchen_display()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            dtDriverStartDate.Format = DateTimePickerFormat.Custom;
            dtDriverStartDate.CustomFormat = "yyyy-MM-dd";
            dtDriverEndDate.Format = DateTimePickerFormat.Custom;
            dtDriverEndDate.CustomFormat = "yyyy-MM-dd";

            DateTime StartDate = DateTime.Now.AddDays(-7);
            DateTime EndDate = DateTime.Now;

            dtDriverStartDate.Text = StartDate.ToString("yyyy-MM-dd");
            dtDriverEndDate.Text = EndDate.ToString("yyyy-MM-dd");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public string invoiceNO
        {
            set
            {
                invoiceNOset = value;
            }
            get
            {
                return invoiceNOset;
            }
        }

        //Show Kitchen item Products with images
        public void ItemList_with_images(string StartDate, string EndDate)
        {
            flowLayoutPanelUserList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
            try
            {
                string sql = " SELECT  si.item_id as ID ,   si.sales_id as 'ReceiptNo' ,si.InvoiceNO , si.itemName as 'ItemName' ,   sp.comment as 'Note', " +
                        "  si.Qty ,   si.Total ,   si.sales_time as 'Date', si.itemcode as itemcode,IC.UOMNAME1 as 'UOM' , p.imagename,  sp.emp_id ,tiu.Image as photo, " +
                         "  CASE   " +
                         "  WHEN si.status = 3 THEN 'Pending' " +
                         "  WHEN si.status = 1 THEN 'Served'  " +
                         "  END 'Status' " +
                         "  FROM  sales_item si " +
                         "  left join  sales_payment sp " +
                         "  ON si.sales_id = sp.sales_id and si.TenentID = sp.TenentID " +
                         "  left join purchase p " +
                         " ON p.product_id = si.itemcode and p.TenentID = si.TenentID  " +
                         " left join  tbl_item_uom_price tiu " +
                         " ON tiu.itemID = si.itemcode and tiu.TenentID = si.TenentID  " +
                         " inner join ICUOM IC on IC.UOM = si.UOM and  IC.TenentID = si.TenentID " +
                         "  where si.status = 3   and  si.Qty != 0 and si.paymentmode !='Draft' and si.TenentID=" + Tenent.TenentID + " and si.sales_time BETWEEN '" + StartDate + "' and '" + EndDate + "' " +
                         " group by si.sales_id,si.item_id " +
                         "  order by si.item_id asc ";               
                DataTable dt = DataAccess.GetDataTable(sql);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button b = new Button();
                    b.Tag = dataReader["ReceiptNo"] + "~" + dataReader["itemcode"] + "-" + dataReader["ItemName"] + "#" + dataReader["UOM"] + "=" + dataReader["Qty"];
                    b.Click += new EventHandler(b_Click);


                    //b.Name = details;
                    toolTip1.ToolTipTitle = "Click to Order Ready";
                    toolTip1.SetToolTip(b, "Press click to serve complete");

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(96, 96);
                    //il.Images.Add(Image.FromFile(img_directory + dataReader["imagename"]));

                    string image = "item.png";
                    if (dataReader["photo"] != null && dataReader["photo"].ToString() != "")
                    {
                        image = dataReader["photo"].ToString();
                        string Filename = Application.StartupPath + @"\ITEMIMAGE\" + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["photo"].ToString();
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

                    b.Size = new Size(200, 300);
                    b.Text.PadRight(4);

                    b.Text += " ========================= ";
                    b.Text += "\n Order # " + dataReader["ReceiptNo"];
                    b.Text += "\n Invoice NO # " + dataReader["InvoiceNO"];
                    b.Text += "\n Staff: " + dataReader["emp_id"];
                    b.Text += "\n Date: " + dataReader["Date"];
                    b.Text += "\n ========================= ";
                    b.Text += "\n " + dataReader["ItemName"].ToString();
                    b.Text += "\n " + dataReader["UOM"].ToString();
                    b.Text += "\n Qty: " + dataReader["Qty"];
                    // b.Text += "\n Total: " + dataReader["Total"];
                    b.Text += "\n Note: " + dataReader["Note"];



                    b.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.TextImageRelation = TextImageRelation.ImageAboveText;
                    b.BackColor = Color.White;

                    flowLayoutPanelUserList.Controls.Add(b);
                    flowLayoutPanelUserList.Refresh();
                    currentImage++;

                }
            }
            catch //(Exception)
            {

                //throw;
            }
        }

        public void ItemList_with_images_invoice()
        {
            flowLayoutPanelUserList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
            try
            {
                string sql = " SELECT  si.item_id as ID ,   si.sales_id as 'ReceiptNo' ,si.InvoiceNO , si.itemName as 'ItemName' ,   sp.comment as 'Note', " +
                        "  si.Qty ,   si.Total ,   si.sales_time as 'Date', si.itemcode as itemcode,IC.UOMNAME1 as 'UOM' , p.imagename,  sp.emp_id ,tiu.Image as photo, " +
                         "  CASE   " +
                         "  WHEN si.status = 3 THEN 'Pending' " +
                         "  WHEN si.status = 1 THEN 'Served'  " +
                         "  END 'Status' " +
                         "  FROM  sales_item si " +
                         "  left join  sales_payment sp " +
                         "  ON si.sales_id = sp.sales_id and si.TenentID = sp.TenentID " +
                         "  left join purchase p " +
                         " ON p.product_id = si.itemcode and p.TenentID = si.TenentID " +
                         " left join  tbl_item_uom_price tiu " +
                         " ON tiu.itemID = si.itemcode and tiu.TenentID = si.TenentID " +
                         " inner join ICUOM IC on IC.UOM = si.UOM and  IC.TenentID = si.TenentID " +
                         "  where si.status = 3   and  si.Qty != 0 and si.paymentmode !='Draft' and si.tenentid=" + Tenent.TenentID + " and si.InvoiceNO = '" + invoiceNOset + "' " +
                         " group by si.sales_id,si.item_id " +
                         "  order by si.item_id asc ";                
                DataTable dt = DataAccess.GetDataTable(sql);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button b = new Button();
                    b.Tag = dataReader["ReceiptNo"] + "~" + dataReader["itemcode"] + "-" + dataReader["ItemName"] + "#" + dataReader["UOM"] + "=" + dataReader["Qty"];
                    b.Click += new EventHandler(b_Click);


                    //b.Name = details;
                    toolTip1.ToolTipTitle = "Click to Order Ready";
                    toolTip1.SetToolTip(b, "Press click to serve complete");

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(96, 96);
                    //il.Images.Add(Image.FromFile(img_directory + dataReader["imagename"]));

                    string image = "item.png";
                    if (dataReader["photo"] != null && dataReader["photo"].ToString() != "")
                    {
                        image = dataReader["photo"].ToString();
                        string Filename = Application.StartupPath + @"\ITEMIMAGE\" + image;
                        if (File.Exists(Filename))
                        {
                            image = dataReader["photo"].ToString();
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

                    b.Size = new Size(200, 300);
                    b.Text.PadRight(4);

                    b.Text += " ========================= ";
                    b.Text += "\n Order # " + dataReader["ReceiptNo"];
                    b.Text += "\n Invoice NO # " + dataReader["InvoiceNO"];
                    b.Text += "\n Staff: " + dataReader["emp_id"];
                    b.Text += "\n Date: " + dataReader["Date"];
                    b.Text += "\n ========================= ";
                    b.Text += "\n " + dataReader["ItemName"].ToString();
                    b.Text += "\n " + dataReader["UOM"].ToString();
                    b.Text += "\n Qty: " + dataReader["Qty"];
                    // b.Text += "\n Total: " + dataReader["Total"];
                    b.Text += "\n Note: " + dataReader["Note"];



                    b.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.TextImageRelation = TextImageRelation.ImageAboveText;
                    b.BackColor = Color.White;

                    flowLayoutPanelUserList.Controls.Add(b);
                    flowLayoutPanelUserList.Refresh();
                    currentImage++;

                }
            }
            catch //(Exception)
            {

                //throw;
            }
        }

        //Click to Served
        protected void b_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            string Button = b.Tag.ToString();
            
            string OrderNO = b.Tag.ToString().Split('~')[0];
            string Itemcode = b.Tag.ToString().Split('~')[1];
            string ItemName = Itemcode.Split('#')[0];
            string UOMQTY = b.Tag.ToString().Split('#')[1];
            string UOM = UOMQTY.ToString().Split('=')[0];
            string saleQty = b.Tag.ToString().Split('=')[1];

            Report.KD_dialog go = new Report.KD_dialog(OrderNO, ItemName, UOM, saleQty);
            go.ShowDialog();

            //string sql = " update sales_item set " +
            //               " status = 1 " +
            //               " where item_id  = '" + b.Tag.ToString() + "' ";
            //DataAccess.ExecuteSQL(sql);
            //DataTable dt1 = DataAccess.GetDataTable(sql);
            //ItemList_with_images();
        }

        public void kitchen_displayDataload()
        {
            string sql = " SELECT  si.item_id as ID ,   si.sales_id as 'Receipt No' ,    si.itemName as 'Item Name' ,   sp.comment as 'Note',  si.Qty ,   si.Total ,   si.sales_time as 'Date', " +
                     "  CASE   " +
                     "  WHEN si.status = 3 THEN 'Pending' " +
                     "  WHEN si.status = 1 THEN 'Served'  " +
                     "  END 'Delevery' " +
                     "  FROM  sales_item si " +
                     "  left join  sales_payment sp " +
                     "  ON si.sales_id = sp.sales_id and si.TenentID = sp.TenentID " +
                     "  where si.TenentID = " + Tenent.TenentID + " and si.status = 3 " +
                     "  order by si.sales_id desc ";            
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dtgridKitchenWaitingList.DataSource = dt1;
            //  dtgridKitchenWaitingList.Columns[5].DefaultCellStyle.ForeColor = Color.DarkViolet;
        }

        private void Kitchen_display_Load(object sender, EventArgs e)
        {
            try
            {
                if (invoiceNOset == null)
                {
                    ItemList_with_images(dtDriverStartDate.Text, dtDriverEndDate.Text);
                }
                else
                {
                    ItemList_with_images_invoice();
                }


                //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                //dtgridKitchenWaitingList.Columns.Add(btn);
                //btn.HeaderText = "Action";
                //btn.Text = "Served";
                //btn.Name = "btn";
                //btn.UseColumnTextForButtonValue = true;
                //kitchen_displayDataload();
            }
            catch
            {
            }
        }

        private void dtgridKitchenWaitingList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row2 in dtgridKitchenWaitingList.SelectedRows)
                {
                    //  DialogResult result = MessageBox.Show("Are you sure this item ready to Serve?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    // if (result == DialogResult.Yes)
                    // {
                    DataGridViewRow row = dtgridKitchenWaitingList.Rows[e.RowIndex];
                    string item_id = row.Cells[1].Value.ToString();

                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql = " update sales_item set " +
                                " status = 1, " +
                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                " where item_id  = '" + item_id + "' and TenentID= " + Tenent.TenentID + " ";
                    DataAccess.ExecuteSQL(sql);

                    string sqlwin = " update Win_sales_item set " +
                                " status = 1, " +
                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                " where item_id  = '" + item_id + "' and TenentID= " + Tenent.TenentID + " ";
                    Datasyncpso.insert_Live_sync(sqlwin, "Win_sales_item", "UPDATE");

                    kitchen_displayDataload();
                    //    MessageBox.Show("Item has been Served", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2); ;
                    // }
                }
            }
            catch
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bool ISrun = backSyncro.isRun;
                if (ISrun != true)
                {
                    if (invoiceNOset == null)
                    {
                        ItemList_with_images(dtDriverStartDate.Text, dtDriverEndDate.Text);
                    }
                    else
                    {
                        ItemList_with_images_invoice();
                    }
                }
            }
            catch
            {
            }
        }

        private void dtDriverStartDate_ValueChanged(object sender, EventArgs e)
        {
            invoiceNOset = null;
            ItemList_with_images(dtDriverStartDate.Text, dtDriverEndDate.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            invoiceNOset = null;
            ItemList_with_images(dtDriverStartDate.Text, dtDriverEndDate.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
