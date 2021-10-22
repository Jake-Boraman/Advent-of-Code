using System;
using System.Linq;

namespace naughtyOrNiceString
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = GetNiceStringCountAfterSantaHadRevisedHisClearlyRidiculousRulesBecauseNewRulesRockAndWeShouldAlwaysTotallyBeMovingForward();
            Console.WriteLine($"Result: {result}!");
            Console.ReadKey();
        }

        public static int GetNiceStringCountAfterSantaHadRevisedHisClearlyRidiculousRulesBecauseNewRulesRockAndWeShouldAlwaysTotallyBeMovingForward()
        {
            // God damn it, santa.
            var strings = System.IO.File.ReadAllLines("strings.txt");

            var ret = strings.Where(s => HasPair(s) && HasRepeats(s)).ToList();

            return ret.Count;
        }

        private static bool HasPair(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                string pair = s.Substring(i, 2);
                if (s.IndexOf(pair, i + 2) != -1)
                    return true;
            }

            return false;
        }

        private static bool HasRepeats(string s)
        {
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (s[i] == s[i + 2])
                    return true;
            }

            return false;
        }
    }
}