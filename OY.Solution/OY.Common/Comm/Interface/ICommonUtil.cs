using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace OY.Common.Comm.Interface
{
    public interface ICommonUtil
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <param name="flag">是否含有特殊字符</param>
        /// <returns>生成的字符串</returns>
        string GetRandomString(int length, bool isContainTime = false, bool flag = false);

        /// <summary>
        /// 将List转为DataSet
        /// </summary>
        /// <typeparam name="T">List中的对象</typeparam>
        /// <param name="lo">数据</param>
        /// <param name="flag">是否按照特性序列号</param>
        /// <returns>转换后的DataSet</returns>
        DataSet ListToDataSet<T>(List<object> lo, bool flag = false);

        /// <summary>
        /// 生成数据脚本
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="flag">是否按照特性序列号</param>
        /// <param name="isSerialNumber">是否添加流水号</param>
        /// <returns>返回脚本数据</returns>
        string ClassToTable<T>(bool flag = false, bool isSerialNumber = false);
    }
}
