using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// LoginLog Data Structure.
    /// </summary>
    [Serializable]
    public class LoginLog 
    {
        /// <summary>
        /// 用户登录或退出客户端的时间
        /// </summary>
        [XmlElement("time")]
        public string Time { get; set; }

        /// <summary>
        /// 标志用户登录或退出。 0表示登陆，1表示退出。
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
