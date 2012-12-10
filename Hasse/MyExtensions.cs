using System;
using System.Collections.Generic;

namespace Hasse {
    public static class MyExtensions {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> function){
            foreach(var element in source)
                function(element);
        }
    }
}
