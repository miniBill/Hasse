using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hasse.Groups.Heavy.Permutation {
	public class SymmetricGroup : Group<SymmetricElement> {
		private uint Size {
			get;
			set;
		}

		public SymmetricGroup(uint size)
			: base(MyMath.Factorial(size)) {
			Size = size;
			_elements = new SymmetricElement[Order];
			for(uint i = 0; i < Order; i++) {
				var curr = new uint[Size];
				uint curval = i;
				for(uint j = 0; j < Size; j++) {
					uint curmod = curval % (Size - j);
					curval = curval / (Size - j);
					uint val = 0;
					while(Contains(curr, j, val))
						val++;
					for(uint k = 0; k < curmod; k++) {
						val++;
						while(Contains(curr, j, val))
							val++;
					}
					curr[j] = val;
				}
				_elements[i] = new SymmetricElement(curr);
			}
		}

		public NamedSubGroup<SymmetricElement> ParseSubGroup(string input) {
			input = input.Trim();
			string name;
			int equalIndex = input.IndexOf('=');
			// ReSharper disable ConvertIfStatementToConditionalTernaryExpression
			if(equalIndex >= 0)
				// ReSharper restore ConvertIfStatementToConditionalTernaryExpression
				name = input.Substring(0, equalIndex).Trim();
			else
				name = input;
			string rest = input.Substring(equalIndex + 1).Trim();
			if(rest.StartsWith("<"))
				return ParseGeneratedSubGroup(name, rest.Substring(1, rest.Length - 2));
			throw new NotImplementedException();
		}

		private NamedSubGroup<SymmetricElement> ParseGeneratedSubGroup(string name, string generatorString) {
			var generators = generatorString.Split(',').Select(gen => gen.Trim());
			var parsedGenerators = generators.Select(ParseElement);
			var toret = new NamedSubGroup<SymmetricElement>(name, this, new SymmetricElement[0]);
			return parsedGenerators.Aggregate(toret, (curr, parsedGenerator) => curr.Generate(parsedGenerator));
		}

		private SymmetricElement ParseElement(string input) {
			var elements = new uint[Size];
			for(uint i = 0; i < Size; i++)
				elements[i] = i;
			string trimmed = input.Substring(1, input.Length - 2);
			while(trimmed.Contains(") "))
				trimmed = trimmed.Replace(") ", ")");
			string[] cycles = trimmed.Split(new[] { ")(" }, StringSplitOptions.RemoveEmptyEntries);
			foreach(var cycle in cycles) {
				if(cycle.Length == 0)
					continue;
				string[] split = cycle.Split(' ');
				uint last = Convert.ToUInt32(split[0]) - 1;
				for(int i = 1; i < split.Length; i++) {
					uint curr = Convert.ToUInt32(split[i]) - 1;
					elements[last] = curr;
					last = curr;
				}
				elements[last] = Convert.ToUInt32(split[0]) - 1;
			}
			return new SymmetricElement(elements);
		}

		bool Contains(uint[] arr, uint maxindex, uint value) {
			for(uint j = 0; j < maxindex; j++)
				if(arr[j] == value)
					return true;
			return false;
		}

		readonly SymmetricElement[] _elements;

		public override SymmetricElement GetElement(uint index) {
			return _elements[index];
		}

		public override string ToString() {
			var sb = new StringBuilder();
			sb.Append('{');
			if(_elements.Length > 0)
				sb.Append(_elements[0]);
			for(int i = 1; i < Order; i++) {
				sb.Append(", ");
				sb.Append(_elements[i]);
			}
			sb.Append('}');
			return sb.ToString();
		}

		public override IEnumerator<SymmetricElement> GetEnumerator() {
			return _elements.AsEnumerable().GetEnumerator();
		}
	}
}

