using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OY.RSSRead.Model
{
    /// <summary>
    /// 本地临时RSS数据
    /// </summary>
    [Serializable]
    [XmlRootAttribute("RSSAddresses")]
    public class RSSAddresses
    {
        /// <summary>
        /// RSS 地址数据
        /// </summary>
        private List<RSSAddress> _RSSAddress;
        /// <summary>
        /// RSS 地址数据
        /// </summary>
        [XmlElementAttribute("RSSAddress")]
        public List<RSSAddress> RSSAddress
        {
            get { return _RSSAddress; }
            set { _RSSAddress = value; }
        }
    }

    /// <summary>
    /// RSS 地址数据
    /// </summary>
    [Serializable]
    public class RSSAddress
    {
        /// <summary>
        /// RSS 类型
        /// </summary>
        private string _type;

        /// <summary>
        /// RSS 类型
        /// </summary>
        [XmlAttribute("Type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// RSS 编号
        /// </summary>
        private string _no;

        /// <summary>
        /// RSS 编号
        /// </summary>
        [XmlElementAttribute("No")]
        public string No
        {
            get { return _no; }
            set { _no = value; }
        }

        /// <summary>
        /// RSS 名称
        /// </summary>
        private string _name;

        /// <summary>
        /// RSS 名称
        /// </summary>
        [XmlElementAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// RSS 地址
        /// </summary>
        private string _url;

        /// <summary>
        /// RSS 地址
        /// </summary>
        [XmlElementAttribute("Url")]
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
    }
}
