namespace Bitkompagniet.StoryGraph.Model
{
	public interface IEntity : IId
    {
        string Name { get; }
		IIdEnumerable<IRelation> Relations { get; }
    }
}
