using System;

namespace Hasse.Groups{
	public interface IGroup{
	}

	public interface IGroup<TSub> : IGroup{
		int Order{get;}

		TSub Generate(int index);
	}
}
