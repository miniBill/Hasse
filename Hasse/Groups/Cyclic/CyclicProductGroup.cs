using System;
using Hasse.Groups.Product;

namespace Hasse.Groups.Cyclic{
	public class CyclicProductGroup : ProductGroup<CyclicElement, CyclicElement>{
		public CyclicProductGroup(CyclicGroup left, CyclicGroup right) : base(left, right){	}

		protected override ProductElement<CyclicElement, CyclicElement> Multiply(CyclicElement left, CyclicElement right){
			return new CyclicProductElement(left, right);
		}
	}
}
