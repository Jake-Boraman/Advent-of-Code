using System;
using System.Linq;

namespace tuningtrouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadLines(@"input.txt").First();
            List<char> recent = new List<char>();
            int index = 0;

            foreach (char c in input)
            {
                if (index < 4)
                {
                    recent.Add(c);
                }
                else
                {
                    recent.Add(c);
                    recent.RemoveAt(0);
                }

                if (recent.Distinct().Count() == 4)
                {
                    // All are unique
                    Console.WriteLine((index + 1) + " characters have been processed");
                    break;
                }

                index++;
            }
        }
    }
}