using System;
using System.Linq;
using System.Collections.Generic;
using Hasse.Groups;
using Light = Hasse.Groups.Light;
using Heavy = Hasse.Groups.Heavy;

namespace Hasse{
	static class Program{
		public static void Main(string[] args){
			Work(new string[]{"z", "10", "2"}); //args);
		}

		public static void Work(string[] args){
			if(args.Length < 2){
				Console.Error.WriteLine("Ohnoes, needz moar argumentz!");
				return;
			}
			if(args[0] == "z" || args[0] == "Z"){
				var @group = (new Light.CyclicGroup(Convert.ToInt32(args[1]))).Power(args.Length == 2 ? 1 : Convert.ToInt32(args[2]));
				var g2 = GeneratorFactory.Create(@group);
				Console.WriteLine("digraph G { ");
				var gen = from subgroup in g2.Generate()
						group subgroup by subgroup.Order into sizegroup
						orderby sizegroup.Key descending
						select sizegroup;
				var list = gen.ToList();
				var wrapped = WrapperFactory.CreateWrapper<Light.SubGroup,int>(list);
				Process(wrapped);
			}
			if(args[0] == "s" || args[0] == "S"){
				var @group = (new Heavy.Permutation.SymmetricGroup(Convert.ToInt32(args[1]))).Power(args.Length == 2 ? 1 : Convert.ToInt32(args[2]));
				var g2 = GeneratorFactory.Create(@group);
				Console.WriteLine("digraph G { ");
				var gen = from subgroup in g2.Generate()
						group subgroup by subgroup.Order into sizegroup
						orderby sizegroup.Key descending
						select sizegroup;
				var list = gen.ToList();
				var wrapped = WrapperFactory.CreateWrapper<Heavy.SubGroup<Heavy.Product.PowerElement<Heavy.Permutation.SymmetricElement>>, Heavy.Product.PowerElement<Heavy.Permutation.SymmetricElement>>(list);
				Process(wrapped);
			}
		}

		public static void Process<T>(IEnumerable<IGrouping<int,IISubGroup<T>>> genlist){
			if(genlist == null)
				return;
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
				int item = 1;
				foreach(var sub in size)
					Console.Write("; l{0}i{1}", size.Key, item++);
				Console.WriteLine("; }");
				if(size.Key > 1){
					item = 1;
					foreach(var sub in size){
						foreach(var lower in genlist.Where(g => g.Key < size.Key)){
							int lowitem = 1;
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
