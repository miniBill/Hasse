using System;
using System.Collections;
using System.Collections.Generic;

namespace Hasse.Groups.Light{
	public class SubGroup : ISubGroup<SubGroup>, IContainer<SubGroup>{
		private SortedSet<uint> backend = new SortedSet<uint>();
		private Group group;

		public SubGroup(Group group, SortedSet<uint> elements){
			this.group = group;
			backend = elements;
		}

		public bool IsSupersetOf(SubGroup other) {
			return backend.IsSupersetOf(other.backend);
		}

		public uint Order{
			get{
				return (uint)backend.Count;
			}
		}

		public SubGroup Generate(uint gen){
			SortedSet<uint> elements = new SortedSet<uint>();
			elements.AddRange(elements);
			foreach(var element in backend){
				uint curr = 0;
				do{
					uint resr = group.Multiply(element,curr);
					elements.Add(resr);
					uint resl = group.Multiply(curr,element);
					elements.Add(resl);
					curr = group.Multiply(curr, gen);
				}while(curr != 0);
			}
			return new SubGroup(group, elements);
		}

		public bool Contains(uint element){
			return backend.Contains(element);
		}

		public bool Equals(SubGroup other){
			if(other.backend.Count != backend.Count)
				return false;
			var els = backend.GetEnumerator();
			var ots = other.backend.GetEnumerator();
			while(els.MoveNext() && ots.MoveNext())
				if(els.Current != ots.Current)
					return false;
			return !els.MoveNext() && !ots.MoveNext();
		}

		public override string ToString(){
			return group.ToString(backend);
		}
	}
}
