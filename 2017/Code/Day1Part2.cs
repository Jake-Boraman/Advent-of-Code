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

            int increase = digString.Length / 2;

            for (int i = 0; i < digString.Length; i++)
            {
                int searchIndex = i + increase;
                if (searchIndex >= digString.Length)
                {
                    searchIndex = searchIndex - digString.Length;
                }
                if (digString[i] == digString[searchIndex])
                {
                    total += digString[i];
                }
            }

            Console.WriteLine($"The sum of all the digits that match the increment index in the list is {total}");
        }
    }
}