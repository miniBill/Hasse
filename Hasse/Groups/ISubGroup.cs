using System;
using System.Collections.Generic;
using Hasse.Groups;

namespace Hasse.Groups{
	public interface ISubGroup<T,U> : IEnumerable<U>, IEquatable<T>{
		bool Contains(int element);

		bool Contains(IEnumerable<U> elements);

		int Order{get;}

		T Generate(int element);
	}
}
