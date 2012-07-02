using System;

namespace Hasse.Groups{
	public interface IGroup{
	}

	public interface IGroup<TSub> : IGroup{
		uint Order{get;}

		TSub Generate(uint index);
	}
}
