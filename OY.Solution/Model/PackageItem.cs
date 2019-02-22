using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// PackageItem Data Structure.
    /// </summary>
    [Serializable]
    public class PackageItem 
    {
        /// <summary>
        /// 商品数量
        /// </summary>
        [XmlElement("count")]
        public long Count { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }
    }
}
