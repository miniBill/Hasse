using System;
using System.Text;

namespace Hasse.Groups.Permutation{
	public class SymmetricGroup : Group<SymmetricElement>{
		private int Size{get;set;}
		private int FullSize{get;set;}

		public SymmetricGroup(int size){
			Size = size;
			FullSize = Factorial(Size);
			elements = new SymmetricElement[FullSize];
			for(int i = 0; i < FullSize; i++){
				int[] curr = new int[Size];
				int curval = i;
				for(int j = 0; j < Size; j++){
					int curmod = curval % (Size - j);
					curval = curval / (Size - j);
					int val = 0;
					while(Contains(curr, j, val))
							val++;
					for(int k = 0; k < curmod; k++){
						val++;
						while(Contains(curr, j, val))
							val++;
					}
					curr[j] = val;
				}
				elements[i] = new SymmetricElement(curr);
			}
		}

		bool Contains(int[] arr, int maxindex, int value){
			for(int j = 0; j < maxindex; j++)
				if(arr[j] == value)
					return true;
			return false;
		}

		SymmetricElement[] elements;

		public override SymmetricElement GetElement(int index){
			return elements[index];
		}

		public override int Order{
			get{
				return FullSize;
			}
		}

		public static int Factorial(int n){
			int toret = 1;
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

