using System;
using System.Collections.Generic;

namespace Hasse.Groups{
	public abstract class LightGroup : IExpableGroup<LightSubGroup, LightPowerGroup>{
		private int order;

		public int Order{
			get{
				return order;
			}
		}

		public LightPowerGroup Power(int power){
			throw new NotImplementedException();//return new LightPowerGroup(this, power);
		}

		public LightSubGroup Generate(int gen){
			var generated = new List<int>();
			int curr = 0;
			while(!generated.Contains(curr)){
				generated.Add(curr);
				curr = Multiply(curr, gen);
			}
			return new LightSubGroup(this, generated);
		}

		public abstract int Multiply(int left, int right);

		public abstract string ToString(int index);

		public abstract string ToString(IEnumerable<int> indexes);

		public LightGroup(int order){
			this.order = order;
		}
	}
}
