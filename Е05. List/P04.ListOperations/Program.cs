using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.ListOperations
{
    //Append static keyword if you want to use extensions!
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];

                if (cmdType == "Add")
                {
                    int numberToAdd = int.Parse(cmdArgs[1]);
                    numbers.Add(numberToAdd);
                }
                else if (cmdType == "Insert")
                {
                    int number = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);

                    if (IsIndexInvalid(numbers, index))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, number);
                }
                else if (cmdType == "Remove")
                {
                    int removeIndex = int.Parse(cmdArgs[1]);

                    if (IsIndexInvalid(numbers, removeIndex))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(removeIndex);
                }
                else if (cmdType == "Shift")
                {
                    string direction = cmdArgs[1];
                    int count = int.Parse(cmdArgs[2]);

                    if (direction == "left")
                    {
                        ShiftListLeft(numbers, count);
                    }
                    else
                    {
                        ShiftListRight(numbers, count);
                    }
                }
            }

            Console.WriteLine(String.Join(' ', numbers));
        }

        //We do not have many benefits in the current example, it's just an example
        //Inline methods
        //=> (return)
        //return true when index is invalid, return false when index is valid
        static bool IsIndexInvalid(List<int> numbers, int index)
            => index < 0 || index >= numbers.Count;

        //Classical way
        static void ShiftListLeft(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int firstNumber = numbers[0]; //Always take first number
                numbers.RemoveAt(0); //Remove first number
                numbers.Add(firstNumber);
            }
        }

        static void ShiftListRight(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int lastNumber = numbers[numbers.Count - 1]; //Always take last number
                numbers.RemoveAt(numbers.Count - 1); //Remove last number
                numbers.Insert(0, lastNumber);
            }
        }

        static List<int> MethodWithOneReturnButTwoThings()
        {
            return new List<int>() { 1, 2, 3, 4, 5 };
        }

        //Just to see it
        //Extension method on List<int>
        //First parameter -> List<int>
        //static void Shift(this List<int> numbers, string direction, int count)
        //{
        //    if (direction == "Left")
        //    {
        //        for (int i = 0; i < count; i++)
        //        {
        //            int firstNumber = numbers[0]; //Always take first number
        //            numbers.RemoveAt(0); //Remove first number
        //            numbers.Add(firstNumber);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < count; i++)
        //        {
        //            int lastNumber = numbers[numbers.Count - 1]; //Always take last number
        //            numbers.RemoveAt(numbers.Count - 1); //Remove last number
        //            numbers.Insert(0, lastNumber);
        //        }
        //    }
        //}
    }
}
