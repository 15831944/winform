using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LRLibrary
{
    public  class DBLibrary
    {
        public static SqlConnection getConn(string serverIp, string dataBase, string dbUser, string dbPasswd)
        {
            SqlConnection sqlConn = new SqlConnection("server=" + serverIp + ";database=" + dataBase + ";uid=" + dbUser + ";password=" + dbPasswd + "");
            return sqlConn;
        }


        public static DataTable GetData(string sql, SqlConnection sqlConn)
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter(sql, sqlConn);
            DataSet ds = new DataSet();
            if (sqlConn.State.ToString().Equals("Closed"))
                sqlConn.Open();
            sqlDa.Fill(ds);
            sqlConn.Close();
            sqlDa.Dispose();

            return ds.Tables[0];
        }

        public static bool UpdateData(string sql, SqlConnection sqlConn)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                if (sqlConn.State.ToString().Equals("Closed"))
                    sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                sqlConn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

       
    }


}
