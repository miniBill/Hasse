using System;
using Hasse.Groups.Generic;

namespace Hasse.Groups.Product{
	public class PowerGroup<T> : Group<PowerElement<T>> where T : GroupElement<T>{
		public Group<T> Group{get; private set;}
		public int Power{get; private set;}

		public PowerGroup(Group<T> group, int power){
			Group = group;
			Power = power;
		}

		public override PowerElement<T> GetElement(int index){
			T[] values = new T[Power];
			for(int i = 0; i < Power; i++){
				values[i] = Group[index % Group.Order];
				index /= Group.Order;
			}
			return new PowerElement<T>(values);
		}

		public override int Order{
			get{
				return Pow(Group.Order, Power);
			}
		}

		public static int Pow(int x, int exp){
			if(exp == 0)
				return 1;

			int result = 1;
			while(exp > 0){
				if((exp & 1) != 0)
					result *= x;
				x *= x;
				exp /= 2;
			}
			return result;
		}
	}
}
