using System;
using Hasse.Groups.Cyclic;

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

			var group = new CyclicGroup(4);

			var g = GeneratorFactory.Create(group);
			foreach(var sub in g.Generate())
				sub.Dump();

			var prod = group * group;
			var g2 = GeneratorFactory.Create(prod);
			foreach(var sub in g2.Generate())
				sub.Dump();
		}
	}
}
