using System;
using System.Linq;
using Bitkompagniet.StoryGraph.Model;
using Bitkompagniet.StoryGraph.Store.Mongo;
using Xunit;

namespace Bitkompagniet.StoryGraph.Store.Tests
{
    public class MemoryStoreTests
    {
        [Fact]
        public void CanInsertToDatabase()
        {
            var mstore = new MongoStore("mongodb://localhost:27017/", RandomDatabaseName());
            var before = mstore.AllEntities().Count();
            Assert.Equal(0, before);
            mstore.Add(new MongoEntity {});
            var all = mstore.AllEntities();
            Assert.Equal(before + 1, all.Count());
        }

        [Fact]
        public void CanFindEntityById() 
        {
            var mstore = new MongoStore("mongodb://localhost:27017/", RandomDatabaseName());
            var entity = new MongoEntity() { Name = "Test" };
            var id = mstore.Add(entity);

            Assert.NotNull(id);
            Assert.True(id.ToString().Length > 10);

            Assert.True(mstore.EntityExists(id));
            var loaded = mstore.GetEntity(id);
            Assert.NotNull(loaded);
            Assert.IsAssignableFrom<IEntity>(loaded);
        }

        [Fact]
        public void CanAddRelationToModel() 
        {
            var mstore = new MongoStore("mongodb://localhost:27017/", RandomDatabaseName());
            var e1 = new MongoEntity() { Name = "Parent" };
            var e2 = new MongoEntity() { Name = "Child" };

            var e1id = mstore.Add(e1);
            var e2id = mstore.Add(e2);

            Assert.Equal(e1.Id, e1id);

            var relation = new MongoRelation()
            {
                From = e1,
                To = e2,
            };

            var relationid = mstore.AddRelation(relation);

            var relationsDirect = mstore.GetOutgoingRelationsOf(e1.Id);
            Assert.Equal(1, relationsDirect.Count());

            var e1reloaded = mstore.GetEntity(e1id);

            Assert.Equal(1, e1reloaded.Relations.Count());

            var firstrelation = e1reloaded.Relations.First();

            Assert.Equal(e1id, firstrelation.From.Id);
            Assert.Equal(e2id, firstrelation.To.Id);
        }

        private string RandomDatabaseName() 
        {
            return Guid.NewGuid().ToString();
        }
    }
}
