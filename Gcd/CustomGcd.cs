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

            // check for special values
            var returnValue = DetectSpecialValues(digits);
            if (returnValue is not null)
            {
                return (int) returnValue;
            }

            digits = EraseZerosAndApplyAbs(digits);

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
            // check for special values
            var returnValue = DetectSpecialValues(first, second);
            if (returnValue is not null)
            {
                return (int) returnValue;
            }

            // this method requires positive numbers
            first = CustomAbs(first);
            second = CustomAbs(second);

            var factor = 1;

            // main loop
            while (first != 0 && second != 0)
            {
                switch (first, second)
                {
                    case var (a, b) when a % 2 == 0 && b % 2 == 0:
                        factor <<= 1;
                        first >>= 1;
                        second >>= 1;
                        break;
                    case var (a, _) when a % 2 == 0:
                        first >>= 1;
                        break;
                    case var (_, b) when b % 2 == 0:
                        second >>= 1;
                        break;
                    case var (a, b) when a < b:
                        second = (second - first) >> 1;
                        break;
                    default: // when a >= b
                        first = (first - second) >> 1;
                        break;
                }
            }

            // one of the result values will be 0, the other - some positive value
            return Math.Max(factor * first, factor * second);
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
        /// <param name="digits">Array of numbers.</param>
        /// <returns><i>If returns non <b>null</b> value, then the GCD method should return it.</i></returns>
        /// <exception cref="ArgumentNullException">Array of numbers is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if one of special values is int.MinValue.</exception>
        /// <exception cref="ArgumentException">Throws if all numbers are 0.</exception>
        private static int? DetectSpecialValues(params int[] digits)
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

            if (IsMembersEqual(digits))
            {
                if (digits[0] == 0)
                {
                    throw new ArgumentException("All digits are 0 at the same time.");
                }

                // if all values are the same then return it
                return CustomAbs(digits[0]);
            }

            // if one of values is int.MaxValue then return 1
            return digits.Contains(int.MaxValue) ? 1 : null;
        }

        private static bool IsMembersEqual(int[] digits)
        {
            if (digits is null || digits.Length < 1)
            {
                throw new ArgumentNullException(nameof(digits));
            }

            return digits.All(i => i == digits[0]);
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

        private static int CustomAbs(int value)
        {
            return value switch
            {
                >= 0 => value,
                int.MinValue => throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be int.MinValue."),
                _ => -value
            };
        }

        private static int[] EraseZerosAndApplyAbs(int[] digits)
        {
            var valueToRemoveCount = digits.Count(digit => digit == 0);

            var result = new int[digits.Length - valueToRemoveCount];
            var resultIterator = 0;

            foreach (var digit in digits)
            {
                if (digit != 0)
                {
                    result[resultIterator] = CustomAbs(digit);
                    resultIterator++;
                }
            }

            return result;
        }
    }
}