using System;
using System.Linq;
using System.Text.RegularExpressions;
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
            int validPasses = -1;

            foreach (string passport in passports)
            {
                bool byrCheck = false;
                bool byrValFld = false;
                bool iyrCheck = false;
                bool iyrValFld = false;
                bool eyrCheck = false;
                bool eyrValFld = false;
                bool hgtCheck = false;
                bool hgtValFld = false;
                bool hclCheck = false;
                bool hclValFld = false;
                bool eclCheck = false;
                bool eclValFld = false;
                bool pidCheck = false;
                bool pidValFld = false;

                if (passport.Contains("byr"))
                {
                    byrCheck = true;
                    int value = 0;
                    int valIndex = passport.IndexOf("byr:") + 4;
                    if (!int.TryParse(passport.Substring(valIndex, 4), out value))
                    {
                        byrValFld = false;
                    }
                    if (value >= 1920 & value <= 2002)
                    {
                        byrValFld = true;
                    }
                }
                if (passport.Contains("iyr"))
                {
                    iyrCheck = true;
                    int value = 0;
                    int valIndex = passport.IndexOf("iyr:") + 4;
                    if (!int.TryParse(passport.Substring(valIndex, 4), out value))
                    {
                        iyrValFld = false;
                    }
                    if (value >= 2010 & value <= 2020)
                    {
                        iyrValFld = true;
                    }
                }
                if (passport.Contains("eyr"))
                {
                    eyrCheck = true;
                    int value = 0;
                    int valIndex = passport.IndexOf("eyr:") + 4;
                    if (!int.TryParse(passport.Substring(valIndex, 4), out value))
                    {
                        eyrValFld = false;
                    }
                    if (value >= 2020 & value <= 2030)
                    {
                        eyrValFld = true;
                    }
                }
                if (passport.Contains("hgt"))
                {
                    hgtCheck = true;
                    int numHeightChars = 0;
                    int value = 0;
                    string heightType = "";
                    try
                    {
                        int valIndex = passport.IndexOf("hgt:") + 4;
                        string twoChars = passport.Substring(valIndex, 4);
                        if (!twoChars.Contains("cm") & !twoChars.Contains("in"))
                        {
                            numHeightChars = 3;
                        }
                        else
                        {
                            numHeightChars = 2;
                        }

                        value = Int32.Parse(passport.Substring(valIndex, numHeightChars));
                        heightType = passport.Substring(valIndex + numHeightChars, 2);

                        if (heightType == "cm")
                        {
                            if (value >= 150 & value <= 193)
                            {
                                hgtValFld = true;
                            }
                        }
                        else
                        {
                            if (value >= 59 & value <= 76)
                            {
                                hgtValFld = true;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        hgtValFld = false;
                    }




                }
                if (passport.Contains("hcl"))
                {
                    Regex rgx = new Regex(@"^[a-zA-Z0-9]{6,}$");
                    hclCheck = true;
                    int hashIndex = passport.IndexOf("hcl:") + 4;
                    string hashtag = passport.Substring(hashIndex, 1);
                    int endIndex = passport.Length - 1;
                    try
                    {
                        string value = passport.Substring(hashIndex + 1, 6);

                        if (hashtag == "#")
                        {
                            if (rgx.IsMatch(value))
                            {
                                hclValFld = true;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        hclValFld = false;
                    }



                }
                if (passport.Contains("ecl"))
                {
                    eclCheck = true;
                    string[] eyeColours = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                    int colIndex = passport.IndexOf("ecl:") + 4;
                    int passportEnd = passport.Length-1;
                    try
                    {
                        int nextColonIndex = passport.IndexOf(":", colIndex);
                        int difference = nextColonIndex - colIndex;
                        string colour = passport.Substring(colIndex, 3);

                        if (difference == 7)
                        {
                            if (eyeColours.Contains(colour))
                            {
                                eclValFld = true;
                            }
                        }
                        else if(colIndex + 2 == passportEnd)
                        {
                            eclValFld = true;
                        }
                    }
                    catch (Exception e)
                    {
                        eclValFld = false;
                    }



                }
                if (passport.Contains("pid"))
                {
                    pidCheck = true;
                    Regex rgx = new Regex(@"^[0-9]{9,}$");
                    int startIndex = passport.IndexOf("pid:") + 4;
                    try
                    {
                        string value = passport.Substring(startIndex, 9);
                        if (rgx.IsMatch(value))
                        {
                            pidValFld = true;
                        }
                    }
                    catch (Exception e)
                    {
                        pidValFld = false;
                    }


                }

                if (byrCheck == true & iyrCheck == true & eyrCheck == true & hgtCheck == true & hclCheck == true & eclCheck == true & pidCheck == true)
                {
                    if (byrValFld == true & iyrValFld == true & eyrValFld == true & hgtValFld == true & hclValFld == true & eclValFld == true & pidValFld == true)
                    {
                        validPasses++;
                    }

                }
            }
            return validPasses;
        }
    }
}