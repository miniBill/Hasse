using System;
using System.Collections.Generic;
using System.Linq;
using Hasse.Groups;

namespace Hasse{
	public class WrapperFactory{
		public static IEnumerable<IGrouping<int,IISubGroup<TElem>>> CreateWrapper<TSub, TElem>(IEnumerable<IGrouping<int,TSub>> list) where TSub : IISubGroup<TElem>{
			return new AbstractWrapper<TSub, TElem>(list);
		}
	}
}
