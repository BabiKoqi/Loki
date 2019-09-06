using System.Collections.Generic;
using System.Linq;

namespace Loki.Interface.Skeleton {
    static class MenuNesting {
        static readonly Stack<string> _stack = new Stack<string>();

        internal static string Render() => string.Join(" >> ", _stack.ToArray().Reverse());
        internal static void Add(string name) => _stack.Push(name);
        internal static void Remove() => _stack.Pop();
    }
}