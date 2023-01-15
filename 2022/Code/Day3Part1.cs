using System;
using System.Linq;

namespace rucksackReorganisation
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            string[] rucksacks = System.IO.File.ReadAllLines("input.txt");

            foreach (string rucksack in rucksacks)
            {
                // Get shared item
                string compart1 = rucksack.Substring(0, (int)(rucksack.Length / 2));
                string compart2 = rucksack.Substring((int)(rucksack.Length / 2), (int)(rucksack.Length / 2));
                int commonItem = (int)compart1.Intersect(compart2).First();
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