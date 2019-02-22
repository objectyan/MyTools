using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OY.RSSRead.Model
{
    /// <summary>
    /// RSS 模型结构
    /// </summary>
    public class RSSModel
    {
        /// <summary>
        /// RSS <channel> 元素
        /// </summary>
        private channel _channel;

        /// <summary>
        /// RSS <channel> 元素
        /// </summary>
        public channel channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        /// <summary>
        /// RSS <item> 元素
        /// </summary>
        private item _item;

        /// <summary>
        /// RSS <item> 元素
        /// </summary>
        public item item
        {
            get { return _item; }
            set { _item = value; }
        }
    }

    /// <summary>
    /// RSS <channel> 元素
    /// </summary>
    public class channel
    {
        /// <summary>
        /// 可选的。为 feed 定义所属的一个或多个种类。
        /// </summary>
        private string _category;

        /// <summary>
        /// 可选的。为 feed 定义所属的一个或多个种类。
        /// </summary>
        public string category
        {
            get { return _category; }
            set { _category = value; }
        }

        /// <summary>
        /// 可选的。注册进程，以获得 feed 更新的立即通知。
        /// </summary>
        private string _cloud;

        /// <summary>
        /// 可选的。注册进程，以获得 feed 更新的立即通知。
        /// </summary>
        public string cloud
        {
            get { return _cloud; }
            set { _cloud = value; }
        }

        /// <summary>
        /// 可选。告知版权资料。
        /// </summary>
        private string _copyright;

        /// <summary>
        /// 可选。告知版权资料。
        /// </summary>
        public string copyright
        {
            get { return _copyright; }
            set { _copyright = value; }
        }

        /// <summary>
        /// 必需的。描述频道。
        /// </summary>
        private string _description;

        /// <summary>
        /// 必需的。描述频道。
        /// </summary>
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// 可选的。规定指向当前 RSS 文件所用格式说明的 URL。
        /// </summary>
        private string _docs;

        /// <summary>
        /// 可选的。规定指向当前 RSS 文件所用格式说明的 URL。
        /// </summary>
        public string docs
        {
            get { return _docs; }
            set { _docs = value; }
        }

        /// <summary>
        /// 可选的。规定用于生成 feed 的程序。
        /// </summary>
        private string _generator;

        /// <summary>
        /// 可选的。规定用于生成 feed 的程序。
        /// </summary>
        public string generator
        {
            get { return _generator; }
            set { _generator = value; }
        }

        /// <summary>
        /// 可选的。在聚合器呈现某个 feed 时，显示一个图像。
        /// </summary>
        private string _image;

        /// <summary>
        /// 可选的。在聚合器呈现某个 feed 时，显示一个图像。
        /// </summary>
        public string image
        {
            get { return _image; }
            set { _image = value; }
        }

        /// <summary>
        /// 可选的。规定编写 feed 所用的语言。
        /// </summary>
        private string _language;

        /// <summary>
        /// 可选的。规定编写 feed 所用的语言。
        /// </summary>
        public string language
        {
            get { return _language; }
            set { _language = value; }
        }

        /// <summary>
        /// 可选的。定义 feed 内容的最后修改日期。
        /// </summary>
        private string _lastBuildDate;

        /// <summary>
        /// 可选的。定义 feed 内容的最后修改日期。
        /// </summary>
        public string lastBuildDate
        {
            get { return _lastBuildDate; }
            set { _lastBuildDate = value; }
        }

        /// <summary>
        /// 必需的。定义指向频道的超链接。
        /// </summary>
        private string _link;

        /// <summary>
        /// 必需的。定义指向频道的超链接。
        /// </summary>
        public string link
        {
            get { return _link; }
            set { _link = value; }
        }

        /// <summary>
        /// 可选的。定义 feed 内容编辑的电子邮件地址。
        /// </summary>
        private string _managingEditor;

        /// <summary>
        /// 可选的。定义 feed 内容编辑的电子邮件地址。
        /// </summary>
        public string managingEditor
        {
            get { return _managingEditor; }
            set { _managingEditor = value; }
        }

        /// <summary>
        /// 可选的。为 feed 的内容定义最后发布日期。
        /// </summary>
        private string _pubDate;

        /// <summary>
        /// 可选的。为 feed 的内容定义最后发布日期。
        /// </summary>
        public string pubDate
        {
            get { return _pubDate; }
            set { _pubDate = value; }
        }

        /// <summary>
        /// 可选的。feed 的 PICS 级别。
        /// </summary>
        private string _rating;

        /// <summary>
        /// 可选的。feed 的 PICS 级别。
        /// </summary>
        public string rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        /// <summary>
        /// 可选的。规定忽略 feed 更新的天。
        /// </summary>
        private string _skipDays;

        /// <summary>
        /// 可选的。规定忽略 feed 更新的天。
        /// </summary>
        public string skipDays
        {
            get { return _skipDays; }
            set { _skipDays = value; }
        }

        /// <summary>
        /// 可选的。规定忽略 feed 更新的小时。
        /// </summary>
        private string _skipHours;

        /// <summary>
        /// 可选的。规定忽略 feed 更新的小时。
        /// </summary>
        public string skipHours
        {
            get { return _skipHours; }
            set { _skipHours = value; }
        }

        /// <summary>
        /// 可选的。规定应当与 feed 一同显示的文本输入域。
        /// </summary>
        private string _textInput;

        /// <summary>
        /// 可选的。规定应当与 feed 一同显示的文本输入域。
        /// </summary>
        public string textInput
        {
            get { return _textInput; }
            set { _textInput = value; }
        }

        /// <summary>
        /// 必需的。定义频道的标题。
        /// </summary>
        private string _title;

        /// <summary>
        /// 必需的。定义频道的标题。
        /// </summary>
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// 可选的。指定从 feed 源更新此 feed 之前，feed 可被缓存的分钟数。
        /// </summary>
        private string _ttl;

        /// <summary>
        /// 可选的。指定从 feed 源更新此 feed 之前，feed 可被缓存的分钟数。
        /// </summary>
        public string ttl
        {
            get { return _ttl; }
            set { _ttl = value; }
        }

        /// <summary>
        /// 可选的。定义此 feed 的 web 管理员的电子邮件地址。
        /// </summary>
        private string _webMaster;

        /// <summary>
        /// 可选的。定义此 feed 的 web 管理员的电子邮件地址。
        /// </summary>
        public string webMaster
        {
            get { return _webMaster; }
            set { _webMaster = value; }
        }
    }

    /// <summary>
    /// RSS <item> 元素
    /// </summary>
    public class item
    {
        /// <summary>
        /// 可选的。规定项目作者的电子邮件地址。
        /// </summary>
        private string _author;

        /// <summary>
        /// 可选的。规定项目作者的电子邮件地址。
        /// </summary>
        public string author
        {
            get { return _author; }
            set { _author = value; }
        }

        /// <summary>
        /// 可选的。定义项目所属的一个或多个类别。
        /// </summary>
        private string _category;

        /// <summary>
        /// 可选的。定义项目所属的一个或多个类别。
        /// </summary>
        public string category
        {
            get { return _category; }
            set { _category = value; }
        }

        /// <summary>
        /// 可选的。允许项目连接到有关此项目的注释（文件）。
        /// </summary>
        private string _comments;

        /// <summary>
        /// 可选的。允许项目连接到有关此项目的注释（文件）。
        /// </summary>
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        /// <summary>
        /// 必需的。描述此项目。
        /// </summary>
        private string _description;

        /// <summary>
        /// 必需的。描述此项目。
        /// </summary>
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// 可选的。允许将一个媒体文件导入一个项中。
        /// </summary>
        private string _enclosure;

        /// <summary>
        /// 可选的。允许将一个媒体文件导入一个项中。
        /// </summary>
        public string enclosure
        {
            get { return _enclosure; }
            set { _enclosure = value; }
        }

        /// <summary>
        /// 可选的。为项目定义一个唯一的标识符。
        /// </summary>
        private string _guid;

        /// <summary>
        /// 可选的。为项目定义一个唯一的标识符。
        /// </summary>
        public string guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        /// <summary>
        /// 必需的。定义指向此项目的超链接。
        /// </summary>
        private string _link;

        /// <summary>
        /// 必需的。定义指向此项目的超链接。
        /// </summary>
        public string link
        {
            get { return _link; }
            set { _link = value; }
        }

        /// <summary>
        /// 可选的。定义此项目的最后发布日期。
        /// </summary>
        private string _pubDate;

        /// <summary>
        /// 可选的。定义此项目的最后发布日期。
        /// </summary>
        public string pubDate
        {
            get { return _pubDate; }
            set { _pubDate = value; }
        }

        /// <summary>
        /// 可选的。为此项目指定一个第三方来源。
        /// </summary>
        private string _source;

        /// <summary>
        /// 可选的。为此项目指定一个第三方来源。
        /// </summary>
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        /// <summary>
        /// 必需的。定义此项目的标题。
        /// </summary>
        private string _title;

        /// <summary>
        /// 必需的。定义此项目的标题。
        /// </summary>
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
