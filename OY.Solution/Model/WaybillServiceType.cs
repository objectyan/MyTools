using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// WaybillServiceType Data Structure.
    /// </summary>
    [Serializable]
    public class WaybillServiceType 
    {
        /// <summary>
        /// 物流服务能力编码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 物流服务能力名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
