using System;
using System.Collections.Generic;

namespace CalorieCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            int maxCals = 0;
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
            
            // Calorie Counter
            foreach (string[] elf in elves)
            {
                int currentTotal = 0;
                foreach (string foodItem in elf)
                {
                    currentTotal += Int32.Parse(foodItem);
                }

                if (currentTotal > maxCals)
                {
                    maxCals = currentTotal;
                    Console.WriteLine("New Calorie Record!");
                }
                else
                {
                    Console.WriteLine("Record not broken");
                }
            }

            Console.WriteLine("The elf with the highest calories has " + maxCals + " calories!");
        }
    }
}