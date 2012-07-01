using System;
using System.Collections.Generic;
using Hasse.Groups.Product;

namespace Hasse.Groups{
	public abstract class Group<T> : IExpableGroup<SubGroup<T>, PowerGroup<T>> where T : GroupElement<T>{
		public virtual SubGroup<T> BuildSubgroup(IEnumerable<T> elements){
			return new SubGroup<T>(this, elements);
		}

		public Group(int order){
			Order = order;
		}

		public int Order{get; private set;}

		public static Group<ProductElement<T,T>> operator*(Group<T> left, Group<T> right){
			return left.Multiply(right);
		}

		public PowerGroup<T> Power(int power){
			return new PowerGroup<T>(this, power);
		}

		public Group<ProductElement<T,V>> Multiply<V>(Group<V> other) where V : GroupElement<V>{
			return new ProductGroup<T,V>(this, other);
		}

		public T this[int index]{
			get{
				return GetElement(index);
			}
		}

		public T Unity{
			get{
				return this[0];
			}
		}

		public abstract T GetElement(int index);

		public SubGroup<T> Generate(int index){
			T gen = GetElement(index);
			var generated = new NCList<T>();
			T curr = Unity;
			while(!generated.Contains(curr)){
				generated.Add(curr);
				curr *= gen;
			}
			return BuildSubgroup(generated);
		}
	}
}
