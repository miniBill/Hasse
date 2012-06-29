using System;
using Hasse.Groups;

namespace Hasse{
	public class GeneratorFactory{
		public static Generator<T> Create<T>(Group<T> group) where T : GroupElement<T>{
			return new Generator<T>(group);
		}
	}
}
