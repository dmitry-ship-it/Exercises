using System;

namespace Gcd
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(CustomGcd.GetGcdByEuclidean(-10234567, -234568989) == 97);
            Console.WriteLine(CustomGcd.GetGcdByStein(-10234567, -234568989) == 97);
        }
    }
}