using System;
using System.Linq;

namespace rucksackReorganisation
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            var rucksacks = System.IO.File.ReadAllLines("input.txt").Chunk(3).ToArray();

            foreach (var group in rucksacks)
            {
                int commonItem = (int)group[0].Intersect(group[1].Intersect(group[2])).First();
                if (commonItem >= 97)
                {
                    commonItem = commonItem - 96;
                }
                else
                {
                    commonItem = commonItem - 38;
                }

                total += commonItem;
            }

            Console.WriteLine(total);
        }
    }
}