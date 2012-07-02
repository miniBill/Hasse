using System;
using System.Collections.Generic;
using Hasse.Groups;

namespace Hasse.Groups{
	public interface ISubGroup<TSub> : IEquatable<TSub>{
		bool Contains(uint element);

		uint Order{get;}

		TSub Generate(uint element);
	}
}
