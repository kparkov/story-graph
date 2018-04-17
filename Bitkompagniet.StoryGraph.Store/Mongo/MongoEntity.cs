using Bitkompagniet.StoryGraph.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Bitkompagniet.StoryGraph.Store.Mongo
{
	internal class MongoEntity : MongoModel, IEntity
	{
		public string Name { get; set; }

		[BsonIgnore] public IIdEnumerable<IRelation> Relations { get; set; }
	}
}