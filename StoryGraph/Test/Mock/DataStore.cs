using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KVP.StoryGraph.Model;

namespace KVP.StoryGraph.Test.Mock
{
    public class DataStore : IDataStore
    {
        public Entity GetEntityAndRelations(object id)
        {
            var entity = _entities.SingleOrDefault(e => e.Id == id);

            if (entity == null) return null;

            entity.Relations = _relations
                .Where(r => r.Subject == (string) entity.Id)
                .Select(idr => new Relation() { Id = Guid.NewGuid().ToString(), Subject = entity, Object = _entities.Single(e => (string) e.Id == idr.Object) })
                .ToModelCollection();

            return entity;
        }

        public Relation GetRelationWithParticipations(object id)
        {
            throw new NotImplementedException();
        }

        private List<Entity> _entities = new List<Entity>()
        {
            new Entity() { Id = "bilbo-baggins", Title = "Bilbo Baggins", Description = "The ring finder." },
            new Entity() { Id = "frodo-baggins", Title = "Frodo Baggins", Description = "The ring bearer." },
            new Entity() { Id = "sauron", Title = "Sauron", Description = "The enemy." },
        };

        private List<IdRelation> _relations = new List<IdRelation>()
        {
            new IdRelation() { Id = "A", Subject = "bilbo-baggins", Object = "frodo-baggins", Type = RelationDefinition.Creator },
            new IdRelation() { Id = "B", Subject = "frodo-baggins", Object = "bilbo-baggins", Type = RelationDefinition.Creator.GetOppositeRelation() },
            new IdRelation() { Id = "C", Subject = "frodo-baggins", Object = "sauron", Type = RelationDefinition.Hate },
            new IdRelation() { Id = "D", Subject = "sauron", Object = "frodo-baggins", Type = RelationDefinition.Hate.GetOppositeRelation() }
        };

        private class IdRelation
        {
            public object Id { get; set; }
            public string Subject { get; set; }
            public string Object { get; set; }
            public RelationDefinition Type { get; set; }
        }
    }
}
