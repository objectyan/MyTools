using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// TmcGroup Data Structure.
    /// </summary>
    [Serializable]
    public class TmcGroup 
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 用户列表
        /// </summary>
        [XmlArray("users")]
        [XmlArrayItem("string")]
        public List<string> Users { get; set; }
    }
}
