using System;

namespace Hasse.Groups.Light{
	public class PowerGroup : Group{
		private Group group;
		private int power;

		public PowerGroup(Group group, int power) : base(MyMath.Pow(group.Order, power)){
			this.group = group;
			this.power = power;
		}

		public override int Multiply(int left, int right){
			int res = 0;
			for(int i = 0; i < power; i++){
				res *= group.Order;
				res += group.Multiply(left % group.Order, right % group.Order);
				left /= group.Order;
				right /= group.Order;
			}
			int toret = 0;
			for(int i = 0; i < power; i++){
				toret *= group.Order;
				toret += res % group.Order;
				res /= group.Order;
			}
			return toret;
		}

		public override string ToString(int index){
			throw new NotImplementedException();
		}

		public override string ToString(System.Collections.Generic.IEnumerable<int> indexes){
			throw new NotImplementedException();
		}
	}
}
