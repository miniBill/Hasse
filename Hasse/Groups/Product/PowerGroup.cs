using System;

namespace Hasse.Groups.Product{
	public class PowerGroup<T> : Group<PowerElement<T>> where T : GroupElement<T>{
		public Group<T> Group{get; private set;}
		public int Power{get; private set;}

		public PowerGroup(Group<T> group, int power){
			Group = group;
			Power = power;
		}

		public override PowerElement<T> GetElement(int index){
			throw new NotImplementedException();
		}

		public override int Order{
			get{
				throw new NotImplementedException();
			}
		}
		#endregion
	}
}

