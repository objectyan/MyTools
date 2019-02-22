using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OY.OAuth.Model
{
    #region XML
    /// <summary>
    /// 授权数据
    /// </summary>
    [Serializable]
    [XmlRootAttribute("OAuthData")]
    public class OAuthData<T>
    {
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
        private T _oAuthConfig;

        /// <summary>
        /// 集合配置
        /// </summary>
        [XmlElementAttribute("OAuthConfig")]
        public T OAuthConfig
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
        /// 令牌刷新地址
        /// </summary>
        private string _refreshUrl;
        /// <summary>
        /// 令牌登出地址
        /// </summary>
        private string _logOffUrl;
        /// <summary>
        /// 授权信息
        /// </summary>
        private OAuthInfo _oAuthInfo;

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

        /// <summary>
        /// 授权信息
        /// </summary>
        [XmlElementAttribute("OAuthInfo")]
        public OAuthInfo OAuthInfo
        {
            get { return _oAuthInfo; }
            set { _oAuthInfo = value; }
        }

        /// <summary>
        /// 令牌刷新地址
        /// </summary>
        public string RefreshUrl
        {
            get { return _refreshUrl; }
            set { _refreshUrl = value; }
        }

        /// <summary>
        /// 令牌登出地址
        /// </summary>
        [XmlElementAttribute("LogOffUrl")]
        public string LogOffUrl
        {
            get { return _logOffUrl; }
            set { _logOffUrl = value; }
        }
    }

    /// <summary>
    /// 授权信息
    /// </summary>
    [Serializable]
    public class OAuthInfo
    {
        /// <summary>
        /// 刷新令牌
        /// </summary>
        private string _refreshToken;

        /// <summary>
        /// 刷新令牌
        /// </summary>
        [XmlElementAttribute("RefreshToken")]
        public string RefreshToken
        {
            get { return _refreshToken; }
            set { _refreshToken = value; }
        }

        /// <summary>
        /// 访问令牌
        /// </summary>
        private string _accessToken;

        /// <summary>
        /// 访问令牌
        /// </summary>
        [XmlElementAttribute("AccessToken")]
        public string AccessToken
        {
            get { return _accessToken; }
            set { _accessToken = value; }
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        private string _userCode;

        /// <summary>
        /// 用户编号
        /// </summary>
        [XmlElementAttribute("UserCode")]
        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        private string _userNick;

        /// <summary>
        /// 用户名称
        /// </summary>
        [XmlElementAttribute("UserNick")]
        public string UserNick
        {
            get { return _userNick; }
            set { _userNick = value; }
        }

        /// <summary>
        /// 授权名称
        /// </summary>
        private string _oAuthName;

        /// <summary>
        /// 授权名称
        /// </summary>
        public string OAuthName
        {
            get
            {
                return _oAuthName;
            }

            set
            {
                _oAuthName = value;
            }
        }
    }
    #endregion

    #region 传输协议
    public class TranProto<T>
    {
        /// <summary>
        /// 是否有错
        /// </summary>
        private bool _isError;

        /// <summary>
        /// 是否有错
        /// </summary>
        public bool IsError
        {
            get { return _isError; }
            set { _isError = value; }
        }

        /// <summary>
        /// 文本信息
        /// </summary>
        private string _msg;

        /// <summary>
        /// 文本信息
        /// </summary>
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        /// <summary>
        /// 数据信息
        /// </summary>
        private T _data;

        /// <summary>
        /// 数据信息
        /// </summary>
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
    #endregion
}
