using System;
using System.Linq;
using System.Collections.Generic;

namespace inventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] boxIDs = System.IO.File.ReadAllLines("input.txt");
            int twosCount = 0;
            int threesCount = 0;

            foreach (string ID in boxIDs)
            {
                bool containsTwo = false;
                bool containsThree = false;
                Dictionary<char, int> letterCounts = new Dictionary<char, int>();

                foreach (char c in ID)
                {
                    if (letterCounts.ContainsKey(c))
                    {
                        letterCounts[c] += 1;
                    }
                    else
                    {
                        letterCounts.Add(c, 1);
                    } 
                }

                for (int i = 0; i < letterCounts.Count; i++)
                {
                    if (letterCounts.ElementAt(i).Value == 2)
                    {
                        containsTwo = true;
                    }

                    if (letterCounts.ElementAt(i).Value == 3)
                    {
                        containsThree = true;
                    }
                }

                if (containsTwo)
                {
                    twosCount++;
                }

                if (containsThree)
                {
                    threesCount++;
                }
            }

            int checksum = twosCount * threesCount;

            Console.WriteLine($"The checksum is {checksum} for the list of box IDs");
        }
    }
}