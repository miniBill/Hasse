using System;
using System.Collections.Generic;

namespace Hasse {
	public static class MyExtensions {
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> function) {
			foreach(var element in source)
				function(element);
		}

		public static bool AddIfNotContained<T>(this List<T> list, T element) {
			if(list.Contains(element))
				return false;
			list.Add(element);
			return true;
		}
	}
}
