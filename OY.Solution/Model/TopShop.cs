using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// TopShop Data Structure.
    /// </summary>
    [Serializable]
    public class TopShop 
    {
        /// <summary>
        /// 外卖店铺id
        /// </summary>
        [XmlElement("shopid")]
        public long Shopid { get; set; }

        /// <summary>
        /// 外卖店铺名称
        /// </summary>
        [XmlElement("shopname")]
        public string Shopname { get; set; }
    }
}
