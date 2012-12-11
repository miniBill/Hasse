using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hasse.Groups.Heavy {
	public class SubGroup<T> : ISubGroup<SubGroup<T>>, IContainer<SubGroup<T>> where T : GroupElement<T> {
		public override int GetHashCode(){
			unchecked{
			return ((_elements != null ? _elements.GetHashCode() : 0) * 397) ^ (Group != null ? Group.GetHashCode() : 0);}}

		protected Group<T> Group{
			get;
			private set;
		}

		public static bool operator ==(SubGroup<T> left, SubGroup<T> right) {
			return Equals(left, right);
		}

		public static bool operator !=(SubGroup<T> left, SubGroup<T> right) {
			return !Equals(left, right);
		}

		private readonly T[] _elements;

		public SubGroup(Group<T> group, IEnumerable<T> elements) {
			_elements = elements.ToArray();
			Group = group;
		}

		public uint Order {
			get {
				return (uint)_elements.Length;
			}
		}

		public bool Contains(uint index) {
			T element = Group.GetElement(index);
			return _elements.Any(el => el.Equals(element));
		}

		private bool Contains(T element) {
			return _elements.Any(el => el.Equals(element));
		}

		public bool IsSupersetOf(SubGroup<T> elements) {
			return elements._elements.All(Contains);
		}

		public override bool Equals(object obj) {
			var sobj = obj as SubGroup<T>;
			if(sobj == null)
				return false;
			return Equals(sobj);
		}

		public bool Equals(SubGroup<T> sobj) {
			return Contains(sobj._elements) && sobj.Contains(_elements);
		}

		private bool Contains(IEnumerable<T> elements) {
			return elements.All(Contains);
		}

		public override string ToString() {
			if(!IsSorted)
				Sort();
			var sb = new StringBuilder();
			sb.Append('{');
			if(_elements.Length > 0)
				sb.Append(_elements[0]);
			for(uint i = 1; i < Order; i++) {
				sb.Append(", ");
				sb.Append(_elements[i]);
			}
			sb.Append('}');
			return sb.ToString();
		}

		private void Sort() {
			Array.Sort(_elements, Compare);
		}

		private bool IsSorted {
			get {
				for(int i = 0; i < _elements.Length - 1; i++)
					if(Compare(_elements[i], _elements[i + 1]) == 1)
						return false;
				return true;
			}
		}

		private int Compare(T left, T right) {
			return left.Compare(right);
		}

		public SubGroup<T> Generate(uint index){
			T gen = Group[index];
			return Generate(gen);
		}

		public SubGroup<T> Generate(T element){
			var elements = GenerateElements(element);
			return Group.BuildSubgroup(elements);
		}

		protected List<T> GenerateElements(T element){
			var elements = new List<T>();
			elements.AddRange(_elements);
			elements.AddIfNotContained(element);
			bool changed;
			do{
				var snapshot = elements.ToArray();
				changed = snapshot
					.Aggregate(false, (current1, left) => snapshot.Select(right => left * right)
						.Aggregate(current1, (current, res) => current | elements.AddIfNotContained(res))
						);
			} while(changed);
			return elements;
		}
	}
}
