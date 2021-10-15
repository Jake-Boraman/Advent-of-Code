using System;
using System.Linq;

namespace feetofRibbon
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] presentDimensions = System.IO.File.ReadAllLines(@"presentSizes.txt");
            int ftOfRibbon = getFtOfRibbon(presentDimensions);
            Console.WriteLine($"The elves will require {ftOfRibbon}ft of ribbon!\nPress Any Key to Exit.");
            Console.ReadKey();
        }

        public static int getFtOfRibbon(string[] presentDimensions)
        {
            int totalRibbon = 0;
            foreach (string presSize in presentDimensions)
            {
                int minVal1 = 0;
                int minVal2 = 0;
                int[] dimensLWH = presSize.Split('x').Select(Int32.Parse).ToArray();
                minVal1 = Math.Min(dimensLWH[0], Math.Min(dimensLWH[1], dimensLWH[2]));
                if (minVal1 == dimensLWH[0])
                {
                    minVal2 = Math.Min(dimensLWH[1], dimensLWH[2]);
                }
                else if (minVal1 == dimensLWH[1])
                {
                    minVal2 = Math.Min(dimensLWH[0], dimensLWH[2]);
                }
                else
                {
                    minVal2 = Math.Min(dimensLWH[0], dimensLWH[1]);
                }

                int ribbonToWrap = (2 * minVal1) + (2 * minVal2);
                int ribbonForBow = dimensLWH[0] * dimensLWH[1] * dimensLWH[2];

                totalRibbon += ribbonForBow + ribbonToWrap;
            }
            return totalRibbon;
        }
    }
}