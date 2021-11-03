using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Configuration;


public static class SqlHelper
{
    public static bool ExecuteQuery(SqlCommand cmd)
    {
        using (SqlConnection connection = new SqlConnection(GetConnectionString()))
        {
            connection.Open();
            SqlTransaction transaction;
            transaction = connection.BeginTransaction("Transaction");

            cmd.Connection = connection;
            cmd.Transaction = transaction;
            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
    }

    public static List<t> ReadQuery<t>(string query)
    {
        using (SqlCommand cmd = new SqlCommand(query))
        {
            return ReadQuery<t>(cmd);
        }
    }


    public static List<t> ReadQuery<t>(SqlCommand cmd)
    {
        List<t> result = new List<t>();
        using (SqlConnection Connection = new SqlConnection(GetConnectionString()))
        {
            Connection.Open();
            cmd.Connection = Connection;
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    var i = Activator.CreateInstance<t>();
                    PropertyInfo[] props = i.GetType().GetProperties();
                    foreach (PropertyInfo info in props)
                    {
                        Type type = info.PropertyType;
                        if (!DBNull.Value.Equals(rdr[info.Name]))
                        {
                            info.SetValue(i, Convert.ChangeType(rdr[info.Name], type), null);
                        }
                    }
                    result.Add(i);
                }
            }
            else
            {
                return null;
            }
        }
        return result;
    }

    public static string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
    }
}
