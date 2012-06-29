using System;
using System.Text;

namespace Hasse.Groups.Permutation{
	public class SymmetricElement : GroupElement<SymmetricElement>{
		private int[] Value{get;set;}

		public SymmetricElement(int[] value){
			Value = value;
		}

		public override SymmetricElement Multiply(SymmetricElement other){
			int[] res = new int[Value.Length];
			for(int i = 0; i < Value.Length; i++)
				res[i] = other.Value[Value[i]];
			return new SymmetricElement(res);
		}

		public override bool Equals(object obj){
			var pobj = obj as SymmetricElement;
			if(pobj == null)
				return false;
			for(int i = 0; i < Value.Length; i++)
				if(Value[i] != pobj.Value[i])
					return false;
			return true;
		}

		public override int GetHashCode(){
			int toret = 0;
			for(int i = 0; i < Value.Length; i++){
				toret *= Value.Length;
				toret += Value[i];
			}
			return toret;
		}

		public override string ToString(){
			bool[] done = new bool[Value.Length];
			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < Value.Length; i++)
				if(!done[i] && Value[i] != i){
					sb.Append('(');
					sb.Append(i + 1);
					for(int curr = Value[i]; curr != i; curr=Value[curr]){
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
