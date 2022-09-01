using System;
using System.Linq;

namespace Gcd
{
    public static class Program
    {
        private static void Main()
        {
            do
            {
                PrintMenu();
                ChooseMethod();

                Console.WriteLine("Try another method and/or numbers? (y/n)");
            } while (Console.ReadKey(intercept: true).Key == ConsoleKey.Y);
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Select a method for calculating GDC:");
            Console.WriteLine("1. Euclidean");
            Console.WriteLine("2. Stein (only for two numbers)");
            Console.WriteLine("3. Exit");
            Console.Write(">> ");
        }

        private static void ChooseMethod()
        {
            try
            {
                switch (Console.ReadKey(intercept: false).Key)
                {
                    case ConsoleKey.D1:
                        UseEuclideanMethod();
                        break;
                    case ConsoleKey.D2:
                        UseSteinMethod();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("One of numbers in too large.");
            }
        }

        private static void UseEuclideanMethod()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter numbers separated by space:");

            var parsed = Parse(Console.ReadLine());

            Console.WriteLine($"GCD of this numbers is {CustomGcd.GetByEuclidean(out var ticks, parsed)}.");
            Console.WriteLine($"Execution time: {TimeSpan.FromTicks(ticks).TotalMilliseconds}ms");
            Console.WriteLine();
        }

        private static void UseSteinMethod()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter two numbers separated by space:");

            var input = Parse(Console.ReadLine());

            if (input.Length != 2)
            {
                Console.WriteLine("Not TWO digits entered.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine($"GCD of this numbers is {CustomGcd.GetByStein(out var ticks, input[0], input[1])}.");
            Console.WriteLine($"Execution time: {TimeSpan.FromTicks(ticks).TotalMilliseconds}ms");
            Console.WriteLine();
        }

        private static int[] Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentNullException(nameof(s));
            }

            var splitted = s
                .Split(' ')
                .Where(item => !string.IsNullOrWhiteSpace(item))
                .ToArray();

            var result = new int[splitted.Length];

            for (var i = 0; i < splitted.Length; i++)
            {
                result[i] = int.Parse(splitted[i]);
            }

            return result;
        }
    }
}