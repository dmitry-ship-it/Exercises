using System;
using System.Diagnostics;
using System.Linq;

namespace BinaryTreeTask
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var rand = new Random();

            var tree = new BinaryTree<int>();

            for (var i = 0; i < 10000; i++)
            {
                tree.Insert(rand.Next(0, 201));
            }

            var fullTime = 0L;
            var N = 1000;

            Stopwatch timer = null;
            for (var i = 0; i < N; i++)
            {
                timer = Stopwatch.StartNew();
                foreach (var item in tree)
                {
                    Console.Write($"{item} ");
                }
                timer.Stop();
                fullTime += timer.ElapsedTicks;
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var fullTime2 = 0L;
            Stopwatch timer2 = null;
            for (var i = 0; i < N; i++)
            {
                timer2 = Stopwatch.StartNew();
                tree.DisplayTree(item => Console.Write($"{item} "));
                timer2.Stop();
                fullTime2 += timer2.ElapsedTicks;
            }

            Console.WriteLine();
            Console.WriteLine($"Using yield time = {TimeSpan.FromTicks(fullTime).TotalMilliseconds / N}ms");

            Console.WriteLine();
            Console.WriteLine($"Using recursion time = {TimeSpan.FromTicks(fullTime2).TotalMilliseconds / N}ms");

            tree.Where(i => i == 0).ToList().ForEach(digit => Console.Write($"{digit} "));
        }
    }
}
