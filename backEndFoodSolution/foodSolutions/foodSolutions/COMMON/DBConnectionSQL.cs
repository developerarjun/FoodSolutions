using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.COMMON
{
    public static class DBConnectionSQL
    {
        static DBConnectionSQL()
        {
        }
        public static string connectionStr
        {
            get { return @"Server=tcp:np-arjun-db-azure.database.windows.net,1433;
                    Initial Catalog=foodSolutions;Persist Security Info=False;User ID=NP_ARJUN_ADMIN;
                    Password=123@Rjun;MultipleActiveResultSets=False;Encrypt=True;
                    TrustServerCertificate=False;Connection Timeout=30;"; }
        }
        public static SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(DBConnectionSQL.connectionStr);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }
        public static int executeProcedure(string StoreProcName, SqlParameter[] param)
        {
            using (SqlConnection con = DBConnectionSQL.getConnection())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = StoreProcName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static int executeTranProcedure(string StoreProcName, SqlParameter[] param, SqlTransaction tran, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = StoreProcName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (tran != null)
                {
                    cmd.Transaction = tran;
                }
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                return cmd.ExecuteNonQuery();
            }
        }
        public static DataSet gettable(string StoreProcName, SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = DBConnectionSQL.getConnection())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = StoreProcName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(ds);
                }
                return ds;
            }
        }
    }
}