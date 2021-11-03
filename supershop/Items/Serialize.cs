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
    public partial class Serialize : Form
    {
        public Serialize(string productid, string uom, double MY_TRANS_ID, string MySysName)//Constructor and nothing return
        {
            InitializeComponent();
            lblprodid.Text = productid;
            lblUom.Text = uom;

            lblMYTRANSID.Text = MY_TRANS_ID.ToString();
            lblMYSYSNAME.Text = MySysName;

            txtSerial.Text = "";
            txtSerial.Focus();



        }

        public string Qty
        {
            set { lblTotalQty.Text = value; }
            get { return lblTotalQty.Text; }
        }
       
        private void Perishable_Load(object sender, EventArgs e)
        {


            this.dgrvMultiUomList.Columns.Add("Serial", "Serial");

            dgrvMultiUomList.Columns["Serial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgrvMultiUomList.Columns["Serial"].DefaultCellStyle.ForeColor = Color.Black;
            dgrvMultiUomList.Columns["Serial"].DefaultCellStyle.BackColor = Color.Silver;
            dgrvMultiUomList.Columns["Serial"].DefaultCellStyle.SelectionForeColor = Color.Black;
            dgrvMultiUomList.Columns["Serial"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            dgrvMultiUomList.Columns["Serial"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            dgrvMultiUomList.Columns["Serial"].Width = 200;
            //BindData();

            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            dgrvMultiUomList.Columns.Add(del);
            del.HeaderText = "X";
            del.Text = "x";
            del.Name = "del";
            del.ToolTipText = "Delete this Item";
            del.UseColumnTextForButtonValue = true;
            dgrvMultiUomList.Columns["Del"].Width = 40;

            string q = "select Serial_Number from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + lblprodid.Text + "  and UOM='" + lblUom.Text + "' and MYTRANSID='" + lblMYTRANSID.Text + "' and MySysName='" + lblMYSYSNAME.Text + "' and RecodName='Serialize' ";
            DataTable dt1 = DataAccess.GetDataTable(q);
            if (dt1.Rows.Count >= 1)
            {
                string Serial = "";
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    Serial = dt1.Rows[i]["Serial_Number"].ToString().Trim();
                    dgrvMultiUomList.Rows.Add(Serial);
                }
            }
            txtSerial.Text = "";
            txtSerial.Focus();
           

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Once Final Save for Serialized item will not be change, Please make sure you are entering right serialization of item.", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                int rows = dgrvMultiUomList.Rows.Count;
                int tqty = Convert.ToInt32(lblTotalQty.Text);
                if (rows == tqty)
                {
                    double MyProdID = Convert.ToDouble(lblprodid.Text);
                    //int UOMID = getuomid();
                    int UOMID = Convert.ToInt32(lblUom.Text);

                    string ProdDate1 = dateProduct.Text;

                    double MYTRANSID = lblMYTRANSID.Text != "" ? Convert.ToDouble(lblMYTRANSID.Text) : 0;
                    string MySysName = lblMYSYSNAME.Text;
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string Serial = "";

                    string sql2 = "Delete from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + lblprodid.Text + "  and UOM=" + UOMID + " and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' and RecodName='Serialize' ";
                    DataAccess.ExecuteSQL(sql2);

                    for (int i = 0; i < rows; i++)
                    {
                        Serial = dgrvMultiUomList.Rows[i].Cells[0].Value.ToString().Trim();
                        if (Serial != "")
                        {
                            string q = "select * from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + lblprodid.Text + "  and UOM=" + UOMID + " and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' and Serial_Number='" + Serial + "' and RecodName='Serialize' ";
                            DataTable dt1 = DataAccess.GetDataTable(q);
                            if (dt1.Rows.Count < 1)
                            {
                                string period_code = "201801";
                                int SIZECODE = 999999998;
                                int COLORID = 999999998;
                                int Bin_ID = 999999998;

                                string RecodName = "Serialize";

                                int LocationID = 1;

                                int ID = DataAccess.getICIT_BR_TMPSerialize(Tenent.TenentID, MyProdID, UOMID, Serial);

                                string sql1 = "insert into ICIT_BR_TMPSerialize (TenentID,ID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID,	Bin_ID, Serial_Number, MYTRANSID, LocationID, " +
                                              " NewQty,  ProdDate,  RecodName,Active, Uploadby ,UploadDate ,SynID)" +
                                              " values (" + Tenent.TenentID + " ," + ID + ", '" + MyProdID + "','" + period_code + "', '" + MySysName + "', '" + UOMID + "', " +
                                              " '" + SIZECODE + "','" + COLORID + "','" + Bin_ID + "', '" + Serial + "', '" + MYTRANSID + "', '" + LocationID + "', " +
                                              " '" + 1 + "', '" + ProdDate1 + "','" + RecodName + "', 'Y', " +
                                              " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                                int flag1 = DataAccess.ExecuteSQL(sql1);

                                string sql1wev = "insert into ICIT_BR_TMPSerializeSerialize (TenentID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID,	Bin_ID, Serial_Number, MYTRANSID, LocationID, " +
                                             " NewQty, OpQty , ProdDate, RecodName,Active, Uploadby ,UploadDate ,SynID)" +
                                             " values (" + Tenent.TenentID + " , '" + MyProdID + "','" + period_code + "', '" + MySysName + "', '" + UOMID + "', " +
                                             " '" + SIZECODE + "','" + COLORID + "','" + Bin_ID + "', '" + Serial + "', '" + MYTRANSID + "', '" + LocationID + "', " +
                                             " '" + 1 + "',0; '" + ProdDate1 + "','" + RecodName + "', 'Y', " +
                                             " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";

                                Datasyncpso.insert_Live_sync(sql1wev, "ICIT_BR_TMPSerialize", "INSERT");

                            }
                            else
                            {

                                string sql1 = "Update ICIT_BR_TMPSerialize set  ProdDate='" + ProdDate1 + "' , " +
                                              " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                              " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + UOMID + " and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' and Serial_Number='" + Serial + "' ";
                                DataAccess.ExecuteSQL(sql1);
                                Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "UPDATE");

                            }
                        }


                    }

                    //MessageBox.Show("Once Final Save for Serialized item will not be change, Please make sure you are entering right serialization of item.");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Container item and Total Qty are not equel.");
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void dgrvMultiUomList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgrvMultiUomList.Columns["del"].Index && e.RowIndex >= 0)
            {
                //foreach (DataGridViewRow row2 in dgrvMultiUomList.SelectedRows)
                //{
                DataGridViewRow row = dgrvMultiUomList.Rows[e.RowIndex];
                if (!row.IsNewRow)
                {
                    dgrvMultiUomList.Rows.Remove(row);
                }

                //}
                txtSerial.Text = "";
                txtSerial.Focus();
            }
        }


     
        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Serial = "";
                double MYTRANSID = lblMYTRANSID.Text != "" ? Convert.ToDouble(lblMYTRANSID.Text) : 0;
                string MySysName = lblMYSYSNAME.Text;
                int UOMID = Convert.ToInt32(lblUom.Text);
                if (txtSerial.Text != "")
                {
                    string q = "select * from ICIT_BR_Serialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + lblprodid.Text + "  and UOM=" + UOMID + " and MySysName='" + MySysName + "' and Serial_Number='" + txtSerial.Text + "' ";
                    DataTable dt1 = DataAccess.GetDataTable(q);
                    if (dt1.Rows.Count < 1)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Duplicate Serial for this item");
                        txtSerial.Text = "";
                        txtSerial.Focus();
                        return;
                    }
                }
                for (int i = 0; i < dgrvMultiUomList.Rows.Count; i++)
                {
                    Serial = dgrvMultiUomList.Rows[i].Cells[0].Value.ToString().Trim();
                    if (txtSerial.Text == Serial)
                    {
                        MessageBox.Show("Duplicate Serial for this item");
                        txtSerial.Text = "";
                        txtSerial.Focus();
                        break;
                    }

                }
                int count = dgrvMultiUomList.Rows.Count + 1;
                int qty = Convert.ToInt32(lblTotalQty.Text);
                if (txtSerial.Text != "")
                {
                    if (count <= qty)
                    {
                        dgrvMultiUomList.Rows.Add(txtSerial.Text);
                        int Rowcount = dgrvMultiUomList.Rows.Count - 1;
                        dgrvMultiUomList.Rows[Rowcount].Selected = true;
                        dgrvMultiUomList.FirstDisplayedScrollingRowIndex = Rowcount;
                        txtSerial.Text = "";
                        txtSerial.Focus();
                    }
                    else
                        MessageBox.Show("Your Qty and Total Qty are equel.");
                }
            }
        }









    }
}


