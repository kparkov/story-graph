using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KVP.StoryGraph.Model
{
    public class ModelCollection<TModel> : IModelCollection<TModel>
        where TModel : IModel
    {
        private Dictionary<object, TModel> _models;

        public ModelCollection(IEnumerable<TModel> models)
        {
            _models = models.ToDictionary(m => m.Id);
        }

        public IEnumerator<TModel> GetEnumerator()
        {
            return _models.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Update(TModel model)
        {
            throw new System.NotImplementedException();
        }

        public TModel Get(object id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(object id)
        {
            throw new System.NotImplementedException();
        }
    }
}