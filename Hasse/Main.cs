using System;
using System.Linq;
using System.Collections.Generic;
using Hasse.Groups;
using Light = Hasse.Groups.Light;
using Heavy = Hasse.Groups.Heavy;
using Hasse.Groups.Heavy.Product;
using Hasse.Groups.Heavy.Permutation;

namespace Hasse{
	static class Program{
		public static void Main(string[] args){
			Work(args);
		}

		public static void Work(string[] args){
			if(args.Length < 2){
				Console.Error.WriteLine("Ohnoes, needz moar argumentz!");
				return;
			}
			uint size = Convert.ToUInt32(args[1]);
			if(args[0] == "z" || args[0] == "Z")
				WorkLight(size, args);
			if(args[0] == "s" || args[0] == "S")
				WorkHeavy(size, args);
		}

		public static void WorkLight(uint size, string[] args){
			var bgroup = new Light.CyclicGroup(size);
			Light.Group @group;
			if(args.Length == 2)
				@group = bgroup;
			else
				@group = bgroup.Power(Convert.ToUInt32(args[2]));
			var g2 = GeneratorFactory.Create(@group);
			Console.WriteLine("digraph G { ");
			var gen = from subgroup in g2.Generate()
					group subgroup by subgroup.Order into sizegroup
					orderby sizegroup.Key descending
					select sizegroup;
			var list = gen.ToList();
			Process(list);
		}
		
		public static void WorkHeavy(uint size, string[] args){
			var @group = new Heavy.Permutation.SymmetricGroup(size);
			var g2 = GeneratorFactory.Create(@group);
			Console.WriteLine("digraph G { ");
			var gen = from subgroup in g2.Generate()
					group subgroup by subgroup.Order into sizegroup
					orderby sizegroup.Key descending
					select sizegroup;
			var list = gen.ToList();
			Process(list);
		}

		public static void Process<U>(IEnumerable<IGrouping<uint, U>> genlist) where U : IContainer<U>{
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
				uint item = 1;
				foreach(var sub in size)
					Console.Write("; l{0}i{1}", size.Key, item++);
				Console.WriteLine("; }");
				if(size.Key > 1){
					item = 1;
					foreach(var sub in size){
						foreach(var lower in genlist.Where(g => g.Key < size.Key)){
							uint lowitem = 1;
							foreach(var low in lower){
								if(sub.IsSupersetOf(low))
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

		public static void AddRange<T>(this SortedSet<T> set, IEnumerable<T> elements){
			foreach(var element in elements)
				set.Add(element);
		}
	}
}
