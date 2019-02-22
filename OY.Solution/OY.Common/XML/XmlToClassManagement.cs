using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OY.Common.XML
{
    /// <summary>
    /// xml 转 类文件
    /// </summary>
    public class XmlToClassManagement
    {
        public void XmlToClass(string xmlData)
        {
            try
            {

                /*
                 * 创建XML操作对象并加载xml数据
                 * 获取XML所以数据节点
                 * 判断节点下是否含有子节点如果含有创建新的文件操作 子节点
                 */
                //加载XML数据
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlData);
                //获取第一个节点信息
                XmlNode xmlNode_Root = xmlDoc.FirstChild;
                XmlNodeList xmlNodeRootChild = xmlNode_Root.ChildNodes;
                if (xmlNode_Root != null && xmlNodeRootChild.Count > 0)
                {
                    NodeDiGui(xmlNode_Root);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void NodeDiGui(XmlNode xmlNode)
        {
            string str_class = File.ReadAllText(@"E:\Documents\Object\Project\MyTools\OY.Solution\OY.Common\XML\Modle\ClassModle.txt");
            StringBuilder sb_private = new StringBuilder();
            StringBuilder sb_public = new StringBuilder();
            string className = xmlNode.Name;
            if (xmlNode.ParentNode.Name.IndexOf('#') < 0)
            {
                className = xmlNode.ParentNode.Name + xmlNode.Name;
            }
            str_class = str_class.Replace("{XmlRootName}", className);
            foreach (XmlNode item in xmlNode.ChildNodes)
            {
                //架构
                string str_Notes = "///<summary>\r\n /// {note} \r\n /// </summary> \r\n";
                string str_Private = " private {type} _{name};\r\n";
                string str_Function = "[XmlElement(\"{XmlElement}\")]\r\n public {type} {fun_name} \r\n { \r\n get \r\n { \r\n return _{name}; \r\n } \r\n set { \r\n _{name} = value; \r\n } \r\n}\r\n";
                //获取节点名称
                string nodeName = item.Name;
                string xmlEleName = nodeName;
                //获取其子节点
                XmlNodeList item_Child = item.ChildNodes;
                string type = "string";
                //保存子节点信息
                if (item_Child.Count > 0)
                {
                    XmlNode itemChidFirst = item_Child.Item(0);
                    if (!itemChidFirst.Name.Equals("#text"))
                    {
                        XmlNode item_Child_Child = itemChidFirst.ChildNodes.Item(0);
                        if (!item_Child_Child.Name.Equals("#text"))
                        {
                            type = string.Format("List<{0}>", strToStr(itemChidFirst.Name));
                            NodeDiGui(item);
                        }
                        else
                        {
                            xmlEleName = itemChidFirst.Name;
                            NodeDiGui(item);
                        }
                    }
                }
                sb_private.Append(str_Notes.Replace("{note}", item.InnerText));
                sb_private.Append(str_Private.Replace("{type}", type).Replace("{name}", nodeName));
                sb_public.Append(str_Notes.Replace("{note}", item.InnerText));
                sb_public.Append(str_Function.Replace("{name}", nodeName).Replace("{XmlElement}", xmlEleName).Replace("{type}", type).Replace("{fun_name}", strToStr(nodeName)));

            }
            str_class = str_class.Replace("{privateData}", sb_private.ToString());
            str_class = str_class.Replace("{publicData}", sb_public.ToString());
            string classPath = string.Format(@"E:\Class\{0}.cs", strToStr(className));
            using (StreamWriter sw = new StreamWriter(classPath))
            {
                sw.Write(str_class);
                sw.Close();
            }
        }

        private string strToStr(string str)
        {
            string str_data = string.Empty;
            if (str.IndexOf('_') >= 0)
            {
                foreach (var item in str.Split('_'))
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        str_data += item[0].ToString().ToUpper() + item.Substring(1);
                    }
                }
                return str_data;
            }
            str_data = str[0].ToString().ToUpper() + str.Substring(1);
            return str_data;
        }
    }
}
