using System;
using System.Collections.Generic;
using Hasse.Groups;

namespace Hasse{
	public class Generator<U, V> where U : GroupElement<U> where V : SubGroup<U>, new(){
		public Group<U> Group{get; private set;}

		public Generator(Group<U> group){
			Group=group;
		}

		public IEnumerable<V> Generate(){
			var generated = new List<V>();
			for(int i = 0; i < Group.Order; i++){
				V single = Generate(Group[i]);
				if(!generated.Contains(single)){
					generated.Add(single);
					Generate(generated, single);
				}
			}
			return generated;
		}

		public V Generate(U gen){
			var generated = new List<U>();
			U curr = Group.Unity;
			while(!generated.Contains(curr)){
				generated.Add(curr);
				curr *= gen;
			}
			return Build(generated);
		}

		public V Build(IEnumerable<U> generated){
			V toret = new V();
			toret.Setup(generated);
			return toret;
		}

		public void Generate(List<V> generated, V curr){
			for(int i = 0; i < Group.Order; i++){
				if(!curr.Contains(Group[i])){
					V next = Generate(curr, Group[i]);
					if(!generated.Contains(next)){
						generated.Add(next);
						Generate(generated, next);
					}
				}
			}
		}

		public V Generate(SubGroup<U> sub, U next){
			List<U> elements = new List<U>();
			elements.AddRange(sub);
			foreach(var element in sub){
				U curr = Group.Unity;
				do{
					U resr = element * curr;
					if(!elements.Contains(resr))
						elements.Add(resr);
					U resl = curr * element;
					if(!elements.Contains(resl))
						elements.Add(resl);
					curr *= next;
				}while(!curr.Equals(Group.Unity));
			}
			return Build(elements);
		}
	}
}
