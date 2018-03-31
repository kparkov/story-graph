using System.Collections.Generic;

namespace Bitkompagniet.StoryGraph.Model
{
	public interface IIdEnumerable<out T> : IEnumerable<T> where T : IId
    {
        bool Exists(object id);
        T Get(object id);
    }
}
