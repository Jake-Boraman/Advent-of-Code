using System;

namespace naughtyOrNiceString
{
    class Program
    {
        static void Main(string[] args)
        {
            int niceCount = 0;
            string[] input = System.IO.File.ReadAllLines("strings.txt");
            foreach (string line in input)
            {
                bool atLeastThreeVowels = vowels(line);
                bool doubleLetter = twice(line);
                bool hasBad = hasBadParts(line);

                if (atLeastThreeVowels && doubleLetter && !hasBad)
                {
                    niceCount++;
                }
            }

            Console.WriteLine($"There were {niceCount} nice words in this group!");
            Console.ReadKey();
        }

        public static bool vowels(string line)
        {
            int vowelCount = 0;
            string vowels = "aeiou";
            foreach (char c in line)
            {
                if (vowels.Contains(c))
                {
                    vowelCount++;
                }
            }

            if (vowelCount >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool twice(string line)
        {
            for(int i = 0; i < line.Length; i++)
            {
                if(i != line.Length-1)
                {
                    if(line[i] == line[i+1])
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public static bool hasBadParts(string line)
        {
            if(line.Contains("ab"))
            {
                return true;
            }
            else if(line.Contains("cd"))
            {
                return true;
            }
            else if(line.Contains("pq"))
            {
                return true;
            }
            else if(line.Contains("xy"))
            {
                return true;
            }

            return false;
        }
    }
}