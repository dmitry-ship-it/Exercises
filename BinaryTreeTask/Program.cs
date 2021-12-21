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

            for (var i = 0; i < 5000; i++)
            {
                tree.Insert(rand.Next(0, 201));
            }

            var timer = Stopwatch.StartNew();
            foreach (var item in tree)
            {
                Console.Write($"{item} ");
            }
            timer.Stop();
            Console.WriteLine();
            Console.WriteLine($"Using yield time = {TimeSpan.FromTicks(timer.ElapsedTicks).TotalMilliseconds}ms");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var timer2 = Stopwatch.StartNew();
            tree.DisplayTree();
            timer2.Stop();
            Console.WriteLine();
            Console.WriteLine($"Using recursion time = {TimeSpan.FromTicks(timer2.ElapsedTicks).TotalMilliseconds}ms");

            tree.Where(i => i == 0).ToList().ForEach(digit => Console.Write($"{digit} "));
        }
    }
}
