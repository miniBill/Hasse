using System.Text;

namespace Hasse.Groups.Heavy.Permutation{
	public class SymmetricGroup : Group<SymmetricElement>{
		private uint Size{get;set;}

		public SymmetricGroup(uint size) : base(Factorial(size)){
			Size = size;
			_elements = new SymmetricElement[Order];
			for(uint i = 0; i < Order; i++){
				var curr = new uint[Size];
				uint curval = i;
				for(uint j = 0; j < Size; j++){
					uint curmod = curval % (Size - j);
					curval = curval / (Size - j);
					uint val = 0;
					while(Contains(curr, j, val))
							val++;
					for(uint k = 0; k < curmod; k++){
						val++;
						while(Contains(curr, j, val))
							val++;
					}
					curr[j] = val;
				}
				_elements[i] = new SymmetricElement(curr);
			}
		}

		bool Contains(uint[] arr, uint maxindex, uint value){
			for(uint j = 0; j < maxindex; j++)
				if(arr[j] == value)
					return true;
			return false;
		}

	    readonly SymmetricElement[] _elements;

		public override SymmetricElement GetElement(uint index){
			return _elements[index];
		}

	    private static uint Factorial(uint n){
			uint toret = 1;
			while(n > 1)
				toret *= n--;
			return toret;
		}

		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append('{');
			if(_elements.Length > 0)
				sb.Append(_elements[0]);
			for(int i = 1; i < Order; i++){
				sb.Append(", ");
				sb.Append(_elements[i]);
			}
			sb.Append('}');
			return sb.ToString();
		}
	}
}

