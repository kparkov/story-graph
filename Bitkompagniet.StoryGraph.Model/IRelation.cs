namespace Bitkompagniet.StoryGraph.Model
{
	public interface IRelation : IId
	{
		IEntity From { get; }
		IEntity To { get; }
	}
}
