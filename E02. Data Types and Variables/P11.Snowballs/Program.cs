namespace P11.Snowballs
{
    using System;
    using System.Numerics;

    internal class Program
    {
        static void Main(string[] args)
        {
            //n = total snowballs
            int n = int.Parse(Console.ReadLine());

            //maxValue is used for comparison and finding the max value!!!
            BigInteger maxValue = BigInteger.MinusOne;
            //These are just variables holding some properties of the maxed snowball
            //We need them just for the output
            int maxSnow = 0;
            int maxTime = 0;
            int maxQuality = 0;
            for (int i = 0; i < n; i++)
            {
                //1 iteration -> 1 snowball
                //For each snowball -> 3 lines
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowballValue > maxValue)
                {
                    maxValue = snowballValue;
                    maxSnow = snowballSnow;
                    maxTime = snowballTime;
                    maxQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{maxSnow} : {maxTime} = {maxValue} ({maxQuality})");
        }
    }
}
