using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// StreamWeight Data Structure.
    /// </summary>
    [Serializable]
    public class StreamWeight 
    {
        /// <summary>
        /// 账号
        /// </summary>
        [XmlElement("user")]
        public string User { get; set; }

        /// <summary>
        /// 账号对应的权重
        /// </summary>
        [XmlElement("weight")]
        public long Weight { get; set; }
    }
}
