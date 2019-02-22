using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.Common.XML;

namespace OY.TestProject
{
    [TestClass]
    public class XmlToClassUtilTest
    {
        [TestMethod]
        public void TestMethod()
        {
            XmlToClassManagement xml = new XmlToClassManagement();
            string xmlData = @"<responseFail>
<reasoncode>原因代码，请参考附录</reasoncode>
<remark>描述，保留</remark>
</responseFail>";
            xml.XmlToClass(xmlData);
        }

        [TestMethod]
        public void TestMethodAll()
        {
            XmlToClassManagement xml = new XmlToClassManagement();
            foreach (var item in Directory.GetFiles(@"C:\Users\object\Documents\OY\MyTools\OY.Solution\OY.TestProject\Data\"))
            {
                using (StreamReader sr = new StreamReader(item))
                {
                    string str = sr.ReadToEnd();
                    str = str.Replace("\r\n", "");
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        xml.XmlToClass(str);
                    }
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine(item);
                    Console.WriteLine(str);
                    Console.WriteLine("-----------------------------------------");
                }
            }
        }
    }
}
