using System;
using System.Text;

namespace Hasse.Groups.Product{
	public class PowerElement<T> : GroupElement<PowerElement<T>> where T : GroupElement<T>{
		public T[] Elements{get; private set;}

		public PowerElement(T[] elements){
			Elements = elements;
		}

		public override PowerElement<T> Multiply(PowerElement<T> other){
			T[] res = new T[Elements.Length];
			for(int i = 0; i < Elements.Length; i++)
				res[i] = Elements[i] * other.Elements[i];
			return new PowerElement<T>(res);
		}

		public override bool Equals(object obj){
			var pobj = obj as PowerElement<T>;
			if(pobj == null)
				return false;
			for(int i = 0; i < Elements.Length; i++)
				if(!Elements[i].Equals(pobj.Elements[i]))
					return false;
			return true;
		}

		public override int GetHashCode(){
			int toret = 0;
			for(int i = 0; i < Elements.Length; i++){
				toret *= 31;
				toret += Elements[i].GetHashCode();
			}
			return toret;
		}

		public override string ToString(){
			StringBuilder sb = new StringBuilder();
			switch(Elements.Length){
			case 0:
				return "{}";
			case 1:
				sb.Append(Elements[0]);
				break;
			default:
				sb.Append('{');
				sb.Append(Elements[0]);
				for(int i = 1; i < Elements.Length; i++){
					sb.Append(", ");
					sb.Append(Elements[i]);
				}
				sb.Append('}');
				break;
			}
			return sb.ToString();
		}
	}
}

