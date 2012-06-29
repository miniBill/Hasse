using System;
using System.Collections.Generic;
using System.Linq;
using Hasse.Groups;
using Hasse.Groups.Product;

namespace Hasse{
	public class AbstractWrapper<T> : IEnumerable<IGrouping<int,ISubGroup>> where T : GroupElement<T>{
		private List<IGrouping<int,SubGroup<PowerElement<T>>>> list;

		public AbstractWrapper(List<IGrouping<int,SubGroup<PowerElement<T>>>> list){
			this.list = list;
		}

		public IEnumerator<IGrouping<int, ISubGroup>> GetEnumerator(){
			foreach(var el in list)
				yield return new AbstractGrouping(el);
		}

		private class AbstractGrouping : IGrouping<int, ISubGroup>{
			private IGrouping<int, SubGroup<PowerElement<T>>> wrapped;

			public AbstractGrouping(IGrouping<int, SubGroup<PowerElement<T>>> wrapped){
				this.wrapped = wrapped;
			}

			public int Key{
				get{
					return wrapped.Key;
				}
			}

			public IEnumerator<ISubGroup> GetEnumerator(){
				foreach(var el in wrapped)
					yield return el;
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
				return GetEnumerator();
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
			return GetEnumerator();
		}
	}
}
