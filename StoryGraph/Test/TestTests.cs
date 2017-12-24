using System.Diagnostics;
using System.Linq;
using KVP.StoryGraph.Model;
using KVP.StoryGraph.Test.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KVP.StoryGraph.Test
{
    [TestClass]
    public class TestTests
    {
        [TestMethod]
        public void TestDataStore()
        {
            var store = new Repository(new DataStore());
            var frodo = store.GetEntity("frodo-baggins");
            Assert.IsNotNull(frodo);
            Assert.IsNotNull(frodo.Relations);
            Assert.AreEqual(2, frodo.Relations.Count());

            Assert.IsTrue(frodo.Relations.All(r => r.Object != null));

            var bilbo = frodo.Relations.Single(r => r.Object.IdentityIs("bilbo-baggins")).Object;

            Assert.IsNull(bilbo.Relations);
        }

        [TestMethod]
        public void CheckAsymmetricalRelation()
        {
            Assert.IsTrue(RelationDefinition.Nephew.Asymmetrical());
            Assert.IsTrue(RelationDefinition.Child.Asymmetrical());
            Assert.IsFalse(RelationDefinition.Sibling.Asymmetrical());
        }
    }
}
