using System.Diagnostics;
using System.Linq;
using KVP.StoryGraph.Model;
using KVP.StoryGraph.Test.Mock;
using KVP.StoryGraph.Utility;
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
            Assert.IsTrue(RelationDefinition.CreatedBy.Asymmetrical());
            Assert.IsTrue(RelationDefinition.Creator.Asymmetrical());
            Assert.IsFalse(RelationDefinition.Hate.Asymmetrical());
        }

        [TestMethod]
        public void MapperCorrectlyMapsOverlappingProperties()
        {
            //var mapper = new ModelMapper<MapperModelA, MapperModelB>();
            var b = new MapperModelA()
            {
                Id = "abc",
                Name = "Frodo Baggins",
                Year = 1937,
                Relationship = "Nephew"
            }.MapTo<MapperModelB>();

            Assert.AreEqual("abc", b.Id);
            Assert.AreEqual("Frodo Baggins", b.Name);
            Assert.AreEqual(10, b.Amount);
            Assert.AreEqual(RelationDefinition.Association, b.Relationship);
        }

        private class MapperModelA
        {
            public object Id { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public string Relationship { get; set; }
        }

        private class MapperModelB
        {
            public object Id { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; } = 10;
            public RelationDefinition Relationship { get; set; } = RelationDefinition.Association;
        }
    }
}
