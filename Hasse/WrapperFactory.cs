using System;
using System.Collections.Generic;
using System.Linq;
using Hasse.Groups;

namespace Hasse{
	public class WrapperFactory{
		public static IEnumerable<IGrouping<int,IContainer<TElem, TSub>>> CreateWrapper<TSub, TElem>(IEnumerable<IGrouping<int,TSub>> list) where TSub : IContainer<TElem, TSub>{
			return new AbstractWrapper<TSub, TElem>(list);
		}
	}
}
