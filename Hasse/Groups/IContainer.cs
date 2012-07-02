using System;
using System.Collections.Generic;

namespace Hasse.Groups{
	public interface IContainer<TElem> : IEnumerable<TElem>{
		bool Contains(IEnumerable<TElem> elements);
	}
}
