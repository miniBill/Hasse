using System;
using System.Collections.Generic;
using Hasse.Groups;

namespace Hasse{
	public class Generator<T,U> where T : ISubGroup<T,U>, IEquatable<T>{
		public IGroup<T> Group{get; private set;}

		public Generator(IGroup<T> group){
			Group=group;
		}

		public IEnumerable<T> Generate(){
			var generated = new NCList<T>();
			for(int i = 0; i < Group.Order; i++){
				T single = Group.Generate(i);
				if(!generated.Contains(single)){
					generated.Add(single);
					Generate(generated, single);
				}
			}
			return generated;
		}

		public void Generate(NCList<T> generated, T curr){
			for(int i = 0; i < Group.Order; i++){
				if(!curr.Contains(i)){
					T next = curr.Generate(i);
					if(!generated.Contains(next)){
						generated.Add(next);
						Generate(generated, next);
					}
				}
			}
		}
	}
}
