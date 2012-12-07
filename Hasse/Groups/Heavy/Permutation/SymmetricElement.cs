using System.Text;

namespace Hasse.Groups.Heavy.Permutation{
	public class SymmetricElement : GroupElement<SymmetricElement>{
		private uint[] Value{get;set;}

		public SymmetricElement(uint[] value){
			Value = value;
		}

	    protected override SymmetricElement Multiply(SymmetricElement other){
			var res = new uint[Value.Length];
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
			foreach(uint element in Value) {
			    toret *= Value.Length;
			    toret += (int)element;
			}
			return toret;
		}

		public override string ToString(){
			var done = new bool[Value.Length];
			var sb = new StringBuilder();
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
