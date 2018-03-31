namespace Bitkompagniet.StoryGraph.Model
{
	public interface IRelation : IModel
	{
		IEntity From { get; }
		IEntity To { get; }
	}
}
