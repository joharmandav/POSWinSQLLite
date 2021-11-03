using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop.Items
{
    public partial class Perishable : Form
    {
        public Perishable(string productid, string uom, double MY_TRANS_ID, string MySysName)//Constructor and nothing return
        {
            InitializeComponent();
            lblprodid.Text = productid;
            lblUom.Text = uom;

            lblMYTRANSID.Text = MY_TRANS_ID.ToString();
            lblMYSYSNAME.Text = MySysName;
        }

        public string Qty
        {
            set { txtQty.Text = value; lblRestQty.Text = value; lblTotalQty.Text = value; }
            get { return txtQty.Text; }
        }

        private void Perishable_Load(object sender, EventArgs e)
        {
            BindData();
        }
        public void BindData()
        {
            dataGridView1.DataSource = null;
            //dataGridView1.Rows.Clear();

            //int UOMID = getuomid();
            int UOMID = Convert.ToInt32(lblUom.Text);
            double MYTRANSID = Convert.ToDouble(lblMYTRANSID.Text);
            string MySysName = lblMYSYSNAME.Text;

            string sql = "select BatchNo as 'Batch No' ,NewQty as 'Qty',ProdDate as 'Product Date', " +
                "ExpiryDate as 'Expiry Date',LeadDays2Destroy as 'Lead Days to Destroy' from ICIT_BR_TMP where TenentID=" + Tenent.TenentID + " and MyProdID = " + lblprodid.Text + " and UOM=" + UOMID + " and MYTRANSID=" + MYTRANSID + "  and MySysName='" + MySysName + "' ";
            DataTable dt5 = DataAccess.GetDataTable(sql);
            if (dt5.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt5;
            }

        }

        DateTimePicker oDateTimePicker1;
        DateTimePicker oDateTimePicker2;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                oDateTimePicker1 = new DateTimePicker();
                dataGridView1.Controls.Add(oDateTimePicker1);
                oDateTimePicker1.Format = DateTimePickerFormat.Short;
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker1.Size = new Size(oRectangle.Width, oRectangle.Height);
                oDateTimePicker1.Location = new Point(oRectangle.X, oRectangle.Y);
                oDateTimePicker1.CloseUp += new EventHandler(oDateTimePicker1_CloseUp);
                oDateTimePicker1.TextChanged += new EventHandler(dateTimePicker1_OnTextChange);
                oDateTimePicker1.Visible = true;
            }

            if (e.ColumnIndex == 3)
            {
                oDateTimePicker2 = new DateTimePicker();
                dataGridView1.Controls.Add(oDateTimePicker2);
                oDateTimePicker2.Format = DateTimePickerFormat.Short;
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker2.Size = new Size(oRectangle.Width, oRectangle.Height);
                oDateTimePicker2.Location = new Point(oRectangle.X, oRectangle.Y);
                oDateTimePicker2.CloseUp += new EventHandler(oDateTimePicker2_CloseUp);
                oDateTimePicker2.TextChanged += new EventHandler(dateTimePicker2_OnTextChange);
                oDateTimePicker2.Visible = true;
            }

        }

        private void dateTimePicker1_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell
            dataGridView1.CurrentCell.Value = oDateTimePicker1.Text.ToString();
        }

        void oDateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use 
            oDateTimePicker1.Visible = false;
        }

        private void dateTimePicker2_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell
            dataGridView1.CurrentCell.Value = oDateTimePicker2.Text.ToString();
        }

        void oDateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use 
            oDateTimePicker2.Visible = false;
        }

        public int getuomid()
        {
            int UOM = 0;

            string UOMNAME1 = lblUom.Text.Trim();
            string sql12 = " select * from ICUOM where UOMNAME1 = '" + UOMNAME1 + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                UOM = Convert.ToInt32(dt1.Rows[0]["UOM"]);
            }
            return UOM;
        }

        public int GetDridQty()
        {
            int qty = 0;
            int rows = dataGridView1.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                qty += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
            }

            return qty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "0")
            {
                MessageBox.Show("Please Enter At least 1 Qty");
                txtQty.Focus();
                return;
            }

            int qty = GetDridQty();
            int TotalQty = Convert.ToInt32(lblTotalQty.Text);
            if (TotalQty < qty)
            {
                MessageBox.Show("Please Enter less than or Equal of Sum of List Qty");
                txtQty.Focus();
                return;
            }
            else
            {
                lblRestQty.Text = (TotalQty - qty).ToString();
            }

            double MyProdID = Convert.ToDouble(lblprodid.Text);
            //int UOMID = getuomid();
            int UOMID = Convert.ToInt32(lblUom.Text);
            string Batch_No = txtBatchNO.Text;
            int qty1 = Convert.ToInt32(txtQty.Text);
            string ProdDate1 = dateProduct.Text;
            string ExpiryDate1 = dateExpiry.Text;
            string LeadDays2Destroy1 = txtLeadTO.Text;
            double MYTRANSID = lblMYTRANSID.Text != "" ? Convert.ToDouble(lblMYTRANSID.Text) : 0;
            string MySysName = lblMYSYSNAME.Text;
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string q = "select * from ICIT_BR_TMP where TenentID=" + Tenent.TenentID + " and MyProdID =" + lblprodid.Text + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
            DataTable dt1 = DataAccess.GetDataTable(q);
            if (dt1.Rows.Count < 1)
            {
                string period_code = "201801";
                int SIZECODE = 999999998;
                int COLORID = 999999998;
                int Bin_ID = 999999998;
                string Serial_Number = "NO";
                string RecodName = "Perishable";

                int LocationID = 1;

                int ID = DataAccess.getICIT_BR_TMPMYid(Tenent.TenentID, MyProdID, UOMID);

                string sql1 = "insert into ICIT_BR_TMP (TenentID,ID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID,	Bin_ID, BatchNo, Serial_Number, MYTRANSID, LocationID, " +
                              " NewQty,  ProdDate, ExpiryDate, LeadDays2Destroy, RecodName,Active, Uploadby ,UploadDate ,SynID)" +
                              " values (" + Tenent.TenentID + " ," + ID + ", '" + MyProdID + "','" + period_code + "', '" + MySysName + "', '" + UOMID + "', " +
                              " '" + SIZECODE + "','" + COLORID + "','" + Bin_ID + "','" + Batch_No + "', '" + Serial_Number + "', '" + MYTRANSID + "', '" + LocationID + "', " +
                              " '" + qty1 + "', '" + ProdDate1 + "', '" + ExpiryDate1 + "', '" + LeadDays2Destroy1 + "','" + RecodName + "', 'Y', " +
                              " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                int flag1 = DataAccess.ExecuteSQL(sql1);

                string sql1wev = "insert into ICIT_BR_TMP (TenentID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID,	Bin_ID, BatchNo, Serial_Number, MYTRANSID, LocationID, " +
                             " NewQty, OpQty , ProdDate, ExpiryDate, LeadDays2Destroy, RecodName,Active, Uploadby ,UploadDate ,SynID)" +
                             " values (" + Tenent.TenentID + " , '" + MyProdID + "','" + period_code + "', '" + MySysName + "', '" + UOMID + "', " +
                             " '" + SIZECODE + "','" + COLORID + "','" + Bin_ID + "','" + Batch_No + "', '" + Serial_Number + "', '" + MYTRANSID + "', '" + LocationID + "', " +
                             " '" + qty1 + "',0; '" + ProdDate1 + "', '" + ExpiryDate1 + "', '" + LeadDays2Destroy1 + "','" + RecodName + "', 'Y', " +
                             " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";

                Datasyncpso.insert_Live_sync(sql1wev, "ICIT_BR_TMP", "INSERT");
               

            }
            else
            {
                string sql1 = "Update ICIT_BR_TMP set NewQty='" + qty1 + "', ProdDate='" + ProdDate1 + "' ,ExpiryDate='" + ExpiryDate1 + "' ,LeadDays2Destroy = '" + LeadDays2Destroy1 + "' , " +
                              " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                              " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                DataAccess.ExecuteSQL(sql1);
                Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMP", "UPDATE");
               
            }

            BindData();
            clear();
        }

        public void clear()
        {
            txtBatchNO.Text = "";
            txtQty.Text = "0";
            txtLeadTO.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text != "" && lblRestQty.Text != "-" && lblTotalQty.Text != "-")
            {

                int Enter = Convert.ToInt32(txtQty.Text);
                int TotalQty = Convert.ToInt32(lblTotalQty.Text);
                int restQty = Convert.ToInt32(lblRestQty.Text);

                if (Enter > TotalQty)
                {
                    MessageBox.Show("Please Enter less than or Equal of " + TotalQty + " Qty");
                    txtQty.Focus();
                    return;
                }

                if (Enter > restQty)
                {
                    MessageBox.Show("Please Enter less than or Equal of " + restQty + " Qty");
                    txtQty.Focus();
                    return;
                }

                int Gridqty = GetDridQty();
                lblRestQty.Text = (TotalQty - Gridqty).ToString();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
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

    }
}


