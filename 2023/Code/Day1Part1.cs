using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace TrebuchetCalibration
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("I:\\C#\\adventofcode\\2023\\Code\\input.txt");
            int[] calib_values = new int[lines.Length];
            int i = 0;

            foreach (string line in lines)
            {
                List<char> chars = new List<char>();

                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        chars.Add(c);
                    }
                }

                calib_values[i] = Int32.Parse(chars[0].ToString() + chars[chars.Count() - 1].ToString());
                i++;
            }

            int total = calib_values.Sum();
            Console.WriteLine($"The sum of these calibration values is {total}.");
        }
    }
}