using System;
using System.Text;

namespace Hasse.Groups.Heavy.Permutation{
	public class SymmetricElement : GroupElement<SymmetricElement>{
		private uint[] Value{get;set;}

		public SymmetricElement(uint[] value){
			Value = value;
		}

		public override SymmetricElement Multiply(SymmetricElement other){
			uint[] res = new uint[Value.Length];
			for(uint i = 0; i < Value.Length; i++)
				res[i] = other.Value[Value[i]];
			return new SymmetricElement(res);
		}

		public override bool Equals(SymmetricElement pobj){
			for(uint i = 0; i < Value.Length; i++)
				if(Value[i] != pobj.Value[i])
					return false;
			return true;
		}

		public override int GetHashCode(){
			int toret = 0;
			for(int i = 0; i < Value.Length; i++){
				toret *= Value.Length;
				toret += (int)Value[i];
			}
			return toret;
		}

		public override string ToString(){
			bool[] done = new bool[Value.Length];
			StringBuilder sb = new StringBuilder();
			for(uint i = 0; i < Value.Length; i++)
				if(!done[i] && Value[i] != i){
					sb.Append('(');
					sb.Append(i + 1);
					for(uint curr = Value[i]; curr != i; curr=Value[curr]){
						done[curr] = true;
						sb.Append(' ');
						sb.Append(curr + 1);
					}
					sb.Append(')');
				}
			if(sb.Length == 0)
				return "()";
			return sb.ToString();
		}
	}
}
