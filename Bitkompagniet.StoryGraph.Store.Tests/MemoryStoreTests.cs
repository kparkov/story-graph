using System;
using System.Linq;
using Bitkompagniet.StoryGraph.Store.Mongo;
using Xunit;

namespace Bitkompagniet.StoryGraph.Store.Tests
{
    public class MemoryStoreTests
    {
        [Fact]
        public void CanInsertToDatabase()
        {
            var mstore = new MongoStore("mongodb://localhost:27017/", "x1");
            var before = mstore.AllEntities().Count();
            mstore.Add(new MongoEntity {});
            var all = mstore.AllEntities();
            Assert.Equal(before + 1, all.Count());
        }
    }
}
