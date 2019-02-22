using System;
using System.Collections.Generic;
using System.Data;

namespace OY.AutoClass.DBAccess.Model
{
    /// <summary>
    /// 存储过程数据对象
    /// </summary>
    public class MyProcData
    {
        /// <summary>
        /// 存储过程查询数据
        /// </summary>
        private DataSet ds;
        /// <summary>
        /// 存储过程查询数据
        /// </summary>
        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }
        /// <summary>
        /// 存储过程返回信息
        /// </summary>
        private Dictionary<string, object> procOutValue;
        /// <summary>
        /// 存储过程返回信息
        /// </summary>
        public Dictionary<string, object> ProcOutValue
        {
            get { return procOutValue; }
            set { procOutValue = value; }
        }
    }
}
