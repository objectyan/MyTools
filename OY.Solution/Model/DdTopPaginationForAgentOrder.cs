using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// DdTopPaginationForAgentOrder Data Structure.
    /// </summary>
    [Serializable]
    public class DdTopPaginationForAgentOrder 
    {
        /// <summary>
        /// 代送商订单列表
        /// </summary>
        [XmlArray("list")]
        [XmlArrayItem("top_delivery_agent_order_v_o")]
        public List<TopDeliveryAgentOrderVO> List { get; set; }

        /// <summary>
        /// 翻页游码
        /// </summary>
        [XmlElement("page_num")]
        public long PageNum { get; set; }

        /// <summary>
        /// 页面大小
        /// </summary>
        [XmlElement("page_size")]
        public long PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

        /// <summary>
        /// 可返回的记录数
        /// </summary>
        [XmlElement("view_count")]
        public long ViewCount { get; set; }
    }
}
