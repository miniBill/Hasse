using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hasse.Groups;

namespace Hasse{
	public class AbstractWrapper<TSub,TElem> : IEnumerable<IGrouping<int,IContainer<TElem,TSub>>> where TSub : IContainer<TElem, TSub>{
		private IEnumerable<IGrouping<int,TSub>> list;

		public AbstractWrapper(IEnumerable<IGrouping<int,TSub>> list){
			this.list = list;
		}

		public IEnumerator<IGrouping<int, IContainer<TElem, TSub>>> GetEnumerator(){
			foreach(var el in list)
				yield return new AbstractGrouping(el);
		}

		private class AbstractGrouping : IGrouping<int, IContainer<TElem, TSub>>{
			private IGrouping<int, TSub> wrapped;

			public AbstractGrouping(IGrouping<int, TSub> wrapped){
				this.wrapped = wrapped;
			}

			public int Key{
				get{
					return wrapped.Key;
				}
			}

			public IEnumerator<IContainer<TElem, TSub>> GetEnumerator(){
				foreach(var el in wrapped)
					yield return el;
			}

			IEnumerator IEnumerable.GetEnumerator(){
				return GetEnumerator();
			}
		}

		IEnumerator IEnumerable.GetEnumerator(){
			return GetEnumerator();
		}
	}
}
