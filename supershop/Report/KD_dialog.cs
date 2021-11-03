using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MsgBox;


namespace supershop.Report
{
    public partial class KD_dialog : Form
    {
        public KD_dialog(string orderNo, string Itemcode, string UOM, string saleQty)
        {
            InitializeComponent();
            lblOrder.Text = orderNo;
            lblItemCode.Text = Itemcode;
            lblUOM.Text = UOM;
            lblsaleQty.Text = saleQty;
        }

        private void KD_dialog_Load(object sender, EventArgs e)
        {

        }

        public void bind_Receipe(string itemID, int UOMID)
        {
            // ComboReceipe.Items.Clear();
            string Sql = "select * from Receipe_Menegement where tenentID = " + Tenent.TenentID + " and ioswitch = 'Output' and ItemCode = '" + itemID + "' and UOM = '" + UOMID + "'";
            DataTable dt1 = DataAccess.GetDataTable(Sql);
            if (dt1.Rows.Count > 0)
            {
                // ComboReceipe.DataSource = dt1;                
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //POSPrintRpt mkc = new POSPrintRpt(lblOrder.Text);
            //mkc.ShowDialog();
            string typr = SalesRegister.GetStoreprintType();
            SalesRegister.PRintInvoice(lblOrder.Text, typr);// Default , Short ,Split
        }

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            string itemCode = lblItemCode.Text.ToString().Split('-')[0];
            string ItemName = lblItemCode.Text.ToString().Split('-')[1];

            string UOMName = lblUOM.Text;
            int UOM = SalesRegister.getuomid(UOMName);

            double SaleQty = Convert.ToDouble(lblsaleQty.Text);

            bool flag = pricessReceipe(itemCode, UOM, ItemName, SaleQty);

            if (flag == true)
            {
                string OrderStutas = GetOrderStutas(lblOrder.Text, itemCode, UOM);

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = " update sales_item set " +
                               " status = 1 ,OrderStutas='" + OrderStutas + "', " +
                               " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                               " where sales_id  = '" + lblOrder.Text + "' and itemcode='" + itemCode + "' and UOM='" + UOM + "' and TenentID= " + Tenent.TenentID + " ";
                DataAccess.ExecuteSQL(sql);

                string sqlwin = " update Win_sales_item set " +
                              " status = 1 ,OrderStutas='" + OrderStutas + "', " +
                              " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                              " where sales_id  = '" + lblOrder.Text + "' and itemcode='" + itemCode + "' and UOM='" + UOM + "' and TenentID= " + Tenent.TenentID + " ";
                Datasyncpso.insert_Live_sync(sqlwin, "Win_sales_item", "UPDATE");

                string ActivityName = "Product Prepared";
                string LogData = "Product Prepared with sales_id = " + lblOrder.Text + " and Product Code=" + itemCode + " and UOM=" + UOM + "  ";
                Login.InsertUserLog(ActivityName, LogData);

                //MessageBox.Show("Order completed \n Wait 10 s for Refresh Display ");

                this.Close();
            }
        }

        public string GetOrderStutas(string sales_ID, string itemCode, int UOM)
        {
            string OrderStutas = null;
            string sql3 = "select * from sales_item where sales_id  = '" + sales_ID + "' and itemcode='" + itemCode + "' and UOM='" + UOM + "' and TenentID= " + Tenent.TenentID + " ";
            DataTable dt3 = DataAccess.GetDataTable(sql3);
            if (dt3.Rows.Count > 0)
            {
                int COD = Convert.ToInt32(dt3.Rows[0]["COD"]);
                if (COD == 1)
                {
                    OrderStutas = "COD-Ready to Delivery";
                }
                else if (COD == 0)
                {
                    OrderStutas = "Paid-Ready to Delivery";
                }
                else
                {
                    OrderStutas = "Paid-Ready to Delivery";
                }
            }

            return OrderStutas;
        }

        public static bool CheckReciepeExist(string itemCode, int UOM)
        {
            string Sql1 = "Select * from Receipe_Menegement Where tenentid=" + Tenent.TenentID + " and IOSwitch='Output' and ItemCode = '" + itemCode + "' and UOM = '" + UOM + "' ";
            DataTable dt12 = DataAccess.GetDataTable(Sql1);

            if (dt12.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        public static bool pricessReceipe(string itemCode, int UOM, string ItemName, double SaleQty)
        {
            string RecName = "";

            string Sql1 = "Select * from Receipe_Menegement Where tenentid=" + Tenent.TenentID + " and IOSwitch='Output' and ItemCode = '" + itemCode + "' and UOM = '" + UOM + "' ";
            DataTable dt12 = DataAccess.GetDataTable(Sql1);

            if (dt12.Rows.Count == 1)
            {
                string rec = dt12.Rows[0]["recNo"].ToString();
                string Sql = "Select * from tbl_Receipe Where tenentid=" + Tenent.TenentID + " and recNo = '" + rec + "' ";
                DataTable dt = DataAccess.GetDataTable(Sql);

                if (dt.Rows.Count > 0)
                {
                    RecName = rec + " - " + dt.Rows[0]["Receipe_English"].ToString();
                }
            }
            else if (dt12.Rows.Count > 1)
            {

                List<string> list = new List<string>();

                for (int i = 0; i < dt12.Rows.Count; i++)
                {
                    string rec = dt12.Rows[i]["recNo"].ToString();
                    string Sql = "Select * from tbl_Receipe Where tenentid=" + Tenent.TenentID + " and recNo = '" + rec + "' ";
                    DataTable dt = DataAccess.GetDataTable(Sql);

                    if (dt.Rows.Count > 0)
                    {
                        string nm = rec + " - " + dt.Rows[0]["Receipe_English"].ToString();
                        list.Add(nm);
                    }
                }

                string[] Recnamestr = list.ToArray(); ;

                InputBox.SetLanguage(InputBox.Language.English); // new string[] { "Qty", "percentage" }

                DialogResult res = InputBox.ShowDialog("Which Receipe used for " + ItemName + " ?", "Select Recipe", InputBox.Icon.Question,
                    InputBox.Buttons.OkCancel, InputBox.Type.ComboBox, Recnamestr, true, new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));


                if (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)
                {
                    RecName = InputBox.ResultValue;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                RecName = "";
            }

            if (RecName != "")
            {
                int recNo = Convert.ToInt32(RecName.Split('-')[0].Trim());

                Efect_Receipe(recNo, SaleQty);
            }
            else
            {
                DialogResult result = MessageBox.Show("recipe Not Found For " + ItemName + " . do you want to continue ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;

        }

        public static void Efect_Receipe(int recNo, double SaleQty)
        {
            string Sql = "Select * from Receipe_Menegement Where tenentid=" + Tenent.TenentID + " and recNo = " + recNo + " and IOSwitch='Input' ";
            DataTable dt1 = DataAccess.GetDataTable(Sql);
            if (dt1.Rows.Count > 0)
            {
                int Count = dt1.Rows.Count;
                for (int i = 0; i < Count; i++)
                {
                    double ItemID = Convert.ToDouble(dt1.Rows[i]["ItemCode"]);
                    string ItemName = GetPRoductName(ItemID);
                    int UOM = Convert.ToInt32(dt1.Rows[i]["UOM"]);
                    double Qty1 = Convert.ToDouble(dt1.Rows[i]["Qty"]);
                    double Perc = Convert.ToDouble(dt1.Rows[i]["Perc"]);

                    string RecType = dt1.Rows[i]["RecType"].ToString();

                    if (RecType == "Package")
                    {
                        pricessReceipeLevel2(ItemID.ToString(), UOM, ItemName, SaleQty);
                    }

                    double FinalQty = SaleQty * Qty1;

                    double PID = Convert.ToDouble(ItemID);
                    int SelctUOM = UOM;
                    double QtyConv = FinalQty;

                    string AllUOMConv = "";

                    int BaseUOM = Purchase.GetBaseUOM(PID);

                    if (BaseUOM == 0)
                    {
                        BaseUOM = SelctUOM;
                        AllUOMConv = SelctUOM.ToString();
                    }
                    else
                    {
                        bool Check = Add_Item.Check_CalculateAspectRatio_allow(BaseUOM);
                        if (Check == true)
                        {
                            AllUOMConv = Purchase.getAllUomOfproduct(PID);
                        }
                        else
                        {
                            AllUOMConv = SelctUOM.ToString();
                        }
                    }

                    double BaseQty = QtyConv;
                    if (SelctUOM != BaseUOM)
                    {
                        BaseQty = Purchase.getConversionBaseQty(BaseUOM, SelctUOM, QtyConv);
                    }

                    string[] ListUOM = AllUOMConv.Split(',');

                    for (int j = 0; j < ListUOM.Length; j++)
                    {
                        double newQty = QtyConv;

                        int ToUOM = Convert.ToInt32(ListUOM[j]);
                        string UOMNAme = Add_Item.getuomName(ToUOM);
                        if (ToUOM != SelctUOM)
                        {
                            if (ToUOM == BaseUOM)
                            {
                                newQty = BaseQty;
                            }
                            else
                            {
                                newQty = Purchase.getConversionToQty(BaseUOM, ToUOM, BaseQty);
                            }
                        }

                        string[] Qt = GetProductQtyForReceipeSale(ItemID, ToUOM).ToString().Split(',');

                        double IOnHand = Convert.ToDouble(Qt[0].ToString().Trim());
                        double IQtyOut = Convert.ToDouble(Qt[1].ToString().Trim());

                        MinusProductEffact(ItemID, ToUOM, IOnHand, IQtyOut, newQty);
                    }
                }
            }

            string Sql1 = "Select * from Receipe_Menegement Where tenentid=" + Tenent.TenentID + " and recNo = " + recNo + " and IOSwitch='Output' ";
            DataTable dt12 = DataAccess.GetDataTable(Sql1);
            if (dt12.Rows.Count > 0)
            {
                int Count = dt12.Rows.Count;
                for (int i = 0; i < Count; i++)
                {
                    double ItemID = Convert.ToDouble(dt12.Rows[i]["ItemCode"]);
                    int UOM = Convert.ToInt32(dt12.Rows[i]["UOM"]);
                    double Qty1 = Convert.ToDouble(dt12.Rows[i]["Qty"]);
                    double Perc = Convert.ToDouble(dt12.Rows[i]["Perc"]);

                    double FinalQty = SaleQty * Qty1;

                    double PID = Convert.ToDouble(ItemID);
                    int SelctUOM = UOM;
                    double QtyConv = FinalQty;

                    string AllUOMConv = "";

                    int BaseUOM = Purchase.GetBaseUOM(PID);

                    if (BaseUOM == 0)
                    {
                        BaseUOM = SelctUOM;
                        AllUOMConv = SelctUOM.ToString();
                    }
                    else
                    {
                        bool Check = Add_Item.Check_CalculateAspectRatio_allow(BaseUOM);
                        if (Check == true)
                        {
                            AllUOMConv = Purchase.getAllUomOfproduct(PID);
                        }
                        else
                        {
                            AllUOMConv = SelctUOM.ToString();
                        }
                    }

                    double BaseQty = QtyConv;
                    if (SelctUOM != BaseUOM)
                    {
                        BaseQty = Purchase.getConversionBaseQty(BaseUOM, SelctUOM, QtyConv);
                    }

                    string[] ListUOM = AllUOMConv.Split(',');

                    for (int j = 0; j < ListUOM.Length; j++)
                    {
                        double newQty = QtyConv;

                        int ToUOM = Convert.ToInt32(ListUOM[j]);
                        string UOMNAme = Add_Item.getuomName(ToUOM);
                        if (ToUOM != SelctUOM)
                        {
                            if (ToUOM == BaseUOM)
                            {
                                newQty = BaseQty;
                            }
                            else
                            {
                                newQty = Purchase.getConversionToQty(BaseUOM, ToUOM, BaseQty);
                            }
                        }

                        string[] Qt = GetProductQtyForReceipeSale1(ItemID, ToUOM).ToString().Split(',');

                        double IOnHand = Convert.ToDouble(Qt[0].ToString().Trim());
                        double IQtyRecived = Convert.ToDouble(Qt[1].ToString().Trim());

                        PlusProductEffact(ItemID, ToUOM, IOnHand, IQtyRecived, newQty);
                    }

                }
            }
        }

        public static void Efect_Appintment_Receipe(int jobID, double SaleQty)
        {
            string Sql = "Select * from AppointmentReceipe Where TenentID=" + Tenent.TenentID + " and jobID = '" + jobID + "'  and IOSwitch='Input' ";
            DataTable dt1 = DataAccess.GetDataTable(Sql);
            if (dt1.Rows.Count > 0)
            {
                int Count = dt1.Rows.Count;
                for (int i = 0; i < Count; i++)
                {
                    double ItemID = Convert.ToDouble(dt1.Rows[i]["ItemCode"]);
                    string ItemName = GetPRoductName(ItemID);
                    int UOM = Convert.ToInt32(dt1.Rows[i]["UOM"]);
                    double Qty1 = Convert.ToDouble(dt1.Rows[i]["Qty"]);

                    double FinalQty = SaleQty * Qty1;

                    double PID = Convert.ToDouble(ItemID);
                    int SelctUOM = UOM;
                    double QtyConv = FinalQty;

                    string AllUOMConv = "";

                    int BaseUOM = Purchase.GetBaseUOM(PID);

                    if (BaseUOM == 0)
                    {
                        BaseUOM = SelctUOM;
                        AllUOMConv = SelctUOM.ToString();
                    }
                    else
                    {
                        bool Check = Add_Item.Check_CalculateAspectRatio_allow(BaseUOM);
                        if (Check == true)
                        {
                            AllUOMConv = Purchase.getAllUomOfproduct(PID);
                        }
                        else
                        {
                            AllUOMConv = SelctUOM.ToString();
                        }
                    }

                    double BaseQty = QtyConv;
                    if (SelctUOM != BaseUOM)
                    {
                        BaseQty = Purchase.getConversionBaseQty(BaseUOM, SelctUOM, QtyConv);
                    }

                    string[] ListUOM = AllUOMConv.Split(',');

                    for (int j = 0; j < ListUOM.Length; j++)
                    {
                        double newQty = QtyConv;

                        int ToUOM = Convert.ToInt32(ListUOM[j]);
                        string UOMNAme = Add_Item.getuomName(ToUOM);
                        if (ToUOM != SelctUOM)
                        {
                            if (ToUOM == BaseUOM)
                            {
                                newQty = BaseQty;
                            }
                            else
                            {
                                newQty = Purchase.getConversionToQty(BaseUOM, ToUOM, BaseQty);
                            }
                        }

                        string[] Qt = GetProductQtyForReceipeSale(ItemID, ToUOM).ToString().Split(',');

                        double IOnHand = Convert.ToDouble(Qt[0].ToString().Trim());
                        double IQtyOut = Convert.ToDouble(Qt[1].ToString().Trim());

                        MinusProductEffact(ItemID, ToUOM, IOnHand, IQtyOut, newQty);
                    }
                }
            }

            string Sql1 = "Select * from AppointmentReceipe Where TenentID=" + Tenent.TenentID + " and jobID = '" + jobID + "' and IOSwitch='Output' ";
            DataTable dt12 = DataAccess.GetDataTable(Sql1);
            if (dt12.Rows.Count > 0)
            {
                int Count = dt12.Rows.Count;
                for (int i = 0; i < Count; i++)
                {
                    double ItemID = Convert.ToDouble(dt12.Rows[i]["ItemCode"]);
                    int UOM = Convert.ToInt32(dt12.Rows[i]["UOM"]);
                    double Qty1 = Convert.ToDouble(dt12.Rows[i]["Qty"]);

                    double FinalQty = SaleQty * Qty1;

                    double PID = Convert.ToDouble(ItemID);
                    int SelctUOM = UOM;
                    double QtyConv = FinalQty;

                    string AllUOMConv = "";

                    int BaseUOM = Purchase.GetBaseUOM(PID);

                    if (BaseUOM == 0)
                    {
                        BaseUOM = SelctUOM;
                        AllUOMConv = SelctUOM.ToString();
                    }
                    else
                    {
                        bool Check = Add_Item.Check_CalculateAspectRatio_allow(BaseUOM);
                        if (Check == true)
                        {
                            AllUOMConv = Purchase.getAllUomOfproduct(PID);
                        }
                        else
                        {
                            AllUOMConv = SelctUOM.ToString();
                        }
                    }

                    double BaseQty = QtyConv;
                    if (SelctUOM != BaseUOM)
                    {
                        BaseQty = Purchase.getConversionBaseQty(BaseUOM, SelctUOM, QtyConv);
                    }

                    string[] ListUOM = AllUOMConv.Split(',');

                    for (int j = 0; j < ListUOM.Length; j++)
                    {
                        double newQty = QtyConv;

                        int ToUOM = Convert.ToInt32(ListUOM[j]);
                        string UOMNAme = Add_Item.getuomName(ToUOM);
                        if (ToUOM != SelctUOM)
                        {
                            if (ToUOM == BaseUOM)
                            {
                                newQty = BaseQty;
                            }
                            else
                            {
                                newQty = Purchase.getConversionToQty(BaseUOM, ToUOM, BaseQty);
                            }
                        }

                        string[] Qt = GetProductQtyForReceipeSale1(ItemID, ToUOM).ToString().Split(',');

                        double IOnHand = Convert.ToDouble(Qt[0].ToString().Trim());
                        double IQtyRecived = Convert.ToDouble(Qt[1].ToString().Trim());

                        PlusProductEffact(ItemID, ToUOM, IOnHand, IQtyRecived, newQty);
                    }

                }
            }
        }

        public static bool pricessReceipeLevel2(string itemCode, int UOM, string ItemName, double SaleQty)
        {
            string RecName = "";

            string Sql1 = "Select * from Receipe_Menegement Where TenentID=" + Tenent.TenentID + " and IOSwitch='Output' and ItemCode = '" + itemCode + "' and UOM = '" + UOM + "' ";
            DataTable dt12 = DataAccess.GetDataTable(Sql1);

            if (dt12.Rows.Count == 1)
            {
                string rec = dt12.Rows[0]["recNo"].ToString();
                string Sql = "Select * from tbl_Receipe Where TenentID=" + Tenent.TenentID + " and recNo = '" + rec + "' ";
                DataTable dt = DataAccess.GetDataTable(Sql);

                if (dt.Rows.Count > 0)
                {
                    RecName = rec + " - " + dt.Rows[0]["Receipe_English"].ToString();
                }
            }
            else if (dt12.Rows.Count > 1)
            {

                List<string> list = new List<string>();

                for (int i = 0; i < dt12.Rows.Count; i++)
                {
                    string rec = dt12.Rows[i]["recNo"].ToString();
                    string Sql = "Select * from tbl_Receipe Where TenentID=" + Tenent.TenentID + " and recNo = '" + rec + "' ";
                    DataTable dt = DataAccess.GetDataTable(Sql);

                    if (dt.Rows.Count > 0)
                    {
                        string nm = rec + " - " + dt.Rows[0]["Receipe_English"].ToString();
                        list.Add(nm);
                    }
                }

                string[] Recnamestr = list.ToArray(); ;

                InputBox.SetLanguage(InputBox.Language.English); // new string[] { "Qty", "percentage" }

                DialogResult res = InputBox.ShowDialog("Which Receipe used for " + ItemName + " ?", "Select Recipe", InputBox.Icon.Question,
                    InputBox.Buttons.OkCancel, InputBox.Type.ComboBox, Recnamestr, true, new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));


                if (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)
                {
                    RecName = InputBox.ResultValue;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                RecName = "";
            }

            if (RecName != "")
            {
                int recNo = Convert.ToInt32(RecName.Split('-')[0].Trim());

                Efect_ReceipeLevel2(recNo, SaleQty);
            }
            else
            {
                DialogResult result = MessageBox.Show("recipe Not Found For " + ItemName + " . do you want to continue ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;

        }
        public static void Efect_ReceipeLevel2(int recNo, double SaleQty)
        {
            string Sql = "Select * from Receipe_Menegement Where TenentID=" + Tenent.TenentID + " and recNo = " + recNo + " and IOSwitch='Input' ";
            DataTable dt1 = DataAccess.GetDataTable(Sql);
            if (dt1.Rows.Count > 0)
            {
                int Count = dt1.Rows.Count;
                for (int i = 0; i < Count; i++)
                {
                    double ItemID = Convert.ToDouble(dt1.Rows[i]["ItemCode"]);
                    int UOM = Convert.ToInt32(dt1.Rows[i]["UOM"]);
                    double Qty1 = Convert.ToDouble(dt1.Rows[i]["Qty"]);
                    double Perc = Convert.ToDouble(dt1.Rows[i]["Perc"]);

                    double FinalQty = SaleQty * Qty1;

                    double PID = Convert.ToDouble(ItemID);
                    int SelctUOM = UOM;
                    double QtyConv = FinalQty;

                    string AllUOMConv = "";

                    int BaseUOM = Purchase.GetBaseUOM(PID);

                    if (BaseUOM == 0)
                    {
                        BaseUOM = SelctUOM;
                        AllUOMConv = SelctUOM.ToString();
                    }
                    else
                    {
                        bool Check = Add_Item.Check_CalculateAspectRatio_allow(BaseUOM);
                        if (Check == true)
                        {
                            AllUOMConv = Purchase.getAllUomOfproduct(PID);
                        }
                        else
                        {
                            AllUOMConv = SelctUOM.ToString();
                        }
                    }

                    double BaseQty = QtyConv;
                    if (SelctUOM != BaseUOM)
                    {
                        BaseQty = Purchase.getConversionBaseQty(BaseUOM, SelctUOM, QtyConv);
                    }

                    string[] ListUOM = AllUOMConv.Split(',');

                    for (int j = 0; j < ListUOM.Length; j++)
                    {
                        double newQty = QtyConv;

                        int ToUOM = Convert.ToInt32(ListUOM[j]);
                        string UOMNAme = Add_Item.getuomName(ToUOM);
                        if (ToUOM != SelctUOM)
                        {
                            if (ToUOM == BaseUOM)
                            {
                                newQty = BaseQty;
                            }
                            else
                            {
                                newQty = Purchase.getConversionToQty(BaseUOM, ToUOM, BaseQty);
                            }
                        }

                        string[] Qt = GetProductQtyForReceipeSale(ItemID, ToUOM).ToString().Split(',');

                        double IOnHand = Convert.ToDouble(Qt[0].ToString().Trim());
                        double IQtyOut = Convert.ToDouble(Qt[1].ToString().Trim());

                        MinusProductEffact(ItemID, ToUOM, IOnHand, IQtyOut, newQty);
                    }
                }
            }

            string Sql1 = "Select * from Receipe_Menegement Where TenentID=" + Tenent.TenentID + " and recNo = " + recNo + " and IOSwitch='Output' ";
            DataTable dt12 = DataAccess.GetDataTable(Sql1);
            if (dt12.Rows.Count > 0)
            {
                int Count = dt12.Rows.Count;
                for (int i = 0; i < Count; i++)
                {
                    double ItemID = Convert.ToDouble(dt12.Rows[i]["ItemCode"]);
                    int UOM = Convert.ToInt32(dt12.Rows[i]["UOM"]);
                    double Qty1 = Convert.ToDouble(dt12.Rows[i]["Qty"]);
                    double Perc = Convert.ToDouble(dt12.Rows[i]["Perc"]);

                    double FinalQty = SaleQty * Qty1;

                    double PID = Convert.ToDouble(ItemID);
                    int SelctUOM = UOM;
                    double QtyConv = FinalQty;

                    string AllUOMConv = "";

                    int BaseUOM = Purchase.GetBaseUOM(PID);

                    if (BaseUOM == 0)
                    {
                        BaseUOM = SelctUOM;
                        AllUOMConv = SelctUOM.ToString();
                    }
                    else
                    {
                        bool Check = Add_Item.Check_CalculateAspectRatio_allow(BaseUOM);
                        if (Check == true)
                        {
                            AllUOMConv = Purchase.getAllUomOfproduct(PID);
                        }
                        else
                        {
                            AllUOMConv = SelctUOM.ToString();
                        }
                    }

                    double BaseQty = QtyConv;
                    if (SelctUOM != BaseUOM)
                    {
                        BaseQty = Purchase.getConversionBaseQty(BaseUOM, SelctUOM, QtyConv);
                    }

                    string[] ListUOM = AllUOMConv.Split(',');

                    for (int j = 0; j < ListUOM.Length; j++)
                    {
                        double newQty = QtyConv;

                        int ToUOM = Convert.ToInt32(ListUOM[j]);
                        string UOMNAme = Add_Item.getuomName(ToUOM);
                        if (ToUOM != SelctUOM)
                        {
                            if (ToUOM == BaseUOM)
                            {
                                newQty = BaseQty;
                            }
                            else
                            {
                                newQty = Purchase.getConversionToQty(BaseUOM, ToUOM, BaseQty);
                            }
                        }

                        string[] Qt = GetProductQtyForReceipeSale1(ItemID, ToUOM).ToString().Split(',');

                        double IOnHand = Convert.ToDouble(Qt[0].ToString().Trim());
                        double IQtyRecived = Convert.ToDouble(Qt[1].ToString().Trim());

                        PlusProductEffact(ItemID, ToUOM, IOnHand, IQtyRecived, newQty);
                    }

                }
            }
        }

        public static void MinusProductEffact(double ItemID, int UOMID, double IOnHand, double IQtyOut, double FinalQty)
        {
            double fanalOnHand = IOnHand - FinalQty;
            double fanalQtyOut = IQtyOut + FinalQty;

            string SqlUpdate = " Update tbl_item_uom_price set OnHand = '" + fanalOnHand + "' , QtyOut = '" + fanalQtyOut + "'  " +
                            " where TenentID = " + Tenent.TenentID + " and itemID = " + ItemID + " and UOMID = '" + UOMID + "'  ";
            DataAccess.ExecuteSQL(SqlUpdate);

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql1Win = " Update Win_tbl_item_uom_price set OnHand = '" + fanalOnHand + "' , QtyOut = '" + fanalQtyOut + "' ,  " +
                             " Uploadby= '" + UserInfo.UserName + "' , UploadDate = '" + UploadDate + "' , SynID = 2 " +
                             " where TenentID = " + Tenent.TenentID + " and itemID = " + ItemID + " and UOMID = '" + UOMID + "'  ";
            Datasyncpso.insert_Live_sync(sql1Win, "Win_tbl_item_uom_price", "UPDATE");
        }

        public static void PlusProductEffact(double ItemID, int UOMID, double IOnHand, double IQtyRecived, double FinalQty)
        {
            double fanalOnHand = IOnHand + FinalQty;
            double fanalQtyRecived = IQtyRecived + FinalQty;

            string SqlUpdate = " Update tbl_item_uom_price set OnHand = '" + fanalOnHand + "' , QtyRecived = '" + fanalQtyRecived + "'  " +
                            " where TenentID = " + Tenent.TenentID + " and itemID = " + ItemID + " and UOMID = '" + UOMID + "'  ";
            DataAccess.ExecuteSQL(SqlUpdate);

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql1Win = " Update Win_tbl_item_uom_price set OnHand = '" + fanalOnHand + "' , QtyRecived = '" + fanalQtyRecived + "' ,  " +
                             " Uploadby= '" + UserInfo.UserName + "' , UploadDate = '" + UploadDate + "' , SynID = 2 " +
                             " where TenentID = " + Tenent.TenentID + " and itemID = " + ItemID + " and UOMID = '" + UOMID + "'  ";
            Datasyncpso.insert_Live_sync(sql1Win, "Win_tbl_item_uom_price", "UPDATE");
        }

        public static string GetProductQtyForReceipeSale(double itemID, int UOMID)
        {
            string Str = "";
            decimal OnHand = 0;
            decimal QtyOut = 0;
            string Sql = "select * from tbl_item_uom_price where tenentID = " + Tenent.TenentID + " and itemID = " + itemID + " and UOMID = '" + UOMID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(Sql);
            if (dt1.Rows.Count > 0)
            {
                OnHand = Convert.ToDecimal(dt1.Rows[0]["OnHand"]);
                QtyOut = Convert.ToDecimal(dt1.Rows[0]["QtyOut"]);
            }

            Str = OnHand + "," + QtyOut;
            return Str;
        }

        public static string GetProductQtyForReceipeSale1(double itemID, int UOMID)
        {
            string Str = "";
            decimal OnHand = 0;
            decimal QtyRecived = 0;
            string Sql = "select * from tbl_item_uom_price where tenentID = " + Tenent.TenentID + " and itemID = " + itemID + " and UOMID = '" + UOMID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(Sql);
            if (dt1.Rows.Count > 0)
            {
                OnHand = Convert.ToDecimal(dt1.Rows[0]["OnHand"]);
                QtyRecived = Convert.ToDecimal(dt1.Rows[0]["QtyRecived"]);
            }

            Str = OnHand + "," + QtyRecived;
            return Str;
        }


        public string GetProductQtyForReceipepur(double itemID, int UOMID)
        {
            string Str = "";
            decimal OnHand = 0;
            decimal QtyRecived = 0;
            string Sql = "select * from tbl_item_uom_price where tenentID = " + Tenent.TenentID + " and itemID = " + itemID + " and UOMID = '" + UOMID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(Sql);
            if (dt1.Rows.Count > 0)
            {
                OnHand = Convert.ToDecimal(dt1.Rows[0]["OnHand"]);
                QtyRecived = Convert.ToDecimal(dt1.Rows[0]["QtyRecived"]);
            }

            Str = OnHand + "," + QtyRecived;
            return Str;
        }

        public static string GetPRoductName(double ITEMCODE)
        {
            string ProductName = "";
            string sql = "select * from purchase where TenentID = " + Tenent.TenentID + " and PRoduct_id = '" + ITEMCODE + "' ";
            DataTable dt = DataAccess.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                ProductName = dt.Rows[0]["product_name"].ToString();
            }

            return ProductName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string itemCode = lblItemCode.Text.ToString().Split('-')[0];
            //string ItemName = lblItemCode.Text.ToString().Split('-')[1];

            //string UOM = lblUOM.Text;

            string strsql = "select * from sales_item where sales_id  = '" + lblOrder.Text + "' and TenentID= " + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(strsql);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string itemCode = dt1.Rows[i]["itemcode"].ToString();
                    int UOM = Convert.ToInt32(dt1.Rows[i]["UOM"]);
                    string ItemName = dt1.Rows[i]["itemName"].ToString();

                    double SaleQty = Convert.ToDouble(dt1.Rows[i]["Qty"]);

                    bool flag = pricessReceipe(itemCode, UOM, ItemName, SaleQty);

                    if (flag == true)
                    {
                        string OrderStutas = GetOrderStutas(lblOrder.Text, itemCode, UOM);

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        string sql = " update sales_item set " +
                                       " status = 1 ,OrderStutas='" + OrderStutas + "', " +
                                       " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                       " where sales_id  = '" + lblOrder.Text + "' and itemcode='" + itemCode + "' and UOM='" + UOM + "' and TenentID= " + Tenent.TenentID + " ";
                        DataAccess.ExecuteSQL(sql);

                        string sqlwin = " update Win_sales_item set " +
                                      " status = 1 ,OrderStutas='" + OrderStutas + "', " +
                                      " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                      " where sales_id  = '" + lblOrder.Text + "' and itemcode='" + itemCode + "' and UOM='" + UOM + "' and TenentID= " + Tenent.TenentID + " ";
                        Datasyncpso.insert_Live_sync(sqlwin, "Win_sales_item", "UPDATE");

                        string ActivityName = "Product Prepared";
                        string LogData = "Product Prepared with sales_id = " + lblOrder.Text + " and Product Code=" + itemCode + " and UOM=" + UOM + "  ";
                        Login.InsertUserLog(ActivityName, LogData);

                        //MessageBox.Show("Order completed \n Wait 10 s for Refresh Display ");

                        this.Close();
                    }

                }

            }




            //MessageBox.Show("Order completed \n Wait 10 s for Refresh Display ");

            this.Close();
        }



    }
}
