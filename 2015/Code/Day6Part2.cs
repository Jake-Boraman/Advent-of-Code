using System;

namespace lightsGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalBrightness = 0;
            int[,] lights = new int[1000, 1000];
            string[] commands = System.IO.File.ReadAllLines("commands.txt");
            foreach (string command in commands)
            {
                string[] words = command.Split(' ');
                if (words[0] == "toggle")
                {
                    lights = toggleLights(lights, words);
                }
                else if (words[0] == "turn")
                {
                    if (words[1] == "on")
                    {
                        lights = onLights(lights, words);
                    }
                    else if (words[1] == "off")
                    {
                        lights = offLights(lights, words);
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    totalBrightness += lights[i, j];
                }
            }

            Console.WriteLine($"The total brightness has increased by {totalBrightness}!");
            Console.ReadKey();
        }

        static int[,] toggleLights(int[,] lightsInput, string[] command)
        {
            int startCommaLoc = command[1].IndexOf(',');
            int endCommaLoc = command[3].IndexOf(',');
            int startLength = command[1].Length;
            int endLength = command[3].Length; ;

            int startX = Int32.Parse(command[1].Substring(0, startCommaLoc));
            int startY = Int32.Parse(command[1].Substring(startCommaLoc + 1, (startLength - 1) - startCommaLoc));

            int endX = Int32.Parse(command[3].Substring(0, endCommaLoc));
            int endY = Int32.Parse(command[3].Substring(endCommaLoc + 1, (endLength - 1) - endCommaLoc));

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    lightsInput[x, y] += 2;
                }
            }
            return lightsInput;
        }

        static int[,] onLights(int[,] lightsInput, string[] command)
        {
            int startCommaLoc = command[2].IndexOf(',');
            int endCommaLoc = command[4].IndexOf(',');
            int startLength = command[2].Length;
            int endLength = command[4].Length; ;

            int startX = Int32.Parse(command[2].Substring(0, startCommaLoc));
            int startY = Int32.Parse(command[2].Substring(startCommaLoc + 1, (startLength - 1) - startCommaLoc));

            int endX = Int32.Parse(command[4].Substring(0, endCommaLoc));
            int endY = Int32.Parse(command[4].Substring(endCommaLoc + 1, (endLength - 1) - endCommaLoc));

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    lightsInput[x, y] += 1;
                }
            }
            return lightsInput;
        }

        static int[,] offLights(int[,] lightsInput, string[] command)
        {
            int startCommaLoc = command[2].IndexOf(',');
            int endCommaLoc = command[4].IndexOf(',');
            int startLength = command[2].Length;
            int endLength = command[4].Length; ;

            int startX = Int32.Parse(command[2].Substring(0, startCommaLoc));
            int startY = Int32.Parse(command[2].Substring(startCommaLoc + 1, (startLength - 1) - startCommaLoc));

            int endX = Int32.Parse(command[4].Substring(0, endCommaLoc));
            int endY = Int32.Parse(command[4].Substring(endCommaLoc + 1, (endLength - 1) - endCommaLoc));

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    if (lightsInput[x, y] != 0)
                    {
                        lightsInput[x, y] -= 1;
                    }
                }
            }
            return lightsInput;
        }
    }
}