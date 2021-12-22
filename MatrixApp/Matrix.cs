using System;
using System.Text;

namespace MatrixApp
{
    public class Matrix
    {
        private readonly double[,] _elements;

        private int Rows => _elements.GetLength(0);
        private int Cols => _elements.GetLength(1);

        public double this[int i, int j]
        {
            get => _elements[i, j];
        }

        public Matrix(double[,] elements)
        {
            if (elements is null || elements.Length < 1)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            _elements = elements.Clone() as double[,];
        }

        public static Matrix Add(Matrix lhs, Matrix rhs)
        {
            return MatricesOperation(lhs, rhs, Operation.Add);
        }

        public static Matrix Subtract(Matrix lhs, Matrix rhs)
        {
            return MatricesOperation(lhs, rhs, Operation.Subtract);
        }

        public static Matrix operator +(Matrix lhs, Matrix rhs)
        {
            return Add(lhs, rhs);
        }

        public static Matrix operator -(Matrix lhs, Matrix rhs)
        {
            return Subtract(lhs, rhs);
        }

        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            if (lhs.Cols != rhs.Rows)
            {
                throw new ArgumentException(
                    "The number of columns in the first matrix does not match the number of rows in the second matrix.");
            }

            var result = new double[lhs.Rows, rhs.Cols];

            for (var i = 0; i < lhs.Rows; i++)
            {
                for (var j = 0; j < rhs.Cols; j++)
                {
                    result[i, j] = MultiplyMatricesCell(lhs, rhs, i, j);
                }
            }

            return new Matrix(result);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (var row = 0; row < Rows; row++)
            {
                AppendRow(result, row);
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        private void AppendRow(StringBuilder result, int row)
        {
            for (var j = 0; j < Cols; j++)
            {
                result.AppendFormat("{0,-8} ", _elements[row, j]);
            }
        }

        private static double MultiplyMatricesCell(Matrix lhs, Matrix rhs, int row, int col)
        {
            var cell = 0d;

            for (var i = 0; i < rhs.Rows; i++)
            {
                cell += lhs[row, i] * rhs[i, col];
            }

            return cell;
        }

        private enum Operation
        {
            Add = 1,
            Subtract = -1
        }

        private static Matrix MatricesOperation(Matrix lhs, Matrix rhs, Operation operation)
        {
            if (lhs.Rows != rhs.Rows
                || lhs.Cols != rhs.Cols)
            {
                throw new ArgumentException("Matrix dimensions do not match.");
            }

            var result = new double[lhs.Rows, rhs.Cols];

            for (var i = 0; i < lhs.Rows; i++)
            {
                for (var j = 0; j < lhs.Cols; j++)
                {
                    result[i, j] = lhs[i, j] + ((int)operation * rhs[i, j]);
                }
            }

            return new Matrix(result);
        }
    }
}