using System;
using System.Collections.Generic;
using System.Linq;

namespace boardingpassID
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] passes = System.IO.File.ReadAllLines(@"boardingpasses.txt");
            int[] seatIDs = highestID(passes);
            int mySeatID = findMySeat(seatIDs);
            Console.WriteLine($"My seat ID is {mySeatID}!");
            Console.ReadKey();
        }

        public static int[] highestID(string[] passes)
        {
            List<int> seatIDList = new List<int>();
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
                seatIDList.Add(seatID);
            }
            return seatIDList.ToArray();
        }

        public static int findMySeat(int[] seatIDs)
        {
            int mySeat = 0;
            for (int i = 0; i < seatIDs.Length; i++)
            {
                int currentSeat = seatIDs[i];

                //Positive Check
                if (seatIDs.Contains(currentSeat + 2))
                {
                    if (!seatIDs.Contains(currentSeat + 1))
                    {
                        mySeat = currentSeat + 1;
                    }
                }

                //Negative check
                if (mySeat == 0)
                {
                    if (seatIDs.Contains(currentSeat - 2))
                    {
                        if (!seatIDs.Contains(currentSeat - 1))
                        {
                            mySeat = currentSeat - 1;
                        }
                    }
                }

            }
            return mySeat;
        }
    }
}