namespace Bitkompagniet.StoryGraph.Model
{
	public interface IEntity : IModel
    {
        string Name { get; }
		IIdEnumerable<IRelation> Relations { get; }
    }
}
