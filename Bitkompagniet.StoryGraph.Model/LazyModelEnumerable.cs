using System;
using System.Collections;
using System.Collections.Generic;

namespace Bitkompagniet.StoryGraph.Model
{
	public class LazyModelEnumerable<T> : IIdEnumerable<T> where T : IId
	{
        private Lazy<DictionaryModelEnumerable<T>> _lazyModels;

        public LazyModelEnumerable(Func<IEnumerable<T>> fx)
        {
            _lazyModels = new Lazy<DictionaryModelEnumerable<T>>(
                () => new DictionaryModelEnumerable<T>(fx())
            );
        }

		public bool Exists(object id) => _lazyModels.Value.Exists(id);

		public T Get(object id) => _lazyModels.Value.Get(id);

		public IEnumerator<T> GetEnumerator() => _lazyModels.Value.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
