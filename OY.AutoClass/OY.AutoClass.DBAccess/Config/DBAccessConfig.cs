using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using OY.AutoClass.DBAccess.Model;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace OY.AutoClass.DBAccess.Config
{
    public class DBAccessConfig : IConfigurationSectionHandler
    {
        /// <summary>
        /// 创建了配置节处理程序
        /// </summary>
        /// <param name="parent">父对象</param>
        /// <param name="configContext">配置上下文对象</param>
        /// <param name="section">XML 节点对象</param>
        /// <returns>创建节处理程序对象</returns>
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            var config = new List<ConfigModel>();
            XmlNodeList xmlNodeConnection = section.SelectNodes("Connection");
            if (xmlNodeConnection != null)
            {
                foreach (XmlNode item in xmlNodeConnection)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ConfigModel));
                    StringReader sr = new StringReader(item.OuterXml);
                    ConfigModel configModel = serializer.Deserialize(sr) as ConfigModel;
                    config.Add(configModel);
                }
            }
            return config;
        }
    }
}
