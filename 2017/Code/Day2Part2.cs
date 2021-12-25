using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace digitizedChecksum
{
    class Program
    {
        static void Main(string[] args)
        {
            int finalTotal = 0;
            string[] rows = System.IO.File.ReadAllLines(@"spreadsheet.txt");
            List<int> rowDivs = new List<int>();

            foreach (string row in rows)
            {
                string rowSpaced = Regex.Replace(row, @"\s+", " ");
                int[] nums = Array.ConvertAll(rowSpaced.Split(' '), int.Parse);
                foreach (int num in nums)
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (num != nums[i])
                        {
                            if (num % nums[i] == 0)
                            {
                                rowDivs.Add(num / nums[i]);
                            }
                        }
                    }
                }
            }

            foreach (int num in rowDivs)
            {
                finalTotal += num;
            }

            Console.WriteLine($"The spreadsheet's checksum is {finalTotal}");
        }
    }
}