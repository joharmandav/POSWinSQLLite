using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class UOMConversion : Form
    {
        public UOMConversion()
        {
            InitializeComponent();
        }

        private void UOMConversion_Load(object sender, EventArgs e)
        {
            bind_UOM();
            if (lblFromUom.Text != "-")
            {
                drpfromUOM.SelectedValue = lblFromUom.Text;
            }
            if (lblToUOM.Text != "-")
            {
                ComTOUOM.SelectedValue = lblToUOM.Text;
            }

            if (lblMode.Text == "ADD")
            {
                drpfromUOM.Enabled = false;
                ComTOUOM.Enabled = true;
            }
            else if (lblMode.Text == "EDIT")
            {
                drpfromUOM.Enabled = false;
                ComTOUOM.Enabled = false;
            }
            else
            {
                drpfromUOM.Enabled = false;
                ComTOUOM.Enabled = true;
            }

        }

        public string ActionMode
        {
            set
            {
                lblMode.Text = value;
            }
            get
            {
                return lblMode.Text;
            }
        }
        public string FUOM
        {
            set
            {
                lblFromUom.Text = value;
            }
            get
            {
                return lblFromUom.Text.ToString();
            }
        }
        public string TUOM
        {
            set
            {
                lblToUOM.Text = value;
            }
            get
            {
                return lblToUOM.Text.ToString();
            }
        }

        public string Conversion
        {
            set
            {
                txtConversion.Text = value;
            }
            get
            {
                return txtConversion.Text;
            }
        }

        public string Remarks
        {
            set
            {
                txtRemark.Text = value;
            }
            get
            {
                return txtRemark.Text;
            }
        }

        public void bind_UOM()
        {
            drpfromUOM.DataSource = null;
            drpfromUOM.Items.Clear();

            string sqluom = "select  UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM where TenentID=" + Tenent.TenentID + " ";
            DataTable dtuom = DataAccess.GetDataTable(sqluom);

            drpfromUOM.DataSource = dtuom;
            drpfromUOM.ValueMember = "UOM";
            drpfromUOM.DisplayMember = "UOMNAME";
        }
        public void BindTOUOM(int UOM)
        {
            ComTOUOM.DataSource = null;
            ComTOUOM.Items.Clear();

            string sqluom = "select  UOM, UOMNAME1 ||' - '|| UOMNAME2 as 'UOMNAME' from ICUOM where TenentID=" + Tenent.TenentID + " and UOM != " + UOM + " ";
            //" and UOM not in (select TUOM from ICUOMCONV where TenentID=" + Tenent.TenentID + " and FUOM = " + UOM + ")";
            DataTable dtuom = DataAccess.GetDataTable(sqluom);

            ComTOUOM.DataSource = dtuom;
            ComTOUOM.ValueMember = "UOM";
            ComTOUOM.DisplayMember = "UOMNAME";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drpfromUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpfromUOM.Text != null && drpfromUOM.Text != "" && drpfromUOM.Text != "System.Data.DataRowView")
                {
                    string uomn = drpfromUOM.SelectedValue.ToString();
                    int UOM = Convert.ToInt32(drpfromUOM.SelectedValue);
                    BindTOUOM(UOM);
                }
            }
            catch
            {

            }
        }

        private void ComTOUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComTOUOM.Text != null && ComTOUOM.Text != "" && ComTOUOM.Text != "System.Data.DataRowView")
                {
                    int FUOM = Convert.ToInt32(drpfromUOM.SelectedValue);
                    int TUOM = Convert.ToInt32(ComTOUOM.SelectedValue);

                    string Sqlcheck = " select Product_ID,BaseUOM,UOMID  from purchase pi inner join tbl_item_uom_price iup ON pi.product_id = iup.itemID and pi.TenentID = iup.TenentID " +
                                      " where pi.TenentID = " + Tenent.TenentID + " and  BaseUOM = " + FUOM + " and UOMID = " + TUOM + " ";
                    DataTable dtCheck = DataAccess.GetDataTable(Sqlcheck);
                    if (dtCheck.Rows.Count > 0)
                    {
                        txtConversion.Enabled = false;
                    }
                    else
                    {
                        txtConversion.Enabled = true;
                    }

                    string Sql = "Select * from ICUOMCONV where TenentID = " + Tenent.TenentID + " and  FUOM = " + FUOM + " and  TUOM = " + TUOM + " ";
                    DataTable Dt = DataAccess.GetDataTable(Sql);
                    if (Dt.Rows.Count > 0)
                    {
                        txtConversion.Text = Dt.Rows[0]["CONVERSION"].ToString();
                        txtRemark.Text = Dt.Rows[0]["REMARKS"].ToString();
                    }
                    else
                    {
                        txtConversion.Text = "";
                        txtRemark.Text = "";                        
                    }

                    
                }
            }
            catch
            {

            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            //`MyID` INTEGER,`FUOM` INTEGER,`TUOM` INTEGER, `CONVERSION` NUMERIC,`REMARKS` TEXT, 
            //`CRUP_ID` INTEGER, `USERID` TEXT,`ENTRYDATE` TEXT, `ENTRYTIME` TEXT, `UPDTTIME` TEXT,
            if (drpfromUOM.Text == "" || drpfromUOM.Text == null || drpfromUOM.Text == "System.Data.DataRowView" || drpfromUOM.SelectedValue == "0")
            {
                MessageBox.Show("select From UOM");
                return;
            }
            else if (ComTOUOM.Text == "" || ComTOUOM.Text == null || ComTOUOM.Text == "System.Data.DataRowView" || ComTOUOM.SelectedValue == "0")
            {
                MessageBox.Show("select TO UOM");
                return;
            }
            else if (txtConversion.Text == "")
            {
                MessageBox.Show("Enter Convertsion");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Please Varify Your Convertion before Save. \n Once Conversion Has been Save Can not be Change or Update. \n Are You Sure Save This Convertion ? ", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {

                    int FUOM = Convert.ToInt32(drpfromUOM.SelectedValue);
                    int TUOM = Convert.ToInt32(ComTOUOM.SelectedValue);
                    string CONVERSION = txtConversion.Text;
                    double CONVERSIOND = Convert.ToDouble(txtConversion.Text);
                    double ConvRatio = (1 / CONVERSIOND);
                    ConvRatio = Math.Round(ConvRatio, 6);
                    string REMARKS = txtRemark.Text;
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string sqlselect = "Select * from ICUOMCONV where TenentID = " + Tenent.TenentID + " and FUOM = " + FUOM + " and TUOM = " + TUOM + " ";
                    DataTable dt = DataAccess.GetDataTable(sqlselect);
                    if (dt.Rows.Count < 1)
                    {
                        string sql = " insert into ICUOMCONV (TenentID,FUOM,TUOM,CONVERSION,ConvRatio,REMARKS,Uploadby ,UploadDate ,SynID) " +
                                 " values ( " + Tenent.TenentID + ", " + FUOM + " , " + TUOM + " , '" + CONVERSION + "' , '" + ConvRatio + "' , '" + REMARKS + "', " +
                                 " '" + UserInfo.UserName + "' ,'" + UploadDate + "',1) ;";
                        DataAccess.ExecuteSQL(sql);
                        Datasyncpso.insert_Live_sync(sql, "ICUOMCONV", "INSERT");

                        string Sqlselect = " select * from tbl_item_uom_price Where TenentID = " + Tenent.TenentID + " and UomID = " + FUOM + " group By ItemID ";
                        DataTable dtselect = DataAccess.GetDataTable(Sqlselect);
                        if (dtselect.Rows.Count > 0)
                        {
                            FindBaseUomuseItem(FUOM, TUOM, CONVERSIOND);
                        }

                    }
                    else
                    {
                        string sql = " Update ICUOMCONV set CONVERSION = '" + CONVERSION + "', ConvRatio = '" + ConvRatio + "', REMARKS = '" + REMARKS + "', " +
                                     " Uploadby = '" + UserInfo.UserName + "' , UploadDate = '" + UploadDate + "'  , SynID = 2 " +
                                     " where TenentID = " + Tenent.TenentID + " and FUOM = " + FUOM + " and TUOM = " + TUOM + " ;";
                        DataAccess.ExecuteSQL(sql);
                        Datasyncpso.insert_Live_sync(sql, "ICUOMCONV", "UPDATE");
                    }

                    UOMConversion go = new UOMConversion();
                    go.ActionMode = "ADD";
                    go.FUOM = FUOM.ToString();
                    go.Show();
                    this.Close();
                }
            }
        }


        public void FindBaseUomuseItem(int FromUOM, int ToUOM, double CONVERSION)
        {
            string Sql = " select * from tbl_item_uom_price Where TenentID = " + Tenent.TenentID + " and UomID = " + FromUOM + " group By ItemID ";
            DataTable dt = DataAccess.GetDataTable(Sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double ProductID = Convert.ToInt32(dt.Rows[i]["ItemID"]);
                    string RecipeType = dt.Rows[i]["RecipeType"].ToString();

                    double msrp = Convert.ToDouble(dt.Rows[i]["msrp"]);
                    double price = Convert.ToDouble(dt.Rows[i]["price"]);

                    int minQty = Convert.ToInt32(dt.Rows[i]["minQty"]);
                    int MaxQty = Convert.ToInt32(dt.Rows[i]["MaxQty"]);

                    double SalesPrice = msrp / CONVERSION;
                    double CostPrice = price / CONVERSION;

                    double BaseOpQty = Convert.ToDouble(dt.Rows[i]["OpQty"]);
                    double BaseOnHand = Convert.ToDouble(dt.Rows[i]["OnHand"]);
                    double BaseQtyOut = Convert.ToDouble(dt.Rows[i]["QtyOut"]);
                    double BaseQtyConsumed = Convert.ToDouble(dt.Rows[i]["QtyConsumed"]);
                    double BaseQtyReserved = Convert.ToDouble(dt.Rows[i]["QtyReserved"]);
                    double BaseQtyRecived = Convert.ToDouble(dt.Rows[i]["QtyRecived"]);

                    double ToOpQty = BaseOpQty * CONVERSION;
                    double ToOnHand = BaseOnHand * CONVERSION;
                    double ToQtyOut = BaseQtyOut * CONVERSION;
                    double ToQtyConsumed = BaseQtyConsumed * CONVERSION;
                    double ToQtyReserved = BaseQtyReserved * CONVERSION;
                    double ToQtyRecived = BaseQtyRecived * CONVERSION;

                    Add_Item.SaveConvertionUOM(ProductID, ToUOM, RecipeType, ToOpQty, ToOnHand, ToQtyOut, ToQtyConsumed, ToQtyReserved, ToQtyRecived, SalesPrice, CostPrice, minQty, MaxQty);

                }

            }
        }

        private void txtConversion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtConversion.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            string from = drpfromUOM.Text.ToString().Split('-')[0].Trim();
            string TOUOM = ComTOUOM.Text.ToString().Split('-')[0].Trim();
            string Convertion = txtConversion.Text;
            string Remark = from + " 1 equal to " + TOUOM + " " + Convertion + " ";
            txtRemark.Text = Remark;
        }


    }
}
