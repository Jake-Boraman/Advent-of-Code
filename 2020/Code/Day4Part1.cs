using System;
using System.Collections.Generic;

namespace passportScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"passports.txt");
            string[] passports = getPassStrings(lines);
            int output = validPassports(passports);
            Console.WriteLine($"There are {output} valid passports!");
            Console.ReadKey();
        }

        public static string[] getPassStrings(string[] lines)
        {
            List<int> splitIndexes = new List<int>();
            List<string> passports = new List<string>();
            int i = 0;

            //Finds where the splits between passports are, given their varying line numbers
            foreach (string line in lines)
            {
                if (line == "")
                {
                    splitIndexes.Add(i);
                }
                i++;
            }

            for (int j = 0; j < splitIndexes.Count + 1; j++)
            {
                if (j == splitIndexes.Count)
                {
                    string temp = "";
                    int firstPassLine = splitIndexes[j - 1] + 1;
                    int lastPassLine = lines.Length - 1;

                    for (int x = firstPassLine; x <= lastPassLine; x++)
                    {
                        temp += lines[x];
                        if (x != lastPassLine)
                        {
                            temp += ' ';
                        }
                    }
                    passports.Add(temp);
                }
                else
                {
                    string temp = "";
                    int firstPassLine = 0;
                    if (j != 0)
                    {
                        firstPassLine = splitIndexes[j - 1] + 1;
                    }
                    int lastPassLine = splitIndexes[j] - 1;

                    for (int x = firstPassLine; x <= lastPassLine; x++)
                    {
                        temp += lines[x];
                        if (x != lastPassLine)
                        {
                            temp += ' ';
                        }
                    }
                    passports.Add(temp);
                }

            }
            return passports.ToArray();
        }

        public static int validPassports(string[] passports)
        {
            int validPasses = 0;

            foreach (string passport in passports)
            {
                bool byrCheck = false;
                bool iyrCheck = false;
                bool eyrCheck = false;
                bool hgtCheck = false;
                bool hclCheck = false;
                bool eclCheck = false;
                bool pidCheck = false;

                if (passport.Contains("byr"))
                {
                    byrCheck = true;
                }
                if (passport.Contains("iyr"))
                {
                    iyrCheck = true;
                }
                if (passport.Contains("eyr"))
                {
                    eyrCheck = true;
                }
                if (passport.Contains("hgt"))
                {
                    hgtCheck = true;
                }
                if (passport.Contains("hcl"))
                {
                    hclCheck = true;
                }
                if (passport.Contains("ecl"))
                {
                    eclCheck = true;
                }
                if (passport.Contains("pid"))
                {
                    pidCheck = true;
                }

                if(byrCheck == true & iyrCheck == true & eyrCheck == true & hgtCheck == true & hclCheck == true & eclCheck == true & pidCheck == true)
                {
                    validPasses++;
                }
            }



            return validPasses;
        }
    }
}