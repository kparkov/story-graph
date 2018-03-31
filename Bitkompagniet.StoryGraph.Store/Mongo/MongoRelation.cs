using Bitkompagniet.StoryGraph.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Bitkompagniet.StoryGraph.Store.Mongo
{
	public class MongoRelation : MongoModel, IRelation
	{
		public string FromId { get; set; }

		public string ToId { get; set; }

		[BsonIgnore] public IEntity From { get; set; }

		[BsonIgnore] public IEntity To { get; set; }
	}
}