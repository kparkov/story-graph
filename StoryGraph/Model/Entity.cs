using System;

namespace KVP.StoryGraph.Model
{
    public class Entity : IModel
    {
        public object Id { get; set; }
        public DateTime Creation { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Description { get; set; }

        public IModelCollection<Relation> Relations { get; set; }
    }
}