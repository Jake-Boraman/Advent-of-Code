using System.Text.RegularExpressions;

namespace supplyStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> instr = new List<string>();
            List<List<string>> newCargo = new List<List<string>>();
            for (int i = 0; i < 9; i++)
            {
                newCargo.Add(new List<string>());
            }

            foreach (string line in System.IO.File.ReadLines("input.txt"))
            {
                if (line.Contains('['))
                {
                    int locatedGroups = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == ' ')
                        {
                            if (i > 0)
                            {
                                // This is a group of spaces
                                newCargo[locatedGroups].Add("   ");
                                locatedGroups += 1;
                                i += 3;
                            }
                            else
                            {
                                // This is a blank group start
                                newCargo[locatedGroups].Add("   ");
                                locatedGroups += 1;
                                i += 3;
                            }

                        }
                        else if (line[i] == '[')
                        {
                            string cargo = "";
                            cargo += line[i];
                            cargo += line[i + 1];
                            cargo += line[i + 2];
                            newCargo[locatedGroups].Add(cargo);
                            locatedGroups += 1;
                            i += 3;
                        }
                    }
                }
                else if (line.Contains("move"))
                {
                    instr.Add(line);
                }
            }

            foreach (string command in instr)
            {
                string[] numbers = Regex.Split(command, @"\D+");
                List<string> cratesToMove = new List<string>();
                int j = 0;
                for (int i = 0; i < int.Parse(numbers[1]); i++)
                {
                    while (newCargo[int.Parse(numbers[2]) - 1][j] == "   ")
                    {
                        j++;
                    }
                    cratesToMove.Insert(0, newCargo[int.Parse(numbers[2]) - 1][j]);
                    newCargo[int.Parse(numbers[2]) - 1][j] = "   "; // Replace removed crate with blank space
                    j++;
                }

                foreach (string crate in cratesToMove)
                {
                    if (newCargo[int.Parse(numbers[3]) - 1][0] == "   ") // Check if the top space in the location to move to is empty
                    {
                        int location = 0;
                        foreach (string cargoSpace in newCargo[int.Parse(numbers[3]) - 1].ToList()) // Each space in destination
                        {
                            // Check if the cargo is completely blank in this column
                            bool empty = true;

                            foreach (string cg in newCargo[int.Parse(numbers[3]) - 1])
                            {
                                if (cg != "   ")
                                {
                                    empty = false;
                                }
                            }


                            if (empty == false)
                            {
                                if (cargoSpace == "   ")
                                {
                                    // Space is empty, keep going down
                                    location++;
                                }
                                else
                                {
                                    // Space is full, place on top
                                    newCargo[int.Parse(numbers[3]) - 1][location - 1] = crate;
                                    break;
                                }
                            }
                            else
                            {
                                int count = newCargo[int.Parse(numbers[3]) - 1].Count();
                                newCargo[int.Parse(numbers[3]) - 1][count - 1] = crate;
                            }
                        }
                    }
                    else
                    {
                        // Top cargo space is filled, needs adding on top
                        newCargo[int.Parse(numbers[3]) - 1].Insert(0, crate);
                    }
                }
            }

            foreach (List<string> column in newCargo)
            {
                int count = 0;
                foreach (string cargo in column)
                {
                    if (cargo != "   ")
                    {
                        Console.WriteLine(column[count]);
                        break;
                    }
                    count++;
                }
            }
        }
    }
}