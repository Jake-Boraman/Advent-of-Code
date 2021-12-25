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
            List<int> rowTotals = new List<int>();

            foreach (string row in rows)
            {
                string rowSpaced = Regex.Replace(row, @"\s+", " ");
                int[] nums = Array.ConvertAll(rowSpaced.Split(' '), int.Parse);
                rowTotals.Add(nums.Max() - nums.Min());
            }

            foreach (int num in rowTotals)
            {
                finalTotal += num;
            }

            Console.WriteLine($"The spreadsheet's checksum is {finalTotal}");
        }
    }
}