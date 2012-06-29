using System;

namespace Hasse.Groups{
	public abstract class GroupElement<T> where T : class{
		public abstract T Multiply(T other);

		public static T operator*(GroupElement<T> left, T right){
			return left.Multiply(right);
		}

		public abstract override bool Equals(object obj);

		public abstract override int GetHashCode();
	}
}
