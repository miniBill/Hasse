using System;
using System.Collections.Generic;

namespace Hasse.Groups{
	public interface IContainer<TElem, TSub> : IEnumerable<TElem>{
		bool IsSupersetOf(TSub elements);
	}
}
