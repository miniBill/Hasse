using System;

namespace Hasse.Groups.Cyclic{
	public class CyclicElement : GroupElement<CyclicElement>{
		public int Value{get; private set;}
		public int Order{get; private set;}

		public CyclicElement(int value, int order){
			Value=value;
			Order=order;
		}

		public override CyclicElement Multiply(CyclicElement other){
			if(other.Order != Order)
				throw new CalcException("Multiplication by different order");
			return new CyclicElement((Value + other.Value) % Order, Order);
		}

		public static CyclicElement operator+(CyclicElement left, CyclicElement right){
			return left.Multiply(right);
		}

		public override bool Equals(object obj){
			CyclicElement cobj = obj as CyclicElement;
			if(cobj == null)
				return false;
			return Value == cobj.Value && Order == cobj.Order;
		}

		public override string ToString(){
			return string.Format("{0}_{1}", Value, Order);
		}

		public override int GetHashCode(){
			return Value ^ Order;
		}
	}
}
