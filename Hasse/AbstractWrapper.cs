using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hasse.Groups;

namespace Hasse{
	public class AbstractWrapper<TSub,TElem> : IEnumerable<IGrouping<int,IContainer<TElem>>> where TSub : IContainer<TElem>{
		private IEnumerable<IGrouping<int,TSub>> list;

		public AbstractWrapper(IEnumerable<IGrouping<int,TSub>> list){
			this.list = list;
		}

		public IEnumerator<IGrouping<int, IContainer<TElem>>> GetEnumerator(){
			foreach(var el in list)
				yield return new AbstractGrouping(el);
		}

		private class AbstractGrouping : IGrouping<int, IContainer<TElem>>{
			private IGrouping<int, TSub> wrapped;

			public AbstractGrouping(IGrouping<int, TSub> wrapped){
				this.wrapped = wrapped;
			}

			public int Key{
				get{
					return wrapped.Key;
				}
			}

			public IEnumerator<IContainer<TElem>> GetEnumerator(){
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
