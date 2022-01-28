using System;
using System.Collections.Generic;

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
            int firstValHitTwice = 0;
            int count = 0;
            bool duplicateFound = false;

            List<int> values = new List<int>();

            while (duplicateFound == false)
            {
                foreach (string change in frequencies)
                {
                    string type = change.Substring(0, 1);
                    int value = Int32.Parse(change.Substring(1, change.Length - 1));

                    if (type == "+")
                    {
                        count += value;

                        if (values.Contains(count))
                        {
                            duplicateFound = true;
                            firstValHitTwice = count;
                            break;
                        }
                        else
                        {
                            values.Add(count);
                        }
                    }
                    else
                    {
                        count -= value;

                        if (values.Contains(count))
                        {
                            duplicateFound = true;
                            firstValHitTwice = count;
                            break;
                        }
                        else
                        {
                            values.Add(count);
                        }
                    }
                }
            }

            return firstValHitTwice;
        }
    }
}