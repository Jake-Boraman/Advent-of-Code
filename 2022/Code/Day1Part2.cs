using System;
using System.Linq;
using System.Collections.Generic;

namespace CalorieCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            List<int> calorieTotals = new List<int>();
            List<string> tempElf = new List<string>();
            List<string[]> elves = new List<string[]>();
            string[] inputs = System.IO.File.ReadAllLines(@"calories.txt");
            
            // Elf array grabber
            foreach (string input in inputs){
                if (!String.IsNullOrWhiteSpace(input))
                {
                    // Add to current array
                    tempElf.Add(input);
                }
                else
                {
                    // Current elf has ended, add array to list, clear array
                    elves.Add(tempElf.ToArray());
                    tempElf.Clear();
                }
            }
            // Fallthrough
            elves.Add(tempElf.ToArray()); 

            // Calorie Counter
            foreach (string[] elf in elves)
            {
                int currentTotal = 0;
                foreach (string foodItem in elf)
                {
                    currentTotal += Int32.Parse(foodItem);
                }
                calorieTotals.Add(currentTotal);
            }

            // Sort
            int[] sortedTotals = calorieTotals.OrderByDescending(x => x).ToArray();
            int topThree = (sortedTotals[0] + sortedTotals[1] + sortedTotals[2]);
            Console.WriteLine("The total of the top three elves is: " + topThree);
        }
    }
}