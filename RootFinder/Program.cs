using System;

namespace RootFinder
{
    internal static class Program
    {
        private const string ProgramName = "Root Finder v0.1";
        private static double _eps = 1E-5;
        private static double _number;
        private static double _rootPower;

        private static void Main()
        {
            Console.Title = ProgramName;
            PrintMenu();

            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        GetRoot();
                        PrintMenu();
                        break;
                    case ConsoleKey.D2:
                        ComparePreviousRootWithPow();
                        PrintMenu();
                        break;
                    case ConsoleKey.D3:
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
            Console.WriteLine("2. Compare previous found root with standard Pow");
            Console.WriteLine("3. Set new Epsilon (now: {0})", _eps);
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.Write(">>> ");
        }
        
        private static void GetRoot()
        {
            SetNumber();
            SetRootPower();

            try
            {
                Console.WriteLine($"Root of power {_rootPower} of {_number} is {Root.Get(_number, _rootPower, _eps)}");

                Console.WriteLine();
                Console.WriteLine("Compare with standard Pow? (y/n)");
                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    ComparePreviousRootWithPow();
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Try another number? (y/n)");
            if (Console.ReadKey(intercept: true).Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                GetRoot();
            }
        }

        private static void ComparePreviousRootWithPow()
        {
            if (Root.PreviousRoot is double.NaN)
            {
                Console.WriteLine("Previous root was NaN. Try to calculate another root.");
                Console.ReadKey(intercept: true);
                return;
            }

            var rootUsingPow = Math.Pow(_number, 1.0 / _rootPower);

            Console.WriteLine();
            Console.WriteLine($"Previous root was: {Root.PreviousRoot}");
            Console.WriteLine($"If we try to use Pow: {rootUsingPow}");
            Console.WriteLine($"Error: {Root.CompareWithPrevious(_number, _rootPower)}");
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
            double result;

            while (!double.TryParse(Console.ReadLine(), out result)
                   || checkNegativeNumbers && result < double.Epsilon)
            {
                Console.WriteLine("Invalid input. Please, try again:");
            }

            return result;
        }
    }
}