using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OY.OAuth.Model;

namespace OY.OAuth.Interface
{
    /// <summary>
    /// 授权接口
    /// </summary>
    public interface IOAuth<T>
    {
        /*
         * 解析XML
         * 获取对应授权信息
         * 获取授权地址
         * 获取授权信息
         * 令牌登出
         * Web请求方法
         * 令牌刷新
         */

        /// <summary>
        /// 解析XML
        /// </summary>
        /// <returns>
        /// Data 为  Model.OAuthData 类型
        /// </returns>
        TranProto<Model.OAuthData<T>> AnalyXML();

        /// <summary>
        /// 获取对应授权信息
        /// </summary>
        /// <returns>
        /// Data 为 Model.OAuthConfig 类型
        /// </returns>
        TranProto<Model.OAuthConfig> GetAuthInfo(string oAuthName = "");

        /// <summary>
        /// 获取授权地址
        /// </summary>
        /// <returns>
        /// Data 为 string 类型
        /// </returns>
        TranProto<string> GetAuthAddress(string oAuthName = "");

        /// <summary>
        /// 获取授权信息
        /// </summary>
        /// <param name="code">code值</param>
        /// <param name="tokenUrl">请求地址</param>
        /// <param name="method">请求方式</param>
        /// <param name="IsGetToken">是否获取令牌</param>
        /// <returns>
        /// Data 为 Model.OAuthInfo 类型
        /// </returns>
        TranProto<Model.OAuthInfo> GetTokenCode(string code, string method, bool IsGetToken = true, string oAuthName = "");

        /// <summary>
        /// 令牌登出地址
        /// </summary>
        /// <returns>
        /// Data 为 string 类型
        /// </returns>
        TranProto<string> GetTokenLogOff(string oAuthName = "");

        /// <summary>
        /// Web请求方法
        /// </summary>
        /// <param name="url">请求网站</param>
        /// <param name="method">请求方式</param>
        /// <returns>
        /// Data 为 string 类型
        /// </returns>
        TranProto<string> GetWebRequestInfo(string url, string method);
    }
}
