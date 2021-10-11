using System;

namespace tobogganTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Right: ");
            string rightInput = Console.ReadLine();
            Console.WriteLine("Down: ");
            string downInput = Console.ReadLine();
            string input = System.IO.File.ReadAllText(@"map.txt");
            char[,] map = createArrayMap(input);
            int treesHit = treeEncounters(map, rightInput, downInput);
            Console.WriteLine($"You will encounter {treesHit} trees on this slope!");
            Console.ReadKey();
        }

        public static char[,] createArrayMap(string input)
        {
            string oop = ".#..........#......#..#.....#..";
            int length = oop.Length;
            int i = 0;
            char[,] result = new char[324, 31];
            foreach (string row in input.Split("\r\n"))
            {
                for (int j = 0; j < row.Length; j++)
                {
                    result[i, j] = row[j];
                }
                i++;
            }
            return result;
        }

        public static int treeEncounters(char[,] map, string rightNum, string downNum)
        {
            int treesCount = 0;
            bool hitBottom = false;
            //First value for row (down), second for column (right)
            int[] currentLocation = new int[] { 0, 0 };

            while (!hitBottom)
            {
                currentLocation[0] += Int16.Parse(downNum);
                currentLocation[1] += Int16.Parse(rightNum);
                if (currentLocation[1] >= 31)
                {
                    currentLocation[1] -= 31;
                }
                char locationSymbol = map[currentLocation[0], currentLocation[1]];

                if (locationSymbol == '#')
                {
                    treesCount++;
                }

                if (currentLocation[0] == map.GetLength(0) - 1)
                {
                    hitBottom = true;
                }
            }
            return treesCount;
        }
    }
}
