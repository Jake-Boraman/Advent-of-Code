using System;
using System.Linq;
using System.Collections.Generic;

namespace subLantern
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = System.IO.File.ReadAllLines(@"fish.txt").First().Split(',');
            List<int> origFishData = Array.ConvertAll(inputs, Int32.Parse).ToList();

            int days = 0;

            Console.WriteLine("Enter total number of days to count: ");
            int daysCap = Int32.Parse(Console.ReadLine());

            while (days < daysCap)
            {
                int startOfDayLength = origFishData.ToArray().Length - 1;
                for (int i = 0; i < origFishData.Count(); i++)
                {
                    int fish = origFishData[i];

                    if (fish == 0)
                    {
                        origFishData[i] = 6;
                        origFishData.Add(8);
                    }
                    else if (i <= startOfDayLength)
                    {
                        origFishData[i]--;
                    }
                }

                days++;
            }

            int fishNum = origFishData.Count();

            Console.WriteLine($"After {daysCap} days, there would be {fishNum} lanternfish!");
            Console.ReadKey();
        }
    }
}