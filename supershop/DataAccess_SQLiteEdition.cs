using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Finisar.SQLite;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer;
using System.IO;
using System.Net;
using System.Drawing.Printing;
using System.ComponentModel;

//using System.Data.SQLite;

namespace supershop
{
    //////SQLite Edition
    class DataAccess
    {

        // Connection String for  SQlite Edition
        //static string _ConnectionString = @"Data Source=psodb.db;Version=3;New=False;Compress=True";
        //public static string txtipaddress = "Ayo\\g\\Parimal";
        public static string dbpath = UserInfo.Database_path;
        static string _ConnectionString = dbpath;
        //static string _ConnectionString = @"Data Source=\\" + dbpath + "\\psodb.db;Version=3;New=False;Compress=True;";
        //Data Source=DemoT.db;Version=3;New=False;Compress=True;

        // Use for Adv_POS.exe.config file -- you can change Database server info after compile/Debug 
        //  static string _ConnectionString = supershop.Properties.Settings.Default.psodbConnectionString1;

        //Its absolute Connection String for MS SQL Server 2008 - Upto
        //static string _ConnectionString = "Data Source=(local);Initial Catalog=APOSDB; User ID=aposdb;Password=aposdb!";


        //This is Mysql Database Access  class -- leave empty if your Mysal does not has PASSWORD       
        // static string _ConnectionString = "server=localhost; database=aposmysqldb; uid=root; PASSWORD=";




        static SQLiteConnection _Connection = null;
        public static SQLiteConnection LocalConnection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new SQLiteConnection(_ConnectionString);
                    _Connection.Open();
                    return _Connection;

                }
                else if (_Connection.State != System.Data.ConnectionState.Open)
                {
                    _Connection.Open();
                    return _Connection;

                }
                else
                {
                    return _Connection;
                }
            }
        }

        public static DataSet GetDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SQLiteTransaction tr = LocalConnection.BeginTransaction())
                {
                    SQLiteCommand cmd = new SQLiteCommand(sql, LocalConnection);
                    SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

                  
                    adp.Fill(ds);
                   

                    tr.Commit();
                   // LocalConnection.Close();
                }

                return ds;
            }
            catch (Exception exc)
            {
                if (exc.Message == "database is locked")
                {
                    MessageBox.Show("Please Close Database File");
                }
                else
                {
                    MessageBox.Show(exc.Message);
                }
                return null;
            }
        }

        public static DataTable GetDataTable(string sql)
        {
            try
            {
                Console.WriteLine(sql);
                DataSet ds = GetDataSet(sql);

                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch (Exception exc)
            {
                if (exc.Message == "database is locked")
                {
                    MessageBox.Show("Please Close Database File");
                }
                else
                {
                    MessageBox.Show(exc.Message);
                }
                return null;
            }
        }

        public static int ExecuteSQL(string sql)
        {
            try
            {
                int RC;
                using (SQLiteTransaction tr = LocalConnection.BeginTransaction())
                {
                    SQLiteCommand cmd = new SQLiteCommand(sql, LocalConnection);
                    RC = cmd.ExecuteNonQuery();

                    tr.Commit();
                }
                    //LocalConnection.Close();
            
                return RC;

            }
            catch (Exception exc)
            {
                if (exc.Message == "database is locked")
                {
                    MessageBox.Show("Please Close Database File");
                }
                else
                {
                    MessageBox.Show(exc.Message);
                }

                return 0;
            }
        }

        public static string LOGO_path()
        {
            string Path = "";
            string SqlQty = "select Logo from storeconfig where TenentID = " + Tenent.TenentID + "";

            DataTable dt = DataAccess.GetDataTable(SqlQty);
            if (dt.Rows.Count > 0)
            {
                Path = Application.StartupPath + @"\LOGO\" + dt.Rows[0]["Logo"];
                if (File.Exists(Path))
                {

                }
                else
                {
                    Path = dt.Rows[0]["Logo"].ToString();
                }
            }
            return Path;
        }


        public static int updateSales(double OnHand, double Qty, string itemids, string uom)
        {
            double QtyOut = 0;
            string SqlQty = "select QtyOut from tbl_item_uom_price where TenentID = " + Tenent.TenentID + " and itemID = '" + itemids + "' and UOMID = '" + uom + "' ";

            DataTable dt = DataAccess.GetDataTable(SqlQty);
            if (dt.Rows.Count > 0)
                QtyOut = Convert.ToDouble(dt.Rows[0]["QtyOut"]);
            double Final = QtyOut + Qty;

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = " update tbl_item_uom_price set OnHand = '" + OnHand + "' , " +
                                    " QtyOut = '" + Final + "' " +
                                    ",Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where itemID = '" + itemids + "' and UOMID = '" + uom + "' and TenentID= " + Tenent.TenentID + " ";
            int RC = DataAccess.ExecuteSQL(sql);

            string sqlwin = " update Win_tbl_item_uom_price set OnHand = '" + OnHand + "' , " +
                                    " QtyOut = '" + Final + "' " +
                                    ",Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where itemID = '" + itemids + "' and UOMID = '" + uom + "' and TenentID= " + Tenent.TenentID + " ";

            Datasyncpso.insert_Live_sync(sqlwin, "Win_tbl_item_uom_price", "UPDATE");
            return RC;
        }

        public static int OrderDeliverd(string sales_id, string OrderStutas, string invoiceNO)
        {
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = " update sales_item set " +
                                    " OrderStutas = '" + OrderStutas + "' " +
                                    ",Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where sales_id = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
            int RC = DataAccess.ExecuteSQL(sql);

            string sqlwin = " update Win_sales_item set " +
                                    " OrderStutas = '" + OrderStutas + "' " +
                                    ",Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where sales_id = '" + sales_id + "' and TenentID= " + Tenent.TenentID + "";

            Datasyncpso.insert_Live_sync(sqlwin, "Win_sales_item", "UPDATE");

            string Sqlselect = "select sales_id from sales_item where TenentID= " + Tenent.TenentID + " and sales_id = '" + sales_id + "' and PaymentMode = 'COD' ";
            DataTable dt = GetDataTable(Sqlselect);
            if (dt.Rows.Count > 0)
            {
                decimal ShiftSales = GetSalesAmount(invoiceNO);
                SalesRegister.Update_ShiftSales_DayClose(ShiftSales);
            }

            string ActivityName = "Order Delivered";
            string LogData = "Order Delivered with InvoiceNO = " + invoiceNO + " ";
            Login.InsertUserLog(ActivityName, LogData);

            return RC;
        }
        public static int BookingOrderDeliverd(string sales_id, string OrderStutas)
        {
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = " update sales_item set " +
                                    " OrderStutas = '" + OrderStutas + "' " +
                                    ",Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where sales_id = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
            int RC = DataAccess.ExecuteSQL(sql);

            string sqlwin = " update Win_sales_item set " +
                                    " OrderStutas = '" + OrderStutas + "' " +
                                    ",Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where sales_id = '" + sales_id + "' and TenentID= " + Tenent.TenentID + "";

            Datasyncpso.insert_Live_sync(sqlwin, "Win_sales_item", "UPDATE");


            string ActivityName = "Booking Order Delivered";
            string LogData = "Booking Order Delivered with sales_id = " + sales_id + " but Payment is Pending ";
            Login.InsertUserLog(ActivityName, LogData);

            return RC;
        }
        public static decimal GetSalesAmount(string InvoiceNO)
        {
            decimal TotalAmt = 0;
            string Sql = "select * from sales_payment where TenentID = " + Tenent.TenentID + " and InvoiceNO = '" + InvoiceNO + "' ";
            DataTable dt = DataAccess.GetDataTable(Sql);
            if (dt.Rows.Count > 0)
            {
                string SqlAmount = "select sum(payment_amount) from sales_payment where TenentID = " + Tenent.TenentID + " and InvoiceNO = '" + InvoiceNO + "'";

                DataTable dtamount = DataAccess.GetDataTable(SqlAmount);
                if (dtamount.Rows.Count > 0)
                {
                    TotalAmt = Convert.ToDecimal(dtamount.Rows[0][0]);
                }
            }
            return TotalAmt;

        }

        public static int PaymentStstusUpdate(string sales_id, string PaymentStutas)
        {
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = " update sales_payment set " +
                                    " PaymentStutas = '" + PaymentStutas + "' " +
                                    ",Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where sales_id = '" + sales_id + "' and TenentID= " + Tenent.TenentID + " ";
            int RC = DataAccess.ExecuteSQL(sql);

            string sqlwin = " update Win_sales_payment set " +
                                    " PaymentStutas = '" + PaymentStutas + "' " +
                                    ",Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                    " where sales_id = '" + sales_id + "' and TenentID= " + Tenent.TenentID + "";

            Datasyncpso.insert_Live_sync(sqlwin, "Win_sales_payment", "UPDATE");
            return RC;
        }

        public static void getTEnentID()
        {
            int TenentID = 0;
            string SqlQty = "select * from mycompanysetup_winapp ";

            DataTable dt = DataAccess.GetDataTable(SqlQty);
            if (dt.Rows.Count > 0)
                TenentID = Convert.ToInt32(dt.Rows[0]["TenentID"]);

            Tenent.TenentID = TenentID;
            //return TenentID;
        }

        public static string GetCompanyFullName()
        {
            try
            {
                string Company = "";
                string SqlQty = "select * from storeconfig where TenentID = " + Tenent.TenentID + " ";

                DataTable dt = DataAccess.GetDataTable(SqlQty);
                if (dt.Rows.Count > 0)
                    Company = dt.Rows[0]["companyname"].ToString();


                return Company;
            }
            catch
            {
                return null;
            }
        }

        public static string GetCompany()
        {
            try
            {
                string Company = "";
                string SqlQty = "select * from storeconfig where TenentID = " + Tenent.TenentID + " ";

                DataTable dt = DataAccess.GetDataTable(SqlQty);
                if (dt.Rows.Count > 0)
                    Company = dt.Rows[0]["companyname"].ToString();


                if (Company != "")
                {
                    if (Company.Length >= 8)
                    {
                        string[] Short = Company.ToString().Split(' ');
                        Company = Short[0];
                        if (Company.Length >= 8)
                        {
                            Company = Company.Substring(0, 7);
                        }
                    }
                    else
                    {
                        if (Company.Length >= 8)
                        {
                            Company = Company.Substring(0, 7);
                        }

                    }

                }

                return Company;
            }
            catch
            {
                return null;
            }
        }


        public static int checkMinus()
        {
            //int TenentID = 0;
            //string SqlQty = "select * from mycompanysetup_winapp ";

            //DataTable dt = DataAccess.GetDataTable(SqlQty);
            //if (dt.Rows.Count > 0)
            //    TenentID = Convert.ToInt32(dt.Rows[0]["TenentID"]);
            int TenentID = Tenent.TenentID;// getTEnentID();// Login.get_reg_TenentID();
            string sqlcheckminus = "select AllowMinusQty from tblsetupsalesh where TenentID=" + TenentID + " and LocationID=1 and AllowMinusQty=1";
            DataSet ds = GetDataSet(sqlcheckminus);
            int AllowMinusQty = 0;
            if (ds.Tables[0].Rows.Count > 0)
                AllowMinusQty = 1;

            return AllowMinusQty;
        }

        public static int UpdateAllowMinus(int AllowMinus)
        {
            int TenentID = Tenent.TenentID;// getTEnentID();

            string SqlQty = "select * from tblsetupsalesh where TenentID=" + TenentID + " ";
            DataTable dt = DataAccess.GetDataTable(SqlQty);
            if (dt.Rows.Count > 0)
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sql = "update tblsetupsalesh set AllowMinusQty =" + AllowMinus + " where TenentID=" + TenentID + " and LocationID=1";
                int RC = DataAccess.ExecuteSQL(sql);

                string sqlwin = "update Win_tblsetupsalesh set AllowMinusQty =" + AllowMinus + ", " +
                                " Uploadby= '" + UserInfo.UserName + "' ,UploadDate = '" + UploadDate + "' ,SynID = 2 " +
                                " where TenentID=" + TenentID + " and locationID=1";
                Datasyncpso.insert_Live_sync(sqlwin, "Win_tblsetupsalesh", "UPDATE");

                return RC;
            }
            else
            {
                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlLogIn = " insert into tblsetupsalesh (TenentID, LocationID,AllowMinusQty,Uploadby ,UploadDate ,SynID) " +
                                    " values ('" + TenentID + "' ,1,1,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                int RC = DataAccess.ExecuteSQL(sqlLogIn);

                string sqlLogI = " insert into Win_tblsetupsalesh (TenentID, LocationID,AllowMinusQty,Uploadby ,UploadDate ,SynID) " +
                                   " values ('" + TenentID + "' ,1,1,'" + UserInfo.UserName + "' , '" + UploadDate + "'  , 1 )";
                Datasyncpso.insert_Live_sync(sqlLogI, "Win_tblsetupsalesh", "INSERT");

                return RC;
            }

        }

        public static void writeFile(string createText)
        {
            CreateFile();
            string Filepath = Application.StartupPath + @"\insert.sql";
            File.WriteAllText(Filepath, createText);

            TextWriter tsw = new StreamWriter(Filepath, true);
            tsw.WriteLine(createText);
            tsw.Close();
        }
        public static void CreateFile()
        {

            string Filepath = Application.StartupPath + @"\insert.sql";

            if (!File.Exists(Filepath))
            {
                FileStream fs1 = new FileStream(Filepath, FileMode.OpenOrCreate, FileAccess.Write);

                fs1.Close();
                //StreamWriter writer = new StreamWriter(fs1);
                //writer.Write("Hello Welcome");
                //writer.Close();
            }

        }

        public static string Translate(string textvalue, string to)
        {
            string appId = "A70C584051881A30549986E65FF4B92B95B353A5";//go to http://msdn.microsoft.com/en-us/library/ff512386.aspx to obtain AppId.
            // string textvalue = "Translate this for me";
            string from = "en";

            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?appId=" + appId + "&text=" + textvalue + "&from=" + from + "&to=" + to;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    string translation = (string)dcs.ReadObject(stream);
                    return translation;
                }
            }
            catch (WebException e)
            {
                return "";
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }

        public static int getPaymentid(int TenentID, string sales_id)
        {
            int ID12 = 1;
           // string sql12 = "select ID from sales_payment where TenentID=" + TenentID + " and sales_id='" + sales_id + "'  ";
           // DataTable dtpayment = DataAccess.GetDataTable(sql12);
           //
           // if (dtpayment.Rows.Count > 0)
           // {
                string sql123 = " select MAX(ID) from sales_payment where TenentID=" + TenentID + " and sales_id='" + sales_id + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (Convert.ToString(dt12.Rows[0][0]) != "")
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
          //  }
            return ID12;
        }
        public static int getPaymentidRecivable(int TenentID, string sales_id)
        {
            int ID12 = 1;
            string sql12 = "select * from sales_payment_Recivable where TenentID=" + TenentID + " and sales_id='" + sales_id + "'  ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from sales_payment_Recivable where TenentID=" + TenentID + " and sales_id='" + sales_id + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }
        public static double getsalesMYid(int TenentID, string sales_id)
        {
            double ID12 = 1;
            string sql12 = "select sales_id from sales_item where TenentID=" + TenentID + " and sales_id='" + sales_id + "'  ";
            DataTable dtsalemy = DataAccess.GetDataTable(sql12);

            if (dtsalemy.Rows.Count > 0)
            {
                string sql123 = " select MAX(item_id) from sales_item where TenentID=" + TenentID + " and sales_id='" + sales_id + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    double id = Convert.ToDouble(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getReturnMYid(int TenentID, string return_id)
        {
            int ID12 = 1;
            string sql12 = "select * from return_item where TenentID=" + TenentID + " and return_id='" + return_id + "'  ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from return_item where TenentID=" + TenentID + " and return_id='" + return_id + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getCustomerMYid(int TenentID)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_customer where TenentID=" + TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from tbl_customer where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getLiveCustomerMYid(int TenentID)
        {
            int ID12 = 1;
            string sql12 = "select * from Win_tbl_customer where TenentID=" + TenentID + " ";
            DataTable dt1 = DataLive.GetLiveDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from Win_tbl_customer where TenentID=" + TenentID + " ";
                DataTable dt12 = DataLive.GetLiveDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getsaleInfoMYid(int TenentID, string InvoiceNo)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_saleInfo where TenentID=" + TenentID + " and InvoiceNo='" + InvoiceNo + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from tbl_saleInfo where TenentID=" + TenentID + " and InvoiceNo='" + InvoiceNo + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getUOMid(int TenentID)
        {
            int UOM = 1;
            string sql12 = "select * from ICUOM where TenentID=" + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(UOM) from ICUOM where TenentID=" + Tenent.TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);

                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    UOM = id + 1;
                }
            }
            return UOM;
        }

        public static int getREFIDid(int TenentID)
        {
            int UOM = 1;
            string sql12 = "select * from REFTABLE where TenentID=" + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(REFID) from REFTABLE where TenentID=" + Tenent.TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);

                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    UOM = id + 1;
                }
            }
            return UOM;
        }

        public static int getLiveUOMid(int TenentID)
        {
            int UOM = 1;
            string sql12 = "select * from ICUOM where TenentID=" + Tenent.TenentID + " ";
            DataTable dt1 = DataLive.GetLiveDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(UOM) from ICUOM where TenentID=" + Tenent.TenentID + " ";
                DataTable dt12 = DataLive.GetLiveDataTable(sql123);

                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    UOM = id + 1;
                }
            }
            return UOM;
        }


        public static int getReceipeid(int TenentID)
        {
            int recNo = 1;
            string sql12 = " select * from tbl_Receipe where TenentID=" + Tenent.TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(recNo) from tbl_Receipe where TenentID=" + Tenent.TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);

                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    recNo = id + 1;
                }
            }
            return recNo;
        }

        public static int getworkrecordsMYid(int TenentID)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_workrecords where TenentID=" + TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from tbl_workrecords where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getDayCloseMYid(int TenentID)
        {
            int ID12 = 1;
            string sql12 = "select * from DayClose where TenentID=" + TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from DayClose where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getUserLogMYid(int TenentID)
        {
            int ID12 = 1;
            string sql12 = "select TenentID from Win_tbl_UserLog where TenentID=" + TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from Win_tbl_UserLog where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            else
            {
                // int id = getUserLogMYidLive(TenentID);
                // if (id != 0)
                // {
                //     ID12 = id + 1;
                // }
                ID12 = 1;
            }
            return ID12;
        }

        public static int getUserLogMYidLive(int TenentID)
        {
            int ID12 = 0;
            string sql12 = "select * from Win_tbl_UserLog where TenentID=" + TenentID + " ";
            DataTable dt1 = DataLive.GetLiveDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from Win_tbl_UserLog where TenentID=" + TenentID + " ";
                DataTable dt12 = DataLive.GetLiveDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }

            return ID12;
        }

        public static int getterminallocationMYid(int TenentID)
        {
            int ID12 = 1;
            //remove this sahir
            string sql12 = "select * from tbl_terminallocation where TenentID=" + TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from tbl_terminallocation where  TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getCAT_MSTMYid(int TenentID)
        {
            int CATID = 1;
            string sql12 = " select * from CAT_MST where TenentID=" + TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(CATID) from CAT_MST where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);

                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    CATID = id + 1;
                }

            }
            return CATID;
        }

        public static int getLiveCAT_MSTMYid(int TenentID)
        {
            int CATID = 1;
            string sql12 = " select * from CAT_MST where TenentID=" + TenentID + " ";
            DataTable dt1 = DataLive.GetLiveDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(CATID) from CAT_MST where TenentID=" + TenentID + " ";
                DataTable dt12 = DataLive.GetLiveDataTable(sql123);

                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    CATID = id + 1;
                }

            }
            return CATID;
        }

        public static int getCashDeliveryMYid(int TenentID, int UserID, string TrmID)
        {
            int ID12 = 1;
            string sql12 = "select * from CashDelivery where TenentID=" + TenentID + " and UserID='" + UserID + "' and TrmID='" + TrmID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from CashDelivery where TenentID=" + TenentID + " and UserID='" + UserID + "' and TrmID='" + TrmID + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getICIT_BR_TMPMYid(int TenentID, double MyProdID, int UOM)
        {
            int ID12 = 1;
            string sql12 = "select * from ICIT_BR_TMP where TenentID=" + TenentID + " and MyProdID='" + MyProdID + "' and UOM='" + UOM + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from ICIT_BR_TMP where TenentID=" + TenentID + " and MyProdID='" + MyProdID + "' and UOM='" + UOM + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }
        public static int getICIT_BR_TMPSerializeMYid(int TenentID, double MyProdID, int UOM)
        {
            int ID12 = 1;
            string sql12 = "select * from ICIT_BR_TMPSerialize where TenentID=" + TenentID + " and MyProdID='" + MyProdID + "' and UOM='" + UOM + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from ICIT_BR_TMPSerialize where TenentID=" + TenentID + " and MyProdID='" + MyProdID + "' and UOM='" + UOM + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }
        public static int getICIT_BR_TMPSerialize(int TenentID, double MyProdID, int UOM,string Serial)
        {
            int ID12 = 1;
            string sql12 = "select * from ICIT_BR_TMPSerialize where TenentID=" + TenentID + " and MyProdID='" + MyProdID + "' and UOM='" + UOM + "' and Serial_Number='" + Serial + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from ICIT_BR_TMPSerialize where TenentID=" + TenentID + " and MyProdID='" + MyProdID + "' and UOM='" + UOM + "' and Serial_Number='" + Serial + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int gettbl_duepaymentMYid(int TenentID, string sales_id)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_duepayment where TenentID=" + TenentID + " and sales_id='" + sales_id + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(id) from tbl_duepayment where TenentID=" + TenentID + "  and sales_id='" + sales_id + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getorderWay_MaintenanceMYid(int TenentID)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_orderWay_Maintenance where TenentID=" + TenentID + "  ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from tbl_orderWay_Maintenance where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getorderWay_transectionMYid(int TenentID, string Sales_ID)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_orderWay_transection where TenentID=" + TenentID + " and Sales_ID='" + Sales_ID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from tbl_orderWay_transection where TenentID=" + TenentID + " and Sales_ID='" + Sales_ID + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getusermgtMYid(int TenentID)
        {
            int ID12 = 1;

            string sql12 = "select * from usermgt where TenentID=" + TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from usermgt where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getAppointmentMaxID(int TenentID, int LocationID)
        {
            int ID12 = 1;
            string sql12 = "select * from Appointment where TenentID=" + TenentID + " and LocationID = " + LocationID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from Appointment where TenentID=" + TenentID + " and LocationID = " + LocationID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getuom_priceMYid(int TenentID, string itemID, int UOMID)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_item_uom_price where TenentID=" + TenentID + " and itemID='" + itemID + "' and UOMID='" + UOMID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from tbl_item_uom_price where TenentID=" + TenentID + " and itemID='" + itemID + "' and UOMID='" + UOMID + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getLiveuom_priceMYid(int TenentID, string itemID, int UOMID)
        {
            int ID12 = 1;
            string sql12 = "select * from Win_tbl_item_uom_price where TenentID=" + TenentID + " and itemID='" + itemID + "' and UOMID='" + UOMID + "' ";
            DataTable dt1 = DataLive.GetLiveDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from Win_tbl_item_uom_price where TenentID=" + TenentID + " and itemID='" + itemID + "' and UOMID='" + UOMID + "' ";
                DataTable dt12 = DataLive.GetLiveDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getCustomer_Eye_MYid(int TenentID, string CustomerID)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_Customer_Eye_history where TenentID=" + TenentID + " and CustomerID='" + CustomerID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(MyID) from tbl_Customer_Eye_history where TenentID=" + TenentID + " and CustomerID='" + CustomerID + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }
        public static int getCustomer_Advance_MYid(int TenentID, string CustomerID)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_Customer_Advance where TenentID=" + TenentID + " and CustomerID='" + CustomerID + "' ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(MyID) from tbl_Customer_Advance where TenentID=" + TenentID + " and CustomerID='" + CustomerID + "' ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static int getexpenseMYid(int TenentID)
        {
            int ID12 = 1;
            string sql12 = "select * from tbl_expense where TenentID=" + TenentID + " ";
            DataTable dt1 = DataAccess.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from tbl_expense where TenentID=" + TenentID + " ";
                DataTable dt12 = DataAccess.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public static void Update_ShiftCIH_DayClose()
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            decimal todayCash = 0;

            string Condition = "where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "' ";
            string sql = "select ((OpAMT + ShiftSales) - (ShiftReturn + VoucharAMT + ExpAMT + ChequeAMT + AMTDelivered + Shiftpurchase  )) as TodayCash from DayClose " + Condition;
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                todayCash = Convert.ToDecimal(dt.Rows[0]["TodayCash"]);

            }

            string sql5 = "Select ID from DayClose where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "' ";
            DataTable dtday = DataAccess.GetDataTable(sql5);
            if (dtday.Rows.Count > 0)
            {
                string sql1 = " Update DayClose set ShiftCIH=" + todayCash + " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'  ";
                DataAccess.ExecuteSQL(sql1);

                string sqlWin = "  Update DayClose set  ShiftCIH=" + todayCash + " " +
                      " where TenentID=" + Tenent.TenentID + " and UserID = '" + UserInfo.Userid + "' and TrmID = '" + UserInfo.Shopid + "' and ShiftID = " + UserInfo.ShiftID + " and Date = '" + Date + "'    ";
                Datasyncpso.insert_Live_sync(sqlWin, "DayClose", "UPDATE");
            }
        }

        public static string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }

        public static string USERDefaultPrinter(string Type) // Cash , Credit , Kitchen
        {
            string DefaultPrinter = "";
            string sql5 = "Select * from tblPrintSetup where TenentID=" + Tenent.TenentID + " and Shopid = '" + UserInfo.Shopid + "' ";
            DataTable dt5 = DataAccess.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                if (Type == "Cash")
                {
                    if (dt5.Rows[0]["CashReciptPRinter"] != null)
                    {
                        DefaultPrinter = dt5.Rows[0]["CashReciptPRinter"].ToString();
                    }
                }
                else if (Type == "Credit")
                {
                    if (dt5.Rows[0]["CreditInvoicePrinter"] != null)
                    {
                        DefaultPrinter = dt5.Rows[0]["CreditInvoicePrinter"].ToString();
                    }
                }
                else if (Type == "Kitchen")
                {
                    if (dt5.Rows[0]["KitchenNotePrinter"] != null)
                    {
                        DefaultPrinter = dt5.Rows[0]["KitchenNotePrinter"].ToString();
                    }
                }
                else
                {
                    if (dt5.Rows[0]["CashReciptPRinter"] != null)
                    {
                        DefaultPrinter = dt5.Rows[0]["CashReciptPRinter"].ToString();
                    }
                }

            }

            if (DefaultPrinter == "")
            {
                DefaultPrinter = GetDefaultPrinter();
            }

            return DefaultPrinter;
        }

        public static string getstr(string Str)
        {
            if (Str!="")
            {
                Str = Str.Replace("'", "");
                Str = Str.Replace("\"", "");
            }            
            return Str;
        }

    }

}
