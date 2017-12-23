using KVP.StoryGraph.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KVP.StoryGraph.Test
{
    [TestClass]
    public class TestTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(2, 1);
        }

        [TestMethod]
        public void TestGetOne()
        {
            var storage = new Storage();
            Assert.AreEqual(1, storage.GetOne());
        }
    }
}
