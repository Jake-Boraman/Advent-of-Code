using System;
using System.Linq;
using System.Collections.Generic;

namespace subBingo
{
    class Program
    {
        static void Main(string[] args)
        {
            int multiplier = 0; // Holds the last bingo number called, for use in score calc
            int numBoards = numBoardsFinder(); // Holds the total number of boards in play
            List<int[,]> allBoardsScore = new List<int[,]>(); // Holds all of the 2D arrays for keeping track of scores
            List<int> winOrder = new List<int>(); // Order of numbers (e.g. 2, 0, 1) shows the order the respective boards won in

            // Loops through all boards, initialises score arrays for each
            for (int i = 0; i < numBoards; i++)
            {
                int[,] boardScore = new int[5, 5];
                allBoardsScore.Add(boardScore);
            }

            allBoardsScore.ToArray(); // Convert list to array

            // Grab all numbers to be drawn for bingo game
            int[] drawNums = Array.ConvertAll(System.IO.File.ReadLines(@"bingo.txt").First().Split(','), int.Parse);

            // Converts txt board data into useable arrays
            string[][] boardVals = boardValsToArray();

            bool loopDone = false; // True once final board has gotten a "bingo"

            // Loops through all of the bingo number calls
            foreach (int value in drawNums)
            {

                if (!loopDone)  // Check if the last board has won already
                {
                    // Loop through every board
                    for (int i = 0; i < numBoards; i++)
                    {
                        bool won = false;
                        // Pass boardChecker the current board's scoresheet, valsheet, and current value to check
                        allBoardsScore[i] = boardChecker(allBoardsScore[i], boardVals[i], value);
                        won = bingoChecker(allBoardsScore[i]);

                        if (won)
                        {
                            if (!winOrder.Contains(i))
                            {
                                winOrder.Add(i);
                                if (winOrder.Count() == numBoards)
                                {
                                    loopDone = true;
                                    multiplier = value;
                                }
                            }
                        }
                    }
                }
            }

            // Output the one-based number of the board that won last
            Console.WriteLine("Board " + (winOrder.Last() + 1) + " won last!\nCalculating score...");

            // Pass scoreFinder the last board to win's scoresheet, datasheet, and the most recent bingo number called
            int score = scoreFinder(allBoardsScore[winOrder.Last()], boardVals[winOrder.Last()], multiplier);

            Console.WriteLine("\nBoard number " + (winOrder.Last() + 1) + " scored " + score + " points!");
            Console.ReadKey();
        }

        static int numBoardsFinder()
        {
            // Calculates how many boards are in play based on number of lines in file
            int numLines = File.ReadLines(@"bingo.txt").Count();
            int numBoards = (numLines - 1) / 6;
            return numBoards;
        }

        static string[][] boardValsToArray()
        {
            int numBoards = numBoardsFinder();

            // Can assume that there is always at least 1 board
            List<int> boardStartLines = new List<int>();

            //Loops through every board, adding its starting line number to the List
            for (int i = 0; i < numBoards; i++)
            {
                boardStartLines.Add(3 + (6 * i));
            }

            string[][] boardVals = getBoardData(boardStartLines.ToArray()).ToArray();

            return boardVals;
        }
        static List<string[]> getBoardData(int[] startLines)
        {
            List<string[]> arrayList = new List<string[]>();

            foreach (int line in startLines)
            {
                string[] board = System.IO.File.ReadLines(@"bingo.txt").Skip(line - 1).Take(5).ToArray();
                arrayList.Add(board);
            }

            return arrayList;
        }

        static int[,] boardChecker(int[,] score, string[] boardVals, int valToCheck)
        {
            // Loop through each line in the board array
            int i = 0;
            foreach (string line in boardVals)
            {
                // Split line string into separate values (will contain nulls)
                string[] values = line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                // Loop through every value in line
                int j = 0;
                foreach (string number in values)
                {
                    // Ignores null values
                    if (number != "")
                    {
                        if (Int32.Parse(number) == valToCheck)
                        {
                            score[i, j] = 1;
                        }
                    }
                    j++;
                }
                i++;
            }

            return score;
        }

        static bool bingoChecker(int[,] scoreSheet)
        {
            bool haveTheyWon = false;

            // Check horizontal
            for (int i = 0; i < 5; i++)
            {
                haveTheyWon = true;

                for (int y = 0; y < 5; y++)
                {
                    if (scoreSheet[i, y] == 0)
                    {
                        haveTheyWon = false;
                        break;
                    }
                }

                if (haveTheyWon)
                {
                    return haveTheyWon;
                }
            }

            if (!haveTheyWon)
            {
                // Check vertical
                for (int i = 0; i < 5; i++)
                {
                    haveTheyWon = true;

                    for (int y = 0; y < 5; y++)
                    {
                        if (scoreSheet[y, i] == 0)
                        {
                            haveTheyWon = false;
                            break;
                        }
                    }

                    if (haveTheyWon)
                    {
                        return haveTheyWon;
                    }
                }
            }

            return false;
        }

        static int scoreFinder(int[,] scoreSheet, string[] boardVals, int value)
        {
            int totalScore = 0;

            int[,] boardsValsList = new int[5, 5];

            // Loops convert the 1D string array boardVals into a 2D array that can be used to compare against the scoreSheet
            int y = 0;
            foreach (string row in boardVals)
            {
                string[] values = row.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                int z = 0;
                foreach (string x in values)
                {
                    boardsValsList[y, z] = Int32.Parse(x);

                    z++;
                }
                y++;
            }

            // Loop every value in scoreSheet, if the value is 1, increment the totalScore by the value 
            // at the same position in the values array
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (scoreSheet[i, j] == 0)
                    {
                        totalScore += boardsValsList[i, j];
                    }
                }
            }

            return totalScore * value;
        }
    }
}