namespace P10.RageExpenses
{
    using System;
    using System.Diagnostics;

    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            Stopwatch sw = Stopwatch.StartNew();
            //Act
            int headsetCnt = 0;
            int mouseCnt = 0;
            int keyboardCnt = 0;
            int displayCnt = 0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    headsetCnt++;
                }

                if (i % 3 == 0)
                {
                    mouseCnt++;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardCnt++;
                }

                if (i % 12 == 0)
                {
                    displayCnt++;
                }
            }
            //int headsetCnt = lostGames / 2;
            //int mouseCnt = lostGames / 3;
            //int keyboardCnt = lostGames / 6;
            //int displayCnt = lostGames / 12;

            //Output
            double expenses = (headsetCnt * headsetPrice) + (mouseCnt * mousePrice) +
                (keyboardCnt * keyboardPrice) + (displayCnt * displayPrice);
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
