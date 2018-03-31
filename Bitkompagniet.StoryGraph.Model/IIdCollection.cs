namespace Bitkompagniet.StoryGraph.Model
{
	public interface IIdCollection<T> : IIdEnumerable<T>, IIdBucket<T> where T : IId
    {
        void Remove(object id);
    }
}
