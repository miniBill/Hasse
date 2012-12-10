using System.Linq;

namespace Hasse.Groups.Heavy.Product {
	// ReSharper disable PossibleInfiniteInheritance
	public class PowerGroup<T> : Group<PowerElement<T>> where T : GroupElement<T> {
		// ReSharper restore PossibleInfiniteInheritance
		private Group<T> Group {
			get;
			set;
		}

		private new uint Power {
			get;
			set;
		}

		public PowerGroup(Group<T> group, uint power)
			: base(MyMath.Pow(group.Order, power)) {
			Group = group;
			Power = power;
			_elements = new PowerElement<T>[Order];
			for(uint index = 0; index < Order; index++) {
				uint curr = index;
				var values = new T[Power];
				for(uint i = 0; i < Power; i++) {
					values[i] = Group[curr % Group.Order];
					curr /= Group.Order;
				}
				_elements[index] = new PowerElement<T>(values);
			}
		}

		private readonly PowerElement<T>[] _elements;

		public override PowerElement<T> GetElement(uint index) {
			return _elements[index];
		}

		public override string ToString() {
			return string.Format("{0}^{1}", Group, Power);
		}

		public override System.Collections.Generic.IEnumerator<PowerElement<T>> GetEnumerator() {
			return _elements.AsEnumerable().GetEnumerator();
		}
	}
}
