using System;
using System.Text;

namespace Hasse.Groups.Heavy.Permutation {
	public class SymmetricElement : GroupElement<SymmetricElement> {
		private uint[] Value {
			get;
			set;
		}
		public SymmetricElement(uint[] value){
			Value = value;
		}

		protected override SymmetricElement Multiply(SymmetricElement other){
			var res = new uint[Value.Length];
			for(uint i = 0; i < Value.Length; i++)
				res[i] = other.Value[Value[i]];
			return new SymmetricElement(res);
		}

		public string ToLaTeX(){
			return ToString().Replace(" ", "\\,");
		}

		public override int Compare(SymmetricElement other) {
			if(CyclicCount < other.CyclicCount)
				return -1;
			if(CyclicCount > other.CyclicCount)
				return 1;
			if(CyclicLength < other.CyclicLength)
				return -1;
			if(CyclicLength > other.CyclicLength)
				return 1;
			return StringComparer.InvariantCulture.Compare(ToString(), other.ToString());
		}

		private int _cyclicLength = -1;

		private int CyclicLength {
			get {
				if(_cyclicLength < 0) {
					_cyclicLength = 0;
					var done = new bool[Value.Length];
					for(uint i = 0; i < Value.Length; i++)
						if(!done[i] && Value[i] != i) {
							_cyclicLength++;
							for(uint curr = Value[i]; curr != i; curr = Value[curr]) {
								_cyclicLength++;
								done[curr] = true;
							}
						}
				}
				return _cyclicLength;
			}
		}

		private int _cyclicCount = -1;

		private int CyclicCount {
			get {
				if(_cyclicCount < 0) {
					_cyclicCount = 0;
					var done = new bool[Value.Length];
					for(uint i = 0; i < Value.Length; i++)
						if(!done[i] && Value[i] != i) {
							_cyclicCount++;
							for(uint curr = Value[i]; curr != i; curr = Value[curr])
								done[curr] = true;
						}
				}
				return _cyclicCount;
			}
		}

		public override bool Equals(SymmetricElement pobj) {
			for(uint i = 0; i < Value.Length; i++)
				if(Value[i] != pobj.Value[i])
					return false;
			return true;
		}

		public override int GetHashCode() {
			int toret = 0;
			foreach(uint element in Value) {
				toret *= Value.Length;
				toret += (int)element;
			}
			return toret;
		}

		public override string ToString() {
			var done = new bool[Value.Length];
			var sb = new StringBuilder();
			for(uint i = 0; i < Value.Length; i++)
				if(!done[i] && Value[i] != i) {
					sb.Append('(');
					sb.Append(i + 1);
					for(uint curr = Value[i]; curr != i; curr = Value[curr]) {
						done[curr] = true;
						sb.Append(' ');
						sb.Append(curr + 1);
					}
					sb.Append(')');
				}
			if(sb.Length == 0)
				return "()";
			//sb.AppendFormat(" CC:{0} CL:{1}", CyclicCount, CyclicLength);
			return sb.ToString();
		}

		public override GroupElement<SymmetricElement> Inverse(){
			var toret = new uint[Value.Length];
			for(uint i = 0; i < Value.Length; i++)
				toret[Value[i]] = i;
			return new SymmetricElement(toret);
		}
	}
}
