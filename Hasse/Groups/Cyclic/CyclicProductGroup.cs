using System;

namespace Hasse.Groups{
	public class CyclicProductGroup : ProductGroup<CyclicGroup, CyclicGroup>{
		public CyclicProductGroup(CyclicGroup left, CyclicGroup right) : base(left, right){	}
	}
}
