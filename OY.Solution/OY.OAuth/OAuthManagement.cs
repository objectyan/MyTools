using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OY.OAuth.Interface;
using System.Xml.Serialization;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace OY.OAuth
{
    public class OAuthManagement<T> : IOAuth<T>
    {
        protected Model.TranProto<Model.OAuthData<T>> tp_Data = null;

        /// <summary>
        /// 默认初始化  将使用XML数据
        /// </summary>
        public OAuthManagement()
        {
            tp_Data = AnalyXML();
        }

        /// <summary>
        /// 初始化信息 使用自定义信息
        /// </summary>
        /// <param name="tpOAuthData">自定义授权所需信息</param>
        public OAuthManagement(Model.TranProto<Model.OAuthData<T>> tpOAuthData)
        {
            tp_Data = tpOAuthData;
        }

        /// <summary>
        /// 解析XML
        /// </summary>
        /// <returns>
        /// 数据类型为 Model.OAuthData
        /// </returns>
        public Model.TranProto<Model.OAuthData<T>> AnalyXML()
        {
            Model.TranProto<Model.OAuthData<T>> tp = new Model.TranProto<Model.OAuthData<T>>();
            tp.IsError = false;
            try
            {
                string path = ConfigurationManager.AppSettings["OAuthXMLConfig"];
                if (string.IsNullOrWhiteSpace(path))
                {
                    tp.IsError = true;
                    tp.Msg = "请配置AuthXML文件路径";
                    return tp;
                }
                //获取更目录地址
                string dir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                path = dir + path;
                //实例化序列化对象
                XmlSerializer xmlserializer = new XmlSerializer(typeof(Model.OAuthData<T>));
                //读取文件
                using (FileStream fileStrem = new FileStream(path, FileMode.Open))
                {
                    //返回序列化对象
                    tp.Data = xmlserializer.Deserialize(fileStrem) as Model.OAuthData<T>;
                }
                //返回结果
                return tp;
            }
            catch (Exception ex)
            {
                tp.IsError = true;
                tp.Msg = ex.StackTrace + System.Environment.NewLine + ex.Message;
                return tp;
            }
        }

        /// <summary>
        /// 获取对应授权信息
        /// </summary>
        /// <returns>数据类型为 Model.OAuthConfig</returns>
        public Model.TranProto<Model.OAuthConfig> GetAuthInfo(string oAuthName = "")
        {
            Model.TranProto<Model.OAuthConfig> tp = new Model.TranProto<Model.OAuthConfig>();
            tp.IsError = false;
            try
            {
                //获取解析XML值
                //Model.TranProto<Model.OAuthData> tp_Data = AnalyXML();
                //判断是否解析
                if (tp_Data.IsError || tp_Data.Data == null)
                {
                    tp.IsError = true;
                    tp.Msg = tp_Data.Msg;
                    return tp;
                }
                else
                {
                    //转换对象
                    Model.OAuthData<T> oAuthData = tp_Data.Data;

                    /*
                     判断 oAuthData.OAuthConfig 的数据类型
                     */

                    //获取配置对象
                    Model.OAuthConfig oAuthConfigItem = null;

                    if (oAuthData.OAuthConfig is List<Model.OAuthConfig>)
                    {
                        //获取数据集合
                        List<Model.OAuthConfig> oAuthConfig = oAuthData.OAuthConfig as List<Model.OAuthConfig>;
                        //判断授权名称
                        if (string.IsNullOrWhiteSpace(oAuthName))
                        {
                            oAuthName = oAuthData.AuthName;
                        }

                        //判断是否含有对应配置信息 且只有唯一一个配置
                        if (oAuthConfig != null && oAuthConfig.Count > 0 && oAuthConfig.Where(x => x.Name.Equals(oAuthName)).Count() > 0
                            && oAuthConfig.Where(x => x.Name.Equals(oAuthName)).Count() == 1)
                        {
                            oAuthConfigItem = oAuthConfig.Where(x => x.Name.Equals(oAuthName)).ToList()[0];
                        }
                        else
                        {
                            tp.IsError = true;
                            tp.Msg = "配置文件错误";
                            return tp;
                        }
                    }
                    else
                    {
                        oAuthConfigItem = oAuthData.OAuthConfig as Model.OAuthConfig;
                    }
                    //授权地址拼接字符
                    string codeUrl = string.Empty;
                    //令牌拼接地址
                    string tokenUrl = string.Empty;
                    //令牌登出地址
                    string logOffUrl = string.Empty;
                    //令牌刷新地址
                    string refreshUrl = string.Empty;

                    //拼接网站
                    codeUrl += oAuthConfigItem.AuthUrl + "?";
                    //获取token网址
                    tokenUrl += oAuthConfigItem.TokenUrl + "?";
                    //获取令牌登出地址
                    logOffUrl += oAuthConfigItem.LogOffUrl + "?";
                    //获取令牌刷新地址
                    refreshUrl += oAuthConfigItem.TokenUrl + "?";

                    //添加client_id (AppKey)
                    codeUrl += "client_id=" + oAuthConfigItem.AppKey + "&";
                    tokenUrl += "client_id=" + oAuthConfigItem.AppKey + "&";
                    logOffUrl += "client_id=" + oAuthConfigItem.AppKey + "&";
                    refreshUrl += "client_id=" + oAuthConfigItem.AppKey + "&";

                    //添加client_secret
                    tokenUrl += "client_secret=" + oAuthConfigItem.AppSecret + "&";
                    refreshUrl += "client_secret=" + oAuthConfigItem.AppSecret + "&";

                    //添加grant_type
                    tokenUrl += "grant_type=authorization_code&";
                    refreshUrl += "grant_type=refresh_token&";

                    //添加response_type (默认值code)
                    codeUrl += "response_type=code&";

                    //添加redirect_uri (回掉地址)
                    codeUrl += "redirect_uri=" + oAuthData.RedirectUrl + "&";
                    tokenUrl += "redirect_uri=" + oAuthData.RedirectUrl + "&";

                    //添加state (状态)
                    codeUrl += "state=" + oAuthData.State + "&";
                    tokenUrl += "state=" + oAuthData.State + "&";
                    refreshUrl += "state=" + oAuthData.State + "&";

                    //添加view (显示方式 默认web)
                    codeUrl += "view=" + oAuthData.View;
                    tokenUrl += "view=" + oAuthData.View + "&";
                    logOffUrl += "view=" + oAuthData.View;

                    //添加code
                    tokenUrl += "code=";

                    //添加刷新令牌
                    refreshUrl += "refresh_token=";

                    //实例化系统配置
                    Model.OAuthConfig oac = new Model.OAuthConfig();
                    //对象共享
                    oac = oAuthConfigItem;
                    //授权地址
                    oac.AuthUrl = codeUrl;
                    //令牌获取地址
                    oac.TokenUrl = tokenUrl;
                    //令牌刷新地址
                    oac.RefreshUrl = refreshUrl;
                    //令牌登出
                    oac.LogOffUrl = logOffUrl;
                    //返回数据
                    tp.Data = oac;

                }
                return tp;
            }
            catch (Exception ex)
            {
                tp.IsError = true;
                tp.Msg = ex.StackTrace + System.Environment.NewLine + ex.Message;
                return tp;
            }
        }

        /// <summary>
        /// 获取授权地址
        /// </summary>
        /// <returns>
        /// 数据类型为 string
        /// </returns>
        public Model.TranProto<string> GetAuthAddress(string oAuthName = "")
        {
            Model.TranProto<string> tp = new Model.TranProto<string>();
            tp.IsError = false;
            try
            {
                Model.TranProto<Model.OAuthConfig> tpData = GetAuthInfo(oAuthName);
                if (tpData != null && tpData.Data != null)
                {
                    tp.Data = tpData.Data.AuthUrl;
                }
                return tp;
            }
            catch (Exception ex)
            {
                tp.IsError = true;
                tp.Msg = ex.StackTrace + System.Environment.NewLine + ex.Message;
                return tp;
            }
        }

        /// <summary>
        /// 获取授权信息
        /// </summary>
        /// <param name="code">code值</param>
        /// <param name="tokenUrl">请求地址</param>
        /// <param name="method">请求方式</param>
        /// <param name="IsGetToken">是否获取令牌</param>
        /// <returns>数据类型为 Model.OAuthInfo</returns>
        public Model.TranProto<Model.OAuthInfo> GetTokenCode(string code, string method, bool IsGetToken = true, string oAuthName = "")
        {
            Model.TranProto<Model.OAuthInfo> tp = new Model.TranProto<Model.OAuthInfo>();
            tp.IsError = false;
            try
            {
                //获取URL
                string tokenUrl = string.Empty;
                Model.TranProto<Model.OAuthConfig> tpUrl = GetAuthInfo(oAuthName);
                if (tpUrl.IsError || tpUrl.Data == null)
                {
                    tp.Msg = tpUrl.Msg;
                    return tp;
                }
                //获取返回对象
                Model.OAuthConfig oac = tpUrl.Data as Model.OAuthConfig;
                if (IsGetToken)
                {
                    //拼接令牌获取地址
                    tokenUrl += oac.TokenUrl + code;
                }
                else
                {
                    tokenUrl = oac.RefreshUrl + code;
                }
                //返回文本数据容器
                string html = string.Empty;
                //获取html值
                Model.TranProto<string> tpHtml = GetWebRequestInfo(tokenUrl, method);
                if (tpHtml == null || tpHtml.IsError || string.IsNullOrWhiteSpace(Convert.ToString(tpHtml.Data)))
                {
                    tp.IsError = true;
                    tp.Msg = "请求服务器异常";
                }
                else
                {
                    html = tpHtml.Data;
                    //json序列号对象
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    //设置json最大长度
                    jsonSerializer.MaxJsonLength = Int32.MaxValue;
                    //返回字典值
                    Dictionary<string, object> dic_Data = jsonSerializer.Deserialize<Dictionary<string, object>>(html);

                    if (dic_Data != null && dic_Data.Count > 0)
                    {
                        //实例化授权对象
                        Model.OAuthInfo oai = new Model.OAuthInfo();

                        string accessToken = oac.OAuthInfo.AccessToken;
                        string refreshToken = oac.OAuthInfo.RefreshToken;
                        string userCode = oac.OAuthInfo.UserCode;
                        string userNick = oac.OAuthInfo.UserNick;

                        //填充数据
                        if (!string.IsNullOrWhiteSpace(accessToken))
                        {
                            oai.AccessToken = Convert.ToString(dic_Data[accessToken]);
                        }
                        if (!string.IsNullOrWhiteSpace(refreshToken))
                        {
                            oai.RefreshToken = Convert.ToString(dic_Data[refreshToken]);
                        }
                        if (!string.IsNullOrWhiteSpace(userCode))
                        {
                            oai.UserCode = Convert.ToString(dic_Data[userCode]);
                        }
                        if (!string.IsNullOrWhiteSpace(userNick))
                        {
                            oai.UserNick = Convert.ToString(dic_Data[userNick]);
                        }
                        oai.OAuthName = oac.Name;
                        //返回值
                        tp.Data = oai;
                    }
                }
                return tp;
            }
            catch (Exception ex)
            {
                tp.IsError = true;
                tp.Msg = ex.StackTrace + System.Environment.NewLine + ex.Message;
                return tp;
            }
        }

        /// <summary>
        /// 令牌登出
        /// </summary>
        /// <returns>
        /// 数据类型为 string
        /// </returns>
        public Model.TranProto<string> GetTokenLogOff(string oAuthName = "")
        {
            Model.TranProto<string> tp = new Model.TranProto<string>();
            tp.IsError = false;
            try
            {
                Model.TranProto<Model.OAuthConfig> tpUrl = GetAuthInfo(oAuthName);
                if (tpUrl.IsError || tpUrl.Data == null)
                {
                    tp.Msg = tpUrl.Msg;
                    return tp;
                }
                //获取返回对象
                Model.OAuthConfig oac = tpUrl.Data as Model.OAuthConfig;
                tp.Data = oac.LogOffUrl;
                return tp;
            }
            catch (Exception ex)
            {
                tp.IsError = true;
                tp.Msg = ex.StackTrace + System.Environment.NewLine + ex.Message;
                return tp;
            }
        }

        /// <summary>
        /// Web请求方法
        /// </summary>
        /// <param name="url">请求网站</param>
        /// <param name="method">请求方式</param>
        /// <returns>
        /// 数据类型为 string
        /// </returns>
        public Model.TranProto<string> GetWebRequestInfo(string url, string method)
        {
            Model.TranProto<string> tp = new Model.TranProto<string>();
            tp.IsError = false;
            try
            {
                //返回文本数据容器
                string html = string.Empty;
                //创建一个请求项
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //判断服务器是否处理POST的数据
                request.ServicePoint.Expect100Continue = method.ToLower().Equals("post");
                //请求方式
                request.Method = method.ToUpper();
                //是否建立持久性链接
                request.KeepAlive = true;
                //设置HTTP头
                request.UserAgent = "object.yan";
                //设置超时时间
                request.Timeout = Int32.MaxValue;
                //设置标题头
                request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                //写入请求数据
                using (Stream reqStream = request.GetRequestStream())
                {
                    //获取返回资源
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    //读取资源流信息
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet));
                    //获取html文本
                    html = sr.ReadToEnd();
                }
                tp.Data = html;
                return tp;
            }
            catch (Exception ex)
            {
                tp.IsError = true;
                tp.Msg = ex.StackTrace + System.Environment.NewLine + ex.Message;
                return tp;
            }
        }
    }
}
