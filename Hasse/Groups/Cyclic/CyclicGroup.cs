using System;

namespace Hasse.Groups{
	public class CyclicGroup : Group<CyclicElement>{
		private int order;

		public override int Order{
			get{
				return order;
			}
		}

		public CyclicGroup(int order){
			this.order = order;
			elements = new CyclicElement[order];
			for(int i = 0; i < order; i++)
				elements[i] = new CyclicElement(i, order);
		}

		private CyclicElement[] elements;

		public override CyclicElement GetElement(int index){
			return elements[index];
		}

		public static CyclicProductGroup operator*(CyclicGroup left, CyclicGroup right){
			return new CyclicProductGroup(left, right);
		}
	}
}
