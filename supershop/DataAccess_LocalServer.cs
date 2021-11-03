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
using System.Configuration;

//using System.Data.SQLite;

namespace supershop
{
    //////SQLite Edition
    class DataLocalServer
    {
        static string _ConnectionString = Login.LocalServerConnection();
        
        static SqlConnection _con = null;
        public static SqlConnection con
        {
            get
            {
                if (_con == null)
                {
                    _con = new SqlConnection(_ConnectionString);
                    _con.Open();
                    return _con;

                }
                else if (_con.State != System.Data.ConnectionState.Open)
                {
                    _con.Open();
                    return _con;

                }
                else
                {
                    return _con;
                }
            }
        }

        public static int ExecuteSQL(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteNonQuery();
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
        public static DataSet GetDataSet(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adp.Fill(ds);
                con.Close();

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
                    //MessageBox.Show(exc.Message);
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
                    //MessageBox.Show(exc.Message);
                }
                return null;
            }
        }

    }

}
