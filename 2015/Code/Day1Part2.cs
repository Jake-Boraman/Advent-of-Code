using System;
using System.Linq;

namespace santaElevator
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = System.IO.File.ReadLines(@"floors.txt").First().ToCharArray();
            int basementWhen = basementFinder(input);
            Console.WriteLine($"Santa entered the basement after the instruction with position {basementWhen}!\nPress Any Key to Exit");
            Console.ReadKey();
        }

        public static int basementFinder(char[] instructions)
        {
            bool enteredBasement = false;
            int i = 0;
            int currentFloor = 0;
            foreach (char direction in instructions)
            {
                if(direction == '(')
                {
                    currentFloor++;
                }
                else if(direction == ')')
                {
                    currentFloor--;
                }
                else
                {
                    Console.WriteLine($"ERROR: Input file contains disallowed characters at location {i+1}");
                    return -1;
                }

                if(currentFloor < 0 & enteredBasement == false)
                {
                    enteredBasement = true;
                    return i + 1;
                }
                i++;
                
            }
            return -1;
        }
    }
}