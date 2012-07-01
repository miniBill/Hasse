using System;

namespace Hasse.Groups.Heavy.Product{
	public class ProductElement<U,V> : GroupElement<ProductElement<U,V>> where U : GroupElement<U> where V : GroupElement<V>{
		public U Left{get; private set;}
		public V Right{get; private set;}

		public ProductElement(U left, V right){
			Left = left;
			Right = right;
		}

		public override bool Equals(ProductElement<U,V> pobj){
			return pobj.Left.Equals(Left) && pobj.Right.Equals(Right);
		}

		public override ProductElement<U, V> Multiply(ProductElement<U, V> other){
			return new ProductElement<U, V>(Left * other.Left, Right * other.Right);
		}

		public override int GetHashCode(){
			return Left.GetHashCode() + Right.GetHashCode();
		}

		public override string ToString(){
			return string.Format("({0},{1})", Left, Right);
		}
	}
}
