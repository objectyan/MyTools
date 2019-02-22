using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Feature Data Structure.
    /// </summary>
    [Serializable]
    public class Feature 
    {
        /// <summary>
        /// 属性键
        /// </summary>
        [XmlElement("attr_key")]
        public string AttrKey { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        [XmlElement("attr_value")]
        public string AttrValue { get; set; }
    }
}
