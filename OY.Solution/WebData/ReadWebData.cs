using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using html = mshtml;
using WebDataTests.Model;
using ScrapySharp.Network;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace WebData
{
    public class ReadWebData
    {
        /// <summary>
        /// ScrapySharp 读取数据
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <param name="dataModel">截取规则</param>
        /// <returns>
        /// 返回截取数据
        /// </returns>
        public Dictionary<string, string> ReadBSData(string url, List<DataModel> dataModel)
        {
            var uri = new Uri(url);
            var browser1 = new ScrapingBrowser();
            browser1.Encoding = Encoding.Default;
            var html1 = browser1.DownloadString(uri);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html1);
            var html = htmlDocument.DocumentNode;
            Dictionary<string, string> dicData = new Dictionary<string, string>();
            DiGui(dataModel, html, dicData, url);
            return dicData;
        }

        /// <summary>
        /// 递归解析数据
        /// </summary>
        /// <param name="dataModel">截取规则</param>
        /// <param name="htmlNode">节点</param>
        /// <param name="dicData">截取后数据</param>
        /// <param name="url">网页地址</param>
        public void DiGui(List<DataModel> dataModel, HtmlNode htmlNode, Dictionary<string, string> dicData, string url)
        {
            foreach (var item in dataModel)
            {
                //查找条件
                string expression = item.NodeType.ToString();
                if (!string.IsNullOrWhiteSpace(item.AttrName) && !string.IsNullOrWhiteSpace(item.AttrValue))
                {
                    expression += string.Format("[{0}={1}]", item.AttrName, item.AttrValue);
                }
                var tmpNode = htmlNode.CssSelect(expression);
                if (tmpNode.Any())
                {
                    if (item.IsChildNode)
                    {
                        foreach (var itemNode in tmpNode)
                        {
                            DiGui(item.ChildInfo, itemNode, dicData, url);
                        }
                    }
                    else if (item.IsIdentityTitle)
                    {
                        foreach (var itemNode in tmpNode)
                        {
                            #region 赋值
                            string value = string.Empty;
                            switch (item.NodeType)
                            {
                                case Model.NodeType.A:
                                    value = itemNode.GetAttributeValue("href");
                                    var tmpUrl = new Uri(url);
                                    if (value.IndexOf("/") == 0)
                                    {
                                        value = tmpUrl.Host + value;
                                    }
                                    else
                                    {
                                        value = url + (url.LastIndexOf("/") == url.Length - 1 ? "" : "/") + value;
                                    }
                                    break;
                                case Model.NodeType.Img:
                                    value = itemNode.GetAttributeValue("src");
                                    tmpUrl = new Uri(url);
                                    if (value.IndexOf("/") == 0)
                                    {
                                        value = tmpUrl.Host + value;
                                    }
                                    else
                                    {
                                        value = url + (url.LastIndexOf("/") == url.Length - 1 ? "" : "/") + value;
                                    }
                                    break;
                                default:
                                    value = itemNode.InnerHtml;
                                    break;
                            }
                            if (dicData.ContainsKey(item.Title))
                            {
                                if (item.IsIdentityTitle)
                                    dicData.Add(item.Title + (dicData.Keys.ToList().Count(x => x.Contains(item.Title)) - 1), value);
                                else
                                    dicData[item.Title] = value;
                            }
                            else
                                dicData.Add(item.Title, value);
                            #endregion
                        }
                    }
                    else
                    {
                        #region 赋值
                        string value = string.Empty;
                        switch (item.NodeType)
                        {
                            case Model.NodeType.A:
                                value = tmpNode.First().GetAttributeValue("href");
                                var tmpUrl = new Uri(url);
                                if (value.IndexOf("/") == 0)
                                {
                                    value = tmpUrl.Host + value;
                                }
                                else
                                {
                                    value = url + (url.LastIndexOf("/") == url.Length - 1 ? "" : "/") + value;
                                }
                                break;
                            case Model.NodeType.Img:
                                value = tmpNode.First().GetAttributeValue("src");
                                tmpUrl = new Uri(url);
                                if (value.IndexOf("/") == 0)
                                {
                                    value = tmpUrl.Host + value;
                                }
                                else
                                {
                                    value = url + (url.LastIndexOf("/") == url.Length - 1 ? "" : "/") + value;
                                }
                                break;
                            default:
                                value = tmpNode.First().InnerHtml;
                                break;
                        }
                        if (dicData.ContainsKey(item.Title))
                        {
                            if (item.IsIdentityTitle)
                                dicData.Add(item.Title + (dicData.Keys.ToList().Count(x => x.Contains(item.Title)) - 1), value);
                            else
                                dicData[item.Title] = value;
                        }
                        else
                            dicData.Add(item.Title, value);
                        #endregion
                    }
                }
            }
        }
    }
}
