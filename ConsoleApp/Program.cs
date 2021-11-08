using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args is null || args.Length < 1 || args[0].Length < 1)
            {
                // using console input
                List<string> result = GetCoordinates();
                PrintCoordinates(result);
            }
            else
            {
                // using file
                var path = Path.Combine(Directory.GetCurrentDirectory(), args[0]);

                try
                {
                    var input = File.ReadAllLines(path);
                    File.WriteAllLines(path, FormatCoordinates(input));
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(intercept: true);
                }
            }
        }

        private static void PrintCoordinates(List<string> result)
        {
            Console.WriteLine();
            foreach (var coordinate in result)
            {
                Console.WriteLine(coordinate);
            }
        }

        private static List<string> GetCoordinates()
        {
            var result = new List<string>();
            
            Console.WriteLine("Enter valid coordinates (example: 4.5,7.8):");

            var currentString = Console.ReadLine()?.Trim();
            while (!string.IsNullOrWhiteSpace(currentString))
            {
                result.Add(currentString.FormatCoordinate());
                currentString = Console.ReadLine()?.Trim();
            }

            return result;
        }

        // for array of coordinates
        private static string[] FormatCoordinates(params string[] coordinates)
        {
            if (coordinates is null)
            {
                throw new ArgumentNullException(nameof(coordinates));
            }

            for (var i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = coordinates[i].Trim().FormatCoordinate();
            }

            return coordinates.Where(coordinate => coordinate != null).ToArray();
        }

        // for single coordinate
        private static string FormatCoordinate(this string coordinate)
        {
            if (!coordinate.IsValidCoordinate())
            {
                return null;
            }
            
            var numbers = coordinate.Split(',', StringSplitOptions.TrimEntries);
            
            var x = double.Parse(numbers[0], CultureInfo.InvariantCulture);
            var y = double.Parse(numbers[1], CultureInfo.InvariantCulture);
            
            return $"X: {x,-10:#.0000} Y: {y:#.0000}"
                .Replace('.', ',');
        }

        private static bool IsValidCoordinate(this string s)
        {
            var regex = new Regex(@"^\s*\d+\.\d+\s*\,\s*\d+\.\d+\s*$");
            return regex.IsMatch(s);
        }
    }
}
