namespace Hasse.Groups.Heavy.Product{
	public sealed class ProductGroup<TU,TV> : Group<ProductElement<TU,TV>> where TU : GroupElement<TU> where TV : GroupElement<TV>{
		public ProductGroup(Group<TU> left, Group<TV> right) : base(left.Order * right.Order) {
			_elements = new ProductElement<TU, TV>[Order];
			for(uint i = 0; i < left.Order; i++)
				for(uint j = 0; j < right.Order; j++)
					_elements[i * right.Order + j] = Multiply(left[i], right[j]);
		}

	    private ProductElement<TU,TV> Multiply(TU left, TV right){
			return new ProductElement<TU,TV>(left, right);
		}

	    readonly ProductElement<TU,TV>[] _elements;

		public override ProductElement<TU, TV> GetElement(uint index){
			return _elements[index];
		}
	}
}

