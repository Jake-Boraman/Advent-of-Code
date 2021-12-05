using System;

namespace subPilot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = System.IO.File.ReadAllLines(@"movements.txt");
            int result = positionFinder(inputs);
            Console.WriteLine("Answer: " + result);
            Console.ReadKey();
        }

        static int positionFinder(string[] commands)
        {
            int output = 0;
            int horizPos = 0;
            int depthPos = 0;
            int aim = 0;

            foreach (string command in commands)
            {
                int indexOfSpace = command.IndexOf(' ');
                string direction = command.Substring(0, indexOfSpace);
                int number = Int32.Parse(command.Substring(indexOfSpace + 1, 1));

                switch (direction)
                {
                    case "forward":
                        horizPos += number;
                        depthPos += aim * number;
                        break;

                    case "up":
                        aim -= number;
                        break;

                    case "down":
                        aim += number;
                        break;

                    default:
                        break;
                }
            }

            output = horizPos * depthPos;

            return output;
        }
    }
}