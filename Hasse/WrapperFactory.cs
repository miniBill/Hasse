using System;
using System.Collections.Generic;
using System.Linq;
using Hasse.Groups;
using Hasse.Groups.Product;
using Hasse.Groups.Permutation;

namespace Hasse{
	public class WrapperFactory{
		public static IEnumerable<IGrouping<int,ISubGroup>> CreateWrapper<T>(List<IGrouping<int,SubGroup<PowerElement<T>>>> list) where T : GroupElement<T>{
			return new AbstractWrapper<T>(list);
		}
	}
}
