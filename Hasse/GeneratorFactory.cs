using System;
using Hasse.Groups;

namespace Hasse{
	public class GeneratorFactory{
		public static Generator<LightSubGroup,int> Create(LightGroup group){
			return new Generator<LightSubGroup, int>(group);
		}

		public static Generator<SubGroup<T>,T> Create<T>(Group<T> group) where T : GroupElement<T>{
			return new Generator<SubGroup<T>, T>(group);
		}
	}
}
