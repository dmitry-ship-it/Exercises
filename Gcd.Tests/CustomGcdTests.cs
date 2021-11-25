using NUnit.Framework;
using System;
using static Gcd.CustomGcd;

namespace Gcd.Tests
{
    public class CustomGcdTests
    {
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(2672, 5678, ExpectedResult = 334)]
        [TestCase(10927782, 6902514, ExpectedResult = 846)]
        [TestCase(1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(-1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-10234562, -7872334, ExpectedResult = 2)]
        [TestCase(1590771464, -1590771620, ExpectedResult = 4)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int GetGcdByEuclidean_WithTwoArguments(int a, int b) => GetGcdByEuclidean(a, b);

        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(5, 5, 5, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        [TestCase(100, -100, -50, ExpectedResult = 50)]
        [TestCase(1, 2, 3, ExpectedResult = 1)]
        [TestCase(-1, -2, -3, ExpectedResult = 1)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        [TestCase(0, 0, -1, ExpectedResult = 1)]
        public int GetGcdByEuclidean_WithThreeArguments(int a, int b, int c) => GetGcdByEuclidean(a, b, c);

        [TestCase(-10, 35, 90, 55, -105, ExpectedResult = 5)]
        [TestCase(1, 213124, -54654, -123124, 65765, 44444, -7, 1234567, int.MaxValue, ExpectedResult = 1)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(0, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 0, 1, ExpectedResult = 1)]
        [TestCase(12, 21, 91, 17, 0, int.MaxValue, ExpectedResult = 1)]
        [TestCase(3, -3, 3, ExpectedResult = 3)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        [TestCase(123413, 943578, 123413, 943578, 943578, int.MaxValue, ExpectedResult = 1)]
        public int GetGcdByEuclidean_WithParams(params int[] digits) => GetGcdByEuclidean(digits);

        [Test]
        public void GetGcdByEuclidean_WithAllZeroNumbers_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetGcdByEuclidean(0, 0, 0, 0, 0, 0, 0, 0, 0),
                "All numbers cannot be 0 at the same time.");

        [TestCase(int.MinValue, 0, 34, 78)]
        [TestCase(int.MinValue, -12, 234, 90)]
        [TestCase(13, int.MinValue, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue, int.MaxValue)]
        public void GetGcdByEuclidean_WithOneOrMoreMinIntegers_ThrowArgumentOutOfRangeException(params int[] digits) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GetGcdByEuclidean(digits),
                $"Number cannot be {int.MinValue}.");

        [Test]
        public void GetGcdByEuclidean_WithNullArray_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetGcdByEuclidean(null), "Array is null.");
            Assert.Throws<ArgumentNullException>(() => GetGcdByEuclidean(Array.Empty<int>()), "Array is empty.");
        }

        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(12, 60, ExpectedResult = 12)]
        [TestCase(2672, 5678, ExpectedResult = 334)]
        [TestCase(10927782, 6902514, ExpectedResult = 846)]
        [TestCase(1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-7, -7, ExpectedResult = 7)]
        [TestCase(18, 0, ExpectedResult = 18)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(-1590771464, 1590771620, ExpectedResult = 4)]
        [TestCase(-10234562, -7872334, ExpectedResult = 2)]
        [TestCase(1590771464, -1590771620, ExpectedResult = 4)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int GetGcdByStein_WithTwoArguments(int a, int b) => GetGcdByStein(a, b);

        [Test]
        public void GetGcdByStein_WithTwoZeroNumbers_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => GetGcdByStein(0, 0), "All numbers cannot be 0 at the same time.");

        [TestCase(int.MinValue, 0)]
        [TestCase(0, int.MinValue)]
        [TestCase(int.MinValue, -12)]
        [TestCase(13, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue)]
        public void GetGcdByStein_WithOneOrTwoMinIntegers_ThrowArgumentOutOfRangeException(int a, int b) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GetGcdByStein(a, b), $"Number cannot be {int.MinValue}.");
    }
}