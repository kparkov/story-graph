namespace KVP.StoryGraph.Model
{
    public interface IModelFactory<out TModel> where TModel : IModel
    {
        TModel Create();
    }
}