using System;
using System.Text;

namespace P01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder activationKey = new StringBuilder(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                ProcessCommands(activationKey, command);
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        static void ProcessCommands(StringBuilder activationKey, string command)
        {
            string[] cmdArgs = command
                    .Split(">>>"/*, StringSplitOptions.RemoveEmptyEntries*/);

            string cmdType = cmdArgs[0];
            if (cmdType == "Contains")
            {
                string subStr = cmdArgs[1];

                CheckKeyContainsSubStrAndPrintResult(activationKey, subStr);
            }
            else if (cmdType == "Flip")
            {
                string flipType = cmdArgs[1];
                int startIndex = int.Parse(cmdArgs[2]);
                int endIndex = int.Parse(cmdArgs[3]); //Exclusive

                FlipPartOfKeyToUpperOrLower(activationKey, flipType, startIndex, endIndex);
            }
            else if (cmdType == "Slice")
            {
                int startIndex = int.Parse(cmdArgs[1]);
                int endIndex = int.Parse(cmdArgs[2]); //Exclusive

                SlicePartOfKeyAndPrintIt(activationKey, startIndex, endIndex);
            }
        }

        static void CheckKeyContainsSubStrAndPrintResult(StringBuilder activationKey, string subStr)
        {
            if (activationKey.ToString().Contains(subStr))
            {
                Console.WriteLine($"{activationKey} contains {subStr}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }

        static void FlipPartOfKeyToUpperOrLower(StringBuilder activationKey, string flipType, int startIndex, int endIndex)
        {
            string subStr = activationKey.ToString()
                        .Substring(startIndex, endIndex - startIndex);
            if (flipType == "Upper")
            {
                subStr = subStr.ToUpper();
            }
            else if (flipType == "Lower")
            {
                subStr = subStr.ToLower();
            }

            //Operations of a StringBuilder -> really fast
            activationKey.Remove(startIndex, endIndex - startIndex);
            activationKey.Insert(startIndex, subStr);

            Console.WriteLine(activationKey);
        }

        static void SlicePartOfKeyAndPrintIt(StringBuilder activationKey, int startIndex, int endIndex)
        {
            activationKey.Remove(startIndex, endIndex - startIndex);

            Console.WriteLine(activationKey);
        }
    }
}
