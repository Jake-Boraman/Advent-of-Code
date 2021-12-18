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
                        int toAdd = 0;
                        int difference = crabPos - i;
                        for (int j = 0; j < difference; j++)
                        {
                            toAdd += 1 + j;
                        }
                        fuelUsed += toAdd;
                    }
                    else if (crabPos < i)
                    {
                        int toAdd = 0;
                        int difference = i - crabPos;
                        for (int j = 0; j < difference; j++)
                        {
                            toAdd += 1 + j;
                        }
                        fuelUsed += toAdd;
                    }
                }

                fuelCounts.Add(fuelUsed);
            }

            int minFuel = fuelCounts.Min();

            Console.WriteLine($"The minimum fuel required would be {minFuel} fuel!");
            Console.ReadKey();
        }
    }
}