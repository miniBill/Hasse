using System;

namespace Hasse.Groups.Heavy.Product{
	public class PowerGroup<T> : Group<PowerElement<T>> where T : GroupElement<T>{
		public Group<T> Group{get; private set;}
		public new uint Power{get; private set;}

		public PowerGroup(Group<T> group, uint power) : base(MyMath.Pow(group.Order, power)){
			Group = group;
			Power = power;
			elements = new PowerElement<T>[Order];
			for(uint index = 0; index < Order; index++){
				uint curr = index;
				T[] values = new T[Power];
				for(uint i = 0; i < Power; i++){
					values[i] = Group[curr % Group.Order];
					curr /= Group.Order;
				}
				elements[index] = new PowerElement<T>(values);
			}
		}

		private PowerElement<T>[] elements;

		public override PowerElement<T> GetElement(uint index){
			return elements[index];
		}

		public override string ToString(){
			return string.Format("{0}^{1}", Group, Power);
		}
	}
}
