using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hasse.Groups;
using Hasse.Groups.Product;

namespace Hasse{
	public class AbstractWrapper<T,U> : IEnumerable<IGrouping<int,ISubGroup<T,U>>> where U : GroupElement<U>{
		private IEnumerable<IGrouping<int,SubGroup<PowerElement<U>>>> list;

		public AbstractWrapper(IEnumerable<IGrouping<int,SubGroup<PowerElement<U>>>> list){
			this.list = list;
		}

		public IEnumerator<IGrouping<int, ISubGroup<T,U>>> GetEnumerator(){
			foreach(var el in list)
				yield return new AbstractGrouping(el);
		}

		private class AbstractGrouping : IGrouping<int, ISubGroup<T,U>>{
			private IGrouping<int, SubGroup<PowerElement<U>>> wrapped;

			public AbstractGrouping(IGrouping<int, SubGroup<PowerElement<U>>> wrapped){
				this.wrapped = wrapped;
			}

			public int Key{
				get{
					return wrapped.Key;
				}
			}

			public IEnumerator<ISubGroup<T,U>> GetEnumerator(){
				foreach(var el in wrapped)
					yield return new InnerWrapper<T,U>(el);
			}

			private class InnerWrapper<T, U> : ISubGroup<T, U>{
				object wrapped;

				public InnerWrapper(object wrapped){
					this.wrapped = wrapped;
				}

				public bool Contains(int element){
					throw new NotImplementedException();
				}

				public bool Contains(IEnumerable<U> elements){
					throw new NotImplementedException();
				}

				public T Generate(int element){
					throw new NotImplementedException();
				}

				public int Order{
					get{
						throw new NotImplementedException();
					}
				}

				public bool Equals(T other){
					throw new NotImplementedException();
				}

				public IEnumerator<U> GetEnumerator(){
					throw new NotImplementedException();
				}

				IEnumerator IEnumerable.GetEnumerator(){
					return GetEnumerator();
				}
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
