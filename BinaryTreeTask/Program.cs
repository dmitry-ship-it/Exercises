using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BinaryTreeTask
{
    internal static class Program
    {
        private static readonly BinaryTree<TestResult> _results = new();

        private static void Main()
        {
            Console.WriteLine("Enter path to file with test results (*.bin)");
            var path = Console.ReadLine();

            try
            {
                ReadTestResults(path);
                var formatted = GetFormattedResults();
                PrintFormattedResults(formatted);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format.");
            }
        }

        private static IEnumerable<TestResult> GetFormattedResults()
        {
            var sortOrder = GetSortOrder();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Choose sort order:");
            Console.WriteLine("1. Ascending");
            Console.WriteLine("2. Descending");
            Console.Write(">> ");

            var results = Console.ReadKey(intercept: false).Key switch
            {
                ConsoleKey.D1 => _results.OrderBy(sortOrder),
                ConsoleKey.D2 => _results.OrderByDescending(sortOrder),
                _ => throw new ArgumentException("There is no such item in the menu.")
            };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"How many lines to select? ({results.Count()} available)");
            Console.Write(">> ");
            var lineCount = int.Parse(Console.ReadLine());

            if (lineCount < 1)
            {
                throw new ArgumentException("Line count cannot be less than 1.");
            }

            return results.Take(lineCount);
        }

        private static Func<TestResult, IComparable> GetSortOrder()
        {
            Console.WriteLine();
            Console.WriteLine("Choose which column to sort by:");
            Console.WriteLine("1. Student name");
            Console.WriteLine("2. Test name");
            Console.WriteLine("3. Date");
            Console.WriteLine("4. Mark");
            Console.Write(">> ");

            return Console.ReadKey(intercept: false).Key switch
            {
                ConsoleKey.D1 => result => result.StudentName,
                ConsoleKey.D2 => result => result.TestName,
                ConsoleKey.D3 => result => result.Date,
                ConsoleKey.D4 => result => result.Mark,
                _ => throw new ArgumentException("There is no such item in the menu.")
            };
        }

        private static void ReadTestResults(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            using var fileStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), path), FileMode.Open);
            using var reader = new BinaryReader(fileStream);

            while (fileStream.Length > fileStream.Position)
            {
                var result = new TestResult
                (
                    studentName: reader.ReadString(),
                    testName: reader.ReadString(),
                    date: DateTime.Parse(reader.ReadString(), CultureInfo.InvariantCulture),
                    mark: reader.ReadInt32()
                );

                _results.Insert(result);
            }
        }

        private static void PrintFormattedResults(IEnumerable<TestResult> foramttedResults)
        {
            Console.WriteLine();
            Console.WriteLine($"{"Student",-20} {"Test",-25} {"Date",-20} {"Mark",5}");
            Console.WriteLine(new string('-', 75));

            foreach (var item in foramttedResults)
            {
                Console.WriteLine($"{item.StudentName,-20} {item.TestName,-25} {item.Date,-20} {item.Mark,5}");
            }
        }
    }
}
