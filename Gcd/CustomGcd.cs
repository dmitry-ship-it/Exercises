using System;
using System.Diagnostics;
using System.Linq;

namespace Gcd
{
    public static class CustomGcd
    {
        public static int GetGcdByEuclidean(params int[] digits)
        {
            if (digits is null || digits.Length < 1)
            {
                throw new ArgumentNullException(nameof(digits));
            }

            if (digits.Count(item => item == 0) == digits.Length)
            {
                throw new ArgumentException("All digits is 0.", nameof(digits));
            }

            // erase all zeros
            digits = digits.Where(item => item != 0).ToArray();

            for (var i = 0; i < digits.Length; i++)
            {
                switch (digits[i])
                {
                    case int.MinValue:
                        throw new ArgumentOutOfRangeException(nameof(digits),
                            "One of digits contains invalid value (int.MinValue).");
                    case int.MaxValue:
                    case -int.MaxValue:
                    case 1:
                        return 1;
                    case < 0:
                        digits[i] = -digits[i];
                        break;
                }
            }

            while (!IsMembersEqual(digits))
            {
                SubtractMin(digits);
            }

            return digits[0];
        }

        public static int GetGcdByEuclidean(out long elapsedTicks, params int[] digits)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = GetGcdByEuclidean(digits);
            stopwatch.Stop();

            elapsedTicks = stopwatch.ElapsedTicks;

            return result;
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

        public static int GetGcdByStein(int first, int second)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("All numbers are 0 at the same time.");
            }

            if (first == int.MinValue || second == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(first),
                    "One or two numbers are invalid (int.MinValue).");
            }

            if (first == 1 || second == 1 || first == int.MaxValue || second == int.MaxValue)
            {
                return 1;
            }

            if (first < 0)
            {
                first = -first;
            }

            if (second < 0)
            {
                second = -second;
            }

            var factor = 1;

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
                else
                {
                    first = (first - second) >> 1;
                }
            }

            return first == 0
                ? second * factor
                : first * factor;
        }

        public static int GetGcdByStein(out long elapsedTicks, int first, int second)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = GetGcdByStein(first, second);
            stopwatch.Stop();

            elapsedTicks = stopwatch.ElapsedTicks;

            return result;
        }
    }
}