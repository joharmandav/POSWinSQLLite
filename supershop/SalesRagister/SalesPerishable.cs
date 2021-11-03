using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class SalesPerishable : Form
    {
        public SalesPerishable(double productid, string ProductName, string uom, int MY_TRANS_ID, string MySysName, string Batch)
        {
            InitializeComponent();

            DataGridViewButtonColumn btnselect = new DataGridViewButtonColumn();
            dtPerishableSalesTemp.Columns.Add(btnselect);
            btnselect.HeaderText = "Select";
            btnselect.Text = "Select";
            btnselect.Name = "Select";
            btnselect.UseColumnTextForButtonValue = true;
            btnselect.Width = 70;

            lblprodid.Text = productid.ToString();
            lblproductName.Text = ProductName;
            lblUom.Text = uom;
            lblMYTRANSID.Text = MY_TRANS_ID.ToString();
            lblMYSYSNAME.Text = MySysName;
            selectBatch.Text = Batch;
        }
        public double Qty
        {
            set { lblTotalQty.Text = value.ToString(); }
            get { return Convert.ToInt32(lblTotalQty.Text); }
        }

        private void SalesPerishable_Load(object sender, EventArgs e)
        {
            BindPerishable();
        }

        public string SplitBatch(string selectBatch)
        {
            string Temp = "";

            string[] strSplit = selectBatch.Split(',');

            int Lenth = strSplit.Length;

            for (int i = 0; i < Lenth; i++)
            {
                string Temp1 = "'" + strSplit[i] + "'";
                Temp = Temp + "," + Temp1;
            }

            Temp = Temp.Trim();
            Temp = Temp.TrimStart(',');
            Temp = Temp.TrimEnd(',');

            return Temp;
        }

        public void BindPerishable()
        {
            string NotDisplay = SplitBatch(selectBatch.Text);// selectBatch.Text;
            double MyProdID = Convert.ToDouble(lblprodid.Text);
            int uom = getuomid();
            string query = "select BatchNo,OnHand,ProdDate,ExpiryDate,LeadDays2Destroy from ICIT_BR_Perishable where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and OnHand>=1 and BatchNo not in (" + NotDisplay + ") ";
            DataTable dtquery = DataAccess.GetDataTable(query);
            if (dtquery.Rows.Count > 0)
            {
                dtPerishableSalesTemp.DataSource = dtquery;
                dtPerishableSalesTemp.Columns["Select"].DisplayIndex = 5;
            }
            else
            {
                this.Close();
            }
        }

        private void dtPerishableSalesTemp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Select

                if (e.ColumnIndex == dtPerishableSalesTemp.Columns["Select"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtPerishableSalesTemp.Rows[e.RowIndex];

                    int qty1 = Convert.ToInt32(lblTotalQty.Text);
                    int OnHand = Convert.ToInt32(row.Cells["OnHand"].Value);

                    if (qty1 <= OnHand)
                    {
                        double MyProdID = Convert.ToDouble(lblprodid.Text);
                        int UOMID = getuomid();
                        string Batch_No = row.Cells["BatchNo"].Value.ToString(); //txtBatchNO.Text;                    
                        string ProdDate1 = row.Cells["ProdDate"].Value.ToString();// dateProduct.Text;
                        string ExpiryDate1 = row.Cells["ExpiryDate"].Value.ToString();// dateExpiry.Text;
                        string LeadDays2Destroy1 = row.Cells["LeadDays2Destroy"].Value.ToString();// txtLeadTO.Text;
                        int MYTRANSID = lblMYTRANSID.Text != "" ? Convert.ToInt32(lblMYTRANSID.Text) : 0;
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

                            string sql1wev = "insert into ICIT_BR_TMP (TenentID,MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID,	Bin_ID, BatchNo, Serial_Number, MYTRANSID, LocationID, " +
                                          " NewQty,OpQty , ProdDate, ExpiryDate, LeadDays2Destroy, RecodName,Active, Uploadby ,UploadDate ,SynID)" +
                                          " values (" + Tenent.TenentID + " ,'" + MyProdID + "','" + period_code + "', '" + MySysName + "', '" + UOMID + "', " +
                                          " '" + SIZECODE + "','" + COLORID + "','" + Bin_ID + "','" + Batch_No + "', '" + Serial_Number + "', '" + MYTRANSID + "', '" + LocationID + "', " +
                                          " '" + qty1 + "',0, '" + ProdDate1 + "', '" + ExpiryDate1 + "', '" + LeadDays2Destroy1 + "','" + RecodName + "', 'Y', " +
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

                        Perishable.selectPerishable = true;
                        Perishable.item = lblproductName.Text + "~" + lblUom.Text;
                        Perishable.BatchNo = Batch_No;
                        Perishable.OnHand = OnHand;
                        Perishable.ExpiryDate = ExpiryDate1;

                        SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                        mkc1.Changeperishable = ".";
                        mkc1.Show();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("no enough qty");
                        return;
                    }

                }

            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        public int getuomid()
        {
            int UOM = 0;

            string UOMNAME1 = lblUom.Text.Trim();
            string sql12 = " select * from ICUOM where TenentID = " + Tenent.TenentID + " and UOMNAME1 = '" + UOMNAME1 + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                UOM = Convert.ToInt32(dt1.Rows[0]["UOM"]);
            }
            return UOM;
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
