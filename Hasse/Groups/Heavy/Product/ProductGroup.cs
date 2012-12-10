using System.Collections.Generic;
using System.Linq;

namespace Hasse.Groups.Heavy.Product {
    public sealed class ProductGroup<TLeft, TRight> : Group<ProductElement<TLeft, TRight>>
        where TLeft : GroupElement<TLeft>
        where TRight : GroupElement<TRight> {
        public ProductGroup(Group<TLeft> left, Group<TRight> right)
            : base(left.Order * right.Order) {
            _elements = new ProductElement<TLeft, TRight>[Order];
            for(uint i = 0; i < left.Order; i++)
                for(uint j = 0; j < right.Order; j++)
                    _elements[i * right.Order + j] = Multiply(left[i], right[j]);
        }

        private ProductElement<TLeft, TRight> Multiply(TLeft left, TRight right) {
            return new ProductElement<TLeft, TRight>(left, right);
        }

        readonly ProductElement<TLeft, TRight>[] _elements;

        public override ProductElement<TLeft, TRight> GetElement(uint index) {
            return _elements[index];
        }

        public override IEnumerator<ProductElement<TLeft, TRight>> GetEnumerator() {
            return _elements.AsEnumerable().GetEnumerator();
        }
    }
}

