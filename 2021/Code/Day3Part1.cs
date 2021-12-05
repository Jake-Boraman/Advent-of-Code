using System;
using System.Linq;

namespace subDiagnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"diagnostic.txt");
            int output = diagnosticCalc(input);
            Console.WriteLine("The Power Consumption of the sub is: " + output + " Watts");
            Console.ReadKey();
        }

        static int diagnosticCalc(string[] diagnostics)
        {
            int gammaRate = gammaFinder(diagnostics);
            int epsilonRate = epsilonFinder(gammaRate);

            int powerConsumption = gammaRate * epsilonRate;

            return powerConsumption;
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
    }
}