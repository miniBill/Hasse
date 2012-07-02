using System;
using System.Collections.Generic;
using Hasse.Groups.Heavy.Product;

namespace Hasse.Groups.Heavy{
	public abstract class Group<TElem> : IGroup<SubGroup<TElem>> where TElem : GroupElement<TElem>{
		public virtual SubGroup<TElem> BuildSubgroup(IEnumerable<TElem> elements){
			return new SubGroup<TElem>(this, elements);
		}

		public Group(int order){
			Order = order;
		}

		public int Order{get; private set;}

		public static Group<ProductElement<TElem,TElem>> operator*(Group<TElem> left, Group<TElem> right){
			return left.Multiply(right);
		}

		public PowerGroup<TElem> Power(int power){
			return new PowerGroup<TElem>(this, power);
		}

		public Group<ProductElement<TElem,V>> Multiply<V>(Group<V> other) where V : GroupElement<V>{
			return new ProductGroup<TElem,V>(this, other);
		}

		public TElem this[int index]{
			get{
				return GetElement(index);
			}
		}

		public TElem Unity{
			get{
				return this[0];
			}
		}

		public abstract TElem GetElement(int index);

		public SubGroup<TElem> Generate(int index){
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
