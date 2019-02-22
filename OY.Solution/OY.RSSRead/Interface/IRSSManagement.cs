using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OY.RSSRead.Model;

namespace OY.RSSRead.Interface
{
    /// <summary>
    /// RSS 操作接口
    /// </summary>
    public interface IRSSManagement
    {
        /*
         * 读取RSS地址 
         * 操作RSS地址 
         * 解析RSS地址
         */
        /// <summary>
        /// 读取RSS地址
        /// </summary>
        /// <param name="IsList">是否返回单个还是集合</param>
        /// <returns>返回数据</returns>
        DataModel GetReadRSSAddress(bool IsList = false, int pageSize = 10, int pageIndex = 0);

        /// <summary>
        /// 操作RSS地址 —— 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        DataModel SetReadRSSAddressInsert(RSSAddress item);

        /// <summary>
        /// 操作RSS地址 —— 修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        DataModel SetReadRSSAddressUpdate(RSSAddress item);

        /// <summary>
        /// 操作RSS地址 —— 删除
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        DataModel SetReadRSSAddressDelete(RSSAddress item);

        /// <summary>
        /// 获取对应的RSS信息
        /// </summary>
        /// <param name="RSSAddress"></param>
        /// <returns></returns>
        DataModel GetReadRSSInfo(List<RSSAddress> itemInfo);
    }
}
