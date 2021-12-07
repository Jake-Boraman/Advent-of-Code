using System;
using System.Linq;
using System.Collections.Generic;

namespace subDiagnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"diagnostic.txt");
            int power = powerCalc(input);
            int life = lifeSupCalc(input);
            Console.WriteLine("The Power Consumption of the sub is: " + power + " Watts");
            Console.WriteLine("The Life Support Rating of the sub is: " + life + " Units");
            Console.ReadKey();
        }

        static int powerCalc(string[] diagnostics)
        {
            int gammaRate = gammaFinder(diagnostics);
            int epsilonRate = epsilonFinder(gammaRate);

            int powerConsumption = gammaRate * epsilonRate;

            return powerConsumption;
        }

        static int lifeSupCalc(string[] diagnostics)
        {
            int oxyRating = oxygenFinder(diagnostics);
            int c02Rating = c02Finder(diagnostics);


            return oxyRating * c02Rating;
        }

        static int gammaFinder(string[] diagnostics)
        {
            string gammaBinary = "";
            int length = diagnostics[0].Length;

            for (int i = 0; i < length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;

                for (int j = 0; j < diagnostics.Length; j++)
                {
                    int firstDigit = Int32.Parse(diagnostics[j].Substring(i, 1));
                    if (firstDigit == 0)
                    {
                        zeroCount++;
                    }
                    else
                    {
                        oneCount++;
                    }
                }

                if (oneCount > zeroCount)
                {
                    gammaBinary += '1';
                }
                else
                {
                    gammaBinary += '0';
                }
            }

            int gammaRate = Convert.ToInt32(gammaBinary, 2);

            return gammaRate;
        }

        static int epsilonFinder(int gammaRate)
        {
            string gammaRateString = Convert.ToString(gammaRate, 2);
            string inverted = new string(gammaRateString.Select(ch => ch == '0' ? '1' : '0').ToArray());
            int epsilonRate = Convert.ToInt32(inverted, 2);
            return epsilonRate;
        }

        static int oxygenFinder(string[] diagnostics)
        {
            string oxBinary = "";
            List<string> diagList = diagnostics.ToList();


            for (int x = 0; x < 12; x++)
            {
                int oneCount = 0;
                int zeroCount = 0;

                for (int i = 0; i < diagList.Count(); i++)
                {
                    string firstChar = diagList[i].Substring(x, 1);
                    if (firstChar == "1")
                    {
                        oneCount++;
                    }
                    else if (firstChar == "0")
                    {
                        zeroCount++;
                    }
                }

                if (oneCount >= zeroCount)
                {
                    for (int i = 0; i < diagList.Count(); i++)
                    {
                        if (diagList[i].Substring(x, 1) == "0")
                        {
                            diagList[i] = "invalidvalue";
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < diagList.Count(); i++)
                    {
                        if (diagList[i].Substring(x, 1) == "1")
                        {
                            diagList[i] = "invalidvalue";
                        }
                    }
                }
            }

            foreach (string value in diagList)
            {
                if (value != "invalidvalue")
                {
                    oxBinary = value;
                }
            }

            int oxyGenRate = Convert.ToInt32(oxBinary, 2);

            return oxyGenRate;
        }

        static int c02Finder(string[] diagnostics)
        {
            string c02Binary = "";
            List<string> diagList = diagnostics.ToList();

            for (int x = 0; x < 12; x++)
            {
                int oneCount = 0;
                int zeroCount = 0;

                for (int i = 0; i < diagList.Count(); i++)
                {
                    string firstChar = diagList[i].Substring(x, 1);
                    if (firstChar == "1")
                    {
                        oneCount++;
                    }
                    else if (firstChar == "0")
                    {
                        zeroCount++;
                    }
                }

                if (!(oneCount == 1 && zeroCount == 0))
                {
                    if (!(oneCount == 0 && zeroCount == 1))
                    {
                        if (oneCount < zeroCount)
                        {
                            for (int i = 0; i < diagList.Count(); i++)
                            {
                                if (diagList[i].Substring(x, 1) == "0")
                                {
                                    diagList[i] = "invalidvalue";
                                }
                            }
                        }
                        else if (oneCount >= zeroCount)
                        {
                            for (int i = 0; i < diagList.Count(); i++)
                            {
                                if (diagList[i].Substring(x, 1) == "1")
                                {
                                    diagList[i] = "invalidvalue";
                                }
                            }
                        }
                    }

                }
            }

            foreach (string value in diagList)
            {
                if (value != "invalidvalue")
                {
                    c02Binary = value;
                }
            }

            int c02GenRate = Convert.ToInt32(c02Binary, 2);

            return c02GenRate;
        }
    }
}