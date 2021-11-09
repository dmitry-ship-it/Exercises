using System;

namespace RootFinder
{
    internal static class Program
    {
        private const string ProgramName = "Root Finder v1.0";
        private static double _eps = 1E-10;
        private static double _number;
        private static double _rootPower;

        private static void Main()
        {
            Console.Title = ProgramName;
            PrintMenu();

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        GetRoot();
                        PrintMenu();
                        break;
                    case "2":
                        GetSquareRoot();
                        PrintMenu();
                        break;
                    case "3":
                        ComparePreviousRootWithPow();
                        PrintMenu();
                        break;
                    case "4":
                        SetEpsilon();
                        PrintMenu();
                        break;
                    default:
                        return;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine($" -- {ProgramName} -- ");
            Console.WriteLine("Options:");
            Console.WriteLine("1. Calculate n-power root");
            Console.WriteLine("2. Calculate square root");
            Console.WriteLine("3. Compare previous found root with standard Pow");
            Console.WriteLine("4. Set new Epsilon (now: {0})", _eps);
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write(">>> ");
        }

        private static void GetSquareRoot()
        {
            SetNumber();

            Console.WriteLine($"Root of power 2 of {_number} is {Root.Get(_number, 2, _eps)}");

            Console.WriteLine();
            Console.WriteLine("Compare with standard Pow? (y/n)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                ComparePreviousRootWithPow();
            }

            Console.WriteLine();
            Console.WriteLine("Try another combination? (y/n)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                GetSquareRoot();
            }
        }

        private static void GetRoot()
        {
            SetNumber();

            SetRootPower();

            Console.WriteLine($"Root of power {_rootPower} of {_number} is {Root.Get(_number, _rootPower, _eps)}");

            Console.WriteLine();
            Console.WriteLine("Compare with standard Pow? (y/n)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                ComparePreviousRootWithPow();
            }

            Console.WriteLine();
            Console.WriteLine("Try another number? (y/n)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                GetRoot();
            }
        }
        
        private static void ComparePreviousRootWithPow()
        {
            var rootUsingPow = Math.Pow(_number, 1.0 / _rootPower);

            Console.WriteLine($"Previous root was: {Root.PreviousRoot}");
            Console.WriteLine($"If we try to use Pow: {rootUsingPow}");
            Console.WriteLine($"Error: {Root.CompareWithPrevious(rootUsingPow)}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(intercept: true);
        }

        private static void SetEpsilon()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Epsilon:");
            _eps = ValidateAndGetInput(checkNegativeNumbers: true);
        }

        private static void SetNumber()
        {
            Console.WriteLine();
            Console.WriteLine("Enter number:");
            _number = ValidateAndGetInput();
        }
        
        private static void SetRootPower()
        {
            Console.WriteLine();
            Console.WriteLine("Enter root power:");
            _rootPower = ValidateAndGetInput(checkNegativeNumbers: true);
        }

        private static double ValidateAndGetInput(bool checkNegativeNumbers = false)
        {
            var input = Console.ReadLine() ?? "0";
            double result;

            while (!double.TryParse(input, out result)
                   || (checkNegativeNumbers && result < double.Epsilon))
            {
                Console.WriteLine("Invalid input. Please, try again:");
            }

            return result;
        }
    }
}