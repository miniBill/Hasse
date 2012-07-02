using System;
using System.Collections.Generic;
using Hasse.Groups;

namespace Hasse.Groups{
	public interface ISubGroup<TSub> : IEquatable<TSub>{
		bool Contains(int element);

		int Order{get;}

		TSub Generate(int element);
	}
}
