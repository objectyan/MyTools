using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OY.AutoClass.DBAccess.DBAccess;
using OY.AutoClass.DBAccess.Interface;

namespace OY.AutoClass.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            IDBAccess _IDBAccess = DBAccess.DBAccessFactory.CreateDBAccess<SqlServer>();
            for (int i = 0; i < 1000; i++)
            {
                _IDBAccess.Query("select * from sys.columns");
            }
        }
    }
}