using System;
using System.Collections.Generic;
using System.Text;

namespace Hasse.Groups.Cyclic{
	public class CyclicSubGroup : SubGroup<CyclicElement>{
		public CyclicSubGroup(IEnumerable<CyclicElement> elements) : base(elements) { }

		public override string ToString(){
			StringBuilder sb = new StringBuilder();
			sb.Append('{');
			if(Order > 0)
				sb.Append(this[0].Value);
			for(int i = 1; i < Order; i++){
				sb.Append(", ");
				sb.Append(this[i].Value);
			}
			sb.Append("}_");
			if(Order > 0)
				sb.Append(this[0].Order);
			else
				sb.Append('?');
			return sb.ToString();
		}
	}
}
