using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// LogisticsTag Data Structure.
    /// </summary>
    [Serializable]
    public class LogisticsTag 
    {
        /// <summary>
        /// 服务标签
        /// </summary>
        [XmlArray("logistic_service_tag_list")]
        [XmlArrayItem("logistic_service_tag")]
        public List<LogisticServiceTag> LogisticServiceTagList { get; set; }

        /// <summary>
        /// 主订单或子订单的订单号
        /// </summary>
        [XmlElement("order_id")]
        public string OrderId { get; set; }
    }
}
