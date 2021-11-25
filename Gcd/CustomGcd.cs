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

            // find index of min value
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