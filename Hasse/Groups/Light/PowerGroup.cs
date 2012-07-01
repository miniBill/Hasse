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
			throw new NotImplementedException();
		}

		public override string ToString(int index){
			throw new NotImplementedException();
		}

		public override string ToString(System.Collections.Generic.IEnumerable<int> indexes){
			throw new NotImplementedException();
		}
	}
}
