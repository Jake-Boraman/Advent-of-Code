using System;
using System.Linq;
using System.Collections.Generic;

namespace subWhale
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> fuelCounts = new List<int>();

            int[] crabs = Array.ConvertAll(System.IO.File.ReadLines(@"crabs.txt").First().Split(','), Int32.Parse);

            int max = crabs.Max();

            for (int i = 0; i <= max; i++)
            {
                int fuelUsed = 0;
                foreach (int crabPos in crabs)
                {
                    if (crabPos > i)
                    {
                        fuelUsed += crabPos - i;
                    }
                    else if (crabPos < i)
                    {
                        fuelUsed += i - crabPos;
                    }
                }

                fuelCounts.Add(fuelUsed);
            }

            int minFuel = fuelCounts.Min();

            Console.WriteLine($"The minimum fuel required would be {minFuel}");
            Console.ReadKey();
        }
    }
}