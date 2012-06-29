using System;
using Hasse.Groups;

namespace Hasse{
	public class StandardGenerator<T> : Generator<T, SubGroup<T>> where T : GroupElement<T> {
		public StandardGenerator(Group<T> group) : base(group) { }
	}
}
