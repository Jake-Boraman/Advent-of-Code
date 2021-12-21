using System;
using System.Linq;

namespace digitizedCaptcha
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;

            int[] digString = Array.ConvertAll(System.IO.File.ReadLines(@"digits.txt").First().ToCharArray(), c => (int)Char.GetNumericValue(c));

            for (int i = 0; i < digString.Length; i++)
            {
                if (i != digString.Length - 1)
                {
                    if (digString[i] == digString[i + 1])
                    {
                        total += digString[i];
                    }
                }
                else
                {
                    if (digString[i] == digString[0])
                    {
                        total += digString[i];
                    }
                }
            }

            Console.WriteLine($"The sum of all the digits that match the next digit in the list is {total}");
        }
    }
}