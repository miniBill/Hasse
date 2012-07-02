using System;
using System.Collections.Generic;
using Hasse.Groups.Heavy.Product;

namespace Hasse.Groups.Heavy{
	public abstract class Group<TElem> : IGroup<SubGroup<TElem>> where TElem : GroupElement<TElem>{
		public virtual SubGroup<TElem> BuildSubgroup(IEnumerable<TElem> elements){
			return new SubGroup<TElem>(this, elements);
		}

		public Group(uint order){
			Order = order;
		}

		public uint Order{get; private set;}

		public static Group<ProductElement<TElem,TElem>> operator*(Group<TElem> left, Group<TElem> right){
			return left.Multiply(right);
		}

		public PowerGroup<TElem> Power(uint power){
			return new PowerGroup<TElem>(this, power);
		}

		public Group<ProductElement<TElem,V>> Multiply<V>(Group<V> other) where V : GroupElement<V>{
			return new ProductGroup<TElem,V>(this, other);
		}

		public TElem this[uint index]{
			get{
				return GetElement(index);
			}
		}

		public TElem Unity{
			get{
				return this[0];
			}
		}

		public abstract TElem GetElement(uint index);

		public SubGroup<TElem> Generate(uint index){
			TElem gen = GetElement(index);
			var generated = new List<TElem>();
			TElem curr = Unity;
			while(!generated.Contains(curr)){
				generated.Add(curr);
				curr *= gen;
			}
			return BuildSubgroup(generated);
		}
	}
}
