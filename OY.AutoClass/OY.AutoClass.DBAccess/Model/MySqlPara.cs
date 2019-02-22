using System;
using System.Data;

namespace OY.AutoClass.DBAccess.Model
{
    /// <summary>
    /// 定义参数对象
    /// </summary>
    public class MySqlPara
    {
        /// <summary>
        /// 参数名
        /// </summary>
        private string paraName;

        /// <summary>
        /// 参数名
        /// </summary>
        public string ParaName
        {
            get { return paraName; }
            set { paraName = value; }
        }
        /// <summary>
        /// 参数值
        /// </summary>
        private object paraValue;
        /// <summary>
        /// 参数值
        /// </summary>
        public object ParaValue
        {
            get { return paraValue; }
            set { paraValue = value; }
        }
        /// <summary>
        /// 数据类型
        /// </summary>
        private DbType dbType;
        /// <summary>
        /// 数据类型
        /// </summary>
        public DbType DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }
        /// <summary>
        /// 参数类型
        /// </summary>
        private ParameterDirection paraDirection;
        /// <summary>
        /// 参数类型
        /// </summary>
        public ParameterDirection ParaDirection
        {
            get { return paraDirection; }
            set { paraDirection = value; }
        }
        /// <summary>
        /// 默认初始化
        /// </summary>
        public MySqlPara() { }

        /// <summary>
        /// 初始化 参数名 与 参数值
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="paraValue">参数值</param>
        public MySqlPara(string paraName, object paraValue)
        {
            this.paraName = paraName;
            this.paraValue = paraValue;
        }

        /// <summary>
        /// 初始化 参数名 、 参数值 、 参数类型
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="paraValue">参数值</param>
        /// <param name="dbType">参数类型</param>
        public MySqlPara(string paraName, object paraValue, DbType dbType)
        {
            this.paraName = paraName;
            this.paraValue = paraValue;
            this.dbType = dbType;
        }

        /// <summary>
        /// 初始化 参数名 、 参数值 、 参数数据类型、参数类型
        /// </summary>
        /// <param name="paraName">参数名</param>
        /// <param name="paraValue">参数值</param>
        /// <param name="dbType">参数数据类型</param>
        /// <param name="dbType">参数类型</param>
        public MySqlPara(string paraName, object paraValue, DbType dbType, ParameterDirection paraDirection)
        {
            this.paraName = paraName;
            this.paraValue = paraValue;
            this.dbType = dbType;
            this.paraDirection = paraDirection;
        }
    }
}
