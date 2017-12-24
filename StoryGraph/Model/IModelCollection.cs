using System.Collections.Generic;

namespace KVP.StoryGraph.Model
{
    public interface IModelCollection<TModel> : IEnumerable<TModel>
        where TModel : IModel
    {
        void Update(TModel model);
        TModel Get(object id);
        bool Exists(object id);

    }
}