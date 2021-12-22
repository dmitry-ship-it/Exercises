using NUnit.Framework;
using System;
using System.Reflection;

namespace MatrixApp.Tests
{
    public class MatrixTests
    {
        [Test]
        public void Ctor_ArrayNullOrEmpty_ThrowsArgumentNullException()
        {
            double[,] array = null;
            Assert.Throws<ArgumentNullException>(() => new Matrix(array));

            array = new double[0, 0];
            Assert.Throws<ArgumentNullException>(() => new Matrix(array));
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.ValidArrays))]
        public void Ctor_ConstructsFine(double[,] array)
            => Assert.DoesNotThrow(() => new Matrix(array));

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.ValidArrayPairsWithDimensionMismatch))]
        public void Add_DimensionMismatch_ThrowsArgumentException(double[,] lhs, double[,] rhs)
            => Assert.Throws<ArgumentException>(() => _ = new Matrix(lhs) + new Matrix(rhs));

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.ValidArrayPairsWithDimensionMismatch))]
        public void Subtract_DimensionMismatch_ThrowsArgumentException(double[,] lhs, double[,] rhs)
            => Assert.Throws<ArgumentException>(() => _ = new Matrix(lhs) - new Matrix(rhs));

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.ValidArrayPairsWithDimensionMismatchForMultiply))]
        public void Multiply_DimensionMismatch_ThrowsArgumentException(double[,] lhs, double[,] rhs)
            => Assert.Throws<ArgumentException>(() => _ = new Matrix(lhs) * new Matrix(rhs));

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.ValidArrayPairsWithSameSizeWithAddResult))]
        public void Add_ValidArrays(double[,] lhs, double[,] rhs, double[,] result)
        {
            var expected = new Matrix(result);
            var actual = new Matrix(lhs) + new Matrix(rhs);

            Assert.IsTrue(MatricesElementwiseEqual(expected, actual, delta: 1E-9));
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.ValidArrayPairsWithSameSizeWithSubtractResult))]
        public void Subtract_ValidArrays(double[,] lhs, double[,] rhs, double[,] result)
        {
            var expected = new Matrix(result);
            var actual = new Matrix(lhs) - new Matrix(rhs);

            Assert.IsTrue(MatricesElementwiseEqual(expected, actual, delta: 1E-9));
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.ValidArrayPairsWithSameSizeWithMultiplyResult))]
        public void Multiply_ValidArrays(double[,] lhs, double[,] rhs, double[,] result)
        {
            var expected = new Matrix(result);
            var actual = new Matrix(lhs) * new Matrix(rhs);

            Assert.IsTrue(MatricesElementwiseEqual(expected, actual, delta: 1E-9));
        }

        private static bool MatricesElementwiseEqual(Matrix lhs, Matrix rhs, double delta)
        {
            if (lhs is null || rhs is null)
            {
                return false;
            }

            var field = lhs.GetType().GetField("_elements", BindingFlags.NonPublic | BindingFlags.Instance);
            var lhsArray = field.GetValue(lhs) as double[,];
            var rhsArray = field.GetValue(rhs) as double[,];

            if (lhsArray.GetLength(0) != rhsArray.GetLength(0)
                || lhsArray.GetLength(1) != rhsArray.GetLength(1))
            {
                return false;
            }

            for (var i = 0; i < lhsArray.GetLength(0); i++)
            {
                for (var j = 0; j < lhsArray.GetLength(1); j++)
                {
                    if (Math.Abs(lhsArray[i, j] - rhsArray[i, j]) > delta)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
