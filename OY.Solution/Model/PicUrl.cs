using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// PicUrl Data Structure.
    /// </summary>
    [Serializable]
    public class PicUrl 
    {
        /// <summary>
        /// 图片链接地址
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
