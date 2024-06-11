using NUnit.Framework;
using Air;

namespace TestProject
{
    public class UnitTest1
    {
        [Test]
        public void Test2()
        {
            Functions functional = new();
            var result = functional.GetTotalUserCount();
            NUnit.Framework.Assert.Equals(11, result);
        }
    }
}