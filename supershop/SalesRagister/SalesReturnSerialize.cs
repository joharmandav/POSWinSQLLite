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
    public partial class SalesReturnSerialize : Form
    {
        public SalesReturnSerialize(double productid, string ProductName, string uom, int MY_TRANS_ID, string MySysName, string Serial)
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

        private void SalesPerishable_Load(object sender, EventArgs e)
        {
            BindSerialize();
        }

        public string SplitSerial(string selectSerial)
        {
            string Temp = "";

            string[] strSplit = selectSerial.Split('~');

            int Lenth = strSplit.Length;

            for (int i = 0; i < Lenth; i++)
            {
                string Temp1 = "" + strSplit[i] + "";
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
            int uom = Convert.ToInt32(lblUom.Text);
            string query = "select Serial_Number,OnHand from ICIT_BR_Serialize where TenentID=" + Tenent.TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + uom + " and OnHand=0 and Serial_Number in (" + NotDisplay + ") ";
            DataTable dtquery = DataAccess.GetDataTable(query);
            if (dtquery.Rows.Count > 0)
            {
               
                if (dtquery.Rows.Count >= 1)
                {
                    string Serial = "";
                    for (int i = 0; i < dtquery.Rows.Count; i++)
                    {
                        Serial = dtquery.Rows[i]["Serial_Number"].ToString().Trim();
                        dtPerishableSalesTemp.Rows.Add(Serial);
                    }
                }
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
                  
                }
                if (e.ColumnIndex == dtPerishableSalesTemp.Columns["Select"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dtPerishableSalesTemp.Rows[e.RowIndex];

                    int qty1 = Convert.ToInt32(lblTotalQty.Text);
                    int OnHand = Convert.ToInt32(row.Cells["OnHand"].Value);

                    if (qty1 <= OnHand)
                    {
                        double MyProdID = Convert.ToDouble(lblprodid.Text);
                        int UOMID = Convert.ToInt32(lblUom.Text);
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
                        Serialize.item = lblproductName.Text ;
                        Serialize.Serial_Number = Serial_Number;
                        Serialize.OnHand = OnHand;
                        //Perishable.ExpiryDate = ExpiryDate1;

                        Return_product mkc1 = (Return_product)Application.OpenForms["Return_product"];
                        mkc1.ChangeSerializeForReturn = ".";
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

        

        private void btnColse_Click(object sender, EventArgs e)
        {
            //Serialize.selectSerialize = true;
            Serialize.item = lblproductName.Text;
            //Serialize.Serial_Number = Serial_Numberlist;
           // Serialize.OnHand = 1;

            Return_product mkc1 = (Return_product)Application.OpenForms["Return_product"];
            mkc1.ChangeSerializeForReturn = "x";
            mkc1.Show();

            this.Close();
        }

       

        private void btnAddToInvoice_Click(object sender, EventArgs e)
        {
            int saleqty = Convert.ToInt32(txtqty.Text);
            int scount = dtPerishableSalesTemp.Rows.Count ;
            if (scount == saleqty)
            {
                string Serial_Numberlist = "";
                for (int i = 0; i < dtPerishableSalesTemp.Rows.Count; i++)//Yogesh Check In Input Commission item
                {

                    string Serial_Number = dtPerishableSalesTemp.Rows[i].Cells[0].Value.ToString();

                    if (Serial_Numberlist != "")
                        Serial_Numberlist +="~"+ Serial_Number;
                    else
                        Serial_Numberlist += Serial_Number;

                }
                if (Serial_Numberlist != "")
                    Serialize.selectSerialize = true;
                Serialize.item = lblproductName.Text + " ~ " + lblUom.Text;
                Serialize.Serial_Number = Serial_Numberlist;
                //Serialize.OnHand = 1;
                //Perishable.ExpiryDate = ExpiryDate1;

                Return_product mkc1 = (Return_product)Application.OpenForms["Return_product"];
                mkc1.ChangeSerializeForReturn = ".";
                mkc1.Show();

                this.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Serialize.item = lblproductName.Text.Trim() + " ~ " + lblUom.Text.Trim();
            //Serialize.Serial_Number = Serial_Numberlist;
            // Serialize.OnHand = 1;

            Return_product mkc1 = (Return_product)Application.OpenForms["Return_product"];
            mkc1.ChangeSerializeForReturn = "x";
            mkc1.Show();

            this.Close();
        }

      


      


       

     
    }
}
        