using System;
using System.Linq;
using MoreLinq;

namespace presentsDeliver
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = System.IO.File.ReadAllText("day3.txt")
            .Scan(new { x = 0, y = 0 }, (state, c) =>
            c == '>' ? new { x = state.x + 1, y = state.y } :
            c == '^' ? new { x = state.x, y = state.y + 1 } :
            c == '<' ? new { x = state.x - 1, y = state.y } :
               new { x = state.x, y = state.y - 1 })
            .Select(p => String.Format("{0},{1}", p.x, p.y))
            .GroupBy(p => p)
            .Count();
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}