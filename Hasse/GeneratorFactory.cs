using System;
using Heavy = Hasse.Groups.Heavy;
using Light = Hasse.Groups.Light;

namespace Hasse{
	public class GeneratorFactory{
		public static Generator<Light.SubGroup> Create(Light.Group group){
			return new Generator<Light.SubGroup>(group);
		}

		public static Generator<Heavy.SubGroup<T>> Create<T>(Heavy.Group<T> group) where T : Heavy.GroupElement<T>{
			return new Generator<Heavy.SubGroup<T>>(group);
		}
	}
}
