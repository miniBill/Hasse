using System;
using Hasse.Groups;

namespace Hasse{
	static class Program{
		public static void Main(string[] args){
			CyclicElement a = new CyclicElement(3, 4);
			Console.WriteLine(a);
			CyclicElement b = new CyclicElement(1, 4);
			Console.WriteLine(b);
			CyclicElement test = a + b;
			Console.WriteLine(test);
			CyclicElement test2 = a * b;
			Console.WriteLine(test2);

			var g = new Generator<CyclicElement,SubCyclicGroup>(new CyclicGroup(4));
			foreach(var sub in g.Generate())
				sub.Dump();
		}
	}
}
