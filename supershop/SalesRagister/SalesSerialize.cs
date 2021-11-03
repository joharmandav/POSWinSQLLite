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
    public partial class SalesSerialize : Form
    {
        public SalesSerialize(double productid, string ProductName, string uom, int MY_TRANS_ID, string MySysName, string Serial)
        {
            InitializeComponent();

            this.dtPerishableSalesTemp.Columns.Add("Serial", "Serial");

            dtPerishableSalesTemp.Columns["Serial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPerishableSalesTemp.Columns["Serial"].DefaultCellStyle.ForeColor = Color.Black;
            dtPerishableSalesTemp.Columns["Serial"].DefaultCellStyle.BackColor = Color.Silver;
            dtPerishableSalesTemp.Columns["Serial"].DefaultCellStyle.SelectionForeColor = Color.Black;
            dtPerishableSalesTemp.Columns["Serial"].DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtPerishableSalesTemp.Columns["Serial"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            dtPerishableSalesTemp.Columns["Serial"].Width = 200;
            //BindData();

            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            dtPerishableSalesTemp.Columns.Add(del);
            del.HeaderText = "X";
            del.Text = "x";
            del.Name = "del";
            del.ToolTipText = "Delete this Item";
            del.UseColumnTextForButtonValue = true;
            dtPerishableSalesTemp.Columns["Del"].Width = 40;

            lblprodid.Text = productid.ToString();
            lblproductName.Text = ProductName;
            lblUom.Text = uom;
            lblMYTRANSID.Text = MY_TRANS_ID.ToString();
            lblMYSYSNAME.Text = MySysName;
            selectSerial.Text = Serial;

        }
        public double Qty
        {
            set { lblTotalQty.Text = value.ToString(); }
            get { return Convert.ToInt32(lblTotalQty.Text); }
        }
        public string selectedSerial
        {
            set
            {
                comboSerial.Text = value;
            }
            get
            {
                return comboSerial.Text;
            }
        }
        private void SalesPerishable_Load(object sender, EventArgs e)
        {
            BindSerial();
        }

        public string SplitSerial(string selectSerial)
        {
            string Temp = "";

            string[] strSplit = selectSerial.Split(',');

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

        public void BindSerialize()
        {
            string NotDisplay = SplitSerial(selectSerial.Text);// selectBatch.Text;
            double MyProdID = Convert.ToDouble(lblprodid.Text);
            int uom = getuomid();
            string query = "select Serial_Number,OnHand from ICIT_BR_Serialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and OnHand>=1 and Serial_Number not in (" + NotDisplay + ") ";
            DataTable dtquery = DataAccess.GetDataTable(query);
            if (dtquery.Rows.Count > 0)
            {
                dtPerishableSalesTemp.DataSource = dtquery;
                dtPerishableSalesTemp.Columns["Select"].DisplayIndex = 2;
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
                if (e.ColumnIndex == dtPerishableSalesTemp.Columns["del"].Index && e.RowIndex >= 0)
                {
                    //foreach (DataGridViewRow row2 in dtPerishableSalesTemp.SelectedRows)
                    //{
                    DataGridViewRow row = dtPerishableSalesTemp.Rows[e.RowIndex];
                    if (!row.IsNewRow)
                    {
                        dtPerishableSalesTemp.Rows.Remove(row);
                    }

                    //}
                    txtSerial.Text = "";
                    txtSerial.Focus();
                }
                if (e.ColumnIndex == dtPerishableSalesTemp.Columns["Select"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtPerishableSalesTemp.Rows[e.RowIndex];

                    int qty1 = Convert.ToInt32(lblTotalQty.Text);
                    int OnHand = Convert.ToInt32(row.Cells["OnHand"].Value);

                    if (qty1 <= OnHand)
                    {
                        double MyProdID = Convert.ToDouble(lblprodid.Text);
                        int UOMID = getuomid();
                        string Serial_Number = row.Cells["Serial_Number"].Value.ToString(); //txtBatchNO.Text;                    

                        int MYTRANSID = lblMYTRANSID.Text != "" ? Convert.ToInt32(lblMYTRANSID.Text) : 0;
                        string MySysName = lblMYSYSNAME.Text;
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        string q = "select * from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + lblprodid.Text + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                        DataTable dt1 = DataAccess.GetDataTable(q);
                        if (dt1.Rows.Count < 1)
                        {
                            string period_code = "201801";
                            int SIZECODE = 999999998;
                            int COLORID = 999999998;
                            int Bin_ID = 999999998;
                            string Batch_No = "NO";
                            string RecodName = "Serialize";

                            int LocationID = 1;

                            int ID = DataAccess.getICIT_BR_TMPSerializeMYid(Tenent.TenentID, MyProdID, UOMID);

                            string sql1 = "insert into ICIT_BR_TMPSerialize (TenentID,ID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID,	Bin_ID, BatchNo, Serial_Number, MYTRANSID, LocationID, " +
                                          " NewQty, RecodName,Active, Uploadby ,UploadDate ,SynID)" +
                                          " values (" + Tenent.TenentID + " ," + ID + ", '" + MyProdID + "','" + period_code + "', '" + MySysName + "', '" + UOMID + "', " +
                                          " '" + SIZECODE + "','" + COLORID + "','" + Bin_ID + "','" + Batch_No + "', '" + Serial_Number + "', '" + MYTRANSID + "', '" + LocationID + "', " +
                                          " '" + qty1 + "','" + RecodName + "', 'Y', " +
                                          " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                            int flag1 = DataAccess.ExecuteSQL(sql1);

                            string sql1wev = "insert into ICIT_BR_TMPSerialize (TenentID,MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID,	Bin_ID, BatchNo, Serial_Number, MYTRANSID, LocationID, " +
                                          " NewQty,OpQty , ProdDate, ExpiryDate, LeadDays2Destroy, RecodName,Active, Uploadby ,UploadDate ,SynID)" +
                                          " values (" + Tenent.TenentID + " ,'" + MyProdID + "','" + period_code + "', '" + MySysName + "', '" + UOMID + "', " +
                                          " '" + SIZECODE + "','" + COLORID + "','" + Bin_ID + "','" + Batch_No + "', '" + Serial_Number + "', '" + MYTRANSID + "', '" + LocationID + "', " +
                                          " '" + qty1 + "',0,'" + RecodName + "', 'Y', " +
                                          " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                            Datasyncpso.insert_Live_sync(sql1wev, "ICIT_BR_TMPSerialize", "INSERT");

                        }
                        else
                        {
                            string sql1 = "Update ICIT_BR_TMPSerialize set NewQty='" + qty1 + "', " +
                                          " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                          " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                            DataAccess.ExecuteSQL(sql1);
                            Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "UPDATE");
                        }

                        Serialize.selectSerialize = true;
                        Serialize.item = lblproductName.Text + "~" + lblUom.Text;
                        Serialize.Serial_Number = Serial_Number;
                        Serialize.OnHand = OnHand;
                        //Perishable.ExpiryDate = ExpiryDate1;

                        SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                        mkc1.ChangeSerialize = ".";
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
            //Serialize.selectSerialize = true;
            Serialize.item = lblproductName.Text + "~" + lblUom.Text;
            //Serialize.Serial_Number = Serial_Numberlist;
            // Serialize.OnHand = 1;

            SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
            mkc1.ChangeSerialize = "x";
            mkc1.Show();

            this.Close();
        }



        private void btnAddToInvoice_Click(object sender, EventArgs e)
        {
            int saleqty = Convert.ToInt32(txtqty.Text);
            int scount = dtPerishableSalesTemp.Rows.Count;
            if (scount == saleqty)
            {
                string Serial_Numberlist = "";
                for (int i = 0; i < dtPerishableSalesTemp.Rows.Count; i++)//Yogesh Check In Input Commission item
                {

                    string Serial_Number = dtPerishableSalesTemp.Rows[i].Cells[0].Value.ToString();

                    double MyProdID = Convert.ToDouble(lblprodid.Text);
                    int UOMID = getuomid();
                    int MYTRANSID = lblMYTRANSID.Text != "" ? Convert.ToInt32(lblMYTRANSID.Text) : 0;
                    string MySysName = lblMYSYSNAME.Text;
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string q = "select * from ICIT_BR_TMPSerialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + lblprodid.Text + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                    DataTable dt1 = DataAccess.GetDataTable(q);
                    if (dt1.Rows.Count < 1)
                    {
                        string period_code = "201801";
                        int SIZECODE = 999999998;
                        int COLORID = 999999998;
                        int Bin_ID = 999999998;
                        string Batch_No = "NO";
                        string RecodName = "Serialize";

                        int LocationID = 1;

                        int ID = DataAccess.getICIT_BR_TMPSerializeMYid(Tenent.TenentID, MyProdID, UOMID);

                        string sql1 = "insert into ICIT_BR_TMPSerialize (TenentID,ID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID,	Bin_ID, BatchNo, Serial_Number, MYTRANSID, LocationID, " +
                                      " NewQty, RecodName,Active, Uploadby ,UploadDate ,SynID)" +
                                      " values (" + Tenent.TenentID + " ," + ID + ", '" + MyProdID + "','" + period_code + "', '" + MySysName + "', '" + UOMID + "', " +
                                      " '" + SIZECODE + "','" + COLORID + "','" + Bin_ID + "','" + Batch_No + "', '" + Serial_Number + "', '" + MYTRANSID + "', '" + LocationID + "', " +
                                      " '" + 1 + "','" + RecodName + "', 'Y', " +
                                      " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                        int flag1 = DataAccess.ExecuteSQL(sql1);

                        string sql1wev = "insert into ICIT_BR_TMPSerialize (TenentID,MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID,	Bin_ID, BatchNo, Serial_Number, MYTRANSID, LocationID, " +
                                      " NewQty,OpQty , ProdDate, ExpiryDate, LeadDays2Destroy, RecodName,Active, Uploadby ,UploadDate ,SynID)" +
                                      " values (" + Tenent.TenentID + " ,'" + MyProdID + "','" + period_code + "', '" + MySysName + "', '" + UOMID + "', " +
                                      " '" + SIZECODE + "','" + COLORID + "','" + Bin_ID + "','" + Batch_No + "', '" + Serial_Number + "', '" + MYTRANSID + "', '" + LocationID + "', " +
                                      " '" + 1 + "',0,'" + RecodName + "', 'Y', " +
                                      " '" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                        Datasyncpso.insert_Live_sync(sql1wev, "ICIT_BR_TMPSerialize", "INSERT");

                    }
                    else
                    {
                        string sql1 = "Update ICIT_BR_TMPSerialize set NewQty='" + 1 + "', " +
                                      " Uploadby='" + UserInfo.UserName + "' , UploadDate='" + UploadDate + "'  , SynID=2  " +
                                      " where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + UOMID + " and Serial_Number='" + Serial_Number + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
                        DataAccess.ExecuteSQL(sql1);
                        Datasyncpso.insert_Live_sync(sql1, "ICIT_BR_TMPSerialize", "UPDATE");
                    }
                    if (Serial_Numberlist != "")
                        Serial_Numberlist += "~" + Serial_Number;
                    else
                        Serial_Numberlist += Serial_Number;

                }
                if (Serial_Numberlist != "")
                    Serialize.selectSerialize = true;
                Serialize.item = lblproductName.Text + "~" + lblUom.Text;
                Serialize.Serial_Number = Serial_Numberlist;
                Serialize.OnHand = 1;
                //Perishable.ExpiryDate = ExpiryDate1;

                SalesRegister mkc1 = (SalesRegister)Application.OpenForms["SalesRegister"];
                mkc1.ChangeSerialize = ".";
                mkc1.Show();

                this.Close();
            }


        }









        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Serial = "";
                double MYTRANSID = lblMYTRANSID.Text != "" ? Convert.ToDouble(lblMYTRANSID.Text) : 0;
                string MySysName = lblMYSYSNAME.Text;
                int UOMID = getuomid();
                if (txtSerial.Text != "" && txtqty.Text != "")
                {
                    int saleqty = Convert.ToInt32(txtqty.Text);
                    int scount = dtPerishableSalesTemp.Rows.Count + 1;
                    if (scount <= saleqty)
                    {
                        string q = "select * from ICIT_BR_Serialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + lblprodid.Text + "  and UOM=" + UOMID + " and Serial_Number='" + txtSerial.Text + "' ";
                        DataTable dt1 = DataAccess.GetDataTable(q);
                        if (dt1.Rows.Count == 1)
                        {
                            int onhand = Convert.ToInt32(dt1.Rows[0]["OnHand"]);//OpQty
                            //int opqty = Convert.ToInt32(dt1.Rows[0]["OpQty"]);
                            if (onhand == 0 )
                            {
                                MessageBox.Show("No One Qty For This Serialize Product.");
                                txtSerial.Text = "";
                                txtSerial.Focus();
                            }
                            else
                            {
                                for (int i = 0; i < dtPerishableSalesTemp.Rows.Count; i++)
                                {
                                    Serial = dtPerishableSalesTemp.Rows[i].Cells[0].Value.ToString().Trim();
                                    if (txtSerial.Text == Serial)
                                    {
                                        MessageBox.Show("Duplicate Serial for this item");
                                        txtSerial.Text = "";
                                        txtSerial.Focus();
                                        break;
                                    }

                                }

                                if (txtSerial.Text != "")
                                {

                                    dtPerishableSalesTemp.Rows.Add(txtSerial.Text);
                                    int Rowcount = dtPerishableSalesTemp.Rows.Count - 1;
                                    dtPerishableSalesTemp.Rows[Rowcount].Selected = true;
                                    dtPerishableSalesTemp.FirstDisplayedScrollingRowIndex = Rowcount;
                                    txtSerial.Text = "";
                                    txtSerial.Focus();

                                }
                            }
                        }
                        else
                        {

                            double pid = Convert.ToDouble(lblprodid.Text);
                            string sqlCmd = "select Serial_Number from ICIT_BR_Serialize where tenentid=" + Tenent.TenentID + " and OnHand >=1 and MyProdID=" + pid + " and Serial_Number like '%" + txtSerial.Text + "%'";
                            DataTable dt11 = DataAccess.GetDataTable(sqlCmd);
                            if (dt11.Rows.Count >= 1)
                            {
                                if (Application.OpenForms["SerialSearch"] != null)
                                {
                                    Application.OpenForms["SerialSearch"].Close();
                                }
                                this.Refresh();
                                SerialSearch go = new SerialSearch(pid, txtSerial.Text);
                                go.PageName = "SalesSerialize";
                                go.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Serial");
                                txtSerial.Text = "";
                                txtSerial.Focus();
                                return;
                            }
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sale Qty and Container qty are same");
                        txtqty.Focus();
                        return;
                    }
                }
                else
                {

                    txtSerial.Text = "";
                    txtSerial.Focus();
                    return;
                }
            }
        }

        public void BindSerial()
        {
            //comboSerial

            comboSerial.Items.Clear();
            comboSerial.Items.Add("-- select Serial --");


            double MyProdID = Convert.ToDouble(lblprodid.Text);
            //Serial Databind 
            string sqlCust = "select * from ICIT_BR_Serialize where tenentid=" + Tenent.TenentID + " and OnHand >=1 and MyProdID=" + MyProdID + "";
            DataTable dtCust = DataAccess.GetDataTable(sqlCust);
            string First = "";
            if (dtCust.Rows.Count > 0)
            {
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    string Serial_Name = dtCust.Rows[i]["Serial_Number"].ToString();
                    if (First == "")
                    {
                        First = Serial_Name;
                        lblFirstSerial.Text = First;
                    }
                    comboSerial.Items.Add(Serial_Name);
                }
            }

            comboSerial.Text = "-- select Serial --";
            if (dtCust != null)
            {
                AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
                foreach (DataRow rw in dtCust.Rows)
                {
                    string Val = rw["Serial_Number"].ToString();
                    AutoItem.Add(Val);

                }
                comboSerial.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboSerial.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboSerial.AutoCompleteCustomSource = AutoItem;
            }

            //comboSerial.DataSource = dtCust;
            //comboSerial.DisplayMember = "Name";
            //comboSerial.ValueMember = "id";
        }

        private void comboSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSerial.Text != "-- select Serial --")
            {
                int saleqty = Convert.ToInt32(txtqty.Text);
                    int scount = dtPerishableSalesTemp.Rows.Count + 1;
                    if (scount <= saleqty)
                    {
                        string Serial = comboSerial.Text.Trim();
                        if (dtPerishableSalesTemp.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtPerishableSalesTemp.Rows.Count; i++)
                            {

                                if (dtPerishableSalesTemp.Rows[i].Cells[0].Value.ToString().Trim().Equals(Serial))
                                {
                                    MessageBox.Show("Duplicate Serial.");
                                    return;
                                }

                            }

                            dtPerishableSalesTemp.Rows.Add(Serial);
                            int Rowcount = dtPerishableSalesTemp.Rows.Count - 1;
                            dtPerishableSalesTemp.Rows[Rowcount].Selected = true;
                            dtPerishableSalesTemp.FirstDisplayedScrollingRowIndex = Rowcount;
                            txtSerial.Text = "";
                            txtSerial.Focus();

                        }
                        else
                        {
                            dtPerishableSalesTemp.Rows.Add(Serial);
                            int Rowcount = dtPerishableSalesTemp.Rows.Count - 1;
                            dtPerishableSalesTemp.Rows[Rowcount].Selected = true;
                            dtPerishableSalesTemp.FirstDisplayedScrollingRowIndex = Rowcount;
                            txtSerial.Text = "";
                            txtSerial.Focus();
                        }
                    }
                else
                    {
                        MessageBox.Show("Sale Qty and Container qty are same");
                        txtqty.Text = "";
                        txtqty.Focus();
                        return;
                    }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["SerialSearch"] != null)
            {
                Application.OpenForms["SerialSearch"].Close();
            }
            this.Refresh();
            double pid = Convert.ToDouble(lblprodid.Text);
            SerialSearch go = new SerialSearch(pid,"");
            go.PageName = "SalesSerialize";
            go.Show();
        }

    }
}
