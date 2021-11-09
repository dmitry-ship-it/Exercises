using System;

namespace RootFinder
{
    internal static class Root
    {
        public static double PreviousRoot { get; private set; }

        public static double Get(double number, double rootPower, double eps = 1E-10)
        {
            if (rootPower < 0)
            {
                throw new ArgumentException("Power of root cannot be less than 0.", nameof(rootPower));
            }

            if (number < 0)
            {
                return double.NaN;
            }

            // initial approximation
            var x0 = number / rootPower;

            // x1 = x0 - f(x0)/f'(x0)
            var x1 = x0 - (Math.Pow(x0, rootPower) - number) / (rootPower * Math.Pow(x0, rootPower - 1.0));
            
            // ! can return NaN if number or rootPower is too big
            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = x0 - (Math.Pow(x0, rootPower) - number) / (rootPower * Math.Pow(x0, rootPower - 1.0));
            }

            PreviousRoot = x1;
            
            return x1;
        }
        /// <summary>
        /// Returns difference between previous calculated root and <b>number</b>
        /// </summary>
        public static double CompareWithPrevious(double number)
        {
            return Math.Abs(number - PreviousRoot);
        }
    }
}