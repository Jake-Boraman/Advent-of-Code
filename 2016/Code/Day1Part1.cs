using System;
using System.Collections.Generic;

namespace taxicabBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllText("instructions.txt").Split(", ");
            int blocksAway = getDistance(input);
            Console.WriteLine($"The Easter Bunny HQ is {blocksAway} blocks away!");
            Console.ReadKey();
        }

        public static int getDistance(string[] instructions)
        {
            int blocksAway = 0;
            int[] currentlocation = new int[] { 0, 0 }; //currentLocation[0] is X
            int currentFacing = 0; //0 for North, 90 for East etc
            List<int,int> visitedLocs = new List<int,int>();
            int i = 0;

            foreach (string instruction in instructions)
            {
                int length = instruction.Length;
                char direction = Char.Parse(instruction.Substring(0, 1));
                int distance = Int32.Parse(instruction.Substring(1, length - 1));

                if (direction == 'R')
                {
                    if (currentFacing != 270)
                    {
                        currentFacing += 90;
                    }
                    else
                    {
                        currentFacing = 0;
                    }

                    switch (currentFacing)
                    {
                        case 0:
                            currentlocation[1] += distance;
                            break;
                        case 90:
                            currentlocation[0] += distance;
                            break;
                        case 180:
                            currentlocation[1] -= distance;
                            break;
                        case 270:
                            currentlocation[0] -= distance;
                            break;
                    }
                }
                else if (direction == 'L')
                {
                    if (currentFacing != 0)
                    {
                        currentFacing -= 90;
                    }
                    else
                    {
                        currentFacing = 270;
                    }

                    switch (currentFacing)
                    {
                        case 0:
                            currentlocation[1] += distance;
                            break;
                        case 90:
                            currentlocation[0] += distance;
                            break;
                        case 180:
                            currentlocation[1] -= distance;
                            break;
                        case 270:
                            currentlocation[0] -= distance;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input error.");
                    Console.ReadKey();
                    System.Environment.Exit(1);
                }
                i++;
            }

            blocksAway = Math.Abs(currentlocation[0]) + Math.Abs(currentlocation[1]);
            return blocksAway;
        }
    }
}