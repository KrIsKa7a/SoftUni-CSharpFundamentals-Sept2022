using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = new List<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];

                if (cmdArgs.Length == 3)
                {
                    //is going
                    if (guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }

                    guestList.Add(name);
                }
                else if (cmdArgs.Length == 4)
                {
                    //is not going
                    if (!guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                        continue;
                    }

                    guestList.Remove(name);
                }
            }

            PrintGuestList(guestList);
        }

        static void PrintGuestList(List<string> guestList)
        {
            //Change in the list here will be appended in the Main()
            foreach (string name in guestList)
            {
                Console.WriteLine(name);
            }
        }

        static void PrintGuestListAlphabetically(List<string> guestList)
        {
            //OrderByDescending = OrderBy + Reverse
            List<string> orderedList = guestList
                .OrderBy(e => e) //Will learn it later in the course!
                .ToList();
            foreach (string name in orderedList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
