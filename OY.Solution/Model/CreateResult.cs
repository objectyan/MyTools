using System;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// CreateResult Data Structure.
    /// </summary>
    [Serializable]
    public class CreateResult 
    {
        /// <summary>
        /// 宝贝id
        /// </summary>
        [XmlElement("result_data")]
        public string ResultData { get; set; }

        /// <summary>
        /// 业务提示信息
        /// </summary>
        [XmlElement("useful_msg")]
        public string UsefulMsg { get; set; }
    }
}
