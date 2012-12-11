using System;
using System.Collections.Generic;

namespace Hasse.Groups.Heavy{
	public class NamedSubGroup<T> : SubGroup<T> where T : GroupElement<T>{
		public string Name{
			get;
			private set;
		}

		public NamedSubGroup(string name, Group<T> group, IEnumerable<T> elements) : base(group, elements){
			Name = name;
		}

		public override string ToString(){
			return string.Format("{0}: Order {1}, Elements {2}", Name, Order, base.ToString());
		}

		public new NamedSubGroup<T> Generate(T element){
			var elements = GenerateElements(element);
			return new Hasse.Groups.Heavy.NamedSubGroup<T>(Name, Group, elements);
		}
	}
}

