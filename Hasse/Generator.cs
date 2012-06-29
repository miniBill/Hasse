using System;
using System.Collections.Generic;
using Hasse.Groups;

namespace Hasse{
	public class Generator<T, U> where T : GroupElement<T> where U : SubGroup<T>, new(){
		public Group<T> Group{get; private set;}

		public Generator(Group<T> group){
			Group=group;
		}

		public IEnumerable<U> Generate(){
			var generated = new List<U>();
			for(int i = 0; i < Group.Order; i++){
				U single = Generate(Group[i]);
				if(!generated.Contains(single)){
					generated.Add(single);
					Generate(generated, single);
				}
			}
			return generated;
		}

		public U Generate(T gen){
			var generated = new List<T>();
			T curr = Group.Unity;
			while(!generated.Contains(curr)){
				generated.Add(curr);
				curr *= gen;
			}
			return Build(generated);
		}

		public U Build(IEnumerable<T> generated){
			U toret = new U();
			toret.Setup(generated);
			return toret;
		}

		public void Generate(List<U> generated, U curr){
			for(int i = 0; i < Group.Order; i++){
				if(!curr.Contains(Group[i])){
					U next = Generate(curr, Group[i]);
					if(!generated.Contains(next)){
						generated.Add(next);
						Generate(generated, next);
					}
				}
			}
		}

		public U Generate(SubGroup<T> sub, T next){
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
