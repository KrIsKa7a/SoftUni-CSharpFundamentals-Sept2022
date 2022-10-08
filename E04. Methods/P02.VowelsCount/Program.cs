namespace P02.VowelsCount
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            //1 way -> void Method (string text) -> Console.WriteLine()
            //2 way -> int Method (string text) -> Main: Console.WriteLine();
            //Second way is mostly used
            string text = Console.ReadLine();
            int vowelsCount = GetVowelsCount(text);
            Console.WriteLine(vowelsCount);
        }

        static int GetVowelsCount(string text)
        {
            //Y may be not considered as vowel
            int vowelsCount = 0;

            char[] vowels = new char[] { 'a', 'e', 'o', 'u', 'i', 'y' };
            foreach (char letter in text.ToLower())
            {
                if (MyContains(vowels, letter))
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }

        static bool MyContains(char[] arr, char searchChar)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                char currChar = arr[i];
                if (currChar == searchChar)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
