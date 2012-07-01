using System;
using System.Collections;
using System.Collections.Generic;

namespace Hasse.Groups{
	public class LightSubGroup : ISubGroup<LightSubGroup,int>{
		private List<int> backend = new List<int>();
		private LightGroup group;

		public LightSubGroup(LightGroup group, IEnumerable<int> elements){
			this.group = group;
			backend.AddRange(elements);
		}

		public bool Contains(IEnumerable<int> elements){
			foreach(var el in elements)
				if(!backend.Contains(el))
					return false;
			return true;
		}

		public int Order{
			get{
				return backend.Count;
			}
		}

		public LightSubGroup Generate(int gen){
			List<int> elements = new List<int>();
			elements.AddRange(elements);
			foreach(var element in backend){
				int curr = 0;
				do{
					int resr = group.Multiply(element,curr);
					if(!elements.Contains(resr))
						elements.Add(resr);
					int resl = group.Multiply(curr,element);
					if(!elements.Contains(resl))
						elements.Add(resl);
					curr = group.Multiply(curr, gen);
				}while(curr != 0);
			}
			return new LightSubGroup(group, elements);
		}

		public bool Contains(int element){
			return backend.Contains(element);
		}

		public IEnumerator<int> GetEnumerator(){
			return backend.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator(){
			return GetEnumerator();
		}

		public bool Equals(LightSubGroup other){
			return Contains(other.backend) && other.Contains(backend);
		}

		public override string ToString(){
			return group.ToString(backend);
		}
	}
}
