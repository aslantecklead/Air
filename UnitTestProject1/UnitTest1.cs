using Air;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test2()
        {
            Functions functional = new Functions();
            var result = functional.GetTotalUserCount();
            Assert.AreEqual("11", result);
        }
    }
}
