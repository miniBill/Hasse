using System;

namespace Hasse.Groups{
	public interface IExpableGroup<T, U> : IGroup<T>{
		U Power(int power);
	}
}
