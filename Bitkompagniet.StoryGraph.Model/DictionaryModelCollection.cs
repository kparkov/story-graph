using System.Collections.Generic;

namespace Bitkompagniet.StoryGraph.Model
{
	public class DictionaryModelCollection<T> : DictionaryModelEnumerable<T>, IIdCollection<T> where T : IId
	{
		public DictionaryModelCollection(IEnumerable<T> models) : base(models)
		{
		}

		public DictionaryModelCollection() : base(new T[] {})
		{
		}

		public void Add(T model)
		{
			_models.Add(model.Id, model);
		}

		public void Remove(object id)
		{
			_models.Remove(id);
		}
	}
}
