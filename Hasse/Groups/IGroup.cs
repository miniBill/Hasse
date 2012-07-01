using System;

namespace Hasse.Groups{
	public interface IGroup<T>{
		int Order{get;}

		T Generate(int index);
	}
}
