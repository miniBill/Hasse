using System;

namespace Hasse.Groups.Product{
	public class PowerElement<T> : GroupElement<PowerElement<T>>{
		public T[] Elements{get; private set;}

		public PowerElement(T[] elements){
			Elements = elements;
		}
	}
}

