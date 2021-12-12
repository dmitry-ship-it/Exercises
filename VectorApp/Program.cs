using System;
using System.Linq;

namespace VectorApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                try
                {
                    PrintMenu();
                    PrintSelected();
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
                    Console.WriteLine("Number is too large or too small.");
                }

                Console.WriteLine("Try something else? (y/n)");
            } while (Console.ReadKey(intercept: true).Key == ConsoleKey.Y);
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Select option:");
            Console.WriteLine("1. Add two vectors");
            Console.WriteLine("2. Substruct two vectors");
            Console.WriteLine("3. Dot product two vectors");
            Console.WriteLine("4. Cross product two vectors");
            Console.WriteLine("5. Scale single vector");
            Console.WriteLine("6. Exit");
            Console.Write(">> ");
        }

        private static void PrintSelected()
        {
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                    PrintDualVectorOperation(key);
                    break;
                case ConsoleKey.D5:
                    PrintSingleVectorOperation();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void PrintDualVectorOperation(ConsoleKey key)
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("First vector");
            var first = GetNewVector();
            Console.WriteLine();

            Console.WriteLine("Second vector");
            var second = GetNewVector();
            Console.WriteLine();

            Console.WriteLine($"First vector: {first}, length = {first.Length()}");
            Console.WriteLine($"Second vector: {second}, length = {second.Length()}");

            Vector3 result;
            switch (key)
            {
                case ConsoleKey.D1:
                    result = first + second;
                    Console.WriteLine($"After add operation: {result}, length = {result.Length()}");
                    break;
                case ConsoleKey.D2:
                    result = first - second;
                    Console.WriteLine($"After substruct operation: {result}, length = {result.Length()}");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine($"Value after dot product operation: {first * second}");
                    break;
                case ConsoleKey.D4:
                    result = first & second;
                    Console.WriteLine($"After cross product operation: {result}, length = {result.Length()}");
                    break;
                default:
                    throw new ArgumentException("Invalid operation.", nameof(key));
            }
        }

        private static void PrintSingleVectorOperation()
        {
            Console.WriteLine();
            Console.WriteLine();

            var vector = GetNewVector();
            Console.WriteLine();
            Console.WriteLine("Enter scalar: ");
            var scalar = double.Parse(Console.ReadLine());

            Console.WriteLine($"After scale operation: {vector * scalar}");
        }

        private static Vector3 GetNewVector()
        {
            var components = GetComponents();
            return new Vector3(components[0], components[1], components[2]);
        }

        private static double[] GetComponents()
        {
            Console.WriteLine("Enter 3 components of vector separated by space:");

            var components = Parse(Console.ReadLine());

            if (components.Length != 3)
            {
                throw new ArgumentException("Not THREE side lengths were entered.");
            }

            return components;
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
