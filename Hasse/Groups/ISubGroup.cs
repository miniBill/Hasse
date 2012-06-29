using System;
using System.Collections.Generic;
using Hasse.Groups;

namespace Hasse.Groups{
	public interface ISubGroup : IEnumerable<IGroupElement>{
		bool Contains(IEnumerable<IGroupElement> elements);
	}
}
