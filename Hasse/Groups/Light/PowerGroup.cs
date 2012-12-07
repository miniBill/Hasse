using System;

namespace Hasse.Groups.Light{
	public sealed class PowerGroup : Group{
		private readonly Group _group;
		private readonly uint _power;

		public PowerGroup(Group group, uint power) : base(MyMath.Pow(group.Order, power)){
			_group = group;
			_power = power;
		}

		public override uint Multiply(uint left, uint right){
			uint res = 0;
			uint order = _group.Order;
			for(uint i = 0; i < _power; i++){
				res *= order;
				res += _group.Multiply(left % order, right % order);
				left /= order;
				right /= order;
			}
			uint toret = 0;
			for(uint i = 0; i < _power; i++){
				toret *= order;
				toret += res % order;
				res /= order;
			}
			return toret;
		}

	    public override string ToString(System.Collections.Generic.IEnumerable<uint> indexes){
			throw new NotImplementedException();
		}
	}
}
