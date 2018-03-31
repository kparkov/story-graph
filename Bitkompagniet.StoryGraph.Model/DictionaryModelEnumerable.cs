using System.Collections;
using System.Collections.Generic;

namespace Bitkompagniet.StoryGraph.Model
{
	public class DictionaryModelEnumerable<T> : IIdEnumerable<T> where T : IId
	{
        protected readonly Dictionary<object, T> _models = new Dictionary<object, T>();

        public DictionaryModelEnumerable(IEnumerable<T> models)
        {
            foreach (var model in models) _models.Add(model.Id, model);
        }

		public bool Exists(object id) => _models.ContainsKey(id);

		public T Get(object id) => _models[id];

		public IEnumerator<T> GetEnumerator() => _models.Values.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
