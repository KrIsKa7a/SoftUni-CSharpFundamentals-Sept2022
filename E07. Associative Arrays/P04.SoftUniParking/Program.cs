using System;
using System.Collections.Generic;

namespace P04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> register =
                new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                //Apart from Split() almost all other LINQ Functions require ToArray() after them
                //After Where(), Select(), OrderBy()... we write ToArray()
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];
                string username = cmdArgs[1];

                if (cmdType == "register")
                {
                    string licensePlateNumber = cmdArgs[2];

                    if (!register.ContainsKey(username))
                    {
                        register[username] = licensePlateNumber;
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        //string registeredPlateNumber = register[username];
                        Console.WriteLine($"ERROR: already registered with plate number {register[username]}");
                    }
                }
                else if (cmdType == "unregister")
                {
                    if (!register.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        register.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in register)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
