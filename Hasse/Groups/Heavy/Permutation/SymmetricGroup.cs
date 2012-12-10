using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hasse.Groups.Heavy.Permutation{
	public class SymmetricGroup : Group<SymmetricElement>{
		private uint Size{get;set;}

		public SymmetricGroup(uint size) : base(MyMath.Factorial(size)){
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

        public override IEnumerator<SymmetricElement> GetEnumerator() {
            return _elements.AsEnumerable().GetEnumerator();
        }
    }
}

