using System;
using System.Linq;

namespace MatrixApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                PrintMenu();
                ChooseAndExecuteOperation();

                Console.WriteLine("Try again? (y/n)");
            } while (Console.ReadKey(intercept: true).Key == ConsoleKey.Y);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Matrix App Menu");
            Console.WriteLine("1. Add two matrices");
            Console.WriteLine("2. Subtract two matrices");
            Console.WriteLine("3. Multiply two matrices");
            Console.WriteLine("4. Exit");
            Console.Write(">> ");
        }

        private static void ChooseAndExecuteOperation()
        {
            var key = Console.ReadKey(intercept: false).Key;

            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                    GetMatricesAndExecuteOpeartion(key);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void GetMatricesAndExecuteOpeartion(ConsoleKey key)
        {
            Matrix lhs;
            Matrix rhs;

            Console.WriteLine();
            Console.WriteLine();

            try
            {
                Console.WriteLine("First matrix:");
                lhs = GetMatrix();
                Console.WriteLine("Second matrix:");
                rhs = GetMatrix();
                ExecuteOperationAndPrintResult(lhs, rhs, key);
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
        }

        private static Matrix GetMatrix()
        {
            Console.WriteLine("Enter number of cols and rows of matrix:");

            Console.Write("Cols = ");
            var cols = int.Parse(Console.ReadLine());

            Console.Write("Rows = ");
            var rows = int.Parse(Console.ReadLine());

            return new Matrix(GetArray(rows, cols));
        }

        private static double[,] GetArray(int rows, int cols)
        {
            if (rows < 1 || cols < 1)
            {
                throw new ArgumentException("Rows and cols numbers is less than zero.");
            }

            var result = new double[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter {cols} elements for row №{i + 1} separated by space:");
                FillRow(result, Parse(Console.ReadLine()), i);
            }

            Console.WriteLine();
            Console.WriteLine();

            return result;
        }

        private static void FillRow(double[,] result, double[] elements, int row)
        {
            if (elements.Length != result.GetLength(1))
            {
                throw new ArgumentException("Number of elements of row is invalid.");
            }

            for (int i = 0; i < elements.Length; i++)
            {
                result[row, i] = elements[i];
            }
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

        private static void ExecuteOperationAndPrintResult(Matrix lhs, Matrix rhs, ConsoleKey key)
        {
            Matrix result = key switch
            {
                ConsoleKey.D1 => lhs + rhs,
                ConsoleKey.D2 => lhs - rhs,
                ConsoleKey.D3 => lhs * rhs,
                _ => throw new ArgumentException("Invalid operation", nameof(key))
            };

            Console.WriteLine();
            Console.WriteLine("Result is:");
            Console.WriteLine(result);
        }
    }
}
