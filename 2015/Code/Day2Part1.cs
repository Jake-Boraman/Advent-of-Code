using System;
using System.Linq;

namespace wrappingpaperCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] presentDimensions = System.IO.File.ReadAllLines(@"presentSizes.txt");
            int sqFeetWrap = getSqFtOfWrapping(presentDimensions);
            Console.WriteLine($"The elves will require {sqFeetWrap}ft^2 of wrapping paper!\nPress Any Key to Exit.");
            Console.ReadKey();
        }

        public static int getSqFtOfWrapping(string[] presentDimensions)
        {
            int sqFeetWrap = 0;
            foreach(string presSize in presentDimensions)
            {
                int minVal1 = 0;
                int minVal2 = 0;
                int[] dimensLWH = presSize.Split('x').Select(Int32.Parse).ToArray();
                minVal1 = Math.Min(dimensLWH[0], Math.Min(dimensLWH[1], dimensLWH[2]));
                if(minVal1 == dimensLWH[0])
                {
                    minVal2 = Math.Min(dimensLWH[1], dimensLWH[2]);
                }
                else if(minVal1 == dimensLWH[1])
                {
                    minVal2 = Math.Min(dimensLWH[0], dimensLWH[2]);
                }
                else
                {
                    minVal2 = Math.Min(dimensLWH[0], dimensLWH[1]);
                }

                int smalSizeArea = minVal1 * minVal2;

                sqFeetWrap += ((2 * dimensLWH[0] * dimensLWH[1]) + (2 * dimensLWH[1] * dimensLWH[2]) + (2 * dimensLWH[2] * dimensLWH[0])) + smalSizeArea;

            }
            return sqFeetWrap;
        }
    }
}