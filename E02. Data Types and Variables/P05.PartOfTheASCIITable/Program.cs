namespace P05.PartOfTheASCIITable
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            //char -> int / int -> char
            for (int i = startIndex; i <= endIndex; i++)
            {
                //We have numeric value of the character in our memory
                //We need to cast in order to get visual representation of the number
                char currCh = (char)i;
                Console.Write(currCh + " ");
            }
        }
    }
}
