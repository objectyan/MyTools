using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OY.Common.Comm.Interface;
using System.Data;
using System.Reflection;
using OY.Common.Model;
using System.Net;
using System.IO;

namespace OY.Common.Comm
{
    public class CommonUtil : ICommonUtil
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <param name="flag">是否含有特殊字符</param>
        /// <returns>生成的字符串</returns>
        public string GetRandomString(int length, bool isContainTime = false, bool flag = false)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (isContainTime && length > 14)
                {
                    sb.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    length = length - 14;
                }
                Random rd = new Random(Convert.ToInt32(Math.Pow(DateTime.Now.Millisecond, 3)));
                for (int i = 0; i < length; i++)
                {
                    int num = rd.Next(1, 254);
                    char c_str = (char)num;
                    if (!flag)
                    {
                        if (num == 33 || (num >= 35 && num <= 38) || num == 43 || num == 45 || (num >= 48 && num <= 57) || (num >= 64 && num <= 91) || num == 93 || num == 95 || (num <= 97 && num >= 126))
                        {
                            sb.Append(c_str);
                        }
                        else
                        {
                            i--;
                        }
                    }
                    else
                    {
                        sb.Append(c_str);
                    }
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 将List转为DataSet
        /// </summary>
        /// <typeparam name="T">List中的对象</typeparam>
        /// <param name="lo">数据</param>
        /// <param name="flag">是否按照特性序列号</param>
        /// <returns>转换后的DataSet</returns>
        public DataSet ListToDataSet<T>(List<object> lo, bool flag = false)
        {
            try
            {
                //数据表
                DataSet ds = new DataSet();
                //获取T下的所有可用属性 
                PropertyInfo[] pi = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                //设置表名称
                string tableName = typeof(T).ToString();
                if (!string.IsNullOrWhiteSpace(tableName) && tableName.LastIndexOf('.') > 0)
                {
                    tableName = tableName.Substring(tableName.LastIndexOf('.') + 1);
                }
                else
                {
                    tableName = "ClassName";
                }
                DataTable dt = new DataTable(tableName);
                //创建表头并填充数据
                foreach (var item in lo)
                {
                    //创建数据行
                    DataRow dr = dt.NewRow();
                    //遍历所有属性
                    foreach (var item_pi in pi)
                    {
                        //按照特性序列号添加数据
                        if (flag)
                        {
                            object[] obj = item_pi.GetCustomAttributes(typeof(ClassPropertyInfoAttribute), false);
                            foreach (ClassPropertyInfoAttribute item_objet in obj)
                            {
                                if (item_objet.IsSerializable)
                                {
                                    DataColumn dc = new DataColumn(item_pi.Name);
                                    dc.Caption = item_objet.PropertyName;
                                    if (dt.Columns.IndexOf(item_pi.Name) < 0)
                                    {
                                        dt.Columns.Add(dc);
                                        dc.Dispose();
                                    }
                                    Type type = item.GetType();
                                    PropertyInfo pi_item = type.GetProperty(item_pi.Name);
                                    if (pi_item == null)
                                    {
                                        dr[item_pi.Name] = string.Empty;
                                    }
                                    else
                                    {
                                        dr[item_pi.Name] = pi_item.GetValue(item, null);
                                    }
                                }
                            }
                        }
                        else
                        {
                            DataColumn dc = new DataColumn(item_pi.Name);
                            dc.Caption = item_pi.Name;
                            if (dt.Columns.IndexOf(item_pi.Name) < 0)
                            {
                                dt.Columns.Add(dc);
                                dc.Dispose();
                            }
                            Type type = item.GetType();
                            PropertyInfo pi_item = type.GetProperty(item_pi.Name);
                            if (pi_item == null)
                            {
                                dr[item_pi.Name] = string.Empty;
                            }
                            else
                            {
                                dr[item_pi.Name] = pi_item.GetValue(item, null);
                            }
                        }
                    }
                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 生成数据脚本
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="flag">是否按照特性序列号</param>
        /// <param name="isSerialNumber">是否添加流水号</param>
        /// <returns>返回脚本数据</returns>
        public string ClassToTable<T>(bool flag = false, bool isSerialNumber = false)
        {
            try
            {
                string tableName = typeof(T).ToString();
                if (!string.IsNullOrWhiteSpace(tableName) && tableName.LastIndexOf('.') > 0)
                {
                    tableName = tableName.Substring(tableName.LastIndexOf('.') + 1);
                }
                else
                {
                    tableName = "ClassName";
                }
                StringBuilder sb = new StringBuilder("create table [" + tableName + "] (");

                if (isSerialNumber)
                {
                    sb.Append(tableName + "SeqCode nvarchar(50) not null,");
                }
                //获取T下的所有可用属性 
                PropertyInfo[] pi = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
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
                sb.Append(",[Creator] nvarchar(1000) not null,[CreateDate] datetime default(getdate()),[Modifier] nvarchar(1000) not null,[ModifyDate] datetime default(getdate()),[IsUpdata] int default(0)");
                sb.Append(")");
                return sb.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// HttpRequest 请求方式
        /// </summary>
        /// <param name="webUrl">请求地址</param>
        /// <param name="contentType">请求Context-Type</param>
        /// <param name="dicPara">请求参数</param>
        /// <param name="method">请求方式</param>
        /// <returns>返回请求结果</returns>
        public string RequestWeb(string webUrl, string contentType, Dictionary<string, string> dicPara = null, string method = "POST")
        {
            try
            {
                //创建一个请求项
                /*
                    * url http://localhost:55563/WMSService.asmx/WMSPushService
                    * url 分为两段
                    * 第一段 webServices 发布地址        eg:http://localhost:55563/WMSService.asmx
                    * 第二段 将调用webServices的函数名   eg:WMSPushService
                    */
                HttpWebRequest request = WebRequest.Create(webUrl) as HttpWebRequest;
                //判断服务器是否处理POST的数据
                request.ServicePoint.Expect100Continue = method.ToUpper().Equals("POST");
                //请求方式
                request.Method = method.ToUpper();
                //是否建立持久性链接
                request.KeepAlive = true;
                //设置HTTP头
                request.UserAgent = "object.yan";
                //设置超时时间
                request.Timeout = Int32.MaxValue;
                //设置请求标题头
                request.ContentType = contentType;
                if (dicPara != null)
                {
                    //参数经过URL编码 
                    /*
                        * webService 请求函数中 所包含的参数 必须在paraUrlCoded中进行拼接
                        *  【且将参数与值进行URL字符串加密】
                        *  否则将返回 服务器 500 错误
                        */
                    StringBuilder sbPara = new StringBuilder();
                    /*
                        * 循环加载参数信息
                        */
                    foreach (var item in dicPara)
                    {
                        if (!string.IsNullOrWhiteSpace(sbPara.ToString()))
                        {
                            sbPara.Append("&");
                        }
                        sbPara.Append(System.Web.HttpUtility.UrlEncode(item.Key));
                        sbPara.Append("=" + System.Web.HttpUtility.UrlEncode(item.Value));
                    }
                    /*
                     * 将字符串参数转为二进制数组
                     * 将其写入请求流中
                     */
                    byte[] paraByte;
                    //将URL编码后的字符串转化为字节
                    paraByte = System.Text.Encoding.UTF8.GetBytes(sbPara.ToString());
                    //设置请求的ContentLength
                    request.ContentLength = paraByte.Length;
                    //获得请求流
                    Stream writer = request.GetRequestStream();
                    //将请求参数写入流
                    writer.Write(paraByte, 0, paraByte.Length);
                    //关闭请求流
                    writer.Close();
                }
                /*
                 * 获取webServices返回信息
                 */
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //读取资源流信息
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet));
                //获取html文本
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                return ex.StackTrace + Environment.NewLine + ex.Message;
            }
        }
    }
}
