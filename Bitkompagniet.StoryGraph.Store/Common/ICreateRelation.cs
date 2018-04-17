namespace Bitkompagniet.StoryGraph.Store.Common
{
	public interface ICreateRelation 
	{
		object FromId { get; }
		object ToId { get; }
	}

	public class CreateRelation : ICreateRelation
	{
		public object FromId { get; set; }
		public object ToId { get; set; }
	}
}