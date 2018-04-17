using System;
using System.Linq;
using Bitkompagniet.StoryGraph.Model;
using Bitkompagniet.StoryGraph.Model.Extensions;
using Bitkompagniet.StoryGraph.Store.Common;
using Bitkompagniet.StoryGraph.Store.Mongo;
using Xunit;

namespace Bitkompagniet.StoryGraph.Store.Tests
{
    public class MongoStoreTests
    {
        private readonly string _mongouri = Environment.GetEnvironmentVariable("SG_MONGO_URI") ?? "mongodb://localhost:27017/";

        [Fact]
        public void MongoUriAlwaysSet()
        {
            Assert.NotNull(_mongouri);
            Assert.Contains("mongo", _mongouri.ToLower());
        }

        [Fact]
        public void CanInsertToDatabase()
        {
            var mstore = new MongoStore("mongodb://localhost:27017/", RandomDatabaseName());
            Assert.Empty(mstore.AllEntities());
            mstore.CreateEntity(new CreateEntity { Name = "Test" });
            Assert.NotEmpty(mstore.AllEntities());
        }

        [Fact]
        public void CanFindEntityById() 
        {
            var mstore = new MongoStore("mongodb://localhost:27017/", RandomDatabaseName());
            var entity = mstore.CreateEntity(new CreateEntity() { Name = "Test" });

            Assert.NotNull(entity);
            Assert.NotNull(entity.Id);
            Assert.True(entity.Id.ToString().Length > 10);

            Assert.True(mstore.EntityExists(entity.Id));
            var reloaded = mstore.GetEntity(entity.Id);
            Assert.NotNull(reloaded);
            Assert.IsAssignableFrom<IEntity>(reloaded);
        }

        [Fact]
        public void CanAddRelationToModel() 
        {
            var mstore = new MongoStore("mongodb://localhost:27017/", RandomDatabaseName());
            var e1 = mstore.CreateEntity(new CreateEntity() { Name = "Parent" });
            var e2 = mstore.CreateEntity(new CreateEntity() { Name = "Child" });

            var relation = new CreateRelation()
            {
                FromId = e1.Id,
                ToId = e2.Id,
            };

            var relationid = mstore.CreateRelation(relation);

            var relationsDirect = mstore.GetOutgoingRelationsOf(e1.Id);
            Assert.Single(relationsDirect);

            var e1reloaded = mstore.GetEntity(e1.Id);

            Assert.Single(e1reloaded.Relations);

            var firstrelation = e1reloaded.Relations.First();

            Assert.Equal(e1.Id, firstrelation.From.Id);
            Assert.Equal(e2.Id, firstrelation.To.Id);
        }

        [Fact]
        public void CanFindRelationById()
        {
            var store = new MongoStore(_mongouri, RandomDatabaseName());
            var e1 = store.CreateEntity(new CreateEntity { Name = "A" });
            var e2 = store.CreateEntity(new CreateEntity { Name = "B" });

            var relation = store.CreateRelation(new CreateRelation { FromId = e1.Id, ToId = e2.Id });

            var reloadedRelation = store.GetRelation(relation.Id);

            Assert.Equal(reloadedRelation.From.Id, e1.Id);
            Assert.Equal(reloadedRelation.To.Id, e2.Id);

            Assert.NotEqual(reloadedRelation.From, e1);

            var relationsOfFrom = reloadedRelation.From.Relations;

            Assert.Single(relationsOfFrom);

            var singleRelation = relationsOfFrom.Single();

            Assert.NotEqual(relation, singleRelation);
            Assert.Equal(relation.Id, singleRelation.Id);
            Assert.True(relation.IdEquals(singleRelation));
        }

        private string RandomDatabaseName() 
        {
            return Guid.NewGuid().ToString();
        }
    }
}
