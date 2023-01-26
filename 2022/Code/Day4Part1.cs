using System;
using System.Linq;

namespace campCleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = System.IO.File.ReadAllLines("input.txt");
            int totalTruePairs = 0;

            foreach (string line in inputs)
            {
                List<int> elf1 = new List<int>();
                List<int> elf2 = new List<int>();
                string[] separate = line.Split(',');

                int elf1DashLoc = separate[0].IndexOf('-');
                int elf2DashLoc = separate[1].IndexOf('-');
                int elf1start = Int32.Parse(separate[0].Substring(0, elf1DashLoc));
                int elf1end = Int32.Parse(separate[0].Substring(elf1DashLoc + 1, separate[0].Length - elf1DashLoc - 1));
                int elf2start = Int32.Parse(separate[1].Substring(0, elf2DashLoc));
                int elf2end = Int32.Parse(separate[1].Substring(elf2DashLoc + 1, separate[1].Length - elf2DashLoc - 1));

                for (int i = elf1start; i <= elf1end; i++)
                {
                    elf1.Add(i);
                }

                for (int i = elf2start; i <= elf2end; i++)
                {
                    elf2.Add(i);
                }

                if (ContainsAllItemsAinB(elf1, elf2))
                {
                    totalTruePairs += 1;
                }
                else if (ContainsAllItemsBinA(elf1, elf2))
                {
                    totalTruePairs += 1;
                }    
            }
            Console.WriteLine("There are " + totalTruePairs + " pairs that match the conditions");
        }

        public static bool ContainsAllItemsAinB(List<int> a, List<int> b)
        {
            return !a.Except(b).Any();
        }

        public static bool ContainsAllItemsBinA(List<int> a, List<int> b)
        {
            return !b.Except(a).Any();
        }
    }
}