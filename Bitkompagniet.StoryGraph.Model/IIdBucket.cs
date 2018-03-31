namespace Bitkompagniet.StoryGraph.Model
{
	public interface IIdBucket<in T> where T : IId
    {
        void Add(T model);
    }
}
