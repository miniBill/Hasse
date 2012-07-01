using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hasse.Groups.Heavy{
	public class SubGroup<T> : ISubGroup<SubGroup<T>,T> where T : GroupElement<T>{
		private T[] elements;

		public SubGroup(Group<T> group, IEnumerable<T> elements){
			this.elements = elements.ToArray();
			this.group = group;
		}

		public int Order{
			get{
				return elements.Length;
			}
		}

		private Group<T> group;

		public bool Contains(int index){
			T element = group.GetElement(index);
			foreach(var el in elements)
				if(el.Equals(element))
					return true;
			return false;
		}

		public bool Contains(T element){
			foreach(var el in elements)
				if(el.Equals(element))
					return true;
			return false;
		}

		public bool Contains(IEnumerable<T> elements){
			foreach(var el in elements)
				if(!Contains(el))
					return false;
			return true;
		}

		public IEnumerator<T> GetEnumerator(){
			foreach(var el in elements)
				yield return el;
		}

		IEnumerator IEnumerable.GetEnumerator(){
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
			return Equals(sobj);
		}

		public bool Equals(SubGroup<T> sobj){
			return Contains(sobj.elements) && sobj.Contains(elements);
		}

		public bool Contains(T[] elements){
			foreach(var el in elements)
				if(!Contains(el))
					return false;
			return true;
		}

		public override string ToString(){
			StringBuilder sb = new StringBuilder();
			sb.Append('{');
			if(elements.Length > 0)
				sb.Append(elements[0]);
			for(int i = 1; i < Order; i++){
				sb.Append(", ");
				sb.Append(elements[i]);
			}
			sb.Append('}');
			return sb.ToString();
		}

		public override int GetHashCode(){
			return base.GetHashCode();
		}

		public SubGroup<T> Generate(int index){
			NCList<T> elements = new NCList<T>();
			T gen = group[index];
			elements.AddRange(elements);
			foreach(var element in elements){
				T curr = group.Unity;
				do{
					T resr = element * curr;
					if(!elements.Contains(resr))
						elements.Add(resr);
					T resl = curr * element;
					if(!elements.Contains(resl))
						elements.Add(resl);
					curr *= gen;
				}while(!curr.Equals(group.Unity));
			}
			return group.BuildSubgroup(elements);
		}
	}
}
