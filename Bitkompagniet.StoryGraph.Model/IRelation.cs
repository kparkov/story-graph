namespace Bitkompagniet.StoryGraph.Model
{
	public interface IRelation : IId
	{
		IEntity From { get; }
		IEntity To { get; }
	}

	public enum RelationType
	{
		Undefined = 0,
		Creator = 1,
	}
}
