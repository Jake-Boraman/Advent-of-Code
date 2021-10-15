using System;

namespace passwordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"passwords.txt");
            int num = numValid(lines);
            Console.WriteLine($"{num} passwords are valid!");
            Console.ReadKey();
        }

        public static int numValid(string[] passLines)
        {
            int validTotal = 0;
            foreach (string line in passLines)
            {
                //int matchingTotal = 0;
                int dashIndex = 0;
                int colonIndex = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if(line[i] == '-')
                    {
                        dashIndex = i;
                    }
                    if(line[i] == ':')
                    {
                        colonIndex = i;
                    }
                }

                char c = line[colonIndex-1];
                int position1 = Int16.Parse(line.Substring(0, dashIndex)) - 1;
                int position2 = Int16.Parse(line.Substring(dashIndex+1, (colonIndex-2) - dashIndex)) - 1; 
                string password = line.Substring(colonIndex+2);

                char test1 = password[position1];
                char test2 = password[position2];
                
                if((password[position1] == c) ^ (password[position2] == c))
                {
                    validTotal++;
                }
                
            }
            return validTotal;
        }
    }
}
