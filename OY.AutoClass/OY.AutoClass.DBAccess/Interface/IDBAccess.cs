using System;
using System.Collections.Generic;
using System.Data;
using OY.AutoClass.DBAccess.Model;

namespace OY.AutoClass.DBAccess.Interface
{
    public interface IDBAccess
    {
        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <param name="Sql">T-SQL 脚本</param>
        /// <param name="Para">参数集合</param>
        /// <returns>
        /// 查询正常则返回对应类型数据反之抛出异常
        /// </returns>
        T QuerySinger<T>(string sql, List<MySqlPara> para = null);

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="Sql">T-SQL 脚本</param>
        /// <param name="Para">参数集合</param>
        /// <returns>
        /// 查询正常则返回数据表反之抛出异常
        /// </returns>
        DataSet Query(string sql, List<MySqlPara> para = null);

        /// <summary>
        /// 脚本执行
        /// </summary>
        /// <param name="Sql">T-SQL 脚本</param>
        /// <param name="Para">参数集合</param>
        /// <returns>
        /// 执行正常则返回印象行数反之抛出异常
        /// </returns>
        int Execute(string sql, List<MySqlPara> para = null);

        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="tranPara">事务执行参数</param>
        /// <returns>
        /// 执行正常则返回印象行数反之抛出异常
        /// </returns>
        int ExecuteTran(List<MyTranPara> tranPara);

        /// <summary>
        /// 执行存储过程数据
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="para">参数集合</param>
        /// <returns>
        /// 存储过程正常执行则返回数据表反之抛出异常
        /// </returns>
        MyProcData ExecuteProc(string procName, List<MySqlPara> para = null);

        /// <summary>
        /// 数据表执行
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dt">数据集</param>
        /// <returns>
        /// 执行正常则返回印象行数反之抛出异常
        /// </returns>
        int ExecuteTable(string tableName, DataTable dt);
    }
}
