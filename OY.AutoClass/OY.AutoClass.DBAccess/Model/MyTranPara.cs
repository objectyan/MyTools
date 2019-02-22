using System;
using System.Collections.Generic;

namespace OY.AutoClass.DBAccess.Model
{
    /// <summary>
    /// 事务参数定义
    /// </summary>
    public class MyTranPara
    {
        /// <summary>
        /// T-SQL 脚本
        /// </summary>
        private string sql;
        /// <summary>
        /// T-SQL 脚本
        /// </summary>
        public string Sql
        {
            get { return sql; }
            set { sql = value; }
        }
        /// <summary>
        /// 参数集合
        /// </summary>
        private List<MySqlPara> para;
        /// <summary>
        /// 参数集合
        /// </summary>
        public List<MySqlPara> Para
        {
            get { return para; }
            set { para = value; }
        }

        /// <summary>
        /// 默认初始化
        /// </summary>
        public MyTranPara() { }

        /// <summary>
        /// 初始化 T-SQL 脚本 与 参数集合
        /// </summary>
        /// <param name="sql">T-SQL 脚本</param>
        /// <param name="para">参数集合</param>
        public MyTranPara(string sql, List<MySqlPara> para)
        {
            this.sql = sql;
            this.para = para;
        }
    }
}
