using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// WlbPartnerContact Data Structure.
    /// </summary>
    [Serializable]
    public class WlbPartnerContact 
    {
        /// <summary>
        /// 仓库联系人姓名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }
    }
}
