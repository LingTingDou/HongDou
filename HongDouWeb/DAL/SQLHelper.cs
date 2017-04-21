using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HongDouWeb.DAL
{
    public class SQLHelper
    {
        public static string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
            /// <summary>
            /// 通用查询
            /// </summary>
            /// <param name="sql"></param>
            /// <param name="sqlparam"></param>
            /// <returns></returns>
            public static DataTable SelectData(string sql, SqlParameter[] sqlparam)
            {
                using (SqlConnection sqlcon = new SqlConnection(strcon))
                {
                    using (SqlCommand comm = new SqlCommand(sql, sqlcon))
                    {
                        comm.CommandTimeout = 120;
                        comm.Parameters.Clear();
                        if (sqlparam != null)
                        {
                            comm.Parameters.AddRange(sqlparam);
                        }
                        using (SqlDataAdapter sqladap = new SqlDataAdapter(comm))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                sqladap.Fill(ds);
                                return ds.Tables[0];
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// 通用新增
            /// </summary>
            /// <param name="sql"></param>
            /// <param name="sqlparam"></param>
            /// <returns></returns>
            public static int InsertData(string sql, SqlParameter[] sqlparam)
            {
                using (SqlConnection sqlcon = new SqlConnection(strcon))
                {
                    sqlcon.Open();
                    using (SqlCommand comm = new SqlCommand(sql, sqlcon))
                    {
                        comm.Parameters.Clear();
                        if (sqlparam != null)
                        {
                            comm.Parameters.AddRange(sqlparam);
                        }
                        return Convert.ToInt32(comm.ExecuteScalar());

                    }
                }
            }

            /// <summary>
            /// 通用修改
            /// </summary>
            /// <param name="sql"></param>
            /// <param name="sqlparam"></param>
            /// <returns></returns>
            public static int UpdateData(string sql, SqlParameter[] sqlparam)
            {
                using (SqlConnection sqlcon = new SqlConnection(strcon))
                {
                    sqlcon.Open();
                    using (SqlCommand comm = new SqlCommand(sql, sqlcon))
                    {
                        comm.Parameters.Clear();
                        if (sqlparam != null)
                        {
                            comm.Parameters.AddRange(sqlparam);
                        }
                        return comm.ExecuteNonQuery();
                    }
                }
            }

    }
}