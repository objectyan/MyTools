using System;
using System.Collections.Generic;
using OY.AutoClass.DBAccess.Interface;
using System.Data.SqlClient;
using OY.AutoClass.DBAccess.Model;
using System.Data;

namespace OY.AutoClass.DBAccess.DBAccess
{
    /// <summary>
    /// SQL Server 数据集合
    /// </summary>
    public class SqlServer : IDBAccess
    {
        #region 私有字段
        /// <summary>
        /// SQL Server 链接对象
        /// </summary>
        private SqlConnection conn;
        /// <summary>
        /// SQL Server 脚本执行对象
        /// </summary>
        private SqlCommand cmd;
        /// <summary>
        /// SQL Server 链接字符串
        /// </summary>
        private SqlConnectionStringBuilder connString;
        /// <summary>
        /// 离线脚本操作
        /// </summary>
        private SqlDataAdapter dar;
        /// <summary>
        /// 存储过程返回信息
        /// </summary>
        private Dictionary<string, object> procOutValue;
        #endregion

        #region 构造函数
        public SqlServer() { }

        public SqlServer(ConfigModel item)
        {
            this.connString = new SqlConnectionStringBuilder();
            this.connString.UserID = item.User;
            this.connString.Password = item.Password;
            this.connString.DataSource = item.Server;
            this.connString.InitialCatalog = item.Database;
        }
        #endregion

        #region 接口重写
        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <param name="Sql">T-SQL 脚本</param>
        /// <param name="Para">参数集合</param>
        /// <returns>
        /// 查询正常则返回对应类型数据反之抛出异常
        /// </returns>
        public T QuerySinger<T>(string sql, List<Model.MySqlPara> para = null)
        {
            try
            {
                using (conn = new SqlConnection(connString.ConnectionString))
                {
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(MySqlParaToSqlPara(para));
                    return (T)cmd.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="Sql">T-SQL 脚本</param>
        /// <param name="Para">参数集合</param>
        /// <returns>
        /// 查询正常则返回数据表反之抛出异常
        /// </returns>
        public System.Data.DataSet Query(string sql, List<Model.MySqlPara> para = null)
        {
            try
            {
                using (conn = new SqlConnection(connString.ConnectionString))
                {
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(MySqlParaToSqlPara(para));
                    dar = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dar.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 脚本执行
        /// </summary>
        /// <param name="Sql">T-SQL 脚本</param>
        /// <param name="Para">参数集合</param>
        /// <returns>
        /// 执行正常则返回印象行数反之抛出异常
        /// </returns>
        public int Execute(string sql, List<Model.MySqlPara> para = null)
        {
            try
            {
                using (conn = new SqlConnection(connString.ConnectionString))
                {
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(MySqlParaToSqlPara(para));
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="tranPara">事务执行参数</param>
        /// <returns>
        /// 执行正常则返回印象行数反之抛出异常
        /// </returns>
        public int ExecuteTran(List<Model.MyTranPara> tranPara)
        {
            SqlTransaction tran = null;
            try
            {
                using (conn = new SqlConnection(connString.ConnectionString))
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    int rows = 0;
                    foreach (var item in tranPara)
                    {
                        cmd = new SqlCommand(item.Sql, conn);
                        cmd.Parameters.AddRange(MySqlParaToSqlPara(item.Para));
                        rows += cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    return rows;
                }
            }
            catch (Exception)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                return -1;
            }
        }

        /// <summary>
        /// 执行存储过程数据
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="para">参数集合</param>
        /// <returns>
        /// 存储过程正常执行则返回数据表反之抛出异常
        /// </returns>
        public Model.MyProcData ExecuteProc(string procName, List<Model.MySqlPara> para = null)
        {
            try
            {
                using (conn = new SqlConnection(connString.ConnectionString))
                {
                    Model.MyProcData mpd = new MyProcData();
                    cmd = new SqlCommand(procName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(MySqlParaToSqlPara(para, true));
                    dar = new SqlDataAdapter(cmd);
                    mpd.Ds = new DataSet();
                    dar.Fill(mpd.Ds);
                    if (procOutValue != null && procOutValue.Count > 0)
                    {
                        mpd.ProcOutValue = new Dictionary<string, object>();
                        foreach (var item in procOutValue)
                        {
                            mpd.ProcOutValue.Add(item.Key, cmd.Parameters[item.Key].Value);
                        }
                    }
                    return mpd;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 数据表执行
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dt">数据集</param>
        /// <returns>
        /// 执行正常则返回印象行数反之抛出异常
        /// </returns>
        public int ExecuteTable(string tableName, System.Data.DataTable dt)
        {
            try
            {
                using (conn = new SqlConnection(connString.ConnectionString))
                {
                    SqlBulkCopy bulk = new SqlBulkCopy(conn);
                    bulk.DestinationTableName = tableName;
                    bulk.WriteToServer(dt);
                    return 1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 自定义数据参数对象转化为SqlParameter
        /// </summary>
        /// <param name="para">自定义数据参数对象</param>
        /// <returns>SqlParameter集合</returns>
        private SqlParameter[] MySqlParaToSqlPara(List<MySqlPara> para, bool flag = false)
        {
            if (para == null) return new SqlParameter[0];
            List<SqlParameter> lsSqlPara = new List<SqlParameter>();
            if (flag)
            {
                procOutValue = new Dictionary<string, object>();
            }
            foreach (MySqlPara item in para)
            {
                SqlParameter sqlPara = new SqlParameter();
                sqlPara.ParameterName = item.ParaName;
                sqlPara.Value = item.ParaValue;
                if (item.ParaValue == null)
                {
                    sqlPara.Value = DBNull.Value;
                }
                if (item.DbType != null)
                {
                    sqlPara.DbType = item.DbType;
                }
                if (item.ParaDirection != null)
                {
                    sqlPara.Direction = item.ParaDirection;
                }
                lsSqlPara.Add(sqlPara);
                if (flag)
                {
                    if (item.ParaDirection != null && item.ParaDirection != ParameterDirection.Input
                        && !procOutValue.ContainsKey(item.ParaName))
                    {
                        procOutValue.Add(item.ParaName, null);
                    }
                }
            }
            return lsSqlPara.ToArray();
        }
        #endregion
    }
}
