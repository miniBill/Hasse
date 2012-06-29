using System;

namespace Hasse.Groups{
	public abstract class Group<T> where T : GroupElement<T>{
		public T this[int index]{
			get{
				return GetElement(index);
			}
		}

		public abstract T GetElement(int index);

		public T Unity{
			get{
				return this[0];
			}
		}

		public abstract int Order{get;}

		public static Group<ProductElement<T,T>> operator*(Group<T> left, Group<T> right){
			return left.Multiply(right);
		}

		public Group<ProductElement<T,V>> Multiply<V>(Group<V> other) where V : GroupElement<V>{
			return new ProductGroup<T,V>(this, other);
		}
	}
}
