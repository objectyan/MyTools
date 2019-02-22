using OY.Common.Comm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Top.Api.Domain;
using System.Text;
using OY.Common.Model;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace OY.TestProject
{


    /// <summary>
    ///这是 CommonUtilTest 的测试类，旨在
    ///包含所有 CommonUtilTest 单元测试
    ///</summary>
    [TestClass()]
    public class CommonUtilTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///ClassToTable 的测试
        ///</summary>
        public void ClassToTableTestHelper<T>()
        {
            CommonUtil target = new CommonUtil(); // TODO: 初始化为适当的值
            bool flag = false; // TODO: 初始化为适当的值
            bool isSerialNumber = false; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ClassToTable<T>(flag, isSerialNumber);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        [TestMethod()]
        public void ClassToTableTest()
        {
            Assembly assembly = Assembly.LoadFile(@"G:\Documents\OY\Project\MyTools\OY.Solution\Model\bin\Debug\Model.dll");
            Type[] types = assembly.GetTypes();
            string actual = string.Empty;
            string delete = string.Empty;
            foreach (Type item in types)
            {
                CommonUtil target = new CommonUtil(); // TODO: 初始化为适当的值
                bool flag = false; // TODO: 初始化为适当的值
                bool isSerialNumber = true; // TODO: 初始化为适当的值

                try
                {
                    string tableName = item.ToString();
                    if (!string.IsNullOrWhiteSpace(tableName) && tableName.LastIndexOf('.') > 0)
                    {
                        tableName = tableName.Substring(tableName.LastIndexOf('.') + 1);
                    }
                    else
                    {
                        tableName = "ClassName";
                    }
                    if (tableName.Equals("Location"))
                    {

                    }
                    StringBuilder sb = new StringBuilder("create table [" + tableName + "] (");
                    delete += "DROP TABLE [dbo].[" + tableName + "] \r\n";
                    if (isSerialNumber)
                    {
                        sb.Append(tableName + "SeqCode nvarchar(50) not null,");
                    }
                    //获取T下的所有可用属性 
                    PropertyInfo[] pi = item.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    //遍历所有属性
                    foreach (var item_pi in pi)
                    {
                        if (flag)
                        {
                            //按照特性序列号添加数据
                            object[] obj = item_pi.GetCustomAttributes(typeof(ClassTablePropertyAttribute), false);
                            foreach (ClassTablePropertyAttribute item_objet in obj)
                            {
                                if (item_objet.IsSerializable)
                                {
                                    sb.Append("[" + item_objet.PropertyTName + "] ");
                                    sb.Append(item_objet.DataType);
                                    if (item_objet.DataType.ToLower().Equals("nvarchar"))
                                    {
                                        sb.Append("(" + item_objet.Length + ") ");
                                    }
                                    if (item_objet.DataType.ToLower().Equals("decimal"))
                                    {
                                        sb.Append("(" + item_objet.Length + "," + item_objet.Precision + ") ");
                                    }
                                    if (item_objet.IsNull)
                                    {
                                        sb.Append("null ");
                                    }
                                    else
                                    {
                                        sb.Append("not null ");
                                    }
                                }
                            }
                        }
                        else
                        {
                            switch (item_pi.PropertyType.Name.ToLower())
                            {
                                case "int16":
                                    sb.Append("[" + item_pi.Name + "] int ");
                                    break;
                                case "int32":
                                    sb.Append("[" + item_pi.Name + "] int ");
                                    break;
                                case "int64":
                                    sb.Append("[" + item_pi.Name + "] decimal(20,0) ");
                                    break;
                                case "long":
                                    sb.Append("[" + item_pi.Name + "] decimal(20,0) ");
                                    break;
                                case "string":
                                    sb.Append("[" + item_pi.Name + "] nvarchar(1000) ");
                                    break;
                                case "boolean":
                                    sb.Append("[" + item_pi.Name + "] int ");
                                    break;
                                case "decimal":
                                    sb.Append("[" + item_pi.Name + "] decimal(20,2)  ");
                                    break;
                                case "datetime":
                                    sb.Append("[" + item_pi.Name + "] datetime  ");
                                    break;
                                case "double":
                                    sb.Append("[" + item_pi.Name + "] double  ");
                                    break;
                                case "float":
                                    sb.Append("[" + item_pi.Name + "] float  ");
                                    break;
                                default:
                                    sb.Append("[FK" + item_pi.Name + "Code] nvarchar(1000) ");
                                    break;
                            }
                        }
                        sb.Append(",");
                    }
                    string sbInfo = sb.ToString().Trim(',');
                    sb.Clear();
                    sb.Append(sbInfo);
                    sb.Append(string.Format(",[{0}Creator] nvarchar(1000) not null,[{0}CreateDate] datetime default(getdate()),[{0}Modifier] nvarchar(1000) not null,[{0}ModifyDate] datetime default(getdate()),[{0}IsUpdata] int default(0)", tableName));
                    sb.Append(")\r\n go");
                    /*
                     * if exists(select 1 from sys.extended_properties p where
                              p.major_id = object_id('dbo.UserCredit')
                          and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GoodNum')
                        )
                        begin
                           execute sp_dropextendedproperty 'MS_Description', 
                           'user', 'dbo', 'table', 'UserCredit', 'column', 'GoodNum'

                        end


                        execute sp_addextendedproperty 'MS_Description', 
                           '收到的好评总条数。取值范围:大于零的整数',
                           'user', 'dbo', 'table', 'UserCredit', 'column', 'GoodNum'
                        go
                     */
                    /*
                     * 0 表名
                     * 1 列名
                     * 2 说明
                     */
                    string desc = @" if exists(select 1 from sys.extended_properties p where
                              p.major_id = object_id('dbo.{0}')
                          and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = '{1}')
                        )
                        begin
                           execute sp_dropextendedproperty 'MS_Description', 
                           'user', 'dbo', 'table', '{0}', 'column', '{1}'

                        end


                        execute sp_addextendedproperty 'MS_Description', 
                           '{2}',
                           'user', 'dbo', 'table', '{0}', 'column', '{1}'
                        go ";
                    sb.Append("\r\n" + string.Format(desc, tableName, tableName + "Creator", "创建人"));
                    sb.Append("\r\n" + string.Format(desc, tableName, tableName + "CreateDate", "创建时间"));
                    sb.Append("\r\n" + string.Format(desc, tableName, tableName + "Modifier", "更新人"));
                    sb.Append("\r\n" + string.Format(desc, tableName, tableName + "ModifyDate", "更新时间"));
                    sb.Append("\r\n" + string.Format(desc, tableName, tableName + "IsUpdata", "是否更新"));

                    actual += sb.ToString() + "\r\n\r\n";
                }
                catch (Exception)
                {

                }
            }


            StreamWriter sw = new StreamWriter("G:\\sql.sql");
            sw.Write(delete + "\r\n" + actual);
            sw.Close();
        }

        /// <summary>
        ///ClassToTable 的测试
        ///</summary>
        public void ClassToTableTest1Helper<T>()
        {
            CommonUtil target = new CommonUtil(); // TODO: 初始化为适当的值
            bool flag = false; // TODO: 初始化为适当的值
            bool isSerialNumber = false; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ClassToTable<T>(flag, isSerialNumber);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        [TestMethod()]
        public void ClassToTableTest1()
        {

            OAuthData oad = new OAuthData();
            oad.AuthName = "AuthName";
            oad.OAuthConfig = new List<OAuthConfig>();
            oad.RedirectUrl = "RedirectUrl";
            oad.State = "State";
            oad.View = "View";
            OAuthConfig oac = new OAuthConfig();
            oac.AppKey = "AppKey";
            oac.AppSecret = "AppSecret";
            oac.AuthUrl = "AuthUrl";
            oac.Name = "Name";
            oac.TokenUrl = "TokenUrl";
            oad.OAuthConfig.Add(oac);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OAuthData));//字符串
            StreamWriter sw = new StreamWriter("E://SW.txt");
            xmlSerializer.Serialize(sw, oad);
            //ClassToTableTest1Helper<GenericParameterHelper>();
        }
    }


    #region XML
    /// <summary>
    /// 授权数据
    /// </summary>
    [Serializable]
    [XmlRootAttribute("OAuthData")]
    public class OAuthData
    {
        /*
        /// <summary>
        /// 是否沙箱测试
        /// </summary>
        private bool _isSandBox;

        /// <summary>
        /// 是否沙箱测试
        /// </summary>
        [XmlElementAttribute("IsSandBox")]
        public bool IsSandBox
        {
            get
            {
                return _isSandBox;
            }

            set
            {
                _isSandBox = value;
            }
        }
        */
        /// <summary>
        /// 回调地址
        /// </summary>
        private string _redirectUrl;

        /// <summary>
        /// 回调地址
        /// </summary>
        [XmlElementAttribute("RedirectUrl")]
        public string RedirectUrl
        {
            get
            {
                return _redirectUrl;
            }

            set
            {
                _redirectUrl = value;
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private string _state;

        /// <summary>
        /// 状态
        /// </summary>
        [XmlElementAttribute("State")]
        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        /// <summary>
        /// 视图状态
        /// </summary>
        private string view;

        /// <summary>
        /// 视图状态
        /// </summary>
        [XmlElementAttribute("View")]
        public string View
        {
            get
            {
                return view;
            }

            set
            {
                view = value;
            }
        }

        /// <summary>
        /// 授权服务名
        /// </summary>
        private string _authName;

        /// <summary>
        /// 授权服务名
        /// </summary>
        [XmlElementAttribute("AuthName")]
        public string AuthName
        {
            get
            {
                return _authName;
            }

            set
            {
                _authName = value;
            }
        }

        /// <summary>
        /// 集合配置
        /// </summary>
        private List<OAuthConfig> _oAuthConfig;

        /// <summary>
        /// 集合配置
        /// </summary>
        [XmlElementAttribute("OAuthConfig")]
        public List<OAuthConfig> OAuthConfig
        {
            get
            {
                return _oAuthConfig;
            }

            set
            {
                _oAuthConfig = value;
            }
        }

    }

    /// <summary>
    /// 授权详细数据
    /// </summary>
    [Serializable]
    public class OAuthConfig
    {
        /// <summary>
        /// 授权服务名称
        /// </summary>
        private string _name;
        /// <summary>
        /// AppKey
        /// </summary>
        private string _appKey;
        /// <summary>
        /// AppSecret
        /// </summary>
        private string _appSecret;
        /// <summary>
        /// 授权地址
        /// </summary>
        private string _authUrl;

        /// <summary>
        /// 令牌获取地址
        /// </summary>
        private string _tokenUrl;

        /// <summary>
        /// 授权服务名称
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// AppKey
        /// </summary>
        [XmlElementAttribute("AppKey")]
        public string AppKey
        {
            get
            {
                return _appKey;
            }

            set
            {
                _appKey = value;
            }
        }

        /// <summary>
        /// AppSecret
        /// </summary>
        [XmlElementAttribute("AppSecret")]
        public string AppSecret
        {
            get
            {
                return _appSecret;
            }

            set
            {
                _appSecret = value;
            }
        }

        /// <summary>
        /// 授权地址
        /// </summary>
        [XmlElementAttribute("AuthUrl")]
        public string AuthUrl
        {
            get
            {
                return _authUrl;
            }

            set
            {
                _authUrl = value;
            }
        }

        /// <summary>
        /// 令牌获取地址
        /// </summary>
        [XmlElementAttribute("TokenUrl")]
        public string TokenUrl
        {
            get { return _tokenUrl; }
            set { _tokenUrl = value; }
        }
    }
    #endregion
}
