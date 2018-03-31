using System;
using System.Collections.Generic;
using System.Linq;
using Bitkompagniet.StoryGraph.Model;
using MongoDB.Bson;
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

		public object Add(IEntity entity)
		{
			var mentity = new MongoEntity
			{
				MongoId = (ObjectId) entity.Id,
				Name = entity.Name
			};

			Entities.InsertOne(mentity);

			return mentity.Id;
		}

		public object AddRelation(IRelation relation)
		{
			var mrelation = new MongoRelation
			{
				FromId = (ObjectId) relation.From.Id,
				ToId = (ObjectId) relation.To.Id,
			};

			Relations.InsertOne(mrelation);

			return mrelation.Id;
		}

		public IIdEnumerable<IEntity> AllEntities()
		{
			var result = Entities
				.Find(x => true)
				.ToEnumerable()
				.Select(MapEntity);

			return new DictionaryModelEnumerable<IEntity>(result);
		}

		public bool EntityExists(object id)
		{
			var mid = (ObjectId) id;

			var result = Entities
				.Count(x => x.MongoId == mid);
			
			return result > 0;
		}

		public IEntity GetEntity(object id)
		{
			var mid = (ObjectId) id;

			var result = Entities
				.Find(x => x.MongoId == mid)
				.Single();

			return MapEntity(result);
		}

		public IIdEnumerable<IRelation> GetOutgoingRelationsOf(object id)
		{
			var mid = (ObjectId) id;

			var allRelations = Relations.Find(x => true).ToList();

			var result = Relations
				.Find(x => x.FromId == mid)
				.ToList();

			foreach (var relation in result)
			{
				relation.From = GetEntity(relation.FromId);
				relation.To = GetEntity(relation.ToId);
			}
			
			return new DictionaryModelEnumerable<IRelation>(result);
		}

		private IEntity MapEntity(MongoEntity entity)
		{
			entity.Relations = new LazyModelEnumerable<IRelation>(() => GetOutgoingRelationsOf(entity.Id));
			return entity;
		}
	}
}