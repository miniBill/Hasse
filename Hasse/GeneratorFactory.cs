using System;
using Hasse.Groups;

namespace Hasse{
	public class GeneratorFactory{
		public static Generator<T,W> Create<T,W>(Group<T> group) where T : GroupElement<T> where W : SubGroup<T>, new(){
			return new Generator<T,W>(group);
		}

		public static Generator<T,SubGroup<T>> Create<T>(Group<T> group) where T : GroupElement<T>{
			return new Generator<T,SubGroup<T>>(group);
		}
	}
}
