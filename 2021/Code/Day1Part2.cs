using System;

namespace sonarDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Beginning measurements...");
            string[] input = System.IO.File.ReadAllLines(@"depths.txt");
            int output = increaseCounter(input);
            Console.WriteLine($"There are {output} measurements larger than the previous.\nPress Any Key to Exit");
            Console.ReadKey();
        }

        static int increaseCounter(string[] depths)
        {
            int counter = 0;

            for (int i = 0; i < depths.Length; i++)
            {
                int group1_firstVal;
                int group1_secValue;
                int group1_thirdVal;
                int group2_firstVal;
                int group2_secValue;
                int group2_thirdVal;
                int group1total;
                int group2total;

                group1_firstVal = Int32.Parse(depths[i]);
                group1_secValue = Int32.Parse(depths[i + 1]);
                group1_thirdVal = Int32.Parse(depths[i + 2]);
                group1total = group1_firstVal + group1_secValue + group1_thirdVal;

                try
                {
                    group2_firstVal = Int32.Parse(depths[i + 1]);
                    group2_secValue = Int32.Parse(depths[i + 2]);
                    group2_thirdVal = Int32.Parse(depths[i + 3]);
                    group2total = group2_firstVal + group2_secValue + group2_thirdVal;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not enough values left, printing result");
                    return counter;
                }

                if (group2total > group1total)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}