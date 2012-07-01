using System;

namespace Hasse.Groups.Product{
	public class ProductGroup<U,V> : Group<ProductElement<U,V>> where U : GroupElement<U> where V : GroupElement<V>{
		private Group<U> left;
		private Group<V> right;

		public ProductGroup(Group<U> left, Group<V> right) : base(left.Order * right.Order) {
			this.left = left;
			this.right = right;
			elements = new ProductElement<U, V>[Order];
			for(int i = 0; i < left.Order; i++)
				for(int j = 0; j < right.Order; j++)
					elements[i * right.Order + j] = Multiply(left[i], right[j]);
		}

		protected virtual ProductElement<U,V> Multiply(U left, V right){
			return new ProductElement<U,V>(left, right);
		}

		ProductElement<U,V>[] elements;

		public override ProductElement<U, V> GetElement(int index){
			return elements[index];
		}
	}
}

