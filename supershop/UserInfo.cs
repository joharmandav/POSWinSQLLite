using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace supershop
{

    /// <summary>
    /// ///////////
    /// Author : Ayosoftech
    /// Country: India
    /// </summary>
    public static class UserInfo
    {
        public static string LOGO { get; set; }
        public static int Userid { get; set; }
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }
        public static string usertype { get; set; }
        public static string invoiceNo { get; set; }
        public static string Shopid { get; set; }
        public static int ShiftID { get; set; }
        public static string usernamWK { get; set; }
        public static string Language { get; set; }
        public static bool addcustomerflag { get; set; }
        public static bool addSupplierflag { get; set; }
        public static string Customer_name { get; set; }
        public static string ExpireDate { get; set; }
        public static int TenentID { get; set; }
        public static string Database_path { get; set; }
        public static string Sync_path { get; set; }
        public static string Img_path { get; set; }
        public static bool EditTransation { get; set; }
        public static string InvoicetransNO { get; set; }
        public static int Invoice { get; set; }
        public static string TranjationPerform { get; set; }
        public static string MDiPerent { get; set; }
        public static bool IsSuperAddmin { get; set; }

    }

    public class PaymentDatasale
    {
        public string invoice { get; set; }
        public string payment_type { get; set; }
        public string Reffrance_NO { get; set; }
        public decimal payment_amount { get; set; }
    }

    public static class backSyncro
    {
        public static bool isRun { get; set; }

        public static string Msg { get; set; }

        public static string MsgCount { get; set; }

        public static int Minute { get; set; }

        public static string SyncType { get; set; }

        public static bool Salessync { get; set; }

    }
    public static class DaftSales
    {
        public static string TransDate1 { get; set; }
    }

    public static class RelatedItemBind
    {
        public static double ProdID { get; set; }
    }

    public static class IdelTime
    {
        public static bool WorkingFalg { get; set; }
    }

    public static class Tenent
    {
        public static int TenentID { get; set; }
        public static int LocationID { get; set; }
    }

    public static class salesSplit
    {
        public static string SplitType { get; set; }

        public static string InvNO { get; set; }
    }

    public static class LoginCheck
    {
        public static int invalidAttapt { get; set; }
    }

    public static class Opening_Balance
    {
        public static bool Falg { get; set; }
    }

    public static class Perishable
    {
        public static bool selectPerishable { get; set; }
        public static string item { get; set; }
        public static string BatchNo { get; set; }
        public static int OnHand { get; set; }
        public static string ExpiryDate { get; set; }
    }
    public static class Serialize
    {
        public static bool selectSerialize { get; set; }
        public static string item { get; set; }
        public static string Serial_Number { get; set; }
        public static int OnHand { get; set; }
    }

    public static class ReportValue  // use in report
    {
        public static string StartDate { get; set; }
        public static string EndDate { get; set; }
        public static string emp { get; set; }
        // public static string Reportid { get; set; }
        public static string Terminal { get; set; }
        //public static string StartDateGroupby { get; set; }
        //public static string EndDateGroupby { get; set; }
    }


    public static class parameter
    {
        public static string helpid { get; set; }
        public static string peopleid { get; set; }
        public static string autoprintid { get; set; }

    }
    public static class vatdisvalue
    {
        public static string vat
        {
            set
            {
                //   //Load Vat and Discount rate
                //   string sqlVat= "select * from storeconfig";
                //   DataAccess.ExecuteSQL(sqlVat);
                //   DataTable dtVat = DataAccess.GetDataTable(sqlVat);
                ////   txtVATRate.Text = dtVatdis.Rows[0].ItemArray[6].ToString();
                //  // txtDiscountRate.Text = dtVatdis.Rows[0].ItemArray[7].ToString();
                //   string vl =  dtVat.Rows[0].ItemArray[6].ToString();
                //   vl = value;              
            }
            get
            {
                string sqlVat = " select VAT from tbl_terminallocation where Shopid = '" + UserInfo.Shopid + "' "; // 
                DataAccess.ExecuteSQL(sqlVat);
                DataTable dtVat = DataAccess.GetDataTable(sqlVat);
                string vl = dtVat.Rows[0].ItemArray[0].ToString();
                return vl;
            }
        }

        public static string dis
        {
            set
            {
                //string sqldis = "select * from storeconfig";
                //DataAccess.ExecuteSQL(sqldis);
                //DataTable dtdis = DataAccess.GetDataTable(sqldis);
                //string vl = dtdis.Rows[0].ItemArray[7].ToString();
                //vl = value;
            }
            get
            {
                string sqldis = "select Dis from tbl_terminallocation   where Shopid = '" + UserInfo.Shopid + "' ";
                DataAccess.ExecuteSQL(sqldis);
                DataTable dtdis = DataAccess.GetDataTable(sqldis);
                string vl = dtdis.Rows[0].ItemArray[0].ToString();
                return vl;
            }
        }
    }


}
