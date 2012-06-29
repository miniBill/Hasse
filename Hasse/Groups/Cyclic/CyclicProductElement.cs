using System;

namespace Hasse.Groups.Cyclic{
	public class CyclicProductElement : ProductElement<CyclicElement, CyclicElement>{
		public CyclicProductElement(CyclicElement left, CyclicElement right) : base(left, right) {	}

		public override string ToString(){
			if(Left.Order == Right.Order)
				return string.Format("({0},{1})_{2}", Left.Value, Right.Value, Left.Order);
			else
				return base.ToString();
		}
	}
}

