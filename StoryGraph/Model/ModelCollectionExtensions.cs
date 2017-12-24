using System.Collections.Generic;

namespace KVP.StoryGraph.Model
{
    public static class ModelCollectionExtensions
    {
        public static ModelCollection<TModel> ToModelCollection<TModel>(this IEnumerable<TModel> models)
            where TModel : IModel
        {
            return new ModelCollection<TModel>(models);
        }
    }
}