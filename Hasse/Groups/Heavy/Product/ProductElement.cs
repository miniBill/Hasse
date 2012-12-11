namespace Hasse.Groups.Heavy.Product {
	public class ProductElement<TLeft, TRight> : GroupElement<ProductElement<TLeft, TRight>>
		where TLeft : GroupElement<TLeft>
		where TRight : GroupElement<TRight> {
		private TLeft Left {
			get;
			set;
		}

		private TRight Right {
			get;
			set;
		}

		public ProductElement(TLeft left, TRight right) {
			Left = left;
			Right = right;
		}

		public override int Compare(ProductElement<TLeft, TRight> other) {
			return 0;
		}

		public override bool Equals(ProductElement<TLeft, TRight> pobj) {
			return pobj.Left.Equals(Left) && pobj.Right.Equals(Right);
		}

		protected override ProductElement<TLeft, TRight> Multiply(ProductElement<TLeft, TRight> other) {
			return new ProductElement<TLeft, TRight>(Left * other.Left, Right * other.Right);
		}

		public override int GetHashCode() {
			return Left.GetHashCode() + Right.GetHashCode();
		}

		public override string ToString() {
			return string.Format("({0},{1})", Left, Right);
		}

		public override GroupElement<ProductElement<TLeft, TRight>> Inverse(){
			return new ProductElement<TLeft,TRight>(Left.Inverse().Explode(), Right.Inverse().Explode());
		}
	}
}
