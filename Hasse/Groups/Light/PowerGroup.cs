using System;

namespace Hasse.Groups.Light{
	public class PowerGroup : Group{
		private Group group;
		private uint power;

		public PowerGroup(Group group, uint power) : base(MyMath.Pow(group.Order, power)){
			this.group = group;
			this.power = power;
		}

		public override uint Multiply(uint left, uint right){
			uint res = 0;
			uint order = group.Order;
			for(uint i = 0; i < power; i++){
				res *= order;
				res += group.Multiply(left % order, right % order);
				left /= order;
				right /= order;
			}
			uint toret = 0;
			for(uint i = 0; i < power; i++){
				toret *= order;
				toret += res % order;
				res /= order;
			}
			return toret;
		}

		public override string ToString(uint index){
			throw new NotImplementedException();
		}

		public override string ToString(System.Collections.Generic.IEnumerable<uint> indexes){
			throw new NotImplementedException();
		}
	}
}
