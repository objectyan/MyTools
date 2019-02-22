using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// ReplyStatById Data Structure.
    /// </summary>
    [Serializable]
    public class ReplyStatById 
    {
        /// <summary>
        /// 客服回复数
        /// </summary>
        [XmlElement("reply_num")]
        public long ReplyNum { get; set; }

        /// <summary>
        /// 客服ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
