using System;
using System.Linq;
using System.Collections.Generic;
using Hasse.Groups;
using Hasse.Groups.Cyclic;
using Hasse.Groups.Permutation;

namespace Hasse{
	static class Program{
		public static void Main(string[] args){
			var genlist = Generate(args);
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
				foreach(var sub in size){
					Console.Write("; \"{0}\"", sub.ToString());
					Console.Error.WriteLine(sub.ToString());
				}
				Console.WriteLine("; }");
				if(size.Key > 1)
					foreach(var sub in size)
						foreach(var lower in genlist.Where(g => g.Key < size.Key))
							foreach(var low in lower)
								if(sub.Contains(low))
									Console.WriteLine("  \"{0}\" -> \"{1}\"", sub.ToString(), low.ToString());
			}
			Console.WriteLine("}");
		}

		public static IEnumerable<IGrouping<int,ISubGroup>> Generate(string[] args){
			if(args.Length < 3){
				Console.Error.WriteLine("Ohnoes, needz moar argumentz!");
				return null;
			}
			if(args[0] == "z" || args[0] == "Z"){
				var @group = (new CyclicGroup(Convert.ToInt32(args[1]))).Power(Convert.ToInt32(args[2]));
				Console.Error.WriteLine(@group.ToString());
				var g2 = GeneratorFactory.Create(@group);
				Console.WriteLine("digraph G { ");
				var gen = from subgroup in g2.Generate()
						group subgroup by subgroup.Order into sizegroup
						orderby sizegroup.Key descending
						select sizegroup;
				return WrapperFactory.CreateWrapper(gen.ToList());
			}
			if(args[0] == "s" || args[0] == "S"){
				var @group = (new SymmetricGroup(Convert.ToInt32(args[1]))).Power(Convert.ToInt32(args[2]));
				Console.Error.WriteLine(@group.ToString());
				var g2 = GeneratorFactory.Create(@group);
				Console.WriteLine("digraph G { ");
				var gen = from subgroup in g2.Generate()
						group subgroup by subgroup.Order into sizegroup
						orderby sizegroup.Key descending
						select sizegroup;
				return WrapperFactory.CreateWrapper(gen.ToList());
			}
			return null;
		}
	}
}
