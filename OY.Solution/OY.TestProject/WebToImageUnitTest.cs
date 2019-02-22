using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Common.WebToImage;

namespace OY.TestProject
{
    [TestClass]
    public class WebToImageUnitTest
    {
        [TestMethod]
        public void WebToThumbnailTestMethod()
        {
            WebToThumbnail wtt = new WebToThumbnail(@"E:\Test.jpg", "http://www.baidu.com/s?ie=utf-8&f=8&rsv_bp=1&tn=96289920_hao_pg&wd=c%23%E6%96%87%E4%BB%B6%E6%AD%A3%E5%88%99&rsv_pq=b02af8c800016164&rsv_t=5014U9K1qFeFrL9UWGmFgeDgpnwpThxMPL7CyDJSK9neppaPl6M0jV5gTpKhzYcvkwwfAfLU&rsv_enter=1&oq=C%23%E6%AD%A3%E5%88%99&rsv_sug3=22&rsv_sug4=1497&rsv_sug1=15&rsv_sug2=0&inputT=7785");
            wtt.Start();
        }
    }
}
