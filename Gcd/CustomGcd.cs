using System;
using System.Diagnostics;
using System.Linq;

namespace Gcd
{
    public static class CustomGcd
    {
        public static int GetByEuclidean(params int[] digits)
        {
            if (digits is null || digits.Length < 1)
            {
                throw new ArgumentNullException(nameof(digits));
            }

            // validate all digits
            if (IsContainsSpecialValues(out var returnValue, digits) && returnValue is not null)
            {
                return (int) returnValue;
            }

            // erase all zeros and apply Math.Abs on the remaining values
            digits = digits.Where(item => item != 0).Select(Math.Abs).ToArray();

            // main loop
            while (!IsMembersEqual(digits))
            {
                SubtractMin(digits);
            }

            return digits[0];
        }

        public static int GetByEuclidean(out long elapsedTicks, params int[] digits)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = GetByEuclidean(digits);
            stopwatch.Stop();

            elapsedTicks = stopwatch.ElapsedTicks;

            return result;
        }

        public static int GetByStein(int first, int second)
        {
            if (IsContainsSpecialValues(out var returnValue, first, second) && returnValue is not null)
            {
                return (int) returnValue;
            }

            // this method requires positive numbers
            if (first < 0)
            {
                first = -first;
            }

            if (second < 0)
            {
                second = -second;
            }

            var factor = 1;

            // main loop
            while (first != 0 && second != 0)
            {
                if (first % 2 == 0 && second % 2 == 0)
                {
                    factor <<= 1;
                    first >>= 1;
                    second >>= 1;
                }
                else if (first % 2 == 0)
                {
                    first >>= 1;
                }
                else if (second % 2 == 0)
                {
                    second >>= 1;
                }
                else if (first < second)
                {
                    second = (second - first) >> 1;
                }
                else // (first > second)
                {
                    first = (first - second) >> 1;
                }
            }

            return first == 0
                ? second * factor
                : first * factor;
        }

        public static int GetByStein(out long elapsedTicks, int first, int second)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = GetByStein(first, second);
            stopwatch.Stop();

            elapsedTicks = stopwatch.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// Method to check for special values - <b>0, 1, int.MinValue, int.MaxValue</b>.
        /// </summary>
        /// <param name="returnValue"><b><i>If this value is set to a non null value, then the GCD method should return it.</i></b></param>
        /// <param name="digits">Array of numbers.</param>
        /// <returns><b>true</b> if array contains special value(s), <b>false</b> if not.</returns>
        /// <exception cref="ArgumentNullException">Array of numbers is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if one of special values is int.MinValue.</exception>
        /// <exception cref="ArgumentException">Throws if all numbers are 0.</exception>
        private static bool IsContainsSpecialValues(out int? returnValue, params int[] digits)
        {
            if (digits is null || digits.Length < 1)
            {
                throw new ArgumentNullException(nameof(digits));
            }

            if (digits.Contains(int.MinValue))
            {
                throw new ArgumentOutOfRangeException(nameof(digits),
                    "One of digits contains invalid value (int.MinValue).");
            }

            returnValue = null;

            if (IsMembersEqual(digits))
            {
                if (digits[0] == 0)
                {
                    throw new ArgumentException("All digits are 0 at the same time.");
                }

                returnValue = Math.Abs(digits[0]) == int.MaxValue
                    ? int.MaxValue
                    : Math.Abs(digits[0]);

                return true;
            }

            // if one of values is int.MaxValue
            if (digits.Contains(int.MaxValue))
            {
                returnValue = 1;
                return true;
            }

            return false;
        }

        private static bool IsMembersEqual(int[] digits)
        {
            for (var i = 1; i < digits.Length; i++)
            {
                if (digits[i - 1] != digits[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static void SubtractMin(int[] array)
        {
            var min = array.Min();

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] > min)
                {
                    array[i] -= min;
                }
            }
        }
    }
}