using System;
using System.Linq;

namespace TriangleApp
{
    internal static class Program
    {
        private static void Main()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Enter 3 sides of the triangle, separated by space:");
                var sides = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    PrintTriangleInfo(sides);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Side length is too large or too small.");
                }

                Console.WriteLine("Try again? (y/n)");
            } while (Console.ReadKey(intercept: true).Key == ConsoleKey.Y);
        }

        private static void PrintTriangleInfo(string sides)
        {
            if (string.IsNullOrWhiteSpace(sides))
            {
                throw new ArgumentNullException(nameof(sides));
            }

            var parsedSides = Parse(sides);
            if (parsedSides.Length != 3)
            {
                throw new ArgumentException("Тot THREE side lengths were enterded.");
            }

            var triangle = new Triangle(parsedSides[0], parsedSides[1], parsedSides[2]);

            Console.WriteLine(triangle);
        }

        private static double[] Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentNullException(nameof(s));
            }

            var splitted = s
                .Split(' ')
                .Where(item => !string.IsNullOrWhiteSpace(item))
                .ToArray();

            var result = new double[splitted.Length];

            for (var i = 0; i < splitted.Length; i++)
            {
                result[i] = double.Parse(splitted[i]);
            }

            return result;
        }
    }
}
