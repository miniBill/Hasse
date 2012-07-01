using System;
using System.Text;
using System.Collections.Generic;

namespace Hasse.Groups.Cyclic{
	public class CyclicGroup : LightGroup{
		public CyclicGroup(int order) : base(order){
		}

		public override int Multiply(int left, int right){
			return (left + right) % Order;
		}

		public override string ToString(int index){
			return string.Format("{0}_{1}", index, Order);
		}

		public override string ToString(IEnumerable<int> indexes){
			StringBuilder sb = new StringBuilder();
			sb.Append('{');
			var enumerator = indexes.GetEnumerator();
			if(enumerator.MoveNext())
				for(;;){
					sb.Append(enumerator.Current);
					if(enumerator.MoveNext())
						sb.Append(", ");
					else
						break;
				}
			sb.Append("}_");
			if(Order > 0)
				sb.Append(Order);
			else
				sb.Append('?');
			return sb.ToString();
		}
	}
}
