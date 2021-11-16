﻿using System;

namespace RootFinder
{
    internal static class Root
    {
        public static double PreviousRoot { get; private set; }

        /// <summary>
        /// Method calculates the root of the number.
        /// </summary>
        /// <param name="number">Number whose root you want to find</param>
        /// <param name="rootPower">Root power/degree, or in standard power notation (number)^(1/rootPower).</param>
        /// <param name="eps">Maximum allowed error.</param>
        /// <returns>Root of <b>number</b></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="OverflowException"></exception>
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
            var currentValue = number / rootPower;

            // nextValue = currentValue - f(currentValue)/f'(currentValue),
            // where f(currentValue) = currentValue^rootPower - number
            var nextValue = currentValue - (Math.Pow(currentValue, rootPower) - number) / (rootPower * Math.Pow(currentValue, rootPower - 1.0));

            // ! can return NaN if number or rootPower is too big
            while (Math.Abs(nextValue - currentValue) > eps)
            {
                currentValue = nextValue;
                nextValue = currentValue - (Math.Pow(currentValue, rootPower) - number) / (rootPower * Math.Pow(currentValue, rootPower - 1.0));
            }

            PreviousRoot = nextValue;

            return nextValue is double.NaN 
                ? throw new OverflowException("This method of root calculation can't evaluate this input.")
                : nextValue;
        }

        /// <summary>
        /// Returns difference between previous calculated root and result of standard Math.Pow method.
        /// </summary>
        public static double CompareWithPrevious(double number, double rootPower)
        {
            var powRoot = Math.Pow(number, 1.0 / rootPower);
            return Math.Abs(powRoot - PreviousRoot);
        }
    }
}