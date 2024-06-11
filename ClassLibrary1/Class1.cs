namespace ClassLibrary1
{
    using Air;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void Test2()
        {
            Functions functional = new();
            var result = functional.GetTotalUserCount();
            Assert.Equals(11, result);
        }
    }
}
