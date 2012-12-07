using System.Collections.Generic;

namespace Hasse.Groups.Light{
	public class SubGroup : ISubGroup<SubGroup>, IContainer<SubGroup>{
		private readonly SortedSet<uint> _backend = new SortedSet<uint>();
		private readonly Group _group;

		public SubGroup(Group group, SortedSet<uint> elements){
			_group = group;
			_backend = elements;
		}

		public bool IsSupersetOf(SubGroup other) {
			return _backend.IsSupersetOf(other._backend);
		}

		public uint Order{
			get{
				return (uint)_backend.Count;
			}
		}

		public SubGroup Generate(uint gen){
			var elements = new SortedSet<uint>();
			elements.AddRange(elements);
			foreach(var element in _backend){
				uint curr = 0;
				do{
					uint resr = _group.Multiply(element,curr);
					elements.Add(resr);
					uint resl = _group.Multiply(curr,element);
					elements.Add(resl);
					curr = _group.Multiply(curr, gen);
				}while(curr != 0);
			}
			return new SubGroup(_group, elements);
		}

		public bool Contains(uint element){
			return _backend.Contains(element);
		}

		public bool Equals(SubGroup other){
			if(other._backend.Count != _backend.Count)
				return false;
			var els = _backend.GetEnumerator();
			var ots = other._backend.GetEnumerator();
			while(els.MoveNext() && ots.MoveNext())
				if(els.Current != ots.Current)
					return false;
			return !els.MoveNext() && !ots.MoveNext();
		}

		public override string ToString(){
			return _group.ToString(_backend);
		}
	}
}
