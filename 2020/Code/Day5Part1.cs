using System;

namespace boardingpassID
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] passes = System.IO.File.ReadAllLines(@"boardingpasses.txt");
            int highest = highestID(passes);
            Console.WriteLine($"The seat ID {highest} is the highest in this list!");
            Console.ReadKey();
        }

        public static int highestID(string[] passes)
        {
            int maxID = 0;
            foreach (string pass in passes)
            {
                int row = 0;
                int column = 0;

                int rowMax = 127;
                int rowMin = 0;
                int colMax = 7;
                int colMin = 0;

                //Row finder
                string rowIdentifiers = pass.Substring(0, 7);
                for (int i = 0; i < rowIdentifiers.Length; i++)
                {
                    int half = ((rowMax - rowMin) / 2) + 1;
                    if (rowIdentifiers[i] == 'F')
                    {
                        rowMax -= half;
                    }
                    else
                    {
                        rowMin += half;
                    }
                }
                if (rowMin == rowMax)
                {
                    row = rowMax;
                }

                //Column finder
                string colIdentifiers = pass.Substring(7, 3);
                for (int i = 0; i < colIdentifiers.Length; i++)
                {
                    int half = ((colMax - colMin) / 2) + 1;
                    if (colIdentifiers[i] == 'L')
                    {
                        colMax -= half;
                    }
                    else
                    {
                        colMin += half;
                    }
                }
                if (colMin == colMax)
                {
                    column = colMax;
                }

                //Seat ID finder
                int seatID = (row * 8) + column;

                if (seatID > maxID)
                {
                    maxID = seatID;
                }
            }
            return maxID;
        }
    }
}