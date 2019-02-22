using System;
using System.Xml.Serialization;
using System.Linq;

namespace OY.AutoClass.DBAccess.Model
{
    [XmlRoot("Connection")]
    public class ConfigModel
    {
        /// <summary>
        /// 链接类型
        /// </summary>
        private string type;
        /// <summary>
        /// 链接类型
        /// </summary>
        [XmlAttribute("type")]
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) type = value;
                var tmp = from chr in value.ToCharArray() where !char.IsControl(chr) && !char.IsWhiteSpace(chr) select chr;
                type = new string(tmp.ToArray());
            }
        }
        /// <summary>
        /// 服务地址
        /// </summary>
        private string server;
        /// <summary>
        /// 服务地址
        /// </summary>
        [XmlAttribute("server")]
        public string Server
        {
            get { return server; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) server = value;
                var tmp = from chr in value.ToCharArray() where !char.IsControl(chr) && !char.IsWhiteSpace(chr) select chr;
                server = new string(tmp.ToArray());
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        private string user;
        /// <summary>
        /// 用户名
        /// </summary>
        [XmlAttribute("user")]
        public string User
        {
            get { return user; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) user = value;
                var tmp = from chr in value.ToCharArray() where !char.IsControl(chr) && !char.IsWhiteSpace(chr) select chr;
                user = new string(tmp.ToArray());
            }
        }
        /// <summary>
        /// 密码
        /// </summary>
        private string password;
        /// <summary>
        /// 密码
        /// </summary>
        [XmlAttribute("password")]
        public string Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) password = value;
                var tmp = from chr in value.ToCharArray() where !char.IsControl(chr) && !char.IsWhiteSpace(chr) select chr;
                password = new string(tmp.ToArray());
            }
        }
        /// <summary>
        /// 数据库
        /// </summary>
        private string database;
        /// <summary>
        /// 数据库
        /// </summary>
        [XmlAttribute("database")]
        public string Database
        {
            get { return database; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) database = value;
                var tmp = from chr in value.ToCharArray() where !char.IsControl(chr) && !char.IsWhiteSpace(chr) select chr;
                database = new string(tmp.ToArray());
            }
        }
    }
}
