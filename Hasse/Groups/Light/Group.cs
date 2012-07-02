using System;
using System.Collections.Generic;

namespace Hasse.Groups.Light{
	public abstract class Group : IGroup<SubGroup>{
		private uint order;

		public uint Order{
			get{
				return order;
			}
		}

		public PowerGroup Power(uint power){
			return new PowerGroup(this, power);
		}

		public SubGroup Generate(uint gen){
			var generated = new SortedSet<uint>();
			uint curr = 0;
			while(!generated.Contains(curr)){
				generated.Add(curr);
				curr = Multiply(curr, gen);
			}
			return new SubGroup(this, generated);
		}

		public abstract uint Multiply(uint left, uint right);

		public abstract string ToString(uint index);

		public abstract string ToString(IEnumerable<uint> indexes);

		public Group(uint order){
			this.order = order;
		}
	}
}
