using Bitkompagniet.StoryGraph.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bitkompagniet.StoryGraph.Store.Mongo
{
	internal class MongoRelation : MongoModel, IRelation
	{
		public ObjectId FromId { get; set; }

		public ObjectId ToId { get; set; }

		[BsonIgnore] public IEntity From { get; set; }

		[BsonIgnore] public IEntity To { get; set; }
	}
}