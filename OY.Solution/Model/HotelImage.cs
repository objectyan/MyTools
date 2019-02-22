using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// HotelImage Data Structure.
    /// </summary>
    [Serializable]
    public class HotelImage 
    {
        /// <summary>
        /// 酒店id
        /// </summary>
        [XmlElement("hid")]
        public long Hid { get; set; }

        /// <summary>
        /// 图片地址链接
        /// </summary>
        [XmlElement("pic")]
        public string Pic { get; set; }
    }
}
