using System;

namespace chronalCalibration
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] frequencies = System.IO.File.ReadAllLines("input.txt");
            int output = GetResultingFrequency(frequencies);
            Console.WriteLine($"The resulting frequency is {output} after all the changes have been applied!");
        }

        static int GetResultingFrequency(string[] frequencies)
        {
            int count = 0;

            foreach (string change in frequencies)
            {
                string type = change.Substring(0, 1);
                int value = Int32.Parse(change.Substring(1, change.Length - 1));

                if (type == "+")
                {
                    count += value;
                }
                else
                {
                    count -= value;
                }
            }

            return count;
        }
    }
}