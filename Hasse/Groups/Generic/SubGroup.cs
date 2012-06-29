using System;
using System.Collections.Generic;
using System.Linq;

namespace Hasse.Groups{
	public class SubGroup<T> : IEnumerable<T> where T : GroupElement<T>{
		private T[] elements;

		public SubGroup(IEnumerable<T> elements){
			this.elements = elements.ToArray();
		}

		public int Order{
			get{
				return elements.Length;
			}
		}

		public bool Contains(T element){
			foreach(var el in elements)
				if(el.Equals(element))
					return true;
			return false;
		}

		public bool Contains(IEnumerable<T> check){
			foreach(var el in check)
				if(!Contains(el))
					return false;
			return true;
		}

		public IEnumerator<T> GetEnumerator(){
			foreach(var el in elements)
				yield return el;
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
			return GetEnumerator();
		}

		public T this[int index]{
			get{
				return elements[index];
			}
		}

		public override bool Equals(object obj){
			SubGroup<T> sobj = obj as SubGroup<T>;
			if(sobj == null)
				return false;
			return Contains(sobj.elements) && sobj.Contains(elements);
		}

		public bool Contains(T[] elements){
			foreach(var el in elements)
				if(!Contains(el))
					return false;
			return true;
		}

		public virtual void Dump(){
			Console.Write('{');
			Console.Write(elements[0]);
			for(int i = 1; i < Order; i++){
				Console.Write(',');
				Console.Write(elements[i]);
			}
			Console.WriteLine('}');
		}
	}
}
