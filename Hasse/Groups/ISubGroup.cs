using System;
using System.Collections.Generic;
using Hasse.Groups;

namespace Hasse.Groups{
	public interface ISubGroup<T,U> : IEquatable<T>, IISubGroup<U>{
		bool Contains(int element);

		int Order{get;}

		T Generate(int element);
	}
}
