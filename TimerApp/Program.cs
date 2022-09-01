using System;

namespace TimerApp
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Clear();
            Console.WriteLine("How much to wait?");
            Console.Write("Seconds = ");
            if (!double.TryParse(Console.ReadLine(), out var seconds))
            {
                Console.WriteLine("Invalid value.");
                Console.WriteLine("Try again? (y/n)");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Main();
                }

                return;
            }

            var timer = new Timer(seconds);
            timer.OnTimerEnds += () => Console.WriteLine("Timer stops.");

            Console.WriteLine("Timer starts.");
            timer.Start();
        }
    }
}