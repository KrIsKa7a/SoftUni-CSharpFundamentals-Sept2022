using System;
using System.Linq;

namespace P10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] randomNumbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                randomNumbers[i] = random.Next(100);
            }

            Console.WriteLine(String.Join(" ", randomNumbers));

            //1. Initialize empty field
            int n = int.Parse(Console.ReadLine()); //Field size
            int[] field = new int[n];
            //bool[] boolField = new bool[n]; //Empty -> False, Ladybug -> True

            //2. Spawn ladybugs on the valid indexes
            //This collection remains unchanged!
            int[] initialIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            foreach (int index in initialIndexes)
            {
                if (index >= 0 && index < field.Length)
                {
                    //Valid index => Initialize ladybug on this index (1)
                    field[index] = 1;
                }
            }

            //3. Proceed game moves (Start Game)
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int ladybugIndex = int.Parse(cmdArgs[0]);
                string direction = cmdArgs[1];
                int flyLength = int.Parse(cmdArgs[2]);

                //3.1. Validate ladybugIndex is inside the field!
                if (ladybugIndex < 0 || ladybugIndex >= field.Length)
                {
                    //Invalid index => Nothing happens
                    continue;
                }

                //3.2. Validate ladybugIndex contains ladybug
                if (field[ladybugIndex] == 0)
                {
                    //There is no ladybug there => Nothing happens
                    continue;
                }

                //3.3. Try to proceed move
                //Right -> ladybugIndex + flyLength
                //Left -> ladybugIndex - flyLength
                //First -> Our ladybug starts flying => it removes from the field, it is in the air
                field[ladybugIndex] = 0;
                if (direction == "left")
                {
                    flyLength *= -1; //1 => -1
                }

                //0 Right 1 => 0 + 1 = 1
                //1 Left 1 => 1 + (-1) = 0
                int nextIndex = ladybugIndex + flyLength;
                while (nextIndex >= 0 && nextIndex < field.Length && field[nextIndex] == 1)
                {
                    //Precalculate next index in case we step on another ladybug
                    nextIndex += flyLength;
                }

                //There are two possibilities:
                //Variant a: nextIndex is calculated somewhere in the field
                //Variant b: nextIndex cannot be calculated in the field
                if (nextIndex < 0 || nextIndex >= field.Length)
                {
                    //Variant b
                    //Outside of the field => Ladybug never lands
                    continue;
                }

                //Variant a
                //Land the ladybug on the valid next index
                field[nextIndex] = 1;
            }

            Console.WriteLine(String.Join(" ", field));
        }
    }
}
