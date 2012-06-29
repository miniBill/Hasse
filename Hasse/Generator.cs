using System;
using System.Collections.Generic;
using Hasse.Groups.Generic;

namespace Hasse{
	public class Generator<T> where T : GroupElement<T>{
		public Group<T> Group{get; private set;}

		public Generator(Group<T> group){
			Group=group;
		}

		public IEnumerable<SubGroup<T>> Generate(){
			var generated = new List<SubGroup<T>>();
			for(int i = 0; i < Group.Order; i++){
				SubGroup<T> single = Generate(Group[i]);
				if(!generated.Contains(single)){
					generated.Add(single);
					Generate(generated, single);
				}
			}
			return generated;
		}

		public SubGroup<T> Generate(T gen){
			var generated = new List<T>();
			T curr = Group.Unity;
			while(!generated.Contains(curr)){
				generated.Add(curr);
				curr *= gen;
			}
			return Build(generated);
		}

		public SubGroup<T> Build(IEnumerable<T> generated){
			return Group.BuildSubgroup(generated);
		}

		public void Generate(List<SubGroup<T>> generated, SubGroup<T> curr){
			for(int i = 0; i < Group.Order; i++){
				if(!curr.Contains(Group[i])){
					SubGroup<T> next = Generate(curr, Group[i]);
					if(!generated.Contains(next)){
						generated.Add(next);
						Generate(generated, next);
					}
				}
			}
		}

		public SubGroup<T> Generate(SubGroup<T> sub, T next){
			List<T> elements = new List<T>();
			elements.AddRange(sub);
			foreach(var element in sub){
				T curr = Group.Unity;
				do{
					T resr = element * curr;
					if(!elements.Contains(resr))
						elements.Add(resr);
					T resl = curr * element;
					if(!elements.Contains(resl))
						elements.Add(resl);
					curr *= next;
				}while(!curr.Equals(Group.Unity));
			}
			return Build(elements);
		}
	}
}
