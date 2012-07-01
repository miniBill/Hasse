using System;
using System.Collections.Generic;

namespace Hasse.Groups.Light{
	public abstract class Group : IExpableGroup<SubGroup, PowerGroup>{
		private int order;

		public int Order{
			get{
				return order;
			}
		}

		public PowerGroup Power(int power){
			return new PowerGroup(this, power);
		}

		public SubGroup Generate(int gen){
			var generated = new List<int>();
			int curr = 0;
			while(!generated.Contains(curr)){
				generated.Add(curr);
				curr = Multiply(curr, gen);
			}
			return new SubGroup(this, generated);
		}

		public abstract int Multiply(int left, int right);

		public abstract string ToString(int index);

		public abstract string ToString(IEnumerable<int> indexes);

		public Group(int order){
			this.order = order;
		}
	}
}
