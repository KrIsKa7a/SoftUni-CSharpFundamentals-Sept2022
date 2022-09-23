namespace P08.TriangleOfNumbers
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            //Outer loop represents rows
            for (int row = 1; row <= n; row++)
            {
                if (type == "Isosceles")
                {
                    int spacesCnt = n - row;
                    for (int spaces = 1; spaces <= spacesCnt; spaces++)
                    {
                        Console.Write(" ");
                    }
                }

                //Nested loop represents columns
                for (int col = 1; col <= row; col++)
                {
                    Console.Write($"{row} ");
                }

                //Console new row
                Console.WriteLine();
            }
        }
    }
}
