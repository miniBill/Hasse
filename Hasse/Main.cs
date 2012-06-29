using System;
using System.Linq;
using Hasse.Groups.Cyclic;

namespace Hasse{
	static class Program{
		public static void Main(string[] args){
			if(args.Length < 2){
				Console.Error.WriteLine("Ohnoes, needz moar argumentz!");
				return;
			}
			var @group = (new CyclicGroup(Convert.ToInt32(args[0]))).Power(Convert.ToInt32(args[1]));
			var g2 = GeneratorFactory.Create(@group);
			Console.WriteLine("digraph G { ");
			var gen = from subgroup in g2.Generate()
				      group subgroup by subgroup.Order into sizegroup
					  orderby sizegroup.Key descending
					  select sizegroup;
			var genlist = gen.ToList();
			Console.WriteLine("  {");
			Console.WriteLine("    node [shape=plaintext];");
			foreach(var size in genlist)
				if(size.Key != 1)
					Console.Write("\"{0} elementi\" -> ", size.Key);
			Console.WriteLine(" \"1 elemento\"");
			Console.WriteLine("  }");
			foreach(var size in genlist){
				Console.Write("  { rank = same; \"");
				Console.Write(size.Key);
				if(size.Key == 1)
					Console.Write(" elemento\"");
				else
					Console.Write(" elementi\"");
				int item = 0;
				foreach(var sub in size)
					Console.Write("; l{0}i{1}", size.Key, item++);
				Console.WriteLine("; }");
				if(size.Key > 1){
					item = 0;
					foreach(var sub in size){
						foreach(var lower in genlist.Where(g => g.Key < size.Key)){
							int lowitem = 0;
							foreach(var low in lower){
								if(sub.Contains(low))
									Console.WriteLine("  l{0}i{1} -> l{2}i{3}", size.Key, item, lower.Key, lowitem);
								lowitem++;
							}
						}
						item++;
					}
				}
			}
			Console.WriteLine("}");
		}
	}
}
