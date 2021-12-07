using System;
using System.Text;

namespace MatrixApp
{
    public class Matrix
    {
        private readonly double[,] _elements;

        public int Rows { get => _elements.GetLength(0); }
        public int Cols { get => _elements.GetLength(1); }

        public Matrix(int rows, int cols)
        {
            if (rows <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows), "Rows count cannot be less or equals zero.");
            }

            if (cols <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cols), "Cols count cannot be less or equals zero.");
            }

            _elements = new double[rows, cols];
        }

        public Matrix(int rows, int cols, double[,] elements) : this(rows, cols)
        {
            if (elements is null || elements.Length < 1)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            if (elements.Length / rows != cols)
            {
                throw new ArgumentException("Цrong number of elements.", nameof(elements));
            }

            _elements = elements;
        }

        public double this[int i, int j]
        {
            get => _elements[i, j];
            set => _elements[i, j] = value;
        }

        public static Matrix Add(Matrix lhs, Matrix rhs)
        {
            if (!IsEqualDimensions(lhs, rhs))
            {
                throw new ArgumentException("Matrix sizes do not match.");
            }

            var result = new Matrix(lhs.Rows, rhs.Cols);

            for (var i = 0; i < lhs.Rows; i++)
            {
                for (var j = 0; j < lhs.Cols; j++)
                {
                    result[i, j] = lhs[i, j] + rhs[i, j];
                }
            }

            return result;
        }

        public static Matrix operator +(Matrix lhs, Matrix rhs)
        {
            return Add(lhs, rhs);
        }

        public static Matrix Subtract(Matrix lhs, Matrix rhs)
        {
            if (!IsEqualDimensions(lhs, rhs))
            {
                throw new ArgumentException("Matrix sizes do not match.");
            }

            var result = new Matrix(lhs.Rows, rhs.Rows);

            for (var i = 0; i < lhs.Rows; i++)
            {
                for (var j = 0; j < lhs.Cols; j++)
                {
                    result[i, j] = lhs[i, j] - rhs[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix lhs, Matrix rhs)
        {
            return Subtract(lhs, rhs);
        }

        public static Matrix Multiply(Matrix lhs, Matrix rhs)
        {
            //TODO: implement matrix multiply
            throw new NotImplementedException();
        }

        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            return Multiply(lhs, rhs);
        }

        public static bool IsEqualDimensions(Matrix lhs, Matrix rhs)
        {
            return lhs.Rows == rhs.Rows
                && lhs.Cols == rhs.Cols;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    result.AppendFormat("{0,-8}", _elements[i, j]);
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
