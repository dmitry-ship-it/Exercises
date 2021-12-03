using System;

namespace TriangleApp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle(11, 12, 13);
            Console.WriteLine(triangle.GetArea());
        }
    }
}
