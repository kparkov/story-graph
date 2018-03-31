using System;
using System.Collections.Generic;
using System.Linq;
using Bitkompagniet.StoryGraph.Model;
using MongoDB.Driver;

namespace Bitkompagniet.StoryGraph.Store.Mongo
{
	public class MongoStore : IStore
	{
		private readonly string _mongoUrl;
		private readonly string _database;
		private readonly MongoClient _client;

		public MongoStore(string mongoUrl, string database)
		{
			_mongoUrl = mongoUrl;
			_database = database;
			_client = new MongoClient(mongoUrl);
		}

		internal MongoStore(MongoClient client) {}

		private IMongoDatabase Database => _client.GetDatabase(_database);
		private IMongoCollection<MongoEntity> Entities => Database.GetCollection<MongoEntity>("Entities");
		private IMongoCollection<MongoRelation> Relations => Database.GetCollection<MongoRelation>("Relations");

		public void Add(IEntity entity)
		{
			Entities.InsertOne(new MongoEntity 
			{
				Name = entity.Name
			});
		}

		public IIdEnumerable<IEntity> AllEntities()
		{
			var result = Entities
				.Find(x => true)
				.ToEnumerable()
				.Select(MapEntity);

			return new DictionaryModelEnumerable<IEntity>(result);
		}

		public IEntity GetEntity(object id)
		{
			var result = Entities
				.Find(x => x.Id == id)
				.Single();

			return MapEntity(result);
		}

		public IIdEnumerable<IRelation> GetOutgoingRelationsOf(object id)
		{
			return null;
		}

		private IEntity MapEntity(MongoEntity entity)
		{
			entity.Relations = new LazyModelEnumerable<IRelation>(() => GetOutgoingRelationsOf(entity.Id));
			return entity;
		}
	}
}