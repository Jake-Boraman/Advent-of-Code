using System;

namespace tobogganTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] inputs = new int[,] { { 1, 3, 5, 7, 1 }, { 1, 1, 1, 1, 2 } };
            string input = System.IO.File.ReadAllText(@"map.txt");
            char[,] map = createArrayMap(input);
            long treesHit = treeEncounters(map, inputs);
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

        public static long treeEncounters(char[,] map, int[,] inputs)
        {
            long total = 0;
            int[] treesCount = new int[5];
            bool hitBottom = false;
            //First value for row (down), second for column (right)
            int[] currentLocation = new int[] { 0, 0 };

            for (int i = 0; i < 5; i++)
            {
                hitBottom = false;
                currentLocation[0] = 0;
                currentLocation[1] = 0;
                while (!hitBottom)
                {
                    currentLocation[0] += inputs[1, i];
                    currentLocation[1] += inputs[0, i];
                    if (currentLocation[1] >= 31)
                    {
                        currentLocation[1] -= 31;
                    }
                    if (currentLocation[0] > map.GetLength(0) - 1)
                    {
                        currentLocation[0] = map.GetLength(0) - 1;
                    }
                    char locationSymbol = map[currentLocation[0], currentLocation[1]];

                    if (locationSymbol == '#')
                    {
                        treesCount[i]++;
                    }

                    if (currentLocation[0] == map.GetLength(0) - 1)
                    {
                        hitBottom = true;
                    }
                }
            }

            //I know this is ridiculous but this was the only way to fix and overflow error, even thought the total value
            //is easily less than a long/Int64 should be able to hold, but it was still overflowing
            long temp1 = treesCount[0] * treesCount[1];
            long temp2 = temp1 * treesCount[2];
            long temp3 = temp2 * treesCount[3];
            total = temp3 * treesCount[4];
            return total; 
        }
    }
}
