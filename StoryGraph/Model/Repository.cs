using System;
using System.Collections.Generic;

namespace KVP.StoryGraph.Model
{
    public class Repository
    {
        private readonly IDataStore _store;

        public Repository(IDataStore store)
        {
            _store = store;
        }

        public IModelCollection<Entity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Entity GetEntity(object id)
        {
            var entity = _store.GetEntityAndRelations(id);
            //entity.Relations = 
            return entity;
        }
    }
}
