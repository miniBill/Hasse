using System;

namespace Hasse.Groups.Heavy {
	public abstract class GroupElement<T> : IEquatable<T> where T : GroupElement<T> {
		public T Explode(){
			return (T)this; //TODO: Fix
		}

		public GroupElement<T> Implode(){
			return this;
		}

		protected abstract T Multiply(T other);

		public abstract GroupElement<T> Inverse();

		public static T operator *(GroupElement<T> left, T right){
			return left.Multiply(right);
		}

		public static T operator ^(GroupElement<T> element, GroupElement<T> exponent){
			var a = exponent.Inverse();
			var b = element.Explode();
			var c = exponent.Explode();
			var left = (a * b).Implode();
			return left * c;
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
