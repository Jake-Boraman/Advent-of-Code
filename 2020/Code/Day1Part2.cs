using System;

namespace sumFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            Console.WriteLine("Please enter total to find: ");
            string input = Console.ReadLine();
            int.TryParse(input, out num);

            string output = numFinder(num);
            Console.WriteLine(output);
            Console.ReadKey();

        }

        public static string numFinder(int numToFind)
        {
            string output = "";
            string[] lines = System.IO.File.ReadAllLines(@"numbers.txt");
            for(int i = 0; i < lines.Length; i++)
            {
                int num1 = Int32.Parse(lines[i]);
                for(int j = 0; j < lines.Length; j++)
                {
                    int num2 = Int32.Parse(lines[j]);
                    for(int x = 0; x < lines.Length; x++)
                    {
                        int num3 = Int32.Parse(lines[x]);
                        if(num1 + num2 + num3 == numToFind)
                        {
                            int multiplied = num1*num2*num3;
                            output = $"The answer is: {multiplied}!";
                            return output;
                        }
                    }
                }
                
            }
            output = "We didn't find it chief.";
            return output;
        }
    }
}
