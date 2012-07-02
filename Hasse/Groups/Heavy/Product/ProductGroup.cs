using System;

namespace Hasse.Groups.Heavy.Product{
	public class ProductGroup<U,V> : Group<ProductElement<U,V>> where U : GroupElement<U> where V : GroupElement<V>{
		public ProductGroup(Group<U> left, Group<V> right) : base(left.Order * right.Order) {
			elements = new ProductElement<U, V>[Order];
			for(uint i = 0; i < left.Order; i++)
				for(uint j = 0; j < right.Order; j++)
					elements[i * right.Order + j] = Multiply(left[i], right[j]);
		}

		protected virtual ProductElement<U,V> Multiply(U left, V right){
			return new ProductElement<U,V>(left, right);
		}

		ProductElement<U,V>[] elements;

		public override ProductElement<U, V> GetElement(uint index){
			return elements[index];
		}
	}
}

