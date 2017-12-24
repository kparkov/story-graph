using System;

namespace KVP.StoryGraph.Model
{
    public class Relation : IModel
    {
        public object Id { get; set;  }
        public DateTime Creation { get; set; } = DateTime.Now;

        public Entity Subject { get; set; }
        public Entity Object { get; set; }
        public RelationDefinition Type { get; set; }
    }
}