using System;

namespace rockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalscore = 0;
            string[] inputs = System.IO.File.ReadAllLines("input.txt");

            foreach (string play in inputs){
                int tempscore = 0;
                string[] plays = play.Split(' ');

                // Win/Lose score
                switch(plays[1]){
                    case "Y":
                        tempscore += 3; // Draw score
                        break;
                    case "Z":
                        tempscore += 6; // Win score
                        break;
                    default:
                        Console.WriteLine("no score"); // Lose score is 0
                        break;
                }

                // Shape score
                if (plays[0] == "A"){ // Rock
                    if (plays[1] == "X"){
                        tempscore += 3; // Play scissors to lose
                    }
                    else if (plays[1] == "Y"){
                        tempscore += 1; // Play rock to draw
                    }
                    else if (plays[1] == "Z"){
                        tempscore += 2; // Play paper to win
                    }
                }
                else if (plays[0] == "B"){ // Paper
                    if (plays[1] == "X"){
                        tempscore += 1; // Play rock to lose
                    }
                    else if (plays[1] == "Y"){
                        tempscore += 2; // Play paper to draw
                    }
                    else if (plays[1] == "Z"){
                        tempscore += 3; // Play scissors to win
                    }
                }
                else if (plays[0] == "C"){ // Scissors
                    if (plays[1] == "X"){
                        tempscore += 2; // Play paper to lose
                    }
                    else if (plays[1] == "Y"){
                        tempscore += 3; // Play scissors to draw
                    }
                    else if (plays[1] == "Z"){
                        tempscore += 1; // Play rock to win
                    }
                }
                totalscore += tempscore;
            }

            Console.WriteLine(totalscore);
        }
    }
}