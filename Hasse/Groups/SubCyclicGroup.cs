using System;
using System.Collections.Generic;

namespace Hasse.Groups{
	public class SubCyclicGroup : SubGroup<CyclicElement>{
		public override void Dump(){
			Console.Write('{');
			Console.Write(this[0].Value);
			for(int i = 1; i < Order; i++){
				Console.Write(',');
				Console.Write(this[i].Value);
			}
			Console.Write("}_");
			Console.WriteLine(this[0].Order);
		}
	}
}

