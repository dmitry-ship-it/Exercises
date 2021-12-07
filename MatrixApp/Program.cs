using System;

namespace MatrixApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Matrix matrix1 = new(3, 4, new double[,] { { 1, 2, 3,1 }, { 4, 5, 6,1 }, { 6, 7, 8,1 } });
            Matrix matrix2 = new(3, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 6, 7, 8 } });

            Console.WriteLine($"rows = {matrix1.Rows}, cols = {matrix1.Cols}");
            Console.WriteLine(matrix1 - matrix2);
        }
    }
}
