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

//using System.Data.SQLite;

namespace supershop
{
    //////SQLite Edition
    class Datasyncpso
    {
        public static string dbpath = UserInfo.Sync_path;
        static string _ConnectionSyncpso = dbpath;

      //  static string _ConnectionSyncpso = @"Data Source=Syncpso.db;Version=3;New=False;Compress=True";

        static SQLiteConnection _Connectionsyncpso = null;
        public static SQLiteConnection Connectionsyncpso
        {
            get
            {
                if (_Connectionsyncpso == null)
                {

                        _Connectionsyncpso = new SQLiteConnection(_ConnectionSyncpso);
                        _Connectionsyncpso.Open();

                      
                    return _Connectionsyncpso;

                }
                else if (_Connectionsyncpso.State != System.Data.ConnectionState.Open)
                {
                    _Connectionsyncpso.Open();
                    return _Connectionsyncpso;

                }
                else
                {
                    return _Connectionsyncpso;
                }
            }
        }

        public static DataSet GetDataSetsyncpso(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
              
                    SQLiteCommand cmd = new SQLiteCommand(sql, Connectionsyncpso);
                    SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

                   
                    adp.Fill(ds);
                  
                Connectionsyncpso.Close();

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

        public static DataTable GetDataTablesyncpso(string sql)
        {
            try
            {
                Console.WriteLine(sql);
                DataSet ds = GetDataSetsyncpso(sql);

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

        public static int ExecuteSQLsyncpso(string sql)
        {
            try
            {
                int RC;
               
                    SQLiteCommand cmd = new SQLiteCommand(sql, Connectionsyncpso);
                    RC = cmd.ExecuteNonQuery();

                   
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

        public static int insert_Live_sync(string Query, string TableName, string ActionName)
        {
            string EnCQuery = EncryptionClass.Encrypt(Query);
            DateTime insert_date = DateTime.Now;
            string sql = "insert into Sync_pos (Qyery,insert_date,ISSync,TableName,ActionName) values ('" + EnCQuery + "' , '" + insert_date + "' ,1,'" + TableName + "','" + ActionName + "')";
            int RC = Datasyncpso.ExecuteSQLsyncpso(sql);
          //  MessageBox.Show("" + RC);
            return RC;
        }        
    }

}
