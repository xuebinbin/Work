/************************************************* 
*作者：赵崇
*小组：
*说明：
*创建日期：2014/11/27 16:55:22
*版本号：V1.0.0
**************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AccountTool
{
    public sealed class SQLHelper
    {
        private SqlCommand cmd = null;
        private SqlConnection conn = null;
        private SqlDataReader sdr = null;

        public static SQLHelper instance = new SQLHelper();

        #region 数据库连接字符串需要手动创建
        ///// <summary>
        ///// 私有的构造函数
        ///// </summary> 
        private SQLHelper()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MSSql2012"].ConnectionString;
            conn = new SqlConnection(strConn);
        }
        #endregion

        /// <summary>
        /// 设置数据库连接字符串——张连海
        /// </summary>
        /// <param name="strConn"></param>
        public void SetConnection(string strConnName)
        {
            string strConnAll = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
            String strConn = strConnAll.Substring(strConnAll.IndexOf("data source"), strConnAll.IndexOf("MultipleActiveResultSets") - strConnAll.IndexOf("data source"));
            conn = new SqlConnection(strConn);
        }

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static SQLHelper GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// 获得数据库连接
        /// </summary>
        /// <returns></returns>
        private SqlConnection GetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <param name="conn">数据库连接</param>
        public static void Close(SqlConnection conn)
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        #region  执行带参数的增删改命令： ExecuteNonQuery(string cmmText, SqlParameter[] para, CommandType cmmType)
        /// <summary>
        /// 执行带参数的增删改命令
        /// </summary>
        /// <param name="cmmText"></param>
        /// <param name="para"></param>
        /// <param name="cmmType"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmmText, SqlParameter[] para, CommandType cmmType)
        {
            using (cmd = new SqlCommand(cmmText, GetConnection()))
            {
                cmd.CommandType = cmmType;
                cmd.Parameters.AddRange(para);
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region  执行不带参数的增删改命令：ExecuteNonQuery(string cmmText, CommandType cmmType)
        /// <summary>
        /// 执行不带参数的增删改命令
        /// </summary>
        /// <param name="cmmText"></param>
        /// <param name="cmmType"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmmText, CommandType cmmType)
        {
            using (cmd = new SqlCommand(cmmText, GetConnection()))
            {
                cmd.CommandType = cmmType;
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region  执行带参数的查询命令：ExecuteQuery(string cmmText, SqlParameter[] para, CommandType cmmType)
        /// <summary>
        /// 执行带参数的查询命令
        /// </summary>
        /// <param name="cmmText"></param>
        /// <param name="para"></param>
        /// <param name="cmmType"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string cmmText, SqlParameter[] para, CommandType cmmType)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(cmmText, GetConnection());
            cmd.CommandType = cmmType;
            cmd.Parameters.AddRange(para);
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
                return dt;
            }
        }
        #endregion

        #region 执行不带参数的查询命令： ExecuteQuery(string cmmText, CommandType cmmType)
        /// <summary>
        /// 执行不带参数的查询命令
        /// </summary>
        /// <param name="cmmText"></param>
        /// <param name="cmmType"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string cmmText, CommandType cmmType)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(cmmText, GetConnection());
            cmd.CommandType = cmmType;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
                return dt;
            }
        }
        #endregion
    }
}