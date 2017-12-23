using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Test
{
    [TestClass]
    public class TestTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestGetOne()
        {
            var storage = new Storage();
            Assert.AreEqual(1, storage.GetOne());
        }
    }
}
