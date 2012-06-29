using System;
using Hasse.Groups.Generic;

namespace Hasse{
	public class GeneratorFactory{
		public static Generator<T> Create<T>(Group<T> group) where T : GroupElement<T>{
			return new Generator<T>(group);
		}
	}
}
