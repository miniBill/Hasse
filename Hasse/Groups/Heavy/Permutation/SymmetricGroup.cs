using System;
using System.Text;

namespace Hasse.Groups.Heavy.Permutation{
	public class SymmetricGroup : Group<SymmetricElement>{
		private uint Size{get;set;}
		private uint FullSize{get;set;}

		public SymmetricGroup(uint size) : base(Factorial(size)){
			Size = size;
			elements = new SymmetricElement[Order];
			for(uint i = 0; i < FullSize; i++){
				uint[] curr = new uint[Size];
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
				elements[i] = new SymmetricElement(curr);
			}
		}

		bool Contains(uint[] arr, uint maxindex, uint value){
			for(uint j = 0; j < maxindex; j++)
				if(arr[j] == value)
					return true;
			return false;
		}

		SymmetricElement[] elements;

		public override SymmetricElement GetElement(uint index){
			return elements[index];
		}

		public static uint Factorial(uint n){
			uint toret = 1;
			while(n > 1)
				toret *= n--;
			return toret;
		}

		public override string ToString(){
			StringBuilder sb = new StringBuilder();
			sb.Append('{');
			if(elements.Length > 0)
				sb.Append(elements[0]);
			for(int i = 1; i < Order; i++){
				sb.Append(", ");
				sb.Append(elements[i]);
			}
			sb.Append('}');
			return sb.ToString();
		}
	}
}

