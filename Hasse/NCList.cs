using System;
using System.Collections.Generic;

namespace Hasse{
	public class NCList<T> : IEnumerable<T> where T : IEquatable<T>{
		public NCList(){
		}

		List<T> backend = new List<T>();

		public void Add(T item){
			backend.Add(item);
		}

		public void AddRange(IEnumerable<T> items){
			backend.AddRange(items);
		}

		public bool Contains(T item){
			foreach(var el in this)
				if(item.Equals(el))
					return true;
			return false;
		}

		public IEnumerator<T> GetEnumerator(){
			return backend.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
			return GetEnumerator();
		}
	}
}
