using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bitkompagniet.StoryGraph.Store.Mongo
{
	internal abstract class MongoModel 
	{
		[BsonId]
		public ObjectId MongoId { get; set; } = ObjectId.GenerateNewId();

		[BsonIgnore] public object Id => MongoId;
	}
}