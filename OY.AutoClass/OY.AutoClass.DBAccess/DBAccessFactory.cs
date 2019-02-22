using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using OY.AutoClass.DBAccess.DBAccess;
using OY.AutoClass.DBAccess.Interface;
using OY.AutoClass.DBAccess.Model;

namespace OY.AutoClass.DBAccess
{
    /// <summary>
    /// 数据工厂
    /// </summary>
    public static class DBAccessFactory
    {
        /// <summary>
        /// 存储数据访问单利对象
        /// </summary>
        private static Dictionary<Type, IDBAccess> dicDBAccess;

        /// <summary>
        /// 数据连接字符串对象
        /// </summary>
        private static Dictionary<Type, ConfigModel> dicConfig;

        /// <summary>
        /// 创建数据对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IDBAccess CreateDBAccess<T>()
        {
            Init();
            if (typeof(T) == typeof(SqlServer))
            {
                if (!dicDBAccess.ContainsKey(typeof(SqlServer)))
                {
                    dicDBAccess.Add(typeof(SqlServer), new SqlServer(dicConfig[typeof(SqlServer)]));
                }
                return dicDBAccess[typeof(SqlServer)];
            }
            if (typeof(T) == typeof(MySQL))
            {
                if (!dicDBAccess.ContainsKey(typeof(MySQL)))
                {
                    dicDBAccess.Add(typeof(MySQL), new MySQL(dicConfig[typeof(MySQL)]));
                }
                return dicDBAccess[typeof(MySQL)];
            }
            return null;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private static void Init()
        {
            if (dicConfig == null)
            {
                /*
                 * 1.自定义配置文件
                 */
                dicConfig = new Dictionary<Type, ConfigModel>();
                var tmpDBAccess = ConfigurationManager.GetSection("DBAccess") as List<ConfigModel>;
                #region MyRegion
                foreach (var item in tmpDBAccess)
                {
                    if (!string.IsNullOrWhiteSpace(item.Type))
                    {
                        if (item.Type.Equals(typeof(SqlServer).ToString(), StringComparison.InvariantCultureIgnoreCase))
                            dicConfig.Add(typeof(SqlServer), item);
                        if (item.Type.Equals(typeof(MySQL).ToString(), StringComparison.InvariantCultureIgnoreCase))
                            dicConfig.Add(typeof(MySQL), item);
                    }
                }
                #endregion

            }
            if (dicDBAccess == null)
            {
                dicDBAccess = new Dictionary<Type, IDBAccess>();
            }
        }
    }
}
