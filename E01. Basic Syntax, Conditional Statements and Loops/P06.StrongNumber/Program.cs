namespace P06.StrongNumber
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //Modular division by 10 -> return last digit
            //Integer division by 10 -> removes last digit
            int numCopy = n;
            int factorialSum = 0;
            while (numCopy > 0)
            {
                //n += 1; //add one -> n = n + 1;
                //n -= 1; //subtract one -> n = n - 1;
                //n *= 2; //multiply by two -> n = n * 2;
                //n /= 10; //divide by ten -> n = n / 10;
                //n %= 10; //modular by ten -> n = n % 10;
                int lastDigit = numCopy % 10; //Take last digit
                numCopy /= 10; //Remove the taken digit

                //Calculate factorial of last digit
                //Stores a product -> start from 1 -> 1 * n = n; 0 * n = 0 (wrong)
                int factorial = 1;
                for (int i = 2; i <= lastDigit; i++)
                {
                    factorial *= i; //factorial = factorial * i;
                }

                //Summing factorial
                factorialSum += factorial;
            }

            if (factorialSum == n)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
