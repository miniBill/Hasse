using System;
using System.Collections.Generic;
using System.Linq;
using Hasse.Groups;
using Hasse.Groups.Heavy;
using Hasse.Groups.Heavy.Product;
using Hasse.Groups.Heavy.Permutation;

namespace Hasse{
	public class WrapperFactory{
		public static IEnumerable<IGrouping<int,ISubGroup<T,U>>> CreateWrapper<T,U>(IEnumerable<IGrouping<int,SubGroup<PowerElement<U>>>> list) where U : GroupElement<U>{
			return new AbstractWrapper<T, U>(list);
		}
	}
}
