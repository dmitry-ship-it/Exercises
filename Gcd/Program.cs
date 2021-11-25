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
                Console.Clear();
                Console.WriteLine("Select a method for calculating GDC:");
                Console.WriteLine("1. Euclidean");
                Console.WriteLine("2. Stein (only for two numbers)");
                Console.WriteLine("3. Exit");
                Console.Write(">> ");

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
                            return;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                }

                Console.WriteLine("Try another method and/or numbers? (y/n)");
            } while (Console.ReadKey(intercept: true).Key == ConsoleKey.Y);
        }

        private static void UseEuclideanMethod()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter numbers separated by space:");

            var parsed = Parse(Console.ReadLine());

            Console.WriteLine($"GCD of this numbers is {CustomGcd.GetGcdByEuclidean(parsed)}.");
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
            
            Console.WriteLine($"GCD of this numbers is {CustomGcd.GetGcdByStein(input[0], input[1])}.");
            Console.WriteLine();
        }

        private static int[] Parse(string s)
        {
            if (s is null)
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