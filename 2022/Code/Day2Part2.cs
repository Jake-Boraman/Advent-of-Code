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

                // Type score
                switch(plays[1]){
                    case "X":
                        tempscore += 1;
                        break;
                    case "Y":
                        tempscore += 2;
                        break;
                    case "Z":
                        tempscore += 3;
                        break;
                    default:
                        Console.WriteLine("what the fuck");
                        break;
                }

                // Win/Lose score
                if (plays[0] == "A"){ // Rock
                    if (plays[1] == "Y"){
                        tempscore += 6;
                    }
                    else if (plays[1] == "X"){
                        tempscore += 3;
                    }
                }
                if (plays[0] == "B"){ // Paper
                    if (plays[1] == "Z"){
                        tempscore += 6;
                    }
                    else if (plays[1] == "Y"){
                        tempscore += 3;
                    }
                }
                else if (plays[0] == "C"){ // Scissors
                    if (plays[1] == "X"){
                        tempscore += 6;
                    }
                    else if (plays[1] == "Z"){
                        tempscore += 3;
                    }
                }
                totalscore += tempscore;
            }

            Console.WriteLine(totalscore);
        }
    }
}