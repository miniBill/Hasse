using System;
using System.Collections.Generic;

namespace Hasse.Groups{
	public interface IContainer<TSub>{
		bool IsSupersetOf(TSub elements);
	}
}
