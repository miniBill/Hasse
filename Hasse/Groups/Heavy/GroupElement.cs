using System;

namespace Hasse.Groups.Heavy {
	public abstract class GroupElement<T> : IEquatable<T> where T : class {
		protected abstract T Multiply(T other);

		public static T operator *(GroupElement<T> left, T right) {
			return left.Multiply(right);
		}

		public abstract int Compare(T other);

		sealed public override bool Equals(object obj) {
			var tobj = obj as T;
			if(tobj == null)
				return false;
			return Equals(tobj);
		}

		public abstract bool Equals(T obj);

		public abstract override int GetHashCode();
	}
}
