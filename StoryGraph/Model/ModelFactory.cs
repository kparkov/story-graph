using System;

namespace KVP.StoryGraph.Model
{
    public class ModelFactory<TModel> : IModelFactory<TModel> where TModel : IModel, new()
    {
        public TModel Create()
        {
            var model = new TModel();
            model.Id = Guid.NewGuid().ToString();
            model.Creation = DateTime.Now;
            return model;
        }
    }
}