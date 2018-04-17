namespace Bitkompagniet.StoryGraph.Model.Extensions
{
	public static class IdExtensions
	{
		public static bool IdEquals(this IId a, IId b)
		{
			return object.Equals(a.Id, b.Id);
		}
	}
}