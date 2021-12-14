using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace subVents
{
    class Program
    {
        static void Main(string[] args)
        {
            int finalCount = 0;
            var coordinates = new Dictionary<string, int>();
            List<int> counts = new List<int>();
            string[] vents = System.IO.File.ReadAllLines(@"vents.txt");

            foreach (string vent in vents)
            {
                int x1, y1, x2, y2;
                string[] parts = vent.Split(',');
                string[] middle = parts[1].Replace(" -> ", ",").Split(',');
                x1 = Int32.Parse(parts[0]);
                y1 = Int32.Parse(middle[0]);
                x2 = Int32.Parse(middle[1]);
                y2 = Int32.Parse(parts[2]);

                if (x1 == x2)
                {
                    if (y1 == y2)
                    {
                        string coord = x1.ToString();
                        coord += ", ";
                        coord += y1.ToString();
                        coordinates = updateDict(coordinates, coord);
                    }
                    else if (y2 > y1)
                    {
                        for (int j = 0; j < (y2 - y1) + 1; j++)
                        {
                            string coord = x1.ToString();
                            coord += ", ";
                            coord += (j + y1).ToString();
                            coordinates = updateDict(coordinates, coord);
                        }
                    }
                    else if (y1 > y2)
                    {
                        for (int j = 0; j < (y1 - y2) + 1; j++)
                        {
                            string coord = x1.ToString();
                            coord += ", ";
                            coord += (y1 - j).ToString();
                            coordinates = updateDict(coordinates, coord);
                        }
                    }
                }
                else if (y1 == y2)
                {
                    if (x1 == x2)
                    {
                        string coord = x1.ToString();
                        coord += ", ";
                        coord += y1.ToString();
                        coordinates = updateDict(coordinates, coord);
                    }
                    else if (x2 > x1)
                    {
                        for (int j = 0; j < (x2 - x1) + 1; j++)
                        {
                            string coord = (x1 + j).ToString();
                            coord += ", ";
                            coord += y1.ToString();
                            coordinates = updateDict(coordinates, coord);
                        }
                    }
                    else if (x1 > x2)
                    {
                        for (int j = 0; j < (x1 - x2) + 1; j++)
                        {
                            string coord = (x1 - j).ToString();
                            coord += ", ";
                            coord += y1.ToString();
                            coordinates = updateDict(coordinates, coord);
                        }
                    }
                }
            
                else if (x1 > x2)
                {
                    if (y1 > y2)
                    {
                        for (int i = 0; i < (x1 - x2) + 1; i++)
                        {
                            string coord = (x1 - i).ToString();
                            coord += ", ";
                            coord += (y1 - i).ToString();
                            coordinates = updateDict(coordinates, coord);
                        }
                    }

                    if (y2 > y1)
                    {
                        for (int i = 0; i < (x1 - x2) + 1; i++)
                        {
                            string coord = (x1 - i).ToString();
                            coord += ", ";
                            coord += (i + y1).ToString();
                            coordinates = updateDict(coordinates, coord);
                        }
                    }

                }

                else if(x2 > x1)
                {
                    if (y1 > y2)
                    {
                        for (int i = 0; i < (x2 - x1) + 1; i++)
                        {
                            string coord = (x1 + i).ToString();
                            coord += ", ";
                            coord += (y1 - i).ToString();
                            coordinates = updateDict(coordinates, coord);
                        }
                    }

                    if (y2 > y1)
                    {
                        for (int i = 0; i < (x2 - x1) + 1; i++)
                        {
                            string coord = (x1 + i).ToString();
                            coord += ", ";
                            coord += (i + y1).ToString();
                            coordinates = updateDict(coordinates, coord);
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, int> entry in coordinates)
            {
                if (entry.Value > 1)
                {
                    finalCount++;
                }
            }

            Console.WriteLine($"There are {finalCount} points where more than one lines overlap!");
            Console.ReadKey();
        }

        static Dictionary<string, int> updateDict(Dictionary<string, int> coordinates, string key)
        {
            if (coordinates.ContainsKey(key))
            {
                coordinates[key] += 1;
            }
            else
            {
                coordinates.Add(key, 1);
            }

            return coordinates;
        }
    }
}