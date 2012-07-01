using System;
using System.Collections.Generic;

namespace Hasse.Groups{
	public interface IISubGroup<T> : IEnumerable<T>{
		bool Contains(IEnumerable<T> elements);
	}
}
