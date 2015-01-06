using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConfigSetting.Data
{
    public class DbHelper
    {
        private static SqlConnection conn;
        private static string strConn = ConfigurationManager.ConnectionStrings["constr"].ToString();
        public static SqlConnection GetConn()
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConn);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            return conn;
        }

        private static void PrepareCommand(SqlCommand cmd, string strSql, CommandType ct, params SqlParameter[] paras)
        {
            cmd.CommandText = strSql;
            cmd.CommandType = ct;
            if (paras != null)
            {
                foreach (SqlParameter para in paras)
                {

                    cmd.Parameters.Add(para);
                }
            }
        }

        /// <summary>
        /// 执行不带参数的sql语句或者存储过程
        /// </summary>
        /// <param name="strSql">Sql语句或者存储过程</param>
        /// <returns></returns>
        public static int ExecuteSql(string strSql)
        {

            return ExecuteSql(strSql, CommandType.Text, null);
        }

        /// <summary>
        /// 执行不带参数的sql语句或者存储过程
        /// </summary>
        /// <param name="strSql">Sql语句或者存储过程</param>
        /// <param name="ct">类型</param>
        /// <returns></returns>
        public static int ExecuteSql(string strSql, params SqlParameter[] paras)
        {

            return ExecuteSql(strSql, CommandType.Text, paras);
        }
        /// <summary>
        /// 执行带参数的Sql语句或者存储过程
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="ct"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExecuteSql(string strSql, CommandType ct, params SqlParameter[] paras)
        {
            int res = 0; ;
            using (SqlCommand cmd = new SqlCommand(strSql, GetConn()))
            {
                PrepareCommand(cmd, strSql, ct, paras);

                try
                {
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return res;
        }

        /// <summary>
        /// 执行不带参数的查询语句或存储过程
        /// </summary>
        /// <param name="strSql">要执行的Sql语句或存储过程</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string strSql)
        {
            return ExecuteDataSet(strSql, null);
        }

        /// <summary>
        /// 执行不带参数的查询语句或存储过程
        /// </summary>
        /// <param name="strSql">要执行的Sql语句或存储过程</param>
        /// <param name="ct">sql语句或存储过程的类型</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string strSql, params SqlParameter[] paras)
        {
            return ExecuteDataSet(strSql, CommandType.Text, paras);
        }
        /// <summary>
        /// 执行带参数的sql语句或存储过程
        /// </summary>
        /// <param name="strSql">要执行的Sql语句或存储过程</param>
        /// <param name="ct">sql语句或存储过程的类型</param>
        /// <param name="paras">参数集合</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string strSql, CommandType ct, params SqlParameter[] paras)
        {
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(strSql, GetConn()))
            {
                PrepareCommand(cmd, strSql, ct, paras);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }
            return ds;
        }

        /// <summary>
        ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
        /// 使用参数数组形式提供参数列表 
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecteNonQuery(string strSql, CommandType ct, params SqlParameter[] paras)
        {
            using (SqlCommand cmd = new SqlCommand(strSql, GetConn()))
            {
                PrepareCommand(cmd, strSql, ct, paras);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }

        public static int ExecteNonQuery(string strSql, params SqlParameter[] paras)
        {
            return ExecteNonQuery(strSql, CommandType.Text, paras);
        }

        public static int ExecteNonQuery(string strSql)
        {
            return ExecteNonQuery(strSql, null);
        }


        public static object ExecuteScalar(string strSql, CommandType ct, params SqlParameter[] paras)
        {
            using (SqlCommand cmd = new SqlCommand(strSql, GetConn()))
            {
                PrepareCommand(cmd, strSql, ct, paras);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }

        public static object ExecuteScalar(string strSql)
        {
            return ExecuteScalar(strSql, CommandType.Text, null);
        }

        public static SqlDataReader ExceuteReader(string strSql, CommandType ct, params SqlParameter[] paras)
        {
            using (SqlCommand cmd = new SqlCommand(strSql, GetConn()))
            {
                PrepareCommand(cmd, strSql, ct, paras);
                SqlDataReader sdr = cmd.ExecuteReader();
                return sdr;
            }
        }

        public static SqlDataReader ExceuteReader(string strSql, params SqlParameter[] paras)
        {
            return ExceuteReader(strSql, CommandType.Text, paras);
        }

        public static SqlDataReader ExceuteReader(string strSql)
        {
            return ExceuteReader(strSql, CommandType.Text, null);
        }
    }
}
