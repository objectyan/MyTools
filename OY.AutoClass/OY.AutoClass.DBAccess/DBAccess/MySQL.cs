using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using OY.AutoClass.DBAccess.Interface;
using OY.AutoClass.DBAccess.Model;

namespace OY.AutoClass.DBAccess.DBAccess
{
    public class MySQL : IDBAccess
    {
        #region 私有字段
        /// <summary>
        /// SQL Server 链接对象
        /// </summary>
        private MySqlConnection conn;
        /// <summary>
        /// SQL Server 脚本执行对象
        /// </summary>
        private MySqlCommand cmd;
        /// <summary>
        /// SQL Server 链接字符串
        /// </summary>
        private MySqlConnectionStringBuilder connString;
        /// <summary>
        /// 离线脚本操作
        /// </summary>
        private MySqlDataAdapter dar;
        /// <summary>
        /// 存储过程返回信息
        /// </summary>
        private Dictionary<string, object> procOutValue;
        #endregion

        #region 构造函数
        public MySQL() { }

        public MySQL(ConfigModel item)
        {
            this.connString = new MySqlConnectionStringBuilder();
            this.connString.UserID = item.User;
            this.connString.Password = item.Password;
            this.connString.Server = item.Server;
            this.connString.Database = item.Database;
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
                using (conn = new MySqlConnection(connString.ConnectionString))
                {
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
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
                using (conn = new MySqlConnection(connString.ConnectionString))
                {
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddRange(MySqlParaToSqlPara(para));
                    dar = new MySqlDataAdapter(cmd);
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
                using (conn = new MySqlConnection(connString.ConnectionString))
                {
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
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
            MySqlTransaction tran = null;
            try
            {
                using (conn = new MySqlConnection(connString.ConnectionString))
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    int rows = 0;
                    foreach (var item in tranPara)
                    {
                        cmd = new MySqlCommand(item.Sql, conn);
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
                using (conn = new MySqlConnection(connString.ConnectionString))
                {
                    Model.MyProcData mpd = new MyProcData();
                    cmd = new MySqlCommand(procName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(MySqlParaToSqlPara(para, true));
                    dar = new MySqlDataAdapter(cmd);
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
                using (conn = new MySqlConnection(connString.ConnectionString))
                {
                    MySqlBulkLoader bulk = new MySqlBulkLoader(conn);
                    bulk.TableName = tableName;
                    bulk.FileName = CreateCSVfile(dt);
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
        /// 自定义数据参数对象转化为MySqlParameter
        /// </summary>
        /// <param name="para">自定义数据参数对象</param>
        /// <returns>MySqlParameter集合</returns>
        private MySqlParameter[] MySqlParaToSqlPara(List<MySqlPara> para, bool flag = false)
        {
            if (para == null) return new MySqlParameter[0];
            List<MySqlParameter> lsSqlPara = new List<MySqlParameter>();
            if (flag)
            {
                procOutValue = new Dictionary<string, object>();
            }
            foreach (MySqlPara item in para)
            {
                MySqlParameter sqlPara = new MySqlParameter();
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

        /// <summary>
        /// 生产数据文件
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string CreateCSVfile(DataTable dt)
        {
            string tmp = System.IO.Path.GetTempPath();
            if (string.IsNullOrWhiteSpace(tmp))
            {

            }
            tmp += "";
            StreamWriter sw = new StreamWriter(tmp, false);
            int icolcount = dt.Columns.Count;
            foreach (DataRow drow in dt.Rows)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]))
                    {
                        sw.Write(drow[i].ToString());
                    }
                    if (i < icolcount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            sw.Dispose();
            return tmp;
        }
        #endregion
    }
}
