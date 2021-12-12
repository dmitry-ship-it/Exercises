using System;

namespace MatrixApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var arr1 = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 6, 7, 8 } };

            Matrix matrix1 = new(arr1);
            Matrix matrix2 = new(arr1);

            Console.WriteLine($"rows = {matrix1.Rows}, cols = {matrix1.Cols}");
            Console.WriteLine(matrix1 - matrix2);

            matrix1[0, 0] = 33;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(matrix1);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(matrix2);
        }
    }
}
