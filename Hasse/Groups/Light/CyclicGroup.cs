using System.Text;
using System.Collections.Generic;

namespace Hasse.Groups.Light{
	public class CyclicGroup : Group{
		public CyclicGroup(uint order) : base(order){
		}

		public override uint Multiply(uint left, uint right){
			return (left + right) % Order;
		}

		public virtual string ToString(uint index){
			return string.Format("{0}_{1}", index, Order);
		}

		public override string ToString(IEnumerable<uint> indexes){
			var sb = new StringBuilder();
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
