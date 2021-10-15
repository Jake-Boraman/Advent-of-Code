using System;
using System.Linq;

namespace santaElevator
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = System.IO.File.ReadLines(@"floors.txt").First().ToCharArray();
            int floor = getFloor(input);
            Console.WriteLine($"Santa ends up at floor {floor}!\nPress Any Key to Exit");
            Console.ReadKey();
        }

        public static int getFloor(char[] instructions)
        {
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
                    Console.WriteLine($"ERROR: Input file contains disallowed characters at location {i}");
                }
                i++;
            }
            return currentFloor;
        }
    }
}