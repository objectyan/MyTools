using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// CertTxtInfo Data Structure.
    /// </summary>
    [Serializable]
    public class CertTxtInfo 
    {
        /// <summary>
        /// 认证类型的数值id
        /// </summary>
        [XmlElement("cert_type")]
        public long CertType { get; set; }

        /// <summary>
        /// 认证文本信息
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }
    }
}
