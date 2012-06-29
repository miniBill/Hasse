using System;

namespace Hasse.Groups{
	public class ProductElement<U,V> : GroupElement<ProductElement<U,V>> where U : GroupElement<U> where V : GroupElement<V>{
		private U left;
		private V right;

		public ProductElement(U left, V right){
			this.left = left;
			this.right = right;
		}

		public override bool Equals(object obj){
			var pobj = obj as ProductElement<U,V>;
			if(pobj == null)
				return false;
			return pobj.left.Equals(left) && pobj.right.Equals(right);
		}

		public override ProductElement<U, V> Multiply(ProductElement<U, V> other){
			return new ProductElement<U, V>(left * other.left, right * other.right);
		}

		public override int GetHashCode(){
			return left.GetHashCode() ^ right.GetHashCode();
		}

		public override string ToString(){
			return string.Format("({0},{1})", left, right);
		}
	}
}
